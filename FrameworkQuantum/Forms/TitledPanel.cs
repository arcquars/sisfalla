using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CNDC.BaseForms
{
    class TitledPanel : Panel
    {
        Label _lblText;
        GradientPanel _pnl;

        public TitledPanel()
        {
            _pnl = new GradientPanel();
            _pnl.Dock = DockStyle.Top;
            _pnl.Height = 20;
            this.Controls.Add(_pnl);

            _lblText = new Label();
            _lblText.Text = "Title";
            _lblText.AutoSize = false;
            _lblText.Dock = DockStyle.Fill;
            _lblText.BackColor = Color.Transparent;
            _lblText.TextAlign = ContentAlignment.MiddleLeft;
            _pnl.Controls.Add(_lblText);

            this.BackColor = _pnl.Color2;
        }

        public string Title
        {
            get { return _lblText.Text; }
            set { _lblText.Text = value; }
        }
    }
}
