using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBox), "CNDCTextbox")]
    public class CNDCTextBox : TextBox, IElementoBD, IEtiquetable,IControlCNDC
    {
        string _helpField;
        bool _enterComoTab;

        public string TablaCampoBD
        {
            get { return _helpField; }
            set { _helpField = value; }
        }

        public bool EnterComoTab
        {
            get { return _enterComoTab; }
            set { _enterComoTab = value; }
        }

        CNDCLabel _lbl;
        public CNDCLabel Etiqueta
        {
            get { return _lbl; }
            set { _lbl = value; }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (_lbl != null)
            {
                _lbl.Visible = this.Visible;
            }
        }
    }    
}
