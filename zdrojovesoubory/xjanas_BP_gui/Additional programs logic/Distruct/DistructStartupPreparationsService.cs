using System.IO;
using System.Linq;
using GenotypeApp.Additional_programs_logic.CLUMPP;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal static class DistructStartupPreparationsService
    {
        public static void Prepare(bool tmp = false)
        {
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string CLUMPPFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
            string setFolder = Path.Combine(distructFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);
            string tmpFolder = Path.Combine(setFolder, "tmp");
            string optionalFilesFolder = Path.Combine(setFolder, "Optional");


            DirectoriesManager.CreateDirectory(setFolder);
            DirectoriesManager.CreateDirectory(DistructConfigurationParametersManager.CurrentParameterSet.OutputFolderPath);
            DirectoriesManager.CreateDirectory(tmpFolder);
            DirectoriesManager.CreateDirectory(optionalFilesFolder);

            if (!string.IsNullOrWhiteSpace(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelBelow))
            {
                string name = Path.GetFileName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelBelow);
                string path = Path.GetDirectoryName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelBelow);

                FilesManager.CopyFile(path, name, optionalFilesFolder);
                DistructParametersModel.Instance.INFILE_LABEL_BELOW = Path.Combine("Optional", name);
            }
            if (!string.IsNullOrWhiteSpace(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelAtop))
            {
                string name = Path.GetFileName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelAtop);
                string path = Path.GetDirectoryName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalLabelAtop);

                FilesManager.CopyFile(path, name, optionalFilesFolder);
                DistructParametersModel.Instance.INFILE_LABEL_ATOP = Path.Combine("Optional", name);
            }
            if (!string.IsNullOrWhiteSpace(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalClustPerm))
            {
                string name = Path.GetFileName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalClustPerm);
                string path = Path.GetDirectoryName(DistructConfigurationParametersManager.CurrentParameterSet.InputOriginalClustPerm);

                FilesManager.CopyFile(path, name, optionalFilesFolder);
                DistructParametersModel.Instance.INFILE_CLUST_PERM = Path.Combine("Optional", name);
            }

            if (!tmp) 
                CreateParamsFiles(setFolder);
            else
            {
                CreateParamsFiles(tmpFolder, tmp);
            }
        }

        private static void CreateParamsFiles(string parametersSetFolder, bool tmp = false)
        {
            var stringList = DistructParametersModel.Instance.GetParamsStringList();

            if (!tmp)
                FilesManager.WriteFileByList(stringList, parametersSetFolder, DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile);
            else
                FilesManager.WriteFileByList(stringList, parametersSetFolder, DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile + "_tmp");
        }
    }
}
