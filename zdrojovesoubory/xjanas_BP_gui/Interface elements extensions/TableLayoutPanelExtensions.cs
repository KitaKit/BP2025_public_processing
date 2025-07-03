using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace GenotypeApp.Interface_elements_extensions
{
    internal static class TableLayoutPanelExtensions
    {
        public static void SetUnactivePrograms(this TableLayoutPanel tableLayoutPanel, IReadOnlyDictionary<string, bool> programs)
        {
            ArgumentNullException.ThrowIfNull(tableLayoutPanel);
            ArgumentNullException.ThrowIfNull(programs);

            if (programs.Count == 4 && programs.Values.All(active => active == true))
                return;

            for (int row = 0; row < tableLayoutPanel.RowCount; row++)
            {
                if (tableLayoutPanel.GetControlFromPosition(0, row) is Label lbl &&
                    tableLayoutPanel.GetControlFromPosition(1, row) is ProgressBar pb)
                {
                    string processName = lbl.Text;

                    bool isActive = programs.TryGetValue(processName, out bool flag) && flag;

                    Color finalColor = isActive ? Color.Black : Color.Gray;
                    bool finalEnabled = isActive;
                    Color finalPbColor = isActive ? SystemColors.Highlight : Color.Gray;

                    lbl.ForeColor = finalColor;
                    pb.Enabled = finalEnabled;
                    pb.ForeColor = finalPbColor;
                }
            }
        }
        public static void UpdateHorizontalProgressBar(this TableLayoutPanel tableLayoutPanel, int rowIndex, int progress)
        {
            ArgumentNullException.ThrowIfNull(tableLayoutPanel);
            if (rowIndex < 0 || rowIndex >= tableLayoutPanel.RowCount)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            Control control = tableLayoutPanel.GetControlFromPosition(1, rowIndex);
            if (control is ProgressBar pb)
            {
                pb.Value = progress;
            }
        }
    }
}
