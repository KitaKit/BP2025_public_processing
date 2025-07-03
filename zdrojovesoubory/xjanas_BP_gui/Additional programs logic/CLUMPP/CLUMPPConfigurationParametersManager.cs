using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    public static class CLUMPPConfigurationParametersManager
    {
        private static readonly string _CLUMPPFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));

        public static string CLUMPPFolder => _CLUMPPFolder;

        public static CLUMPPConfigurationParametersModel CurrentParameterSet { get => _currentParameterSet; set => _currentParameterSet = value; }
        public static HashSet<CLUMPPConfigurationParametersModel> ParameterSetList { get => _parameterSetList; }

        private static CLUMPPConfigurationParametersModel _currentParameterSet;
        private static HashSet<CLUMPPConfigurationParametersModel> _parameterSetList = new HashSet<CLUMPPConfigurationParametersModel>();
    }
}
