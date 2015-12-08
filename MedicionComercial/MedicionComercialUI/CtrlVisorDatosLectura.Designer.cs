namespace MedicionComercialUI
{
    partial class CtrlVisorDatosLectura
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
            this._dgvDatosLectura = new Controles.CNDCGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatosLectura)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcGridView1
            // 
            this._dgvDatosLectura.AllowUserToAddRows = false;
            this._dgvDatosLectura.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDatosLectura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvDatosLectura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDatosLectura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDatosLectura.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvDatosLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDatosLectura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDatosLectura.Location = new System.Drawing.Point(0, 0);
            this._dgvDatosLectura.Name = "cndcGridView1";
            this._dgvDatosLectura.NombreContenedor = null;
            this._dgvDatosLectura.ReadOnly = true;
            this._dgvDatosLectura.RowHeadersWidth = 25;
            this._dgvDatosLectura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDatosLectura.Size = new System.Drawing.Size(758, 524);
            this._dgvDatosLectura.TabIndex = 0;
            this._dgvDatosLectura.TablaCampoBD = null;
            // 
            // CtrlVisorDatosLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dgvDatosLectura);
            this.Name = "CtrlVisorDatosLectura";
            this.Size = new System.Drawing.Size(758, 524);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatosLectura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvDatosLectura;
    }
}
