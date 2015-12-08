namespace SISFALLA.Informe
{
    partial class AnalisisFalla
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
            this._cbxAgente = new Controles.CNDCComboBox();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._txtCodigoFalla = new Controles.CNDCTextBox();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._txtDesconexionde = new Controles.CNDCTextBox();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._txtAnalisisCausa = new Controles.CNDCTextBox();
            this.cndcLabelControl5 = new Controles.CNDCLabel();
            this._lblArchivoAnalisisFalla = new Controles.CNDCLabel();
            this._btnAdjuntarAnalisis = new Controles.CNDCButton();
            this._lblAdjuntarAnalisis = new Controles.CNDCLabel();
            this.cndcRichTextBox1 = new Controles.CNDCRichTextBox();
            this.cndcGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbxAgente
            // 
            this._cbxAgente.FormattingEnabled = true;
            this._cbxAgente.TablaCampoBD = null;
            this._cbxAgente.Location = new System.Drawing.Point(432, 41);
            this._cbxAgente.Name = "_cbxAgente";
            this._cbxAgente.Size = new System.Drawing.Size(156, 21);
            this._cbxAgente.TabIndex = 118;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(303, 43);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(123, 13);
            this.cndcLabelControl1.TabIndex = 117;
            this.cndcLabelControl1.Text = "Donde se activo EDAC :";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Location = new System.Drawing.Point(100, 43);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(83, 13);
            this.cndcLabelControl2.TabIndex = 119;
            this.cndcLabelControl2.Text = "Codigo de falla :";
            // 
            // _txtCodigoFalla
            // 
            this._txtCodigoFalla.TablaCampoBD = null;
            this._txtCodigoFalla.Location = new System.Drawing.Point(189, 40);
            this._txtCodigoFalla.Name = "_txtCodigoFalla";
            this._txtCodigoFalla.Size = new System.Drawing.Size(82, 20);
            this._txtCodigoFalla.TabIndex = 120;
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.cndcGroupBox2.Controls.Add(this.cndcRichTextBox1);
            this.cndcGroupBox2.Controls.Add(this._txtDesconexionde);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl4);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl3);
            this.cndcGroupBox2.Controls.Add(this._txtAnalisisCausa);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl5);
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.Location = new System.Drawing.Point(23, 136);
            this.cndcGroupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cndcGroupBox2.Size = new System.Drawing.Size(657, 279);
            this.cndcGroupBox2.TabIndex = 121;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "ANALISIS DE FALLA";
            // 
            // _txtDesconexionde
            // 
            this._txtDesconexionde.TablaCampoBD = null;
            this._txtDesconexionde.Location = new System.Drawing.Point(115, 18);
            this._txtDesconexionde.Name = "_txtDesconexionde";
            this._txtDesconexionde.Size = new System.Drawing.Size(189, 20);
            this._txtDesconexionde.TabIndex = 30;
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Location = new System.Drawing.Point(18, 17);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(91, 16);
            this.cndcLabelControl4.TabIndex = 29;
            this.cndcLabelControl4.Text = "Desconexión de :";
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Location = new System.Drawing.Point(325, 17);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(45, 16);
            this.cndcLabelControl3.TabIndex = 28;
            this.cndcLabelControl3.Text = "Causa :";
            // 
            // _txtAnalisisCausa
            // 
            this._txtAnalisisCausa.TablaCampoBD = null;
            this._txtAnalisisCausa.Location = new System.Drawing.Point(374, 16);
            this._txtAnalisisCausa.Multiline = true;
            this._txtAnalisisCausa.Name = "_txtAnalisisCausa";
            this._txtAnalisisCausa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtAnalisisCausa.Size = new System.Drawing.Size(170, 48);
            this._txtAnalisisCausa.TabIndex = 27;
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.AutoSize = true;
            this.cndcLabelControl5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl5.TablaCampoBD = null;
            this.cndcLabelControl5.Location = new System.Drawing.Point(11, 82);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(85, 16);
            this.cndcLabelControl5.TabIndex = 26;
            this.cndcLabelControl5.Text = "Observaciones :";
            // 
            // _lblArchivoAnalisisFalla
            // 
            this._lblArchivoAnalisisFalla.AutoSize = true;
            this._lblArchivoAnalisisFalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblArchivoAnalisisFalla.TablaCampoBD = null;
            this._lblArchivoAnalisisFalla.Location = new System.Drawing.Point(347, 105);
            this._lblArchivoAnalisisFalla.Name = "_lblArchivoAnalisisFalla";
            this._lblArchivoAnalisisFalla.Size = new System.Drawing.Size(54, 13);
            this._lblArchivoAnalisisFalla.TabIndex = 124;
            this._lblArchivoAnalisisFalla.Text = "Ninguno";
            // 
            // _btnAdjuntarAnalisis
            // 
            this._btnAdjuntarAnalisis.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._btnAdjuntarAnalisis.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAdjuntarAnalisis.TablaCampoBD = null;
            this._btnAdjuntarAnalisis.Location = new System.Drawing.Point(344, 74);
            this._btnAdjuntarAnalisis.Name = "_btnAdjuntarAnalisis";
            this._btnAdjuntarAnalisis.Size = new System.Drawing.Size(144, 23);
            this._btnAdjuntarAnalisis.TabIndex = 123;
            this._btnAdjuntarAnalisis.Text = "Elegir Analisis de Falla";
            this._btnAdjuntarAnalisis.UseVisualStyleBackColor = false;
            this._btnAdjuntarAnalisis.Click += new System.EventHandler(this._btnAdjuntarAnalisis_Click);
            // 
            // _lblAdjuntarAnalisis
            // 
            this._lblAdjuntarAnalisis.AutoSize = true;
            this._lblAdjuntarAnalisis.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAdjuntarAnalisis.TablaCampoBD = null;
            this._lblAdjuntarAnalisis.Location = new System.Drawing.Point(162, 77);
            this._lblAdjuntarAnalisis.Name = "_lblAdjuntarAnalisis";
            this._lblAdjuntarAnalisis.Size = new System.Drawing.Size(165, 16);
            this._lblAdjuntarAnalisis.TabIndex = 122;
            this._lblAdjuntarAnalisis.Text = "Adjuntar Analisis de Falla (PDF) :";
            // 
            // cndcRichTextBox1
            // 
            this.cndcRichTextBox1.TablaCampoBD = null;
            this.cndcRichTextBox1.Location = new System.Drawing.Point(102, 82);
            this.cndcRichTextBox1.Name = "cndcRichTextBox1";
            this.cndcRichTextBox1.Size = new System.Drawing.Size(504, 180);
            this.cndcRichTextBox1.TabIndex = 31;
            this.cndcRichTextBox1.Text = "";
            // 
            // AnalisisFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 455);
            this.Controls.Add(this._lblArchivoAnalisisFalla);
            this.Controls.Add(this._btnAdjuntarAnalisis);
            this.Controls.Add(this._lblAdjuntarAnalisis);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this._txtCodigoFalla);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this._cbxAgente);
            this.Controls.Add(this.cndcLabelControl1);
            this.Name = "AnalisisFalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisis de Informe de Falla";
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this._cbxAgente, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl2, 0);
            this.Controls.SetChildIndex(this._txtCodigoFalla, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.Controls.SetChildIndex(this._lblAdjuntarAnalisis, 0);
            this.Controls.SetChildIndex(this._btnAdjuntarAnalisis, 0);
            this.Controls.SetChildIndex(this._lblArchivoAnalisisFalla, 0);
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cbxAgente;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCTextBox _txtCodigoFalla;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCTextBox _txtDesconexionde;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCTextBox _txtAnalisisCausa;
        private Controles.CNDCLabel cndcLabelControl5;
        private Controles.CNDCLabel _lblArchivoAnalisisFalla;
        private Controles.CNDCButton _btnAdjuntarAnalisis;
        private Controles.CNDCLabel _lblAdjuntarAnalisis;
        private Controles.CNDCRichTextBox cndcRichTextBox1;
    }
}