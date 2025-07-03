using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GenotypeApp.Application_logic
{
    internal class LoggingManager
    {
        private static readonly LoggingConfiguration config = new LoggingConfiguration();
        private static readonly Dictionary<string, Logger> loggers = new Dictionary<string, Logger>();
        public static void Initialize(string filePath, TextBox[] programTextBoxes)
        {
            var fileTarget = new FileTarget("file")
            {
                FileName = filePath,
                Layout = "${longdate}|${logger}|${level:uppercase=true}|${message}"
            };
            config.AddTarget(fileTarget);

            config.AddRuleForAllLevels(target: fileTarget, loggerNamePattern: "*");

            string[] programs = { "Structure", "Structure harvester", "CLUMPP", "Distruct" };
            string[] programsTextBoxNames = { "structureLogTextBox", "structureHarvesterLogTextBox", "clumppLogTextBox", "distructLogTextBox" };

            for (int i = 0; i < programTextBoxes.Length; i++)
            {
                string progLoggerName = programs[i];
                var textBoxControl = programTextBoxes[i];

                var uiTarget = new BatchedTextBoxTarget
                {
                    Name = programsTextBoxNames[i] + "_ui",
                    TextBoxControl = textBoxControl,
                    Layout = "${message}"
                };
                config.AddTarget(uiTarget);

                var asyncUi = new AsyncTargetWrapper(uiTarget)
                {
                    Name = programsTextBoxNames[i] + "_async",
                    QueueLimit = 10000,
                    OverflowAction = AsyncTargetWrapperOverflowAction.Discard,
                    TimeToSleepBetweenBatches = 50
                };
                config.AddTarget(asyncUi);

                config.AddRuleForAllLevels(target: asyncUi, loggerNamePattern: progLoggerName);
            }

            LogManager.Configuration = config;
            LogManager.ReconfigExistingLoggers();
        }

        public static Logger GetLogger(string name)
        {
            if (!loggers.ContainsKey(name))
                loggers[name] = LogManager.GetLogger(name);
            return loggers[name];
        }
    }
}
