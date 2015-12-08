namespace MedicionComercialUI
{
    partial class FormEditorFormula
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtFormula = new Controles.CNDCTextBox();
            this._dgvPuntosMedicion = new Controles.CNDCGridView();
            this._txtFiltro = new Controles.CNDCTextBox();
            this._dgvMagnitudesElectricas = new Controles.CNDCGridView();
            this._btnAdjuntar = new Controles.CNDCButton();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._txtConstante = new Controles.CNDCTextBoxNumerico();
            this._btnIngresar = new Controles.CNDCButton();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._btnLlaveCi = new Controles.CNDCButton();
            this._btnLlaveAp = new Controles.CNDCButton();
            this._btnParentesisCi = new Controles.CNDCButton();
            this._btnParentisisAp = new Controles.CNDCButton();
            this._btnSuma = new Controles.CNDCButton();
            this._btnDivision = new Controles.CNDCButton();
            this._btnMultiplicacion = new Controles.CNDCButton();
            this._btnResta = new Controles.CNDCButton();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._btnAvanzarCursor = new Controles.CNDCButton();
            this._btnRetrocederCursor = new Controles.CNDCButton();
            this._btnBorrar = new Controles.CNDCButton();
            this._btnSuprimir = new Controles.CNDCButton();
            this._btnCursorAlFinal = new Controles.CNDCButton();
            this._btnCursorAlInicio = new Controles.CNDCButton();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMagnitudesElectricas)).BeginInit();
            this.cndcPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1, 400);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(29, 400);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(18, 42);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fórmula:";
            // 
            // _txtFormula
            // 
            this._txtFormula.EnterComoTab = false;
            this._txtFormula.Etiqueta = null;
            this._txtFormula.Location = new System.Drawing.Point(21, 58);
            this._txtFormula.Multiline = true;
            this._txtFormula.Name = "_txtFormula";
            this._txtFormula.Size = new System.Drawing.Size(796, 85);
            this._txtFormula.TabIndex = 5;
            this._txtFormula.TablaCampoBD = null;
            // 
            // _dgvPuntosMedicion
            // 
            this._dgvPuntosMedicion.AllowUserToAddRows = false;
            this._dgvPuntosMedicion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvPuntosMedicion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this._dgvPuntosMedicion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this._dgvPuntosMedicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvPuntosMedicion.DefaultCellStyle = dataGridViewCellStyle27;
            this._dgvPuntosMedicion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvPuntosMedicion.Location = new System.Drawing.Point(21, 161);
            this._dgvPuntosMedicion.Name = "_dgvPuntosMedicion";
            this._dgvPuntosMedicion.NombreContenedor = null;
            this._dgvPuntosMedicion.ReadOnly = true;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvPuntosMedicion.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this._dgvPuntosMedicion.RowHeadersWidth = 25;
            this._dgvPuntosMedicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvPuntosMedicion.Size = new System.Drawing.Size(240, 150);
            this._dgvPuntosMedicion.TabIndex = 6;
            this._dgvPuntosMedicion.TablaCampoBD = null;
            this._dgvPuntosMedicion.SelectionChanged += new System.EventHandler(this._dgvPuntosMedicion_SelectionChanged);
            // 
            // _txtFiltro
            // 
            this._txtFiltro.EnterComoTab = false;
            this._txtFiltro.Etiqueta = null;
            this._txtFiltro.Location = new System.Drawing.Point(68, 317);
            this._txtFiltro.Name = "_txtFiltro";
            this._txtFiltro.Size = new System.Drawing.Size(193, 20);
            this._txtFiltro.TabIndex = 7;
            this._txtFiltro.TablaCampoBD = null;
            // 
            // _dgvMagnitudesElectricas
            // 
            this._dgvMagnitudesElectricas.AllowUserToAddRows = false;
            this._dgvMagnitudesElectricas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvMagnitudesElectricas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this._dgvMagnitudesElectricas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMagnitudesElectricas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this._dgvMagnitudesElectricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvMagnitudesElectricas.DefaultCellStyle = dataGridViewCellStyle31;
            this._dgvMagnitudesElectricas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvMagnitudesElectricas.Location = new System.Drawing.Point(267, 161);
            this._dgvMagnitudesElectricas.Name = "_dgvMagnitudesElectricas";
            this._dgvMagnitudesElectricas.NombreContenedor = null;
            this._dgvMagnitudesElectricas.ReadOnly = true;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvMagnitudesElectricas.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this._dgvMagnitudesElectricas.RowHeadersWidth = 25;
            this._dgvMagnitudesElectricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMagnitudesElectricas.Size = new System.Drawing.Size(240, 150);
            this._dgvMagnitudesElectricas.TabIndex = 8;
            this._dgvMagnitudesElectricas.TablaCampoBD = null;
            this._dgvMagnitudesElectricas.SelectionChanged += new System.EventHandler(this._dgvMagnitudesElectricas_SelectionChanged);
            // 
            // _btnAdjuntar
            // 
            this._btnAdjuntar.Enabled = false;
            this._btnAdjuntar.Location = new System.Drawing.Point(432, 317);
            this._btnAdjuntar.Name = "_btnAdjuntar";
            this._btnAdjuntar.Size = new System.Drawing.Size(75, 23);
            this._btnAdjuntar.TabIndex = 9;
            this._btnAdjuntar.TablaCampoBD = null;
            this._btnAdjuntar.Text = "Adjuntar";
            this._btnAdjuntar.UseVisualStyleBackColor = true;
            this._btnAdjuntar.Click += new System.EventHandler(this._btnAdjuntar_Click);
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this._txtConstante);
            this.cndcPanelControl1.Controls.Add(this._btnIngresar);
            this.cndcPanelControl1.Controls.Add(this.cndcLabel3);
            this.cndcPanelControl1.Controls.Add(this._btnLlaveCi);
            this.cndcPanelControl1.Controls.Add(this._btnLlaveAp);
            this.cndcPanelControl1.Controls.Add(this._btnParentesisCi);
            this.cndcPanelControl1.Controls.Add(this._btnParentisisAp);
            this.cndcPanelControl1.Controls.Add(this._btnSuma);
            this.cndcPanelControl1.Controls.Add(this._btnDivision);
            this.cndcPanelControl1.Controls.Add(this._btnMultiplicacion);
            this.cndcPanelControl1.Controls.Add(this._btnResta);
            this.cndcPanelControl1.Location = new System.Drawing.Point(513, 161);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(304, 68);
            this.cndcPanelControl1.TabIndex = 10;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _txtConstante
            // 
            this._txtConstante.AceptaNegativo = true;
            this._txtConstante.EnterComoTab = false;
            this._txtConstante.Etiqueta = null;
            this._txtConstante.Location = new System.Drawing.Point(79, 36);
            this._txtConstante.MaxDigitosDecimales = 2;
            this._txtConstante.MaxDigitosEnteros = 8;
            this._txtConstante.Name = "_txtConstante";
            this._txtConstante.Size = new System.Drawing.Size(151, 20);
            this._txtConstante.TabIndex = 22;
            this._txtConstante.TablaCampoBD = null;
            this._txtConstante.Text = "0.00";
            this._txtConstante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtConstante.UsarFormatoNumerico = true;
            this._txtConstante.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this._txtConstante.ValorDouble = 0D;
            this._txtConstante.ValorFloat = 0F;
            this._txtConstante.ValorInt = 0;
            this._txtConstante.ValorLong = ((long)(0));
            // 
            // _btnIngresar
            // 
            this._btnIngresar.Location = new System.Drawing.Point(236, 33);
            this._btnIngresar.Name = "_btnIngresar";
            this._btnIngresar.Size = new System.Drawing.Size(65, 25);
            this._btnIngresar.TabIndex = 21;
            this._btnIngresar.TablaCampoBD = null;
            this._btnIngresar.Text = "Ingresar";
            this._btnIngresar.UseVisualStyleBackColor = true;
            this._btnIngresar.Click += new System.EventHandler(this._btnIngresar_Click);
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(3, 39);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(58, 13);
            this.cndcLabel3.TabIndex = 20;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Constante:";
            // 
            // _btnLlaveCi
            // 
            this._btnLlaveCi.Location = new System.Drawing.Point(218, 3);
            this._btnLlaveCi.Name = "_btnLlaveCi";
            this._btnLlaveCi.Size = new System.Drawing.Size(25, 25);
            this._btnLlaveCi.TabIndex = 18;
            this._btnLlaveCi.TablaCampoBD = null;
            this._btnLlaveCi.Text = "}";
            this._btnLlaveCi.UseVisualStyleBackColor = true;
            this._btnLlaveCi.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnLlaveAp
            // 
            this._btnLlaveAp.Location = new System.Drawing.Point(187, 3);
            this._btnLlaveAp.Name = "_btnLlaveAp";
            this._btnLlaveAp.Size = new System.Drawing.Size(25, 25);
            this._btnLlaveAp.TabIndex = 17;
            this._btnLlaveAp.TablaCampoBD = null;
            this._btnLlaveAp.Text = "{";
            this._btnLlaveAp.UseVisualStyleBackColor = true;
            this._btnLlaveAp.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnParentesisCi
            // 
            this._btnParentesisCi.Location = new System.Drawing.Point(156, 3);
            this._btnParentesisCi.Name = "_btnParentesisCi";
            this._btnParentesisCi.Size = new System.Drawing.Size(25, 25);
            this._btnParentesisCi.TabIndex = 16;
            this._btnParentesisCi.TablaCampoBD = null;
            this._btnParentesisCi.Text = ")";
            this._btnParentesisCi.UseVisualStyleBackColor = true;
            this._btnParentesisCi.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnParentisisAp
            // 
            this._btnParentisisAp.Location = new System.Drawing.Point(125, 3);
            this._btnParentisisAp.Name = "_btnParentisisAp";
            this._btnParentisisAp.Size = new System.Drawing.Size(25, 25);
            this._btnParentisisAp.TabIndex = 15;
            this._btnParentisisAp.TablaCampoBD = null;
            this._btnParentisisAp.Text = "(";
            this._btnParentisisAp.UseVisualStyleBackColor = true;
            this._btnParentisisAp.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnSuma
            // 
            this._btnSuma.Location = new System.Drawing.Point(3, 3);
            this._btnSuma.Name = "_btnSuma";
            this._btnSuma.Size = new System.Drawing.Size(25, 25);
            this._btnSuma.TabIndex = 14;
            this._btnSuma.TablaCampoBD = null;
            this._btnSuma.Text = "+";
            this._btnSuma.UseVisualStyleBackColor = true;
            this._btnSuma.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnDivision
            // 
            this._btnDivision.Location = new System.Drawing.Point(94, 3);
            this._btnDivision.Name = "_btnDivision";
            this._btnDivision.Size = new System.Drawing.Size(25, 25);
            this._btnDivision.TabIndex = 13;
            this._btnDivision.TablaCampoBD = null;
            this._btnDivision.Text = "/";
            this._btnDivision.UseVisualStyleBackColor = true;
            this._btnDivision.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnMultiplicacion
            // 
            this._btnMultiplicacion.Location = new System.Drawing.Point(63, 3);
            this._btnMultiplicacion.Name = "_btnMultiplicacion";
            this._btnMultiplicacion.Size = new System.Drawing.Size(25, 25);
            this._btnMultiplicacion.TabIndex = 12;
            this._btnMultiplicacion.TablaCampoBD = null;
            this._btnMultiplicacion.Text = "*";
            this._btnMultiplicacion.UseVisualStyleBackColor = true;
            this._btnMultiplicacion.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // _btnResta
            // 
            this._btnResta.Location = new System.Drawing.Point(32, 3);
            this._btnResta.Name = "_btnResta";
            this._btnResta.Size = new System.Drawing.Size(25, 25);
            this._btnResta.TabIndex = 11;
            this._btnResta.TablaCampoBD = null;
            this._btnResta.Text = "-";
            this._btnResta.UseVisualStyleBackColor = true;
            this._btnResta.Click += new System.EventHandler(this._btnSimbolo_Click);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(30, 320);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(32, 13);
            this.cndcLabel2.TabIndex = 11;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Filtro:";
            // 
            // _btnAvanzarCursor
            // 
            this._btnAvanzarCursor.Location = new System.Drawing.Point(693, 30);
            this._btnAvanzarCursor.Name = "_btnAvanzarCursor";
            this._btnAvanzarCursor.Size = new System.Drawing.Size(25, 25);
            this._btnAvanzarCursor.TabIndex = 24;
            this._btnAvanzarCursor.TablaCampoBD = null;
            this._btnAvanzarCursor.Text = ">";
            this._btnAvanzarCursor.UseVisualStyleBackColor = true;
            this._btnAvanzarCursor.Click += new System.EventHandler(this._btnAvanzarCursor_Click);
            // 
            // _btnRetrocederCursor
            // 
            this._btnRetrocederCursor.Location = new System.Drawing.Point(664, 30);
            this._btnRetrocederCursor.Name = "_btnRetrocederCursor";
            this._btnRetrocederCursor.Size = new System.Drawing.Size(25, 25);
            this._btnRetrocederCursor.TabIndex = 23;
            this._btnRetrocederCursor.TablaCampoBD = null;
            this._btnRetrocederCursor.Text = "<";
            this._btnRetrocederCursor.UseVisualStyleBackColor = true;
            this._btnRetrocederCursor.Click += new System.EventHandler(this._btnRetrocederCursor_Click);
            // 
            // _btnBorrar
            // 
            this._btnBorrar.Location = new System.Drawing.Point(761, 30);
            this._btnBorrar.Name = "_btnBorrar";
            this._btnBorrar.Size = new System.Drawing.Size(25, 25);
            this._btnBorrar.TabIndex = 25;
            this._btnBorrar.TablaCampoBD = null;
            this._btnBorrar.Text = "B";
            this._btnBorrar.UseVisualStyleBackColor = true;
            this._btnBorrar.Click += new System.EventHandler(this._btnBorrar_Click);
            // 
            // _btnSuprimir
            // 
            this._btnSuprimir.Location = new System.Drawing.Point(792, 30);
            this._btnSuprimir.Name = "_btnSuprimir";
            this._btnSuprimir.Size = new System.Drawing.Size(25, 25);
            this._btnSuprimir.TabIndex = 26;
            this._btnSuprimir.TablaCampoBD = null;
            this._btnSuprimir.Text = "S";
            this._btnSuprimir.UseVisualStyleBackColor = true;
            this._btnSuprimir.Click += new System.EventHandler(this._btnSuprimir_Click);
            // 
            // _btnCursorAlFinal
            // 
            this._btnCursorAlFinal.Location = new System.Drawing.Point(722, 30);
            this._btnCursorAlFinal.Name = "_btnCursorAlFinal";
            this._btnCursorAlFinal.Size = new System.Drawing.Size(25, 25);
            this._btnCursorAlFinal.TabIndex = 28;
            this._btnCursorAlFinal.TablaCampoBD = null;
            this._btnCursorAlFinal.Text = ">|";
            this._btnCursorAlFinal.UseVisualStyleBackColor = true;
            this._btnCursorAlFinal.Click += new System.EventHandler(this._btnCursorAlFinal_Click);
            // 
            // _btnCursorAlInicio
            // 
            this._btnCursorAlInicio.Location = new System.Drawing.Point(635, 30);
            this._btnCursorAlInicio.Name = "_btnCursorAlInicio";
            this._btnCursorAlInicio.Size = new System.Drawing.Size(25, 25);
            this._btnCursorAlInicio.TabIndex = 27;
            this._btnCursorAlInicio.TablaCampoBD = null;
            this._btnCursorAlInicio.Text = "|<";
            this._btnCursorAlInicio.UseVisualStyleBackColor = true;
            this._btnCursorAlInicio.Click += new System.EventHandler(this._btnCursorAlInicio_Click);
            // 
            // FormEditorFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 367);
            this.Controls.Add(this._btnCursorAlFinal);
            this.Controls.Add(this._btnCursorAlInicio);
            this.Controls.Add(this._btnSuprimir);
            this.Controls.Add(this._btnBorrar);
            this.Controls.Add(this._btnAvanzarCursor);
            this.Controls.Add(this._btnRetrocederCursor);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._dgvMagnitudesElectricas);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._btnAdjuntar);
            this.Controls.Add(this._txtFormula);
            this.Controls.Add(this._txtFiltro);
            this.Controls.Add(this._dgvPuntosMedicion);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormEditorFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditorFormula";
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this._dgvPuntosMedicion, 0);
            this.Controls.SetChildIndex(this._txtFiltro, 0);
            this.Controls.SetChildIndex(this._txtFormula, 0);
            this.Controls.SetChildIndex(this._btnAdjuntar, 0);
            this.Controls.SetChildIndex(this.cndcPanelControl1, 0);
            this.Controls.SetChildIndex(this._dgvMagnitudesElectricas, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this._btnRetrocederCursor, 0);
            this.Controls.SetChildIndex(this._btnAvanzarCursor, 0);
            this.Controls.SetChildIndex(this._btnBorrar, 0);
            this.Controls.SetChildIndex(this._btnSuprimir, 0);
            this.Controls.SetChildIndex(this._btnCursorAlInicio, 0);
            this.Controls.SetChildIndex(this._btnCursorAlFinal, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPuntosMedicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMagnitudesElectricas)).EndInit();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtFormula;
        private Controles.CNDCGridView _dgvPuntosMedicion;
        private Controles.CNDCTextBox _txtFiltro;
        private Controles.CNDCGridView _dgvMagnitudesElectricas;
        private Controles.CNDCButton _btnAdjuntar;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCButton _btnLlaveCi;
        private Controles.CNDCButton _btnLlaveAp;
        private Controles.CNDCButton _btnParentesisCi;
        private Controles.CNDCButton _btnParentisisAp;
        private Controles.CNDCButton _btnSuma;
        private Controles.CNDCButton _btnDivision;
        private Controles.CNDCButton _btnMultiplicacion;
        private Controles.CNDCButton _btnResta;
        private Controles.CNDCButton _btnIngresar;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBoxNumerico _txtConstante;
        private Controles.CNDCButton _btnAvanzarCursor;
        private Controles.CNDCButton _btnRetrocederCursor;
        private Controles.CNDCButton _btnBorrar;
        private Controles.CNDCButton _btnSuprimir;
        private Controles.CNDCButton _btnCursorAlFinal;
        private Controles.CNDCButton _btnCursorAlInicio;
    }
}