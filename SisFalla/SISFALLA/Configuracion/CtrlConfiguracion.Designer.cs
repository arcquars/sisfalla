namespace SISFALLA
{
    partial class CtrlConfiguracion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._tspAdConfig = new System.Windows.Forms.ToolStripButton();
            this._tspEditarConfig = new System.Windows.Forms.ToolStripButton();
            this._tspBorrarConfig = new System.Windows.Forms.ToolStripButton();
            this._dgvConfiguracion = new Controles.CNDCGridView();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._dgvAgentes = new Controles.CNDCGridView();
            this.cndcGroupBox2.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvConfiguracion)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cndcGroupBox2.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox2.Controls.Add(this._dgvConfiguracion);
            this.cndcGroupBox2.Location = new System.Drawing.Point(327, 3);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(560, 390);
            this.cndcGroupBox2.TabIndex = 3;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Configuración";
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tspAdConfig,
            this._tspEditarConfig,
            this._tspBorrarConfig});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(554, 25);
            this.cndcToolStrip1.TabIndex = 90;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _tspAdConfig
            // 
            this._tspAdConfig.Image = global::SISFALLA.Properties.Resources.Add;
            this._tspAdConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspAdConfig.Name = "_tspAdConfig";
            this._tspAdConfig.Size = new System.Drawing.Size(120, 22);
            this._tspAdConfig.Text = "Adicionar Config.";
            this._tspAdConfig.Click += new System.EventHandler(this._tspAdConfig_Click);
            // 
            // _tspEditarConfig
            // 
            this._tspEditarConfig.Image = global::SISFALLA.Properties.Resources.Edit;
            this._tspEditarConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspEditarConfig.Name = "_tspEditarConfig";
            this._tspEditarConfig.Size = new System.Drawing.Size(99, 22);
            this._tspEditarConfig.Text = "Editar Config.";
            this._tspEditarConfig.Click += new System.EventHandler(this._tspEditarConfig_Click);
            // 
            // _tspBorrarConfig
            // 
            this._tspBorrarConfig.Image = global::SISFALLA.Properties.Resources.Delete;
            this._tspBorrarConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspBorrarConfig.Name = "_tspBorrarConfig";
            this._tspBorrarConfig.Size = new System.Drawing.Size(101, 22);
            this._tspBorrarConfig.Text = "Borrar Config.";
            // 
            // _dgvConfiguracion
            // 
            this._dgvConfiguracion.AllowUserToAddRows = false;
            this._dgvConfiguracion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvConfiguracion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvConfiguracion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvConfiguracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvConfiguracion.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvConfiguracion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvConfiguracion.Location = new System.Drawing.Point(6, 45);
            this._dgvConfiguracion.Name = "_dgvConfiguracion";
            this._dgvConfiguracion.ReadOnly = true;
            this._dgvConfiguracion.RowHeadersWidth = 25;
            this._dgvConfiguracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvConfiguracion.Size = new System.Drawing.Size(549, 343);
            this._dgvConfiguracion.TabIndex = 0;
            this._dgvConfiguracion.TablaCampoBD = null;
            this._dgvConfiguracion.SelectionChanged += new System.EventHandler(this._dgvConfiguracion_SelectionChanged);
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cndcGroupBox1.Controls.Add(this._dgvAgentes);
            this.cndcGroupBox1.Location = new System.Drawing.Point(2, 3);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(319, 390);
            this.cndcGroupBox1.TabIndex = 2;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Agentes";
            // 
            // _dgvAgentes
            // 
            this._dgvAgentes.AllowUserToAddRows = false;
            this._dgvAgentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this._dgvAgentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentes.DefaultCellStyle = dataGridViewCellStyle8;
            this._dgvAgentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentes.Location = new System.Drawing.Point(7, 16);
            this._dgvAgentes.Name = "_dgvAgentes";
            this._dgvAgentes.ReadOnly = true;
            this._dgvAgentes.RowHeadersWidth = 25;
            this._dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentes.Size = new System.Drawing.Size(301, 372);
            this._dgvAgentes.TabIndex = 0;
            this._dgvAgentes.TablaCampoBD = null;
            this._dgvAgentes.SelectionChanged += new System.EventHandler(this._dgvAgentes_SelectionChanged);
            // 
            // CtrlConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox1);
            this.Name = "CtrlConfiguracion";
            this.Size = new System.Drawing.Size(891, 400);
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvConfiguracion)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCGridView _dgvConfiguracion;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGridView _dgvAgentes;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _tspAdConfig;
        private System.Windows.Forms.ToolStripButton _tspEditarConfig;
        private System.Windows.Forms.ToolStripButton _tspBorrarConfig;
    }
}
