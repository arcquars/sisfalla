using System;
using System.Configuration;

namespace SISFALLA
{
    partial class SisFallaPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

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
            this.cndcToolTip1 = new Controles.CNDCToolTip();
            this._dgvFallas = new Controles.CNDCGridView();
            this._dgvUsuarios = new Controles.CNDCGridView();
            this.ColNotif = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColPrelim = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColFinal = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColRectif = new System.Windows.Forms.DataGridViewImageColumn();
            this._timerSinc = new System.Windows.Forms.Timer(this.components);
            this._bscFailures = new System.Windows.Forms.BindingSource(this.components);
            this._bscUsers = new System.Windows.Forms.BindingSource(this.components);
            this._pnlPrincipal = new Controles.CNDCPanelControl();
            this._pnlAgentesInvolucrados = new Controles.CNDCPanelControl();
            this._ctrlSincronizacion = new SISFALLA.CtrlSincronizacion();
            this._pnlVerInformes = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnVerInfPreliminar = new System.Windows.Forms.ToolStripButton();
            this._btnVerInfFinal = new System.Windows.Forms.ToolStripButton();
            this._btnVerInfRectificatorio = new System.Windows.Forms.ToolStripButton();
            this._pnlBotones = new Controles.CNDCPanelControl();
            this._txtFiltroNumeroFalla = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._cmbVista = new Controles.CNDCComboBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._btnPublicar = new Controles.CNDCButton();

            this._btnSincronizar = new Controles.CNDCButton();

            this._bgWorker = new System.ComponentModel.BackgroundWorker();
            this._cmDescargarFalla = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tbsDescargarInformesDeFalla = new System.Windows.Forms.ToolStripMenuItem();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte2 = new repSisfalla.CachedplantillaReporte();
            this.cachedplantillaReporte3 = new repSisfalla.CachedplantillaReporte();
            this.bgwSincronizadorFallas = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._dgvFallas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscFailures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscUsers)).BeginInit();
            this._pnlPrincipal.SuspendLayout();
            this._pnlAgentesInvolucrados.SuspendLayout();
            this._pnlVerInformes.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this._pnlBotones.SuspendLayout();
            this._cmDescargarFalla.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcToolTip1
            // 
            this.cndcToolTip1.TablaCampoBD = null;
            // 
            // _dgvFallas
            // 
            this._dgvFallas.AllowUserToAddRows = false;
            this._dgvFallas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvFallas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvFallas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvFallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvFallas.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvFallas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvFallas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvFallas.Location = new System.Drawing.Point(0, 33);
            this._dgvFallas.Name = "_dgvFallas";
            this._dgvFallas.NombreContenedor = "SisFallaPrincipal";
            this._dgvFallas.ReadOnly = true;
            this._dgvFallas.RowHeadersWidth = 25;
            this._dgvFallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvFallas.Size = new System.Drawing.Size(528, 191);
            this._dgvFallas.TabIndex = 1;
            this._dgvFallas.TablaCampoBD = null;
            this._dgvFallas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvFallas_CellFormatting);
            this._dgvFallas.SelectionChanged += new System.EventHandler(this._dgvFallas_SelectionChanged);
            this._dgvFallas.DoubleClick += new System.EventHandler(this._dgvFallas_DoubleClick);
            // 
            // _dgvUsuarios
            // 
            this._dgvUsuarios.AllowUserToAddRows = false;
            this._dgvUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNotif,
            this.ColPrelim,
            this.ColFinal,
            this.ColRectif});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvUsuarios.Location = new System.Drawing.Point(0, 23);
            this._dgvUsuarios.Name = "_dgvUsuarios";
            this._dgvUsuarios.NombreContenedor = "SisFallaPrincipal";
            this._dgvUsuarios.ReadOnly = true;
            this._dgvUsuarios.RowHeadersWidth = 25;
            this._dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvUsuarios.Size = new System.Drawing.Size(272, 145);
            this._dgvUsuarios.TabIndex = 1;
            this._dgvUsuarios.TablaCampoBD = null;
            this._dgvUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvUsuarios_CellFormatting);
            this._dgvUsuarios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._dgvUsuarios_DataError);
            this._dgvUsuarios.SelectionChanged += new System.EventHandler(this._dgvUsuarios_SelectionChanged);
            // 
            // ColNotif
            // 
            this.ColNotif.HeaderText = "Notif";
            this.ColNotif.Name = "ColNotif";
            this.ColNotif.ReadOnly = true;
            this.ColNotif.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColPrelim
            // 
            this.ColPrelim.HeaderText = "Prelim";
            this.ColPrelim.Name = "ColPrelim";
            this.ColPrelim.ReadOnly = true;
            this.ColPrelim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColFinal
            // 
            this.ColFinal.HeaderText = "Final";
            this.ColFinal.Name = "ColFinal";
            this.ColFinal.ReadOnly = true;
            this.ColFinal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColRectif
            // 
            this.ColRectif.HeaderText = "Rectif";
            this.ColRectif.Name = "ColRectif";
            this.ColRectif.ReadOnly = true;
            this.ColRectif.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _timerSinc
            // 
            this._timerSinc.Interval = 10000;
            this._timerSinc.Tick += new System.EventHandler(this._sincTimer_Tick);
            // 
            // _pnlPrincipal
            // 
            this._pnlPrincipal.Controls.Add(this._dgvFallas);
            this._pnlPrincipal.Controls.Add(this._pnlAgentesInvolucrados);
            this._pnlPrincipal.Controls.Add(this._pnlBotones);
            this._pnlPrincipal.Location = new System.Drawing.Point(45, 49);
            this._pnlPrincipal.MinimumSize = new System.Drawing.Size(800, 0);
            this._pnlPrincipal.Name = "_pnlPrincipal";
            this._pnlPrincipal.Size = new System.Drawing.Size(800, 224);
            this._pnlPrincipal.TabIndex = 3;
            this._pnlPrincipal.TablaCampoBD = null;
            this._pnlPrincipal.Visible = false;
            // 
            // _pnlAgentesInvolucrados
            // 
            this._pnlAgentesInvolucrados.Controls.Add(this.panel1);
            this._pnlAgentesInvolucrados.Controls.Add(this._dgvUsuarios);
            this._pnlAgentesInvolucrados.Controls.Add(this._ctrlSincronizacion);
            this._pnlAgentesInvolucrados.Controls.Add(this._pnlVerInformes);
            this._pnlAgentesInvolucrados.Dock = System.Windows.Forms.DockStyle.Right;
            this._pnlAgentesInvolucrados.Location = new System.Drawing.Point(528, 33);
            this._pnlAgentesInvolucrados.Name = "_pnlAgentesInvolucrados";
            this._pnlAgentesInvolucrados.Size = new System.Drawing.Size(272, 191);
            this._pnlAgentesInvolucrados.TabIndex = 2;
            this._pnlAgentesInvolucrados.TablaCampoBD = null;
            // 
            // _ctrlSincronizacion
            // 
            this._ctrlSincronizacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ctrlSincronizacion.Location = new System.Drawing.Point(0, 168);
            this._ctrlSincronizacion.Name = "_ctrlSincronizacion";
            this._ctrlSincronizacion.Size = new System.Drawing.Size(272, 23);
            this._ctrlSincronizacion.TabIndex = 3;
            // 
            // _pnlVerInformes
            // 
            this._pnlVerInformes.Controls.Add(this.cndcToolStrip1);
            this._pnlVerInformes.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlVerInformes.Location = new System.Drawing.Point(0, 0);
            this._pnlVerInformes.Name = "_pnlVerInformes";
            this._pnlVerInformes.Size = new System.Drawing.Size(272, 23);
            this._pnlVerInformes.TabIndex = 2;
            this._pnlVerInformes.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnVerInfPreliminar,
            this._btnVerInfFinal,
            this._btnVerInfRectificatorio});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(272, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnVerInfPreliminar
            // 
            this._btnVerInfPreliminar.Image = global::SISFALLA.Properties.Resources.InfPrelim;
            this._btnVerInfPreliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnVerInfPreliminar.Name = "_btnVerInfPreliminar";
            this._btnVerInfPreliminar.Size = new System.Drawing.Size(81, 22);
            this._btnVerInfPreliminar.Text = "Preliminar";
            this._btnVerInfPreliminar.Click += new System.EventHandler(this._btnVerInfPreliminar_Click);
            // 
            // _btnVerInfFinal
            // 
            this._btnVerInfFinal.Image = global::SISFALLA.Properties.Resources.informe4;
            this._btnVerInfFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnVerInfFinal.Name = "_btnVerInfFinal";
            this._btnVerInfFinal.Size = new System.Drawing.Size(52, 22);
            this._btnVerInfFinal.Text = "Final";
            this._btnVerInfFinal.Click += new System.EventHandler(this._btnVerInfFinal_Click);
            // 
            // _btnVerInfRectificatorio
            // 
            this._btnVerInfRectificatorio.Image = global::SISFALLA.Properties.Resources.informe41;
            this._btnVerInfRectificatorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnVerInfRectificatorio.Name = "_btnVerInfRectificatorio";
            this._btnVerInfRectificatorio.Size = new System.Drawing.Size(97, 22);
            this._btnVerInfRectificatorio.Text = "Rectificatorio";
            this._btnVerInfRectificatorio.Click += new System.EventHandler(this._btnVerInfRectificatorio_Click);
            // 
            // _pnlBotones
            // 
            this._pnlBotones.Controls.Add(this._txtFiltroNumeroFalla);
            this._pnlBotones.Controls.Add(this.cndcLabel2);
            this._pnlBotones.Controls.Add(this._cmbVista);
            this._pnlBotones.Controls.Add(this.cndcLabel1);
            this._pnlBotones.Controls.Add(this._btnPublicar);
            this._pnlBotones.Controls.Add(this._btnSincronizar);

            this._pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlBotones.Location = new System.Drawing.Point(0, 0);
            this._pnlBotones.Name = "_pnlBotones";
            this._pnlBotones.Size = new System.Drawing.Size(800, 33);
            this._pnlBotones.TabIndex = 3;
            this._pnlBotones.TablaCampoBD = null;
            // 
            // _txtFiltroNumeroFalla
            // 
            this._txtFiltroNumeroFalla.EnterComoTab = false;
            this._txtFiltroNumeroFalla.Etiqueta = null;
            this._txtFiltroNumeroFalla.Location = new System.Drawing.Point(317, 5);
            this._txtFiltroNumeroFalla.MaxLength = 7;
            this._txtFiltroNumeroFalla.Name = "_txtFiltroNumeroFalla";
            this._txtFiltroNumeroFalla.Size = new System.Drawing.Size(100, 20);
            this._txtFiltroNumeroFalla.TabIndex = 10;
            this._txtFiltroNumeroFalla.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(251, 10);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(60, 13);
            this.cndcLabel2.TabIndex = 9;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Num.  Falla";
            // 
            // _cmbVista
            // 
            this._cmbVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbVista.EnterComoTab = false;
            this._cmbVista.Etiqueta = null;
            this._cmbVista.FormattingEnabled = true;
            this._cmbVista.Location = new System.Drawing.Point(53, 5);
            this._cmbVista.Name = "_cmbVista";
            this._cmbVista.Size = new System.Drawing.Size(168, 21);
            this._cmbVista.TabIndex = 5;
            this._cmbVista.TablaCampoBD = null;
            this._cmbVista.SelectedIndexChanged += new System.EventHandler(this._cmbVista_SelectedIndexChanged);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(14, 10);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(33, 13);
            this.cndcLabel1.TabIndex = 4;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Vista:";
            // 
            // _btnPublicar
            // 
            this._btnPublicar.Image = global::SISFALLA.Properties.Resources.ie31;
            this._btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnPublicar.Location = new System.Drawing.Point(672, 5);
            this._btnPublicar.Name = "_btnPublicar";
            this._btnPublicar.Size = new System.Drawing.Size(117, 23);
            this._btnPublicar.TabIndex = 3;
            this._btnPublicar.TablaCampoBD = null;
            this._btnPublicar.Text = "Publicar";
            this._btnPublicar.UseVisualStyleBackColor = true;
            this._btnPublicar.Visible = false;
            this._btnPublicar.Click += new System.EventHandler(this._btnPublicar_Click);
            // 
            // _btnSincronizar
            // 
            this._btnSincronizar.Location = new System.Drawing.Point(672, 5);
            this._btnSincronizar.Name = "_btnSincronizar";
            this._btnSincronizar.Size = new System.Drawing.Size(117, 23);
            this._btnSincronizar.TabIndex = 3;
            this._btnSincronizar.TablaCampoBD = null;
            this._btnSincronizar.Text = "Sincronizar";
            this._btnSincronizar.UseVisualStyleBackColor = true;
            this._btnSincronizar.Click += new System.EventHandler(this._btnSincronizar_Click);
            // 
            // _bgWorker
            // 
            
                this._bgWorker.WorkerReportsProgress = true;
                this._bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bgWorker_DoWork);
                this._bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bgWorker_RunWorkerCompleted);
            
            // 
            // _cmDescargarFalla
            // 
            this._cmDescargarFalla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tbsDescargarInformesDeFalla});
            this._cmDescargarFalla.Name = "_cmDescargarFalla";
            this._cmDescargarFalla.Size = new System.Drawing.Size(220, 26);
            // 
            // _tbsDescargarInformesDeFalla
            // 
            this._tbsDescargarInformesDeFalla.Name = "_tbsDescargarInformesDeFalla";
            this._tbsDescargarInformesDeFalla.Size = new System.Drawing.Size(219, 22);
            this._tbsDescargarInformesDeFalla.Text = "Descargar Informes de Falla";
            this._tbsDescargarInformesDeFalla.Click += new System.EventHandler(this._tbsDescargarInformesDeFalla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 18);
            this.panel1.TabIndex = 5;
            // 
            // SisFallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this._pnlPrincipal);
            this.DoubleBuffered = true;
            this.Name = "SisFallaPrincipal";
            this.Size = new System.Drawing.Size(888, 387);
            this.Resize += new System.EventHandler(this.SisFallaPrincipal_Resize);
            ((System.ComponentModel.ISupportInitialize)(this._dgvFallas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscFailures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscUsers)).EndInit();
            this._pnlPrincipal.ResumeLayout(false);
            this._pnlAgentesInvolucrados.ResumeLayout(false);
            this._pnlVerInformes.ResumeLayout(false);
            this._pnlVerInformes.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this._pnlBotones.ResumeLayout(false);
            this._pnlBotones.PerformLayout();
            this._cmDescargarFalla.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _bscFailures;
        private System.Windows.Forms.BindingSource _bscUsers;
        private Controles.CNDCToolTip cndcToolTip1;
        private System.Windows.Forms.Timer _timerSinc;
        private Controles.CNDCGridView _dgvFallas;
        private Controles.CNDCGridView _dgvUsuarios;
        private Controles.CNDCPanelControl _pnlPrincipal;
        private Controles.CNDCPanelControl _pnlAgentesInvolucrados;
        private Controles.CNDCPanelControl _pnlVerInformes;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnVerInfPreliminar;
        private System.Windows.Forms.ToolStripButton _btnVerInfFinal;
        private System.Windows.Forms.ToolStripButton _btnVerInfRectificatorio;
        private Controles.CNDCPanelControl _pnlBotones;
        private Controles.CNDCButton _btnPublicar;

        private Controles.CNDCButton _btnSincronizar;

        private System.Windows.Forms.DataGridViewImageColumn ColNotif;
        private System.Windows.Forms.DataGridViewImageColumn ColPrelim;
        private System.Windows.Forms.DataGridViewImageColumn ColFinal;
        private System.Windows.Forms.DataGridViewImageColumn ColRectif;
        private System.ComponentModel.BackgroundWorker _bgWorker;
        private CtrlSincronizacion _ctrlSincronizacion;
        private Controles.CNDCComboBox _cmbVista;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtFiltroNumeroFalla;
        private System.Windows.Forms.ContextMenuStrip _cmDescargarFalla;
        private System.Windows.Forms.ToolStripMenuItem _tbsDescargarInformesDeFalla;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte2;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte3;
        private System.ComponentModel.BackgroundWorker bgwSincronizadorFallas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}

