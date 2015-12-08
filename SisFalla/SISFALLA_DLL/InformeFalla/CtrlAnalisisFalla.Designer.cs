namespace SISFALLA
{
    partial class CtrlAnalisisFalla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._ofd = new System.Windows.Forms.OpenFileDialog();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._btnSeleccionarArchivo = new Controles.CNDCButton();
            this._txtArchivo = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._tbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this._dgvAlimentadores = new Controles.CNDCGridView();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._lblCargaDesc = new Controles.CNDCLabelFloat();
            this._txtCausa = new Controles.CNDCTextBox();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cachedplantillaReporte1 = new repSisfalla.CachedplantillaReporte();
            this._pnlAnalisis = new Controles.CNDCPanelControl();
            this.cachedplantillaReporte2 = new repSisfalla.CachedplantillaReporte();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).BeginInit();
            this._pnlAnalisis.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ofd
            // 
            this._ofd.FileName = "openFileDialog1";
            this._ofd.Filter = "Archivos PDF|*.pdf";
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._btnSeleccionarArchivo);
            this.cndcGroupBox1.Controls.Add(this._txtArchivo);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel1);
            this.cndcGroupBox1.Location = new System.Drawing.Point(3, 30);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(672, 48);
            this.cndcGroupBox1.TabIndex = 60;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Documento de Análisis de Falla";
            // 
            // _btnSeleccionarArchivo
            // 
            this._btnSeleccionarArchivo.Location = new System.Drawing.Point(547, 19);
            this._btnSeleccionarArchivo.Name = "_btnSeleccionarArchivo";
            this._btnSeleccionarArchivo.Size = new System.Drawing.Size(119, 22);
            this._btnSeleccionarArchivo.TabIndex = 3;
            this._btnSeleccionarArchivo.TablaCampoBD = null;
            this._btnSeleccionarArchivo.Text = "Seleccionar Archivo";
            this._btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this._btnSeleccionarArchivo.Click += new System.EventHandler(this._btnSeleccionarArchivo_Click);
            // 
            // _txtArchivo
            // 
            this._txtArchivo.BackColor = System.Drawing.SystemColors.Window;
            this._txtArchivo.EnterComoTab = false;
            this._txtArchivo.Etiqueta = null;
            this._txtArchivo.Location = new System.Drawing.Point(81, 21);
            this._txtArchivo.Name = "_txtArchivo";
            this._txtArchivo.ReadOnly = true;
            this._txtArchivo.Size = new System.Drawing.Size(460, 20);
            this._txtArchivo.TabIndex = 1;
            this._txtArchivo.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(10, 24);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(65, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Documento:";
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tbtnGuardar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(680, 25);
            this.cndcToolStrip1.TabIndex = 59;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _tbtnGuardar
            // 
            this._tbtnGuardar.Image = global::SISFALLA.Properties.Resources.save;
            this._tbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnGuardar.Name = "_tbtnGuardar";
            this._tbtnGuardar.Size = new System.Drawing.Size(66, 22);
            this._tbtnGuardar.Text = "Guardar";
            this._tbtnGuardar.Click += new System.EventHandler(this._tbtnGuardar_Click);
            // 
            // _dgvAlimentadores
            // 
            this._dgvAlimentadores.AllowUserToAddRows = false;
            this._dgvAlimentadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAlimentadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvAlimentadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAlimentadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAlimentadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAlimentadores.DefaultCellStyle = dataGridViewCellStyle6;
            this._dgvAlimentadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAlimentadores.Location = new System.Drawing.Point(6, 103);
            this._dgvAlimentadores.Name = "_dgvAlimentadores";
            this._dgvAlimentadores.ReadOnly = true;
            this._dgvAlimentadores.RowHeadersWidth = 15;
            this._dgvAlimentadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAlimentadores.ShowRowErrors = false;
            this._dgvAlimentadores.Size = new System.Drawing.Size(661, 230);
            this._dgvAlimentadores.TabIndex = 61;
            this._dgvAlimentadores.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(41, 3);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(201, 13);
            this.cndcLabel2.TabIndex = 62;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Carga desconectada en el Evento [MW]:";
            // 
            // _lblCargaDesc
            // 
            this._lblCargaDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblCargaDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this._lblCargaDesc.Location = new System.Drawing.Point(248, 1);
            this._lblCargaDesc.Margin = new System.Windows.Forms.Padding(0);
            this._lblCargaDesc.Name = "_lblCargaDesc";
            this._lblCargaDesc.Size = new System.Drawing.Size(100, 23);
            this._lblCargaDesc.TabIndex = 63;
            this._lblCargaDesc.Text = "0.00";
            this._lblCargaDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._lblCargaDesc.Value = 0F;
            // 
            // _txtCausa
            // 
            this._txtCausa.EnterComoTab = false;
            this._txtCausa.Etiqueta = null;
            this._txtCausa.Location = new System.Drawing.Point(248, 26);
            this._txtCausa.Name = "_txtCausa";
            this._txtCausa.Size = new System.Drawing.Size(294, 20);
            this._txtCausa.TabIndex = 64;
            this._txtCausa.TablaCampoBD = null;
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Location = new System.Drawing.Point(248, 47);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(294, 52);
            this._txtObservaciones.TabIndex = 65;
            this._txtObservaciones.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(202, 29);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(40, 13);
            this.cndcLabel3.TabIndex = 66;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Causa:";
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(161, 50);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(81, 13);
            this.cndcLabel4.TabIndex = 67;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Observaciones:";
            // 
            // _pnlAnalisis
            // 
            this._pnlAnalisis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlAnalisis.Controls.Add(this.cndcLabel2);
            this._pnlAnalisis.Controls.Add(this.cndcLabel4);
            this._pnlAnalisis.Controls.Add(this._dgvAlimentadores);
            this._pnlAnalisis.Controls.Add(this.cndcLabel3);
            this._pnlAnalisis.Controls.Add(this._lblCargaDesc);
            this._pnlAnalisis.Controls.Add(this._txtObservaciones);
            this._pnlAnalisis.Controls.Add(this._txtCausa);
            this._pnlAnalisis.Location = new System.Drawing.Point(5, 84);
            this._pnlAnalisis.Name = "_pnlAnalisis";
            this._pnlAnalisis.Size = new System.Drawing.Size(672, 335);
            this._pnlAnalisis.TabIndex = 68;
            this._pnlAnalisis.TablaCampoBD = null;
            // 
            // CtrlAnalisisFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pnlAnalisis);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this.cndcToolStrip1);
            this.Name = "CtrlAnalisisFalla";
            this.Size = new System.Drawing.Size(680, 423);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAlimentadores)).EndInit();
            this._pnlAnalisis.ResumeLayout(false);
            this._pnlAnalisis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _tbtnGuardar;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCButton _btnSeleccionarArchivo;
        private Controles.CNDCTextBox _txtArchivo;
        private Controles.CNDCLabel cndcLabel1;
        private System.Windows.Forms.OpenFileDialog _ofd;
        private Controles.CNDCGridView _dgvAlimentadores;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCLabelFloat _lblCargaDesc;
        private Controles.CNDCTextBox _txtCausa;
        private Controles.CNDCTextBox _txtObservaciones;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCLabel cndcLabel4;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
        private Controles.CNDCPanelControl _pnlAnalisis;
        private repSisfalla.CachedplantillaReporte cachedplantillaReporte2;
    }
}
