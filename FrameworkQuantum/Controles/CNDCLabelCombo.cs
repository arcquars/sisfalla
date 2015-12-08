using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCLabelCombo), "CNDCLabelcombo")]
    public partial class CNDCLabelCombo : UserControl, IElementoBD
    {
        public CNDCLabelCombo()
        {
            InitializeComponent();
        }

        string _helpField;

        public string TablaCampoBD
        {
            get
            {
                return _helpField;
            }
            set
            {
                _helpField = value;
            }
        }

        public string LabelText
        {
            get { return _lbl.Text; }
            set { _lbl.Text = value; }
        }

        public ComboBox ComboBox
        { get { return _cmb; } }
    }
}
