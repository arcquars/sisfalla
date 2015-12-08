namespace Proyectos
{
    partial class CtrlDatosTecnicosDeProysCapacitores
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
            this._txTensionNominal = new Controles.CNDCTextBoxFloat();
            this._txtPotenciaNominalTrifasica = new Controles.CNDCTextBoxFloat();
            this.label9 = new Controles.CNDCLabel();
            this.label4 = new Controles.CNDCLabel();
            this._cmbTipoCapacitor = new Controles.CNDCComboBox();
            this.label1 = new Controles.CNDCLabel();
            this._txtXcReactanciaCapcitiva = new Controles.CNDCTextBoxFloat();
            this.label2 = new Controles.CNDCLabel();
            this.label6 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this.label14 = new Controles.CNDCLabel();
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this._txtX1 = new Controles.CNDCTextBoxFloat();
            this.label15 = new Controles.CNDCLabel();
            this._txtNodoDestino = new Controles.CNDCTextBox();
            this._txtNodoOrigen = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtSubestacionOrigen = new Controles.CNDCTextBox();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._gbxDatosProyectos.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _txTensionNominal
            // 
            this._txTensionNominal.AceptaNegativo = false;
            this._txTensionNominal.BackColor = System.Drawing.Color.White;
            this._txTensionNominal.EnterComoTab = true;
            this._txTensionNominal.Etiqueta = null;
            this._txTensionNominal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txTensionNominal.Location = new System.Drawing.Point(385, 68);
            this._txTensionNominal.MaxDigitosDecimales = 0;
            this._txTensionNominal.MaxDigitosEnteros = 0;
            this._txTensionNominal.MaxLength = 30;
            this._txTensionNominal.Name = "_txTensionNominal";
            this._txTensionNominal.Size = new System.Drawing.Size(113, 22);
            this._txTensionNominal.TabIndex = 5;
            this._txTensionNominal.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.TENSION_NOMINAL";
            this._txTensionNominal.Text = "0";
            this._txTensionNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txTensionNominal.UsarFormatoNumerico = true;
            this._txTensionNominal.ValDouble = 0D;
            this._txTensionNominal.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txTensionNominal.ValorDouble = 0D;
            this._txTensionNominal.ValorFloat = 0F;
            this._txTensionNominal.ValorInt = 0;
            this._txTensionNominal.ValorLong = ((long)(0));
            this._txTensionNominal.Value = 0F;
            this._txTensionNominal.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txTensionNominal_KeyDown);
            this._txTensionNominal.Validating += new System.ComponentModel.CancelEventHandler(this._txTensionNominal_Validating);
            // 
            // _txtPotenciaNominalTrifasica
            // 
            this._txtPotenciaNominalTrifasica.AceptaNegativo = false;
            this._txtPotenciaNominalTrifasica.BackColor = System.Drawing.Color.White;
            this._txtPotenciaNominalTrifasica.EnterComoTab = true;
            this._txtPotenciaNominalTrifasica.Etiqueta = null;
            this._txtPotenciaNominalTrifasica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPotenciaNominalTrifasica.Location = new System.Drawing.Point(385, 91);
            this._txtPotenciaNominalTrifasica.MaxDigitosDecimales = 0;
            this._txtPotenciaNominalTrifasica.MaxDigitosEnteros = 0;
            this._txtPotenciaNominalTrifasica.MaxLength = 30;
            this._txtPotenciaNominalTrifasica.Name = "_txtPotenciaNominalTrifasica";
            this._txtPotenciaNominalTrifasica.Size = new System.Drawing.Size(113, 22);
            this._txtPotenciaNominalTrifasica.TabIndex = 7;
            this._txtPotenciaNominalTrifasica.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.POT_NOMINAL_TRIFASICA_REAC";
            this._txtPotenciaNominalTrifasica.Text = "0";
            this._txtPotenciaNominalTrifasica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPotenciaNominalTrifasica.UsarFormatoNumerico = true;
            this._txtPotenciaNominalTrifasica.ValDouble = 0D;
            this._txtPotenciaNominalTrifasica.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtPotenciaNominalTrifasica.ValorDouble = 0D;
            this._txtPotenciaNominalTrifasica.ValorFloat = 0F;
            this._txtPotenciaNominalTrifasica.ValorInt = 0;
            this._txtPotenciaNominalTrifasica.ValorLong = ((long)(0));
            this._txtPotenciaNominalTrifasica.Value = 0F;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 16);
            this.label9.TabIndex = 6;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Potencia nominal trifásica de reactivo (MVAr):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 16);
            this.label4.TabIndex = 2;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tipo de banco de capacitor:";
            // 
            // _cmbTipoCapacitor
            // 
            this._cmbTipoCapacitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoCapacitor.EnterComoTab = false;
            this._cmbTipoCapacitor.Etiqueta = null;
            this._cmbTipoCapacitor.FormattingEnabled = true;
            this._cmbTipoCapacitor.Items.AddRange(new object[] {
            "Capacitor en paralelo",
            "Capacitor en serie"});
            this._cmbTipoCapacitor.Location = new System.Drawing.Point(385, 45);
            this._cmbTipoCapacitor.Name = "_cmbTipoCapacitor";
            this._cmbTipoCapacitor.Size = new System.Drawing.Size(198, 21);
            this._cmbTipoCapacitor.TabIndex = 3;
            this._cmbTipoCapacitor.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            this._cmbTipoCapacitor.SelectedIndexChanged += new System.EventHandler(this._cmbTipoCapacitor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 4;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Tensión nominal (kV):";
            // 
            // _txtXcReactanciaCapcitiva
            // 
            this._txtXcReactanciaCapcitiva.AceptaNegativo = false;
            this._txtXcReactanciaCapcitiva.BackColor = System.Drawing.Color.White;
            this._txtXcReactanciaCapcitiva.EnterComoTab = true;
            this._txtXcReactanciaCapcitiva.Etiqueta = null;
            this._txtXcReactanciaCapcitiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtXcReactanciaCapcitiva.Location = new System.Drawing.Point(385, 114);
            this._txtXcReactanciaCapcitiva.MaxDigitosDecimales = 0;
            this._txtXcReactanciaCapcitiva.MaxDigitosEnteros = 0;
            this._txtXcReactanciaCapcitiva.MaxLength = 30;
            this._txtXcReactanciaCapcitiva.Name = "_txtXcReactanciaCapcitiva";
            this._txtXcReactanciaCapcitiva.Size = new System.Drawing.Size(113, 22);
            this._txtXcReactanciaCapcitiva.TabIndex = 9;
            this._txtXcReactanciaCapcitiva.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.XC_REACTANCIA_CAPACITIVA";
            this._txtXcReactanciaCapcitiva.Text = "0";
            this._txtXcReactanciaCapcitiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtXcReactanciaCapcitiva.UsarFormatoNumerico = true;
            this._txtXcReactanciaCapcitiva.ValDouble = 0D;
            this._txtXcReactanciaCapcitiva.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtXcReactanciaCapcitiva.ValorDouble = 0D;
            this._txtXcReactanciaCapcitiva.ValorFloat = 0F;
            this._txtXcReactanciaCapcitiva.ValorInt = 0;
            this._txtXcReactanciaCapcitiva.ValorLong = ((long)(0));
            this._txtXcReactanciaCapcitiva.Value = 0F;
            this._txtXcReactanciaCapcitiva.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtXcReactanciaCapcitiva_KeyDown);
            this._txtXcReactanciaCapcitiva.Validating += new System.ComponentModel.CancelEventHandler(this._txtXcReactanciaCapcitiva_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 16);
            this.label2.TabIndex = 8;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Xc Reactancia capacitiva (ohm):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(244, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 12;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Nodo de conexión:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(385, 160);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(402, 78);
            this._txtObservaciones.TabIndex = 16;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.OBSERVACIONES";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(265, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 16);
            this.label14.TabIndex = 15;
            this.label14.TablaCampoBD = null;
            this.label14.Text = "Observaciones:";
            // 
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this.cndcLabel7);
            this._gbxDatosProyectos.Controls.Add(this._txtX1);
            this._gbxDatosProyectos.Controls.Add(this.label15);
            this._gbxDatosProyectos.Controls.Add(this._txtNodoDestino);
            this._gbxDatosProyectos.Controls.Add(this._txtNodoOrigen);
            this._gbxDatosProyectos.Controls.Add(this.cndcLabel2);
            this._gbxDatosProyectos.Controls.Add(this._txtSubestacionOrigen);
            this._gbxDatosProyectos.Controls.Add(this.label14);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this.label6);
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this._txtXcReactanciaCapcitiva);
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this._cmbTipoCapacitor);
            this._gbxDatosProyectos.Controls.Add(this.label4);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this._txtPotenciaNominalTrifasica);
            this._gbxDatosProyectos.Controls.Add(this._txTensionNominal);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(0, 19);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(971, 249);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel7.Location = new System.Drawing.Point(590, 96);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(99, 15);
            this.cndcLabel7.TabIndex = 39;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Base 100 MVA";
            // 
            // _txtX1
            // 
            this._txtX1.AceptaNegativo = true;
            this._txtX1.BackColor = System.Drawing.Color.Gainsboro;
            this._txtX1.EnterComoTab = true;
            this._txtX1.Etiqueta = null;
            this._txtX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtX1.Location = new System.Drawing.Point(585, 115);
            this._txtX1.MaxDigitosDecimales = 0;
            this._txtX1.MaxDigitosEnteros = 0;
            this._txtX1.Name = "_txtX1";
            this._txtX1.ReadOnly = true;
            this._txtX1.Size = new System.Drawing.Size(109, 22);
            this._txtX1.TabIndex = 38;
            this._txtX1.TablaCampoBD = null;
            this._txtX1.Text = "0";
            this._txtX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtX1.UsarFormatoNumerico = true;
            this._txtX1.ValDouble = 0D;
            this._txtX1.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtX1.ValorDouble = 0D;
            this._txtX1.ValorFloat = 0F;
            this._txtX1.ValorInt = 0;
            this._txtX1.ValorLong = ((long)(0));
            this._txtX1.Value = 0F;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(526, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 37;
            this.label15.TablaCampoBD = null;
            this.label15.Text = "X1 (%):";
            // 
            // _txtNodoDestino
            // 
            this._txtNodoDestino.BackColor = System.Drawing.Color.White;
            this._txtNodoDestino.EnterComoTab = true;
            this._txtNodoDestino.Etiqueta = null;
            this._txtNodoDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNodoDestino.Location = new System.Drawing.Point(585, 137);
            this._txtNodoDestino.MaxLength = 2000;
            this._txtNodoDestino.Name = "_txtNodoDestino";
            this._txtNodoDestino.Size = new System.Drawing.Size(201, 22);
            this._txtNodoDestino.TabIndex = 14;
            this._txtNodoDestino.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.NODO_CONEXION_DESTINO";
            // 
            // _txtNodoOrigen
            // 
            this._txtNodoOrigen.BackColor = System.Drawing.Color.White;
            this._txtNodoOrigen.EnterComoTab = true;
            this._txtNodoOrigen.Etiqueta = null;
            this._txtNodoOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNodoOrigen.Location = new System.Drawing.Point(385, 137);
            this._txtNodoOrigen.MaxLength = 2000;
            this._txtNodoOrigen.Name = "_txtNodoOrigen";
            this._txtNodoOrigen.Size = new System.Drawing.Size(198, 22);
            this._txtNodoOrigen.TabIndex = 13;
            this._txtNodoOrigen.TablaCampoBD = "F_PR_DATO_TEC_CAPACITOR.NODO_CONEXION_ORIGEN";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(284, 26);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(98, 16);
            this.cndcLabel2.TabIndex = 0;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Subestación:";
            // 
            // _txtSubestacionOrigen
            // 
            this._txtSubestacionOrigen.BackColor = System.Drawing.Color.Gainsboro;
            this._txtSubestacionOrigen.Enabled = false;
            this._txtSubestacionOrigen.EnterComoTab = true;
            this._txtSubestacionOrigen.Etiqueta = null;
            this._txtSubestacionOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSubestacionOrigen.Location = new System.Drawing.Point(385, 23);
            this._txtSubestacionOrigen.Name = "_txtSubestacionOrigen";
            this._txtSubestacionOrigen.ReadOnly = true;
            this._txtSubestacionOrigen.Size = new System.Drawing.Size(267, 22);
            this._txtSubestacionOrigen.TabIndex = 1;
            this._txtSubestacionOrigen.TablaCampoBD = null;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(2, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(200, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::Proyectos.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(66, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(55, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::Proyectos.Properties.Resources.Delete;
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
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(862, 2);
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
            this.cndcLabel1.Location = new System.Drawing.Point(736, 3);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosTecnicosDeProysCapacitores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatosTecnicosDeProysCapacitores";
            this.Size = new System.Drawing.Size(972, 276);
            this._gbxDatosProyectos.ResumeLayout(false);
            this._gbxDatosProyectos.PerformLayout();
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
        private Controles.CNDCTextBoxFloat _txTensionNominal;
        private Controles.CNDCTextBoxFloat _txtPotenciaNominalTrifasica;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label4;
        private Controles.CNDCComboBox _cmbTipoCapacitor;
        private Controles.CNDCLabel label1;
        private Controles.CNDCTextBoxFloat _txtXcReactanciaCapcitiva;
        private Controles.CNDCLabel label2;
        private Controles.CNDCLabel label6;
        private Controles.CNDCTextBox _txtObservaciones;
        private Controles.CNDCLabel label14;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtSubestacionOrigen;
        private Controles.CNDCTextBox _txtNodoDestino;
        private Controles.CNDCTextBox _txtNodoOrigen;
        private Controles.CNDCLabel cndcLabel7;
        private Controles.CNDCTextBoxFloat _txtX1;
        private Controles.CNDCLabel label15;

    }
}
