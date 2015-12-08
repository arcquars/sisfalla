namespace SISFALLA
{
    partial class FormAsigResp
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
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this._txtTAsigResp = new Controles.CNDCTextBoxFloat();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
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
            // _btnAceptar
            // 
            this._btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnAceptar.Image = global::SisFallaUIInforme.Properties.Resources.save;
            this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnAceptar.Location = new System.Drawing.Point(138, 257);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(75, 23);
            this._btnAceptar.TabIndex = 3;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Guardar";
            this._btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancelar.Image = global::SisFallaUIInforme.Properties.Resources.cancel;
            this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCancelar.Location = new System.Drawing.Point(229, 257);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 4;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _txtTAsigResp
            // 
            this._txtTAsigResp.AceptaNegativo = true;
            this._txtTAsigResp.EnterComoTab = false;
            this._txtTAsigResp.Etiqueta = null;
            this._txtTAsigResp.Location = new System.Drawing.Point(204, 222);
            this._txtTAsigResp.MaxDigitosDecimales = 2;
            this._txtTAsigResp.MaxDigitosEnteros = 5;
            this._txtTAsigResp.Name = "_txtTAsigResp";
            this._txtTAsigResp.Size = new System.Drawing.Size(100, 20);
            this._txtTAsigResp.TabIndex = 2;
            this._txtTAsigResp.TablaCampoBD = "F_GF_RESPONSABILIDAD.TIEMPO_RESPONSABILIDAD";
            this._txtTAsigResp.Text = "0,00";
            this._txtTAsigResp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTAsigResp.UsarFormatoNumerico = true;
            this._txtTAsigResp.ValDouble = 0D;
            this._txtTAsigResp.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this._txtTAsigResp.ValorDouble = 0D;
            this._txtTAsigResp.ValorFloat = 0F;
            this._txtTAsigResp.ValorInt = 0;
            this._txtTAsigResp.ValorLong = ((long)(0));
            this._txtTAsigResp.Value = 0F;
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Location = new System.Drawing.Point(79, 225);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(124, 13);
            this.cndcLabelControl4.TabIndex = 1;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Tiempo Asig. Resp.(min.)";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormAsigResp
            // 
            this.AcceptButton = this._btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(430, 284);
            this.Controls.Add(this._txtTAsigResp);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._dgvAgentes);
            this.MaximizeBox = false;
            this.Name = "FormAsigResp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de tiempos";
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGridView _dgvAgentes;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCTextBoxFloat _txtTAsigResp;
        private Controles.CNDCLabel cndcLabelControl4;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}