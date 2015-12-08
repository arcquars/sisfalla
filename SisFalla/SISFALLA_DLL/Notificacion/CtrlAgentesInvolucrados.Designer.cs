namespace SISFALLA
{
    partial class CtrlAgentesInvolucrados
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
            this._btnVisualizarTodos = new Controles.CNDCButton();
            this._dgvContactos = new Controles.CNDCGridView();
            this._dgvAgentesNotificar = new Controles.CNDCGridView();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            ((System.ComponentModel.ISupportInitialize)(this._dgvContactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesNotificar)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnVisualizarTodos
            // 
            this._btnVisualizarTodos.Location = new System.Drawing.Point(457, 183);
            this._btnVisualizarTodos.Margin = new System.Windows.Forms.Padding(0);
            this._btnVisualizarTodos.Name = "_btnVisualizarTodos";
            this._btnVisualizarTodos.Size = new System.Drawing.Size(299, 23);
            this._btnVisualizarTodos.TabIndex = 28;
            this._btnVisualizarTodos.TablaCampoBD = null;
            this._btnVisualizarTodos.Text = "Visualizar todos los contactos.";
            this._btnVisualizarTodos.UseVisualStyleBackColor = true;
            this._btnVisualizarTodos.Click += new System.EventHandler(this._btnVisualizarTodos_Click);
            // 
            // _dgvContactos
            // 
            this._dgvContactos.AllowUserToAddRows = false;
            this._dgvContactos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvContactos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvContactos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvContactos.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvContactos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvContactos.Location = new System.Drawing.Point(406, 0);
            this._dgvContactos.Name = "_dgvContactos";
            this._dgvContactos.ReadOnly = true;
            this._dgvContactos.RowHeadersWidth = 25;
            this._dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvContactos.Size = new System.Drawing.Size(394, 180);
            this._dgvContactos.TabIndex = 27;
            this._dgvContactos.TablaCampoBD = null;
            // 
            // _dgvAgentesNotificar
            // 
            this._dgvAgentesNotificar.AllowUserToAddRows = false;
            this._dgvAgentesNotificar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentesNotificar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvAgentesNotificar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentesNotificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentesNotificar.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvAgentesNotificar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentesNotificar.Location = new System.Drawing.Point(0, 0);
            this._dgvAgentesNotificar.Name = "_dgvAgentesNotificar";
            this._dgvAgentesNotificar.ReadOnly = true;
            this._dgvAgentesNotificar.RowHeadersWidth = 25;
            this._dgvAgentesNotificar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentesNotificar.Size = new System.Drawing.Size(404, 209);
            this._dgvAgentesNotificar.TabIndex = 26;
            this._dgvAgentesNotificar.TablaCampoBD = null;
            this._dgvAgentesNotificar.SelectionChanged += new System.EventHandler(this._dgvAgentesNotificar_SelectionChanged);
            // 
            // CtrlAgentesInvolucrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnVisualizarTodos);
            this.Controls.Add(this._dgvContactos);
            this.Controls.Add(this._dgvAgentesNotificar);
            this.Name = "CtrlAgentesInvolucrados";
            this.Size = new System.Drawing.Size(800, 209);
            ((System.ComponentModel.ISupportInitialize)(this._dgvContactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesNotificar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCButton _btnVisualizarTodos;
        private Controles.CNDCGridView _dgvContactos;
        private Controles.CNDCGridView _dgvAgentesNotificar;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
    }
}
