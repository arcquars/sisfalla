namespace QuantumUI
{
    partial class FormIngreso
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
            this.cndcLabelUsuario = new Controles.CNDCLabel();
            this.cndcLabelPass = new Controles.CNDCLabel();
            this.TextBoxUsuario = new Controles.CNDCTextBox();
            this.cndcLabelInfo = new Controles.CNDCLabel();
            this.cndcLabelDestino = new Controles.CNDCLabel();

            this.cndcLabelConexion = new Controles.CNDCLabel();
            this.cndcComboConexion = new Controles.CNDCComboBox();

            this.cndcComboDestino = new Controles.CNDCComboBox();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this._cmbConectarDesde = new Controles.CNDCComboBox();
            this._lblConectadoDesde = new Controles.CNDCLabel();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte2 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte3 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte4 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte5 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte6 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte7 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte8 = new repSisfalla.CachedplantillaReporte();
            this.cndcPictureBox1 = new Controles.CNDCPictureBox();
            this.PasswordEye = new Controles.CNDCPasswordEye();
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelUsuario
            // 
            this.cndcLabelUsuario.AutoSize = true;
            this.cndcLabelUsuario.Location = new System.Drawing.Point(150, 40);
            this.cndcLabelUsuario.Name = "cndcLabelUsuario";
            this.cndcLabelUsuario.Size = new System.Drawing.Size(49, 13);
            this.cndcLabelUsuario.TabIndex = 0;
            this.cndcLabelUsuario.TablaCampoBD = null;
            this.cndcLabelUsuario.Text = "Usuario :";
            // 
            // cndcLabelPass
            // 
            this.cndcLabelPass.AutoSize = true;
            this.cndcLabelPass.Location = new System.Drawing.Point(132, 64);
            this.cndcLabelPass.Name = "cndcLabelPass";
            this.cndcLabelPass.Size = new System.Drawing.Size(67, 13);
            this.cndcLabelPass.TabIndex = 2;
            this.cndcLabelPass.TablaCampoBD = null;
            this.cndcLabelPass.Text = "Contraseña :";
            // 
            // TextBoxUsuario
            // 
            this.TextBoxUsuario.EnterComoTab = false;
            this.TextBoxUsuario.Etiqueta = null;
            this.TextBoxUsuario.Location = new System.Drawing.Point(203, 38);
            this.TextBoxUsuario.Name = "TextBoxUsuario";
            this.TextBoxUsuario.Size = new System.Drawing.Size(112, 20);
            this.TextBoxUsuario.TabIndex = 1;
            this.TextBoxUsuario.TablaCampoBD = null;
            // 
            // cndcLabelInfo
            // 
            this.cndcLabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cndcLabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cndcLabelInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cndcLabelInfo.Location = new System.Drawing.Point(0, 157);
            this.cndcLabelInfo.Name = "cndcLabelInfo";
            this.cndcLabelInfo.Size = new System.Drawing.Size(369, 20);
            this.cndcLabelInfo.TabIndex = 6;
            this.cndcLabelInfo.TablaCampoBD = null;
            this.cndcLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cndcLabelDestino
            // 
            this.cndcLabelDestino.AutoSize = true;
            this.cndcLabelDestino.Location = new System.Drawing.Point(132, 88);
            this.cndcLabelDestino.Name = "cndcLabelDestino";
            this.cndcLabelDestino.Size = new System.Drawing.Size(67, 13);
            this.cndcLabelDestino.TabIndex = 4;
            this.cndcLabelDestino.TablaCampoBD = null;
            this.cndcLabelDestino.Text = "Conectarse :";
            this.cndcLabelDestino.Visible = false;
            // 
            // cndcLabelConexion
            // 
            this.cndcLabelConexion.AutoSize = true;
            this.cndcLabelConexion.Location = new System.Drawing.Point(132, 88);
            this.cndcLabelConexion.Name = "cndcLabelConexion";
            this.cndcLabelConexion.Size = new System.Drawing.Size(67, 13);
            this.cndcLabelConexion.TabIndex = 4;
            this.cndcLabelConexion.TablaCampoBD = null;
            this.cndcLabelConexion.Text = "Conectado:";
            //this.cndcLabelConexion.Visible = false;
            // 
            // cndcComboConexion
            // 
            this.cndcComboConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cndcComboConexion.EnterComoTab = false;
            this.cndcComboConexion.Etiqueta = null;
            this.cndcComboConexion.FormattingEnabled = true;
            this.cndcComboConexion.Location = new System.Drawing.Point(203, 85);
            this.cndcComboConexion.Name = "cndcComboConexion";
            this.cndcComboConexion.Size = new System.Drawing.Size(112, 21);
            this.cndcComboConexion.TabIndex = 3;
            this.cndcComboConexion.TablaCampoBD = null;
            //this.cndcComboConexion.Visible = false;

            // 
            // cndcComboDestino
            // 
            this.cndcComboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cndcComboDestino.EnterComoTab = false;
            this.cndcComboDestino.Etiqueta = null;
            this.cndcComboDestino.FormattingEnabled = true;
            this.cndcComboDestino.Location = new System.Drawing.Point(203, 85);
            this.cndcComboDestino.Name = "cndcComboDestino";
            this.cndcComboDestino.Size = new System.Drawing.Size(112, 21);
            this.cndcComboDestino.TabIndex = 3;
            this.cndcComboDestino.TablaCampoBD = null;
            this.cndcComboDestino.Visible = false;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(45, 107);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(132, 35);
            this._btnAceptar.TabIndex = 4;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Ingresar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancelar.Location = new System.Drawing.Point(183, 107);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(132, 35);
            this._btnCancelar.TabIndex = 5;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _cmbConectarDesde
            // 
            this._cmbConectarDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbConectarDesde.EnterComoTab = false;
            this._cmbConectarDesde.Etiqueta = null;
            this._cmbConectarDesde.FormattingEnabled = true;
            this._cmbConectarDesde.Items.AddRange(new object[] {
            "Interior Sala CDC",
            "Exterior Sala CDC"});
            this._cmbConectarDesde.Location = new System.Drawing.Point(203, 14);
            this._cmbConectarDesde.Name = "_cmbConectarDesde";
            this._cmbConectarDesde.Size = new System.Drawing.Size(135, 21);
            this._cmbConectarDesde.TabIndex = 0;
            this._cmbConectarDesde.TablaCampoBD = null;
            // 
            // _lblConectadoDesde
            // 
            this._lblConectadoDesde.AutoSize = true;
            this._lblConectadoDesde.Location = new System.Drawing.Point(99, 17);
            this._lblConectadoDesde.Name = "_lblConectadoDesde";
            this._lblConectadoDesde.Size = new System.Drawing.Size(100, 13);
            this._lblConectadoDesde.TabIndex = 8;
            this._lblConectadoDesde.TablaCampoBD = null;
            this._lblConectadoDesde.Text = "Conectando desde:";
            // 
            // cndcPictureBox1
            // 
            this.cndcPictureBox1.Image = global::QuantumUI.Properties.Resources.logo_q;
            this.cndcPictureBox1.Location = new System.Drawing.Point(14, 11);
            this.cndcPictureBox1.Name = "cndcPictureBox1";
            this.cndcPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.cndcPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cndcPictureBox1.TabIndex = 7;
            this.cndcPictureBox1.TablaCampoBD = null;
            this.cndcPictureBox1.TabStop = false;
            // 
            // PasswordEye
            // 
            this.PasswordEye.Location = new System.Drawing.Point(203, 62);
            this.PasswordEye.Maximum_Width = 10;
            this.PasswordEye.MaxLength = 20;
            this.PasswordEye.Name = "PasswordEye";
            this.PasswordEye.Size = new System.Drawing.Size(92, 17);
            this.PasswordEye.TabIndex = 2;
            // 
            // FormIngreso
            // 
            this.AcceptButton = this._btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(369, 177);
            this.CloseButtonDisable = true;
            this.Controls.Add(this.PasswordEye);
            this.Controls.Add(this._cmbConectarDesde);
            this.Controls.Add(this._lblConectadoDesde);
            this.Controls.Add(this.cndcPictureBox1);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this.cndcComboDestino);
            this.Controls.Add(this.cndcLabelDestino);
            this.Controls.Add(this.cndcComboConexion);
            this.Controls.Add(this.cndcLabelConexion);
            this.Controls.Add(this.cndcLabelInfo);
            this.Controls.Add(this.TextBoxUsuario);
            this.Controls.Add(this.cndcLabelPass);
            this.Controls.Add(this.cndcLabelUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.LoginIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelUsuario;
        private Controles.CNDCLabel cndcLabelPass;
        private Controles.CNDCTextBox TextBoxUsuario;
        private Controles.CNDCLabel cndcLabelInfo;
        private Controles.CNDCLabel cndcLabelDestino;

        private Controles.CNDCLabel cndcLabelConexion;
        private Controles.CNDCComboBox cndcComboConexion;

        private Controles.CNDCComboBox cndcComboDestino;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCPictureBox cndcPictureBox1;
        private Controles.CNDCComboBox _cmbConectarDesde;
        private Controles.CNDCLabel _lblConectadoDesde;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte2;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte3;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte4;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte5;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte6;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte7;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte8;
        private Controles.CNDCPasswordEye PasswordEye;
    }
}