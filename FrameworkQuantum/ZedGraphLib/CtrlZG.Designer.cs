namespace CNDCZedGraphLib
{
    partial class CtrlZG
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
            this._zg = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // _zg
            // 
            this._zg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._zg.Location = new System.Drawing.Point(0, 0);
            this._zg.Name = "_zg";
            this._zg.ScrollGrace = 0D;
            this._zg.ScrollMaxX = 0D;
            this._zg.ScrollMaxY = 0D;
            this._zg.ScrollMaxY2 = 0D;
            this._zg.ScrollMinX = 0D;
            this._zg.ScrollMinY = 0D;
            this._zg.ScrollMinY2 = 0D;
            this._zg.Size = new System.Drawing.Size(526, 299);
            this._zg.TabIndex = 0;
            // 
            // CtrlZG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._zg);
            this.Name = "CtrlZG";
            this.Size = new System.Drawing.Size(526, 299);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl _zg;
    }
}
