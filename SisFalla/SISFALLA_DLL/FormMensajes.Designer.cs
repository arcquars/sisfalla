namespace SISFALLA
{
    partial class FormMensajes
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
            this.ctrlPanelMensajes1 = new SISFALLA.CtrlPanelMensajes();
            this.SuspendLayout();
            // 
            // ctrlPanelMensajes1
            // 
            this.ctrlPanelMensajes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPanelMensajes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanelMensajes1.Name = "ctrlPanelMensajes1";
            this.ctrlPanelMensajes1.Size = new System.Drawing.Size(567, 252);
            this.ctrlPanelMensajes1.TabIndex = 0;
            // 
            // FormMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 252);
            this.Controls.Add(this.ctrlPanelMensajes1);
            this.Name = "FormMensajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensajes";
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlPanelMensajes ctrlPanelMensajes1;
    }
}