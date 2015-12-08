namespace MedicionComercialUI
{
    partial class CtrlFormulasPtoMed
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
            this.cndcPanelControl2 = new Controles.CNDCPanelControl();
            this.cndcToolStrip2 = new Controles.CNDCToolStrip();
            this._btnAdicionarMagnitud = new System.Windows.Forms.ToolStripButton();
            this._btnEditarMagnitud = new System.Windows.Forms.ToolStripButton();
            this._btnEliminarMagnitud = new System.Windows.Forms.ToolStripButton();
            this._dgvFormulas = new Controles.CNDCGridView();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcPanelControl2.SuspendLayout();
            this.cndcToolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvFormulas)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcPanelControl2
            // 
            this.cndcPanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cndcPanelControl2.Controls.Add(this.cndcToolStrip2);
            this.cndcPanelControl2.Location = new System.Drawing.Point(3, 256);
            this.cndcPanelControl2.Name = "cndcPanelControl2";
            this.cndcPanelControl2.Size = new System.Drawing.Size(530, 26);
            this.cndcPanelControl2.TabIndex = 10;
            this.cndcPanelControl2.TablaCampoBD = null;
            // 
            // cndcToolStrip2
            // 
            this.cndcToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionarMagnitud,
            this._btnEditarMagnitud,
            this._btnEliminarMagnitud});
            this.cndcToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip2.Name = "cndcToolStrip2";
            this.cndcToolStrip2.Size = new System.Drawing.Size(530, 25);
            this.cndcToolStrip2.TabIndex = 5;
            this.cndcToolStrip2.TablaCampoBD = null;
            this.cndcToolStrip2.Text = "cndcToolStrip2";
            // 
            // _btnAdicionarMagnitud
            // 
            this._btnAdicionarMagnitud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionarMagnitud.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnAdicionarMagnitud.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionarMagnitud.Name = "_btnAdicionarMagnitud";
            this._btnAdicionarMagnitud.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionarMagnitud.Text = "toolStripButton1";
            this._btnAdicionarMagnitud.Click += new System.EventHandler(this._btnAdicionarMagnitud_Click);
            // 
            // _btnEditarMagnitud
            // 
            this._btnEditarMagnitud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditarMagnitud.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditarMagnitud.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditarMagnitud.Name = "_btnEditarMagnitud";
            this._btnEditarMagnitud.Size = new System.Drawing.Size(23, 22);
            this._btnEditarMagnitud.Text = "toolStripButton2";
            this._btnEditarMagnitud.Click += new System.EventHandler(this._btnEditarMagnitud_Click);
            // 
            // _btnEliminarMagnitud
            // 
            this._btnEliminarMagnitud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminarMagnitud.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnEliminarMagnitud.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminarMagnitud.Name = "_btnEliminarMagnitud";
            this._btnEliminarMagnitud.Size = new System.Drawing.Size(23, 22);
            this._btnEliminarMagnitud.Text = "toolStripButton3";
            // 
            // _dgvFormulas
            // 
            this._dgvFormulas.AllowUserToAddRows = false;
            this._dgvFormulas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvFormulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvFormulas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvFormulas.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvFormulas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvFormulas.Location = new System.Drawing.Point(3, 18);
            this._dgvFormulas.Name = "_dgvFormulas";
            this._dgvFormulas.NombreContenedor = "CtrlMedidorFto";
            this._dgvFormulas.RowHeadersWidth = 25;
            this._dgvFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvFormulas.Size = new System.Drawing.Size(530, 232);
            this._dgvFormulas.TabIndex = 9;
            this._dgvFormulas.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(0, 2);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(153, 13);
            this.cndcLabel2.TabIndex = 8;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Detalle - Magnitudes Eléctricas";
            // 
            // CtrlFormulasPtoMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcPanelControl2);
            this.Controls.Add(this._dgvFormulas);
            this.Controls.Add(this.cndcLabel2);
            this.Name = "CtrlFormulasPtoMed";
            this.Size = new System.Drawing.Size(533, 282);
            this.cndcPanelControl2.ResumeLayout(false);
            this.cndcPanelControl2.PerformLayout();
            this.cndcToolStrip2.ResumeLayout(false);
            this.cndcToolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvFormulas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCPanelControl cndcPanelControl2;
        private Controles.CNDCToolStrip cndcToolStrip2;
        private System.Windows.Forms.ToolStripButton _btnAdicionarMagnitud;
        private System.Windows.Forms.ToolStripButton _btnEditarMagnitud;
        private System.Windows.Forms.ToolStripButton _btnEliminarMagnitud;
        private Controles.CNDCGridView _dgvFormulas;
        private Controles.CNDCLabel cndcLabel2;
    }
}
