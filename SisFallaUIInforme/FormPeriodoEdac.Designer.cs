namespace SISFALLA
{
    partial class FormPeriodoEdac
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this._FechaVigencia = new Controles.CNDCDateTimePicker();
            this._lbldemo = new Controles.CNDCLabel();
            this._panelEdac = new Controles.CNDCPanelControl();
            this._CndcTSEdac = new Controles.CNDCToolStrip();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._cmbAgentes = new Controles.CNDCComboBox();
            this._tabEtapas = new Controles.CNDCTabControl();
            this._tabSubFrecuencia = new System.Windows.Forms.TabPage();
            this._dgvEdacSubFrecuencia = new Controles.CNDCGridView();
            this._tabRestitucion = new System.Windows.Forms.TabPage();
            this._dgvEdacRestitucion = new Controles.CNDCGridView();
            this._tabGradiente = new System.Windows.Forms.TabPage();
            this._dgvEdacGradiente = new Controles.CNDCGridView();
            this._lblFecha = new Controles.CNDCLabel();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnGenerarNuevo = new System.Windows.Forms.ToolStripButton();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._panelEdac.SuspendLayout();
            this._CndcTSEdac.SuspendLayout();
            this._tabEtapas.SuspendLayout();
            this._tabSubFrecuencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacSubFrecuencia)).BeginInit();
            this._tabRestitucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacRestitucion)).BeginInit();
            this._tabGradiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacGradiente)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _FechaVigencia
            // 
            this._FechaVigencia.CustomFormat = "dd/MM/YYYY";
            this._FechaVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._FechaVigencia.Location = new System.Drawing.Point(296, 20);
            this._FechaVigencia.Name = "_FechaVigencia";
            this._FechaVigencia.Size = new System.Drawing.Size(87, 20);
            this._FechaVigencia.TabIndex = 7;
            this._FechaVigencia.TablaCampoBD = null;
            // 
            // _lbldemo
            // 
            this._lbldemo.AutoSize = true;
            this._lbldemo.Location = new System.Drawing.Point(172, 24);
            this._lbldemo.Name = "_lbldemo";
            this._lbldemo.Size = new System.Drawing.Size(101, 13);
            this._lbldemo.TabIndex = 8;
            this._lbldemo.TablaCampoBD = null;
            this._lbldemo.Text = "Vigente a partir del :";
            // 
            // _panelEdac
            // 
            this._panelEdac.Controls.Add(this._CndcTSEdac);
            this._panelEdac.Controls.Add(this.cndcLabel1);
            this._panelEdac.Controls.Add(this._cmbAgentes);
            this._panelEdac.Controls.Add(this._tabEtapas);
            this._panelEdac.Location = new System.Drawing.Point(11, 19);
            this._panelEdac.Name = "_panelEdac";
            this._panelEdac.Size = new System.Drawing.Size(588, 302);
            this._panelEdac.TabIndex = 13;
            this._panelEdac.TablaCampoBD = null;
            // 
            // _CndcTSEdac
            // 
            this._CndcTSEdac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._CndcTSEdac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnEditar,
            this._btnEliminar});
            this._CndcTSEdac.Location = new System.Drawing.Point(0, 277);
            this._CndcTSEdac.Name = "_CndcTSEdac";
            this._CndcTSEdac.Size = new System.Drawing.Size(588, 25);
            this._CndcTSEdac.TabIndex = 12;
            this._CndcTSEdac.TablaCampoBD = null;
            this._CndcTSEdac.Text = "cndcToolStrip1";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(157, 6);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(106, 13);
            this.cndcLabel1.TabIndex = 11;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Seleccionar Agente :";
            // 
            // _cmbAgentes
            // 
            this._cmbAgentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAgentes.EnterComoTab = false;
            this._cmbAgentes.Etiqueta = null;
            this._cmbAgentes.FormattingEnabled = true;
            this._cmbAgentes.Location = new System.Drawing.Point(285, 3);
            this._cmbAgentes.Name = "_cmbAgentes";
            this._cmbAgentes.Size = new System.Drawing.Size(131, 21);
            this._cmbAgentes.TabIndex = 10;
            this._cmbAgentes.TablaCampoBD = null;
            this._cmbAgentes.SelectedIndexChanged += new System.EventHandler(this._cmbAgentes_SelectedIndexChanged);
            // 
            // _tabEtapas
            // 
            this._tabEtapas.Controls.Add(this._tabSubFrecuencia);
            this._tabEtapas.Controls.Add(this._tabRestitucion);
            this._tabEtapas.Controls.Add(this._tabGradiente);
            this._tabEtapas.Location = new System.Drawing.Point(2, 36);
            this._tabEtapas.Name = "_tabEtapas";
            this._tabEtapas.SelectedIndex = 0;
            this._tabEtapas.Size = new System.Drawing.Size(583, 238);
            this._tabEtapas.TabIndex = 6;
            this._tabEtapas.TablaCampoBD = null;
            this._tabEtapas.SelectedIndexChanged += new System.EventHandler(this._tabEtapas_SelectedIndexChanged);
            // 
            // _tabSubFrecuencia
            // 
            this._tabSubFrecuencia.Controls.Add(this._dgvEdacSubFrecuencia);
            this._tabSubFrecuencia.Location = new System.Drawing.Point(4, 22);
            this._tabSubFrecuencia.Name = "_tabSubFrecuencia";
            this._tabSubFrecuencia.Padding = new System.Windows.Forms.Padding(3);
            this._tabSubFrecuencia.Size = new System.Drawing.Size(575, 212);
            this._tabSubFrecuencia.TabIndex = 0;
            this._tabSubFrecuencia.Text = "Subfrecuencia";
            this._tabSubFrecuencia.UseVisualStyleBackColor = true;
            // 
            // _dgvEdacSubFrecuencia
            // 
            this._dgvEdacSubFrecuencia.AllowUserToAddRows = false;
            this._dgvEdacSubFrecuencia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvEdacSubFrecuencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvEdacSubFrecuencia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacSubFrecuencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvEdacSubFrecuencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvEdacSubFrecuencia.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvEdacSubFrecuencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEdacSubFrecuencia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvEdacSubFrecuencia.Location = new System.Drawing.Point(3, 3);
            this._dgvEdacSubFrecuencia.MultiSelect = false;
            this._dgvEdacSubFrecuencia.Name = "_dgvEdacSubFrecuencia";
            this._dgvEdacSubFrecuencia.NombreContenedor = null;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacSubFrecuencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvEdacSubFrecuencia.RowHeadersWidth = 25;
            this._dgvEdacSubFrecuencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvEdacSubFrecuencia.Size = new System.Drawing.Size(569, 206);
            this._dgvEdacSubFrecuencia.TabIndex = 5;
            this._dgvEdacSubFrecuencia.TablaCampoBD = null;
            this._dgvEdacSubFrecuencia.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Grilla_CellValidating);
            this._dgvEdacSubFrecuencia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgComboSubfrecuencia_CellValueChanged);
            this._dgvEdacSubFrecuencia.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grilla_EditingControlShowing);
            this._dgvEdacSubFrecuencia.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.Grilla__RowStateChanged);
            this._dgvEdacSubFrecuencia.SelectionChanged += new System.EventHandler(this.Grilla_SelectionChanged);
            // 
            // _tabRestitucion
            // 
            this._tabRestitucion.Controls.Add(this._dgvEdacRestitucion);
            this._tabRestitucion.Location = new System.Drawing.Point(4, 22);
            this._tabRestitucion.Name = "_tabRestitucion";
            this._tabRestitucion.Padding = new System.Windows.Forms.Padding(3);
            this._tabRestitucion.Size = new System.Drawing.Size(575, 212);
            this._tabRestitucion.TabIndex = 1;
            this._tabRestitucion.Text = "Restitución";
            this._tabRestitucion.UseVisualStyleBackColor = true;
            // 
            // _dgvEdacRestitucion
            // 
            this._dgvEdacRestitucion.AllowUserToAddRows = false;
            this._dgvEdacRestitucion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvEdacRestitucion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvEdacRestitucion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacRestitucion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this._dgvEdacRestitucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvEdacRestitucion.DefaultCellStyle = dataGridViewCellStyle7;
            this._dgvEdacRestitucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEdacRestitucion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvEdacRestitucion.Location = new System.Drawing.Point(3, 3);
            this._dgvEdacRestitucion.MultiSelect = false;
            this._dgvEdacRestitucion.Name = "_dgvEdacRestitucion";
            this._dgvEdacRestitucion.NombreContenedor = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacRestitucion.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this._dgvEdacRestitucion.RowHeadersWidth = 25;
            this._dgvEdacRestitucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvEdacRestitucion.Size = new System.Drawing.Size(569, 206);
            this._dgvEdacRestitucion.TabIndex = 6;
            this._dgvEdacRestitucion.TablaCampoBD = null;
            this._dgvEdacRestitucion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Grilla_CellValidating);
            this._dgvEdacRestitucion.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgComboRestitucion_CellValueChanged);
            this._dgvEdacRestitucion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grilla_EditingControlShowing);
            this._dgvEdacRestitucion.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.Grilla__RowStateChanged);
            this._dgvEdacRestitucion.SelectionChanged += new System.EventHandler(this.Grilla_SelectionChanged);
            // 
            // _tabGradiente
            // 
            this._tabGradiente.Controls.Add(this._dgvEdacGradiente);
            this._tabGradiente.Location = new System.Drawing.Point(4, 22);
            this._tabGradiente.Name = "_tabGradiente";
            this._tabGradiente.Padding = new System.Windows.Forms.Padding(3);
            this._tabGradiente.Size = new System.Drawing.Size(575, 212);
            this._tabGradiente.TabIndex = 3;
            this._tabGradiente.Text = "Gradiente";
            this._tabGradiente.UseVisualStyleBackColor = true;
            // 
            // _dgvEdacGradiente
            // 
            this._dgvEdacGradiente.AllowUserToAddRows = false;
            this._dgvEdacGradiente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvEdacGradiente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this._dgvEdacGradiente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacGradiente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this._dgvEdacGradiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvEdacGradiente.DefaultCellStyle = dataGridViewCellStyle11;
            this._dgvEdacGradiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEdacGradiente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvEdacGradiente.Location = new System.Drawing.Point(3, 3);
            this._dgvEdacGradiente.MultiSelect = false;
            this._dgvEdacGradiente.Name = "_dgvEdacGradiente";
            this._dgvEdacGradiente.NombreContenedor = null;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvEdacGradiente.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this._dgvEdacGradiente.RowHeadersWidth = 25;
            this._dgvEdacGradiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvEdacGradiente.Size = new System.Drawing.Size(569, 206);
            this._dgvEdacGradiente.TabIndex = 7;
            this._dgvEdacGradiente.TablaCampoBD = null;
            this._dgvEdacGradiente.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Grilla_CellValidating);
            this._dgvEdacGradiente.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgComboGradiente_CellValueChanged);
            this._dgvEdacGradiente.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grilla_EditingControlShowing);
            this._dgvEdacGradiente.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.Grilla__RowStateChanged);
            this._dgvEdacGradiente.SelectionChanged += new System.EventHandler(this.Grilla_SelectionChanged);
            // 
            // _lblFecha
            // 
            this._lblFecha.AutoSize = true;
            this._lblFecha.Location = new System.Drawing.Point(521, 28);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(0, 13);
            this._lblFecha.TabIndex = 14;
            this._lblFecha.TablaCampoBD = null;
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._panelEdac);
            this.cndcGroupBox1.Location = new System.Drawing.Point(29, 95);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(611, 332);
            this.cndcGroupBox1.TabIndex = 16;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Etapas Frecuencia y Tiempo por Agente";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._lbldemo);
            this.cndcGroupBox2.Controls.Add(this._FechaVigencia);
            this.cndcGroupBox2.Location = new System.Drawing.Point(29, 34);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(611, 55);
            this.cndcGroupBox2.TabIndex = 17;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Ultimo Periodo EDAC";
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this.toolStripSeparator1,
            this._btnCancelar,
            this.toolStripSeparator2,
            this._btnGenerarNuevo});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(670, 25);
            this.cndcToolStrip1.TabIndex = 18;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Image = global::SisFallaUIInforme.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(69, 22);
            this._btnGuardar.Text = " Guardar";
            this._btnGuardar.ToolTipText = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnGenerarNuevo
            // 
            this._btnGenerarNuevo.Image = global::SisFallaUIInforme.Properties.Resources.copiarDeInforme;
            this._btnGenerarNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGenerarNuevo.Name = "_btnGenerarNuevo";
            this._btnGenerarNuevo.Size = new System.Drawing.Size(172, 22);
            this._btnGenerarNuevo.Text = " Generar Nuevo Periodo EDAC";
            this._btnGenerarNuevo.Click += new System.EventHandler(this._btnGenerarNuevo_Click);
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionar.Image = global::SisFallaUIInforme.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionar.Text = "toolStripButton1";
            this._btnAdicionar.ToolTipText = "Adicionar";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditar.Image = global::SisFallaUIInforme.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(23, 22);
            this._btnEditar.Text = "toolStripButton2";
            this._btnEditar.ToolTipText = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminar.Image = global::SisFallaUIInforme.Properties.Resources.Delete;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(23, 22);
            this._btnEliminar.Text = "toolStripButton3";
            this._btnEliminar.ToolTipText = "Borrar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // FormPeriodoEdac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 452);
            this.Controls.Add(this.cndcToolStrip1);
            this.Controls.Add(this._lblFecha);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this.cndcGroupBox2);
            this.Name = "FormPeriodoEdac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPeriodoEdac";
            
            this._panelEdac.ResumeLayout(false);
            this._panelEdac.PerformLayout();
            this._CndcTSEdac.ResumeLayout(false);
            this._CndcTSEdac.PerformLayout();
            this._tabEtapas.ResumeLayout(false);
            this._tabSubFrecuencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacSubFrecuencia)).EndInit();
            this._tabRestitucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacRestitucion)).EndInit();
            this._tabGradiente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdacGradiente)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCDateTimePicker _FechaVigencia;
        private Controles.CNDCLabel _lbldemo;
        private Controles.CNDCPanelControl _panelEdac;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cmbAgentes;
        private Controles.CNDCTabControl _tabEtapas;
        private System.Windows.Forms.TabPage _tabSubFrecuencia;
        private Controles.CNDCGridView _dgvEdacSubFrecuencia;
        private System.Windows.Forms.TabPage _tabRestitucion;
        private Controles.CNDCGridView _dgvEdacRestitucion;
        private System.Windows.Forms.TabPage _tabGradiente;
        private Controles.CNDCGridView _dgvEdacGradiente;
        private Controles.CNDCToolStrip _CndcTSEdac;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCLabel _lblFecha;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnGenerarNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


    }
}