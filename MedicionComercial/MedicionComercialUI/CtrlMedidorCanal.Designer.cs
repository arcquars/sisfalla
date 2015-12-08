namespace MedicionComercialUI
{
    partial class CtrlMedidorCanal
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtKC = new Controles.CNDCTextBoxNumerico();
            this._txtKCT = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtKPT = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._ctrlSelecCanal = new MedicionComercialUI.CtrlSelecCanal();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._txtNumCanal = new Controles.CNDCTextBoxNumerico();
            this.cndcGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(3, 8);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(52, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Tipo Info:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(6, 22);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(24, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "KC:";
            // 
            // _txtKC
            // 
            this._txtKC.EnterComoTab = false;
            this._txtKC.Etiqueta = null;
            this._txtKC.Location = new System.Drawing.Point(36, 19);
            this._txtKC.MaxDigitosDecimales = 0;
            this._txtKC.MaxDigitosEnteros = 0;
            this._txtKC.Name = "_txtKC";
            this._txtKC.Size = new System.Drawing.Size(99, 20);
            this._txtKC.TabIndex = 3;
            this._txtKC.TablaCampoBD = null;
            this._txtKC.Text = "0";
            this._txtKC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtKCT
            // 
            this._txtKCT.EnterComoTab = false;
            this._txtKCT.Etiqueta = null;
            this._txtKCT.Location = new System.Drawing.Point(184, 19);
            this._txtKCT.MaxDigitosDecimales = 0;
            this._txtKCT.MaxDigitosEnteros = 0;
            this._txtKCT.Name = "_txtKCT";
            this._txtKCT.Size = new System.Drawing.Size(99, 20);
            this._txtKCT.TabIndex = 5;
            this._txtKCT.TablaCampoBD = null;
            this._txtKCT.Text = "0";
            this._txtKCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(147, 22);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(31, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "KCT:";
            // 
            // _txtKPT
            // 
            this._txtKPT.EnterComoTab = false;
            this._txtKPT.Etiqueta = null;
            this._txtKPT.Location = new System.Drawing.Point(335, 19);
            this._txtKPT.MaxDigitosDecimales = 0;
            this._txtKPT.MaxDigitosEnteros = 0;
            this._txtKPT.Name = "_txtKPT";
            this._txtKPT.Size = new System.Drawing.Size(99, 20);
            this._txtKPT.TabIndex = 7;
            this._txtKPT.TablaCampoBD = null;
            this._txtKPT.Text = "0";
            this._txtKPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(298, 22);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(31, 13);
            this.cndcLabel4.TabIndex = 8;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "KPT:";
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtKC);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel4);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel2);
            this.cndcGroupBox1.Controls.Add(this._txtKPT);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel3);
            this.cndcGroupBox1.Controls.Add(this._txtKCT);
            this.cndcGroupBox1.Location = new System.Drawing.Point(118, 31);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(436, 46);
            this.cndcGroupBox1.TabIndex = 9;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Constantes:";
            // 
            // _ctrlSelecCanal
            // 
            this._ctrlSelecCanal.Location = new System.Drawing.Point(58, 4);
            this._ctrlSelecCanal.Name = "_ctrlSelecCanal";
            this._ctrlSelecCanal.Size = new System.Drawing.Size(496, 21);
            this._ctrlSelecCanal.TabIndex = 1;
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(9, 52);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(37, 13);
            this.cndcLabel5.TabIndex = 10;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Canal:";
            // 
            // _txtNumCanal
            // 
            this._txtNumCanal.EnterComoTab = false;
            this._txtNumCanal.Etiqueta = null;
            this._txtNumCanal.Location = new System.Drawing.Point(49, 50);
            this._txtNumCanal.MaxDigitosDecimales = 0;
            this._txtNumCanal.MaxDigitosEnteros = 0;
            this._txtNumCanal.Name = "_txtNumCanal";
            this._txtNumCanal.Size = new System.Drawing.Size(63, 20);
            this._txtNumCanal.TabIndex = 9;
            this._txtNumCanal.TablaCampoBD = null;
            this._txtNumCanal.Text = "0";
            this._txtNumCanal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CtrlMedidorCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtNumCanal);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._ctrlSelecCanal);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlMedidorCanal";
            this.Size = new System.Drawing.Size(557, 82);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private CtrlSelecCanal _ctrlSelecCanal;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBoxNumerico _txtKC;
        private Controles.CNDCTextBoxNumerico _txtKCT;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBoxNumerico _txtKPT;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBoxNumerico _txtNumCanal;
    }
}
