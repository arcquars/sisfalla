namespace Proyectos
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctrlPrincipalIzquierda1 = new Proyectos.CtrlPrincipalIzquierda();
            this.ctrlPrincipalTop1 = new Proyectos.CtrlPrincipalTop();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlPrincipalIzquierda1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.ctrlPrincipalTop1);
            this.splitContainer1.Size = new System.Drawing.Size(1281, 816);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 3;
            // 
            // ctrlPrincipalIzquierda1
            // 
            this.ctrlPrincipalIzquierda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrincipalIzquierda1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrincipalIzquierda1.Name = "ctrlPrincipalIzquierda1";
            this.ctrlPrincipalIzquierda1.Size = new System.Drawing.Size(190, 816);
            this.ctrlPrincipalIzquierda1.TabIndex = 0;
            this.ctrlPrincipalIzquierda1.TipoProyectoSeleccionado += new System.EventHandler<Proyectos.TipoProySelecEventArgs>(this.ctrlPrincipalIzquierda1_TipoProyectoSeleccionado);
            // 
            // ctrlPrincipalTop1
            // 
            this.ctrlPrincipalTop1.AutoScroll = true;
            this.ctrlPrincipalTop1.AutoSize = true;
            this.ctrlPrincipalTop1.CtrlIzq = null;
            this.ctrlPrincipalTop1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrincipalTop1.Name = "ctrlPrincipalTop1";
            this.ctrlPrincipalTop1.Size = new System.Drawing.Size(1087, 816);
            this.ctrlPrincipalTop1.TabIndex = 0;
            // 
            // CtrlPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlPrincipal";
            this.Size = new System.Drawing.Size(1281, 816);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CtrlPrincipalIzquierda ctrlPrincipalIzquierda1;
        private CtrlPrincipalTop ctrlPrincipalTop1;
    }
}
