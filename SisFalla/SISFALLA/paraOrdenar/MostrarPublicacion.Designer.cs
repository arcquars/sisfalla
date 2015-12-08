namespace SISFALLA
{
    partial class MostrarPublicacion
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
            this._btnPublicarWeb = new Controles.CNDCButton();
            this._btnEnviarWeb = new Controles.CNDCButton();
            this.SuspendLayout();
            // 
            // _btnPublicarWeb
            // 
            this._btnPublicarWeb.Location = new System.Drawing.Point(298, 87);
            this._btnPublicarWeb.Name = "_btnPublicarWeb";
            this._btnPublicarWeb.Size = new System.Drawing.Size(174, 38);
            this._btnPublicarWeb.TabIndex = 0;
            this._btnPublicarWeb.TablaCampoBD = null;
            this._btnPublicarWeb.Tag = "copiar";
            this._btnPublicarWeb.Text = "Publicar en el sitio Web";
            this._btnPublicarWeb.UseVisualStyleBackColor = true;
            this._btnPublicarWeb.Click += new System.EventHandler(this._btnPublicarWeb_Click);
            // 
            // _btnEnviarWeb
            // 
            this._btnEnviarWeb.Location = new System.Drawing.Point(119, 87);
            this._btnEnviarWeb.Name = "_btnEnviarWeb";
            this._btnEnviarWeb.Size = new System.Drawing.Size(174, 38);
            this._btnEnviarWeb.TabIndex = 1;
            this._btnEnviarWeb.TablaCampoBD = null;
            this._btnEnviarWeb.Tag = "copiar";
            this._btnEnviarWeb.Text = "Copiar al sitio Web";
            this._btnEnviarWeb.UseVisualStyleBackColor = true;
            this._btnEnviarWeb.Click += new System.EventHandler(this._btnEnviarWeb_Click);
            // 
            // MostrarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 136);
            this.Controls.Add(this._btnEnviarWeb);
            this.Controls.Add(this._btnPublicarWeb);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(581, 170);
            this.Name = "MostrarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicador Web";
            this.Load += new System.EventHandler(this.MostrarPublicacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCButton _btnPublicarWeb;
        private Controles.CNDCButton _btnEnviarWeb;
    }
}