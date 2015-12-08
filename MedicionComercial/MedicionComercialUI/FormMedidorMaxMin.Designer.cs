namespace MedicionComercialUI
{
    partial class FormMedidorMaxMin
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
            this._dtpDesde = new Controles.CNDCDateTimePicker();
            this._dtpHasta = new Controles.CNDCDateTimePicker();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtMinimo = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._txtMaximo = new Controles.CNDCTextBoxNumerico();
            this._chbxHasta = new Controles.CNDCCheckBox();
            this._txtNoDefinido = new Controles.CNDCTextBox();
            this._ctrlSelecCanal = new MedicionComercialUI.CtrlSelecCanal();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(31, 35);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(37, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Canal:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(75, 76);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel2.TabIndex = 6;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Desde:";
            // 
            // _dtpDesde
            // 
            this._dtpDesde.CustomFormat = "dd/MMM/yyyy";
            this._dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpDesde.Location = new System.Drawing.Point(122, 70);
            this._dtpDesde.Name = "_dtpDesde";
            this._dtpDesde.Size = new System.Drawing.Size(112, 20);
            this._dtpDesde.TabIndex = 7;
            this._dtpDesde.TablaCampoBD = null;
            // 
            // _dtpHasta
            // 
            this._dtpHasta.CustomFormat = "dd/MMM/yyyy";
            this._dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpHasta.Location = new System.Drawing.Point(122, 93);
            this._dtpHasta.Name = "_dtpHasta";
            this._dtpHasta.Size = new System.Drawing.Size(112, 20);
            this._dtpHasta.TabIndex = 9;
            this._dtpHasta.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(71, 120);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(45, 13);
            this.cndcLabel4.TabIndex = 10;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Mínimo:";
            // 
            // _txtMinimo
            // 
            this._txtMinimo.AceptaNegativo = true;
            this._txtMinimo.EnterComoTab = false;
            this._txtMinimo.Etiqueta = null;
            this._txtMinimo.Location = new System.Drawing.Point(122, 117);
            this._txtMinimo.MaxDigitosDecimales = 0;
            this._txtMinimo.MaxDigitosEnteros = 0;
            this._txtMinimo.Name = "_txtMinimo";
            this._txtMinimo.Size = new System.Drawing.Size(100, 20);
            this._txtMinimo.TabIndex = 11;
            this._txtMinimo.TablaCampoBD = null;
            this._txtMinimo.Text = "0";
            this._txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtMinimo.UsarFormatoNumerico = true;
            this._txtMinimo.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtMinimo.ValorDouble = 0D;
            this._txtMinimo.ValorFloat = 0F;
            this._txtMinimo.ValorInt = 0;
            this._txtMinimo.ValorLong = ((long)(0));
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(70, 144);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(46, 13);
            this.cndcLabel5.TabIndex = 12;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Máximo:";
            // 
            // _txtMaximo
            // 
            this._txtMaximo.AceptaNegativo = true;
            this._txtMaximo.EnterComoTab = false;
            this._txtMaximo.Etiqueta = null;
            this._txtMaximo.Location = new System.Drawing.Point(122, 141);
            this._txtMaximo.MaxDigitosDecimales = 0;
            this._txtMaximo.MaxDigitosEnteros = 0;
            this._txtMaximo.Name = "_txtMaximo";
            this._txtMaximo.Size = new System.Drawing.Size(100, 20);
            this._txtMaximo.TabIndex = 13;
            this._txtMaximo.TablaCampoBD = null;
            this._txtMaximo.Text = "0";
            this._txtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtMaximo.UsarFormatoNumerico = true;
            this._txtMaximo.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtMaximo.ValorDouble = 0D;
            this._txtMaximo.ValorFloat = 0F;
            this._txtMaximo.ValorInt = 0;
            this._txtMaximo.ValorLong = ((long)(0));
            // 
            // _chbxHasta
            // 
            this._chbxHasta.AutoSize = true;
            this._chbxHasta.Location = new System.Drawing.Point(59, 95);
            this._chbxHasta.Name = "_chbxHasta";
            this._chbxHasta.Size = new System.Drawing.Size(57, 17);
            this._chbxHasta.TabIndex = 14;
            this._chbxHasta.TablaCampoBD = null;
            this._chbxHasta.Text = "Hasta:";
            this._chbxHasta.UseVisualStyleBackColor = true;
            this._chbxHasta.CheckedChanged += new System.EventHandler(this._chbxHasta_CheckedChanged);
            // 
            // _txtNoDefinido
            // 
            this._txtNoDefinido.EnterComoTab = false;
            this._txtNoDefinido.Etiqueta = null;
            this._txtNoDefinido.Location = new System.Drawing.Point(122, 93);
            this._txtNoDefinido.Name = "_txtNoDefinido";
            this._txtNoDefinido.Size = new System.Drawing.Size(112, 20);
            this._txtNoDefinido.TabIndex = 15;
            this._txtNoDefinido.TablaCampoBD = null;
            this._txtNoDefinido.Text = "No Definido.";
            // 
            // _ctrlSelecCanal
            // 
            this._ctrlSelecCanal.Location = new System.Drawing.Point(74, 31);
            this._ctrlSelecCanal.Name = "_ctrlSelecCanal";
            this._ctrlSelecCanal.Size = new System.Drawing.Size(496, 21);
            this._ctrlSelecCanal.TabIndex = 5;
            // 
            // FormMedidorMaxMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 219);
            this.Controls.Add(this._chbxHasta);
            this.Controls.Add(this._txtMaximo);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this._txtMinimo);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._dtpHasta);
            this.Controls.Add(this._dtpDesde);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._ctrlSelecCanal);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._txtNoDefinido);
            this.Name = "FormMedidorMaxMin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMedidorMaxMin";
            this.Controls.SetChildIndex(this._txtNoDefinido, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._ctrlSelecCanal, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._dtpDesde, 0);
            this.Controls.SetChildIndex(this._dtpHasta, 0);
            this.Controls.SetChildIndex(this.cndcLabel4, 0);
            this.Controls.SetChildIndex(this._txtMinimo, 0);
            this.Controls.SetChildIndex(this.cndcLabel5, 0);
            this.Controls.SetChildIndex(this._txtMaximo, 0);
            this.Controls.SetChildIndex(this._chbxHasta, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlSelecCanal _ctrlSelecCanal;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCDateTimePicker _dtpDesde;
        private Controles.CNDCDateTimePicker _dtpHasta;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBoxNumerico _txtMinimo;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBoxNumerico _txtMaximo;
        private Controles.CNDCCheckBox _chbxHasta;
        private Controles.CNDCTextBox _txtNoDefinido;
    }
}