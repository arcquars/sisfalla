namespace SISFALLA
{
    partial class CtrlTiempoDetalle
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
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._txtTSisPre = new Controles.CNDCLabelFloat();
            this._txtTSisCon = new Controles.CNDCLabelFloat();
            this._txtTSisIndis = new Controles.CNDCLabelFloat();
            this._txtTiempoTotalCon = new Controles.CNDCTextBoxFloat();
            this._lblTiempoCon = new Controles.CNDCLabel();
            this._lblTSConexion = new Controles.CNDCLabel();
            this.cndcLabelControl5 = new Controles.CNDCLabel();
            this._txtTiempoTotalPre = new Controles.CNDCTextBoxFloat();
            this._lblTiempoPre = new Controles.CNDCLabel();
            this._lblTSPreCon = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._txtTiempoTotalIndis = new Controles.CNDCTextBoxFloat();
            this._lblTiempoIndis = new Controles.CNDCLabel();
            this._pnlTool = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this._btnEditar = new System.Windows.Forms.ToolStripButton();
            this._btnEliminar = new System.Windows.Forms.ToolStripButton();
            this._dgvTiempos = new Controles.CNDCGridView();
            this._lblTSIndis = new Controles.CNDCLabel();
            this._lblIndisponibilidad = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._pnlTool.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTiempos)).BeginInit();
            this.SuspendLayout();
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _txtTSisPre
            // 
            this._txtTSisPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTSisPre.Location = new System.Drawing.Point(333, 56);
            this._txtTSisPre.Margin = new System.Windows.Forms.Padding(0);
            this._txtTSisPre.Name = "_txtTSisPre";
            this._txtTSisPre.Size = new System.Drawing.Size(48, 20);
            this._txtTSisPre.TabIndex = 118;
            this._txtTSisPre.Text = "0,00";
            this._txtTSisPre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._txtTSisPre.Value = 0F;
            // 
            // _txtTSisCon
            // 
            this._txtTSisCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTSisCon.Location = new System.Drawing.Point(473, 56);
            this._txtTSisCon.Margin = new System.Windows.Forms.Padding(0);
            this._txtTSisCon.Name = "_txtTSisCon";
            this._txtTSisCon.Size = new System.Drawing.Size(48, 20);
            this._txtTSisCon.TabIndex = 117;
            this._txtTSisCon.Text = "0,00";
            this._txtTSisCon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._txtTSisCon.Value = 0F;
            // 
            // _txtTSisIndis
            // 
            this._txtTSisIndis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTSisIndis.Location = new System.Drawing.Point(192, 56);
            this._txtTSisIndis.Margin = new System.Windows.Forms.Padding(0);
            this._txtTSisIndis.Name = "_txtTSisIndis";
            this._txtTSisIndis.Size = new System.Drawing.Size(48, 20);
            this._txtTSisIndis.TabIndex = 116;
            this._txtTSisIndis.Text = "0,00";
            this._txtTSisIndis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._txtTSisIndis.Value = 0F;
            // 
            // _txtTiempoTotalCon
            // 
            this._txtTiempoTotalCon.EnterComoTab = false;
            this._txtTiempoTotalCon.Etiqueta = this._lblTiempoCon;
            this._txtTiempoTotalCon.Location = new System.Drawing.Point(473, 35);
            this._txtTiempoTotalCon.MaxLength = 6;
            this._txtTiempoTotalCon.Name = "_txtTiempoTotalCon";
            this._txtTiempoTotalCon.Size = new System.Drawing.Size(46, 20);
            this._txtTiempoTotalCon.TabIndex = 12;
            this._txtTiempoTotalCon.TablaCampoBD = "F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION";
            this._txtTiempoTotalCon.Text = ",00";
            this._txtTiempoTotalCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempoTotalCon.ValDouble = 0D;
            this._txtTiempoTotalCon.Value = 0F;
            this._txtTiempoTotalCon.TextChanged += new System.EventHandler(this._txtTiempoTotalIndis_TextChanged);
            // 
            // _lblTiempoCon
            // 
            this._lblTiempoCon.AutoSize = true;
            this._lblTiempoCon.Location = new System.Drawing.Point(401, 39);
            this._lblTiempoCon.Name = "_lblTiempoCon";
            this._lblTiempoCon.Size = new System.Drawing.Size(69, 13);
            this._lblTiempoCon.TabIndex = 11;
            this._lblTiempoCon.TablaCampoBD = null;
            this._lblTiempoCon.Text = "T. Total Con:";
            // 
            // _lblTSConexion
            // 
            this._lblTSConexion.AutoSize = true;
            this._lblTSConexion.Location = new System.Drawing.Point(385, 58);
            this._lblTSConexion.Name = "_lblTSConexion";
            this._lblTSConexion.Size = new System.Drawing.Size(85, 13);
            this._lblTSConexion.TabIndex = 13;
            this._lblTSConexion.TablaCampoBD = null;
            this._lblTSConexion.Text = "Tiempo Sistema:";
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl5.Location = new System.Drawing.Point(380, 0);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(135, 13);
            this.cndcLabelControl5.TabIndex = 10;
            this.cndcLabelControl5.TablaCampoBD = null;
            this.cndcLabelControl5.Text = "CONEXIÓN(min)";
            this.cndcLabelControl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtTiempoTotalPre
            // 
            this._txtTiempoTotalPre.EnterComoTab = false;
            this._txtTiempoTotalPre.Etiqueta = this._lblTiempoPre;
            this._txtTiempoTotalPre.Location = new System.Drawing.Point(333, 35);
            this._txtTiempoTotalPre.MaxLength = 6;
            this._txtTiempoTotalPre.Name = "_txtTiempoTotalPre";
            this._txtTiempoTotalPre.Size = new System.Drawing.Size(46, 20);
            this._txtTiempoTotalPre.TabIndex = 7;
            this._txtTiempoTotalPre.TablaCampoBD = "F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION";
            this._txtTiempoTotalPre.Text = ",00";
            this._txtTiempoTotalPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempoTotalPre.ValDouble = 0D;
            this._txtTiempoTotalPre.Value = 0F;
            this._txtTiempoTotalPre.TextChanged += new System.EventHandler(this._txtTiempoTotalIndis_TextChanged);
            // 
            // _lblTiempoPre
            // 
            this._lblTiempoPre.AutoSize = true;
            this._lblTiempoPre.Location = new System.Drawing.Point(239, 39);
            this._lblTiempoPre.Name = "_lblTiempoPre";
            this._lblTiempoPre.Size = new System.Drawing.Size(91, 13);
            this._lblTiempoPre.TabIndex = 6;
            this._lblTiempoPre.TablaCampoBD = null;
            this._lblTiempoPre.Text = "Tiempo Total Pre:";
            // 
            // _lblTSPreCon
            // 
            this._lblTSPreCon.AutoSize = true;
            this._lblTSPreCon.Location = new System.Drawing.Point(245, 58);
            this._lblTSPreCon.Name = "_lblTSPreCon";
            this._lblTSPreCon.Size = new System.Drawing.Size(85, 13);
            this._lblTSPreCon.TabIndex = 8;
            this._lblTSPreCon.TablaCampoBD = null;
            this._lblTSPreCon.Text = "Tiempo Sistema:";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.Location = new System.Drawing.Point(239, 0);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(138, 13);
            this.cndcLabelControl2.TabIndex = 5;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "PRECONEXIÓN(min)";
            this.cndcLabelControl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtTiempoTotalIndis
            // 
            this._txtTiempoTotalIndis.EnterComoTab = false;
            this._txtTiempoTotalIndis.Etiqueta = this._lblTiempoIndis;
            this._txtTiempoTotalIndis.Location = new System.Drawing.Point(192, 35);
            this._txtTiempoTotalIndis.MaxLength = 6;
            this._txtTiempoTotalIndis.Name = "_txtTiempoTotalIndis";
            this._txtTiempoTotalIndis.Size = new System.Drawing.Size(46, 20);
            this._txtTiempoTotalIndis.TabIndex = 2;
            this._txtTiempoTotalIndis.TablaCampoBD = "F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD";
            this._txtTiempoTotalIndis.Text = ",00";
            this._txtTiempoTotalIndis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempoTotalIndis.ValDouble = 0D;
            this._txtTiempoTotalIndis.Value = 0F;
            this._txtTiempoTotalIndis.TextChanged += new System.EventHandler(this._txtTiempoTotalIndis_TextChanged);
            // 
            // _lblTiempoIndis
            // 
            this._lblTiempoIndis.AutoSize = true;
            this._lblTiempoIndis.Location = new System.Drawing.Point(92, 39);
            this._lblTiempoIndis.Name = "_lblTiempoIndis";
            this._lblTiempoIndis.Size = new System.Drawing.Size(97, 13);
            this._lblTiempoIndis.TabIndex = 1;
            this._lblTiempoIndis.TablaCampoBD = null;
            this._lblTiempoIndis.Text = "Tiempo Total Indis:";
            // 
            // _pnlTool
            // 
            this._pnlTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pnlTool.Controls.Add(this.cndcToolStrip1);
            this._pnlTool.Location = new System.Drawing.Point(0, 195);
            this._pnlTool.Name = "_pnlTool";
            this._pnlTool.Size = new System.Drawing.Size(519, 25);
            this._pnlTool.TabIndex = 115;
            this._pnlTool.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdicionar,
            this._btnEditar,
            this._btnEliminar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(519, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnAdicionar.Image = global::SISFALLA.Properties.Resources.Add;
            this._btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(23, 22);
            this._btnAdicionar.Text = "toolStripButton1";
            this._btnAdicionar.ToolTipText = "Adicionar";
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnEditar
            // 
            this._btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEditar.Image = global::SISFALLA.Properties.Resources.Edit;
            this._btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEditar.Name = "_btnEditar";
            this._btnEditar.Size = new System.Drawing.Size(23, 22);
            this._btnEditar.Text = "toolStripButton2";
            this._btnEditar.ToolTipText = "Editar";
            this._btnEditar.Click += new System.EventHandler(this._btnEditar_Click);
            // 
            // _btnEliminar
            // 
            this._btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnEliminar.Image = global::SISFALLA.Properties.Resources.Delete;
            this._btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(23, 22);
            this._btnEliminar.Text = "toolStripButton3";
            this._btnEliminar.ToolTipText = "Borrar";
            this._btnEliminar.Click += new System.EventHandler(this._btnEliminar_Click);
            // 
            // _dgvTiempos
            // 
            this._dgvTiempos.AllowUserToAddRows = false;
            this._dgvTiempos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvTiempos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvTiempos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvTiempos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvTiempos.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvTiempos.GridColor = System.Drawing.Color.Gray;
            this._dgvTiempos.Location = new System.Drawing.Point(0, 78);
            this._dgvTiempos.MultiSelect = false;
            this._dgvTiempos.Name = "_dgvTiempos";
            this._dgvTiempos.ReadOnly = true;
            this._dgvTiempos.RowHeadersWidth = 15;
            this._dgvTiempos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvTiempos.Size = new System.Drawing.Size(519, 106);
            this._dgvTiempos.TabIndex = 15;
            this._dgvTiempos.TablaCampoBD = null;
            this._dgvTiempos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dgvTiempos_CellFormatting);
            this._dgvTiempos.SelectionChanged += new System.EventHandler(this._dgvTiempos_SelectionChanged);
            // 
            // _lblTSIndis
            // 
            this._lblTSIndis.AutoSize = true;
            this._lblTSIndis.Location = new System.Drawing.Point(104, 58);
            this._lblTSIndis.Name = "_lblTSIndis";
            this._lblTSIndis.Size = new System.Drawing.Size(85, 13);
            this._lblTSIndis.TabIndex = 3;
            this._lblTSIndis.TablaCampoBD = null;
            this._lblTSIndis.Text = "Tiempo Sistema:";
            // 
            // _lblIndisponibilidad
            // 
            this._lblIndisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIndisponibilidad.Location = new System.Drawing.Point(79, 0);
            this._lblIndisponibilidad.Name = "_lblIndisponibilidad";
            this._lblIndisponibilidad.Size = new System.Drawing.Size(158, 13);
            this._lblIndisponibilidad.TabIndex = 0;
            this._lblIndisponibilidad.TablaCampoBD = null;
            this._lblIndisponibilidad.Text = "INDISPONIBILIDAD (min)";
            this._lblIndisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlTiempoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtTSisPre);
            this.Controls.Add(this._txtTSisCon);
            this.Controls.Add(this._txtTSisIndis);
            this.Controls.Add(this._txtTiempoTotalCon);
            this.Controls.Add(this._lblTSConexion);
            this.Controls.Add(this.cndcLabelControl5);
            this.Controls.Add(this._lblTiempoCon);
            this.Controls.Add(this._txtTiempoTotalPre);
            this.Controls.Add(this._lblTSPreCon);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this._lblTiempoPre);
            this.Controls.Add(this._txtTiempoTotalIndis);
            this.Controls.Add(this._pnlTool);
            this.Controls.Add(this._dgvTiempos);
            this.Controls.Add(this._lblTSIndis);
            this.Controls.Add(this._lblIndisponibilidad);
            this.Controls.Add(this._lblTiempoIndis);
            this.Name = "CtrlTiempoDetalle";
            this.Size = new System.Drawing.Size(533, 220);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._pnlTool.ResumeLayout(false);
            this._pnlTool.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTiempos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBoxFloat _txtTiempoTotalIndis;
        private Controles.CNDCPanelControl _pnlTool;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAdicionar;
        private System.Windows.Forms.ToolStripButton _btnEditar;
        private System.Windows.Forms.ToolStripButton _btnEliminar;
        private Controles.CNDCGridView _dgvTiempos;
        private Controles.CNDCLabel _lblTSIndis;
        private Controles.CNDCLabel _lblIndisponibilidad;
        private Controles.CNDCLabel _lblTiempoIndis;
        private Controles.CNDCTextBoxFloat _txtTiempoTotalPre;
        private Controles.CNDCLabel _lblTSPreCon;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCLabel _lblTiempoPre;
        private Controles.CNDCTextBoxFloat _txtTiempoTotalCon;
        private Controles.CNDCLabel _lblTSConexion;
        private Controles.CNDCLabel cndcLabelControl5;
        private Controles.CNDCLabel _lblTiempoCon;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCLabelFloat _txtTSisIndis;
        private Controles.CNDCLabelFloat _txtTSisPre;
        private Controles.CNDCLabelFloat _txtTSisCon;
    }
}
