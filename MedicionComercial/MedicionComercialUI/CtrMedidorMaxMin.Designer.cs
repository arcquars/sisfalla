namespace MedicionComercialUI
{
    partial class CtrMedidorMaxMin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvMaxMinDetalle = new Controles.CNDCGridView();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.cndcToolStrip2 = new Controles.CNDCToolStrip();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._dgvMaxMin = new Controles.CNDCGridView();
            this.cndcPanelControl2 = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMaxMinDetalle)).BeginInit();
            this.cndcPanelControl1.SuspendLayout();
            this.cndcToolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMaxMin)).BeginInit();
            this.cndcPanelControl2.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvMaxMinDetalle
            // 
            this._dgvMaxMinDetalle.AllowUserToAddRows = false;
            this._dgvMaxMinDetalle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMaxMinDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvMaxMinDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvMaxMinDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvMaxMinDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMaxMinDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvMaxMinDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMaxMinDetalle.Location = new System.Drawing.Point(211, 24);
            this._dgvMaxMinDetalle.Name = "_dgvMaxMinDetalle";
            this._dgvMaxMinDetalle.NombreContenedor = null;
            this._dgvMaxMinDetalle.ReadOnly = true;
            this._dgvMaxMinDetalle.RowHeadersWidth = 25;
            this._dgvMaxMinDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMaxMinDetalle.Size = new System.Drawing.Size(515, 327);
            this._dgvMaxMinDetalle.TabIndex = 7;
            this._dgvMaxMinDetalle.TablaCampoBD = null;
            this._dgvMaxMinDetalle.SelectionChanged += new System.EventHandler(this._dgvMaxMinDetalle_SelectionChanged);
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cndcPanelControl1.Controls.Add(this.cndcToolStrip2);
            this.cndcPanelControl1.Location = new System.Drawing.Point(211, 352);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(515, 27);
            this.cndcPanelControl1.TabIndex = 8;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // cndcToolStrip2
            // 
            this.cndcToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cndcToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEditar,
            this._btnEliminar});
            this.cndcToolStrip2.Location = new System.Drawing.Point(0, 2);
            this.cndcToolStrip2.Name = "cndcToolStrip2";
            this.cndcToolStrip2.Size = new System.Drawing.Size(515, 25);
            this.cndcToolStrip2.TabIndex = 7;
            this.cndcToolStrip2.TablaCampoBD = null;
            this.cndcToolStrip2.Text = "cndcToolStrip2";
            // 
            // _btnEditar
            // 
            this._btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditar.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(23, 22);
            this._btnEditar.Text = "toolStripButton2";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminar.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(23, 22);
            this._btnEliminar.Text = "toolStripButton3";
            // 
            // _dgvMaxMin
            // 
            this._dgvMaxMin.AllowUserToAddRows = false;
            this._dgvMaxMin.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMaxMin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvMaxMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._dgvMaxMin.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvMaxMin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMaxMin.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvMaxMin.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMaxMin.Location = new System.Drawing.Point(7, 24);
            this._dgvMaxMin.Name = "_dgvMaxMin";
            this._dgvMaxMin.NombreContenedor = null;
            this._dgvMaxMin.ReadOnly = true;
            this._dgvMaxMin.RowHeadersWidth = 25;
            this._dgvMaxMin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMaxMin.Size = new System.Drawing.Size(198, 327);
            this._dgvMaxMin.TabIndex = 9;
            this._dgvMaxMin.TablaCampoBD = null;
            this._dgvMaxMin.SelectionChanged += new System.EventHandler(this._dgvMaxMin_SelectionChanged);
            // 
            // cndcPanelControl2
            // 
            this.cndcPanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cndcPanelControl2.Controls.Add(this.cndcToolStrip1);
            this.cndcPanelControl2.Location = new System.Drawing.Point(7, 352);
            this.cndcPanelControl2.Name = "cndcPanelControl2";
            this.cndcPanelControl2.Size = new System.Drawing.Size(198, 26);
            this.cndcPanelControl2.TabIndex = 10;
            this.cndcPanelControl2.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(198, 25);
            this.cndcToolStrip1.TabIndex = 5;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionar.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionar.Text = "toolStripButton1";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // CtrMedidorMaxMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcPanelControl2);
            this.Controls.Add(this._dgvMaxMin);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._dgvMaxMinDetalle);
            this.Name = "CtrMedidorMaxMin";
            this.Size = new System.Drawing.Size(729, 382);
            ((System.ComponentModel.ISupportInitialize)(this._dgvMaxMinDetalle)).EndInit();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.cndcToolStrip2.ResumeLayout(false);
            this.cndcToolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMaxMin)).EndInit();
            this.cndcPanelControl2.ResumeLayout(false);
            this.cndcPanelControl2.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvMaxMinDetalle;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCToolStrip cndcToolStrip2;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCGridView _dgvMaxMin;
        private Controles.CNDCPanelControl cndcPanelControl2;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
    }
}
