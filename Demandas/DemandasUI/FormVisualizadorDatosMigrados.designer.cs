namespace DemandasUI
{
    partial class FormVisualizadorDatosMigrados
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
            this._dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnRecalcular = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._nudDecimales = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._btnCrear = new System.Windows.Forms.Button();
            this._tsbObcionesDeEdicion = new System.Windows.Forms.ToolStrip();
            this._tsbEliminarSerie = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminarRegistro = new System.Windows.Forms.ToolStripButton();
            this._tsbInsertarRegistros = new System.Windows.Forms.ToolStripButton();
            this._tsbModificarRegistros = new System.Windows.Forms.ToolStripButton();
            this._gbxNodoSalida = new System.Windows.Forms.GroupBox();
            this._rbtPowerFactory = new System.Windows.Forms.RadioButton();
            this._rbtNCP = new System.Windows.Forms.RadioButton();
            this._rbtOPTGEN = new System.Windows.Forms.RadioButton();
            this._rbtSDDP = new System.Windows.Forms.RadioButton();
            this._cbxNodoSalida = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._cmbNodoSalida = new System.Windows.Forms.ComboBox();
            this._cbxNodoDeConexion = new System.Windows.Forms.CheckBox();
            this._cbxNodo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cmbNodos = new System.Windows.Forms.ComboBox();
            this._gbxTipoAgente = new System.Windows.Forms.GroupBox();
            this._rbtNoRegulado = new System.Windows.Forms.RadioButton();
            this._rbtProyectos = new System.Windows.Forms.RadioButton();
            this._rbtDistribucion = new System.Windows.Forms.RadioButton();
            this._rbtSisAislados = new System.Windows.Forms.RadioButton();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).BeginInit();
            this._tsbObcionesDeEdicion.SuspendLayout();
            this._gbxNodoSalida.SuspendLayout();
            this._gbxTipoAgente.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 61);
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
            this._cmbNodoDeConexion.Size = new System.Drawing.Size(293, 24);
            this._cmbNodoDeConexion.TabIndex = 3;
            this._cmbNodoDeConexion.SelectedIndexChanged += new System.EventHandler(this._cmbNodo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nodo de conexión:";
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
            this.label3.Location = new System.Drawing.Point(160, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo Tabla:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.*|*.*";
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDatos.Location = new System.Drawing.Point(6, 189);
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
            this._dgvDatos.Size = new System.Drawing.Size(1017, 349);
            this._dgvDatos.TabIndex = 9;
            this._dgvDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvDatos_CellFormatting);
            this._dgvDatos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this._dgvDatos_RowPrePaint);
            this._dgvDatos.SelectionChanged += new System.EventHandler(this._dgvDatos_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnRecalcular);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._btnCrear);
            this.groupBox1.Controls.Add(this._tsbObcionesDeEdicion);
            this.groupBox1.Controls.Add(this._gbxNodoSalida);
            this.groupBox1.Controls.Add(this._cbxNodoSalida);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._cmbNodoSalida);
            this.groupBox1.Controls.Add(this._cbxNodoDeConexion);
            this.groupBox1.Controls.Add(this._cbxNodo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._cmbNodos);
            this.groupBox1.Controls.Add(this._gbxTipoAgente);
            this.groupBox1.Controls.Add(this._cmbAgente);
            this.groupBox1.Controls.Add(this._dgvDatos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._cmbNodoDeConexion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._cmbTipoTabla);
            this.groupBox1.Location = new System.Drawing.Point(3, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 570);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // _btnRecalcular
            // 
            this._btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnRecalcular.Location = new System.Drawing.Point(732, 157);
            this._btnRecalcular.Name = "_btnRecalcular";
            this._btnRecalcular.Size = new System.Drawing.Size(72, 26);
            this._btnRecalcular.TabIndex = 221;
            this._btnRecalcular.Text = "Recalcular";
            this._btnRecalcular.UseVisualStyleBackColor = true;
            this._btnRecalcular.Click += new System.EventHandler(this._btnRecalcular_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._nudDecimales);
            this.groupBox2.Controls.Add(this.cndcLabel5);
            this.groupBox2.Location = new System.Drawing.Point(588, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 39);
            this.groupBox2.TabIndex = 220;
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
            this.cndcLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel5.Location = new System.Drawing.Point(4, 15);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(86, 16);
            this.cndcLabel5.TabIndex = 10;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Decimales:";
            // 
            // _btnCrear
            // 
            this._btnCrear.Image = global::DemandasUI.Properties.Resources.informe4;
            this._btnCrear.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnCrear.Location = new System.Drawing.Point(623, 157);
            this._btnCrear.Name = "_btnCrear";
            this._btnCrear.Size = new System.Drawing.Size(105, 26);
            this._btnCrear.TabIndex = 219;
            this._btnCrear.Text = "   Visualizar datos";
            this._btnCrear.UseVisualStyleBackColor = true;
            this._btnCrear.Click += new System.EventHandler(this._btnVisualizar_Click);
            // 
            // _tsbObcionesDeEdicion
            // 
            this._tsbObcionesDeEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tsbObcionesDeEdicion.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbObcionesDeEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbEliminarSerie,
            this._tsbEliminarRegistro,
            this._tsbInsertarRegistros,
            this._tsbModificarRegistros});
            this._tsbObcionesDeEdicion.Location = new System.Drawing.Point(6, 542);
            this._tsbObcionesDeEdicion.Name = "_tsbObcionesDeEdicion";
            this._tsbObcionesDeEdicion.Size = new System.Drawing.Size(517, 25);
            this._tsbObcionesDeEdicion.TabIndex = 218;
            this._tsbObcionesDeEdicion.Text = "toolStrip1";
            // 
            // _tsbEliminarSerie
            // 
            this._tsbEliminarSerie.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbEliminarSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarSerie.Name = "_tsbEliminarSerie";
            this._tsbEliminarSerie.Size = new System.Drawing.Size(88, 22);
            this._tsbEliminarSerie.Text = "Borrar tabla";
            this._tsbEliminarSerie.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._tsbEliminarSerie.Click += new System.EventHandler(this._tsbEliminarSerie_Click);
            // 
            // _tsbEliminarRegistro
            // 
            this._tsbEliminarRegistro.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbEliminarRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarRegistro.Name = "_tsbEliminarRegistro";
            this._tsbEliminarRegistro.Size = new System.Drawing.Size(102, 22);
            this._tsbEliminarRegistro.Text = "Borrar registro";
            this._tsbEliminarRegistro.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // _tsbInsertarRegistros
            // 
            this._tsbInsertarRegistros.Image = global::DemandasUI.Properties.Resources.Add;
            this._tsbInsertarRegistros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbInsertarRegistros.Name = "_tsbInsertarRegistros";
            this._tsbInsertarRegistros.Size = new System.Drawing.Size(114, 22);
            this._tsbInsertarRegistros.Text = "Insertar registros";
            this._tsbInsertarRegistros.Click += new System.EventHandler(this._tsbInsertarRegistros_Click);
            // 
            // _tsbModificarRegistros
            // 
            this._tsbModificarRegistros.Image = global::DemandasUI.Properties.Resources.ElaborarInf___copia;
            this._tsbModificarRegistros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbModificarRegistros.Name = "_tsbModificarRegistros";
            this._tsbModificarRegistros.Size = new System.Drawing.Size(201, 22);
            this._tsbModificarRegistros.Text = "Modificar registros desde el excel";
            this._tsbModificarRegistros.Click += new System.EventHandler(this._tsbModificarRegistros_Click);
            // 
            // _gbxNodoSalida
            // 
            this._gbxNodoSalida.Controls.Add(this._rbtPowerFactory);
            this._gbxNodoSalida.Controls.Add(this._rbtNCP);
            this._gbxNodoSalida.Controls.Add(this._rbtOPTGEN);
            this._gbxNodoSalida.Controls.Add(this._rbtSDDP);
            this._gbxNodoSalida.Location = new System.Drawing.Point(527, 126);
            this._gbxNodoSalida.Name = "_gbxNodoSalida";
            this._gbxNodoSalida.Size = new System.Drawing.Size(306, 32);
            this._gbxNodoSalida.TabIndex = 42;
            this._gbxNodoSalida.TabStop = false;
            this._gbxNodoSalida.Text = "Tipo Salida";
            // 
            // _rbtPowerFactory
            // 
            this._rbtPowerFactory.AutoSize = true;
            this._rbtPowerFactory.Location = new System.Drawing.Point(208, 11);
            this._rbtPowerFactory.Name = "_rbtPowerFactory";
            this._rbtPowerFactory.Size = new System.Drawing.Size(93, 17);
            this._rbtPowerFactory.TabIndex = 57;
            this._rbtPowerFactory.TabStop = true;
            this._rbtPowerFactory.Text = "Power Factory";
            this._rbtPowerFactory.UseVisualStyleBackColor = true;
            this._rbtPowerFactory.CheckedChanged += new System.EventHandler(this._rbtPowerFactory_CheckedChanged);
            // 
            // _rbtNCP
            // 
            this._rbtNCP.AutoSize = true;
            this._rbtNCP.Location = new System.Drawing.Point(150, 12);
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
            this._rbtOPTGEN.Location = new System.Drawing.Point(70, 12);
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
            this._rbtSDDP.Location = new System.Drawing.Point(6, 11);
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
            this._cbxNodoSalida.Location = new System.Drawing.Point(133, 138);
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
            this.label6.Location = new System.Drawing.Point(149, 137);
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
            this._cmbNodoSalida.Size = new System.Drawing.Size(294, 24);
            this._cmbNodoSalida.TabIndex = 50;
            this._cmbNodoSalida.SelectedIndexChanged += new System.EventHandler(this._cmbNodoSalida_SelectedIndexChanged);
            // 
            // _cbxNodoDeConexion
            // 
            this._cbxNodoDeConexion.AutoSize = true;
            this._cbxNodoDeConexion.Location = new System.Drawing.Point(100, 88);
            this._cbxNodoDeConexion.Name = "_cbxNodoDeConexion";
            this._cbxNodoDeConexion.Size = new System.Drawing.Size(15, 14);
            this._cbxNodoDeConexion.TabIndex = 48;
            this._cbxNodoDeConexion.UseVisualStyleBackColor = true;
            this._cbxNodoDeConexion.CheckedChanged += new System.EventHandler(this._cbxNodoDeConexion_CheckedChanged);
            // 
            // _cbxNodo
            // 
            this._cbxNodo.AutoSize = true;
            this._cbxNodo.Location = new System.Drawing.Point(169, 113);
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
            this.label5.Location = new System.Drawing.Point(185, 111);
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
            this._cmbNodos.Size = new System.Drawing.Size(293, 24);
            this._cmbNodos.TabIndex = 43;
            this._cmbNodos.SelectedIndexChanged += new System.EventHandler(this._cmbNodos_SelectedIndexChanged);
            // 
            // _gbxTipoAgente
            // 
            this._gbxTipoAgente.Controls.Add(this._rbtNoRegulado);
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
            // _rbtNoRegulado
            // 
            this._rbtNoRegulado.AutoSize = true;
            this._rbtNoRegulado.Location = new System.Drawing.Point(346, 17);
            this._rbtNoRegulado.Name = "_rbtNoRegulado";
            this._rbtNoRegulado.Size = new System.Drawing.Size(101, 17);
            this._rbtNoRegulado.TabIndex = 41;
            this._rbtNoRegulado.TabStop = true;
            this._rbtNoRegulado.Text = "C. No Regulado";
            this._rbtNoRegulado.UseVisualStyleBackColor = true;
            this._rbtNoRegulado.CheckedChanged += new System.EventHandler(this._rbtNoRegulados_CheckedChanged);
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
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(3, 5);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(216, 25);
            this._toolStrip.TabIndex = 34;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::DemandasUI.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(69, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(62, 22);
            this._tsbEditar.Text = "Nuevo";
            this._tsbEditar.Click += new System.EventHandler(this._tsbNuevo_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(73, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormVisualizadorDatosMigrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 596);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormVisualizadorDatosMigrados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de datos migrados";
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDecimales)).EndInit();
            this._tsbObcionesDeEdicion.ResumeLayout(false);
            this._tsbObcionesDeEdicion.PerformLayout();
            this._gbxNodoSalida.ResumeLayout(false);
            this._gbxNodoSalida.PerformLayout();
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
        private System.Windows.Forms.DataGridView _dgvDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.GroupBox _gbxTipoAgente;
        private System.Windows.Forms.RadioButton _rbtProyectos;
        private System.Windows.Forms.RadioButton _rbtDistribucion;
        private System.Windows.Forms.RadioButton _rbtSisAislados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cmbNodos;
        private System.Windows.Forms.CheckBox _cbxNodo;
        private System.Windows.Forms.CheckBox _cbxNodoDeConexion;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.RadioButton _rbtNoRegulado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cmbNodoSalida;
        private System.Windows.Forms.CheckBox _cbxNodoSalida;
        private System.Windows.Forms.GroupBox _gbxNodoSalida;
        private System.Windows.Forms.RadioButton _rbtNCP;
        private System.Windows.Forms.RadioButton _rbtOPTGEN;
        private System.Windows.Forms.RadioButton _rbtSDDP;
        private System.Windows.Forms.ToolStrip _tsbObcionesDeEdicion;
        private System.Windows.Forms.ToolStripButton _tsbEliminarSerie;
        private System.Windows.Forms.ToolStripButton _tsbEliminarRegistro;
        private System.Windows.Forms.ToolStripButton _tsbInsertarRegistros;
        private System.Windows.Forms.ToolStripButton _tsbModificarRegistros;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown _nudDecimales;
        private Controles.CNDCLabel cndcLabel5;
        private System.Windows.Forms.Button _btnCrear;
        private System.Windows.Forms.Button _btnRecalcular;
        private System.Windows.Forms.RadioButton _rbtPowerFactory;
    }
}