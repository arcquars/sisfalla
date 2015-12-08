namespace SISFALLA
{
    partial class CtrlAsignacionResponsabilidad
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
            this._lblTiempoTot = new Controles.CNDCLabel();
            this.cndcLabelControl8 = new Controles.CNDCLabel();
            this._pnlTool = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._dgvAsigResp = new Controles.CNDCGridView();
            this._txtTTotal = new Controles.CNDCLabelFloat();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtPorOperacion = new Controles.CNDCTextBoxFloat();
            this._txtPorSistema = new Controles.CNDCTextBoxFloat();
            this._pnlTool.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAsigResp)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblTiempoTot
            // 
            this._lblTiempoTot.AutoSize = true;
            this._lblTiempoTot.Location = new System.Drawing.Point(56, 62);
            this._lblTiempoTot.Name = "_lblTiempoTot";
            this._lblTiempoTot.Size = new System.Drawing.Size(72, 13);
            this._lblTiempoTot.TabIndex = 136;
            this._lblTiempoTot.TablaCampoBD = null;
            this._lblTiempoTot.Text = "Tiempo Total:";
            // 
            // cndcLabelControl8
            // 
            this.cndcLabelControl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl8.Location = new System.Drawing.Point(3, 0);
            this.cndcLabelControl8.Name = "cndcLabelControl8";
            this.cndcLabelControl8.Size = new System.Drawing.Size(174, 13);
            this.cndcLabelControl8.TabIndex = 135;
            this.cndcLabelControl8.TablaCampoBD = null;
            this.cndcLabelControl8.Text = "ASIGNACIÓN DE RESP.(min)";
            this.cndcLabelControl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlTool
            // 
            this._pnlTool.Controls.Add(this.cndcToolStrip1);
            this._pnlTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnlTool.Location = new System.Drawing.Point(0, 188);
            this._pnlTool.Name = "_pnlTool";
            this._pnlTool.Size = new System.Drawing.Size(180, 25);
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
            this.cndcToolStrip1.Size = new System.Drawing.Size(180, 25);
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
            this._btnAdicionar.ToolTipText = "Adicionar";
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
            this._btnEditar.ToolTipText = "Editar";
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
            this._btnEliminar.ToolTipText = "Borrar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // _dgvAsigResp
            // 
            this._dgvAsigResp.AllowUserToAddRows = false;
            this._dgvAsigResp.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAsigResp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAsigResp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAsigResp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAsigResp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAsigResp.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAsigResp.GridColor = System.Drawing.Color.Gray;
            this._dgvAsigResp.Location = new System.Drawing.Point(0, 78);
            this._dgvAsigResp.MultiSelect = false;
            this._dgvAsigResp.Name = "_dgvAsigResp";
            this._dgvAsigResp.ReadOnly = true;
            this._dgvAsigResp.RowHeadersWidth = 15;
            this._dgvAsigResp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAsigResp.Size = new System.Drawing.Size(177, 106);
            this._dgvAsigResp.TabIndex = 133;
            this._dgvAsigResp.TablaCampoBD = null;
            this._dgvAsigResp.SelectionChanged += new System.EventHandler(this._dgvAsigResp_SelectionChanged);
            // 
            // _txtTTotal
            // 
            this._txtTTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTTotal.Location = new System.Drawing.Point(131, 58);
            this._txtTTotal.Margin = new System.Windows.Forms.Padding(0);
            this._txtTTotal.Name = "_txtTTotal";
            this._txtTTotal.Size = new System.Drawing.Size(46, 20);
            this._txtTTotal.TabIndex = 138;
            this._txtTTotal.Text = "0,00";
            this._txtTTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._txtTTotal.Value = 0F;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(52, 20);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(78, 13);
            this.cndcLabel1.TabIndex = 139;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Por Operación:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(63, 40);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel2.TabIndex = 140;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Por Sistema:";
            // 
            // _txtPorOperacion
            // 
            this._txtPorOperacion.EnterComoTab = true;
            this._txtPorOperacion.Etiqueta = null;
            this._txtPorOperacion.Location = new System.Drawing.Point(132, 17);
            this._txtPorOperacion.Name = "_txtPorOperacion";
            this._txtPorOperacion.Size = new System.Drawing.Size(46, 20);
            this._txtPorOperacion.TabIndex = 141;
            this._txtPorOperacion.TablaCampoBD = null;
            this._txtPorOperacion.Text = ",00";
            this._txtPorOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPorOperacion.ValDouble = 0D;
            this._txtPorOperacion.Value = 0F;
            this._txtPorOperacion.Validated += new System.EventHandler(this._txtPorOperacion_Validated);
            // 
            // _txtPorSistema
            // 
            this._txtPorSistema.EnterComoTab = true;
            this._txtPorSistema.Etiqueta = null;
            this._txtPorSistema.Location = new System.Drawing.Point(132, 37);
            this._txtPorSistema.Name = "_txtPorSistema";
            this._txtPorSistema.Size = new System.Drawing.Size(46, 20);
            this._txtPorSistema.TabIndex = 142;
            this._txtPorSistema.TablaCampoBD = null;
            this._txtPorSistema.Text = ",00";
            this._txtPorSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPorSistema.ValDouble = 0D;
            this._txtPorSistema.Value = 0F;
            this._txtPorSistema.Validated += new System.EventHandler(this._txtPorOperacion_Validated);
            // 
            // CtrlAsignacionResponsabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtPorSistema);
            this.Controls.Add(this._txtPorOperacion);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._txtTTotal);
            this.Controls.Add(this._lblTiempoTot);
            this.Controls.Add(this.cndcLabelControl8);
            this.Controls.Add(this._pnlTool);
            this.Controls.Add(this._dgvAsigResp);
            this.MaximumSize = new System.Drawing.Size(180, 220);
            this.Name = "CtrlAsignacionResponsabilidad";
            this.Size = new System.Drawing.Size(180, 213);
            this._pnlTool.ResumeLayout(false);
            this._pnlTool.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAsigResp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel _lblTiempoTot;
        private Controles.CNDCLabel cndcLabelControl8;
        private Controles.CNDCPanelControl _pnlTool;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCGridView _dgvAsigResp;
        private Controles.CNDCLabelFloat _txtTTotal;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBoxFloat _txtPorOperacion;
        private Controles.CNDCTextBoxFloat _txtPorSistema;
    }
}
