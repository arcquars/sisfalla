namespace CNDC.BaseForms
{
    partial class EnviarBaseForm
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
            this.components = new System.ComponentModel.Container();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnEnviar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._toolStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEnviar,
            this._btnCancelar});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(670, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _btnEnviar
            // 
            this._btnEnviar.Image = global::CNDC.BaseForms.Properties.Resources.Refresh;
            this._btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(59, 22);
            this._btnEnviar.Text = "Enviar";
            this._btnEnviar.Click += new System.EventHandler(this._btnEnviar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::CNDC.BaseForms.Properties.Resources.cancel;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(73, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblMessage});
            this._statusStrip.Location = new System.Drawing.Point(0, 408);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(670, 22);
            this._statusStrip.TabIndex = 1;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _lblMessage
            // 
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(58, 17);
            this._lblMessage.Text = "Messages";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // EnviarBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(670, 430);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._toolStrip);
            this.Name = "EnviarBaseForm";
            this.Text = "ABMBaseForm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _lblMessage;
        private System.Windows.Forms.ToolStripButton _btnEnviar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}