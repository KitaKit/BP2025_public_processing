
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GenotypeApp.Additional_programs_logic.Structure_Harvester
{
    public static class HarvesterChartForm
    {
        private static void InitChartContextMenu(Chart ch, SeriesChartType[] supportedTypes = null)
        {
            var cms = new ContextMenuStrip();

            var resetZoom = new ToolStripMenuItem("Reset zoom");
            resetZoom.Click += (s, e) =>
            {
                var area = ch.ChartAreas[0];
                area.AxisX.ScaleView.ZoomReset();
                area.AxisY.ScaleView.ZoomReset();
                ch.Refresh();
            };
            cms.Items.Add(resetZoom);

            SeriesChartType[] seriesType = supportedTypes
                ?? (SeriesChartType[])Enum.GetValues(typeof(SeriesChartType));

            var tsLine = new ToolStripMenuItem("Line type");
            foreach (var t in seriesType)
            {
                var chartType = t;
                var item = new ToolStripMenuItem(chartType.ToString());
                item.Click += (s, e) =>
                {
                    ch.Series.Last().ChartType = chartType;
                    ch.ChartAreas[0].RecalculateAxesScale();
                    ch.Refresh();
                };
                tsLine.DropDownItems.Add(item);
            }
            cms.Items.Add(tsLine);

            var tsMarker = new ToolStripMenuItem("Marker style");
            foreach (MarkerStyle m in Enum.GetValues(typeof(MarkerStyle)))
            {
                var marker = m; 
                var item = new ToolStripMenuItem(marker.ToString());
                item.Click += (s, e) =>
                {
                    ch.Series.Last().MarkerStyle = marker;
                    ch.Refresh();
                };
                tsMarker.DropDownItems.Add(item);
            }
            cms.Items.Add(tsMarker);

            cms.Opening += (s, e) =>
            {
                var main = ch.Series.Last();
                foreach (ToolStripMenuItem item in tsLine.DropDownItems)
                    item.Checked = item.Text == main.ChartType.ToString();
                foreach (ToolStripMenuItem item in tsMarker.DropDownItems)
                    item.Checked = item.Text == main.MarkerStyle.ToString();
            };

            ch.ContextMenuStrip = cms;
        }

        public static void LoadCharts(Chart meanCh, Chart prime, Chart doublePrime, Chart deltaCh)
        {
            LoadEvanno(out double[] k, out double[] mean, out double[] sd,
                       out double[] ln1, out double[] ln2, out double[] delta);

            BuildMeanLnPChart(meanCh, k, mean, sd);
            BuildLineChart(prime, k, ln1, "Ln'(K)", Color.MediumSeaGreen);
            BuildLineChart(doublePrime, k, ln2, "|Ln''(K)|", Color.OrangeRed);
            BuildDeltaKChart(deltaCh, k, delta);
        }

        private static void BuildMeanLnPChart(Chart ch, double[] k, double[] mean, double[] sd)
        {
            ch.TabStop = true;
            if (ch.ChartAreas.Count == 0)
                ch.ChartAreas.Add(new ChartArea());

            ch.Titles.Clear();
            ch.Series.Clear();

            var area = ch.ChartAreas[0];

            double xMin = k.Min(), xMax = k.Max();
            var lows = new List<double>();
            var highs = new List<double>();
            for (int i = 0; i < mean.Length; i++)
            {
                if (double.IsNaN(mean[i])) continue;
                double e = double.IsNaN(sd[i]) ? 0 : sd[i];
                lows.Add(mean[i] - e);
                highs.Add(mean[i] + e);
            }
            double yMin = lows.Min(), yMax = highs.Max();

            double padX = (xMax - xMin) * 0.05;
            double padY = (yMax - yMin) * 0.05;

            var dummy = new Series
            {
                ChartType = SeriesChartType.Point,
                MarkerSize = 0,
                Color = Color.Transparent,
                Enabled = false,
                IsVisibleInLegend = false
            };

            dummy.Points.AddXY(xMin - padX, yMin);
            dummy.Points.AddXY(xMax + padX, yMin);

            dummy.Points.AddXY(xMin, yMin - padY);
            dummy.Points.AddXY(xMin, yMax + padY);

            ch.Series.Add(dummy);

            area.AxisX.Title = "K";
            area.AxisY.Title = "Mean LnP(K)";
            area.CursorX.IsUserEnabled = area.CursorX.IsUserSelectionEnabled =
            area.CursorY.IsUserEnabled = area.CursorY.IsUserSelectionEnabled = true;
            area.AxisX.ScaleView.Zoomable = area.AxisY.ScaleView.Zoomable = true;
            area.CursorX.AutoScroll = area.CursorY.AutoScroll = true;
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.IsPositionedInside = true;
            area.AxisX.ScrollBar.Size = 10;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            area.AxisX.LabelStyle.Format = "F0";
            area.AxisY.LabelStyle.Format = "F0";

            area.CursorX.LineColor = Color.Transparent;
            area.CursorY.LineColor = Color.Transparent;

            var errSeries = new Series
            {
                ChartType = SeriesChartType.ErrorBar,
                Color = Color.DimGray,
                BorderWidth = 2,
                YValuesPerPoint = 3
            };
            errSeries["ErrorBarStyle"] = "Both";
            errSeries["ErrorBarCenterMarkerStyle"] = "None";
            errSeries["PointWidth"] = "0.1";

            var meanSeries = new Series
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                Color = Color.MediumBlue
            };

            for (int i = 0; i < k.Length; i++)
            {
                if (double.IsNaN(mean[i])) continue;
                double e = double.IsNaN(sd[i]) ? 0 : sd[i];

                errSeries.Points.AddXY(k[i], mean[i], mean[i] - e, mean[i] + e);

                int idx = meanSeries.Points.AddXY(k[i], mean[i]);
                meanSeries.Points[idx].ToolTip =
                    $"K = {k[i]:F0}, Mean LnP(K) = {mean[i]:F2}, SD = ±{e:F2}";
            }

            ch.Series.Add(errSeries);
            ch.Series.Add(meanSeries);

            area.RecalculateAxesScale();

            var supportedSeriesTypes = new[]
            {
                SeriesChartType.Line,
                SeriesChartType.Spline,
                SeriesChartType.StepLine,
                SeriesChartType.FastLine,
                SeriesChartType.Column,
                SeriesChartType.StackedColumn,
                SeriesChartType.StackedColumn100,
                SeriesChartType.Area,
                SeriesChartType.SplineArea,
                SeriesChartType.StackedArea,
                SeriesChartType.StackedArea100,
                SeriesChartType.Stock,
                SeriesChartType.Candlestick,
                SeriesChartType.Range,
                SeriesChartType.SplineRange,
                SeriesChartType.RangeColumn,
                SeriesChartType.ErrorBar,
                SeriesChartType.BoxPlot
            };

            InitChartContextMenu(ch, supportedSeriesTypes);
            ch.Refresh();
        }
        private static void BuildLineChart(Chart ch, double[] k, double[] values, string title, Color clr)
        {
            ch.TabStop = true;
            if (ch.ChartAreas.Count == 0)
                ch.ChartAreas.Add(new ChartArea());

            ch.Titles.Clear();
            ch.Series.Clear();

            var area = ch.ChartAreas[0];

            area.AxisX.Minimum = k.Min();
            area.AxisX.Maximum = k.Max();

            var yData = values.Where(v => !double.IsNaN(v)).ToArray();
            if (yData.Length > 0)
            {
                area.AxisY.Minimum = yData.Min();
                area.AxisY.Maximum = yData.Max();
            }

            double xMin = k.Min(), xMax = k.Max();
            double yMin = yData.Min(), yMax = yData.Max();
            double padX = (xMax - xMin) * 0.05;
            double padY = (yMax - yMin) * 0.05;
            var dummy = new Series
            {
                ChartType = SeriesChartType.Point,
                MarkerSize = 0,
                Color = Color.Transparent,
                Enabled = false,
                IsVisibleInLegend = false
            };
            dummy.Points.AddXY(xMin - padX, yMin);
            dummy.Points.AddXY(xMax + padX, yMin);
            dummy.Points.AddXY(xMin, yMin - padY);
            dummy.Points.AddXY(xMin, yMax + padY);
            ch.Series.Add(dummy);

            ch.Titles.Add(title);
            area.AxisX.Title = "K";
            area.AxisY.Title = title;

            ch.ChartAreas[0].CursorX.IsUserEnabled = true;
            ch.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            ch.ChartAreas[0].CursorY.IsUserEnabled = true;
            ch.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            ch.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ch.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            ch.ChartAreas[0].CursorX.AutoScroll = true;
            ch.ChartAreas[0].CursorY.AutoScroll = true;

            area.CursorX.LineColor = Color.Transparent;
            area.CursorY.LineColor = Color.Transparent;

            ch.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            ch.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            ch.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            ch.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            area.AxisX.LabelStyle.Format = "F0";
            area.AxisY.LabelStyle.Format = "F0";

            var s = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = clr,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                ToolTip = $"K = #VALX, {title} = #VALY"
            };
            ch.Series.Add(s);

            for (int i = 0; i < k.Length; i++)
                if (!double.IsNaN(values[i]))
                    s.Points.AddXY(k[i], values[i]);

            area.RecalculateAxesScale();
            InitChartContextMenu(ch);
            ch.Refresh();
        }

        private static void BuildDeltaKChart(Chart ch, double[] k, double[] delta)
        {
            ch.TabStop = true;

            if (ch.ChartAreas.Count == 0)
                ch.ChartAreas.Add(new ChartArea());

            ch.Titles.Clear();
            ch.Series.Clear();

            ch.Titles.Add("ΔK");
            ch.ChartAreas[0].AxisX.Title = "K";
            ch.ChartAreas[0].AxisY.Title = "ΔK";

            ch.ChartAreas[0].CursorX.IsUserEnabled = true;
            ch.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            ch.ChartAreas[0].CursorY.IsUserEnabled = true;
            ch.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            var area = ch.ChartAreas[0];
            area.AxisX.Minimum = k.Min();
            area.AxisX.Maximum = k.Max();
            double yMin = delta.Where(v => !double.IsNaN(v)).Min();
            double yMax = delta.Where(v => !double.IsNaN(v)).Max();
            area.AxisY.Minimum = yMin;
            area.AxisY.Maximum = yMax;

            double xMin = k.Min(), xMax = k.Max();
            double padX = (xMax - xMin) * 0.05;
            double padY = (yMax - yMin) * 0.05;
            var dummy = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Transparent,
                Enabled = false,
                IsVisibleInLegend = false
            };
            dummy.Points.AddXY(xMin - padX, yMin);
            dummy.Points.AddXY(xMax + padX, yMin);
            dummy.Points.AddXY(xMin, yMin - padY);
            dummy.Points.AddXY(xMin, yMax + padY);
            ch.Series.Add(dummy);

            ch.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ch.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            ch.ChartAreas[0].CursorX.AutoScroll = true;
            ch.ChartAreas[0].CursorY.AutoScroll = true;

            ch.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            ch.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            ch.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            ch.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            area.CursorX.LineColor = Color.Transparent;
            area.CursorY.LineColor = Color.Transparent;

            area.AxisX.LabelStyle.Format = "F0";
            area.AxisY.LabelStyle.Format = "F0";

            var s = new Series
            {
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                BorderWidth = 2,
                ToolTip = "K = #VALX, ΔK = #VALY"
            };
            ch.Series.Add(s);

            for (int i = 0; i < k.Length; i++)
                if (!double.IsNaN(delta[i]))
                    s.Points.AddXY(k[i], delta[i]);

            area.RecalculateAxesScale();
            InitChartContextMenu(ch);
            ch.Refresh();
        }

        private static double ParseOrNaN(string s)
            => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double v) ? v : double.NaN;

        private static void LoadEvanno(out double[] k, out double[] mean, out double[] sd,
                                 out double[] ln1, out double[] ln2, out double[] delta)
        {
            string evannoPath = Path.Combine(StructureHarvesterConfigurationParametersManager.CurrentParameterSet.OutputFolderPath, "evanno.txt");
            if (!File.Exists(evannoPath))
                throw new FileNotFoundException("Evanno file not found", evannoPath);

            var ks = new List<double>();
            var m = new List<double>();
            var s = new List<double>();
            var l1 = new List<double>();
            var l2 = new List<double>();
            var dk = new List<double>();

            string[] lines = File.ReadAllLines(evannoPath)
                .Where(l => !string.IsNullOrWhiteSpace(l) && !l.StartsWith("#"))
                .ToArray();

            bool hasHeader = lines[0].TrimStart().StartsWith("K", StringComparison.OrdinalIgnoreCase);
            foreach (string line in lines.Skip(hasHeader ? 1 : 0))
            {
                string[] parts = line.Split(new[] { '\t', ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 7) continue; // K Reps Mean SD Ln' Ln" ΔK

                ks.Add(ParseOrNaN(parts[0]));
                m.Add(ParseOrNaN(parts[2]));
                s.Add(ParseOrNaN(parts[3]));
                l1.Add(ParseOrNaN(parts[4]));
                l2.Add(ParseOrNaN(parts[5]));
                dk.Add(ParseOrNaN(parts[6]));
            }

            k = ks.ToArray();
            mean = m.ToArray();
            sd = s.ToArray();
            ln1 = l1.ToArray();
            ln2 = l2.ToArray();
            delta = dk.ToArray();
        }
    }
}