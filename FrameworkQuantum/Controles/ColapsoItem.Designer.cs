namespace Controles
{
    partial class ColapsoItem
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cndcCheckBox1 = new Controles.CNDCCheckBox();
            this.cndcRadioButton1 = new Controles.CNDCRadioButton();
            this.cndcRadioButton2 = new Controles.CNDCRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cndcCheckBox1
            // 
            this.cndcCheckBox1.AutoSize = true;
            this.cndcCheckBox1.TablaCampoBD = null;
            this.cndcCheckBox1.Location = new System.Drawing.Point(3, 3);
            this.cndcCheckBox1.Name = "cndcCheckBox1";
            this.cndcCheckBox1.Size = new System.Drawing.Size(15, 14);
            this.cndcCheckBox1.TabIndex = 0;
            this.cndcCheckBox1.UseVisualStyleBackColor = true;
            this.cndcCheckBox1.CheckedChanged += new System.EventHandler(this.cndcCheckBox1_CheckedChanged);
            // 
            // cndcRadioButton1
            // 
            this.cndcRadioButton1.AutoSize = true;
            this.cndcRadioButton1.TablaCampoBD = null;
            this.cndcRadioButton1.Location = new System.Drawing.Point(134, 0);
            this.cndcRadioButton1.Name = "cndcRadioButton1";
            this.cndcRadioButton1.Size = new System.Drawing.Size(57, 17);
            this.cndcRadioButton1.TabIndex = 1;
            this.cndcRadioButton1.TabStop = true;
            this.cndcRadioButton1.Text = "Parcial";
            this.cndcRadioButton1.UseVisualStyleBackColor = true;
            // 
            // cndcRadioButton2
            // 
            this.cndcRadioButton2.AutoSize = true;
            this.cndcRadioButton2.TablaCampoBD = null;
            this.cndcRadioButton2.Location = new System.Drawing.Point(254, 0);
            this.cndcRadioButton2.Name = "cndcRadioButton2";
            this.cndcRadioButton2.Size = new System.Drawing.Size(49, 17);
            this.cndcRadioButton2.TabIndex = 2;
            this.cndcRadioButton2.TabStop = true;
            this.cndcRadioButton2.Text = "Total";
            this.cndcRadioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // ColapsoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cndcRadioButton2);
            this.Controls.Add(this.cndcRadioButton1);
            this.Controls.Add(this.cndcCheckBox1);
            this.Name = "ColapsoItem";
            this.Size = new System.Drawing.Size(386, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCCheckBox cndcCheckBox1;
        private Controles.CNDCRadioButton cndcRadioButton1;
        private Controles.CNDCRadioButton cndcRadioButton2;
        private System.Windows.Forms.Label label1;
    }
}
