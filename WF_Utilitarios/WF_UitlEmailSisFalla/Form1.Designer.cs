namespace WF_UtilEmailSisFalla
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._btnIngresar = new System.Windows.Forms.Button();
            this._txtContrasena = new System.Windows.Forms.TextBox();
            this._pnlLogin = new System.Windows.Forms.Panel();
            this._lblMensaje = new System.Windows.Forms.Label();
            this._pnlEnvio = new System.Windows.Forms.Panel();
            this._lblEnviados = new System.Windows.Forms.Label();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._btnAdicionarEmail = new System.Windows.Forms.Button();
            this._btnEnviar = new System.Windows.Forms.Button();
            this._dgvEnvios = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this._cmbSmtpDeliveryMethod = new System.Windows.Forms.ComboBox();
            this._pnlLogin.SuspendLayout();
            this._pnlEnvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEnvios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Location = new System.Drawing.Point(248, 11);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(100, 20);
            this._txtUsuario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // _btnIngresar
            // 
            this._btnIngresar.Location = new System.Drawing.Point(257, 59);
            this._btnIngresar.Name = "_btnIngresar";
            this._btnIngresar.Size = new System.Drawing.Size(75, 23);
            this._btnIngresar.TabIndex = 4;
            this._btnIngresar.Text = "Ingresar";
            this._btnIngresar.UseVisualStyleBackColor = true;
            this._btnIngresar.Click += new System.EventHandler(this._btnIngresar_Click);
            // 
            // _txtContrasena
            // 
            this._txtContrasena.Location = new System.Drawing.Point(248, 33);
            this._txtContrasena.Name = "_txtContrasena";
            this._txtContrasena.PasswordChar = '*';
            this._txtContrasena.Size = new System.Drawing.Size(100, 20);
            this._txtContrasena.TabIndex = 3;
            // 
            // _pnlLogin
            // 
            this._pnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlLogin.Controls.Add(this._lblMensaje);
            this._pnlLogin.Controls.Add(this._btnIngresar);
            this._pnlLogin.Controls.Add(this._txtContrasena);
            this._pnlLogin.Controls.Add(this.label1);
            this._pnlLogin.Controls.Add(this._txtUsuario);
            this._pnlLogin.Controls.Add(this.label2);
            this._pnlLogin.Location = new System.Drawing.Point(8, 8);
            this._pnlLogin.Name = "_pnlLogin";
            this._pnlLogin.Size = new System.Drawing.Size(614, 134);
            this._pnlLogin.TabIndex = 0;
            // 
            // _lblMensaje
            // 
            this._lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblMensaje.ForeColor = System.Drawing.Color.MidnightBlue;
            this._lblMensaje.Location = new System.Drawing.Point(0, 109);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(612, 23);
            this._lblMensaje.TabIndex = 5;
            this._lblMensaje.Text = "...";
            this._lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _pnlEnvio
            // 
            this._pnlEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlEnvio.Controls.Add(this._cmbSmtpDeliveryMethod);
            this._pnlEnvio.Controls.Add(this.label3);
            this._pnlEnvio.Controls.Add(this._lblEnviados);
            this._pnlEnvio.Controls.Add(this._txtEmail);
            this._pnlEnvio.Controls.Add(this._btnAdicionarEmail);
            this._pnlEnvio.Controls.Add(this._btnEnviar);
            this._pnlEnvio.Controls.Add(this._dgvEnvios);
            this._pnlEnvio.Enabled = false;
            this._pnlEnvio.Location = new System.Drawing.Point(9, 147);
            this._pnlEnvio.Name = "_pnlEnvio";
            this._pnlEnvio.Size = new System.Drawing.Size(613, 190);
            this._pnlEnvio.TabIndex = 1;
            // 
            // _lblEnviados
            // 
            this._lblEnviados.Location = new System.Drawing.Point(444, 158);
            this._lblEnviados.Name = "_lblEnviados";
            this._lblEnviados.Size = new System.Drawing.Size(151, 23);
            this._lblEnviados.TabIndex = 7;
            this._lblEnviados.Text = "[..]";
            // 
            // _txtEmail
            // 
            this._txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEmail.Location = new System.Drawing.Point(444, 34);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(151, 20);
            this._txtEmail.TabIndex = 6;
            // 
            // _btnAdicionarEmail
            // 
            this._btnAdicionarEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdicionarEmail.Location = new System.Drawing.Point(444, 56);
            this._btnAdicionarEmail.Name = "_btnAdicionarEmail";
            this._btnAdicionarEmail.Size = new System.Drawing.Size(151, 23);
            this._btnAdicionarEmail.TabIndex = 1;
            this._btnAdicionarEmail.Text = "Adicionar Destinatario";
            this._btnAdicionarEmail.UseVisualStyleBackColor = true;
            this._btnAdicionarEmail.Click += new System.EventHandler(this._btnAdicionarEmail_Click);
            // 
            // _btnEnviar
            // 
            this._btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEnviar.Location = new System.Drawing.Point(444, 132);
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(151, 23);
            this._btnEnviar.TabIndex = 2;
            this._btnEnviar.Text = "Enviar";
            this._btnEnviar.UseVisualStyleBackColor = true;
            this._btnEnviar.Click += new System.EventHandler(this._btnEnviar_Click);
            // 
            // _dgvEnvios
            // 
            this._dgvEnvios.AllowUserToAddRows = false;
            this._dgvEnvios.AllowUserToDeleteRows = false;
            this._dgvEnvios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEnvios.Location = new System.Drawing.Point(3, 28);
            this._dgvEnvios.Name = "_dgvEnvios";
            this._dgvEnvios.ReadOnly = true;
            this._dgvEnvios.Size = new System.Drawing.Size(417, 156);
            this._dgvEnvios.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SmtpDeliveryMethod:";
            // 
            // _cmbSmtpDeliveryMethod
            // 
            this._cmbSmtpDeliveryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbSmtpDeliveryMethod.FormattingEnabled = true;
            this._cmbSmtpDeliveryMethod.Location = new System.Drawing.Point(146, 3);
            this._cmbSmtpDeliveryMethod.Name = "_cmbSmtpDeliveryMethod";
            this._cmbSmtpDeliveryMethod.Size = new System.Drawing.Size(274, 21);
            this._cmbSmtpDeliveryMethod.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 350);
            this.Controls.Add(this._pnlEnvio);
            this.Controls.Add(this._pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Utilitario - Envío Correo Electrónico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this._pnlLogin.ResumeLayout(false);
            this._pnlLogin.PerformLayout();
            this._pnlEnvio.ResumeLayout(false);
            this._pnlEnvio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEnvios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnIngresar;
        private System.Windows.Forms.TextBox _txtContrasena;
        private System.Windows.Forms.Panel _pnlLogin;
        private System.Windows.Forms.Label _lblMensaje;
        private System.Windows.Forms.Panel _pnlEnvio;
        private System.Windows.Forms.Button _btnAdicionarEmail;
        private System.Windows.Forms.Button _btnEnviar;
        private System.Windows.Forms.DataGridView _dgvEnvios;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.Label _lblEnviados;
        private System.Windows.Forms.ComboBox _cmbSmtpDeliveryMethod;
        private System.Windows.Forms.Label label3;
    }
}

