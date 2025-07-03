
using System;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace GenotypeApp
{
    partial class GenotypeProjectsWindow
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
            lastProjectsLabel = new Label();
            doneButton = new Button();
            currentProjectInfoLabel = new Label();
            currentProjectInfoTextBox = new TextBox();
            currentProjectInfoBindingSource = new BindingSource(components);
            lastProjectsListView = new ListView();
            projectInformationModelBindingSource = new BindingSource(components);
            programsCheckedListBox = new CheckedListBox();
            usingProgramsLabel = new Label();
            operatingModeGroupBox = new GroupBox();
            allowParallelExecutionCheckBox = new CheckBox();
            parallelExecutionGroupBox = new GroupBox();
            coresLabel = new Label();
            coresNumLabel = new Label();
            coresNumTrackBar = new TrackBar();
            selectCoresRadioButton = new RadioButton();
            allCoresRadioButton = new RadioButton();
            projectNameTextBox = new TextBox();
            projectPathTextBox = new TextBox();
            openProjectButton = new Button();
            label1 = new Label();
            label2 = new Label();
            changePathButton = new Button();
            ((System.ComponentModel.ISupportInitialize)currentProjectInfoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectInformationModelBindingSource).BeginInit();
            operatingModeGroupBox.SuspendLayout();
            parallelExecutionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)coresNumTrackBar).BeginInit();
            SuspendLayout();
            // 
            // lastProjectsLabel
            // 
            lastProjectsLabel.AutoSize = true;
            lastProjectsLabel.Location = new System.Drawing.Point(12, 134);
            lastProjectsLabel.Name = "lastProjectsLabel";
            lastProjectsLabel.Size = new System.Drawing.Size(73, 15);
            lastProjectsLabel.TabIndex = 13;
            lastProjectsLabel.Text = "Last projects";
            // 
            // doneButton
            // 
            doneButton.Location = new System.Drawing.Point(699, 260);
            doneButton.Name = "doneButton";
            doneButton.Size = new System.Drawing.Size(293, 67);
            doneButton.TabIndex = 27;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // currentProjectInfoLabel
            // 
            currentProjectInfoLabel.AutoSize = true;
            currentProjectInfoLabel.Location = new System.Drawing.Point(699, 31);
            currentProjectInfoLabel.Name = "currentProjectInfoLabel";
            currentProjectInfoLabel.Size = new System.Drawing.Size(153, 15);
            currentProjectInfoLabel.TabIndex = 31;
            currentProjectInfoLabel.Text = "Current project information";
            // 
            // currentProjectInfoTextBox
            // 
            currentProjectInfoTextBox.DataBindings.Add(new Binding("Text", currentProjectInfoBindingSource, "FormattedCurrentProjectInfo", true, DataSourceUpdateMode.OnPropertyChanged));
            currentProjectInfoTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            currentProjectInfoTextBox.Location = new System.Drawing.Point(699, 49);
            currentProjectInfoTextBox.Multiline = true;
            currentProjectInfoTextBox.Name = "currentProjectInfoTextBox";
            currentProjectInfoTextBox.ReadOnly = true;
            currentProjectInfoTextBox.ScrollBars = ScrollBars.Vertical;
            currentProjectInfoTextBox.Size = new System.Drawing.Size(293, 205);
            currentProjectInfoTextBox.TabIndex = 33;
            // 
            // currentProjectInfoBindingSource
            // 
            currentProjectInfoBindingSource.DataSource = typeof(Interface_view_models.CurrentProjectInfoViewModel);
            // 
            // lastProjectsListView
            // 
            lastProjectsListView.Location = new System.Drawing.Point(12, 157);
            lastProjectsListView.Name = "lastProjectsListView";
            lastProjectsListView.Size = new System.Drawing.Size(404, 170);
            lastProjectsListView.TabIndex = 34;
            lastProjectsListView.UseCompatibleStateImageBehavior = false;
            // 
            // projectInformationModelBindingSource
            // 
            projectInformationModelBindingSource.DataSource = typeof(ProjectInformationModel);
            // 
            // programsCheckedListBox
            // 
            programsCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            programsCheckedListBox.BorderStyle = BorderStyle.None;
            programsCheckedListBox.CheckOnClick = true;
            programsCheckedListBox.ColumnWidth = 122;
            programsCheckedListBox.FormattingEnabled = true;
            programsCheckedListBox.Items.AddRange(new object[] { "Structure", "Structure Harvester", "CLUMPP", "Distruct" });
            programsCheckedListBox.Location = new System.Drawing.Point(4, 34);
            programsCheckedListBox.MultiColumn = true;
            programsCheckedListBox.Name = "programsCheckedListBox";
            programsCheckedListBox.Size = new System.Drawing.Size(249, 36);
            programsCheckedListBox.TabIndex = 28;
            programsCheckedListBox.ItemCheck += programsCheckedListBox_ItemCheck;
            // 
            // usingProgramsLabel
            // 
            usingProgramsLabel.AutoSize = true;
            usingProgramsLabel.Location = new System.Drawing.Point(4, 12);
            usingProgramsLabel.Name = "usingProgramsLabel";
            usingProgramsLabel.Size = new System.Drawing.Size(150, 15);
            usingProgramsLabel.TabIndex = 30;
            usingProgramsLabel.Text = "Select the programs to use:";
            // 
            // operatingModeGroupBox
            // 
            operatingModeGroupBox.Controls.Add(usingProgramsLabel);
            operatingModeGroupBox.Controls.Add(programsCheckedListBox);
            operatingModeGroupBox.Location = new System.Drawing.Point(426, 49);
            operatingModeGroupBox.Name = "operatingModeGroupBox";
            operatingModeGroupBox.Size = new System.Drawing.Size(267, 82);
            operatingModeGroupBox.TabIndex = 35;
            operatingModeGroupBox.TabStop = false;
            // 
            // allowParallelExecutionCheckBox
            // 
            allowParallelExecutionCheckBox.AutoSize = true;
            allowParallelExecutionCheckBox.DataBindings.Add(new Binding("Checked", projectInformationModelBindingSource, "ParallelExec", true, DataSourceUpdateMode.OnPropertyChanged));
            allowParallelExecutionCheckBox.Location = new System.Drawing.Point(435, 167);
            allowParallelExecutionCheckBox.Name = "allowParallelExecutionCheckBox";
            allowParallelExecutionCheckBox.Size = new System.Drawing.Size(151, 19);
            allowParallelExecutionCheckBox.TabIndex = 167;
            allowParallelExecutionCheckBox.Text = "Allow parallel execution";
            allowParallelExecutionCheckBox.UseVisualStyleBackColor = true;
            allowParallelExecutionCheckBox.CheckedChanged += allowParallelExecutionCheckBox_CheckedChanged;
            // 
            // parallelExecutionGroupBox
            // 
            parallelExecutionGroupBox.Controls.Add(coresLabel);
            parallelExecutionGroupBox.Controls.Add(coresNumLabel);
            parallelExecutionGroupBox.Controls.Add(coresNumTrackBar);
            parallelExecutionGroupBox.Controls.Add(selectCoresRadioButton);
            parallelExecutionGroupBox.Controls.Add(allCoresRadioButton);
            parallelExecutionGroupBox.Enabled = false;
            parallelExecutionGroupBox.Location = new System.Drawing.Point(429, 179);
            parallelExecutionGroupBox.Name = "parallelExecutionGroupBox";
            parallelExecutionGroupBox.Size = new System.Drawing.Size(264, 127);
            parallelExecutionGroupBox.TabIndex = 168;
            parallelExecutionGroupBox.TabStop = false;
            // 
            // coresLabel
            // 
            coresLabel.AutoSize = true;
            coresLabel.Location = new System.Drawing.Point(45, 73);
            coresLabel.Name = "coresLabel";
            coresLabel.Size = new System.Drawing.Size(35, 15);
            coresLabel.TabIndex = 24;
            coresLabel.Text = "cores";
            // 
            // coresNumLabel
            // 
            coresNumLabel.AutoSize = true;
            coresNumLabel.Location = new System.Drawing.Point(33, 73);
            coresNumLabel.Name = "coresNumLabel";
            coresNumLabel.Size = new System.Drawing.Size(13, 15);
            coresNumLabel.TabIndex = 23;
            coresNumLabel.Text = "1";
            // 
            // coresNumTrackBar
            // 
            coresNumTrackBar.DataBindings.Add(new Binding("Value", projectInformationModelBindingSource, "Cores", true, DataSourceUpdateMode.OnPropertyChanged));
            coresNumTrackBar.Enabled = false;
            coresNumTrackBar.Location = new System.Drawing.Point(75, 72);
            coresNumTrackBar.Maximum = 8;
            coresNumTrackBar.Minimum = 1;
            coresNumTrackBar.Name = "coresNumTrackBar";
            coresNumTrackBar.Size = new System.Drawing.Size(183, 45);
            coresNumTrackBar.TabIndex = 22;
            coresNumTrackBar.Value = 1;
            coresNumTrackBar.ValueChanged += coresNumTrackBar_ValueChanged;
            // 
            // selectCoresRadioButton
            // 
            selectCoresRadioButton.AutoSize = true;
            selectCoresRadioButton.Location = new System.Drawing.Point(19, 47);
            selectCoresRadioButton.Name = "selectCoresRadioButton";
            selectCoresRadioButton.Size = new System.Drawing.Size(146, 19);
            selectCoresRadioButton.TabIndex = 21;
            selectCoresRadioButton.Text = "Select number of cores";
            selectCoresRadioButton.UseVisualStyleBackColor = true;
            selectCoresRadioButton.CheckedChanged += selectCoresRadioButton_CheckedChanged;
            // 
            // allCoresRadioButton
            // 
            allCoresRadioButton.AutoSize = true;
            allCoresRadioButton.Checked = true;
            allCoresRadioButton.Location = new System.Drawing.Point(19, 22);
            allCoresRadioButton.Name = "allCoresRadioButton";
            allCoresRadioButton.Size = new System.Drawing.Size(119, 19);
            allCoresRadioButton.TabIndex = 20;
            allCoresRadioButton.TabStop = true;
            allCoresRadioButton.Text = "All available cores";
            allCoresRadioButton.UseVisualStyleBackColor = true;
            // 
            // projectNameTextBox
            // 
            projectNameTextBox.DataBindings.Add(new Binding("Text", projectInformationModelBindingSource, "ProjectName", true, DataSourceUpdateMode.OnPropertyChanged));
            projectNameTextBox.Location = new System.Drawing.Point(12, 49);
            projectNameTextBox.Name = "projectNameTextBox";
            projectNameTextBox.Size = new System.Drawing.Size(249, 23);
            projectNameTextBox.TabIndex = 169;
            projectNameTextBox.TextChanged += projectNameTextBox_TextChanged;
            // 
            // projectPathTextBox
            // 
            projectPathTextBox.DataBindings.Add(new Binding("Text", projectInformationModelBindingSource, "ProjectPath", true, DataSourceUpdateMode.OnPropertyChanged));
            projectPathTextBox.Location = new System.Drawing.Point(12, 91);
            projectPathTextBox.Name = "projectPathTextBox";
            projectPathTextBox.Size = new System.Drawing.Size(323, 23);
            projectPathTextBox.TabIndex = 170;
            // 
            // openProjectButton
            // 
            openProjectButton.Location = new System.Drawing.Point(267, 49);
            openProjectButton.Name = "openProjectButton";
            openProjectButton.Size = new System.Drawing.Size(149, 23);
            openProjectButton.TabIndex = 171;
            openProjectButton.Text = "Open an existing project";
            openProjectButton.UseVisualStyleBackColor = true;
            openProjectButton.Click += openExistingProject_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 15);
            label1.TabIndex = 172;
            label1.Text = "Project name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 15);
            label2.TabIndex = 173;
            label2.Text = "Project path";
            // 
            // changePathButton
            // 
            changePathButton.Location = new System.Drawing.Point(341, 91);
            changePathButton.Name = "changePathButton";
            changePathButton.Size = new System.Drawing.Size(75, 23);
            changePathButton.TabIndex = 174;
            changePathButton.Text = "Change";
            changePathButton.UseVisualStyleBackColor = true;
            changePathButton.Click += changePathButton_Click;
            // 
            // GenotypeProjectsWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1004, 330);
            Controls.Add(allowParallelExecutionCheckBox);
            Controls.Add(changePathButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(openProjectButton);
            Controls.Add(projectPathTextBox);
            Controls.Add(projectNameTextBox);
            Controls.Add(parallelExecutionGroupBox);
            Controls.Add(operatingModeGroupBox);
            Controls.Add(lastProjectsListView);
            Controls.Add(currentProjectInfoTextBox);
            Controls.Add(currentProjectInfoLabel);
            Controls.Add(doneButton);
            Controls.Add(lastProjectsLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "GenotypeProjectsWindow";
            Text = "Genotype projects";
            Load += GenotypeProjectsWindow_Load;
            ((System.ComponentModel.ISupportInitialize)currentProjectInfoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectInformationModelBindingSource).EndInit();
            operatingModeGroupBox.ResumeLayout(false);
            operatingModeGroupBox.PerformLayout();
            parallelExecutionGroupBox.ResumeLayout(false);
            parallelExecutionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)coresNumTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lastProjectsLabel;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label currentProjectInfoLabel;
        private System.Windows.Forms.TextBox currentProjectInfoTextBox;
        private System.Windows.Forms.ListView lastProjectsListView;
        private CheckedListBox programsCheckedListBox;
        private Label usingProgramsLabel;
        private GroupBox operatingModeGroupBox;
        private BindingSource currentProjectInfoBindingSource;
        private CheckBox allowParallelExecutionCheckBox;
        private GroupBox parallelExecutionGroupBox;
        private Label coresLabel;
        private Label coresNumLabel;
        private TrackBar coresNumTrackBar;
        private RadioButton selectCoresRadioButton;
        private RadioButton allCoresRadioButton;
        private BindingSource projectInformationModelBindingSource;
        private TextBox projectNameTextBox;
        private TextBox projectPathTextBox;
        private Button openProjectButton;
        private Label label1;
        private Label label2;
        private Button changePathButton;
    }
}