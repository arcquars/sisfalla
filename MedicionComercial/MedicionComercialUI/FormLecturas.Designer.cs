namespace MedicionComercialUI
{
    partial class FormLecturas
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
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._lblFechaHoy = new System.Windows.Forms.ToolStripLabel();
            this._pnlResumen = new Controles.CNDCPanelControl();
            this._dgv = new Controles.CNDCGridView();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblFechaHoy});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(998, 25);
            this.cndcToolStrip1.TabIndex = 1;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _lblFechaHoy
            // 
            this._lblFechaHoy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._lblFechaHoy.Name = "_lblFechaHoy";
            this._lblFechaHoy.Size = new System.Drawing.Size(40, 22);
            this._lblFechaHoy.Text = "Fecha:";
            // 
            // _pnlResumen
            // 
            this._pnlResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlResumen.AutoScroll = true;
            this._pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlResumen.Location = new System.Drawing.Point(6, 564);
            this._pnlResumen.Name = "_pnlResumen";
            this._pnlResumen.Size = new System.Drawing.Size(988, 32);
            this._pnlResumen.TabIndex = 11;
            this._pnlResumen.TablaCampoBD = null;
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgv.Location = new System.Drawing.Point(8, 37);
            this._dgv.Name = "_dgv";
            this._dgv.NombreContenedor = null;
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersWidth = 25;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(985, 513);
            this._dgv.TabIndex = 12;
            this._dgv.TablaCampoBD = null;
            this._dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgv_CellContentDoubleClick);
            // 
            // FormLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 599);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._pnlResumen);
            this.Controls.Add(this.cndcToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FormLecturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLecturas";
            this.Load += new System.EventHandler(this.FormLecturas_Load);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripLabel _lblFechaHoy;
        private Controles.CNDCPanelControl _pnlResumen;
        private Controles.CNDCGridView _dgv;
    }
}