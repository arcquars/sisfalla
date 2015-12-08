namespace Proyectos
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
            this._txtNombre = new Controles.CNDCTextBox();
            this.label2 = new Controles.CNDCLabel();
            this.label6 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this.label11 = new Controles.CNDCLabel();
            this._txtSigla = new Controles.CNDCTextBox();
            this._txtDireccion = new Controles.CNDCTextBox();
            this._txtTelefono = new Controles.CNDCTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dgvProyectos = new System.Windows.Forms.DataGridView();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this._tsbAgregarAgenteExistente = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminarAgente = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).BeginInit();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNombre
            // 
            this._txtNombre.BackColor = System.Drawing.Color.White;
            this._txtNombre.EnterComoTab = true;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNombre.Location = new System.Drawing.Point(175, 19);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(486, 22);
            this._txtNombre.TabIndex = 21;
            this._txtNombre.TablaCampoBD = "F_AP_PERSONA.NOM_PERSONA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 22;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(105, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 24;
            this.label6.TablaCampoBD = null;
            this.label6.Text = "Teléfono:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 18;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Sigla:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(58, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 16);
            this.label11.TabIndex = 16;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Nombre entidad:";
            // 
            // _txtSigla
            // 
            this._txtSigla.BackColor = System.Drawing.Color.White;
            this._txtSigla.EnterComoTab = true;
            this._txtSigla.Etiqueta = null;
            this._txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSigla.Location = new System.Drawing.Point(175, 42);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(160, 22);
            this._txtSigla.TabIndex = 25;
            this._txtSigla.TablaCampoBD = "F_AP_PERSONA.SIGLA";
            // 
            // _txtDireccion
            // 
            this._txtDireccion.BackColor = System.Drawing.Color.White;
            this._txtDireccion.EnterComoTab = true;
            this._txtDireccion.Etiqueta = null;
            this._txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDireccion.Location = new System.Drawing.Point(175, 65);
            this._txtDireccion.Name = "_txtDireccion";
            this._txtDireccion.Size = new System.Drawing.Size(486, 22);
            this._txtDireccion.TabIndex = 26;
            this._txtDireccion.TablaCampoBD = "F_AP_PERSONA.DIRECCION";
            // 
            // _txtTelefono
            // 
            this._txtTelefono.BackColor = System.Drawing.Color.White;
            this._txtTelefono.EnterComoTab = true;
            this._txtTelefono.Etiqueta = null;
            this._txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTelefono.Location = new System.Drawing.Point(175, 87);
            this._txtTelefono.Name = "_txtTelefono";
            this._txtTelefono.Size = new System.Drawing.Size(160, 22);
            this._txtTelefono.TabIndex = 27;
            this._txtTelefono.TablaCampoBD = "F_AP_PERSONA.TELEFONO";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._dgvProyectos);
            this.groupBox1.Controls.Add(this._txtNombre);
            this.groupBox1.Controls.Add(this._txtTelefono);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this._txtDireccion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._txtSigla);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 487);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // _dgvProyectos
            // 
            this._dgvProyectos.AllowUserToAddRows = false;
            this._dgvProyectos.AllowUserToDeleteRows = false;
            this._dgvProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvProyectos.Location = new System.Drawing.Point(6, 116);
            this._dgvProyectos.Name = "_dgvProyectos";
            this._dgvProyectos.ReadOnly = true;
            this._dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvProyectos.Size = new System.Drawing.Size(735, 365);
            this._dgvProyectos.TabIndex = 28;
            this._dgvProyectos.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            this._dgvProyectos.DoubleClick += new System.EventHandler(this._dgvProyectos_DoubleClick);
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._tsbNuevo,
            this._tsbAgregarAgenteExistente,
            this._tsbEliminarAgente});
            this._toolStrip.Location = new System.Drawing.Point(2, -1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(500, 25);
            this._toolStrip.TabIndex = 29;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::Proyectos.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(69, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(57, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(73, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // _tsbNuevo
            // 
            this._tsbNuevo.Image = global::Proyectos.Properties.Resources.InformeBlanco;
            this._tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNuevo.Name = "_tsbNuevo";
            this._tsbNuevo.Size = new System.Drawing.Size(62, 22);
            this._tsbNuevo.Text = "Nuevo";
            this._tsbNuevo.Click += new System.EventHandler(this._tsbNuevo_Click);
            // 
            // _tsbAgregarAgenteExistente
            // 
            this._tsbAgregarAgenteExistente.Image = global::Proyectos.Properties.Resources.InformeBlanco;
            this._tsbAgregarAgenteExistente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbAgregarAgenteExistente.Name = "_tsbAgregarAgenteExistente";
            this._tsbAgregarAgenteExistente.Size = new System.Drawing.Size(157, 22);
            this._tsbAgregarAgenteExistente.Text = "Agregar agente existente";
            this._tsbAgregarAgenteExistente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._tsbAgregarAgenteExistente.Click += new System.EventHandler(this._tsbAgregarAgenteExistente_Click);
            // 
            // _tsbEliminarAgente
            // 
            this._tsbEliminarAgente.Image = global::Proyectos.Properties.Resources.cancel;
            this._tsbEliminarAgente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarAgente.Name = "_tsbEliminarAgente";
            this._tsbEliminarAgente.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminarAgente.Text = "Eliminar";
            this._tsbEliminarAgente.Click += new System.EventHandler(this._tsbEliminarAgente_Click);
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
            this.ClientSize = new System.Drawing.Size(755, 513);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormEntidadResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar/editar entidad responsable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).EndInit();
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
        private System.Windows.Forms.DataGridView _dgvProyectos;
        private System.Windows.Forms.ToolStripButton _tsbNuevo;
        private System.Windows.Forms.ToolStripButton _tsbAgregarAgenteExistente;
        private System.Windows.Forms.ToolStripButton _tsbEliminarAgente;
    }
}