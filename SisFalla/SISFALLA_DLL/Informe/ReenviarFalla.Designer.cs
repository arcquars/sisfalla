namespace SISFALLA.Informe
{
    partial class ReenviarFalla
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
            this._cbxAgente = new Controles.CNDCComboBox();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._txtCodigoFalla = new Controles.CNDCTextBox();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._lblAdjuntarAnalisis = new Controles.CNDCLabel();
            this.cndcTextBox1 = new Controles.CNDCTextBox();
            this.cndcGridView1 = new Controles.CNDCGridView();
            this.cndcGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cndcGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _cbxAgente
            // 
            this._cbxAgente.FormattingEnabled = true;
            this._cbxAgente.TablaCampoBD = null;
            this._cbxAgente.Location = new System.Drawing.Point(432, 41);
            this._cbxAgente.Name = "_cbxAgente";
            this._cbxAgente.Size = new System.Drawing.Size(156, 21);
            this._cbxAgente.TabIndex = 118;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(327, 43);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(87, 13);
            this.cndcLabelControl1.TabIndex = 117;
            this.cndcLabelControl1.Text = "Tipo de Informe :";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Location = new System.Drawing.Point(100, 43);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(83, 13);
            this.cndcLabelControl2.TabIndex = 119;
            this.cndcLabelControl2.Text = "Codigo de falla :";
            // 
            // _txtCodigoFalla
            // 
            this._txtCodigoFalla.TablaCampoBD = null;
            this._txtCodigoFalla.Location = new System.Drawing.Point(189, 40);
            this._txtCodigoFalla.Name = "_txtCodigoFalla";
            this._txtCodigoFalla.Size = new System.Drawing.Size(82, 20);
            this._txtCodigoFalla.TabIndex = 120;
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.cndcGroupBox2.Controls.Add(this.cndcGridView1);
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.Location = new System.Drawing.Point(23, 136);
            this.cndcGroupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cndcGroupBox2.Size = new System.Drawing.Size(657, 279);
            this.cndcGroupBox2.TabIndex = 121;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Agentes - Contactos ";
            // 
            // _lblAdjuntarAnalisis
            // 
            this._lblAdjuntarAnalisis.AutoSize = true;
            this._lblAdjuntarAnalisis.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAdjuntarAnalisis.TablaCampoBD = null;
            this._lblAdjuntarAnalisis.Location = new System.Drawing.Point(100, 77);
            this._lblAdjuntarAnalisis.Name = "_lblAdjuntarAnalisis";
            this._lblAdjuntarAnalisis.Size = new System.Drawing.Size(102, 16);
            this._lblAdjuntarAnalisis.TabIndex = 122;
            this._lblAdjuntarAnalisis.Text = "Otros Destinatarios :";
            // 
            // cndcTextBox1
            // 
            this.cndcTextBox1.TablaCampoBD = null;
            this.cndcTextBox1.Location = new System.Drawing.Point(225, 76);
            this.cndcTextBox1.Name = "cndcTextBox1";
            this.cndcTextBox1.Size = new System.Drawing.Size(389, 20);
            this.cndcTextBox1.TabIndex = 125;
            // 
            // cndcGridView1
            // 
            this.cndcGridView1.AllowUserToAddRows = false;
            this.cndcGridView1.AllowUserToDeleteRows = false;
            this.cndcGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cndcGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndcGridView1.TablaCampoBD = null;
            this.cndcGridView1.Location = new System.Drawing.Point(3, 16);
            this.cndcGridView1.Name = "cndcGridView1";
            this.cndcGridView1.ReadOnly = true;
            this.cndcGridView1.Size = new System.Drawing.Size(651, 260);
            this.cndcGridView1.TabIndex = 0;
            // 
            // ReenviarFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 455);
            this.Controls.Add(this.cndcTextBox1);
            this.Controls.Add(this._lblAdjuntarAnalisis);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this._txtCodigoFalla);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this._cbxAgente);
            this.Controls.Add(this.cndcLabelControl1);
            this.Name = "ReenviarFalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reenviar de Informe de Falla";
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this._cbxAgente, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl2, 0);
            this.Controls.SetChildIndex(this._txtCodigoFalla, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.Controls.SetChildIndex(this._lblAdjuntarAnalisis, 0);
            this.Controls.SetChildIndex(this.cndcTextBox1, 0);
            this.cndcGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cndcGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cbxAgente;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCTextBox _txtCodigoFalla;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCLabel _lblAdjuntarAnalisis;
        private Controles.CNDCGridView cndcGridView1;
        private Controles.CNDCTextBox cndcTextBox1;
    }
}