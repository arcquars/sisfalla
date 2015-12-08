namespace SISFALLA
{
    partial class FormInterruptor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtFechaHoraAp = new Controles.CNDCTextBoxDateTime();
            this._txtMiliSegApertura = new Controles.CNDCTextBoxInt();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl13 = new Controles.CNDCLabel();
            this._cbxTipoOpeAper = new Controles.CNDCComboBox();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this.cndcGroupBox4 = new Controles.CNDCGroupBox();
            this._txtFechaHoraCi = new Controles.CNDCTextBoxDateTime();
            this._rbtnNo = new Controles.CNDCRadioButton();
            this._rbtnSI = new Controles.CNDCRadioButton();
            this._txtMiliSegCierre = new Controles.CNDCTextBoxInt();
            this.cndcLabelControl15 = new Controles.CNDCLabel();
            this.cndcLabelControl14 = new Controles.CNDCLabel();
            this._cbxTipoOpeCierre = new Controles.CNDCComboBox();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._dgvRelesOperados = new Controles.CNDCGridView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._ctrlComponenteComprometido = new SISFALLA.CtrlComponente();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox4.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvRelesOperados)).BeginInit();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtFechaHoraAp);
            this.cndcGroupBox1.Controls.Add(this._txtMiliSegApertura);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl1);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl13);
            this.cndcGroupBox1.Controls.Add(this._cbxTipoOpeAper);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl2);
            this.cndcGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox1.Location = new System.Drawing.Point(55, 54);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(310, 129);
            this.cndcGroupBox1.TabIndex = 4;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Apertura :";
            // 
            // _txtFechaHoraAp
            // 
            this._txtFechaHoraAp.Etiqueta = null;
            this._txtFechaHoraAp.Location = new System.Drawing.Point(131, 25);
            this._txtFechaHoraAp.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraAp.Name = "_txtFechaHoraAp";
            this._txtFechaHoraAp.Size = new System.Drawing.Size(112, 20);
            this._txtFechaHoraAp.TabIndex = 1;
            this._txtFechaHoraAp.TablaCampoBD = "F_GF_OP_ALIMENTADOR.FECHA_APERTURA";
            this._txtFechaHoraAp.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraAp.ValidadorFormatoFecha = null;
            this._txtFechaHoraAp.ValidadorIngresoOnline = null;
            this._txtFechaHoraAp.Value = new System.DateTime(((long)(0)));
            // 
            // _txtMiliSegApertura
            // 
            this._txtMiliSegApertura.EnterComoTab = false;
            this._txtMiliSegApertura.Etiqueta = null;
            this._txtMiliSegApertura.Location = new System.Drawing.Point(131, 47);
            this._txtMiliSegApertura.MaxLength = 3;
            this._txtMiliSegApertura.Multiline = true;
            this._txtMiliSegApertura.Name = "_txtMiliSegApertura";
            this._txtMiliSegApertura.Size = new System.Drawing.Size(59, 20);
            this._txtMiliSegApertura.TabIndex = 3;
            this._txtMiliSegApertura.TablaCampoBD = "";
            this._txtMiliSegApertura.Text = "0";
            this._txtMiliSegApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtMiliSegApertura.Value = 0;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl1.Location = new System.Drawing.Point(45, 27);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl1.TabIndex = 0;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Fecha y Hora :";
            // 
            // cndcLabelControl13
            // 
            this.cndcLabelControl13.AutoSize = true;
            this.cndcLabelControl13.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl13.Location = new System.Drawing.Point(50, 49);
            this.cndcLabelControl13.Name = "cndcLabelControl13";
            this.cndcLabelControl13.Size = new System.Drawing.Size(75, 16);
            this.cndcLabelControl13.TabIndex = 2;
            this.cndcLabelControl13.TablaCampoBD = null;
            this.cndcLabelControl13.Text = "Milisegundos :";
            // 
            // _cbxTipoOpeAper
            // 
            this._cbxTipoOpeAper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxTipoOpeAper.EnterComoTab = false;
            this._cbxTipoOpeAper.Etiqueta = null;
            this._cbxTipoOpeAper.FormattingEnabled = true;
            this._cbxTipoOpeAper.Location = new System.Drawing.Point(131, 69);
            this._cbxTipoOpeAper.Name = "_cbxTipoOpeAper";
            this._cbxTipoOpeAper.Size = new System.Drawing.Size(121, 21);
            this._cbxTipoOpeAper.TabIndex = 5;
            this._cbxTipoOpeAper.TablaCampoBD = "F_GF_OP_ALIMENTADOR.D_COD_TIPO_OPER_APER";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.Location = new System.Drawing.Point(24, 73);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(101, 13);
            this.cndcLabelControl2.TabIndex = 4;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "Tipo de Operación :";
            // 
            // cndcGroupBox4
            // 
            this.cndcGroupBox4.Controls.Add(this._txtFechaHoraCi);
            this.cndcGroupBox4.Controls.Add(this._rbtnNo);
            this.cndcGroupBox4.Controls.Add(this._rbtnSI);
            this.cndcGroupBox4.Controls.Add(this._txtMiliSegCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl15);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl14);
            this.cndcGroupBox4.Controls.Add(this._cbxTipoOpeCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl3);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl4);
            this.cndcGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox4.Location = new System.Drawing.Point(404, 54);
            this.cndcGroupBox4.Name = "cndcGroupBox4";
            this.cndcGroupBox4.Size = new System.Drawing.Size(302, 126);
            this.cndcGroupBox4.TabIndex = 5;
            this.cndcGroupBox4.TablaCampoBD = null;
            this.cndcGroupBox4.TabStop = false;
            this.cndcGroupBox4.Text = "Cierre :";
            // 
            // _txtFechaHoraCi
            // 
            this._txtFechaHoraCi.Etiqueta = null;
            this._txtFechaHoraCi.Location = new System.Drawing.Point(135, 25);
            this._txtFechaHoraCi.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraCi.Name = "_txtFechaHoraCi";
            this._txtFechaHoraCi.Size = new System.Drawing.Size(112, 20);
            this._txtFechaHoraCi.TabIndex = 1;
            this._txtFechaHoraCi.TablaCampoBD = "F_GF_OP_ALIMENTADOR.FECHA_APERTURA";
            this._txtFechaHoraCi.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraCi.ValidadorFormatoFecha = null;
            this._txtFechaHoraCi.ValidadorIngresoOnline = null;
            this._txtFechaHoraCi.Value = new System.DateTime(((long)(0)));
            // 
            // _rbtnNo
            // 
            this._rbtnNo.AutoSize = true;
            this._rbtnNo.Checked = true;
            this._rbtnNo.Location = new System.Drawing.Point(189, 93);
            this._rbtnNo.Name = "_rbtnNo";
            this._rbtnNo.Size = new System.Drawing.Size(41, 17);
            this._rbtnNo.TabIndex = 8;
            this._rbtnNo.TablaCampoBD = null;
            this._rbtnNo.TabStop = true;
            this._rbtnNo.Text = "NO";
            this._rbtnNo.UseVisualStyleBackColor = true;
            this._rbtnNo.Visible = false;
            // 
            // _rbtnSI
            // 
            this._rbtnSI.AutoSize = true;
            this._rbtnSI.Location = new System.Drawing.Point(135, 93);
            this._rbtnSI.Name = "_rbtnSI";
            this._rbtnSI.Size = new System.Drawing.Size(35, 17);
            this._rbtnSI.TabIndex = 7;
            this._rbtnSI.TablaCampoBD = null;
            this._rbtnSI.Text = "SI";
            this._rbtnSI.UseVisualStyleBackColor = true;
            this._rbtnSI.Visible = false;
            // 
            // _txtMiliSegCierre
            // 
            this._txtMiliSegCierre.EnterComoTab = false;
            this._txtMiliSegCierre.Etiqueta = null;
            this._txtMiliSegCierre.Location = new System.Drawing.Point(135, 47);
            this._txtMiliSegCierre.MaxLength = 3;
            this._txtMiliSegCierre.Name = "_txtMiliSegCierre";
            this._txtMiliSegCierre.Size = new System.Drawing.Size(59, 20);
            this._txtMiliSegCierre.TabIndex = 3;
            this._txtMiliSegCierre.TablaCampoBD = "";
            this._txtMiliSegCierre.Text = "0";
            this._txtMiliSegCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtMiliSegCierre.Value = 0;
            // 
            // cndcLabelControl15
            // 
            this.cndcLabelControl15.AutoSize = true;
            this.cndcLabelControl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl15.Location = new System.Drawing.Point(34, 95);
            this.cndcLabelControl15.Name = "cndcLabelControl15";
            this.cndcLabelControl15.Size = new System.Drawing.Size(92, 13);
            this.cndcLabelControl15.TabIndex = 6;
            this.cndcLabelControl15.TablaCampoBD = null;
            this.cndcLabelControl15.Text = "Rec. Automática :";
            this.cndcLabelControl15.Visible = false;
            // 
            // cndcLabelControl14
            // 
            this.cndcLabelControl14.AutoSize = true;
            this.cndcLabelControl14.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl14.Location = new System.Drawing.Point(53, 49);
            this.cndcLabelControl14.Name = "cndcLabelControl14";
            this.cndcLabelControl14.Size = new System.Drawing.Size(75, 16);
            this.cndcLabelControl14.TabIndex = 2;
            this.cndcLabelControl14.TablaCampoBD = null;
            this.cndcLabelControl14.Text = "Milisegundos :";
            // 
            // _cbxTipoOpeCierre
            // 
            this._cbxTipoOpeCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxTipoOpeCierre.EnterComoTab = false;
            this._cbxTipoOpeCierre.Etiqueta = null;
            this._cbxTipoOpeCierre.FormattingEnabled = true;
            this._cbxTipoOpeCierre.Location = new System.Drawing.Point(135, 69);
            this._cbxTipoOpeCierre.Name = "_cbxTipoOpeCierre";
            this._cbxTipoOpeCierre.Size = new System.Drawing.Size(121, 21);
            this._cbxTipoOpeCierre.TabIndex = 5;
            this._cbxTipoOpeCierre.TablaCampoBD = "F_GF_OP_ALIMENTADOR.D_COD_TIPO_OP_CIERRE";
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl3.Location = new System.Drawing.Point(25, 73);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(101, 13);
            this.cndcLabelControl3.TabIndex = 4;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Tipo de Operación :";
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.Location = new System.Drawing.Point(47, 27);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl4.TabIndex = 0;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Fecha y Hora :";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._dgvRelesOperados);
            this.cndcGroupBox2.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox2.Location = new System.Drawing.Point(12, 189);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(733, 193);
            this.cndcGroupBox2.TabIndex = 6;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "RELÉS OPERADOS";
            // 
            // _dgvRelesOperados
            // 
            this._dgvRelesOperados.AllowUserToAddRows = false;
            this._dgvRelesOperados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvRelesOperados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvRelesOperados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvRelesOperados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvRelesOperados.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvRelesOperados.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvRelesOperados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvRelesOperados.Location = new System.Drawing.Point(3, 41);
            this._dgvRelesOperados.Name = "_dgvRelesOperados";
            this._dgvRelesOperados.ReadOnly = true;
            this._dgvRelesOperados.RowHeadersWidth = 15;
            this._dgvRelesOperados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvRelesOperados.Size = new System.Drawing.Size(727, 149);
            this._dgvRelesOperados.TabIndex = 1;
            this._dgvRelesOperados.TablaCampoBD = null;
            this._dgvRelesOperados.SelectionChanged += new System.EventHandler(this._dgvRelesOperados_SelectionChanged);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnEditar,
            this._btnEliminar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(727, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.Image = global::SISFALLA.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(62, 22);
            this._btnAdicionar.Text = "Añadir";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::SISFALLA.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(57, 22);
            this._btnEditar.Text = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.Image = global::SISFALLA.Properties.Resources.Delete;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(59, 22);
            this._btnEliminar.Text = "Borrar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // _ctrlComponenteComprometido
            // 
            this._ctrlComponenteComprometido.AnchoBoton = 145;
            this._ctrlComponenteComprometido.Componente = null;
            this._ctrlComponenteComprometido.Location = new System.Drawing.Point(24, 28);
            this._ctrlComponenteComprometido.Name = "_ctrlComponenteComprometido";
            this._ctrlComponenteComprometido.PkCodComponente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._ctrlComponenteComprometido.Size = new System.Drawing.Size(707, 23);
            this._ctrlComponenteComprometido.TabIndex = 3;
            this._ctrlComponenteComprometido.TextoBoton = "Interruptor";
            // 
            // FormInterruptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 408);
            this.Controls.Add(this._ctrlComponenteComprometido);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox4);
            this.Controls.Add(this.cndcGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormInterruptor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Editar Interruptor";
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox4, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.Controls.SetChildIndex(this._ctrlComponenteComprometido, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcGroupBox4.ResumeLayout(false);
            this.cndcGroupBox4.PerformLayout();
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvRelesOperados)).EndInit();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCComboBox _cbxTipoOpeAper;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCGroupBox cndcGroupBox4;
        private Controles.CNDCComboBox _cbxTipoOpeCierre;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCLabel cndcLabelControl15;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCGridView _dgvRelesOperados;
        private CtrlComponente _ctrlComponenteComprometido;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCTextBoxInt _txtMiliSegApertura;
        private Controles.CNDCLabel cndcLabelControl13;
        private Controles.CNDCTextBoxInt _txtMiliSegCierre;
        private Controles.CNDCLabel cndcLabelControl14;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCRadioButton _rbtnNo;
        private Controles.CNDCRadioButton _rbtnSI;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraAp;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraCi;
        private System.Windows.Forms.ToolStripButton _btnEditar;
    }
}