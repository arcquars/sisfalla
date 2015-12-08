namespace MedicionComercialUI
{
    partial class FormRMedidorCanal
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
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtKC = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtKPT = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtKCT = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtNumCanal = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this._txtColArchivo = new Controles.CNDCTextBox();
            this._ctrlSelecCanal = new MedicionComercialUI.CtrlSelecCanal();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtKC);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel4);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel2);
            this.cndcGroupBox1.Controls.Add(this._txtKPT);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel3);
            this.cndcGroupBox1.Controls.Add(this._txtKCT);
            this.cndcGroupBox1.Location = new System.Drawing.Point(359, 78);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(192, 123);
            this.cndcGroupBox1.TabIndex = 7;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Constantes:";
            // 
            // _txtKC
            // 
            this._txtKC.AceptaNegativo = false;
            this._txtKC.EnterComoTab = true;
            this._txtKC.Etiqueta = null;
            this._txtKC.Location = new System.Drawing.Point(69, 31);
            this._txtKC.MaxDigitosDecimales = 0;
            this._txtKC.MaxDigitosEnteros = 0;
            this._txtKC.Name = "_txtKC";
            this._txtKC.Size = new System.Drawing.Size(99, 20);
            this._txtKC.TabIndex = 1;
            this._txtKC.TablaCampoBD = "F_MC_RPTO_MED_FTO_DET.KC";
            this._txtKC.Text = "0";
            this._txtKC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtKC.UsarFormatoNumerico = true;
            this._txtKC.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtKC.ValorDouble = 0D;
            this._txtKC.ValorFloat = 0F;
            this._txtKC.ValorInt = 0;
            this._txtKC.ValorLong = ((long)(0));
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(32, 86);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(31, 13);
            this.cndcLabel4.TabIndex = 4;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "KPT:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(39, 34);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(24, 13);
            this.cndcLabel2.TabIndex = 0;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "KC:";
            // 
            // _txtKPT
            // 
            this._txtKPT.AceptaNegativo = false;
            this._txtKPT.EnterComoTab = true;
            this._txtKPT.Etiqueta = null;
            this._txtKPT.Location = new System.Drawing.Point(69, 83);
            this._txtKPT.MaxDigitosDecimales = 0;
            this._txtKPT.MaxDigitosEnteros = 0;
            this._txtKPT.Name = "_txtKPT";
            this._txtKPT.Size = new System.Drawing.Size(99, 20);
            this._txtKPT.TabIndex = 5;
            this._txtKPT.TablaCampoBD = "F_MC_RPTO_MED_FTO_DET.KPT";
            this._txtKPT.Text = "0";
            this._txtKPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtKPT.UsarFormatoNumerico = true;
            this._txtKPT.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtKPT.ValorDouble = 0D;
            this._txtKPT.ValorFloat = 0F;
            this._txtKPT.ValorInt = 0;
            this._txtKPT.ValorLong = ((long)(0));
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(32, 60);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(31, 13);
            this.cndcLabel3.TabIndex = 2;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "KCT:";
            // 
            // _txtKCT
            // 
            this._txtKCT.AceptaNegativo = false;
            this._txtKCT.EnterComoTab = true;
            this._txtKCT.Etiqueta = null;
            this._txtKCT.Location = new System.Drawing.Point(69, 57);
            this._txtKCT.MaxDigitosDecimales = 0;
            this._txtKCT.MaxDigitosEnteros = 0;
            this._txtKCT.Name = "_txtKCT";
            this._txtKCT.Size = new System.Drawing.Size(99, 20);
            this._txtKCT.TabIndex = 3;
            this._txtKCT.TablaCampoBD = "F_MC_RPTO_MED_FTO_DET.KCT";
            this._txtKCT.Text = "0";
            this._txtKCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtKCT.UsarFormatoNumerico = true;
            this._txtKCT.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtKCT.ValorDouble = 0D;
            this._txtKCT.ValorFloat = 0F;
            this._txtKCT.ValorInt = 0;
            this._txtKCT.ValorLong = ((long)(0));
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(12, 55);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(37, 13);
            this.cndcLabel1.TabIndex = 1;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Canal:";
            // 
            // _txtNumCanal
            // 
            this._txtNumCanal.AceptaNegativo = false;
            this._txtNumCanal.EnterComoTab = true;
            this._txtNumCanal.Etiqueta = null;
            this._txtNumCanal.Location = new System.Drawing.Point(203, 109);
            this._txtNumCanal.MaxDigitosDecimales = 0;
            this._txtNumCanal.MaxDigitosEnteros = 0;
            this._txtNumCanal.Name = "_txtNumCanal";
            this._txtNumCanal.Size = new System.Drawing.Size(59, 20);
            this._txtNumCanal.TabIndex = 4;
            this._txtNumCanal.TablaCampoBD = "F_MC_RMEDIDOR_CANALES.CANAL";
            this._txtNumCanal.Text = "0";
            this._txtNumCanal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtNumCanal.UsarFormatoNumerico = true;
            this._txtNumCanal.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtNumCanal.ValorDouble = 0D;
            this._txtNumCanal.ValorFloat = 0F;
            this._txtNumCanal.ValorInt = 0;
            this._txtNumCanal.ValorLong = ((long)(0));
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(160, 112);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(37, 13);
            this.cndcLabel5.TabIndex = 3;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Canal:";
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Location = new System.Drawing.Point(92, 136);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(105, 13);
            this.cndcLabel6.TabIndex = 5;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Columna en Archivo:";
            // 
            // _txtColArchivo
            // 
            this._txtColArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtColArchivo.EnterComoTab = true;
            this._txtColArchivo.Etiqueta = null;
            this._txtColArchivo.Location = new System.Drawing.Point(203, 133);
            this._txtColArchivo.Name = "_txtColArchivo";
            this._txtColArchivo.Size = new System.Drawing.Size(60, 20);
            this._txtColArchivo.TabIndex = 6;
            this._txtColArchivo.TablaCampoBD = "F_MC_RMEDIDOR_CANALES.COL_ARCHIVO";
            this._txtColArchivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtColArchivo_KeyPress);
            // 
            // _ctrlSelecCanal
            // 
            this._ctrlSelecCanal.Location = new System.Drawing.Point(55, 51);
            this._ctrlSelecCanal.Name = "_ctrlSelecCanal";
            this._ctrlSelecCanal.Size = new System.Drawing.Size(496, 21);
            this._ctrlSelecCanal.TabIndex = 2;
            // 
            // FormRMedidorCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 236);
            this.Controls.Add(this._txtColArchivo);
            this.Controls.Add(this.cndcLabel6);
            this.Controls.Add(this._txtNumCanal);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._ctrlSelecCanal);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormRMedidorCanal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMedidorCanal";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._ctrlSelecCanal, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcLabel5, 0);
            this.Controls.SetChildIndex(this._txtNumCanal, 0);
            this.Controls.SetChildIndex(this.cndcLabel6, 0);
            this.Controls.SetChildIndex(this._txtColArchivo, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCTextBoxNumerico _txtKC;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBoxNumerico _txtKPT;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBoxNumerico _txtKCT;
        private CtrlSelecCanal _ctrlSelecCanal;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBoxNumerico _txtNumCanal;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCTextBox _txtColArchivo;
    }
}