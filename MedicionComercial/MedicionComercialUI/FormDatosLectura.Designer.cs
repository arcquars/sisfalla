namespace MedicionComercialUI
{
    partial class FormDatosLectura
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
            this._dgvPuntosMedicion = new Controles.CNDCGridView();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dtpDesde = new Controles.CNDCDateTimePicker();
            this._dtpHasta = new Controles.CNDCDateTimePicker();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._ctrlVisorDatosLectura = new MedicionComercialUI.CtrlVisorDatosLectura();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).BeginInit();
            this.cndcPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvPuntosMedicion
            // 
            this._dgvPuntosMedicion.AllowUserToAddRows = false;
            this._dgvPuntosMedicion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvPuntosMedicion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvPuntosMedicion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvPuntosMedicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvPuntosMedicion.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvPuntosMedicion.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvPuntosMedicion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvPuntosMedicion.Location = new System.Drawing.Point(0, 0);
            this._dgvPuntosMedicion.Name = "_dgvPuntosMedicion";
            this._dgvPuntosMedicion.NombreContenedor = "FormABMMedidores";
            this._dgvPuntosMedicion.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvPuntosMedicion.RowHeadersWidth = 25;
            this._dgvPuntosMedicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvPuntosMedicion.Size = new System.Drawing.Size(1089, 231);
            this._dgvPuntosMedicion.TabIndex = 9;
            this._dgvPuntosMedicion.TablaCampoBD = null;
            this._dgvPuntosMedicion.SelectionChanged += new System.EventHandler(this._dgvPuntosMedicion_SelectionChanged);
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
            // _ctrlVisorDatosLectura
            // 
            this._ctrlVisorDatosLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlVisorDatosLectura.Location = new System.Drawing.Point(0, 259);
            this._ctrlVisorDatosLectura.Name = "_ctrlVisorDatosLectura";
            this._ctrlVisorDatosLectura.Size = new System.Drawing.Size(1089, 483);
            this._ctrlVisorDatosLectura.TabIndex = 14;
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this._dtpDesde);
            this.cndcPanelControl1.Controls.Add(this.cndcLabel1);
            this.cndcPanelControl1.Controls.Add(this._dtpHasta);
            this.cndcPanelControl1.Controls.Add(this.cndcLabel2);
            this.cndcPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cndcPanelControl1.Location = new System.Drawing.Point(0, 231);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(1089, 28);
            this.cndcPanelControl1.TabIndex = 15;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // FormDatosLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 742);
            this.Controls.Add(this._ctrlVisorDatosLectura);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._dgvPuntosMedicion);
            this.Name = "FormDatosLectura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDatosLectura";
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).EndInit();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvPuntosMedicion;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCDateTimePicker _dtpDesde;
        private Controles.CNDCDateTimePicker _dtpHasta;
        private Controles.CNDCLabel cndcLabel2;
        private CtrlVisorDatosLectura _ctrlVisorDatosLectura;
        private Controles.CNDCPanelControl cndcPanelControl1;
    }
}