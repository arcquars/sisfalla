using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public class CNDCLabelFloat : Label
    {
        float _value;
        public CNDCLabelFloat()
        {
            AutoSize = false;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            Margin = new Padding(0);
        }

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Text = _value.ToString("N2");
            }
        }
    }
}
