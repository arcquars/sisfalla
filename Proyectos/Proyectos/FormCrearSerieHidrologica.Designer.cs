namespace Proyectos
{
    partial class FormCrearSerieHidrologica
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
            this._nudAnioInicio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new Controles.CNDCLabel();
            this._nudAnioFin = new System.Windows.Forms.NumericUpDown();
            this._lblAnioFin = new Controles.CNDCLabel();
            this._btnCrear = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._gbxFilas = new System.Windows.Forms.GroupBox();
            this._nudFilaInicio = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._nudFilaFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._gbxColumnas = new System.Windows.Forms.GroupBox();
            this._txtColumna = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._pnlPanelAnios = new System.Windows.Forms.GroupBox();
            this._ctrlSelectorHojaDocExcel = new Proyectos.CtrlSelectorHojaDocExcel();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._gbxFilas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).BeginInit();
            this._gbxColumnas.SuspendLayout();
            this._pnlPanelAnios.SuspendLayout();
            this.SuspendLayout();
            // 
            // _nudAnioInicio
            // 
            this._nudAnioInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioInicio.Location = new System.Drawing.Point(67, 10);
            this._nudAnioInicio.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this._nudAnioInicio.Minimum = new decimal(new int[] {
            1879,
            0,
            0,
            0});
            this._nudAnioInicio.Name = "_nudAnioInicio";
            this._nudAnioInicio.Size = new System.Drawing.Size(66, 22);
            this._nudAnioInicio.TabIndex = 7;
            this._nudAnioInicio.Value = new decimal(new int[] {
            1979,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 6;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Inicio:";
            // 
            // _nudAnioFin
            // 
            this._nudAnioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioFin.Location = new System.Drawing.Point(67, 33);
            this._nudAnioFin.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this._nudAnioFin.Minimum = new decimal(new int[] {
            1879,
            0,
            0,
            0});
            this._nudAnioFin.Name = "_nudAnioFin";
            this._nudAnioFin.Size = new System.Drawing.Size(66, 22);
            this._nudAnioFin.TabIndex = 9;
            this._nudAnioFin.Value = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this._nudAnioFin.Visible = false;
            // 
            // _lblAnioFin
            // 
            this._lblAnioFin.AutoSize = true;
            this._lblAnioFin.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this._lblAnioFin.Location = new System.Drawing.Point(35, 35);
            this._lblAnioFin.Name = "_lblAnioFin";
            this._lblAnioFin.Size = new System.Drawing.Size(29, 16);
            this._lblAnioFin.TabIndex = 8;
            this._lblAnioFin.TablaCampoBD = null;
            this._lblAnioFin.Text = "Fin:";
            this._lblAnioFin.Visible = false;
            // 
            // _btnCrear
            // 
            this._btnCrear.Location = new System.Drawing.Point(168, 133);
            this._btnCrear.Name = "_btnCrear";
            this._btnCrear.Size = new System.Drawing.Size(84, 29);
            this._btnCrear.TabIndex = 14;
            this._btnCrear.Text = "Crear";
            this._btnCrear.UseVisualStyleBackColor = true;
            this._btnCrear.Click += new System.EventHandler(this._btnCrear_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(279, 133);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 29);
            this._btnCancelar.TabIndex = 15;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _gbxFilas
            // 
            this._gbxFilas.Controls.Add(this._nudFilaInicio);
            this._gbxFilas.Controls.Add(this.cndcLabel2);
            this._gbxFilas.Controls.Add(this._nudFilaFin);
            this._gbxFilas.Controls.Add(this.cndcLabel3);
            this._gbxFilas.Location = new System.Drawing.Point(205, 67);
            this._gbxFilas.Name = "_gbxFilas";
            this._gbxFilas.Size = new System.Drawing.Size(131, 57);
            this._gbxFilas.TabIndex = 17;
            this._gbxFilas.TabStop = false;
            this._gbxFilas.Text = "Filas";
            // 
            // _nudFilaInicio
            // 
            this._nudFilaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudFilaInicio.Location = new System.Drawing.Point(56, 9);
            this._nudFilaInicio.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudFilaInicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudFilaInicio.Name = "_nudFilaInicio";
            this._nudFilaInicio.Size = new System.Drawing.Size(66, 22);
            this._nudFilaInicio.TabIndex = 11;
            this._nudFilaInicio.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel2.Location = new System.Drawing.Point(10, 11);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel2.TabIndex = 10;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Inicio:";
            // 
            // _nudFilaFin
            // 
            this._nudFilaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudFilaFin.Location = new System.Drawing.Point(56, 32);
            this._nudFilaFin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudFilaFin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudFilaFin.Name = "_nudFilaFin";
            this._nudFilaFin.Size = new System.Drawing.Size(66, 22);
            this._nudFilaFin.TabIndex = 13;
            this._nudFilaFin.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel3.Location = new System.Drawing.Point(23, 34);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(29, 16);
            this.cndcLabel3.TabIndex = 12;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Fin:";
            // 
            // _gbxColumnas
            // 
            this._gbxColumnas.Controls.Add(this._txtColumna);
            this._gbxColumnas.Controls.Add(this.cndcLabel4);
            this._gbxColumnas.Location = new System.Drawing.Point(342, 67);
            this._gbxColumnas.Name = "_gbxColumnas";
            this._gbxColumnas.Size = new System.Drawing.Size(141, 57);
            this._gbxColumnas.TabIndex = 18;
            this._gbxColumnas.TabStop = false;
            this._gbxColumnas.Text = "Columnas";
            // 
            // _txtColumna
            // 
            this._txtColumna.BackColor = System.Drawing.Color.White;
            this._txtColumna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._txtColumna.EnterComoTab = false;
            this._txtColumna.Etiqueta = null;
            this._txtColumna.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtColumna.Location = new System.Drawing.Point(57, 13);
            this._txtColumna.Name = "_txtColumna";
            this._txtColumna.Size = new System.Drawing.Size(66, 22);
            this._txtColumna.TabIndex = 21;
            this._txtColumna.TablaCampoBD = "";
            this._txtColumna.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtColumna_KeyPress);
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel4.Location = new System.Drawing.Point(11, 16);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel4.TabIndex = 10;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Inicio:";
            // 
            // _pnlPanelAnios
            // 
            this._pnlPanelAnios.Controls.Add(this._nudAnioInicio);
            this._pnlPanelAnios.Controls.Add(this.label1);
            this._pnlPanelAnios.Controls.Add(this._nudAnioFin);
            this._pnlPanelAnios.Controls.Add(this._lblAnioFin);
            this._pnlPanelAnios.Location = new System.Drawing.Point(49, 66);
            this._pnlPanelAnios.Name = "_pnlPanelAnios";
            this._pnlPanelAnios.Size = new System.Drawing.Size(147, 58);
            this._pnlPanelAnios.TabIndex = 19;
            this._pnlPanelAnios.TabStop = false;
            this._pnlPanelAnios.Text = "Año";
            // 
            // _ctrlSelectorHojaDocExcel
            // 
            this._ctrlSelectorHojaDocExcel.Location = new System.Drawing.Point(12, 12);
            this._ctrlSelectorHojaDocExcel.Name = "_ctrlSelectorHojaDocExcel";
            this._ctrlSelectorHojaDocExcel.Size = new System.Drawing.Size(501, 48);
            this._ctrlSelectorHojaDocExcel.TabIndex = 29;
            // 
            // FormCrearSerieHidrologica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 165);
            this.Controls.Add(this._ctrlSelectorHojaDocExcel);
            this.Controls.Add(this._pnlPanelAnios);
            this.Controls.Add(this._gbxColumnas);
            this.Controls.Add(this._gbxFilas);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnCrear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCrearSerieHidrologica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear series";
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._gbxFilas.ResumeLayout(false);
            this._gbxFilas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).EndInit();
            this._gbxColumnas.ResumeLayout(false);
            this._gbxColumnas.PerformLayout();
            this._pnlPanelAnios.ResumeLayout(false);
            this._pnlPanelAnios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _nudAnioInicio;
        private Controles.CNDCLabel label1;
        private System.Windows.Forms.NumericUpDown _nudAnioFin;
        private Controles.CNDCLabel _lblAnioFin;
        private System.Windows.Forms.Button _btnCrear;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.GroupBox _gbxFilas;
        private System.Windows.Forms.NumericUpDown _nudFilaInicio;
        private Controles.CNDCLabel cndcLabel2;
        private System.Windows.Forms.NumericUpDown _nudFilaFin;
        private Controles.CNDCLabel cndcLabel3;
        private System.Windows.Forms.GroupBox _gbxColumnas;
        private Controles.CNDCLabel cndcLabel4;
        private System.Windows.Forms.GroupBox _pnlPanelAnios;
        private Controles.CNDCTextBox _txtColumna;
        private CtrlSelectorHojaDocExcel _ctrlSelectorHojaDocExcel;
    }
}