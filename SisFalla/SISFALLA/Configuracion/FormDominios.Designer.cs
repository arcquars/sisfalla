namespace SISFALLA
{
    partial class FormDominios
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
            this.components = new System.ComponentModel.Container();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtDescParam = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dtpFecInicio = new Controles.CNDCDateTimePicker();
            this._dtpFecFin = new Controles.CNDCDateTimePicker();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtComentario = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Image = global::SISFALLA.Properties.Resources.save;
            this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnAceptar.Location = new System.Drawing.Point(76, 120);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(92, 23);
            this._btnAceptar.TabIndex = 8;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SISFALLA.Properties.Resources.cancel;
            this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCancelar.Location = new System.Drawing.Point(178, 120);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(92, 23);
            this._btnCancelar.TabIndex = 9;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Location = new System.Drawing.Point(17, 76);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(147, 13);
            this.cndcLabelControl4.TabIndex = 6;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Comentario de Administrador :";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(29, 9);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(135, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Descripción de Parámetro :";
            // 
            // _txtDescParam
            // 
            this._txtDescParam.EnterComoTab = false;
            this._txtDescParam.Etiqueta = null;
            this._txtDescParam.Location = new System.Drawing.Point(168, 6);
            this._txtDescParam.Name = "_txtDescParam";
            this._txtDescParam.Size = new System.Drawing.Size(189, 20);
            this._txtDescParam.TabIndex = 1;
            this._txtDescParam.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(76, 33);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(88, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Fecha de Inicial :";
            // 
            // _dtpFecInicio
            // 
            this._dtpFecInicio.CustomFormat = "dd/MM/yyyy";
            this._dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFecInicio.Location = new System.Drawing.Point(168, 29);
            this._dtpFecInicio.Name = "_dtpFecInicio";
            this._dtpFecInicio.Size = new System.Drawing.Size(88, 20);
            this._dtpFecInicio.TabIndex = 3;
            this._dtpFecInicio.TablaCampoBD = null;
            // 
            // _dtpFecFin
            // 
            this._dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this._dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFecFin.Location = new System.Drawing.Point(169, 51);
            this._dtpFecFin.Name = "_dtpFecFin";
            this._dtpFecFin.Size = new System.Drawing.Size(87, 20);
            this._dtpFecFin.TabIndex = 5;
            this._dtpFecFin.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(81, 55);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(83, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Fecha de Final :";
            // 
            // _txtComentario
            // 
            this._txtComentario.EnterComoTab = false;
            this._txtComentario.Etiqueta = null;
            this._txtComentario.Location = new System.Drawing.Point(168, 73);
            this._txtComentario.Multiline = true;
            this._txtComentario.Name = "_txtComentario";
            this._txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtComentario.Size = new System.Drawing.Size(189, 32);
            this._txtComentario.TabIndex = 7;
            this._txtComentario.TablaCampoBD = null;
            // 
            // FormDominios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 146);
            this.Controls.Add(this._txtComentario);
            this.Controls.Add(this._dtpFecFin);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._dtpFecInicio);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtDescParam);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDominios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar / Editar Datos";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCLabel cndcLabelControl4;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCTextBox _txtDescParam;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtComentario;
        private Controles.CNDCDateTimePicker _dtpFecFin;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCDateTimePicker _dtpFecInicio;
        private Controles.CNDCLabel cndcLabel2;
    }
}