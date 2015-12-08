namespace CNDC.BaseForms
{
    partial class ABMMainBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMMainBaseForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnInsertar = new System.Windows.Forms.ToolStripButton();
            this._btnDarBaja = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._btnRecargar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._tsLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this._grid = new System.Windows.Forms.DataGridView();
            this._menu = new System.Windows.Forms.MenuStrip();
            this._bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnInsertar,
            this._btnDarBaja,
            this._btnEditar,
            this._btnEliminar,
            this._btnRecargar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(759, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btnInsertar
            // 
            this._btnInsertar.Image = global::CNDC.BaseForms.Properties.Resources.Add;
            this._btnInsertar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnInsertar.Name = "_btnInsertar";
            this._btnInsertar.Size = new System.Drawing.Size(66, 22);
            this._btnInsertar.Text = "Insertar";
            this._btnInsertar.Click += new System.EventHandler(this._btnInsertar_Click);
            // 
            // _btnDarBaja
            // 
            this._btnDarBaja.Image = global::CNDC.BaseForms.Properties.Resources.disable__v3929;
            this._btnDarBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnDarBaja.Name = "_btnDarBaja";
            this._btnDarBaja.Size = new System.Drawing.Size(83, 22);
            this._btnDarBaja.Text = "Dar de Baja";
            this._btnDarBaja.Click += new System.EventHandler(this._btnDarBaja_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.Image = global::CNDC.BaseForms.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(55, 22);
            this._btnEditar.Text = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.Image = global::CNDC.BaseForms.Properties.Resources.Delete;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(63, 22);
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // _btnRecargar
            // 
            this._btnRecargar.Image = global::CNDC.BaseForms.Properties.Resources.Refresh;
            this._btnRecargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnRecargar.Name = "_btnRecargar";
            this._btnRecargar.Size = new System.Drawing.Size(71, 22);
            this._btnRecargar.Text = "Recargar";
            this._btnRecargar.Click += new System.EventHandler(this._btnRecargar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsLblStatus,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(759, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _tsLblStatus
            // 
            this._tsLblStatus.AutoSize = false;
            this._tsLblStatus.Name = "_tsLblStatus";
            this._tsLblStatus.Size = new System.Drawing.Size(120, 17);
            this._tsLblStatus.Text = "Status";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 49);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(759, 435);
            this._grid.TabIndex = 2;
            // 
            // _menu
            // 
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(759, 24);
            this._menu.TabIndex = 3;
            this._menu.Text = "menuStrip1";
            // 
            // ABMMainBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 506);
            this.Controls.Add(this._grid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menu;
            this.Name = "ABMMainBaseForm";
            this.Text = "Título";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel _tsLblStatus;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.BindingSource _bindingSource;
        protected System.Windows.Forms.MenuStrip _menu;
        protected System.Windows.Forms.ToolStripButton _btnInsertar;
        protected System.Windows.Forms.ToolStripButton _btnDarBaja;
        protected System.Windows.Forms.ToolStripButton _btnEditar;
        protected System.Windows.Forms.ToolStripButton _btnEliminar;
        protected System.Windows.Forms.ToolStripButton _btnRecargar;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.DataGridView _grid;
    }
}