using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GenotypeApp.Additional_programs_logic.Structure;
using GenotypeApp.Interface_elements_extensions;

namespace GenotypeApp
{
    public partial class LoadStructureDataFileWindow : Form
    {
        private readonly string[] _rowParamNames =
            {
                "MARKERNAMES",
                "RECESSIVEALLELES",
                "MAPDISTANCES",
                "PHASEINFO",
                "NOTAMBIGUOUS"
            };

        private readonly string[] _colParamNames =
            {
                "LABEL",
                "POPDATA",
                "POPFLAG",
                "LOCDATA",
                "PHENOTYPE",
                "EXTRACOLS"
            };

        private string[] _originalColHeaders;

        private int lastCountTrueRows = 0;
        private int lastPrefixCount = 0;
        private int lastExtraCount = 0;

        public LoadStructureDataFileWindow()
        {
            InitializeComponent();
        }

        private void LoadStructureDataFileWindow_Load(object sender, EventArgs e)
        {
            structureMainparamsBindingSource.DataSource = StructureParametersModel.Instance;
            StructureParametersModel.Instance.mainparams.PropertyChanged += MainParams_PropertyChanged;
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "Choose input data file for Structure...";


            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                StructureStartupPreparationService.OriginalDataFilePath = fileDialog.FileName;
                dataFileNameTextBox.Text = fileDialog.FileName;
                mainGroupBox.Enabled = true;

                try
                {
                    structureInputDataDataGridView.LoadDataFile(fileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _originalColHeaders = structureInputDataDataGridView.Columns
                   .Cast<DataGridViewColumn>()
                   .Select(c => c.HeaderText)
                   .ToArray();

                structureInputDataDataGridView.RowHeadersVisible = true;

                RefreshRowHighlights();
                RefreshColumnHighlights();

                var mp = StructureParametersModel.Instance.mainparams;

                try
                {
                    mp.PREDICTED_LABEL = StructureInputDataPredictor.DetectLabel(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                    mp.PREDICTED_POPDATA = StructureInputDataPredictor.DetectPopData(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));

                    if (mp.PREDICTED_LABEL)
                    {
                        mp.PREDICTED_ONEROWPERIND = StructureInputDataPredictor.DetectOneRowPerInd(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_POPFLAG = StructureInputDataPredictor.DetectPopFlag(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_LOCDATA = StructureInputDataPredictor.DetectLocData(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_PHENOTYPE = StructureInputDataPredictor.DetectPhenotype(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_NUMINDS = StructureInputDataPredictor.DetectNumInds(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        (mp.PREDICTED_EXTRACOLS, mp.PREDICTED_NUMLOCI) = StructureInputDataPredictor.DetectExtraColsAndNumLoci(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        StructureInputDataPredictor.DetectAdditionalRows(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_MISSING = StructureInputDataPredictor.DetectMissingCandidates(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                        mp.PREDICTED_PLOIDY = StructureInputDataPredictor.DetectPloidy(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void lociNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var mp = StructureParametersModel.Instance.mainparams;

            if (!string.IsNullOrWhiteSpace(StructureStartupPreparationService.OriginalDataFilePath) && lociNumericUpDown.Value != 0 && ploidyNumericUpDown.Value != 0 && !mp.PREDICTED_LABEL)
            {
                mp.PREDICTED_ONEROWPERIND = StructureInputDataPredictor.DetectOneRowPerInd(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_POPFLAG = StructureInputDataPredictor.DetectPopFlag(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_LOCDATA = StructureInputDataPredictor.DetectLocData(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_PHENOTYPE = StructureInputDataPredictor.DetectPhenotype(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_NUMINDS = StructureInputDataPredictor.DetectNumInds(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                (_, mp.PREDICTED_EXTRACOLS) = StructureInputDataPredictor.DetectExtraColsAndNumLoci(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                StructureInputDataPredictor.DetectAdditionalRows(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_MISSING = StructureInputDataPredictor.DetectMissingCandidates(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));
                mp.PREDICTED_NUMLOCI = (int)lociNumericUpDown.Value;
                mp.PREDICTED_PLOIDY = (int)ploidyNumericUpDown.Value;
            }
        }

        private void ploidyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var mp = StructureParametersModel.Instance.mainparams;

            if (!string.IsNullOrWhiteSpace(StructureStartupPreparationService.OriginalDataFilePath) && lociNumericUpDown.Value != 0 && ploidyNumericUpDown.Value != 0 && !mp.PREDICTED_LABEL)
            {
                mp.PREDICTED_ONEROWPERIND = StructureInputDataPredictor.DetectOneRowPerInd(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_POPFLAG = StructureInputDataPredictor.DetectPopFlag(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_LOCDATA = StructureInputDataPredictor.DetectLocData(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_PHENOTYPE = StructureInputDataPredictor.DetectPhenotype(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_NUMINDS = StructureInputDataPredictor.DetectNumInds(StructureStartupPreparationService.OriginalDataFilePath);
                (_, mp.PREDICTED_EXTRACOLS) = StructureInputDataPredictor.DetectExtraColsAndNumLoci(StructureStartupPreparationService.OriginalDataFilePath);
                StructureInputDataPredictor.DetectAdditionalRows(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_MISSING = StructureInputDataPredictor.DetectMissingCandidates(StructureStartupPreparationService.OriginalDataFilePath);
                mp.PREDICTED_NUMLOCI = (int)lociNumericUpDown.Value;
                mp.PREDICTED_PLOIDY = (int)ploidyNumericUpDown.Value;
            }
        }
        private void extraColumsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            extraColumsNumericUpDown.Enabled = extraColumsCheckBox.Checked;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dataFileNameTextBox.Text))
            {
                MessageBox.Show("Data file path can't be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                StructureInputDataValidator.ValidateInputData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MainParams_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.MARKERNAMES) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.RECESSIVEALLELES) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.MAPDISTANCES) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.PHASEINFO) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.NOTAMBIGUOUS))
            {
                RefreshRowHighlights();
            }

            if (e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.LABEL) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.POPDATA) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.POPFLAG) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.LOCDATA) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.PHENOTYPE) ||
                e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.EXTRACOLS))
            {
                RefreshColumnHighlights();
            }

            if (e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.MISSING))
                structureInputDataDataGridView.Invalidate();

            if (e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.NUMINDS)
                || e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.PLOIDY)
                || e.PropertyName == nameof(StructureParametersModel.Instance.mainparams.NUMLOCI))
            {
                structureInputDataDataGridView.Invalidate();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;

            base.OnFormClosing(e);
        }
        private void RefreshRowHighlights()
        {
            var mp = StructureParametersModel.Instance.mainparams;
            var flags = new[]
            {
                mp.MARKERNAMES,
                mp.RECESSIVEALLELES,
                mp.MAPDISTANCES,
                mp.PHASEINFO,
                mp.NOTAMBIGUOUS
            };

            int newPrefix = flags.Count(f => f);

            int oldPrefix = lastCountTrueRows;

            var selected = flags
                .Select((f, i) => f ? i : -1)
                .Where(i => i >= 0)
                .ToList();

            int newCount = selected.Count;
            if (newCount != lastCountTrueRows)
            {
                int start = Math.Min(lastCountTrueRows, newCount);
                int end = Math.Max(lastCountTrueRows, newCount);
                for (int r = start; r < end; r++)
                    structureInputDataDataGridView.InvalidateRow(r);
                lastCountTrueRows = newCount;
            }

            for (int r = 0; r < structureInputDataDataGridView.Rows.Count; r++)
            {
                if (r < selected.Count)
                    structureInputDataDataGridView.Rows[r].HeaderCell.Value
                        = _rowParamNames[selected[r]];
                else
                    structureInputDataDataGridView.Rows[r].HeaderCell.Value = "";
            }

            structureInputDataDataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            if (newPrefix != oldPrefix)
            {
                int start = Math.Min(oldPrefix, newPrefix);
                int end = Math.Max(oldPrefix, newPrefix);
                for (int r = start; r < end; r++)
                    structureInputDataDataGridView.InvalidateRow(r);
            }

            lastCountTrueRows = newPrefix;

            int genoRowCount = mp.NUMINDS * mp.PLOIDY;
            int oldGenoStart = oldPrefix;
            int oldGenoEnd = oldPrefix + genoRowCount;
            int newGenoStart = newPrefix;
            int newGenoEnd = newPrefix + genoRowCount;

            int rowCount2 = structureInputDataDataGridView.Rows.Count;
            int startG = Math.Min(oldGenoStart, newGenoStart);
            int endG = Math.Max(oldGenoEnd, newGenoEnd);

            startG = Math.Max(0, Math.Min(startG, rowCount2));
            endG = Math.Max(0, Math.Min(endG, rowCount2));

            for (int r = startG; r < endG; r++)
                structureInputDataDataGridView.InvalidateRow(r);
        }

        private void recessiveAllelesRowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ambiguousGenotypesCheckBox.Enabled = recessiveAllelesRowCheckBox.Checked;
        }
        private void RefreshColumnHighlights()
        {
            var mp = StructureParametersModel.Instance.mainparams;

            int oldPrefix = lastPrefixCount;
            int oldExtra = lastExtraCount;

            bool[] prefixFlags =
            {
                mp.LABEL,
                mp.POPDATA,
                mp.POPFLAG,
                mp.LOCDATA,
                mp.PHENOTYPE
            };
            var selectedPrefix = prefixFlags
                .Select((f, i) => f ? i : -1)
                .Where(i => i >= 0)
                .ToList();

            int prefixCount = selectedPrefix.Count;
            int extraCount = mp.EXTRACOLS;
            int genoCount = mp.NUMLOCI;

            lastPrefixCount = prefixCount;
            lastExtraCount = extraCount;

            int colCount = structureInputDataDataGridView.Columns.Count;

            if (prefixCount != lastPrefixCount)
            {
                int start = Math.Min(lastPrefixCount, prefixCount);
                int end = Math.Max(lastPrefixCount, prefixCount);

                start = Math.Max(0, Math.Min(start, colCount));
                end = Math.Max(0, Math.Min(end, colCount));
                for (int c = start; c < end; c++)
                    structureInputDataDataGridView.InvalidateColumn(c);
                lastPrefixCount = prefixCount;
            }

            if (extraCount != lastExtraCount)
            {
                int startOld = oldPrefix;
                int endOld = oldPrefix + oldExtra;
                int startNew = prefixCount;
                int endNew = prefixCount + extraCount;

                int startE = Math.Min(startOld, startNew);
                int endE = Math.Max(endOld, endNew);

                startE = Math.Max(0, Math.Min(startE, colCount));
                endE = Math.Max(0, Math.Min(endE, colCount));
                for (int c = startE; c < endE; c++)
                    structureInputDataDataGridView.InvalidateColumn(c);
            }

            for (int c = 0; c < colCount; c++)
            {
                if (c < prefixCount)
                {
                    int paramIdx = selectedPrefix[c];
                    structureInputDataDataGridView.Columns[c].HeaderText
                        = _colParamNames[paramIdx];
                }
                else if (c < prefixCount + extraCount)
                {
                    structureInputDataDataGridView.Columns[c].HeaderText
                        = _colParamNames[5];
                }
                else
                {
                    structureInputDataDataGridView.Columns[c].HeaderText
                        = _originalColHeaders[c];
                }
            }

            structureInputDataDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            int genCount = mp.NUMLOCI;
            int oldStart = oldPrefix + oldExtra;
            int oldEnd = oldStart + genCount;
            int newStart = prefixCount + extraCount;
            int newEnd = newStart + genCount;

            int startG = Math.Min(oldStart, newStart);
            int endG = Math.Max(oldEnd, newEnd);

            startG = Math.Max(0, Math.Min(startG, colCount));
            endG = Math.Max(0, Math.Min(endG, colCount));
            for (int c = startG; c < endG; c++)
                structureInputDataDataGridView.InvalidateColumn(c);

            int genStart = prefixCount + extraCount;
            int genEnd = genStart + genoCount;


            for (int c = genStart; c < genEnd && c < colCount; c++)
            {
                structureInputDataDataGridView.Columns[c].HeaderText =
                    $"Loc {c - genStart + 1}";
            }
        }

        private void structureInputDataDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var mp = StructureParametersModel.Instance.mainparams;

            int rowPrefixEnd = lastCountTrueRows;
            int colPrefixEnd = lastPrefixCount;

            int colExtraStart = colPrefixEnd;
            int colExtraEnd = colPrefixEnd + lastExtraCount;

            int genRowStart = rowPrefixEnd;
            int genRowEnd = genRowStart + mp.NUMINDS * mp.PLOIDY;
            int genColStart = colExtraEnd;
            int genColEnd = genColStart + mp.NUMLOCI;

            bool isPrefixRow = e.RowIndex < rowPrefixEnd;
            bool isPrefixCol = e.ColumnIndex < colPrefixEnd;
            bool isExtraCol = e.ColumnIndex >= colExtraStart && e.ColumnIndex < colExtraEnd;
            bool isGenoCell = e.RowIndex >= genRowStart && e.RowIndex < genRowEnd
                              && e.ColumnIndex >= genColStart && e.ColumnIndex < genColEnd;
            bool isMissingCell = e.RowIndex >= rowPrefixEnd
                              && e.ColumnIndex >= colExtraEnd
                              && e.FormattedValue?.ToString() == mp.MISSING.ToString();

            if (!(isPrefixRow || isPrefixCol || isExtraCol || isGenoCell || isMissingCell))
                return;

            if (isMissingCell)
            {
                using (var brush = new SolidBrush(Color.DarkKhaki))
                    e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else
            {
                e.PaintBackground(e.CellBounds, true);
            }
            e.PaintContent(e.CellBounds);

            Color penColor;
            if (isMissingCell) penColor = Color.DarkKhaki;        
            else if (isGenoCell) penColor = Color.LightSkyBlue;
            else if (isPrefixRow) penColor = Color.LightSalmon;
            else /* prefix columns */    penColor = Color.LightGreen;

            using (var pen = new Pen(penColor, 2))
            {
                var r = e.CellBounds;
                r.Width--; r.Height--;
                e.Graphics.DrawRectangle(pen, r);
            }

            e.Handled = true;
        }
    }
}






