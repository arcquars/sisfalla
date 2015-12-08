namespace ComponentesUI
{
    partial class CtrlDescNodo
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
            this.components = new System.ComponentModel.Container();
            this._cmbNodo = new Controles.CNDCComboBox();
            this._txtNombreNodo = new Controles.CNDCTextBox();
            this._txtDescripcionNodo = new Controles.CNDCTextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmbNodo
            // 
            this._cmbNodo.EnterComoTab = false;
            this._cmbNodo.Etiqueta = null;
            this._cmbNodo.FormattingEnabled = true;
            this._cmbNodo.Location = new System.Drawing.Point(3, 3);
            this._cmbNodo.Name = "_cmbNodo";
            this._cmbNodo.Size = new System.Drawing.Size(87, 21);
            this._cmbNodo.TabIndex = 0;
            this._cmbNodo.TablaCampoBD = null;
            this._cmbNodo.SelectedIndexChanged += new System.EventHandler(this._cmbNodo_SelectedIndexChanged);
            // 
            // _txtNombreNodo
            // 
            this._txtNombreNodo.EnterComoTab = false;
            this._txtNombreNodo.Etiqueta = null;
            this._txtNombreNodo.Location = new System.Drawing.Point(96, 3);
            this._txtNombreNodo.Name = "_txtNombreNodo";
            this._txtNombreNodo.Size = new System.Drawing.Size(100, 20);
            this._txtNombreNodo.TabIndex = 1;
            this._txtNombreNodo.TablaCampoBD = null;
            // 
            // _txtDescripcionNodo
            // 
            this._txtDescripcionNodo.EnterComoTab = false;
            this._txtDescripcionNodo.Etiqueta = null;
            this._txtDescripcionNodo.Location = new System.Drawing.Point(202, 3);
            this._txtDescripcionNodo.Name = "_txtDescripcionNodo";
            this._txtDescripcionNodo.Size = new System.Drawing.Size(250, 20);
            this._txtDescripcionNodo.TabIndex = 2;
            this._txtDescripcionNodo.TablaCampoBD = null;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlDescNodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtDescripcionNodo);
            this.Controls.Add(this._txtNombreNodo);
            this.Controls.Add(this._cmbNodo);
            this.Name = "CtrlDescNodo";
            this.Size = new System.Drawing.Size(457, 26);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbNodo;
        private Controles.CNDCTextBox _txtNombreNodo;
        private Controles.CNDCTextBox _txtDescripcionNodo;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}
