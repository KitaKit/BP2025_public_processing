using ImageMagick;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GenotypeApp.Additional_programs_logic.CLUMPP;
using GenotypeApp.Additional_programs_logic.Distruct;
using GenotypeApp.Additional_programs_logic.Structure;
using GenotypeApp.Additional_programs_logic.Structure_Harvester;
using GenotypeApp.Application_logic;
using GenotypeApp.Application_logic.Custom_exceptions;
using GenotypeApp.Directories_and_files_processing;
using GenotypeApp.Interface_elements_extensions;
using static GenotypeApp.Additional_programs_logic.Distruct.DistructStartupService;
using static GenotypeApp.Additional_programs_logic.Structure.StructureStartupService;
using static GenotypeApp.Additional_programs_logic.Structure_Harvester.StructureHarvesterStartupService;

namespace GenotypeApp
{
    public partial class GenotypeApplicationMainWindow : Form
    {
        private readonly GenotypeProjectsWindow _showOnClose;
        private DirectoriesLiveMonitor _directoryLiveMonitor;

        private StructureConfigurationParametersModel _structureConfigurationParametersModel = new();
        private StructureHarvesterConfigurationParametersModel _structureHarvesterConfigurationParametersModel = new();
        private CLUMPPConfigurationParametersModel _CLUMPPConfigurationParametersModel = new();
        private DistructConfigurationParametersModel _distructConfigurationParametersModel = new();

        public System.Windows.Forms.TextBox StructureLogTextBox => structureLogTextBox;
        public System.Windows.Forms.TextBox StructureHarvesterLogTextBox => structureHarvesterLogTextBox;
        public System.Windows.Forms.TextBox CLUMPPLogTextBox => clumppLogTextBox;
        public System.Windows.Forms.TextBox DistructLogTextBox => distructLogTextBox;

        private Logger _appLogger = LoggingManager.GetLogger("App");
        private Logger _structureLogger = LoggingManager.GetLogger("Structure");
        private Logger _structureHarvesterLogger = LoggingManager.GetLogger("Structure Harvester");
        private Logger _CLUMPPLogger = LoggingManager.GetLogger("CLUMPP");
        private Logger _distructLogger = LoggingManager.GetLogger("Distruct");

        private CancellationTokenSource _structureCTS;
        private CancellationTokenSource _clumppCTS;
        private CancellationTokenSource _distructCTS;

        private bool _isNewProject;
        public GenotypeApplicationMainWindow(GenotypeProjectsWindow parentWindow)
        {
            InitializeComponent();

            _showOnClose = parentWindow;
        }

        private void GenotypeApplicationMainWindow_Load(object sender, EventArgs e)
        {
            _isNewProject = _showOnClose.IsNewProject;

            foreach (TabPage page in tabControl1.TabPages)
            {
                if (ProjectInformationModel.Instance.UsedSubPrograms.TryGetValue(page.Text, out bool used))
                    page.Enabled = used;
            }

            string projectDirectoryPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);

            try
            {
                currentProjectFoldersTreeView.PopulateProjectFolders(projectDirectoryPath);
                currentProjectFoldersTreeView.ExpandAll();

                _directoryLiveMonitor = new DirectoriesLiveMonitor(projectDirectoryPath);
                _directoryLiveMonitor.DirectoriesChanged += OnDirectoriesChanged;
                _directoryLiveMonitor.Start();

                structureParametersSetComboBox.PopulateParameterSets(Path.Combine(projectDirectoryPath, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First()), true);

                programsProcessTableLayoutPanel.SetUnactivePrograms(ProjectInformationModel.Instance.UsedSubPrograms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetElementsEnableState(true, loadStructureDataFileLabel, loadStructureDataFileButton, structureDataFileNameLabel, structureDataFileNameTextBox);

            structureHarvesterMeanChartForm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            structureHarvesterPrimeChartForm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            structureHarvesterDoublePrimeChartForm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            structureHarvesterDeltaChartForm = new System.Windows.Forms.DataVisualization.Charting.Chart();

            tabPage2.Controls.Add(structureHarvesterMeanChartForm);
            tabPage2.Controls.Add(structureHarvesterDeltaChartForm);
            tabPage2.Controls.Add(structureHarvesterDoublePrimeChartForm);
            tabPage2.Controls.Add(structureHarvesterPrimeChartForm);

            // 
            // structureHarvesterMeanChartForm
            // 
            structureHarvesterMeanChartForm.Enabled = false;
            structureHarvesterMeanChartForm.Location = new System.Drawing.Point(6, 4);
            structureHarvesterMeanChartForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterMeanChartForm.Name = "structureHarvesterMeanChartForm";
            structureHarvesterMeanChartForm.Size = new System.Drawing.Size(500, 250);
            structureHarvesterMeanChartForm.TabIndex = 102;
            // 
            // structureHarvesterPrimeChartForm
            // 
            structureHarvesterPrimeChartForm.Enabled = false;
            structureHarvesterPrimeChartForm.Location = new System.Drawing.Point(524, 4);
            structureHarvesterPrimeChartForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterPrimeChartForm.Name = "structureHarvesterPrimeChartForm";
            structureHarvesterPrimeChartForm.Size = new System.Drawing.Size(500, 250);
            structureHarvesterPrimeChartForm.TabIndex = 111;
            //// 
            //// structureHarvesterDoublePrimeChartForm
            //// 
            structureHarvesterDoublePrimeChartForm.Enabled = false;
            structureHarvesterDoublePrimeChartForm.Location = new System.Drawing.Point(6, 261);
            structureHarvesterDoublePrimeChartForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterDoublePrimeChartForm.Name = "structureHarvesterDoublePrimeChartForm";
            structureHarvesterDoublePrimeChartForm.Size = new System.Drawing.Size(500, 250);
            structureHarvesterDoublePrimeChartForm.TabIndex = 112;
            //// 
            //// structureHarvesterDeltaChartForm
            //// 
            structureHarvesterDeltaChartForm.Enabled = false;
            structureHarvesterDeltaChartForm.Location = new System.Drawing.Point(524, 261);
            structureHarvesterDeltaChartForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterDeltaChartForm.Name = "structureHarvesterDeltaChartForm";
            structureHarvesterDeltaChartForm.Size = new System.Drawing.Size(500, 250);
            structureHarvesterDeltaChartForm.TabIndex = 113;

            EnableChartInteractions(structureHarvesterMeanChartForm);
            EnableChartInteractions(structureHarvesterPrimeChartForm);
            EnableChartInteractions(structureHarvesterDoublePrimeChartForm);
            EnableChartInteractions(structureHarvesterDeltaChartForm);

            distructExportTypeCheckedListBox.Items.Clear();
            foreach (DistructPSExportService.OutputFormat fmt in Enum.GetValues(typeof(DistructPSExportService.OutputFormat)))
            {
                distructExportTypeCheckedListBox.Items.Add(fmt, false);
            }

            structureMainparamsBindingSource.DataSource = StructureParametersModel.Instance;
            structureExtraparamsBindingSource.DataSource = StructureParametersModel.Instance;
            CLUMPPParametersModelBindingSource.DataSource = CLUMPPParametersModel.Instance;
            distructParametersModelBindingSource.DataSource = DistructParametersModel.Instance;

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string structureHarvesterFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(1));

            if (!_isNewProject)
            {
                try
                {
                    if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Structure")))
                    {
                        structureParametersSetComboBox.SelectedIndexChanged -= structureParametersSetComboBox_SelectedIndexChanged;

                        structureParametersSetComboBox.DataSource = null;
                        structureParametersSetComboBox.PopulateAndSelect(StructureConfigurationParametersManager.ParameterSetList, StructureConfigurationParametersManager.CurrentParameterSet.SetName);
                        structureConfigurationParametersBindingSource.DataSource = StructureConfigurationParametersManager.CurrentParameterSet;

                        SetElementsEnableState(StructureParametersModel.Instance.mainparams.PHASEINFO, linkageModelCheckBox);

                        SetElementsEnableState(true, chooseStructureParametersSetLabel, structureParametersSetComboBox, structureSetNameLabel, structureSetNameTextBox, runLenghtGroupBox, alleleFrequencyModelGroupBox, ancestryModelGroupBox, advancedGroupBox, structureKFromLabel, structureKFromNumericUpDown, structureKToLabel, structureKToNumericUpDown, structureWithLabel, structureIterationsNumericUpDown, structureIterationsLabel);

                        structureParametersSetComboBox.SelectedIndexChanged += structureParametersSetComboBox_SelectedIndexChanged;
                    }
                    if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Structure Harvester")))
                    {
                        structureHarvesterInputComboBox.SelectedIndexChanged -= structureHarvesterInputComboBox_SelectedIndexChanged;

                        structureHarvesterInputComboBox.PopulateAndSelect(StructureHarvesterConfigurationParametersManager.ParameterSetList, StructureHarvesterConfigurationParametersManager.CurrentParameterSet.SetName);
                        structureHarvesterConfigurationParametersBindingSource.DataSource = StructureHarvesterConfigurationParametersManager.CurrentParameterSet;

                        SetElementsEnableState(true, structureHarvesterInputComboBox, structureHarvesterClumppCheckBox, structureHarvesterEvannoCheckBox, structureHarvesterInputLabel, structureHarvesterLoadChartButton, structureHarvesterSetForChartComboBox, structureHarvesterSetForChartLabel);

                        structureHarvesterInputComboBox.SelectedIndexChanged += structureHarvesterInputComboBox_SelectedIndexChanged;
                    }
                    if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "CLUMPP")))
                    {
                        CLUMPPInputComboBox.SelectedIndexChanged -= CLUMPPInputComboBox_SelectedIndexChanged;

                        CLUMPPInputComboBox.PopulateAndSelect(CLUMPPConfigurationParametersManager.ParameterSetList, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);
                        CLUMPPConfigurationParametersBindingSource.DataSource = CLUMPPConfigurationParametersManager.CurrentParameterSet;

                        SetElementsEnableState(true, clumppOnlyPopRadioButton, clumppPopAndIndRadioButton, groupBox6, groupBox8, groupBox9, groupBox7, CLUMPPKFromLabel, CLUMPPKFromNumericUpDown, CLUMPPKToLabel, CLUMPPKToNumericUpDown, SaveCLUMPPParamSetButt);

                        PermutationFileText.Text = CLUMPPParametersModel.Instance.PERMUTATIONFILE;

                        CLUMPPInputComboBox.SelectedIndexChanged += CLUMPPInputComboBox_SelectedIndexChanged;
                    }
                    if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Distruct")))
                    {
                        distructInputComboBox.SelectedIndexChanged -= distructInputComboBox_SelectedIndexChanged;

                        distructInputComboBox.PopulateAndSelect(DistructConfigurationParametersManager.ParameterSetList, DistructConfigurationParametersManager.CurrentParameterSet.SetName);
                        distructConfigurationParametersBindingSource.DataSource = DistructConfigurationParametersManager.CurrentParameterSet;
                        string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
                        distructProcessedSetsToExportComboBox.PopulateParameterSets(distructFolder);

                        SetElementsEnableState(true, groupBox13, groupBox10, groupBox12, groupBox11, distructKFromLabel, distructKFromNumericUpDown, distructKToLabel, distructKToNumericUpDown, SaveDistructaParamSetButt, label1, distructPre_renderedComboBox, distructPre_renderedButton);

                        LabelsBelowFileNameText.Text = DistructParametersModel.Instance.INFILE_LABEL_BELOW;
                        inputFileOfLabelsAtop.Text = DistructParametersModel.Instance.INFILE_LABEL_ATOP;
                        PermutationOfClustersFileText.Text = DistructParametersModel.Instance.INFILE_CLUST_PERM;

                        if(Directory.Exists(Path.Combine(distructFolder, "Results")))
                        {
                            if (Directory.GetFiles(Path.Combine(distructFolder, "Results")).Count() > 0)
                            {
                                distructExportGroupBox.Enabled = true;
                            }
                        }
                        
                        distructInputComboBox.SelectedIndexChanged += distructInputComboBox_SelectedIndexChanged;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                structureConfigurationParametersBindingSource.DataSource = _structureConfigurationParametersModel;
                structureHarvesterConfigurationParametersBindingSource.DataSource = _structureHarvesterConfigurationParametersModel;
                CLUMPPConfigurationParametersBindingSource.DataSource = _CLUMPPConfigurationParametersModel;
                distructConfigurationParametersBindingSource.DataSource = _distructConfigurationParametersModel;
            }

            _structureCTS = new();
            _clumppCTS = new();
            _distructCTS = new();
        }

        private void loadStructureDataFileButton_Click(object sender, EventArgs e)
        {
            using LoadStructureDataFileWindow loadStructureDataFileWindow = new();
            loadStructureDataFileWindow.ShowDialog();

            if (loadStructureDataFileWindow.DialogResult == DialogResult.OK)
            {
                StructureParametersModel.Instance.mainparams.INFILE = StructureStartupPreparationService.OriginalDataFileName;

                SetElementsEnableState(true, chooseStructureParametersSetLabel, structureParametersSetComboBox, structureSetNameLabel, structureSetNameTextBox, runLenghtGroupBox, alleleFrequencyModelGroupBox, ancestryModelGroupBox, advancedGroupBox, structureKFromLabel, structureKFromNumericUpDown, structureKToLabel, structureKToNumericUpDown, structureWithLabel, structureIterationsNumericUpDown, structureIterationsLabel);

                SetElementsEnableState(StructureParametersModel.Instance.mainparams.PHASEINFO, linkageModelCheckBox);
            }
        }

        private void structureParametersSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (structureParametersSetComboBox.SelectedIndex <= 0)
            {
                _structureConfigurationParametersModel = new();
                StructureConfigurationParametersManager.CurrentParameterSet = _structureConfigurationParametersModel;
                structureConfigurationParametersBindingSource.DataSource = StructureConfigurationParametersManager.CurrentParameterSet;
                StructureConfigurationParametersManager.ParameterSetList.Add(StructureConfigurationParametersManager.CurrentParameterSet);
                structureSetNameTextBox.Clear();

                return;
            }

            var selectedSet = structureParametersSetComboBox.GetSelectedItem(StructureConfigurationParametersManager.ParameterSetList);

            StructureConfigurationParametersManager.CurrentParameterSet = selectedSet;

            structureConfigurationParametersBindingSource.DataSource = StructureConfigurationParametersManager.CurrentParameterSet;

            structureSetNameTextBox.Text = structureParametersSetComboBox.SelectedItem.ToString();

            try
            {
                var list = FilesManager.ReadFileToList(Path.Combine(StructureConfigurationParametersManager.StructureFolder, StructureConfigurationParametersManager.CurrentParameterSet.SetName), StructureConfigurationParametersManager.MainparamsFileName);

                StructureParametersModel.Instance.LoadFromLines(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void saveStructureParamButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(structureSetNameTextBox.Text))
                return;

            string projectDirectoryPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);

            try
            {
                StructureStartupPreparationService.Prepare();
                ProjectConfigurationService.SaveStructureConfig(projectDirectoryPath, _appLogger);


                structureParametersSetComboBox.SelectedIndexChanged -= structureParametersSetComboBox_SelectedIndexChanged;
                structureParametersSetComboBox.PopulateParameterSets(StructureConfigurationParametersManager.StructureFolder, true);
                structureParametersSetComboBox.SelectedIndexChanged += structureParametersSetComboBox_SelectedIndexChanged;
            }
            catch (ConfigSaveException)
            {
                MessageBox.Show($"Writing information about the parameter set {StructureConfigurationParametersManager.CurrentParameterSet.SetName} for Structure failed. Check the log file for more information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch { }


            structureParametersSetComboBox.SelectedItem = StructureConfigurationParametersManager.CurrentParameterSet.SetName;

            SetElementsEnableState(true, startStructureButton);
        }
        private void structureSetNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetElementsEnableState(!string.IsNullOrWhiteSpace(structureSetNameTextBox.Text), saveStructureParamButton);

            if (startStructureButton.Enabled)
            {
                bool isExist = false;
                foreach (string el in structureParametersSetComboBox.Items)
                {
                    if (el.Equals(structureDataFileNameTextBox.Text))
                        isExist = true;
                }
                if (!isExist)
                    startStructureButton.Enabled = false;
            }
        }
        private async void startStructureButton_Click(object sender, EventArgs e)
        {
            _structureCTS?.Dispose();
            _structureCTS = new CancellationTokenSource();


            saveStructureParamButton.Enabled = false;
            startStructureButton.Enabled = false;
            stopStructureButton.Enabled = true;

            string outputFolder = StructureConfigurationParametersManager.CurrentParameterSet.OutputFolder;
            int kStart = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
            int kEnd = StructureConfigurationParametersManager.CurrentParameterSet.KEnd;
            int iterations = StructureConfigurationParametersManager.CurrentParameterSet.Iterations;

            string projectDirectoryPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);

            try
            {
                DirectoriesManager.CreateDirectory(outputFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool finished = false;

            int p = 0;
            int lk = 0;
            int li = 0;

            try
            {
                StructureStartupService startupService = new StructureStartupService(kStart, kEnd, iterations, outputFolder);

                var progress = new Progress<ProgressReport>(r =>
                {
                    if (finished)
                        return;

                    int percent = (int)(r.Fraction * 100);
                    structureProgressBarTableLayoutPanel.Value = percent;
                    p = percent;
                    lk = r.LastK;
                    li = r.LastIter;
                    structureProgressBarTableLayoutPanel.OverlayText = $"Last K = {r.LastK}, last i = {r.LastIter} ({percent}%)";

                    if (r.CompletedJobs <= 0)
                        structureEtaLabelTableLayoutPanel.Text = "Calculating…";
                    else if (r.CompletedJobs >= r.TotalJobs)
                    {
                        structureProgressBarTableLayoutPanel.OverlayText = $"Last K = {kEnd}, last i = {iterations} (100%)";
                        structureProgressBarTableLayoutPanel.Value = structureProgressBarTableLayoutPanel.Maximum;
                        structureEtaLabelTableLayoutPanel.Text = "Done";
                    }
                    else
                        structureEtaLabelTableLayoutPanel.Text = "Time remaining ~" + r.Remaining.ToString(@"mm\:ss");

                    structureProgressBarTableLayoutPanel.Refresh();
                    structureEtaLabelTableLayoutPanel.Refresh();
                });

                await startupService.RunAsync(progress, _structureLogger, _structureCTS.Token);

                finished = true;

                stopStructureButton.Enabled = false;

                structureProgressBarTableLayoutPanel.Value = structureProgressBarTableLayoutPanel.Maximum;
                structureProgressBarTableLayoutPanel.OverlayText = $"Last K = {kEnd}, last i = {iterations} (100%)";
                structureEtaLabelTableLayoutPanel.Text = "Done";

                structureProgressBarTableLayoutPanel.Refresh();
                structureEtaLabelTableLayoutPanel.Refresh();

            }
            catch (OperationCanceledException)
            {
                structureProgressBarTableLayoutPanel.Value = p;
                structureProgressBarTableLayoutPanel.OverlayText = $"Last K = {lk}, last i = {li} ({p})%";
                structureEtaLabelTableLayoutPanel.Text = "Stopped";

                structureHarvesterProgressBarTableLayoutPanel.Refresh();
                structureHarvesterEtaLabelTableLayoutPanel.Refresh();

                finished = true;

                _structureLogger.Info("Structure was stopped.");
            }
            catch (Exception ex)
            {
                structureProgressBarTableLayoutPanel.Value = p;
                structureProgressBarTableLayoutPanel.OverlayText = $"Last K = {lk}, last i = {li} ({p})%";
                structureEtaLabelTableLayoutPanel.Text = "Error";

                structureHarvesterProgressBarTableLayoutPanel.Refresh();
                structureHarvesterEtaLabelTableLayoutPanel.Refresh();

                MessageBox.Show("Structure was crushed. Check log for more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Structure Harvester")))
            {
                try
                {
                    structureHarvesterInputComboBox.PopulateParameterSets(Path.Combine(projectDirectoryPath, ProjectInformationModel.Instance.UsedSubPrograms.Keys.First()));

                    int kMax, iMax;

                    (kMax, iMax) = FileSequenceScanner.FindMaxKi(StructureConfigurationParametersManager.CurrentParameterSet.OutputFolder);

                    StructureHarvesterConfigurationParametersManager.CurrentParameterSet.KEnd = kMax;
                    StructureHarvesterConfigurationParametersManager.CurrentParameterSet.IEnd = iMax;

                    if (kMax != 0 && iMax != 0)
                        SetElementsEnableState(true, structureHarvesterInputComboBox, structureHarvesterClumppCheckBox, structureHarvesterEvannoCheckBox, structureHarvesterInputLabel);
                    else
                    {
                        MessageBox.Show("There is no processed data, no further execution is possible.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SetElementsEnableState(false, startStructureHarvesterButton);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                saveStructureParamButton.Enabled = true;
                startStructureButton.Enabled = true;
                stopStructureButton.Enabled = false;
            }
        }
        private void structureHarvesterInputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (structureHarvesterInputComboBox.SelectedIndex == -1)
            {
                SetElementsEnableState(false, startStructureHarvesterButton, structureHarvesterSetForChartComboBox, structureHarvesterSetForChartLabel);
                return;
            }

            SetElementsEnableState(true, startStructureHarvesterButton);

            var selectedSet = structureHarvesterInputComboBox.GetSelectedItem(StructureHarvesterConfigurationParametersManager.ParameterSetList);

            if (selectedSet != default)
            {
                StructureHarvesterConfigurationParametersManager.CurrentParameterSet = _structureHarvesterConfigurationParametersModel;
                return;
            }

            _structureHarvesterConfigurationParametersModel = new();
            structureHarvesterConfigurationParametersBindingSource.DataSource = _structureHarvesterConfigurationParametersModel;
            _structureHarvesterConfigurationParametersModel.SetName = structureHarvesterInputComboBox.SelectedItem.ToString();
            StructureHarvesterConfigurationParametersManager.ParameterSetList.Add(_structureHarvesterConfigurationParametersModel);
            StructureHarvesterConfigurationParametersManager.CurrentParameterSet = _structureHarvesterConfigurationParametersModel;
        }
        private async void startStructureHarvesterButton_MouseClick(object sender, MouseEventArgs e)
        {
            startStructureHarvesterButton.Enabled = false;

            try
            {
                StructureHarvesterStartupPreparationService.Prepare();

                ProjectConfigurationService.SaveStructureHarvesterConfig(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName), _appLogger);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool finished = false;

            try
            {
                var progress = new Progress<HarvesterProgressReport>(r =>
                {
                    if (finished)
                        return;

                    int percent = (int)(r.Fraction * 100);
                    structureHarvesterProgressBarTableLayoutPanel.Value = percent;
                    structureHarvesterProgressBarTableLayoutPanel.OverlayText = $"{percent}%";

                    if (percent <= 0)
                        structureHarvesterEtaLabelTableLayoutPanel.Text = "Calculating…";
                    else if (percent >= 100)
                    {
                        structureHarvesterProgressBarTableLayoutPanel.OverlayText = "(100%)";
                        structureHarvesterProgressBarTableLayoutPanel.Value = structureHarvesterProgressBarTableLayoutPanel.Maximum;
                        structureHarvesterEtaLabelTableLayoutPanel.Text = "Done";
                    }
                    else
                        structureHarvesterEtaLabelTableLayoutPanel.Text = "Time remaining ~" + r.Remaining.ToString(@"mm\:ss");

                    structureHarvesterProgressBarTableLayoutPanel.Refresh();
                    structureHarvesterEtaLabelTableLayoutPanel.Refresh();
                });

                await StructureHarvesterStartupService.Instance.RunAsync(progress, _structureHarvesterLogger, CancellationToken.None);

                finished = true;

                structureHarvesterProgressBarTableLayoutPanel.Value = structureHarvesterProgressBarTableLayoutPanel.Maximum;
                structureHarvesterProgressBarTableLayoutPanel.OverlayText = "(100%)";
                structureHarvesterEtaLabelTableLayoutPanel.Text = "Done";

                structureHarvesterProgressBarTableLayoutPanel.Refresh();
                structureHarvesterEtaLabelTableLayoutPanel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Structure Harvester was crushed. Check log for more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            startStructureHarvesterButton.Enabled = true;

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string structureHarvesterFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(1));

            int numOfPop = 0;
            int? numOfIndiv = 0;

            try
            {
                numOfPop = StructureHarvesterConfigurationParametersManager.GetPopCountFromOutputFile(StructureConfigurationParametersManager.CurrentParameterSet.KStart, StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath);
                numOfIndiv = StructureHarvesterConfigurationParametersManager.GetIndivCountFromOutputFile(StructureConfigurationParametersManager.CurrentParameterSet.KStart, StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "CLUMPP")))
            {
                try
                {
                    CLUMPPParametersModel.Instance.NumOfPop = numOfPop;
                    CLUMPPParametersModel.Instance.NumOfInd = numOfIndiv ?? 0;

                    CLUMPPInputComboBox.PopulateParameterSets(structureHarvesterFolder);

                    CLUMPPParametersModel.Instance.R = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.IEnd;

                    BindingContext[CLUMPPParametersModel.Instance].ResumeBinding();

                    CLUMPPKFromNumericUpDown.Minimum = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
                    CLUMPPKFromNumericUpDown.Maximum = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.KEnd;
                    CLUMPPKToNumericUpDown.Minimum = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
                    CLUMPPKToNumericUpDown.Maximum = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.KEnd;

                    _CLUMPPConfigurationParametersModel.KStart = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
                    _CLUMPPConfigurationParametersModel.KEnd = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.KEnd;

                    _CLUMPPConfigurationParametersModel.SetName = StructureHarvesterConfigurationParametersManager.CurrentParameterSet.SetName;

                    string CLUMPPFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));
                    string parametersPath = Path.Combine(CLUMPPFolder, CLUMPPInputComboBox.SelectedItem.ToString());

                    CLUMPPParametersComboBox.PopulateParameterSets(parametersPath, true);

                    SetElementsEnableState(true, clumppOnlyPopRadioButton, clumppPopAndIndRadioButton, groupBox6, groupBox8, groupBox9, groupBox7, CLUMPPKFromLabel, CLUMPPKFromNumericUpDown, CLUMPPKToLabel, CLUMPPKToNumericUpDown, SaveCLUMPPParamSetButt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Distruct")))
            {
                try
                {
                    DistructParametersModel.Instance.NUMPOPS = numOfPop;
                    DistructParametersModel.Instance.NUMINDS = numOfIndiv ?? 0;

                    BindingContext[DistructParametersModel.Instance].ResumeBinding();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            try
            {
                structureHarvesterSetForChartComboBox.PopulateParameterSets(structureHarvesterFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SetElementsEnableState(true, structureHarvesterLoadChartButton, structureHarvesterSetForChartComboBox, structureHarvesterSetForChartLabel);
        }
        private static void EnableChartInteractions(Chart ch)
        {
            ch.TabStop = true;
            ch.MouseEnter += (s, e) => ch.Focus();

            ch.MouseWheel += Chart_MouseWheel;
            ch.MouseDown += Chart_MouseDown;
            ch.MouseMove += Chart_MouseMove;
            ch.MouseUp += Chart_MouseUp;
        }
        private class PanState
        {
            public bool IsPanning;
            public bool SelX, SelY;
            public Point StartPixel;
            public double X0min, X0max, Y0min, Y0max;
        }
        private static void Chart_MouseDown(object s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var chart = (Chart)s;
            var area = chart.ChartAreas[0];

            bool ctrl = (ModifierKeys & Keys.Control) != 0;

            if (ctrl)   // ─── Ctrl-панорамирование ──────────────────────────────
            {
                chart.Tag = new PanState
                {
                    IsPanning = true,
                    StartPixel = e.Location,
                    X0min = area.AxisX.ScaleView.IsZoomed ? area.AxisX.ScaleView.ViewMinimum : area.AxisX.Minimum,
                    X0max = area.AxisX.ScaleView.IsZoomed ? area.AxisX.ScaleView.ViewMaximum : area.AxisX.Maximum,
                    Y0min = area.AxisY.ScaleView.IsZoomed ? area.AxisY.ScaleView.ViewMinimum : area.AxisY.Minimum,
                    Y0max = area.AxisY.ScaleView.IsZoomed ? area.AxisY.ScaleView.ViewMaximum : area.AxisY.Maximum,
                    SelX = area.CursorX.IsUserSelectionEnabled,
                    SelY = area.CursorY.IsUserSelectionEnabled
                };

                // временно отключаем прямоугольник-выделения
                area.CursorX.IsUserSelectionEnabled =
                area.CursorY.IsUserSelectionEnabled = false;

                chart.Cursor = Cursors.Hand;
            }
            /* иначе ничего не трогаем — работает стандартное
               прямоугольное выделение области */
        }

        private static void Chart_MouseMove(object s, MouseEventArgs e)
        {
            if (!(s is Chart chart) || !(chart.Tag is PanState ps) || !ps.IsPanning)
                return;

            var area = chart.ChartAreas[0];

            double x0 = area.AxisX.PixelPositionToValue(ps.StartPixel.X);
            double x1 = area.AxisX.PixelPositionToValue(e.Location.X);
            double dx = x0 - x1;

            double y0 = area.AxisY.PixelPositionToValue(ps.StartPixel.Y);
            double y1 = area.AxisY.PixelPositionToValue(e.Location.Y);
            double dy = y0 - y1;

            double newXmin = ps.X0min + dx;
            double newXmax = ps.X0max + dx;
            double newYmin = ps.Y0min + dy;
            double newYmax = ps.Y0max + dy;

            // не уходим за пределы данных
            if (newXmin < area.AxisX.Minimum) { newXmax += area.AxisX.Minimum - newXmin; newXmin = area.AxisX.Minimum; }
            if (newXmax > area.AxisX.Maximum) { newXmin -= newXmax - area.AxisX.Maximum; newXmax = area.AxisX.Maximum; }
            if (newYmin < area.AxisY.Minimum) { newYmax += area.AxisY.Minimum - newYmin; newYmin = area.AxisY.Minimum; }
            if (newYmax > area.AxisY.Maximum) { newYmin -= newYmax - area.AxisY.Maximum; newYmax = area.AxisY.Maximum; }

            area.AxisX.ScaleView.Zoom(newXmin, newXmax);
            area.AxisY.ScaleView.Zoom(newYmin, newYmax);
        }

        private static void Chart_MouseUp(object s, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var chart = (Chart)s;
            if (chart.Tag is PanState ps && ps.IsPanning)
            {
                var area = chart.ChartAreas[0];
                area.CursorX.IsUserSelectionEnabled = ps.SelX; // возвращаем, как было
                area.CursorY.IsUserSelectionEnabled = ps.SelY;

                chart.Cursor = Cursors.Default;
            }
            chart.Tag = null;
        }

        private static void Chart_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            if (chart.ChartAreas.Count == 0) return;

            var ca = chart.ChartAreas[0];

            // Координаты точки под курсором в осях графика
            double xValue = ca.AxisX.PixelPositionToValue(e.Location.X);
            double yValue = ca.AxisY.PixelPositionToValue(e.Location.Y);

            // Текущий диапазон отображаемого окна
            double xStart = ca.AxisX.ScaleView.IsZoomed ? ca.AxisX.ScaleView.ViewMinimum : ca.AxisX.Minimum;
            double xFinish = ca.AxisX.ScaleView.IsZoomed ? ca.AxisX.ScaleView.ViewMaximum : ca.AxisX.Maximum;
            double yStart = ca.AxisY.ScaleView.IsZoomed ? ca.AxisY.ScaleView.ViewMinimum : ca.AxisY.Minimum;
            double yFinish = ca.AxisY.ScaleView.IsZoomed ? ca.AxisY.ScaleView.ViewMaximum : ca.AxisY.Maximum;

            double xRange = xFinish - xStart;
            double yRange = yFinish - yStart;

            // колесо вверх — приблизить (уменьшить окно), вниз — отдалить
            const double zoomStepIn = 0.8;   // 20 % ближе
            const double zoomStepOut = 1.25;  // 25 % дальше
            double factor = e.Delta > 0 ? zoomStepIn : zoomStepOut;

            double newXSize = xRange * factor;
            double newYSize = yRange * factor;

            double newXMin = xValue - newXSize / 2;
            double newXMax = xValue + newXSize / 2;
            double newYMin = yValue - newYSize / 2;
            double newYMax = yValue + newYSize / 2;

            // не выходим за пределы исходных данных
            newXMin = Math.Max(newXMin, ca.AxisX.Minimum);
            newXMax = Math.Min(newXMax, ca.AxisX.Maximum);
            newYMin = Math.Max(newYMin, ca.AxisY.Minimum);
            newYMax = Math.Min(newYMax, ca.AxisY.Maximum);

            // если «расшатали» график почти до исходного размера — сбрасываем
            bool zoomingOut = e.Delta < 0 &&
                              (newXMax - newXMin) >= (ca.AxisX.Maximum - ca.AxisX.Minimum) * 0.99;

            if (zoomingOut)
            {
                ca.AxisX.ScaleView.ZoomReset(0);
                ca.AxisY.ScaleView.ZoomReset(0);
            }
            else
            {
                ca.AxisX.ScaleView.Zoom(newXMin, newXMax);
                ca.AxisY.ScaleView.Zoom(newYMin, newYMax);
            }
        }

        private void structureHarvesterLoadChartButton_Click(object sender, EventArgs e)
        {
            try
            {
                HarvesterChartForm.LoadCharts(structureHarvesterMeanChartForm, structureHarvesterPrimeChartForm, structureHarvesterDoublePrimeChartForm, structureHarvesterDeltaChartForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is not enough data to build graphs. Try running Structure for a larger K value and iteration values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            structureHarvesterMeanChartForm.Enabled = true;
            structureHarvesterPrimeChartForm.Enabled = true;
            structureHarvesterDoublePrimeChartForm.Enabled = true;
            structureHarvesterDeltaChartForm.Enabled = true;
        }
        private void CLUMPPInputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSet = CLUMPPInputComboBox.GetSelectedItem(CLUMPPConfigurationParametersManager.ParameterSetList);

            if (selectedSet == default)
            {
                _CLUMPPConfigurationParametersModel = new();
                CLUMPPConfigurationParametersBindingSource.DataSource = _CLUMPPConfigurationParametersModel;
                _CLUMPPConfigurationParametersModel.SetName = CLUMPPInputComboBox.SelectedItem.ToString();

                CLUMPPConfigurationParametersManager.CurrentParameterSet = _CLUMPPConfigurationParametersModel;
                CLUMPPConfigurationParametersManager.ParameterSetList.Add(_CLUMPPConfigurationParametersModel);
                return;
            }

            CLUMPPConfigurationParametersManager.CurrentParameterSet = selectedSet;
            CLUMPPConfigurationParametersBindingSource.DataSource = CLUMPPConfigurationParametersManager.CurrentParameterSet;

            try
            {
                var list = FilesManager.ReadFileToList(Path.Combine(CLUMPPConfigurationParametersManager.CLUMPPFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName), CLUMPPConfigurationParametersManager.CurrentParameterSet.CurrentParamFile);

                CLUMPPParametersModel.Instance.LoadFromLines(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void SaveCLUMPPParamSetButt_MouseClick(object sender, MouseEventArgs e)
        {
            CLUMPPConfigurationParametersManager.CurrentParameterSet = _CLUMPPConfigurationParametersModel;
            CLUMPPConfigurationParametersManager.ParameterSetList.Add(_CLUMPPConfigurationParametersModel);

            try
            {
                CLUMPPStartupPreparationService.Prepare(clumppOnlyPopRadioButton.Checked);
                ProjectConfigurationService.SaveClumppConfig(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName), _appLogger);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartCLUMPPButt.Enabled = true;
        }
        private async void StartCLUMPPButt_MouseClick(object sender, MouseEventArgs e)
        {
            if (CLUMPPParametersModel.Instance.M == 0)
            {
                if (CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd > 6 || CLUMPPParametersModel.Instance.R > 15)
                {
                    MessageBox.Show($"For these values of iterations and K, the data processing process with the \"Full search\" algorithm can take a long time. It may be worth changing the algorithm to {((CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd >= 15) ? "\"LargeKGreedy\"" : "\"Greedy\"")}. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (DialogResult == DialogResult.No)
                        return;
                }
            }
            else if (CLUMPPParametersModel.Instance.M == 1)
            {
                if (CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd >= 15)
                {
                    MessageBox.Show($"For these values of iterations and K, the data processing process with the \"Greedy\" algorithm can take a long time. It may be worth changing the algorithm to \"LargeKGreedy\". Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (DialogResult == DialogResult.No)
                        return;
                }
            }

            _clumppCTS?.Dispose();
            _clumppCTS = new CancellationTokenSource();

            SaveCLUMPPParamSetButt.Enabled = false;
            StartCLUMPPButt.Enabled = false;
            clumppStopButton.Enabled = true;

            bool finished = false;

            try
            {
                var progress = new Progress<ProgressRegistry.ClumppProgressReport>(r =>
                {
                    if (finished)
                        return;

                    int percent = (int)(r.Fraction * 100);
                    clumppProgressBarTableLayoutPanel.Value = percent;
                    clumppProgressBarTableLayoutPanel.OverlayText = $"Last K = {r.LastK} ({percent}%)";

                    if (r.CompletedJobs <= 0)
                        CLUMPPEtaLabelTableLayoutPanel.Text = "Calculating…";
                    else if (r.CompletedJobs >= r.TotalJobs)
                    {
                        clumppProgressBarTableLayoutPanel.OverlayText = $"Last K = {CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd} (100%)";
                        clumppProgressBarTableLayoutPanel.Value = clumppProgressBarTableLayoutPanel.Maximum;
                        CLUMPPEtaLabelTableLayoutPanel.Text = "Done";
                    }
                    else
                        CLUMPPEtaLabelTableLayoutPanel.Text = "Time remaining ~" + r.Remaining.ToString(@"hh\:mm\:ss");

                    clumppProgressBarTableLayoutPanel.Refresh();
                    CLUMPPEtaLabelTableLayoutPanel.Refresh();

                });

                await CLUMPPStartupService.Instance.RunAsync(_CLUMPPLogger, clumppOnlyPopRadioButton.Checked, progress, _clumppCTS.Token);

                finished = true;

                clumppProgressBarTableLayoutPanel.Value = clumppProgressBarTableLayoutPanel.Maximum;
                clumppProgressBarTableLayoutPanel.OverlayText = $"Last K = {CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd} (100%)";
                CLUMPPEtaLabelTableLayoutPanel.Text = "Done";

                clumppProgressBarTableLayoutPanel.Refresh();
                CLUMPPEtaLabelTableLayoutPanel.Refresh();
            }
            catch (OperationCanceledException oce)
            {
                _CLUMPPLogger.Info("CLUMPP was stopped.");
                finished = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CLUMPP was crushed. Check log for more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SaveCLUMPPParamSetButt.Enabled = true;
            StartCLUMPPButt.Enabled = true;
            clumppStopButton.Enabled = false;

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string CLUMPPFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(2));

            if (Directory.Exists(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName, "Distruct")))
            {
                try
                {
                    distructInputComboBox.PopulateParameterSets(CLUMPPFolder);

                    int maxKPop, maxKindiv;

                    (maxKPop, maxKindiv) = FileSequenceScanner.FindMaxKByType(Path.Combine(CLUMPPFolder, distructInputComboBox.SelectedItem.ToString()));

                    distructKFromNumericUpDown.Minimum = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
                    distructKFromNumericUpDown.Maximum = maxKPop;
                    distructKToNumericUpDown.Minimum = StructureConfigurationParametersManager.CurrentParameterSet.KStart;
                    distructKToNumericUpDown.Maximum = maxKPop;

                    _distructConfigurationParametersModel.KStart = CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart;
                    _distructConfigurationParametersModel.KEnd = maxKPop;

                    _distructConfigurationParametersModel.SetName = distructInputComboBox.SelectedItem.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
                string parametersPath = Path.Combine(distructFolder, CLUMPPInputComboBox.SelectedItem.ToString());

                try
                {
                    distructParametersComboBox.PopulateParameterSets(parametersPath, true);

                    distructPre_renderedComboBox.PopulateByNumberRange(CLUMPPConfigurationParametersManager.CurrentParameterSet.KStart, CLUMPPConfigurationParametersManager.CurrentParameterSet.KEnd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                PrintIndividCheck.Enabled = !clumppOnlyPopRadioButton.Checked;

                SetElementsEnableState(true, groupBox13, groupBox10, groupBox12, groupBox11, distructKFromLabel, distructKFromNumericUpDown, distructKToLabel, distructKToNumericUpDown, SaveDistructaParamSetButt, label1, distructPre_renderedComboBox, distructPre_renderedButton);
            }
        }
        private void distructInputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSet = distructInputComboBox.GetSelectedItem(DistructConfigurationParametersManager.ParameterSetList);

            if (selectedSet == default)
            {
                _distructConfigurationParametersModel = new();
                distructConfigurationParametersBindingSource.DataSource = _distructConfigurationParametersModel;
                _distructConfigurationParametersModel.SetName = CLUMPPInputComboBox.SelectedItem.ToString();

                DistructConfigurationParametersManager.CurrentParameterSet = _distructConfigurationParametersModel;
                DistructConfigurationParametersManager.ParameterSetList.Add(_distructConfigurationParametersModel);
                return;
            }

            DistructConfigurationParametersManager.CurrentParameterSet = selectedSet;
            distructConfigurationParametersBindingSource.DataSource = DistructConfigurationParametersManager.CurrentParameterSet;

            try
            {
                var list = FilesManager.ReadFileToList(Path.Combine(DistructConfigurationParametersManager.DistructFolder, DistructConfigurationParametersManager.CurrentParameterSet.SetName), DistructConfigurationParametersManager.CurrentParameterSet.CurrentParamFile);

                DistructParametersModel.Instance.LoadFromLines(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void distructParametersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SaveDistructaParamSetButt_Click(object sender, EventArgs e)
        {
            try
            {
                DistructStartupPreparationsService.Prepare();
                ProjectConfigurationService.SaveDistructConfig(Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName), _appLogger);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartDistructaButt.Enabled = true;
        }

        private async void StartDistructaButt_ClickAsync(object sender, EventArgs e)
        {
            _distructCTS?.Dispose();
            _distructCTS = new CancellationTokenSource();

            SaveDistructaParamSetButt.Enabled = false;
            StartDistructaButt.Enabled = false;
            distructStopButton.Enabled = true;

            bool finished = false;
            try
            {
                var progress = new Progress<DistructProgressReport>(r =>
                {
                    if (finished)
                        return;

                    int percent = (int)(r.CompletedJobs / (double)r.TotalJobs * 100);
                    distructProgressBarTableLayoutPanel.Value = percent;
                    distructProgressBarTableLayoutPanel.OverlayText = $"Last K = {r.LastK} ({percent}%)";

                    if (r.CompletedJobs >= r.TotalJobs)
                    {
                        distructProgressBarTableLayoutPanel.OverlayText = $"Last K = {DistructConfigurationParametersManager.CurrentParameterSet.KEnd} (100%)";
                        distructProgressBarTableLayoutPanel.Value = distructProgressBarTableLayoutPanel.Maximum;
                        distructEtaLabelTableLayoutPanel.Text = "Done";
                    }
                    else if (r.CompletedJobs <= 0)
                        distructEtaLabelTableLayoutPanel.Text = "Calculating…";
                    else
                    {
                        distructEtaLabelTableLayoutPanel.Text = "Time remaining ~" + r.Remaining.ToString(@"mm\:ss");
                    }

                    distructProgressBarTableLayoutPanel.Refresh();
                    distructEtaLabelTableLayoutPanel.Refresh();
                });

                await DistructStartupService.Instance.RunAsync(progress, DistructConfigurationParametersManager.CurrentParameterSet.KStart, DistructConfigurationParametersManager.CurrentParameterSet.KEnd, _distructLogger, false, _distructCTS.Token);

                finished = true;
                progress = null;

                distructProgressBarTableLayoutPanel.Value = distructProgressBarTableLayoutPanel.Maximum;
                distructProgressBarTableLayoutPanel.OverlayText = $"Last K = {DistructConfigurationParametersManager.CurrentParameterSet.KEnd} (100%)";
                distructEtaLabelTableLayoutPanel.Text = "Done";

                distructProgressBarTableLayoutPanel.Refresh();
                distructEtaLabelTableLayoutPanel.Refresh();
            }
            catch (OperationCanceledException)
            {
                finished = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Distruct was crushed. Check log for more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SaveDistructaParamSetButt.Enabled = true;
            StartDistructaButt.Enabled = true;
            distructStopButton.Enabled = false;

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
            string resultFolder = Path.Combine(distructFolder, distructInputComboBox.SelectedItem.ToString(), "Results");

            try
            {
                distructProcessedSetsToExportComboBox.PopulateParameterSets(distructFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Directory.GetFiles(resultFolder).Count() > 0)
            {
                distructExportGroupBox.Enabled = true;
            }
        }
        private async void distructExportButton_Click(object sender, EventArgs e)
        {
            var selectedFormats = distructExportTypeCheckedListBox.CheckedItems.Cast<DistructPSExportService.OutputFormat>();

            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));

            var selectedParametersSet = distructProcessedSetsToExportComboBox.GetSelectedItem(DistructConfigurationParametersManager.ParameterSetList);

            string setFolder = Path.Combine(distructFolder, selectedParametersSet.SetName);
            string exportResultsFolder = Path.Combine(setFolder, "Exported");

            string dllPath = DistructPSExportConfigurationModel.DllGhostscriptPath;
            string libPath = DistructPSExportConfigurationModel.LibGhostscriptPath;
            string psFolder = Path.Combine(setFolder, "Results");

            int kStart = selectedParametersSet.KStart;
            int kEnd = selectedParametersSet.KEnd;

            DistructPSExportService.PageOrientation orientation;

            switch (OrientationChoose.SelectedIndex)
            {
                case 0:
                    orientation = DistructPSExportService.PageOrientation.Landscape;
                    break;
                case 1:
                    orientation = DistructPSExportService.PageOrientation.Portrait;
                    break;
                case 2:
                    orientation = DistructPSExportService.PageOrientation.Seascape;
                    break;
                case 3:
                    orientation = DistructPSExportService.PageOrientation.ReversePortrait;
                    break;
                default:
                    orientation = DistructPSExportService.PageOrientation.Landscape;
                    break;
            }

            try
            {
                DistructPSExportPreparationsService.Prepare(selectedParametersSet.SetName);
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                await DistructPSExportService.ExportRangeAsync(dllPath, libPath, psFolder, kStart, kEnd, selectedFormats, orientation, exportResultsFolder);
            }
            catch
            {

            }


        }
        private async void distructPre_renderedButton_Click(object sender, EventArgs e)
        {
            string projectFolder = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
            string distructFolder = Path.Combine(projectFolder, ProjectInformationModel.Instance.UsedSubPrograms.Keys.ElementAt(3));
            string setFolder = Path.Combine(distructFolder, CLUMPPConfigurationParametersManager.CurrentParameterSet.SetName);
            string exportResultsFolder = Path.Combine(setFolder, "Exported");
            string tmpExportedFolder = Path.Combine(setFolder, "tmp");

            string dllPath = DistructPSExportConfigurationModel.DllGhostscriptPath;
            string libPath = DistructPSExportConfigurationModel.LibGhostscriptPath;
            string psFolder = Path.Combine(setFolder, "Results");

            int k = 0;
            if (int.TryParse(distructPre_renderedComboBox.SelectedItem.ToString(), out int x))
            {
                k = x;
            }
            else return;

            try
            {
                DistructStartupPreparationsService.Prepare(true);
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                var progress = new Progress<DistructProgressReport>();
                await DistructStartupService.Instance.RunAsync(progress, k, k, _distructLogger, true, CancellationToken.None);
            }
            catch
            {

            }

            DistructPSExportService.PageOrientation orientation;

            switch (OrientationChoose.SelectedIndex)
            {
                case 0:
                    orientation = DistructPSExportService.PageOrientation.Landscape;
                    break;
                case 1:
                    orientation = DistructPSExportService.PageOrientation.Portrait;
                    break;
                case 2:
                    orientation = DistructPSExportService.PageOrientation.Seascape;
                    break;
                case 3:
                    orientation = DistructPSExportService.PageOrientation.ReversePortrait;
                    break;
                default:
                    orientation = DistructPSExportService.PageOrientation.Landscape;
                    break;
            }

            try
            {
                await DistructPSExportService.ExportRangeAsync(dllPath, libPath, tmpExportedFolder, k, k, new[] { DistructPSExportService.OutputFormat.PNG }, orientation, tmpExportedFolder, true);
            }
            catch
            {

            }

            string tempPngPath = Path.Combine(tmpExportedFolder, $"K{k}_tmp.png");

            try
            {
                using var img = new MagickImage(tempPngPath);
                img.Trim();
                distructPre_renderedPictureBox.Image?.Dispose();
                distructPre_renderedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                distructPre_renderedPictureBox.Image = img.ToBitmap();

                img.Write(tempPngPath, MagickFormat.Png);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ChooseFileBelowButt_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "Choose INFILE LABEL BELOW for Distruct...";

            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                LabelsBelowFileNameText.Text = fileDialog.FileName;
            }
        }
        private void ChooseFileAtopButt_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "Choose INFILE LABEL ATOP for Distruct...";

            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                inputFileOfLabelsAtop.Text = fileDialog.FileName;
            }
        }

        private void ChooseFilePermutaButt_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "Choose INFILE CLUST PERM for Distruct...";

            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                PermutationOfClustersFileText.Text = fileDialog.FileName;
            }
        }
        private void OnDirectoriesChanged(IEnumerable<string> parentPaths)
        {
            if (currentProjectFoldersTreeView.InvokeRequired)
            {
                currentProjectFoldersTreeView.BeginInvoke(new Action(() =>
                {
                    foreach (var path in parentPaths)
                        currentProjectFoldersTreeView.UpdateNode(path);
                }));
            }
            else
            {
                foreach (var path in parentPaths)
                    currentProjectFoldersTreeView.UpdateNode(path);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _directoryLiveMonitor.Stop();

            base.OnFormClosed(e);
            _showOnClose.Show();
        }

        private void stopStructureButton_Click(object sender, EventArgs e)
        {
            _structureCTS.Cancel();
        }

        private void clumppStopButton_Click(object sender, EventArgs e)
        {
            _clumppCTS.Cancel();
        }

        private void distructStopButton_Click(object sender, EventArgs e)
        {
            _distructCTS.Cancel();
        }

        private void MethodUsedChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnableM = !(MethodUsedChoose.SelectedIndex == 0);
            bool isEnableGO = !(GreedyOptionChoose.SelectedIndex == 0);

            RepeatsNum.Enabled = isEnableM && isEnableGO;
            clumppRepeatsLabel.Enabled = isEnableM && isEnableGO;
            GreedyOptionChoose.Enabled = isEnableM;
            clumppGreedyOptionLabel.Enabled = isEnableM;
            ChooseButt.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
            clumppPermutationFilelabel.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
            PermutationFileText.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
        }

        private void GreedyOptionChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLUMPPParametersModel.Instance.GREADY_OPTION = GreedyOptionChoose.SelectedIndex;

            bool isEnableM = !(MethodUsedChoose.SelectedIndex == 0);
            bool isEnableGO = !(GreedyOptionChoose.SelectedIndex == 0);

            RepeatsNum.Enabled = isEnableM && isEnableGO;
            clumppRepeatsLabel.Enabled = isEnableM && isEnableGO;
            ChooseButt.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
            clumppPermutationFilelabel.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
            PermutationFileText.Enabled = isEnableM && GreedyOptionChoose.SelectedIndex == 2;
        }

        private void clumppPopAndIndRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            clumppWCheckBox.Enabled = clumppPopAndIndRadioButton.Checked;
            if (!clumppPopAndIndRadioButton.Checked)
                clumppWCheckBox.Checked = false;
        }

        private void PrintLabelsBelowCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isBelow = PrintLabelsBelowCheck.Checked;

            distructPrintLabelBelowLabel.Enabled = isBelow;
            LabelsBelowFileNameText.Enabled = isBelow;
            ChooseFileBelowButt.Enabled = isBelow;
        }

        private void PrintLabelsAboveCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isAtop = PrintLabelsAboveCheck.Checked;

            distructLabelAtopLabel.Enabled = isAtop;
            inputFileOfLabelsAtop.Enabled = isAtop;
            ChooseFileAtopButt.Enabled = isAtop;
        }

        private void PrintLinesToSeparateCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isSep = PrintLinesToSeparateCheck.Checked;
            label84.Enabled = isSep;
            SeparatorsWidthNum.Enabled = isSep;
        }

        private void OrientationChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintThePOPQCheck.Enabled = OrientationChoose.SelectedIndex == 0;
        }

        private void noAdmixtureModelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isNoAdmx = noAdmixtureModelCheckBox.Checked;
            groupBox3.Enabled = !isNoAdmx;

            if (linkageModelCheckBox.Checked && linkageModelCheckBox.Enabled)
            {
                linkageModelCheckBox.CheckedChanged -= linkageModelCheckBox_CheckedChanged;
                linkageModelCheckBox.Checked = false;
                linkageModelCheckBox.CheckedChanged += linkageModelCheckBox_CheckedChanged;
            }

            if (usePriorPopInfoCheckBox.Checked)
            {
                usePriorPopInfoCheckBox.CheckedChanged -= usePriorPopInfoCheckBox_CheckedChanged;
                usePriorPopInfoCheckBox.Checked = false;
                usePriorPopInfoCheckBox.CheckedChanged += usePriorPopInfoCheckBox_CheckedChanged;
            }
        }

        private void locationInfoUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            locPriorModelGroupBox.Enabled = locationInfoUseCheckBox.Checked;
        }

        private void usePriorPopInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isUsePrior = usePriorPopInfoCheckBox.Checked;
            priorPopInformationGroupBox.Enabled = isUsePrior;

            if (linkageModelCheckBox.Checked && linkageModelCheckBox.Enabled)
            {
                linkageModelCheckBox.CheckedChanged -= linkageModelCheckBox_CheckedChanged;
                linkageModelCheckBox.Checked = false;
                linkageModelCheckBox.CheckedChanged += linkageModelCheckBox_CheckedChanged;
            }

            if (noAdmixtureModelCheckBox.Checked)
            {
                noAdmixtureModelCheckBox.CheckedChanged -= noAdmixtureModelCheckBox_CheckedChanged;
                noAdmixtureModelCheckBox.Checked = false;
                noAdmixtureModelCheckBox.CheckedChanged += noAdmixtureModelCheckBox_CheckedChanged;
            }
        }

        private void alleleFrequencisAreCorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isCorr = alleleFrequencisAreCorCheckBox.Checked;
            assumeSameValueCheckBox.Enabled = isCorr; label50.Enabled = isCorr; priorMeanNumericUpDown.Enabled = isCorr;
            label49.Enabled = isCorr; priorSDNumericUpDown.Enabled = isCorr;
        }
        private void linkageModelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isUseLink = linkageModelCheckBox.Checked;
            linkageModelGroupBox.Enabled = isUseLink;

            if (noAdmixtureModelCheckBox.Checked)
            {
                noAdmixtureModelCheckBox.CheckedChanged -= noAdmixtureModelCheckBox_CheckedChanged;
                noAdmixtureModelCheckBox.Checked = false;
                noAdmixtureModelCheckBox.CheckedChanged += noAdmixtureModelCheckBox_CheckedChanged;
            }

            if (usePriorPopInfoCheckBox.Checked)
            {
                usePriorPopInfoCheckBox.CheckedChanged -= usePriorPopInfoCheckBox_CheckedChanged;
                usePriorPopInfoCheckBox.Checked = !isUseLink;
                usePriorPopInfoCheckBox.CheckedChanged += usePriorPopInfoCheckBox_CheckedChanged;
            }

        }

        private void SetLambdaCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isSet = SetLambdaCheck.Checked;
            SetLambdaNum.Enabled = isSet;

            InferLambdaCheck.CheckedChanged -= InferLambdaCheck_CheckedChanged;
            InferLambdaCheck.Checked = !isSet;
            InferLambdaCheck.CheckedChanged += InferLambdaCheck_CheckedChanged;

            label29.Enabled = !isSet; initLambdaNum.Enabled = !isSet;

            inferSeparateLambdaCheckBox.Checked = !isSet;

            inferSeparateLambdaCheckBox.Enabled = !isSet;
        }

        private void InferLambdaCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isInfer = InferLambdaCheck.Checked;
            SetLambdaNum.Enabled = !isInfer;

            label29.Enabled = isInfer; initLambdaNum.Enabled = isInfer;
            inferSeparateLambdaCheckBox.Enabled = isInfer;

            SetLambdaCheck.CheckedChanged -= SetLambdaCheck_CheckedChanged;
            SetLambdaCheck.Checked = !isInfer;
            SetLambdaCheck.CheckedChanged += SetLambdaCheck_CheckedChanged;
        }

        private void printQhatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isQ = printQhatCheckBox.Checked;
            label5.Enabled = isQ;
            printUpdateFreqNumericUpDown.Enabled = isQ;
        }

        private void randomizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isRand = randomizeCheckBox.Checked;
            label28.Enabled = isRand;
            seedNumericUpDown.Enabled = isRand;
        }

        private void printCredibleRegCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isCred = printCredibleRegCheckBox.Checked;

            label22.Enabled = isCred;
            numboxesNumericUpDown.Enabled = isCred;
            label12.Enabled = isCred;
            ancestpintNumericUpDown.Enabled = isCred;
        }

        private void SetAlphaCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isSet = SetAlphaCheck.Checked;
            SetAlphaNum.Enabled = isSet;

            InferAlphaCheck.CheckedChanged -= InferAlphaCheck_CheckedChanged;
            InferAlphaCheck.Checked = !isSet;
            InferAlphaCheck.CheckedChanged += InferAlphaCheck_CheckedChanged;

            label27.Enabled = !isSet; InitAlphaNum.Enabled = !isSet; sepAlphaForEachPopCheckBox.Checked = !isSet;
            sepAlphaForEachPopCheckBox.Enabled = !isSet;

            useUniformPriorForAlphaCheckBox.Enabled = !isSet;

            useUniformPriorForAlphaCheckBox.CheckedChanged -= useUniformPriorForAlphaCheckBox_CheckedChanged;
            useUniformPriorForAlphaCheckBox.Checked = false;
            useUniformPriorForAlphaCheckBox.CheckedChanged += useUniformPriorForAlphaCheckBox_CheckedChanged;

            label30.Enabled = !isSet;
            alphaMaxNumericUpDown.Enabled = !isSet;
            label31.Enabled = !isSet;
            alphaPropsdNumericUpDown.Enabled = !isSet;

            label33.Enabled = !isSet;
            AalphaPriorANumericUpDown.Enabled = !isSet;
            label32.Enabled = !isSet;
            alphaPriorBNumericUpDown.Enabled = !isSet;
        }

        private void InferAlphaCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isInfer = InferAlphaCheck.Checked;
            SetAlphaNum.Enabled = !isInfer;

            label27.Enabled = isInfer; InitAlphaNum.Enabled = isInfer;
            sepAlphaForEachPopCheckBox.Enabled = isInfer;

            SetAlphaCheck.CheckedChanged -= SetAlphaCheck_CheckedChanged;
            SetAlphaCheck.Checked = !isInfer;
            SetAlphaCheck.CheckedChanged += SetAlphaCheck_CheckedChanged;

            useUniformPriorForAlphaCheckBox.Enabled = isInfer;

            useUniformPriorForAlphaCheckBox.Checked = true;

            label30.Enabled = isInfer;
            alphaMaxNumericUpDown.Enabled = isInfer;
            label31.Enabled = isInfer;
            alphaPropsdNumericUpDown.Enabled = isInfer;
        }

        private void useUniformPriorForAlphaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isUseUni = useUniformPriorForAlphaCheckBox.Checked;

            label30.Enabled = isUseUni;
            alphaMaxNumericUpDown.Enabled = isUseUni;
            label31.Enabled = isUseUni;
            alphaPropsdNumericUpDown.Enabled = isUseUni;

            label33.Enabled = !isUseUni;
            AalphaPriorANumericUpDown.Enabled = !isUseUni;
            label32.Enabled = !isUseUni;
            alphaPriorBNumericUpDown.Enabled = !isUseUni;
        }

        private void ChooseButt_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "Choose Choose permutation file for CLUMPP...";

            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                PermutationFileText.Text = fileDialog.FileName;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLUMPPParametersModel.Instance.PRINT_PERMUTED_DATA = comboBox1.SelectedIndex;
        }
    }
}
