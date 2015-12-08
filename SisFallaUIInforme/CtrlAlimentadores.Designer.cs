namespace SISFALLA
{
    partial class CtrlAlimentadores
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
            this._dgvAlimentadores = new Controles.CNDCGridView();
            this.cndcToolStrip3 = new Controles.CNDCToolStrip();
            this._tspIngresarAlimentador = new System.Windows.Forms.ToolStripButton();
            this._tspEditarAlimentador = new System.Windows.Forms.ToolStripButton();
            this._tspBorrarAlimentador = new System.Windows.Forms.ToolStripButton();
            this._tspCopiarAlimentador = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).BeginInit();
            this.cndcToolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvAlimentadores
            // 
            this._dgvAlimentadores.AllowUserToAddRows = false;
            this._dgvAlimentadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAlimentadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAlimentadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAlimentadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAlimentadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAlimentadores.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAlimentadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAlimentadores.Location = new System.Drawing.Point(4, 28);
            this._dgvAlimentadores.Name = "_dgvAlimentadores";
            this._dgvAlimentadores.ReadOnly = true;
            this._dgvAlimentadores.RowHeadersWidth = 15;
            this._dgvAlimentadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAlimentadores.ShowRowErrors = false;
            this._dgvAlimentadores.Size = new System.Drawing.Size(960, 271);
            this._dgvAlimentadores.TabIndex = 5;
            this._dgvAlimentadores.TablaCampoBD = null;
            this._dgvAlimentadores.SelectionChanged += new System.EventHandler(this._dgvAlimentadores_SelectionChanged);
            // 
            // cndcToolStrip3
            // 
            this.cndcToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tspIngresarAlimentador,
            this._tspEditarAlimentador,
            this._tspBorrarAlimentador,
            this._tspCopiarAlimentador});
            this.cndcToolStrip3.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip3.Name = "cndcToolStrip3";
            this.cndcToolStrip3.Size = new System.Drawing.Size(966, 25);
            this.cndcToolStrip3.TabIndex = 4;
            this.cndcToolStrip3.TablaCampoBD = null;
            this.cndcToolStrip3.Text = "cndcToolStrip3";
            // 
            // _tspIngresarAlimentador
            // 
            this._tspIngresarAlimentador.Image = global::SisFallaUIInforme.Properties.Resources.Add;
            this._tspIngresarAlimentador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspIngresarAlimentador.Name = "_tspIngresarAlimentador";
            this._tspIngresarAlimentador.Size = new System.Drawing.Size(138, 22);
            this._tspIngresarAlimentador.Text = "Ingresar Alimentador";
            this._tspIngresarAlimentador.Click += new System.EventHandler(this._tspIngresarAlimentador_Click);
            // 
            // _tspEditarAlimentador
            // 
            this._tspEditarAlimentador.Image = global::SisFallaUIInforme.Properties.Resources.Edit;
            this._tspEditarAlimentador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspEditarAlimentador.Name = "_tspEditarAlimentador";
            this._tspEditarAlimentador.Size = new System.Drawing.Size(126, 22);
            this._tspEditarAlimentador.Text = "Editar Alimentador";
            this._tspEditarAlimentador.Click += new System.EventHandler(this._tspEditarAlimentador_Click);
            // 
            // _tspBorrarAlimentador
            // 
            this._tspBorrarAlimentador.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._tspBorrarAlimentador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspBorrarAlimentador.Name = "_tspBorrarAlimentador";
            this._tspBorrarAlimentador.Size = new System.Drawing.Size(128, 22);
            this._tspBorrarAlimentador.Text = "Borrar Alimentador";
            this._tspBorrarAlimentador.Click += new System.EventHandler(this._tspBorrarAlimentador_Click);
            // 
            // _tspCopiarAlimentador
            // 
            this._tspCopiarAlimentador.Image = global::SisFallaUIInforme.Properties.Resources.copiarDeInforme;
            this._tspCopiarAlimentador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspCopiarAlimentador.Name = "_tspCopiarAlimentador";
            this._tspCopiarAlimentador.Size = new System.Drawing.Size(235, 22);
            this._tspCopiarAlimentador.Text = "Copiar Alimentador desde otro Informe";
            this._tspCopiarAlimentador.Click += new System.EventHandler(this._tspCopiarAlimentador_Click);
            // 
            // CtrlAlimentadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dgvAlimentadores);
            this.Controls.Add(this.cndcToolStrip3);
            this.Name = "CtrlAlimentadores";
            this.Size = new System.Drawing.Size(966, 304);
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).EndInit();
            this.cndcToolStrip3.ResumeLayout(false);
            this.cndcToolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvAlimentadores;
        private Controles.CNDCToolStrip cndcToolStrip3;
        private System.Windows.Forms.ToolStripButton _tspIngresarAlimentador;
        private System.Windows.Forms.ToolStripButton _tspEditarAlimentador;
        private System.Windows.Forms.ToolStripButton _tspBorrarAlimentador;
        private System.Windows.Forms.ToolStripButton _tspCopiarAlimentador;
    }
}
