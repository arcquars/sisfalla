namespace MedicionComercialUI
{
    partial class CtrlMedidorFto
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dgvFormatos = new Controles.CNDCGridView();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dgvDetMagnitudesElectricas = new Controles.CNDCGridView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionarFormato = new System.Windows.Forms.ToolStripButton();
            this._btnEditarFormato = new System.Windows.Forms.ToolStripButton();
            this._btnEliminarFormato = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.cndcPanelControl2 = new Controles.CNDCPanelControl();
            this.cndcToolStrip2 = new Controles.CNDCToolStrip();
            this._btnAdicionarMagnitud = new System.Windows.Forms.ToolStripButton();
            this._btnEditarMagnitud = new System.Windows.Forms.ToolStripButton();
            this._btnEliminarMagnitud = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvFormatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDetMagnitudesElectricas)).BeginInit();
            this.cndcToolStrip1.SuspendLayout();
            this.cndcPanelControl1.SuspendLayout();
            this.cndcPanelControl2.SuspendLayout();
            this.cndcToolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(1, 7);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(53, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Formatos:";
            // 
            // _dgvFormatos
            // 
            this._dgvFormatos.AllowUserToAddRows = false;
            this._dgvFormatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvFormatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvFormatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._dgvFormatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvFormatos.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvFormatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvFormatos.Location = new System.Drawing.Point(4, 23);
            this._dgvFormatos.Name = "_dgvFormatos";
            this._dgvFormatos.NombreContenedor = "CtrlMedidorFto";
            this._dgvFormatos.ReadOnly = true;
            this._dgvFormatos.RowHeadersWidth = 25;
            this._dgvFormatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvFormatos.Size = new System.Drawing.Size(336, 210);
            this._dgvFormatos.TabIndex = 2;
            this._dgvFormatos.TablaCampoBD = null;
            this._dgvFormatos.SelectionChanged += new System.EventHandler(this._dgvFormatos_SelectionChanged);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(274, 7);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(153, 13);
            this.cndcLabel2.TabIndex = 3;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Detalle - Magnitudes Eléctricas";
            // 
            // _dgvDetMagnitudesElectricas
            // 
            this._dgvDetMagnitudesElectricas.AllowUserToAddRows = false;
            this._dgvDetMagnitudesElectricas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDetMagnitudesElectricas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvDetMagnitudesElectricas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvDetMagnitudesElectricas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDetMagnitudesElectricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDetMagnitudesElectricas.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvDetMagnitudesElectricas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDetMagnitudesElectricas.Location = new System.Drawing.Point(346, 23);
            this._dgvDetMagnitudesElectricas.Name = "_dgvDetMagnitudesElectricas";
            this._dgvDetMagnitudesElectricas.NombreContenedor = "CtrlMedidorFto";
            this._dgvDetMagnitudesElectricas.RowHeadersWidth = 25;
            this._dgvDetMagnitudesElectricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDetMagnitudesElectricas.Size = new System.Drawing.Size(523, 210);
            this._dgvDetMagnitudesElectricas.TabIndex = 4;
            this._dgvDetMagnitudesElectricas.TablaCampoBD = null;
            this._dgvDetMagnitudesElectricas.SelectionChanged += new System.EventHandler(this._dgvDetMagnitudesElectricas_SelectionChanged);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionarFormato,
            this._btnEditarFormato,
            this._btnEliminarFormato,
            this.toolStripButton6,
            this.toolStripButton5});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(336, 25);
            this.cndcToolStrip1.TabIndex = 5;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionarFormato
            // 
            this._btnAdicionarFormato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionarFormato.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnAdicionarFormato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionarFormato.Name = "_btnAdicionarFormato";
            this._btnAdicionarFormato.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionarFormato.Text = "toolStripButton1";
            this._btnAdicionarFormato.Click += new System.EventHandler(this._btnAdicionarFormato_Click);
            // 
            // _btnEditarFormato
            // 
            this._btnEditarFormato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditarFormato.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditarFormato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditarFormato.Name = "_btnEditarFormato";
            this._btnEditarFormato.Size = new System.Drawing.Size(23, 22);
            this._btnEditarFormato.Text = "toolStripButton2";
            this._btnEditarFormato.Click += new System.EventHandler(this._btnEditarFormato_Click);
            // 
            // _btnEliminarFormato
            // 
            this._btnEliminarFormato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminarFormato.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnEliminarFormato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminarFormato.Name = "_btnEliminarFormato";
            this._btnEliminarFormato.Size = new System.Drawing.Size(23, 22);
            this._btnEliminarFormato.Text = "toolStripButton3";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::MedicionComercialUI.Properties.Resources.bajar;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::MedicionComercialUI.Properties.Resources.subir;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cndcPanelControl1.Controls.Add(this.cndcToolStrip1);
            this.cndcPanelControl1.Location = new System.Drawing.Point(4, 236);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(336, 26);
            this.cndcPanelControl1.TabIndex = 6;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // cndcPanelControl2
            // 
            this.cndcPanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cndcPanelControl2.Controls.Add(this.cndcToolStrip2);
            this.cndcPanelControl2.Location = new System.Drawing.Point(346, 236);
            this.cndcPanelControl2.Name = "cndcPanelControl2";
            this.cndcPanelControl2.Size = new System.Drawing.Size(523, 26);
            this.cndcPanelControl2.TabIndex = 7;
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
            this.cndcToolStrip2.Size = new System.Drawing.Size(523, 25);
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
            // CtrlMedidorFto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcPanelControl2);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._dgvDetMagnitudesElectricas);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._dgvFormatos);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlMedidorFto";
            this.Size = new System.Drawing.Size(872, 267);
            ((System.ComponentModel.ISupportInitialize)(this._dgvFormatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDetMagnitudesElectricas)).EndInit();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.cndcPanelControl2.ResumeLayout(false);
            this.cndcPanelControl2.PerformLayout();
            this.cndcToolStrip2.ResumeLayout(false);
            this.cndcToolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCGridView _dgvFormatos;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCGridView _dgvDetMagnitudesElectricas;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionarFormato;
        private System.Windows.Forms.ToolStripButton _btnEditarFormato;
        private System.Windows.Forms.ToolStripButton _btnEliminarFormato;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCPanelControl cndcPanelControl2;
        private Controles.CNDCToolStrip cndcToolStrip2;
        private System.Windows.Forms.ToolStripButton _btnAdicionarMagnitud;
        private System.Windows.Forms.ToolStripButton _btnEditarMagnitud;
        private System.Windows.Forms.ToolStripButton _btnEliminarMagnitud;
    }
}
