namespace Proyectos
{
    partial class FormCopiarDatosDeOtraEtapa
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
            this._cmbEtapa = new Controles.CNDCComboBox();
            this.label1 = new Controles.CNDCLabel();
            this._btnCopiar = new System.Windows.Forms.Button();
            this._toolStrip = new Controles.CNDCToolStrip();
            this._tsbNoCopiar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmbEtapa
            // 
            this._cmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEtapa.EnterComoTab = false;
            this._cmbEtapa.Etiqueta = null;
            this._cmbEtapa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEtapa.FormattingEnabled = true;
            this._cmbEtapa.Location = new System.Drawing.Point(129, 30);
            this._cmbEtapa.Name = "_cmbEtapa";
            this._cmbEtapa.Size = new System.Drawing.Size(220, 24);
            this._cmbEtapa.TabIndex = 5;
            this._cmbEtapa.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            this._cmbEtapa.SelectedIndexChanged += new System.EventHandler(this._cmbEtapa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 4;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Etapas registradas:";
            // 
            // _btnCopiar
            // 
            this._btnCopiar.Image = global::Proyectos.Properties.Resources.ElaborarInf___copia;
            this._btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCopiar.Location = new System.Drawing.Point(351, 28);
            this._btnCopiar.Name = "_btnCopiar";
            this._btnCopiar.Size = new System.Drawing.Size(62, 27);
            this._btnCopiar.TabIndex = 6;
            this._btnCopiar.Text = "Copiar";
            this._btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnCopiar.UseVisualStyleBackColor = true;
            this._btnCopiar.Click += new System.EventHandler(this._btnCopiar_Click);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbNoCopiar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(422, 25);
            this._toolStrip.TabIndex = 9;
            this._toolStrip.TablaCampoBD = null;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbNoCopiar
            // 
            this._tsbNoCopiar.Image = global::Proyectos.Properties.Resources.InformeBlanco;
            this._tsbNoCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbNoCopiar.Name = "_tsbNoCopiar";
            this._tsbNoCopiar.Size = new System.Drawing.Size(104, 22);
            this._tsbNoCopiar.Text = "Nuevo proyecto";
            this._tsbNoCopiar.Click += new System.EventHandler(this._btnNoCopiar_Click);
            // 
            // _tsbCancelar
            // 
            this._tsbCancelar.Image = global::Proyectos.Properties.Resources.Delete;
            this._tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbCancelar.Name = "_tsbCancelar";
            this._tsbCancelar.Size = new System.Drawing.Size(69, 22);
            this._tsbCancelar.Text = "Cancelar";
            this._tsbCancelar.Click += new System.EventHandler(this._tsbCancelar_Click);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel1.Location = new System.Drawing.Point(8, 58);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(118, 16);
            this.cndcLabel1.TabIndex = 7;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Registrar con Fecha:";
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Arial", 9.75F);
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(129, 56);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(126, 22);
            this._dtpFechaRegistro.TabIndex = 8;
            this._dtpFechaRegistro.TablaCampoBD = null;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // FormCopiarDatosDeOtraEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 85);
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._btnCopiar);
            this.Controls.Add(this._cmbEtapa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCopiarDatosDeOtraEtapa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear proyectos";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbEtapa;
        private Controles.CNDCLabel label1;
        private Controles.CNDCToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbNoCopiar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private System.Windows.Forms.Button _btnCopiar;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}