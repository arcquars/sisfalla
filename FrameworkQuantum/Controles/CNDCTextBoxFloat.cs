using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBoxFloat), "CNDCFloatTextbox")]
    public class CNDCTextBoxFloat : CNDCTextBoxNumerico
    {

        

        public CNDCTextBoxFloat()
        {
            
        }

         
 
        float _value;
        public double ValDouble
        {
            get
            {
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                string negativeSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NegativeSign;
                double resultado = 0;
                if (string.IsNullOrEmpty(Text) || Text == decimalSeparator || Text == negativeSign)
                {
                    resultado = 0;
                }
                else
                {
                    try
                    {
                        resultado = double.Parse(Text);
                    }
                    catch (Exception)
                    {
                        resultado = 0;
                    }
                }
                return resultado;
            }
            set
            {
                _value = (float)value;
                Text = _value.ToString("N" + MaxDigitosDecimales);
            }
        }

        public float Value
        {
            get
            {
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                string negativeSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NegativeSign;
                float resultado = 0;
                if (string.IsNullOrEmpty(Text) || Text == decimalSeparator || Text == negativeSign)
                {
                    resultado = 0;
                }
                else
                {
                    try
                    {
                        resultado = float.Parse(Text);
                    }
                    catch (Exception)
                    {
                        resultado = 0;
                    }
                }
                return resultado;
            }
            set
            {
                _value = value;
                Text = _value.ToString("N" + MaxDigitosDecimales);
            }
        }


     

        
 




    }
}
