﻿namespace GeneradorEnumsPorDominios
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
            this.label1 = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this._dgvCategorias = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this._txtNamespace = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar categorias:";
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnOk.Location = new System.Drawing.Point(323, 234);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 2;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "*.cs|*.cs";
            // 
            // _dgvCategorias
            // 
            this._dgvCategorias.AllowUserToAddRows = false;
            this._dgvCategorias.AllowUserToDeleteRows = false;
            this._dgvCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvCategorias.Location = new System.Drawing.Point(8, 28);
            this._dgvCategorias.Name = "_dgvCategorias";
            this._dgvCategorias.Size = new System.Drawing.Size(466, 198);
            this._dgvCategorias.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Namespace:";
            // 
            // _txtNamespace
            // 
            this._txtNamespace.Location = new System.Drawing.Point(85, 236);
            this._txtNamespace.Name = "_txtNamespace";
            this._txtNamespace.Size = new System.Drawing.Size(232, 20);
            this._txtNamespace.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 265);
            this.Controls.Add(this._txtNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._dgvCategorias);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Generador de enumerados para dominios";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView _dgvCategorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtNamespace;
    }
}
