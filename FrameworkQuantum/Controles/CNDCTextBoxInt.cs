using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBoxInt), "CNDCIntTextbox")]
    public class CNDCTextBoxInt : CNDCTextBoxNumerico
    {
        public int Value
        {
            get { return ValorInt; }
            set { this.Text = value.ToString(); }
        }
    }
}
