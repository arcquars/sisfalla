namespace MedicionComercialUI
{
    partial class FormFormula
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dtpFechaInicio = new Controles.CNDCDateTimePicker();
            this._dtpFechaFin = new Controles.CNDCDateTimePicker();
            this._txtFormula = new Controles.CNDCTextBox();
            this._btnEditarFormula = new Controles.CNDCButton();
            this._chbxHasta = new Controles.CNDCCheckBox();
            this._txtSinDefinir = new Controles.CNDCTextBox();
            this._ctrlMagnitudElec = new MedicionComercialUI.CtrlSelecCanal();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(12, 45);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(98, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Magnitud Eléctrica:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(69, 71);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel2.TabIndex = 6;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Desde:";
            // 
            // _dtpFechaInicio
            // 
            this._dtpFechaInicio.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaInicio.Location = new System.Drawing.Point(116, 68);
            this._dtpFechaInicio.Name = "_dtpFechaInicio";
            this._dtpFechaInicio.Size = new System.Drawing.Size(154, 20);
            this._dtpFechaInicio.TabIndex = 7;
            this._dtpFechaInicio.TablaCampoBD = null;
            // 
            // _dtpFechaFin
            // 
            this._dtpFechaFin.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaFin.Location = new System.Drawing.Point(116, 94);
            this._dtpFechaFin.Name = "_dtpFechaFin";
            this._dtpFechaFin.Size = new System.Drawing.Size(154, 20);
            this._dtpFechaFin.TabIndex = 9;
            this._dtpFechaFin.TablaCampoBD = null;
            this._dtpFechaFin.Visible = false;
            // 
            // _txtFormula
            // 
            this._txtFormula.EnterComoTab = false;
            this._txtFormula.Etiqueta = null;
            this._txtFormula.Location = new System.Drawing.Point(116, 120);
            this._txtFormula.Multiline = true;
            this._txtFormula.Name = "_txtFormula";
            this._txtFormula.Size = new System.Drawing.Size(496, 76);
            this._txtFormula.TabIndex = 11;
            this._txtFormula.TablaCampoBD = null;
            // 
            // _btnEditarFormula
            // 
            this._btnEditarFormula.Location = new System.Drawing.Point(22, 120);
            this._btnEditarFormula.Name = "_btnEditarFormula";
            this._btnEditarFormula.Size = new System.Drawing.Size(88, 26);
            this._btnEditarFormula.TabIndex = 12;
            this._btnEditarFormula.TablaCampoBD = null;
            this._btnEditarFormula.Text = "Formula";
            this._btnEditarFormula.UseVisualStyleBackColor = true;
            this._btnEditarFormula.Click += new System.EventHandler(this._btnEditarFormula_Click);
            // 
            // _chbxHasta
            // 
            this._chbxHasta.AutoSize = true;
            this._chbxHasta.Location = new System.Drawing.Point(53, 94);
            this._chbxHasta.Name = "_chbxHasta";
            this._chbxHasta.Size = new System.Drawing.Size(57, 17);
            this._chbxHasta.TabIndex = 13;
            this._chbxHasta.TablaCampoBD = null;
            this._chbxHasta.Text = "Hasta:";
            this._chbxHasta.UseVisualStyleBackColor = true;
            this._chbxHasta.CheckedChanged += new System.EventHandler(this._chbxHasta_CheckedChanged);
            // 
            // _txtSinDefinir
            // 
            this._txtSinDefinir.BackColor = System.Drawing.SystemColors.Window;
            this._txtSinDefinir.EnterComoTab = false;
            this._txtSinDefinir.Etiqueta = null;
            this._txtSinDefinir.Location = new System.Drawing.Point(116, 94);
            this._txtSinDefinir.Name = "_txtSinDefinir";
            this._txtSinDefinir.ReadOnly = true;
            this._txtSinDefinir.Size = new System.Drawing.Size(154, 20);
            this._txtSinDefinir.TabIndex = 14;
            this._txtSinDefinir.TablaCampoBD = null;
            this._txtSinDefinir.Text = "Sin definir.";
            // 
            // _ctrlMagnitudElec
            // 
            this._ctrlMagnitudElec.Location = new System.Drawing.Point(116, 42);
            this._ctrlMagnitudElec.Name = "_ctrlMagnitudElec";
            this._ctrlMagnitudElec.Size = new System.Drawing.Size(496, 21);
            this._ctrlMagnitudElec.TabIndex = 5;
            // 
            // FormFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 253);
            this.Controls.Add(this._txtSinDefinir);
            this.Controls.Add(this._chbxHasta);
            this.Controls.Add(this._btnEditarFormula);
            this.Controls.Add(this._txtFormula);
            this.Controls.Add(this._dtpFechaFin);
            this.Controls.Add(this._dtpFechaInicio);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._ctrlMagnitudElec);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFormula";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._ctrlMagnitudElec, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this._dtpFechaFin, 0);
            this.Controls.SetChildIndex(this._txtFormula, 0);
            this.Controls.SetChildIndex(this._btnEditarFormula, 0);
            this.Controls.SetChildIndex(this._chbxHasta, 0);
            this.Controls.SetChildIndex(this._txtSinDefinir, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlSelecCanal _ctrlMagnitudElec;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCDateTimePicker _dtpFechaInicio;
        private Controles.CNDCDateTimePicker _dtpFechaFin;
        private Controles.CNDCTextBox _txtFormula;
        private Controles.CNDCButton _btnEditarFormula;
        private Controles.CNDCCheckBox _chbxHasta;
        private Controles.CNDCTextBox _txtSinDefinir;
    }
}