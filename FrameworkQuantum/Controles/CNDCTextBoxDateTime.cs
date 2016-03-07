using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCTextBoxDateTime), "CNDCTextbox")]
    public class CNDCTextBoxDateTime : TextBox, IElementoBD, IEtiquetable
    {
        public CNDCTextBoxDateTime()
        {
            this.Provider = new ErrorProvider();
        }
        CNDCLabel _lbl;
        public CNDCLabel Etiqueta
        {
            get { return _lbl; }

            set { _lbl = value; }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.SelectionLength = 1;
        }
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            try
            {
                int pos = this.SelectionStart;
                string separators = "/ : - |";
                string formato = (string)Tag;
                if (pos < formato.Length)
                {
                    string val = formato.Substring(pos, 1);
                    if (separators.IndexOf(val) >= 0)
                    {
                        e.Handled = true;

                        if (e.KeyData == Keys.Left)
                        {
                            this.SelectionStart = pos - 1;
                        }
                        else
                        {
                            this.SelectionStart = pos + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: manejar excepcion
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (ValidadorFormatoFecha != null)
            {
                e.Cancel |= !ValidadorFormatoFecha.IsValido(this.Text);
            }
        }
      
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
           

            if ((ValidadorIngresoOnline != null)  )
            {
                int pos = this.SelectionStart;
                ValidadorIngresoOnline.Posicion = pos;
                 
                //     ValidadorIngresoOnline.Posicion = pos;
                if (!ValidadorIngresoOnline.IsValido(this.Text))
                {
                    //MessageBox.Show("Mensaje");
                }
                else
                {
                    int q = 0;
                }
            }          
        }

        public IValidadorControl ValidadorFormatoFecha { get; set; }
        public IValidadorControl ValidadorIngresoOnline { get; set; }

        public bool EsFechaValida()
        {
            DateTime rs;
            return DateTime.TryParseExact(Text, "dd/MM/yyyy-HH:mm:ss", ci, DateTimeStyles.None, out rs);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (_lbl != null)
            {
                _lbl.Visible = this.Visible;
            }
        }


        public DateTime Value
        {
            get
            {
                DateTime rs;

                if (!DateTime.TryParseExact(Text, "dd/MM/yyyy-HH:mm:ss", ci, DateTimeStyles.None, out rs))
                {
                    return rs;
                }
                return rs;
            }
            set
            {
                if (value != null)
                {
                    Text = value.ToString("dd/MM/yyyy-HH:mm:ss");
                }
            }
        }

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
        private string _helpField;
        private CultureInfo ci = new CultureInfo("es-bo");
        public string Mask
        {
            get;
            set;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Provider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Provider)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Provider)).EndInit();
            this.ResumeLayout(false);

        }

        public ErrorProvider Provider;
        private IContainer components;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == '\b')
            {
                e.Handled = true;
                return;
            }


            if (this.SelectionLength > 1)
            {
                e.Handled = true;
            }
            if (Text.Length == MaxLength && SelectedText == "")
            {
                SelectionLength = 1;
            }
        }
    }
    //public class CNDCTextBoxDateTime : MaskedTextBox, 
    //{
    //   
    //   

    //  

    //    public CNDCTextBoxDateTime()
    //    {
    //        this.Mask = "00/00/0000 00:00:00";
    //    }



    //   

    //
    //}    
}
