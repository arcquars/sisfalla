using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBoxLong), "CNDCIntTextbox")]
    public class CNDCTextBoxLong : CNDCTextBoxNumerico
    {
        public long Value
        {
            get { return ValorLong; }
            set
            {
                Text = value.ToString("N0");
            }
        }
    }
}
