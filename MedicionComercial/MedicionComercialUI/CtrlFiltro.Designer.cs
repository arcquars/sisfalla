namespace MedicionComercialUI
{
    partial class CtrlFiltro
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
            this._chbxFiltroAgente = new Controles.CNDCCheckBox();
            this._chbxFiltroMedidor = new Controles.CNDCCheckBox();
            this._cmbFiltroAgente = new Controles.CNDCComboBox();
            this._txtFiltroMedidor = new Controles.CNDCTextBox();
            this.SuspendLayout();
            // 
            // _chbxFiltroAgente
            // 
            this._chbxFiltroAgente.AutoSize = true;
            this._chbxFiltroAgente.Location = new System.Drawing.Point(2, 25);
            this._chbxFiltroAgente.Name = "_chbxFiltroAgente";
            this._chbxFiltroAgente.Size = new System.Drawing.Size(63, 17);
            this._chbxFiltroAgente.TabIndex = 9;
            this._chbxFiltroAgente.TablaCampoBD = null;
            this._chbxFiltroAgente.Text = "Agente:";
            this._chbxFiltroAgente.UseVisualStyleBackColor = true;
            this._chbxFiltroAgente.CheckedChanged += new System.EventHandler(this._chbxFiltroAgente_CheckedChanged);
            // 
            // _chbxFiltroMedidor
            // 
            this._chbxFiltroMedidor.AutoSize = true;
            this._chbxFiltroMedidor.Location = new System.Drawing.Point(2, 3);
            this._chbxFiltroMedidor.Name = "_chbxFiltroMedidor";
            this._chbxFiltroMedidor.Size = new System.Drawing.Size(67, 17);
            this._chbxFiltroMedidor.TabIndex = 8;
            this._chbxFiltroMedidor.TablaCampoBD = null;
            this._chbxFiltroMedidor.Text = "Medidor:";
            this._chbxFiltroMedidor.UseVisualStyleBackColor = true;
            this._chbxFiltroMedidor.CheckedChanged += new System.EventHandler(this._chbxFiltroMedidor_CheckedChanged);
            // 
            // _cmbFiltroAgente
            // 
            this._cmbFiltroAgente.EnterComoTab = false;
            this._cmbFiltroAgente.Etiqueta = null;
            this._cmbFiltroAgente.FormattingEnabled = true;
            this._cmbFiltroAgente.Location = new System.Drawing.Point(70, 25);
            this._cmbFiltroAgente.Name = "_cmbFiltroAgente";
            this._cmbFiltroAgente.Size = new System.Drawing.Size(223, 21);
            this._cmbFiltroAgente.TabIndex = 7;
            this._cmbFiltroAgente.TablaCampoBD = null;
            this._cmbFiltroAgente.SelectedIndexChanged += new System.EventHandler(this._cmbFiltroAgente_SelectedIndexChanged);
            // 
            // _txtFiltroMedidor
            // 
            this._txtFiltroMedidor.EnterComoTab = false;
            this._txtFiltroMedidor.Etiqueta = null;
            this._txtFiltroMedidor.Location = new System.Drawing.Point(70, 3);
            this._txtFiltroMedidor.Name = "_txtFiltroMedidor";
            this._txtFiltroMedidor.Size = new System.Drawing.Size(121, 20);
            this._txtFiltroMedidor.TabIndex = 6;
            this._txtFiltroMedidor.TablaCampoBD = null;
            this._txtFiltroMedidor.TextChanged += new System.EventHandler(this._txtFiltroMedidor_TextChanged);
            // 
            // CtrlFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._chbxFiltroAgente);
            this.Controls.Add(this._chbxFiltroMedidor);
            this.Controls.Add(this._cmbFiltroAgente);
            this.Controls.Add(this._txtFiltroMedidor);
            this.Name = "CtrlFiltro";
            this.Size = new System.Drawing.Size(295, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCCheckBox _chbxFiltroAgente;
        private Controles.CNDCCheckBox _chbxFiltroMedidor;
        private Controles.CNDCComboBox _cmbFiltroAgente;
        private Controles.CNDCTextBox _txtFiltroMedidor;
    }
}
