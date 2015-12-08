namespace SISFALLA
{
    partial class CtrlDominios
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
            this.cndcLabelControl8 = new Controles.CNDCLabel();
            this._pnlTool = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._dgvDominio = new Controles.CNDCGridView();
            this._pnlTool.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDominio)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelControl8
            // 
            this.cndcLabelControl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl8.Location = new System.Drawing.Point(3, 6);
            this.cndcLabelControl8.Name = "cndcLabelControl8";
            this.cndcLabelControl8.Size = new System.Drawing.Size(143, 13);
            this.cndcLabelControl8.TabIndex = 135;
            this.cndcLabelControl8.TablaCampoBD = null;
            this.cndcLabelControl8.Text = "Valores  de Categoría";
            this.cndcLabelControl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlTool
            // 
            this._pnlTool.Controls.Add(this.cndcToolStrip1);
            this._pnlTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnlTool.Location = new System.Drawing.Point(0, 195);
            this._pnlTool.Name = "_pnlTool";
            this._pnlTool.Size = new System.Drawing.Size(800, 25);
            this._pnlTool.TabIndex = 134;
            this._pnlTool.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnEditar,
            this._btnEliminar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(800, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionar.Image = global::SISFALLA.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionar.Text = "toolStripButton1";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditar.Image = global::SISFALLA.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(23, 22);
            this._btnEditar.Text = "toolStripButton2";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminar.Image = global::SISFALLA.Properties.Resources.Delete;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(23, 22);
            this._btnEliminar.Text = "toolStripButton3";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // _dgvDominio
            // 
            this._dgvDominio.AllowUserToAddRows = false;
            this._dgvDominio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDominio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvDominio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDominio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDominio.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvDominio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDominio.Location = new System.Drawing.Point(6, 22);
            this._dgvDominio.MultiSelect = false;
            this._dgvDominio.Name = "_dgvDominio";
            this._dgvDominio.ReadOnly = true;
            this._dgvDominio.RowHeadersWidth = 25;
            this._dgvDominio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDominio.Size = new System.Drawing.Size(791, 170);
            this._dgvDominio.TabIndex = 136;
            this._dgvDominio.TablaCampoBD = null;
            this._dgvDominio.SelectionChanged += new System.EventHandler(this._dgvDominio_SelectionChanged);
            // 
            // CtrlDominios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dgvDominio);
            this.Controls.Add(this.cndcLabelControl8);
            this.Controls.Add(this._pnlTool);
            this.MaximumSize = new System.Drawing.Size(800, 220);
            this.MinimumSize = new System.Drawing.Size(800, 220);
            this.Name = "CtrlDominios";
            this.Size = new System.Drawing.Size(800, 220);
            this._pnlTool.ResumeLayout(false);
            this._pnlTool.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDominio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl8;
        private Controles.CNDCPanelControl _pnlTool;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCGridView _dgvDominio;
    }
}
