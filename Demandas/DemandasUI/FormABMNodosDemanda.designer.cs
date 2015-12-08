namespace DemandasUI
{
    partial class FormABMNodosDemanda
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
            this._txtNombre = new Controles.CNDCTextBox();
            this.label2 = new Controles.CNDCLabel();
            this.label6 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this.label11 = new Controles.CNDCLabel();
            this._txtSigla = new Controles.CNDCTextBox();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this._txtTension = new Controles.CNDCTextBoxInt();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnEliminarNodoConexion = new System.Windows.Forms.Button();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtCriterioDeAsignacion = new Controles.CNDCTextBox();
            this._btnAdicionarNodo = new System.Windows.Forms.Button();
            this._txtSiglaNodoDeConexion = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtNroDeNodoDeConexion = new Controles.CNDCTextBox();
            this._cmbArea = new Controles.CNDCComboBox();
            this.Area = new Controles.CNDCLabel();
            this._cmbTipoNodo = new Controles.CNDCComboBox();
            this.label4 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dtpFechaSalida = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dtpFechaIngreso = new Controles.CNDCDateTimePicker();
            this._dgvNodos = new System.Windows.Forms.DataGridView();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodos)).BeginInit();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.White;
            this._txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtNombre.EnterComoTab = true;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(253, 34);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(274, 22);
            this._txtNombre.TabIndex = 3;
            this._txtNombre.TablaCampoBD = "F_DM_NODO_DEMANDA.NOMBRE_NODO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 21;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Descripción:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 6;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Tensión (kV):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(210, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 4;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Sigla:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(196, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 2;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nombre:";
            // 
            // _txtSigla
            // 
            this._txtSigla.BackColor = System.Drawing.Color.White;
            this._txtSigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtSigla.EnterComoTab = true;
            this._txtSigla.Etiqueta = null;
            this._txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSigla.Location = new System.Drawing.Point(253, 56);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(160, 22);
            this._txtSigla.TabIndex = 5;
            this._txtSigla.TablaCampoBD = "F_DM_NODO_DEMANDA.SIGLA_NODO";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.BackColor = System.Drawing.Color.White;
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDescripcion.Location = new System.Drawing.Point(253, 190);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(486, 39);
            this._txtDescripcion.TabIndex = 22;
            this._txtDescripcion.TablaCampoBD = "F_DM_NODO_DEMANDA.DESCRIPCION_NODO";
            // 
            // _txtTension
            // 
            this._txtTension.BackColor = System.Drawing.Color.White;
            this._txtTension.EnterComoTab = true;
            this._txtTension.Etiqueta = null;
            this._txtTension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTension.Location = new System.Drawing.Point(253, 78);
            this._txtTension.MaxDigitosDecimales = 0;
            this._txtTension.MaxDigitosEnteros = 0;
            this._txtTension.Name = "_txtTension";
            this._txtTension.Size = new System.Drawing.Size(160, 22);
            this._txtTension.TabIndex = 7;
            this._txtTension.TablaCampoBD = "F_DM_NODO_DEMANDA.NIVEL_TENSION";
            this._txtTension.Text = "0";
            this._txtTension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTension.Value = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnEliminarNodoConexion);
            this.groupBox1.Controls.Add(this.cndcLabel4);
            this.groupBox1.Controls.Add(this._txtCriterioDeAsignacion);
            this.groupBox1.Controls.Add(this._btnAdicionarNodo);
            this.groupBox1.Controls.Add(this._txtSiglaNodoDeConexion);
            this.groupBox1.Controls.Add(this.cndcLabel3);
            this.groupBox1.Controls.Add(this._txtNroDeNodoDeConexion);
            this.groupBox1.Controls.Add(this._cmbArea);
            this.groupBox1.Controls.Add(this.Area);
            this.groupBox1.Controls.Add(this._cmbTipoNodo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cndcLabel2);
            this.groupBox1.Controls.Add(this._dtpFechaSalida);
            this.groupBox1.Controls.Add(this.cndcLabel1);
            this.groupBox1.Controls.Add(this._dtpFechaIngreso);
            this.groupBox1.Controls.Add(this._dgvNodos);
            this.groupBox1.Controls.Add(this._txtNombre);
            this.groupBox1.Controls.Add(this._txtTension);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this._txtDescripcion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._txtSigla);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 537);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // _btnEliminarNodoConexion
            // 
            this._btnEliminarNodoConexion.Image = global::DemandasUI.Properties.Resources.Delete;
            this._btnEliminarNodoConexion.Location = new System.Drawing.Point(528, 99);
            this._btnEliminarNodoConexion.Name = "_btnEliminarNodoConexion";
            this._btnEliminarNodoConexion.Size = new System.Drawing.Size(24, 23);
            this._btnEliminarNodoConexion.TabIndex = 12;
            this._btnEliminarNodoConexion.UseVisualStyleBackColor = true;
            this._btnEliminarNodoConexion.Click += new System.EventHandler(this._btnEliminarNodoConexion_Click);
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel4.Location = new System.Drawing.Point(136, 172);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(113, 16);
            this.cndcLabel4.TabIndex = 19;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Criterio agregación:";
            // 
            // _txtCriterioDeAsignacion
            // 
            this._txtCriterioDeAsignacion.BackColor = System.Drawing.Color.White;
            this._txtCriterioDeAsignacion.EnterComoTab = true;
            this._txtCriterioDeAsignacion.Etiqueta = null;
            this._txtCriterioDeAsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCriterioDeAsignacion.Location = new System.Drawing.Point(253, 168);
            this._txtCriterioDeAsignacion.Name = "_txtCriterioDeAsignacion";
            this._txtCriterioDeAsignacion.Size = new System.Drawing.Size(160, 22);
            this._txtCriterioDeAsignacion.TabIndex = 20;
            this._txtCriterioDeAsignacion.TablaCampoBD = "F_DM_NODO_DEMANDA.CRITERIO_AGREGACION";
            // 
            // _btnAdicionarNodo
            // 
            this._btnAdicionarNodo.Image = global::DemandasUI.Properties.Resources.Add;
            this._btnAdicionarNodo.Location = new System.Drawing.Point(503, 99);
            this._btnAdicionarNodo.Name = "_btnAdicionarNodo";
            this._btnAdicionarNodo.Size = new System.Drawing.Size(24, 23);
            this._btnAdicionarNodo.TabIndex = 11;
            this._btnAdicionarNodo.UseVisualStyleBackColor = true;
            this._btnAdicionarNodo.Click += new System.EventHandler(this._btnAdicionarNodo_Click);
            // 
            // _txtSiglaNodoDeConexion
            // 
            this._txtSiglaNodoDeConexion.BackColor = System.Drawing.Color.Gainsboro;
            this._txtSiglaNodoDeConexion.EnterComoTab = false;
            this._txtSiglaNodoDeConexion.Etiqueta = null;
            this._txtSiglaNodoDeConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSiglaNodoDeConexion.Location = new System.Drawing.Point(415, 100);
            this._txtSiglaNodoDeConexion.Name = "_txtSiglaNodoDeConexion";
            this._txtSiglaNodoDeConexion.ReadOnly = true;
            this._txtSiglaNodoDeConexion.Size = new System.Drawing.Size(85, 22);
            this._txtSiglaNodoDeConexion.TabIndex = 10;
            this._txtSiglaNodoDeConexion.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel3.Location = new System.Drawing.Point(130, 104);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(119, 16);
            this.cndcLabel3.TabIndex = 8;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Nodo de agregación:";
            // 
            // _txtNroDeNodoDeConexion
            // 
            this._txtNroDeNodoDeConexion.BackColor = System.Drawing.Color.Gainsboro;
            this._txtNroDeNodoDeConexion.EnterComoTab = false;
            this._txtNroDeNodoDeConexion.Etiqueta = null;
            this._txtNroDeNodoDeConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNroDeNodoDeConexion.Location = new System.Drawing.Point(253, 100);
            this._txtNroDeNodoDeConexion.Name = "_txtNroDeNodoDeConexion";
            this._txtNroDeNodoDeConexion.ReadOnly = true;
            this._txtNroDeNodoDeConexion.Size = new System.Drawing.Size(160, 22);
            this._txtNroDeNodoDeConexion.TabIndex = 9;
            this._txtNroDeNodoDeConexion.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // _cmbArea
            // 
            this._cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbArea.EnterComoTab = false;
            this._cmbArea.Etiqueta = null;
            this._cmbArea.FormattingEnabled = true;
            this._cmbArea.Location = new System.Drawing.Point(253, 123);
            this._cmbArea.Name = "_cmbArea";
            this._cmbArea.Size = new System.Drawing.Size(160, 21);
            this._cmbArea.TabIndex = 14;
            this._cmbArea.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // Area
            // 
            this.Area.AutoSize = true;
            this.Area.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Area.Location = new System.Drawing.Point(214, 129);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(35, 16);
            this.Area.TabIndex = 13;
            this.Area.TablaCampoBD = null;
            this.Area.Text = "Area:";
            // 
            // _cmbTipoNodo
            // 
            this._cmbTipoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoNodo.EnterComoTab = false;
            this._cmbTipoNodo.Etiqueta = null;
            this._cmbTipoNodo.FormattingEnabled = true;
            this._cmbTipoNodo.Location = new System.Drawing.Point(253, 12);
            this._cmbTipoNodo.Name = "_cmbTipoNodo";
            this._cmbTipoNodo.Size = new System.Drawing.Size(160, 21);
            this._cmbTipoNodo.TabIndex = 1;
            this._cmbTipoNodo.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            this._cmbTipoNodo.SelectedIndexChanged += new System.EventHandler(this._cmbTipoNodo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 0;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tipo Nodo:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(377, 148);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(102, 16);
            this.cndcLabel2.TabIndex = 17;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Fecha salida:";
            // 
            // _dtpFechaSalida
            // 
            this._dtpFechaSalida.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaSalida.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaSalida.Location = new System.Drawing.Point(483, 145);
            this._dtpFechaSalida.Name = "_dtpFechaSalida";
            this._dtpFechaSalida.Size = new System.Drawing.Size(118, 22);
            this._dtpFechaSalida.TabIndex = 18;
            this._dtpFechaSalida.TablaCampoBD = "F_DM_NODO_DEMANDA.FECHA_SALIDA";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(162, 149);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(87, 16);
            this.cndcLabel1.TabIndex = 15;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha ingreso:";
            // 
            // _dtpFechaIngreso
            // 
            this._dtpFechaIngreso.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaIngreso.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaIngreso.Location = new System.Drawing.Point(253, 145);
            this._dtpFechaIngreso.Name = "_dtpFechaIngreso";
            this._dtpFechaIngreso.Size = new System.Drawing.Size(118, 22);
            this._dtpFechaIngreso.TabIndex = 16;
            this._dtpFechaIngreso.TablaCampoBD = "F_DM_NODO_DEMANDA.FECHA_INGRESO";
            // 
            // _dgvNodos
            // 
            this._dgvNodos.AllowUserToAddRows = false;
            this._dgvNodos.AllowUserToDeleteRows = false;
            this._dgvNodos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvNodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvNodos.Location = new System.Drawing.Point(10, 235);
            this._dgvNodos.Name = "_dgvNodos";
            this._dgvNodos.ReadOnly = true;
            this._dgvNodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvNodos.Size = new System.Drawing.Size(828, 302);
            this._dgvNodos.TabIndex = 23;
            this._dgvNodos.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._tsbNuevo,
            this._tsbEliminar});
            this._toolStrip.Location = new System.Drawing.Point(2, -1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(343, 25);
            this._toolStrip.TabIndex = 0;
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
            this._tsbEditar.Image = global::DemandasUI.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(57, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
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
            // _tsbNuevo
            // 
            this._tsbNuevo.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNuevo.Name = "_tsbNuevo";
            this._tsbNuevo.Size = new System.Drawing.Size(62, 22);
            this._tsbNuevo.Text = "Nuevo";
            this._tsbNuevo.Click += new System.EventHandler(this._tsbNuevo_Click);
            // 
            // _tsbEliminar
            // 
            this._tsbEliminar.Image = global::DemandasUI.Properties.Resources.cancel;
            this._tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminar.Name = "_tsbEliminar";
            this._tsbEliminar.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminar.Text = "Eliminar";
            this._tsbEliminar.Click += new System.EventHandler(this._tsbEliminar_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormABMNodosDemanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 559);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormABMNodosDemanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar/Editar nodos ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodos)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel label2;
        private Controles.CNDCLabel label6;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBox _txtSigla;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCTextBoxInt _txtTension;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.DataGridView _dgvNodos;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private Controles.CNDCLabel cndcLabel2;
        protected Controles.CNDCDateTimePicker _dtpFechaSalida;
        private Controles.CNDCLabel cndcLabel1;
        protected Controles.CNDCDateTimePicker _dtpFechaIngreso;
        private Controles.CNDCComboBox _cmbTipoNodo;
        private Controles.CNDCLabel label4;
        private Controles.CNDCComboBox _cmbArea;
        private Controles.CNDCLabel Area;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtNroDeNodoDeConexion;
        private Controles.CNDCTextBox _txtSiglaNodoDeConexion;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBox _txtCriterioDeAsignacion;
        private System.Windows.Forms.Button _btnAdicionarNodo;
        private System.Windows.Forms.Button _btnEliminarNodoConexion;
        private System.Windows.Forms.ToolStripButton _tsbEliminar;
    }
}