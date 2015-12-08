namespace SISFALLA
{
    partial class ABMRegistroFallaForm
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
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this.cndcLabelControl5 = new Controles.CNDCLabel();
            this._txtDescripcionFalla = new Controles.CNDCTextBox();
            this._txtOtrosDestinatarios = new Controles.CNDCTextBox();
            this.cndcLabelControl6 = new Controles.CNDCLabel();
            this._cmbOrigen = new Controles.CNDCComboBox();
            this._cmbTipoDesconexion = new Controles.CNDCComboBox();
            this.cndcLabelControl7 = new Controles.CNDCLabel();
            this._cmbCausa = new Controles.CNDCComboBox();
            this.cndcLabelControl8 = new Controles.CNDCLabel();
            this._cmbOperador = new Controles.CNDCComboBox();
            this.cndcLabelControl9 = new Controles.CNDCLabel();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this._lblSupervisor = new Controles.CNDCLabel();
            this.cndcLabelControl10 = new Controles.CNDCLabel();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this._txtFechaHoraFalla = new Controles.CNDCTextBoxDateTime();
            this._btnAgentesNotificar = new Controles.CNDCButton();
            this._rbtnDeficit = new Controles.CNDCRadioButton();
            this._rbtnFalla = new Controles.CNDCRadioButton();
            this._pnlBotonesRadio = new Controles.CNDCPanelControl();
            this._cmbProblemasGen = new Controles.CNDCComboBox();
            this._lblProbGen = new Controles.CNDCLabel();
            this._txtNumeroFalla = new SISFALLA.TxtNumeroFalla();
            this._ctrlComponenteComprometido = new SISFALLA.CtrlComponente();
            this._ctrlAgentesInvolucrados = new SISFALLA.CtrlAgentesInvolucrados();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._pnlBotonesRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl1.Location = new System.Drawing.Point(57, 55);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(90, 16);
            this.cndcLabelControl1.TabIndex = 1;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Número de Falla:";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.Location = new System.Drawing.Point(25, 77);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(122, 16);
            this.cndcLabelControl2.TabIndex = 3;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "Fecha y hora de la falla:";
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl3.Location = new System.Drawing.Point(55, 146);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(92, 16);
            this.cndcLabelControl3.TabIndex = 9;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Descripción Falla:";
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl5.Location = new System.Drawing.Point(34, 504);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(183, 22);
            this.cndcLabelControl5.TabIndex = 25;
            this.cndcLabelControl5.TablaCampoBD = null;
            this.cndcLabelControl5.Text = "Otros destinatarios (separados por;):";
            // 
            // _txtDescripcionFalla
            // 
            this._txtDescripcionFalla.AcceptsReturn = true;
            this._txtDescripcionFalla.EnterComoTab = false;
            this._txtDescripcionFalla.Etiqueta = null;
            this._txtDescripcionFalla.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDescripcionFalla.Location = new System.Drawing.Point(153, 146);
            this._txtDescripcionFalla.Multiline = true;
            this._txtDescripcionFalla.Name = "_txtDescripcionFalla";
            this._txtDescripcionFalla.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtDescripcionFalla.Size = new System.Drawing.Size(582, 45);
            this._txtDescripcionFalla.TabIndex = 10;
            this._txtDescripcionFalla.TablaCampoBD = "F_GF_REGFALLA.DESCRIPCION_FALLA";
            // 
            // _txtOtrosDestinatarios
            // 
            this._txtOtrosDestinatarios.EnterComoTab = false;
            this._txtOtrosDestinatarios.Etiqueta = null;
            this._txtOtrosDestinatarios.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtOtrosDestinatarios.Location = new System.Drawing.Point(220, 504);
            this._txtOtrosDestinatarios.Name = "_txtOtrosDestinatarios";
            this._txtOtrosDestinatarios.Size = new System.Drawing.Size(589, 22);
            this._txtOtrosDestinatarios.TabIndex = 26;
            this._txtOtrosDestinatarios.TablaCampoBD = null;
            // 
            // cndcLabelControl6
            // 
            this.cndcLabelControl6.AutoSize = true;
            this.cndcLabelControl6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl6.Location = new System.Drawing.Point(104, 196);
            this.cndcLabelControl6.Name = "cndcLabelControl6";
            this.cndcLabelControl6.Size = new System.Drawing.Size(43, 16);
            this.cndcLabelControl6.TabIndex = 11;
            this.cndcLabelControl6.TablaCampoBD = null;
            this.cndcLabelControl6.Text = "Origen:";
            // 
            // _cmbOrigen
            // 
            this._cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbOrigen.EnterComoTab = true;
            this._cmbOrigen.Etiqueta = null;
            this._cmbOrigen.FormattingEnabled = true;
            this._cmbOrigen.Location = new System.Drawing.Point(153, 194);
            this._cmbOrigen.Name = "_cmbOrigen";
            this._cmbOrigen.Size = new System.Drawing.Size(290, 21);
            this._cmbOrigen.TabIndex = 12;
            this._cmbOrigen.TablaCampoBD = "F_GF_REGFALLA.D_COD_ORIGEN";
            // 
            // _cmbTipoDesconexion
            // 
            this._cmbTipoDesconexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoDesconexion.EnterComoTab = true;
            this._cmbTipoDesconexion.Etiqueta = null;
            this._cmbTipoDesconexion.FormattingEnabled = true;
            this._cmbTipoDesconexion.Location = new System.Drawing.Point(153, 217);
            this._cmbTipoDesconexion.Name = "_cmbTipoDesconexion";
            this._cmbTipoDesconexion.Size = new System.Drawing.Size(290, 21);
            this._cmbTipoDesconexion.TabIndex = 14;
            this._cmbTipoDesconexion.TablaCampoBD = "F_GF_REGFALLA.D_COD_TIPO_DESCONEXION";
            // 
            // cndcLabelControl7
            // 
            this.cndcLabelControl7.AutoSize = true;
            this.cndcLabelControl7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl7.Location = new System.Drawing.Point(50, 219);
            this.cndcLabelControl7.Name = "cndcLabelControl7";
            this.cndcLabelControl7.Size = new System.Drawing.Size(97, 16);
            this.cndcLabelControl7.TabIndex = 13;
            this.cndcLabelControl7.TablaCampoBD = null;
            this.cndcLabelControl7.Text = "Tipo Desconexión:";
            // 
            // _cmbCausa
            // 
            this._cmbCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCausa.EnterComoTab = true;
            this._cmbCausa.Etiqueta = null;
            this._cmbCausa.FormattingEnabled = true;
            this._cmbCausa.Location = new System.Drawing.Point(518, 222);
            this._cmbCausa.Name = "_cmbCausa";
            this._cmbCausa.Size = new System.Drawing.Size(290, 21);
            this._cmbCausa.TabIndex = 16;
            this._cmbCausa.TablaCampoBD = "F_GF_REGFALLA.D_COD_CAUSA";
            // 
            // cndcLabelControl8
            // 
            this.cndcLabelControl8.AutoSize = true;
            this.cndcLabelControl8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl8.Location = new System.Drawing.Point(470, 219);
            this.cndcLabelControl8.Name = "cndcLabelControl8";
            this.cndcLabelControl8.Size = new System.Drawing.Size(42, 16);
            this.cndcLabelControl8.TabIndex = 15;
            this.cndcLabelControl8.TablaCampoBD = null;
            this.cndcLabelControl8.Text = "Causa:";
            // 
            // _cmbOperador
            // 
            this._cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbOperador.EnterComoTab = true;
            this._cmbOperador.Etiqueta = null;
            this._cmbOperador.FormattingEnabled = true;
            this._cmbOperador.Location = new System.Drawing.Point(518, 245);
            this._cmbOperador.Name = "_cmbOperador";
            this._cmbOperador.Size = new System.Drawing.Size(290, 21);
            this._cmbOperador.TabIndex = 20;
            this._cmbOperador.TablaCampoBD = "F_GF_REGFALLA.FK_COD_OPERADOR";
            // 
            // cndcLabelControl9
            // 
            this.cndcLabelControl9.AutoSize = true;
            this.cndcLabelControl9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl9.Location = new System.Drawing.Point(64, 243);
            this.cndcLabelControl9.Name = "cndcLabelControl9";
            this.cndcLabelControl9.Size = new System.Drawing.Size(84, 16);
            this.cndcLabelControl9.TabIndex = 17;
            this.cndcLabelControl9.TablaCampoBD = null;
            this.cndcLabelControl9.Text = "Ing. Supervisor:";
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.Location = new System.Drawing.Point(455, 243);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(57, 16);
            this.cndcLabelControl4.TabIndex = 19;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Operador:";
            // 
            // _lblSupervisor
            // 
            this._lblSupervisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblSupervisor.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSupervisor.Location = new System.Drawing.Point(153, 240);
            this._lblSupervisor.Name = "_lblSupervisor";
            this._lblSupervisor.Size = new System.Drawing.Size(290, 21);
            this._lblSupervisor.TabIndex = 18;
            this._lblSupervisor.TablaCampoBD = null;
            this._lblSupervisor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cndcLabelControl10
            // 
            this.cndcLabelControl10.AutoSize = true;
            this.cndcLabelControl10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl10.Location = new System.Drawing.Point(81, 124);
            this.cndcLabelControl10.Name = "cndcLabelControl10";
            this.cndcLabelControl10.Size = new System.Drawing.Size(66, 16);
            this.cndcLabelControl10.TabIndex = 7;
            this.cndcLabelControl10.TablaCampoBD = null;
            this.cndcLabelControl10.Text = "Descripción:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = true;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._txtDescripcion.Location = new System.Drawing.Point(153, 124);
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(582, 20);
            this._txtDescripcion.TabIndex = 8;
            this._txtDescripcion.TablaCampoBD = "F_GF_REGFALLA.DESCRIPCION";
            // 
            // _txtFechaHoraFalla
            // 
            this._txtFechaHoraFalla.Etiqueta = null;
            this._txtFechaHoraFalla.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtFechaHoraFalla.Location = new System.Drawing.Point(153, 77);
            this._txtFechaHoraFalla.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraFalla.Name = "_txtFechaHoraFalla";
            this._txtFechaHoraFalla.Size = new System.Drawing.Size(135, 21);
            this._txtFechaHoraFalla.TabIndex = 4;
            this._txtFechaHoraFalla.TablaCampoBD = "F_GF_REGFALLA.FEC_INICIO";
            this._txtFechaHoraFalla.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraFalla.ValidadorFormatoFecha = null;
            this._txtFechaHoraFalla.ValidadorIngresoOnline = null;
            this._txtFechaHoraFalla.Value = new System.DateTime(((long)(0)));
            this._txtFechaHoraFalla.TextChanged += new System.EventHandler(this._txtFechaHoraFalla_TextChanged);
            this._txtFechaHoraFalla.Validating += new System.ComponentModel.CancelEventHandler(this._txtFechaHoraFalla_Validating);
            // 
            // _btnAgentesNotificar
            // 
            this._btnAgentesNotificar.Location = new System.Drawing.Point(8, 267);
            this._btnAgentesNotificar.Margin = new System.Windows.Forms.Padding(0);
            this._btnAgentesNotificar.Name = "_btnAgentesNotificar";
            this._btnAgentesNotificar.Size = new System.Drawing.Size(145, 23);
            this._btnAgentesNotificar.TabIndex = 21;
            this._btnAgentesNotificar.TablaCampoBD = null;
            this._btnAgentesNotificar.Text = "Agentes a Notificar";
            this._btnAgentesNotificar.UseVisualStyleBackColor = true;
            this._btnAgentesNotificar.Click += new System.EventHandler(this._btnAgentesNotificar_Click);
            // 
            // _rbtnDeficit
            // 
            this._rbtnDeficit.AutoSize = true;
            this._rbtnDeficit.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._rbtnDeficit.ForeColor = System.Drawing.Color.Black;
            this._rbtnDeficit.Location = new System.Drawing.Point(77, 0);
            this._rbtnDeficit.Name = "_rbtnDeficit";
            this._rbtnDeficit.Size = new System.Drawing.Size(149, 20);
            this._rbtnDeficit.TabIndex = 1;
            this._rbtnDeficit.TablaCampoBD = null;
            this._rbtnDeficit.Text = "Problemas de Generación";
            this._rbtnDeficit.UseVisualStyleBackColor = true;
            this._rbtnDeficit.CheckedChanged += new System.EventHandler(this._rbtnFalla_CheckedChanged);
            // 
            // _rbtnFalla
            // 
            this._rbtnFalla.AutoSize = true;
            this._rbtnFalla.Checked = true;
            this._rbtnFalla.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._rbtnFalla.ForeColor = System.Drawing.Color.Black;
            this._rbtnFalla.Location = new System.Drawing.Point(3, 0);
            this._rbtnFalla.Name = "_rbtnFalla";
            this._rbtnFalla.Size = new System.Drawing.Size(49, 20);
            this._rbtnFalla.TabIndex = 0;
            this._rbtnFalla.TablaCampoBD = null;
            this._rbtnFalla.TabStop = true;
            this._rbtnFalla.Text = "Falla";
            this._rbtnFalla.UseVisualStyleBackColor = true;
            this._rbtnFalla.CheckedChanged += new System.EventHandler(this._rbtnFalla_CheckedChanged);
            // 
            // _pnlBotonesRadio
            // 
            this._pnlBotonesRadio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlBotonesRadio.Controls.Add(this._rbtnFalla);
            this._pnlBotonesRadio.Controls.Add(this._rbtnDeficit);
            this._pnlBotonesRadio.ForeColor = System.Drawing.Color.Black;
            this._pnlBotonesRadio.Location = new System.Drawing.Point(54, 28);
            this._pnlBotonesRadio.Name = "_pnlBotonesRadio";
            this._pnlBotonesRadio.Size = new System.Drawing.Size(234, 22);
            this._pnlBotonesRadio.TabIndex = 0;
            this._pnlBotonesRadio.TablaCampoBD = null;
            // 
            // _cmbProblemasGen
            // 
            this._cmbProblemasGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbProblemasGen.EnterComoTab = true;
            this._cmbProblemasGen.Etiqueta = this._lblProbGen;
            this._cmbProblemasGen.FormattingEnabled = true;
            this._cmbProblemasGen.Location = new System.Drawing.Point(153, 101);
            this._cmbProblemasGen.Name = "_cmbProblemasGen";
            this._cmbProblemasGen.Size = new System.Drawing.Size(297, 21);
            this._cmbProblemasGen.TabIndex = 28;
            this._cmbProblemasGen.TablaCampoBD = "F_GF_REGFALLA.D_COD_ORIGEN";
            this._cmbProblemasGen.Visible = false;
            // 
            // _lblProbGen
            // 
            this._lblProbGen.AutoSize = true;
            this._lblProbGen.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblProbGen.Location = new System.Drawing.Point(13, 103);
            this._lblProbGen.Name = "_lblProbGen";
            this._lblProbGen.Size = new System.Drawing.Size(134, 16);
            this._lblProbGen.TabIndex = 27;
            this._lblProbGen.TablaCampoBD = null;
            this._lblProbGen.Text = "Problemas de Generación:";
            this._lblProbGen.Visible = false;
            // 
            // _txtNumeroFalla
            // 
            this._txtNumeroFalla.EnterComoTab = true;
            this._txtNumeroFalla.Location = new System.Drawing.Point(153, 54);
            this._txtNumeroFalla.Mask = "0000-00";
            this._txtNumeroFalla.Name = "_txtNumeroFalla";
            this._txtNumeroFalla.Size = new System.Drawing.Size(64, 20);
            this._txtNumeroFalla.TabIndex = 2;
            this._txtNumeroFalla.TablaCampoBD = null;
            // 
            // _ctrlComponenteComprometido
            // 
            this._ctrlComponenteComprometido.AnchoBoton = 145;
            this._ctrlComponenteComprometido.Componente = null;
            this._ctrlComponenteComprometido.Location = new System.Drawing.Point(5, 100);
            this._ctrlComponenteComprometido.Name = "_ctrlComponenteComprometido";
            this._ctrlComponenteComprometido.PkCodComponente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._ctrlComponenteComprometido.Size = new System.Drawing.Size(730, 21);
            this._ctrlComponenteComprometido.TabIndex = 6;
            this._ctrlComponenteComprometido.TextoBoton = "Componente Fallado";
            // 
            // _ctrlAgentesInvolucrados
            // 
            this._ctrlAgentesInvolucrados.Location = new System.Drawing.Point(9, 292);
            this._ctrlAgentesInvolucrados.Name = "_ctrlAgentesInvolucrados";
            this._ctrlAgentesInvolucrados.Size = new System.Drawing.Size(800, 209);
            this._ctrlAgentesInvolucrados.TabIndex = 29;
            // 
            // ABMRegistroFallaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 552);
            this.Controls.Add(this._ctrlAgentesInvolucrados);
            this.Controls.Add(this._cmbProblemasGen);
            this.Controls.Add(this._lblProbGen);
            this.Controls.Add(this._txtNumeroFalla);
            this.Controls.Add(this._pnlBotonesRadio);
            this.Controls.Add(this._btnAgentesNotificar);
            this.Controls.Add(this._txtFechaHoraFalla);
            this.Controls.Add(this._ctrlComponenteComprometido);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabelControl10);
            this.Controls.Add(this._lblSupervisor);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._cmbOperador);
            this.Controls.Add(this.cndcLabelControl9);
            this.Controls.Add(this._cmbCausa);
            this.Controls.Add(this.cndcLabelControl8);
            this.Controls.Add(this._cmbTipoDesconexion);
            this.Controls.Add(this.cndcLabelControl7);
            this.Controls.Add(this._cmbOrigen);
            this.Controls.Add(this.cndcLabelControl6);
            this.Controls.Add(this._txtOtrosDestinatarios);
            this.Controls.Add(this._txtDescripcionFalla);
            this.Controls.Add(this.cndcLabelControl5);
            this.Controls.Add(this.cndcLabelControl3);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this.cndcLabelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ABMRegistroFallaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de falla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ABMRegistroFallaForm_FormClosing);
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl2, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl3, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl5, 0);
            this.Controls.SetChildIndex(this._txtDescripcionFalla, 0);
            this.Controls.SetChildIndex(this._txtOtrosDestinatarios, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl6, 0);
            this.Controls.SetChildIndex(this._cmbOrigen, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl7, 0);
            this.Controls.SetChildIndex(this._cmbTipoDesconexion, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl8, 0);
            this.Controls.SetChildIndex(this._cmbCausa, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl9, 0);
            this.Controls.SetChildIndex(this._cmbOperador, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl4, 0);
            this.Controls.SetChildIndex(this._lblSupervisor, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl10, 0);
            this.Controls.SetChildIndex(this._txtDescripcion, 0);
            this.Controls.SetChildIndex(this._ctrlComponenteComprometido, 0);
            this.Controls.SetChildIndex(this._txtFechaHoraFalla, 0);
            this.Controls.SetChildIndex(this._btnAgentesNotificar, 0);
            this.Controls.SetChildIndex(this._pnlBotonesRadio, 0);
            this.Controls.SetChildIndex(this._txtNumeroFalla, 0);
            this.Controls.SetChildIndex(this._lblProbGen, 0);
            this.Controls.SetChildIndex(this._cmbProblemasGen, 0);
            this.Controls.SetChildIndex(this._ctrlAgentesInvolucrados, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._pnlBotonesRadio.ResumeLayout(false);
            this._pnlBotonesRadio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCLabel cndcLabelControl5;
        private Controles.CNDCTextBox _txtDescripcionFalla;
        private Controles.CNDCTextBox _txtOtrosDestinatarios;
        private Controles.CNDCLabel cndcLabelControl6;
        private Controles.CNDCComboBox _cmbOrigen;
        private Controles.CNDCComboBox _cmbTipoDesconexion;
        private Controles.CNDCLabel cndcLabelControl7;
        private Controles.CNDCComboBox _cmbCausa;
        private Controles.CNDCLabel cndcLabelControl8;
        private Controles.CNDCComboBox _cmbOperador;
        private Controles.CNDCLabel cndcLabelControl9;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCLabel _lblSupervisor;
        private Controles.CNDCLabel cndcLabelControl10;
        private Controles.CNDCTextBox _txtDescripcion;
        private CtrlComponente _ctrlComponenteComprometido;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraFalla;
        private Controles.CNDCButton _btnAgentesNotificar;
        private Controles.CNDCRadioButton _rbtnDeficit;
        private Controles.CNDCRadioButton _rbtnFalla;
        private Controles.CNDCPanelControl _pnlBotonesRadio;
        private TxtNumeroFalla _txtNumeroFalla;
        private Controles.CNDCComboBox _cmbProblemasGen;
        private Controles.CNDCLabel _lblProbGen;
        private CtrlAgentesInvolucrados _ctrlAgentesInvolucrados;
    }
}