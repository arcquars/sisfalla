namespace DemandasUI
{
    partial class CtrlPrincipal
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
            this.ctrlMenuArbol1 = new MenuQuantum.CtrlMenuArbol();
            this.SuspendLayout();
            // 
            // ctrlMenuArbol1
            // 
            this.ctrlMenuArbol1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlMenuArbol1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMenuArbol1.Name = "ctrlMenuArbol1";
            this.ctrlMenuArbol1.Padre = null;
            this.ctrlMenuArbol1.Size = new System.Drawing.Size(248, 453);
            this.ctrlMenuArbol1.TabIndex = 0;
            // 
            // CtrlPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlMenuArbol1);
            this.Name = "CtrlPrincipal";
            this.Size = new System.Drawing.Size(718, 453);
            this.ResumeLayout(false);

        }

        #endregion

        private MenuQuantum.CtrlMenuArbol ctrlMenuArbol1;



    }
}
