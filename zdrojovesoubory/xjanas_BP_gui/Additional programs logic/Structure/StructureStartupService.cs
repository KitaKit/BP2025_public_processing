using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public sealed class StructureStartupService
    {
        public record ProgressReport(int CompletedJobs, int TotalJobs, TimeSpan Elapsed, TimeSpan Remaining, int LastK, int LastIter)
        {
            public double Fraction => CompletedJobs / (double)TotalJobs;
        }

        private int _completedJobs;
        private int _totalJobs;
        private Stopwatch _swGlobal;

        private readonly int _maxSamples = 20;
        private readonly Queue<(DateTime Timestamp, int Jobs)> _samples = new();
        private double _smoothedSpeed = -1;    

        private System.Timers.Timer _progressTimer;

        private IProgress<ProgressReport>? _progress;

        private int _lastCompletedK;
        private int _lastCompletedIter;

        private int _kStart;
        private int _kEnd;
        private int _iterations;
        private string _outputFolder;

        public StructureStartupService(int kStart, int kEnd, int iterations, string outputFolder)
        {
            _kStart = kStart;
            _kEnd = kEnd;
            _iterations = iterations;
            _outputFolder = outputFolder;
        }

        private static readonly object _consoleLock = new();

        private static readonly string _exeFilePath = Path.Combine(DirectoriesManager.RootPath, "structure.exe");

        record RunConfig(int K, int Iteration, string OutFile);

        public async Task RunAsync(IProgress<ProgressReport> progress, Logger logger, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var swGlobal = Stopwatch.StartNew();

            _progress = progress ?? throw new ArgumentNullException(nameof(progress));

            var runConfid =
                from k in Enumerable.Range(_kStart, _kEnd - _kStart + 1)
                from iter in Enumerable.Range(1, _iterations)
                select new RunConfig
                (
                    k,
                    iter,
                    Path.Combine(_outputFolder, $"K{k}-i{iter}")
                );

            _totalJobs = runConfid.Count();
            _completedJobs = 0;
            _swGlobal = Stopwatch.StartNew();

            lock (_samples) { _samples.Clear(); }

            _progressTimer = new System.Timers.Timer(500);
            _progressTimer.Elapsed += (_, __) => ReportSlidingProgress();

            logger.Info("Starting Structure...");
            _progressTimer.Start();

            ReportSlidingProgress();

            try
            {
                using var semaphore = new SemaphoreSlim(ProjectInformationModel.Instance.Cores);

                var tasks = runConfid.Select(job => RunSingleWrappedAsync(job, semaphore, logger, token));

                await Task.WhenAll(tasks);

                ReportSlidingProgress();
            }
            finally
            {
                if (_progressTimer != null)
                {
                    _progressTimer.Stop();
                    _progressTimer.Dispose();
                    _progressTimer = null;
                }
            }

            if (!token.IsCancellationRequested)
            {
                _progress?.Report(new ProgressReport(_totalJobs, _totalJobs,
                                                     _swGlobal.Elapsed, TimeSpan.Zero,
                                                     _lastCompletedK, _lastCompletedIter));
                _swGlobal.Stop();
            }

            _swGlobal.Stop();

            swGlobal.Stop();
        }

        private async Task RunSingleWrappedAsync(RunConfig job, SemaphoreSlim semaphore, Logger logger, CancellationToken token)
        {
            await semaphore.WaitAsync(token);
            try
            {
                await RunSingleAsync(job, logger, token);

                int done = Interlocked.Increment(ref _completedJobs);

                double elapsedSec = _swGlobal.Elapsed.TotalSeconds;

                Interlocked.Exchange(ref _lastCompletedK, job.K);
                Interlocked.Exchange(ref _lastCompletedIter, job.Iteration);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            finally
            {
                semaphore.Release();
            }
        }


        private async Task RunSingleAsync(RunConfig job, Logger logger, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();

            string arguments = $"-K {job.K} -m mainparams -e extraparams -o {job.OutFile}";
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string structureFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First());
            string parametersSetFolder = Path.Combine(structureFolder, StructureConfigurationParametersManager.CurrentParameterSet.SetName);


            var psi = new ProcessStartInfo
            {
                FileName = _exeFilePath,
                Arguments = arguments,
                WorkingDirectory = parametersSetFolder,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };


            using var process = new Process { StartInfo = psi, EnableRaisingEvents = true };

            using var reg = token.Register(() =>
            {
                try
                {
                    if (!process.HasExited)
                        process.Kill(entireProcessTree: true);
                }
                catch { }
            });


            process.OutputDataReceived += (_, e) =>
            {
                if (e.Data is not null)
                {
                    logger.Info($"[K={job.K}, iter={job.Iteration}] {e.Data}");
                }
            };
            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data is not null)
                {
                    logger.Error($"[K={job.K}, iter={job.Iteration} ERROR] {e.Data}");
                }
            };

            process.Start();


            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync(token);

            sw.Stop();

            if (process.ExitCode != 0)
            {
                logger.Error($"STRUCTURE exited with code {process.ExitCode} (K={job.K}, iter={job.Iteration})");
            }
        }

        private void ReportSlidingProgress()
        {
            if (_completedJobs >= _totalJobs)
            {
                _progressTimer.Stop();
                return;
            }

            var now = DateTime.UtcNow;
            int done = _completedJobs;

            double maturity = done / (double)_totalJobs;  
            int minSamples = (int)(maturity * _maxSamples);

            double alpha = 0.1 * (1 - maturity) + 0.02 * maturity;

            List<(DateTime Timestamp, int Jobs)> snapshot;
            lock (_samples)
            {
                _samples.Enqueue((now, done));
                while (_samples.Count > _maxSamples)
                    _samples.Dequeue();

                snapshot = _samples.ToList();
            }

            if (done == 0)
            {
                _progress?.Report(new ProgressReport(done, _totalJobs, _swGlobal.Elapsed, TimeSpan.Zero, _lastCompletedK, _lastCompletedIter));
                return;
            }

            double fraction = done / (double)_totalJobs;
            var elapsed = _swGlobal.Elapsed;
            TimeSpan etaLinear = TimeSpan.Zero;
            if (fraction > 0)
            {
                long totalTicks = (long)(elapsed.Ticks / fraction);
                etaLinear = TimeSpan.FromTicks(totalTicks - elapsed.Ticks);
            }

            if (snapshot.Count < Math.Max(2, minSamples))
            {
                _progress?.Report(new ProgressReport(done, _totalJobs, elapsed, etaLinear, _lastCompletedK, _lastCompletedIter));
                return;
            }

            var (t0, j0) = snapshot[0];
            var (t1, j1) = snapshot[^1];
            double dt = (t1 - t0).TotalSeconds;
            double dj = j1 - j0;
            if (dt <= 0 || dj <= 0)
            {
                _progress?.Report(new ProgressReport(done, _totalJobs, elapsed, etaLinear, _lastCompletedK, _lastCompletedIter));
                return;
            }

            double instantSpeed = dj / dt;        // jobs/sec

            if (_smoothedSpeed < 0)
                _smoothedSpeed = instantSpeed; 
            else
                _smoothedSpeed = alpha * instantSpeed + (1 - alpha) * _smoothedSpeed;

            int remainingJobs = _totalJobs - done;
            TimeSpan etaSmooth = TimeSpan.FromSeconds(remainingJobs / _smoothedSpeed);

            var combinedEta = TimeSpan.FromTicks((etaLinear.Ticks + etaSmooth.Ticks) / 2);

            _progress?.Report(new ProgressReport(done, _totalJobs, elapsed, combinedEta, _lastCompletedK, _lastCompletedIter));
        }
    }
}