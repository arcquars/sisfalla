namespace Proyectos
{
    partial class CtrlSeriesHidrolologicas
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._tsbOpcionesDeEdicion = new System.Windows.Forms.ToolStrip();
            this._tsbEliminarSerie = new System.Windows.Forms.ToolStripButton();
            this._tsbCrearSerieHidrologicaImpExcel = new System.Windows.Forms.ToolStripButton();
            this._btnPegarDeExcel = new System.Windows.Forms.ToolStripButton();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnElimFilaFin = new System.Windows.Forms.ToolStripButton();
            this._btnElimFilaInicio = new System.Windows.Forms.ToolStripButton();
            this._btnAdFilaFin = new System.Windows.Forms.ToolStripButton();
            this._btnAdFilaInicio = new System.Windows.Forms.ToolStripButton();
            this._dgvSerieHidrologica = new Controles.CNDCGridView();
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._tsbOpcionesDeEdicion.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSerieHidrologica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(357, 6);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(34, 13);
            this.cndcLabel1.TabIndex = 217;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "(m³/s)";
            // 
            // _tsbOpcionesDeEdicion
            // 
            this._tsbOpcionesDeEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tsbOpcionesDeEdicion.Dock = System.Windows.Forms.DockStyle.None;
            this._tsbOpcionesDeEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbEliminarSerie,
            this._tsbCrearSerieHidrologicaImpExcel,

            this._btnPegarDeExcel});
            this._tsbOpcionesDeEdicion.Location = new System.Drawing.Point(0, 324);
    
            this._tsbOpcionesDeEdicion.Name = "_tsbOpcionesDeEdicion";
            this._tsbOpcionesDeEdicion.Size = new System.Drawing.Size(114, 25);
            this._tsbOpcionesDeEdicion.TabIndex = 216;
            this._tsbOpcionesDeEdicion.Text = "toolStrip1";
            // 
            // _tsbEliminarSerie
            // 
            this._tsbEliminarSerie.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbEliminarSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEliminarSerie.Name = "_tsbEliminarSerie";
            this._tsbEliminarSerie.Size = new System.Drawing.Size(149, 22);
            this._tsbEliminarSerie.Text = "Borrar serie hidrológica";
            this._tsbEliminarSerie.Visible = false;
            this._tsbEliminarSerie.Click += new System.EventHandler(this._tsbEliminarSerie_Click);
            // 
            // _tsbCrearSerieHidrologicaImpExcel
            // 
            this._tsbCrearSerieHidrologicaImpExcel.Image = global::Proyectos.Properties.Resources.IcoExcel;
            this._tsbCrearSerieHidrologicaImpExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCrearSerieHidrologicaImpExcel.Name = "_tsbCrearSerieHidrologicaImpExcel";
            this._tsbCrearSerieHidrologicaImpExcel.Size = new System.Drawing.Size(145, 22);
            this._tsbCrearSerieHidrologicaImpExcel.Text = "Importar de Doc. Excel";
            this._tsbCrearSerieHidrologicaImpExcel.Visible = false;
            this._tsbCrearSerieHidrologicaImpExcel.Click += new System.EventHandler(this._tsbCrearSerieHidrologicaImpExcel_Click);
            // 
            // _btnPegarDeExcel
            // 
            this._btnPegarDeExcel.Image = global::Proyectos.Properties.Resources.pegarExcel;
            this._btnPegarDeExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnPegarDeExcel.Name = "_btnPegarDeExcel";
            this._btnPegarDeExcel.Size = new System.Drawing.Size(102, 22);
            this._btnPegarDeExcel.Text = "Pegar de Excel";
            this._btnPegarDeExcel.Click += new System.EventHandler(this._btnPegarDeExcel_Click);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar,
            this._btnElimFilaFin,
            this._btnElimFilaInicio,
            this._btnAdFilaFin,
            this._btnAdFilaInicio});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(802, 25);
            this._toolStrip.TabIndex = 213;
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
            // _btnElimFilaFin
            // 
            this._btnElimFilaFin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnElimFilaFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnElimFilaFin.Enabled = false;
            this._btnElimFilaFin.Image = global::Proyectos.Properties.Resources.ElimFilaFin;
            this._btnElimFilaFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnElimFilaFin.Name = "_btnElimFilaFin";
            this._btnElimFilaFin.Size = new System.Drawing.Size(23, 22);
            this._btnElimFilaFin.Text = "toolStripButton5";
            this._btnElimFilaFin.ToolTipText = "Borrar último registro";
            this._btnElimFilaFin.Click += new System.EventHandler(this._btnElimFilaFin_Click);
            // 
            // _btnElimFilaInicio
            // 
            this._btnElimFilaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnElimFilaInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnElimFilaInicio.Enabled = false;
            this._btnElimFilaInicio.Image = global::Proyectos.Properties.Resources.ElimFilaIni;
            this._btnElimFilaInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnElimFilaInicio.Name = "_btnElimFilaInicio";
            this._btnElimFilaInicio.Size = new System.Drawing.Size(23, 22);
            this._btnElimFilaInicio.Text = "toolStripButton4";
            this._btnElimFilaInicio.ToolTipText = "Borrar primer registro";
            this._btnElimFilaInicio.Click += new System.EventHandler(this._btnElimFilaInicio_Click);
            // 
            // _btnAdFilaFin
            // 
            this._btnAdFilaFin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnAdFilaFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdFilaFin.Enabled = false;
            this._btnAdFilaFin.Image = global::Proyectos.Properties.Resources.AdFilaFin;
            this._btnAdFilaFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdFilaFin.Name = "_btnAdFilaFin";
            this._btnAdFilaFin.Size = new System.Drawing.Size(23, 22);
            this._btnAdFilaFin.Text = "toolStripButton3";
            this._btnAdFilaFin.ToolTipText = "Adicionar al final";
            this._btnAdFilaFin.Click += new System.EventHandler(this._btnAdFilaFin_Click);
            // 
            // _btnAdFilaInicio
            // 
            this._btnAdFilaInicio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnAdFilaInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdFilaInicio.Enabled = false;
            this._btnAdFilaInicio.Image = global::Proyectos.Properties.Resources.AdFilaIni;
            this._btnAdFilaInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdFilaInicio.Name = "_btnAdFilaInicio";
            this._btnAdFilaInicio.Size = new System.Drawing.Size(23, 22);
            this._btnAdFilaInicio.Text = "toolStripButton1";
            this._btnAdFilaInicio.ToolTipText = "Adicionar al inicio";
            this._btnAdFilaInicio.Click += new System.EventHandler(this._btnAdFilaInicio_Click);
            // 
            // _dgvSerieHidrologica
            // 
            this._dgvSerieHidrologica.AllowUserToAddRows = false;
            this._dgvSerieHidrologica.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvSerieHidrologica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvSerieHidrologica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvSerieHidrologica.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvSerieHidrologica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvSerieHidrologica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvSerieHidrologica.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvSerieHidrologica.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvSerieHidrologica.Location = new System.Drawing.Point(0, 30);
            this._dgvSerieHidrologica.Name = "_dgvSerieHidrologica";
            this._dgvSerieHidrologica.NombreContenedor = null;
            this._dgvSerieHidrologica.RowHeadersWidth = 25;
            this._dgvSerieHidrologica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dgvSerieHidrologica.Size = new System.Drawing.Size(802, 292);
            this._dgvSerieHidrologica.TabIndex = 0;
            this._dgvSerieHidrologica.TablaCampoBD = null;
            this._dgvSerieHidrologica.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this._dgvSerieHidrologica_CellParsing);
            this._dgvSerieHidrologica.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvSerieHidrologica_CellValidated);
            this._dgvSerieHidrologica.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._dgvSerieHidrologica_CellValidating);
            this._dgvSerieHidrologica.SelectionChanged += new System.EventHandler(this._dgvSerieHidrologica_SelectionChanged);
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(730, 3);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(29, 22);
            this._dtpFechaRegistro.TabIndex = 215;
            this._dtpFechaRegistro.TablaCampoBD = null;
            this._dtpFechaRegistro.Visible = false;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlSeriesHidrolologicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._tsbOpcionesDeEdicion);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._dgvSerieHidrologica);
            this.Controls.Add(this._dtpFechaRegistro);
            this.Name = "CtrlSeriesHidrolologicas";
            this.Size = new System.Drawing.Size(802, 349);
            this._tsbOpcionesDeEdicion.ResumeLayout(false);
            this._tsbOpcionesDeEdicion.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSerieHidrologica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvSerieHidrologica;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStrip _tsbOpcionesDeEdicion;
        private System.Windows.Forms.ToolStripButton _tsbEliminarSerie;
        private System.Windows.Forms.ToolStripButton _btnPegarDeExcel;
        private System.Windows.Forms.ToolStripButton _btnElimFilaFin;
        private System.Windows.Forms.ToolStripButton _btnElimFilaInicio;
        private System.Windows.Forms.ToolStripButton _btnAdFilaFin;
        private System.Windows.Forms.ToolStripButton _btnAdFilaInicio;
        private System.Windows.Forms.ToolStripButton _tsbCrearSerieHidrologicaImpExcel;
        private Controles.CNDCLabel cndcLabel1;
    }
}
