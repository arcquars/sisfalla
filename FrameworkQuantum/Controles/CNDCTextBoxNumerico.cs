using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public class CNDCTextBoxNumerico : CNDCTextBox
    {
        private int _maxDigitosEnteros;
        private int _maxDigitosDecimales;
        public bool AceptaNegativo { get; set; }
        public bool UsarFormatoNumerico { get; set; }
        public CNDCTextBoxNumerico()
        {
            TextAlign = HorizontalAlignment.Right;
            AceptaNegativo = true;
            UsarFormatoNumerico = true;
            this.Click += new EventHandler(CNDCTextBoxNumerico_Click);
        }

        void CNDCTextBoxNumerico_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        public int MaxDigitosEnteros
        {
            get { return _maxDigitosEnteros; }
            set
            {
                _maxDigitosEnteros = value;
                AplicarFormato();
            }
        }

        public int MaxDigitosDecimales
        {
            get { return _maxDigitosDecimales; }
            set
            {
                _maxDigitosDecimales = value;
                AplicarFormato();
            }
        }

        private void AplicarFormato()
        {
            Text = TextoConFormato;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                e.Handled = true;
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                //OnKeyPress(new KeyPressEventArgs(decimalSeparator[0]));
                //OnKeyDown(new KeyEventArgs(Keys.
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string groupSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
            string negativeSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                if (MaxDigitosEnteros != -1 || MaxDigitosDecimales != -1)
                {
                    int idxCursor = this.SelectionStart;
                    int idxSeparadorDecimal = Text.IndexOf(decimalSeparator);
                    if (idxSeparadorDecimal < 0 || idxCursor <= idxSeparadorDecimal)
                    {
                        if (CantDigEnteros == MaxDigitosEnteros && SelectedText.Length == 0)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (CantDigDecimales == MaxDigitosDecimales)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (keyInput.Equals(decimalSeparator) )
            {
                if (MaxDigitosDecimales == 0 || Text.Contains(keyInput))
                {
                    e.Handled = true;
                }
            }
            else if (keyInput.Equals(negativeSign) && AceptaNegativo)
            {
                if (Text.Contains(keyInput))
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Text = TextoSinFormato;
            Select(0, Text.Length);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (UsarFormatoNumerico)
            {
                Text = TextoConFormato;
            }
            else
            {
                Text = TextoSinFormato;
            }
        }

        public int CantDigEnteros
        {
            get
            {
                int resultado = 0;
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                int idxSeparadorDecimal = Text.IndexOf(decimalSeparator);
                if (idxSeparadorDecimal < 0)
                {
                    resultado = Text.Length;
                }
                else
                {
                    resultado = idxSeparadorDecimal;
                }
                return resultado;
            }
        }

        public int CantDigDecimales
        {
            get
            {
                int resultado = 0;
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                int idxSeparadorDecimal = Text.IndexOf(decimalSeparator);
                if (idxSeparadorDecimal < 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = Text.Length - 1 - idxSeparadorDecimal;
                }
                return resultado;
            }
        }

        int _valorInt;
        public int ValorInt
        {
            get {


                int val = 0;
                try
                {
                    val = int.Parse(TextoSinFormato);
                }
                catch
                { }
                return val;               
             
            }
            set
            {
                _valorInt = value;
                Text = _valorInt.ToString("N" + MaxDigitosDecimales);
            }
        }

        long _valorLong ;
        public long ValorLong
        {
            get {
                long val = 0;
                try
                {
                    val = long.Parse(TextoSinFormato);
                }
                catch
                { }
                return  val; 
            }
            set
            {
                _valorLong = value;
                Text = _valorLong.ToString("N" + MaxDigitosDecimales);
            }
        }

        float _valorFloat;
        public float ValorFloat
        {
            get { return float.Parse(TextoSinFormato); }
            set
            {
                _valorFloat = value;
                Text = _valorFloat.ToString("N" + MaxDigitosDecimales);
            }
        }

        double _valorDouble;
        public double ValorDouble
        {
            get { return double.Parse(TextoSinFormato); }
            set
            {
                _valorDouble = value;
                Text = _valorDouble.ToString("N" + MaxDigitosDecimales);
            }
        }

        decimal _valorDecimal;
        public decimal ValorDecimal
        {
            get { return decimal.Parse(TextoSinFormato); }
            set
            {
                _valorDecimal = value;
                Text = _valorDecimal.ToString("N" + MaxDigitosDecimales);
            }
        }

        public string TextoSinFormato
        {
            get
            {
                string resultado = string.Empty;
                string groupSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
                string negativeSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NegativeSign;
                if (string.IsNullOrEmpty(Text) || Text == negativeSign)
                {
                    Text = "0";
                }
                resultado = Text.Replace(groupSeparator, string.Empty);
                return resultado;
            }
        }

        public string TextoConFormato
        {
            get 
            {
                string negativeSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NegativeSign;
                string resultado = string.Empty;
                if (string.IsNullOrEmpty(Text) || Text == negativeSign)
                {
                    resultado = "0";
                }
                else
                {
                    resultado = Text;
                }

                if (MaxDigitosEnteros == 0 && MaxDigitosDecimales == 0)
                {
                    resultado = decimal.Parse(resultado).ToString();
                }
                else
                {
                    resultado = decimal.Parse(resultado).ToString("N" + MaxDigitosDecimales);
                }
                return resultado;
            }
        }
    }
}