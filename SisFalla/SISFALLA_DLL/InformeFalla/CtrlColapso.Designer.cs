namespace SISFALLA
{
    partial class CtrlColapso
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
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._tbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this._dgvZonas = new Controles.CNDCGridView();
            this._rbtnParcial = new Controles.CNDCRadioButton();
            this._rbtnTotal = new Controles.CNDCRadioButton();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvZonas)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tbtnGuardar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(251, 25);
            this.cndcToolStrip1.TabIndex = 60;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _tbtnGuardar
            // 
            this._tbtnGuardar.Image = global::SISFALLA.Properties.Resources.save;
            this._tbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnGuardar.Name = "_tbtnGuardar";
            this._tbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this._tbtnGuardar.Text = "Guardar";
            this._tbtnGuardar.Click += new System.EventHandler(this._tbtnGuardar_Click);
            // 
            // _dgvZonas
            // 
            this._dgvZonas.AllowUserToAddRows = false;
            this._dgvZonas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvZonas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvZonas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._dgvZonas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvZonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvZonas.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvZonas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvZonas.Location = new System.Drawing.Point(3, 55);
            this._dgvZonas.Name = "_dgvZonas";
            this._dgvZonas.RowHeadersWidth = 25;
            this._dgvZonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvZonas.Size = new System.Drawing.Size(245, 134);
            this._dgvZonas.TabIndex = 62;
            this._dgvZonas.TablaCampoBD = null;
            // 
            // _rbtnParcial
            // 
            this._rbtnParcial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._rbtnParcial.AutoSize = true;
            this._rbtnParcial.Checked = true;
            this._rbtnParcial.Location = new System.Drawing.Point(141, 29);
            this._rbtnParcial.Name = "_rbtnParcial";
            this._rbtnParcial.Size = new System.Drawing.Size(57, 17);
            this._rbtnParcial.TabIndex = 61;
            this._rbtnParcial.TablaCampoBD = null;
            this._rbtnParcial.TabStop = true;
            this._rbtnParcial.Text = "Parcial";
            this._rbtnParcial.UseVisualStyleBackColor = true;
            this._rbtnParcial.Click += new System.EventHandler(this._rbtnTotal_Click);
            // 
            // _rbtnTotal
            // 
            this._rbtnTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._rbtnTotal.AutoSize = true;
            this._rbtnTotal.Location = new System.Drawing.Point(74, 29);
            this._rbtnTotal.Name = "_rbtnTotal";
            this._rbtnTotal.Size = new System.Drawing.Size(49, 17);
            this._rbtnTotal.TabIndex = 63;
            this._rbtnTotal.TablaCampoBD = null;
            this._rbtnTotal.TabStop = true;
            this._rbtnTotal.Text = "Total";
            this._rbtnTotal.UseVisualStyleBackColor = true;
            this._rbtnTotal.Click += new System.EventHandler(this._rbtnTotal_Click);
            // 
            // CtrlColapso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dgvZonas);
            this.Controls.Add(this._rbtnParcial);
            this.Controls.Add(this._rbtnTotal);
            this.Controls.Add(this.cndcToolStrip1);
            this.Name = "CtrlColapso";
            this.Size = new System.Drawing.Size(251, 196);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvZonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _tbtnGuardar;
        private Controles.CNDCGridView _dgvZonas;
        private Controles.CNDCRadioButton _rbtnParcial;
        private Controles.CNDCRadioButton _rbtnTotal;
    }
}
