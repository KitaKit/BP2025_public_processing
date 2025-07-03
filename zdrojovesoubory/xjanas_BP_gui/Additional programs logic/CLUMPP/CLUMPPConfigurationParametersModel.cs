using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    public sealed class CLUMPPConfigurationParametersModel : INotifyPropertyChanged, IJsonConfigurable, IHasSetName
    {
        public CLUMPPConfigurationParametersModel() 
        {
            _currentParamFile = _paramFileDefaultName;
        }
        private string _inputDataFolderPath = string.Empty;
        private string _outputFolderPath = string.Empty;
        private string _paramFileDefaultName = "paramfile";
        private string _setName = string.Empty;
        private int _kStart = 0;
        private int _kEnd = 0;
        private string _currentParamFile = string.Empty;
        private List<string> _paramFiles = new List<string>();
        private string _inputOriginalPermFile = string.Empty;

        public string OutputFolderPath => _outputFolderPath;
        public string InputDataFolderPath 
        { 
            get => _inputDataFolderPath;
            set { if (_inputDataFolderPath == value) return; _inputDataFolderPath = value; }
        }

        public int KEnd
        {
            get => _kEnd;
            set { if (_kEnd == value) return; _kEnd = value; OnPropertyChanged(); }
        }
        public int KStart
        {
            get => _kStart;
            set { if (_kStart == value) return; _kStart = Math.Max(2, value); OnPropertyChanged(); }
        }
        public string SetName
        {
            get => _setName;
            set { if (_setName == value) return; _setName = value; _outputFolderPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2), _setName, "Results"); }
        }

        public string CurrentParamFile 
        { 
            get => _currentParamFile;
            set {if (_currentParamFile == value) return; _currentParamFile = value; OnPropertyChanged(); } 
        }
        public List<string> ParamFiles { get => _paramFiles; }
        public string InputOriginalPermFile { get => _inputOriginalPermFile; set => _inputOriginalPermFile = value; }

        public JsonObject ToJson()
        {
            JsonObject jo = new JsonObject
            {
            
                ["SetName"] = SetName,
                ["InputDataFolderPath"] = InputDataFolderPath,
                ["CurrentParamFile"] = CurrentParamFile,
                ["KStart"] = KStart,
                ["KEnd"] = KEnd
            };

            var pfArray = new JsonArray();
            foreach (var file in ParamFiles)
                pfArray.Add(JsonValue.Create(file));
            jo["ParamFiles"] = pfArray;

            return jo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
