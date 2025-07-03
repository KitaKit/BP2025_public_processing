
namespace GenotypeApp
{
    partial class LoadStructureDataFileWindow
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
            saveButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            chooseFileButton = new System.Windows.Forms.Button();
            mainGroupBox = new System.Windows.Forms.GroupBox();
            predictedOnePerRowLabel = new System.Windows.Forms.Label();
            structureMainparamsBindingSource = new System.Windows.Forms.BindingSource(components);
            predictedMarkerNamesLabel = new System.Windows.Forms.Label();
            predictedRecessiveAllelesLabel = new System.Windows.Forms.Label();
            predictedNotAmbiguousLabel = new System.Windows.Forms.Label();
            predictedMapDistanceLabel = new System.Windows.Forms.Label();
            predictedPhaseInfoLabel = new System.Windows.Forms.Label();
            predictedLabelLabel = new System.Windows.Forms.Label();
            predictedPopFlagLabel = new System.Windows.Forms.Label();
            predictedPopDataLabel = new System.Windows.Forms.Label();
            predictedPhenotypeLabel = new System.Windows.Forms.Label();
            predictedExtraColsLabel = new System.Windows.Forms.Label();
            predictedLocDataLabel = new System.Windows.Forms.Label();
            predictedMissingLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            predictedPloidyLabel = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            extraColumsCheckBox = new System.Windows.Forms.CheckBox();
            extraColumsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            popInfoFlagCheckBox = new System.Windows.Forms.CheckBox();
            allegedPopulationCheckBox = new System.Windows.Forms.CheckBox();
            locationInformationCheckBox = new System.Windows.Forms.CheckBox();
            individualIDCheckBox = new System.Windows.Forms.CheckBox();
            phenotypeInformationCheckBox = new System.Windows.Forms.CheckBox();
            predictedNumLociLabel = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ambiguousGenotypesCheckBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            markerRowCheckBox = new System.Windows.Forms.CheckBox();
            singleLineCheckBox = new System.Windows.Forms.CheckBox();
            mapDistancesCheckBox = new System.Windows.Forms.CheckBox();
            recessiveAllelesRowCheckBox = new System.Windows.Forms.CheckBox();
            phaseInfoCheckBox = new System.Windows.Forms.CheckBox();
            predictedNumIndsLabel = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            missingDataValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            individualsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ploidyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            lociNumericUpDown = new System.Windows.Forms.NumericUpDown();
            dataFileNameTextBox = new System.Windows.Forms.TextBox();
            structureInputModelBindingSource = new System.Windows.Forms.BindingSource(components);
            structureInputDataDataGridView = new System.Windows.Forms.DataGridView();
            mainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)structureMainparamsBindingSource).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)extraColumsNumericUpDown).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)missingDataValueNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)individualsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ploidyNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lociNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)structureInputModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)structureInputDataDataGridView).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(300, 603);
            saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(102, 30);
            saveButton.TabIndex = 19;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(408, 604);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(102, 30);
            cancelButton.TabIndex = 18;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // chooseFileButton
            // 
            chooseFileButton.Location = new System.Drawing.Point(407, 20);
            chooseFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            chooseFileButton.Name = "chooseFileButton";
            chooseFileButton.Size = new System.Drawing.Size(102, 25);
            chooseFileButton.TabIndex = 17;
            chooseFileButton.Text = "Choose file";
            chooseFileButton.UseVisualStyleBackColor = true;
            chooseFileButton.Click += chooseFileButton_Click;
            // 
            // mainGroupBox
            // 
            mainGroupBox.Controls.Add(predictedOnePerRowLabel);
            mainGroupBox.Controls.Add(predictedMarkerNamesLabel);
            mainGroupBox.Controls.Add(predictedRecessiveAllelesLabel);
            mainGroupBox.Controls.Add(predictedNotAmbiguousLabel);
            mainGroupBox.Controls.Add(predictedMapDistanceLabel);
            mainGroupBox.Controls.Add(predictedPhaseInfoLabel);
            mainGroupBox.Controls.Add(predictedLabelLabel);
            mainGroupBox.Controls.Add(predictedPopFlagLabel);
            mainGroupBox.Controls.Add(predictedPopDataLabel);
            mainGroupBox.Controls.Add(predictedPhenotypeLabel);
            mainGroupBox.Controls.Add(predictedExtraColsLabel);
            mainGroupBox.Controls.Add(predictedLocDataLabel);
            mainGroupBox.Controls.Add(predictedMissingLabel);
            mainGroupBox.Controls.Add(label3);
            mainGroupBox.Controls.Add(predictedPloidyLabel);
            mainGroupBox.Controls.Add(groupBox5);
            mainGroupBox.Controls.Add(predictedNumLociLabel);
            mainGroupBox.Controls.Add(groupBox2);
            mainGroupBox.Controls.Add(predictedNumIndsLabel);
            mainGroupBox.Controls.Add(groupBox3);
            mainGroupBox.Enabled = false;
            mainGroupBox.Location = new System.Drawing.Point(5, 50);
            mainGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            mainGroupBox.Name = "mainGroupBox";
            mainGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            mainGroupBox.Size = new System.Drawing.Size(505, 550);
            mainGroupBox.TabIndex = 16;
            mainGroupBox.TabStop = false;
            mainGroupBox.Text = "Choose input data file";
            // 
            // predictedOnePerRowLabel
            // 
            predictedOnePerRowLabel.AutoSize = true;
            predictedOnePerRowLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_ONEROWPERIND", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedOnePerRowLabel.Location = new System.Drawing.Point(390, 325);
            predictedOnePerRowLabel.Name = "predictedOnePerRowLabel";
            predictedOnePerRowLabel.Size = new System.Drawing.Size(0, 15);
            predictedOnePerRowLabel.TabIndex = 17;
            // 
            // structureMainparamsBindingSource
            // 
            structureMainparamsBindingSource.DataMember = "mainparams";
            structureMainparamsBindingSource.DataSource = typeof(Additional_programs_logic.Structure.StructureParametersModel);
            // 
            // predictedMarkerNamesLabel
            // 
            predictedMarkerNamesLabel.AutoSize = true;
            predictedMarkerNamesLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_MARKERNAMES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedMarkerNamesLabel.Location = new System.Drawing.Point(390, 205);
            predictedMarkerNamesLabel.Name = "predictedMarkerNamesLabel";
            predictedMarkerNamesLabel.Size = new System.Drawing.Size(0, 15);
            predictedMarkerNamesLabel.TabIndex = 18;
            // 
            // predictedRecessiveAllelesLabel
            // 
            predictedRecessiveAllelesLabel.AutoSize = true;
            predictedRecessiveAllelesLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_RECESSIVEALLELES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedRecessiveAllelesLabel.Location = new System.Drawing.Point(390, 225);
            predictedRecessiveAllelesLabel.Name = "predictedRecessiveAllelesLabel";
            predictedRecessiveAllelesLabel.Size = new System.Drawing.Size(0, 15);
            predictedRecessiveAllelesLabel.TabIndex = 19;
            // 
            // predictedNotAmbiguousLabel
            // 
            predictedNotAmbiguousLabel.AutoSize = true;
            predictedNotAmbiguousLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_NOTAMBIGUOUS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedNotAmbiguousLabel.Location = new System.Drawing.Point(390, 245);
            predictedNotAmbiguousLabel.Name = "predictedNotAmbiguousLabel";
            predictedNotAmbiguousLabel.Size = new System.Drawing.Size(0, 15);
            predictedNotAmbiguousLabel.TabIndex = 20;
            // 
            // predictedMapDistanceLabel
            // 
            predictedMapDistanceLabel.AutoSize = true;
            predictedMapDistanceLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_MAPDISTANCES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedMapDistanceLabel.Location = new System.Drawing.Point(390, 265);
            predictedMapDistanceLabel.Name = "predictedMapDistanceLabel";
            predictedMapDistanceLabel.Size = new System.Drawing.Size(0, 15);
            predictedMapDistanceLabel.TabIndex = 21;
            // 
            // predictedPhaseInfoLabel
            // 
            predictedPhaseInfoLabel.AutoSize = true;
            predictedPhaseInfoLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_PHASEINFO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedPhaseInfoLabel.Location = new System.Drawing.Point(390, 285);
            predictedPhaseInfoLabel.Name = "predictedPhaseInfoLabel";
            predictedPhaseInfoLabel.Size = new System.Drawing.Size(0, 15);
            predictedPhaseInfoLabel.TabIndex = 22;
            // 
            // predictedLabelLabel
            // 
            predictedLabelLabel.AutoSize = true;
            predictedLabelLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_LABEL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedLabelLabel.Location = new System.Drawing.Point(390, 395);
            predictedLabelLabel.Name = "predictedLabelLabel";
            predictedLabelLabel.Size = new System.Drawing.Size(0, 15);
            predictedLabelLabel.TabIndex = 30;
            // 
            // predictedPopFlagLabel
            // 
            predictedPopFlagLabel.AutoSize = true;
            predictedPopFlagLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_POPFLAG", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedPopFlagLabel.Location = new System.Drawing.Point(390, 435);
            predictedPopFlagLabel.Name = "predictedPopFlagLabel";
            predictedPopFlagLabel.Size = new System.Drawing.Size(0, 15);
            predictedPopFlagLabel.TabIndex = 31;
            // 
            // predictedPopDataLabel
            // 
            predictedPopDataLabel.AutoSize = true;
            predictedPopDataLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_POPDATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedPopDataLabel.Location = new System.Drawing.Point(390, 415);
            predictedPopDataLabel.Name = "predictedPopDataLabel";
            predictedPopDataLabel.Size = new System.Drawing.Size(0, 15);
            predictedPopDataLabel.TabIndex = 32;
            // 
            // predictedPhenotypeLabel
            // 
            predictedPhenotypeLabel.AutoSize = true;
            predictedPhenotypeLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_PHENOTYPE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedPhenotypeLabel.Location = new System.Drawing.Point(390, 475);
            predictedPhenotypeLabel.Name = "predictedPhenotypeLabel";
            predictedPhenotypeLabel.Size = new System.Drawing.Size(0, 15);
            predictedPhenotypeLabel.TabIndex = 33;
            // 
            // predictedExtraColsLabel
            // 
            predictedExtraColsLabel.AutoSize = true;
            predictedExtraColsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_EXTRACOLS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedExtraColsLabel.Location = new System.Drawing.Point(390, 495);
            predictedExtraColsLabel.Name = "predictedExtraColsLabel";
            predictedExtraColsLabel.Size = new System.Drawing.Size(0, 15);
            predictedExtraColsLabel.TabIndex = 34;
            // 
            // predictedLocDataLabel
            // 
            predictedLocDataLabel.AutoSize = true;
            predictedLocDataLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_LOCDATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedLocDataLabel.Location = new System.Drawing.Point(390, 455);
            predictedLocDataLabel.Name = "predictedLocDataLabel";
            predictedLocDataLabel.Size = new System.Drawing.Size(0, 15);
            predictedLocDataLabel.TabIndex = 35;
            // 
            // predictedMissingLabel
            // 
            predictedMissingLabel.AutoSize = true;
            predictedMissingLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_MISSING", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedMissingLabel.Location = new System.Drawing.Point(390, 110);
            predictedMissingLabel.Name = "predictedMissingLabel";
            predictedMissingLabel.Size = new System.Drawing.Size(0, 15);
            predictedMissingLabel.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(360, 15);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(124, 15);
            label3.TabIndex = 8;
            label3.Text = "Recommended values";
            // 
            // predictedPloidyLabel
            // 
            predictedPloidyLabel.AutoSize = true;
            predictedPloidyLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_PLOIDY", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedPloidyLabel.Location = new System.Drawing.Point(390, 90);
            predictedPloidyLabel.Name = "predictedPloidyLabel";
            predictedPloidyLabel.Size = new System.Drawing.Size(0, 15);
            predictedPloidyLabel.TabIndex = 10;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(extraColumsCheckBox);
            groupBox5.Controls.Add(extraColumsNumericUpDown);
            groupBox5.Controls.Add(popInfoFlagCheckBox);
            groupBox5.Controls.Add(allegedPopulationCheckBox);
            groupBox5.Controls.Add(locationInformationCheckBox);
            groupBox5.Controls.Add(individualIDCheckBox);
            groupBox5.Controls.Add(phenotypeInformationCheckBox);
            groupBox5.Location = new System.Drawing.Point(5, 370);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(340, 163);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Please check box if data file contains following column(s):";
            // 
            // extraColumsCheckBox
            // 
            extraColumsCheckBox.AutoSize = true;
            extraColumsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "UseExtraCols", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            extraColumsCheckBox.Location = new System.Drawing.Point(15, 125);
            extraColumsCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            extraColumsCheckBox.Name = "extraColumsCheckBox";
            extraColumsCheckBox.Size = new System.Drawing.Size(228, 19);
            extraColumsCheckBox.TabIndex = 28;
            extraColumsCheckBox.Text = "Other extra colums      if so, how many";
            extraColumsCheckBox.UseVisualStyleBackColor = true;
            extraColumsCheckBox.CheckedChanged += extraColumsCheckBox_CheckedChanged;
            // 
            // extraColumsNumericUpDown
            // 
            extraColumsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "EXTRACOLS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            extraColumsNumericUpDown.Enabled = false;
            extraColumsNumericUpDown.Location = new System.Drawing.Point(260, 120);
            extraColumsNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            extraColumsNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            extraColumsNumericUpDown.Name = "extraColumsNumericUpDown";
            extraColumsNumericUpDown.Size = new System.Drawing.Size(68, 23);
            extraColumsNumericUpDown.TabIndex = 29;
            // 
            // popInfoFlagCheckBox
            // 
            popInfoFlagCheckBox.AutoSize = true;
            popInfoFlagCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "POPFLAG", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            popInfoFlagCheckBox.Location = new System.Drawing.Point(15, 65);
            popInfoFlagCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            popInfoFlagCheckBox.Name = "popInfoFlagCheckBox";
            popInfoFlagCheckBox.Size = new System.Drawing.Size(119, 19);
            popInfoFlagCheckBox.TabIndex = 25;
            popInfoFlagCheckBox.Text = "USEPOPINFO flag";
            popInfoFlagCheckBox.UseVisualStyleBackColor = true;
            // 
            // allegedPopulationCheckBox
            // 
            allegedPopulationCheckBox.AutoSize = true;
            allegedPopulationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "POPDATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            allegedPopulationCheckBox.Location = new System.Drawing.Point(15, 45);
            allegedPopulationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            allegedPopulationCheckBox.Name = "allegedPopulationCheckBox";
            allegedPopulationCheckBox.Size = new System.Drawing.Size(258, 19);
            allegedPopulationCheckBox.TabIndex = 24;
            allegedPopulationCheckBox.Text = "Alleged population origin of each individual";
            allegedPopulationCheckBox.UseVisualStyleBackColor = true;
            // 
            // locationInformationCheckBox
            // 
            locationInformationCheckBox.AutoSize = true;
            locationInformationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "LOCDATA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            locationInformationCheckBox.Location = new System.Drawing.Point(15, 85);
            locationInformationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            locationInformationCheckBox.Name = "locationInformationCheckBox";
            locationInformationCheckBox.Size = new System.Drawing.Size(188, 19);
            locationInformationCheckBox.TabIndex = 26;
            locationInformationCheckBox.Text = "Sampling location information";
            locationInformationCheckBox.UseVisualStyleBackColor = true;
            // 
            // individualIDCheckBox
            // 
            individualIDCheckBox.AutoSize = true;
            individualIDCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "LABEL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            individualIDCheckBox.Location = new System.Drawing.Point(15, 25);
            individualIDCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            individualIDCheckBox.Name = "individualIDCheckBox";
            individualIDCheckBox.Size = new System.Drawing.Size(138, 19);
            individualIDCheckBox.TabIndex = 22;
            individualIDCheckBox.Text = "ID for each individual";
            individualIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // phenotypeInformationCheckBox
            // 
            phenotypeInformationCheckBox.AutoSize = true;
            phenotypeInformationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "PHENOTYPE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            phenotypeInformationCheckBox.Location = new System.Drawing.Point(15, 105);
            phenotypeInformationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            phenotypeInformationCheckBox.Name = "phenotypeInformationCheckBox";
            phenotypeInformationCheckBox.Size = new System.Drawing.Size(149, 19);
            phenotypeInformationCheckBox.TabIndex = 27;
            phenotypeInformationCheckBox.Text = "Phenotype information";
            phenotypeInformationCheckBox.UseVisualStyleBackColor = true;
            // 
            // predictedNumLociLabel
            // 
            predictedNumLociLabel.AutoSize = true;
            predictedNumLociLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_NUMLOCI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedNumLociLabel.Location = new System.Drawing.Point(390, 70);
            predictedNumLociLabel.Name = "predictedNumLociLabel";
            predictedNumLociLabel.Size = new System.Drawing.Size(0, 15);
            predictedNumLociLabel.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ambiguousGenotypesCheckBox);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(markerRowCheckBox);
            groupBox2.Controls.Add(singleLineCheckBox);
            groupBox2.Controls.Add(mapDistancesCheckBox);
            groupBox2.Controls.Add(recessiveAllelesRowCheckBox);
            groupBox2.Controls.Add(phaseInfoCheckBox);
            groupBox2.Location = new System.Drawing.Point(5, 165);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox2.Size = new System.Drawing.Size(340, 195);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Format of input data set";
            // 
            // ambiguousGenotypesCheckBox
            // 
            ambiguousGenotypesCheckBox.AutoSize = true;
            ambiguousGenotypesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "NOTAMBIGUOUS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ambiguousGenotypesCheckBox.Enabled = false;
            ambiguousGenotypesCheckBox.Location = new System.Drawing.Point(30, 85);
            ambiguousGenotypesCheckBox.Name = "ambiguousGenotypesCheckBox";
            ambiguousGenotypesCheckBox.Size = new System.Drawing.Size(260, 19);
            ambiguousGenotypesCheckBox.TabIndex = 16;
            ambiguousGenotypesCheckBox.Text = "Exclude ambiguous genotypes from analysis";
            ambiguousGenotypesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 150);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 5;
            label1.Text = "Special format";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(291, 15);
            label2.TabIndex = 15;
            label2.Text = "Please check box if data file contains following row(s):";
            // 
            // markerRowCheckBox
            // 
            markerRowCheckBox.AutoSize = true;
            markerRowCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "MARKERNAMES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            markerRowCheckBox.Location = new System.Drawing.Point(15, 45);
            markerRowCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            markerRowCheckBox.Name = "markerRowCheckBox";
            markerRowCheckBox.Size = new System.Drawing.Size(124, 19);
            markerRowCheckBox.TabIndex = 0;
            markerRowCheckBox.Text = "Marker names row";
            markerRowCheckBox.UseVisualStyleBackColor = true;
            // 
            // singleLineCheckBox
            // 
            singleLineCheckBox.AutoSize = true;
            singleLineCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "ONEROWPERIND", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            singleLineCheckBox.Location = new System.Drawing.Point(15, 170);
            singleLineCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            singleLineCheckBox.Name = "singleLineCheckBox";
            singleLineCheckBox.Size = new System.Drawing.Size(225, 19);
            singleLineCheckBox.TabIndex = 4;
            singleLineCheckBox.Text = "Data for individuals are in a single line";
            singleLineCheckBox.UseVisualStyleBackColor = true;
            // 
            // mapDistancesCheckBox
            // 
            mapDistancesCheckBox.AutoSize = true;
            mapDistancesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "MAPDISTANCES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            mapDistancesCheckBox.Location = new System.Drawing.Point(15, 105);
            mapDistancesCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            mapDistancesCheckBox.Name = "mapDistancesCheckBox";
            mapDistancesCheckBox.Size = new System.Drawing.Size(195, 19);
            mapDistancesCheckBox.TabIndex = 2;
            mapDistancesCheckBox.Text = "Map distances between loci row";
            mapDistancesCheckBox.UseVisualStyleBackColor = true;
            // 
            // recessiveAllelesRowCheckBox
            // 
            recessiveAllelesRowCheckBox.AutoSize = true;
            recessiveAllelesRowCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "RECESSIVEALLELES", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            recessiveAllelesRowCheckBox.Location = new System.Drawing.Point(15, 65);
            recessiveAllelesRowCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            recessiveAllelesRowCheckBox.Name = "recessiveAllelesRowCheckBox";
            recessiveAllelesRowCheckBox.Size = new System.Drawing.Size(134, 19);
            recessiveAllelesRowCheckBox.TabIndex = 1;
            recessiveAllelesRowCheckBox.Text = "Recessive alleles row";
            recessiveAllelesRowCheckBox.UseVisualStyleBackColor = true;
            recessiveAllelesRowCheckBox.CheckedChanged += recessiveAllelesRowCheckBox_CheckedChanged;
            // 
            // phaseInfoCheckBox
            // 
            phaseInfoCheckBox.AutoSize = true;
            phaseInfoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", structureMainparamsBindingSource, "PHASEINFO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            phaseInfoCheckBox.Location = new System.Drawing.Point(15, 130);
            phaseInfoCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            phaseInfoCheckBox.Name = "phaseInfoCheckBox";
            phaseInfoCheckBox.Size = new System.Drawing.Size(81, 19);
            phaseInfoCheckBox.TabIndex = 3;
            phaseInfoCheckBox.Text = "Phase info";
            phaseInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // predictedNumIndsLabel
            // 
            predictedNumIndsLabel.AutoSize = true;
            predictedNumIndsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", structureMainparamsBindingSource, "PREDICTED_NUMINDS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            predictedNumIndsLabel.Location = new System.Drawing.Point(390, 50);
            predictedNumIndsLabel.Name = "predictedNumIndsLabel";
            predictedNumIndsLabel.Size = new System.Drawing.Size(0, 15);
            predictedNumIndsLabel.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(missingDataValueNumericUpDown);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(individualsNumericUpDown);
            groupBox3.Controls.Add(ploidyNumericUpDown);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(lociNumericUpDown);
            groupBox3.Location = new System.Drawing.Point(5, 20);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            groupBox3.Size = new System.Drawing.Size(340, 140);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Information of input data set";
            // 
            // missingDataValueNumericUpDown
            // 
            missingDataValueNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "MISSING", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            missingDataValueNumericUpDown.Location = new System.Drawing.Point(260, 100);
            missingDataValueNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            missingDataValueNumericUpDown.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            missingDataValueNumericUpDown.Minimum = new decimal(new int[] { 999, 0, 0, int.MinValue });
            missingDataValueNumericUpDown.Name = "missingDataValueNumericUpDown";
            missingDataValueNumericUpDown.Size = new System.Drawing.Size(59, 23);
            missingDataValueNumericUpDown.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 105);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(108, 15);
            label5.TabIndex = 7;
            label5.Text = "Missing data value:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(15, 30);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(128, 15);
            label8.TabIndex = 4;
            label8.Text = "Number of individuals:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(15, 55);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(90, 15);
            label7.TabIndex = 5;
            label7.Text = "Number of loci:";
            // 
            // individualsNumericUpDown
            // 
            individualsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "NUMINDS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            individualsNumericUpDown.Location = new System.Drawing.Point(260, 25);
            individualsNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            individualsNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            individualsNumericUpDown.Name = "individualsNumericUpDown";
            individualsNumericUpDown.Size = new System.Drawing.Size(59, 23);
            individualsNumericUpDown.TabIndex = 3;
            // 
            // ploidyNumericUpDown
            // 
            ploidyNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "PLOIDY", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ploidyNumericUpDown.Location = new System.Drawing.Point(260, 75);
            ploidyNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ploidyNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            ploidyNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ploidyNumericUpDown.Name = "ploidyNumericUpDown";
            ploidyNumericUpDown.Size = new System.Drawing.Size(59, 23);
            ploidyNumericUpDown.TabIndex = 1;
            ploidyNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            ploidyNumericUpDown.ValueChanged += ploidyNumericUpDown_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(15, 80);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 15);
            label6.TabIndex = 6;
            label6.Text = "Ploidy of data:";
            // 
            // lociNumericUpDown
            // 
            lociNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", structureMainparamsBindingSource, "NUMLOCI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            lociNumericUpDown.Location = new System.Drawing.Point(260, 50);
            lociNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lociNumericUpDown.Maximum = new decimal(new int[] { 32768, 0, 0, 0 });
            lociNumericUpDown.Name = "lociNumericUpDown";
            lociNumericUpDown.Size = new System.Drawing.Size(59, 23);
            lociNumericUpDown.TabIndex = 2;
            lociNumericUpDown.ValueChanged += lociNumericUpDown_ValueChanged;
            // 
            // dataFileNameTextBox
            // 
            dataFileNameTextBox.Location = new System.Drawing.Point(5, 20);
            dataFileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dataFileNameTextBox.Name = "dataFileNameTextBox";
            dataFileNameTextBox.ReadOnly = true;
            dataFileNameTextBox.Size = new System.Drawing.Size(396, 23);
            dataFileNameTextBox.TabIndex = 15;
            dataFileNameTextBox.Text = "Choose file ...";
            // 
            // structureInputModelBindingSource
            // 
            structureInputModelBindingSource.DataSource = typeof(Additional_programs_logic.Structure.StructureConfigurationParametersModel);
            // 
            // structureInputDataDataGridView
            // 
            structureInputDataDataGridView.AllowUserToAddRows = false;
            structureInputDataDataGridView.AllowUserToDeleteRows = false;
            structureInputDataDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            structureInputDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            structureInputDataDataGridView.Location = new System.Drawing.Point(516, 59);
            structureInputDataDataGridView.Name = "structureInputDataDataGridView";
            structureInputDataDataGridView.ReadOnly = true;
            structureInputDataDataGridView.Size = new System.Drawing.Size(1233, 541);
            structureInputDataDataGridView.TabIndex = 20;
            structureInputDataDataGridView.CellPainting += structureInputDataDataGridView_CellPainting;
            // 
            // LoadStructureDataFileWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1761, 646);
            Controls.Add(structureInputDataDataGridView);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(chooseFileButton);
            Controls.Add(dataFileNameTextBox);
            Controls.Add(mainGroupBox);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "LoadStructureDataFileWindow";
            Text = "Load Structure Data";
            Load += LoadStructureDataFileWindow_Load;
            mainGroupBox.ResumeLayout(false);
            mainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)structureMainparamsBindingSource).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)extraColumsNumericUpDown).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)missingDataValueNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)individualsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ploidyNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)lociNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)structureInputModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)structureInputDataDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox extraColumsCheckBox;
        private System.Windows.Forms.NumericUpDown extraColumsNumericUpDown;
        private System.Windows.Forms.CheckBox popInfoFlagCheckBox;
        private System.Windows.Forms.CheckBox allegedPopulationCheckBox;
        private System.Windows.Forms.CheckBox locationInformationCheckBox;
        private System.Windows.Forms.CheckBox individualIDCheckBox;
        private System.Windows.Forms.CheckBox phenotypeInformationCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox markerRowCheckBox;
        private System.Windows.Forms.CheckBox singleLineCheckBox;
        private System.Windows.Forms.CheckBox mapDistancesCheckBox;
        private System.Windows.Forms.CheckBox recessiveAllelesRowCheckBox;
        private System.Windows.Forms.CheckBox phaseInfoCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown missingDataValueNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown individualsNumericUpDown;
        private System.Windows.Forms.NumericUpDown ploidyNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown lociNumericUpDown;
        private System.Windows.Forms.BindingSource structureMainparamsBindingSource;
        private System.Windows.Forms.CheckBox ambiguousGenotypesCheckBox;
        private System.Windows.Forms.TextBox dataFileNameTextBox;
        private System.Windows.Forms.BindingSource structureInputModelBindingSource;
        private System.Windows.Forms.Label predictedNumIndsLabel;
        private System.Windows.Forms.Label predictedNumLociLabel;
        private System.Windows.Forms.Label predictedPloidyLabel;
        private System.Windows.Forms.Label predictedMissingLabel;
        private System.Windows.Forms.Label predictedOnePerRowLabel;
        private System.Windows.Forms.Label predictedLabelLabel;
        private System.Windows.Forms.Label predictedPopFlagLabel;
        private System.Windows.Forms.Label predictedPopDataLabel;
        private System.Windows.Forms.Label predictedPhenotypeLabel;
        private System.Windows.Forms.Label predictedExtraColsLabel;
        private System.Windows.Forms.Label predictedMarkerNamesLabel;
        private System.Windows.Forms.Label predictedRecessiveAllelesLabel;
        private System.Windows.Forms.Label predictedNotAmbiguousLabel;
        private System.Windows.Forms.Label predictedMapDistanceLabel;
        private System.Windows.Forms.Label predictedPhaseInfoLabel;
        private System.Windows.Forms.Label predictedLocDataLabel;
        private System.Windows.Forms.DataGridView structureInputDataDataGridView;
        private System.Windows.Forms.Label label3;
    }
}