namespace MedicionComercialUI
{
    partial class FormMedidorFlujoMaxMinDetalle
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
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtMinimo = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._txtMaximo = new Controles.CNDCTextBoxNumerico();
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
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(138, 61);
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
            this._txtMinimo.Location = new System.Drawing.Point(189, 58);
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
            this.cndcLabel5.Location = new System.Drawing.Point(322, 61);
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
            this._txtMaximo.Location = new System.Drawing.Point(374, 58);
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
            // _ctrlSelecCanal
            // 
            this._ctrlSelecCanal.Location = new System.Drawing.Point(74, 31);
            this._ctrlSelecCanal.Name = "_ctrlSelecCanal";
            this._ctrlSelecCanal.Size = new System.Drawing.Size(496, 21);
            this._ctrlSelecCanal.TabIndex = 5;
            // 
            // FormMedidorFlujoMaxMinDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 121);
            this.Controls.Add(this._txtMaximo);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this._txtMinimo);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._ctrlSelecCanal);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormMedidorFlujoMaxMinDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMedidorMaxMin";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._ctrlSelecCanal, 0);
            this.Controls.SetChildIndex(this.cndcLabel4, 0);
            this.Controls.SetChildIndex(this._txtMinimo, 0);
            this.Controls.SetChildIndex(this.cndcLabel5, 0);
            this.Controls.SetChildIndex(this._txtMaximo, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlSelecCanal _ctrlSelecCanal;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBoxNumerico _txtMinimo;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBoxNumerico _txtMaximo;
    }
}