namespace MedicionComercialUI
{
    partial class FormABMDefCanales
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
            this._dgvMagnitudElectrica = new Controles.CNDCGridView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnNuevo = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this._ctrlDefCanal = new MedicionComercialUI.CtrlDefCanal();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMagnitudElectrica)).BeginInit();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvMagnitudElectrica
            // 
            this._dgvMagnitudElectrica.AllowUserToAddRows = false;
            this._dgvMagnitudElectrica.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMagnitudElectrica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvMagnitudElectrica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvMagnitudElectrica.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMagnitudElectrica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvMagnitudElectrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMagnitudElectrica.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvMagnitudElectrica.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMagnitudElectrica.Location = new System.Drawing.Point(8, 168);
            this._dgvMagnitudElectrica.Name = "_dgvMagnitudElectrica";
            this._dgvMagnitudElectrica.NombreContenedor = null;
            this._dgvMagnitudElectrica.ReadOnly = true;
            this._dgvMagnitudElectrica.RowHeadersWidth = 25;
            this._dgvMagnitudElectrica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMagnitudElectrica.Size = new System.Drawing.Size(756, 208);
            this._dgvMagnitudElectrica.TabIndex = 0;
            this._dgvMagnitudElectrica.TablaCampoBD = null;
            this._dgvMagnitudElectrica.SelectionChanged += new System.EventHandler(this._dgvDefCanales_SelectionChanged);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnNuevo,
            this._btnEditar,
            this._btnCancelar,
            this._btnDarBaja});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(772, 25);
            this.cndcToolStrip1.TabIndex = 1;
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
            this._btnNuevo.Click += new System.EventHandler(this._btnNuevo_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(55, 22);
            this._btnEditar.Text = "Editar";
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
            // _ctrlDefCanal
            // 
            this._ctrlDefCanal.Location = new System.Drawing.Point(177, 26);
            this._ctrlDefCanal.Name = "_ctrlDefCanal";
            this._ctrlDefCanal.Size = new System.Drawing.Size(389, 136);
            this._ctrlDefCanal.TabIndex = 2;
            // 
            // FormABMDefCanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 390);
            this.Controls.Add(this._ctrlDefCanal);
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._dgvMagnitudElectrica);
            this.Name = "FormABMDefCanales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDefCanales";
            ((System.ComponentModel.ISupportInitialize)(this._dgvMagnitudElectrica)).EndInit();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvMagnitudElectrica;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnNuevo;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnDarBaja;
        private CtrlDefCanal _ctrlDefCanal;
    }
}