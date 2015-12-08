namespace MedicionComercialUI
{
    partial class CtrlPuntoMedicion
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
            this._cmbPropietario = new Controles.CNDCComboBox();
            this.cndcLabel7 = new Controles.CNDCLabel();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._chbxFechaSalida = new Controles.CNDCCheckBox();
            this._dtpFechaIngreso = new Controles.CNDCDateTimePicker();
            this._dtpFechaSalida = new Controles.CNDCDateTimePicker();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._txtFechaSinDefinir = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._pnlRadioButtons = new Controles.CNDCPanelControl();
            this._rbtnVirtual = new Controles.CNDCRadioButton();
            this._rbtnReal = new Controles.CNDCRadioButton();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._pnlRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cmbPropietario
            // 
            this._cmbPropietario.Enabled = false;
            this._cmbPropietario.EnterComoTab = false;
            this._cmbPropietario.Etiqueta = null;
            this._cmbPropietario.FormattingEnabled = true;
            this._cmbPropietario.Location = new System.Drawing.Point(191, 146);
            this._cmbPropietario.Name = "_cmbPropietario";
            this._cmbPropietario.Size = new System.Drawing.Size(300, 21);
            this._cmbPropietario.TabIndex = 31;
            this._cmbPropietario.TablaCampoBD = null;
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Location = new System.Drawing.Point(125, 149);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(60, 13);
            this.cndcLabel7.TabIndex = 30;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Propietario:";
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnGuardar,
            this._btnEditar,
            this._btnDarBaja,
            this._btnCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(567, 25);
            this.cndcToolStrip1.TabIndex = 29;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.Image = global::MedicionComercialUI.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(58, 22);
            this._btnAdicionar.Text = "Nuevo";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Enabled = false;
            this._btnGuardar.Image = global::MedicionComercialUI.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(66, 22);
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::MedicionComercialUI.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(55, 22);
            this._btnEditar.Text = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnDarBaja
            // 
            this._btnDarBaja.Image = global::MedicionComercialUI.Properties.Resources.Clear;
            this._btnDarBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnDarBaja.Name = "_btnDarBaja";
            this._btnDarBaja.Size = new System.Drawing.Size(68, 22);
            this._btnDarBaja.Text = "Dar Baja";
            this._btnDarBaja.Click += new System.EventHandler(this._btnDarBaja_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Enabled = false;
            this._btnCancelar.Image = global::MedicionComercialUI.Properties.Resources.disable__v3929;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(191, 100);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.ReadOnly = true;
            this._txtDescripcion.Size = new System.Drawing.Size(300, 44);
            this._txtDescripcion.TabIndex = 22;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(119, 103);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel3.TabIndex = 21;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Descripción:";
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(191, 79);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.ReadOnly = true;
            this._txtNombre.Size = new System.Drawing.Size(300, 20);
            this._txtNombre.TabIndex = 20;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(138, 82);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel2.TabIndex = 19;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nombre:";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(107, 173);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(78, 13);
            this.cndcLabel1.TabIndex = 32;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha Ingreso:";
            // 
            // _chbxFechaSalida
            // 
            this._chbxFechaSalida.AutoSize = true;
            this._chbxFechaSalida.Enabled = false;
            this._chbxFechaSalida.Location = new System.Drawing.Point(94, 195);
            this._chbxFechaSalida.Name = "_chbxFechaSalida";
            this._chbxFechaSalida.Size = new System.Drawing.Size(91, 17);
            this._chbxFechaSalida.TabIndex = 36;
            this._chbxFechaSalida.TablaCampoBD = null;
            this._chbxFechaSalida.Text = "Fecha Salida:";
            this._chbxFechaSalida.UseVisualStyleBackColor = true;
            this._chbxFechaSalida.CheckedChanged += new System.EventHandler(this._chbxFechaSalida_CheckedChanged);
            // 
            // _dtpFechaIngreso
            // 
            this._dtpFechaIngreso.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaIngreso.Enabled = false;
            this._dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaIngreso.Location = new System.Drawing.Point(191, 169);
            this._dtpFechaIngreso.Name = "_dtpFechaIngreso";
            this._dtpFechaIngreso.Size = new System.Drawing.Size(115, 20);
            this._dtpFechaIngreso.TabIndex = 37;
            this._dtpFechaIngreso.TablaCampoBD = null;
            // 
            // _dtpFechaSalida
            // 
            this._dtpFechaSalida.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaSalida.Enabled = false;
            this._dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaSalida.Location = new System.Drawing.Point(191, 192);
            this._dtpFechaSalida.Name = "_dtpFechaSalida";
            this._dtpFechaSalida.Size = new System.Drawing.Size(115, 20);
            this._dtpFechaSalida.TabIndex = 38;
            this._dtpFechaSalida.TablaCampoBD = null;
            this._dtpFechaSalida.Visible = false;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _txtFechaSinDefinir
            // 
            this._txtFechaSinDefinir.Enabled = false;
            this._txtFechaSinDefinir.EnterComoTab = false;
            this._txtFechaSinDefinir.Etiqueta = null;
            this._txtFechaSinDefinir.Location = new System.Drawing.Point(191, 192);
            this._txtFechaSinDefinir.Name = "_txtFechaSinDefinir";
            this._txtFechaSinDefinir.ReadOnly = true;
            this._txtFechaSinDefinir.Size = new System.Drawing.Size(115, 20);
            this._txtFechaSinDefinir.TabIndex = 39;
            this._txtFechaSinDefinir.TablaCampoBD = null;
            this._txtFechaSinDefinir.Text = "Sin Definir.";
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(77, 56);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(108, 13);
            this.cndcLabel4.TabIndex = 40;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Tipo Punto Medición:";
            // 
            // _pnlRadioButtons
            // 
            this._pnlRadioButtons.Controls.Add(this._rbtnVirtual);
            this._pnlRadioButtons.Controls.Add(this._rbtnReal);
            this._pnlRadioButtons.Enabled = false;
            this._pnlRadioButtons.Location = new System.Drawing.Point(191, 49);
            this._pnlRadioButtons.Name = "_pnlRadioButtons";
            this._pnlRadioButtons.Size = new System.Drawing.Size(133, 26);
            this._pnlRadioButtons.TabIndex = 41;
            this._pnlRadioButtons.TablaCampoBD = null;
            // 
            // _rbtnVirtual
            // 
            this._rbtnVirtual.AutoSize = true;
            this._rbtnVirtual.Location = new System.Drawing.Point(68, 5);
            this._rbtnVirtual.Name = "_rbtnVirtual";
            this._rbtnVirtual.Size = new System.Drawing.Size(54, 17);
            this._rbtnVirtual.TabIndex = 1;
            this._rbtnVirtual.TablaCampoBD = null;
            this._rbtnVirtual.Text = "Virtual";
            this._rbtnVirtual.UseVisualStyleBackColor = true;
            // 
            // _rbtnReal
            // 
            this._rbtnReal.AutoSize = true;
            this._rbtnReal.Checked = true;
            this._rbtnReal.Location = new System.Drawing.Point(3, 5);
            this._rbtnReal.Name = "_rbtnReal";
            this._rbtnReal.Size = new System.Drawing.Size(47, 17);
            this._rbtnReal.TabIndex = 0;
            this._rbtnReal.TablaCampoBD = null;
            this._rbtnReal.TabStop = true;
            this._rbtnReal.Text = "Real";
            this._rbtnReal.UseVisualStyleBackColor = true;
            // 
            // CtrlPuntoMedicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pnlRadioButtons);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._dtpFechaSalida);
            this.Controls.Add(this._dtpFechaIngreso);
            this.Controls.Add(this._chbxFechaSalida);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._cmbPropietario);
            this.Controls.Add(this.cndcLabel7);
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtFechaSinDefinir);
            this.Name = "CtrlPuntoMedicion";
            this.Size = new System.Drawing.Size(567, 325);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._pnlRadioButtons.ResumeLayout(false);
            this._pnlRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbPropietario;
        private Controles.CNDCLabel cndcLabel7;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnDarBaja;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCCheckBox _chbxFechaSalida;
        private Controles.CNDCDateTimePicker _dtpFechaIngreso;
        private Controles.CNDCDateTimePicker _dtpFechaSalida;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCTextBox _txtFechaSinDefinir;
        private Controles.CNDCPanelControl _pnlRadioButtons;
        private Controles.CNDCRadioButton _rbtnVirtual;
        private Controles.CNDCRadioButton _rbtnReal;
        private Controles.CNDCLabel cndcLabel4;
    }
}
