namespace Proyectos
{
    partial class CtrlDatosTecnicosProysEolicos
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this.label2 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this._txtTecnologia = new Controles.CNDCTextBox();
            this.groupBox1 = new Controles.CNDCGroupBox();
            this._tsbOpcionesDeEdicion = new System.Windows.Forms.ToolStrip();
            this._tsbEliminarSerie = new System.Windows.Forms.ToolStripButton();
            this._btnImportarDeExcel = new System.Windows.Forms.ToolStripButton();
            this._btnPegarDeExcel = new System.Windows.Forms.ToolStripButton();
            this._dgvGeneracionPorAnio = new Controles.CNDCGridView();
            this._cmbTecnologia = new Controles.CNDCComboBox();
            this.label4 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this._txtNroUnidades = new Controles.CNDCTextBoxInt();
            this.label11 = new Controles.CNDCLabel();
            this._txtPotenciaInstalada = new Controles.CNDCTextBoxFloat();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnElimFilaFin = new System.Windows.Forms.ToolStripButton();
            this._btnElimFilaInicio = new System.Windows.Forms.ToolStripButton();
            this._btnAdFilaFin = new System.Windows.Forms.ToolStripButton();
            this._btnAdFilaInicio = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._gbxDatosProyectos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._tsbOpcionesDeEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvGeneracionPorAnio)).BeginInit();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this._txtTecnologia);
            this._gbxDatosProyectos.Controls.Add(this.groupBox1);
            this._gbxDatosProyectos.Controls.Add(this._cmbTecnologia);
            this._gbxDatosProyectos.Controls.Add(this.label4);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this._txtNroUnidades);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtPotenciaInstalada);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(2, 21);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(983, 570);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 6;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Observaciones:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(446, 79);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(399, 48);
            this._txtObservaciones.TabIndex = 7;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_EOLICO_SOLAR.OBSERVACIONES";
            // 
            // _txtTecnologia
            // 
            this._txtTecnologia.BackColor = System.Drawing.Color.White;
            this._txtTecnologia.EnterComoTab = true;
            this._txtTecnologia.Etiqueta = null;
            this._txtTecnologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTecnologia.Location = new System.Drawing.Point(446, 57);
            this._txtTecnologia.MaxLength = 2000;
            this._txtTecnologia.Name = "_txtTecnologia";
            this._txtTecnologia.Size = new System.Drawing.Size(399, 22);
            this._txtTecnologia.TabIndex = 5;
            this._txtTecnologia.TablaCampoBD = "F_PR_DATO_TEC_EOLICO_SOLAR.TECNOLOGIA";
            this._txtTecnologia.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._tsbOpcionesDeEdicion);
            this.groupBox1.Controls.Add(this._dgvGeneracionPorAnio);
            this.groupBox1.Location = new System.Drawing.Point(6, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 441);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TablaCampoBD = null;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabla de generación probable por año (MWh)";
            // 
            // _tsbOpcionesDeEdicion
            // 
            this._tsbOpcionesDeEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tsbOpcionesDeEdicion.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbOpcionesDeEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbEliminarSerie,
            this._btnImportarDeExcel,
            this._btnPegarDeExcel});
            this._tsbOpcionesDeEdicion.Location = new System.Drawing.Point(7, 413);
            this._tsbOpcionesDeEdicion.Name = "_tsbOpcionesDeEdicion";
            this._tsbOpcionesDeEdicion.Size = new System.Drawing.Size(114, 25);
            this._tsbOpcionesDeEdicion.TabIndex = 217;
            this._tsbOpcionesDeEdicion.Text = "toolStrip1";
            // 
            // _tsbEliminarSerie
            // 
            this._tsbEliminarSerie.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbEliminarSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarSerie.Name = "_tsbEliminarSerie";
            this._tsbEliminarSerie.Size = new System.Drawing.Size(121, 22);
            this._tsbEliminarSerie.Text = "Borrar generación";
            this._tsbEliminarSerie.Visible = false;
            this._tsbEliminarSerie.Click += new System.EventHandler(this._tsbEliminarSerie_Click);
            // 
            // _btnImportarDeExcel
            // 
            this._btnImportarDeExcel.Image = global::Proyectos.Properties.Resources.IcoExcel;
            this._btnImportarDeExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnImportarDeExcel.Name = "_btnImportarDeExcel";
            this._btnImportarDeExcel.Size = new System.Drawing.Size(145, 22);
            this._btnImportarDeExcel.Text = "Importar de Doc. Excel";
            this._btnImportarDeExcel.Visible = false;
            this._btnImportarDeExcel.Click += new System.EventHandler(this._btnImportarDeExcel_Click);
            // 
            // _btnPegarDeExcel
            // 
            this._btnPegarDeExcel.Image = global::Proyectos.Properties.Resources.pegarExcel;
            this._btnPegarDeExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnPegarDeExcel.Name = "_btnPegarDeExcel";
            this._btnPegarDeExcel.Size = new System.Drawing.Size(102, 22);
            this._btnPegarDeExcel.Text = "Pegar de Excel";
            this._btnPegarDeExcel.Click += new System.EventHandler(this._btnPegarDeExcel_Click);
            // 
            // _dgvGeneracionPorAnio
            // 
            this._dgvGeneracionPorAnio.AllowUserToAddRows = false;
            this._dgvGeneracionPorAnio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvGeneracionPorAnio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvGeneracionPorAnio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvGeneracionPorAnio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvGeneracionPorAnio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvGeneracionPorAnio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvGeneracionPorAnio.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvGeneracionPorAnio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvGeneracionPorAnio.Location = new System.Drawing.Point(6, 19);
            this._dgvGeneracionPorAnio.Name = "_dgvGeneracionPorAnio";
            this._dgvGeneracionPorAnio.NombreContenedor = null;
            this._dgvGeneracionPorAnio.RowHeadersWidth = 25;
            this._dgvGeneracionPorAnio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dgvGeneracionPorAnio.Size = new System.Drawing.Size(959, 388);
            this._dgvGeneracionPorAnio.TabIndex = 0;
            this._dgvGeneracionPorAnio.TablaCampoBD = null;
            this._dgvGeneracionPorAnio.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvGeneracionPorAnio_CellValidated);
            this._dgvGeneracionPorAnio.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._dgvGeneracionPorAnio_CellValidating);
            this._dgvGeneracionPorAnio.SelectionChanged += new System.EventHandler(this._dgvGeneracionPorAnio_SelectionChanged);
            // 
            // _cmbTecnologia
            // 
            this._cmbTecnologia.EnterComoTab = true;
            this._cmbTecnologia.Etiqueta = null;
            this._cmbTecnologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbTecnologia.FormattingEnabled = true;
            this._cmbTecnologia.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this._cmbTecnologia.Location = new System.Drawing.Point(446, 58);
            this._cmbTecnologia.Name = "_cmbTecnologia";
            this._cmbTecnologia.Size = new System.Drawing.Size(198, 24);
            this._cmbTecnologia.TabIndex = 170;
            this._cmbTecnologia.TablaCampoBD = null;
            this._cmbTecnologia.SelectedIndexChanged += new System.EventHandler(this._cmbTecnologia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(353, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 4;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tecnología:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(313, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 16);
            this.label9.TabIndex = 2;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Nro. de unidades:";
            // 
            // _txtNroUnidades
            // 
            this._txtNroUnidades.AceptaNegativo = false;
            this._txtNroUnidades.BackColor = System.Drawing.Color.White;
            this._txtNroUnidades.EnterComoTab = true;
            this._txtNroUnidades.Etiqueta = null;
            this._txtNroUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNroUnidades.Location = new System.Drawing.Point(446, 34);
            this._txtNroUnidades.MaxDigitosDecimales = 0;
            this._txtNroUnidades.MaxDigitosEnteros = 0;
            this._txtNroUnidades.MaxLength = 30;
            this._txtNroUnidades.Name = "_txtNroUnidades";
            this._txtNroUnidades.Size = new System.Drawing.Size(121, 22);
            this._txtNroUnidades.TabIndex = 3;
            this._txtNroUnidades.TablaCampoBD = "F_PR_DATO_TEC_EOLICO_SOLAR.NRO_UNIDADES";
            this._txtNroUnidades.Text = "0";
            this._txtNroUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtNroUnidades.UsarFormatoNumerico = true;
            this._txtNroUnidades.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtNroUnidades.ValorDouble = 0D;
            this._txtNroUnidades.ValorFloat = 0F;
            this._txtNroUnidades.ValorInt = 0;
            this._txtNroUnidades.ValorLong = ((long)(0));
            this._txtNroUnidades.Value = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(263, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 16);
            this.label11.TabIndex = 0;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Potencia instalada (MW):";
            // 
            // _txtPotenciaInstalada
            // 
            this._txtPotenciaInstalada.AceptaNegativo = false;
            this._txtPotenciaInstalada.BackColor = System.Drawing.Color.White;
            this._txtPotenciaInstalada.EnterComoTab = true;
            this._txtPotenciaInstalada.Etiqueta = null;
            this._txtPotenciaInstalada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPotenciaInstalada.Location = new System.Drawing.Point(446, 11);
            this._txtPotenciaInstalada.MaxDigitosDecimales = 0;
            this._txtPotenciaInstalada.MaxDigitosEnteros = 0;
            this._txtPotenciaInstalada.MaxLength = 30;
            this._txtPotenciaInstalada.Name = "_txtPotenciaInstalada";
            this._txtPotenciaInstalada.Size = new System.Drawing.Size(121, 22);
            this._txtPotenciaInstalada.TabIndex = 1;
            this._txtPotenciaInstalada.TablaCampoBD = "F_PR_DATO_TEC_EOLICO_SOLAR.POTENCIA_INSTALADA";
            this._txtPotenciaInstalada.Text = "0";
            this._txtPotenciaInstalada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPotenciaInstalada.UsarFormatoNumerico = true;
            this._txtPotenciaInstalada.ValDouble = 0D;
            this._txtPotenciaInstalada.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtPotenciaInstalada.ValorDouble = 0D;
            this._txtPotenciaInstalada.ValorFloat = 0F;
            this._txtPotenciaInstalada.ValorInt = 0;
            this._txtPotenciaInstalada.ValorLong = ((long)(0));
            this._txtPotenciaInstalada.Value = 0F;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._btnElimFilaFin,
            this._btnElimFilaInicio,
            this._btnAdFilaFin,
            this._btnAdFilaInicio});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(989, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::Proyectos.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(69, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(57, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(73, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _btnElimFilaFin
            // 
            this._btnElimFilaFin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnElimFilaFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnElimFilaFin.Enabled = false;
            this._btnElimFilaFin.Image = global::Proyectos.Properties.Resources.ElimFilaFin;
            this._btnElimFilaFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnElimFilaFin.Name = "_btnElimFilaFin";
            this._btnElimFilaFin.Size = new System.Drawing.Size(23, 22);
            this._btnElimFilaFin.Text = "toolStripButton5";
            this._btnElimFilaFin.ToolTipText = "Borrar último registro";
            this._btnElimFilaFin.Click += new System.EventHandler(this._btnElimFilaFin_Click);
            // 
            // _btnElimFilaInicio
            // 
            this._btnElimFilaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnElimFilaInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnElimFilaInicio.Enabled = false;
            this._btnElimFilaInicio.Image = global::Proyectos.Properties.Resources.ElimFilaIni;
            this._btnElimFilaInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnElimFilaInicio.Name = "_btnElimFilaInicio";
            this._btnElimFilaInicio.Size = new System.Drawing.Size(23, 22);
            this._btnElimFilaInicio.Text = "toolStripButton4";
            this._btnElimFilaInicio.ToolTipText = "Borrar primer registro";
            this._btnElimFilaInicio.Click += new System.EventHandler(this._btnElimFilaInicio_Click);
            // 
            // _btnAdFilaFin
            // 
            this._btnAdFilaFin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnAdFilaFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdFilaFin.Enabled = false;
            this._btnAdFilaFin.Image = global::Proyectos.Properties.Resources.AdFilaFin;
            this._btnAdFilaFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdFilaFin.Name = "_btnAdFilaFin";
            this._btnAdFilaFin.Size = new System.Drawing.Size(23, 22);
            this._btnAdFilaFin.Text = "toolStripButton3";
            this._btnAdFilaFin.ToolTipText = "Adicionar el final";
            this._btnAdFilaFin.Click += new System.EventHandler(this._btnAdFilaFin_Click);
            // 
            // _btnAdFilaInicio
            // 
            this._btnAdFilaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnAdFilaInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdFilaInicio.Enabled = false;
            this._btnAdFilaInicio.Image = global::Proyectos.Properties.Resources.AdFilaIni;
            this._btnAdFilaInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdFilaInicio.Name = "_btnAdFilaInicio";
            this._btnAdFilaInicio.Size = new System.Drawing.Size(23, 22);
            this._btnAdFilaInicio.Text = "toolStripButton1";
            this._btnAdFilaInicio.ToolTipText = "Adicionar al inicio";
            this._btnAdFilaInicio.Click += new System.EventHandler(this._btnAdFilaInicio_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(1000, 3);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(109, 22);
            this._dtpFechaRegistro.TabIndex = 3;
            this._dtpFechaRegistro.TablaCampoBD = null;
            this._dtpFechaRegistro.Visible = false;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cndcLabel1.Location = new System.Drawing.Point(874, 4);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosTecnicosProysEolicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlDatosTecnicosProysEolicos";
            this.Size = new System.Drawing.Size(989, 592);
            this._gbxDatosProyectos.ResumeLayout(false);
            this._gbxDatosProyectos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._tsbOpcionesDeEdicion.ResumeLayout(false);
            this._tsbOpcionesDeEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvGeneracionPorAnio)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCLabel label4;
        private Controles.CNDCLabel label9;
        private Controles.CNDCTextBoxInt _txtNroUnidades;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBoxFloat _txtPotenciaInstalada;
        private Controles.CNDCComboBox _cmbTecnologia;
        private Controles.CNDCGroupBox groupBox1;
        private Controles.CNDCTextBox _txtTecnologia;
        private Controles.CNDCLabel label2;
        private Controles.CNDCTextBox _txtObservaciones;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCGridView _dgvGeneracionPorAnio;
        private System.Windows.Forms.ToolStrip _tsbOpcionesDeEdicion;
        private System.Windows.Forms.ToolStripButton _tsbEliminarSerie;
        private System.Windows.Forms.ToolStripButton _btnPegarDeExcel;
        private System.Windows.Forms.ToolStripButton _btnElimFilaFin;
        private System.Windows.Forms.ToolStripButton _btnElimFilaInicio;
        private System.Windows.Forms.ToolStripButton _btnAdFilaFin;
        private System.Windows.Forms.ToolStripButton _btnAdFilaInicio;
        private System.Windows.Forms.ToolStripButton _btnImportarDeExcel;

    }
}
