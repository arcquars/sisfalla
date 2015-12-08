namespace Proyectos
{
    partial class CtrlDatosTecnicosDeProyBiomasa
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
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this._dtpFechaHasta = new Controles.CNDCDateTimePicker();
            this._dtpFechaDesde = new Controles.CNDCDateTimePicker();
            this.label10 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this.label7 = new Controles.CNDCLabel();
            this.label2 = new Controles.CNDCLabel();
            this._cmbTecnologia = new Controles.CNDCComboBox();
            this.label1 = new Controles.CNDCLabel();
            this._txtPoderCalorifico = new Controles.CNDCTextBoxFloat();
            this.label5 = new Controles.CNDCLabel();
            this.label6 = new Controles.CNDCLabel();
            this._txtConsumoEspecifico = new Controles.CNDCTextBoxFloat();
            this._txtBiomasaDisponible = new Controles.CNDCTextBoxFloat();
            this.label3 = new Controles.CNDCLabel();
            this.label4 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this._txtNroUnidades = new Controles.CNDCTextBoxInt();
            this.label11 = new Controles.CNDCLabel();
            this._txtPotenciaInstalada = new Controles.CNDCTextBoxFloat();
            this.label8 = new Controles.CNDCLabel();
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
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this._dtpFechaHasta);
            this._gbxDatosProyectos.Controls.Add(this._dtpFechaDesde);
            this._gbxDatosProyectos.Controls.Add(this.label10);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this.label7);
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this._cmbTecnologia);
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this._txtPoderCalorifico);
            this._gbxDatosProyectos.Controls.Add(this.label5);
            this._gbxDatosProyectos.Controls.Add(this.label6);
            this._gbxDatosProyectos.Controls.Add(this._txtConsumoEspecifico);
            this._gbxDatosProyectos.Controls.Add(this._txtBiomasaDisponible);
            this._gbxDatosProyectos.Controls.Add(this.label3);
            this._gbxDatosProyectos.Controls.Add(this.label4);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this._txtNroUnidades);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtPotenciaInstalada);
            this._gbxDatosProyectos.Controls.Add(this.label8);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(2, 22);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(927, 172);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // _dtpFechaHasta
            // 
            this._dtpFechaHasta.CustomFormat = "dd/MMM";
            this._dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaHasta.Location = new System.Drawing.Point(402, 88);
            this._dtpFechaHasta.Name = "_dtpFechaHasta";
            this._dtpFechaHasta.Size = new System.Drawing.Size(67, 22);
            this._dtpFechaHasta.TabIndex = 9;
            this._dtpFechaHasta.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.PERIODO_OPERACION_MES_A";
            // 
            // _dtpFechaDesde
            // 
            this._dtpFechaDesde.CustomFormat = "dd/MMM";
            this._dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaDesde.Location = new System.Drawing.Point(288, 87);
            this._dtpFechaDesde.Name = "_dtpFechaDesde";
            this._dtpFechaDesde.Size = new System.Drawing.Size(67, 22);
            this._dtpFechaDesde.TabIndex = 7;
            this._dtpFechaDesde.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.PERIODO_OPERACION_MES_DE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(169, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 10;
            this.label10.TablaCampoBD = null;
            this.label10.Text = "Observaciones:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(288, 110);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(583, 52);
            this._txtObservaciones.TabIndex = 11;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(378, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 16);
            this.label7.TabIndex = 8;
            this.label7.TablaCampoBD = null;
            this.label7.Text = "a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 16);
            this.label2.TabIndex = 12;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Biomasa disponible (Ton/año):";
            // 
            // _cmbTecnologia
            // 
            this._cmbTecnologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTecnologia.EnterComoTab = false;
            this._cmbTecnologia.Etiqueta = null;
            this._cmbTecnologia.FormattingEnabled = true;
            this._cmbTecnologia.Items.AddRange(new object[] {
            "Contrapresión",
            "Condensación"});
            this._cmbTecnologia.Location = new System.Drawing.Point(288, 65);
            this._cmbTecnologia.Name = "_cmbTecnologia";
            this._cmbTecnologia.Size = new System.Drawing.Size(198, 21);
            this._cmbTecnologia.TabIndex = 5;
            this._cmbTecnologia.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 16);
            this.label1.TabIndex = 16;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Poder calorífico (MMBTU/Ton):";
            // 
            // _txtPoderCalorifico
            // 
            this._txtPoderCalorifico.AceptaNegativo = false;
            this._txtPoderCalorifico.BackColor = System.Drawing.Color.White;
            this._txtPoderCalorifico.EnterComoTab = true;
            this._txtPoderCalorifico.Etiqueta = null;
            this._txtPoderCalorifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPoderCalorifico.Location = new System.Drawing.Point(749, 65);
            this._txtPoderCalorifico.MaxDigitosDecimales = 0;
            this._txtPoderCalorifico.MaxDigitosEnteros = 0;
            this._txtPoderCalorifico.MaxLength = 30;
            this._txtPoderCalorifico.Name = "_txtPoderCalorifico";
            this._txtPoderCalorifico.Size = new System.Drawing.Size(100, 22);
            this._txtPoderCalorifico.TabIndex = 17;
            this._txtPoderCalorifico.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.PORDER_CALORIFICO";
            this._txtPoderCalorifico.Text = "0";
            this._txtPoderCalorifico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPoderCalorifico.UsarFormatoNumerico = true;
            this._txtPoderCalorifico.ValDouble = 0D;
            this._txtPoderCalorifico.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtPoderCalorifico.ValorDouble = 0D;
            this._txtPoderCalorifico.ValorFloat = 0F;
            this._txtPoderCalorifico.ValorInt = 0;
            this._txtPoderCalorifico.ValorLong = ((long)(0));
            this._txtPoderCalorifico.Value = 0F;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 16);
            this.label5.TabIndex = 6;
            this.label5.TablaCampoBD = null;
            this.label5.Text = "Periodo de operación (dd/mm) de:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 16);
            this.label6.TabIndex = 14;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Consumo específico (Ton/kWh):";
            // 
            // _txtConsumoEspecifico
            // 
            this._txtConsumoEspecifico.AceptaNegativo = false;
            this._txtConsumoEspecifico.BackColor = System.Drawing.Color.White;
            this._txtConsumoEspecifico.EnterComoTab = true;
            this._txtConsumoEspecifico.Etiqueta = null;
            this._txtConsumoEspecifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtConsumoEspecifico.Location = new System.Drawing.Point(749, 42);
            this._txtConsumoEspecifico.MaxDigitosDecimales = 0;
            this._txtConsumoEspecifico.MaxDigitosEnteros = 0;
            this._txtConsumoEspecifico.MaxLength = 30;
            this._txtConsumoEspecifico.Name = "_txtConsumoEspecifico";
            this._txtConsumoEspecifico.Size = new System.Drawing.Size(100, 22);
            this._txtConsumoEspecifico.TabIndex = 15;
            this._txtConsumoEspecifico.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.CONSUMO_ESPECIFICO";
            this._txtConsumoEspecifico.Text = "0";
            this._txtConsumoEspecifico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtConsumoEspecifico.UsarFormatoNumerico = true;
            this._txtConsumoEspecifico.ValDouble = 0D;
            this._txtConsumoEspecifico.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtConsumoEspecifico.ValorDouble = 0D;
            this._txtConsumoEspecifico.ValorFloat = 0F;
            this._txtConsumoEspecifico.ValorInt = 0;
            this._txtConsumoEspecifico.ValorLong = ((long)(0));
            this._txtConsumoEspecifico.Value = 0F;
            // 
            // _txtBiomasaDisponible
            // 
            this._txtBiomasaDisponible.AceptaNegativo = false;
            this._txtBiomasaDisponible.BackColor = System.Drawing.Color.White;
            this._txtBiomasaDisponible.EnterComoTab = true;
            this._txtBiomasaDisponible.Etiqueta = null;
            this._txtBiomasaDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBiomasaDisponible.Location = new System.Drawing.Point(749, 19);
            this._txtBiomasaDisponible.MaxDigitosDecimales = 0;
            this._txtBiomasaDisponible.MaxDigitosEnteros = 0;
            this._txtBiomasaDisponible.MaxLength = 30;
            this._txtBiomasaDisponible.Name = "_txtBiomasaDisponible";
            this._txtBiomasaDisponible.Size = new System.Drawing.Size(100, 22);
            this._txtBiomasaDisponible.TabIndex = 13;
            this._txtBiomasaDisponible.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.BIOMADA_DISPONIBLE";
            this._txtBiomasaDisponible.Text = "0";
            this._txtBiomasaDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtBiomasaDisponible.UsarFormatoNumerico = true;
            this._txtBiomasaDisponible.ValDouble = 0D;
            this._txtBiomasaDisponible.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtBiomasaDisponible.ValorDouble = 0D;
            this._txtBiomasaDisponible.ValorFloat = 0F;
            this._txtBiomasaDisponible.ValorInt = 0;
            this._txtBiomasaDisponible.ValorLong = ((long)(0));
            this._txtBiomasaDisponible.Value = 0F;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 32);
            this.label3.TabIndex = 157;
            this.label3.TablaCampoBD = null;
            this.label3.Tag = "Generación media anual (GWh):";
            this.label3.Text = "\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 67);
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
            this.label9.Location = new System.Drawing.Point(155, 45);
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
            this._txtNroUnidades.Location = new System.Drawing.Point(288, 42);
            this._txtNroUnidades.MaxDigitosDecimales = 0;
            this._txtNroUnidades.MaxDigitosEnteros = 0;
            this._txtNroUnidades.MaxLength = 30;
            this._txtNroUnidades.Name = "_txtNroUnidades";
            this._txtNroUnidades.Size = new System.Drawing.Size(98, 22);
            this._txtNroUnidades.TabIndex = 3;
            this._txtNroUnidades.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.NRO_UNIDADES";
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
            this.label11.Location = new System.Drawing.Point(105, 22);
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
            this._txtPotenciaInstalada.Location = new System.Drawing.Point(288, 19);
            this._txtPotenciaInstalada.MaxDigitosDecimales = 0;
            this._txtPotenciaInstalada.MaxDigitosEnteros = 0;
            this._txtPotenciaInstalada.MaxLength = 30;
            this._txtPotenciaInstalada.Name = "_txtPotenciaInstalada";
            this._txtPotenciaInstalada.Size = new System.Drawing.Size(98, 22);
            this._txtPotenciaInstalada.TabIndex = 1;
            this._txtPotenciaInstalada.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.POTENCIA_INSTALADA";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 148;
            this.label8.TablaCampoBD = null;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(2, 2);
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
            this._dtpFechaRegistro.Location = new System.Drawing.Point(820, 4);
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
            this.cndcLabel1.Location = new System.Drawing.Point(694, 5);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosTecnicosDeProyBiomasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatosTecnicosDeProyBiomasa";
            this.Size = new System.Drawing.Size(931, 202);
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
        private System.Windows.Forms.TextBox textBox1;
        private Controles.CNDCTextBox _txtObservaciones;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCLabel label2;
        private Controles.CNDCComboBox _cmbTecnologia;
        private Controles.CNDCLabel label1;
        private Controles.CNDCLabel label5;
        private Controles.CNDCLabel label6;
        private Controles.CNDCLabel label3;
        private Controles.CNDCLabel label4;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label11;
        private Controles.CNDCLabel label8;
        private Controles.CNDCLabel label7;
        private Controles.CNDCLabel label10;
        protected Controles.CNDCDateTimePicker _dtpFechaHasta;
        protected Controles.CNDCDateTimePicker _dtpFechaDesde;
        private Controles.CNDCTextBoxFloat _txtPoderCalorifico;
        private Controles.CNDCTextBoxFloat _txtConsumoEspecifico;
        private Controles.CNDCTextBoxFloat _txtBiomasaDisponible;
        private Controles.CNDCTextBoxInt _txtNroUnidades;
        private Controles.CNDCTextBoxFloat _txtPotenciaInstalada;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
    }
}
