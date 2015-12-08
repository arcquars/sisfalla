namespace Controles
{
    partial class CNDCLabelCombo
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
            this._lbl = new Controles.CNDCLabel();
            this._cmb = new Controles.CNDCComboBox();
            this.SuspendLayout();
            // 
            // cndcLabelControl1
            // 
            this._lbl.AutoSize = true;
            this._lbl.TablaCampoBD = null;
            this._lbl.Location = new System.Drawing.Point(12, 11);
            this._lbl.Name = "cndcLabelControl1";
            this._lbl.Size = new System.Drawing.Size(96, 13);
            this._lbl.TabIndex = 1;
            this._lbl.Text = "cndcLabelControl1";
            // 
            // cndcComboBox1
            // 
            this._cmb.FormattingEnabled = true;
            this._cmb.TablaCampoBD = null;
            this._cmb.Location = new System.Drawing.Point(138, 7);
            this._cmb.Name = "cndcComboBox1";
            this._cmb.Size = new System.Drawing.Size(121, 21);
            this._cmb.TabIndex = 2;
            // 
            // CNDCLabelText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cmb);
            this.Controls.Add(this._lbl);
            this.Name = "CNDCLabelText";
            this.Size = new System.Drawing.Size(268, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CNDCLabel _lbl;
        private CNDCComboBox _cmb;
    }
}
