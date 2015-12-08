namespace ActualizadorModulosCliente
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._lbxModulosActualizar = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lbxModulosActualizar
            // 
            this._lbxModulosActualizar.FormattingEnabled = true;
            this._lbxModulosActualizar.Location = new System.Drawing.Point(17, 29);
            this._lbxModulosActualizar.Name = "_lbxModulosActualizar";
            this._lbxModulosActualizar.Size = new System.Drawing.Size(364, 173);
            this._lbxModulosActualizar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Módulos a actualizar:";
            // 
            // _btnActualizar
            // 
            this._btnActualizar.Location = new System.Drawing.Point(278, 206);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(103, 23);
            this._btnActualizar.TabIndex = 2;
            this._btnActualizar.Text = "Actualizar";
            this._btnActualizar.UseVisualStyleBackColor = true;
            this._btnActualizar.Click += new System.EventHandler(this._btnActualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 243);
            this.Controls.Add(this._btnActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lbxModulosActualizar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox _lbxModulosActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnActualizar;
    }
}

