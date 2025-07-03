using System.IO;
using System.Linq;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    internal static class StructureStartupPreparationService
    {
        private static string _originalDataFilePath = string.Empty;
        private static string _originalDataFileName = string.Empty;

        public static string OriginalDataFilePath
        {
            get => _originalDataFilePath;
            set { if (value == _originalDataFilePath) return; OriginalDataFileName = Path.GetFileName(value); _originalDataFilePath = Path.GetDirectoryName(value); }
        }
        public static string OriginalDataFileName
        {
            get => _originalDataFileName;
            set { if (value == _originalDataFileName) return; _originalDataFileName = value; }
        }
        public static void Prepare()
        {
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string structureFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First());

            DirectoriesManager.CreateDirectory(structureFolder, StructureConfigurationParametersManager.CurrentParameterSet.SetName);

            string parametersSetFolder = Path.Combine(structureFolder, StructureConfigurationParametersManager.CurrentParameterSet.SetName);

            FilesManager.CopyFile(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName, parametersSetFolder, StructureParametersModel.Instance.mainparams.INFILE);

            CreateParamsFiles(parametersSetFolder);

        }
        private static void CreateParamsFiles(string parametersSetFolder)
        {
            var mainStringList = StructureParametersModel.Instance.GetMainparamsStringList();
            var extraStringList = StructureParametersModel.Instance.GetExtraparamsStringList();

            FilesManager.WriteFileByList(mainStringList, parametersSetFolder, StructureConfigurationParametersManager.MainparamsFileName);
            FilesManager.WriteFileByList(extraStringList, parametersSetFolder, StructureConfigurationParametersManager.ExtraparamsFileName);
        }
    }
}