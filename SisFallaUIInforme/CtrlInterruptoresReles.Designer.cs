namespace SISFALLA
{
    partial class CtrlInterruptoresReles
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
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._dgvReles = new Controles.CNDCGridView();
            this._dgvInterruptor = new Controles.CNDCGridView();
            this.cndcToolStrip2 = new Controles.CNDCToolStrip();
            this._tspIngresarInterruptor = new System.Windows.Forms.ToolStripButton();
            this._tspEditarInterruptor = new System.Windows.Forms.ToolStripButton();
            this._tspBorrarInterruptor = new System.Windows.Forms.ToolStripButton();
            this._tspCopiarInterruptor = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvReles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvInterruptor)).BeginInit();
            this.cndcToolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(8, 167);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(89, 13);
            this.cndcLabelControl1.TabIndex = 8;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Relés Operados :";
            // 
            // _dgvReles
            // 
            this._dgvReles.AllowUserToAddRows = false;
            this._dgvReles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvReles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvReles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dgvReles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvReles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvReles.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvReles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvReles.Location = new System.Drawing.Point(3, 183);
            this._dgvReles.Name = "_dgvReles";
            this._dgvReles.ReadOnly = true;
            this._dgvReles.RowHeadersWidth = 15;
            this._dgvReles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvReles.ShowRowErrors = false;
            this._dgvReles.Size = new System.Drawing.Size(727, 121);
            this._dgvReles.TabIndex = 7;
            this._dgvReles.TablaCampoBD = null;
            // 
            // _dgvInterruptor
            // 
            this._dgvInterruptor.AllowUserToAddRows = false;
            this._dgvInterruptor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvInterruptor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvInterruptor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvInterruptor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvInterruptor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvInterruptor.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvInterruptor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvInterruptor.Location = new System.Drawing.Point(3, 28);
            this._dgvInterruptor.Name = "_dgvInterruptor";
            this._dgvInterruptor.ReadOnly = true;
            this._dgvInterruptor.RowHeadersWidth = 15;
            this._dgvInterruptor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvInterruptor.ShowRowErrors = false;
            this._dgvInterruptor.Size = new System.Drawing.Size(922, 122);
            this._dgvInterruptor.TabIndex = 6;
            this._dgvInterruptor.TablaCampoBD = null;
            this._dgvInterruptor.SelectionChanged += new System.EventHandler(this._dgvInterruptor_SelectionChanged);
            // 
            // cndcToolStrip2
            // 
            this.cndcToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tspIngresarInterruptor,
            this._tspEditarInterruptor,
            this._tspBorrarInterruptor,
            this._tspCopiarInterruptor});
            this.cndcToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip2.Name = "cndcToolStrip2";
            this.cndcToolStrip2.Size = new System.Drawing.Size(933, 25);
            this.cndcToolStrip2.TabIndex = 5;
            this.cndcToolStrip2.TablaCampoBD = null;
            this.cndcToolStrip2.Text = "cndcToolStrip2";
            // 
            // _tspIngresarInterruptor
            // 
            this._tspIngresarInterruptor.Image = global::SisFallaUIInforme.Properties.Resources.Add;
            this._tspIngresarInterruptor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspIngresarInterruptor.Name = "_tspIngresarInterruptor";
            this._tspIngresarInterruptor.Size = new System.Drawing.Size(129, 22);
            this._tspIngresarInterruptor.Text = "Ingresar Interruptor";
            this._tspIngresarInterruptor.Click += new System.EventHandler(this._tspIngresarInterruptor_Click);
            // 
            // _tspEditarInterruptor
            // 
            this._tspEditarInterruptor.Image = global::SisFallaUIInforme.Properties.Resources.Edit;
            this._tspEditarInterruptor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspEditarInterruptor.Name = "_tspEditarInterruptor";
            this._tspEditarInterruptor.Size = new System.Drawing.Size(117, 22);
            this._tspEditarInterruptor.Text = "Editar Interruptor";
            this._tspEditarInterruptor.Click += new System.EventHandler(this._tspEditarInterruptor_Click);
            // 
            // _tspBorrarInterruptor
            // 
            this._tspBorrarInterruptor.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._tspBorrarInterruptor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspBorrarInterruptor.Name = "_tspBorrarInterruptor";
            this._tspBorrarInterruptor.Size = new System.Drawing.Size(119, 22);
            this._tspBorrarInterruptor.Text = "Borrar Interruptor";
            this._tspBorrarInterruptor.Click += new System.EventHandler(this._tspBorrarInterruptor_Click);
            // 
            // _tspCopiarInterruptor
            // 
            this._tspCopiarInterruptor.Image = global::SisFallaUIInforme.Properties.Resources.copiarDeInforme;
            this._tspCopiarInterruptor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tspCopiarInterruptor.Name = "_tspCopiarInterruptor";
            this._tspCopiarInterruptor.Size = new System.Drawing.Size(226, 22);
            this._tspCopiarInterruptor.Text = "Copiar Interruptor desde otro Informe";
            this._tspCopiarInterruptor.Click += new System.EventHandler(this._tspCopiarInterruptor_Click);
            // 
            // CtrlInterruptoresReles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._dgvReles);
            this.Controls.Add(this._dgvInterruptor);
            this.Controls.Add(this.cndcToolStrip2);
            this.Name = "CtrlInterruptoresReles";
            this.Size = new System.Drawing.Size(933, 312);
            ((System.ComponentModel.ISupportInitialize)(this._dgvReles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvInterruptor)).EndInit();
            this.cndcToolStrip2.ResumeLayout(false);
            this.cndcToolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCGridView _dgvReles;
        private Controles.CNDCGridView _dgvInterruptor;
        private Controles.CNDCToolStrip cndcToolStrip2;
        private System.Windows.Forms.ToolStripButton _tspIngresarInterruptor;
        private System.Windows.Forms.ToolStripButton _tspEditarInterruptor;
        private System.Windows.Forms.ToolStripButton _tspBorrarInterruptor;
        private System.Windows.Forms.ToolStripButton _tspCopiarInterruptor;
    }
}
