using System.IO;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal static class DistructPSExportPreparationsService
    {
        public static void Prepare(string parametersSetName)
        {
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
            string setFolder = Path.Combine(distructFolder, parametersSetName);
            string exportResultsFolder = Path.Combine(setFolder, "Exported");

            DirectoriesManager.CreateDirectory(exportResultsFolder);
        }
    }
}
