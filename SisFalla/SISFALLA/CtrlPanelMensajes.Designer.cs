namespace SISFALLA
{
    partial class CtrlPanelMensajes
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
            this._btnBorrarMensaje = new Controles.CNDCButton();
            this._txtDetalleMensaje = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dgvMensajes = new Controles.CNDCGridView();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnBorrarMensaje
            // 
            this._btnBorrarMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBorrarMensaje.Location = new System.Drawing.Point(423, 0);
            this._btnBorrarMensaje.Name = "_btnBorrarMensaje";
            this._btnBorrarMensaje.Size = new System.Drawing.Size(114, 23);
            this._btnBorrarMensaje.TabIndex = 3;
            this._btnBorrarMensaje.TablaCampoBD = null;
            this._btnBorrarMensaje.Text = "Borrar Mensaje";
            this._btnBorrarMensaje.UseVisualStyleBackColor = true;
            this._btnBorrarMensaje.Click += new System.EventHandler(this._btnBorrarMensaje_Click);
            // 
            // _txtDetalleMensaje
            // 
            this._txtDetalleMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDetalleMensaje.EnterComoTab = false;
            this._txtDetalleMensaje.Etiqueta = null;
            this._txtDetalleMensaje.Location = new System.Drawing.Point(1, 24);
            this._txtDetalleMensaje.Multiline = true;
            this._txtDetalleMensaje.Name = "_txtDetalleMensaje";
            this._txtDetalleMensaje.Size = new System.Drawing.Size(536, 65);
            this._txtDetalleMensaje.TabIndex = 2;
            this._txtDetalleMensaje.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(3, 5);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(58, 13);
            this.cndcLabel2.TabIndex = 1;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "DETALLE:";
            // 
            // _dgvMensajes
            // 
            this._dgvMensajes.AllowUserToAddRows = false;
            this._dgvMensajes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMensajes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvMensajes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMensajes.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvMensajes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMensajes.Location = new System.Drawing.Point(1, 92);
            this._dgvMensajes.Name = "_dgvMensajes";
            this._dgvMensajes.ReadOnly = true;
            this._dgvMensajes.RowHeadersWidth = 25;
            this._dgvMensajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMensajes.Size = new System.Drawing.Size(536, 100);
            this._dgvMensajes.TabIndex = 0;
            this._dgvMensajes.TablaCampoBD = null;
            this._dgvMensajes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvMensajes_CellFormatting);
            this._dgvMensajes.SelectionChanged += new System.EventHandler(this._dgvMensajes_SelectionChanged);
            // 
            // CtrlPanelMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dgvMensajes);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._btnBorrarMensaje);
            this.Controls.Add(this._txtDetalleMensaje);
            this.Name = "CtrlPanelMensajes";
            this.Size = new System.Drawing.Size(540, 194);
            ((System.ComponentModel.ISupportInitialize)(this._dgvMensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtDetalleMensaje;
        private Controles.CNDCButton _btnBorrarMensaje;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCGridView _dgvMensajes;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
    }
}
