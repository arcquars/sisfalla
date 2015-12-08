namespace SISFALLA
{
    partial class FormCopiarInterruptores
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
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._dgvReles = new Controles.CNDCGridView();
            this._dgvInterruptor = new Controles.CNDCGridView();
            this._btnSalir = new Controles.CNDCButton();
            this._btnAceptar = new Controles.CNDCButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvReles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvInterruptor)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(6, 144);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(89, 13);
            this.cndcLabelControl1.TabIndex = 1;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Relés Operados :";
            // 
            // _dgvReles
            // 
            this._dgvReles.AllowUserToAddRows = false;
            this._dgvReles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvReles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this._dgvReles.Location = new System.Drawing.Point(1, 160);
            this._dgvReles.Name = "_dgvReles";
            this._dgvReles.ReadOnly = true;
            this._dgvReles.RowHeadersWidth = 15;
            this._dgvReles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvReles.ShowRowErrors = false;
            this._dgvReles.Size = new System.Drawing.Size(727, 121);
            this._dgvReles.TabIndex = 2;
            this._dgvReles.TablaCampoBD = null;
            // 
            // _dgvInterruptor
            // 
            this._dgvInterruptor.AllowUserToAddRows = false;
            this._dgvInterruptor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvInterruptor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this._dgvInterruptor.Location = new System.Drawing.Point(1, 1);
            this._dgvInterruptor.Name = "_dgvInterruptor";
            this._dgvInterruptor.ReadOnly = true;
            this._dgvInterruptor.RowHeadersWidth = 15;
            this._dgvInterruptor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvInterruptor.ShowRowErrors = false;
            this._dgvInterruptor.Size = new System.Drawing.Size(925, 126);
            this._dgvInterruptor.TabIndex = 0;
            this._dgvInterruptor.TablaCampoBD = null;
            this._dgvInterruptor.SelectionChanged += new System.EventHandler(this._dgvInterruptor_SelectionChanged);
            // 
            // _btnSalir
            // 
            this._btnSalir.Location = new System.Drawing.Point(470, 287);
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(95, 23);
            this._btnSalir.TabIndex = 4;
            this._btnSalir.TablaCampoBD = null;
            this._btnSalir.Text = "Salir";
            this._btnSalir.UseVisualStyleBackColor = true;
            this._btnSalir.Click += new System.EventHandler(this._btnSalir_Click);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(359, 287);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(95, 23);
            this._btnAceptar.TabIndex = 3;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // FormCopiarInterruptores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 313);
            this.Controls.Add(this._btnSalir);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._dgvReles);
            this.Controls.Add(this._dgvInterruptor);
            this.Name = "FormCopiarInterruptores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copiar Interruptores";
            ((System.ComponentModel.ISupportInitialize)(this._dgvReles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvInterruptor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCGridView _dgvReles;
        private Controles.CNDCGridView _dgvInterruptor;
        private Controles.CNDCButton _btnSalir;
        private Controles.CNDCButton _btnAceptar;
    }
}