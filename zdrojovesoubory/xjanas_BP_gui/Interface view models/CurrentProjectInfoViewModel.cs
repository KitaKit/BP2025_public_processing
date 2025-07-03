using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GenotypeApp.Interface_view_models
{
    public class CurrentProjectInfoViewModel : INotifyPropertyChanged
    {
        public CurrentProjectInfoViewModel()
        {
            ProjectInformationModel.Instance.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(FormattedCurrentProjectInfo));
        }

        public string FormattedCurrentProjectInfo
        {
            get
            {
                var programs = ProjectInformationModel.Instance.UsedSubPrograms.Where(kv => kv.Value).Select(kv => kv.Key).ToList();

                string formatedProgramsString = programs.Count switch
                {
                    1 => programs[0],
                    2 => $"{programs[0]} and {programs[1]}",
                    3 => $"{programs[0]}, {programs[1]} and {programs[2]}",
                    4 => $"{programs[0]}, {programs[1]}, {programs[2]} and {programs[3]}",
                    _ => "-"
                };
                
                return
                    $"Name:\t{ProjectInformationModel.Instance.ProjectName}\r\n" +
                    "═════════════════════════════════════\r\n" +
                    $"Path:\t{ProjectInformationModel.Instance.ProjectPath}\r\n" +
                    "═════════════════════════════════════\r\n" +
                    $"Programs to use:\t{formatedProgramsString}\r\n" +
                    "═════════════════════════════════════\r\n" +
                    $"Number of cores:\t{ProjectInformationModel.Instance.Cores.ToString()}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
