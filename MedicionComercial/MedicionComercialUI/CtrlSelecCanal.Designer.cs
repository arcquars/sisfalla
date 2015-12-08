namespace MedicionComercialUI
{
    partial class CtrlSelecCanal
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
            this._cmbCanal = new Controles.CNDCComboBox();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this._txtUnidades = new Controles.CNDCTextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmbCanal
            // 
            this._cmbCanal.Dock = System.Windows.Forms.DockStyle.Left;
            this._cmbCanal.EnterComoTab = false;
            this._cmbCanal.Etiqueta = null;
            this._cmbCanal.FormattingEnabled = true;
            this._cmbCanal.Location = new System.Drawing.Point(0, 0);
            this._cmbCanal.Name = "_cmbCanal";
            this._cmbCanal.Size = new System.Drawing.Size(154, 21);
            this._cmbCanal.TabIndex = 0;
            this._cmbCanal.TablaCampoBD = "P_MC_DEF_INFCANAL.NOMBRE_INFCANAL";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this._txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(154, 0);
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.ReadOnly = true;
            this._txtDescripcion.Size = new System.Drawing.Size(287, 20);
            this._txtDescripcion.TabIndex = 1;
            this._txtDescripcion.TablaCampoBD = "P_MC_DEF_INFCANAL.DESCRIPCION_INFCANAL";
            // 
            // _txtUnidades
            // 
            this._txtUnidades.BackColor = System.Drawing.SystemColors.Window;
            this._txtUnidades.Dock = System.Windows.Forms.DockStyle.Right;
            this._txtUnidades.EnterComoTab = false;
            this._txtUnidades.Etiqueta = null;
            this._txtUnidades.Location = new System.Drawing.Point(441, 0);
            this._txtUnidades.Name = "_txtUnidades";
            this._txtUnidades.ReadOnly = true;
            this._txtUnidades.Size = new System.Drawing.Size(100, 20);
            this._txtUnidades.TabIndex = 2;
            this._txtUnidades.TablaCampoBD = "P_MC_DEF_INFCANAL.UNIDADES";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlSelecCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this._txtUnidades);
            this.Controls.Add(this._cmbCanal);
            this.Name = "CtrlSelecCanal";
            this.Size = new System.Drawing.Size(541, 21);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbCanal;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCTextBox _txtUnidades;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}
