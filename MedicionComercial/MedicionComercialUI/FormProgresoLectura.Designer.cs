namespace MedicionComercialUI
{
    partial class FormProgresoLectura
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
            this._pgbar = new Controles.CNDCProgressBar();
            this._btnCancelar = new Controles.CNDCButton();
            this._bkwr = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // _pgbar
            // 
            this._pgbar.Location = new System.Drawing.Point(12, 50);
            this._pgbar.Name = "_pgbar";
            this._pgbar.Size = new System.Drawing.Size(423, 41);
            this._pgbar.TabIndex = 0;
            this._pgbar.TablaCampoBD = null;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(360, 97);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 1;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _bkwr
            // 
            this._bkwr.WorkerReportsProgress = true;
            this._bkwr.WorkerSupportsCancellation = true;
            this._bkwr.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bkwr_DoWork);
            this._bkwr.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._bkwr_ProgressChanged);
            this._bkwr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bkwr_RunWorkerCompleted);
            // 
            // FormProgresoLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 127);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._pgbar);
            this.Name = "FormProgresoLectura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progreso de la lectura";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCProgressBar _pgbar;
        private Controles.CNDCButton _btnCancelar;
        private System.ComponentModel.BackgroundWorker _bkwr;
    }
}