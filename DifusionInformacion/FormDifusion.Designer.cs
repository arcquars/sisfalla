namespace SISFALLA
{
    partial class FormDifusion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this._panelArchivos = new Controles.CNDCPanelControl();
            this._tabArchivos = new Controles.CNDCTabControl();
            this._tabSubFrecuencia = new System.Windows.Forms.TabPage();
            this._dgvArchivosPub = new Controles.CNDCGridView();
            this._lblFecha = new Controles.CNDCLabel();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._panelParametros = new Controles.CNDCPanelControl();
            this._btnAceptar = new Controles.CNDCButton();
            this._panelRepublicar = new Controles.CNDCPanelControl();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._txtMotivo = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._anio = new Controles.CNDCDateTimePicker();
            this._fechaFin = new Controles.CNDCDateTimePicker();
            this._fechaInicio = new Controles.CNDCDateTimePicker();
            this._mes = new Controles.CNDCComboBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._PanelProceso = new Controles.CNDCPanelControl();
            this._btnTerminar = new Controles.CNDCButton();
            this._btnPublicar = new Controles.CNDCButton();
            this._btnCopiar = new Controles.CNDCButton();
            this._btnPreparar = new Controles.CNDCButton();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._errorProvider = new System.Windows.Forms.ErrorProvider();
            this.cndcGroupBox3 = new Controles.CNDCGroupBox();
            this._lblCantidadArchivos = new Controles.CNDCLabel();
            this._panelArchivos.SuspendLayout();
            this._tabArchivos.SuspendLayout();
            this._tabSubFrecuencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvArchivosPub)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            this._panelParametros.SuspendLayout();
            this._panelRepublicar.SuspendLayout();
            this._PanelProceso.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelArchivos
            // 
            this._panelArchivos.Controls.Add(this._tabArchivos);
            this._panelArchivos.Location = new System.Drawing.Point(11, 15);
            this._panelArchivos.Name = "_panelArchivos";
            this._panelArchivos.Size = new System.Drawing.Size(561, 283);
            this._panelArchivos.TabIndex = 13;
            this._panelArchivos.TablaCampoBD = null;
            // 
            // _tabArchivos
            // 
            this._tabArchivos.Controls.Add(this._tabSubFrecuencia);
            this._tabArchivos.Location = new System.Drawing.Point(2, 13);
            this._tabArchivos.Name = "_tabArchivos";
            this._tabArchivos.SelectedIndex = 0;
            this._tabArchivos.Size = new System.Drawing.Size(554, 267);
            this._tabArchivos.TabIndex = 6;
            this._tabArchivos.TablaCampoBD = null;
            // 
            // _tabSubFrecuencia
            // 
            this._tabSubFrecuencia.Controls.Add(this._dgvArchivosPub);
            this._tabSubFrecuencia.Location = new System.Drawing.Point(4, 22);
            this._tabSubFrecuencia.Name = "_tabSubFrecuencia";
            this._tabSubFrecuencia.Padding = new System.Windows.Forms.Padding(3);
            this._tabSubFrecuencia.Size = new System.Drawing.Size(546, 241);
            this._tabSubFrecuencia.TabIndex = 0;
            this._tabSubFrecuencia.Text = "Detalle de Archivos";
            this._tabSubFrecuencia.UseVisualStyleBackColor = true;
            // 
            // _dgvArchivosPub
            // 
            this._dgvArchivosPub.AllowUserToAddRows = false;
            this._dgvArchivosPub.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvArchivosPub.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvArchivosPub.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvArchivosPub.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this._dgvArchivosPub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvArchivosPub.DefaultCellStyle = dataGridViewCellStyle7;
            this._dgvArchivosPub.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvArchivosPub.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvArchivosPub.Location = new System.Drawing.Point(3, 3);
            this._dgvArchivosPub.MultiSelect = false;
            this._dgvArchivosPub.Name = "_dgvArchivosPub";
            this._dgvArchivosPub.NombreContenedor = null;
            this._dgvArchivosPub.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvArchivosPub.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this._dgvArchivosPub.RowHeadersWidth = 25;
            this._dgvArchivosPub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvArchivosPub.Size = new System.Drawing.Size(540, 235);
            this._dgvArchivosPub.TabIndex = 5;
            this._dgvArchivosPub.TablaCampoBD = null;
            // 
            // _lblFecha
            // 
            this._lblFecha.AutoSize = true;
            this._lblFecha.Location = new System.Drawing.Point(521, 28);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(0, 13);
            this._lblFecha.TabIndex = 14;
            this._lblFecha.TablaCampoBD = null;
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._panelArchivos);
            this.cndcGroupBox1.Location = new System.Drawing.Point(29, 306);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(576, 301);
            this.cndcGroupBox1.TabIndex = 16;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Detalle de archivos procesados";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._panelParametros);
            this.cndcGroupBox2.Location = new System.Drawing.Point(29, 34);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(278, 266);
            this.cndcGroupBox2.TabIndex = 17;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Datos Iniciales del Proceso";
            // 
            // _panelParametros
            // 
            this._panelParametros.Controls.Add(this._btnAceptar);
            this._panelParametros.Controls.Add(this._panelRepublicar);
            this._panelParametros.Controls.Add(this.cndcLabel4);
            this._panelParametros.Controls.Add(this.cndcLabel3);
            this._panelParametros.Controls.Add(this._anio);
            this._panelParametros.Controls.Add(this._fechaFin);
            this._panelParametros.Controls.Add(this._fechaInicio);
            this._panelParametros.Controls.Add(this._mes);
            this._panelParametros.Controls.Add(this.cndcLabel2);
            this._panelParametros.Controls.Add(this.cndcLabel1);
            this._panelParametros.Location = new System.Drawing.Point(7, 21);
            this._panelParametros.Name = "_panelParametros";
            this._panelParametros.Size = new System.Drawing.Size(255, 239);
            this._panelParametros.TabIndex = 0;
            this._panelParametros.TablaCampoBD = null;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(63, 179);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(141, 31);
            this._btnAceptar.TabIndex = 6;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _panelRepublicar
            // 
            this._panelRepublicar.Controls.Add(this.cndcLabel5);
            this._panelRepublicar.Controls.Add(this._txtMotivo);
            this._panelRepublicar.Location = new System.Drawing.Point(6, 129);
            this._panelRepublicar.Name = "_panelRepublicar";
            this._panelRepublicar.Size = new System.Drawing.Size(244, 44);
            this._panelRepublicar.TabIndex = 17;
            this._panelRepublicar.TablaCampoBD = null;
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(7, 3);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(150, 13);
            this.cndcLabel5.TabIndex = 17;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Motivo para volver a publicar :";
            // 
            // _txtMotivo
            // 
            this._txtMotivo.EnterComoTab = false;
            this._txtMotivo.Etiqueta = null;
            this._txtMotivo.Location = new System.Drawing.Point(9, 21);
            this._txtMotivo.MaxLength = 500;
            this._txtMotivo.Name = "_txtMotivo";
            this._txtMotivo.Size = new System.Drawing.Size(227, 20);
            this._txtMotivo.TabIndex = 5;
            this._txtMotivo.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(47, 50);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(68, 13);
            this.cndcLabel4.TabIndex = 13;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Fecha Final :";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(43, 21);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(73, 13);
            this.cndcLabel3.TabIndex = 12;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Fecha Inicial :";
            // 
            // _anio
            // 
            this._anio.CustomFormat = "yyyy";
            this._anio.Enabled = false;
            this._anio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._anio.Location = new System.Drawing.Point(131, 103);
            this._anio.Name = "_anio";
            this._anio.ShowUpDown = true;
            this._anio.Size = new System.Drawing.Size(50, 20);
            this._anio.TabIndex = 4;
            this._anio.TablaCampoBD = null;
            // 
            // _fechaFin
            // 
            this._fechaFin.CustomFormat = "dd/MM/yyyy";
            this._fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._fechaFin.Location = new System.Drawing.Point(131, 47);
            this._fechaFin.Name = "_fechaFin";
            this._fechaFin.Size = new System.Drawing.Size(87, 20);
            this._fechaFin.TabIndex = 3;
            this._fechaFin.TablaCampoBD = null;
            // 
            // _fechaInicio
            // 
            this._fechaInicio.CustomFormat = "dd/MM/yyyy";
            this._fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._fechaInicio.Location = new System.Drawing.Point(131, 17);
            this._fechaInicio.Name = "_fechaInicio";
            this._fechaInicio.Size = new System.Drawing.Size(87, 20);
            this._fechaInicio.TabIndex = 2;
            this._fechaInicio.TablaCampoBD = null;
            this._fechaInicio.ValueChanged += new System.EventHandler(this._fechaInicio_ValueChanged);
            // 
            // _mes
            // 
            this._mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._mes.EnterComoTab = false;
            this._mes.Etiqueta = null;
            this._mes.FormattingEnabled = true;
            this._mes.Location = new System.Drawing.Point(131, 75);
            this._mes.Name = "_mes";
            this._mes.Size = new System.Drawing.Size(110, 21);
            this._mes.TabIndex = 3;
            this._mes.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(79, 78);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(36, 13);
            this.cndcLabel2.TabIndex = 1;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "MES :";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(79, 105);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(36, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "AÑO :";
            // 
            // _PanelProceso
            // 
            this._PanelProceso.Controls.Add(this._btnTerminar);
            this._PanelProceso.Controls.Add(this._btnPublicar);
            this._PanelProceso.Controls.Add(this._btnCopiar);
            this._PanelProceso.Controls.Add(this._btnPreparar);
            this._PanelProceso.Location = new System.Drawing.Point(13, 19);
            this._PanelProceso.Name = "_PanelProceso";
            this._PanelProceso.Size = new System.Drawing.Size(251, 241);
            this._PanelProceso.TabIndex = 11;
            this._PanelProceso.TablaCampoBD = null;
            // 
            // _btnTerminar
            // 
            this._btnTerminar.Image = global::DifusionInformacion.Properties.Resources.Internet_explorer1;
            this._btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnTerminar.Location = new System.Drawing.Point(61, 176);
            this._btnTerminar.Name = "_btnTerminar";
            this._btnTerminar.Size = new System.Drawing.Size(141, 47);
            this._btnTerminar.TabIndex = 10;
            this._btnTerminar.TablaCampoBD = null;
            this._btnTerminar.Text = "Terminar";
            this._btnTerminar.UseVisualStyleBackColor = true;
            this._btnTerminar.Click += new System.EventHandler(this._btnTerminar_Click);
            // 
            // _btnPublicar
            // 
            this._btnPublicar.Image = global::DifusionInformacion.Properties.Resources.Earth;
            this._btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnPublicar.Location = new System.Drawing.Point(61, 123);
            this._btnPublicar.Name = "_btnPublicar";
            this._btnPublicar.Size = new System.Drawing.Size(141, 47);
            this._btnPublicar.TabIndex = 9;
            this._btnPublicar.TablaCampoBD = null;
            this._btnPublicar.Text = "Publicar";
            this._btnPublicar.UseVisualStyleBackColor = true;
            this._btnPublicar.Click += new System.EventHandler(this._btnPublicar_Click);
            // 
            // _btnCopiar
            // 
            this._btnCopiar.Image = global::DifusionInformacion.Properties.Resources.Folder_files;
            this._btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCopiar.Location = new System.Drawing.Point(61, 70);
            this._btnCopiar.Name = "_btnCopiar";
            this._btnCopiar.Size = new System.Drawing.Size(141, 47);
            this._btnCopiar.TabIndex = 8;
            this._btnCopiar.TablaCampoBD = null;
            this._btnCopiar.Text = "Copiar";
            this._btnCopiar.UseVisualStyleBackColor = true;
            this._btnCopiar.Click += new System.EventHandler(this._btnCopiar_Click);
            // 
            // _btnPreparar
            // 
            this._btnPreparar.Image = global::DifusionInformacion.Properties.Resources.Control_panel;
            this._btnPreparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnPreparar.Location = new System.Drawing.Point(61, 19);
            this._btnPreparar.Name = "_btnPreparar";
            this._btnPreparar.Size = new System.Drawing.Size(141, 45);
            this._btnPreparar.TabIndex = 7;
            this._btnPreparar.TablaCampoBD = null;
            this._btnPreparar.Text = "Preparar";
            this._btnPreparar.UseVisualStyleBackColor = true;
            this._btnPreparar.Click += new System.EventHandler(this._btnPreparar_Click);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnCancelar,
            this.toolStripSeparator1});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(634, 25);
            this.cndcToolStrip1.TabIndex = 18;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::DifusionInformacion.Properties.Resources.cancel;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(73, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // cndcGroupBox3
            // 
            this.cndcGroupBox3.Controls.Add(this._PanelProceso);
            this.cndcGroupBox3.Location = new System.Drawing.Point(330, 34);
            this.cndcGroupBox3.Name = "cndcGroupBox3";
            this.cndcGroupBox3.Size = new System.Drawing.Size(275, 266);
            this.cndcGroupBox3.TabIndex = 19;
            this.cndcGroupBox3.TablaCampoBD = null;
            this.cndcGroupBox3.TabStop = false;
            this.cndcGroupBox3.Text = "Etapas del Proceso";
            // 
            // _lblCantidadArchivos
            // 
            this._lblCantidadArchivos.AutoSize = true;
            this._lblCantidadArchivos.Location = new System.Drawing.Point(39, 610);
            this._lblCantidadArchivos.Name = "_lblCantidadArchivos";
            this._lblCantidadArchivos.Size = new System.Drawing.Size(0, 13);
            this._lblCantidadArchivos.TabIndex = 19;
            this._lblCantidadArchivos.TablaCampoBD = null;
            // 
            // FormDifusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 645);
            this.Controls.Add(this._lblCantidadArchivos);
            this.Controls.Add(this.cndcGroupBox3);
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._lblFecha);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this.cndcGroupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDifusion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicaciones Web";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDifusion_FormClosed);
            this._panelArchivos.ResumeLayout(false);
            this._tabArchivos.ResumeLayout(false);
            this._tabSubFrecuencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvArchivosPub)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox2.ResumeLayout(false);
            this._panelParametros.ResumeLayout(false);
            this._panelParametros.PerformLayout();
            this._panelRepublicar.ResumeLayout(false);
            this._panelRepublicar.PerformLayout();
            this._PanelProceso.ResumeLayout(false);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCPanelControl _panelArchivos;
        private Controles.CNDCLabel _lblFecha;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Controles.CNDCTabControl _tabArchivos;
        private System.Windows.Forms.TabPage _tabSubFrecuencia;
        private Controles.CNDCGridView _dgvArchivosPub;
        private Controles.CNDCPanelControl _panelParametros;
        private Controles.CNDCComboBox _mes;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCDateTimePicker _fechaFin;
        private Controles.CNDCDateTimePicker _fechaInicio;
        private Controles.CNDCDateTimePicker _anio;
        private Controles.CNDCPanelControl _PanelProceso;
        private Controles.CNDCButton _btnPreparar;
        private Controles.CNDCButton _btnCopiar;
        private Controles.CNDCButton _btnPublicar;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCButton _btnTerminar;
        private Controles.CNDCGroupBox cndcGroupBox3;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCPanelControl _panelRepublicar;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBox _txtMotivo;
        private Controles.CNDCLabel _lblCantidadArchivos;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


    }
}