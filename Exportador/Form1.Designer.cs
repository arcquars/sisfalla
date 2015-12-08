namespace Exportador
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcTextBox1 = new Controles.CNDCTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cndcButton1 = new Controles.CNDCButton();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(12, 9);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(46, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Archivo:";
            // 
            // cndcTextBox1
            // 
            this.cndcTextBox1.EnterComoTab = false;
            this.cndcTextBox1.Etiqueta = null;
            this.cndcTextBox1.Location = new System.Drawing.Point(64, 6);
            this.cndcTextBox1.Name = "cndcTextBox1";
            this.cndcTextBox1.Size = new System.Drawing.Size(250, 20);
            this.cndcTextBox1.TabIndex = 1;
            this.cndcTextBox1.TablaCampoBD = null;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cndcButton1
            // 
            this.cndcButton1.Location = new System.Drawing.Point(334, 10);
            this.cndcButton1.Name = "cndcButton1";
            this.cndcButton1.Size = new System.Drawing.Size(26, 15);
            this.cndcButton1.TabIndex = 2;
            this.cndcButton1.TablaCampoBD = null;
            this.cndcButton1.Text = "cndcButton1";
            this.cndcButton1.UseVisualStyleBackColor = true;
            this.cndcButton1.Click += new System.EventHandler(this.cndcButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 127);
            this.Controls.Add(this.cndcButton1);
            this.Controls.Add(this.cndcTextBox1);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "Form1";
            this.Text = "ExportarArchivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox cndcTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Controles.CNDCButton cndcButton1;
    }
}

