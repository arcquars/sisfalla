namespace SISFALLA
{
    partial class SplashQuantum
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
            this.cndcPictureBox1 = new Controles.CNDCPictureBox();
            this.cndcProgressBar1 = new Controles.CNDCProgressBar();
            this.cndcLabel1 = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcPictureBox1
            // 
            this.cndcPictureBox1.BackColor = System.Drawing.Color.White;
            this.cndcPictureBox1.Image = global::SISFALLA.Properties.Resources.logo_quantum;
            this.cndcPictureBox1.Location = new System.Drawing.Point(8, 2);
            this.cndcPictureBox1.Name = "cndcPictureBox1";
            this.cndcPictureBox1.Size = new System.Drawing.Size(283, 120);
            this.cndcPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cndcPictureBox1.TabIndex = 0;
            this.cndcPictureBox1.TablaCampoBD = null;
            this.cndcPictureBox1.TabStop = false;
            // 
            // cndcProgressBar1
            // 
            this.cndcProgressBar1.Location = new System.Drawing.Point(104, 126);
            this.cndcProgressBar1.Name = "cndcProgressBar1";
            this.cndcProgressBar1.Size = new System.Drawing.Size(184, 15);
            this.cndcProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cndcProgressBar1.TabIndex = 1;
            this.cndcProgressBar1.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.Location = new System.Drawing.Point(12, 126);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(86, 13);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Conectando...";
            // 
            // SplashQuantum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 147);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcProgressBar1);
            this.Controls.Add(this.cndcPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashQuantum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashQuantum";
            ((System.ComponentModel.ISupportInitialize)(this.cndcPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCPictureBox cndcPictureBox1;
        private Controles.CNDCProgressBar cndcProgressBar1;
        private Controles.CNDCLabel cndcLabel1;
    }
}