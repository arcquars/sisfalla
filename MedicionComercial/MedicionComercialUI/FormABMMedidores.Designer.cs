namespace MedicionComercialUI
{
    partial class FormABMMedidores
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
            this._dgvMedidores = new Controles.CNDCGridView();
            this.cndcTabControl1 = new Controles.CNDCTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._ctrlResumenMedidor = new MedicionComercialUI.CtrlResumenMedidor();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrMedidorMaxMin1 = new MedicionComercialUI.CtrMedidorMaxMin();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMedidores)).BeginInit();
            this.cndcTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvMedidores
            // 
            this._dgvMedidores.AllowUserToAddRows = false;
            this._dgvMedidores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMedidores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvMedidores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMedidores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvMedidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMedidores.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvMedidores.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvMedidores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMedidores.Location = new System.Drawing.Point(0, 0);
            this._dgvMedidores.Name = "_dgvMedidores";
            this._dgvMedidores.NombreContenedor = "FormABMMedidores";
            this._dgvMedidores.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMedidores.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvMedidores.RowHeadersWidth = 25;
            this._dgvMedidores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMedidores.Size = new System.Drawing.Size(1016, 231);
            this._dgvMedidores.TabIndex = 8;
            this._dgvMedidores.TablaCampoBD = null;
            this._dgvMedidores.SelectionChanged += new System.EventHandler(this._dgvMedidores_SelectionChanged);
            // 
            // cndcTabControl1
            // 
            this.cndcTabControl1.Controls.Add(this.tabPage1);
            this.cndcTabControl1.Controls.Add(this.tabPage3);
            this.cndcTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndcTabControl1.Location = new System.Drawing.Point(0, 231);
            this.cndcTabControl1.Name = "cndcTabControl1";
            this.cndcTabControl1.SelectedIndex = 0;
            this.cndcTabControl1.Size = new System.Drawing.Size(1016, 378);
            this.cndcTabControl1.TabIndex = 9;
            this.cndcTabControl1.TablaCampoBD = null;
            this.cndcTabControl1.SelectedIndexChanged += new System.EventHandler(this.cndcTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._ctrlResumenMedidor);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1008, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Medidor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _ctrlResumenMedidor
            // 
            this._ctrlResumenMedidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlResumenMedidor.Location = new System.Drawing.Point(3, 3);
            this._ctrlResumenMedidor.Medidor = null;
            this._ctrlResumenMedidor.Name = "_ctrlResumenMedidor";
            this._ctrlResumenMedidor.Size = new System.Drawing.Size(1002, 346);
            this._ctrlResumenMedidor.TabIndex = 0;
            this._ctrlResumenMedidor.MedidorModificado += new System.EventHandler<MedicionComercialUI.MedidorEventArgs>(this._ctrlResumenMedidor_MedidorModificado);
            this._ctrlResumenMedidor.MedidorCreado += new System.EventHandler<MedicionComercialUI.MedidorEventArgs>(this._ctrlResumenMedidor_MedidorCreado);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrMedidorMaxMin1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1008, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Max Min";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrMedidorMaxMin1
            // 
            this.ctrMedidorMaxMin1.Location = new System.Drawing.Point(26, 6);
            this.ctrMedidorMaxMin1.Medidor = null;
            this.ctrMedidorMaxMin1.Name = "ctrMedidorMaxMin1";
            this.ctrMedidorMaxMin1.Size = new System.Drawing.Size(957, 343);
            this.ctrMedidorMaxMin1.TabIndex = 0;
            // 
            // FormABMMedidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 609);
            this.Controls.Add(this.cndcTabControl1);
            this.Controls.Add(this._dgvMedidores);
            this.Name = "FormABMMedidores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListaMedidores";
            ((System.ComponentModel.ISupportInitialize)(this._dgvMedidores)).EndInit();
            this.cndcTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlResumenMedidor _ctrlResumenMedidor;
        private Controles.CNDCGridView _dgvMedidores;
        private Controles.CNDCTabControl cndcTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private CtrMedidorMaxMin ctrMedidorMaxMin1;
    }
}