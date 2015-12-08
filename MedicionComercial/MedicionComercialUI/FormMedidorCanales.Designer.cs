namespace MedicionComercialUI
{
    partial class FormMedidorCanales
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
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._ctrlResumenMedidor = new MedicionComercialUI.CtrlResumenMedidor();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this.ctrlMedidorCanal1 = new MedicionComercialUI.CtrlMedidorCanal();
            this._dgvMedidorCanales = new Controles.CNDCGridView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnNuevo = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMedidorCanales)).BeginInit();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._ctrlResumenMedidor);
            this.cndcGroupBox1.Location = new System.Drawing.Point(12, 6);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(747, 148);
            this.cndcGroupBox1.TabIndex = 3;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Medidor";
            // 
            // _ctrlResumenMedidor
            // 
            this._ctrlResumenMedidor.Location = new System.Drawing.Point(165, 9);
            this._ctrlResumenMedidor.Name = "_ctrlResumenMedidor";
            this._ctrlResumenMedidor.Size = new System.Drawing.Size(406, 133);
            this._ctrlResumenMedidor.TabIndex = 0;
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this.ctrlMedidorCanal1);
            this.cndcGroupBox2.Controls.Add(this._dgvMedidorCanales);
            this.cndcGroupBox2.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox2.Location = new System.Drawing.Point(12, 160);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(747, 401);
            this.cndcGroupBox2.TabIndex = 4;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Canales";
            // 
            // ctrlMedidorCanal1
            // 
            this.ctrlMedidorCanal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlMedidorCanal1.Location = new System.Drawing.Point(94, 47);
            this.ctrlMedidorCanal1.Name = "ctrlMedidorCanal1";
            this.ctrlMedidorCanal1.Size = new System.Drawing.Size(557, 82);
            this.ctrlMedidorCanal1.TabIndex = 5;
            // 
            // _dgvMedidorCanales
            // 
            this._dgvMedidorCanales.AllowUserToAddRows = false;
            this._dgvMedidorCanales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMedidorCanales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvMedidorCanales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMedidorCanales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvMedidorCanales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMedidorCanales.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvMedidorCanales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMedidorCanales.Location = new System.Drawing.Point(3, 135);
            this._dgvMedidorCanales.Name = "_dgvMedidorCanales";
            this._dgvMedidorCanales.NombreContenedor = null;
            this._dgvMedidorCanales.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMedidorCanales.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvMedidorCanales.RowHeadersWidth = 25;
            this._dgvMedidorCanales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMedidorCanales.Size = new System.Drawing.Size(740, 260);
            this._dgvMedidorCanales.TabIndex = 4;
            this._dgvMedidorCanales.TablaCampoBD = null;
            this._dgvMedidorCanales.SelectionChanged += new System.EventHandler(this._dgvMedidorCanales_SelectionChanged);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnNuevo,
            this._btnEditar,
            this._btnCancelar,
            this._btnDarBaja});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(741, 25);
            this.cndcToolStrip1.TabIndex = 3;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnNuevo
            // 
            this._btnNuevo.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(58, 22);
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            // 
            // _btnDarBaja
            // 
            this._btnDarBaja.Image = global::MedicionComercialUI.Properties.Resources.disable__v3929;
            this._btnDarBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnDarBaja.Name = "_btnDarBaja";
            this._btnDarBaja.Size = new System.Drawing.Size(68, 22);
            this._btnDarBaja.Text = "Dar Baja";
            // 
            // FormMedidorCanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 564);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMedidorCanales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMedidorCanales";
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMedidorCanales)).EndInit();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnNuevo;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnDarBaja;
        private Controles.CNDCGridView _dgvMedidorCanales;
        private CtrlMedidorCanal ctrlMedidorCanal1;
        private CtrlResumenMedidor _ctrlResumenMedidor;
    }
}