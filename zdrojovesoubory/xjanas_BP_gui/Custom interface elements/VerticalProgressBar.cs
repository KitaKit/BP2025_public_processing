using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace xjanas_BP_gui.Custom_interface_s_elements
{
    internal class VerticalProgressBar : Control
    {
        private int _value;
        private int _maximum = 100;

        public int Value
        {
            get => _value;
            set
            {
                _value = Math.Max(0, Math.Min(value, _maximum));
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = Math.Max(1, value);
                Invalidate();
            }
        }

        public VerticalProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.MinimumSize = new Size(20, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;

            ControlPaint.DrawBorder(g, rect, Color.Black, ButtonBorderStyle.Solid);

            float percent = (float)_value / _maximum;
            int fillHeight = (int)(rect.Height * percent);
            Rectangle fillRect = new Rectangle(rect.X, rect.Bottom - fillHeight, rect.Width, fillHeight);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                g.FillRectangle(brush, fillRect);
            }
        }
    }
}
