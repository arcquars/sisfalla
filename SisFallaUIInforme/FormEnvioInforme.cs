using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using ModeloSisFalla;
using OraDalSisFalla;
using CNDC.Dominios;
using CNDC.ExceptionHandlerLib;
using SisFallaEmailLib;
using System.IO;
using MenuQuantum;
using CNDC.Pistas;
using System.Diagnostics;
using repSisfalla;
using System.Text.RegularExpressions;
using System.Globalization;
using CNDC.UtilesComunes;

 
namespace SISFALLA
{
    public partial class FormEnvioInforme : BaseForm
    {
        private Controles.CNDCToolStrip cndcToolStrip1;
        private ToolStripButton _btnEnviar;
        private Controles.CNDCTextBox _txtContenido;
        private Controles.CNDCTextBox _txtAsunto;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtPara;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCListBox _cmbAdjuntos;
        private Controles.CNDCLabel cndcLabel4;
        private ToolStripButton _btnCancelar;
        private ErrorProvider errorProvider;
        private IContainer components;
        private List<string> _archivosAdjuntos;
        private List<string> _destinosNoEnviados;
        private ResultadoEnvioEmail _resultadoEnvio;

        public FormEnvioInforme()
        {
            InitializeComponent();
            _archivosAdjuntos = new List<string>();
            Resultado = ResultadoEnvioEmail.EnvioCanceladoPorUs;
            this.Text = "Envio de correo";
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnEnviar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._txtContenido = new Controles.CNDCTextBox();
            this._txtAsunto = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtPara = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._cmbAdjuntos = new Controles.CNDCListBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEnviar,
            this._btnCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(542, 25);
            this.cndcToolStrip1.TabIndex = 5;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnEnviar
            // 
            this._btnEnviar.Image = global::SisFallaUIInforme.Properties.Resources.email_go;
            this._btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(57, 22);
            this._btnEnviar.Text = "Enviar";
            this._btnEnviar.Click += new System.EventHandler(this._btnEnviar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _txtContenido
            // 
            this._txtContenido.EnterComoTab = false;
            this._txtContenido.Etiqueta = null;
            this._txtContenido.Location = new System.Drawing.Point(2, 130);
            this._txtContenido.Multiline = true;
            this._txtContenido.Name = "_txtContenido";
            this._txtContenido.Size = new System.Drawing.Size(530, 78);
            this._txtContenido.TabIndex = 9;
            this._txtContenido.TablaCampoBD = null;
            // 
            // _txtAsunto
            // 
            this._txtAsunto.EnterComoTab = false;
            this._txtAsunto.Etiqueta = null;
            this._txtAsunto.Location = new System.Drawing.Point(2, 82);
            this._txtAsunto.Name = "_txtAsunto";
            this._txtAsunto.Size = new System.Drawing.Size(530, 20);
            this._txtAsunto.TabIndex = 8;
            this._txtAsunto.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(2, 114);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(68, 13);
            this.cndcLabel2.TabIndex = 7;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Contenido:";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(2, 66);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(50, 13);
            this.cndcLabel1.TabIndex = 6;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Asunto:";
            // 
            // _txtPara
            // 
            this._txtPara.EnterComoTab = false;
            this._txtPara.Etiqueta = null;
            this._txtPara.Location = new System.Drawing.Point(0, 43);
            this._txtPara.Name = "_txtPara";
            this._txtPara.Size = new System.Drawing.Size(530, 20);
            this._txtPara.TabIndex = 11;
            this._txtPara.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel3.Location = new System.Drawing.Point(0, 27);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(37, 13);
            this.cndcLabel3.TabIndex = 10;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Para:";
            // 
            // _cmbAdjuntos
            // 
            this._cmbAdjuntos.FormattingEnabled = true;
            this._cmbAdjuntos.Location = new System.Drawing.Point(5, 227);
            this._cmbAdjuntos.Name = "_cmbAdjuntos";
            this._cmbAdjuntos.Size = new System.Drawing.Size(525, 95);
            this._cmbAdjuntos.TabIndex = 12;
            this._cmbAdjuntos.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel4.Location = new System.Drawing.Point(2, 211);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(60, 13);
            this.cndcLabel4.TabIndex = 13;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Adjuntos:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // FormEnvioInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(542, 331);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._cmbAdjuntos);
            this.Controls.Add(this._txtPara);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtContenido);
            this.Controls.Add(this._txtAsunto);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcToolStrip1);
            this.Name = "FormEnvioInforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public List<string> Para
        {
            set
            {
                _txtPara.Text = UtilesString.ToString(value, ";");
            }
            get
            {
                return UtilesString.ToListString(_txtPara.Text, ';');
            }
        }

        public List<string> DestinosNoEnviados
        { get { return _destinosNoEnviados; } }

        public string Asunto
        {
            get { return _txtAsunto.Text; }
            set
            {
                _txtAsunto.Text = value;
                _txtAsunto.ReadOnly = true;
            }
        }

        public string Cuerpo
        {
            get { return _txtContenido.Text; }
            set
            {
                _txtContenido.Text = value;
                _txtContenido.ReadOnly = true;
            }
        }

        public List<string> Adjunto
        {
            set
            {
                _archivosAdjuntos = value;
                _cmbAdjuntos.Items.Clear();
                foreach (string s in _archivosAdjuntos)
                {
                    _cmbAdjuntos.Items.Add(UtilesArchivo.GetFileName(s));
                }
            }
        }
        
        public ResultadoEnvioEmail Resultado
        {
            get { return _resultadoEnvio; }
            set
            {
                _resultadoEnvio = value;
            }
        }

        private bool Validar()
        {
            bool rtn = true;
            errorProvider.Clear();
            string errorMensaje = string.Empty;
            string correos = _txtPara.Text.Replace(',', ';');
            string[] emails = correos.Split(';');

            if (correos.Trim().Length == 0)
            {
                errorMensaje = MessageMgr.Instance.GetMessage("EMAILS_OBLIGATORIO");
            }
            else
            {
                EmailValidator validador = new EmailValidator();
                string detalleNoValidos = string.Empty;
                foreach (string email in emails)
                {
                    if (!validador.IsValidEmail(email.Trim()))
                    {
                        detalleNoValidos += email + ";";
                    }
                }
                if (detalleNoValidos.Length > 0)
                {
                    string emailsNoValidosMsg = MessageMgr.Instance.GetMessage("EMAIL_NO_VALIDO");
                    errorMensaje += emailsNoValidosMsg + detalleNoValidos;
                }
            }

            if (errorMensaje.Length > 0)
            {
                rtn = false;
                errorProvider.SetError(_txtPara, errorMensaje);
            }
            return rtn;
        }

        private void _btnEnviar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void Enviar()
        {
            EnviadorEmail email = new EnviadorEmail();

            ResultadoEnvio resEnvioEmail = email.Enviar(Asunto, Cuerpo, Para, _archivosAdjuntos);
            if (resEnvioEmail == null)
            {
                _resultadoEnvio = ResultadoEnvioEmail.EnviadoConError;
            }
            else
            {
                _destinosNoEnviados = resEnvioEmail.NoEnviados;
                if (!string.IsNullOrEmpty(resEnvioEmail.Msg))
                {
                    MessageBox.Show(resEnvioEmail.Msg);
                }
                else if (resEnvioEmail.NoEnviados == null)
                {
                    _resultadoEnvio = ResultadoEnvioEmail.NoEnviado;
                }
                else if (resEnvioEmail.NoEnviados.Count == 0)
                {
                    _resultadoEnvio = ResultadoEnvioEmail.Enviado;
                }
                else
                {
                    _resultadoEnvio = ResultadoEnvioEmail.EnviadoConError;
                }
            }
        }
    }

    public class EmailValidator
    {
        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }

}