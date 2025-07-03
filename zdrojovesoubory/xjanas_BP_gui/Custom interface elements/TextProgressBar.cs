using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenotypeApp.Custom_interface_elements
{
    public class TextProgressBar : ProgressBar
    {
        public string OverlayText { get; set; } = string.Empty;

        public TextProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = ClientRectangle;

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(g, rect);
            else
                g.DrawRectangle(Pens.Gray, rect);

            rect.Inflate(-2, -2);
            if (Value > 0 && Maximum > 0)
            {
                int fillWidth = (int)(rect.Width * (Value / (double)Maximum));
                var fillRect = new Rectangle(rect.X, rect.Y, fillWidth, rect.Height);
                g.FillRectangle(Brushes.Green, fillRect);
            }

            string txt = OverlayText ?? $"{Value * 100 / Maximum}%";
            TextRenderer.DrawText(
                g,
                txt,
                Font,
                rect,
                Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
