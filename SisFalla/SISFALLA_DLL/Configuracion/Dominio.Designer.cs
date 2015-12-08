namespace SISFALLA
{
    partial class Dominio
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
            this.cndcTabControl1 = new Controles.CNDCTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlDominio1 = new SISFALLA.CtrlDominio();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlConfiguracion1 = new SISFALLA.CtrlConfiguracion();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cndcTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcTabControl1
            // 
            this.cndcTabControl1.Controls.Add(this.tabPage1);
            this.cndcTabControl1.Controls.Add(this.tabPage2);
            this.cndcTabControl1.Controls.Add(this.tabPage3);
            this.cndcTabControl1.Location = new System.Drawing.Point(6, 2);
            this.cndcTabControl1.Name = "cndcTabControl1";
            this.cndcTabControl1.SelectedIndex = 0;
            this.cndcTabControl1.Size = new System.Drawing.Size(892, 440);
            this.cndcTabControl1.TabIndex = 0;
            this.cndcTabControl1.TablaCampoBD = null;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlDominio1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(884, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dominios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlDominio1
            // 
            this.ctrlDominio1.Location = new System.Drawing.Point(3, 6);
            this.ctrlDominio1.Name = "ctrlDominio1";
            this.ctrlDominio1.Size = new System.Drawing.Size(875, 307);
            this.ctrlDominio1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlConfiguracion1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(884, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuraciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlConfiguracion1
            // 
            this.ctrlConfiguracion1.Location = new System.Drawing.Point(13, 10);
            this.ctrlConfiguracion1.Name = "ctrlConfiguracion1";
            this.ctrlConfiguracion1.Size = new System.Drawing.Size(853, 400);
            this.ctrlConfiguracion1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(884, 414);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Orden Menús";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Dominio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(906, 445);
            this.Controls.Add(this.cndcTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 378);
            this.Name = "Dominio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuraciones";
            this.cndcTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCTabControl cndcTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlDominio ctrlDominio1;
        private CtrlConfiguracion ctrlConfiguracion1;
        private System.Windows.Forms.TabPage tabPage3;

    }
}