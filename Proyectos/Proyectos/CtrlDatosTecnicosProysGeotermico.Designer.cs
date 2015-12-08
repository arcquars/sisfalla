namespace Proyectos
{
    partial class CtrlDatosTecnicosProysGeotermico
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
            this.label1 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this._txtPoderCalorifico = new Controles.CNDCTextBoxFloat();
            this._txtProductividad = new Controles.CNDCTextBoxFloat();
            this.label2 = new Controles.CNDCLabel();
            this._cmbTecnologia = new Controles.CNDCComboBox();
            this.label6 = new Controles.CNDCLabel();
            this.label7 = new Controles.CNDCLabel();
            this._txtGeneracionMediaAnual = new Controles.CNDCTextBoxFloat();
            this.label4 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this._txtNroUnidades = new Controles.CNDCTextBoxInt();
            this.label11 = new Controles.CNDCLabel();
            this._txtPotenciaInstalada = new Controles.CNDCTextBoxFloat();
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
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this._txtPoderCalorifico);
            this._gbxDatosProyectos.Controls.Add(this._txtProductividad);
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this._cmbTecnologia);
            this._gbxDatosProyectos.Controls.Add(this.label6);
            this._gbxDatosProyectos.Controls.Add(this.label7);
            this._gbxDatosProyectos.Controls.Add(this._txtGeneracionMediaAnual);
            this._gbxDatosProyectos.Controls.Add(this.label4);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this._txtNroUnidades);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtPotenciaInstalada);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(3, 21);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(826, 219);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 12;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Observaciones:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(397, 146);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(399, 60);
            this._txtObservaciones.TabIndex = 13;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.OBSERVACIONES";
            // 
            // _txtPoderCalorifico
            // 
            this._txtPoderCalorifico.AceptaNegativo = false;
            this._txtPoderCalorifico.BackColor = System.Drawing.Color.White;
            this._txtPoderCalorifico.EnterComoTab = true;
            this._txtPoderCalorifico.Etiqueta = null;
            this._txtPoderCalorifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPoderCalorifico.Location = new System.Drawing.Point(397, 102);
            this._txtPoderCalorifico.MaxDigitosDecimales = 0;
            this._txtPoderCalorifico.MaxDigitosEnteros = 0;
            this._txtPoderCalorifico.MaxLength = 30;
            this._txtPoderCalorifico.Name = "_txtPoderCalorifico";
            this._txtPoderCalorifico.Size = new System.Drawing.Size(101, 22);
            this._txtPoderCalorifico.TabIndex = 9;
            this._txtPoderCalorifico.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.PODER_CALORIFICO";
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
            // _txtProductividad
            // 
            this._txtProductividad.AceptaNegativo = false;
            this._txtProductividad.BackColor = System.Drawing.Color.White;
            this._txtProductividad.EnterComoTab = true;
            this._txtProductividad.Etiqueta = null;
            this._txtProductividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtProductividad.Location = new System.Drawing.Point(397, 124);
            this._txtProductividad.MaxDigitosDecimales = 0;
            this._txtProductividad.MaxDigitosEnteros = 0;
            this._txtProductividad.MaxLength = 30;
            this._txtProductividad.Name = "_txtProductividad";
            this._txtProductividad.Size = new System.Drawing.Size(101, 22);
            this._txtProductividad.TabIndex = 11;
            this._txtProductividad.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.PRODUCTIVIDAD";
            this._txtProductividad.Text = "0";
            this._txtProductividad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtProductividad.UsarFormatoNumerico = true;
            this._txtProductividad.ValDouble = 0D;
            this._txtProductividad.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtProductividad.ValorDouble = 0D;
            this._txtProductividad.ValorFloat = 0F;
            this._txtProductividad.ValorInt = 0;
            this._txtProductividad.ValorLong = ((long)(0));
            this._txtProductividad.Value = 0F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 16);
            this.label2.TabIndex = 8;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Poder calorífico (MMBTU/Ton):";
            // 
            // _cmbTecnologia
            // 
            this._cmbTecnologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTecnologia.EnterComoTab = false;
            this._cmbTecnologia.Etiqueta = null;
            this._cmbTecnologia.FormattingEnabled = true;
            this._cmbTecnologia.Items.AddRange(new object[] {
            "Vapor seco",
            "Vapor flash",
            "Ciclos binarios"});
            this._cmbTecnologia.Location = new System.Drawing.Point(397, 58);
            this._cmbTecnologia.Name = "_cmbTecnologia";
            this._cmbTecnologia.Size = new System.Drawing.Size(233, 21);
            this._cmbTecnologia.TabIndex = 5;
            this._cmbTecnologia.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 16);
            this.label6.TabIndex = 10;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Productividad (MW/MMBTU):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(167, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 16);
            this.label7.TabIndex = 6;
            this.label7.TablaCampoBD = null;
            this.label7.Text = "Generación media anual (GWh):";
            // 
            // _txtGeneracionMediaAnual
            // 
            this._txtGeneracionMediaAnual.AceptaNegativo = false;
            this._txtGeneracionMediaAnual.BackColor = System.Drawing.Color.White;
            this._txtGeneracionMediaAnual.EnterComoTab = true;
            this._txtGeneracionMediaAnual.Etiqueta = null;
            this._txtGeneracionMediaAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtGeneracionMediaAnual.Location = new System.Drawing.Point(397, 80);
            this._txtGeneracionMediaAnual.MaxDigitosDecimales = 0;
            this._txtGeneracionMediaAnual.MaxDigitosEnteros = 0;
            this._txtGeneracionMediaAnual.MaxLength = 30;
            this._txtGeneracionMediaAnual.Name = "_txtGeneracionMediaAnual";
            this._txtGeneracionMediaAnual.Size = new System.Drawing.Size(101, 22);
            this._txtGeneracionMediaAnual.TabIndex = 7;
            this._txtGeneracionMediaAnual.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.GENERACION_MEDIA_ANUAL";
            this._txtGeneracionMediaAnual.Text = "0";
            this._txtGeneracionMediaAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtGeneracionMediaAnual.UsarFormatoNumerico = true;
            this._txtGeneracionMediaAnual.ValDouble = 0D;
            this._txtGeneracionMediaAnual.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtGeneracionMediaAnual.ValorDouble = 0D;
            this._txtGeneracionMediaAnual.ValorFloat = 0F;
            this._txtGeneracionMediaAnual.ValorInt = 0;
            this._txtGeneracionMediaAnual.ValorLong = ((long)(0));
            this._txtGeneracionMediaAnual.Value = 0F;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 61);
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
            this.label9.Location = new System.Drawing.Point(264, 38);
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
            this._txtNroUnidades.Location = new System.Drawing.Point(397, 35);
            this._txtNroUnidades.MaxDigitosDecimales = 0;
            this._txtNroUnidades.MaxDigitosEnteros = 0;
            this._txtNroUnidades.MaxLength = 30;
            this._txtNroUnidades.Name = "_txtNroUnidades";
            this._txtNroUnidades.Size = new System.Drawing.Size(101, 22);
            this._txtNroUnidades.TabIndex = 3;
            this._txtNroUnidades.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.NRO_UNIDADES";
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
            this.label11.Location = new System.Drawing.Point(214, 16);
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
            this._txtPotenciaInstalada.Location = new System.Drawing.Point(397, 13);
            this._txtPotenciaInstalada.MaxDigitosDecimales = 0;
            this._txtPotenciaInstalada.MaxDigitosEnteros = 0;
            this._txtPotenciaInstalada.MaxLength = 30;
            this._txtPotenciaInstalada.Name = "_txtPotenciaInstalada";
            this._txtPotenciaInstalada.Size = new System.Drawing.Size(101, 22);
            this._txtPotenciaInstalada.TabIndex = 1;
            this._txtPotenciaInstalada.TablaCampoBD = "F_PR_DATO_TEC_GEOTERMICO.POTENCIA_INSTALADA";
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
            this._dtpFechaRegistro.Location = new System.Drawing.Point(720, 3);
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
            this.cndcLabel1.Location = new System.Drawing.Point(594, 4);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosTecnicosProysGeotermico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatosTecnicosProysGeotermico";
            this.Size = new System.Drawing.Size(832, 248);
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
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCTextBoxFloat _txtPoderCalorifico;
        private Controles.CNDCTextBoxFloat _txtProductividad;
        private Controles.CNDCLabel label2;
        private Controles.CNDCComboBox _cmbTecnologia;
        private Controles.CNDCLabel label6;
        private Controles.CNDCLabel label7;
        private Controles.CNDCTextBoxFloat _txtGeneracionMediaAnual;
        private Controles.CNDCLabel label4;
        private Controles.CNDCLabel label9;
        private Controles.CNDCTextBoxInt _txtNroUnidades;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBoxFloat _txtPotenciaInstalada;
        private Controles.CNDCLabel label1;
        private Controles.CNDCTextBox _txtObservaciones;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
    }
}
