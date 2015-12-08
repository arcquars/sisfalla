namespace SISFALLA
{
    partial class FormTiempo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvAgentes = new Controles.CNDCGridView();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._txtTIndis = new Controles.CNDCTextBoxFloat();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this._txtTPreCon = new Controles.CNDCTextBoxFloat();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._txtTCon = new Controles.CNDCTextBoxFloat();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvAgentes
            // 
            this._dgvAgentes.AllowUserToAddRows = false;
            this._dgvAgentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAgentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentes.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAgentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentes.Location = new System.Drawing.Point(17, 12);
            this._dgvAgentes.Name = "_dgvAgentes";
            this._dgvAgentes.NombreContenedor = null;
            this._dgvAgentes.ReadOnly = true;
            this._dgvAgentes.RowHeadersWidth = 25;
            this._dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentes.Size = new System.Drawing.Size(397, 205);
            this._dgvAgentes.TabIndex = 0;
            this._dgvAgentes.TablaCampoBD = null;
            this._dgvAgentes.SelectionChanged += new System.EventHandler(this._dgvAgentes_SelectionChanged);
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(54, 227);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(142, 13);
            this.cndcLabelControl1.TabIndex = 1;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Tiempo Indisponibilidad(min.)";
            // 
            // _txtTIndis
            // 
            this._txtTIndis.AceptaNegativo = true;
            this._txtTIndis.EnterComoTab = false;
            this._txtTIndis.Etiqueta = null;
            this._txtTIndis.Location = new System.Drawing.Point(197, 224);
            this._txtTIndis.MaxDigitosDecimales = 2;
            this._txtTIndis.MaxDigitosEnteros = 0;
            this._txtTIndis.Name = "_txtTIndis";
            this._txtTIndis.Size = new System.Drawing.Size(100, 20);
            this._txtTIndis.TabIndex = 2;
            this._txtTIndis.TablaCampoBD = "F_GF_TIEMPOSDETALLE.TIEMPO_INDISPONIBILIDAD";
            this._txtTIndis.Text = "0.00";
            this._txtTIndis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTIndis.UsarFormatoNumerico = true;
            this._txtTIndis.ValDouble = 0D;
            this._txtTIndis.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this._txtTIndis.ValorDouble = 0D;
            this._txtTIndis.ValorFloat = 0F;
            this._txtTIndis.ValorInt = 0;
            this._txtTIndis.ValorLong = ((long)(0));
            this._txtTIndis.Value = 0F;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Image = global::SisFallaUIInforme.Properties.Resources.save;
            this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnAceptar.Location = new System.Drawing.Point(131, 295);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(75, 23);
            this._btnAceptar.TabIndex = 7;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Guardar";
            this._btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::SisFallaUIInforme.Properties.Resources.cancel;
            this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCancelar.Location = new System.Drawing.Point(222, 295);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 8;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _txtTPreCon
            // 
            this._txtTPreCon.AceptaNegativo = true;
            this._txtTPreCon.EnterComoTab = false;
            this._txtTPreCon.Etiqueta = null;
            this._txtTPreCon.Location = new System.Drawing.Point(197, 246);
            this._txtTPreCon.MaxDigitosDecimales = 2;
            this._txtTPreCon.MaxDigitosEnteros = 0;
            this._txtTPreCon.Name = "_txtTPreCon";
            this._txtTPreCon.Size = new System.Drawing.Size(100, 20);
            this._txtTPreCon.TabIndex = 4;
            this._txtTPreCon.TablaCampoBD = "F_GF_TIEMPOSDETALLE.TIEMPO_PRECONEXION";
            this._txtTPreCon.Text = "0.00";
            this._txtTPreCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTPreCon.UsarFormatoNumerico = true;
            this._txtTPreCon.ValDouble = 0D;
            this._txtTPreCon.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this._txtTPreCon.ValorDouble = 0D;
            this._txtTPreCon.ValorFloat = 0F;
            this._txtTPreCon.ValorInt = 0;
            this._txtTPreCon.ValorLong = ((long)(0));
            this._txtTPreCon.Value = 0F;
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Location = new System.Drawing.Point(63, 249);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(133, 13);
            this.cndcLabelControl2.TabIndex = 3;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "Tiempo Pre Conexión(min.)";
            // 
            // _txtTCon
            // 
            this._txtTCon.AceptaNegativo = true;
            this._txtTCon.EnterComoTab = false;
            this._txtTCon.Etiqueta = null;
            this._txtTCon.Location = new System.Drawing.Point(197, 268);
            this._txtTCon.MaxDigitosDecimales = 2;
            this._txtTCon.MaxDigitosEnteros = 0;
            this._txtTCon.Name = "_txtTCon";
            this._txtTCon.Size = new System.Drawing.Size(100, 20);
            this._txtTCon.TabIndex = 6;
            this._txtTCon.TablaCampoBD = "F_GF_TIEMPOSDETALLE.TIEMPO_CONEXION";
            this._txtTCon.Text = "0.00";
            this._txtTCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTCon.UsarFormatoNumerico = true;
            this._txtTCon.ValDouble = 0D;
            this._txtTCon.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this._txtTCon.ValorDouble = 0D;
            this._txtTCon.ValorFloat = 0F;
            this._txtTCon.ValorInt = 0;
            this._txtTCon.ValorLong = ((long)(0));
            this._txtTCon.Value = 0F;
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Location = new System.Drawing.Point(82, 271);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(114, 13);
            this.cndcLabelControl3.TabIndex = 5;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Tiempo Conexión(min.)";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormTiempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 323);
            this.Controls.Add(this._txtTCon);
            this.Controls.Add(this.cndcLabelControl3);
            this.Controls.Add(this._txtTPreCon);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._txtTIndis);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._dgvAgentes);
            this.MaximizeBox = false;
            this.Name = "FormTiempo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Tiempos";
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvAgentes;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCTextBoxFloat _txtTIndis;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCTextBoxFloat _txtTPreCon;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCTextBoxFloat _txtTCon;
        private Controles.CNDCLabel cndcLabelControl3;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}