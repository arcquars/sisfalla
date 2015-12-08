namespace SISFALLA
{
    partial class FormEnvioNotif
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtAsunto = new Controles.CNDCTextBox();
            this._txtContenido = new Controles.CNDCTextBox();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnEnviar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(8, 25);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(50, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Asunto:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(8, 73);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(68, 13);
            this.cndcLabel2.TabIndex = 1;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Contenido:";
            // 
            // _txtAsunto
            // 
            this._txtAsunto.EnterComoTab = false;
            this._txtAsunto.Etiqueta = null;
            this._txtAsunto.Location = new System.Drawing.Point(8, 41);
            this._txtAsunto.Name = "_txtAsunto";
            this._txtAsunto.Size = new System.Drawing.Size(433, 20);
            this._txtAsunto.TabIndex = 2;
            this._txtAsunto.TablaCampoBD = null;
            // 
            // _txtContenido
            // 
            this._txtContenido.EnterComoTab = false;
            this._txtContenido.Etiqueta = null;
            this._txtContenido.Location = new System.Drawing.Point(8, 89);
            this._txtContenido.Multiline = true;
            this._txtContenido.Name = "_txtContenido";
            this._txtContenido.Size = new System.Drawing.Size(433, 78);
            this._txtContenido.TabIndex = 3;
            this._txtContenido.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEnviar,
            this._btnCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(461, 25);
            this.cndcToolStrip1.TabIndex = 4;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnEnviar
            // 
            this._btnEnviar.Image = global::SISFALLA.Properties.Resources.email_go;
            this._btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(59, 22);
            this._btnEnviar.Text = "Enviar";
            this._btnEnviar.Click += new System.EventHandler(this._btnEnviar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SISFALLA.Properties.Resources.Clear;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(73, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormEnvioNotif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 170);
            this.ControlBox = false;
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._txtContenido);
            this.Controls.Add(this._txtAsunto);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnvioNotif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envío de Notificación...";
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtAsunto;
        private Controles.CNDCTextBox _txtContenido;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnEnviar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}