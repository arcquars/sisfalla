namespace MedicionComercialUI
{
    partial class FormRMedidorFormato
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
            this._cmbFormato = new Controles.CNDCComboBox();
            this._txtNombreArchivo = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._chbxContieneFinIntervalo = new Controles.CNDCCheckBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._cmbMedidor = new Controles.CNDCComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(113, 69);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(48, 13);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Formato:";
            // 
            // _cmbFormato
            // 
            this._cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFormato.EnterComoTab = false;
            this._cmbFormato.Etiqueta = null;
            this._cmbFormato.FormattingEnabled = true;
            this._cmbFormato.Location = new System.Drawing.Point(167, 66);
            this._cmbFormato.Name = "_cmbFormato";
            this._cmbFormato.Size = new System.Drawing.Size(199, 21);
            this._cmbFormato.TabIndex = 3;
            this._cmbFormato.TablaCampoBD = "F_MC_RMEDIDOR_FTO.PK_COD_FORMATO";
            // 
            // _txtNombreArchivo
            // 
            this._txtNombreArchivo.EnterComoTab = false;
            this._txtNombreArchivo.Etiqueta = null;
            this._txtNombreArchivo.Location = new System.Drawing.Point(167, 93);
            this._txtNombreArchivo.Name = "_txtNombreArchivo";
            this._txtNombreArchivo.Size = new System.Drawing.Size(199, 20);
            this._txtNombreArchivo.TabIndex = 5;
            this._txtNombreArchivo.TablaCampoBD = "F_MC_RMEDIDOR_FTO.NOMBRE_ARCHIVO";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(75, 96);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(86, 13);
            this.cndcLabel2.TabIndex = 4;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nombre Archivo:";
            // 
            // _chbxContieneFinIntervalo
            // 
            this._chbxContieneFinIntervalo.AutoSize = true;
            this._chbxContieneFinIntervalo.Location = new System.Drawing.Point(167, 119);
            this._chbxContieneFinIntervalo.Name = "_chbxContieneFinIntervalo";
            this._chbxContieneFinIntervalo.Size = new System.Drawing.Size(143, 17);
            this._chbxContieneFinIntervalo.TabIndex = 6;
            this._chbxContieneFinIntervalo.TablaCampoBD = null;
            this._chbxContieneFinIntervalo.Text = "Contiene fin de intervalo.";
            this._chbxContieneFinIntervalo.UseVisualStyleBackColor = true;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(113, 43);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(48, 13);
            this.cndcLabel3.TabIndex = 0;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Medidor:";
            // 
            // _cmbMedidor
            // 
            this._cmbMedidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbMedidor.EnterComoTab = false;
            this._cmbMedidor.Etiqueta = null;
            this._cmbMedidor.FormattingEnabled = true;
            this._cmbMedidor.Location = new System.Drawing.Point(167, 40);
            this._cmbMedidor.Name = "_cmbMedidor";
            this._cmbMedidor.Size = new System.Drawing.Size(199, 21);
            this._cmbMedidor.TabIndex = 1;
            this._cmbMedidor.TablaCampoBD = "F_MC_RMEDIDOR_FTO.PK_COD_FORMATO";
            // 
            // FormRMedidorFormato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 163);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._cmbMedidor);
            this.Controls.Add(this._chbxContieneFinIntervalo);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._cmbFormato);
            this.Controls.Add(this._txtNombreArchivo);
            this.Name = "FormRMedidorFormato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRMedidorFormato";
            this.Controls.SetChildIndex(this._txtNombreArchivo, 0);
            this.Controls.SetChildIndex(this._cmbFormato, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._chbxContieneFinIntervalo, 0);
            this.Controls.SetChildIndex(this._cmbMedidor, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cmbFormato;
        private Controles.CNDCTextBox _txtNombreArchivo;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCCheckBox _chbxContieneFinIntervalo;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCComboBox _cmbMedidor;
    }
}