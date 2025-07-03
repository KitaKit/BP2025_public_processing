using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GenotypeApp.Additional_programs_logic.Structure;

namespace GenotypeApp.Additional_programs_logic.Structure_Harvester
{
    internal sealed class StructureHarvesterStartupService
    {
        public record HarvesterProgressReport(
            double Fraction,   
            TimeSpan Elapsed,  
            TimeSpan Remaining  
        );

        private int _totalFiles;

        private readonly string _outputFolder =
            StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath;

        private readonly int _maxSamples = 20;
        private readonly Queue<(DateTime Timestamp, double Fraction)> _samples = new();

        private double _smoothedSpeed = -1;


        private System.Timers.Timer _progressTimer;
        private Stopwatch _swGlobal;

        private IProgress<HarvesterProgressReport>? _progress;

        private int _initialFileCount;
        private Dictionary<string, DateTime> _initialWriteTimes;



        private static readonly StructureHarvesterStartupService _instance = new StructureHarvesterStartupService();
        public static StructureHarvesterStartupService Instance => _instance;

        private static readonly string _exeFilePath = Path.Combine(DirectoriesManager.RootPath, "structureHarvester.exe");
        private string arguments = $"--dir=\"{StructureHarvesterConfigurationParametersManager.CurrentParameterSet.InputDataFolderPath}\" --out=\"{StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath}\"" +
                        (StructureHarvesterConfigurationParametersManager.CurrentParameterSet.Evanno? " --evanno" : string.Empty) + (StructureHarvesterConfigurationParametersManager.CurrentParameterSet.Clumpp? " --clumpp" : string.Empty);

        public async Task RunAsync(IProgress<HarvesterProgressReport> progress, Logger logger, CancellationToken token = default)
        {
            _progress = progress ?? throw new ArgumentNullException(nameof(progress));
            _initialFileCount = Directory.GetFiles(_outputFolder, "*", SearchOption.TopDirectoryOnly).Length;
            _initialWriteTimes = Directory.GetFiles(_outputFolder, "*", SearchOption.TopDirectoryOnly).ToDictionary(path => path, path => File.GetLastWriteTimeUtc(path));

            var ks = Enumerable.Range(
                StructureConfigurationParametersManager.CurrentParameterSet.KStart,
                StructureHarvesterConfigurationParametersManager.CurrentParameterSet.KEnd
                  - StructureConfigurationParametersManager.CurrentParameterSet.KStart + 1
            );
            _totalFiles = ks.Count() * 2;

            _swGlobal = Stopwatch.StartNew();

            lock (_samples) { _samples.Clear(); }
            _progressTimer = new System.Timers.Timer(50);
            _progressTimer.Elapsed += (_, __) => ReportFileProgress();
            _progressTimer.Start();

            ReportFileProgress();


            var startInfo = new ProcessStartInfo
            {
                FileName = _exeFilePath,
                Arguments = arguments,
                WorkingDirectory = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var proc = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
            proc.OutputDataReceived += (s, e) => 
            { 
                if (e.Data != null)
                {
                    logger.Info(e.Data);
                }
            };
            proc.ErrorDataReceived += (s, e) => 
            { 
                if (e.Data != null)
                {
                    logger.Error(e.Data);
                }
            };

            logger.Info("Starting Structure Harvester...");
            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();

            await proc.WaitForExitAsync();

            ReportFileProgress();

            _swGlobal.Stop();
            _progressTimer.Stop();
            _progressTimer.Dispose();
            _progress?.Report(new HarvesterProgressReport(1.0, _swGlobal.Elapsed, TimeSpan.Zero));


            if (proc.ExitCode != 0)
                logger.Error($"Harvester exit code {proc.ExitCode}");
        }

        private void ReportFileProgress()
        {
            var currentFiles = Directory.GetFiles(_outputFolder, "*", SearchOption.TopDirectoryOnly);
            int doneFiles = 0;
            foreach (var path in currentFiles)
            {
                if (!_initialWriteTimes.TryGetValue(path, out var oldTime))
                {
                    doneFiles++;
                }
                else
                {
                    var newTime = File.GetLastWriteTimeUtc(path);
                    if (newTime > oldTime)
                        doneFiles++;
                }
            }

            if (doneFiles >= _totalFiles)
            {
                _progressTimer.Stop();
                return;
            }

            double fraction = Math.Min(1.0, doneFiles / (double)_totalFiles);

            var now = DateTime.UtcNow;
            var elapsed = _swGlobal.Elapsed;

            double maturity = doneFiles / (double)_totalFiles; 
            int minSamples = (int)(maturity * _maxSamples);

            double alpha = 0.1 * (1 - maturity) + 0.02 * maturity;

            List<(DateTime Timestamp, double fractions)> snapshot;
            lock (_samples)
            {
                _samples.Enqueue((now, fraction));
                while (_samples.Count > _maxSamples)
                    _samples.Dequeue();

                snapshot = _samples.ToList();
            }

            TimeSpan etaLinear = TimeSpan.Zero;
            if (fraction > 0)
            {
                long totalTicks = (long)(elapsed.Ticks / fraction);
                etaLinear = TimeSpan.FromTicks(totalTicks - elapsed.Ticks);
            }
            if (snapshot.Count < Math.Max(2, minSamples))
            {
                _progress?.Report(new HarvesterProgressReport(fraction, elapsed, etaLinear));
                return;
            }

            var (t0, f0) = snapshot[0];
            var (t1, f1) = snapshot[^1];
            double dt = (t1 - t0).TotalSeconds;
            double df = f1 - f0;
            if (dt <= 0 || df <= 0)
            {
                _progress?.Report(new HarvesterProgressReport(fraction, elapsed, etaLinear));
                return;
            }
            double instantSpeed = df / dt;  

            if (_smoothedSpeed < 0)
                _smoothedSpeed = instantSpeed;
            else
                _smoothedSpeed = alpha * instantSpeed + (1 - alpha) * _smoothedSpeed;

            TimeSpan etaSmooth = TimeSpan.FromSeconds((1 - fraction) / _smoothedSpeed);

            var combinedEta = TimeSpan.FromTicks((etaLinear.Ticks + etaSmooth.Ticks) / 2);

            _progress?.Report(new HarvesterProgressReport(fraction, elapsed, combinedEta));
        }

    }
}
