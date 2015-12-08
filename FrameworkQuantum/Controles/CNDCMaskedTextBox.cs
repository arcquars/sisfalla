using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCMaskedTextBox), "CNDCMaskedtextbox")]
    public class CNDCMaskedTextBox : MaskedTextBox, IElementoBD, IControlCNDC
    {
        string _helpField;
        public bool EnterComoTab { get; set; }
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
