namespace SISFALLA
{
    partial class FormEditarConfig
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
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this._btnCancelar = new Controles.CNDCButton();
            this._btnGuardar = new Controles.CNDCButton();
            this._txtValorConfig = new Controles.CNDCTextBox();
            this._cmbConfiguracion = new Controles.CNDCComboBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.SuspendLayout();
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Location = new System.Drawing.Point(52, 38);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(34, 13);
            this.cndcLabelControl4.TabIndex = 6;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Valor:";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SISFALLA.Properties.Resources.cancel;
            this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCancelar.Location = new System.Drawing.Point(249, 103);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 9;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Image = global::SISFALLA.Properties.Resources.save;
            this._btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnGuardar.Location = new System.Drawing.Point(158, 103);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(75, 23);
            this._btnGuardar.TabIndex = 8;
            this._btnGuardar.TablaCampoBD = null;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnGuardar.UseVisualStyleBackColor = true;
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _txtValorConfig
            // 
            this._txtValorConfig.EnterComoTab = false;
            this._txtValorConfig.Etiqueta = null;
            this._txtValorConfig.Location = new System.Drawing.Point(92, 35);
            this._txtValorConfig.Multiline = true;
            this._txtValorConfig.Name = "_txtValorConfig";
            this._txtValorConfig.Size = new System.Drawing.Size(357, 62);
            this._txtValorConfig.TabIndex = 10;
            this._txtValorConfig.TablaCampoBD = null;
            // 
            // _cmbConfiguracion
            // 
            this._cmbConfiguracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbConfiguracion.EnterComoTab = false;
            this._cmbConfiguracion.Etiqueta = null;
            this._cmbConfiguracion.FormattingEnabled = true;
            this._cmbConfiguracion.Location = new System.Drawing.Point(92, 8);
            this._cmbConfiguracion.Name = "_cmbConfiguracion";
            this._cmbConfiguracion.Size = new System.Drawing.Size(357, 21);
            this._cmbConfiguracion.TabIndex = 11;
            this._cmbConfiguracion.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(11, 11);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(75, 13);
            this.cndcLabel1.TabIndex = 12;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Configuración:";
            // 
            // FormEditarConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 135);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._cmbConfiguracion);
            this.Controls.Add(this._txtValorConfig);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEditarConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Configuración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCButton _btnGuardar;
        private Controles.CNDCTextBox _txtValorConfig;
        private Controles.CNDCComboBox _cmbConfiguracion;
        private Controles.CNDCLabel cndcLabel1;
    }
}