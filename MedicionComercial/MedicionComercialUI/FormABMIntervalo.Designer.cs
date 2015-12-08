namespace MedicionComercialUI
{
    partial class FormABMIntervalo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvIntervalos = new Controles.CNDCGridView();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._dgvDetalleIntervalo = new Controles.CNDCGridView();
            this._ctrlIntervalo = new MedicionComercialUI.CtrlIntervalo();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIntervalos)).BeginInit();
            this.cndcPanelControl1.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.cndcGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDetalleIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvIntervalos
            // 
            this._dgvIntervalos.AllowUserToAddRows = false;
            this._dgvIntervalos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvIntervalos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvIntervalos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvIntervalos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvIntervalos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvIntervalos.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvIntervalos.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvIntervalos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvIntervalos.Location = new System.Drawing.Point(0, 0);
            this._dgvIntervalos.Name = "_dgvIntervalos";
            this._dgvIntervalos.NombreContenedor = "FormABMMedidores";
            this._dgvIntervalos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvIntervalos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvIntervalos.RowHeadersWidth = 25;
            this._dgvIntervalos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvIntervalos.Size = new System.Drawing.Size(925, 231);
            this._dgvIntervalos.TabIndex = 9;
            this._dgvIntervalos.TablaCampoBD = null;
            this._dgvIntervalos.SelectionChanged += new System.EventHandler(this._dgvIntervalos_SelectionChanged);
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this.cndcGroupBox1);
            this.cndcPanelControl1.Controls.Add(this.cndcToolStrip1);
            this.cndcPanelControl1.Controls.Add(this._ctrlIntervalo);
            this.cndcPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndcPanelControl1.Location = new System.Drawing.Point(0, 231);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(925, 340);
            this.cndcPanelControl1.TabIndex = 11;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnGuardar,
            this._btnEditar,
            this._btnDarBaja,
            this._btnCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(925, 25);
            this.cndcToolStrip1.TabIndex = 15;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(58, 22);
            this._btnAdicionar.Text = "Nuevo";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Enabled = false;
            this._btnGuardar.Image = global::MedicionComercialUI.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(66, 22);
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(55, 22);
            this._btnEditar.Text = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnDarBaja
            // 
            this._btnDarBaja.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnDarBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnDarBaja.Name = "_btnDarBaja";
            this._btnDarBaja.Size = new System.Drawing.Size(68, 22);
            this._btnDarBaja.Text = "Dar Baja";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Enabled = false;
            this._btnCancelar.Image = global::MedicionComercialUI.Properties.Resources.disable__v3929;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._dgvDetalleIntervalo);
            this.cndcGroupBox1.Location = new System.Drawing.Point(508, 28);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(374, 293);
            this.cndcGroupBox1.TabIndex = 16;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Detalle";
            // 
            // _dgvDetalleIntervalo
            // 
            this._dgvDetalleIntervalo.AllowUserToAddRows = false;
            this._dgvDetalleIntervalo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDetalleIntervalo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvDetalleIntervalo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDetalleIntervalo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDetalleIntervalo.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvDetalleIntervalo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDetalleIntervalo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDetalleIntervalo.Location = new System.Drawing.Point(3, 16);
            this._dgvDetalleIntervalo.Name = "_dgvDetalleIntervalo";
            this._dgvDetalleIntervalo.NombreContenedor = null;
            this._dgvDetalleIntervalo.ReadOnly = true;
            this._dgvDetalleIntervalo.RowHeadersWidth = 25;
            this._dgvDetalleIntervalo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDetalleIntervalo.Size = new System.Drawing.Size(368, 274);
            this._dgvDetalleIntervalo.TabIndex = 0;
            this._dgvDetalleIntervalo.TablaCampoBD = null;
            // 
            // _ctrlIntervalo
            // 
            this._ctrlIntervalo.Location = new System.Drawing.Point(81, 61);
            this._ctrlIntervalo.Name = "_ctrlIntervalo";
            this._ctrlIntervalo.Size = new System.Drawing.Size(396, 132);
            this._ctrlIntervalo.TabIndex = 10;
            // 
            // FormABMIntervalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 571);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._dgvIntervalos);
            this.Name = "FormABMIntervalo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormABMIntervalo";
            ((System.ComponentModel.ISupportInitialize)(this._dgvIntervalos)).EndInit();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.cndcGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDetalleIntervalo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvIntervalos;
        private CtrlIntervalo _ctrlIntervalo;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGridView _dgvDetalleIntervalo;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnDarBaja;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
    }
}