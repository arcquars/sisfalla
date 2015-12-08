namespace SISFALLA
{
    partial class FormCopiarAlimentadores
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
            this._dgvAlimentadores = new Controles.CNDCGridView();
            this._btnSalir = new Controles.CNDCButton();
            this._btnAceptar = new Controles.CNDCButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvAlimentadores
            // 
            this._dgvAlimentadores.AllowUserToAddRows = false;
            this._dgvAlimentadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAlimentadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAlimentadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAlimentadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAlimentadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAlimentadores.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAlimentadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAlimentadores.Location = new System.Drawing.Point(4, 3);
            this._dgvAlimentadores.Name = "_dgvAlimentadores";
            this._dgvAlimentadores.ReadOnly = true;
            this._dgvAlimentadores.RowHeadersWidth = 15;
            this._dgvAlimentadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAlimentadores.ShowRowErrors = false;
            this._dgvAlimentadores.Size = new System.Drawing.Size(900, 291);
            this._dgvAlimentadores.TabIndex = 0;
            this._dgvAlimentadores.TablaCampoBD = null;
            // 
            // _btnSalir
            // 
            this._btnSalir.Location = new System.Drawing.Point(469, 299);
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(95, 23);
            this._btnSalir.TabIndex = 2;
            this._btnSalir.TablaCampoBD = null;
            this._btnSalir.Text = "Salir";
            this._btnSalir.UseVisualStyleBackColor = true;
            this._btnSalir.Click += new System.EventHandler(this._btnSalir_Click);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(358, 299);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(95, 23);
            this._btnAceptar.TabIndex = 1;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // FormCopiarAlimentadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 325);
            this.Controls.Add(this._btnSalir);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._dgvAlimentadores);
            this.Name = "FormCopiarAlimentadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Alimentadores";
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvAlimentadores;
        private Controles.CNDCButton _btnSalir;
        private Controles.CNDCButton _btnAceptar;
    }
}