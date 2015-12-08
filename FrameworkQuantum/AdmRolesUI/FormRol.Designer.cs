namespace AdmRolesUI
{
    partial class FormRol
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
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtDescripcion = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(52, 45);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Nombre:";
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(102, 42);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(289, 20);
            this._txtNombre.TabIndex = 5;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(33, 71);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel2.TabIndex = 6;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Descripcion:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(102, 68);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(289, 74);
            this._txtDescripcion.TabIndex = 7;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // FormRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 186);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtNombre);
            this.Name = "FormRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRol";
            this.Controls.SetChildIndex(this._txtNombre, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._txtDescripcion, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtDescripcion;
    }
}