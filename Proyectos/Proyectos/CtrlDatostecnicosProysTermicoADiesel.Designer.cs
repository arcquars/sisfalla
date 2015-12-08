namespace Proyectos
{
    partial class CtrlDatostecnicosProysTermicoADiesel
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
            this.label14 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this.label1 = new Controles.CNDCLabel();
            this._txtModelo = new Controles.CNDCTextBox();
            this.label9 = new Controles.CNDCLabel();
            this.label11 = new Controles.CNDCLabel();
            this._txtCapacidadInstalada = new Controles.CNDCTextBoxFloat();
            this._txtHR50 = new Controles.CNDCTextBoxInt();
            this.label19 = new Controles.CNDCLabel();
            this._txtHR75 = new Controles.CNDCTextBoxInt();
            this.label18 = new Controles.CNDCLabel();
            this._txtHR100 = new Controles.CNDCTextBoxInt();
            this.label17 = new Controles.CNDCLabel();
            this.label16 = new Controles.CNDCLabel();
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
            this._gbxDatosProyectos.Controls.Add(this.label14);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this._txtModelo);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtCapacidadInstalada);
            this._gbxDatosProyectos.Controls.Add(this._txtHR50);
            this._gbxDatosProyectos.Controls.Add(this.label19);
            this._gbxDatosProyectos.Controls.Add(this._txtHR75);
            this._gbxDatosProyectos.Controls.Add(this.label18);
            this._gbxDatosProyectos.Controls.Add(this._txtHR100);
            this._gbxDatosProyectos.Controls.Add(this.label17);
            this._gbxDatosProyectos.Controls.Add(this.label16);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(1, 21);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(846, 236);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(174, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 16);
            this.label14.TabIndex = 12;
            this.label14.TablaCampoBD = null;
            this.label14.Text = "Observaciones:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(297, 167);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(525, 59);
            this._txtObservaciones.TabIndex = 13;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.OBSERVACIONES";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 34);
            this.label1.TabIndex = 4;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Porcentaje carga (%)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtModelo
            // 
            this._txtModelo.BackColor = System.Drawing.Color.White;
            this._txtModelo.EnterComoTab = true;
            this._txtModelo.Etiqueta = null;
            this._txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtModelo.Location = new System.Drawing.Point(297, 19);
            this._txtModelo.MaxLength = 500;
            this._txtModelo.Name = "_txtModelo";
            this._txtModelo.Size = new System.Drawing.Size(525, 22);
            this._txtModelo.TabIndex = 1;
            this._txtModelo.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.MODELO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(98, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 16);
            this.label9.TabIndex = 2;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Capacidad instalada (MW):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 0;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Modelo:";
            // 
            // _txtCapacidadInstalada
            // 
            this._txtCapacidadInstalada.AceptaNegativo = false;
            this._txtCapacidadInstalada.BackColor = System.Drawing.Color.White;
            this._txtCapacidadInstalada.EnterComoTab = true;
            this._txtCapacidadInstalada.Etiqueta = null;
            this._txtCapacidadInstalada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCapacidadInstalada.Location = new System.Drawing.Point(297, 42);
            this._txtCapacidadInstalada.MaxDigitosDecimales = 0;
            this._txtCapacidadInstalada.MaxDigitosEnteros = 0;
            this._txtCapacidadInstalada.MaxLength = 30;
            this._txtCapacidadInstalada.Name = "_txtCapacidadInstalada";
            this._txtCapacidadInstalada.Size = new System.Drawing.Size(131, 22);
            this._txtCapacidadInstalada.TabIndex = 3;
            this._txtCapacidadInstalada.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.CAPACIDAD_INSTALADA";
            this._txtCapacidadInstalada.Text = "0";
            this._txtCapacidadInstalada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtCapacidadInstalada.UsarFormatoNumerico = true;
            this._txtCapacidadInstalada.ValDouble = 0D;
            this._txtCapacidadInstalada.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtCapacidadInstalada.ValorDouble = 0D;
            this._txtCapacidadInstalada.ValorFloat = 0F;
            this._txtCapacidadInstalada.ValorInt = 0;
            this._txtCapacidadInstalada.ValorLong = ((long)(0));
            this._txtCapacidadInstalada.Value = 0F;
            // 
            // _txtHR50
            // 
            this._txtHR50.AceptaNegativo = false;
            this._txtHR50.BackColor = System.Drawing.Color.White;
            this._txtHR50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHR50.EnterComoTab = true;
            this._txtHR50.Etiqueta = null;
            this._txtHR50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHR50.Location = new System.Drawing.Point(427, 142);
            this._txtHR50.MaxDigitosDecimales = 0;
            this._txtHR50.MaxDigitosEnteros = 0;
            this._txtHR50.MaxLength = 30;
            this._txtHR50.Name = "_txtHR50";
            this._txtHR50.Size = new System.Drawing.Size(119, 22);
            this._txtHR50.TabIndex = 11;
            this._txtHR50.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.HEAT_RATE50";
            this._txtHR50.Text = "0";
            this._txtHR50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHR50.UsarFormatoNumerico = true;
            this._txtHR50.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHR50.ValorDouble = 0D;
            this._txtHR50.ValorFloat = 0F;
            this._txtHR50.ValorInt = 0;
            this._txtHR50.ValorLong = ((long)(0));
            this._txtHR50.Value = 0;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(297, 142);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(131, 22);
            this.label19.TabIndex = 10;
            this.label19.TablaCampoBD = null;
            this.label19.Text = "50%";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtHR75
            // 
            this._txtHR75.AceptaNegativo = false;
            this._txtHR75.BackColor = System.Drawing.Color.White;
            this._txtHR75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHR75.EnterComoTab = true;
            this._txtHR75.Etiqueta = null;
            this._txtHR75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHR75.Location = new System.Drawing.Point(427, 121);
            this._txtHR75.MaxDigitosDecimales = 0;
            this._txtHR75.MaxDigitosEnteros = 0;
            this._txtHR75.MaxLength = 30;
            this._txtHR75.Name = "_txtHR75";
            this._txtHR75.Size = new System.Drawing.Size(119, 22);
            this._txtHR75.TabIndex = 9;
            this._txtHR75.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.HEAT_RATE75";
            this._txtHR75.Text = "0";
            this._txtHR75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHR75.UsarFormatoNumerico = true;
            this._txtHR75.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHR75.ValorDouble = 0D;
            this._txtHR75.ValorFloat = 0F;
            this._txtHR75.ValorInt = 0;
            this._txtHR75.ValorLong = ((long)(0));
            this._txtHR75.Value = 0;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(297, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 22);
            this.label18.TabIndex = 8;
            this.label18.TablaCampoBD = null;
            this.label18.Text = "75%";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtHR100
            // 
            this._txtHR100.AceptaNegativo = false;
            this._txtHR100.BackColor = System.Drawing.Color.White;
            this._txtHR100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHR100.EnterComoTab = true;
            this._txtHR100.Etiqueta = null;
            this._txtHR100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHR100.Location = new System.Drawing.Point(427, 100);
            this._txtHR100.MaxDigitosDecimales = 0;
            this._txtHR100.MaxDigitosEnteros = 0;
            this._txtHR100.MaxLength = 30;
            this._txtHR100.Name = "_txtHR100";
            this._txtHR100.Size = new System.Drawing.Size(119, 22);
            this._txtHR100.TabIndex = 7;
            this._txtHR100.TablaCampoBD = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL.HEAT_RATE100";
            this._txtHR100.Text = "0";
            this._txtHR100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHR100.UsarFormatoNumerico = true;
            this._txtHR100.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHR100.ValorDouble = 0D;
            this._txtHR100.ValorFloat = 0F;
            this._txtHR100.ValorInt = 0;
            this._txtHR100.ValorLong = ((long)(0));
            this._txtHR100.Value = 0;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(297, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 22);
            this.label17.TabIndex = 6;
            this.label17.TablaCampoBD = null;
            this.label17.Text = "100%";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(427, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 34);
            this.label16.TabIndex = 5;
            this.label16.TablaCampoBD = null;
            this.label16.Text = "HEAT RATE (BTU/kWh)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(3, 0);
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
            this._dtpFechaRegistro.Location = new System.Drawing.Point(735, 3);
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
            this.cndcLabel1.Location = new System.Drawing.Point(609, 4);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatostecnicosProysTermicoADiesel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatostecnicosProysTermicoADiesel";
            this.Size = new System.Drawing.Size(847, 260);
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
        private Controles.CNDCTextBoxFloat _txtCapacidadInstalada;
        private Controles.CNDCTextBoxInt _txtHR50;
        private Controles.CNDCLabel label19;
        private Controles.CNDCTextBoxInt _txtHR75;
        private Controles.CNDCLabel label18;
        private Controles.CNDCTextBoxInt _txtHR100;
        private Controles.CNDCLabel label17;
        private Controles.CNDCLabel label16;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBox _txtModelo;
        private Controles.CNDCLabel label1;
        private Controles.CNDCLabel label14;
        private Controles.CNDCTextBox _txtObservaciones;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;

    }
}
