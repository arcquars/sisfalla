using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBoxDouble), "CNDCFloatTextbox")]
    public class CNDCTextBoxDouble : CNDCTextBoxNumerico
    {
        public double Value
        {
            get { return ValorDouble; }
            set
            {
                Text = value.ToString("##.00");
            }
        }
    }
}
