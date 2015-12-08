namespace MedicionComercialUI
{
    partial class FormABMPuntosMedicion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvPuntosMedicion = new Controles.CNDCGridView();
            this.cndcTabControl1 = new Controles.CNDCTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlPuntoMedicion1 = new MedicionComercialUI.CtrlPuntoMedicion();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlMedidorFto1 = new MedicionComercialUI.CtrlPtoMedicionFto();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ctrlFormulasPtoMed1 = new MedicionComercialUI.CtrlFormulasPtoMed();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).BeginInit();
            this.cndcTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvPuntosMedicion
            // 
            this._dgvPuntosMedicion.AllowUserToAddRows = false;
            this._dgvPuntosMedicion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvPuntosMedicion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvPuntosMedicion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvPuntosMedicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvPuntosMedicion.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvPuntosMedicion.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvPuntosMedicion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvPuntosMedicion.Location = new System.Drawing.Point(0, 0);
            this._dgvPuntosMedicion.Name = "_dgvPuntosMedicion";
            this._dgvPuntosMedicion.NombreContenedor = "FormABMMedidores";
            this._dgvPuntosMedicion.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvPuntosMedicion.RowHeadersWidth = 25;
            this._dgvPuntosMedicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvPuntosMedicion.Size = new System.Drawing.Size(1177, 231);
            this._dgvPuntosMedicion.TabIndex = 9;
            this._dgvPuntosMedicion.TablaCampoBD = null;
            this._dgvPuntosMedicion.SelectionChanged += new System.EventHandler(this._dgvPuntosMedicion_SelectionChanged);
            // 
            // cndcTabControl1
            // 
            this.cndcTabControl1.Controls.Add(this.tabPage1);
            this.cndcTabControl1.Controls.Add(this.tabPage2);
            this.cndcTabControl1.Controls.Add(this.tabPage3);
            this.cndcTabControl1.Controls.Add(this.tabPage4);
            this.cndcTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndcTabControl1.Location = new System.Drawing.Point(0, 231);
            this.cndcTabControl1.Name = "cndcTabControl1";
            this.cndcTabControl1.SelectedIndex = 0;
            this.cndcTabControl1.Size = new System.Drawing.Size(1177, 363);
            this.cndcTabControl1.TabIndex = 10;
            this.cndcTabControl1.TablaCampoBD = null;
            this.cndcTabControl1.SelectedIndexChanged += new System.EventHandler(this.cndcTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlPuntoMedicion1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1169, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Punto Med.";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlPuntoMedicion1
            // 
            this.ctrlPuntoMedicion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPuntoMedicion1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPuntoMedicion1.Name = "ctrlPuntoMedicion1";
            this.ctrlPuntoMedicion1.PuntoMedicion = null;
            this.ctrlPuntoMedicion1.Size = new System.Drawing.Size(1163, 331);
            this.ctrlPuntoMedicion1.TabIndex = 0;
            this.ctrlPuntoMedicion1.PuntoMedicionModificado += new System.EventHandler<MedicionComercialUI.PuntoMedicionEventArgs>(this.ctrlPuntoMedicion1_PuntoMedicionModificado);
            this.ctrlPuntoMedicion1.PuntoMedicionCreado += new System.EventHandler<MedicionComercialUI.PuntoMedicionEventArgs>(this.ctrlPuntoMedicion1_PuntoMedicionCreado);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlMedidorFto1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1169, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Formatos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlMedidorFto1
            // 
            this.ctrlMedidorFto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMedidorFto1.Location = new System.Drawing.Point(3, 3);
            this.ctrlMedidorFto1.Name = "ctrlMedidorFto1";
            this.ctrlMedidorFto1.PuntoMedicion = null;
            this.ctrlMedidorFto1.Size = new System.Drawing.Size(1163, 331);
            this.ctrlMedidorFto1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlFormulasPtoMed1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1169, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fórmulas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1169, 337);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Perfil Carga";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ctrlFormulasPtoMed1
            // 
            this.ctrlFormulasPtoMed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFormulasPtoMed1.Location = new System.Drawing.Point(3, 3);
            this.ctrlFormulasPtoMed1.Name = "ctrlFormulasPtoMed1";
            this.ctrlFormulasPtoMed1.PuntoMedicion = null;
            this.ctrlFormulasPtoMed1.Size = new System.Drawing.Size(1163, 331);
            this.ctrlFormulasPtoMed1.TabIndex = 0;
            // 
            // FormABMPuntosMedicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 594);
            this.Controls.Add(this.cndcTabControl1);
            this.Controls.Add(this._dgvPuntosMedicion);
            this.Name = "FormABMPuntosMedicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormABMPuntosMedicion";
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).EndInit();
            this.cndcTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvPuntosMedicion;
        private Controles.CNDCTabControl cndcTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private CtrlPuntoMedicion ctrlPuntoMedicion1;
        private CtrlPtoMedicionFto ctrlMedidorFto1;
        private CtrlFormulasPtoMed ctrlFormulasPtoMed1;
    }
}