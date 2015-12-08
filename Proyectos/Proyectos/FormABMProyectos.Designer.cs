namespace Proyectos
{
    partial class FormABMProyectos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tbDatosDelProyecto = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // _tbDatosDelProyecto
            // 
            this._tbDatosDelProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbDatosDelProyecto.Location = new System.Drawing.Point(3, 3);
            this._tbDatosDelProyecto.Name = "_tbDatosDelProyecto";
            this._tbDatosDelProyecto.SelectedIndex = 0;
            this._tbDatosDelProyecto.Size = new System.Drawing.Size(1054, 612);
            this._tbDatosDelProyecto.TabIndex = 0;
            // 
            // FormABMProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 685);
            this.Controls.Add(this._tbDatosDelProyecto);
            this.Name = "FormABMProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro-Edición de Proyectos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tbDatosDelProyecto;
    }
}