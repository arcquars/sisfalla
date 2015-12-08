namespace SISFALLA
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
            this.TextBoxPassword = new Controles.CNDCTextBox();
            this.cndcLabelInfo = new Controles.CNDCLabel();
            this.cndcLabelDestino = new Controles.CNDCLabel();
            this.cndcComboDestino = new Controles.CNDCComboBox();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this.cndcPictureBox1 = new Controles.CNDCPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelUsuario
            // 
            this.cndcLabelUsuario.AutoSize = true;
            this.cndcLabelUsuario.Location = new System.Drawing.Point(124, 39);
            this.cndcLabelUsuario.Name = "cndcLabelUsuario";
            this.cndcLabelUsuario.Size = new System.Drawing.Size(49, 13);
            this.cndcLabelUsuario.TabIndex = 0;
            this.cndcLabelUsuario.TablaCampoBD = null;
            this.cndcLabelUsuario.Text = "Usuario :";
            // 
            // cndcLabelPass
            // 
            this.cndcLabelPass.AutoSize = true;
            this.cndcLabelPass.Location = new System.Drawing.Point(106, 63);
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
            this.TextBoxUsuario.Location = new System.Drawing.Point(183, 37);
            this.TextBoxUsuario.Name = "TextBoxUsuario";
            this.TextBoxUsuario.Size = new System.Drawing.Size(112, 20);
            this.TextBoxUsuario.TabIndex = 1;
            this.TextBoxUsuario.TablaCampoBD = null;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.EnterComoTab = false;
            this.TextBoxPassword.Etiqueta = null;
            this.TextBoxPassword.Location = new System.Drawing.Point(183, 60);
            this.TextBoxPassword.MaxLength = 15;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '•';
            this.TextBoxPassword.Size = new System.Drawing.Size(112, 20);
            this.TextBoxPassword.TabIndex = 3;
            this.TextBoxPassword.TablaCampoBD = null;
            // 
            // cndcLabelInfo
            // 
            this.cndcLabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cndcLabelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cndcLabelInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cndcLabelInfo.Location = new System.Drawing.Point(0, 157);
            this.cndcLabelInfo.Name = "cndcLabelInfo";
            this.cndcLabelInfo.Size = new System.Drawing.Size(369, 20);
            this.cndcLabelInfo.TabIndex = 8;
            this.cndcLabelInfo.TablaCampoBD = null;
            this.cndcLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cndcLabelDestino
            // 
            this.cndcLabelDestino.AutoSize = true;
            this.cndcLabelDestino.Location = new System.Drawing.Point(106, 87);
            this.cndcLabelDestino.Name = "cndcLabelDestino";
            this.cndcLabelDestino.Size = new System.Drawing.Size(67, 13);
            this.cndcLabelDestino.TabIndex = 4;
            this.cndcLabelDestino.TablaCampoBD = null;
            this.cndcLabelDestino.Text = "Conectarse :";
            this.cndcLabelDestino.Visible = false;
            // 
            // cndcComboDestino
            // 
            this.cndcComboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cndcComboDestino.EnterComoTab = false;
            this.cndcComboDestino.Etiqueta = null;
            this.cndcComboDestino.FormattingEnabled = true;
            this.cndcComboDestino.Location = new System.Drawing.Point(183, 84);
            this.cndcComboDestino.Name = "cndcComboDestino";
            this.cndcComboDestino.Size = new System.Drawing.Size(112, 21);
            this.cndcComboDestino.TabIndex = 5;
            this.cndcComboDestino.TablaCampoBD = null;
            this.cndcComboDestino.Visible = false;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(45, 107);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(132, 35);
            this._btnAceptar.TabIndex = 6;
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
            this._btnCancelar.TabIndex = 7;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // cndcPictureBox1
            // 
            this.cndcPictureBox1.Image = global::SISFALLA.Properties.Resources.logo_q;
            this.cndcPictureBox1.Location = new System.Drawing.Point(14, 11);
            this.cndcPictureBox1.Name = "cndcPictureBox1";
            this.cndcPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.cndcPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cndcPictureBox1.TabIndex = 7;
            this.cndcPictureBox1.TablaCampoBD = null;
            this.cndcPictureBox1.TabStop = false;
            // 
            // FormIngreso
            // 
            this.AcceptButton = this._btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(369, 177);
            this.CloseButtonDisable = true;
            this.Controls.Add(this.cndcPictureBox1);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this.cndcComboDestino);
            this.Controls.Add(this.cndcLabelDestino);
            this.Controls.Add(this.cndcLabelInfo);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUsuario);
            this.Controls.Add(this.cndcLabelPass);
            this.Controls.Add(this.cndcLabelUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conexión a QUANTUM";
            this.Load += new System.EventHandler(this.LoginIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelUsuario;
        private Controles.CNDCLabel cndcLabelPass;
        private Controles.CNDCTextBox TextBoxUsuario;
        private Controles.CNDCTextBox TextBoxPassword;
        private Controles.CNDCLabel cndcLabelInfo;
        private Controles.CNDCLabel cndcLabelDestino;
        private Controles.CNDCComboBox cndcComboDestino;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCPictureBox cndcPictureBox1;
    }
}