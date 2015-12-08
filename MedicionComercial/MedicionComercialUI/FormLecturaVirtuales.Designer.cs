namespace MedicionComercialUI
{
    partial class FormLecturaVirtuales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._dtpDesde = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dtpHasta = new Controles.CNDCDateTimePicker();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcPanelControl2 = new Controles.CNDCPanelControl();
            this._dgv = new Controles.CNDCGridView();
            this._btnIniciar = new Controles.CNDCButton();
            this.cndcPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this._btnIniciar);
            this.cndcPanelControl1.Controls.Add(this._dtpDesde);
            this.cndcPanelControl1.Controls.Add(this.cndcLabel1);
            this.cndcPanelControl1.Controls.Add(this._dtpHasta);
            this.cndcPanelControl1.Controls.Add(this.cndcLabel2);
            this.cndcPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cndcPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(912, 28);
            this.cndcPanelControl1.TabIndex = 16;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _dtpDesde
            // 
            this._dtpDesde.CustomFormat = "dd/MMM/yyyy";
            this._dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpDesde.Location = new System.Drawing.Point(49, 3);
            this._dtpDesde.Name = "_dtpDesde";
            this._dtpDesde.Size = new System.Drawing.Size(127, 20);
            this._dtpDesde.TabIndex = 11;
            this._dtpDesde.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(2, 6);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel1.TabIndex = 10;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Desde:";
            // 
            // _dtpHasta
            // 
            this._dtpHasta.CustomFormat = "dd/MMM/yyyy";
            this._dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpHasta.Location = new System.Drawing.Point(240, 3);
            this._dtpHasta.Name = "_dtpHasta";
            this._dtpHasta.Size = new System.Drawing.Size(127, 20);
            this._dtpHasta.TabIndex = 13;
            this._dtpHasta.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(196, 6);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(38, 13);
            this.cndcLabel2.TabIndex = 12;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Hasta:";
            // 
            // cndcPanelControl2
            // 
            this.cndcPanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cndcPanelControl2.Location = new System.Drawing.Point(0, 474);
            this.cndcPanelControl2.Name = "cndcPanelControl2";
            this.cndcPanelControl2.Size = new System.Drawing.Size(912, 28);
            this.cndcPanelControl2.TabIndex = 18;
            this.cndcPanelControl2.TablaCampoBD = null;
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgv.Location = new System.Drawing.Point(0, 28);
            this._dgv.Name = "_dgv";
            this._dgv.NombreContenedor = null;
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersWidth = 25;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(912, 446);
            this._dgv.TabIndex = 19;
            this._dgv.TablaCampoBD = null;
            // 
            // _btnIniciar
            // 
            this._btnIniciar.Location = new System.Drawing.Point(377, 3);
            this._btnIniciar.Name = "_btnIniciar";
            this._btnIniciar.Size = new System.Drawing.Size(75, 23);
            this._btnIniciar.TabIndex = 14;
            this._btnIniciar.TablaCampoBD = null;
            this._btnIniciar.Text = "Iniciar";
            this._btnIniciar.UseVisualStyleBackColor = true;
            this._btnIniciar.Click += new System.EventHandler(this._btnIniciar_Click);
            // 
            // FormLecturaVirtuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 502);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this.cndcPanelControl2);
            this.Controls.Add(this.cndcPanelControl1);
            this.Name = "FormLecturaVirtuales";
            this.Text = "FormLecturaVirtuales";
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCDateTimePicker _dtpDesde;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCDateTimePicker _dtpHasta;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCPanelControl cndcPanelControl2;
        private Controles.CNDCGridView _dgv;
        private Controles.CNDCButton _btnIniciar;
    }
}