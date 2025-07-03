using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public class StructureConfigurationParametersModel : INotifyPropertyChanged, IJsonConfigurable, IHasSetName
    {
        private string _setName = string.Empty;
        private string _outputFolderPath = string.Empty;
        private int _kStart = 1;
        private int _kEnd = 3;
        private int _iterations = 3;
        public string OutputFolder => _outputFolderPath;
        
        public string SetName
        {
            get => _setName;
            set { if (value == _setName) return; _setName = value; _outputFolderPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First(), _setName, "Results"); }
        }
        public int KStart 
        { 
            get => _kStart;
            set { if (_kStart == value) return; _kStart = Math.Max(1, value); }
        }
        public int KEnd
        {
            get => _kEnd;
            set { if (_kEnd == value) return; _kEnd = Math.Max(_kStart, value); OnPropertyChanged(); }
           
        }
        public int Iterations
        { 
            get => _iterations;
            set { if (_iterations == value) return; _iterations = Math.Max(1, value); OnPropertyChanged(); }
        }

        public JsonObject ToJson() => new JsonObject
        {
            ["SetName"] = SetName,
            ["KStart"] = KStart,
            ["KEnd"] = KEnd,
            ["Iterations"] = Iterations
        };

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
