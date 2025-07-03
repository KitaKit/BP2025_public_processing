using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GenotypeApp.Additional_programs_logic.CLUMPP;
using GenotypeApp.Additional_programs_logic.Distruct;
using GenotypeApp.Additional_programs_logic.Structure;
using GenotypeApp.Application_logic;
using GenotypeApp.Application_logic.Custom_exceptions;
using GenotypeApp.Interface_elements_interaction;
using GenotypeApp.Interface_view_models;

namespace GenotypeApp
{
    public partial class GenotypeProjectsWindow : Form
    {
        private readonly CurrentProjectInfoViewModel _currentProjectInfoViewModel = new();
        private bool _newProject = true;
        private static readonly Dictionary<string, Action<string, Logger>> _loaders = new()
        {
            ["Structure"] = (s, l) =>
            {
                l.Info("");
                ProjectConfigurationService.LoadStructureConfig(s, l);
                var list = FilesManager.ReadFileToList(Path.Combine(StructureConfigurationParametersManager.StructureFolder, StructureConfigurationParametersManager.CurrentParameterSet.SetName), StructureConfigurationParametersManager.MainparamsFileName);
                StructureParametersModel.Instance.LoadFromLines(list);
            },
            ["Structure Harvester"] = (s, l) =>
            {
                ProjectConfigurationService.LoadStructureHarvesterConfig(s, l);
            },
            ["CLUMPP"] = (s, l) =>
            {
                ProjectConfigurationService.LoadCLUMPPConfig(s, l);
                var list = FilesManager.ReadFileToList(Path.Combine(CLUMPPConfigurationParametersManager.CLUMPPFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName), CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile);
                CLUMPPParametersModel.Instance.LoadFromLines(list);
            },
            ["Distruct"] = (s, l) =>
            {
                ProjectConfigurationService.LoadDistructConfig(s, l);
                var list = FilesManager.ReadFileToList(Path.Combine(DistructConfigurationParametersManager.DistructFolder, DistructConfigurationParametersManager.CurrentParameterSet.SetName), DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile);
                DistructParametersModel.Instance.LoadFromLines(list);
            }
        };

        private GenotypeApplicationMainWindow _genotypeApplicationMainWindow;
        public bool IsNewProject { get => _newProject; }

        private static void EnsureDependencies()
        {
            var items = new (string ItemPath, bool IsDirectory)[]
            {
            ("structure.exe", false),
            ("structureHarvester.exe", false),
            ("CLUMPP.exe", false),
            ("distructWindows1.1.exe", false),
            ("gsdll64.dll", false),
            ("ghostscript_lib", true),
            };

            foreach (var (itemPath, isDir) in items)
            {
                var fullPath = Path.Combine(DirectoriesManager.RootPath, itemPath);
                bool exists = isDir
                    ? Directory.Exists(fullPath)
                    : File.Exists(fullPath);

                if (!exists)
                {
                    FatalMissing(itemPath, fullPath, isDir);
                }
            }
        }

        private static void FatalMissing(string itemName, string fullPath, bool isDir)
        {
            string what = isDir ? "folder" : "file";
            string msg = $"The {what} «{itemName}» was not found at path «{DirectoriesManager.RootPath}». Application launch is not possible.";

            MessageBox.Show(msg, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(1);
        }

        public GenotypeProjectsWindow()
        {
            EnsureDependencies();

            InitializeComponent();
        }
        private void GenotypeProjectsWindow_Load(object sender, EventArgs e)
        {
            currentProjectInfoBindingSource.DataSource = _currentProjectInfoViewModel;
            projectInformationModelBindingSource.DataSource = ProjectInformationModel.Instance;

            programsCheckedListBox.CheckAllCheckedListBoxItems();

            
        }

        private void changePathButton_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderDialog = new();
            folderDialog.Description = "Select folder for project...";
            folderDialog.ShowNewFolderButton = true;

            if (folderDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                ProjectInformationModel.Instance.ProjectPath = folderDialog.SelectedPath;
        }

        private void programsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string key = programsCheckedListBox.Items[e.Index].ToString();

            bool newCheckedState = (e.NewValue == CheckState.Checked);

            ProjectInformationModel.Instance.SetUsedSubProgram(key, newCheckedState);

        }
        private void allowParallelExecutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowParallelExecutionCheckBox.Checked)
            {
                parallelExecutionGroupBox.Enabled = false;
                ProjectInformationModel.Instance.Cores = 1;
                return;
            }

            parallelExecutionGroupBox.Enabled = true;
            coresNumTrackBar.Enabled = false;
            coresLabel.Enabled = false;
            coresNumLabel.Enabled = false;
            ProjectInformationModel.Instance.Cores = Environment.ProcessorCount;
        }
        private void selectCoresRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool coresRBState = selectCoresRadioButton.Checked;

            if (coresRBState) { ProjectInformationModel.Instance.Cores = coresNumTrackBar.Value; }
            else { ProjectInformationModel.Instance.Cores = Environment.ProcessorCount; }

            coresNumTrackBar.Enabled = coresRBState;
            coresLabel.Enabled = coresRBState;
            coresNumLabel.Enabled = coresRBState;

        }
        private void coresNumTrackBar_ValueChanged(object sender, EventArgs e)
        {
            coresNumLabel.Text = coresNumTrackBar.Value.ToString();
        }
        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            doneButton.Enabled = !string.IsNullOrEmpty(projectNameTextBox.Text);
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectInformationModel.Instance.ProjectName))
            {
                MessageBox.Show("The \'Project name\' text field cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(ProjectInformationModel.Instance.ProjectPath))
            {
                MessageBox.Show("The \'Project folder\' text field cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _genotypeApplicationMainWindow = new GenotypeApplicationMainWindow(this);

            LoggingManager.Initialize(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, $"{ProjectInformationModel.Instance.ProjectName}_app.log"), new[] { _genotypeApplicationMainWindow.StructureLogTextBox, _genotypeApplicationMainWindow.StructureHarvesterLogTextBox, _genotypeApplicationMainWindow.CLUMPPLogTextBox, _genotypeApplicationMainWindow.DistructLogTextBox });

            var appLogger = LoggingManager.GetLogger("App");

            if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName)))
            {
                if (_newProject)
                {
                    MessageBox.Show(
                        $"A project named {ProjectInformationModel.Instance.ProjectName} already exists. Load project information?",
                        "Information",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (DialogResult == DialogResult.No)
                        return;

                    _newProject = false;

                    try
                    {
                        ProjectConfigurationService.LoadProjectInfo(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName), appLogger);

                        allowParallelExecutionCheckBox.Checked = true;
                        selectCoresRadioButton.Checked = true;

                        appLogger.Info($"Project data for {ProjectInformationModel.Instance.ProjectName} loaded successfully.");

                    }
                    catch (ConfigLoadException)
                    {
                        MessageBox.Show("Configuration file loading failed, check the log file for more detailed information. Default configuration will be used.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        appLogger.Info($"Loading of project data for {ProjectInformationModel.Instance.ProjectName} did not complete. Default configuration will be used");
                    }


                    return;
                }

                LoadUsedConfigs(appLogger);

                if (!DirectoriesManager.SyncProgramDirectories())
                    return;
            }
            else
            {
                DirectoriesManager.CreateDirectory(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
                DirectoriesManager.CreateAdditionalProgramsDirectories(ProjectInformationModel.Instance.UsedSubPrograms.Where(pair => pair.Value).Select(pair => pair.Key).ToArray());
            }

            try
            {
                ProjectConfigurationService.SaveProjectInfo(appLogger);

                appLogger.Info($"Project data for {ProjectInformationModel.Instance.ProjectName} saved successfully.");
            }
            catch (ConfigSaveException)
            {
                appLogger.Error($"Saving project data for {ProjectInformationModel.Instance.ProjectName} failed. Further operation of the application is not possible.");
                MessageBox.Show("Saving project configuration failed, check the log file for more detailed information. Current session settings will not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Hide();

            _genotypeApplicationMainWindow.Show();
        }

        private void openExistingProject_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Choose project folder...";
            folderDialog.ShowNewFolderButton = false;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var appLogger = LoggingManager.GetLogger("App");
                _newProject = false;

                try
                {
                    ProjectConfigurationService.LoadProjectInfo(folderDialog.SelectedPath, appLogger);

                    allowParallelExecutionCheckBox.Checked = true;
                    selectCoresRadioButton.Checked = true;

                    appLogger.Info($"Project data for {ProjectInformationModel.Instance.ProjectName} loaded successfully.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Configuration file loading failed, check the log file for more detailed information. Default configuration will be used.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    appLogger.Info($"Loading of project data for {ProjectInformationModel.Instance.ProjectName} did not complete. Default configuration will be used");
                }
            }
        }

        private static void LoadUsedConfigs(Logger logger)
        {
            var info = ProjectInformationModel.Instance;
            var basePath = Path.Combine(info.ProjectPath, info.ProjectName);

            foreach (var kvp in info.UsedSubPrograms.Where(x => x.Value))
            {
                if (_loaders.TryGetValue(kvp.Key, out var loader))
                {
                    loader(basePath, logger);
                }
            }
        }
    }
}
