namespace MedicionComercialUI
{
    partial class FormMedidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMedidor));
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtMarca = new Controles.CNDCTextBox();
            this._txtModelo = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtPresicion = new Controles.CNDCTextBoxNumerico();
            this._txtPrimeNoins = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._rbtnReal = new Controles.CNDCRadioButton();
            this._rbtnVirtual = new Controles.CNDCRadioButton();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnVerSoftLect = new System.Windows.Forms.ToolStripButton();
            this._btnConfigSoftLect = new System.Windows.Forms.ToolStripButton();
            this.cndcTextBox8 = new Controles.CNDCTextBox();
            this.cndcLabel9 = new Controles.CNDCLabel();
            this.cndcTextBox7 = new Controles.CNDCTextBox();
            this.cndcLabel8 = new Controles.CNDCLabel();
            this.cndcTextBox6 = new Controles.CNDCTextBox();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.cndcLabel10 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel11 = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1, 397);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(29, 397);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(53, 122);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(40, 13);
            this.cndcLabel1.TabIndex = 6;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Marca:";
            // 
            // _txtMarca
            // 
            this._txtMarca.EnterComoTab = false;
            this._txtMarca.Etiqueta = null;
            this._txtMarca.Location = new System.Drawing.Point(96, 119);
            this._txtMarca.Name = "_txtMarca";
            this._txtMarca.Size = new System.Drawing.Size(277, 20);
            this._txtMarca.TabIndex = 7;
            this._txtMarca.TablaCampoBD = null;
            // 
            // _txtModelo
            // 
            this._txtModelo.EnterComoTab = false;
            this._txtModelo.Etiqueta = null;
            this._txtModelo.Location = new System.Drawing.Point(96, 141);
            this._txtModelo.Name = "_txtModelo";
            this._txtModelo.Size = new System.Drawing.Size(277, 20);
            this._txtModelo.TabIndex = 9;
            this._txtModelo.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(48, 144);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(45, 13);
            this.cndcLabel2.TabIndex = 8;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Modelo:";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(40, 167);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(53, 13);
            this.cndcLabel3.TabIndex = 10;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Presición:";
            // 
            // _txtPresicion
            // 
            this._txtPresicion.AceptaNegativo = true;
            this._txtPresicion.EnterComoTab = false;
            this._txtPresicion.Etiqueta = null;
            this._txtPresicion.Location = new System.Drawing.Point(96, 164);
            this._txtPresicion.MaxDigitosDecimales = 0;
            this._txtPresicion.MaxDigitosEnteros = 0;
            this._txtPresicion.Name = "_txtPresicion";
            this._txtPresicion.Size = new System.Drawing.Size(100, 20);
            this._txtPresicion.TabIndex = 11;
            this._txtPresicion.TablaCampoBD = null;
            this._txtPresicion.Text = "0";
            this._txtPresicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPresicion.UsarFormatoNumerico = true;
            this._txtPresicion.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtPresicion.ValorDouble = 0D;
            this._txtPresicion.ValorFloat = 0F;
            this._txtPresicion.ValorInt = 0;
            this._txtPresicion.ValorLong = ((long)(0));
            // 
            // _txtPrimeNoins
            // 
            this._txtPrimeNoins.EnterComoTab = false;
            this._txtPrimeNoins.Etiqueta = null;
            this._txtPrimeNoins.Location = new System.Drawing.Point(96, 187);
            this._txtPrimeNoins.Name = "_txtPrimeNoins";
            this._txtPrimeNoins.Size = new System.Drawing.Size(277, 20);
            this._txtPrimeNoins.TabIndex = 13;
            this._txtPrimeNoins.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(20, 190);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(73, 13);
            this.cndcLabel4.TabIndex = 12;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Prime NOINS:";
            // 
            // _rbtnReal
            // 
            this._rbtnReal.AutoSize = true;
            this._rbtnReal.Location = new System.Drawing.Point(126, 31);
            this._rbtnReal.Name = "_rbtnReal";
            this._rbtnReal.Size = new System.Drawing.Size(88, 17);
            this._rbtnReal.TabIndex = 0;
            this._rbtnReal.TablaCampoBD = null;
            this._rbtnReal.TabStop = true;
            this._rbtnReal.Text = "Medidor Real";
            this._rbtnReal.UseVisualStyleBackColor = true;
            // 
            // _rbtnVirtual
            // 
            this._rbtnVirtual.AutoSize = true;
            this._rbtnVirtual.Location = new System.Drawing.Point(238, 31);
            this._rbtnVirtual.Name = "_rbtnVirtual";
            this._rbtnVirtual.Size = new System.Drawing.Size(95, 17);
            this._rbtnVirtual.TabIndex = 1;
            this._rbtnVirtual.TablaCampoBD = null;
            this._rbtnVirtual.TabStop = true;
            this._rbtnVirtual.Text = "Medidor Virtual";
            this._rbtnVirtual.UseVisualStyleBackColor = true;
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox1.Controls.Add(this.cndcTextBox8);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel9);
            this.cndcGroupBox1.Controls.Add(this.cndcTextBox7);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel8);
            this.cndcGroupBox1.Controls.Add(this.cndcTextBox6);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel7);
            this.cndcGroupBox1.Location = new System.Drawing.Point(56, 226);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(413, 84);
            this.cndcGroupBox1.TabIndex = 20;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Software Lectura";
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnVerSoftLect,
            this._btnConfigSoftLect});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(407, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnVerSoftLect
            // 
            this._btnVerSoftLect.Image = ((System.Drawing.Image)(resources.GetObject("_btnVerSoftLect.Image")));
            this._btnVerSoftLect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnVerSoftLect.Name = "_btnVerSoftLect";
            this._btnVerSoftLect.Size = new System.Drawing.Size(43, 22);
            this._btnVerSoftLect.Text = "Ver";
            // 
            // _btnConfigSoftLect
            // 
            this._btnConfigSoftLect.Image = ((System.Drawing.Image)(resources.GetObject("_btnConfigSoftLect.Image")));
            this._btnConfigSoftLect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnConfigSoftLect.Name = "_btnConfigSoftLect";
            this._btnConfigSoftLect.Size = new System.Drawing.Size(78, 22);
            this._btnConfigSoftLect.Text = "Configurar";
            // 
            // cndcTextBox8
            // 
            this.cndcTextBox8.EnterComoTab = false;
            this.cndcTextBox8.Etiqueta = null;
            this.cndcTextBox8.Location = new System.Drawing.Point(236, 57);
            this.cndcTextBox8.Name = "cndcTextBox8";
            this.cndcTextBox8.Size = new System.Drawing.Size(173, 20);
            this.cndcTextBox8.TabIndex = 6;
            this.cndcTextBox8.TablaCampoBD = null;
            // 
            // cndcLabel9
            // 
            this.cndcLabel9.AutoSize = true;
            this.cndcLabel9.Location = new System.Drawing.Point(237, 41);
            this.cndcLabel9.Name = "cndcLabel9";
            this.cndcLabel9.Size = new System.Drawing.Size(86, 13);
            this.cndcLabel9.TabIndex = 5;
            this.cndcLabel9.TablaCampoBD = null;
            this.cndcLabel9.Text = "Nombre Archivo:";
            // 
            // cndcTextBox7
            // 
            this.cndcTextBox7.EnterComoTab = false;
            this.cndcTextBox7.Etiqueta = null;
            this.cndcTextBox7.Location = new System.Drawing.Point(185, 57);
            this.cndcTextBox7.Name = "cndcTextBox7";
            this.cndcTextBox7.Size = new System.Drawing.Size(46, 20);
            this.cndcTextBox7.TabIndex = 4;
            this.cndcTextBox7.TablaCampoBD = null;
            // 
            // cndcLabel8
            // 
            this.cndcLabel8.AutoSize = true;
            this.cndcLabel8.Location = new System.Drawing.Point(186, 41);
            this.cndcLabel8.Name = "cndcLabel8";
            this.cndcLabel8.Size = new System.Drawing.Size(25, 13);
            this.cndcLabel8.TabIndex = 3;
            this.cndcLabel8.TablaCampoBD = null;
            this.cndcLabel8.Text = "Ext.";
            // 
            // cndcTextBox6
            // 
            this.cndcTextBox6.EnterComoTab = false;
            this.cndcTextBox6.Etiqueta = null;
            this.cndcTextBox6.Location = new System.Drawing.Point(6, 57);
            this.cndcTextBox6.Name = "cndcTextBox6";
            this.cndcTextBox6.Size = new System.Drawing.Size(173, 20);
            this.cndcTextBox6.TabIndex = 2;
            this.cndcTextBox6.TablaCampoBD = null;
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Location = new System.Drawing.Point(7, 41);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(52, 13);
            this.cndcLabel7.TabIndex = 1;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Software:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(96, 73);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(354, 44);
            this._txtDescripcion.TabIndex = 5;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // cndcLabel10
            // 
            this.cndcLabel10.AutoSize = true;
            this.cndcLabel10.Location = new System.Drawing.Point(27, 76);
            this.cndcLabel10.Name = "cndcLabel10";
            this.cndcLabel10.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel10.TabIndex = 4;
            this.cndcLabel10.TablaCampoBD = null;
            this.cndcLabel10.Text = "Descripción:";
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(96, 51);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(277, 20);
            this._txtNombre.TabIndex = 3;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel11
            // 
            this.cndcLabel11.AutoSize = true;
            this.cndcLabel11.Location = new System.Drawing.Point(46, 54);
            this.cndcLabel11.Name = "cndcLabel11";
            this.cndcLabel11.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel11.TabIndex = 2;
            this.cndcLabel11.TablaCampoBD = null;
            this.cndcLabel11.Text = "Nombre:";
            // 
            // FormMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 337);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabel10);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this.cndcLabel11);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._rbtnVirtual);
            this.Controls.Add(this._rbtnReal);
            this.Controls.Add(this._txtPrimeNoins);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._txtPresicion);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtModelo);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtMarca);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormMedidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medidor";
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._txtMarca, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._txtModelo, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            this.Controls.SetChildIndex(this._txtPresicion, 0);
            this.Controls.SetChildIndex(this.cndcLabel4, 0);
            this.Controls.SetChildIndex(this._txtPrimeNoins, 0);
            this.Controls.SetChildIndex(this._rbtnReal, 0);
            this.Controls.SetChildIndex(this._rbtnVirtual, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcLabel11, 0);
            this.Controls.SetChildIndex(this._txtNombre, 0);
            this.Controls.SetChildIndex(this.cndcLabel10, 0);
            this.Controls.SetChildIndex(this._txtDescripcion, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtMarca;
        private Controles.CNDCTextBox _txtModelo;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBoxNumerico _txtPresicion;
        private Controles.CNDCTextBox _txtPrimeNoins;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCRadioButton _rbtnReal;
        private Controles.CNDCRadioButton _rbtnVirtual;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCTextBox cndcTextBox8;
        private Controles.CNDCLabel cndcLabel9;
        private Controles.CNDCTextBox cndcTextBox7;
        private Controles.CNDCLabel cndcLabel8;
        private Controles.CNDCTextBox cndcTextBox6;
        private Controles.CNDCLabel cndcLabel7;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnVerSoftLect;
        private System.Windows.Forms.ToolStripButton _btnConfigSoftLect;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel cndcLabel10;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel11;
    }
}