using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCToolStrip), "CNDCToolStrip")]
    public class CNDCToolStrip : ToolStrip,IElementoBD
    {
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
