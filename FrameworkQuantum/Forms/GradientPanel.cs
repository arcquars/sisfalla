using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CNDC.BaseForms
{
    class GradientPanel : Panel
    {
        private Color _color1;
        private Color _color2;

        public GradientPanel()
        {
            _color1 = Color.FromArgb(160, 187, 214);
            _color2 = Color.FromArgb(235, 240, 245);
            _color2 = Color.FromArgb(247, 249, 251);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, _color1, _color2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            e.Graphics.DrawLine(new Pen(_color1), ClientRectangle.Left, ClientRectangle.Bottom-1, ClientRectangle.Right, ClientRectangle.Bottom-1);
        }

        public Color Color1
        { get { return _color1; } }

        public Color Color2
        { get { return _color2; } }
    }
}
