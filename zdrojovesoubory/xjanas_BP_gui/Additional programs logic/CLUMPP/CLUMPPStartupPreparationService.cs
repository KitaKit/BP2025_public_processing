using System.IO;
using System.Linq;
using GenotypeApp.Additional_programs_logic.Distruct;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    internal static class CLUMPPStartupPreparationService
    {
        public static void Prepare(bool onlyPop)
        {
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string structureHarvesterFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(1));
            string CLUMPPFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));
            string setFolder = Path.Combine(CLUMPPFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);
            string optionalFilesFolder = Path.Combine(setFolder, "Optional");

            DirectoriesManager.CreateDirectory(setFolder);
            DirectoriesManager.CreateDirectory(CLUMPPConfigurationParametersManager.CurrentParameterSet.OutputFolderPath);
            DirectoriesManager.CreateDirectory(optionalFilesFolder);

            if (!string.IsNullOrWhiteSpace(CLUMPPConfigurationParametersManager.CurrentParameterSet.InputOriginalPermFile))
            {
                string name = Path.GetFileName(CLUMPPConfigurationParametersManager.CurrentParameterSet.InputOriginalPermFile);
                string path = Path.GetDirectoryName(CLUMPPConfigurationParametersManager.CurrentParameterSet.InputOriginalPermFile);

                FilesManager.CopyFile(path, name, optionalFilesFolder);
                CLUMPPParametersModel.Instance.PERMUTATIONFILE = Path.Combine("Optional", name);
            }
            CreateParamsFiles(setFolder, onlyPop);
        }

        private static void CreateParamsFiles(string parametersSetFolder, bool onlyPop)
        {
            CLUMPPParametersModel.Instance.DATATYPE = true;
            var stringList = CLUMPPParametersModel.Instance.GetParamsStringList();
            var fileName = CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "1";

            FilesManager.WriteFileByList(stringList, parametersSetFolder, fileName);

            if (!onlyPop)
            {
                CLUMPPParametersModel.Instance.DATATYPE = false;
                stringList = CLUMPPParametersModel.Instance.GetParamsStringList();
                fileName = CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "0";

                FilesManager.WriteFileByList(stringList, parametersSetFolder, fileName);
            }
        }
    }
}
