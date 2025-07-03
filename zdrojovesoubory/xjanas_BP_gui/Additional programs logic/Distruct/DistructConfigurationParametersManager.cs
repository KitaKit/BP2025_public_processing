using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal static class DistructConfigurationParametersManager
    {
        private static readonly string _distructFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));

        private static DistructConfigurationParametersModel _currentParameterSet;
        private static HashSet<DistructConfigurationParametersModel> _parameterSetList = new HashSet<DistructConfigurationParametersModel>();

        public static string DistructFolder => _distructFolder;
        public static DistructConfigurationParametersModel CurrentParameterSet { get => _currentParameterSet; set => _currentParameterSet = value; }
        public static HashSet<DistructConfigurationParametersModel> ParameterSetList { get => _parameterSetList; }
    }
}
