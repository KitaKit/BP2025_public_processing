using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using GenotypeApp.Additional_programs_logic.CLUMPP;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal sealed class DistructStartupService
    {
        public record DistructProgressReport(
            int CompletedJobs,
            int TotalJobs,       
            TimeSpan Elapsed,    
            TimeSpan Remaining,  
            int LastK            
        );

        private int _totalJobs;
        private int _completedJobs;
        private int _lastCompletedK;
        private Stopwatch _swGlobal;
        private System.Timers.Timer _progressTimer;
        private IProgress<DistructProgressReport>? _progress;

        private readonly int _maxSamples = 20;
        private readonly Queue<(DateTime T, int Done)> _samples = new();
        private double _smoothedSpeed = -1;

        private static readonly DistructStartupService _instance = new DistructStartupService();
        public static DistructStartupService Instance => _instance;


        private string _exeFilePath = Path.Combine(DirectoriesManager.RootPath, "distructWindows1.1.exe");

        record RunConfig(int K, string InputFilePopQ, string InputFileIndQ, string OutFile);

        public async Task RunAsync(IProgress<DistructProgressReport> progress, int kStart, int kEnd, Logger logger, bool tmp = false, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            _progress = progress ?? throw new ArgumentNullException(nameof(progress));
            _totalJobs = kEnd - kStart + 1;
            _completedJobs = 0;
            _lastCompletedK = -1;
            _swGlobal = Stopwatch.StartNew();

            lock (_samples) { _samples.Clear(); }
            _progressTimer = new System.Timers.Timer(500);
            _progressTimer.Elapsed += (_, __) => ReportSlidingProgress();
            _progressTimer.Start();

            ReportSlidingProgress();

            var swGlobal = Stopwatch.StartNew();

            var runConfid =
                from k in Enumerable.Range(kStart, kEnd - kStart + 1)
                select new RunConfig
                (
                    k,
                    Path.Combine("..", "..", "CLUMPP", CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName, "Results", "K" + k + ".popq"),
                    Path.Combine("..", "..", "CLUMPP", CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName, "Results", "K" + k + ".indq"),
                    tmp ? Path.Combine("tmp", "K" + k + "_tmp" + ".ps") : Path.Combine("Results", "K" + k + ".ps")
                );

            try
            {
                using var semaphore = new SemaphoreSlim(ProjectInformationModel.Instance.Cores);
                var tasks = runConfid.Select(job => RunSingleWrappedAsync(job, semaphore, logger, token, tmp));
                await Task.WhenAll(tasks);

                ReportSlidingProgress();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            finally
            {
                if (_progressTimer != null)
                {
                    _progressTimer.Stop();
                    _progressTimer.Dispose();
                    _progressTimer = null;
                }
                _swGlobal?.Stop();
            }

            if (!token.IsCancellationRequested)
            {
                _progress?.Report(new DistructProgressReport(
                    _totalJobs, _totalJobs,
                    _swGlobal.Elapsed, TimeSpan.Zero,
                    _lastCompletedK));
            }

            swGlobal.Stop();
        }

        private async Task RunSingleWrappedAsync(RunConfig job, SemaphoreSlim semaphore, Logger logger, CancellationToken token, bool tmp = false)
        {
            await semaphore.WaitAsync(token);
            try
            {
                await RunSingleAsync(job, logger, token, tmp);

                int done = Interlocked.Increment(ref _completedJobs);
                Interlocked.Exchange(ref _lastCompletedK, job.K);

                var now = DateTime.UtcNow;
                lock (_samples)
                {
                    _samples.Enqueue((now, done));
                    if (_samples.Count > _maxSamples) _samples.Dequeue();
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task RunSingleAsync(RunConfig job, Logger logger, CancellationToken token, bool tmp = false)
        {
            token.ThrowIfCancellationRequested();

            var sw = Stopwatch.StartNew();

            string arguments = 
                $"-d {(tmp ? Path.Combine("tmp", DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "_tmp") : DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile)}" +
                $" -K {job.K}" +
                $" -p {job.InputFilePopQ}" +
                $" -i {job.InputFileIndQ}" +
                $" -c {DistructParametersModel.Instance.INFILE_CLUST_PERM}"+
                $" -o {job.OutFile}";

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
            string setFolder = Path.Combine(distructFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);


            var psi = new ProcessStartInfo
            {
                FileName = _exeFilePath,
                Arguments = arguments,
                WorkingDirectory = setFolder,
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
                    logger.Info($"[K={job.K}, {e.Data}");
                }
            };
            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data is not null)
                {
                    logger.Error($"[K={job.K}, ERROR] {e.Data}");
                }
            };

            logger.Info("Starting Distruct...");
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync(token);

            if (token.IsCancellationRequested) return;

            sw.Stop();

            if (process.ExitCode != 0)
            {
                logger.Error($"Distruct exited with code {process.ExitCode} (K={job.K})");
                throw new ExternalException();
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

            List<(DateTime Time, int Done)> snapshot;
            lock (_samples)
            {
                _samples.Enqueue((now, done));
                while (_samples.Count > _maxSamples)
                    _samples.Dequeue();
                snapshot = _samples.ToList();
            }

            if (done == 0)
            {
                _progress?.Report(new DistructProgressReport(
                    done, _totalJobs, _swGlobal.Elapsed, TimeSpan.Zero, _lastCompletedK));
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
                _progress?.Report(new DistructProgressReport(
                    done, _totalJobs, elapsed, etaLinear, _lastCompletedK));
                return;
            }

            var (t0, d0) = snapshot[0];
            var (t1, d1) = snapshot[^1];
            double dt = (t1 - t0).TotalSeconds;
            double dd = d1 - d0;
            if (dt <= 0 || dd <= 0)
            {
                _progress?.Report(new DistructProgressReport(
                    done, _totalJobs, elapsed, etaLinear, _lastCompletedK));
                return;
            }

            double instantSpeed = dd / dt;
            if (_smoothedSpeed < 0) _smoothedSpeed = instantSpeed;
            else _smoothedSpeed = alpha * instantSpeed + (1 - alpha) * _smoothedSpeed;

            int remaining = _totalJobs - done;
            TimeSpan etaSmooth = TimeSpan.FromSeconds(remaining / _smoothedSpeed);

            var combinedEta = TimeSpan.FromTicks((etaLinear.Ticks + etaSmooth.Ticks) / 2);

 
            _progress?.Report(new DistructProgressReport(
                done, _totalJobs, elapsed, combinedEta, _lastCompletedK));
        }
    }
}