namespace DemandasUI
{
    partial class FormAsignarNodosDeConexion
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
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._gbxNodosConectados = new System.Windows.Forms.GroupBox();
            this._lbxNodosConectados = new System.Windows.Forms.ListBox();
            this._tsbNodosHijosProyectos = new System.Windows.Forms.ToolStrip();
            this._tsbAdicionarNodoHijoProy = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminarNodoHijoProy = new System.Windows.Forms.ToolStripButton();
            this._gbxNodosDemanda = new System.Windows.Forms.GroupBox();
            this._lbxNodosDemanda = new System.Windows.Forms.ListBox();
            this._tsbNodosDemanda = new System.Windows.Forms.ToolStrip();
            this._tsbAdicionarNodoProy = new System.Windows.Forms.ToolStripButton();
            this._tsbAsignarNodosSalida = new System.Windows.Forms.ToolStripButton();
            this._tsbEliminarNodosProy = new System.Windows.Forms.ToolStripButton();
            this._gbxTipoAgente = new System.Windows.Forms.GroupBox();
            this._rbtNoRegulados = new System.Windows.Forms.RadioButton();
            this._rbtProyectos = new System.Windows.Forms.RadioButton();
            this._rbtDistribucion = new System.Windows.Forms.RadioButton();
            this._rbtSisAislados = new System.Windows.Forms.RadioButton();
            this._dgvAgentes = new System.Windows.Forms.DataGridView();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._toolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._gbxNodosConectados.SuspendLayout();
            this._tsbNodosHijosProyectos.SuspendLayout();
            this._gbxNodosDemanda.SuspendLayout();
            this._tsbNodosDemanda.SuspendLayout();
            this._gbxTipoAgente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(3, 1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(211, 25);
            this._toolStrip.TabIndex = 33;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._gbxNodosConectados);
            this.groupBox1.Controls.Add(this._gbxNodosDemanda);
            this.groupBox1.Controls.Add(this._gbxTipoAgente);
            this.groupBox1.Controls.Add(this._dgvAgentes);
            this.groupBox1.Location = new System.Drawing.Point(3, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 576);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // _gbxNodosConectados
            // 
            this._gbxNodosConectados.Controls.Add(this._lbxNodosConectados);
            this._gbxNodosConectados.Controls.Add(this._tsbNodosHijosProyectos);
            this._gbxNodosConectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gbxNodosConectados.Location = new System.Drawing.Point(350, 236);
            this._gbxNodosConectados.Name = "_gbxNodosConectados";
            this._gbxNodosConectados.Size = new System.Drawing.Size(294, 334);
            this._gbxNodosConectados.TabIndex = 44;
            this._gbxNodosConectados.TabStop = false;
            this._gbxNodosConectados.Text = "Nodos ";
            this._gbxNodosConectados.Enter += new System.EventHandler(this._gbxNodosConectados_Enter);
            // 
            // _lbxNodosConectados
            // 
            this._lbxNodosConectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbxNodosConectados.FormattingEnabled = true;
            this._lbxNodosConectados.ItemHeight = 16;
            this._lbxNodosConectados.Location = new System.Drawing.Point(5, 21);
            this._lbxNodosConectados.Name = "_lbxNodosConectados";
            this._lbxNodosConectados.Size = new System.Drawing.Size(267, 276);
            this._lbxNodosConectados.TabIndex = 35;
            this._lbxNodosConectados.SelectedIndexChanged += new System.EventHandler(this._lbxNodosConectados_SelectedIndexChanged);
            // 
            // _tsbNodosHijosProyectos
            // 
            this._tsbNodosHijosProyectos.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbNodosHijosProyectos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbAdicionarNodoHijoProy,
            this._tsbEliminarNodoHijoProy});
            this._tsbNodosHijosProyectos.Location = new System.Drawing.Point(4, 304);
            this._tsbNodosHijosProyectos.Name = "_tsbNodosHijosProyectos";
            this._tsbNodosHijosProyectos.Size = new System.Drawing.Size(160, 25);
            this._tsbNodosHijosProyectos.TabIndex = 36;
            // 
            // _tsbAdicionarNodoHijoProy
            // 
            this._tsbAdicionarNodoHijoProy.Image = global::DemandasUI.Properties.Resources.Add;
            this._tsbAdicionarNodoHijoProy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbAdicionarNodoHijoProy.Name = "_tsbAdicionarNodoHijoProy";
            this._tsbAdicionarNodoHijoProy.Size = new System.Drawing.Size(78, 22);
            this._tsbAdicionarNodoHijoProy.Text = "Adicionar";
            this._tsbAdicionarNodoHijoProy.Click += new System.EventHandler(this._tsbAdicionarNodoConexion_Click);
            // 
            // _tsbEliminarNodoHijoProy
            // 
            this._tsbEliminarNodoHijoProy.Image = global::DemandasUI.Properties.Resources.cancel;
            this._tsbEliminarNodoHijoProy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarNodoHijoProy.Name = "_tsbEliminarNodoHijoProy";
            this._tsbEliminarNodoHijoProy.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminarNodoHijoProy.Text = "Eliminar";
            this._tsbEliminarNodoHijoProy.Click += new System.EventHandler(this._tsbEliminarNodoHijoProy_Click);
            // 
            // _gbxNodosDemanda
            // 
            this._gbxNodosDemanda.Controls.Add(this._lbxNodosDemanda);
            this._gbxNodosDemanda.Controls.Add(this._tsbNodosDemanda);
            this._gbxNodosDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gbxNodosDemanda.Location = new System.Drawing.Point(32, 236);
            this._gbxNodosDemanda.Name = "_gbxNodosDemanda";
            this._gbxNodosDemanda.Size = new System.Drawing.Size(312, 334);
            this._gbxNodosDemanda.TabIndex = 42;
            this._gbxNodosDemanda.TabStop = false;
            this._gbxNodosDemanda.Text = "Nodos de agregación";
            // 
            // _lbxNodosDemanda
            // 
            this._lbxNodosDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbxNodosDemanda.FormattingEnabled = true;
            this._lbxNodosDemanda.ItemHeight = 16;
            this._lbxNodosDemanda.Location = new System.Drawing.Point(5, 22);
            this._lbxNodosDemanda.Name = "_lbxNodosDemanda";
            this._lbxNodosDemanda.Size = new System.Drawing.Size(285, 276);
            this._lbxNodosDemanda.TabIndex = 35;
            this._lbxNodosDemanda.SelectedIndexChanged += new System.EventHandler(this._lbxNodosDemanda_SelectedIndexChanged);
            // 
            // _tsbNodosDemanda
            // 
            this._tsbNodosDemanda.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbNodosDemanda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbAdicionarNodoProy,
            this._tsbAsignarNodosSalida,
            this._tsbEliminarNodosProy});
            this._tsbNodosDemanda.Location = new System.Drawing.Point(3, 306);
            this._tsbNodosDemanda.Name = "_tsbNodosDemanda";
            this._tsbNodosDemanda.Size = new System.Drawing.Size(289, 25);
            this._tsbNodosDemanda.TabIndex = 36;
            // 
            // _tsbAdicionarNodoProy
            // 
            this._tsbAdicionarNodoProy.Image = global::DemandasUI.Properties.Resources.Add;
            this._tsbAdicionarNodoProy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbAdicionarNodoProy.Name = "_tsbAdicionarNodoProy";
            this._tsbAdicionarNodoProy.Size = new System.Drawing.Size(78, 22);
            this._tsbAdicionarNodoProy.Text = "Adicionar";
            this._tsbAdicionarNodoProy.Click += new System.EventHandler(this._tsbAdicionarNodoProy_Click);
            // 
            // _tsbAsignarNodosSalida
            // 
            this._tsbAsignarNodosSalida.Image = global::DemandasUI.Properties.Resources.InformeBlanco;
            this._tsbAsignarNodosSalida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbAsignarNodosSalida.Name = "_tsbAsignarNodosSalida";
            this._tsbAsignarNodosSalida.Size = new System.Drawing.Size(129, 22);
            this._tsbAsignarNodosSalida.Text = "Asigar nodos salida";
            this._tsbAsignarNodosSalida.Click += new System.EventHandler(this._tsbAsignarNodosSalida_Click);
            // 
            // _tsbEliminarNodosProy
            // 
            this._tsbEliminarNodosProy.Image = global::DemandasUI.Properties.Resources.cancel;
            this._tsbEliminarNodosProy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarNodosProy.Name = "_tsbEliminarNodosProy";
            this._tsbEliminarNodosProy.Size = new System.Drawing.Size(70, 22);
            this._tsbEliminarNodosProy.Text = "Eliminar";
            this._tsbEliminarNodosProy.Click += new System.EventHandler(this._tsbEliminarNodosProy_Click);
            // 
            // _gbxTipoAgente
            // 
            this._gbxTipoAgente.Controls.Add(this._rbtNoRegulados);
            this._gbxTipoAgente.Controls.Add(this._rbtProyectos);
            this._gbxTipoAgente.Controls.Add(this._rbtDistribucion);
            this._gbxTipoAgente.Controls.Add(this._rbtSisAislados);
            this._gbxTipoAgente.Location = new System.Drawing.Point(32, 8);
            this._gbxTipoAgente.Name = "_gbxTipoAgente";
            this._gbxTipoAgente.Size = new System.Drawing.Size(659, 41);
            this._gbxTipoAgente.TabIndex = 40;
            this._gbxTipoAgente.TabStop = false;
            this._gbxTipoAgente.Text = "Tipo demanda";
            // 
            // _rbtNoRegulados
            // 
            this._rbtNoRegulados.AutoSize = true;
            this._rbtNoRegulados.Location = new System.Drawing.Point(367, 18);
            this._rbtNoRegulados.Name = "_rbtNoRegulados";
            this._rbtNoRegulados.Size = new System.Drawing.Size(101, 17);
            this._rbtNoRegulados.TabIndex = 40;
            this._rbtNoRegulados.TabStop = true;
            this._rbtNoRegulados.Text = "C. No Regulado";
            this._rbtNoRegulados.UseVisualStyleBackColor = true;
            this._rbtNoRegulados.CheckedChanged += new System.EventHandler(this._rbtNoRegulados_CheckedChanged);
            // 
            // _rbtProyectos
            // 
            this._rbtProyectos.AutoSize = true;
            this._rbtProyectos.Location = new System.Drawing.Point(266, 17);
            this._rbtProyectos.Name = "_rbtProyectos";
            this._rbtProyectos.Size = new System.Drawing.Size(67, 17);
            this._rbtProyectos.TabIndex = 39;
            this._rbtProyectos.TabStop = true;
            this._rbtProyectos.Text = "Proyecto";
            this._rbtProyectos.UseVisualStyleBackColor = true;
            this._rbtProyectos.CheckedChanged += new System.EventHandler(this._rbtProyectos_CheckedChanged);
            // 
            // _rbtDistribucion
            // 
            this._rbtDistribucion.AutoSize = true;
            this._rbtDistribucion.Location = new System.Drawing.Point(20, 17);
            this._rbtDistribucion.Name = "_rbtDistribucion";
            this._rbtDistribucion.Size = new System.Drawing.Size(77, 17);
            this._rbtDistribucion.TabIndex = 37;
            this._rbtDistribucion.TabStop = true;
            this._rbtDistribucion.Text = "Distribuidor";
            this._rbtDistribucion.UseVisualStyleBackColor = true;
            this._rbtDistribucion.CheckedChanged += new System.EventHandler(this._rbtDistribucion_CheckedChanged);
            // 
            // _rbtSisAislados
            // 
            this._rbtSisAislados.AutoSize = true;
            this._rbtSisAislados.Location = new System.Drawing.Point(133, 17);
            this._rbtSisAislados.Name = "_rbtSisAislados";
            this._rbtSisAislados.Size = new System.Drawing.Size(99, 17);
            this._rbtSisAislados.TabIndex = 38;
            this._rbtSisAislados.TabStop = true;
            this._rbtSisAislados.Text = "Sistema Aislado";
            this._rbtSisAislados.UseVisualStyleBackColor = true;
            this._rbtSisAislados.CheckedChanged += new System.EventHandler(this._rbtSisAislados_CheckedChanged);
            // 
            // _dgvAgentes
            // 
            this._dgvAgentes.AllowUserToAddRows = false;
            this._dgvAgentes.AllowUserToDeleteRows = false;
            this._dgvAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvAgentes.Location = new System.Drawing.Point(32, 51);
            this._dgvAgentes.Name = "_dgvAgentes";
            this._dgvAgentes.ReadOnly = true;
            this._dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentes.Size = new System.Drawing.Size(659, 183);
            this._dgvAgentes.TabIndex = 28;
            this._dgvAgentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvAgentes_CellContentClick);
            this._dgvAgentes.SelectionChanged += new System.EventHandler(this._dgvAgentes_SelectionChanged);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormAsignarNodosDeConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 604);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAsignarNodosDeConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar nodos de conexión";
            this.Load += new System.EventHandler(this.FormAsignarNodosDeConexion_Load);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this._gbxNodosConectados.ResumeLayout(false);
            this._gbxNodosConectados.PerformLayout();
            this._tsbNodosHijosProyectos.ResumeLayout(false);
            this._tsbNodosHijosProyectos.PerformLayout();
            this._gbxNodosDemanda.ResumeLayout(false);
            this._gbxNodosDemanda.PerformLayout();
            this._tsbNodosDemanda.ResumeLayout(false);
            this._tsbNodosDemanda.PerformLayout();
            this._gbxTipoAgente.ResumeLayout(false);
            this._gbxTipoAgente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView _dgvAgentes;
        private System.Windows.Forms.ToolStrip _tsbNodosDemanda;
        private System.Windows.Forms.ToolStripButton _tsbAdicionarNodoProy;
        private System.Windows.Forms.ToolStripButton _tsbEliminarNodosProy;
        private System.Windows.Forms.ListBox _lbxNodosDemanda;
        private System.Windows.Forms.RadioButton _rbtProyectos;
        private System.Windows.Forms.RadioButton _rbtSisAislados;
        private System.Windows.Forms.RadioButton _rbtDistribucion;
        private System.Windows.Forms.GroupBox _gbxTipoAgente;
        private System.Windows.Forms.GroupBox _gbxNodosDemanda;
        private System.Windows.Forms.GroupBox _gbxNodosConectados;
        private System.Windows.Forms.ListBox _lbxNodosConectados;
        private System.Windows.Forms.ToolStrip _tsbNodosHijosProyectos;
        private System.Windows.Forms.ToolStripButton _tsbAdicionarNodoHijoProy;
        private System.Windows.Forms.ToolStripButton _tsbEliminarNodoHijoProy;
        private System.Windows.Forms.RadioButton _rbtNoRegulados;
        private System.Windows.Forms.ToolStripButton _tsbAsignarNodosSalida;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}