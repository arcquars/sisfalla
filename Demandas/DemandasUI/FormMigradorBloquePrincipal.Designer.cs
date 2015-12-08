namespace DemandasUI
{
    partial class FormMigradorBloquePrincipal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._btnLimpiar = new System.Windows.Forms.Button();
            this._txtCriterioBloque = new System.Windows.Forms.TextBox();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbVisualizar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._gbxAnios = new System.Windows.Forms.GroupBox();
            this._nudAnioInicio = new System.Windows.Forms.NumericUpDown();
            this._nudAnioFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._nudDecimales = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._gbxColumnas = new System.Windows.Forms.GroupBox();
            this._txtColumna = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._pnlExcel = new System.Windows.Forms.GroupBox();
            this._nudFilaInicio = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._nudFilaFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._btnCrear = new System.Windows.Forms.Button();
            this._dgvDatos = new System.Windows.Forms.DataGridView();
            this._btnExaminar = new System.Windows.Forms.Button();
            this._txtDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._toolStrip.SuspendLayout();
            this._gbxAnios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).BeginInit();
            this._gbxColumnas.SuspendLayout();
            this._pnlExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnLimpiar
            // 
            this._btnLimpiar.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnLimpiar.Location = new System.Drawing.Point(718, 98);
            this._btnLimpiar.Name = "_btnLimpiar";
            this._btnLimpiar.Size = new System.Drawing.Size(84, 26);
            this._btnLimpiar.TabIndex = 53;
            this._btnLimpiar.Text = "Limpiar";
            this._btnLimpiar.UseVisualStyleBackColor = true;
            this._btnLimpiar.Click += new System.EventHandler(this._btnLimpiar_Click);
            // 
            // _txtCriterioBloque
            // 
            this._txtCriterioBloque.BackColor = System.Drawing.Color.White;
            this._txtCriterioBloque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCriterioBloque.Location = new System.Drawing.Point(212, 22);
            this._txtCriterioBloque.Name = "_txtCriterioBloque";
            this._txtCriterioBloque.Size = new System.Drawing.Size(64, 22);
            this._txtCriterioBloque.TabIndex = 52;
            this._txtCriterioBloque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbVisualizar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(4, 5);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(216, 25);
            this._toolStrip.TabIndex = 36;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::DemandasUI.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(66, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbVisualizar
            // 
            this._tsbVisualizar.Image = global::DemandasUI.Properties.Resources.InformeListo___copia;
            this._tsbVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbVisualizar.Name = "_tsbVisualizar";
            this._tsbVisualizar.Size = new System.Drawing.Size(71, 22);
            this._tsbVisualizar.Text = "Visualizar";
            this._tsbVisualizar.Click += new System.EventHandler(this._tsbVisualizar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(69, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _gbxAnios
            // 
            this._gbxAnios.Controls.Add(this._nudAnioInicio);
            this._gbxAnios.Controls.Add(this._nudAnioFin);
            this._gbxAnios.Controls.Add(this.cndcLabel6);
            this._gbxAnios.Controls.Add(this.cndcLabel7);
            this._gbxAnios.Location = new System.Drawing.Point(73, 66);
            this._gbxAnios.Name = "_gbxAnios";
            this._gbxAnios.Size = new System.Drawing.Size(136, 57);
            this._gbxAnios.TabIndex = 47;
            this._gbxAnios.TabStop = false;
            this._gbxAnios.Text = "Años";
            // 
            // _nudAnioInicio
            // 
            this._nudAnioInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioInicio.Location = new System.Drawing.Point(56, 9);
            this._nudAnioInicio.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this._nudAnioInicio.Minimum = new decimal(new int[] {
            1879,
            0,
            0,
            0});
            this._nudAnioInicio.Name = "_nudAnioInicio";
            this._nudAnioInicio.Size = new System.Drawing.Size(66, 22);
            this._nudAnioInicio.TabIndex = 13;
            this._nudAnioInicio.Value = new decimal(new int[] {
            1979,
            0,
            0,
            0});
            // 
            // _nudAnioFin
            // 
            this._nudAnioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioFin.Location = new System.Drawing.Point(56, 32);
            this._nudAnioFin.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this._nudAnioFin.Minimum = new decimal(new int[] {
            1879,
            0,
            0,
            0});
            this._nudAnioFin.Name = "_nudAnioFin";
            this._nudAnioFin.Size = new System.Drawing.Size(66, 22);
            this._nudAnioFin.TabIndex = 14;
            this._nudAnioFin.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this._nudAnioFin.Visible = false;
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel6.Location = new System.Drawing.Point(10, 11);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel6.TabIndex = 10;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Inicio:";
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel7.Location = new System.Drawing.Point(23, 34);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(29, 16);
            this.cndcLabel7.TabIndex = 12;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Fin:";
            this.cndcLabel7.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._btnLimpiar);
            this.groupBox1.Controls.Add(this._txtCriterioBloque);
            this.groupBox1.Controls.Add(this._gbxAnios);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._gbxColumnas);
            this.groupBox1.Controls.Add(this._pnlExcel);
            this.groupBox1.Controls.Add(this._btnCrear);
            this.groupBox1.Controls.Add(this._dgvDatos);
            this.groupBox1.Controls.Add(this._btnExaminar);
            this.groupBox1.Controls.Add(this._txtDocumento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(4, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 586);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Num. Bloque:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._nudDecimales);
            this.groupBox2.Controls.Add(this.cndcLabel5);
            this.groupBox2.Location = new System.Drawing.Point(496, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 57);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cantidad decimales";
            // 
            // _nudDecimales
            // 
            this._nudDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudDecimales.Location = new System.Drawing.Point(92, 14);
            this._nudDecimales.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this._nudDecimales.Name = "_nudDecimales";
            this._nudDecimales.Size = new System.Drawing.Size(38, 22);
            this._nudDecimales.TabIndex = 11;
            this._nudDecimales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel5.Location = new System.Drawing.Point(23, 17);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(65, 16);
            this.cndcLabel5.TabIndex = 10;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Decimales:";
            // 
            // _gbxColumnas
            // 
            this._gbxColumnas.Controls.Add(this._txtColumna);
            this._gbxColumnas.Controls.Add(this.cndcLabel1);
            this._gbxColumnas.Location = new System.Drawing.Point(354, 66);
            this._gbxColumnas.Name = "_gbxColumnas";
            this._gbxColumnas.Size = new System.Drawing.Size(136, 57);
            this._gbxColumnas.TabIndex = 47;
            this._gbxColumnas.TabStop = false;
            this._gbxColumnas.Text = "Columnas";
            // 
            // _txtColumna
            // 
            this._txtColumna.BackColor = System.Drawing.Color.White;
            this._txtColumna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtColumna.EnterComoTab = false;
            this._txtColumna.Etiqueta = null;
            this._txtColumna.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtColumna.Location = new System.Drawing.Point(59, 15);
            this._txtColumna.Name = "_txtColumna";
            this._txtColumna.Size = new System.Drawing.Size(66, 22);
            this._txtColumna.TabIndex = 21;
            this._txtColumna.TablaCampoBD = "";
            this._txtColumna.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtColumna_KeyPress);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(13, 17);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel1.TabIndex = 10;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Inicio:";
            // 
            // _pnlExcel
            // 
            this._pnlExcel.Controls.Add(this._nudFilaInicio);
            this._pnlExcel.Controls.Add(this.cndcLabel2);
            this._pnlExcel.Controls.Add(this._nudFilaFin);
            this._pnlExcel.Controls.Add(this.cndcLabel3);
            this._pnlExcel.Location = new System.Drawing.Point(212, 66);
            this._pnlExcel.Name = "_pnlExcel";
            this._pnlExcel.Size = new System.Drawing.Size(136, 57);
            this._pnlExcel.TabIndex = 46;
            this._pnlExcel.TabStop = false;
            this._pnlExcel.Text = "Filas";
            // 
            // _nudFilaInicio
            // 
            this._nudFilaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudFilaInicio.Location = new System.Drawing.Point(56, 9);
            this._nudFilaInicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudFilaInicio.Name = "_nudFilaInicio";
            this._nudFilaInicio.Size = new System.Drawing.Size(66, 22);
            this._nudFilaInicio.TabIndex = 11;
            this._nudFilaInicio.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(10, 11);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel2.TabIndex = 10;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Inicio:";
            // 
            // _nudFilaFin
            // 
            this._nudFilaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudFilaFin.Location = new System.Drawing.Point(56, 32);
            this._nudFilaFin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudFilaFin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudFilaFin.Name = "_nudFilaFin";
            this._nudFilaFin.Size = new System.Drawing.Size(66, 22);
            this._nudFilaFin.TabIndex = 13;
            this._nudFilaFin.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel3.Location = new System.Drawing.Point(23, 34);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(29, 16);
            this.cndcLabel3.TabIndex = 12;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Fin:";
            // 
            // _btnCrear
            // 
            this._btnCrear.Image = global::DemandasUI.Properties.Resources.informe4;
            this._btnCrear.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnCrear.Location = new System.Drawing.Point(718, 71);
            this._btnCrear.Name = "_btnCrear";
            this._btnCrear.Size = new System.Drawing.Size(84, 26);
            this._btnCrear.TabIndex = 45;
            this._btnCrear.Text = "Leer datos";
            this._btnCrear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this._btnCrear.UseVisualStyleBackColor = true;
            this._btnCrear.Click += new System.EventHandler(this._btnCrear_Click);
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDatos.Location = new System.Drawing.Point(6, 136);
            this._dgvDatos.Name = "_dgvDatos";
            this._dgvDatos.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvDatos.Size = new System.Drawing.Size(1017, 444);
            this._dgvDatos.TabIndex = 9;
            this._dgvDatos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this._dgvDatos_RowPrePaint);
            // 
            // _btnExaminar
            // 
            this._btnExaminar.Location = new System.Drawing.Point(718, 44);
            this._btnExaminar.Name = "_btnExaminar";
            this._btnExaminar.Size = new System.Drawing.Size(84, 23);
            this._btnExaminar.TabIndex = 8;
            this._btnExaminar.Text = "Examinar";
            this._btnExaminar.UseVisualStyleBackColor = true;
            this._btnExaminar.Click += new System.EventHandler(this._btnExaminar_Click);
            // 
            // _txtDocumento
            // 
            this._txtDocumento.BackColor = System.Drawing.Color.Gainsboro;
            this._txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDocumento.Location = new System.Drawing.Point(212, 44);
            this._txtDocumento.Name = "_txtDocumento";
            this._txtDocumento.ReadOnly = true;
            this._txtDocumento.Size = new System.Drawing.Size(500, 22);
            this._txtDocumento.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Documento:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormMigradorBloquePrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 615);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMigradorBloquePrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migrador/Visualizador duración de bloques";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._gbxAnios.ResumeLayout(false);
            this._gbxAnios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).EndInit();
            this._gbxColumnas.ResumeLayout(false);
            this._gbxColumnas.PerformLayout();
            this._pnlExcel.ResumeLayout(false);
            this._pnlExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnLimpiar;
        private System.Windows.Forms.TextBox _txtCriterioBloque;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbVisualizar;
        private System.Windows.Forms.GroupBox _gbxAnios;
        private System.Windows.Forms.NumericUpDown _nudAnioInicio;
        private System.Windows.Forms.NumericUpDown _nudAnioFin;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCLabel cndcLabel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown _nudDecimales;
        private Controles.CNDCLabel cndcLabel5;
        private System.Windows.Forms.GroupBox _gbxColumnas;
        private Controles.CNDCTextBox _txtColumna;
        private Controles.CNDCLabel cndcLabel1;
        private System.Windows.Forms.GroupBox _pnlExcel;
        private System.Windows.Forms.NumericUpDown _nudFilaInicio;
        private Controles.CNDCLabel cndcLabel2;
        private System.Windows.Forms.NumericUpDown _nudFilaFin;
        private Controles.CNDCLabel cndcLabel3;
        private System.Windows.Forms.Button _btnCrear;
        private System.Windows.Forms.DataGridView _dgvDatos;
        private System.Windows.Forms.Button _btnExaminar;
        private System.Windows.Forms.TextBox _txtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
    }
}