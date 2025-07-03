using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace GenotypeApp
{
    public sealed class ProjectInformationModel : INotifyPropertyChanged
    {
        private static readonly ProjectInformationModel _instance = new ProjectInformationModel();
        public static ProjectInformationModel Instance => _instance;
        private ProjectInformationModel()
        {
            _projectPath = Path.Combine(DirectoriesManager.RootPath, _defaultProjectFolderName);
        }

        private readonly Dictionary<string, bool> _usedSubPrograms = new()
        {
            { "Structure", false },
            { "Structure Harvester", false },
            { "CLUMPP", false },
            { "Distruct", false }
        };
        private readonly string _defaultProjectFolderName = "Projects";

        private string _projectName = string.Empty;
        private string _projectPath = string.Empty;
        private bool _parallelExec = false;
        private int _cores = 1;

        public int Cores
        {
            get => _cores;
            set
            {
                if (_cores == value) return;
                _cores = value;
            }
        }

        public IReadOnlyDictionary<string, bool> UsedSubPrograms => _usedSubPrograms;
        public void SetUsedSubProgram(string key, bool value)
        {
            if (!_usedSubPrograms.ContainsKey(key))
                return;
            if (_usedSubPrograms[key] == value)
                return;

            _usedSubPrograms[key] = value;
            OnPropertyChanged(nameof(UsedSubPrograms));
        }

        public string DefaultProjectFolderName => _defaultProjectFolderName;
        public string ProjectName
        { 
            get => _projectName;
            set
                {
                    if (_projectName == value) return;
                    _projectName = value;
                    OnPropertyChanged();
                }
        }
        public string ProjectPath
        { 
            get => _projectPath;
            set 
            {
                if (_projectPath == value) return;
                _projectPath = value;
                OnPropertyChanged();
            }
        }

        public bool ParallelExec 
        { 
            get => _parallelExec; 
            set { _parallelExec = value; if (value == false) Cores = 1; OnPropertyChanged(); } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
