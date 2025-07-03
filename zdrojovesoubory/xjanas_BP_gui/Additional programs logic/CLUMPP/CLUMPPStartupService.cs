using NLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GenotypeApp.Additional_programs_logic.CLUMPP.ProgressRegistry;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    internal sealed class CLUMPPStartupService
    {
        private readonly ProgressRegistry _registry = new();

        private static readonly CLUMPPStartupService _instance = new CLUMPPStartupService();
        public static CLUMPPStartupService Instance => _instance;

        private string _exeFilePath = Path.Combine(DirectoriesManager.RootPath, "CLUMPP.exe");

        record RunConfig(int K, string InputFile, string OutFile, string OutputMiscFile, bool type);

        public async Task RunAsync(Logger logger, bool onlyPop, IProgress<ClumppProgressReport>? progress = null, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var swGlobal = Stopwatch.StartNew();

            var dataTypes = onlyPop ? new[] { true } : new[] { true, false };

            var runConfid = dataTypes
                .SelectMany(dataType =>
                    Enumerable.Range(
                        CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart,
                        CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd
                        - CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart + 1
                    )
                    .Select(k => new RunConfig(
                        k,
                        Path.Combine("..", "..", "Structure Harvester",
                                     CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName,
                                     dataType ? $"K{k}.popfile" : $"K{k}.indfile"),
                        Path.Combine("Results", dataType ? $"K{k}.popq" : $"K{k}.indq"),
                        Path.Combine("Results", dataType ? $"K{k}.popq.miscfile" : $"K{k}.indq.miscfile"),
                        dataType
                    ))
                );


            //if (onlyPop)
            //{

            //}

            //var runConfid =
            //    from k in Enumerable.Range(CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart, CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd - CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart + 1)
            //    select new RunConfig
            //    (
            //        k,
            //        Path.Combine("..", "..", "Structure Harvester", CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName, CLUMPPParametersModel.Instance.DATATYPE ? $"K{k}.popfile" : $"K{k}.indfile"),
            //        Path.Combine("Results", (CLUMPPParametersModel.Instance.DATATYPE ? "K" + k + ".popq" : "K" + k + ".indq")),
            //        Path.Combine("Results", (CLUMPPParametersModel.Instance.DATATYPE ? "K" + k + ".popq.miscfile" : "K" + k + ".indq.miscfile"))
            //    );

            foreach (var job in runConfid)
            {
                double total = CLUMPPParametersModel.Instance.M == 1 ? Math.Pow(Factorial(job.K), CLUMPPParametersModel.Instance.R - 1) : CLUMPPParametersModel.Instance.REPEATS;
                total = onlyPop ? total : total * 2;
                _registry.RegisterJob(job.K, total);
            }

            using var semaphore = new SemaphoreSlim(ProjectInformationModel.Instance.Cores);
            var childTasks = runConfid.Select(job => RunSingleWrappedAsync(job, semaphore, logger, token));
            var processingTask = Task.WhenAll(childTasks);

            var reporterTask = Task.Run(async () =>
            {
                using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));
                try
                {
                    while (await timer.WaitForNextTickAsync(token))
                    {
                        progress?.Report(_registry.MakeReport());
                        if (processingTask.IsCompleted || token.IsCancellationRequested) break;
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                finally
                {
                    if (!token.IsCancellationRequested)
                        progress?.Report(_registry.MakeReport());
                }

            }, token);

            try
            {
                await processingTask;
                await reporterTask;      
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            finally
            {

                swGlobal.Stop();
            }
        }

        private async Task RunSingleWrappedAsync(RunConfig job, SemaphoreSlim semaphore, Logger logger, CancellationToken token)
        {
            await semaphore.WaitAsync(token);
            try
            {
                await RunSingleAsync(job, logger, token);
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task RunSingleAsync(RunConfig job, Logger logger, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var sw = Stopwatch.StartNew();

            string? highestHLine = null;

            string arguments = $"{(job.type ? CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "1" : CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "0")}" +
                $"{(job.type ? " -p " : " -i ")}" +
                $"\"{job.InputFile}\"" +
                $" -c {(job.type ? CLUMPPParametersModel.Instance.NumOfPop : CLUMPPParametersModel.Instance.NumOfInd)}"+
                $" -o {job.OutFile}" +
                $" -j {job.OutputMiscFile}" +
                $" -k {job.K}";

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string CLUMPPFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));
            string setFolder = Path.Combine(CLUMPPFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);

            var psi = new ProcessStartInfo
            {
                FileName = _exeFilePath,
                Arguments = arguments,
                WorkingDirectory = setFolder,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            };


            using var process = new Process { StartInfo = psi, EnableRaisingEvents = true };

            using var killReg = token.Register(() =>
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
                if (e.Data is null) return;

                if (e.Data.StartsWith((job.type ? ("The highest value of H") : ("The highest value of G")), StringComparison.OrdinalIgnoreCase))
                {
                    highestHLine = e.Data;
                }

                logger.Info($"[K={job.K}, {e.Data}");

                if (e.Data.StartsWith("The program finished in", StringComparison.OrdinalIgnoreCase))
                {
                    process.StandardInput.WriteLine();
                }
            };

            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data is not null)
                {
                    logger.Error($"[K={job.K}, ERROR] {e.Data}");
                }
            };

            logger.Info("Starting CLUMPP...");

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync(token);

            var outputDir = Path.Combine(setFolder, "Results");

            if (!string.IsNullOrEmpty(highestHLine))
            {
                try
                {
                    var hvFileName = $"K{job.K}_hv.txt";
                    var hvFilePath = Path.Combine(outputDir, hvFileName);

                    await File.WriteAllTextAsync(
                        hvFilePath,
                        highestHLine + Environment.NewLine,
                        Encoding.UTF8
                    );
                }
                catch (Exception ex)
                {
                    logger.Error($"[K={job.K}] {(job.type ? ("Can't write H value in new file: ") : ("Can't write G value in new file: "))} {ex.Message}");
                }
            }

            if (token.IsCancellationRequested) return;

            double total = CLUMPPParametersModel.Instance.M == 1 ? Math.Pow(Factorial(job.K), CLUMPPParametersModel.Instance.R - 1) : CLUMPPParametersModel.Instance.REPEATS;
            _registry.Update(job.K, total);

            sw.Stop();

            if (process.ExitCode != 0)
            {
                logger.Error($"CLUMPP exited with code {process.ExitCode} (K={job.K})");
                throw new ExternalException();
            }
        }

        public static double Factorial(int n)
        {
            double f = 1;
            for (int i = 2; i <= n; i++) f *= i;
            return f;
        }
    }
}
