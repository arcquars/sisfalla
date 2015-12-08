namespace DemandasUI
{
    partial class FormEntidadResponsable
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
            this._btnEliminarNodoConexion = new System.Windows.Forms.Button();
            this._btnTipoAgente = new System.Windows.Forms.Button();
            this._txtTipoAgente = new Controles.CNDCTextBox();
            this.label5 = new Controles.CNDCLabel();
            this._dgvAgentes = new System.Windows.Forms.DataGridView();
            this._txtNombre = new Controles.CNDCTextBox();
            this._txtTelefono = new Controles.CNDCTextBox();
            this.label11 = new Controles.CNDCLabel();
            this._txtDireccion = new Controles.CNDCTextBox();
            this.label9 = new Controles.CNDCLabel();
            this._txtSigla = new Controles.CNDCTextBox();
            this.label6 = new Controles.CNDCLabel();
            this.label2 = new Controles.CNDCLabel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._tsbAsociarAgente = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).BeginInit();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._btnEliminarNodoConexion);
            this.groupBox1.Controls.Add(this._btnTipoAgente);
            this.groupBox1.Controls.Add(this._txtTipoAgente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._dgvAgentes);
            this.groupBox1.Controls.Add(this._txtNombre);
            this.groupBox1.Controls.Add(this._txtTelefono);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this._txtDireccion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._txtSigla);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 532);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // _btnEliminarNodoConexion
            // 
            this._btnEliminarNodoConexion.Image = global::DemandasUI.Properties.Resources.Delete;
            this._btnEliminarNodoConexion.Location = new System.Drawing.Point(467, 107);
            this._btnEliminarNodoConexion.Name = "_btnEliminarNodoConexion";
            this._btnEliminarNodoConexion.Size = new System.Drawing.Size(27, 21);
            this._btnEliminarNodoConexion.TabIndex = 61;
            this._btnEliminarNodoConexion.UseVisualStyleBackColor = true;
            this._btnEliminarNodoConexion.Click += new System.EventHandler(this._btnEliminarNodoConexion_Click);
            // 
            // _btnTipoAgente
            // 
            this._btnTipoAgente.Image = global::DemandasUI.Properties.Resources.Add;
            this._btnTipoAgente.Location = new System.Drawing.Point(439, 107);
            this._btnTipoAgente.Name = "_btnTipoAgente";
            this._btnTipoAgente.Size = new System.Drawing.Size(27, 21);
            this._btnTipoAgente.TabIndex = 60;
            this._btnTipoAgente.UseVisualStyleBackColor = true;
            this._btnTipoAgente.Click += new System.EventHandler(this._btnTipoAgente_Click);
            // 
            // _txtTipoAgente
            // 
            this._txtTipoAgente.BackColor = System.Drawing.Color.Gainsboro;
            this._txtTipoAgente.Enabled = false;
            this._txtTipoAgente.EnterComoTab = false;
            this._txtTipoAgente.Etiqueta = null;
            this._txtTipoAgente.Location = new System.Drawing.Point(212, 108);
            this._txtTipoAgente.Name = "_txtTipoAgente";
            this._txtTipoAgente.ReadOnly = true;
            this._txtTipoAgente.Size = new System.Drawing.Size(223, 20);
            this._txtTipoAgente.TabIndex = 59;
            this._txtTipoAgente.TablaCampoBD = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 58;
            this.label5.TablaCampoBD = null;
            this.label5.Text = "Tipo Agente:";
            // 
            // _dgvAgentes
            // 
            this._dgvAgentes.AllowUserToAddRows = false;
            this._dgvAgentes.AllowUserToDeleteRows = false;
            this._dgvAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvAgentes.Location = new System.Drawing.Point(6, 137);
            this._dgvAgentes.Name = "_dgvAgentes";
            this._dgvAgentes.ReadOnly = true;
            this._dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentes.Size = new System.Drawing.Size(785, 389);
            this._dgvAgentes.TabIndex = 28;
            this._dgvAgentes.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.White;
            this._txtNombre.EnterComoTab = true;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(212, 19);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(486, 22);
            this._txtNombre.TabIndex = 21;
            this._txtNombre.TablaCampoBD = "F_AP_PERSONA.NOM_PERSONA";
            // 
            // _txtTelefono
            // 
            this._txtTelefono.BackColor = System.Drawing.Color.White;
            this._txtTelefono.EnterComoTab = true;
            this._txtTelefono.Etiqueta = null;
            this._txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTelefono.Location = new System.Drawing.Point(212, 85);
            this._txtTelefono.Name = "_txtTelefono";
            this._txtTelefono.Size = new System.Drawing.Size(160, 22);
            this._txtTelefono.TabIndex = 27;
            this._txtTelefono.TablaCampoBD = "F_AP_PERSONA.TELEFONO";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(155, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 16;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nombre:";
            // 
            // _txtDireccion
            // 
            this._txtDireccion.BackColor = System.Drawing.Color.White;
            this._txtDireccion.EnterComoTab = true;
            this._txtDireccion.Etiqueta = null;
            this._txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDireccion.Location = new System.Drawing.Point(212, 63);
            this._txtDireccion.Name = "_txtDireccion";
            this._txtDireccion.Size = new System.Drawing.Size(486, 22);
            this._txtDireccion.TabIndex = 26;
            this._txtDireccion.TablaCampoBD = "F_AP_PERSONA.DIRECCION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(169, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 18;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Sigla:";
            // 
            // _txtSigla
            // 
            this._txtSigla.BackColor = System.Drawing.Color.White;
            this._txtSigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtSigla.EnterComoTab = true;
            this._txtSigla.Etiqueta = null;
            this._txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSigla.Location = new System.Drawing.Point(212, 41);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(160, 22);
            this._txtSigla.TabIndex = 25;
            this._txtSigla.TablaCampoBD = "F_AP_PERSONA.SIGLA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 24;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Teléfono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 22;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Dirección:";
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._tsbEliminar,
            this._tsbNuevo,
            this._tsbAsociarAgente});
            this._toolStrip.Location = new System.Drawing.Point(2, -1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(497, 25);
            this._toolStrip.TabIndex = 29;
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
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::DemandasUI.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(73, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _tsbEliminar
            // 
            this._tsbEliminar.Image = global::DemandasUI.Properties.Resources.cancel;
            this._tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminar.Name = "_tsbEliminar";
            this._tsbEliminar.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminar.Text = "Eliminar";
            this._tsbEliminar.Click += new System.EventHandler(this._tsbEliminar_Click);
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
            // _tsbAsociarAgente
            // 
            this._tsbAsociarAgente.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbAsociarAgente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbAsociarAgente.Name = "_tsbAsociarAgente";
            this._tsbAsociarAgente.Size = new System.Drawing.Size(154, 22);
            this._tsbAsociarAgente.Text = "Asociar agente existente";
            this._tsbAsociarAgente.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormEntidadResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 555);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormEntidadResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar/Editar agentes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel label2;
        private Controles.CNDCLabel label6;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBox _txtSigla;
        private Controles.CNDCTextBox _txtDireccion;
        private Controles.CNDCTextBox _txtTelefono;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.DataGridView _dgvAgentes;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private System.Windows.Forms.ToolStripButton _tsbEliminar;
        private System.Windows.Forms.Button _btnEliminarNodoConexion;
        private System.Windows.Forms.Button _btnTipoAgente;
        private Controles.CNDCTextBox _txtTipoAgente;
        private Controles.CNDCLabel label5;
        private System.Windows.Forms.ToolStripButton _tsbAsociarAgente;
    }
}