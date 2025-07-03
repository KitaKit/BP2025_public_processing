namespace GenotypeApp
{
    partial class GenotypeApplicationMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("mainparams");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("extraparams");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Parameter set X", new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Structure", new System.Windows.Forms.TreeNode[] { treeNode3 });
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Structure Harvester");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("CLLUMP");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("distruct");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("\"Project name\"", new System.Windows.Forms.TreeNode[] { treeNode4, treeNode5, treeNode6, treeNode7 });
            currentProjectFoldersTreeView = new System.Windows.Forms.TreeView();
            currentProjectInfoBindingSource = new System.Windows.Forms.BindingSource(components);
            genotypeMainWindowMenuStrip = new System.Windows.Forms.MenuStrip();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            structureLogTextBox = new System.Windows.Forms.TextBox();
            structureIterationsLabel = new System.Windows.Forms.Label();
            structureWithLabel = new System.Windows.Forms.Label();
            structureKToLabel = new System.Windows.Forms.Label();
            structureKFromLabel = new System.Windows.Forms.Label();
            structureIterationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            structureConfigurationParametersBindingSource = new System.Windows.Forms.BindingSource(components);
            structureKToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            structureKFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ancestryModelGroupBox = new System.Windows.Forms.GroupBox();
            usePopFlagForTrainingCheckBox = new System.Windows.Forms.CheckBox();
            structureExtraparamsBindingSource = new System.Windows.Forms.BindingSource(components);
            usePriorPopInfoCheckBox = new System.Windows.Forms.CheckBox();
            locationInfoUseCheckBox = new System.Windows.Forms.CheckBox();
            linkageModelCheckBox = new System.Windows.Forms.CheckBox();
            locPriorModelGroupBox = new System.Windows.Forms.GroupBox();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            initialValueNNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label25 = new System.Windows.Forms.Label();
            initialValueNLabel = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            priorPopInformationGroupBox = new System.Windows.Forms.GroupBox();
            gensbackNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label23 = new System.Windows.Forms.Label();
            migPriorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label24 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            preBurnLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            sepAlphaForEachPopCheckBox = new System.Windows.Forms.CheckBox();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            InitAlphaNum = new System.Windows.Forms.NumericUpDown();
            SetAlphaNum = new System.Windows.Forms.NumericUpDown();
            InferAlphaCheck = new System.Windows.Forms.CheckBox();
            SetAlphaCheck = new System.Windows.Forms.CheckBox();
            useUniformPriorForAlphaCheckBox = new System.Windows.Forms.CheckBox();
            label32 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            alphaPropsdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            alphaMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            AalphaPriorANumericUpDown = new System.Windows.Forms.NumericUpDown();
            alphaPriorBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            noAdmixtureModelCheckBox = new System.Windows.Forms.CheckBox();
            linkageModelGroupBox = new System.Windows.Forms.GroupBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            phaseFollowsMarkorModelCheckBox = new System.Windows.Forms.CheckBox();
            structureMainparamsBindingSource = new System.Windows.Forms.BindingSource(components);
            label18 = new System.Windows.Forms.Label();
            CorrectPhaseChek = new System.Windows.Forms.CheckBox();
            label16 = new System.Windows.Forms.Label();
            log10rminNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label17 = new System.Windows.Forms.Label();
            log10rstartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            log10rmaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            log10rpropsdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label19 = new System.Windows.Forms.Label();
            alleleFrequencyModelGroupBox = new System.Windows.Forms.GroupBox();
            inferSeparateLambdaCheckBox = new System.Windows.Forms.CheckBox();
            initLambdaNum = new System.Windows.Forms.NumericUpDown();
            priorSDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            priorMeanNumericUpDown = new System.Windows.Forms.NumericUpDown();
            alleleFrequencisAreCorCheckBox = new System.Windows.Forms.CheckBox();
            SetLambdaCheck = new System.Windows.Forms.CheckBox();
            assumeSameValueCheckBox = new System.Windows.Forms.CheckBox();
            InferLambdaCheck = new System.Windows.Forms.CheckBox();
            SetLambdaNum = new System.Windows.Forms.NumericUpDown();
            label29 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            label49 = new System.Windows.Forms.Label();
            loadStructureDataFileButton = new System.Windows.Forms.Button();
            structureDataFileNameTextBox = new System.Windows.Forms.TextBox();
            advancedGroupBox = new System.Windows.Forms.GroupBox();
            hitRateCheckBox = new System.Windows.Forms.CheckBox();
            seedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label28 = new System.Windows.Forms.Label();
            randomizeCheckBox = new System.Windows.Forms.CheckBox();
            printBriefSummaryCheckBox = new System.Windows.Forms.CheckBox();
            saveIntermediateDataCheckBox = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            printUpdateFreqNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            printSumOfQCheckBox = new System.Windows.Forms.CheckBox();
            printCurrentLambdaValueCheckBox = new System.Windows.Forms.CheckBox();
            printNetCheckBox = new System.Windows.Forms.CheckBox();
            estimateTheProbabiCheckBox = new System.Windows.Forms.CheckBox();
            ancestpintNumericUpDown = new System.Windows.Forms.NumericUpDown();
            numboxesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            freqOfMetroToUpdQNumericUpDown = new System.Windows.Forms.NumericUpDown();
            printCredibleRegCheckBox = new System.Windows.Forms.CheckBox();
            popinfoInitializeCheckBox = new System.Windows.Forms.CheckBox();
            printQhatCheckBox = new System.Windows.Forms.CheckBox();
            label12 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            structureDataFileNameLabel = new System.Windows.Forms.Label();
            loadStructureDataFileLabel = new System.Windows.Forms.Label();
            structureSetNameTextBox = new System.Windows.Forms.TextBox();
            structureSetNameLabel = new System.Windows.Forms.Label();
            structureParametersSetComboBox = new System.Windows.Forms.ComboBox();
            stopStructureButton = new System.Windows.Forms.Button();
            saveStructureParamButton = new System.Windows.Forms.Button();
            startStructureButton = new System.Windows.Forms.Button();
            runLenghtGroupBox = new System.Windows.Forms.GroupBox();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            burninPeriodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            MCMCrepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            chooseStructureParametersSetLabel = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            structureHarvesterLogTextBox = new System.Windows.Forms.TextBox();
            structureHarvesterInputComboBox = new System.Windows.Forms.ComboBox();
            structureHarvesterClumppCheckBox = new System.Windows.Forms.CheckBox();
            structureHarvesterConfigurationParametersBindingSource = new System.Windows.Forms.BindingSource(components);
            structureHarvesterEvannoCheckBox = new System.Windows.Forms.CheckBox();
            structureHarvesterSetForChartLabel = new System.Windows.Forms.Label();
            structureHarvesterSetForChartComboBox = new System.Windows.Forms.ComboBox();
            structureHarvesterLoadChartButton = new System.Windows.Forms.Button();
            structureHarvesterInputLabel = new System.Windows.Forms.Label();
            startStructureHarvesterButton = new System.Windows.Forms.Button();
            tabPage3 = new System.Windows.Forms.TabPage();
            clumppPopAndIndRadioButton = new System.Windows.Forms.RadioButton();
            clumppOnlyPopRadioButton = new System.Windows.Forms.RadioButton();
            clumppStopButton = new System.Windows.Forms.Button();
            clumppLogTextBox = new System.Windows.Forms.TextBox();
            CLUMPPKToLabel = new System.Windows.Forms.Label();
            CLUMPPKFromLabel = new System.Windows.Forms.Label();
            CLUMPPKToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            CLUMPPConfigurationParametersBindingSource = new System.Windows.Forms.BindingSource(components);
            CLUMPPKFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            CLUMPPInputComboBox = new System.Windows.Forms.ComboBox();
            CLUMPPInputLabel = new System.Windows.Forms.Label();
            SaveCLUMPPParamSetButt = new System.Windows.Forms.Button();
            StartCLUMPPButt = new System.Windows.Forms.Button();
            textBox3 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            CLUMPPParametersComboBox = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            groupBox9 = new System.Windows.Forms.GroupBox();
            clumppSCheckBox = new System.Windows.Forms.CheckBox();
            CLUMPPParametersModelBindingSource = new System.Windows.Forms.BindingSource(components);
            clumppOrderByRunNumericUpDown = new System.Windows.Forms.NumericUpDown();
            clumppOrderByRunLabel = new System.Windows.Forms.Label();
            clumppWCheckBox = new System.Windows.Forms.CheckBox();
            OverrideWarningCheck = new System.Windows.Forms.CheckBox();
            groupBox8 = new System.Windows.Forms.GroupBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            PrintRandomInputCheck = new System.Windows.Forms.CheckBox();
            PrintEveryPermCheck = new System.Windows.Forms.CheckBox();
            label15 = new System.Windows.Forms.Label();
            groupBox7 = new System.Windows.Forms.GroupBox();
            GreedyOptionChoose = new System.Windows.Forms.ComboBox();
            ChooseButt = new System.Windows.Forms.Button();
            clumppGreedyOptionLabel = new System.Windows.Forms.Label();
            clumppRepeatsLabel = new System.Windows.Forms.Label();
            clumppPermutationFilelabel = new System.Windows.Forms.Label();
            RepeatsNum = new System.Windows.Forms.NumericUpDown();
            PermutationFileText = new System.Windows.Forms.TextBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            numOfPopulationsLabel = new System.Windows.Forms.Label();
            numOfPopulationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label42 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            MethodUsedChoose = new System.Windows.Forms.ComboBox();
            IndividualsNum = new System.Windows.Forms.NumericUpDown();
            NumberOfIterationsNum = new System.Windows.Forms.NumericUpDown();
            tabPage4 = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            distructStopButton = new System.Windows.Forms.Button();
            distructLogTextBox = new System.Windows.Forms.TextBox();
            distructPre_renderedComboBox = new System.Windows.Forms.ComboBox();
            distructPre_renderedButton = new System.Windows.Forms.Button();
            distructPre_renderedPictureBox = new System.Windows.Forms.PictureBox();
            distructExportGroupBox = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            distructProcessedSetsToExportComboBox = new System.Windows.Forms.ComboBox();
            distructExportButton = new System.Windows.Forms.Button();
            distructExportTypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            distructKToLabel = new System.Windows.Forms.Label();
            distructKToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            distructConfigurationParametersBindingSource = new System.Windows.Forms.BindingSource(components);
            distructKFromLabel = new System.Windows.Forms.Label();
            distructKFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            distructInputComboBox = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            groupBox12 = new System.Windows.Forms.GroupBox();
            label76 = new System.Windows.Forms.Label();
            label79 = new System.Windows.Forms.Label();
            label75 = new System.Windows.Forms.Label();
            label74 = new System.Windows.Forms.Label();
            label73 = new System.Windows.Forms.Label();
            label86 = new System.Windows.Forms.Label();
            OrientationChoose = new System.Windows.Forms.ComboBox();
            distructParametersModelBindingSource = new System.Windows.Forms.BindingSource(components);
            LowerLetXNum = new System.Windows.Forms.NumericUpDown();
            LowerLetYNum = new System.Windows.Forms.NumericUpDown();
            AngleForTopNum = new System.Windows.Forms.NumericUpDown();
            ScaleForYNum = new System.Windows.Forms.NumericUpDown();
            ScaleForXNum = new System.Windows.Forms.NumericUpDown();
            PrintSomeOfTheDataCheck = new System.Windows.Forms.CheckBox();
            label90 = new System.Windows.Forms.Label();
            PrintTheDataAsCommCheck = new System.Windows.Forms.CheckBox();
            RimWidthNum = new System.Windows.Forms.NumericUpDown();
            PrintColorBrewCheck = new System.Windows.Forms.CheckBox();
            label89 = new System.Windows.Forms.Label();
            label84 = new System.Windows.Forms.Label();
            label83 = new System.Windows.Forms.Label();
            UseGrayscaleCheck = new System.Windows.Forms.CheckBox();
            AngleForBelowNum = new System.Windows.Forms.NumericUpDown();
            SeparatorsWidthNum = new System.Windows.Forms.NumericUpDown();
            PrintThePOPQCheck = new System.Windows.Forms.CheckBox();
            IndividualsWidthNum = new System.Windows.Forms.NumericUpDown();
            textBox4 = new System.Windows.Forms.TextBox();
            SaveDistructaParamSetButt = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            StartDistructaButt = new System.Windows.Forms.Button();
            groupBox13 = new System.Windows.Forms.GroupBox();
            PrintLinesToSeparateCheck = new System.Windows.Forms.CheckBox();
            PrintIndividCheck = new System.Windows.Forms.CheckBox();
            PrintLabelsBelowCheck = new System.Windows.Forms.CheckBox();
            PrintLabelsAboveCheck = new System.Windows.Forms.CheckBox();
            distructParametersComboBox = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            groupBox11 = new System.Windows.Forms.GroupBox();
            WidthOfAnIndivNum = new System.Windows.Forms.NumericUpDown();
            label82 = new System.Windows.Forms.Label();
            label81 = new System.Windows.Forms.Label();
            label80 = new System.Windows.Forms.Label();
            label78 = new System.Windows.Forms.Label();
            label77 = new System.Windows.Forms.Label();
            SizeOfFontNum = new System.Windows.Forms.NumericUpDown();
            DistanceAbovePlotNum = new System.Windows.Forms.NumericUpDown();
            DistanceBelowPlotNum = new System.Windows.Forms.NumericUpDown();
            HeightOfTheFigure = new System.Windows.Forms.NumericUpDown();
            groupBox10 = new System.Windows.Forms.GroupBox();
            PermutationOfClustersFileText = new System.Windows.Forms.TextBox();
            distructPrintLabelBelowLabel = new System.Windows.Forms.Label();
            distructLabelAtopLabel = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            label64 = new System.Windows.Forms.Label();
            LabelsBelowFileNameText = new System.Windows.Forms.TextBox();
            ChooseFileBelowButt = new System.Windows.Forms.Button();
            inputFileOfLabelsAtop = new System.Windows.Forms.TextBox();
            ChooseFileAtopButt = new System.Windows.Forms.Button();
            ChooseFilePermutaButt = new System.Windows.Forms.Button();
            PreDefinedPopNum = new System.Windows.Forms.NumericUpDown();
            OfIndividualsNum = new System.Windows.Forms.NumericUpDown();
            label54 = new System.Windows.Forms.Label();
            programsProcessTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            structurLabelTableLayoutPanel = new System.Windows.Forms.Label();
            structureHarvesterLabelTableLayoutPanel = new System.Windows.Forms.Label();
            clumppLabelTableLayoutPanel = new System.Windows.Forms.Label();
            distructTableLayoutPanel = new System.Windows.Forms.Label();
            structureProgressBarTableLayoutPanel = new GenotypeApp.Custom_interface_elements.TextProgressBar();
            structureHarvesterProgressBarTableLayoutPanel = new GenotypeApp.Custom_interface_elements.TextProgressBar();
            clumppProgressBarTableLayoutPanel = new GenotypeApp.Custom_interface_elements.TextProgressBar();
            distructProgressBarTableLayoutPanel = new GenotypeApp.Custom_interface_elements.TextProgressBar();
            structureEtaLabelTableLayoutPanel = new System.Windows.Forms.Label();
            structureHarvesterEtaLabelTableLayoutPanel = new System.Windows.Forms.Label();
            CLUMPPEtaLabelTableLayoutPanel = new System.Windows.Forms.Label();
            distructEtaLabelTableLayoutPanel = new System.Windows.Forms.Label();
            label69 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)currentProjectInfoBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)structureIterationsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)structureConfigurationParametersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)structureKToNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)structureKFromNumericUpDown).BeginInit();
            ancestryModelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)structureExtraparamsBindingSource).BeginInit();
            locPriorModelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)initialValueNNumericUpDown).BeginInit();
            priorPopInformationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gensbackNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)migPriorNumericUpDown).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)preBurnLengthNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InitAlphaNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SetAlphaNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaPropsdNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaMaxNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AalphaPriorANumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaPriorBNumericUpDown).BeginInit();
            linkageModelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)structureMainparamsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)log10rminNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)log10rstartNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)log10rmaxNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)log10rpropsdNumericUpDown).BeginInit();
            alleleFrequencyModelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)initLambdaNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priorSDNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priorMeanNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SetLambdaNum).BeginInit();
            advancedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)seedNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)printUpdateFreqNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ancestpintNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numboxesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)freqOfMetroToUpdQNumericUpDown).BeginInit();
            runLenghtGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)burninPeriodNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MCMCrepsNumericUpDown).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)structureHarvesterConfigurationParametersBindingSource).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CLUMPPKToNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CLUMPPConfigurationParametersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CLUMPPKFromNumericUpDown).BeginInit();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CLUMPPParametersModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clumppOrderByRunNumericUpDown).BeginInit();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RepeatsNum).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numOfPopulationsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IndividualsNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberOfIterationsNum).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)distructPre_renderedPictureBox).BeginInit();
            distructExportGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)distructKToNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)distructConfigurationParametersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)distructKFromNumericUpDown).BeginInit();
            groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)distructParametersModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowerLetXNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowerLetYNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleForTopNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScaleForYNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScaleForXNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RimWidthNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleForBelowNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorsWidthNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IndividualsWidthNum).BeginInit();
            groupBox13.SuspendLayout();
            groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WidthOfAnIndivNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SizeOfFontNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DistanceAbovePlotNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DistanceBelowPlotNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HeightOfTheFigure).BeginInit();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PreDefinedPopNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OfIndividualsNum).BeginInit();
            programsProcessTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // currentProjectFoldersTreeView
            // 
            currentProjectFoldersTreeView.Location = new System.Drawing.Point(12, 36);
            currentProjectFoldersTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            currentProjectFoldersTreeView.Name = "currentProjectFoldersTreeView";
            treeNode1.Name = "Node5";
            treeNode1.Tag = "";
            treeNode1.Text = "mainparams";
            treeNode2.Name = "Node6";
            treeNode2.Text = "extraparams";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Parameter set X";
            treeNode4.Checked = true;
            treeNode4.Name = "Node0";
            treeNode4.Text = "Structure";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Structure Harvester";
            treeNode6.Name = "Node2";
            treeNode6.Text = "CLLUMP";
            treeNode7.Name = "Node3";
            treeNode7.Text = "distruct";
            treeNode8.Checked = true;
            treeNode8.Name = "\"Project name\"\"";
            treeNode8.Text = "\"Project name\"";
            currentProjectFoldersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode8 });
            currentProjectFoldersTreeView.Size = new System.Drawing.Size(480, 684);
            currentProjectFoldersTreeView.TabIndex = 10;
            // 
            // currentProjectInfoBindingSource
            // 
            currentProjectInfoBindingSource.DataSource = typeof(Interface_view_models.CurrentProjectInfoViewModel);
            // 
            // genotypeMainWindowMenuStrip
            // 
            genotypeMainWindowMenuStrip.Location = new System.Drawing.Point(0, 0);
            genotypeMainWindowMenuStrip.Name = "genotypeMainWindowMenuStrip";
            genotypeMainWindowMenuStrip.Size = new System.Drawing.Size(1538, 24);
            genotypeMainWindowMenuStrip.TabIndex = 158;
            genotypeMainWindowMenuStrip.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new System.Drawing.Point(498, 36);
            tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1035, 817);
            tabControl1.TabIndex = 159;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(structureLogTextBox);
            tabPage1.Controls.Add(structureIterationsLabel);
            tabPage1.Controls.Add(structureWithLabel);
            tabPage1.Controls.Add(structureKToLabel);
            tabPage1.Controls.Add(structureKFromLabel);
            tabPage1.Controls.Add(structureIterationsNumericUpDown);
            tabPage1.Controls.Add(structureKToNumericUpDown);
            tabPage1.Controls.Add(structureKFromNumericUpDown);
            tabPage1.Controls.Add(ancestryModelGroupBox);
            tabPage1.Controls.Add(alleleFrequencyModelGroupBox);
            tabPage1.Controls.Add(loadStructureDataFileButton);
            tabPage1.Controls.Add(structureDataFileNameTextBox);
            tabPage1.Controls.Add(advancedGroupBox);
            tabPage1.Controls.Add(structureDataFileNameLabel);
            tabPage1.Controls.Add(loadStructureDataFileLabel);
            tabPage1.Controls.Add(structureSetNameTextBox);
            tabPage1.Controls.Add(structureSetNameLabel);
            tabPage1.Controls.Add(structureParametersSetComboBox);
            tabPage1.Controls.Add(stopStructureButton);
            tabPage1.Controls.Add(saveStructureParamButton);
            tabPage1.Controls.Add(startStructureButton);
            tabPage1.Controls.Add(runLenghtGroupBox);
            tabPage1.Controls.Add(chooseStructureParametersSetLabel);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage1.Size = new System.Drawing.Size(1027, 789);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Structure";
            // 
            // structureLogTextBox
            // 
            structureLogTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            structureLogTextBox.Location = new System.Drawing.Point(5, 580);
            structureLogTextBox.Multiline = true;
            structureLogTextBox.Name = "structureLogTextBox";
            structureLogTextBox.ReadOnly = true;
            structureLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            structureLogTextBox.Size = new System.Drawing.Size(1017, 202);
            structureLogTextBox.TabIndex = 174;
            structureLogTextBox.WordWrap = false;
            // 
            // structureIterationsLabel
            // 
            structureIterationsLabel.AutoSize = true;
            structureIterationsLabel.Enabled = false;
            structureIterationsLabel.Location = new System.Drawing.Point(297, 550);
            structureIterationsLabel.Name = "structureIterationsLabel";
            structureIterationsLabel.Size = new System.Drawing.Size(56, 15);
            structureIterationsLabel.TabIndex = 173;
            structureIterationsLabel.Text = "iterations";
            // 
            // structureWithLabel
            // 
            structureWithLabel.AutoSize = true;
            structureWithLabel.Enabled = false;
            structureWithLabel.Location = new System.Drawing.Point(212, 550);
            structureWithLabel.Name = "structureWithLabel";
            structureWithLabel.Size = new System.Drawing.Size(30, 15);
            structureWithLabel.TabIndex = 172;
            structureWithLabel.Text = "with";
            // 
            // structureKToLabel
            // 
            structureKToLabel.AutoSize = true;
            structureKToLabel.Enabled = false;
            structureKToLabel.Location = new System.Drawing.Point(139, 550);
            structureKToLabel.Name = "structureKToLabel";
            structureKToLabel.Size = new System.Drawing.Size(18, 15);
            structureKToLabel.TabIndex = 171;
            structureKToLabel.Text = "to";
            // 
            // structureKFromLabel
            // 
            structureKFromLabel.AutoSize = true;
            structureKFromLabel.Enabled = false;
            structureKFromLabel.Location = new System.Drawing.Point(35, 550);
            structureKFromLabel.Name = "structureKFromLabel";
            structureKFromLabel.Size = new System.Drawing.Size(49, 15);
            structureKFromLabel.TabIndex = 170;
            structureKFromLabel.Text = "'K' from";
            // 
            // structureIterationsNumericUpDown
            // 
            structureIterationsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureConfigurationParametersBindingSource, "Iterations", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureIterationsNumericUpDown.Enabled = false;
            structureIterationsNumericUpDown.Location = new System.Drawing.Point(247, 545);
            structureIterationsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            structureIterationsNumericUpDown.Name = "structureIterationsNumericUpDown";
            structureIterationsNumericUpDown.Size = new System.Drawing.Size(45, 23);
            structureIterationsNumericUpDown.TabIndex = 169;
            structureIterationsNumericUpDown.Tag = "";
            structureIterationsNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // structureConfigurationParametersBindingSource
            // 
            structureConfigurationParametersBindingSource.DataSource = typeof(Additional_programs_logic.Structure.StructureConfigurationParametersModel);
            // 
            // structureKToNumericUpDown
            // 
            structureKToNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureConfigurationParametersBindingSource, "KEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureKToNumericUpDown.Enabled = false;
            structureKToNumericUpDown.Location = new System.Drawing.Point(162, 545);
            structureKToNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            structureKToNumericUpDown.Name = "structureKToNumericUpDown";
            structureKToNumericUpDown.Size = new System.Drawing.Size(45, 23);
            structureKToNumericUpDown.TabIndex = 168;
            structureKToNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // structureKFromNumericUpDown
            // 
            structureKFromNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureConfigurationParametersBindingSource, "KStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureKFromNumericUpDown.Enabled = false;
            structureKFromNumericUpDown.Location = new System.Drawing.Point(89, 545);
            structureKFromNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            structureKFromNumericUpDown.Name = "structureKFromNumericUpDown";
            structureKFromNumericUpDown.Size = new System.Drawing.Size(45, 23);
            structureKFromNumericUpDown.TabIndex = 167;
            structureKFromNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ancestryModelGroupBox
            // 
            ancestryModelGroupBox.Controls.Add(usePopFlagForTrainingCheckBox);
            ancestryModelGroupBox.Controls.Add(usePriorPopInfoCheckBox);
            ancestryModelGroupBox.Controls.Add(locationInfoUseCheckBox);
            ancestryModelGroupBox.Controls.Add(linkageModelCheckBox);
            ancestryModelGroupBox.Controls.Add(locPriorModelGroupBox);
            ancestryModelGroupBox.Controls.Add(priorPopInformationGroupBox);
            ancestryModelGroupBox.Controls.Add(groupBox3);
            ancestryModelGroupBox.Controls.Add(noAdmixtureModelCheckBox);
            ancestryModelGroupBox.Controls.Add(linkageModelGroupBox);
            ancestryModelGroupBox.Enabled = false;
            ancestryModelGroupBox.Location = new System.Drawing.Point(35, 139);
            ancestryModelGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ancestryModelGroupBox.Name = "ancestryModelGroupBox";
            ancestryModelGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ancestryModelGroupBox.Size = new System.Drawing.Size(615, 405);
            ancestryModelGroupBox.TabIndex = 150;
            ancestryModelGroupBox.TabStop = false;
            ancestryModelGroupBox.Text = "Ancestry Model";
            // 
            // usePopFlagForTrainingCheckBox
            // 
            usePopFlagForTrainingCheckBox.AutoSize = true;
            usePopFlagForTrainingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "PFROMPOPFLAGONLY", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            usePopFlagForTrainingCheckBox.Location = new System.Drawing.Point(320, 145);
            usePopFlagForTrainingCheckBox.Name = "usePopFlagForTrainingCheckBox";
            usePopFlagForTrainingCheckBox.Size = new System.Drawing.Size(161, 19);
            usePopFlagForTrainingCheckBox.TabIndex = 122;
            usePopFlagForTrainingCheckBox.Text = "Use POPFLAG for training";
            usePopFlagForTrainingCheckBox.UseVisualStyleBackColor = true;
            // 
            // structureExtraparamsBindingSource
            // 
            structureExtraparamsBindingSource.DataMember = "extraparams";
            structureExtraparamsBindingSource.DataSource = typeof(Additional_programs_logic.Structure.StructureParametersModel);
            // 
            // usePriorPopInfoCheckBox
            // 
            usePriorPopInfoCheckBox.AutoSize = true;
            usePriorPopInfoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "USEPOPINFO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            usePriorPopInfoCheckBox.Location = new System.Drawing.Point(320, 165);
            usePriorPopInfoCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            usePriorPopInfoCheckBox.Name = "usePriorPopInfoCheckBox";
            usePriorPopInfoCheckBox.Size = new System.Drawing.Size(200, 19);
            usePriorPopInfoCheckBox.TabIndex = 108;
            usePriorPopInfoCheckBox.Text = "Use prior population information";
            usePriorPopInfoCheckBox.UseVisualStyleBackColor = true;
            usePriorPopInfoCheckBox.CheckedChanged += usePriorPopInfoCheckBox_CheckedChanged;
            // 
            // locationInfoUseCheckBox
            // 
            locationInfoUseCheckBox.AutoSize = true;
            locationInfoUseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "LOCPRIOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            locationInfoUseCheckBox.Location = new System.Drawing.Point(320, 45);
            locationInfoUseCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            locationInfoUseCheckBox.Name = "locationInfoUseCheckBox";
            locationInfoUseCheckBox.Size = new System.Drawing.Size(232, 19);
            locationInfoUseCheckBox.TabIndex = 120;
            locationInfoUseCheckBox.Text = "Use location info to improve weak data";
            locationInfoUseCheckBox.UseVisualStyleBackColor = true;
            locationInfoUseCheckBox.CheckedChanged += locationInfoUseCheckBox_CheckedChanged;
            // 
            // linkageModelCheckBox
            // 
            linkageModelCheckBox.AutoSize = true;
            linkageModelCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "LINKAGE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            linkageModelCheckBox.Location = new System.Drawing.Point(15, 45);
            linkageModelCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            linkageModelCheckBox.Name = "linkageModelCheckBox";
            linkageModelCheckBox.Size = new System.Drawing.Size(143, 19);
            linkageModelCheckBox.TabIndex = 101;
            linkageModelCheckBox.Text = "Use the linkage model";
            linkageModelCheckBox.UseVisualStyleBackColor = true;
            linkageModelCheckBox.CheckedChanged += linkageModelCheckBox_CheckedChanged;
            // 
            // locPriorModelGroupBox
            // 
            locPriorModelGroupBox.Controls.Add(numericUpDown2);
            locPriorModelGroupBox.Controls.Add(initialValueNNumericUpDown);
            locPriorModelGroupBox.Controls.Add(label25);
            locPriorModelGroupBox.Controls.Add(initialValueNLabel);
            locPriorModelGroupBox.Controls.Add(checkBox1);
            locPriorModelGroupBox.Enabled = false;
            locPriorModelGroupBox.Location = new System.Drawing.Point(310, 50);
            locPriorModelGroupBox.Name = "locPriorModelGroupBox";
            locPriorModelGroupBox.Size = new System.Drawing.Size(285, 95);
            locPriorModelGroupBox.TabIndex = 167;
            locPriorModelGroupBox.TabStop = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "MAXLOCPRIOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            numericUpDown2.Location = new System.Drawing.Point(130, 65);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(60, 23);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // initialValueNNumericUpDown
            // 
            initialValueNNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "LOCPRIORINIT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            initialValueNNumericUpDown.Location = new System.Drawing.Point(130, 40);
            initialValueNNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            initialValueNNumericUpDown.Name = "initialValueNNumericUpDown";
            initialValueNNumericUpDown.Size = new System.Drawing.Size(60, 23);
            initialValueNNumericUpDown.TabIndex = 3;
            initialValueNNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(40, 70);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(70, 15);
            label25.TabIndex = 2;
            label25.Text = "Max value η";
            // 
            // initialValueNLabel
            // 
            initialValueNLabel.AutoSize = true;
            initialValueNLabel.Location = new System.Drawing.Point(40, 45);
            initialValueNLabel.Name = "initialValueNLabel";
            initialValueNLabel.Size = new System.Drawing.Size(77, 15);
            initialValueNLabel.TabIndex = 1;
            initialValueNLabel.Text = "Initial value η";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "LOCISPOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", structureExtraparamsBindingSource, "LOCISPOP", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            checkBox1.Location = new System.Drawing.Point(20, 20);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(231, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Consider the population for each locus";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // priorPopInformationGroupBox
            // 
            priorPopInformationGroupBox.Controls.Add(gensbackNumericUpDown);
            priorPopInformationGroupBox.Controls.Add(label23);
            priorPopInformationGroupBox.Controls.Add(migPriorNumericUpDown);
            priorPopInformationGroupBox.Controls.Add(label24);
            priorPopInformationGroupBox.Enabled = false;
            priorPopInformationGroupBox.Location = new System.Drawing.Point(310, 170);
            priorPopInformationGroupBox.Name = "priorPopInformationGroupBox";
            priorPopInformationGroupBox.Size = new System.Drawing.Size(285, 75);
            priorPopInformationGroupBox.TabIndex = 124;
            priorPopInformationGroupBox.TabStop = false;
            // 
            // gensbackNumericUpDown
            // 
            gensbackNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "GENSBACK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            gensbackNumericUpDown.Location = new System.Drawing.Point(130, 20);
            gensbackNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gensbackNumericUpDown.Maximum = new decimal(new int[] { 32738, 0, 0, 0 });
            gensbackNumericUpDown.Name = "gensbackNumericUpDown";
            gensbackNumericUpDown.Size = new System.Drawing.Size(60, 23);
            gensbackNumericUpDown.TabIndex = 95;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(5, 25);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(58, 15);
            label23.TabIndex = 21;
            label23.Text = "Gensback";
            // 
            // migPriorNumericUpDown
            // 
            migPriorNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "MIGRPRIOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            migPriorNumericUpDown.DecimalPlaces = 2;
            migPriorNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            migPriorNumericUpDown.Location = new System.Drawing.Point(130, 45);
            migPriorNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            migPriorNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            migPriorNumericUpDown.Name = "migPriorNumericUpDown";
            migPriorNumericUpDown.Size = new System.Drawing.Size(60, 23);
            migPriorNumericUpDown.TabIndex = 94;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(5, 50);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(53, 15);
            label24.TabIndex = 22;
            label24.Text = "Migprior";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(preBurnLengthNumericUpDown);
            groupBox3.Controls.Add(sepAlphaForEachPopCheckBox);
            groupBox3.Controls.Add(label27);
            groupBox3.Controls.Add(label26);
            groupBox3.Controls.Add(InitAlphaNum);
            groupBox3.Controls.Add(SetAlphaNum);
            groupBox3.Controls.Add(InferAlphaCheck);
            groupBox3.Controls.Add(SetAlphaCheck);
            groupBox3.Controls.Add(useUniformPriorForAlphaCheckBox);
            groupBox3.Controls.Add(label32);
            groupBox3.Controls.Add(label30);
            groupBox3.Controls.Add(label31);
            groupBox3.Controls.Add(label33);
            groupBox3.Controls.Add(alphaPropsdNumericUpDown);
            groupBox3.Controls.Add(alphaMaxNumericUpDown);
            groupBox3.Controls.Add(AalphaPriorANumericUpDown);
            groupBox3.Controls.Add(alphaPriorBNumericUpDown);
            groupBox3.Location = new System.Drawing.Point(5, 245);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Size = new System.Drawing.Size(590, 150);
            groupBox3.TabIndex = 121;
            groupBox3.TabStop = false;
            groupBox3.Text = "Admixture Model";
            // 
            // preBurnLengthNumericUpDown
            // 
            preBurnLengthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ADMBURNIN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            preBurnLengthNumericUpDown.Location = new System.Drawing.Point(225, 90);
            preBurnLengthNumericUpDown.Name = "preBurnLengthNumericUpDown";
            preBurnLengthNumericUpDown.Size = new System.Drawing.Size(60, 23);
            preBurnLengthNumericUpDown.TabIndex = 145;
            // 
            // sepAlphaForEachPopCheckBox
            // 
            sepAlphaForEachPopCheckBox.AutoSize = true;
            sepAlphaForEachPopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "POPALPHAS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            sepAlphaForEachPopCheckBox.Location = new System.Drawing.Point(95, 70);
            sepAlphaForEachPopCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            sepAlphaForEachPopCheckBox.Name = "sepAlphaForEachPopCheckBox";
            sepAlphaForEachPopCheckBox.Size = new System.Drawing.Size(210, 19);
            sepAlphaForEachPopCheckBox.TabIndex = 104;
            sepAlphaForEachPopCheckBox.Text = "Separate alpha for each population";
            sepAlphaForEachPopCheckBox.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(110, 45);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(105, 15);
            label27.TabIndex = 25;
            label27.Text = "Alpha initialization";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(5, 95);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(155, 15);
            label26.TabIndex = 144;
            label26.Text = "Length of pre-burnin period";
            // 
            // InitAlphaNum
            // 
            InitAlphaNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ALPHA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            InitAlphaNum.DecimalPlaces = 1;
            InitAlphaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            InitAlphaNum.Location = new System.Drawing.Point(225, 40);
            InitAlphaNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            InitAlphaNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            InitAlphaNum.Minimum = new decimal(new int[] { 27000, 0, 0, int.MinValue });
            InitAlphaNum.Name = "InitAlphaNum";
            InitAlphaNum.Size = new System.Drawing.Size(60, 23);
            InitAlphaNum.TabIndex = 91;
            InitAlphaNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SetAlphaNum
            // 
            SetAlphaNum.DecimalPlaces = 1;
            SetAlphaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            SetAlphaNum.Location = new System.Drawing.Point(20, 40);
            SetAlphaNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SetAlphaNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            SetAlphaNum.Minimum = new decimal(new int[] { 27000, 0, 0, int.MinValue });
            SetAlphaNum.Name = "SetAlphaNum";
            SetAlphaNum.Size = new System.Drawing.Size(60, 23);
            SetAlphaNum.TabIndex = 97;
            SetAlphaNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // InferAlphaCheck
            // 
            InferAlphaCheck.AutoSize = true;
            InferAlphaCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "INFERALPHA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            InferAlphaCheck.Location = new System.Drawing.Point(95, 20);
            InferAlphaCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            InferAlphaCheck.Name = "InferAlphaCheck";
            InferAlphaCheck.Size = new System.Drawing.Size(82, 19);
            InferAlphaCheck.TabIndex = 102;
            InferAlphaCheck.Text = "Infer alpha";
            InferAlphaCheck.UseVisualStyleBackColor = true;
            InferAlphaCheck.CheckedChanged += InferAlphaCheck_CheckedChanged;
            // 
            // SetAlphaCheck
            // 
            SetAlphaCheck.AutoSize = true;
            SetAlphaCheck.Location = new System.Drawing.Point(5, 20);
            SetAlphaCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SetAlphaCheck.Name = "SetAlphaCheck";
            SetAlphaCheck.Size = new System.Drawing.Size(74, 19);
            SetAlphaCheck.TabIndex = 103;
            SetAlphaCheck.Text = "Set alpha";
            SetAlphaCheck.UseVisualStyleBackColor = true;
            SetAlphaCheck.CheckedChanged += SetAlphaCheck_CheckedChanged;
            // 
            // useUniformPriorForAlphaCheckBox
            // 
            useUniformPriorForAlphaCheckBox.AutoSize = true;
            useUniformPriorForAlphaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "UNIFPRIORALPHA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            useUniformPriorForAlphaCheckBox.Location = new System.Drawing.Point(315, 20);
            useUniformPriorForAlphaCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            useUniformPriorForAlphaCheckBox.Name = "useUniformPriorForAlphaCheckBox";
            useUniformPriorForAlphaCheckBox.Size = new System.Drawing.Size(178, 19);
            useUniformPriorForAlphaCheckBox.TabIndex = 105;
            useUniformPriorForAlphaCheckBox.Text = "Use a uniform prior for alpha";
            useUniformPriorForAlphaCheckBox.UseVisualStyleBackColor = true;
            useUniformPriorForAlphaCheckBox.CheckedChanged += useUniformPriorForAlphaCheckBox_CheckedChanged;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(330, 125);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(70, 15);
            label32.TabIndex = 30;
            label32.Text = "Alphapriorb";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(330, 45);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(63, 15);
            label30.TabIndex = 28;
            label30.Text = "Alpha max";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(330, 70);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(78, 15);
            label31.TabIndex = 29;
            label31.Text = "Alpha propsd";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new System.Drawing.Point(330, 100);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(69, 15);
            label33.TabIndex = 31;
            label33.Text = "Alphapriora";
            // 
            // alphaPropsdNumericUpDown
            // 
            alphaPropsdNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ALPHAPROPSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            alphaPropsdNumericUpDown.DecimalPlaces = 3;
            alphaPropsdNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            alphaPropsdNumericUpDown.Location = new System.Drawing.Point(435, 65);
            alphaPropsdNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alphaPropsdNumericUpDown.Name = "alphaPropsdNumericUpDown";
            alphaPropsdNumericUpDown.Size = new System.Drawing.Size(60, 23);
            alphaPropsdNumericUpDown.TabIndex = 92;
            // 
            // alphaMaxNumericUpDown
            // 
            alphaMaxNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ALPHAMAX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            alphaMaxNumericUpDown.DecimalPlaces = 1;
            alphaMaxNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            alphaMaxNumericUpDown.Location = new System.Drawing.Point(435, 40);
            alphaMaxNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alphaMaxNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            alphaMaxNumericUpDown.Name = "alphaMaxNumericUpDown";
            alphaMaxNumericUpDown.Size = new System.Drawing.Size(60, 23);
            alphaMaxNumericUpDown.TabIndex = 93;
            // 
            // AalphaPriorANumericUpDown
            // 
            AalphaPriorANumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ALPHAPRIORA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            AalphaPriorANumericUpDown.DecimalPlaces = 2;
            AalphaPriorANumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            AalphaPriorANumericUpDown.Location = new System.Drawing.Point(435, 95);
            AalphaPriorANumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            AalphaPriorANumericUpDown.Name = "AalphaPriorANumericUpDown";
            AalphaPriorANumericUpDown.Size = new System.Drawing.Size(60, 23);
            AalphaPriorANumericUpDown.TabIndex = 96;
            // 
            // alphaPriorBNumericUpDown
            // 
            alphaPriorBNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ALPHAPRIORB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            alphaPriorBNumericUpDown.DecimalPlaces = 3;
            alphaPriorBNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            alphaPriorBNumericUpDown.Location = new System.Drawing.Point(435, 120);
            alphaPriorBNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alphaPriorBNumericUpDown.Name = "alphaPriorBNumericUpDown";
            alphaPriorBNumericUpDown.Size = new System.Drawing.Size(60, 23);
            alphaPriorBNumericUpDown.TabIndex = 98;
            // 
            // noAdmixtureModelCheckBox
            // 
            noAdmixtureModelCheckBox.AutoSize = true;
            noAdmixtureModelCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "NOADMIX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            noAdmixtureModelCheckBox.Location = new System.Drawing.Point(5, 20);
            noAdmixtureModelCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            noAdmixtureModelCheckBox.Name = "noAdmixtureModelCheckBox";
            noAdmixtureModelCheckBox.Size = new System.Drawing.Size(225, 19);
            noAdmixtureModelCheckBox.TabIndex = 118;
            noAdmixtureModelCheckBox.Text = "Assume the model without admixture";
            noAdmixtureModelCheckBox.UseVisualStyleBackColor = true;
            noAdmixtureModelCheckBox.CheckedChanged += noAdmixtureModelCheckBox_CheckedChanged;
            // 
            // linkageModelGroupBox
            // 
            linkageModelGroupBox.Controls.Add(checkBox2);
            linkageModelGroupBox.Controls.Add(phaseFollowsMarkorModelCheckBox);
            linkageModelGroupBox.Controls.Add(label18);
            linkageModelGroupBox.Controls.Add(CorrectPhaseChek);
            linkageModelGroupBox.Controls.Add(label16);
            linkageModelGroupBox.Controls.Add(log10rminNumericUpDown);
            linkageModelGroupBox.Controls.Add(label17);
            linkageModelGroupBox.Controls.Add(log10rstartNumericUpDown);
            linkageModelGroupBox.Controls.Add(log10rmaxNumericUpDown);
            linkageModelGroupBox.Controls.Add(log10rpropsdNumericUpDown);
            linkageModelGroupBox.Controls.Add(label19);
            linkageModelGroupBox.Enabled = false;
            linkageModelGroupBox.Location = new System.Drawing.Point(5, 50);
            linkageModelGroupBox.Name = "linkageModelGroupBox";
            linkageModelGroupBox.Size = new System.Drawing.Size(295, 195);
            linkageModelGroupBox.TabIndex = 125;
            linkageModelGroupBox.TabStop = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "SITEBYSITE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            checkBox2.Location = new System.Drawing.Point(20, 40);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(146, 19);
            checkBox2.TabIndex = 123;
            checkBox2.Text = "Print site by site results";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // phaseFollowsMarkorModelCheckBox
            // 
            phaseFollowsMarkorModelCheckBox.AutoSize = true;
            phaseFollowsMarkorModelCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "MARKOVPHASE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            phaseFollowsMarkorModelCheckBox.Location = new System.Drawing.Point(20, 20);
            phaseFollowsMarkorModelCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            phaseFollowsMarkorModelCheckBox.Name = "phaseFollowsMarkorModelCheckBox";
            phaseFollowsMarkorModelCheckBox.Size = new System.Drawing.Size(234, 19);
            phaseFollowsMarkorModelCheckBox.TabIndex = 106;
            phaseFollowsMarkorModelCheckBox.Text = "The phase info follows a Markov model";
            phaseFollowsMarkorModelCheckBox.UseVisualStyleBackColor = true;
            // 
            // structureMainparamsBindingSource
            // 
            structureMainparamsBindingSource.DataMember = "mainparams";
            structureMainparamsBindingSource.DataSource = typeof(Additional_programs_logic.Structure.StructureParametersModel);
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(40, 110);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(65, 15);
            label18.TabIndex = 16;
            label18.Text = "Log10rmax";
            // 
            // CorrectPhaseChek
            // 
            CorrectPhaseChek.AutoSize = true;
            CorrectPhaseChek.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "PHASED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            CorrectPhaseChek.Location = new System.Drawing.Point(20, 60);
            CorrectPhaseChek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            CorrectPhaseChek.Name = "CorrectPhaseChek";
            CorrectPhaseChek.Size = new System.Drawing.Size(156, 19);
            CorrectPhaseChek.TabIndex = 107;
            CorrectPhaseChek.Text = "Data are in correct phase";
            CorrectPhaseChek.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(40, 85);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(64, 15);
            label16.TabIndex = 14;
            label16.Text = "Log10rmin";
            // 
            // log10rminNumericUpDown
            // 
            log10rminNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "LOG10RMIN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            log10rminNumericUpDown.DecimalPlaces = 1;
            log10rminNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            log10rminNumericUpDown.Location = new System.Drawing.Point(225, 80);
            log10rminNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            log10rminNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            log10rminNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            log10rminNumericUpDown.Name = "log10rminNumericUpDown";
            log10rminNumericUpDown.Size = new System.Drawing.Size(60, 23);
            log10rminNumericUpDown.TabIndex = 85;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(39, 140);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(80, 15);
            label17.TabIndex = 15;
            label17.Text = "Log10rpropsd";
            // 
            // log10rstartNumericUpDown
            // 
            log10rstartNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "LOG10RSTART", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            log10rstartNumericUpDown.DecimalPlaces = 1;
            log10rstartNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            log10rstartNumericUpDown.Location = new System.Drawing.Point(225, 160);
            log10rstartNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            log10rstartNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            log10rstartNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            log10rstartNumericUpDown.Name = "log10rstartNumericUpDown";
            log10rstartNumericUpDown.Size = new System.Drawing.Size(60, 23);
            log10rstartNumericUpDown.TabIndex = 82;
            // 
            // log10rmaxNumericUpDown
            // 
            log10rmaxNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "LOG10RMAX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            log10rmaxNumericUpDown.DecimalPlaces = 1;
            log10rmaxNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            log10rmaxNumericUpDown.Location = new System.Drawing.Point(225, 105);
            log10rmaxNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            log10rmaxNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            log10rmaxNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            log10rmaxNumericUpDown.Name = "log10rmaxNumericUpDown";
            log10rmaxNumericUpDown.Size = new System.Drawing.Size(60, 23);
            log10rmaxNumericUpDown.TabIndex = 83;
            // 
            // log10rpropsdNumericUpDown
            // 
            log10rpropsdNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "LOG10PROPSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            log10rpropsdNumericUpDown.DecimalPlaces = 1;
            log10rpropsdNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            log10rpropsdNumericUpDown.Location = new System.Drawing.Point(225, 135);
            log10rpropsdNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            log10rpropsdNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            log10rpropsdNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            log10rpropsdNumericUpDown.Name = "log10rpropsdNumericUpDown";
            log10rpropsdNumericUpDown.Size = new System.Drawing.Size(60, 23);
            log10rpropsdNumericUpDown.TabIndex = 84;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(39, 165);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(66, 15);
            label19.TabIndex = 17;
            label19.Text = "Log10rstart";
            // 
            // alleleFrequencyModelGroupBox
            // 
            alleleFrequencyModelGroupBox.Controls.Add(inferSeparateLambdaCheckBox);
            alleleFrequencyModelGroupBox.Controls.Add(initLambdaNum);
            alleleFrequencyModelGroupBox.Controls.Add(priorSDNumericUpDown);
            alleleFrequencyModelGroupBox.Controls.Add(priorMeanNumericUpDown);
            alleleFrequencyModelGroupBox.Controls.Add(alleleFrequencisAreCorCheckBox);
            alleleFrequencyModelGroupBox.Controls.Add(SetLambdaCheck);
            alleleFrequencyModelGroupBox.Controls.Add(assumeSameValueCheckBox);
            alleleFrequencyModelGroupBox.Controls.Add(InferLambdaCheck);
            alleleFrequencyModelGroupBox.Controls.Add(SetLambdaNum);
            alleleFrequencyModelGroupBox.Controls.Add(label29);
            alleleFrequencyModelGroupBox.Controls.Add(label50);
            alleleFrequencyModelGroupBox.Controls.Add(label49);
            alleleFrequencyModelGroupBox.Enabled = false;
            alleleFrequencyModelGroupBox.Location = new System.Drawing.Point(330, 50);
            alleleFrequencyModelGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alleleFrequencyModelGroupBox.Name = "alleleFrequencyModelGroupBox";
            alleleFrequencyModelGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alleleFrequencyModelGroupBox.Size = new System.Drawing.Size(670, 90);
            alleleFrequencyModelGroupBox.TabIndex = 151;
            alleleFrequencyModelGroupBox.TabStop = false;
            alleleFrequencyModelGroupBox.Text = "Allele Frequency Model";
            // 
            // inferSeparateLambdaCheckBox
            // 
            inferSeparateLambdaCheckBox.AutoSize = true;
            inferSeparateLambdaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "POPSPECIFICLAMBDA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            inferSeparateLambdaCheckBox.Enabled = false;
            inferSeparateLambdaCheckBox.Location = new System.Drawing.Point(420, 65);
            inferSeparateLambdaCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            inferSeparateLambdaCheckBox.Name = "inferSeparateLambdaCheckBox";
            inferSeparateLambdaCheckBox.Size = new System.Drawing.Size(221, 19);
            inferSeparateLambdaCheckBox.TabIndex = 113;
            inferSeparateLambdaCheckBox.Text = "Separate lambda for each population";
            inferSeparateLambdaCheckBox.UseVisualStyleBackColor = true;
            // 
            // initLambdaNum
            // 
            initLambdaNum.DecimalPlaces = 1;
            initLambdaNum.Enabled = false;
            initLambdaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            initLambdaNum.Location = new System.Drawing.Point(542, 35);
            initLambdaNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            initLambdaNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            initLambdaNum.Minimum = new decimal(new int[] { 27000, 0, 0, int.MinValue });
            initLambdaNum.Name = "initLambdaNum";
            initLambdaNum.Size = new System.Drawing.Size(60, 23);
            initLambdaNum.TabIndex = 86;
            initLambdaNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // priorSDNumericUpDown
            // 
            priorSDNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "FPRIORSD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            priorSDNumericUpDown.DecimalPlaces = 2;
            priorSDNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            priorSDNumericUpDown.Location = new System.Drawing.Point(247, 60);
            priorSDNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            priorSDNumericUpDown.Name = "priorSDNumericUpDown";
            priorSDNumericUpDown.Size = new System.Drawing.Size(60, 23);
            priorSDNumericUpDown.TabIndex = 87;
            // 
            // priorMeanNumericUpDown
            // 
            priorMeanNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "FPRIORMEAN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            priorMeanNumericUpDown.DecimalPlaces = 2;
            priorMeanNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            priorMeanNumericUpDown.Location = new System.Drawing.Point(105, 60);
            priorMeanNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            priorMeanNumericUpDown.Name = "priorMeanNumericUpDown";
            priorMeanNumericUpDown.Size = new System.Drawing.Size(60, 23);
            priorMeanNumericUpDown.TabIndex = 88;
            priorMeanNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // alleleFrequencisAreCorCheckBox
            // 
            alleleFrequencisAreCorCheckBox.AutoSize = true;
            alleleFrequencisAreCorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "FREQSCORR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            alleleFrequencisAreCorCheckBox.Location = new System.Drawing.Point(5, 20);
            alleleFrequencisAreCorCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            alleleFrequencisAreCorCheckBox.Name = "alleleFrequencisAreCorCheckBox";
            alleleFrequencisAreCorCheckBox.Size = new System.Drawing.Size(194, 19);
            alleleFrequencisAreCorCheckBox.TabIndex = 109;
            alleleFrequencisAreCorCheckBox.Text = "Allele frequencies are correlated";
            alleleFrequencisAreCorCheckBox.UseVisualStyleBackColor = true;
            alleleFrequencisAreCorCheckBox.CheckedChanged += alleleFrequencisAreCorCheckBox_CheckedChanged;
            // 
            // SetLambdaCheck
            // 
            SetLambdaCheck.AutoSize = true;
            SetLambdaCheck.Checked = true;
            SetLambdaCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            SetLambdaCheck.Location = new System.Drawing.Point(315, 20);
            SetLambdaCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SetLambdaCheck.Name = "SetLambdaCheck";
            SetLambdaCheck.Size = new System.Drawing.Size(85, 19);
            SetLambdaCheck.TabIndex = 110;
            SetLambdaCheck.Text = "Set lambda";
            SetLambdaCheck.UseVisualStyleBackColor = true;
            SetLambdaCheck.CheckedChanged += SetLambdaCheck_CheckedChanged;
            // 
            // assumeSameValueCheckBox
            // 
            assumeSameValueCheckBox.AutoSize = true;
            assumeSameValueCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "ONEFST", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            assumeSameValueCheckBox.Location = new System.Drawing.Point(20, 40);
            assumeSameValueCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            assumeSameValueCheckBox.Name = "assumeSameValueCheckBox";
            assumeSameValueCheckBox.Size = new System.Drawing.Size(280, 19);
            assumeSameValueCheckBox.TabIndex = 111;
            assumeSameValueCheckBox.Text = "Assume same value of Fst for all subpopulations";
            assumeSameValueCheckBox.UseVisualStyleBackColor = true;
            // 
            // InferLambdaCheck
            // 
            InferLambdaCheck.AutoSize = true;
            InferLambdaCheck.Location = new System.Drawing.Point(405, 20);
            InferLambdaCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            InferLambdaCheck.Name = "InferLambdaCheck";
            InferLambdaCheck.Size = new System.Drawing.Size(93, 19);
            InferLambdaCheck.TabIndex = 112;
            InferLambdaCheck.Text = "Infer lambda";
            InferLambdaCheck.UseVisualStyleBackColor = true;
            InferLambdaCheck.CheckedChanged += InferLambdaCheck_CheckedChanged;
            // 
            // SetLambdaNum
            // 
            SetLambdaNum.DecimalPlaces = 1;
            SetLambdaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            SetLambdaNum.Location = new System.Drawing.Point(330, 40);
            SetLambdaNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SetLambdaNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            SetLambdaNum.Minimum = new decimal(new int[] { 27000, 0, 0, int.MinValue });
            SetLambdaNum.Name = "SetLambdaNum";
            SetLambdaNum.Size = new System.Drawing.Size(60, 23);
            SetLambdaNum.TabIndex = 125;
            SetLambdaNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Enabled = false;
            label29.Location = new System.Drawing.Point(420, 40);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(117, 15);
            label29.TabIndex = 131;
            label29.Text = "Lambda initialization";
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new System.Drawing.Point(35, 65);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(65, 15);
            label50.TabIndex = 138;
            label50.Text = "Prior mean";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new System.Drawing.Point(195, 65);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(47, 15);
            label49.TabIndex = 139;
            label49.Text = "Prior sd";
            // 
            // loadStructureDataFileButton
            // 
            loadStructureDataFileButton.Enabled = false;
            loadStructureDataFileButton.Location = new System.Drawing.Point(35, 20);
            loadStructureDataFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            loadStructureDataFileButton.Name = "loadStructureDataFileButton";
            loadStructureDataFileButton.Size = new System.Drawing.Size(130, 25);
            loadStructureDataFileButton.TabIndex = 166;
            loadStructureDataFileButton.Text = "Load";
            loadStructureDataFileButton.UseVisualStyleBackColor = true;
            loadStructureDataFileButton.Click += loadStructureDataFileButton_Click;
            // 
            // structureDataFileNameTextBox
            // 
            structureDataFileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "INFILE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureDataFileNameTextBox.Enabled = false;
            structureDataFileNameTextBox.Location = new System.Drawing.Point(170, 20);
            structureDataFileNameTextBox.MaxLength = 30;
            structureDataFileNameTextBox.Name = "structureDataFileNameTextBox";
            structureDataFileNameTextBox.Size = new System.Drawing.Size(130, 23);
            structureDataFileNameTextBox.TabIndex = 165;
            // 
            // advancedGroupBox
            // 
            advancedGroupBox.Controls.Add(hitRateCheckBox);
            advancedGroupBox.Controls.Add(seedNumericUpDown);
            advancedGroupBox.Controls.Add(label28);
            advancedGroupBox.Controls.Add(randomizeCheckBox);
            advancedGroupBox.Controls.Add(printBriefSummaryCheckBox);
            advancedGroupBox.Controls.Add(saveIntermediateDataCheckBox);
            advancedGroupBox.Controls.Add(checkBox3);
            advancedGroupBox.Controls.Add(printUpdateFreqNumericUpDown);
            advancedGroupBox.Controls.Add(label5);
            advancedGroupBox.Controls.Add(printSumOfQCheckBox);
            advancedGroupBox.Controls.Add(printCurrentLambdaValueCheckBox);
            advancedGroupBox.Controls.Add(printNetCheckBox);
            advancedGroupBox.Controls.Add(estimateTheProbabiCheckBox);
            advancedGroupBox.Controls.Add(ancestpintNumericUpDown);
            advancedGroupBox.Controls.Add(numboxesNumericUpDown);
            advancedGroupBox.Controls.Add(freqOfMetroToUpdQNumericUpDown);
            advancedGroupBox.Controls.Add(printCredibleRegCheckBox);
            advancedGroupBox.Controls.Add(popinfoInitializeCheckBox);
            advancedGroupBox.Controls.Add(printQhatCheckBox);
            advancedGroupBox.Controls.Add(label12);
            advancedGroupBox.Controls.Add(label14);
            advancedGroupBox.Controls.Add(label22);
            advancedGroupBox.Enabled = false;
            advancedGroupBox.Location = new System.Drawing.Point(655, 139);
            advancedGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            advancedGroupBox.Name = "advancedGroupBox";
            advancedGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            advancedGroupBox.Size = new System.Drawing.Size(345, 405);
            advancedGroupBox.TabIndex = 152;
            advancedGroupBox.TabStop = false;
            advancedGroupBox.Text = "Advanced";
            // 
            // hitRateCheckBox
            // 
            hitRateCheckBox.AutoSize = true;
            hitRateCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "REPORTHITRATE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            hitRateCheckBox.Location = new System.Drawing.Point(5, 380);
            hitRateCheckBox.Name = "hitRateCheckBox";
            hitRateCheckBox.Size = new System.Drawing.Size(95, 19);
            hitRateCheckBox.TabIndex = 147;
            hitRateCheckBox.Text = "Show hit rate";
            hitRateCheckBox.UseVisualStyleBackColor = true;
            // 
            // seedNumericUpDown
            // 
            seedNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "SEED", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            seedNumericUpDown.Enabled = false;
            seedNumericUpDown.Location = new System.Drawing.Point(215, 325);
            seedNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            seedNumericUpDown.Name = "seedNumericUpDown";
            seedNumericUpDown.Size = new System.Drawing.Size(60, 23);
            seedNumericUpDown.TabIndex = 146;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Enabled = false;
            label28.Location = new System.Drawing.Point(25, 330);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(32, 15);
            label28.TabIndex = 145;
            label28.Text = "Seed";
            // 
            // randomizeCheckBox
            // 
            randomizeCheckBox.AutoSize = true;
            randomizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "RANDOMIZE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            randomizeCheckBox.Location = new System.Drawing.Point(5, 305);
            randomizeCheckBox.Name = "randomizeCheckBox";
            randomizeCheckBox.Size = new System.Drawing.Size(286, 19);
            randomizeCheckBox.TabIndex = 144;
            randomizeCheckBox.Text = "Use a different random number seed for each run";
            randomizeCheckBox.UseVisualStyleBackColor = true;
            randomizeCheckBox.CheckedChanged += randomizeCheckBox_CheckedChanged;
            // 
            // printBriefSummaryCheckBox
            // 
            printBriefSummaryCheckBox.AutoSize = true;
            printBriefSummaryCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "ECHODATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printBriefSummaryCheckBox.Location = new System.Drawing.Point(5, 285);
            printBriefSummaryCheckBox.Name = "printBriefSummaryCheckBox";
            printBriefSummaryCheckBox.Size = new System.Drawing.Size(218, 19);
            printBriefSummaryCheckBox.TabIndex = 143;
            printBriefSummaryCheckBox.Text = "Print a brief summary of the data set";
            printBriefSummaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveIntermediateDataCheckBox
            // 
            saveIntermediateDataCheckBox.AutoSize = true;
            saveIntermediateDataCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "INTERMEDSAVE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            saveIntermediateDataCheckBox.Location = new System.Drawing.Point(5, 265);
            saveIntermediateDataCheckBox.Name = "saveIntermediateDataCheckBox";
            saveIntermediateDataCheckBox.Size = new System.Drawing.Size(146, 19);
            saveIntermediateDataCheckBox.TabIndex = 142;
            saveIntermediateDataCheckBox.Text = "Save intermediate data";
            saveIntermediateDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "PRINTLIKES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            checkBox3.Location = new System.Drawing.Point(5, 245);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(323, 19);
            checkBox3.TabIndex = 141;
            checkBox3.Text = "Print the current value of the likelihood in every iteration";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // printUpdateFreqNumericUpDown
            // 
            printUpdateFreqNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "UPDATEFREQ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printUpdateFreqNumericUpDown.Enabled = false;
            printUpdateFreqNumericUpDown.Location = new System.Drawing.Point(215, 215);
            printUpdateFreqNumericUpDown.Name = "printUpdateFreqNumericUpDown";
            printUpdateFreqNumericUpDown.Size = new System.Drawing.Size(60, 23);
            printUpdateFreqNumericUpDown.TabIndex = 140;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Location = new System.Drawing.Point(25, 220);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(166, 15);
            label5.TabIndex = 139;
            label5.Text = "Frequency of printing updates";
            // 
            // printSumOfQCheckBox
            // 
            printSumOfQCheckBox.AutoSize = true;
            printSumOfQCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", structureExtraparamsBindingSource, "PRINTQSUM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printSumOfQCheckBox.Location = new System.Drawing.Point(5, 175);
            printSumOfQCheckBox.Name = "printSumOfQCheckBox";
            printSumOfQCheckBox.Size = new System.Drawing.Size(275, 19);
            printSumOfQCheckBox.TabIndex = 138;
            printSumOfQCheckBox.Text = "Print summary of current Q estimates to screen";
            printSumOfQCheckBox.UseVisualStyleBackColor = true;
            // 
            // printCurrentLambdaValueCheckBox
            // 
            printCurrentLambdaValueCheckBox.AutoSize = true;
            printCurrentLambdaValueCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "PRINTLAMBDA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printCurrentLambdaValueCheckBox.Location = new System.Drawing.Point(5, 155);
            printCurrentLambdaValueCheckBox.Name = "printCurrentLambdaValueCheckBox";
            printCurrentLambdaValueCheckBox.Size = new System.Drawing.Size(180, 19);
            printCurrentLambdaValueCheckBox.TabIndex = 137;
            printCurrentLambdaValueCheckBox.Text = "Print current value of lambda";
            printCurrentLambdaValueCheckBox.UseVisualStyleBackColor = true;
            // 
            // printNetCheckBox
            // 
            printNetCheckBox.AutoSize = true;
            printNetCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", structureExtraparamsBindingSource, "PRINTNET", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printNetCheckBox.Location = new System.Drawing.Point(5, 135);
            printNetCheckBox.Name = "printNetCheckBox";
            printNetCheckBox.Size = new System.Drawing.Size(298, 19);
            printNetCheckBox.TabIndex = 136;
            printNetCheckBox.Text = "Print the “net nucleotide distance” between clusters";
            printNetCheckBox.UseVisualStyleBackColor = true;
            // 
            // estimateTheProbabiCheckBox
            // 
            estimateTheProbabiCheckBox.AutoSize = true;
            estimateTheProbabiCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "COMPUTEPROB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            estimateTheProbabiCheckBox.Location = new System.Drawing.Point(5, 20);
            estimateTheProbabiCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            estimateTheProbabiCheckBox.Name = "estimateTheProbabiCheckBox";
            estimateTheProbabiCheckBox.Size = new System.Drawing.Size(302, 19);
            estimateTheProbabiCheckBox.TabIndex = 115;
            estimateTheProbabiCheckBox.Text = "Estimate the probability of the data under the model";
            estimateTheProbabiCheckBox.UseVisualStyleBackColor = true;
            // 
            // ancestpintNumericUpDown
            // 
            ancestpintNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "ANCESTPINT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ancestpintNumericUpDown.DecimalPlaces = 2;
            ancestpintNumericUpDown.Enabled = false;
            ancestpintNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ancestpintNumericUpDown.Location = new System.Drawing.Point(215, 85);
            ancestpintNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ancestpintNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ancestpintNumericUpDown.Name = "ancestpintNumericUpDown";
            ancestpintNumericUpDown.Size = new System.Drawing.Size(60, 23);
            ancestpintNumericUpDown.TabIndex = 89;
            // 
            // numboxesNumericUpDown
            // 
            numboxesNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "NUMBOXES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            numboxesNumericUpDown.Enabled = false;
            numboxesNumericUpDown.Location = new System.Drawing.Point(215, 60);
            numboxesNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            numboxesNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            numboxesNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numboxesNumericUpDown.Name = "numboxesNumericUpDown";
            numboxesNumericUpDown.Size = new System.Drawing.Size(60, 23);
            numboxesNumericUpDown.TabIndex = 90;
            numboxesNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // freqOfMetroToUpdQNumericUpDown
            // 
            freqOfMetroToUpdQNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureExtraparamsBindingSource, "METROFREQ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            freqOfMetroToUpdQNumericUpDown.Location = new System.Drawing.Point(215, 350);
            freqOfMetroToUpdQNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            freqOfMetroToUpdQNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            freqOfMetroToUpdQNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            freqOfMetroToUpdQNumericUpDown.Name = "freqOfMetroToUpdQNumericUpDown";
            freqOfMetroToUpdQNumericUpDown.Size = new System.Drawing.Size(60, 23);
            freqOfMetroToUpdQNumericUpDown.TabIndex = 100;
            freqOfMetroToUpdQNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // printCredibleRegCheckBox
            // 
            printCredibleRegCheckBox.AutoSize = true;
            printCredibleRegCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "ANCESTDIST", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printCredibleRegCheckBox.Location = new System.Drawing.Point(5, 40);
            printCredibleRegCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            printCredibleRegCheckBox.Name = "printCredibleRegCheckBox";
            printCredibleRegCheckBox.Size = new System.Drawing.Size(138, 19);
            printCredibleRegCheckBox.TabIndex = 114;
            printCredibleRegCheckBox.Text = "Print credible regions";
            printCredibleRegCheckBox.UseVisualStyleBackColor = true;
            printCredibleRegCheckBox.CheckedChanged += printCredibleRegCheckBox_CheckedChanged;
            // 
            // popinfoInitializeCheckBox
            // 
            popinfoInitializeCheckBox.AutoSize = true;
            popinfoInitializeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "STARTATPOPINFO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            popinfoInitializeCheckBox.Location = new System.Drawing.Point(5, 115);
            popinfoInitializeCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            popinfoInitializeCheckBox.Name = "popinfoInitializeCheckBox";
            popinfoInitializeCheckBox.Size = new System.Drawing.Size(135, 19);
            popinfoInitializeCheckBox.TabIndex = 116;
            popinfoInitializeCheckBox.Text = "Initialize at POPINFO";
            popinfoInitializeCheckBox.UseVisualStyleBackColor = true;
            // 
            // printQhatCheckBox
            // 
            printQhatCheckBox.AutoSize = true;
            printQhatCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureExtraparamsBindingSource, "PRINTQHAT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            printQhatCheckBox.Location = new System.Drawing.Point(5, 195);
            printQhatCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            printQhatCheckBox.Name = "printQhatCheckBox";
            printQhatCheckBox.Size = new System.Drawing.Size(85, 19);
            printQhatCheckBox.TabIndex = 124;
            printQhatCheckBox.Text = "Print Q-hat";
            printQhatCheckBox.UseVisualStyleBackColor = true;
            printQhatCheckBox.CheckedChanged += printQhatCheckBox_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Enabled = false;
            label12.Location = new System.Drawing.Point(25, 90);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(64, 15);
            label12.TabIndex = 126;
            label12.Text = "Ancestpint";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(5, 355);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(198, 15);
            label14.TabIndex = 128;
            label14.Text = "Freq. of metropolis step to update Q";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Enabled = false;
            label22.Location = new System.Drawing.Point(25, 65);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(64, 15);
            label22.TabIndex = 135;
            label22.Text = "Numboxes";
            // 
            // structureDataFileNameLabel
            // 
            structureDataFileNameLabel.AutoSize = true;
            structureDataFileNameLabel.Enabled = false;
            structureDataFileNameLabel.Location = new System.Drawing.Point(175, 5);
            structureDataFileNameLabel.Name = "structureDataFileNameLabel";
            structureDataFileNameLabel.Size = new System.Drawing.Size(83, 15);
            structureDataFileNameLabel.TabIndex = 164;
            structureDataFileNameLabel.Text = "Data file name";
            // 
            // loadStructureDataFileLabel
            // 
            loadStructureDataFileLabel.AutoSize = true;
            loadStructureDataFileLabel.Enabled = false;
            loadStructureDataFileLabel.Location = new System.Drawing.Point(40, 5);
            loadStructureDataFileLabel.Name = "loadStructureDataFileLabel";
            loadStructureDataFileLabel.Size = new System.Drawing.Size(78, 15);
            loadStructureDataFileLabel.TabIndex = 161;
            loadStructureDataFileLabel.Text = "Load data file";
            // 
            // structureSetNameTextBox
            // 
            structureSetNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureConfigurationParametersBindingSource, "SetName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureSetNameTextBox.Enabled = false;
            structureSetNameTextBox.Location = new System.Drawing.Point(465, 20);
            structureSetNameTextBox.MaxLength = 30;
            structureSetNameTextBox.Name = "structureSetNameTextBox";
            structureSetNameTextBox.Size = new System.Drawing.Size(130, 23);
            structureSetNameTextBox.TabIndex = 160;
            structureSetNameTextBox.TextChanged += structureSetNameTextBox_TextChanged;
            // 
            // structureSetNameLabel
            // 
            structureSetNameLabel.AutoSize = true;
            structureSetNameLabel.Enabled = false;
            structureSetNameLabel.Location = new System.Drawing.Point(470, 5);
            structureSetNameLabel.Name = "structureSetNameLabel";
            structureSetNameLabel.Size = new System.Drawing.Size(56, 15);
            structureSetNameLabel.TabIndex = 159;
            structureSetNameLabel.Text = "Set name";
            // 
            // structureParametersSetComboBox
            // 
            structureParametersSetComboBox.Enabled = false;
            structureParametersSetComboBox.FormattingEnabled = true;
            structureParametersSetComboBox.Location = new System.Drawing.Point(330, 20);
            structureParametersSetComboBox.Name = "structureParametersSetComboBox";
            structureParametersSetComboBox.Size = new System.Drawing.Size(130, 23);
            structureParametersSetComboBox.TabIndex = 158;
            structureParametersSetComboBox.SelectedIndexChanged += structureParametersSetComboBox_SelectedIndexChanged;
            // 
            // stopStructureButton
            // 
            stopStructureButton.Enabled = false;
            stopStructureButton.Location = new System.Drawing.Point(905, 545);
            stopStructureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            stopStructureButton.Name = "stopStructureButton";
            stopStructureButton.Size = new System.Drawing.Size(95, 25);
            stopStructureButton.TabIndex = 155;
            stopStructureButton.Text = "Stop";
            stopStructureButton.UseVisualStyleBackColor = true;
            stopStructureButton.Click += stopStructureButton_Click;
            // 
            // saveStructureParamButton
            // 
            saveStructureParamButton.Enabled = false;
            saveStructureParamButton.Location = new System.Drawing.Point(690, 545);
            saveStructureParamButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            saveStructureParamButton.Name = "saveStructureParamButton";
            saveStructureParamButton.Size = new System.Drawing.Size(95, 25);
            saveStructureParamButton.TabIndex = 154;
            saveStructureParamButton.Text = "Save";
            saveStructureParamButton.UseVisualStyleBackColor = true;
            saveStructureParamButton.Click += saveStructureParamButton_Click;
            // 
            // startStructureButton
            // 
            startStructureButton.Enabled = false;
            startStructureButton.Location = new System.Drawing.Point(805, 545);
            startStructureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            startStructureButton.Name = "startStructureButton";
            startStructureButton.Size = new System.Drawing.Size(95, 25);
            startStructureButton.TabIndex = 5;
            startStructureButton.Text = "Start";
            startStructureButton.UseVisualStyleBackColor = true;
            startStructureButton.Click += startStructureButton_Click;
            // 
            // runLenghtGroupBox
            // 
            runLenghtGroupBox.Controls.Add(label11);
            runLenghtGroupBox.Controls.Add(label10);
            runLenghtGroupBox.Controls.Add(burninPeriodNumericUpDown);
            runLenghtGroupBox.Controls.Add(MCMCrepsNumericUpDown);
            runLenghtGroupBox.Enabled = false;
            runLenghtGroupBox.Location = new System.Drawing.Point(35, 50);
            runLenghtGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            runLenghtGroupBox.Name = "runLenghtGroupBox";
            runLenghtGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            runLenghtGroupBox.Size = new System.Drawing.Size(290, 90);
            runLenghtGroupBox.TabIndex = 149;
            runLenghtGroupBox.TabStop = false;
            runLenghtGroupBox.Text = "Run Lenght";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(5, 45);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(196, 15);
            label11.TabIndex = 9;
            label11.Text = "Number of MCMC reps after burnin";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(5, 20);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(133, 15);
            label10.TabIndex = 8;
            label10.Text = "Length of burnin period";
            // 
            // burninPeriodNumericUpDown
            // 
            burninPeriodNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "BURNIN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            burninPeriodNumericUpDown.Location = new System.Drawing.Point(225, 15);
            burninPeriodNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            burninPeriodNumericUpDown.Maximum = new decimal(new int[] { 131072, 0, 0, 0 });
            burninPeriodNumericUpDown.Name = "burninPeriodNumericUpDown";
            burninPeriodNumericUpDown.Size = new System.Drawing.Size(60, 23);
            burninPeriodNumericUpDown.TabIndex = 80;
            // 
            // MCMCrepsNumericUpDown
            // 
            MCMCrepsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "NUMREPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            MCMCrepsNumericUpDown.Location = new System.Drawing.Point(225, 40);
            MCMCrepsNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MCMCrepsNumericUpDown.Maximum = new decimal(new int[] { 131072, 0, 0, 0 });
            MCMCrepsNumericUpDown.Name = "MCMCrepsNumericUpDown";
            MCMCrepsNumericUpDown.Size = new System.Drawing.Size(60, 23);
            MCMCrepsNumericUpDown.TabIndex = 121;
            // 
            // chooseStructureParametersSetLabel
            // 
            chooseStructureParametersSetLabel.AutoSize = true;
            chooseStructureParametersSetLabel.Enabled = false;
            chooseStructureParametersSetLabel.Location = new System.Drawing.Point(335, 5);
            chooseStructureParametersSetLabel.Name = "chooseStructureParametersSetLabel";
            chooseStructureParametersSetLabel.Size = new System.Drawing.Size(127, 15);
            chooseStructureParametersSetLabel.TabIndex = 145;
            chooseStructureParametersSetLabel.Text = "Choose parameters set";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(structureHarvesterLogTextBox);
            tabPage2.Controls.Add(structureHarvesterInputComboBox);
            tabPage2.Controls.Add(structureHarvesterClumppCheckBox);
            tabPage2.Controls.Add(structureHarvesterEvannoCheckBox);
            tabPage2.Controls.Add(structureHarvesterSetForChartLabel);
            tabPage2.Controls.Add(structureHarvesterSetForChartComboBox);
            tabPage2.Controls.Add(structureHarvesterLoadChartButton);
            tabPage2.Controls.Add(structureHarvesterInputLabel);
            tabPage2.Controls.Add(startStructureHarvesterButton);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage2.Size = new System.Drawing.Size(1027, 789);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Structure harvester";
            // 
            // structureHarvesterLogTextBox
            // 
            structureHarvesterLogTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            structureHarvesterLogTextBox.Location = new System.Drawing.Point(5, 580);
            structureHarvesterLogTextBox.Multiline = true;
            structureHarvesterLogTextBox.Name = "structureHarvesterLogTextBox";
            structureHarvesterLogTextBox.ReadOnly = true;
            structureHarvesterLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            structureHarvesterLogTextBox.Size = new System.Drawing.Size(1017, 202);
            structureHarvesterLogTextBox.TabIndex = 175;
            structureHarvesterLogTextBox.WordWrap = false;
            // 
            // structureHarvesterInputComboBox
            // 
            structureHarvesterInputComboBox.Enabled = false;
            structureHarvesterInputComboBox.FormattingEnabled = true;
            structureHarvesterInputComboBox.Location = new System.Drawing.Point(5, 545);
            structureHarvesterInputComboBox.Name = "structureHarvesterInputComboBox";
            structureHarvesterInputComboBox.Size = new System.Drawing.Size(110, 23);
            structureHarvesterInputComboBox.TabIndex = 110;
            structureHarvesterInputComboBox.SelectedIndexChanged += structureHarvesterInputComboBox_SelectedIndexChanged;
            // 
            // structureHarvesterClumppCheckBox
            // 
            structureHarvesterClumppCheckBox.AutoSize = true;
            structureHarvesterClumppCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureHarvesterConfigurationParametersBindingSource, "Clumpp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureHarvesterClumppCheckBox.Enabled = false;
            structureHarvesterClumppCheckBox.Location = new System.Drawing.Point(125, 550);
            structureHarvesterClumppCheckBox.Name = "structureHarvesterClumppCheckBox";
            structureHarvesterClumppCheckBox.Size = new System.Drawing.Size(132, 19);
            structureHarvesterClumppCheckBox.TabIndex = 109;
            structureHarvesterClumppCheckBox.Text = "Output for CLUMPP";
            structureHarvesterClumppCheckBox.UseVisualStyleBackColor = true;
            // 
            // structureHarvesterConfigurationParametersBindingSource
            // 
            structureHarvesterConfigurationParametersBindingSource.DataSource = typeof(Additional_programs_logic.Structure_Harvester.StructureHarvesterConfigurationParametersModel);
            // 
            // structureHarvesterEvannoCheckBox
            // 
            structureHarvesterEvannoCheckBox.AutoSize = true;
            structureHarvesterEvannoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureHarvesterConfigurationParametersBindingSource, "Evanno", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            structureHarvesterEvannoCheckBox.Enabled = false;
            structureHarvesterEvannoCheckBox.Location = new System.Drawing.Point(125, 525);
            structureHarvesterEvannoCheckBox.Name = "structureHarvesterEvannoCheckBox";
            structureHarvesterEvannoCheckBox.Size = new System.Drawing.Size(110, 19);
            structureHarvesterEvannoCheckBox.TabIndex = 108;
            structureHarvesterEvannoCheckBox.Text = "Method evanno";
            structureHarvesterEvannoCheckBox.UseVisualStyleBackColor = true;
            // 
            // structureHarvesterSetForChartLabel
            // 
            structureHarvesterSetForChartLabel.AutoSize = true;
            structureHarvesterSetForChartLabel.Enabled = false;
            structureHarvesterSetForChartLabel.Location = new System.Drawing.Point(742, 525);
            structureHarvesterSetForChartLabel.Name = "structureHarvesterSetForChartLabel";
            structureHarvesterSetForChartLabel.Size = new System.Drawing.Size(135, 15);
            structureHarvesterSetForChartLabel.TabIndex = 107;
            structureHarvesterSetForChartLabel.Text = "Processed parameter set";
            // 
            // structureHarvesterSetForChartComboBox
            // 
            structureHarvesterSetForChartComboBox.Enabled = false;
            structureHarvesterSetForChartComboBox.FormattingEnabled = true;
            structureHarvesterSetForChartComboBox.Location = new System.Drawing.Point(742, 545);
            structureHarvesterSetForChartComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterSetForChartComboBox.Name = "structureHarvesterSetForChartComboBox";
            structureHarvesterSetForChartComboBox.Size = new System.Drawing.Size(110, 23);
            structureHarvesterSetForChartComboBox.TabIndex = 103;
            // 
            // structureHarvesterLoadChartButton
            // 
            structureHarvesterLoadChartButton.Enabled = false;
            structureHarvesterLoadChartButton.Location = new System.Drawing.Point(887, 525);
            structureHarvesterLoadChartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            structureHarvesterLoadChartButton.Name = "structureHarvesterLoadChartButton";
            structureHarvesterLoadChartButton.Size = new System.Drawing.Size(135, 50);
            structureHarvesterLoadChartButton.TabIndex = 105;
            structureHarvesterLoadChartButton.Text = "Load charts";
            structureHarvesterLoadChartButton.UseVisualStyleBackColor = true;
            structureHarvesterLoadChartButton.Click += structureHarvesterLoadChartButton_Click;
            // 
            // structureHarvesterInputLabel
            // 
            structureHarvesterInputLabel.AutoSize = true;
            structureHarvesterInputLabel.Enabled = false;
            structureHarvesterInputLabel.Location = new System.Drawing.Point(5, 525);
            structureHarvesterInputLabel.Name = "structureHarvesterInputLabel";
            structureHarvesterInputLabel.Size = new System.Drawing.Size(112, 15);
            structureHarvesterInputLabel.TabIndex = 101;
            structureHarvesterInputLabel.Text = "Structure output set";
            // 
            // startStructureHarvesterButton
            // 
            startStructureHarvesterButton.Enabled = false;
            startStructureHarvesterButton.Location = new System.Drawing.Point(260, 525);
            startStructureHarvesterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            startStructureHarvesterButton.Name = "startStructureHarvesterButton";
            startStructureHarvesterButton.Size = new System.Drawing.Size(135, 50);
            startStructureHarvesterButton.TabIndex = 100;
            startStructureHarvesterButton.Text = "Start processing";
            startStructureHarvesterButton.UseVisualStyleBackColor = true;
            startStructureHarvesterButton.MouseClick += startStructureHarvesterButton_MouseClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(clumppPopAndIndRadioButton);
            tabPage3.Controls.Add(clumppOnlyPopRadioButton);
            tabPage3.Controls.Add(clumppStopButton);
            tabPage3.Controls.Add(clumppLogTextBox);
            tabPage3.Controls.Add(CLUMPPKToLabel);
            tabPage3.Controls.Add(CLUMPPKFromLabel);
            tabPage3.Controls.Add(CLUMPPKToNumericUpDown);
            tabPage3.Controls.Add(CLUMPPKFromNumericUpDown);
            tabPage3.Controls.Add(CLUMPPInputComboBox);
            tabPage3.Controls.Add(CLUMPPInputLabel);
            tabPage3.Controls.Add(SaveCLUMPPParamSetButt);
            tabPage3.Controls.Add(StartCLUMPPButt);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(CLUMPPParametersComboBox);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(groupBox9);
            tabPage3.Controls.Add(groupBox8);
            tabPage3.Controls.Add(groupBox7);
            tabPage3.Controls.Add(groupBox6);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(1027, 789);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "CLUMPP";
            // 
            // clumppPopAndIndRadioButton
            // 
            clumppPopAndIndRadioButton.AutoSize = true;
            clumppPopAndIndRadioButton.Enabled = false;
            clumppPopAndIndRadioButton.Location = new System.Drawing.Point(508, 165);
            clumppPopAndIndRadioButton.Name = "clumppPopAndIndRadioButton";
            clumppPopAndIndRadioButton.Size = new System.Drawing.Size(159, 19);
            clumppPopAndIndRadioButton.TabIndex = 179;
            clumppPopAndIndRadioButton.Text = "Populations + individuals";
            clumppPopAndIndRadioButton.UseVisualStyleBackColor = true;
            clumppPopAndIndRadioButton.CheckedChanged += clumppPopAndIndRadioButton_CheckedChanged;
            // 
            // clumppOnlyPopRadioButton
            // 
            clumppOnlyPopRadioButton.AutoSize = true;
            clumppOnlyPopRadioButton.Checked = true;
            clumppOnlyPopRadioButton.Enabled = false;
            clumppOnlyPopRadioButton.Location = new System.Drawing.Point(378, 165);
            clumppOnlyPopRadioButton.Name = "clumppOnlyPopRadioButton";
            clumppOnlyPopRadioButton.Size = new System.Drawing.Size(116, 19);
            clumppOnlyPopRadioButton.TabIndex = 178;
            clumppOnlyPopRadioButton.TabStop = true;
            clumppOnlyPopRadioButton.Text = "Only populations";
            clumppOnlyPopRadioButton.UseVisualStyleBackColor = true;
            // 
            // clumppStopButton
            // 
            clumppStopButton.Enabled = false;
            clumppStopButton.Location = new System.Drawing.Point(716, 440);
            clumppStopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            clumppStopButton.Name = "clumppStopButton";
            clumppStopButton.Size = new System.Drawing.Size(95, 25);
            clumppStopButton.TabIndex = 177;
            clumppStopButton.Text = "Stop";
            clumppStopButton.UseVisualStyleBackColor = true;
            clumppStopButton.Click += clumppStopButton_Click;
            // 
            // clumppLogTextBox
            // 
            clumppLogTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            clumppLogTextBox.Location = new System.Drawing.Point(5, 580);
            clumppLogTextBox.Multiline = true;
            clumppLogTextBox.Name = "clumppLogTextBox";
            clumppLogTextBox.ReadOnly = true;
            clumppLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            clumppLogTextBox.Size = new System.Drawing.Size(1017, 202);
            clumppLogTextBox.TabIndex = 176;
            clumppLogTextBox.WordWrap = false;
            // 
            // CLUMPPKToLabel
            // 
            CLUMPPKToLabel.AutoSize = true;
            CLUMPPKToLabel.Enabled = false;
            CLUMPPKToLabel.Location = new System.Drawing.Point(320, 445);
            CLUMPPKToLabel.Name = "CLUMPPKToLabel";
            CLUMPPKToLabel.Size = new System.Drawing.Size(18, 15);
            CLUMPPKToLabel.TabIndex = 175;
            CLUMPPKToLabel.Text = "to";
            // 
            // CLUMPPKFromLabel
            // 
            CLUMPPKFromLabel.AutoSize = true;
            CLUMPPKFromLabel.Enabled = false;
            CLUMPPKFromLabel.Location = new System.Drawing.Point(216, 445);
            CLUMPPKFromLabel.Name = "CLUMPPKFromLabel";
            CLUMPPKFromLabel.Size = new System.Drawing.Size(49, 15);
            CLUMPPKFromLabel.TabIndex = 174;
            CLUMPPKFromLabel.Text = "'K' from";
            // 
            // CLUMPPKToNumericUpDown
            // 
            CLUMPPKToNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPConfigurationParametersBindingSource, "KEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            CLUMPPKToNumericUpDown.Enabled = false;
            CLUMPPKToNumericUpDown.Location = new System.Drawing.Point(343, 440);
            CLUMPPKToNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CLUMPPKToNumericUpDown.Name = "CLUMPPKToNumericUpDown";
            CLUMPPKToNumericUpDown.Size = new System.Drawing.Size(45, 23);
            CLUMPPKToNumericUpDown.TabIndex = 173;
            CLUMPPKToNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // CLUMPPConfigurationParametersBindingSource
            // 
            CLUMPPConfigurationParametersBindingSource.DataSource = typeof(Additional_programs_logic.CLUMPP.CLUMPPConfigurationParametersModel);
            // 
            // CLUMPPKFromNumericUpDown
            // 
            CLUMPPKFromNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPConfigurationParametersBindingSource, "KStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            CLUMPPKFromNumericUpDown.Enabled = false;
            CLUMPPKFromNumericUpDown.Location = new System.Drawing.Point(270, 440);
            CLUMPPKFromNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CLUMPPKFromNumericUpDown.Name = "CLUMPPKFromNumericUpDown";
            CLUMPPKFromNumericUpDown.Size = new System.Drawing.Size(45, 23);
            CLUMPPKFromNumericUpDown.TabIndex = 172;
            CLUMPPKFromNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // CLUMPPInputComboBox
            // 
            CLUMPPInputComboBox.FormattingEnabled = true;
            CLUMPPInputComboBox.Location = new System.Drawing.Point(216, 136);
            CLUMPPInputComboBox.Name = "CLUMPPInputComboBox";
            CLUMPPInputComboBox.Size = new System.Drawing.Size(130, 23);
            CLUMPPInputComboBox.TabIndex = 171;
            CLUMPPInputComboBox.SelectedIndexChanged += CLUMPPInputComboBox_SelectedIndexChanged;
            // 
            // CLUMPPInputLabel
            // 
            CLUMPPInputLabel.AutoSize = true;
            CLUMPPInputLabel.Location = new System.Drawing.Point(216, 121);
            CLUMPPInputLabel.Name = "CLUMPPInputLabel";
            CLUMPPInputLabel.Size = new System.Drawing.Size(165, 15);
            CLUMPPInputLabel.TabIndex = 170;
            CLUMPPInputLabel.Text = "Structure Harvester output set";
            // 
            // SaveCLUMPPParamSetButt
            // 
            SaveCLUMPPParamSetButt.Enabled = false;
            SaveCLUMPPParamSetButt.Location = new System.Drawing.Point(426, 440);
            SaveCLUMPPParamSetButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SaveCLUMPPParamSetButt.Name = "SaveCLUMPPParamSetButt";
            SaveCLUMPPParamSetButt.Size = new System.Drawing.Size(95, 25);
            SaveCLUMPPParamSetButt.TabIndex = 169;
            SaveCLUMPPParamSetButt.Text = "Save";
            SaveCLUMPPParamSetButt.UseVisualStyleBackColor = true;
            SaveCLUMPPParamSetButt.MouseClick += SaveCLUMPPParamSetButt_MouseClick;
            // 
            // StartCLUMPPButt
            // 
            StartCLUMPPButt.Enabled = false;
            StartCLUMPPButt.Location = new System.Drawing.Point(616, 440);
            StartCLUMPPButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            StartCLUMPPButt.Name = "StartCLUMPPButt";
            StartCLUMPPButt.Size = new System.Drawing.Size(95, 25);
            StartCLUMPPButt.TabIndex = 168;
            StartCLUMPPButt.Text = "Start";
            StartCLUMPPButt.UseVisualStyleBackColor = true;
            StartCLUMPPButt.MouseClick += StartCLUMPPButt_MouseClick;
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", CLUMPPConfigurationParametersBindingSource, "CurrentParamFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            textBox3.Location = new System.Drawing.Point(661, 136);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(130, 23);
            textBox3.TabIndex = 167;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(661, 121);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(94, 15);
            label3.TabIndex = 166;
            label3.Text = "Parameter name";
            // 
            // CLUMPPParametersComboBox
            // 
            CLUMPPParametersComboBox.FormattingEnabled = true;
            CLUMPPParametersComboBox.Location = new System.Drawing.Point(526, 136);
            CLUMPPParametersComboBox.Name = "CLUMPPParametersComboBox";
            CLUMPPParametersComboBox.Size = new System.Drawing.Size(130, 23);
            CLUMPPParametersComboBox.TabIndex = 165;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(526, 121);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(123, 15);
            label7.TabIndex = 164;
            label7.Text = "Choose parameter file";
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(clumppSCheckBox);
            groupBox9.Controls.Add(clumppOrderByRunNumericUpDown);
            groupBox9.Controls.Add(clumppOrderByRunLabel);
            groupBox9.Controls.Add(clumppWCheckBox);
            groupBox9.Controls.Add(OverrideWarningCheck);
            groupBox9.Enabled = false;
            groupBox9.Location = new System.Drawing.Point(216, 315);
            groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox9.Size = new System.Drawing.Size(305, 120);
            groupBox9.TabIndex = 111;
            groupBox9.TabStop = false;
            groupBox9.Text = "Advanced options";
            // 
            // clumppSCheckBox
            // 
            clumppSCheckBox.AutoSize = true;
            clumppSCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", CLUMPPParametersModelBindingSource, "S", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            clumppSCheckBox.Location = new System.Drawing.Point(5, 90);
            clumppSCheckBox.Name = "clumppSCheckBox";
            clumppSCheckBox.Size = new System.Drawing.Size(226, 19);
            clumppSCheckBox.TabIndex = 96;
            clumppSCheckBox.Text = "Use alternative similarity statistic [0, 1]";
            clumppSCheckBox.UseVisualStyleBackColor = true;
            // 
            // CLUMPPParametersModelBindingSource
            // 
            CLUMPPParametersModelBindingSource.DataSource = typeof(Additional_programs_logic.CLUMPP.CLUMPPParametersModel);
            // 
            // clumppOrderByRunNumericUpDown
            // 
            clumppOrderByRunNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPParametersModelBindingSource, "ORDER_BY_RUN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            clumppOrderByRunNumericUpDown.Location = new System.Drawing.Point(190, 60);
            clumppOrderByRunNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            clumppOrderByRunNumericUpDown.Name = "clumppOrderByRunNumericUpDown";
            clumppOrderByRunNumericUpDown.Size = new System.Drawing.Size(80, 23);
            clumppOrderByRunNumericUpDown.TabIndex = 95;
            // 
            // clumppOrderByRunLabel
            // 
            clumppOrderByRunLabel.AutoSize = true;
            clumppOrderByRunLabel.Location = new System.Drawing.Point(5, 65);
            clumppOrderByRunLabel.Name = "clumppOrderByRunLabel";
            clumppOrderByRunLabel.Size = new System.Drawing.Size(74, 15);
            clumppOrderByRunLabel.TabIndex = 94;
            clumppOrderByRunLabel.Text = "Order by run";
            // 
            // clumppWCheckBox
            // 
            clumppWCheckBox.AutoSize = true;
            clumppWCheckBox.Location = new System.Drawing.Point(5, 20);
            clumppWCheckBox.Name = "clumppWCheckBox";
            clumppWCheckBox.Size = new System.Drawing.Size(267, 19);
            clumppWCheckBox.TabIndex = 93;
            clumppWCheckBox.Text = "Weighing based on the number of individuals";
            clumppWCheckBox.UseVisualStyleBackColor = true;
            // 
            // OverrideWarningCheck
            // 
            OverrideWarningCheck.AutoSize = true;
            OverrideWarningCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", CLUMPPParametersModelBindingSource, "OVERRIDE_WARNINGS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            OverrideWarningCheck.Location = new System.Drawing.Point(5, 40);
            OverrideWarningCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            OverrideWarningCheck.Name = "OverrideWarningCheck";
            OverrideWarningCheck.Size = new System.Drawing.Size(122, 19);
            OverrideWarningCheck.TabIndex = 91;
            OverrideWarningCheck.Text = "Override warnings";
            OverrideWarningCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(comboBox1);
            groupBox8.Controls.Add(PrintRandomInputCheck);
            groupBox8.Controls.Add(PrintEveryPermCheck);
            groupBox8.Controls.Add(label15);
            groupBox8.Enabled = false;
            groupBox8.Location = new System.Drawing.Point(526, 190);
            groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox8.Size = new System.Drawing.Size(285, 120);
            groupBox8.TabIndex = 110;
            groupBox8.TabStop = false;
            groupBox8.Text = "Optional outputs";
            // 
            // comboBox1
            // 
            comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", CLUMPPParametersModelBindingSource, "PRINT_PERMUTED_DATA", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "don't print", "print into one file", "print each run into separate files" });
            comboBox1.Location = new System.Drawing.Point(170, 17);
            comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(80, 23);
            comboBox1.TabIndex = 180;
            comboBox1.Text = "don't print";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // PrintRandomInputCheck
            // 
            PrintRandomInputCheck.AutoSize = true;
            PrintRandomInputCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", CLUMPPParametersModelBindingSource, "PRINT_RANDOM_INPUTORDER", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintRandomInputCheck.Location = new System.Drawing.Point(5, 65);
            PrintRandomInputCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintRandomInputCheck.Name = "PrintRandomInputCheck";
            PrintRandomInputCheck.Size = new System.Drawing.Size(158, 19);
            PrintRandomInputCheck.TabIndex = 89;
            PrintRandomInputCheck.Text = "Print random input order";
            PrintRandomInputCheck.UseVisualStyleBackColor = true;
            // 
            // PrintEveryPermCheck
            // 
            PrintEveryPermCheck.AutoSize = true;
            PrintEveryPermCheck.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", CLUMPPParametersModelBindingSource, "PRINT_EVERY_PERM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintEveryPermCheck.Location = new System.Drawing.Point(5, 45);
            PrintEveryPermCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintEveryPermCheck.Name = "PrintEveryPermCheck";
            PrintEveryPermCheck.Size = new System.Drawing.Size(113, 19);
            PrintEveryPermCheck.TabIndex = 90;
            PrintEveryPermCheck.Text = "Print every perm";
            PrintEveryPermCheck.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(5, 20);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(113, 15);
            label15.TabIndex = 107;
            label15.Text = "Print permuted data";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(GreedyOptionChoose);
            groupBox7.Controls.Add(ChooseButt);
            groupBox7.Controls.Add(clumppGreedyOptionLabel);
            groupBox7.Controls.Add(clumppRepeatsLabel);
            groupBox7.Controls.Add(clumppPermutationFilelabel);
            groupBox7.Controls.Add(RepeatsNum);
            groupBox7.Controls.Add(PermutationFileText);
            groupBox7.Enabled = false;
            groupBox7.Location = new System.Drawing.Point(526, 315);
            groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox7.Size = new System.Drawing.Size(285, 120);
            groupBox7.TabIndex = 109;
            groupBox7.TabStop = false;
            groupBox7.Text = "Options for algorithms";
            // 
            // GreedyOptionChoose
            // 
            GreedyOptionChoose.Enabled = false;
            GreedyOptionChoose.FormattingEnabled = true;
            GreedyOptionChoose.Items.AddRange(new object[] { "all possible input orders", "random input orders", "pre-specified input orders" });
            GreedyOptionChoose.Location = new System.Drawing.Point(170, 12);
            GreedyOptionChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            GreedyOptionChoose.Name = "GreedyOptionChoose";
            GreedyOptionChoose.Size = new System.Drawing.Size(80, 23);
            GreedyOptionChoose.TabIndex = 180;
            GreedyOptionChoose.Text = "all possible input orders";
            GreedyOptionChoose.SelectedIndexChanged += GreedyOptionChoose_SelectedIndexChanged;
            // 
            // ChooseButt
            // 
            ChooseButt.Enabled = false;
            ChooseButt.Location = new System.Drawing.Point(170, 90);
            ChooseButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ChooseButt.Name = "ChooseButt";
            ChooseButt.Size = new System.Drawing.Size(80, 25);
            ChooseButt.TabIndex = 87;
            ChooseButt.Text = "Choose";
            ChooseButt.UseVisualStyleBackColor = true;
            ChooseButt.Click += ChooseButt_Click;
            // 
            // clumppGreedyOptionLabel
            // 
            clumppGreedyOptionLabel.AutoSize = true;
            clumppGreedyOptionLabel.Enabled = false;
            clumppGreedyOptionLabel.Location = new System.Drawing.Point(5, 20);
            clumppGreedyOptionLabel.Name = "clumppGreedyOptionLabel";
            clumppGreedyOptionLabel.Size = new System.Drawing.Size(82, 15);
            clumppGreedyOptionLabel.TabIndex = 19;
            clumppGreedyOptionLabel.Text = "Greedy option";
            // 
            // clumppRepeatsLabel
            // 
            clumppRepeatsLabel.AutoSize = true;
            clumppRepeatsLabel.Enabled = false;
            clumppRepeatsLabel.Location = new System.Drawing.Point(5, 45);
            clumppRepeatsLabel.Name = "clumppRepeatsLabel";
            clumppRepeatsLabel.Size = new System.Drawing.Size(48, 15);
            clumppRepeatsLabel.TabIndex = 20;
            clumppRepeatsLabel.Text = "Repeats";
            // 
            // clumppPermutationFilelabel
            // 
            clumppPermutationFilelabel.AutoSize = true;
            clumppPermutationFilelabel.Enabled = false;
            clumppPermutationFilelabel.Location = new System.Drawing.Point(5, 70);
            clumppPermutationFilelabel.Name = "clumppPermutationFilelabel";
            clumppPermutationFilelabel.Size = new System.Drawing.Size(135, 15);
            clumppPermutationFilelabel.TabIndex = 21;
            clumppPermutationFilelabel.Text = "Choose permutation file";
            // 
            // RepeatsNum
            // 
            RepeatsNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPParametersModelBindingSource, "REPEATS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            RepeatsNum.Enabled = false;
            RepeatsNum.Location = new System.Drawing.Point(170, 40);
            RepeatsNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            RepeatsNum.Maximum = new decimal(new int[] { 27000000, 0, 0, 0 });
            RepeatsNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RepeatsNum.Name = "RepeatsNum";
            RepeatsNum.Size = new System.Drawing.Size(80, 23);
            RepeatsNum.TabIndex = 80;
            RepeatsNum.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // PermutationFileText
            // 
            PermutationFileText.DataBindings.Add(new System.Windows.Forms.Binding("Text", CLUMPPConfigurationParametersBindingSource, "InputOriginalPermFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PermutationFileText.Enabled = false;
            PermutationFileText.Location = new System.Drawing.Point(5, 90);
            PermutationFileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PermutationFileText.Name = "PermutationFileText";
            PermutationFileText.Size = new System.Drawing.Size(159, 23);
            PermutationFileText.TabIndex = 86;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(numOfPopulationsLabel);
            groupBox6.Controls.Add(numOfPopulationsNumericUpDown);
            groupBox6.Controls.Add(label42);
            groupBox6.Controls.Add(label43);
            groupBox6.Controls.Add(label45);
            groupBox6.Controls.Add(MethodUsedChoose);
            groupBox6.Controls.Add(IndividualsNum);
            groupBox6.Controls.Add(NumberOfIterationsNum);
            groupBox6.Enabled = false;
            groupBox6.Location = new System.Drawing.Point(216, 190);
            groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox6.Size = new System.Drawing.Size(305, 120);
            groupBox6.TabIndex = 108;
            groupBox6.TabStop = false;
            groupBox6.Text = "Main parameters";
            // 
            // numOfPopulationsLabel
            // 
            numOfPopulationsLabel.AutoSize = true;
            numOfPopulationsLabel.Location = new System.Drawing.Point(5, 70);
            numOfPopulationsLabel.Name = "numOfPopulationsLabel";
            numOfPopulationsLabel.Size = new System.Drawing.Size(131, 15);
            numOfPopulationsLabel.TabIndex = 86;
            numOfPopulationsLabel.Text = "Number of populations";
            // 
            // numOfPopulationsNumericUpDown
            // 
            numOfPopulationsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPParametersModelBindingSource, "NumOfPop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            numOfPopulationsNumericUpDown.Location = new System.Drawing.Point(190, 65);
            numOfPopulationsNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            numOfPopulationsNumericUpDown.Maximum = new decimal(new int[] { 27000000, 0, 0, 0 });
            numOfPopulationsNumericUpDown.Name = "numOfPopulationsNumericUpDown";
            numOfPopulationsNumericUpDown.Size = new System.Drawing.Size(80, 23);
            numOfPopulationsNumericUpDown.TabIndex = 87;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(5, 20);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(153, 15);
            label42.TabIndex = 15;
            label42.Text = "Number of iterations over K";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new System.Drawing.Point(5, 45);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(125, 15);
            label43.TabIndex = 16;
            label43.Text = "Number of individuals";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(5, 95);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(107, 15);
            label45.TabIndex = 18;
            label45.Text = "Method to be used";
            // 
            // MethodUsedChoose
            // 
            MethodUsedChoose.FormattingEnabled = true;
            MethodUsedChoose.Items.AddRange(new object[] { "FullSearch", "Greedy", "LargeKGreedy" });
            MethodUsedChoose.Location = new System.Drawing.Point(190, 90);
            MethodUsedChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MethodUsedChoose.Name = "MethodUsedChoose";
            MethodUsedChoose.Size = new System.Drawing.Size(80, 23);
            MethodUsedChoose.TabIndex = 82;
            MethodUsedChoose.Text = "FullSearch";
            MethodUsedChoose.SelectedIndexChanged += MethodUsedChoose_SelectedIndexChanged;
            // 
            // IndividualsNum
            // 
            IndividualsNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPParametersModelBindingSource, "NumOfInd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            IndividualsNum.Location = new System.Drawing.Point(190, 40);
            IndividualsNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            IndividualsNum.Maximum = new decimal(new int[] { 27000000, 0, 0, 0 });
            IndividualsNum.Name = "IndividualsNum";
            IndividualsNum.Size = new System.Drawing.Size(80, 23);
            IndividualsNum.TabIndex = 84;
            // 
            // NumberOfIterationsNum
            // 
            NumberOfIterationsNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", CLUMPPParametersModelBindingSource, "R", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NumberOfIterationsNum.Location = new System.Drawing.Point(190, 15);
            NumberOfIterationsNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NumberOfIterationsNum.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumberOfIterationsNum.Name = "NumberOfIterationsNum";
            NumberOfIterationsNum.Size = new System.Drawing.Size(80, 23);
            NumberOfIterationsNum.TabIndex = 85;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label1);
            tabPage4.Controls.Add(distructStopButton);
            tabPage4.Controls.Add(distructLogTextBox);
            tabPage4.Controls.Add(distructPre_renderedComboBox);
            tabPage4.Controls.Add(distructPre_renderedButton);
            tabPage4.Controls.Add(distructPre_renderedPictureBox);
            tabPage4.Controls.Add(distructExportGroupBox);
            tabPage4.Controls.Add(distructKToLabel);
            tabPage4.Controls.Add(distructKToNumericUpDown);
            tabPage4.Controls.Add(distructKFromLabel);
            tabPage4.Controls.Add(distructKFromNumericUpDown);
            tabPage4.Controls.Add(distructInputComboBox);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(groupBox12);
            tabPage4.Controls.Add(textBox4);
            tabPage4.Controls.Add(SaveDistructaParamSetButt);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(StartDistructaButt);
            tabPage4.Controls.Add(groupBox13);
            tabPage4.Controls.Add(distructParametersComboBox);
            tabPage4.Controls.Add(label9);
            tabPage4.Controls.Add(groupBox11);
            tabPage4.Controls.Add(groupBox10);
            tabPage4.Controls.Add(label54);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(1027, 789);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Distruct";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new System.Drawing.Point(669, 377);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 15);
            label1.TabIndex = 187;
            label1.Text = "Choose 'K' numder";
            // 
            // distructStopButton
            // 
            distructStopButton.Enabled = false;
            distructStopButton.Location = new System.Drawing.Point(568, 511);
            distructStopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            distructStopButton.Name = "distructStopButton";
            distructStopButton.Size = new System.Drawing.Size(95, 25);
            distructStopButton.TabIndex = 186;
            distructStopButton.Text = "Stop";
            distructStopButton.UseVisualStyleBackColor = true;
            distructStopButton.Click += distructStopButton_Click;
            // 
            // distructLogTextBox
            // 
            distructLogTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            distructLogTextBox.Location = new System.Drawing.Point(5, 580);
            distructLogTextBox.Multiline = true;
            distructLogTextBox.Name = "distructLogTextBox";
            distructLogTextBox.ReadOnly = true;
            distructLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            distructLogTextBox.Size = new System.Drawing.Size(1017, 202);
            distructLogTextBox.TabIndex = 185;
            distructLogTextBox.WordWrap = false;
            // 
            // distructPre_renderedComboBox
            // 
            distructPre_renderedComboBox.Enabled = false;
            distructPre_renderedComboBox.FormattingEnabled = true;
            distructPre_renderedComboBox.Location = new System.Drawing.Point(666, 395);
            distructPre_renderedComboBox.Name = "distructPre_renderedComboBox";
            distructPre_renderedComboBox.Size = new System.Drawing.Size(121, 23);
            distructPre_renderedComboBox.TabIndex = 184;
            // 
            // distructPre_renderedButton
            // 
            distructPre_renderedButton.Enabled = false;
            distructPre_renderedButton.Location = new System.Drawing.Point(811, 395);
            distructPre_renderedButton.Name = "distructPre_renderedButton";
            distructPre_renderedButton.Size = new System.Drawing.Size(200, 25);
            distructPre_renderedButton.TabIndex = 183;
            distructPre_renderedButton.Text = "Show pre-rendered";
            distructPre_renderedButton.UseVisualStyleBackColor = true;
            distructPre_renderedButton.Click += distructPre_renderedButton_Click;
            // 
            // distructPre_renderedPictureBox
            // 
            distructPre_renderedPictureBox.Location = new System.Drawing.Point(666, 73);
            distructPre_renderedPictureBox.Name = "distructPre_renderedPictureBox";
            distructPre_renderedPictureBox.Size = new System.Drawing.Size(345, 300);
            distructPre_renderedPictureBox.TabIndex = 182;
            distructPre_renderedPictureBox.TabStop = false;
            // 
            // distructExportGroupBox
            // 
            distructExportGroupBox.Controls.Add(label4);
            distructExportGroupBox.Controls.Add(distructProcessedSetsToExportComboBox);
            distructExportGroupBox.Controls.Add(distructExportButton);
            distructExportGroupBox.Controls.Add(distructExportTypeCheckedListBox);
            distructExportGroupBox.Enabled = false;
            distructExportGroupBox.Location = new System.Drawing.Point(666, 427);
            distructExportGroupBox.Name = "distructExportGroupBox";
            distructExportGroupBox.Size = new System.Drawing.Size(345, 81);
            distructExportGroupBox.TabIndex = 181;
            distructExportGroupBox.TabStop = false;
            distructExportGroupBox.Text = "Export options";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(218, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(121, 15);
            label4.TabIndex = 3;
            label4.Text = "Choose processed set";
            // 
            // distructProcessedSetsToExportComboBox
            // 
            distructProcessedSetsToExportComboBox.FormattingEnabled = true;
            distructProcessedSetsToExportComboBox.Location = new System.Drawing.Point(215, 30);
            distructProcessedSetsToExportComboBox.Name = "distructProcessedSetsToExportComboBox";
            distructProcessedSetsToExportComboBox.Size = new System.Drawing.Size(121, 23);
            distructProcessedSetsToExportComboBox.TabIndex = 2;
            // 
            // distructExportButton
            // 
            distructExportButton.Location = new System.Drawing.Point(215, 53);
            distructExportButton.Name = "distructExportButton";
            distructExportButton.Size = new System.Drawing.Size(121, 23);
            distructExportButton.TabIndex = 1;
            distructExportButton.Text = "Export";
            distructExportButton.UseVisualStyleBackColor = true;
            distructExportButton.Click += distructExportButton_Click;
            // 
            // distructExportTypeCheckedListBox
            // 
            distructExportTypeCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            distructExportTypeCheckedListBox.CheckOnClick = true;
            distructExportTypeCheckedListBox.ColumnWidth = 70;
            distructExportTypeCheckedListBox.FormattingEnabled = true;
            distructExportTypeCheckedListBox.Items.AddRange(new object[] { "" });
            distructExportTypeCheckedListBox.Location = new System.Drawing.Point(6, 18);
            distructExportTypeCheckedListBox.MultiColumn = true;
            distructExportTypeCheckedListBox.Name = "distructExportTypeCheckedListBox";
            distructExportTypeCheckedListBox.Size = new System.Drawing.Size(145, 58);
            distructExportTypeCheckedListBox.TabIndex = 0;
            // 
            // distructKToLabel
            // 
            distructKToLabel.AutoSize = true;
            distructKToLabel.Enabled = false;
            distructKToLabel.Location = new System.Drawing.Point(115, 516);
            distructKToLabel.Name = "distructKToLabel";
            distructKToLabel.Size = new System.Drawing.Size(18, 15);
            distructKToLabel.TabIndex = 180;
            distructKToLabel.Text = "to";
            // 
            // distructKToNumericUpDown
            // 
            distructKToNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructConfigurationParametersBindingSource, "KEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            distructKToNumericUpDown.Enabled = false;
            distructKToNumericUpDown.Location = new System.Drawing.Point(138, 511);
            distructKToNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            distructKToNumericUpDown.Name = "distructKToNumericUpDown";
            distructKToNumericUpDown.Size = new System.Drawing.Size(45, 23);
            distructKToNumericUpDown.TabIndex = 179;
            distructKToNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // distructConfigurationParametersBindingSource
            // 
            distructConfigurationParametersBindingSource.DataSource = typeof(Additional_programs_logic.Distruct.DistructConfigurationParametersModel);
            // 
            // distructKFromLabel
            // 
            distructKFromLabel.AutoSize = true;
            distructKFromLabel.Enabled = false;
            distructKFromLabel.Location = new System.Drawing.Point(11, 516);
            distructKFromLabel.Name = "distructKFromLabel";
            distructKFromLabel.Size = new System.Drawing.Size(49, 15);
            distructKFromLabel.TabIndex = 178;
            distructKFromLabel.Text = "'K' from";
            // 
            // distructKFromNumericUpDown
            // 
            distructKFromNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructConfigurationParametersBindingSource, "KStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            distructKFromNumericUpDown.Enabled = false;
            distructKFromNumericUpDown.Location = new System.Drawing.Point(65, 511);
            distructKFromNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            distructKFromNumericUpDown.Name = "distructKFromNumericUpDown";
            distructKFromNumericUpDown.Size = new System.Drawing.Size(45, 23);
            distructKFromNumericUpDown.TabIndex = 176;
            distructKFromNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // distructInputComboBox
            // 
            distructInputComboBox.FormattingEnabled = true;
            distructInputComboBox.Location = new System.Drawing.Point(11, 45);
            distructInputComboBox.Name = "distructInputComboBox";
            distructInputComboBox.Size = new System.Drawing.Size(130, 23);
            distructInputComboBox.TabIndex = 173;
            distructInputComboBox.SelectedIndexChanged += distructInputComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(11, 30);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(105, 15);
            label6.TabIndex = 172;
            label6.Text = "Distruct output set";
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(label76);
            groupBox12.Controls.Add(label79);
            groupBox12.Controls.Add(label75);
            groupBox12.Controls.Add(label74);
            groupBox12.Controls.Add(label73);
            groupBox12.Controls.Add(label86);
            groupBox12.Controls.Add(OrientationChoose);
            groupBox12.Controls.Add(LowerLetXNum);
            groupBox12.Controls.Add(LowerLetYNum);
            groupBox12.Controls.Add(AngleForTopNum);
            groupBox12.Controls.Add(ScaleForYNum);
            groupBox12.Controls.Add(ScaleForXNum);
            groupBox12.Controls.Add(PrintSomeOfTheDataCheck);
            groupBox12.Controls.Add(label90);
            groupBox12.Controls.Add(PrintTheDataAsCommCheck);
            groupBox12.Controls.Add(RimWidthNum);
            groupBox12.Controls.Add(PrintColorBrewCheck);
            groupBox12.Controls.Add(label89);
            groupBox12.Controls.Add(label84);
            groupBox12.Controls.Add(label83);
            groupBox12.Controls.Add(UseGrayscaleCheck);
            groupBox12.Controls.Add(AngleForBelowNum);
            groupBox12.Controls.Add(SeparatorsWidthNum);
            groupBox12.Controls.Add(PrintThePOPQCheck);
            groupBox12.Controls.Add(IndividualsWidthNum);
            groupBox12.Enabled = false;
            groupBox12.Location = new System.Drawing.Point(311, 125);
            groupBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox12.Name = "groupBox12";
            groupBox12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox12.Size = new System.Drawing.Size(350, 385);
            groupBox12.TabIndex = 102;
            groupBox12.TabStop = false;
            groupBox12.Text = "Extra options";
            // 
            // label76
            // 
            label76.AutoSize = true;
            label76.Location = new System.Drawing.Point(5, 20);
            label76.Name = "label76";
            label76.Size = new System.Drawing.Size(67, 15);
            label76.TabIndex = 39;
            label76.Text = "Orientation";
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Location = new System.Drawing.Point(5, 120);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(111, 15);
            label79.TabIndex = 36;
            label79.Text = "Scale for y direction";
            // 
            // label75
            // 
            label75.AutoSize = true;
            label75.Location = new System.Drawing.Point(5, 45);
            label75.Name = "label75";
            label75.Size = new System.Drawing.Size(127, 15);
            label75.TabIndex = 40;
            label75.Text = "Lower-let x-coordinate";
            // 
            // label74
            // 
            label74.AutoSize = true;
            label74.Location = new System.Drawing.Point(5, 70);
            label74.Name = "label74";
            label74.Size = new System.Drawing.Size(128, 15);
            label74.TabIndex = 41;
            label74.Text = "Lowet-let y-coordinate";
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Location = new System.Drawing.Point(5, 95);
            label73.Name = "label73";
            label73.Size = new System.Drawing.Size(110, 15);
            label73.TabIndex = 42;
            label73.Text = "Scale for x direction";
            // 
            // label86
            // 
            label86.AutoSize = true;
            label86.Location = new System.Drawing.Point(5, 145);
            label86.Name = "label86";
            label86.Size = new System.Drawing.Size(116, 15);
            label86.TabIndex = 49;
            label86.Text = "Angle for labels atop";
            // 
            // OrientationChoose
            // 
            OrientationChoose.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", distructParametersModelBindingSource, "ORIENTATION", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            OrientationChoose.FormattingEnabled = true;
            OrientationChoose.Items.AddRange(new object[] { "horizontal", "vertical", "reverse horizontal", "reverse vertical" });
            OrientationChoose.Location = new System.Drawing.Point(196, 15);
            OrientationChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            OrientationChoose.Name = "OrientationChoose";
            OrientationChoose.Size = new System.Drawing.Size(130, 23);
            OrientationChoose.TabIndex = 73;
            OrientationChoose.Text = "horizontal";
            OrientationChoose.SelectedIndexChanged += OrientationChoose_SelectedIndexChanged;
            // 
            // distructParametersModelBindingSource
            // 
            distructParametersModelBindingSource.DataSource = typeof(Additional_programs_logic.Distruct.DistructParametersModel);
            // 
            // LowerLetXNum
            // 
            LowerLetXNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "XORIGIN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            LowerLetXNum.DecimalPlaces = 1;
            LowerLetXNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            LowerLetXNum.Location = new System.Drawing.Point(265, 40);
            LowerLetXNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            LowerLetXNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            LowerLetXNum.Name = "LowerLetXNum";
            LowerLetXNum.Size = new System.Drawing.Size(60, 23);
            LowerLetXNum.TabIndex = 74;
            LowerLetXNum.Value = new decimal(new int[] { 72, 0, 0, 0 });
            // 
            // LowerLetYNum
            // 
            LowerLetYNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "YORIGIN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            LowerLetYNum.DecimalPlaces = 1;
            LowerLetYNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            LowerLetYNum.Location = new System.Drawing.Point(265, 65);
            LowerLetYNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            LowerLetYNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            LowerLetYNum.Name = "LowerLetYNum";
            LowerLetYNum.Size = new System.Drawing.Size(60, 23);
            LowerLetYNum.TabIndex = 75;
            LowerLetYNum.Value = new decimal(new int[] { 28, 0, 0, 0 });
            // 
            // AngleForTopNum
            // 
            AngleForTopNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "ANGLE_LABEL_ATOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            AngleForTopNum.DecimalPlaces = 1;
            AngleForTopNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            AngleForTopNum.Location = new System.Drawing.Point(265, 140);
            AngleForTopNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            AngleForTopNum.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            AngleForTopNum.Name = "AngleForTopNum";
            AngleForTopNum.Size = new System.Drawing.Size(60, 23);
            AngleForTopNum.TabIndex = 77;
            AngleForTopNum.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // ScaleForYNum
            // 
            ScaleForYNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "YSCALE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ScaleForYNum.DecimalPlaces = 1;
            ScaleForYNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ScaleForYNum.Location = new System.Drawing.Point(265, 115);
            ScaleForYNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ScaleForYNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            ScaleForYNum.Name = "ScaleForYNum";
            ScaleForYNum.Size = new System.Drawing.Size(60, 23);
            ScaleForYNum.TabIndex = 78;
            ScaleForYNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ScaleForXNum
            // 
            ScaleForXNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "XSCALE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ScaleForXNum.DecimalPlaces = 1;
            ScaleForXNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ScaleForXNum.Location = new System.Drawing.Point(265, 90);
            ScaleForXNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ScaleForXNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            ScaleForXNum.Name = "ScaleForXNum";
            ScaleForXNum.Size = new System.Drawing.Size(60, 23);
            ScaleForXNum.TabIndex = 79;
            ScaleForXNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // PrintSomeOfTheDataCheck
            // 
            PrintSomeOfTheDataCheck.AutoSize = true;
            PrintSomeOfTheDataCheck.Checked = true;
            PrintSomeOfTheDataCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintSomeOfTheDataCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "ECHO_DATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintSomeOfTheDataCheck.Location = new System.Drawing.Point(5, 195);
            PrintSomeOfTheDataCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintSomeOfTheDataCheck.Name = "PrintSomeOfTheDataCheck";
            PrintSomeOfTheDataCheck.Size = new System.Drawing.Size(214, 19);
            PrintSomeOfTheDataCheck.TabIndex = 80;
            PrintSomeOfTheDataCheck.Text = "Print some of the data to the screen";
            PrintSomeOfTheDataCheck.UseVisualStyleBackColor = true;
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Location = new System.Drawing.Point(5, 170);
            label90.Name = "label90";
            label90.Size = new System.Drawing.Size(124, 15);
            label90.TabIndex = 45;
            label90.Text = "Angle for labels below";
            // 
            // PrintTheDataAsCommCheck
            // 
            PrintTheDataAsCommCheck.AutoSize = true;
            PrintTheDataAsCommCheck.Checked = true;
            PrintTheDataAsCommCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintTheDataAsCommCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "REPRINT_DATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintTheDataAsCommCheck.Location = new System.Drawing.Point(5, 335);
            PrintTheDataAsCommCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintTheDataAsCommCheck.Name = "PrintTheDataAsCommCheck";
            PrintTheDataAsCommCheck.Size = new System.Drawing.Size(247, 19);
            PrintTheDataAsCommCheck.TabIndex = 86;
            PrintTheDataAsCommCheck.Text = "Print the data as a comment in the output";
            PrintTheDataAsCommCheck.UseVisualStyleBackColor = true;
            // 
            // RimWidthNum
            // 
            RimWidthNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "LINEWIDTH_RIM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            RimWidthNum.DecimalPlaces = 1;
            RimWidthNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            RimWidthNum.Location = new System.Drawing.Point(265, 285);
            RimWidthNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            RimWidthNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            RimWidthNum.Name = "RimWidthNum";
            RimWidthNum.Size = new System.Drawing.Size(60, 23);
            RimWidthNum.TabIndex = 88;
            RimWidthNum.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // PrintColorBrewCheck
            // 
            PrintColorBrewCheck.AutoSize = true;
            PrintColorBrewCheck.Checked = true;
            PrintColorBrewCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintColorBrewCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_COLOR_BREWER", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintColorBrewCheck.Location = new System.Drawing.Point(5, 355);
            PrintColorBrewCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintColorBrewCheck.Name = "PrintColorBrewCheck";
            PrintColorBrewCheck.Size = new System.Drawing.Size(233, 19);
            PrintColorBrewCheck.TabIndex = 85;
            PrintColorBrewCheck.Text = "Print colorBrewer settings in the output";
            PrintColorBrewCheck.UseVisualStyleBackColor = true;
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Location = new System.Drawing.Point(5, 290);
            label89.Name = "label89";
            label89.Size = new System.Drawing.Size(161, 15);
            label89.TabIndex = 46;
            label89.Text = "Width of \"pen\" for rim of box";
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Location = new System.Drawing.Point(5, 265);
            label84.Name = "label84";
            label84.Size = new System.Drawing.Size(238, 15);
            label84.TabIndex = 51;
            label84.Text = "Width of \"pen\" for separators between pops";
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Location = new System.Drawing.Point(5, 240);
            label83.Name = "label83";
            label83.Size = new System.Drawing.Size(192, 15);
            label83.TabIndex = 52;
            label83.Text = "Width of \"pen\" used for individuals";
            // 
            // UseGrayscaleCheck
            // 
            UseGrayscaleCheck.AutoSize = true;
            UseGrayscaleCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "GRAYSCALE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            UseGrayscaleCheck.Location = new System.Drawing.Point(5, 315);
            UseGrayscaleCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            UseGrayscaleCheck.Name = "UseGrayscaleCheck";
            UseGrayscaleCheck.Size = new System.Drawing.Size(187, 19);
            UseGrayscaleCheck.TabIndex = 84;
            UseGrayscaleCheck.Text = "Use grayscale instead of colors";
            UseGrayscaleCheck.UseVisualStyleBackColor = true;
            // 
            // AngleForBelowNum
            // 
            AngleForBelowNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "ANGLE_LABEL_BELOW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            AngleForBelowNum.DecimalPlaces = 1;
            AngleForBelowNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            AngleForBelowNum.Location = new System.Drawing.Point(265, 165);
            AngleForBelowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            AngleForBelowNum.Name = "AngleForBelowNum";
            AngleForBelowNum.Size = new System.Drawing.Size(60, 23);
            AngleForBelowNum.TabIndex = 76;
            AngleForBelowNum.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // SeparatorsWidthNum
            // 
            SeparatorsWidthNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "LINEWIDTH_SEP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            SeparatorsWidthNum.DecimalPlaces = 1;
            SeparatorsWidthNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            SeparatorsWidthNum.Location = new System.Drawing.Point(265, 260);
            SeparatorsWidthNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SeparatorsWidthNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            SeparatorsWidthNum.Name = "SeparatorsWidthNum";
            SeparatorsWidthNum.Size = new System.Drawing.Size(60, 23);
            SeparatorsWidthNum.TabIndex = 83;
            SeparatorsWidthNum.Value = new decimal(new int[] { 3, 0, 0, 65536 });
            // 
            // PrintThePOPQCheck
            // 
            PrintThePOPQCheck.AutoSize = true;
            PrintThePOPQCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_INFILE_NAME", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintThePOPQCheck.Location = new System.Drawing.Point(5, 215);
            PrintThePOPQCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintThePOPQCheck.Name = "PrintThePOPQCheck";
            PrintThePOPQCheck.Size = new System.Drawing.Size(247, 19);
            PrintThePOPQCheck.TabIndex = 81;
            PrintThePOPQCheck.Text = "Print the POPQ file name above the figure";
            PrintThePOPQCheck.UseVisualStyleBackColor = true;
            // 
            // IndividualsWidthNum
            // 
            IndividualsWidthNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "LINEWIDTH_IND", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            IndividualsWidthNum.DecimalPlaces = 1;
            IndividualsWidthNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            IndividualsWidthNum.Location = new System.Drawing.Point(265, 235);
            IndividualsWidthNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            IndividualsWidthNum.Maximum = new decimal(new int[] { 27000, 0, 0, 0 });
            IndividualsWidthNum.Name = "IndividualsWidthNum";
            IndividualsWidthNum.Size = new System.Drawing.Size(60, 23);
            IndividualsWidthNum.TabIndex = 82;
            IndividualsWidthNum.Value = new decimal(new int[] { 3, 0, 0, 65536 });
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", distructConfigurationParametersBindingSource, "CurrentParamFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            textBox4.Location = new System.Drawing.Point(531, 46);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(130, 23);
            textBox4.TabIndex = 174;
            // 
            // SaveDistructaParamSetButt
            // 
            SaveDistructaParamSetButt.Enabled = false;
            SaveDistructaParamSetButt.Location = new System.Drawing.Point(206, 511);
            SaveDistructaParamSetButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SaveDistructaParamSetButt.Name = "SaveDistructaParamSetButt";
            SaveDistructaParamSetButt.Size = new System.Drawing.Size(95, 25);
            SaveDistructaParamSetButt.TabIndex = 156;
            SaveDistructaParamSetButt.Text = "Save";
            SaveDistructaParamSetButt.UseVisualStyleBackColor = true;
            SaveDistructaParamSetButt.Click += SaveDistructaParamSetButt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(533, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 15);
            label2.TabIndex = 172;
            label2.Text = "Parameter name";
            // 
            // StartDistructaButt
            // 
            StartDistructaButt.Enabled = false;
            StartDistructaButt.Location = new System.Drawing.Point(468, 511);
            StartDistructaButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            StartDistructaButt.Name = "StartDistructaButt";
            StartDistructaButt.Size = new System.Drawing.Size(95, 25);
            StartDistructaButt.TabIndex = 155;
            StartDistructaButt.Text = "Start";
            StartDistructaButt.UseVisualStyleBackColor = true;
            StartDistructaButt.Click += StartDistructaButt_ClickAsync;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(PrintLinesToSeparateCheck);
            groupBox13.Controls.Add(PrintIndividCheck);
            groupBox13.Controls.Add(PrintLabelsBelowCheck);
            groupBox13.Controls.Add(PrintLabelsAboveCheck);
            groupBox13.Enabled = false;
            groupBox13.Location = new System.Drawing.Point(11, 73);
            groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox13.Size = new System.Drawing.Size(650, 44);
            groupBox13.TabIndex = 103;
            groupBox13.TabStop = false;
            groupBox13.Text = "Main usage options";
            // 
            // PrintLinesToSeparateCheck
            // 
            PrintLinesToSeparateCheck.AutoSize = true;
            PrintLinesToSeparateCheck.Checked = true;
            PrintLinesToSeparateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintLinesToSeparateCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_SEP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintLinesToSeparateCheck.Location = new System.Drawing.Point(437, 20);
            PrintLinesToSeparateCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintLinesToSeparateCheck.Name = "PrintLinesToSeparateCheck";
            PrintLinesToSeparateCheck.Size = new System.Drawing.Size(205, 19);
            PrintLinesToSeparateCheck.TabIndex = 67;
            PrintLinesToSeparateCheck.Text = "Print lines to separate populations";
            PrintLinesToSeparateCheck.UseVisualStyleBackColor = true;
            PrintLinesToSeparateCheck.CheckedChanged += PrintLinesToSeparateCheck_CheckedChanged;
            // 
            // PrintIndividCheck
            // 
            PrintIndividCheck.AutoSize = true;
            PrintIndividCheck.Checked = true;
            PrintIndividCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintIndividCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_INDIVS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintIndividCheck.Location = new System.Drawing.Point(5, 20);
            PrintIndividCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintIndividCheck.Name = "PrintIndividCheck";
            PrintIndividCheck.Size = new System.Drawing.Size(111, 19);
            PrintIndividCheck.TabIndex = 64;
            PrintIndividCheck.Text = "Print individuals";
            PrintIndividCheck.UseVisualStyleBackColor = true;
            // 
            // PrintLabelsBelowCheck
            // 
            PrintLabelsBelowCheck.AutoSize = true;
            PrintLabelsBelowCheck.Checked = true;
            PrintLabelsBelowCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintLabelsBelowCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_LABEL_BELOW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintLabelsBelowCheck.Location = new System.Drawing.Point(279, 20);
            PrintLabelsBelowCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintLabelsBelowCheck.Name = "PrintLabelsBelowCheck";
            PrintLabelsBelowCheck.Size = new System.Drawing.Size(153, 19);
            PrintLabelsBelowCheck.TabIndex = 65;
            PrintLabelsBelowCheck.Text = "Print labels below figure";
            PrintLabelsBelowCheck.UseVisualStyleBackColor = true;
            PrintLabelsBelowCheck.CheckedChanged += PrintLabelsBelowCheck_CheckedChanged;
            // 
            // PrintLabelsAboveCheck
            // 
            PrintLabelsAboveCheck.AutoSize = true;
            PrintLabelsAboveCheck.Checked = true;
            PrintLabelsAboveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            PrintLabelsAboveCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", distructParametersModelBindingSource, "PRINT_LABEL_ATOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PrintLabelsAboveCheck.Location = new System.Drawing.Point(121, 20);
            PrintLabelsAboveCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PrintLabelsAboveCheck.Name = "PrintLabelsAboveCheck";
            PrintLabelsAboveCheck.Size = new System.Drawing.Size(145, 19);
            PrintLabelsAboveCheck.TabIndex = 66;
            PrintLabelsAboveCheck.Text = "Print labels atop figure";
            PrintLabelsAboveCheck.UseVisualStyleBackColor = true;
            PrintLabelsAboveCheck.CheckedChanged += PrintLabelsAboveCheck_CheckedChanged;
            // 
            // distructParametersComboBox
            // 
            distructParametersComboBox.FormattingEnabled = true;
            distructParametersComboBox.Location = new System.Drawing.Point(394, 46);
            distructParametersComboBox.Name = "distructParametersComboBox";
            distructParametersComboBox.Size = new System.Drawing.Size(130, 23);
            distructParametersComboBox.TabIndex = 171;
            distructParametersComboBox.SelectedIndexChanged += distructParametersComboBox_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(395, 32);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(123, 15);
            label9.TabIndex = 170;
            label9.Text = "Choose parameter file";
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(WidthOfAnIndivNum);
            groupBox11.Controls.Add(label82);
            groupBox11.Controls.Add(label81);
            groupBox11.Controls.Add(label80);
            groupBox11.Controls.Add(label78);
            groupBox11.Controls.Add(label77);
            groupBox11.Controls.Add(SizeOfFontNum);
            groupBox11.Controls.Add(DistanceAbovePlotNum);
            groupBox11.Controls.Add(DistanceBelowPlotNum);
            groupBox11.Controls.Add(HeightOfTheFigure);
            groupBox11.Enabled = false;
            groupBox11.Location = new System.Drawing.Point(11, 370);
            groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox11.Name = "groupBox11";
            groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox11.Size = new System.Drawing.Size(290, 140);
            groupBox11.TabIndex = 101;
            groupBox11.TabStop = false;
            groupBox11.Text = "Figure appearance";
            // 
            // WidthOfAnIndivNum
            // 
            WidthOfAnIndivNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "INDIVWIDTH", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            WidthOfAnIndivNum.DecimalPlaces = 1;
            WidthOfAnIndivNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            WidthOfAnIndivNum.Location = new System.Drawing.Point(210, 115);
            WidthOfAnIndivNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            WidthOfAnIndivNum.Name = "WidthOfAnIndivNum";
            WidthOfAnIndivNum.Size = new System.Drawing.Size(60, 23);
            WidthOfAnIndivNum.TabIndex = 72;
            WidthOfAnIndivNum.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Location = new System.Drawing.Point(5, 20);
            label82.Name = "label82";
            label82.Size = new System.Drawing.Size(66, 15);
            label82.TabIndex = 33;
            label82.Text = "Size of font";
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Location = new System.Drawing.Point(5, 45);
            label81.Name = "label81";
            label81.Size = new System.Drawing.Size(178, 15);
            label81.TabIndex = 34;
            label81.Text = "Distance above plot to place text";
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Location = new System.Drawing.Point(5, 70);
            label80.Name = "label80";
            label80.Size = new System.Drawing.Size(178, 15);
            label80.TabIndex = 35;
            label80.Text = "Distance below plot to place text";
            // 
            // label78
            // 
            label78.AutoSize = true;
            label78.Location = new System.Drawing.Point(5, 95);
            label78.Name = "label78";
            label78.Size = new System.Drawing.Size(111, 15);
            label78.TabIndex = 37;
            label78.Text = "Height of the figure";
            // 
            // label77
            // 
            label77.AutoSize = true;
            label77.Location = new System.Drawing.Point(5, 120);
            label77.Name = "label77";
            label77.Size = new System.Drawing.Size(124, 15);
            label77.TabIndex = 38;
            label77.Text = "Width of an individual";
            // 
            // SizeOfFontNum
            // 
            SizeOfFontNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "FONTHEIGHT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            SizeOfFontNum.DecimalPlaces = 1;
            SizeOfFontNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            SizeOfFontNum.Location = new System.Drawing.Point(210, 15);
            SizeOfFontNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SizeOfFontNum.Name = "SizeOfFontNum";
            SizeOfFontNum.Size = new System.Drawing.Size(60, 23);
            SizeOfFontNum.TabIndex = 68;
            SizeOfFontNum.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // DistanceAbovePlotNum
            // 
            DistanceAbovePlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "DIST_ABOVE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            DistanceAbovePlotNum.DecimalPlaces = 1;
            DistanceAbovePlotNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            DistanceAbovePlotNum.Location = new System.Drawing.Point(210, 40);
            DistanceAbovePlotNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            DistanceAbovePlotNum.Name = "DistanceAbovePlotNum";
            DistanceAbovePlotNum.Size = new System.Drawing.Size(60, 23);
            DistanceAbovePlotNum.TabIndex = 69;
            DistanceAbovePlotNum.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // DistanceBelowPlotNum
            // 
            DistanceBelowPlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "DIST_BELOW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            DistanceBelowPlotNum.DecimalPlaces = 1;
            DistanceBelowPlotNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            DistanceBelowPlotNum.Location = new System.Drawing.Point(210, 65);
            DistanceBelowPlotNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            DistanceBelowPlotNum.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            DistanceBelowPlotNum.Name = "DistanceBelowPlotNum";
            DistanceBelowPlotNum.Size = new System.Drawing.Size(60, 23);
            DistanceBelowPlotNum.TabIndex = 70;
            DistanceBelowPlotNum.Value = new decimal(new int[] { 7, 0, 0, int.MinValue });
            // 
            // HeightOfTheFigure
            // 
            HeightOfTheFigure.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "BOXHEIGHT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            HeightOfTheFigure.DecimalPlaces = 1;
            HeightOfTheFigure.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            HeightOfTheFigure.Location = new System.Drawing.Point(210, 90);
            HeightOfTheFigure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            HeightOfTheFigure.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            HeightOfTheFigure.Name = "HeightOfTheFigure";
            HeightOfTheFigure.Size = new System.Drawing.Size(60, 23);
            HeightOfTheFigure.TabIndex = 71;
            HeightOfTheFigure.Value = new decimal(new int[] { 36, 0, 0, 0 });
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label69);
            groupBox10.Controls.Add(PermutationOfClustersFileText);
            groupBox10.Controls.Add(distructPrintLabelBelowLabel);
            groupBox10.Controls.Add(distructLabelAtopLabel);
            groupBox10.Controls.Add(label65);
            groupBox10.Controls.Add(label64);
            groupBox10.Controls.Add(LabelsBelowFileNameText);
            groupBox10.Controls.Add(ChooseFileBelowButt);
            groupBox10.Controls.Add(inputFileOfLabelsAtop);
            groupBox10.Controls.Add(ChooseFileAtopButt);
            groupBox10.Controls.Add(ChooseFilePermutaButt);
            groupBox10.Controls.Add(PreDefinedPopNum);
            groupBox10.Controls.Add(OfIndividualsNum);
            groupBox10.Enabled = false;
            groupBox10.Location = new System.Drawing.Point(11, 125);
            groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox10.Size = new System.Drawing.Size(290, 240);
            groupBox10.TabIndex = 100;
            groupBox10.TabStop = false;
            groupBox10.Text = "Data settings";
            // 
            // PermutationOfClustersFileText
            // 
            PermutationOfClustersFileText.DataBindings.Add(new System.Windows.Forms.Binding("Text", distructConfigurationParametersBindingSource, "InputOriginalClustPerm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PermutationOfClustersFileText.Location = new System.Drawing.Point(5, 140);
            PermutationOfClustersFileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PermutationOfClustersFileText.Name = "PermutationOfClustersFileText";
            PermutationOfClustersFileText.Size = new System.Drawing.Size(175, 23);
            PermutationOfClustersFileText.TabIndex = 57;
            // 
            // distructPrintLabelBelowLabel
            // 
            distructPrintLabelBelowLabel.AutoSize = true;
            distructPrintLabelBelowLabel.Location = new System.Drawing.Point(5, 20);
            distructPrintLabelBelowLabel.Name = "distructPrintLabelBelowLabel";
            distructPrintLabelBelowLabel.Size = new System.Drawing.Size(188, 15);
            distructPrintLabelBelowLabel.TabIndex = 20;
            distructPrintLabelBelowLabel.Text = "Input file of labels for below figure";
            // 
            // distructLabelAtopLabel
            // 
            distructLabelAtopLabel.AutoSize = true;
            distructLabelAtopLabel.Location = new System.Drawing.Point(6, 70);
            distructLabelAtopLabel.Name = "distructLabelAtopLabel";
            distructLabelAtopLabel.Size = new System.Drawing.Size(180, 15);
            distructLabelAtopLabel.TabIndex = 21;
            distructLabelAtopLabel.Text = "Input file of labels for atop figure";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new System.Drawing.Point(5, 180);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(196, 15);
            label65.TabIndex = 25;
            label65.Text = "Number of pre-defined populations";
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new System.Drawing.Point(5, 205);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(125, 15);
            label64.TabIndex = 26;
            label64.Text = "Number of individuals";
            // 
            // LabelsBelowFileNameText
            // 
            LabelsBelowFileNameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", distructConfigurationParametersBindingSource, "InputOriginalLabelBelow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            LabelsBelowFileNameText.Location = new System.Drawing.Point(5, 40);
            LabelsBelowFileNameText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            LabelsBelowFileNameText.Name = "LabelsBelowFileNameText";
            LabelsBelowFileNameText.Size = new System.Drawing.Size(175, 23);
            LabelsBelowFileNameText.TabIndex = 53;
            // 
            // ChooseFileBelowButt
            // 
            ChooseFileBelowButt.Location = new System.Drawing.Point(190, 40);
            ChooseFileBelowButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ChooseFileBelowButt.Name = "ChooseFileBelowButt";
            ChooseFileBelowButt.Size = new System.Drawing.Size(80, 25);
            ChooseFileBelowButt.TabIndex = 54;
            ChooseFileBelowButt.Text = "Choose";
            ChooseFileBelowButt.UseVisualStyleBackColor = true;
            ChooseFileBelowButt.Click += ChooseFileBelowButt_Click;
            // 
            // inputFileOfLabelsAtop
            // 
            inputFileOfLabelsAtop.DataBindings.Add(new System.Windows.Forms.Binding("Text", distructConfigurationParametersBindingSource, "InputOriginalLabelAtop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            inputFileOfLabelsAtop.Location = new System.Drawing.Point(5, 90);
            inputFileOfLabelsAtop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            inputFileOfLabelsAtop.Name = "inputFileOfLabelsAtop";
            inputFileOfLabelsAtop.Size = new System.Drawing.Size(175, 23);
            inputFileOfLabelsAtop.TabIndex = 55;
            // 
            // ChooseFileAtopButt
            // 
            ChooseFileAtopButt.Location = new System.Drawing.Point(190, 90);
            ChooseFileAtopButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ChooseFileAtopButt.Name = "ChooseFileAtopButt";
            ChooseFileAtopButt.Size = new System.Drawing.Size(80, 25);
            ChooseFileAtopButt.TabIndex = 56;
            ChooseFileAtopButt.Text = "Choose";
            ChooseFileAtopButt.UseVisualStyleBackColor = true;
            ChooseFileAtopButt.Click += ChooseFileAtopButt_Click;
            // 
            // ChooseFilePermutaButt
            // 
            ChooseFilePermutaButt.Location = new System.Drawing.Point(190, 140);
            ChooseFilePermutaButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ChooseFilePermutaButt.Name = "ChooseFilePermutaButt";
            ChooseFilePermutaButt.Size = new System.Drawing.Size(80, 25);
            ChooseFilePermutaButt.TabIndex = 58;
            ChooseFilePermutaButt.Text = "Choose";
            ChooseFilePermutaButt.UseVisualStyleBackColor = true;
            ChooseFilePermutaButt.Click += ChooseFilePermutaButt_Click;
            // 
            // PreDefinedPopNum
            // 
            PreDefinedPopNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "NUMPOPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            PreDefinedPopNum.Location = new System.Drawing.Point(210, 175);
            PreDefinedPopNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PreDefinedPopNum.Maximum = new decimal(new int[] { 27000000, 0, 0, 0 });
            PreDefinedPopNum.Name = "PreDefinedPopNum";
            PreDefinedPopNum.Size = new System.Drawing.Size(60, 23);
            PreDefinedPopNum.TabIndex = 62;
            // 
            // OfIndividualsNum
            // 
            OfIndividualsNum.DataBindings.Add(new System.Windows.Forms.Binding("Value", distructParametersModelBindingSource, "NUMINDS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            OfIndividualsNum.Location = new System.Drawing.Point(210, 200);
            OfIndividualsNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            OfIndividualsNum.Maximum = new decimal(new int[] { 27000000, 0, 0, 0 });
            OfIndividualsNum.Name = "OfIndividualsNum";
            OfIndividualsNum.Size = new System.Drawing.Size(60, 23);
            OfIndividualsNum.TabIndex = 63;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new System.Drawing.Point(8, 29);
            label54.Name = "label54";
            label54.Size = new System.Drawing.Size(0, 15);
            label54.TabIndex = 19;
            // 
            // programsProcessTableLayoutPanel
            // 
            programsProcessTableLayoutPanel.ColumnCount = 3;
            programsProcessTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.4689274F));
            programsProcessTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.5310745F));
            programsProcessTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            programsProcessTableLayoutPanel.Controls.Add(structurLabelTableLayoutPanel, 0, 0);
            programsProcessTableLayoutPanel.Controls.Add(structureHarvesterLabelTableLayoutPanel, 0, 1);
            programsProcessTableLayoutPanel.Controls.Add(clumppLabelTableLayoutPanel, 0, 2);
            programsProcessTableLayoutPanel.Controls.Add(distructTableLayoutPanel, 0, 3);
            programsProcessTableLayoutPanel.Controls.Add(structureProgressBarTableLayoutPanel, 1, 0);
            programsProcessTableLayoutPanel.Controls.Add(structureHarvesterProgressBarTableLayoutPanel, 1, 1);
            programsProcessTableLayoutPanel.Controls.Add(clumppProgressBarTableLayoutPanel, 1, 2);
            programsProcessTableLayoutPanel.Controls.Add(distructProgressBarTableLayoutPanel, 1, 3);
            programsProcessTableLayoutPanel.Controls.Add(structureEtaLabelTableLayoutPanel, 2, 0);
            programsProcessTableLayoutPanel.Controls.Add(structureHarvesterEtaLabelTableLayoutPanel, 2, 1);
            programsProcessTableLayoutPanel.Controls.Add(CLUMPPEtaLabelTableLayoutPanel, 2, 2);
            programsProcessTableLayoutPanel.Controls.Add(distructEtaLabelTableLayoutPanel, 2, 3);
            programsProcessTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            programsProcessTableLayoutPanel.Location = new System.Drawing.Point(12, 725);
            programsProcessTableLayoutPanel.Name = "programsProcessTableLayoutPanel";
            programsProcessTableLayoutPanel.RowCount = 4;
            programsProcessTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            programsProcessTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            programsProcessTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            programsProcessTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            programsProcessTableLayoutPanel.Size = new System.Drawing.Size(480, 123);
            programsProcessTableLayoutPanel.TabIndex = 164;
            // 
            // structurLabelTableLayoutPanel
            // 
            structurLabelTableLayoutPanel.AutoSize = true;
            structurLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structurLabelTableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            structurLabelTableLayoutPanel.Location = new System.Drawing.Point(3, 0);
            structurLabelTableLayoutPanel.Name = "structurLabelTableLayoutPanel";
            structurLabelTableLayoutPanel.Size = new System.Drawing.Size(70, 30);
            structurLabelTableLayoutPanel.TabIndex = 0;
            structurLabelTableLayoutPanel.Text = "Structure";
            structurLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // structureHarvesterLabelTableLayoutPanel
            // 
            structureHarvesterLabelTableLayoutPanel.AutoSize = true;
            structureHarvesterLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structureHarvesterLabelTableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            structureHarvesterLabelTableLayoutPanel.Location = new System.Drawing.Point(3, 30);
            structureHarvesterLabelTableLayoutPanel.Name = "structureHarvesterLabelTableLayoutPanel";
            structureHarvesterLabelTableLayoutPanel.Size = new System.Drawing.Size(70, 30);
            structureHarvesterLabelTableLayoutPanel.TabIndex = 1;
            structureHarvesterLabelTableLayoutPanel.Text = "Structure Harvester";
            structureHarvesterLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clumppLabelTableLayoutPanel
            // 
            clumppLabelTableLayoutPanel.AutoSize = true;
            clumppLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            clumppLabelTableLayoutPanel.Location = new System.Drawing.Point(3, 60);
            clumppLabelTableLayoutPanel.Name = "clumppLabelTableLayoutPanel";
            clumppLabelTableLayoutPanel.Size = new System.Drawing.Size(70, 30);
            clumppLabelTableLayoutPanel.TabIndex = 2;
            clumppLabelTableLayoutPanel.Text = "CLUMPP";
            clumppLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // distructTableLayoutPanel
            // 
            distructTableLayoutPanel.AutoSize = true;
            distructTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            distructTableLayoutPanel.Location = new System.Drawing.Point(3, 90);
            distructTableLayoutPanel.Name = "distructTableLayoutPanel";
            distructTableLayoutPanel.Size = new System.Drawing.Size(70, 33);
            distructTableLayoutPanel.TabIndex = 3;
            distructTableLayoutPanel.Text = "Distruct";
            distructTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // structureProgressBarTableLayoutPanel
            // 
            structureProgressBarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structureProgressBarTableLayoutPanel.Location = new System.Drawing.Point(79, 3);
            structureProgressBarTableLayoutPanel.Name = "structureProgressBarTableLayoutPanel";
            structureProgressBarTableLayoutPanel.OverlayText = null;
            structureProgressBarTableLayoutPanel.Size = new System.Drawing.Size(272, 24);
            structureProgressBarTableLayoutPanel.TabIndex = 4;
            // 
            // structureHarvesterProgressBarTableLayoutPanel
            // 
            structureHarvesterProgressBarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structureHarvesterProgressBarTableLayoutPanel.Location = new System.Drawing.Point(79, 33);
            structureHarvesterProgressBarTableLayoutPanel.Name = "structureHarvesterProgressBarTableLayoutPanel";
            structureHarvesterProgressBarTableLayoutPanel.OverlayText = "";
            structureHarvesterProgressBarTableLayoutPanel.Size = new System.Drawing.Size(272, 24);
            structureHarvesterProgressBarTableLayoutPanel.TabIndex = 5;
            // 
            // clumppProgressBarTableLayoutPanel
            // 
            clumppProgressBarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            clumppProgressBarTableLayoutPanel.Location = new System.Drawing.Point(79, 63);
            clumppProgressBarTableLayoutPanel.Name = "clumppProgressBarTableLayoutPanel";
            clumppProgressBarTableLayoutPanel.OverlayText = "";
            clumppProgressBarTableLayoutPanel.Size = new System.Drawing.Size(272, 24);
            clumppProgressBarTableLayoutPanel.TabIndex = 6;
            // 
            // distructProgressBarTableLayoutPanel
            // 
            distructProgressBarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            distructProgressBarTableLayoutPanel.Location = new System.Drawing.Point(79, 93);
            distructProgressBarTableLayoutPanel.Name = "distructProgressBarTableLayoutPanel";
            distructProgressBarTableLayoutPanel.OverlayText = "";
            distructProgressBarTableLayoutPanel.Size = new System.Drawing.Size(272, 27);
            distructProgressBarTableLayoutPanel.TabIndex = 7;
            // 
            // structureEtaLabelTableLayoutPanel
            // 
            structureEtaLabelTableLayoutPanel.AutoSize = true;
            structureEtaLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structureEtaLabelTableLayoutPanel.Location = new System.Drawing.Point(357, 0);
            structureEtaLabelTableLayoutPanel.Name = "structureEtaLabelTableLayoutPanel";
            structureEtaLabelTableLayoutPanel.Size = new System.Drawing.Size(120, 30);
            structureEtaLabelTableLayoutPanel.TabIndex = 8;
            structureEtaLabelTableLayoutPanel.Text = "None results";
            structureEtaLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // structureHarvesterEtaLabelTableLayoutPanel
            // 
            structureHarvesterEtaLabelTableLayoutPanel.AutoSize = true;
            structureHarvesterEtaLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            structureHarvesterEtaLabelTableLayoutPanel.Location = new System.Drawing.Point(357, 30);
            structureHarvesterEtaLabelTableLayoutPanel.Name = "structureHarvesterEtaLabelTableLayoutPanel";
            structureHarvesterEtaLabelTableLayoutPanel.Size = new System.Drawing.Size(120, 30);
            structureHarvesterEtaLabelTableLayoutPanel.TabIndex = 9;
            structureHarvesterEtaLabelTableLayoutPanel.Text = "None results";
            structureHarvesterEtaLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CLUMPPEtaLabelTableLayoutPanel
            // 
            CLUMPPEtaLabelTableLayoutPanel.AutoSize = true;
            CLUMPPEtaLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            CLUMPPEtaLabelTableLayoutPanel.Location = new System.Drawing.Point(357, 60);
            CLUMPPEtaLabelTableLayoutPanel.Name = "CLUMPPEtaLabelTableLayoutPanel";
            CLUMPPEtaLabelTableLayoutPanel.Size = new System.Drawing.Size(120, 30);
            CLUMPPEtaLabelTableLayoutPanel.TabIndex = 10;
            CLUMPPEtaLabelTableLayoutPanel.Text = "None results";
            CLUMPPEtaLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // distructEtaLabelTableLayoutPanel
            // 
            distructEtaLabelTableLayoutPanel.AutoSize = true;
            distructEtaLabelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            distructEtaLabelTableLayoutPanel.Location = new System.Drawing.Point(357, 90);
            distructEtaLabelTableLayoutPanel.Name = "distructEtaLabelTableLayoutPanel";
            distructEtaLabelTableLayoutPanel.Size = new System.Drawing.Size(120, 33);
            distructEtaLabelTableLayoutPanel.TabIndex = 11;
            distructEtaLabelTableLayoutPanel.Text = "None results";
            distructEtaLabelTableLayoutPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Location = new System.Drawing.Point(5, 120);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(236, 15);
            label69.TabIndex = 64;
            label69.Text = "Input file of permutation of clusters to print";
            // 
            // GenotypeApplicationMainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1538, 857);
            Controls.Add(tabControl1);
            Controls.Add(programsProcessTableLayoutPanel);
            Controls.Add(currentProjectFoldersTreeView);
            Controls.Add(genotypeMainWindowMenuStrip);
            MainMenuStrip = genotypeMainWindowMenuStrip;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximumSize = new System.Drawing.Size(1554, 896);
            MinimumSize = new System.Drawing.Size(1554, 896);
            Name = "GenotypeApplicationMainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Genotype application";
            Load += GenotypeApplicationMainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)currentProjectInfoBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)structureIterationsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)structureConfigurationParametersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)structureKToNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)structureKFromNumericUpDown).EndInit();
            ancestryModelGroupBox.ResumeLayout(false);
            ancestryModelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)structureExtraparamsBindingSource).EndInit();
            locPriorModelGroupBox.ResumeLayout(false);
            locPriorModelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)initialValueNNumericUpDown).EndInit();
            priorPopInformationGroupBox.ResumeLayout(false);
            priorPopInformationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gensbackNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)migPriorNumericUpDown).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)preBurnLengthNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)InitAlphaNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)SetAlphaNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaPropsdNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaMaxNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AalphaPriorANumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaPriorBNumericUpDown).EndInit();
            linkageModelGroupBox.ResumeLayout(false);
            linkageModelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)structureMainparamsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)log10rminNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)log10rstartNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)log10rmaxNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)log10rpropsdNumericUpDown).EndInit();
            alleleFrequencyModelGroupBox.ResumeLayout(false);
            alleleFrequencyModelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)initLambdaNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)priorSDNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)priorMeanNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SetLambdaNum).EndInit();
            advancedGroupBox.ResumeLayout(false);
            advancedGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)seedNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)printUpdateFreqNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ancestpintNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)numboxesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)freqOfMetroToUpdQNumericUpDown).EndInit();
            runLenghtGroupBox.ResumeLayout(false);
            runLenghtGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)burninPeriodNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MCMCrepsNumericUpDown).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)structureHarvesterConfigurationParametersBindingSource).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CLUMPPKToNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CLUMPPConfigurationParametersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)CLUMPPKFromNumericUpDown).EndInit();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CLUMPPParametersModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)clumppOrderByRunNumericUpDown).EndInit();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RepeatsNum).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numOfPopulationsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)IndividualsNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumberOfIterationsNum).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)distructPre_renderedPictureBox).EndInit();
            distructExportGroupBox.ResumeLayout(false);
            distructExportGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)distructKToNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)distructConfigurationParametersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)distructKFromNumericUpDown).EndInit();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)distructParametersModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowerLetXNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowerLetYNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleForTopNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScaleForYNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScaleForXNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)RimWidthNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleForBelowNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorsWidthNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)IndividualsWidthNum).EndInit();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WidthOfAnIndivNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)SizeOfFontNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)DistanceAbovePlotNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)DistanceBelowPlotNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)HeightOfTheFigure).EndInit();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PreDefinedPopNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)OfIndividualsNum).EndInit();
            programsProcessTableLayoutPanel.ResumeLayout(false);
            programsProcessTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView currentProjectFoldersTreeView;
        private System.Windows.Forms.MenuStrip genotypeMainWindowMenuStrip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label loadStructureDataFileLabel;
        private System.Windows.Forms.TextBox structureSetNameTextBox;
        private System.Windows.Forms.Label structureSetNameLabel;
        private System.Windows.Forms.ComboBox structureParametersSetComboBox;
        private System.Windows.Forms.Button stopStructureButton;
        private System.Windows.Forms.Button saveStructureParamButton;
        private System.Windows.Forms.Button startStructureButton;
        private System.Windows.Forms.GroupBox advancedGroupBox;
        private System.Windows.Forms.CheckBox estimateTheProbabiCheckBox;
        private System.Windows.Forms.NumericUpDown ancestpintNumericUpDown;
        private System.Windows.Forms.NumericUpDown numboxesNumericUpDown;
        private System.Windows.Forms.NumericUpDown freqOfMetroToUpdQNumericUpDown;
        private System.Windows.Forms.CheckBox printCredibleRegCheckBox;
        private System.Windows.Forms.CheckBox popinfoInitializeCheckBox;
        private System.Windows.Forms.CheckBox printQhatCheckBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox alleleFrequencyModelGroupBox;
        private System.Windows.Forms.CheckBox inferSeparateLambdaCheckBox;
        private System.Windows.Forms.NumericUpDown initLambdaNum;
        private System.Windows.Forms.NumericUpDown priorSDNumericUpDown;
        private System.Windows.Forms.NumericUpDown priorMeanNumericUpDown;
        private System.Windows.Forms.CheckBox alleleFrequencisAreCorCheckBox;
        private System.Windows.Forms.CheckBox SetLambdaCheck;
        private System.Windows.Forms.CheckBox assumeSameValueCheckBox;
        private System.Windows.Forms.CheckBox InferLambdaCheck;
        private System.Windows.Forms.NumericUpDown SetLambdaNum;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox ancestryModelGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox sepAlphaForEachPopCheckBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown InitAlphaNum;
        private System.Windows.Forms.NumericUpDown SetAlphaNum;
        private System.Windows.Forms.CheckBox InferAlphaCheck;
        private System.Windows.Forms.CheckBox SetAlphaCheck;
        private System.Windows.Forms.CheckBox useUniformPriorForAlphaCheckBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown alphaPropsdNumericUpDown;
        private System.Windows.Forms.NumericUpDown alphaMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown AalphaPriorANumericUpDown;
        private System.Windows.Forms.NumericUpDown alphaPriorBNumericUpDown;
        private System.Windows.Forms.CheckBox locationInfoUseCheckBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown log10rstartNumericUpDown;
        private System.Windows.Forms.NumericUpDown log10rmaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown log10rpropsdNumericUpDown;
        private System.Windows.Forms.NumericUpDown log10rminNumericUpDown;
        private System.Windows.Forms.NumericUpDown migPriorNumericUpDown;
        private System.Windows.Forms.NumericUpDown gensbackNumericUpDown;
        private System.Windows.Forms.CheckBox linkageModelCheckBox;
        private System.Windows.Forms.CheckBox phaseFollowsMarkorModelCheckBox;
        private System.Windows.Forms.CheckBox CorrectPhaseChek;
        private System.Windows.Forms.CheckBox usePriorPopInfoCheckBox;
        private System.Windows.Forms.CheckBox noAdmixtureModelCheckBox;
        private System.Windows.Forms.GroupBox runLenghtGroupBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown burninPeriodNumericUpDown;
        private System.Windows.Forms.NumericUpDown MCMCrepsNumericUpDown;
        private System.Windows.Forms.Label chooseStructureParametersSetLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label structureHarvesterSetForChartLabel;
        private System.Windows.Forms.Button structureHarvesterLoadChartButton;
        private System.Windows.Forms.ComboBox structureHarvesterSetForChartComboBox;
        //private System.Windows.Forms.Panel structureHarvesterChartPanel;
        private System.Windows.Forms.Label structureHarvesterInputLabel;
        private System.Windows.Forms.Button startStructureHarvesterButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox OverrideWarningCheck;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox PrintRandomInputCheck;
        private System.Windows.Forms.CheckBox PrintEveryPermCheck;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button ChooseButt;
        private System.Windows.Forms.Label clumppGreedyOptionLabel;
        private System.Windows.Forms.Label clumppRepeatsLabel;
        private System.Windows.Forms.Label clumppPermutationFilelabel;
        private System.Windows.Forms.NumericUpDown RepeatsNum;
        private System.Windows.Forms.TextBox PermutationFileText;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox MethodUsedChoose;
        private System.Windows.Forms.NumericUpDown IndividualsNum;
        private System.Windows.Forms.NumericUpDown NumberOfIterationsNum;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button SaveDistructaParamSetButt;
        private System.Windows.Forms.Button StartDistructaButt;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox PrintLinesToSeparateCheck;
        private System.Windows.Forms.CheckBox PrintIndividCheck;
        private System.Windows.Forms.CheckBox PrintLabelsBelowCheck;
        private System.Windows.Forms.CheckBox PrintLabelsAboveCheck;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.ComboBox OrientationChoose;
        private System.Windows.Forms.NumericUpDown LowerLetXNum;
        private System.Windows.Forms.NumericUpDown LowerLetYNum;
        private System.Windows.Forms.NumericUpDown AngleForTopNum;
        private System.Windows.Forms.NumericUpDown ScaleForYNum;
        private System.Windows.Forms.NumericUpDown ScaleForXNum;
        private System.Windows.Forms.CheckBox PrintSomeOfTheDataCheck;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.CheckBox PrintTheDataAsCommCheck;
        private System.Windows.Forms.NumericUpDown RimWidthNum;
        private System.Windows.Forms.CheckBox PrintColorBrewCheck;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.CheckBox UseGrayscaleCheck;
        private System.Windows.Forms.NumericUpDown AngleForBelowNum;
        private System.Windows.Forms.NumericUpDown SeparatorsWidthNum;
        private System.Windows.Forms.CheckBox PrintThePOPQCheck;
        private System.Windows.Forms.NumericUpDown IndividualsWidthNum;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.NumericUpDown WidthOfAnIndivNum;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.NumericUpDown SizeOfFontNum;
        private System.Windows.Forms.NumericUpDown DistanceAbovePlotNum;
        private System.Windows.Forms.NumericUpDown DistanceBelowPlotNum;
        private System.Windows.Forms.NumericUpDown HeightOfTheFigure;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox PermutationOfClustersFileText;
        private System.Windows.Forms.Label distructPrintLabelBelowLabel;
        private System.Windows.Forms.Label distructLabelAtopLabel;
        private System.Windows.Forms.CheckBox ToCheck;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox LabelsBelowFileNameText;
        private System.Windows.Forms.Button ChooseFileBelowButt;
        private System.Windows.Forms.TextBox inputFileOfLabelsAtop;
        private System.Windows.Forms.Button ChooseFileAtopButt;
        private System.Windows.Forms.Button ChooseFilePermutaButt;
        private System.Windows.Forms.NumericUpDown distructKfromNumericUpDown;
        private System.Windows.Forms.NumericUpDown distructKtoNumericUpDown;
        private System.Windows.Forms.NumericUpDown PreDefinedPopNum;
        private System.Windows.Forms.NumericUpDown OfIndividualsNum;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox structureDataFileNameTextBox;
        private System.Windows.Forms.Label structureDataFileNameLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CLUMPPParametersComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SaveCLUMPPParamSetButt;
        private System.Windows.Forms.Button StartCLUMPPButt;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox distructParametersComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel programsProcessTableLayoutPanel;
        private System.Windows.Forms.Label structurLabelTableLayoutPanel;
        private System.Windows.Forms.Label structureHarvesterLabelTableLayoutPanel;
        private System.Windows.Forms.Label clumppLabelTableLayoutPanel;
        private System.Windows.Forms.Label distructTableLayoutPanel;
        private Custom_interface_elements.TextProgressBar structureProgressBarTableLayoutPanel;
        private Custom_interface_elements.TextProgressBar structureHarvesterProgressBarTableLayoutPanel;
        private Custom_interface_elements.TextProgressBar clumppProgressBarTableLayoutPanel;
        private Custom_interface_elements.TextProgressBar distructProgressBarTableLayoutPanel;
        private System.Windows.Forms.Button loadStructureDataFileButton;
        private System.Windows.Forms.BindingSource currentProjectInfoBindingSource;
        private System.Windows.Forms.BindingSource structureMainparamsBindingSource;
        private System.Windows.Forms.BindingSource structureExtraparamsBindingSource;
        private System.Windows.Forms.CheckBox usePopFlagForTrainingCheckBox;
        private System.Windows.Forms.GroupBox locPriorModelGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown initialValueNNumericUpDown;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label initialValueNLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox priorPopInformationGroupBox;
        private System.Windows.Forms.GroupBox linkageModelGroupBox;
        private System.Windows.Forms.CheckBox printNetCheckBox;
        private System.Windows.Forms.CheckBox printCurrentLambdaValueCheckBox;
        private System.Windows.Forms.CheckBox printSumOfQCheckBox;
        private System.Windows.Forms.NumericUpDown printUpdateFreqNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox saveIntermediateDataCheckBox;
        private System.Windows.Forms.CheckBox printBriefSummaryCheckBox;
        private System.Windows.Forms.NumericUpDown preBurnLengthNumericUpDown;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown seedNumericUpDown;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox randomizeCheckBox;
        private System.Windows.Forms.CheckBox hitRateCheckBox;
        private System.Windows.Forms.NumericUpDown structureIterationsNumericUpDown;
        private System.Windows.Forms.NumericUpDown structureKToNumericUpDown;
        private System.Windows.Forms.NumericUpDown structureKFromNumericUpDown;
        private System.Windows.Forms.Label structureIterationsLabel;
        private System.Windows.Forms.Label structureWithLabel;
        private System.Windows.Forms.Label structureKToLabel;
        private System.Windows.Forms.Label structureKFromLabel;
        private System.Windows.Forms.CheckBox structureHarvesterClumppCheckBox;
        private System.Windows.Forms.CheckBox structureHarvesterEvannoCheckBox;
        //private OxyPlot.WindowsForms.PlotView structureHarvesterMeanChartForm;
        //private ScottPlot.WinForms.FormsPlot structureHarvesterMeanChartForm;
        //private ScottPlot.WinForms.FormsPlot structureHarvesterDeltaChartForm;
        //private ScottPlot.WinForms.FormsPlot structureHarvesterDoublePrimeChartForm;
        //private ScottPlot.WinForms.FormsPlot structureHarvesterPrimeChartForm;
        private System.Windows.Forms.DataVisualization.Charting.Chart structureHarvesterMeanChartForm;
        private System.Windows.Forms.DataVisualization.Charting.Chart structureHarvesterPrimeChartForm;
        private System.Windows.Forms.DataVisualization.Charting.Chart structureHarvesterDoublePrimeChartForm;
        private System.Windows.Forms.DataVisualization.Charting.Chart structureHarvesterDeltaChartForm;
        private System.Windows.Forms.ComboBox CLUMPPInputComboBox;
        private System.Windows.Forms.Label CLUMPPInputLabel;
        private System.Windows.Forms.Label CLUMPPKToLabel;
        private System.Windows.Forms.Label CLUMPPKFromLabel;
        private System.Windows.Forms.NumericUpDown CLUMPPKToNumericUpDown;
        private System.Windows.Forms.NumericUpDown CLUMPPKFromNumericUpDown;
        private System.Windows.Forms.BindingSource CLUMPPParametersModelBindingSource;
        private System.Windows.Forms.ComboBox distructInputComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource distructParametersModelBindingSource;
        private System.Windows.Forms.Label numOfPopulationsLabel;
        private System.Windows.Forms.NumericUpDown numOfPopulationsNumericUpDown;
        private System.Windows.Forms.Label distructKFromLabel;
        private System.Windows.Forms.NumericUpDown distructKFromNumericUpDown;
        private System.Windows.Forms.Label distructKToLabel;
        private System.Windows.Forms.NumericUpDown distructKToNumericUpDown;
        private System.Windows.Forms.BindingSource structureConfigurationParametersBindingSource;
        private System.Windows.Forms.BindingSource structureHarvesterConfigurationParametersBindingSource;
        private System.Windows.Forms.BindingSource CLUMPPConfigurationParametersBindingSource;
        private System.Windows.Forms.BindingSource distructConfigurationParametersBindingSource;
        private System.Windows.Forms.Label structureEtaLabelTableLayoutPanel;
        private System.Windows.Forms.Label structureHarvesterEtaLabelTableLayoutPanel;
        private System.Windows.Forms.Label CLUMPPEtaLabelTableLayoutPanel;
        private System.Windows.Forms.Label distructEtaLabelTableLayoutPanel;
        private System.Windows.Forms.GroupBox distructExportGroupBox;
        private System.Windows.Forms.CheckedListBox distructExportTypeCheckedListBox;
        private System.Windows.Forms.Button distructExportButton;
        private System.Windows.Forms.ComboBox distructProcessedSetsToExportComboBox;
        private System.Windows.Forms.PictureBox distructPre_renderedPictureBox;
        private System.Windows.Forms.Button distructPre_renderedButton;
        private System.Windows.Forms.ComboBox distructPre_renderedComboBox;
        private System.Windows.Forms.TextBox structureLogTextBox;
        private System.Windows.Forms.TextBox structureHarvesterLogTextBox;
        private System.Windows.Forms.TextBox clumppLogTextBox;
        private System.Windows.Forms.TextBox distructLogTextBox;
        private System.Windows.Forms.Button clumppStopButton;
        private System.Windows.Forms.Button distructStopButton;
        private System.Windows.Forms.ComboBox structureHarvesterInputComboBox;
        private System.Windows.Forms.RadioButton clumppPopAndIndRadioButton;
        private System.Windows.Forms.RadioButton clumppOnlyPopRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox clumppWCheckBox;
        private System.Windows.Forms.Label clumppOrderByRunLabel;
        private System.Windows.Forms.NumericUpDown clumppOrderByRunNumericUpDown;
        private System.Windows.Forms.CheckBox clumppSCheckBox;
        private System.Windows.Forms.ComboBox GreedyOptionChoose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label69;
    }
}