namespace SISFALLA
{
    partial class FormDetalleBorradoRegFalla
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtMotivo = new Controles.CNDCTextBox();
            this._txtUsuario = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(82, 34);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(46, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Usuario:";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(33, 44);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(42, 13);
            this.cndcLabel3.TabIndex = 2;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Motivo:";
            // 
            // _txtMotivo
            // 
            this._txtMotivo.EnterComoTab = false;
            this._txtMotivo.Etiqueta = null;
            this._txtMotivo.Location = new System.Drawing.Point(31, 60);
            this._txtMotivo.Multiline = true;
            this._txtMotivo.Name = "_txtMotivo";
            this._txtMotivo.Size = new System.Drawing.Size(351, 127);
            this._txtMotivo.TabIndex = 3;
            this._txtMotivo.TablaCampoBD = null;
            // 
            // _txtUsuario
            // 
            this._txtUsuario.EnterComoTab = false;
            this._txtUsuario.Etiqueta = null;
            this._txtUsuario.Location = new System.Drawing.Point(131, 31);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.ReadOnly = true;
            this._txtUsuario.Size = new System.Drawing.Size(251, 20);
            this._txtUsuario.TabIndex = 4;
            this._txtUsuario.TablaCampoBD = null;
            // 
            // FormDetalleBorradoRegFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 226);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtMotivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDetalleBorradoRegFalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Borrado";
            this.Load += new System.EventHandler(this.FormDetalleBorradoRegFalla_Load);
            this.Controls.SetChildIndex(this._txtMotivo, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._txtUsuario, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtMotivo;
        private Controles.CNDCTextBox _txtUsuario;
    }
}