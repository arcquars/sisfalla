namespace SISFALLA
{
    partial class EnvioCorreo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._tbxServidor = new Controles.CNDCTextBox();
            this._tbxIP = new Controles.CNDCTextBox();
            this._tbxEmail = new Controles.CNDCTextBox();
            this._tbxPasswd = new Controles.CNDCTextBox();
            this._tbxPuerto = new Controles.CNDCTextBox();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this._lblEmpresa = new Controles.CNDCLabel();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this._tbxMensaje = new Controles.CNDCTextBox();
            this._chkSsl = new Controles.CNDCCheckBox();
            this._btnVerificar = new Controles.CNDCButton();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte2 = new repSisfalla.CachedplantillaReporte();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(97, 129);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(83, 15);
            this.cndcLabel2.TabIndex = 7;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Servidor SMTP  :";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel3.Location = new System.Drawing.Point(112, 161);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(69, 15);
            this.cndcLabel3.TabIndex = 8;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Direccion IP :";
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel4.Location = new System.Drawing.Point(103, 191);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(78, 15);
            this.cndcLabel4.TabIndex = 9;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Cuenta correo :";
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel5.Location = new System.Drawing.Point(116, 221);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(65, 15);
            this.cndcLabel5.TabIndex = 10;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Contraseña :";
            // 
            // _tbxServidor
            // 
            this._tbxServidor.EnterComoTab = false;
            this._tbxServidor.Etiqueta = null;
            this._tbxServidor.Location = new System.Drawing.Point(230, 129);
            this._tbxServidor.Name = "_tbxServidor";
            this._tbxServidor.Size = new System.Drawing.Size(248, 20);
            this._tbxServidor.TabIndex = 0;
            this._tbxServidor.TablaCampoBD = "P_DEF_SERVICIOENVIO.NOMBRE_URI";
            // 
            // _tbxIP
            // 
            this._tbxIP.EnterComoTab = false;
            this._tbxIP.Etiqueta = null;
            this._tbxIP.Location = new System.Drawing.Point(230, 159);
            this._tbxIP.Name = "_tbxIP";
            this._tbxIP.Size = new System.Drawing.Size(248, 20);
            this._tbxIP.TabIndex = 2;
            this._tbxIP.TablaCampoBD = "P_DEF_SERVICIOENVIO.DIRECCION_IP";
            // 
            // _tbxEmail
            // 
            this._tbxEmail.EnterComoTab = false;
            this._tbxEmail.Etiqueta = null;
            this._tbxEmail.Location = new System.Drawing.Point(230, 189);
            this._tbxEmail.Name = "_tbxEmail";
            this._tbxEmail.Size = new System.Drawing.Size(248, 20);
            this._tbxEmail.TabIndex = 4;
            this._tbxEmail.TablaCampoBD = "P_DEF_SERVICIOENVIO.NOM_CUENTA";
            // 
            // _tbxPasswd
            // 
            this._tbxPasswd.EnterComoTab = false;
            this._tbxPasswd.Etiqueta = null;
            this._tbxPasswd.Location = new System.Drawing.Point(230, 219);
            this._tbxPasswd.MaxLength = 17;
            this._tbxPasswd.Name = "_tbxPasswd";
            this._tbxPasswd.PasswordChar = '*';
            this._tbxPasswd.Size = new System.Drawing.Size(248, 20);
            this._tbxPasswd.TabIndex = 5;
            this._tbxPasswd.TablaCampoBD = "P_DEF_SERVICIOENVIO.CUENTA_PASSWD";
            // 
            // _tbxPuerto
            // 
            this._tbxPuerto.EnterComoTab = false;
            this._tbxPuerto.Etiqueta = null;
            this._tbxPuerto.Location = new System.Drawing.Point(564, 159);
            this._tbxPuerto.MaxLength = 5;
            this._tbxPuerto.Name = "_tbxPuerto";
            this._tbxPuerto.Size = new System.Drawing.Size(61, 20);
            this._tbxPuerto.TabIndex = 3;
            this._tbxPuerto.TablaCampoBD = "P_DEF_SERVICIOENVIO.NUM_PUERTO";
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel6.Location = new System.Drawing.Point(515, 161);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(43, 15);
            this.cndcLabel6.TabIndex = 15;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Puerto :";
            // 
            // _lblEmpresa
            // 
            this._lblEmpresa.AutoSize = true;
            this._lblEmpresa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa.Location = new System.Drawing.Point(227, 95);
            this._lblEmpresa.Name = "_lblEmpresa";
            this._lblEmpresa.Size = new System.Drawing.Size(0, 15);
            this._lblEmpresa.TabIndex = 17;
            this._lblEmpresa.TablaCampoBD = null;
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel7.Location = new System.Drawing.Point(118, 95);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(62, 15);
            this.cndcLabel7.TabIndex = 18;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "EMPRESA  :";
            // 
            // _tbxMensaje
            // 
            this._tbxMensaje.BackColor = System.Drawing.SystemColors.ControlLight;
            this._tbxMensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxMensaje.EnterComoTab = false;
            this._tbxMensaje.Etiqueta = null;
            this._tbxMensaje.Location = new System.Drawing.Point(0, 25);
            this._tbxMensaje.Multiline = true;
            this._tbxMensaje.Name = "_tbxMensaje";
            this._tbxMensaje.ReadOnly = true;
            this._tbxMensaje.Size = new System.Drawing.Size(678, 38);
            this._tbxMensaje.TabIndex = 19;
            this._tbxMensaje.TablaCampoBD = null;
            // 
            // _chkSsl
            // 
            this._chkSsl.AutoSize = true;
            this._chkSsl.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkSsl.Location = new System.Drawing.Point(518, 131);
            this._chkSsl.Name = "_chkSsl";
            this._chkSsl.Size = new System.Drawing.Size(83, 19);
            this._chkSsl.TabIndex = 1;
            this._chkSsl.TablaCampoBD = "P_DEF_SERVICIOENVIO.SSL_ACTIVO";
            this._chkSsl.Text = "Soporta SSL";
            this._chkSsl.UseVisualStyleBackColor = true;
            // 
            // _btnVerificar
            // 
            this._btnVerificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnVerificar.Location = new System.Drawing.Point(518, 200);
            this._btnVerificar.Name = "_btnVerificar";
            this._btnVerificar.Size = new System.Drawing.Size(116, 39);
            this._btnVerificar.TabIndex = 6;
            this._btnVerificar.TablaCampoBD = null;
            this._btnVerificar.Text = "Verificar";
            this._btnVerificar.UseVisualStyleBackColor = true;
            this._btnVerificar.Click += new System.EventHandler(this._btnVerificar_Click);
            // 
            // EnvioCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(694, 295);
            this.Controls.Add(this._btnVerificar);
            this.Controls.Add(this._chkSsl);
            this.Controls.Add(this._tbxMensaje);
            this.Controls.Add(this.cndcLabel7);
            this.Controls.Add(this._lblEmpresa);
            this.Controls.Add(this._tbxPuerto);
            this.Controls.Add(this.cndcLabel6);
            this.Controls.Add(this._tbxPasswd);
            this.Controls.Add(this._tbxEmail);
            this.Controls.Add(this._tbxIP);
            this.Controls.Add(this._tbxServidor);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this.cndcLabel2);
            this.MaximumSize = new System.Drawing.Size(700, 320);
            this.MinimumSize = new System.Drawing.Size(700, 320);
            this.Name = "EnvioCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion del Servicio de Correo";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            this.Controls.SetChildIndex(this.cndcLabel4, 0);
            this.Controls.SetChildIndex(this.cndcLabel5, 0);
            this.Controls.SetChildIndex(this._tbxServidor, 0);
            this.Controls.SetChildIndex(this._tbxIP, 0);
            this.Controls.SetChildIndex(this._tbxEmail, 0);
            this.Controls.SetChildIndex(this._tbxPasswd, 0);
            this.Controls.SetChildIndex(this.cndcLabel6, 0);
            this.Controls.SetChildIndex(this._tbxPuerto, 0);
            this.Controls.SetChildIndex(this._lblEmpresa, 0);
            this.Controls.SetChildIndex(this.cndcLabel7, 0);
            this.Controls.SetChildIndex(this._tbxMensaje, 0);
            this.Controls.SetChildIndex(this._chkSsl, 0);
            this.Controls.SetChildIndex(this._btnVerificar, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBox _tbxServidor;
        private Controles.CNDCTextBox _tbxIP;
        private Controles.CNDCTextBox _tbxEmail;
        private Controles.CNDCTextBox _tbxPasswd;
        private Controles.CNDCTextBox _tbxPuerto;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCLabel _lblEmpresa;
        private Controles.CNDCLabel cndcLabel7;
        private Controles.CNDCTextBox _tbxMensaje;
        private Controles.CNDCCheckBox _chkSsl;
        private Controles.CNDCButton _btnVerificar;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte2;
    }
}