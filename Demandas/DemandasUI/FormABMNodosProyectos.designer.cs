namespace DemandasUI
{
    partial class FormABMNodosProyectos
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
            this._txtTension = new Controles.CNDCTextBoxFloat();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dtpFechaSalida = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dtpFechaIngreso = new Controles.CNDCDateTimePicker();
            this._dgvProyectos = new System.Windows.Forms.DataGridView();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._cmbTipoNodo = new Controles.CNDCComboBox();
            this.label4 = new Controles.CNDCLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).BeginInit();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.White;
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(175, 40);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(486, 22);
            this._txtNombre.TabIndex = 21;
            this._txtNombre.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 22;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Descripción:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(105, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 24;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Tensión:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(124, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 18;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Sigla:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(105, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 16;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nombre:";
            // 
            // _txtSigla
            // 
            this._txtSigla.BackColor = System.Drawing.Color.White;
            this._txtSigla.EnterComoTab = false;
            this._txtSigla.Etiqueta = null;
            this._txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSigla.Location = new System.Drawing.Point(175, 64);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(160, 22);
            this._txtSigla.TabIndex = 25;
            this._txtSigla.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.BackColor = System.Drawing.Color.White;
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDescripcion.Location = new System.Drawing.Point(175, 152);
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(486, 22);
            this._txtDescripcion.TabIndex = 26;
            this._txtDescripcion.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // _txtTension
            // 
            this._txtTension.BackColor = System.Drawing.Color.White;
            this._txtTension.EnterComoTab = false;
            this._txtTension.Etiqueta = null;
            this._txtTension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTension.Location = new System.Drawing.Point(175, 86);
            this._txtTension.Name = "_txtTension";
            this._txtTension.Size = new System.Drawing.Size(160, 22);
            this._txtTension.TabIndex = 27;
            this._txtTension.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            this._txtTension.Text = ".00";
            this._txtTension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTension.ValDouble = 0D;
            this._txtTension.Value = 0F;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cmbTipoNodo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cndcLabel2);
            this.groupBox1.Controls.Add(this._dtpFechaSalida);
            this.groupBox1.Controls.Add(this.cndcLabel1);
            this.groupBox1.Controls.Add(this._dtpFechaIngreso);
            this.groupBox1.Controls.Add(this._dgvProyectos);
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
            this.groupBox1.Size = new System.Drawing.Size(737, 450);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(71, 133);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(102, 16);
            this.cndcLabel2.TabIndex = 33;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Fecha salida:";
            // 
            // _dtpFechaSalida
            // 
            this._dtpFechaSalida.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaSalida.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaSalida.Location = new System.Drawing.Point(175, 130);
            this._dtpFechaSalida.Name = "_dtpFechaSalida";
            this._dtpFechaSalida.Size = new System.Drawing.Size(109, 22);
            this._dtpFechaSalida.TabIndex = 32;
            this._dtpFechaSalida.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(62, 111);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(111, 16);
            this.cndcLabel1.TabIndex = 31;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha ingreso:";
            // 
            // _dtpFechaIngreso
            // 
            this._dtpFechaIngreso.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaIngreso.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaIngreso.Location = new System.Drawing.Point(175, 108);
            this._dtpFechaIngreso.Name = "_dtpFechaIngreso";
            this._dtpFechaIngreso.Size = new System.Drawing.Size(109, 22);
            this._dtpFechaIngreso.TabIndex = 30;
            this._dtpFechaIngreso.TablaCampoBD = null;
            // 
            // _dgvProyectos
            // 
            this._dgvProyectos.AllowUserToAddRows = false;
            this._dgvProyectos.AllowUserToDeleteRows = false;
            this._dgvProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvProyectos.Location = new System.Drawing.Point(6, 178);
            this._dgvProyectos.Name = "_dgvProyectos";
            this._dgvProyectos.ReadOnly = true;
            this._dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvProyectos.Size = new System.Drawing.Size(721, 266);
            this._dgvProyectos.TabIndex = 28;
            this._dgvProyectos.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._tsbNuevo});
            this._toolStrip.Location = new System.Drawing.Point(2, -1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(258, 25);
            this._toolStrip.TabIndex = 29;
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
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::DemandasUI.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(55, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
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
            // _tsbNuevo
            // 
            this._tsbNuevo.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNuevo.Name = "_tsbNuevo";
            this._tsbNuevo.Size = new System.Drawing.Size(58, 22);
            this._tsbNuevo.Text = "Nuevo";
            this._tsbNuevo.Click += new System.EventHandler(this._tsbNuevo_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _cmbTipoNodo
            // 
            this._cmbTipoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoNodo.EnterComoTab = false;
            this._cmbTipoNodo.Etiqueta = null;
            this._cmbTipoNodo.FormattingEnabled = true;
            this._cmbTipoNodo.Location = new System.Drawing.Point(175, 19);
            this._cmbTipoNodo.Name = "_cmbTipoNodo";
            this._cmbTipoNodo.Size = new System.Drawing.Size(160, 21);
            this._cmbTipoNodo.TabIndex = 35;
            this._cmbTipoNodo.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 34;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tipo Nodo:";
            // 
            // FormABMNodosProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 471);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormABMNodosProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Nodos proyectos/salida";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).EndInit();
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
        private Controles.CNDCTextBoxFloat _txtTension;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.DataGridView _dgvProyectos;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private Controles.CNDCLabel cndcLabel2;
        protected Controles.CNDCDateTimePicker _dtpFechaSalida;
        private Controles.CNDCLabel cndcLabel1;
        protected Controles.CNDCDateTimePicker _dtpFechaIngreso;
        private Controles.CNDCComboBox _cmbTipoNodo;
        private Controles.CNDCLabel label4;
    }
}