namespace MedicionComercialUI
{
    partial class FormConfigSoft
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
            this.cndcComboBox1 = new Controles.CNDCComboBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcDateTimePicker1 = new Controles.CNDCDateTimePicker();
            this.cndcCheckBox1 = new Controles.CNDCCheckBox();
            this.cndcDateTimePicker2 = new Controles.CNDCDateTimePicker();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this.cndcTextBox1 = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(142, 39);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(52, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Software:";
            // 
            // cndcComboBox1
            // 
            this.cndcComboBox1.EnterComoTab = false;
            this.cndcComboBox1.Etiqueta = null;
            this.cndcComboBox1.FormattingEnabled = true;
            this.cndcComboBox1.Location = new System.Drawing.Point(195, 36);
            this.cndcComboBox1.Name = "cndcComboBox1";
            this.cndcComboBox1.Size = new System.Drawing.Size(225, 21);
            this.cndcComboBox1.TabIndex = 5;
            this.cndcComboBox1.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(126, 67);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(68, 13);
            this.cndcLabel2.TabIndex = 6;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Fecha Inicio:";
            // 
            // cndcDateTimePicker1
            // 
            this.cndcDateTimePicker1.Location = new System.Drawing.Point(195, 61);
            this.cndcDateTimePicker1.Name = "cndcDateTimePicker1";
            this.cndcDateTimePicker1.Size = new System.Drawing.Size(134, 20);
            this.cndcDateTimePicker1.TabIndex = 7;
            this.cndcDateTimePicker1.TablaCampoBD = null;
            // 
            // cndcCheckBox1
            // 
            this.cndcCheckBox1.AutoSize = true;
            this.cndcCheckBox1.Location = new System.Drawing.Point(118, 87);
            this.cndcCheckBox1.Name = "cndcCheckBox1";
            this.cndcCheckBox1.Size = new System.Drawing.Size(76, 17);
            this.cndcCheckBox1.TabIndex = 8;
            this.cndcCheckBox1.TablaCampoBD = null;
            this.cndcCheckBox1.Text = "Fecha Fin:";
            this.cndcCheckBox1.UseVisualStyleBackColor = true;
            // 
            // cndcDateTimePicker2
            // 
            this.cndcDateTimePicker2.Location = new System.Drawing.Point(195, 84);
            this.cndcDateTimePicker2.Name = "cndcDateTimePicker2";
            this.cndcDateTimePicker2.Size = new System.Drawing.Size(134, 20);
            this.cndcDateTimePicker2.TabIndex = 9;
            this.cndcDateTimePicker2.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(93, 113);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(101, 13);
            this.cndcLabel3.TabIndex = 10;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Nombre de Archivo:";
            // 
            // cndcTextBox1
            // 
            this.cndcTextBox1.EnterComoTab = false;
            this.cndcTextBox1.Etiqueta = null;
            this.cndcTextBox1.Location = new System.Drawing.Point(195, 110);
            this.cndcTextBox1.Name = "cndcTextBox1";
            this.cndcTextBox1.Size = new System.Drawing.Size(225, 20);
            this.cndcTextBox1.TabIndex = 12;
            this.cndcTextBox1.TablaCampoBD = null;
            // 
            // FormConfigSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 169);
            this.Controls.Add(this.cndcComboBox1);
            this.Controls.Add(this.cndcDateTimePicker2);
            this.Controls.Add(this.cndcDateTimePicker1);
            this.Controls.Add(this.cndcTextBox1);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this.cndcCheckBox1);
            this.Controls.Add(this.cndcLabel2);
            this.Name = "FormConfigSoft";
            this.Text = "FormConfigSoft";
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this.cndcCheckBox1, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this.cndcTextBox1, 0);
            this.Controls.SetChildIndex(this.cndcDateTimePicker1, 0);
            this.Controls.SetChildIndex(this.cndcDateTimePicker2, 0);
            this.Controls.SetChildIndex(this.cndcComboBox1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox cndcComboBox1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCDateTimePicker cndcDateTimePicker1;
        private Controles.CNDCCheckBox cndcCheckBox1;
        private Controles.CNDCDateTimePicker cndcDateTimePicker2;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox cndcTextBox1;
    }
}