namespace WF_EstresServicioSisFalla
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlEnvioInforme1 = new WF_EstresServicioSisFalla.CtrlEnvioInforme();
            this.SuspendLayout();
            // 
            // ctrlEnvioInforme1
            // 
            this.ctrlEnvioInforme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEnvioInforme1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEnvioInforme1.Name = "ctrlEnvioInforme1";
            this.ctrlEnvioInforme1.PkCodPersona = ((long)(0));
            this.ctrlEnvioInforme1.Size = new System.Drawing.Size(801, 387);
            this.ctrlEnvioInforme1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 387);
            this.Controls.Add(this.ctrlEnvioInforme1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlEnvioInforme ctrlEnvioInforme1;
    }
}

