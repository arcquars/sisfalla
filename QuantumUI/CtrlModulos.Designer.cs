namespace QuantumUI
{
    partial class CtrlModulos
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
            this._cmbModulos = new Controles.CNDCComboBox();
            this._btnIr = new Controles.CNDCButton();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cndcLabel1.Location = new System.Drawing.Point(0, 0);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(45, 22);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Módulo:";
            this.cndcLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cmbModulos
            // 
            this._cmbModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cmbModulos.EnterComoTab = false;
            this._cmbModulos.Etiqueta = null;
            this._cmbModulos.FormattingEnabled = true;
            this._cmbModulos.Location = new System.Drawing.Point(45, 0);
            this._cmbModulos.Name = "_cmbModulos";
            this._cmbModulos.Size = new System.Drawing.Size(217, 21);
            this._cmbModulos.TabIndex = 1;
            this._cmbModulos.TablaCampoBD = null;
            this._cmbModulos.SelectedIndexChanged += new System.EventHandler(this._cmbModulos_SelectedIndexChanged);
            // 
            // _btnIr
            // 
            this._btnIr.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnIr.Image = global::QuantumUI.Properties.Resources.Refresh;
            this._btnIr.Location = new System.Drawing.Point(262, 0);
            this._btnIr.Name = "_btnIr";
            this._btnIr.Size = new System.Drawing.Size(21, 22);
            this._btnIr.TabIndex = 2;
            this._btnIr.TablaCampoBD = null;
            this._btnIr.UseVisualStyleBackColor = true;
            // 
            // CtrlModulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cmbModulos);
            this.Controls.Add(this._btnIr);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlModulos";
            this.Size = new System.Drawing.Size(283, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cmbModulos;
        private Controles.CNDCButton _btnIr;
    }
}
