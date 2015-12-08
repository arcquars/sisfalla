namespace DemandasUI
{
    partial class FormMigrador
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
            this.label1 = new System.Windows.Forms.Label();
            this._cmbAgente = new System.Windows.Forms.ComboBox();
            this._cmbNodoDeConexion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cmbTipoTabla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this._txtDocumento = new System.Windows.Forms.TextBox();
            this._btnExaminar = new System.Windows.Forms.Button();
            this._dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lblCantidadBloques = new System.Windows.Forms.Label();
            this._btnLimpiar = new System.Windows.Forms.Button();
            this._txtCriterioBloque = new System.Windows.Forms.TextBox();
            this._gbxNodoSalida = new System.Windows.Forms.GroupBox();
            this._rbtPowerFactory = new System.Windows.Forms.RadioButton();
            this._rbtNCP = new System.Windows.Forms.RadioButton();
            this._rbtOPTGEN = new System.Windows.Forms.RadioButton();
            this._rbtSDDP = new System.Windows.Forms.RadioButton();
            this._cbxNodoSalida = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._cmbNodoSalida = new System.Windows.Forms.ComboBox();
            this._gbxAnios = new System.Windows.Forms.GroupBox();
            this._nudAnioInicio = new System.Windows.Forms.NumericUpDown();
            this._nudAnioFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._nudDecimales = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._cbxNodoDeConexion = new System.Windows.Forms.CheckBox();
            this._gbxColumnas = new System.Windows.Forms.GroupBox();
            this._txtColumna = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._pnlExcel = new System.Windows.Forms.GroupBox();
            this._nudFilaInicio = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._nudFilaFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._btnCrear = new System.Windows.Forms.Button();
            this._cbxNodo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cmbNodos = new System.Windows.Forms.ComboBox();
            this._gbxTipoAgente = new System.Windows.Forms.GroupBox();
            this._rbtNoRegulados = new System.Windows.Forms.RadioButton();
            this._rbtProyectos = new System.Windows.Forms.RadioButton();
            this._rbtDistribucion = new System.Windows.Forms.RadioButton();
            this._rbtSisAislados = new System.Windows.Forms.RadioButton();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this._gbxNodoSalida.SuspendLayout();
            this._gbxAnios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).BeginInit();
            this._gbxColumnas.SuspendLayout();
            this._pnlExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).BeginInit();
            this._gbxTipoAgente.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agente:";
            // 
            // _cmbAgente
            // 
            this._cmbAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbAgente.FormattingEnabled = true;
            this._cmbAgente.Location = new System.Drawing.Point(230, 59);
            this._cmbAgente.Name = "_cmbAgente";
            this._cmbAgente.Size = new System.Drawing.Size(387, 24);
            this._cmbAgente.TabIndex = 1;
            this._cmbAgente.SelectedIndexChanged += new System.EventHandler(this._cmbAgente_SelectedIndexChanged);
            // 
            // _cmbNodoDeConexion
            // 
            this._cmbNodoDeConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNodoDeConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbNodoDeConexion.FormattingEnabled = true;
            this._cmbNodoDeConexion.Location = new System.Drawing.Point(230, 84);
            this._cmbNodoDeConexion.Name = "_cmbNodoDeConexion";
            this._cmbNodoDeConexion.Size = new System.Drawing.Size(289, 24);
            this._cmbNodoDeConexion.TabIndex = 3;
            this._cmbNodoDeConexion.SelectedIndexChanged += new System.EventHandler(this._cmbNodo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nodo de agregación:";
            // 
            // _cmbTipoTabla
            // 
            this._cmbTipoTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbTipoTabla.FormattingEnabled = true;
            this._cmbTipoTabla.Location = new System.Drawing.Point(229, 159);
            this._cmbTipoTabla.Name = "_cmbTipoTabla";
            this._cmbTipoTabla.Size = new System.Drawing.Size(388, 24);
            this._cmbTipoTabla.TabIndex = 5;
            this._cmbTipoTabla.SelectedIndexChanged += new System.EventHandler(this._cmbTipoTabla_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo Tabla:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Documento:";
            // 
            // _txtDocumento
            // 
            this._txtDocumento.BackColor = System.Drawing.Color.Gainsboro;
            this._txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDocumento.Location = new System.Drawing.Point(229, 184);
            this._txtDocumento.Name = "_txtDocumento";
            this._txtDocumento.ReadOnly = true;
            this._txtDocumento.Size = new System.Drawing.Size(500, 22);
            this._txtDocumento.TabIndex = 7;
            // 
            // _btnExaminar
            // 
            this._btnExaminar.Location = new System.Drawing.Point(735, 183);
            this._btnExaminar.Name = "_btnExaminar";
            this._btnExaminar.Size = new System.Drawing.Size(75, 23);
            this._btnExaminar.TabIndex = 8;
            this._btnExaminar.Text = "Examinar";
            this._btnExaminar.UseVisualStyleBackColor = true;
            this._btnExaminar.Click += new System.EventHandler(this._btnExaminar_Click);
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDatos.Location = new System.Drawing.Point(6, 266);
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
            this._dgvDatos.Size = new System.Drawing.Size(1017, 298);
            this._dgvDatos.TabIndex = 9;
            this._dgvDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvDatos_CellFormatting);
            this._dgvDatos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this._dgvDatos_RowPrePaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lblCantidadBloques);
            this.groupBox1.Controls.Add(this._btnLimpiar);
            this.groupBox1.Controls.Add(this._txtCriterioBloque);
            this.groupBox1.Controls.Add(this._gbxNodoSalida);
            this.groupBox1.Controls.Add(this._cbxNodoSalida);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._cmbNodoSalida);
            this.groupBox1.Controls.Add(this._gbxAnios);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._cbxNodoDeConexion);
            this.groupBox1.Controls.Add(this._gbxColumnas);
            this.groupBox1.Controls.Add(this._pnlExcel);
            this.groupBox1.Controls.Add(this._btnCrear);
            this.groupBox1.Controls.Add(this._cbxNodo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._cmbNodos);
            this.groupBox1.Controls.Add(this._gbxTipoAgente);
            this.groupBox1.Controls.Add(this._cmbAgente);
            this.groupBox1.Controls.Add(this._dgvDatos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._btnExaminar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._txtDocumento);
            this.groupBox1.Controls.Add(this._cmbNodoDeConexion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._cmbTipoTabla);
            this.groupBox1.Location = new System.Drawing.Point(3, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 570);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // _lblCantidadBloques
            // 
            this._lblCantidadBloques.AutoSize = true;
            this._lblCantidadBloques.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCantidadBloques.Location = new System.Drawing.Point(632, 161);
            this._lblCantidadBloques.Name = "_lblCantidadBloques";
            this._lblCantidadBloques.Size = new System.Drawing.Size(97, 20);
            this._lblCantidadBloques.TabIndex = 54;
            this._lblCantidadBloques.Text = "Cant. bloques:";
            // 
            // _btnLimpiar
            // 
            this._btnLimpiar.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnLimpiar.Location = new System.Drawing.Point(745, 238);
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
            this._txtCriterioBloque.Location = new System.Drawing.Point(735, 159);
            this._txtCriterioBloque.Name = "_txtCriterioBloque";
            this._txtCriterioBloque.Size = new System.Drawing.Size(38, 22);
            this._txtCriterioBloque.TabIndex = 52;
            this._txtCriterioBloque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _gbxNodoSalida
            // 
            this._gbxNodoSalida.Controls.Add(this._rbtPowerFactory);
            this._gbxNodoSalida.Controls.Add(this._rbtNCP);
            this._gbxNodoSalida.Controls.Add(this._rbtOPTGEN);
            this._gbxNodoSalida.Controls.Add(this._rbtSDDP);
            this._gbxNodoSalida.Location = new System.Drawing.Point(537, 124);
            this._gbxNodoSalida.Name = "_gbxNodoSalida";
            this._gbxNodoSalida.Size = new System.Drawing.Size(300, 34);
            this._gbxNodoSalida.TabIndex = 42;
            this._gbxNodoSalida.TabStop = false;
            this._gbxNodoSalida.Text = "Tipo Salida";
            this._gbxNodoSalida.Enter += new System.EventHandler(this._gbxNodoSalida_Enter);
            // 
            // _rbtPowerFactory
            // 
            this._rbtPowerFactory.AutoSize = true;
            this._rbtPowerFactory.Location = new System.Drawing.Point(198, 13);
            this._rbtPowerFactory.Name = "_rbtPowerFactory";
            this._rbtPowerFactory.Size = new System.Drawing.Size(93, 17);
            this._rbtPowerFactory.TabIndex = 56;
            this._rbtPowerFactory.TabStop = true;
            this._rbtPowerFactory.Text = "Power Factory";
            this._rbtPowerFactory.UseVisualStyleBackColor = true;
            this._rbtPowerFactory.CheckedChanged += new System.EventHandler(this._rbtPowerFactory_CheckedChanged);
            // 
            // _rbtNCP
            // 
            this._rbtNCP.AutoSize = true;
            this._rbtNCP.Location = new System.Drawing.Point(139, 14);
            this._rbtNCP.Name = "_rbtNCP";
            this._rbtNCP.Size = new System.Drawing.Size(47, 17);
            this._rbtNCP.TabIndex = 5;
            this._rbtNCP.Text = "NCP";
            this._rbtNCP.UseVisualStyleBackColor = true;
            this._rbtNCP.CheckedChanged += new System.EventHandler(this._rbtNCP_CheckedChanged);
            // 
            // _rbtOPTGEN
            // 
            this._rbtOPTGEN.AutoSize = true;
            this._rbtOPTGEN.Location = new System.Drawing.Point(65, 14);
            this._rbtOPTGEN.Name = "_rbtOPTGEN";
            this._rbtOPTGEN.Size = new System.Drawing.Size(70, 17);
            this._rbtOPTGEN.TabIndex = 4;
            this._rbtOPTGEN.Text = "OPTGEN";
            this._rbtOPTGEN.UseVisualStyleBackColor = true;
            this._rbtOPTGEN.CheckedChanged += new System.EventHandler(this._rbtOPTGEN_CheckedChanged);
            // 
            // _rbtSDDP
            // 
            this._rbtSDDP.AutoSize = true;
            this._rbtSDDP.Location = new System.Drawing.Point(6, 13);
            this._rbtSDDP.Name = "_rbtSDDP";
            this._rbtSDDP.Size = new System.Drawing.Size(55, 17);
            this._rbtSDDP.TabIndex = 3;
            this._rbtSDDP.Text = "SDDP";
            this._rbtSDDP.UseVisualStyleBackColor = true;
            this._rbtSDDP.CheckedChanged += new System.EventHandler(this._rbtSDDP_CheckedChanged);
            // 
            // _cbxNodoSalida
            // 
            this._cbxNodoSalida.AutoSize = true;
            this._cbxNodoSalida.Location = new System.Drawing.Point(132, 139);
            this._cbxNodoSalida.Name = "_cbxNodoSalida";
            this._cbxNodoSalida.Size = new System.Drawing.Size(15, 14);
            this._cbxNodoSalida.TabIndex = 51;
            this._cbxNodoSalida.UseVisualStyleBackColor = true;
            this._cbxNodoSalida.CheckedChanged += new System.EventHandler(this._cbxNodoSalida_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Nodo Salida:";
            // 
            // _cmbNodoSalida
            // 
            this._cmbNodoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNodoSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbNodoSalida.FormattingEnabled = true;
            this._cmbNodoSalida.Location = new System.Drawing.Point(229, 134);
            this._cmbNodoSalida.Name = "_cmbNodoSalida";
            this._cmbNodoSalida.Size = new System.Drawing.Size(290, 24);
            this._cmbNodoSalida.TabIndex = 50;
            this._cmbNodoSalida.SelectedIndexChanged += new System.EventHandler(this._cmbNodoSalida_SelectedIndexChanged);
            // 
            // _gbxAnios
            // 
            this._gbxAnios.Controls.Add(this._nudAnioInicio);
            this._gbxAnios.Controls.Add(this._nudAnioFin);
            this._gbxAnios.Controls.Add(this.cndcLabel6);
            this._gbxAnios.Controls.Add(this.cndcLabel7);
            this._gbxAnios.Location = new System.Drawing.Point(90, 206);
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
            this.cndcLabel6.Location = new System.Drawing.Point(11, 11);
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
            this.cndcLabel7.Location = new System.Drawing.Point(24, 34);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(29, 16);
            this.cndcLabel7.TabIndex = 12;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Fin:";
            this.cndcLabel7.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._nudDecimales);
            this.groupBox2.Controls.Add(this.cndcLabel5);
            this.groupBox2.Location = new System.Drawing.Point(513, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 57);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cantidad decimales";
            // 
            // _nudDecimales
            // 
            this._nudDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudDecimales.Location = new System.Drawing.Point(92, 13);
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
            this._nudDecimales.ValueChanged += new System.EventHandler(this._nudDecimales_ValueChanged);
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel5.Location = new System.Drawing.Point(24, 16);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(65, 16);
            this.cndcLabel5.TabIndex = 10;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Decimales:";
            // 
            // _cbxNodoDeConexion
            // 
            this._cbxNodoDeConexion.AutoSize = true;
            this._cbxNodoDeConexion.Location = new System.Drawing.Point(89, 88);
            this._cbxNodoDeConexion.Name = "_cbxNodoDeConexion";
            this._cbxNodoDeConexion.Size = new System.Drawing.Size(15, 14);
            this._cbxNodoDeConexion.TabIndex = 48;
            this._cbxNodoDeConexion.UseVisualStyleBackColor = true;
            this._cbxNodoDeConexion.CheckedChanged += new System.EventHandler(this._cbxNodoDeConexion_CheckedChanged);
            // 
            // _gbxColumnas
            // 
            this._gbxColumnas.Controls.Add(this._txtColumna);
            this._gbxColumnas.Controls.Add(this.cndcLabel1);
            this._gbxColumnas.Location = new System.Drawing.Point(371, 206);
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
            this._txtColumna.Location = new System.Drawing.Point(59, 13);
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
            this.cndcLabel1.Location = new System.Drawing.Point(14, 16);
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
            this._pnlExcel.Location = new System.Drawing.Point(229, 206);
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
            this._nudFilaInicio.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudFilaInicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudFilaInicio.Name = "_nudFilaInicio";
            this._nudFilaInicio.Size = new System.Drawing.Size(74, 22);
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
            this.cndcLabel2.Location = new System.Drawing.Point(11, 11);
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
            this._nudFilaFin.Size = new System.Drawing.Size(74, 22);
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
            this.cndcLabel3.Location = new System.Drawing.Point(24, 34);
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
            this._btnCrear.Location = new System.Drawing.Point(655, 238);
            this._btnCrear.Name = "_btnCrear";
            this._btnCrear.Size = new System.Drawing.Size(84, 26);
            this._btnCrear.TabIndex = 45;
            this._btnCrear.Text = "    Leer datos";
            this._btnCrear.UseVisualStyleBackColor = true;
            this._btnCrear.Click += new System.EventHandler(this._btnCrear_Click);
            // 
            // _cbxNodo
            // 
            this._cbxNodo.AutoSize = true;
            this._cbxNodo.Location = new System.Drawing.Point(168, 113);
            this._cbxNodo.Name = "_cbxNodo";
            this._cbxNodo.Size = new System.Drawing.Size(15, 14);
            this._cbxNodo.TabIndex = 44;
            this._cbxNodo.UseVisualStyleBackColor = true;
            this._cbxNodo.CheckedChanged += new System.EventHandler(this._cbxNodo_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(184, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Nodo:";
            // 
            // _cmbNodos
            // 
            this._cmbNodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbNodos.FormattingEnabled = true;
            this._cmbNodos.Location = new System.Drawing.Point(230, 109);
            this._cmbNodos.Name = "_cmbNodos";
            this._cmbNodos.Size = new System.Drawing.Size(289, 24);
            this._cmbNodos.TabIndex = 43;
            this._cmbNodos.SelectedIndexChanged += new System.EventHandler(this._cmbNodos_SelectedIndexChanged);
            // 
            // _gbxTipoAgente
            // 
            this._gbxTipoAgente.Controls.Add(this._rbtNoRegulados);
            this._gbxTipoAgente.Controls.Add(this._rbtProyectos);
            this._gbxTipoAgente.Controls.Add(this._rbtDistribucion);
            this._gbxTipoAgente.Controls.Add(this._rbtSisAislados);
            this._gbxTipoAgente.Location = new System.Drawing.Point(230, 12);
            this._gbxTipoAgente.Name = "_gbxTipoAgente";
            this._gbxTipoAgente.Size = new System.Drawing.Size(471, 41);
            this._gbxTipoAgente.TabIndex = 41;
            this._gbxTipoAgente.TabStop = false;
            this._gbxTipoAgente.Text = "Tipo agente";
            // 
            // _rbtNoRegulados
            // 
            this._rbtNoRegulados.AutoSize = true;
            this._rbtNoRegulados.Location = new System.Drawing.Point(346, 17);
            this._rbtNoRegulados.Name = "_rbtNoRegulados";
            this._rbtNoRegulados.Size = new System.Drawing.Size(101, 17);
            this._rbtNoRegulados.TabIndex = 41;
            this._rbtNoRegulados.TabStop = true;
            this._rbtNoRegulados.Text = "C. No Regulado";
            this._rbtNoRegulados.UseVisualStyleBackColor = true;
            this._rbtNoRegulados.CheckedChanged += new System.EventHandler(this._rbtNoRegulados_CheckedChanged);
            // 
            // _rbtProyectos
            // 
            this._rbtProyectos.AutoSize = true;
            this._rbtProyectos.Location = new System.Drawing.Point(254, 17);
            this._rbtProyectos.Name = "_rbtProyectos";
            this._rbtProyectos.Size = new System.Drawing.Size(67, 17);
            this._rbtProyectos.TabIndex = 39;
            this._rbtProyectos.TabStop = true;
            this._rbtProyectos.Text = "Proyecto";
            this._rbtProyectos.UseVisualStyleBackColor = true;
            this._rbtProyectos.CheckedChanged += new System.EventHandler(this._rbtProyectos_CheckedChanged);
            // 
            // _rbtDistribucion
            // 
            this._rbtDistribucion.AutoSize = true;
            this._rbtDistribucion.Location = new System.Drawing.Point(20, 17);
            this._rbtDistribucion.Name = "_rbtDistribucion";
            this._rbtDistribucion.Size = new System.Drawing.Size(77, 17);
            this._rbtDistribucion.TabIndex = 37;
            this._rbtDistribucion.TabStop = true;
            this._rbtDistribucion.Text = "Distribuidor";
            this._rbtDistribucion.UseVisualStyleBackColor = true;
            this._rbtDistribucion.CheckedChanged += new System.EventHandler(this._rbtDistribucion_CheckedChanged);
            // 
            // _rbtSisAislados
            // 
            this._rbtSisAislados.AutoSize = true;
            this._rbtSisAislados.Location = new System.Drawing.Point(119, 17);
            this._rbtSisAislados.Name = "_rbtSisAislados";
            this._rbtSisAislados.Size = new System.Drawing.Size(99, 17);
            this._rbtSisAislados.TabIndex = 38;
            this._rbtSisAislados.TabStop = true;
            this._rbtSisAislados.Text = "Sistema Aislado";
            this._rbtSisAislados.UseVisualStyleBackColor = true;
            this._rbtSisAislados.CheckedChanged += new System.EventHandler(this._rbtSisAislados_CheckedChanged);
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbNuevo,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(3, 5);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(203, 25);
            this._toolStrip.TabIndex = 34;
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
            // _tsbNuevo
            // 
            this._tsbNuevo.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNuevo.Name = "_tsbNuevo";
            this._tsbNuevo.Size = new System.Drawing.Size(58, 22);
            this._tsbNuevo.Text = "Nuevo";
            this._tsbNuevo.Click += new System.EventHandler(this._tsbNuevo_Click);
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
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormMigrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 596);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMigrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migrador de datos";
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._gbxNodoSalida.ResumeLayout(false);
            this._gbxNodoSalida.PerformLayout();
            this._gbxAnios.ResumeLayout(false);
            this._gbxAnios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).EndInit();
            this._gbxColumnas.ResumeLayout(false);
            this._gbxColumnas.PerformLayout();
            this._pnlExcel.ResumeLayout(false);
            this._pnlExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).EndInit();
            this._gbxTipoAgente.ResumeLayout(false);
            this._gbxTipoAgente.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cmbAgente;
        private System.Windows.Forms.ComboBox _cmbNodoDeConexion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbTipoTabla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtDocumento;
        private System.Windows.Forms.Button _btnExaminar;
        private System.Windows.Forms.DataGridView _dgvDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.GroupBox _gbxTipoAgente;
        private System.Windows.Forms.RadioButton _rbtProyectos;
        private System.Windows.Forms.RadioButton _rbtDistribucion;
        private System.Windows.Forms.RadioButton _rbtSisAislados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cmbNodos;
        private System.Windows.Forms.CheckBox _cbxNodo;
        private System.Windows.Forms.GroupBox _pnlExcel;
        private System.Windows.Forms.NumericUpDown _nudFilaInicio;
        private Controles.CNDCLabel cndcLabel2;
        private System.Windows.Forms.NumericUpDown _nudFilaFin;
        private Controles.CNDCLabel cndcLabel3;
        private System.Windows.Forms.Button _btnCrear;
        private System.Windows.Forms.GroupBox _gbxColumnas;
        private Controles.CNDCLabel cndcLabel1;
        private System.Windows.Forms.CheckBox _cbxNodoDeConexion;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown _nudDecimales;
        private Controles.CNDCLabel cndcLabel5;
        private System.Windows.Forms.GroupBox _gbxAnios;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCLabel cndcLabel7;
        private System.Windows.Forms.NumericUpDown _nudAnioInicio;
        private System.Windows.Forms.NumericUpDown _nudAnioFin;
        private Controles.CNDCTextBox _txtColumna;
        private System.Windows.Forms.RadioButton _rbtNoRegulados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cmbNodoSalida;
        private System.Windows.Forms.CheckBox _cbxNodoSalida;
        private System.Windows.Forms.GroupBox _gbxNodoSalida;
        private System.Windows.Forms.RadioButton _rbtNCP;
        private System.Windows.Forms.RadioButton _rbtOPTGEN;
        private System.Windows.Forms.RadioButton _rbtSDDP;
        private System.Windows.Forms.TextBox _txtCriterioBloque;
        private System.Windows.Forms.Button _btnLimpiar;
        private System.Windows.Forms.Label _lblCantidadBloques;
        private System.Windows.Forms.RadioButton _rbtPowerFactory;
    }
}