namespace MedicionComercialUI
{
    partial class CtrlIntervalo
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
            this._txtEstado = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtTiempoPeriodo = new Controles.CNDCTextBoxInt();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._dtpDesde = new Controles.CNDCDateTimePicker();
            this._dtpHasta = new Controles.CNDCDateTimePicker();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._chbxHasta = new Controles.CNDCCheckBox();
            this._txtSinDefinir = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtEstado
            // 
            this._txtEstado.Enabled = false;
            this._txtEstado.EnterComoTab = false;
            this._txtEstado.Etiqueta = null;
            this._txtEstado.Location = new System.Drawing.Point(96, 106);
            this._txtEstado.Name = "_txtEstado";
            this._txtEstado.Size = new System.Drawing.Size(108, 20);
            this._txtEstado.TabIndex = 15;
            this._txtEstado.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(47, 109);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(43, 13);
            this.cndcLabel4.TabIndex = 14;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Estado:";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(6, 35);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(84, 13);
            this.cndcLabel3.TabIndex = 12;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Tiempo Periodo:";
            // 
            // _txtNombre
            // 
            this._txtNombre.Enabled = false;
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(96, 8);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(284, 20);
            this._txtNombre.TabIndex = 9;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(43, 11);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel1.TabIndex = 8;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Nombre:";
            // 
            // _txtTiempoPeriodo
            // 
            this._txtTiempoPeriodo.AceptaNegativo = false;
            this._txtTiempoPeriodo.Enabled = false;
            this._txtTiempoPeriodo.EnterComoTab = false;
            this._txtTiempoPeriodo.Etiqueta = null;
            this._txtTiempoPeriodo.Location = new System.Drawing.Point(96, 32);
            this._txtTiempoPeriodo.MaxDigitosDecimales = 0;
            this._txtTiempoPeriodo.MaxDigitosEnteros = 0;
            this._txtTiempoPeriodo.Name = "_txtTiempoPeriodo";
            this._txtTiempoPeriodo.Size = new System.Drawing.Size(108, 20);
            this._txtTiempoPeriodo.TabIndex = 16;
            this._txtTiempoPeriodo.TablaCampoBD = null;
            this._txtTiempoPeriodo.Text = "0";
            this._txtTiempoPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempoPeriodo.UsarFormatoNumerico = true;
            this._txtTiempoPeriodo.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtTiempoPeriodo.ValorDouble = 0D;
            this._txtTiempoPeriodo.ValorFloat = 0F;
            this._txtTiempoPeriodo.ValorInt = 0;
            this._txtTiempoPeriodo.ValorLong = ((long)(0));
            this._txtTiempoPeriodo.Value = 0;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(49, 61);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel2.TabIndex = 17;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Desde:";
            // 
            // _dtpDesde
            // 
            this._dtpDesde.CustomFormat = "dd/MMM/yyyy";
            this._dtpDesde.Enabled = false;
            this._dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpDesde.Location = new System.Drawing.Point(96, 57);
            this._dtpDesde.Name = "_dtpDesde";
            this._dtpDesde.Size = new System.Drawing.Size(108, 20);
            this._dtpDesde.TabIndex = 19;
            this._dtpDesde.TablaCampoBD = null;
            // 
            // _dtpHasta
            // 
            this._dtpHasta.CustomFormat = "dd/MMM/yyyy";
            this._dtpHasta.Enabled = false;
            this._dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpHasta.Location = new System.Drawing.Point(96, 82);
            this._dtpHasta.Name = "_dtpHasta";
            this._dtpHasta.Size = new System.Drawing.Size(108, 20);
            this._dtpHasta.TabIndex = 20;
            this._dtpHasta.TablaCampoBD = null;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _chbxHasta
            // 
            this._chbxHasta.AutoSize = true;
            this._chbxHasta.Enabled = false;
            this._chbxHasta.Location = new System.Drawing.Point(33, 83);
            this._chbxHasta.Name = "_chbxHasta";
            this._chbxHasta.Size = new System.Drawing.Size(57, 17);
            this._chbxHasta.TabIndex = 21;
            this._chbxHasta.TablaCampoBD = null;
            this._chbxHasta.Text = "Hasta:";
            this._chbxHasta.UseVisualStyleBackColor = true;
            this._chbxHasta.CheckedChanged += new System.EventHandler(this._chbxHasta_CheckedChanged);
            // 
            // _txtSinDefinir
            // 
            this._txtSinDefinir.Enabled = false;
            this._txtSinDefinir.EnterComoTab = false;
            this._txtSinDefinir.Etiqueta = null;
            this._txtSinDefinir.Location = new System.Drawing.Point(96, 82);
            this._txtSinDefinir.Name = "_txtSinDefinir";
            this._txtSinDefinir.ReadOnly = true;
            this._txtSinDefinir.Size = new System.Drawing.Size(108, 20);
            this._txtSinDefinir.TabIndex = 22;
            this._txtSinDefinir.TablaCampoBD = null;
            this._txtSinDefinir.Text = "Sin definir.";
            this._txtSinDefinir.Visible = false;
            // 
            // CtrlIntervalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._chbxHasta);
            this.Controls.Add(this._dtpDesde);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtTiempoPeriodo);
            this.Controls.Add(this._txtEstado);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._dtpHasta);
            this.Controls.Add(this._txtSinDefinir);
            this.Name = "CtrlIntervalo";
            this.Size = new System.Drawing.Size(401, 134);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtEstado;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBoxInt _txtTiempoPeriodo;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCDateTimePicker _dtpDesde;
        private Controles.CNDCDateTimePicker _dtpHasta;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCCheckBox _chbxHasta;
        private Controles.CNDCTextBox _txtSinDefinir;
    }
}
