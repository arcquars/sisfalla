namespace SISFALLA.Informe
{
    partial class IngresarEditarInterruptor
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
            this._btnComponente = new Controles.CNDCButton();
            this._txtComponente = new Controles.CNDCTextBox();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtMilisegAper = new Controles.CNDCTextBox();
            this.cndcLabelControl13 = new Controles.CNDCLabelControl();
            this._cbxTipoOpeAper = new Controles.CNDCComboBox();
            this.cndcLabelControl2 = new Controles.CNDCLabelControl();
            this._txtFecHoraApertura = new Controles.CNDCTextBox();
            this.cndcLabelControl5 = new Controles.CNDCLabelControl();
            this.cndcGroupBox4 = new Controles.CNDCGroupBox();
            this._cbxReconexCierre = new Controles.CNDCComboBox();
            this.cndcLabelControl15 = new Controles.CNDCLabelControl();
            this._txtMilisegCierre = new Controles.CNDCTextBox();
            this.cndcLabelControl14 = new Controles.CNDCLabelControl();
            this._cbxTipoOpeCierre = new Controles.CNDCComboBox();
            this.cndcLabelControl3 = new Controles.CNDCLabelControl();
            this._txtFecHoraCierre = new Controles.CNDCTextBox();
            this.cndcLabelControl4 = new Controles.CNDCLabelControl();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._dgvRelesOperados = new Controles.CNDCGridView();
            this._colFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTipoRele = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox4.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvRelesOperados)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnComponente
            // 
            this._btnComponente.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._btnComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnComponente.HelpField = null;
            this._btnComponente.Location = new System.Drawing.Point(106, 40);
            this._btnComponente.Name = "_btnComponente";
            this._btnComponente.Size = new System.Drawing.Size(110, 23);
            this._btnComponente.TabIndex = 3;
            this._btnComponente.Text = "Interruptor ";
            this._btnComponente.UseVisualStyleBackColor = false;
            this._btnComponente.Click += new System.EventHandler(this._btnComponente_Click);
            // 
            // _txtComponente
            // 
            this._txtComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtComponente.HelpField = null;
            this._txtComponente.Location = new System.Drawing.Point(242, 41);
            this._txtComponente.Name = "_txtComponente";
            this._txtComponente.Size = new System.Drawing.Size(424, 22);
            this._txtComponente.TabIndex = 9;
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtMilisegAper);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl13);
            this.cndcGroupBox1.Controls.Add(this._cbxTipoOpeAper);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl2);
            this.cndcGroupBox1.Controls.Add(this._txtFecHoraApertura);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl5);
            this.cndcGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox1.HelpField = null;
            this.cndcGroupBox1.Location = new System.Drawing.Point(64, 76);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(310, 134);
            this.cndcGroupBox1.TabIndex = 11;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Apertura :";
            // 
            // _txtMilisegAper
            // 
            this._txtMilisegAper.HelpField = null;
            this._txtMilisegAper.Location = new System.Drawing.Point(147, 60);
            this._txtMilisegAper.Name = "_txtMilisegAper";
            this._txtMilisegAper.Size = new System.Drawing.Size(44, 20);
            this._txtMilisegAper.TabIndex = 117;
            // 
            // cndcLabelControl13
            // 
            this.cndcLabelControl13.AutoSize = true;
            this.cndcLabelControl13.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl13.HelpField = null;
            this.cndcLabelControl13.Location = new System.Drawing.Point(67, 61);
            this.cndcLabelControl13.Name = "cndcLabelControl13";
            this.cndcLabelControl13.Size = new System.Drawing.Size(75, 16);
            this.cndcLabelControl13.TabIndex = 116;
            this.cndcLabelControl13.Text = "Milisegundos :";
            // 
            // _cbxTipoOpeAper
            // 
            this._cbxTipoOpeAper.FormattingEnabled = true;
            this._cbxTipoOpeAper.HelpField = null;
            this._cbxTipoOpeAper.Location = new System.Drawing.Point(148, 92);
            this._cbxTipoOpeAper.Name = "_cbxTipoOpeAper";
            this._cbxTipoOpeAper.Size = new System.Drawing.Size(91, 21);
            this._cbxTipoOpeAper.TabIndex = 115;
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.HelpField = null;
            this.cndcLabelControl2.Location = new System.Drawing.Point(39, 94);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(101, 13);
            this.cndcLabelControl2.TabIndex = 114;
            this.cndcLabelControl2.Text = "Tipo de Operación :";
            // 
            // _txtFecHoraApertura
            // 
            this._txtFecHoraApertura.HelpField = null;
            this._txtFecHoraApertura.Location = new System.Drawing.Point(148, 28);
            this._txtFecHoraApertura.Name = "_txtFecHoraApertura";
            this._txtFecHoraApertura.Size = new System.Drawing.Size(129, 20);
            this._txtFecHoraApertura.TabIndex = 113;
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.AutoSize = true;
            this.cndcLabelControl5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl5.HelpField = null;
            this.cndcLabelControl5.Location = new System.Drawing.Point(59, 29);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl5.TabIndex = 112;
            this.cndcLabelControl5.Text = "Fecha y Hora :";
            // 
            // cndcGroupBox4
            // 
            this.cndcGroupBox4.Controls.Add(this._cbxReconexCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl15);
            this.cndcGroupBox4.Controls.Add(this._txtMilisegCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl14);
            this.cndcGroupBox4.Controls.Add(this._cbxTipoOpeCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl3);
            this.cndcGroupBox4.Controls.Add(this._txtFecHoraCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl4);
            this.cndcGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox4.HelpField = null;
            this.cndcGroupBox4.Location = new System.Drawing.Point(413, 79);
            this.cndcGroupBox4.Name = "cndcGroupBox4";
            this.cndcGroupBox4.Size = new System.Drawing.Size(302, 164);
            this.cndcGroupBox4.TabIndex = 113;
            this.cndcGroupBox4.TabStop = false;
            this.cndcGroupBox4.Text = "Cierre :";
            // 
            // _cbxReconexCierre
            // 
            this._cbxReconexCierre.FormattingEnabled = true;
            this._cbxReconexCierre.HelpField = null;
            this._cbxReconexCierre.Location = new System.Drawing.Point(148, 127);
            this._cbxReconexCierre.Name = "_cbxReconexCierre";
            this._cbxReconexCierre.Size = new System.Drawing.Size(68, 21);
            this._cbxReconexCierre.TabIndex = 121;
            // 
            // cndcLabelControl15
            // 
            this.cndcLabelControl15.AutoSize = true;
            this.cndcLabelControl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl15.HelpField = null;
            this.cndcLabelControl15.Location = new System.Drawing.Point(23, 130);
            this.cndcLabelControl15.Name = "cndcLabelControl15";
            this.cndcLabelControl15.Size = new System.Drawing.Size(115, 13);
            this.cndcLabelControl15.TabIndex = 120;
            this.cndcLabelControl15.Text = "Reconex. Automática :";
            // 
            // _txtMilisegCierre
            // 
            this._txtMilisegCierre.HelpField = null;
            this._txtMilisegCierre.Location = new System.Drawing.Point(148, 60);
            this._txtMilisegCierre.Name = "_txtMilisegCierre";
            this._txtMilisegCierre.Size = new System.Drawing.Size(44, 20);
            this._txtMilisegCierre.TabIndex = 119;
            // 
            // cndcLabelControl14
            // 
            this.cndcLabelControl14.AutoSize = true;
            this.cndcLabelControl14.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl14.HelpField = null;
            this.cndcLabelControl14.Location = new System.Drawing.Point(66, 61);
            this.cndcLabelControl14.Name = "cndcLabelControl14";
            this.cndcLabelControl14.Size = new System.Drawing.Size(75, 16);
            this.cndcLabelControl14.TabIndex = 118;
            this.cndcLabelControl14.Text = "Milisegundos :";
            // 
            // _cbxTipoOpeCierre
            // 
            this._cbxTipoOpeCierre.FormattingEnabled = true;
            this._cbxTipoOpeCierre.HelpField = null;
            this._cbxTipoOpeCierre.Location = new System.Drawing.Point(148, 92);
            this._cbxTipoOpeCierre.Name = "_cbxTipoOpeCierre";
            this._cbxTipoOpeCierre.Size = new System.Drawing.Size(121, 21);
            this._cbxTipoOpeCierre.TabIndex = 115;
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl3.HelpField = null;
            this.cndcLabelControl3.Location = new System.Drawing.Point(38, 94);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(101, 13);
            this.cndcLabelControl3.TabIndex = 114;
            this.cndcLabelControl3.Text = "Tipo de Operación :";
            // 
            // _txtFecHoraCierre
            // 
            this._txtFecHoraCierre.HelpField = null;
            this._txtFecHoraCierre.Location = new System.Drawing.Point(148, 28);
            this._txtFecHoraCierre.Name = "_txtFecHoraCierre";
            this._txtFecHoraCierre.Size = new System.Drawing.Size(125, 20);
            this._txtFecHoraCierre.TabIndex = 113;
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.HelpField = null;
            this.cndcLabelControl4.Location = new System.Drawing.Point(60, 29);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl4.TabIndex = 112;
            this.cndcLabelControl4.Text = "Fecha y Hora :";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._dgvRelesOperados);
            this.cndcGroupBox2.HelpField = null;
            this.cndcGroupBox2.Location = new System.Drawing.Point(32, 249);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(698, 148);
            this.cndcGroupBox2.TabIndex = 114;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "RELES OPERADOS";
            // 
            // _dgvRelesOperados
            // 
            this._dgvRelesOperados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvRelesOperados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colFuncion,
            this._colDescripcion,
            this._colTipoRele,
            this._colTiempo,
            this._colZona,
            this._colDist});
            this._dgvRelesOperados.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvRelesOperados.HelpField = null;
            this._dgvRelesOperados.Location = new System.Drawing.Point(3, 16);
            this._dgvRelesOperados.Name = "_dgvRelesOperados";
            this._dgvRelesOperados.RowHeadersWidth = 15;
            this._dgvRelesOperados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvRelesOperados.Size = new System.Drawing.Size(692, 129);
            this._dgvRelesOperados.TabIndex = 0;
            // 
            // _colFuncion
            // 
            this._colFuncion.HeaderText = "Función";
            this._colFuncion.Name = "_colFuncion";
            this._colFuncion.Width = 80;
            // 
            // _colDescripcion
            // 
            this._colDescripcion.HeaderText = "Descripción";
            this._colDescripcion.Name = "_colDescripcion";
            this._colDescripcion.Width = 280;
            // 
            // _colTipoRele
            // 
            this._colTipoRele.HeaderText = "Tipo de Relé";
            this._colTipoRele.Name = "_colTipoRele";
            this._colTipoRele.Width = 110;
            // 
            // _colTiempo
            // 
            this._colTiempo.HeaderText = "Tiempo (ms)";
            this._colTiempo.Name = "_colTiempo";
            // 
            // _colZona
            // 
            this._colZona.HeaderText = "Zona";
            this._colZona.Name = "_colZona";
            this._colZona.Width = 50;
            // 
            // _colDist
            // 
            this._colDist.HeaderText = "Dist (Km)";
            this._colDist.Name = "_colDist";
            this._colDist.Width = 80;
            // 
            // IngresarEditarInterruptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 432);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox4);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._txtComponente);
            this.Controls.Add(this._btnComponente);
            this.Name = "IngresarEditarInterruptor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Editar Interruptor";
            this.Controls.SetChildIndex(this._btnComponente, 0);
            this.Controls.SetChildIndex(this._txtComponente, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox4, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcGroupBox4.ResumeLayout(false);
            this.cndcGroupBox4.PerformLayout();
            this.cndcGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvRelesOperados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCButton _btnComponente;
        private Controles.CNDCTextBox _txtComponente;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCComboBox _cbxTipoOpeAper;
        private Controles.CNDCLabelControl cndcLabelControl2;
        private Controles.CNDCTextBox _txtFecHoraApertura;
        private Controles.CNDCLabelControl cndcLabelControl5;
        private Controles.CNDCGroupBox cndcGroupBox4;
        private Controles.CNDCComboBox _cbxTipoOpeCierre;
        private Controles.CNDCLabelControl cndcLabelControl3;
        private Controles.CNDCTextBox _txtFecHoraCierre;
        private Controles.CNDCLabelControl cndcLabelControl4;
        private Controles.CNDCTextBox _txtMilisegAper;
        private Controles.CNDCLabelControl cndcLabelControl13;
        private Controles.CNDCComboBox _cbxReconexCierre;
        private Controles.CNDCLabelControl cndcLabelControl15;
        private Controles.CNDCTextBox _txtMilisegCierre;
        private Controles.CNDCLabelControl cndcLabelControl14;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCGridView _dgvRelesOperados;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFuncion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTipoRele;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDist;
    }
}