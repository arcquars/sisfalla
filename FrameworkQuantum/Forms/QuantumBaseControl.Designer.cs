namespace CNDC.BaseForms
{
    partial class QuantumBaseControl
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
            this._helpProvider = new System.Windows.Forms.HelpProvider();
            this._toolTip = new Controles.CNDCToolTip();
            this.SuspendLayout();
            // 
            // _toolTip
            // 
            this._toolTip.TablaCampoBD = null;
            // 
            // QuantumBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "QuantumBaseControl";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.HelpProvider _helpProvider;
        protected Controles.CNDCToolTip _toolTip;
    }
}
