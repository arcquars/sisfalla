namespace DemandasUI
{
    partial class FormAsignacionNodosSalidas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gbxTipoSalida = new System.Windows.Forms.GroupBox();
            this._rbtPowerFactory = new System.Windows.Forms.RadioButton();
            this._btnCrearAutamaticamente = new System.Windows.Forms.Button();
            this._rbtNCP = new System.Windows.Forms.RadioButton();
            this._rbtOPTGEN = new System.Windows.Forms.RadioButton();
            this._rbtSDDP = new System.Windows.Forms.RadioButton();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminarSalida = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnAdicionarNodoSalida = new System.Windows.Forms.Button();
            this._txtSiglaNodoSalida = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtNodoSalida = new Controles.CNDCTextBox();
            this._dgvNodosSalida = new System.Windows.Forms.DataGridView();
            this._chkListaNodosConexion = new System.Windows.Forms.CheckedListBox();
            this._txtAgente = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this.label11 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this._txtSigla = new Controles.CNDCTextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this._gbxTipoSalida.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodosSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._gbxTipoSalida);
            this.groupBox1.Controls.Add(this._toolStrip);
            this.groupBox1.Controls.Add(this._btnAdicionarNodoSalida);
            this.groupBox1.Controls.Add(this._txtSiglaNodoSalida);
            this.groupBox1.Controls.Add(this.cndcLabel2);
            this.groupBox1.Controls.Add(this._txtNodoSalida);
            this.groupBox1.Controls.Add(this._dgvNodosSalida);
            this.groupBox1.Controls.Add(this._chkListaNodosConexion);
            this.groupBox1.Controls.Add(this._txtAgente);
            this.groupBox1.Controls.Add(this.cndcLabel1);
            this.groupBox1.Controls.Add(this._txtNombre);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._txtSigla);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salida SDDP";
            // 
            // _gbxTipoSalida
            // 
            this._gbxTipoSalida.Controls.Add(this._rbtPowerFactory);
            this._gbxTipoSalida.Controls.Add(this._btnCrearAutamaticamente);
            this._gbxTipoSalida.Controls.Add(this._rbtNCP);
            this._gbxTipoSalida.Controls.Add(this._rbtOPTGEN);
            this._gbxTipoSalida.Controls.Add(this._rbtSDDP);
            this._gbxTipoSalida.Location = new System.Drawing.Point(167, 80);
            this._gbxTipoSalida.Name = "_gbxTipoSalida";
            this._gbxTipoSalida.Size = new System.Drawing.Size(412, 42);
            this._gbxTipoSalida.TabIndex = 53;
            this._gbxTipoSalida.TabStop = false;
            this._gbxTipoSalida.Text = "Tipo Salida ";
            // 
            // _rbtPowerFactory
            // 
            this._rbtPowerFactory.AutoSize = true;
            this._rbtPowerFactory.Location = new System.Drawing.Point(220, 18);
            this._rbtPowerFactory.Name = "_rbtPowerFactory";
            this._rbtPowerFactory.Size = new System.Drawing.Size(93, 17);
            this._rbtPowerFactory.TabIndex = 55;
            this._rbtPowerFactory.TabStop = true;
            this._rbtPowerFactory.Text = "Power Factory";
            this._rbtPowerFactory.UseVisualStyleBackColor = true;
            this._rbtPowerFactory.CheckedChanged += new System.EventHandler(this._rbtPowerFactory_CheckedChanged);
            // 
            // _btnCrearAutamaticamente
            // 
            this._btnCrearAutamaticamente.Location = new System.Drawing.Point(327, 14);
            this._btnCrearAutamaticamente.Name = "_btnCrearAutamaticamente";
            this._btnCrearAutamaticamente.Size = new System.Drawing.Size(79, 23);
            this._btnCrearAutamaticamente.TabIndex = 54;
            this._btnCrearAutamaticamente.Text = "Crear Salidas";
            this._btnCrearAutamaticamente.UseVisualStyleBackColor = true;
            this._btnCrearAutamaticamente.Click += new System.EventHandler(this._btnCrearAutamaticamente_Click);
            // 
            // _rbtNCP
            // 
            this._rbtNCP.AutoSize = true;
            this._rbtNCP.Location = new System.Drawing.Point(160, 18);
            this._rbtNCP.Name = "_rbtNCP";
            this._rbtNCP.Size = new System.Drawing.Size(47, 17);
            this._rbtNCP.TabIndex = 2;
            this._rbtNCP.TabStop = true;
            this._rbtNCP.Text = "NCP";
            this._rbtNCP.UseVisualStyleBackColor = true;
            this._rbtNCP.CheckedChanged += new System.EventHandler(this._rbtNCP_CheckedChanged);
            // 
            // _rbtOPTGEN
            // 
            this._rbtOPTGEN.AutoSize = true;
            this._rbtOPTGEN.Location = new System.Drawing.Point(74, 18);
            this._rbtOPTGEN.Name = "_rbtOPTGEN";
            this._rbtOPTGEN.Size = new System.Drawing.Size(70, 17);
            this._rbtOPTGEN.TabIndex = 1;
            this._rbtOPTGEN.TabStop = true;
            this._rbtOPTGEN.Text = "OPTGEN";
            this._rbtOPTGEN.UseVisualStyleBackColor = true;
            this._rbtOPTGEN.CheckedChanged += new System.EventHandler(this._rbtOPTGEN_CheckedChanged);
            // 
            // _rbtSDDP
            // 
            this._rbtSDDP.AutoSize = true;
            this._rbtSDDP.Location = new System.Drawing.Point(5, 19);
            this._rbtSDDP.Name = "_rbtSDDP";
            this._rbtSDDP.Size = new System.Drawing.Size(55, 17);
            this._rbtSDDP.TabIndex = 0;
            this._rbtSDDP.TabStop = true;
            this._rbtSDDP.Text = "SDDP";
            this._rbtSDDP.UseVisualStyleBackColor = true;
            this._rbtSDDP.CheckedChanged += new System.EventHandler(this._rbtSDDP_CheckedChanged);
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbNuevo,
            this._tsbEliminarSalida,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(35, 389);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(343, 25);
            this._toolStrip.TabIndex = 30;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::DemandasUI.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(69, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::DemandasUI.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(57, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
            // 
            // _tsbNuevo
            // 
            this._tsbNuevo.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNuevo.Name = "_tsbNuevo";
            this._tsbNuevo.Size = new System.Drawing.Size(62, 22);
            this._tsbNuevo.Text = "Nuevo";
            this._tsbNuevo.Click += new System.EventHandler(this._tsbNuevo_Click);
            // 
            // _tsbEliminarSalida
            // 
            this._tsbEliminarSalida.Image = global::DemandasUI.Properties.Resources.cancel;
            this._tsbEliminarSalida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarSalida.Name = "_tsbEliminarSalida";
            this._tsbEliminarSalida.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminarSalida.Text = "Eliminar";
            this._tsbEliminarSalida.Click += new System.EventHandler(this._tsbEliminarSalida_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(73, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _btnAdicionarNodoSalida
            // 
            this._btnAdicionarNodoSalida.Image = global::DemandasUI.Properties.Resources.Add;
            this._btnAdicionarNodoSalida.Location = new System.Drawing.Point(526, 122);
            this._btnAdicionarNodoSalida.Name = "_btnAdicionarNodoSalida";
            this._btnAdicionarNodoSalida.Size = new System.Drawing.Size(24, 23);
            this._btnAdicionarNodoSalida.TabIndex = 52;
            this._btnAdicionarNodoSalida.UseVisualStyleBackColor = true;
            this._btnAdicionarNodoSalida.Click += new System.EventHandler(this._btnAdicionarNodoSalida_Click);
            // 
            // _txtSiglaNodoSalida
            // 
            this._txtSiglaNodoSalida.BackColor = System.Drawing.Color.Gainsboro;
            this._txtSiglaNodoSalida.EnterComoTab = false;
            this._txtSiglaNodoSalida.Etiqueta = null;
            this._txtSiglaNodoSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSiglaNodoSalida.Location = new System.Drawing.Point(382, 123);
            this._txtSiglaNodoSalida.Name = "_txtSiglaNodoSalida";
            this._txtSiglaNodoSalida.ReadOnly = true;
            this._txtSiglaNodoSalida.Size = new System.Drawing.Size(141, 22);
            this._txtSiglaNodoSalida.TabIndex = 51;
            this._txtSiglaNodoSalida.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel2.Location = new System.Drawing.Point(87, 125);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(77, 16);
            this.cndcLabel2.TabIndex = 49;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nodo Salida:";
            // 
            // _txtNodoSalida
            // 
            this._txtNodoSalida.BackColor = System.Drawing.Color.Gainsboro;
            this._txtNodoSalida.EnterComoTab = false;
            this._txtNodoSalida.Etiqueta = null;
            this._txtNodoSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNodoSalida.Location = new System.Drawing.Point(167, 123);
            this._txtNodoSalida.Name = "_txtNodoSalida";
            this._txtNodoSalida.ReadOnly = true;
            this._txtNodoSalida.Size = new System.Drawing.Size(214, 22);
            this._txtNodoSalida.TabIndex = 50;
            this._txtNodoSalida.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // _dgvNodosSalida
            // 
            this._dgvNodosSalida.AllowUserToAddRows = false;
            this._dgvNodosSalida.AllowUserToDeleteRows = false;
            this._dgvNodosSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvNodosSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvNodosSalida.Location = new System.Drawing.Point(64, 151);
            this._dgvNodosSalida.Name = "_dgvNodosSalida";
            this._dgvNodosSalida.ReadOnly = true;
            this._dgvNodosSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvNodosSalida.Size = new System.Drawing.Size(515, 238);
            this._dgvNodosSalida.TabIndex = 47;
            this._dgvNodosSalida.SelectionChanged += new System.EventHandler(this._dgvNodosSalida_SelectionChanged);
            // 
            // _chkListaNodosConexion
            // 
            this._chkListaNodosConexion.CheckOnClick = true;
            this._chkListaNodosConexion.FormattingEnabled = true;
            this._chkListaNodosConexion.Location = new System.Drawing.Point(585, 15);
            this._chkListaNodosConexion.Name = "_chkListaNodosConexion";
            this._chkListaNodosConexion.Size = new System.Drawing.Size(282, 379);
            this._chkListaNodosConexion.TabIndex = 46;
            // 
            // _txtAgente
            // 
            this._txtAgente.BackColor = System.Drawing.Color.Gainsboro;
            this._txtAgente.EnterComoTab = false;
            this._txtAgente.Etiqueta = null;
            this._txtAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAgente.Location = new System.Drawing.Point(167, 15);
            this._txtAgente.Name = "_txtAgente";
            this._txtAgente.ReadOnly = true;
            this._txtAgente.Size = new System.Drawing.Size(375, 22);
            this._txtAgente.TabIndex = 45;
            this._txtAgente.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(72, 17);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(92, 16);
            this.cndcLabel1.TabIndex = 44;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Nombre agente:";
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.Gainsboro;
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(167, 37);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.ReadOnly = true;
            this._txtNombre.Size = new System.Drawing.Size(192, 22);
            this._txtNombre.TabIndex = 42;
            this._txtNombre.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(45, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 40;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nodo de agregación:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 41;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Sigla nodo:";
            // 
            // _txtSigla
            // 
            this._txtSigla.BackColor = System.Drawing.Color.Gainsboro;
            this._txtSigla.EnterComoTab = false;
            this._txtSigla.Etiqueta = null;
            this._txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSigla.Location = new System.Drawing.Point(167, 59);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.ReadOnly = true;
            this._txtSigla.Size = new System.Drawing.Size(192, 22);
            this._txtSigla.TabIndex = 43;
            this._txtSigla.TablaCampoBD = "F_PR_DATO_TEC_BIOMASA.OBSERVACIONES";
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // FormAsignacionNodosSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 427);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAsignacionNodosSalidas";
            this.Text = "Asignación nodos salidas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._gbxTipoSalida.ResumeLayout(false);
            this._gbxTipoSalida.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodosSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnAdicionarNodoSalida;
        private Controles.CNDCTextBox _txtSiglaNodoSalida;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtNodoSalida;
        private System.Windows.Forms.DataGridView _dgvNodosSalida;
        private System.Windows.Forms.CheckedListBox _chkListaNodosConexion;
        private Controles.CNDCTextBox _txtAgente;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel label11;
        private Controles.CNDCLabel label9;
        private Controles.CNDCTextBox _txtSigla;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.GroupBox _gbxTipoSalida;
        private System.Windows.Forms.RadioButton _rbtNCP;
        private System.Windows.Forms.RadioButton _rbtOPTGEN;
        private System.Windows.Forms.RadioButton _rbtSDDP;
        private System.Windows.Forms.Button _btnCrearAutamaticamente;
        private System.Windows.Forms.ToolStripButton _tsbEliminarSalida;
        private System.Windows.Forms.RadioButton _rbtPowerFactory;

    }
}