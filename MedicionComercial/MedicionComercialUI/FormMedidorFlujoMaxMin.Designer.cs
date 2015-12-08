namespace MedicionComercialUI
{
    partial class FormMedidorFlujoMaxMin
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
            this._chbxHasta = new Controles.CNDCCheckBox();
            this._dtpHasta = new Controles.CNDCDateTimePicker();
            this._dtpDesde = new Controles.CNDCDateTimePicker();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtNoDefinido = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _chbxHasta
            // 
            this._chbxHasta.AutoSize = true;
            this._chbxHasta.Location = new System.Drawing.Point(27, 72);
            this._chbxHasta.Name = "_chbxHasta";
            this._chbxHasta.Size = new System.Drawing.Size(57, 17);
            this._chbxHasta.TabIndex = 19;
            this._chbxHasta.TablaCampoBD = null;
            this._chbxHasta.Text = "Hasta:";
            this._chbxHasta.UseVisualStyleBackColor = true;
            // 
            // _dtpHasta
            // 
            this._dtpHasta.CustomFormat = "dd/MMM/yyyy";
            this._dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpHasta.Location = new System.Drawing.Point(90, 70);
            this._dtpHasta.Name = "_dtpHasta";
            this._dtpHasta.Size = new System.Drawing.Size(112, 20);
            this._dtpHasta.TabIndex = 18;
            this._dtpHasta.TablaCampoBD = null;
            // 
            // _dtpDesde
            // 
            this._dtpDesde.CustomFormat = "dd/MMM/yyyy";
            this._dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpDesde.Location = new System.Drawing.Point(90, 47);
            this._dtpDesde.Name = "_dtpDesde";
            this._dtpDesde.Size = new System.Drawing.Size(112, 20);
            this._dtpDesde.TabIndex = 17;
            this._dtpDesde.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(43, 53);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel2.TabIndex = 16;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Desde:";
            // 
            // _txtNoDefinido
            // 
            this._txtNoDefinido.EnterComoTab = false;
            this._txtNoDefinido.Etiqueta = null;
            this._txtNoDefinido.Location = new System.Drawing.Point(90, 70);
            this._txtNoDefinido.Name = "_txtNoDefinido";
            this._txtNoDefinido.Size = new System.Drawing.Size(112, 20);
            this._txtNoDefinido.TabIndex = 20;
            this._txtNoDefinido.TablaCampoBD = null;
            this._txtNoDefinido.Text = "No Definido.";
            // 
            // FormMedidorFlujoMaxMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 132);
            this.Controls.Add(this._chbxHasta);
            this.Controls.Add(this._dtpHasta);
            this.Controls.Add(this._dtpDesde);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtNoDefinido);
            this.Name = "FormMedidorFlujoMaxMin";
            this.Text = "FormMedidorFlujoMaxMin";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this._txtNoDefinido, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._dtpDesde, 0);
            this.Controls.SetChildIndex(this._dtpHasta, 0);
            this.Controls.SetChildIndex(this._chbxHasta, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCCheckBox _chbxHasta;
        private Controles.CNDCDateTimePicker _dtpHasta;
        private Controles.CNDCDateTimePicker _dtpDesde;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtNoDefinido;
    }
}