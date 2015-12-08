namespace Proyectos
{
    partial class CtrlLocalizacionDeProysDeGeneracion
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
            this._gbxLocalizacion = new Controles.CNDCGroupBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtProvincia = new Controles.CNDCTextBox();
            this._txtLocalidad = new Controles.CNDCTextBox();
            this._gbxUnidadMedida = new Controles.CNDCGroupBox();
            this._lblLatitudUTM = new Controles.CNDCLabel();
            this._lblLongitudUTM = new Controles.CNDCLabel();
            this._lblLatitudGrados = new Controles.CNDCLabel();
            this._rbtUTM = new Controles.CNDCRadioButton();
            this._txtLatitudGrados = new System.Windows.Forms.MaskedTextBox();
            this._txtLongitudGrados = new System.Windows.Forms.MaskedTextBox();
            this._txtLatitudUTM = new Controles.CNDCTextBoxFloat();
            this._rbtGrados = new Controles.CNDCRadioButton();
            this._lblLongitudGrados = new Controles.CNDCLabel();
            this._txtLongitudUTM = new Controles.CNDCTextBoxFloat();
            this.label8 = new Controles.CNDCLabel();
            this._txtAltitud = new Controles.CNDCTextBoxInt();
            this._cmbDepartamento = new Controles.CNDCComboBox();
            this.label5 = new Controles.CNDCLabel();
            this.label4 = new Controles.CNDCLabel();
            this.label3 = new Controles.CNDCLabel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._gbxLocalizacion.SuspendLayout();
            this._gbxUnidadMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbxLocalizacion
            // 
            this._gbxLocalizacion.Controls.Add(this.cndcLabel1);
            this._gbxLocalizacion.Controls.Add(this._txtProvincia);
            this._gbxLocalizacion.Controls.Add(this._txtLocalidad);
            this._gbxLocalizacion.Controls.Add(this._gbxUnidadMedida);
            this._gbxLocalizacion.Controls.Add(this.label8);
            this._gbxLocalizacion.Controls.Add(this._txtAltitud);
            this._gbxLocalizacion.Controls.Add(this._cmbDepartamento);
            this._gbxLocalizacion.Controls.Add(this.label5);
            this._gbxLocalizacion.Controls.Add(this.label4);
            this._gbxLocalizacion.Controls.Add(this.label3);
            this._gbxLocalizacion.Location = new System.Drawing.Point(5, 4);
            this._gbxLocalizacion.Name = "_gbxLocalizacion";
            this._gbxLocalizacion.Size = new System.Drawing.Size(890, 122);
            this._gbxLocalizacion.TabIndex = 0;
            this._gbxLocalizacion.TablaCampoBD = null;
            this._gbxLocalizacion.TabStop = false;
            this._gbxLocalizacion.Text = "LOCALIZACION";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(9, 41);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(90, 13);
            this.cndcLabel1.TabIndex = 6;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Datum WGS84";
            // 
            // _txtProvincia
            // 
            this._txtProvincia.BackColor = System.Drawing.Color.White;
            this._txtProvincia.EnterComoTab = true;
            this._txtProvincia.Etiqueta = null;
            this._txtProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtProvincia.Location = new System.Drawing.Point(375, 15);
            this._txtProvincia.MaxLength = 1000;
            this._txtProvincia.Name = "_txtProvincia";
            this._txtProvincia.Size = new System.Drawing.Size(180, 22);
            this._txtProvincia.TabIndex = 3;
            this._txtProvincia.TablaCampoBD = "F_PR_LOCAL_PROYS_GENERACION.PROVINCIA";
            // 
            // _txtLocalidad
            // 
            this._txtLocalidad.BackColor = System.Drawing.Color.White;
            this._txtLocalidad.EnterComoTab = true;
            this._txtLocalidad.Etiqueta = null;
            this._txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLocalidad.Location = new System.Drawing.Point(93, 14);
            this._txtLocalidad.MaxLength = 1000;
            this._txtLocalidad.Name = "_txtLocalidad";
            this._txtLocalidad.Size = new System.Drawing.Size(192, 22);
            this._txtLocalidad.TabIndex = 1;
            this._txtLocalidad.TablaCampoBD = "F_PR_LOCAL_PROYS_GENERACION.LOCALIDAD";
            // 
            // _gbxUnidadMedida
            // 
            this._gbxUnidadMedida.Controls.Add(this._lblLatitudUTM);
            this._gbxUnidadMedida.Controls.Add(this._lblLongitudUTM);
            this._gbxUnidadMedida.Controls.Add(this._lblLatitudGrados);
            this._gbxUnidadMedida.Controls.Add(this._rbtUTM);
            this._gbxUnidadMedida.Controls.Add(this._txtLatitudGrados);
            this._gbxUnidadMedida.Controls.Add(this._txtLongitudGrados);
            this._gbxUnidadMedida.Controls.Add(this._txtLatitudUTM);
            this._gbxUnidadMedida.Controls.Add(this._rbtGrados);
            this._gbxUnidadMedida.Controls.Add(this._lblLongitudGrados);
            this._gbxUnidadMedida.Controls.Add(this._txtLongitudUTM);
            this._gbxUnidadMedida.Location = new System.Drawing.Point(9, 55);
            this._gbxUnidadMedida.Name = "_gbxUnidadMedida";
            this._gbxUnidadMedida.Size = new System.Drawing.Size(329, 65);
            this._gbxUnidadMedida.TabIndex = 9;
            this._gbxUnidadMedida.TablaCampoBD = null;
            this._gbxUnidadMedida.TabStop = false;
            this._gbxUnidadMedida.Text = "Grados o UTM";
            // 
            // _lblLatitudUTM
            // 
            this._lblLatitudUTM.AutoSize = true;
            this._lblLatitudUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLatitudUTM.Location = new System.Drawing.Point(95, 14);
            this._lblLatitudUTM.Name = "_lblLatitudUTM";
            this._lblLatitudUTM.Size = new System.Drawing.Size(66, 16);
            this._lblLatitudUTM.TabIndex = 2;
            this._lblLatitudUTM.TablaCampoBD = null;
            this._lblLatitudUTM.Text = "Este (X):";
            // 
            // _lblLongitudUTM
            // 
            this._lblLongitudUTM.AutoSize = true;
            this._lblLongitudUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLongitudUTM.Location = new System.Drawing.Point(87, 39);
            this._lblLongitudUTM.Name = "_lblLongitudUTM";
            this._lblLongitudUTM.Size = new System.Drawing.Size(74, 16);
            this._lblLongitudUTM.TabIndex = 6;
            this._lblLongitudUTM.TablaCampoBD = null;
            this._lblLongitudUTM.Text = "Norte (Y):";
            // 
            // _lblLatitudGrados
            // 
            this._lblLatitudGrados.AutoSize = true;
            this._lblLatitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLatitudGrados.Location = new System.Drawing.Point(103, 40);
            this._lblLatitudGrados.Name = "_lblLatitudGrados";
            this._lblLatitudGrados.Size = new System.Drawing.Size(85, 16);
            this._lblLatitudGrados.TabIndex = 7;
            this._lblLatitudGrados.TablaCampoBD = null;
            this._lblLatitudGrados.Text = "Latitud Sur:";
            // 
            // _rbtUTM
            // 
            this._rbtUTM.AutoSize = true;
            this._rbtUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbtUTM.Location = new System.Drawing.Point(6, 37);
            this._rbtUTM.Name = "_rbtUTM";
            this._rbtUTM.Size = new System.Drawing.Size(55, 19);
            this._rbtUTM.TabIndex = 5;
            this._rbtUTM.TablaCampoBD = null;
            this._rbtUTM.TabStop = true;
            this._rbtUTM.Text = "UTM ";
            this._rbtUTM.UseVisualStyleBackColor = true;
            this._rbtUTM.CheckedChanged += new System.EventHandler(this._rbtUTM_CheckedChanged);
            // 
            // _txtLatitudGrados
            // 
            this._txtLatitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudGrados.Location = new System.Drawing.Point(193, 37);
            this._txtLatitudGrados.Mask = "00° 00\' 00.00\'\'";
            this._txtLatitudGrados.Name = "_txtLatitudGrados";
            this._txtLatitudGrados.Size = new System.Drawing.Size(107, 24);
            this._txtLatitudGrados.TabIndex = 9;
            this._txtLatitudGrados.Validating += new System.ComponentModel.CancelEventHandler(this._txtLongitudGrados_Validating);
            // 
            // _txtLongitudGrados
            // 
            this._txtLongitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudGrados.Location = new System.Drawing.Point(192, 11);
            this._txtLongitudGrados.Mask = "00° 00\' 00.00\'\'";
            this._txtLongitudGrados.Name = "_txtLongitudGrados";
            this._txtLongitudGrados.Size = new System.Drawing.Size(108, 24);
            this._txtLongitudGrados.TabIndex = 4;
            this._txtLongitudGrados.Validating += new System.ComponentModel.CancelEventHandler(this._txtLongitudGrados_Validating);
            // 
            // _txtLatitudUTM
            // 
            this._txtLatitudUTM.AceptaNegativo = false;
            this._txtLatitudUTM.BackColor = System.Drawing.Color.White;
            this._txtLatitudUTM.EnterComoTab = true;
            this._txtLatitudUTM.Etiqueta = null;
            this._txtLatitudUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudUTM.Location = new System.Drawing.Point(164, 37);
            this._txtLatitudUTM.MaxDigitosDecimales = 0;
            this._txtLatitudUTM.MaxDigitosEnteros = 0;
            this._txtLatitudUTM.MaxLength = 7;
            this._txtLatitudUTM.Name = "_txtLatitudUTM";
            this._txtLatitudUTM.Size = new System.Drawing.Size(100, 22);
            this._txtLatitudUTM.TabIndex = 8;
            this._txtLatitudUTM.TablaCampoBD = "F_PR_LOCAL_PROYS_GENERACION.LATITUD_UTM";
            this._txtLatitudUTM.Text = "0";
            this._txtLatitudUTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLatitudUTM.UsarFormatoNumerico = true;
            this._txtLatitudUTM.ValDouble = 0D;
            this._txtLatitudUTM.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLatitudUTM.ValorDouble = 0D;
            this._txtLatitudUTM.ValorFloat = 0F;
            this._txtLatitudUTM.ValorInt = 0;
            this._txtLatitudUTM.ValorLong = ((long)(0));
            this._txtLatitudUTM.Value = 0F;
            this._txtLatitudUTM.Visible = false;
            // 
            // _rbtGrados
            // 
            this._rbtGrados.AutoSize = true;
            this._rbtGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbtGrados.Location = new System.Drawing.Point(6, 14);
            this._rbtGrados.Name = "_rbtGrados";
            this._rbtGrados.Size = new System.Drawing.Size(65, 19);
            this._rbtGrados.TabIndex = 0;
            this._rbtGrados.TablaCampoBD = null;
            this._rbtGrados.TabStop = true;
            this._rbtGrados.Text = "Grados";
            this._rbtGrados.UseVisualStyleBackColor = true;
            this._rbtGrados.CheckedChanged += new System.EventHandler(this._rbtGrados_CheckedChanged);
            // 
            // _lblLongitudGrados
            // 
            this._lblLongitudGrados.AutoSize = true;
            this._lblLongitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLongitudGrados.Location = new System.Drawing.Point(72, 16);
            this._lblLongitudGrados.Name = "_lblLongitudGrados";
            this._lblLongitudGrados.Size = new System.Drawing.Size(116, 16);
            this._lblLongitudGrados.TabIndex = 1;
            this._lblLongitudGrados.TablaCampoBD = null;
            this._lblLongitudGrados.Text = "Longitud Oeste:";
            // 
            // _txtLongitudUTM
            // 
            this._txtLongitudUTM.AceptaNegativo = false;
            this._txtLongitudUTM.BackColor = System.Drawing.Color.White;
            this._txtLongitudUTM.EnterComoTab = true;
            this._txtLongitudUTM.Etiqueta = null;
            this._txtLongitudUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudUTM.Location = new System.Drawing.Point(164, 12);
            this._txtLongitudUTM.MaxDigitosDecimales = 0;
            this._txtLongitudUTM.MaxDigitosEnteros = 0;
            this._txtLongitudUTM.MaxLength = 6;
            this._txtLongitudUTM.Name = "_txtLongitudUTM";
            this._txtLongitudUTM.Size = new System.Drawing.Size(100, 22);
            this._txtLongitudUTM.TabIndex = 3;
            this._txtLongitudUTM.TablaCampoBD = "F_PR_LOCAL_PROYS_GENERACION.LONGITUD_UTM";
            this._txtLongitudUTM.Text = "0";
            this._txtLongitudUTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLongitudUTM.UsarFormatoNumerico = true;
            this._txtLongitudUTM.ValDouble = 0D;
            this._txtLongitudUTM.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLongitudUTM.ValorDouble = 0D;
            this._txtLongitudUTM.ValorFloat = 0F;
            this._txtLongitudUTM.ValorInt = 0;
            this._txtLongitudUTM.ValorLong = ((long)(0));
            this._txtLongitudUTM.Value = 0F;
            this._txtLongitudUTM.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(321, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 7;
            this.label8.TablaCampoBD = null;
            this.label8.Text = "Altitud (m.s.n.m):";
            // 
            // _txtAltitud
            // 
            this._txtAltitud.AceptaNegativo = false;
            this._txtAltitud.BackColor = System.Drawing.Color.White;
            this._txtAltitud.EnterComoTab = true;
            this._txtAltitud.Etiqueta = null;
            this._txtAltitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAltitud.Location = new System.Drawing.Point(446, 38);
            this._txtAltitud.MaxDigitosDecimales = 0;
            this._txtAltitud.MaxDigitosEnteros = 0;
            this._txtAltitud.MaxLength = 30;
            this._txtAltitud.Name = "_txtAltitud";
            this._txtAltitud.Size = new System.Drawing.Size(108, 22);
            this._txtAltitud.TabIndex = 8;
            this._txtAltitud.TablaCampoBD = "F_PR_LOCAL_PROYS_GENERACION.ALTITUD";
            this._txtAltitud.Text = "0";
            this._txtAltitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtAltitud.UsarFormatoNumerico = true;
            this._txtAltitud.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtAltitud.ValorDouble = 0D;
            this._txtAltitud.ValorFloat = 0F;
            this._txtAltitud.ValorInt = 0;
            this._txtAltitud.ValorLong = ((long)(0));
            this._txtAltitud.Value = 0;
            // 
            // _cmbDepartamento
            // 
            this._cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDepartamento.EnterComoTab = false;
            this._cmbDepartamento.Etiqueta = null;
            this._cmbDepartamento.FormattingEnabled = true;
            this._cmbDepartamento.Items.AddRange(new object[] {
            "Beni",
            "Cochabamba",
            "La Paz",
            "Oruro",
            "Pando",
            "Santa Cruz",
            "Sucre",
            "Tarija"});
            this._cmbDepartamento.Location = new System.Drawing.Point(690, 16);
            this._cmbDepartamento.Name = "_cmbDepartamento";
            this._cmbDepartamento.Size = new System.Drawing.Size(193, 21);
            this._cmbDepartamento.TabIndex = 5;
            this._cmbDepartamento.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(578, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 4;
            this.label5.TablaCampoBD = null;
            this.label5.Text = "Departamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 2;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Provincia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 0;
            this.label3.TablaCampoBD = null;
            this.label3.Text = "Localidad:";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlLocalizacionDeProysDeGeneracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this._gbxLocalizacion);
            this.Name = "CtrlLocalizacionDeProysDeGeneracion";
            this.Size = new System.Drawing.Size(897, 131);
            this._gbxLocalizacion.ResumeLayout(false);
            this._gbxLocalizacion.PerformLayout();
            this._gbxUnidadMedida.ResumeLayout(false);
            this._gbxUnidadMedida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGroupBox _gbxLocalizacion;
        private Controles.CNDCLabel label8;
        private Controles.CNDCTextBoxInt _txtAltitud;
        private Controles.CNDCComboBox _cmbDepartamento;
        private Controles.CNDCLabel label5;
        private Controles.CNDCLabel label4;
        private Controles.CNDCLabel label3;
        private Controles.CNDCGroupBox _gbxUnidadMedida;
        private Controles.CNDCRadioButton _rbtUTM;
        private Controles.CNDCRadioButton _rbtGrados;
        private Controles.CNDCTextBox _txtProvincia;
        private Controles.CNDCTextBox _txtLocalidad;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCTextBoxFloat _txtLongitudUTM;
        private Controles.CNDCTextBoxFloat _txtLatitudUTM;
        private System.Windows.Forms.MaskedTextBox _txtLatitudGrados;
        private System.Windows.Forms.MaskedTextBox _txtLongitudGrados;
        private Controles.CNDCLabel _lblLatitudGrados;
        private Controles.CNDCLabel _lblLongitudGrados;
        private Controles.CNDCLabel _lblLatitudUTM;
        private Controles.CNDCLabel _lblLongitudUTM;
        private Controles.CNDCLabel cndcLabel1;

    }
}
