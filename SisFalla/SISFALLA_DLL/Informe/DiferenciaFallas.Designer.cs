namespace SISFALLA.Informe
{
    partial class DiferenciaFallas
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
            this._btnComparar = new Controles.CNDCButton();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._cbxFiltroInfFinal = new Controles.CNDCComboBox();
            this._lblTOperacionApe = new Controles.CNDCLabel();
            this.cndcGroupBox4 = new Controles.CNDCGroupBox();
            this._cbxFiltroInfPreliminar = new Controles.CNDCComboBox();
            this.LblTOpeCierre = new Controles.CNDCLabel();
            this._txtContenidoInfFinal = new Controles.CNDCTextBox();
            this._txtContenidoInfPremilinar = new Controles.CNDCTextBox();
            this._cbxAgente = new Controles.CNDCComboBox();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._txtCodigoFalla = new Controles.CNDCTextBox();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnComparar
            // 
            this._btnComparar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._btnComparar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnComparar.TablaCampoBD = null;
            this._btnComparar.Location = new System.Drawing.Point(519, 38);
            this._btnComparar.Name = "_btnComparar";
            this._btnComparar.Size = new System.Drawing.Size(110, 23);
            this._btnComparar.TabIndex = 3;
            this._btnComparar.Text = "Comparar :";
            this._btnComparar.UseVisualStyleBackColor = false;
            this._btnComparar.Click += new System.EventHandler(this._btnComponente_Click);
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtContenidoInfFinal);
            this.cndcGroupBox1.Controls.Add(this._cbxFiltroInfFinal);
            this.cndcGroupBox1.Controls.Add(this._lblTOperacionApe);
            this.cndcGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.Location = new System.Drawing.Point(45, 82);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(310, 376);
            this.cndcGroupBox1.TabIndex = 11;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Informe Final  :";
            // 
            // _cbxFiltroInfFinal
            // 
            this._cbxFiltroInfFinal.FormattingEnabled = true;
            this._cbxFiltroInfFinal.TablaCampoBD = null;
            this._cbxFiltroInfFinal.Location = new System.Drawing.Point(148, 22);
            this._cbxFiltroInfFinal.Name = "_cbxFiltroInfFinal";
            this._cbxFiltroInfFinal.Size = new System.Drawing.Size(156, 21);
            this._cbxFiltroInfFinal.TabIndex = 115;
            // 
            // _lblTOperacionApe
            // 
            this._lblTOperacionApe.AutoSize = true;
            this._lblTOperacionApe.TablaCampoBD = null;
            this._lblTOperacionApe.Location = new System.Drawing.Point(20, 25);
            this._lblTOperacionApe.Name = "_lblTOperacionApe";
            this._lblTOperacionApe.Size = new System.Drawing.Size(90, 13);
            this._lblTOperacionApe.TabIndex = 114;
            this._lblTOperacionApe.Text = "Tipo de Filtro :";
            // 
            // cndcGroupBox4
            // 
            this.cndcGroupBox4.Controls.Add(this._txtContenidoInfPremilinar);
            this.cndcGroupBox4.Controls.Add(this._cbxFiltroInfPreliminar);
            this.cndcGroupBox4.Controls.Add(this.LblTOpeCierre);
            this.cndcGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox4.TablaCampoBD = null;
            this.cndcGroupBox4.Location = new System.Drawing.Point(382, 81);
            this.cndcGroupBox4.Name = "cndcGroupBox4";
            this.cndcGroupBox4.Size = new System.Drawing.Size(302, 377);
            this.cndcGroupBox4.TabIndex = 113;
            this.cndcGroupBox4.TabStop = false;
            this.cndcGroupBox4.Text = "Informe Preliminar :";
            // 
            // _cbxFiltroInfPreliminar
            // 
            this._cbxFiltroInfPreliminar.FormattingEnabled = true;
            this._cbxFiltroInfPreliminar.TablaCampoBD = null;
            this._cbxFiltroInfPreliminar.Location = new System.Drawing.Point(148, 22);
            this._cbxFiltroInfPreliminar.Name = "_cbxFiltroInfPreliminar";
            this._cbxFiltroInfPreliminar.Size = new System.Drawing.Size(148, 21);
            this._cbxFiltroInfPreliminar.TabIndex = 115;
            // 
            // LblTOpeCierre
            // 
            this.LblTOpeCierre.AutoSize = true;
            this.LblTOpeCierre.TablaCampoBD = null;
            this.LblTOpeCierre.Location = new System.Drawing.Point(22, 23);
            this.LblTOpeCierre.Name = "LblTOpeCierre";
            this.LblTOpeCierre.Size = new System.Drawing.Size(90, 13);
            this.LblTOpeCierre.TabIndex = 114;
            this.LblTOpeCierre.Text = "Tipo de Filtro :";
            // 
            // _txtContenidoInfFinal
            // 
            this._txtContenidoInfFinal.TablaCampoBD = null;
            this._txtContenidoInfFinal.Location = new System.Drawing.Point(23, 60);
            this._txtContenidoInfFinal.Multiline = true;
            this._txtContenidoInfFinal.Name = "_txtContenidoInfFinal";
            this._txtContenidoInfFinal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtContenidoInfFinal.Size = new System.Drawing.Size(273, 310);
            this._txtContenidoInfFinal.TabIndex = 116;
            // 
            // _txtContenidoInfPremilinar
            // 
            this._txtContenidoInfPremilinar.TablaCampoBD = null;
            this._txtContenidoInfPremilinar.Location = new System.Drawing.Point(12, 61);
            this._txtContenidoInfPremilinar.Multiline = true;
            this._txtContenidoInfPremilinar.Name = "_txtContenidoInfPremilinar";
            this._txtContenidoInfPremilinar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtContenidoInfPremilinar.Size = new System.Drawing.Size(273, 310);
            this._txtContenidoInfPremilinar.TabIndex = 117;
            // 
            // _cbxAgente
            // 
            this._cbxAgente.FormattingEnabled = true;
            this._cbxAgente.TablaCampoBD = null;
            this._cbxAgente.Location = new System.Drawing.Point(316, 40);
            this._cbxAgente.Name = "_cbxAgente";
            this._cbxAgente.Size = new System.Drawing.Size(156, 21);
            this._cbxAgente.TabIndex = 118;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(263, 44);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(47, 13);
            this.cndcLabelControl1.TabIndex = 117;
            this.cndcLabelControl1.Text = "Agente :";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Location = new System.Drawing.Point(56, 43);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(83, 13);
            this.cndcLabelControl2.TabIndex = 119;
            this.cndcLabelControl2.Text = "Codigo de falla :";
            // 
            // _txtCodigoFalla
            // 
            this._txtCodigoFalla.TablaCampoBD = null;
            this._txtCodigoFalla.Location = new System.Drawing.Point(146, 40);
            this._txtCodigoFalla.Name = "_txtCodigoFalla";
            this._txtCodigoFalla.Size = new System.Drawing.Size(82, 20);
            this._txtCodigoFalla.TabIndex = 120;
            // 
            // DiferenciaFallas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 483);
            this.Controls.Add(this._txtCodigoFalla);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this._cbxAgente);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this.cndcGroupBox4);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._btnComparar);
            this.Name = "DiferenciaFallas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diferencias en el Informe de Falla";
            this.Controls.SetChildIndex(this._btnComparar, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox4, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this._cbxAgente, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl2, 0);
            this.Controls.SetChildIndex(this._txtCodigoFalla, 0);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcGroupBox4.ResumeLayout(false);
            this.cndcGroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCButton _btnComparar;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCComboBox _cbxFiltroInfFinal;
        private Controles.CNDCLabel _lblTOperacionApe;
        private Controles.CNDCGroupBox cndcGroupBox4;
        private Controles.CNDCComboBox _cbxFiltroInfPreliminar;
        private Controles.CNDCLabel LblTOpeCierre;
        private Controles.CNDCTextBox _txtContenidoInfFinal;
        private Controles.CNDCTextBox _txtContenidoInfPremilinar;
        private Controles.CNDCComboBox _cbxAgente;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCTextBox _txtCodigoFalla;
    }
}