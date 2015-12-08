namespace SISFALLA
{
    partial class CtrlSincronizacion
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
            this._pgBar = new Controles.CNDCProgressBar();
            this._btnVerMensajes = new Controles.CNDCButton();
            this.SuspendLayout();
            // 
            // _pgBar
            // 
            this._pgBar.Location = new System.Drawing.Point(8, 1);
            this._pgBar.MarqueeAnimationSpeed = 300;
            this._pgBar.Name = "_pgBar";
            this._pgBar.Size = new System.Drawing.Size(100, 23);
            this._pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._pgBar.TabIndex = 0;
            this._pgBar.TablaCampoBD = null;
            this._pgBar.Visible = false;
            // 
            // _btnVerMensajes
            // 
            this._btnVerMensajes.Location = new System.Drawing.Point(114, 1);
            this._btnVerMensajes.Name = "_btnVerMensajes";
            this._btnVerMensajes.Size = new System.Drawing.Size(108, 23);
            this._btnVerMensajes.TabIndex = 1;
            this._btnVerMensajes.TablaCampoBD = null;
            this._btnVerMensajes.Text = "Hay mensajes nuevos";
            this._btnVerMensajes.UseVisualStyleBackColor = true;
            this._btnVerMensajes.Visible = false;
            this._btnVerMensajes.Click += new System.EventHandler(this._btnVerMensajes_Click);
            // 
            // CtrlSincronizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnVerMensajes);
            this.Controls.Add(this._pgBar);
            this.Name = "CtrlSincronizacion";
            this.Size = new System.Drawing.Size(236, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCProgressBar _pgBar;
        private Controles.CNDCButton _btnVerMensajes;
    }
}
