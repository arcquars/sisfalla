namespace MedicionComercialUI
{
    partial class FormMigrador
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
            this.label1 = new System.Windows.Forms.Label();
            this._txtArchivo = new System.Windows.Forms.TextBox();
            this._btnExaminar = new System.Windows.Forms.Button();
            this._dgvDatos = new System.Windows.Forms.DataGridView();
            this._btnMigrar = new System.Windows.Forms.Button();
            this._ofdlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo Excel:";
            // 
            // _txtArchivo
            // 
            this._txtArchivo.Location = new System.Drawing.Point(93, 9);
            this._txtArchivo.Name = "_txtArchivo";
            this._txtArchivo.Size = new System.Drawing.Size(541, 20);
            this._txtArchivo.TabIndex = 1;
            // 
            // _btnExaminar
            // 
            this._btnExaminar.Location = new System.Drawing.Point(640, 9);
            this._btnExaminar.Name = "_btnExaminar";
            this._btnExaminar.Size = new System.Drawing.Size(24, 23);
            this._btnExaminar.TabIndex = 2;
            this._btnExaminar.Text = "...";
            this._btnExaminar.UseVisualStyleBackColor = true;
            this._btnExaminar.Click += new System.EventHandler(this._btnExaminar_Click);
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            this._dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDatos.Location = new System.Drawing.Point(2, 38);
            this._dgvDatos.Name = "_dgvDatos";
            this._dgvDatos.ReadOnly = true;
            this._dgvDatos.Size = new System.Drawing.Size(766, 329);
            this._dgvDatos.TabIndex = 3;
            // 
            // _btnMigrar
            // 
            this._btnMigrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMigrar.Location = new System.Drawing.Point(682, 7);
            this._btnMigrar.Name = "_btnMigrar";
            this._btnMigrar.Size = new System.Drawing.Size(75, 23);
            this._btnMigrar.TabIndex = 4;
            this._btnMigrar.Text = "Migrar";
            this._btnMigrar.UseVisualStyleBackColor = true;
            this._btnMigrar.Click += new System.EventHandler(this._btnMigrar_Click);
            // 
            // _ofdlg
            // 
            this._ofdlg.FileName = "openFileDialog1";
            this._ofdlg.Filter = "*.xlsx|*.xlsx";
            this._ofdlg.FileOk += new System.ComponentModel.CancelEventHandler(this._ofdlg_FileOk);
            // 
            // FormMigrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 367);
            this.Controls.Add(this._dgvDatos);
            this.Controls.Add(this._btnMigrar);
            this.Controls.Add(this._btnExaminar);
            this.Controls.Add(this._txtArchivo);
            this.Controls.Add(this.label1);
            this.Name = "FormMigrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtArchivo;
        private System.Windows.Forms.Button _btnExaminar;
        private System.Windows.Forms.DataGridView _dgvDatos;
        private System.Windows.Forms.Button _btnMigrar;
        private System.Windows.Forms.OpenFileDialog _ofdlg;
    }
}

