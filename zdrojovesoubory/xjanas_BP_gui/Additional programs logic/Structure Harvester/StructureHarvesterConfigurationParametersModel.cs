using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.Structure_Harvester
{
    public sealed class StructureHarvesterConfigurationParametersModel : INotifyPropertyChanged, IJsonConfigurable, IHasSetName
    {
        private string _inputDataFolderPath = string.Empty;
        private string _outputFolderPath = string.Empty;
        private bool _evanno = true;
        private bool _clumpp = true;
        private string _setName = string.Empty;
        private int _kEnd, iEnd;
    
        public string OutputFolderPath => _outputFolderPath;

        public string InputDataFolderPath 
        { 
            get => _inputDataFolderPath;
            set { if (_inputDataFolderPath == value) return; _inputDataFolderPath = value; } 
        }
        public bool Evanno
        { 
            get => _evanno;
            set { _evanno = value; OnPropertyChanged(); } 
        }
        public bool Clumpp
        { 
            get => _clumpp;
            set { _clumpp = value; OnPropertyChanged(); } 
        }
        public string SetName
        {
            get => _setName;
            set { if (_setName == value) return; _setName = value; _outputFolderPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(1), _setName); }
        }
        public int KEnd { get => _kEnd; set => _kEnd = value; }
        public int IEnd { get => iEnd; set => iEnd = value; }

        public JsonObject ToJson() => new JsonObject
        {
            ["SetName"] = SetName,
            ["InputDataFolderPath"] = InputDataFolderPath,
            ["Evanno"] = Evanno,
            ["Clumpp"] = Clumpp,
            ["KEnd"] = KEnd,
            ["IEnd"] = IEnd
        };

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
