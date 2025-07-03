using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public static class StructureConfigurationParametersManager
    {
        
        private static readonly string _mainparamsFileName = "mainparams";
        private static readonly string _extraparamsFileName = "extraparams";
        private static readonly string _structureFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First());

        private static StructureConfigurationParametersModel _currentParameterSet;
        private static HashSet<StructureConfigurationParametersModel> _parameterSetList = new HashSet<StructureConfigurationParametersModel>();

        public static StructureConfigurationParametersModel CurrentParameterSet { get => _currentParameterSet; set => _currentParameterSet = value; }
        public static HashSet<StructureConfigurationParametersModel> ParameterSetList { get => _parameterSetList; }

        public static string MainparamsFileName => _mainparamsFileName;

        public static string ExtraparamsFileName => _extraparamsFileName;

        public static string StructureFolder => _structureFolder;
    }
}
