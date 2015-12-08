namespace Controles
{
    partial class CNDCLabelText
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
            this.cndcTextBox1 = new Controles.CNDCTextBox();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.SuspendLayout();
            // 
            // cndcTextBox1
            // 
            this.cndcTextBox1.TablaCampoBD = null;
            this.cndcTextBox1.Location = new System.Drawing.Point(159, 7);
            this.cndcTextBox1.Name = "cndcTextBox1";
            this.cndcTextBox1.Size = new System.Drawing.Size(100, 20);
            this.cndcTextBox1.TabIndex = 0;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(12, 11);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(96, 13);
            this.cndcLabelControl1.TabIndex = 1;
            this.cndcLabelControl1.Text = "cndcLabelControl1";
            // 
            // CNDCLabelText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this.cndcTextBox1);
            this.Name = "CNDCLabelText";
            this.Size = new System.Drawing.Size(268, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CNDCTextBox cndcTextBox1;
        private CNDCLabel cndcLabelControl1;
    }
}
