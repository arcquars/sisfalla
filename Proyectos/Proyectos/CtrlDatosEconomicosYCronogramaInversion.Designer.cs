namespace Proyectos
{
    partial class CtrlDatosEconomicosYCronogramaInversion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this._gbxCostos = new Controles.CNDCGroupBox();
            this._txtCostovariableOM = new Controles.CNDCTextBoxFloat();
            this._lblCostoVariable = new Controles.CNDCLabel();
            this._txtCostoFijoOM = new Controles.CNDCTextBoxFloat();
            this._lblCostoFijo = new Controles.CNDCLabel();
            this._gbxCronograma = new Controles.CNDCGroupBox();
            this._tsbCronograma = new System.Windows.Forms.ToolStrip();
            this._tsbEliminarCronograma = new System.Windows.Forms.ToolStripButton();
            this._gbxHistorico = new Controles.CNDCGroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnEliminarHistorico = new System.Windows.Forms.ToolStripButton();
            this._dgvHistoricoCronograma = new Controles.CNDCGridView();
            this._dgvCronograma = new Controles.CNDCGridView();
            this.groupBox1 = new Controles.CNDCGroupBox();
            this._txtInversionTotal = new Controles.CNDCTextBoxFloat();
            this.label2 = new Controles.CNDCLabel();
            this._dtpFechaInicio = new Controles.CNDCDateTimePicker();
            this.label7 = new Controles.CNDCLabel();
            this._gbxLocalizacion = new Controles.CNDCGroupBox();
            this._nudAnioRefInformacion = new System.Windows.Forms.NumericUpDown();
            this.label1 = new Controles.CNDCLabel();
            this._txtVidaUtil = new Controles.CNDCTextBoxInt();
            this.label6 = new Controles.CNDCLabel();
            this._txtTiempoEjecucion = new Controles.CNDCTextBoxInt();
            this.label3 = new Controles.CNDCLabel();
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._gbxDatosProyectos.SuspendLayout();
            this._gbxCostos.SuspendLayout();
            this._gbxCronograma.SuspendLayout();
            this._tsbCronograma.SuspendLayout();
            this._gbxHistorico.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistoricoCronograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCronograma)).BeginInit();
            this.groupBox1.SuspendLayout();
            this._gbxLocalizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioRefInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(2, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(200, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::Proyectos.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(66, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(55, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(69, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this._gbxCostos);
            this._gbxDatosProyectos.Controls.Add(this._gbxCronograma);
            this._gbxDatosProyectos.Controls.Add(this.groupBox1);
            this._gbxDatosProyectos.Controls.Add(this._gbxLocalizacion);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(2, 21);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(924, 430);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // _gbxCostos
            // 
            this._gbxCostos.Controls.Add(this._txtCostovariableOM);
            this._gbxCostos.Controls.Add(this._lblCostoVariable);
            this._gbxCostos.Controls.Add(this._txtCostoFijoOM);
            this._gbxCostos.Controls.Add(this._lblCostoFijo);
            this._gbxCostos.Location = new System.Drawing.Point(9, 365);
            this._gbxCostos.Name = "_gbxCostos";
            this._gbxCostos.Size = new System.Drawing.Size(907, 62);
            this._gbxCostos.TabIndex = 3;
            this._gbxCostos.TablaCampoBD = null;
            this._gbxCostos.TabStop = false;
            // 
            // _txtCostovariableOM
            // 
            this._txtCostovariableOM.AceptaNegativo = false;
            this._txtCostovariableOM.BackColor = System.Drawing.Color.White;
            this._txtCostovariableOM.EnterComoTab = true;
            this._txtCostovariableOM.Etiqueta = null;
            this._txtCostovariableOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCostovariableOM.Location = new System.Drawing.Point(263, 32);
            this._txtCostovariableOM.MaxDigitosDecimales = 0;
            this._txtCostovariableOM.MaxDigitosEnteros = 0;
            this._txtCostovariableOM.MaxLength = 30;
            this._txtCostovariableOM.Name = "_txtCostovariableOM";
            this._txtCostovariableOM.Size = new System.Drawing.Size(136, 22);
            this._txtCostovariableOM.TabIndex = 3;
            this._txtCostovariableOM.TablaCampoBD = "F_PR_DATO_ECONOMICO.COSTO_VARIABLE_OM";
            this._txtCostovariableOM.Text = "0";
            this._txtCostovariableOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtCostovariableOM.UsarFormatoNumerico = true;
            this._txtCostovariableOM.ValDouble = 0D;
            this._txtCostovariableOM.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtCostovariableOM.ValorDouble = 0D;
            this._txtCostovariableOM.ValorFloat = 0F;
            this._txtCostovariableOM.ValorInt = 0;
            this._txtCostovariableOM.ValorLong = ((long)(0));
            this._txtCostovariableOM.Value = 0F;
            // 
            // _lblCostoVariable
            // 
            this._lblCostoVariable.AutoSize = true;
            this._lblCostoVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCostoVariable.Location = new System.Drawing.Point(5, 35);
            this._lblCostoVariable.Name = "_lblCostoVariable";
            this._lblCostoVariable.Size = new System.Drawing.Size(254, 16);
            this._lblCostoVariable.TabIndex = 2;
            this._lblCostoVariable.TablaCampoBD = null;
            this._lblCostoVariable.Text = "Costo variable de O&&M (US$/MWh):";
            // 
            // _txtCostoFijoOM
            // 
            this._txtCostoFijoOM.AceptaNegativo = false;
            this._txtCostoFijoOM.BackColor = System.Drawing.Color.White;
            this._txtCostoFijoOM.EnterComoTab = true;
            this._txtCostoFijoOM.Etiqueta = null;
            this._txtCostoFijoOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCostoFijoOM.Location = new System.Drawing.Point(263, 9);
            this._txtCostoFijoOM.MaxDigitosDecimales = 0;
            this._txtCostoFijoOM.MaxDigitosEnteros = 0;
            this._txtCostoFijoOM.MaxLength = 30;
            this._txtCostoFijoOM.Name = "_txtCostoFijoOM";
            this._txtCostoFijoOM.Size = new System.Drawing.Size(136, 22);
            this._txtCostoFijoOM.TabIndex = 1;
            this._txtCostoFijoOM.TablaCampoBD = "F_PR_DATO_ECONOMICO.COSTO_FIJO_OM";
            this._txtCostoFijoOM.Text = "0";
            this._txtCostoFijoOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtCostoFijoOM.UsarFormatoNumerico = true;
            this._txtCostoFijoOM.ValDouble = 0D;
            this._txtCostoFijoOM.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtCostoFijoOM.ValorDouble = 0D;
            this._txtCostoFijoOM.ValorFloat = 0F;
            this._txtCostoFijoOM.ValorInt = 0;
            this._txtCostoFijoOM.ValorLong = ((long)(0));
            this._txtCostoFijoOM.Value = 0F;
            // 
            // _lblCostoFijo
            // 
            this._lblCostoFijo.AutoSize = true;
            this._lblCostoFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCostoFijo.Location = new System.Drawing.Point(49, 12);
            this._lblCostoFijo.Name = "_lblCostoFijo";
            this._lblCostoFijo.Size = new System.Drawing.Size(210, 16);
            this._lblCostoFijo.TabIndex = 0;
            this._lblCostoFijo.TablaCampoBD = null;
            this._lblCostoFijo.Text = "Costo fijo de O&&M (US$/año):";
            // 
            // _gbxCronograma
            // 
            this._gbxCronograma.Controls.Add(this._tsbCronograma);
            this._gbxCronograma.Controls.Add(this._gbxHistorico);
            this._gbxCronograma.Controls.Add(this._dgvCronograma);
            this._gbxCronograma.Location = new System.Drawing.Point(9, 88);
            this._gbxCronograma.Name = "_gbxCronograma";
            this._gbxCronograma.Size = new System.Drawing.Size(907, 276);
            this._gbxCronograma.TabIndex = 2;
            this._gbxCronograma.TablaCampoBD = null;
            this._gbxCronograma.TabStop = false;
            this._gbxCronograma.Text = "Cronograma de Inversión (MMUS$) s/Imp.";
            // 
            // _tsbCronograma
            // 
            this._tsbCronograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tsbCronograma.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbCronograma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbEliminarCronograma});
            this._tsbCronograma.Location = new System.Drawing.Point(3, 248);
            this._tsbCronograma.Name = "_tsbCronograma";
            this._tsbCronograma.Size = new System.Drawing.Size(113, 25);
            this._tsbCronograma.TabIndex = 1;
            this._tsbCronograma.Text = "toolStrip1";
            // 
            // _tsbEliminarCronograma
            // 
            this._tsbEliminarCronograma.Image = global::Proyectos.Properties.Resources.cancel;
            this._tsbEliminarCronograma.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarCronograma.Name = "_tsbEliminarCronograma";
            this._tsbEliminarCronograma.Size = new System.Drawing.Size(103, 22);
            this._tsbEliminarCronograma.Text = "Eliminar registro";
            this._tsbEliminarCronograma.Click += new System.EventHandler(this._tsbEliminarCronograma_Click);
            // 
            // _gbxHistorico
            // 
            this._gbxHistorico.Controls.Add(this.toolStrip1);
            this._gbxHistorico.Controls.Add(this._dgvHistoricoCronograma);
            this._gbxHistorico.Location = new System.Drawing.Point(277, 9);
            this._gbxHistorico.Name = "_gbxHistorico";
            this._gbxHistorico.Size = new System.Drawing.Size(624, 267);
            this._gbxHistorico.TabIndex = 1;
            this._gbxHistorico.TablaCampoBD = null;
            this._gbxHistorico.TabStop = false;
            this._gbxHistorico.Text = "Histórico del cronograma de inversión";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEliminarHistorico});
            this.toolStrip1.Location = new System.Drawing.Point(6, 239);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(116, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btnEliminarHistorico
            // 
            this._btnEliminarHistorico.Image = global::Proyectos.Properties.Resources.cancel;
            this._btnEliminarHistorico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminarHistorico.Name = "_btnEliminarHistorico";
            this._btnEliminarHistorico.Size = new System.Drawing.Size(106, 22);
            this._btnEliminarHistorico.Text = "Eliminar histórico";
            this._btnEliminarHistorico.Click += new System.EventHandler(this._btnEliminarHistorico_Click);
            // 
            // _dgvHistoricoCronograma
            // 
            this._dgvHistoricoCronograma.AllowUserToAddRows = false;
            this._dgvHistoricoCronograma.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvHistoricoCronograma.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvHistoricoCronograma.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvHistoricoCronograma.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvHistoricoCronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvHistoricoCronograma.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvHistoricoCronograma.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvHistoricoCronograma.Location = new System.Drawing.Point(6, 19);
            this._dgvHistoricoCronograma.MultiSelect = false;
            this._dgvHistoricoCronograma.Name = "_dgvHistoricoCronograma";
            this._dgvHistoricoCronograma.NombreContenedor = null;
            this._dgvHistoricoCronograma.ReadOnly = true;
            this._dgvHistoricoCronograma.RowHeadersWidth = 25;
            this._dgvHistoricoCronograma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvHistoricoCronograma.Size = new System.Drawing.Size(612, 217);
            this._dgvHistoricoCronograma.TabIndex = 0;
            this._dgvHistoricoCronograma.TablaCampoBD = null;
            this._dgvHistoricoCronograma.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvHistoricoCronograma_CellFormatting);
            // 
            // _dgvCronograma
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.Format = "N2";
            this._dgvCronograma.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvCronograma.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvCronograma.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvCronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvCronograma.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvCronograma.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvCronograma.Location = new System.Drawing.Point(3, 21);
            this._dgvCronograma.MultiSelect = false;
            this._dgvCronograma.Name = "_dgvCronograma";
            this._dgvCronograma.NombreContenedor = null;
            this._dgvCronograma.RowHeadersWidth = 25;
            this._dgvCronograma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dgvCronograma.Size = new System.Drawing.Size(250, 224);
            this._dgvCronograma.TabIndex = 0;
            this._dgvCronograma.TablaCampoBD = null;
            this._dgvCronograma.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvCronograma_CellFormatting);
            this._dgvCronograma.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvCronograma_CellValidated);
            this._dgvCronograma.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._dgvCronograma_CellValidating);
            this._dgvCronograma.SelectionChanged += new System.EventHandler(this._dgvCronograma_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtInversionTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(461, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TablaCampoBD = null;
            this.groupBox1.TabStop = false;
            // 
            // _txtInversionTotal
            // 
            this._txtInversionTotal.AceptaNegativo = false;
            this._txtInversionTotal.BackColor = System.Drawing.Color.Gainsboro;
            this._txtInversionTotal.EnterComoTab = true;
            this._txtInversionTotal.Etiqueta = null;
            this._txtInversionTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtInversionTotal.Location = new System.Drawing.Point(312, 9);
            this._txtInversionTotal.MaxDigitosDecimales = 0;
            this._txtInversionTotal.MaxDigitosEnteros = 0;
            this._txtInversionTotal.Name = "_txtInversionTotal";
            this._txtInversionTotal.ReadOnly = true;
            this._txtInversionTotal.Size = new System.Drawing.Size(119, 22);
            this._txtInversionTotal.TabIndex = 1;
            this._txtInversionTotal.TablaCampoBD = "F_PR_DATO_ECONOMICO.";
            this._txtInversionTotal.Text = "0";
            this._txtInversionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtInversionTotal.UsarFormatoNumerico = true;
            this._txtInversionTotal.ValDouble = 0D;
            this._txtInversionTotal.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtInversionTotal.ValorDouble = 0D;
            this._txtInversionTotal.ValorFloat = 0F;
            this._txtInversionTotal.ValorInt = 0;
            this._txtInversionTotal.ValorLong = ((long)(0));
            this._txtInversionTotal.Value = 0F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 0;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Inversión total (MMUS$):";
            // 
            // _dtpFechaInicio
            // 
            this._dtpFechaInicio.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaInicio.Location = new System.Drawing.Point(312, 33);
            this._dtpFechaInicio.Name = "_dtpFechaInicio";
            this._dtpFechaInicio.Size = new System.Drawing.Size(119, 22);
            this._dtpFechaInicio.TabIndex = 3;
            this._dtpFechaInicio.TablaCampoBD = "F_PR_DATO_ECONOMICO.FECHA_MIN_INGRESO_OPERACION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 16);
            this.label7.TabIndex = 2;
            this.label7.TablaCampoBD = null;
            this.label7.Text = "Fecha mínima de ingreso en operación:";
            // 
            // _gbxLocalizacion
            // 
            this._gbxLocalizacion.Controls.Add(this._nudAnioRefInformacion);
            this._gbxLocalizacion.Controls.Add(this.label1);
            this._gbxLocalizacion.Controls.Add(this._txtVidaUtil);
            this._gbxLocalizacion.Controls.Add(this.label6);
            this._gbxLocalizacion.Controls.Add(this._txtTiempoEjecucion);
            this._gbxLocalizacion.Controls.Add(this.label3);
            this._gbxLocalizacion.Location = new System.Drawing.Point(9, 9);
            this._gbxLocalizacion.Name = "_gbxLocalizacion";
            this._gbxLocalizacion.Size = new System.Drawing.Size(446, 79);
            this._gbxLocalizacion.TabIndex = 0;
            this._gbxLocalizacion.TablaCampoBD = null;
            this._gbxLocalizacion.TabStop = false;
            // 
            // _nudAnioRefInformacion
            // 
            this._nudAnioRefInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioRefInformacion.Location = new System.Drawing.Point(254, 53);
            this._nudAnioRefInformacion.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this._nudAnioRefInformacion.Minimum = new decimal(new int[] {
            1899,
            0,
            0,
            0});
            this._nudAnioRefInformacion.Name = "_nudAnioRefInformacion";
            this._nudAnioRefInformacion.Size = new System.Drawing.Size(66, 22);
            this._nudAnioRefInformacion.TabIndex = 5;
            this._nudAnioRefInformacion.Value = new decimal(new int[] {
            1899,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 16);
            this.label1.TabIndex = 4;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Año de referencia de información:";
            // 
            // _txtVidaUtil
            // 
            this._txtVidaUtil.AceptaNegativo = false;
            this._txtVidaUtil.BackColor = System.Drawing.Color.White;
            this._txtVidaUtil.EnterComoTab = true;
            this._txtVidaUtil.Etiqueta = null;
            this._txtVidaUtil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtVidaUtil.Location = new System.Drawing.Point(254, 31);
            this._txtVidaUtil.MaxDigitosDecimales = 0;
            this._txtVidaUtil.MaxDigitosEnteros = 0;
            this._txtVidaUtil.MaxLength = 30;
            this._txtVidaUtil.Name = "_txtVidaUtil";
            this._txtVidaUtil.Size = new System.Drawing.Size(119, 22);
            this._txtVidaUtil.TabIndex = 3;
            this._txtVidaUtil.TablaCampoBD = "F_PR_DATO_ECONOMICO.VIDA_UTIL";
            this._txtVidaUtil.Text = "0";
            this._txtVidaUtil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtVidaUtil.UsarFormatoNumerico = true;
            this._txtVidaUtil.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtVidaUtil.ValorDouble = 0D;
            this._txtVidaUtil.ValorFloat = 0F;
            this._txtVidaUtil.ValorInt = 0;
            this._txtVidaUtil.ValorLong = ((long)(0));
            this._txtVidaUtil.Value = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(137, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 2;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Vida útil (años):";
            // 
            // _txtTiempoEjecucion
            // 
            this._txtTiempoEjecucion.AceptaNegativo = false;
            this._txtTiempoEjecucion.BackColor = System.Drawing.Color.White;
            this._txtTiempoEjecucion.EnterComoTab = true;
            this._txtTiempoEjecucion.Etiqueta = null;
            this._txtTiempoEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTiempoEjecucion.Location = new System.Drawing.Point(254, 9);
            this._txtTiempoEjecucion.MaxDigitosDecimales = 0;
            this._txtTiempoEjecucion.MaxDigitosEnteros = 0;
            this._txtTiempoEjecucion.MaxLength = 30;
            this._txtTiempoEjecucion.Name = "_txtTiempoEjecucion";
            this._txtTiempoEjecucion.Size = new System.Drawing.Size(119, 22);
            this._txtTiempoEjecucion.TabIndex = 1;
            this._txtTiempoEjecucion.TablaCampoBD = "F_PR_DATO_ECONOMICO.TIEMPO_EJECUCION";
            this._txtTiempoEjecucion.Text = "0";
            this._txtTiempoEjecucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempoEjecucion.UsarFormatoNumerico = true;
            this._txtTiempoEjecucion.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtTiempoEjecucion.ValorDouble = 0D;
            this._txtTiempoEjecucion.ValorFloat = 0F;
            this._txtTiempoEjecucion.ValorInt = 0;
            this._txtTiempoEjecucion.ValorLong = ((long)(0));
            this._txtTiempoEjecucion.Value = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 16);
            this.label3.TabIndex = 0;
            this.label3.TablaCampoBD = null;
            this.label3.Text = "Tiempo de ejecución (años):";
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(817, 3);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(109, 22);
            this._dtpFechaRegistro.TabIndex = 2;
            this._dtpFechaRegistro.TablaCampoBD = null;
            this._dtpFechaRegistro.Visible = false;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cndcLabel1.Location = new System.Drawing.Point(691, 4);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 1;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosEconomicosYCronogramaInversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatosEconomicosYCronogramaInversion";
            this.Size = new System.Drawing.Size(926, 452);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._gbxDatosProyectos.ResumeLayout(false);
            this._gbxCostos.ResumeLayout(false);
            this._gbxCostos.PerformLayout();
            this._gbxCronograma.ResumeLayout(false);
            this._gbxCronograma.PerformLayout();
            this._tsbCronograma.ResumeLayout(false);
            this._tsbCronograma.PerformLayout();
            this._gbxHistorico.ResumeLayout(false);
            this._gbxHistorico.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistoricoCronograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCronograma)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._gbxLocalizacion.ResumeLayout(false);
            this._gbxLocalizacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioRefInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvCronograma;
        private Controles.CNDCGridView _dgvHistoricoCronograma;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.NumericUpDown _nudAnioRefInformacion;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCGroupBox _gbxCostos;
        protected Controles.CNDCDateTimePicker _dtpFechaInicio;
        private Controles.CNDCLabel label7;
        private Controles.CNDCLabel _lblCostoVariable;
        private Controles.CNDCLabel _lblCostoFijo;
        private Controles.CNDCGroupBox _gbxCronograma;
        private Controles.CNDCGroupBox groupBox1;
        private Controles.CNDCLabel label1;
        private Controles.CNDCLabel label2;
        private Controles.CNDCGroupBox _gbxLocalizacion;
        private Controles.CNDCLabel label6;
        private Controles.CNDCLabel label3;
        private Controles.CNDCGroupBox _gbxHistorico;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCTextBoxFloat _txtCostovariableOM;
        private Controles.CNDCTextBoxFloat _txtCostoFijoOM;
        private Controles.CNDCTextBoxInt _txtVidaUtil;
        private Controles.CNDCTextBoxInt _txtTiempoEjecucion;
        private Controles.CNDCTextBoxFloat _txtInversionTotal;
        private System.Windows.Forms.ToolStrip _tsbCronograma;
        private System.Windows.Forms.ToolStripButton _tsbEliminarCronograma;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnEliminarHistorico;
    }
}
