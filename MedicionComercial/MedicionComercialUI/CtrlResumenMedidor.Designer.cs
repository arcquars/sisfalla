namespace MedicionComercialUI
{
    partial class CtrlResumenMedidor
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtPrimeNoins = new Controles.CNDCTextBox();
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtMarca = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtModelo = new Controles.CNDCTextBox();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this._txtPresicion = new Controles.CNDCTextBoxNumerico();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cndcLabel7 = new Controles.CNDCLabel();
            this._cmbPropietario = new Controles.CNDCComboBox();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(178, 76);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(81, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "PRIME NOINS:";
            // 
            // _txtPrimeNoins
            // 
            this._txtPrimeNoins.EnterComoTab = false;
            this._txtPrimeNoins.Etiqueta = null;
            this._txtPrimeNoins.Location = new System.Drawing.Point(262, 73);
            this._txtPrimeNoins.Name = "_txtPrimeNoins";
            this._txtPrimeNoins.ReadOnly = true;
            this._txtPrimeNoins.Size = new System.Drawing.Size(169, 20);
            this._txtPrimeNoins.TabIndex = 1;
            this._txtPrimeNoins.TablaCampoBD = null;
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(262, 94);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.ReadOnly = true;
            this._txtNombre.Size = new System.Drawing.Size(300, 20);
            this._txtNombre.TabIndex = 3;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(212, 97);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nombre:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(262, 115);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.ReadOnly = true;
            this._txtDescripcion.Size = new System.Drawing.Size(300, 44);
            this._txtDescripcion.TabIndex = 5;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(193, 118);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Descripción:";
            // 
            // _txtMarca
            // 
            this._txtMarca.EnterComoTab = false;
            this._txtMarca.Etiqueta = null;
            this._txtMarca.Location = new System.Drawing.Point(262, 160);
            this._txtMarca.Name = "_txtMarca";
            this._txtMarca.ReadOnly = true;
            this._txtMarca.Size = new System.Drawing.Size(300, 20);
            this._txtMarca.TabIndex = 7;
            this._txtMarca.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(219, 163);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(40, 13);
            this.cndcLabel4.TabIndex = 6;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Marca:";
            // 
            // _txtModelo
            // 
            this._txtModelo.EnterComoTab = false;
            this._txtModelo.Etiqueta = null;
            this._txtModelo.Location = new System.Drawing.Point(262, 181);
            this._txtModelo.Name = "_txtModelo";
            this._txtModelo.ReadOnly = true;
            this._txtModelo.Size = new System.Drawing.Size(300, 20);
            this._txtModelo.TabIndex = 9;
            this._txtModelo.TablaCampoBD = null;
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(214, 184);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(45, 13);
            this.cndcLabel5.TabIndex = 8;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Modelo:";
            // 
            // _txtPresicion
            // 
            this._txtPresicion.AceptaNegativo = true;
            this._txtPresicion.EnterComoTab = false;
            this._txtPresicion.Etiqueta = null;
            this._txtPresicion.Location = new System.Drawing.Point(262, 202);
            this._txtPresicion.MaxDigitosDecimales = 0;
            this._txtPresicion.MaxDigitosEnteros = 0;
            this._txtPresicion.Name = "_txtPresicion";
            this._txtPresicion.ReadOnly = true;
            this._txtPresicion.Size = new System.Drawing.Size(100, 20);
            this._txtPresicion.TabIndex = 13;
            this._txtPresicion.TablaCampoBD = null;
            this._txtPresicion.Text = "0";
            this._txtPresicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPresicion.UsarFormatoNumerico = true;
            this._txtPresicion.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtPresicion.ValorDouble = 0D;
            this._txtPresicion.ValorFloat = 0F;
            this._txtPresicion.ValorInt = 0;
            this._txtPresicion.ValorLong = ((long)(0));
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Location = new System.Drawing.Point(206, 205);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(53, 13);
            this.cndcLabel6.TabIndex = 12;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Presición:";
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
            this.cndcToolStrip1.Size = new System.Drawing.Size(727, 25);
            this.cndcToolStrip1.TabIndex = 14;
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
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // cndcLabel7
            // 
            this.cndcLabel7.AutoSize = true;
            this.cndcLabel7.Location = new System.Drawing.Point(199, 51);
            this.cndcLabel7.Name = "cndcLabel7";
            this.cndcLabel7.Size = new System.Drawing.Size(60, 13);
            this.cndcLabel7.TabIndex = 15;
            this.cndcLabel7.TablaCampoBD = null;
            this.cndcLabel7.Text = "Propietario:";
            // 
            // _cmbPropietario
            // 
            this._cmbPropietario.EnterComoTab = false;
            this._cmbPropietario.Etiqueta = null;
            this._cmbPropietario.FormattingEnabled = true;
            this._cmbPropietario.Location = new System.Drawing.Point(262, 48);
            this._cmbPropietario.Name = "_cmbPropietario";
            this._cmbPropietario.Size = new System.Drawing.Size(300, 21);
            this._cmbPropietario.TabIndex = 16;
            this._cmbPropietario.TablaCampoBD = null;
            // 
            // CtrlResumenMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cmbPropietario);
            this.Controls.Add(this.cndcLabel7);
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._txtPresicion);
            this.Controls.Add(this.cndcLabel6);
            this.Controls.Add(this._txtModelo);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this._txtMarca);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtPrimeNoins);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlResumenMedidor";
            this.Size = new System.Drawing.Size(727, 325);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtPrimeNoins;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtMarca;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBox _txtModelo;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCTextBoxNumerico _txtPresicion;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnDarBaja;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCComboBox _cmbPropietario;
        private Controles.CNDCLabel cndcLabel7;
    }
}
