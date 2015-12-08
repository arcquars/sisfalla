namespace ComponentesUI
{
    partial class FrmAbmComponente
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._tbIdComp = new Controles.CNDCTextBox();
            this._tbCodComp = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._tbDescrip = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._cmbAgente = new Controles.CNDCComboBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this.cndcLabel5 = new Controles.CNDCLabel();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this._cbFechaBaja = new Controles.CNDCCheckBox();
            this._dtpFechaIni = new Controles.CNDCDateTimePicker();
            this._dtpFechaBaja = new Controles.CNDCDateTimePicker();
            this._lblNodoOrigen = new Controles.CNDCLabel();
            this.cndcLabel8 = new Controles.CNDCLabel();
            this._lblNodoDestino = new Controles.CNDCLabel();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._cndcTS = new Controles.CNDCToolStrip();
            this._tSBNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this._lblTipoC = new Controles.CNDCLabel();
            this.tbFechaBlanca = new Controles.CNDCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._cndcTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(7, 36);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Id. Universal";
            // 
            // _tbIdComp
            // 
            this._tbIdComp.EnterComoTab = false;
            this._tbIdComp.Etiqueta = null;
            this._tbIdComp.Location = new System.Drawing.Point(82, 32);
            this._tbIdComp.MaxLength = 16;
            this._tbIdComp.Name = "_tbIdComp";
            this._tbIdComp.Size = new System.Drawing.Size(173, 20);
            this._tbIdComp.TabIndex = 0;
            this._tbIdComp.TablaCampoBD = null;
            // 
            // _tbCodComp
            // 
            this._tbCodComp.EnterComoTab = false;
            this._tbCodComp.Etiqueta = null;
            this._tbCodComp.Location = new System.Drawing.Point(82, 60);
            this._tbCodComp.MaxLength = 30;
            this._tbCodComp.Name = "_tbCodComp";
            this._tbCodComp.Size = new System.Drawing.Size(173, 20);
            this._tbCodComp.TabIndex = 1;
            this._tbCodComp.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(7, 63);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(44, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nombre";
            // 
            // _tbDescrip
            // 
            this._tbDescrip.EnterComoTab = false;
            this._tbDescrip.Etiqueta = null;
            this._tbDescrip.Location = new System.Drawing.Point(82, 88);
            this._tbDescrip.MaxLength = 150;
            this._tbDescrip.Multiline = true;
            this._tbDescrip.Name = "_tbDescrip";
            this._tbDescrip.Size = new System.Drawing.Size(275, 49);
            this._tbDescrip.TabIndex = 2;
            this._tbDescrip.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(7, 87);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(63, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Descripción";
            // 
            // _cmbAgente
            // 
            this._cmbAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAgente.EnterComoTab = false;
            this._cmbAgente.Etiqueta = null;
            this._cmbAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbAgente.FormattingEnabled = true;
            this._cmbAgente.Location = new System.Drawing.Point(82, 166);
            this._cmbAgente.Name = "_cmbAgente";
            this._cmbAgente.Size = new System.Drawing.Size(275, 24);
            this._cmbAgente.TabIndex = 4;
            this._cmbAgente.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(7, 145);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(28, 13);
            this.cndcLabel4.TabIndex = 22;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Tipo";
            // 
            // cndcLabel5
            // 
            this.cndcLabel5.AutoSize = true;
            this.cndcLabel5.Location = new System.Drawing.Point(7, 172);
            this.cndcLabel5.Name = "cndcLabel5";
            this.cndcLabel5.Size = new System.Drawing.Size(41, 13);
            this.cndcLabel5.TabIndex = 23;
            this.cndcLabel5.TablaCampoBD = null;
            this.cndcLabel5.Text = "Agente";
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Location = new System.Drawing.Point(7, 202);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(65, 13);
            this.cndcLabel6.TabIndex = 24;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Fecha Inicio";
            // 
            // _cbFechaBaja
            // 
            this._cbFechaBaja.AutoSize = true;
            this._cbFechaBaja.Location = new System.Drawing.Point(210, 200);
            this._cbFechaBaja.Name = "_cbFechaBaja";
            this._cbFechaBaja.Size = new System.Drawing.Size(80, 17);
            this._cbFechaBaja.TabIndex = 26;
            this._cbFechaBaja.TablaCampoBD = null;
            this._cbFechaBaja.Text = "Fecha Baja";
            this._cbFechaBaja.UseVisualStyleBackColor = true;
            this._cbFechaBaja.CheckedChanged += new System.EventHandler(this._cbFechaBaja_CheckedChanged);
            // 
            // _dtpFechaIni
            // 
            this._dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFechaIni.Location = new System.Drawing.Point(82, 198);
            this._dtpFechaIni.Name = "_dtpFechaIni";
            this._dtpFechaIni.Size = new System.Drawing.Size(100, 20);
            this._dtpFechaIni.TabIndex = 5;
            this._dtpFechaIni.TablaCampoBD = null;
            this._dtpFechaIni.ValueChanged += new System.EventHandler(this._dtpFechaIni_ValueChanged);
            // 
            // _dtpFechaBaja
            // 
            this._dtpFechaBaja.Enabled = false;
            this._dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFechaBaja.Location = new System.Drawing.Point(295, 198);
            this._dtpFechaBaja.Name = "_dtpFechaBaja";
            this._dtpFechaBaja.Size = new System.Drawing.Size(100, 20);
            this._dtpFechaBaja.TabIndex = 6;
            this._dtpFechaBaja.TablaCampoBD = null;
            this._dtpFechaBaja.ValueChanged += new System.EventHandler(this._dtpFechaBaja_ValueChanged);
            // 
            // _lblNodoOrigen
            // 
            this._lblNodoOrigen.AutoSize = true;
            this._lblNodoOrigen.Location = new System.Drawing.Point(274, 36);
            this._lblNodoOrigen.Name = "_lblNodoOrigen";
            this._lblNodoOrigen.Size = new System.Drawing.Size(13, 13);
            this._lblNodoOrigen.TabIndex = 29;
            this._lblNodoOrigen.TablaCampoBD = null;
            this._lblNodoOrigen.Text = "_";
            // 
            // cndcLabel8
            // 
            this.cndcLabel8.AutoSize = true;
            this.cndcLabel8.Location = new System.Drawing.Point(353, 36);
            this.cndcLabel8.Name = "cndcLabel8";
            this.cndcLabel8.Size = new System.Drawing.Size(10, 13);
            this.cndcLabel8.TabIndex = 30;
            this.cndcLabel8.TablaCampoBD = null;
            this.cndcLabel8.Text = "-";
            // 
            // _lblNodoDestino
            // 
            this._lblNodoDestino.AutoSize = true;
            this._lblNodoDestino.Location = new System.Drawing.Point(382, 36);
            this._lblNodoDestino.Name = "_lblNodoDestino";
            this._lblNodoDestino.Size = new System.Drawing.Size(13, 13);
            this._lblNodoDestino.TabIndex = 31;
            this._lblNodoDestino.TablaCampoBD = null;
            this._lblNodoDestino.Text = "_";
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _cndcTS
            // 
            this._cndcTS.AutoSize = false;
            this._cndcTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tSBNuevo,
            this.tsEditar});
            this._cndcTS.Location = new System.Drawing.Point(0, 0);
            this._cndcTS.Name = "_cndcTS";
            this._cndcTS.Size = new System.Drawing.Size(488, 32);
            this._cndcTS.TabIndex = 7;
            this._cndcTS.TablaCampoBD = null;
            this._cndcTS.Text = "cndcToolStrip1";
            // 
            // _tSBNuevo
            // 
            this._tSBNuevo.Image = global::ComponentesUI.Properties.Resources.save;
            this._tSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBNuevo.Name = "_tSBNuevo";
            this._tSBNuevo.Size = new System.Drawing.Size(69, 29);
            this._tSBNuevo.Text = "Guardar";
            this._tSBNuevo.Click += new System.EventHandler(this._tSBNuevo_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.Image = global::ComponentesUI.Properties.Resources.cancel;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(73, 29);
            this.tsEditar.Text = "Cancelar";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // _lblTipoC
            // 
            this._lblTipoC.AutoSize = true;
            this._lblTipoC.Location = new System.Drawing.Point(82, 145);
            this._lblTipoC.Name = "_lblTipoC";
            this._lblTipoC.Size = new System.Drawing.Size(13, 13);
            this._lblTipoC.TabIndex = 32;
            this._lblTipoC.TablaCampoBD = null;
            this._lblTipoC.Text = "_";
            // 
            // tbFechaBlanca
            // 
            this.tbFechaBlanca.EnterComoTab = false;
            this.tbFechaBlanca.Etiqueta = null;
            this.tbFechaBlanca.Location = new System.Drawing.Point(296, 198);
            this.tbFechaBlanca.Name = "tbFechaBlanca";
            this.tbFechaBlanca.ReadOnly = true;
            this.tbFechaBlanca.Size = new System.Drawing.Size(100, 20);
            this.tbFechaBlanca.TabIndex = 33;
            this.tbFechaBlanca.TablaCampoBD = null;
            // 
            // FrmAbmComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 233);
            this.Controls.Add(this.tbFechaBlanca);
            this.Controls.Add(this._lblTipoC);
            this.Controls.Add(this._cndcTS);
            this.Controls.Add(this._lblNodoDestino);
            this.Controls.Add(this.cndcLabel8);
            this.Controls.Add(this._lblNodoOrigen);
            this.Controls.Add(this._dtpFechaBaja);
            this.Controls.Add(this._dtpFechaIni);
            this.Controls.Add(this._cbFechaBaja);
            this.Controls.Add(this.cndcLabel6);
            this.Controls.Add(this.cndcLabel5);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._cmbAgente);
            this.Controls.Add(this._tbDescrip);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._tbCodComp);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._tbIdComp);
            this.Controls.Add(this.cndcLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAbmComponente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Componente";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._cndcTS.ResumeLayout(false);
            this._cndcTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _tbIdComp;
        private Controles.CNDCTextBox _tbCodComp;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _tbDescrip;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCComboBox _cmbAgente;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCLabel cndcLabel5;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCCheckBox _cbFechaBaja;
        private Controles.CNDCDateTimePicker _dtpFechaIni;
        private Controles.CNDCDateTimePicker _dtpFechaBaja;
        private Controles.CNDCLabel _lblNodoOrigen;
        private Controles.CNDCLabel cndcLabel8;
        private Controles.CNDCLabel _lblNodoDestino;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private Controles.CNDCToolStrip _cndcTS;
        private System.Windows.Forms.ToolStripButton _tSBNuevo;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private Controles.CNDCLabel _lblTipoC;
        private Controles.CNDCTextBox tbFechaBlanca;

    }
}