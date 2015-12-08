namespace SISFALLA
{
    partial class FormRevertirNotificacion
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
            this._dgvAgentesInvolucrados = new Controles.CNDCGridView();
            this.cndcLabel1 = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesInvolucrados)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvAgentesInvolucrados
            // 
            this._dgvAgentesInvolucrados.AllowUserToAddRows = false;
            this._dgvAgentesInvolucrados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentesInvolucrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAgentesInvolucrados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentesInvolucrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentesInvolucrados.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAgentesInvolucrados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentesInvolucrados.Location = new System.Drawing.Point(28, 48);
            this._dgvAgentesInvolucrados.Name = "_dgvAgentesInvolucrados";
            this._dgvAgentesInvolucrados.RowHeadersWidth = 20;
            this._dgvAgentesInvolucrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentesInvolucrados.Size = new System.Drawing.Size(442, 246);
            this._dgvAgentesInvolucrados.TabIndex = 6;
            this._dgvAgentesInvolucrados.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(27, 30);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(237, 13);
            this.cndcLabel1.TabIndex = 9;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Seleccionar los Agentes para revertir notificación";
            // 
            // FormRevertirNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 325);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._dgvAgentesInvolucrados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRevertirNotificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revertir Notificacion";
            this.Controls.SetChildIndex(this._dgvAgentesInvolucrados, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesInvolucrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvAgentesInvolucrados;
        private Controles.CNDCLabel cndcLabel1;

    }
}