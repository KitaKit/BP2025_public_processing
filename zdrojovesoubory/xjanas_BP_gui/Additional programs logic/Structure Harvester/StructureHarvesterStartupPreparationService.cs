using GenotypeApp.Additional_programs_logic.Structure;

namespace GenotypeApp.Additional_programs_logic.Structure_Harvester
{
    internal static class StructureHarvesterStartupPreparationService
    {
        public static void Prepare()
        {
            StructureHarvesterConfigurationParametersManager.CurrentParameterSet.InputDataFolderPath = StructureConfigurationParametersManager.CurrentParameterSet.OutputFolder;

            DirectoriesManager.CreateDirectory(StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath);
        }
    }
}