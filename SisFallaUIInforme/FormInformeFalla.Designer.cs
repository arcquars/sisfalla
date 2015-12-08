namespace SISFALLA
{
    partial class FormInformeFalla
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
            this._tabcomponentes = new Controles.CNDCTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._txtOperacionProtecciones = new Controles.CNDCTextBox();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtInfAdicional = new Controles.CNDCTextBox();
            this._gpxProceRestitucion = new Controles.CNDCGroupBox();
            this._txtProcRestitucion = new Controles.CNDCTextBox();
            this._gpxDescripcionFalla = new Controles.CNDCGroupBox();
            this._txtDescripcionFalla = new Controles.CNDCTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlComponentesComprometidos1 = new SISFALLA.CtrlComponentesComprometidos();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlInterruptoresReles1 = new SISFALLA.CtrlInterruptoresReles();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlAlimentadores1 = new SISFALLA.CtrlAlimentadores();
            this._tabAnalisis = new System.Windows.Forms.TabPage();
            this.ctrlAnalisisFalla1 = new SISFALLA.CtrlAnalisisFalla();
            this._tabColapso = new System.Windows.Forms.TabPage();
            this.ctrlColapso1 = new SISFALLA.CtrlColapso();
            this._cbxCausa = new Controles.CNDCComboBox();
            this._cbxOrigen = new Controles.CNDCComboBox();
            this._cbxTipoDesconex = new Controles.CNDCComboBox();
            this._lblCausa = new Controles.CNDCLabel();
            this._lblElaboradoPor = new Controles.CNDCLabel();
            this._txtTipoInforme = new Controles.CNDCTextBox();
            this._lblTipoInforme = new Controles.CNDCLabel();
            this._txtNumFallaAgente = new Controles.CNDCTextBox();
            this._lblNumFallaAgente = new Controles.CNDCLabel();
            this._lblTipoDesconex = new Controles.CNDCLabel();
            this._lblOrigen = new Controles.CNDCLabel();
            this._lblAgente = new Controles.CNDCLabel();
            this._lblProblemasGen = new Controles.CNDCLabel();
            this._lblFecHoraInforme = new Controles.CNDCLabel();
            this._txtFecHoraFalla = new Controles.CNDCTextBox();
            this._lblFecHoraFalla = new Controles.CNDCLabel();
            this._gpxInfGeneral = new Controles.CNDCGroupBox();
            this._tStripInformeFalla = new Controles.CNDCToolStrip();
            this._tbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this._tbtnCancelar = new System.Windows.Forms.ToolStripButton();
            this._tbtnDocAnalisis = new System.Windows.Forms.ToolStripButton();
            this._cmbProblemasGen = new Controles.CNDCComboBox();
            this._ctrlComponenteComprometido = new SISFALLA.CtrlComponente();
            this._txtElaboradoPor = new Controles.CNDCTextBox();
            this._txtAgente = new Controles.CNDCTextBox();
            this._txtFechaHoraInforme = new Controles.CNDCTextBox();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._rbtnFalla = new Controles.CNDCRadioButton();
            this._rbtnDeficit = new Controles.CNDCRadioButton();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._txtNumFalla = new Controles.CNDCTextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._pnlComandos = new CNDC.BaseForms.PanelComandos();
            this._tabcomponentes.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            this.cndcGroupBox1.SuspendLayout();
            this._gpxProceRestitucion.SuspendLayout();
            this._gpxDescripcionFalla.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this._tabAnalisis.SuspendLayout();
            this._tabColapso.SuspendLayout();
            this._gpxInfGeneral.SuspendLayout();
            this._tStripInformeFalla.SuspendLayout();
            this.cndcPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabcomponentes
            // 
            this._tabcomponentes.Controls.Add(this.tabPage4);
            this._tabcomponentes.Controls.Add(this.tabPage1);
            this._tabcomponentes.Controls.Add(this.tabPage2);
            this._tabcomponentes.Controls.Add(this.tabPage3);
            this._tabcomponentes.Controls.Add(this._tabAnalisis);
            this._tabcomponentes.Controls.Add(this._tabColapso);
            this._tabcomponentes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tabcomponentes.Location = new System.Drawing.Point(0, 198);
            this._tabcomponentes.Name = "_tabcomponentes";
            this._tabcomponentes.SelectedIndex = 0;
            this._tabcomponentes.Size = new System.Drawing.Size(985, 460);
            this._tabcomponentes.TabIndex = 1;
            this._tabcomponentes.TablaCampoBD = null;
            this._tabcomponentes.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._tabcomponentes_Selecting);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cndcGroupBox2);
            this.tabPage4.Controls.Add(this.cndcGroupBox1);
            this.tabPage4.Controls.Add(this._gpxProceRestitucion);
            this.tabPage4.Controls.Add(this._gpxDescripcionFalla);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(977, 434);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "DESCRIPCIÓN";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.cndcGroupBox2.Controls.Add(this._txtOperacionProtecciones);
            this.cndcGroupBox2.Location = new System.Drawing.Point(5, 248);
            this.cndcGroupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cndcGroupBox2.Size = new System.Drawing.Size(964, 95);
            this.cndcGroupBox2.TabIndex = 3;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "OPERACIÓN DE PROTECCIONES";
            // 
            // _txtOperacionProtecciones
            // 
            this._txtOperacionProtecciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtOperacionProtecciones.EnterComoTab = false;
            this._txtOperacionProtecciones.Etiqueta = null;
            this._txtOperacionProtecciones.Location = new System.Drawing.Point(3, 16);
            this._txtOperacionProtecciones.Multiline = true;
            this._txtOperacionProtecciones.Name = "_txtOperacionProtecciones";
            this._txtOperacionProtecciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtOperacionProtecciones.Size = new System.Drawing.Size(939, 76);
            this._txtOperacionProtecciones.TabIndex = 0;
            this._txtOperacionProtecciones.TablaCampoBD = "F_GF_INFORMEFALLA.OPERACION_PROTECCIONES";
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.cndcGroupBox1.Controls.Add(this._txtInfAdicional);
            this.cndcGroupBox1.Location = new System.Drawing.Point(5, 349);
            this.cndcGroupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cndcGroupBox1.Size = new System.Drawing.Size(964, 83);
            this.cndcGroupBox1.TabIndex = 4;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "INFORMACIÓN ADICIONAL";
            // 
            // _txtInfAdicional
            // 
            this._txtInfAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtInfAdicional.EnterComoTab = false;
            this._txtInfAdicional.Etiqueta = null;
            this._txtInfAdicional.Location = new System.Drawing.Point(3, 16);
            this._txtInfAdicional.Multiline = true;
            this._txtInfAdicional.Name = "_txtInfAdicional";
            this._txtInfAdicional.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtInfAdicional.Size = new System.Drawing.Size(939, 64);
            this._txtInfAdicional.TabIndex = 0;
            this._txtInfAdicional.TablaCampoBD = "F_GF_INFORMEFALLA.INFORMACION_ADICIONAL";
            // 
            // _gpxProceRestitucion
            // 
            this._gpxProceRestitucion.BackColor = System.Drawing.SystemColors.Control;
            this._gpxProceRestitucion.Controls.Add(this._txtProcRestitucion);
            this._gpxProceRestitucion.Location = new System.Drawing.Point(5, 140);
            this._gpxProceRestitucion.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this._gpxProceRestitucion.Name = "_gpxProceRestitucion";
            this._gpxProceRestitucion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._gpxProceRestitucion.Size = new System.Drawing.Size(964, 105);
            this._gpxProceRestitucion.TabIndex = 2;
            this._gpxProceRestitucion.TablaCampoBD = null;
            this._gpxProceRestitucion.TabStop = false;
            this._gpxProceRestitucion.Text = "PROCEDIMIENTO DE RESTITUCIÓN";
            // 
            // _txtProcRestitucion
            // 
            this._txtProcRestitucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProcRestitucion.EnterComoTab = false;
            this._txtProcRestitucion.Etiqueta = null;
            this._txtProcRestitucion.Location = new System.Drawing.Point(3, 16);
            this._txtProcRestitucion.Multiline = true;
            this._txtProcRestitucion.Name = "_txtProcRestitucion";
            this._txtProcRestitucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtProcRestitucion.Size = new System.Drawing.Size(939, 86);
            this._txtProcRestitucion.TabIndex = 0;
            this._txtProcRestitucion.TablaCampoBD = "F_GF_INFORMEFALLA.RESTITUCION";
            // 
            // _gpxDescripcionFalla
            // 
            this._gpxDescripcionFalla.BackColor = System.Drawing.SystemColors.Control;
            this._gpxDescripcionFalla.Controls.Add(this._txtDescripcionFalla);
            this._gpxDescripcionFalla.Location = new System.Drawing.Point(5, 6);
            this._gpxDescripcionFalla.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this._gpxDescripcionFalla.Name = "_gpxDescripcionFalla";
            this._gpxDescripcionFalla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._gpxDescripcionFalla.Size = new System.Drawing.Size(964, 130);
            this._gpxDescripcionFalla.TabIndex = 1;
            this._gpxDescripcionFalla.TablaCampoBD = null;
            this._gpxDescripcionFalla.TabStop = false;
            this._gpxDescripcionFalla.Text = "DESCRIPCIÓN DE LA FALLA";
            // 
            // _txtDescripcionFalla
            // 
            this._txtDescripcionFalla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescripcionFalla.EnterComoTab = false;
            this._txtDescripcionFalla.Etiqueta = null;
            this._txtDescripcionFalla.Location = new System.Drawing.Point(3, 16);
            this._txtDescripcionFalla.Multiline = true;
            this._txtDescripcionFalla.Name = "_txtDescripcionFalla";
            this._txtDescripcionFalla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDescripcionFalla.Size = new System.Drawing.Size(939, 111);
            this._txtDescripcionFalla.TabIndex = 0;
            this._txtDescripcionFalla.TablaCampoBD = "F_GF_INFORMEFALLA.DESCRIPCION_INFORME";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlComponentesComprometidos1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "COMPONENTES COMPROMETIDOS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlComponentesComprometidos1
            // 
            this.ctrlComponentesComprometidos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlComponentesComprometidos1.Location = new System.Drawing.Point(3, 3);
            this.ctrlComponentesComprometidos1.Name = "ctrlComponentesComprometidos1";
            this.ctrlComponentesComprometidos1.Size = new System.Drawing.Size(971, 428);
            this.ctrlComponentesComprometidos1.SoloLectura = false;
            this.ctrlComponentesComprometidos1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlInterruptoresReles1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "INTERRUPTORES Y RELES";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlInterruptoresReles1
            // 
            this.ctrlInterruptoresReles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlInterruptoresReles1.Location = new System.Drawing.Point(3, 3);
            this.ctrlInterruptoresReles1.Name = "ctrlInterruptoresReles1";
            this.ctrlInterruptoresReles1.Size = new System.Drawing.Size(971, 428);
            this.ctrlInterruptoresReles1.SoloLectura = false;
            this.ctrlInterruptoresReles1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlAlimentadores1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(977, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ALIMENTADORES";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlAlimentadores1
            // 
            this.ctrlAlimentadores1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAlimentadores1.Location = new System.Drawing.Point(3, 3);
            this.ctrlAlimentadores1.Name = "ctrlAlimentadores1";
            this.ctrlAlimentadores1.Size = new System.Drawing.Size(971, 428);
            this.ctrlAlimentadores1.SoloLectura = false;
            this.ctrlAlimentadores1.TabIndex = 0;
            // 
            // _tabAnalisis
            // 
            this._tabAnalisis.Controls.Add(this.ctrlAnalisisFalla1);
            this._tabAnalisis.Location = new System.Drawing.Point(4, 22);
            this._tabAnalisis.Name = "_tabAnalisis";
            this._tabAnalisis.Padding = new System.Windows.Forms.Padding(3);
            this._tabAnalisis.Size = new System.Drawing.Size(977, 434);
            this._tabAnalisis.TabIndex = 4;
            this._tabAnalisis.Text = "ANÁLISIS";
            this._tabAnalisis.UseVisualStyleBackColor = true;
            // 
            // ctrlAnalisisFalla1
            // 
            this.ctrlAnalisisFalla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAnalisisFalla1.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnalisisFalla1.Name = "ctrlAnalisisFalla1";
            this.ctrlAnalisisFalla1.Size = new System.Drawing.Size(971, 428);
            this.ctrlAnalisisFalla1.SoloLectura = false;
            this.ctrlAnalisisFalla1.TabIndex = 0;
            // 
            // _tabColapso
            // 
            this._tabColapso.Controls.Add(this.ctrlColapso1);
            this._tabColapso.Location = new System.Drawing.Point(4, 22);
            this._tabColapso.Name = "_tabColapso";
            this._tabColapso.Padding = new System.Windows.Forms.Padding(3);
            this._tabColapso.Size = new System.Drawing.Size(977, 434);
            this._tabColapso.TabIndex = 5;
            this._tabColapso.Text = "COLAPSO";
            this._tabColapso.UseVisualStyleBackColor = true;
            // 
            // ctrlColapso1
            // 
            this.ctrlColapso1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlColapso1.Location = new System.Drawing.Point(3, 3);
            this.ctrlColapso1.Name = "ctrlColapso1";
            this.ctrlColapso1.Size = new System.Drawing.Size(971, 428);
            this.ctrlColapso1.SoloLectura = false;
            this.ctrlColapso1.TabIndex = 0;
            // 
            // _cbxCausa
            // 
            this._cbxCausa.BackColor = System.Drawing.Color.White;
            this._cbxCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxCausa.EnterComoTab = false;
            this._cbxCausa.Etiqueta = null;
            this._cbxCausa.ForeColor = System.Drawing.Color.Black;
            this._cbxCausa.FormattingEnabled = true;
            this._cbxCausa.Location = new System.Drawing.Point(371, 134);
            this._cbxCausa.Name = "_cbxCausa";
            this._cbxCausa.Size = new System.Drawing.Size(213, 21);
            this._cbxCausa.TabIndex = 24;
            this._cbxCausa.TablaCampoBD = null;
            // 
            // _cbxOrigen
            // 
            this._cbxOrigen.BackColor = System.Drawing.Color.White;
            this._cbxOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxOrigen.EnterComoTab = false;
            this._cbxOrigen.Etiqueta = null;
            this._cbxOrigen.ForeColor = System.Drawing.Color.Black;
            this._cbxOrigen.FormattingEnabled = true;
            this._cbxOrigen.Location = new System.Drawing.Point(371, 90);
            this._cbxOrigen.Name = "_cbxOrigen";
            this._cbxOrigen.Size = new System.Drawing.Size(345, 21);
            this._cbxOrigen.TabIndex = 12;
            this._cbxOrigen.TablaCampoBD = null;
            // 
            // _cbxTipoDesconex
            // 
            this._cbxTipoDesconex.BackColor = System.Drawing.Color.White;
            this._cbxTipoDesconex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxTipoDesconex.EnterComoTab = false;
            this._cbxTipoDesconex.Etiqueta = null;
            this._cbxTipoDesconex.ForeColor = System.Drawing.Color.Black;
            this._cbxTipoDesconex.FormattingEnabled = true;
            this._cbxTipoDesconex.Location = new System.Drawing.Point(371, 112);
            this._cbxTipoDesconex.Name = "_cbxTipoDesconex";
            this._cbxTipoDesconex.Size = new System.Drawing.Size(213, 21);
            this._cbxTipoDesconex.TabIndex = 18;
            this._cbxTipoDesconex.TablaCampoBD = null;
            // 
            // _lblCausa
            // 
            this._lblCausa.AutoSize = true;
            this._lblCausa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCausa.Location = new System.Drawing.Point(323, 134);
            this._lblCausa.Name = "_lblCausa";
            this._lblCausa.Size = new System.Drawing.Size(45, 16);
            this._lblCausa.TabIndex = 23;
            this._lblCausa.TablaCampoBD = null;
            this._lblCausa.Text = "Causa :";
            // 
            // _lblElaboradoPor
            // 
            this._lblElaboradoPor.AutoSize = true;
            this._lblElaboradoPor.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblElaboradoPor.Location = new System.Drawing.Point(741, 134);
            this._lblElaboradoPor.Name = "_lblElaboradoPor";
            this._lblElaboradoPor.Size = new System.Drawing.Size(82, 16);
            this._lblElaboradoPor.TabIndex = 19;
            this._lblElaboradoPor.TablaCampoBD = null;
            this._lblElaboradoPor.Text = "Elaborado por :";
            // 
            // _txtTipoInforme
            // 
            this._txtTipoInforme.BackColor = System.Drawing.Color.White;
            this._txtTipoInforme.Enabled = false;
            this._txtTipoInforme.EnterComoTab = false;
            this._txtTipoInforme.Etiqueta = null;
            this._txtTipoInforme.ForeColor = System.Drawing.Color.Black;
            this._txtTipoInforme.Location = new System.Drawing.Point(826, 113);
            this._txtTipoInforme.Name = "_txtTipoInforme";
            this._txtTipoInforme.Size = new System.Drawing.Size(142, 20);
            this._txtTipoInforme.TabIndex = 14;
            this._txtTipoInforme.TablaCampoBD = null;
            // 
            // _lblTipoInforme
            // 
            this._lblTipoInforme.AutoSize = true;
            this._lblTipoInforme.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTipoInforme.Location = new System.Drawing.Point(735, 114);
            this._lblTipoInforme.Name = "_lblTipoInforme";
            this._lblTipoInforme.Size = new System.Drawing.Size(88, 16);
            this._lblTipoInforme.TabIndex = 13;
            this._lblTipoInforme.TablaCampoBD = null;
            this._lblTipoInforme.Text = "Tipo de Informe :";
            // 
            // _txtNumFallaAgente
            // 
            this._txtNumFallaAgente.EnterComoTab = false;
            this._txtNumFallaAgente.Etiqueta = this._lblNumFallaAgente;
            this._txtNumFallaAgente.Location = new System.Drawing.Point(826, 91);
            this._txtNumFallaAgente.Name = "_txtNumFallaAgente";
            this._txtNumFallaAgente.Size = new System.Drawing.Size(142, 20);
            this._txtNumFallaAgente.TabIndex = 8;
            this._txtNumFallaAgente.TablaCampoBD = null;
            // 
            // _lblNumFallaAgente
            // 
            this._lblNumFallaAgente.AutoSize = true;
            this._lblNumFallaAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblNumFallaAgente.Location = new System.Drawing.Point(722, 93);
            this._lblNumFallaAgente.Name = "_lblNumFallaAgente";
            this._lblNumFallaAgente.Size = new System.Drawing.Size(101, 16);
            this._lblNumFallaAgente.TabIndex = 7;
            this._lblNumFallaAgente.TablaCampoBD = null;
            this._lblNumFallaAgente.Text = "Num. Falla Agente :";
            // 
            // _lblTipoDesconex
            // 
            this._lblTipoDesconex.AutoSize = true;
            this._lblTipoDesconex.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTipoDesconex.Location = new System.Drawing.Point(253, 113);
            this._lblTipoDesconex.Name = "_lblTipoDesconex";
            this._lblTipoDesconex.Size = new System.Drawing.Size(115, 16);
            this._lblTipoDesconex.TabIndex = 17;
            this._lblTipoDesconex.TablaCampoBD = null;
            this._lblTipoDesconex.Text = "Tipo de Desconexión :";
            // 
            // _lblOrigen
            // 
            this._lblOrigen.AutoSize = true;
            this._lblOrigen.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrigen.Location = new System.Drawing.Point(322, 91);
            this._lblOrigen.Name = "_lblOrigen";
            this._lblOrigen.Size = new System.Drawing.Size(46, 16);
            this._lblOrigen.TabIndex = 11;
            this._lblOrigen.TablaCampoBD = null;
            this._lblOrigen.Text = "Origen :";
            // 
            // _lblAgente
            // 
            this._lblAgente.AutoSize = true;
            this._lblAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAgente.Location = new System.Drawing.Point(72, 134);
            this._lblAgente.Name = "_lblAgente";
            this._lblAgente.Size = new System.Drawing.Size(47, 16);
            this._lblAgente.TabIndex = 21;
            this._lblAgente.TablaCampoBD = null;
            this._lblAgente.Text = "Agente :";
            // 
            // _lblProblemasGen
            // 
            this._lblProblemasGen.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblProblemasGen.Location = new System.Drawing.Point(257, 72);
            this._lblProblemasGen.Name = "_lblProblemasGen";
            this._lblProblemasGen.Size = new System.Drawing.Size(112, 16);
            this._lblProblemasGen.TabIndex = 3;
            this._lblProblemasGen.TablaCampoBD = null;
            this._lblProblemasGen.Text = "Probl. Generación :";
            this._lblProblemasGen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblFecHoraInforme
            // 
            this._lblFecHoraInforme.AutoSize = true;
            this._lblFecHoraInforme.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFecHoraInforme.Location = new System.Drawing.Point(22, 113);
            this._lblFecHoraInforme.Name = "_lblFecHoraInforme";
            this._lblFecHoraInforme.Size = new System.Drawing.Size(97, 16);
            this._lblFecHoraInforme.TabIndex = 15;
            this._lblFecHoraInforme.TablaCampoBD = null;
            this._lblFecHoraInforme.Text = "Fecha y Hora Inf. :";
            // 
            // _txtFecHoraFalla
            // 
            this._txtFecHoraFalla.BackColor = System.Drawing.Color.White;
            this._txtFecHoraFalla.Enabled = false;
            this._txtFecHoraFalla.EnterComoTab = false;
            this._txtFecHoraFalla.Etiqueta = null;
            this._txtFecHoraFalla.ForeColor = System.Drawing.Color.Black;
            this._txtFecHoraFalla.Location = new System.Drawing.Point(122, 90);
            this._txtFecHoraFalla.Name = "_txtFecHoraFalla";
            this._txtFecHoraFalla.Size = new System.Drawing.Size(126, 20);
            this._txtFecHoraFalla.TabIndex = 10;
            this._txtFecHoraFalla.TablaCampoBD = null;
            // 
            // _lblFecHoraFalla
            // 
            this._lblFecHoraFalla.AutoSize = true;
            this._lblFecHoraFalla.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFecHoraFalla.Location = new System.Drawing.Point(13, 91);
            this._lblFecHoraFalla.Name = "_lblFecHoraFalla";
            this._lblFecHoraFalla.Size = new System.Drawing.Size(106, 16);
            this._lblFecHoraFalla.TabIndex = 9;
            this._lblFecHoraFalla.TablaCampoBD = null;
            this._lblFecHoraFalla.Text = "Fecha y Hora Falla :";
            // 
            // _gpxInfGeneral
            // 
            this._gpxInfGeneral.BackColor = System.Drawing.SystemColors.Control;
            this._gpxInfGeneral.Controls.Add(this._tStripInformeFalla);
            this._gpxInfGeneral.Controls.Add(this._cmbProblemasGen);
            this._gpxInfGeneral.Controls.Add(this._lblProblemasGen);
            this._gpxInfGeneral.Controls.Add(this._ctrlComponenteComprometido);
            this._gpxInfGeneral.Controls.Add(this._txtElaboradoPor);
            this._gpxInfGeneral.Controls.Add(this._txtAgente);
            this._gpxInfGeneral.Controls.Add(this._txtFechaHoraInforme);
            this._gpxInfGeneral.Controls.Add(this.cndcPanelControl1);
            this._gpxInfGeneral.Controls.Add(this.cndcLabelControl1);
            this._gpxInfGeneral.Controls.Add(this._txtNumFalla);
            this._gpxInfGeneral.Controls.Add(this._cbxCausa);
            this._gpxInfGeneral.Controls.Add(this._cbxOrigen);
            this._gpxInfGeneral.Controls.Add(this._lblFecHoraFalla);
            this._gpxInfGeneral.Controls.Add(this._cbxTipoDesconex);
            this._gpxInfGeneral.Controls.Add(this._txtFecHoraFalla);
            this._gpxInfGeneral.Controls.Add(this._lblCausa);
            this._gpxInfGeneral.Controls.Add(this._lblFecHoraInforme);
            this._gpxInfGeneral.Controls.Add(this._lblElaboradoPor);
            this._gpxInfGeneral.Controls.Add(this._txtTipoInforme);
            this._gpxInfGeneral.Controls.Add(this._lblTipoInforme);
            this._gpxInfGeneral.Controls.Add(this._txtNumFallaAgente);
            this._gpxInfGeneral.Controls.Add(this._lblAgente);
            this._gpxInfGeneral.Controls.Add(this._lblNumFallaAgente);
            this._gpxInfGeneral.Controls.Add(this._lblOrigen);
            this._gpxInfGeneral.Controls.Add(this._lblTipoDesconex);
            this._gpxInfGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this._gpxInfGeneral.Location = new System.Drawing.Point(0, 0);
            this._gpxInfGeneral.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this._gpxInfGeneral.Name = "_gpxInfGeneral";
            this._gpxInfGeneral.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._gpxInfGeneral.Size = new System.Drawing.Size(985, 158);
            this._gpxInfGeneral.TabIndex = 0;
            this._gpxInfGeneral.TablaCampoBD = null;
            this._gpxInfGeneral.TabStop = false;
            this._gpxInfGeneral.Text = "INFORMACION GENERAL";
            // 
            // _tStripInformeFalla
            // 
            this._tStripInformeFalla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tbtnGuardar,
            this._tbtnCancelar,
            this._tbtnDocAnalisis});
            this._tStripInformeFalla.Location = new System.Drawing.Point(3, 16);
            this._tStripInformeFalla.Name = "_tStripInformeFalla";
            this._tStripInformeFalla.Size = new System.Drawing.Size(979, 25);
            this._tStripInformeFalla.TabIndex = 26;
            this._tStripInformeFalla.TablaCampoBD = null;
            this._tStripInformeFalla.Text = "cndcToolStrip1";
            // 
            // _tbtnGuardar
            // 
            this._tbtnGuardar.Image = global::SisFallaUIInforme.Properties.Resources.save;
            this._tbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnGuardar.Name = "_tbtnGuardar";
            this._tbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this._tbtnGuardar.Text = "Guardar";
            this._tbtnGuardar.Click += new System.EventHandler(this._tbtnGuardar_Click);
            // 
            // _tbtnCancelar
            // 
            this._tbtnCancelar.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._tbtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnCancelar.Name = "_tbtnCancelar";
            this._tbtnCancelar.Size = new System.Drawing.Size(73, 22);
            this._tbtnCancelar.Text = "Cancelar";
            this._tbtnCancelar.Visible = false;
            this._tbtnCancelar.Click += new System.EventHandler(this._sbtnCancelar_Click);
            // 
            // _tbtnDocAnalisis
            // 
            this._tbtnDocAnalisis.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._tbtnDocAnalisis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnDocAnalisis.Name = "_tbtnDocAnalisis";
            this._tbtnDocAnalisis.Size = new System.Drawing.Size(78, 22);
            this._tbtnDocAnalisis.Text = "Doc. Análisis";
            this._tbtnDocAnalisis.Click += new System.EventHandler(this._tspDocAnalisis_Click);
            // 
            // _cmbProblemasGen
            // 
            this._cmbProblemasGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbProblemasGen.Enabled = false;
            this._cmbProblemasGen.EnterComoTab = true;
            this._cmbProblemasGen.Etiqueta = null;
            this._cmbProblemasGen.FormattingEnabled = true;
            this._cmbProblemasGen.Location = new System.Drawing.Point(372, 68);
            this._cmbProblemasGen.Name = "_cmbProblemasGen";
            this._cmbProblemasGen.Size = new System.Drawing.Size(297, 21);
            this._cmbProblemasGen.TabIndex = 6;
            this._cmbProblemasGen.TablaCampoBD = "F_GF_REGFALLA.D_COD_ORIGEN";
            this._cmbProblemasGen.Visible = false;
            // 
            // _ctrlComponenteComprometido
            // 
            this._ctrlComponenteComprometido.AnchoBoton = 115;
            this._ctrlComponenteComprometido.Componente = null;
            this._ctrlComponenteComprometido.Location = new System.Drawing.Point(254, 69);
            this._ctrlComponenteComprometido.Name = "_ctrlComponenteComprometido";
            this._ctrlComponenteComprometido.PkCodComponente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._ctrlComponenteComprometido.Size = new System.Drawing.Size(714, 21);
            this._ctrlComponenteComprometido.TabIndex = 25;
            this._ctrlComponenteComprometido.TextoBoton = "Componente Fallado";
            // 
            // _txtElaboradoPor
            // 
            this._txtElaboradoPor.BackColor = System.Drawing.Color.White;
            this._txtElaboradoPor.EnterComoTab = false;
            this._txtElaboradoPor.Etiqueta = null;
            this._txtElaboradoPor.ForeColor = System.Drawing.Color.Black;
            this._txtElaboradoPor.Location = new System.Drawing.Point(826, 134);
            this._txtElaboradoPor.Name = "_txtElaboradoPor";
            this._txtElaboradoPor.Size = new System.Drawing.Size(142, 20);
            this._txtElaboradoPor.TabIndex = 20;
            this._txtElaboradoPor.TablaCampoBD = "F_GF_INFORMEFALLA.ELABORADO_POR";
            // 
            // _txtAgente
            // 
            this._txtAgente.BackColor = System.Drawing.Color.White;
            this._txtAgente.Enabled = false;
            this._txtAgente.EnterComoTab = false;
            this._txtAgente.Etiqueta = null;
            this._txtAgente.ForeColor = System.Drawing.Color.Black;
            this._txtAgente.Location = new System.Drawing.Point(122, 133);
            this._txtAgente.Name = "_txtAgente";
            this._txtAgente.Size = new System.Drawing.Size(126, 20);
            this._txtAgente.TabIndex = 22;
            this._txtAgente.TablaCampoBD = null;
            // 
            // _txtFechaHoraInforme
            // 
            this._txtFechaHoraInforme.BackColor = System.Drawing.Color.White;
            this._txtFechaHoraInforme.Enabled = false;
            this._txtFechaHoraInforme.EnterComoTab = false;
            this._txtFechaHoraInforme.Etiqueta = null;
            this._txtFechaHoraInforme.ForeColor = System.Drawing.Color.Black;
            this._txtFechaHoraInforme.Location = new System.Drawing.Point(122, 112);
            this._txtFechaHoraInforme.Name = "_txtFechaHoraInforme";
            this._txtFechaHoraInforme.Size = new System.Drawing.Size(126, 20);
            this._txtFechaHoraInforme.TabIndex = 16;
            this._txtFechaHoraInforme.TablaCampoBD = null;
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cndcPanelControl1.Controls.Add(this._rbtnFalla);
            this.cndcPanelControl1.Controls.Add(this._rbtnDeficit);
            this.cndcPanelControl1.Enabled = false;
            this.cndcPanelControl1.Location = new System.Drawing.Point(28, 46);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(220, 22);
            this.cndcPanelControl1.TabIndex = 0;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _rbtnFalla
            // 
            this._rbtnFalla.AutoSize = true;
            this._rbtnFalla.Checked = true;
            this._rbtnFalla.Location = new System.Drawing.Point(3, 2);
            this._rbtnFalla.Name = "_rbtnFalla";
            this._rbtnFalla.Size = new System.Drawing.Size(47, 17);
            this._rbtnFalla.TabIndex = 0;
            this._rbtnFalla.TablaCampoBD = null;
            this._rbtnFalla.TabStop = true;
            this._rbtnFalla.Text = "Falla";
            this._rbtnFalla.UseVisualStyleBackColor = true;
            // 
            // _rbtnDeficit
            // 
            this._rbtnDeficit.AutoSize = true;
            this._rbtnDeficit.Location = new System.Drawing.Point(66, 2);
            this._rbtnDeficit.Name = "_rbtnDeficit";
            this._rbtnDeficit.Size = new System.Drawing.Size(147, 17);
            this._rbtnDeficit.TabIndex = 1;
            this._rbtnDeficit.TablaCampoBD = null;
            this._rbtnDeficit.Text = "Problemas de Generación";
            this._rbtnDeficit.UseVisualStyleBackColor = true;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl1.Location = new System.Drawing.Point(25, 70);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(94, 16);
            this.cndcLabelControl1.TabIndex = 1;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Registro de Falla :";
            // 
            // _txtNumFalla
            // 
            this._txtNumFalla.BackColor = System.Drawing.Color.White;
            this._txtNumFalla.Enabled = false;
            this._txtNumFalla.EnterComoTab = false;
            this._txtNumFalla.Etiqueta = null;
            this._txtNumFalla.ForeColor = System.Drawing.Color.Black;
            this._txtNumFalla.Location = new System.Drawing.Point(122, 69);
            this._txtNumFalla.Name = "_txtNumFalla";
            this._txtNumFalla.Size = new System.Drawing.Size(126, 20);
            this._txtNumFalla.TabIndex = 2;
            this._txtNumFalla.TablaCampoBD = null;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _pnlComandos
            // 
            this._pnlComandos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(183)))), ((int)(((byte)(213)))));
            this._pnlComandos.Location = new System.Drawing.Point(4, 161);
            this._pnlComandos.Name = "_pnlComandos";
            this._pnlComandos.Size = new System.Drawing.Size(976, 36);
            this._pnlComandos.TabIndex = 9;
            this._pnlComandos.Text = "panelComandos1";
            // 
            // FormInformeFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 658);
            this.Controls.Add(this._pnlComandos);
            this.Controls.Add(this._gpxInfGeneral);
            this.Controls.Add(this._tabcomponentes);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInformeFalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe de Falla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInformeFalla_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInformeFalla_FormClosed);
            this.Load += new System.EventHandler(this.FormInformeFalla_Load);
            this._tabcomponentes.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this._gpxProceRestitucion.ResumeLayout(false);
            this._gpxProceRestitucion.PerformLayout();
            this._gpxDescripcionFalla.ResumeLayout(false);
            this._gpxDescripcionFalla.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this._tabAnalisis.ResumeLayout(false);
            this._tabColapso.ResumeLayout(false);
            this._gpxInfGeneral.ResumeLayout(false);
            this._gpxInfGeneral.PerformLayout();
            this._tStripInformeFalla.ResumeLayout(false);
            this._tStripInformeFalla.PerformLayout();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCTabControl _tabcomponentes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCTextBox _txtInfAdicional;
        private Controles.CNDCGroupBox _gpxProceRestitucion;
        private Controles.CNDCTextBox _txtProcRestitucion;
        private Controles.CNDCGroupBox _gpxDescripcionFalla;
        private Controles.CNDCTextBox _txtDescripcionFalla;
        private Controles.CNDCComboBox _cbxCausa;
        private Controles.CNDCComboBox _cbxOrigen;
        private Controles.CNDCComboBox _cbxTipoDesconex;
        private Controles.CNDCLabel _lblCausa;
        private Controles.CNDCLabel _lblElaboradoPor;
        private Controles.CNDCTextBox _txtTipoInforme;
        private Controles.CNDCLabel _lblTipoInforme;
        private Controles.CNDCTextBox _txtNumFallaAgente;
        private Controles.CNDCLabel _lblNumFallaAgente;
        private Controles.CNDCLabel _lblTipoDesconex;
        private Controles.CNDCLabel _lblOrigen;
        private Controles.CNDCLabel _lblAgente;
        private Controles.CNDCLabel _lblProblemasGen;
        private Controles.CNDCLabel _lblFecHoraInforme;
        private Controles.CNDCTextBox _txtFecHoraFalla;
        private Controles.CNDCLabel _lblFecHoraFalla;
        private Controles.CNDCGroupBox _gpxInfGeneral;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCTextBox _txtOperacionProtecciones;
        private System.Windows.Forms.TabPage tabPage1;
        private CtrlComponentesComprometidos ctrlComponentesComprometidos1;
        private CtrlInterruptoresReles ctrlInterruptoresReles1;
        private CtrlAlimentadores ctrlAlimentadores1;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCTextBox _txtNumFalla;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCRadioButton _rbtnFalla;
        private Controles.CNDCRadioButton _rbtnDeficit;
        private System.Windows.Forms.TabPage _tabAnalisis;
        private CtrlAnalisisFalla ctrlAnalisisFalla1;
        private Controles.CNDCTextBox _txtFechaHoraInforme;
        private Controles.CNDCTextBox _txtAgente;
        private Controles.CNDCComboBox _cmbProblemasGen;
        private System.Windows.Forms.TabPage _tabColapso;
        private CtrlColapso ctrlColapso1;
        private CtrlComponente _ctrlComponenteComprometido;
        private CNDC.BaseForms.PanelComandos _pnlComandos;
        private Controles.CNDCToolStrip _tStripInformeFalla;
        private System.Windows.Forms.ToolStripButton _tbtnGuardar;
        private System.Windows.Forms.ToolStripButton _tbtnCancelar;
        private System.Windows.Forms.ToolStripButton _tbtnDocAnalisis;
        public Controles.CNDCTextBox _txtElaboradoPor;
    }
}