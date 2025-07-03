using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using GenotypeApp.Additional_programs_logic.CLUMPP;
using GenotypeApp.Additional_programs_logic.Distruct;
using GenotypeApp.Additional_programs_logic.Structure;
using GenotypeApp.Additional_programs_logic.Structure_Harvester;
using GenotypeApp.Application_logic.Custom_exceptions;

namespace GenotypeApp.Application_logic
{
    internal static class ProjectConfigurationService
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        private const string ProjectConfigFileName = "project.json";
        private const string ProgramsConfigFileName = "programs.json";

        private static JsonObject LoadJson(string projectFolderPath, string configFileName, Logger logger, bool isProject)
        {
            string projectName = ProjectInformationModel.Instance.ProjectName;

            string context = isProject ? $"project configuration «{projectName}»" : $"external application configuration for project «{projectName}»";
            logger.Info("Loading {Context} from file {FileName}...", context, configFileName);

            var filePath = Path.Combine(projectFolderPath, configFileName);
            if (!File.Exists(filePath))
            {
                var msg = $"Configuration file {configFileName} for {context} was not found.";
                logger.Warn(msg);
                throw new ConfigLoadException();
            }

            try
            {
                logger.Info("Attempting to read configuration file {FileName} for {Context}.", configFileName, context);
                var json = File.ReadAllText(filePath);
                logger.Info("Successfully read configuration file {FileName} for {Context}.", configFileName, context);
                logger.Info("Attempting to interpret data from configuration file {FileName} for {Context}.", configFileName, context);
                var obj = JsonNode.Parse(json)?.AsObject() ?? throw new ConfigLoadException();
                logger.Info("Successfully interpreted data from configuration file {FileName} for {Context}.", configFileName, context);
                return obj;
            }
            catch (JsonException ex)
            {
                var msg = $"JSON parsing error in {configFileName} for {context}.";
                logger.Error(ex, msg);
                throw new ConfigLoadException();
            }
            catch (Exception ex)
            {
                var msg = $"Error reading file {configFileName} for {context}.";
                logger.Error(ex, msg);
                throw new ConfigLoadException();
            }
        }

        private static void SaveJson(JsonObject root, string projectFolderPath, string configFileName, Logger logger, bool isProject)
        {
            var filePath = Path.Combine(projectFolderPath, configFileName);
            var tempFile = filePath + ".tmp";

            var jsonText = root.ToJsonString(JsonOptions);

            string projectName = ProjectInformationModel.Instance.ProjectName;
            string context = isProject ? $"project configuration «{projectName}»" : $"external application configuration for project «{projectName}»";
            logger.Info("Saving {Context} to file {FileName}...", context, configFileName);

            try
            {
                logger.Info("Attempting to create temporary configuration file.");
                File.WriteAllText(tempFile, jsonText);
                logger.Info("Temporary configuration file {TempFile} created successfully.", configFileName);
            }
            catch (Exception ex)
            {
                logger.Error("Error creating temporary configuration file {TempFile}: {ex}.", configFileName, ex);
                throw new ConfigSaveException();
            }

            try
            {
                if (File.Exists(filePath))
                {
                    logger.Info("Configuration file {FileName} will be replaced with the updated temporary {TempFile}.", configFileName, configFileName);
                    File.Replace(tempFile, filePath, null);
                    logger.Info("Configuration file {FileName} was successfully replaced with the updated configuration.", configFileName);
                }
                else
                {
                    logger.Info("Temporary configuration file {TempFile} will be converted into the main file.", configFileName);
                    File.Move(tempFile, filePath);
                    logger.Info("Conversion completed successfully.");
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error creating configuration file {FileName}: {ex}.", configFileName, ex);
                throw new ConfigSaveException();
            }
        }

        public static void SaveProjectInfo(Logger logger)
        {
            var model = ProjectInformationModel.Instance;
            string projectFolder = Path.Combine(model.ProjectPath, model.ProjectName);
            string filePath = Path.Combine(projectFolder, ProjectConfigFileName);

            string originalJson = null;
            logger.Info("Checking for existence of project configuration file {FileName}.", ProjectConfigFileName);

            JsonObject root;

            try
            {
                if (File.Exists(filePath))
                {
                    logger.Info("Project configuration file {FileName} was found.", ProjectConfigFileName);
                    logger.Info("Attempting to read project configuration file {FileName}...", ProjectConfigFileName);
                    originalJson = File.ReadAllText(filePath);
                    logger.Info("Project configuration file {FileName} loaded successfully. It will be updated.", ProjectConfigFileName);
                }
                else
                {
                    logger.Info("Project configuration file {FileName} was not found. A new one will be created.", ProjectConfigFileName);
                }

                if (originalJson == null)
                    root = new JsonObject();
                else
                {
                    logger.Info("Attempting to interpret project data from configuration file {FileName}...", ProjectConfigFileName);
                    root = JsonNode.Parse(originalJson).AsObject();
                    logger.Info("Project data interpretation from file {FileName} completed successfully.", ProjectConfigFileName);
                }
            }
            catch (JsonException)
            {
                root = new JsonObject();
                logger.Info("Project data interpretation from file {FileName} failed. Configuration file will be overwritten.", ProjectConfigFileName);
            }
            catch (Exception)
            {
                root = new JsonObject();
                logger.Info("Reading project configuration file {FileName} failed. It will be overwritten.", ProjectConfigFileName);
            }

            root["ProjectName"] = model.ProjectName;
            root["ProjectPath"] = model.ProjectPath;
            root["ParallelExec"] = model.ParallelExec;
            root["Cores"] = model.Cores;

            var dictNode = JsonSerializer.SerializeToNode(model.UsedSubPrograms, JsonOptions)?.AsObject();
            if (dictNode != null)
                root["UsedSubPrograms"] = dictNode;

            string newJson = root.ToJsonString(JsonOptions);

            logger.Info("Checking for changes in the new project configuration.");
            if (originalJson != null && string.Equals(originalJson, newJson, StringComparison.Ordinal))
            {
                logger.Info("No changes detected. Update of project configuration file {FileName} is canceled.", ProjectConfigFileName);
                return;
            }

            logger.Info("Changes detected. Project configuration file {FileName} will be updated.", ProjectConfigFileName);

            try
            {
                SaveJson(root, projectFolder, ProjectConfigFileName, logger, true);
            }
            catch (ConfigSaveException)
            {
                throw;
            }
        }

        public static void LoadProjectInfo(string projectFolderPath, Logger logger)
        {
            JsonObject root;
            try
            {
                root = LoadJson(projectFolderPath, ProjectConfigFileName, logger, true);
            }
            catch (ConfigLoadException)
            {
                throw;
            }

            var projModel = ProjectInformationModel.Instance;
            if (root.TryGetPropertyValue("ProjectName", out var pn))
                projModel.ProjectName = pn?.GetValue<string>() ?? projModel.ProjectName;
            if (root.TryGetPropertyValue("ProjectPath", out var pp))
                projModel.ProjectPath = pp?.GetValue<string>() ?? projModel.ProjectPath;
            if (root.TryGetPropertyValue("Cores", out var cr))
                projModel.Cores = cr?.GetValue<int>() ?? projModel.Cores;
            if (root.TryGetPropertyValue("UsedSubPrograms", out var uspNode) && uspNode is JsonObject uspObj)
            {
                foreach (var kv in uspObj)
                    if (kv.Value is JsonValue val && val.TryGetValue<bool>(out var flag))
                        projModel.SetUsedSubProgram(kv.Key, flag);
            }
        }
        public static void SaveStructureConfig(string projectFolderPath, Logger logger)
        {
            try
            {
                SaveConfig(projectFolderPath, sectionName: "Structure", parameterSetList: StructureConfigurationParametersManager.ParameterSetList, currentParameterSet: StructureConfigurationParametersManager.CurrentParameterSet, logger);
            }
            catch (ConfigSaveException)
            {
                throw;
            }
            
        }

        public static void LoadStructureConfig(string projectFolderPath, Logger logger)
        {
            LoadConfig(
                projectFolderPath,
                sectionName: "Structure",
                parameterSetList: StructureConfigurationParametersManager.ParameterSetList,
                factory: jo => new StructureConfigurationParametersModel
                {
                    SetName = jo["SetName"]?.GetValue<string>() ?? string.Empty,
                    KStart = jo["KStart"]?.GetValue<int>() ?? 0,
                    KEnd = jo["KEnd"]?.GetValue<int>() ?? 0,
                    Iterations = jo["Iterations"]?.GetValue<int>() ?? 0,
                },
                setCurrentParameter: m => StructureConfigurationParametersManager.CurrentParameterSet = m,
                logger
            );
        }

        public static void SaveStructureHarvesterConfig(string projectFolderPath, Logger logger)
        {
            SaveConfig(projectFolderPath, sectionName: "Structure Harvester", parameterSetList: StructureHarvesterConfigurationParametersManager.ParameterSetList, currentParameterSet: StructureHarvesterConfigurationParametersManager.CurrentParameterSet, logger);
        }
        public static void LoadStructureHarvesterConfig(string projectFolderPath, Logger logger)
        {
            LoadConfig(
                projectFolderPath,
                sectionName: "Structure Harvester",
                parameterSetList: StructureHarvesterConfigurationParametersManager.ParameterSetList,
                factory: jo => new StructureHarvesterConfigurationParametersModel
                {
                    SetName = jo["SetName"]?.GetValue<string>() ?? string.Empty,
                    InputDataFolderPath = jo["InputDataFolderPath"]?.GetValue<string>() ?? string.Empty,
                    Evanno = jo["Evanno"]?.GetValue<bool>() ?? false,
                    Clumpp = jo["Clumpp"]?.GetValue<bool>() ?? false,
                    KEnd = jo["KEnd"]?.GetValue<int>() ?? 0,
                    IEnd = jo["IEnd"]?.GetValue<int>() ?? 0,
                },
                setCurrentParameter: m => StructureHarvesterConfigurationParametersManager.CurrentParameterSet = m,
                logger
            );
        }
        public static void SaveClumppConfig(string projectFolderPath, Logger logger)
        {
            SaveConfig(projectFolderPath, sectionName: "CLUMPP", parameterSetList: CLUMPPConfigurationParametersManager.ParameterSetList, currentParameterSet: CLUMPPConfigurationParametersManager.CurrentParameterSet, logger);
        }
        public static void LoadCLUMPPConfig(string projectFolderPath, Logger logger)
        {
            LoadConfig(
                 projectFolderPath,
                 sectionName: "CLUMPP",
                 parameterSetList: CLUMPPConfigurationParametersManager.ParameterSetList,
                 factory: jo =>
                 {
                     var model = new CLUMPPConfigurationParametersModel
                     {
                         SetName = jo["SetName"]?.GetValue<string>() ?? string.Empty,
                         InputDataFolderPath = jo["InputDataFolderPath"]?.GetValue<string>() ?? string.Empty,
                         CurrentParamFile = jo["CurrentParamFile"]?.GetValue<string>() ?? string.Empty,
                         KStart = jo["KStart"]?.GetValue<int>() ?? 0,
                         KEnd = jo["KEnd"]?.GetValue<int>() ?? 0,
                     };

                     model.ParamFiles.AddRange(jo["ParamFiles"].AsArray().Select(node => node.GetValue<string>()));
                     
                     return model;
                 },
                 setCurrentParameter: m => CLUMPPConfigurationParametersManager.CurrentParameterSet = m,
                 logger
             );
        }
        public static void SaveDistructConfig(string projectFolderPath, Logger logger)
        {
            SaveConfig(projectFolderPath, sectionName: "Distruct", parameterSetList: DistructConfigurationParametersManager.ParameterSetList, currentParameterSet: DistructConfigurationParametersManager.CurrentParameterSet, logger);
        }
        public static void LoadDistructConfig(string projectFolderPath, Logger logger)
        {
            LoadConfig(
                projectFolderPath,
                sectionName: "Distruct",
                parameterSetList: DistructConfigurationParametersManager.ParameterSetList,
                factory: jo =>
                {
                    var model = new DistructConfigurationParametersModel
                    {
                         SetName = jo["SetName"]?.GetValue<string>() ?? string.Empty,
                         InputDataFolderPath = jo["InputDataFolderPath"]?.GetValue<string>() ?? string.Empty,
                         CurrentParamFile = jo["CurrentParamFile"]?.GetValue<string>() ?? string.Empty,
                         KStart = jo["KStart"]?.GetValue<int>() ?? 0,
                         KEnd = jo["KEnd"]?.GetValue<int>() ?? 0,
                    };

                     model.ParamFiles.AddRange(jo["ParamFiles"].AsArray().Select(node => node.GetValue<string>()));

                     return model;
                },
                setCurrentParameter: m => DistructConfigurationParametersManager.CurrentParameterSet = m,
                logger
            );
        }
        private static void SaveConfig<TSet>(
            string projectFolderPath,
            string sectionName,
            IEnumerable<TSet> parameterSetList,
            TSet currentParameterSet,
            Logger logger
            ) where TSet : IJsonConfigurable
        {
            JsonObject root;

            try
            {
                root = LoadJson(projectFolderPath, ProgramsConfigFileName, logger, false);
            }
            catch (ConfigLoadException)
            {
                logger.Warn("Loading existing configuration {ParameterSetName} for {ProgramName} from file {FileName} failed because it is missing from the file or the file is corrupted. Parameter values will be recorded as new.", currentParameterSet, sectionName, ProgramsConfigFileName);
                root = new JsonObject();
            }

            var paramSets = new JsonArray();
            foreach (var set in parameterSetList)
                paramSets.Add(set.ToJson());

            var section = new JsonObject
            {
                ["ParameterSets"] = paramSets,
                ["CurrentSetName"] = currentParameterSet?.SetName
            };

            root[sectionName] = section;

            try
            {
                SaveJson(root, projectFolderPath, ProgramsConfigFileName, logger, false);
            }
            catch (ConfigSaveException)
            {
                logger.Error("Writing configuration {ParameterSetName} for {ProgramName} to file {FileName} failed. Further program progress will not be saved and cannot be recovered when the project is reopened.", currentParameterSet, sectionName, ProgramsConfigFileName);
                throw;
            }

        }

        private static void LoadConfig<T>(
            string projectFolderPath,
            string sectionName,
            HashSet<T> parameterSetList,
            Func<JsonObject, T> factory,
            Action<T> setCurrentParameter,
            Logger logger
        ) where T : IJsonConfigurable
        {
            var root = LoadJson(projectFolderPath, ProgramsConfigFileName, logger, false);
            if (!root.TryGetPropertyValue(sectionName, out var node) || node is not JsonObject sectionObj)
                return;

            string currentName = sectionObj.TryGetPropertyValue("CurrentSetName", out var csn)
                ? csn?.GetValue<string>()
                : null;

            parameterSetList.Clear();
            T selected = default;

            if (sectionObj.TryGetPropertyValue("ParameterSets", out var psNode) && psNode is JsonArray psArr)
            {
                foreach (var item in psArr)
                {
                    if (item is not JsonObject jo) continue;
                    var model = factory(jo);
                    parameterSetList.Add(model);
                    if (model.SetName == currentName)
                        selected = model;
                }
            }

            if (selected != null)
                setCurrentParameter(selected);
        }
    }
}
