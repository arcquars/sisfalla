namespace SISFALLA
{
    partial class CtrlComponentesComprometidos
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
            this._dgvCompoComprometido = new Controles.CNDCGridView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._tspIngresarCompo = new System.Windows.Forms.ToolStripButton();
            this._tspEditarCompo = new System.Windows.Forms.ToolStripButton();
            this._tspBorrarCompo = new System.Windows.Forms.ToolStripButton();
            this._ctrlAsignacionResponsabilidad = new SISFALLA.CtrlAsignacionResponsabilidad();
            this._ctrlTiemposDetalle = new SISFALLA.CtrlTiempoDetalle();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCompoComprometido)).BeginInit();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvCompoComprometido
            // 
            this._dgvCompoComprometido.AllowUserToAddRows = false;
            this._dgvCompoComprometido.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvCompoComprometido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvCompoComprometido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvCompoComprometido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvCompoComprometido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvCompoComprometido.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvCompoComprometido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvCompoComprometido.Location = new System.Drawing.Point(3, 28);
            this._dgvCompoComprometido.Name = "_dgvCompoComprometido";
            this._dgvCompoComprometido.ReadOnly = true;
            this._dgvCompoComprometido.RowHeadersWidth = 15;
            this._dgvCompoComprometido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvCompoComprometido.Size = new System.Drawing.Size(893, 125);
            this._dgvCompoComprometido.TabIndex = 90;
            this._dgvCompoComprometido.TablaCampoBD = null;
            this._dgvCompoComprometido.SelectionChanged += new System.EventHandler(this._dgvCompoComprometido_SelectionChanged);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tspIngresarCompo,
            this._tspEditarCompo,
            this._tspBorrarCompo});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(903, 25);
            this.cndcToolStrip1.TabIndex = 89;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _tspIngresarCompo
            // 
            this._tspIngresarCompo.Image = global::SISFALLA.Properties.Resources.Add;
            this._tspIngresarCompo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspIngresarCompo.Name = "_tspIngresarCompo";
            this._tspIngresarCompo.Size = new System.Drawing.Size(142, 22);
            this._tspIngresarCompo.Text = "Ingresar Componente";
            this._tspIngresarCompo.Click += new System.EventHandler(this._tspIngresarCompo_Click);
            // 
            // _tspEditarCompo
            // 
            this._tspEditarCompo.Image = global::SISFALLA.Properties.Resources.Edit;
            this._tspEditarCompo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspEditarCompo.Name = "_tspEditarCompo";
            this._tspEditarCompo.Size = new System.Drawing.Size(130, 22);
            this._tspEditarCompo.Text = "Editar Componente";
            this._tspEditarCompo.Click += new System.EventHandler(this._tspEditarCompo_Click);
            // 
            // _tspBorrarCompo
            // 
            this._tspBorrarCompo.Image = global::SISFALLA.Properties.Resources.Delete;
            this._tspBorrarCompo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspBorrarCompo.Name = "_tspBorrarCompo";
            this._tspBorrarCompo.Size = new System.Drawing.Size(132, 22);
            this._tspBorrarCompo.Text = "Borrar Componente";
            this._tspBorrarCompo.Click += new System.EventHandler(this._tspBorrarCompo_Click);
            // 
            // _ctrlAsignacionResponsabilidad
            // 
            this._ctrlAsignacionResponsabilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._ctrlAsignacionResponsabilidad.Location = new System.Drawing.Point(594, 159);
            this._ctrlAsignacionResponsabilidad.MaximumSize = new System.Drawing.Size(180, 220);
            this._ctrlAsignacionResponsabilidad.Name = "_ctrlAsignacionResponsabilidad";
            this._ctrlAsignacionResponsabilidad.PanelToolVisible = false;
            this._ctrlAsignacionResponsabilidad.Size = new System.Drawing.Size(180, 193);
            this._ctrlAsignacionResponsabilidad.SoloLectura = true;
            this._ctrlAsignacionResponsabilidad.TabIndex = 171;
            this._ctrlAsignacionResponsabilidad.TiempoPOper = 0F;
            this._ctrlAsignacionResponsabilidad.TiempoPSist = 0F;
            this._ctrlAsignacionResponsabilidad.TiempoTotalSistema = 0F;
            // 
            // _ctrlTiemposDetalle
            // 
            this._ctrlTiemposDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._ctrlTiemposDetalle.Location = new System.Drawing.Point(71, 159);
            this._ctrlTiemposDetalle.Name = "_ctrlTiemposDetalle";
            this._ctrlTiemposDetalle.PanelToolVisible = false;
            this._ctrlTiemposDetalle.Size = new System.Drawing.Size(522, 193);
            this._ctrlTiemposDetalle.SoloLectura = true;
            this._ctrlTiemposDetalle.TabIndex = 170;
            this._ctrlTiemposDetalle.TiempoConexion = 0F;
            this._ctrlTiemposDetalle.TiempoIndisponibilidad = 0F;
            this._ctrlTiemposDetalle.TiempoPreconexion = 0F;
            // 
            // CtrlComponentesComprometidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ctrlAsignacionResponsabilidad);
            this.Controls.Add(this._ctrlTiemposDetalle);
            this.Controls.Add(this._dgvCompoComprometido);
            this.Controls.Add(this.cndcToolStrip1);
            this.Name = "CtrlComponentesComprometidos";
            this.Size = new System.Drawing.Size(903, 353);
            ((System.ComponentModel.ISupportInitialize)(this._dgvCompoComprometido)).EndInit();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvCompoComprometido;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _tspIngresarCompo;
        private System.Windows.Forms.ToolStripButton _tspEditarCompo;
        private System.Windows.Forms.ToolStripButton _tspBorrarCompo;
        private CtrlTiempoDetalle _ctrlTiemposDetalle;
        private CtrlAsignacionResponsabilidad _ctrlAsignacionResponsabilidad;
    }
}
