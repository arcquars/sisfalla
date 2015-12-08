namespace Proyectos
{
    partial class CtrlLocalizacionDeProysDeTransmision
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
            this._lblUTMLongitud = new Controles.CNDCLabel();
            this._lblUTMLatitud = new Controles.CNDCLabel();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtLatitudGradosB = new System.Windows.Forms.MaskedTextBox();
            this._txtLongitudGradosB = new System.Windows.Forms.MaskedTextBox();
            this._txtLatitudGradosA = new System.Windows.Forms.MaskedTextBox();
            this._txtLongitudGradosA = new System.Windows.Forms.MaskedTextBox();
            this._cmbDepartamentoB = new Controles.CNDCComboBox();
            this._cmbDepartamentoA = new Controles.CNDCComboBox();
            this._txtLocalidadB = new Controles.CNDCTextBox();
            this._txtLocalidadA = new Controles.CNDCTextBox();
            this._txtSubestacionB = new Controles.CNDCTextBox();
            this._txtSubestacionA = new Controles.CNDCTextBox();
            this._txtLatitudA = new Controles.CNDCTextBoxFloat();
            this._txtLatitudB = new Controles.CNDCTextBoxFloat();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._lblLongitudGrados = new Controles.CNDCLabel();
            this._lblLatitudGrados = new Controles.CNDCLabel();
            this.label4 = new Controles.CNDCLabel();
            this._txtAltitudA = new Controles.CNDCTextBoxInt();
            this._txtAltitudB = new Controles.CNDCTextBoxInt();
            this._txtLongitudA = new Controles.CNDCTextBoxFloat();
            this._txtLongitudB = new Controles.CNDCTextBoxFloat();
            this.label2 = new Controles.CNDCLabel();
            this.label1 = new Controles.CNDCLabel();
            this._gbxLatitud = new Controles.CNDCGroupBox();
            this._rbtUTM = new Controles.CNDCRadioButton();
            this._rbtGrados = new Controles.CNDCRadioButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._gbxLocalizacion.SuspendLayout();
            this._gbxLatitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbxLocalizacion
            // 
            this._gbxLocalizacion.Controls.Add(this._lblUTMLongitud);
            this._gbxLocalizacion.Controls.Add(this._lblUTMLatitud);
            this._gbxLocalizacion.Controls.Add(this.cndcLabel4);
            this._gbxLocalizacion.Controls.Add(this._txtLatitudGradosB);
            this._gbxLocalizacion.Controls.Add(this._txtLongitudGradosB);
            this._gbxLocalizacion.Controls.Add(this._txtLatitudGradosA);
            this._gbxLocalizacion.Controls.Add(this._txtLongitudGradosA);
            this._gbxLocalizacion.Controls.Add(this._cmbDepartamentoB);
            this._gbxLocalizacion.Controls.Add(this._cmbDepartamentoA);
            this._gbxLocalizacion.Controls.Add(this._txtLocalidadB);
            this._gbxLocalizacion.Controls.Add(this._txtLocalidadA);
            this._gbxLocalizacion.Controls.Add(this._txtSubestacionB);
            this._gbxLocalizacion.Controls.Add(this._txtSubestacionA);
            this._gbxLocalizacion.Controls.Add(this._txtLatitudA);
            this._gbxLocalizacion.Controls.Add(this._txtLatitudB);
            this._gbxLocalizacion.Controls.Add(this.cndcLabel3);
            this._gbxLocalizacion.Controls.Add(this._lblLongitudGrados);
            this._gbxLocalizacion.Controls.Add(this._lblLatitudGrados);
            this._gbxLocalizacion.Controls.Add(this.label4);
            this._gbxLocalizacion.Controls.Add(this._txtAltitudA);
            this._gbxLocalizacion.Controls.Add(this._txtAltitudB);
            this._gbxLocalizacion.Controls.Add(this._txtLongitudA);
            this._gbxLocalizacion.Controls.Add(this._txtLongitudB);
            this._gbxLocalizacion.Controls.Add(this.label2);
            this._gbxLocalizacion.Controls.Add(this.label1);
            this._gbxLocalizacion.Controls.Add(this._gbxLatitud);
            this._gbxLocalizacion.Location = new System.Drawing.Point(3, 3);
            this._gbxLocalizacion.Name = "_gbxLocalizacion";
            this._gbxLocalizacion.Size = new System.Drawing.Size(964, 134);
            this._gbxLocalizacion.TabIndex = 0;
            this._gbxLocalizacion.TablaCampoBD = null;
            this._gbxLocalizacion.TabStop = false;
            this._gbxLocalizacion.Text = "LOCALIZACION";
            this._gbxLocalizacion.Enter += new System.EventHandler(this._gbxLocalizacion_Enter);
            // 
            // _lblUTMLongitud
            // 
            this._lblUTMLongitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblUTMLongitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblUTMLongitud.Location = new System.Drawing.Point(714, 60);
            this._lblUTMLongitud.Name = "_lblUTMLongitud";
            this._lblUTMLongitud.Size = new System.Drawing.Size(114, 21);
            this._lblUTMLongitud.TabIndex = 11;
            this._lblUTMLongitud.TablaCampoBD = null;
            this._lblUTMLongitud.Text = "Este (X)";
            this._lblUTMLongitud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblUTMLatitud
            // 
            this._lblUTMLatitud.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this._lblUTMLatitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblUTMLatitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblUTMLatitud.Location = new System.Drawing.Point(611, 60);
            this._lblUTMLatitud.Name = "_lblUTMLatitud";
            this._lblUTMLatitud.Size = new System.Drawing.Size(104, 21);
            this._lblUTMLatitud.TabIndex = 8;
            this._lblUTMLatitud.TablaCampoBD = null;
            this._lblUTMLatitud.Text = "Norte (Y)";
            this._lblUTMLatitud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel4.Location = new System.Drawing.Point(615, 10);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(90, 13);
            this.cndcLabel4.TabIndex = 0;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Datum WGS84";
            // 
            // _txtLatitudGradosB
            // 
            this._txtLatitudGradosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLatitudGradosB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudGradosB.Location = new System.Drawing.Point(611, 101);
            this._txtLatitudGradosB.Mask = "00° 00\' 00.00\'\'";
            this._txtLatitudGradosB.Name = "_txtLatitudGradosB";
            this._txtLatitudGradosB.Size = new System.Drawing.Size(104, 22);
            this._txtLatitudGradosB.TabIndex = 20;
            this._txtLatitudGradosB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLatitudGradosB.Validating += new System.ComponentModel.CancelEventHandler(this._txtLatitudGradosB_Validating);
            // 
            // _txtLongitudGradosB
            // 
            this._txtLongitudGradosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLongitudGradosB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudGradosB.Location = new System.Drawing.Point(714, 101);
            this._txtLongitudGradosB.Mask = "00° 00\' 00.00\'\'";
            this._txtLongitudGradosB.Name = "_txtLongitudGradosB";
            this._txtLongitudGradosB.Size = new System.Drawing.Size(114, 22);
            this._txtLongitudGradosB.TabIndex = 22;
            this._txtLongitudGradosB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLongitudGradosB.Validating += new System.ComponentModel.CancelEventHandler(this._txtLongitudGradosB_Validating);
            // 
            // _txtLatitudGradosA
            // 
            this._txtLatitudGradosA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLatitudGradosA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudGradosA.Location = new System.Drawing.Point(611, 80);
            this._txtLatitudGradosA.Mask = "00° 00\' 00.00\'\'";
            this._txtLatitudGradosA.Name = "_txtLatitudGradosA";
            this._txtLatitudGradosA.Size = new System.Drawing.Size(104, 22);
            this._txtLatitudGradosA.TabIndex = 10;
            this._txtLatitudGradosA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLatitudGradosA.Validating += new System.ComponentModel.CancelEventHandler(this._txtLatitudGradosA_Validating);
            // 
            // _txtLongitudGradosA
            // 
            this._txtLongitudGradosA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLongitudGradosA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudGradosA.Location = new System.Drawing.Point(714, 80);
            this._txtLongitudGradosA.Mask = "00° 00\' 00.00\'\'";
            this._txtLongitudGradosA.Name = "_txtLongitudGradosA";
            this._txtLongitudGradosA.Size = new System.Drawing.Size(114, 22);
            this._txtLongitudGradosA.TabIndex = 13;
            this._txtLongitudGradosA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLongitudGradosA.Validating += new System.ComponentModel.CancelEventHandler(this._txtLongitudGradosA_Validating);
            // 
            // _cmbDepartamentoB
            // 
            this._cmbDepartamentoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDepartamentoB.EnterComoTab = false;
            this._cmbDepartamentoB.Etiqueta = null;
            this._cmbDepartamentoB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbDepartamentoB.FormattingEnabled = true;
            this._cmbDepartamentoB.Location = new System.Drawing.Point(459, 101);
            this._cmbDepartamentoB.Name = "_cmbDepartamentoB";
            this._cmbDepartamentoB.Size = new System.Drawing.Size(153, 24);
            this._cmbDepartamentoB.TabIndex = 18;
            this._cmbDepartamentoB.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // _cmbDepartamentoA
            // 
            this._cmbDepartamentoA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDepartamentoA.EnterComoTab = false;
            this._cmbDepartamentoA.Etiqueta = null;
            this._cmbDepartamentoA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbDepartamentoA.FormattingEnabled = true;
            this._cmbDepartamentoA.Location = new System.Drawing.Point(459, 80);
            this._cmbDepartamentoA.Name = "_cmbDepartamentoA";
            this._cmbDepartamentoA.Size = new System.Drawing.Size(153, 24);
            this._cmbDepartamentoA.TabIndex = 7;
            this._cmbDepartamentoA.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            // 
            // _txtLocalidadB
            // 
            this._txtLocalidadB.BackColor = System.Drawing.Color.White;
            this._txtLocalidadB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLocalidadB.EnterComoTab = true;
            this._txtLocalidadB.Etiqueta = null;
            this._txtLocalidadB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLocalidadB.Location = new System.Drawing.Point(255, 101);
            this._txtLocalidadB.MaxLength = 500;
            this._txtLocalidadB.Name = "_txtLocalidadB";
            this._txtLocalidadB.Size = new System.Drawing.Size(205, 22);
            this._txtLocalidadB.TabIndex = 17;
            this._txtLocalidadB.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LOCALIDAD";
            // 
            // _txtLocalidadA
            // 
            this._txtLocalidadA.BackColor = System.Drawing.Color.White;
            this._txtLocalidadA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLocalidadA.EnterComoTab = true;
            this._txtLocalidadA.Etiqueta = null;
            this._txtLocalidadA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLocalidadA.Location = new System.Drawing.Point(255, 80);
            this._txtLocalidadA.MaxLength = 500;
            this._txtLocalidadA.Name = "_txtLocalidadA";
            this._txtLocalidadA.Size = new System.Drawing.Size(205, 22);
            this._txtLocalidadA.TabIndex = 5;
            this._txtLocalidadA.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LOCALIDAD";
            // 
            // _txtSubestacionB
            // 
            this._txtSubestacionB.BackColor = System.Drawing.Color.White;
            this._txtSubestacionB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtSubestacionB.EnterComoTab = true;
            this._txtSubestacionB.Etiqueta = null;
            this._txtSubestacionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSubestacionB.Location = new System.Drawing.Point(2, 101);
            this._txtSubestacionB.MaxLength = 500;
            this._txtSubestacionB.Name = "_txtSubestacionB";
            this._txtSubestacionB.Size = new System.Drawing.Size(255, 22);
            this._txtSubestacionB.TabIndex = 16;
            this._txtSubestacionB.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.SUBESTACION";
            // 
            // _txtSubestacionA
            // 
            this._txtSubestacionA.BackColor = System.Drawing.Color.White;
            this._txtSubestacionA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtSubestacionA.EnterComoTab = true;
            this._txtSubestacionA.Etiqueta = null;
            this._txtSubestacionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSubestacionA.Location = new System.Drawing.Point(2, 80);
            this._txtSubestacionA.MaxLength = 500;
            this._txtSubestacionA.Name = "_txtSubestacionA";
            this._txtSubestacionA.Size = new System.Drawing.Size(255, 22);
            this._txtSubestacionA.TabIndex = 3;
            this._txtSubestacionA.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.SUBESTACION";
            // 
            // _txtLatitudA
            // 
            this._txtLatitudA.AceptaNegativo = false;
            this._txtLatitudA.BackColor = System.Drawing.Color.White;
            this._txtLatitudA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLatitudA.EnterComoTab = true;
            this._txtLatitudA.Etiqueta = null;
            this._txtLatitudA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudA.Location = new System.Drawing.Point(611, 80);
            this._txtLatitudA.MaxDigitosDecimales = 0;
            this._txtLatitudA.MaxDigitosEnteros = 0;
            this._txtLatitudA.MaxLength = 30;
            this._txtLatitudA.Name = "_txtLatitudA";
            this._txtLatitudA.Size = new System.Drawing.Size(104, 22);
            this._txtLatitudA.TabIndex = 9;
            this._txtLatitudA.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LATITUD_UTM";
            this._txtLatitudA.Text = "0";
            this._txtLatitudA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLatitudA.UsarFormatoNumerico = true;
            this._txtLatitudA.ValDouble = 0D;
            this._txtLatitudA.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLatitudA.ValorDouble = 0D;
            this._txtLatitudA.ValorFloat = 0F;
            this._txtLatitudA.ValorInt = 0;
            this._txtLatitudA.ValorLong = ((long)(0));
            this._txtLatitudA.Value = 0F;
            // 
            // _txtLatitudB
            // 
            this._txtLatitudB.AceptaNegativo = false;
            this._txtLatitudB.BackColor = System.Drawing.Color.White;
            this._txtLatitudB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLatitudB.EnterComoTab = true;
            this._txtLatitudB.Etiqueta = null;
            this._txtLatitudB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLatitudB.Location = new System.Drawing.Point(611, 101);
            this._txtLatitudB.MaxDigitosDecimales = 0;
            this._txtLatitudB.MaxDigitosEnteros = 0;
            this._txtLatitudB.MaxLength = 30;
            this._txtLatitudB.Name = "_txtLatitudB";
            this._txtLatitudB.Size = new System.Drawing.Size(104, 22);
            this._txtLatitudB.TabIndex = 19;
            this._txtLatitudB.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LATITUD_UTM";
            this._txtLatitudB.Text = "0";
            this._txtLatitudB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLatitudB.UsarFormatoNumerico = true;
            this._txtLatitudB.ValDouble = 0D;
            this._txtLatitudB.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLatitudB.ValorDouble = 0D;
            this._txtLatitudB.ValorFloat = 0F;
            this._txtLatitudB.ValorInt = 0;
            this._txtLatitudB.ValorLong = ((long)(0));
            this._txtLatitudB.Value = 0F;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cndcLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel3.Location = new System.Drawing.Point(827, 60);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(116, 21);
            this.cndcLabel3.TabIndex = 14;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Altitud (m.s.n.m)";
            this.cndcLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblLongitudGrados
            // 
            this._lblLongitudGrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblLongitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLongitudGrados.Location = new System.Drawing.Point(714, 60);
            this._lblLongitudGrados.Name = "_lblLongitudGrados";
            this._lblLongitudGrados.Size = new System.Drawing.Size(114, 21);
            this._lblLongitudGrados.TabIndex = 4;
            this._lblLongitudGrados.TablaCampoBD = null;
            this._lblLongitudGrados.Text = "Longitud Oeste";
            this._lblLongitudGrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblLatitudGrados
            // 
            this._lblLatitudGrados.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this._lblLatitudGrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblLatitudGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLatitudGrados.Location = new System.Drawing.Point(611, 60);
            this._lblLatitudGrados.Name = "_lblLatitudGrados";
            this._lblLatitudGrados.Size = new System.Drawing.Size(104, 21);
            this._lblLatitudGrados.TabIndex = 3;
            this._lblLatitudGrados.TablaCampoBD = null;
            this._lblLatitudGrados.Text = "Latitud Sur";
            this._lblLatitudGrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 21);
            this.label4.TabIndex = 6;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Departamento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtAltitudA
            // 
            this._txtAltitudA.AceptaNegativo = false;
            this._txtAltitudA.BackColor = System.Drawing.Color.White;
            this._txtAltitudA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtAltitudA.EnterComoTab = true;
            this._txtAltitudA.Etiqueta = null;
            this._txtAltitudA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAltitudA.Location = new System.Drawing.Point(827, 80);
            this._txtAltitudA.MaxDigitosDecimales = 0;
            this._txtAltitudA.MaxDigitosEnteros = 0;
            this._txtAltitudA.MaxLength = 30;
            this._txtAltitudA.Name = "_txtAltitudA";
            this._txtAltitudA.Size = new System.Drawing.Size(116, 22);
            this._txtAltitudA.TabIndex = 15;
            this._txtAltitudA.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.ALTITUD";
            this._txtAltitudA.Text = "0";
            this._txtAltitudA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtAltitudA.UsarFormatoNumerico = true;
            this._txtAltitudA.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtAltitudA.ValorDouble = 0D;
            this._txtAltitudA.ValorFloat = 0F;
            this._txtAltitudA.ValorInt = 0;
            this._txtAltitudA.ValorLong = ((long)(0));
            this._txtAltitudA.Value = 0;
            // 
            // _txtAltitudB
            // 
            this._txtAltitudB.AceptaNegativo = false;
            this._txtAltitudB.BackColor = System.Drawing.Color.White;
            this._txtAltitudB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtAltitudB.EnterComoTab = true;
            this._txtAltitudB.Etiqueta = null;
            this._txtAltitudB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAltitudB.Location = new System.Drawing.Point(827, 101);
            this._txtAltitudB.MaxDigitosDecimales = 0;
            this._txtAltitudB.MaxDigitosEnteros = 0;
            this._txtAltitudB.MaxLength = 30;
            this._txtAltitudB.Name = "_txtAltitudB";
            this._txtAltitudB.Size = new System.Drawing.Size(116, 22);
            this._txtAltitudB.TabIndex = 23;
            this._txtAltitudB.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.ALTITUD";
            this._txtAltitudB.Text = "0";
            this._txtAltitudB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtAltitudB.UsarFormatoNumerico = true;
            this._txtAltitudB.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtAltitudB.ValorDouble = 0D;
            this._txtAltitudB.ValorFloat = 0F;
            this._txtAltitudB.ValorInt = 0;
            this._txtAltitudB.ValorLong = ((long)(0));
            this._txtAltitudB.Value = 0;
            // 
            // _txtLongitudA
            // 
            this._txtLongitudA.AceptaNegativo = false;
            this._txtLongitudA.BackColor = System.Drawing.Color.White;
            this._txtLongitudA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLongitudA.EnterComoTab = true;
            this._txtLongitudA.Etiqueta = null;
            this._txtLongitudA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudA.Location = new System.Drawing.Point(714, 80);
            this._txtLongitudA.MaxDigitosDecimales = 0;
            this._txtLongitudA.MaxDigitosEnteros = 0;
            this._txtLongitudA.MaxLength = 30;
            this._txtLongitudA.Name = "_txtLongitudA";
            this._txtLongitudA.Size = new System.Drawing.Size(114, 22);
            this._txtLongitudA.TabIndex = 12;
            this._txtLongitudA.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LONGITUD_UTM";
            this._txtLongitudA.Text = "0";
            this._txtLongitudA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLongitudA.UsarFormatoNumerico = true;
            this._txtLongitudA.ValDouble = 0D;
            this._txtLongitudA.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLongitudA.ValorDouble = 0D;
            this._txtLongitudA.ValorFloat = 0F;
            this._txtLongitudA.ValorInt = 0;
            this._txtLongitudA.ValorLong = ((long)(0));
            this._txtLongitudA.Value = 0F;
            // 
            // _txtLongitudB
            // 
            this._txtLongitudB.AceptaNegativo = false;
            this._txtLongitudB.BackColor = System.Drawing.Color.White;
            this._txtLongitudB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtLongitudB.EnterComoTab = true;
            this._txtLongitudB.Etiqueta = null;
            this._txtLongitudB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtLongitudB.Location = new System.Drawing.Point(714, 101);
            this._txtLongitudB.MaxDigitosDecimales = 0;
            this._txtLongitudB.MaxDigitosEnteros = 0;
            this._txtLongitudB.MaxLength = 30;
            this._txtLongitudB.Name = "_txtLongitudB";
            this._txtLongitudB.Size = new System.Drawing.Size(114, 22);
            this._txtLongitudB.TabIndex = 21;
            this._txtLongitudB.TablaCampoBD = "F_PR_LOCAL_PROYS_TRANSMISION.LONGITUD_UTM";
            this._txtLongitudB.Text = "0";
            this._txtLongitudB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtLongitudB.UsarFormatoNumerico = true;
            this._txtLongitudB.ValDouble = 0D;
            this._txtLongitudB.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtLongitudB.ValorDouble = 0D;
            this._txtLongitudB.ValorFloat = 0F;
            this._txtLongitudB.ValorInt = 0;
            this._txtLongitudB.ValorLong = ((long)(0));
            this._txtLongitudB.Value = 0F;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 21);
            this.label2.TabIndex = 4;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Localidad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 21);
            this.label1.TabIndex = 2;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Subestación";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _gbxLatitud
            // 
            this._gbxLatitud.Controls.Add(this._rbtUTM);
            this._gbxLatitud.Controls.Add(this._rbtGrados);
            this._gbxLatitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gbxLatitud.Location = new System.Drawing.Point(613, 25);
            this._gbxLatitud.Name = "_gbxLatitud";
            this._gbxLatitud.Size = new System.Drawing.Size(200, 31);
            this._gbxLatitud.TabIndex = 1;
            this._gbxLatitud.TablaCampoBD = null;
            this._gbxLatitud.TabStop = false;
            this._gbxLatitud.Text = "Grados o UTM";
            // 
            // _rbtUTM
            // 
            this._rbtUTM.AutoSize = true;
            this._rbtUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbtUTM.Location = new System.Drawing.Point(124, 11);
            this._rbtUTM.Name = "_rbtUTM";
            this._rbtUTM.Size = new System.Drawing.Size(49, 17);
            this._rbtUTM.TabIndex = 1;
            this._rbtUTM.TablaCampoBD = null;
            this._rbtUTM.TabStop = true;
            this._rbtUTM.Text = "UTM";
            this._rbtUTM.UseVisualStyleBackColor = true;
            this._rbtUTM.CheckedChanged += new System.EventHandler(this._rbtUTM_CheckedChanged);
            // 
            // _rbtGrados
            // 
            this._rbtGrados.AutoSize = true;
            this._rbtGrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbtGrados.Location = new System.Drawing.Point(27, 11);
            this._rbtGrados.Name = "_rbtGrados";
            this._rbtGrados.Size = new System.Drawing.Size(59, 17);
            this._rbtGrados.TabIndex = 0;
            this._rbtGrados.TablaCampoBD = null;
            this._rbtGrados.Text = "Grados";
            this._rbtGrados.UseVisualStyleBackColor = true;
            this._rbtGrados.CheckedChanged += new System.EventHandler(this._rbtGrados_CheckedChanged);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlLocalizacionDeProysDeTransmision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._gbxLocalizacion);
            this.Name = "CtrlLocalizacionDeProysDeTransmision";
            this.Size = new System.Drawing.Size(970, 140);
            this._gbxLocalizacion.ResumeLayout(false);
            this._gbxLocalizacion.PerformLayout();
            this._gbxLatitud.ResumeLayout(false);
            this._gbxLatitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGroupBox _gbxLocalizacion;
        private Controles.CNDCGroupBox _gbxLatitud;
        private Controles.CNDCRadioButton _rbtUTM;
        private Controles.CNDCRadioButton _rbtGrados;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCTextBoxFloat _txtLatitudA;
        private Controles.CNDCTextBoxFloat _txtLatitudB;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCLabel _lblLongitudGrados;
        private Controles.CNDCLabel _lblLatitudGrados;
        private Controles.CNDCLabel label4;
        private Controles.CNDCTextBoxInt _txtAltitudA;
        private Controles.CNDCTextBoxInt _txtAltitudB;
        private Controles.CNDCTextBoxFloat _txtLongitudA;
        private Controles.CNDCTextBoxFloat _txtLongitudB;
        private Controles.CNDCLabel label2;
        private Controles.CNDCLabel label1;
        private Controles.CNDCTextBox _txtLocalidadB;
        private Controles.CNDCTextBox _txtLocalidadA;
        private Controles.CNDCTextBox _txtSubestacionB;
        private Controles.CNDCTextBox _txtSubestacionA;
        private Controles.CNDCComboBox _cmbDepartamentoB;
        private Controles.CNDCComboBox _cmbDepartamentoA;
        private System.Windows.Forms.MaskedTextBox _txtLatitudGradosB;
        private System.Windows.Forms.MaskedTextBox _txtLongitudGradosB;
        private System.Windows.Forms.MaskedTextBox _txtLatitudGradosA;
        private System.Windows.Forms.MaskedTextBox _txtLongitudGradosA;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCLabel _lblUTMLongitud;
        private Controles.CNDCLabel _lblUTMLatitud;

    }
}
