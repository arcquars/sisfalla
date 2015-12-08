using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCLabelText), "CNDCLabeltext")]
    public partial class CNDCLabelText : UserControl,IElementoBD
    {
        
        public CNDCLabelText()
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
    }
}
