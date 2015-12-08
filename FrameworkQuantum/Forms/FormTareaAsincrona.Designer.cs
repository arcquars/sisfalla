namespace CNDC.BaseForms
{
    partial class FormTareaAsincrona
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
            this._pgBar = new Controles.CNDCProgressBar();
            this._lblMensaje = new Controles.CNDCLabel();
            this._bgWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // _pgBar
            // 
            this._pgBar.Location = new System.Drawing.Point(15, 44);
            this._pgBar.Name = "_pgBar";
            this._pgBar.Size = new System.Drawing.Size(285, 33);
            this._pgBar.Step = 1;
            this._pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._pgBar.TabIndex = 0;
            this._pgBar.TablaCampoBD = null;
            // 
            // _lblMensaje
            // 
            this._lblMensaje.AutoSize = true;
            this._lblMensaje.Location = new System.Drawing.Point(19, 19);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(62, 13);
            this._lblMensaje.TabIndex = 1;
            this._lblMensaje.TablaCampoBD = null;
            this._lblMensaje.Text = "[Mensaje...]";
            // 
            // _bgWorker
            // 
            this._bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bgWorker_DoWork);
            this._bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bgWorker_RunWorkerCompleted);
            // 
            // FormTareaAsincrona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 97);
            this.ControlBox = false;
            this.Controls.Add(this._lblMensaje);
            this.Controls.Add(this._pgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTareaAsincrona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTareaAsincrona";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCProgressBar _pgBar;
        private Controles.CNDCLabel _lblMensaje;
        private System.ComponentModel.BackgroundWorker _bgWorker;
    }
}