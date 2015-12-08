namespace SISFALLA
{
    partial class FormSeleccionInforme
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
            this._dgvInformes = new Controles.CNDCGridView();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnSalir = new Controles.CNDCButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvInformes
            // 
            this._dgvInformes.AllowUserToAddRows = false;
            this._dgvInformes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvInformes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvInformes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvInformes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvInformes.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvInformes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvInformes.Location = new System.Drawing.Point(5, 8);
            this._dgvInformes.Name = "_dgvInformes";
            this._dgvInformes.ReadOnly = true;
            this._dgvInformes.RowHeadersWidth = 25;
            this._dgvInformes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvInformes.Size = new System.Drawing.Size(387, 206);
            this._dgvInformes.TabIndex = 0;
            this._dgvInformes.TablaCampoBD = null;
            this._dgvInformes.SelectionChanged += new System.EventHandler(this._dgvInformes_SelectionChanged);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(88, 220);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(95, 23);
            this._btnAceptar.TabIndex = 1;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnSalir
            // 
            this._btnSalir.Location = new System.Drawing.Point(199, 220);
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(95, 23);
            this._btnSalir.TabIndex = 2;
            this._btnSalir.TablaCampoBD = null;
            this._btnSalir.Text = "Salir";
            this._btnSalir.UseVisualStyleBackColor = true;
            this._btnSalir.Click += new System.EventHandler(this._btnSalir_Click);
            // 
            // FormSeleccionInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 248);
            this.Controls.Add(this._btnSalir);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._dgvInformes);
            this.Name = "FormSeleccionInforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Informe";
            ((System.ComponentModel.ISupportInitialize)(this._dgvInformes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvInformes;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnSalir;
    }
}