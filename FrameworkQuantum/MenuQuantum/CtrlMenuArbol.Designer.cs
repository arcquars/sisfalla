namespace MenuQuantum
{
    partial class CtrlMenuArbol
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
            this._tvwMenu = new Controles.CNDCTreeView();
            this.SuspendLayout();
            // 
            // _tvwMenu
            // 
            this._tvwMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tvwMenu.Location = new System.Drawing.Point(0, 0);
            this._tvwMenu.Name = "_tvwMenu";
            this._tvwMenu.Size = new System.Drawing.Size(227, 514);
            this._tvwMenu.TabIndex = 0;
            this._tvwMenu.TablaCampoBD = null;
            this._tvwMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvwMenu_NodeMouseClick);
            // 
            // CtrlMenuArbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tvwMenu);
            this.Name = "CtrlMenuArbol";
            this.Size = new System.Drawing.Size(227, 514);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCTreeView _tvwMenu;
    }
}
