namespace Proyectos
{
    partial class CtrlPrincipalTop
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
            this._gbxProyectos = new Controles.CNDCGroupBox();
            this._lblT = new Controles.CNDCLabel();
            this._dgvEstadosDeProyecto = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._tsbInsertarProyecto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._tsbEliminarProyecto = new System.Windows.Forms.ToolStripButton();
            this._gbxProyectosMaestro = new Controles.CNDCGroupBox();
            this._dgvProyectos = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnInsertar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tabABM = new System.Windows.Forms.TabControl();
            this._gbxProyectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEstadosDeProyecto)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this._gbxProyectosMaestro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbxProyectos
            // 
            this._gbxProyectos.Controls.Add(this._lblT);
            this._gbxProyectos.Controls.Add(this._dgvEstadosDeProyecto);
            this._gbxProyectos.Controls.Add(this.toolStrip2);
            this._gbxProyectos.Location = new System.Drawing.Point(516, 1);
            this._gbxProyectos.Name = "_gbxProyectos";
            this._gbxProyectos.Size = new System.Drawing.Size(516, 165);
            this._gbxProyectos.TabIndex = 6;
            this._gbxProyectos.TablaCampoBD = null;
            this._gbxProyectos.TabStop = false;
            this._gbxProyectos.Text = "Etapas del Proyecto";
            // 
            // _lblT
            // 
            this._lblT.AutoSize = true;
            this._lblT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblT.Location = new System.Drawing.Point(204, 21);
            this._lblT.Name = "_lblT";
            this._lblT.Size = new System.Drawing.Size(0, 13);
            this._lblT.TabIndex = 8;
            this._lblT.TablaCampoBD = null;
            // 
            // _dgvEstadosDeProyecto
            // 
            this._dgvEstadosDeProyecto.AllowUserToAddRows = false;
            this._dgvEstadosDeProyecto.AllowUserToDeleteRows = false;
            this._dgvEstadosDeProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvEstadosDeProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEstadosDeProyecto.Location = new System.Drawing.Point(3, 40);
            this._dgvEstadosDeProyecto.MultiSelect = false;
            this._dgvEstadosDeProyecto.Name = "_dgvEstadosDeProyecto";
            this._dgvEstadosDeProyecto.ReadOnly = true;
            this._dgvEstadosDeProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dgvEstadosDeProyecto.Size = new System.Drawing.Size(508, 119);
            this._dgvEstadosDeProyecto.TabIndex = 2;
            this._dgvEstadosDeProyecto.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvEstadosDeProyecto_CellEnter);
            this._dgvEstadosDeProyecto.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvEstadosDeProyecto_CellFormatting);
            this._dgvEstadosDeProyecto.SelectionChanged += new System.EventHandler(this._dgvEstadosDeProyecto_SelectionChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbInsertarProyecto,
            this.toolStripSeparator2,
            this._tsbEliminarProyecto});
            this.toolStrip2.Location = new System.Drawing.Point(3, 14);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(145, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _tsbInsertarProyecto
            // 
            this._tsbInsertarProyecto.Image = global::Proyectos.Properties.Resources.Add;
            this._tsbInsertarProyecto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbInsertarProyecto.Name = "_tsbInsertarProyecto";
            this._tsbInsertarProyecto.Size = new System.Drawing.Size(66, 22);
            this._tsbInsertarProyecto.Text = "Insertar";
            this._tsbInsertarProyecto.Click += new System.EventHandler(this._tsbInsertarProyecto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _tsbEliminarProyecto
            // 
            this._tsbEliminarProyecto.Image = global::Proyectos.Properties.Resources.cancel;
            this._tsbEliminarProyecto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarProyecto.Name = "_tsbEliminarProyecto";
            this._tsbEliminarProyecto.Size = new System.Drawing.Size(63, 22);
            this._tsbEliminarProyecto.Text = "Eliminar";
            this._tsbEliminarProyecto.Click += new System.EventHandler(this._tsbEliminarProyecto_Click);
            // 
            // _gbxProyectosMaestro
            // 
            this._gbxProyectosMaestro.Controls.Add(this._dgvProyectos);
            this._gbxProyectosMaestro.Controls.Add(this.toolStrip1);
            this._gbxProyectosMaestro.Location = new System.Drawing.Point(3, 1);
            this._gbxProyectosMaestro.Name = "_gbxProyectosMaestro";
            this._gbxProyectosMaestro.Size = new System.Drawing.Size(509, 165);
            this._gbxProyectosMaestro.TabIndex = 5;
            this._gbxProyectosMaestro.TablaCampoBD = null;
            this._gbxProyectosMaestro.TabStop = false;
            this._gbxProyectosMaestro.Text = "Proyectos";
            // 
            // _dgvProyectos
            // 
            this._dgvProyectos.AllowUserToAddRows = false;
            this._dgvProyectos.AllowUserToDeleteRows = false;
            this._dgvProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvProyectos.Location = new System.Drawing.Point(4, 38);
            this._dgvProyectos.Name = "_dgvProyectos";
            this._dgvProyectos.ReadOnly = true;
            this._dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvProyectos.Size = new System.Drawing.Size(499, 121);
            this._dgvProyectos.TabIndex = 2;
            this._dgvProyectos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvProyectos_CellFormatting);
            this._dgvProyectos.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnInsertar,
            this._btnEditar,
            this._btnEliminar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(4, 14);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(200, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Ver";
            // 
            // _btnInsertar
            // 
            this._btnInsertar.Image = global::Proyectos.Properties.Resources.Add;
            this._btnInsertar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnInsertar.Name = "_btnInsertar";
            this._btnInsertar.Size = new System.Drawing.Size(66, 22);
            this._btnInsertar.Text = "Insertar";
            this._btnInsertar.Click += new System.EventHandler(this._btnInsertar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(55, 22);
            this._btnEditar.Text = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.Image = global::Proyectos.Properties.Resources.cancel;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(63, 22);
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _tabABM
            // 
            this._tabABM.Location = new System.Drawing.Point(5, 171);
            this._tabABM.Name = "_tabABM";
            this._tabABM.SelectedIndex = 0;
            this._tabABM.Size = new System.Drawing.Size(1027, 256);
            this._tabABM.TabIndex = 7;
            this._tabABM.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._tabABM_Selecting);
            // 
            // CtrlPrincipalTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this._tabABM);
            this.Controls.Add(this._gbxProyectos);
            this.Controls.Add(this._gbxProyectosMaestro);
            this.Name = "CtrlPrincipalTop";
            this.Size = new System.Drawing.Size(1036, 430);
            this._gbxProyectos.ResumeLayout(false);
            this._gbxProyectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEstadosDeProyecto)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this._gbxProyectosMaestro.ResumeLayout(false);
            this._gbxProyectosMaestro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvEstadosDeProyecto;
        private System.Windows.Forms.ToolStrip toolStrip2;
        protected System.Windows.Forms.ToolStripButton _tsbInsertarProyecto;
        protected System.Windows.Forms.ToolStripButton _tsbEliminarProyecto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView _dgvProyectos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton _btnInsertar;
        protected System.Windows.Forms.ToolStripButton _btnEditar;
        protected System.Windows.Forms.ToolStripButton _btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controles.CNDCGroupBox _gbxProyectos;
        private Controles.CNDCLabel _lblT;
        private Controles.CNDCGroupBox _gbxProyectosMaestro;
        private System.Windows.Forms.TabControl _tabABM;
    }
}
