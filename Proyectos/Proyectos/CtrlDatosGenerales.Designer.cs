namespace Proyectos
{
    partial class CtrlDatosGenerales
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._toolStrip = new Controles.CNDCToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._numPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._rbtnReducida = new Controles.CNDCRadioButton();
            this._rbtnReal = new Controles.CNDCRadioButton();
            this._btnAddEntidadResponsable = new Controles.CNDCButton();
            this._cmbEtapa = new Controles.CNDCComboBox();
            this._pnlEsquema = new System.Windows.Forms.Panel();
            this._pbxEsquema = new Controles.CNDCPictureBox();
            this._cmbEntidadeResponsable = new Controles.CNDCComboBox();
            this._btnEsquema = new Controles.CNDCButton();
            this._txtEsquema = new Controles.CNDCTextBox();
            this.label14 = new Controles.CNDCLabel();
            this.label13 = new Controles.CNDCLabel();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.label2 = new Controles.CNDCLabel();
            this.label1 = new Controles.CNDCLabel();
            this.label11 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this._pnlLocalizacion = new System.Windows.Forms.Panel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this._gbxDatosProyectos.SuspendLayout();
            this.cndcGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numPorcentaje)).BeginInit();
            this._pnlEsquema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbxEsquema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.jpeg|*.jpeg|*.jpe|*.jpe|*.png|*.png|*.bmp|*.bmp|*.gif|*.gif|*.pict|" +
                "*.pict";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._dtpFechaRegistro);
            this.groupBox1.Controls.Add(this.cndcLabel1);
            this.groupBox1.Controls.Add(this._toolStrip);
            this.groupBox1.Controls.Add(this._gbxDatosProyectos);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 519);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(781, 18);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(118, 22);
            this._dtpFechaRegistro.TabIndex = 0;
            this._dtpFechaRegistro.TablaCampoBD = "F_PR_PROYECTO_MAESTRO.FECHA_REGISTRO";
            this._dtpFechaRegistro.ValueChanged += new System.EventHandler(this._dtpFechaRegistro_ValueChanged);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cndcLabel1.Location = new System.Drawing.Point(655, 19);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 3;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(3, 17);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(200, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.TablaCampoBD = null;
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
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this.cndcGroupBox1);
            this._gbxDatosProyectos.Controls.Add(this._btnAddEntidadResponsable);
            this._gbxDatosProyectos.Controls.Add(this._cmbEtapa);
            this._gbxDatosProyectos.Controls.Add(this._pnlEsquema);
            this._gbxDatosProyectos.Controls.Add(this._cmbEntidadeResponsable);
            this._gbxDatosProyectos.Controls.Add(this._btnEsquema);
            this._gbxDatosProyectos.Controls.Add(this._txtEsquema);
            this._gbxDatosProyectos.Controls.Add(this.label14);
            this._gbxDatosProyectos.Controls.Add(this.label13);
            this._gbxDatosProyectos.Controls.Add(this._txtDescripcion);
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtNombre);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(2, 37);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(958, 476);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._numPorcentaje);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel2);
            this.cndcGroupBox1.Controls.Add(this._rbtnReducida);
            this.cndcGroupBox1.Controls.Add(this._rbtnReal);
            this.cndcGroupBox1.Location = new System.Drawing.Point(799, 287);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(100, 112);
            this.cndcGroupBox1.TabIndex = 15;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Vista Imagen";
            // 
            // _numPorcentaje
            // 
            this._numPorcentaje.Location = new System.Drawing.Point(23, 56);
            this._numPorcentaje.Name = "_numPorcentaje";
            this._numPorcentaje.Size = new System.Drawing.Size(66, 20);
            this._numPorcentaje.TabIndex = 16;
            this._numPorcentaje.ValueChanged += new System.EventHandler(this._numPorcentaje_ValueChanged);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(23, 40);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(61, 13);
            this.cndcLabel2.TabIndex = 15;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Porcentaje:";
            // 
            // _rbtnReducida
            // 
            this._rbtnReducida.AutoSize = true;
            this._rbtnReducida.Checked = true;
            this._rbtnReducida.Location = new System.Drawing.Point(6, 19);
            this._rbtnReducida.Name = "_rbtnReducida";
            this._rbtnReducida.Size = new System.Drawing.Size(71, 17);
            this._rbtnReducida.TabIndex = 13;
            this._rbtnReducida.TablaCampoBD = null;
            this._rbtnReducida.TabStop = true;
            this._rbtnReducida.Text = "Reducida";
            this._rbtnReducida.UseVisualStyleBackColor = true;
            this._rbtnReducida.Click += new System.EventHandler(this._rbtnReal_Click);
            // 
            // _rbtnReal
            // 
            this._rbtnReal.AutoSize = true;
            this._rbtnReal.Location = new System.Drawing.Point(6, 88);
            this._rbtnReal.Name = "_rbtnReal";
            this._rbtnReal.Size = new System.Drawing.Size(47, 17);
            this._rbtnReal.TabIndex = 14;
            this._rbtnReal.TablaCampoBD = null;
            this._rbtnReal.Text = "Real";
            this._rbtnReal.UseVisualStyleBackColor = true;
            this._rbtnReal.Click += new System.EventHandler(this._rbtnReal_Click);
            // 
            // _btnAddEntidadResponsable
            // 
            this._btnAddEntidadResponsable.Image = global::Proyectos.Properties.Resources.Add;
            this._btnAddEntidadResponsable.Location = new System.Drawing.Point(874, 32);
            this._btnAddEntidadResponsable.Name = "_btnAddEntidadResponsable";
            this._btnAddEntidadResponsable.Size = new System.Drawing.Size(23, 21);
            this._btnAddEntidadResponsable.TabIndex = 12;
            this._btnAddEntidadResponsable.TablaCampoBD = null;
            this._btnAddEntidadResponsable.UseVisualStyleBackColor = true;
            this._btnAddEntidadResponsable.Click += new System.EventHandler(this._btnAddEntidadResponsable_Click);
            // 
            // _cmbEtapa
            // 
            this._cmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEtapa.EnterComoTab = false;
            this._cmbEtapa.Etiqueta = null;
            this._cmbEtapa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEtapa.FormattingEnabled = true;
            this._cmbEtapa.Location = new System.Drawing.Point(122, 31);
            this._cmbEtapa.Name = "_cmbEtapa";
            this._cmbEtapa.Size = new System.Drawing.Size(282, 24);
            this._cmbEtapa.TabIndex = 3;
            this._cmbEtapa.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // _pnlEsquema
            // 
            this._pnlEsquema.AutoScroll = true;
            this._pnlEsquema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlEsquema.Controls.Add(this._pbxEsquema);
            this._pnlEsquema.Location = new System.Drawing.Point(122, 145);
            this._pnlEsquema.Name = "_pnlEsquema";
            this._pnlEsquema.Size = new System.Drawing.Size(671, 325);
            this._pnlEsquema.TabIndex = 11;
            // 
            // _pbxEsquema
            // 
            this._pbxEsquema.Location = new System.Drawing.Point(0, 0);
            this._pbxEsquema.Name = "_pbxEsquema";
            this._pbxEsquema.Size = new System.Drawing.Size(669, 253);
            this._pbxEsquema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._pbxEsquema.TabIndex = 0;
            this._pbxEsquema.TablaCampoBD = null;
            this._pbxEsquema.TabStop = false;
            // 
            // _cmbEntidadeResponsable
            // 
            this._cmbEntidadeResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEntidadeResponsable.EnterComoTab = false;
            this._cmbEntidadeResponsable.Etiqueta = null;
            this._cmbEntidadeResponsable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEntidadeResponsable.FormattingEnabled = true;
            this._cmbEntidadeResponsable.Location = new System.Drawing.Point(564, 31);
            this._cmbEntidadeResponsable.Name = "_cmbEntidadeResponsable";
            this._cmbEntidadeResponsable.Size = new System.Drawing.Size(308, 24);
            this._cmbEntidadeResponsable.TabIndex = 5;
            this._cmbEntidadeResponsable.TablaCampoBD = "F_AP_PERSONA.NOM_PERSONA";
            // 
            // _btnEsquema
            // 
            this._btnEsquema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnEsquema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnEsquema.Location = new System.Drawing.Point(797, 118);
            this._btnEsquema.Name = "_btnEsquema";
            this._btnEsquema.Size = new System.Drawing.Size(75, 22);
            this._btnEsquema.TabIndex = 10;
            this._btnEsquema.TablaCampoBD = null;
            this._btnEsquema.Text = "Examinar";
            this._btnEsquema.UseVisualStyleBackColor = true;
            this._btnEsquema.Click += new System.EventHandler(this._btnEsquema_Click);
            // 
            // _txtEsquema
            // 
            this._txtEsquema.BackColor = System.Drawing.Color.White;
            this._txtEsquema.EnterComoTab = true;
            this._txtEsquema.Etiqueta = null;
            this._txtEsquema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEsquema.Location = new System.Drawing.Point(122, 117);
            this._txtEsquema.Name = "_txtEsquema";
            this._txtEsquema.ReadOnly = true;
            this._txtEsquema.Size = new System.Drawing.Size(671, 22);
            this._txtEsquema.TabIndex = 9;
            this._txtEsquema.TablaCampoBD = "F_PR_PROYECTO.ESQUEMA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(49, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 16);
            this.label14.TabIndex = 8;
            this.label14.TablaCampoBD = null;
            this.label14.Text = "Esquema:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(33, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 16);
            this.label13.TabIndex = 6;
            this.label13.TablaCampoBD = null;
            this.label13.Text = "Descripción:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.BackColor = System.Drawing.Color.White;
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDescripcion.Location = new System.Drawing.Point(122, 56);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDescripcion.Size = new System.Drawing.Size(750, 61);
            this._txtDescripcion.TabIndex = 7;
            this._txtDescripcion.TablaCampoBD = "F_PR_PROYECTO.DESCRIPCION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 4;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Entidad Responsable:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Etapa:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(57, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 0;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nombre:";
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this._txtNombre.EnterComoTab = true;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(122, 8);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.ReadOnly = true;
            this._txtNombre.Size = new System.Drawing.Size(750, 22);
            this._txtNombre.TabIndex = 1;
            this._txtNombre.TablaCampoBD = "F_PR_PROYECTO_MAESTRO.NOMBRE";
            // 
            // _pnlLocalizacion
            // 
            this._pnlLocalizacion.Location = new System.Drawing.Point(2, 528);
            this._pnlLocalizacion.Name = "_pnlLocalizacion";
            this._pnlLocalizacion.Size = new System.Drawing.Size(977, 144);
            this._pnlLocalizacion.TabIndex = 1;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlDatosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._pnlLocalizacion);
            this.Name = "CtrlDatosGenerales";
            this.Size = new System.Drawing.Size(980, 678);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._gbxDatosProyectos.ResumeLayout(false);
            this._gbxDatosProyectos.PerformLayout();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numPorcentaje)).EndInit();
            this._pnlEsquema.ResumeLayout(false);
            this._pnlEsquema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbxEsquema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlEsquema;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel _pnlLocalizacion;
        private Controles.CNDCToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCButton _btnEsquema;
        private Controles.CNDCTextBox _txtEsquema;
        private Controles.CNDCLabel label14;
        private Controles.CNDCLabel label13;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel label2;
        private Controles.CNDCLabel label1;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCComboBox _cmbEntidadeResponsable;
        private Controles.CNDCPictureBox _pbxEsquema;
        private Controles.CNDCComboBox _cmbEtapa;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCButton _btnAddEntidadResponsable;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCRadioButton _rbtnReducida;
        private Controles.CNDCRadioButton _rbtnReal;
        private System.Windows.Forms.NumericUpDown _numPorcentaje;
        private Controles.CNDCLabel cndcLabel2;
    }
}
