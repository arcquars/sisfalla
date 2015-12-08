namespace WF_BorradorFallas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnBorrarFallas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnBorrarFallas
            // 
            this._btnBorrarFallas.Location = new System.Drawing.Point(12, 12);
            this._btnBorrarFallas.Name = "_btnBorrarFallas";
            this._btnBorrarFallas.Size = new System.Drawing.Size(349, 23);
            this._btnBorrarFallas.TabIndex = 0;
            this._btnBorrarFallas.Text = "Borrar Fallas";
            this._btnBorrarFallas.UseVisualStyleBackColor = true;
            this._btnBorrarFallas.Click += new System.EventHandler(this._btnBorrarFallas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 169);
            this.Controls.Add(this._btnBorrarFallas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnBorrarFallas;
    }
}

