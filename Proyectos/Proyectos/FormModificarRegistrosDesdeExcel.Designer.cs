namespace Proyectos
{
    partial class FormModificarRegistrosDesdeExcel
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
            this._gbxFilas = new System.Windows.Forms.GroupBox();
            this._nudFilaInicio = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._nudFilaFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._gbxColumnas = new System.Windows.Forms.GroupBox();
            this._txtColumna = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._gbxAnios = new System.Windows.Forms.GroupBox();
            this._nudAnioInicio = new System.Windows.Forms.NumericUpDown();
            this._nudAnioFin = new System.Windows.Forms.NumericUpDown();
            this.label13 = new Controles.CNDCLabel();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnModificar = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._ctrlSelectorHojaDocExcel = new Proyectos.CtrlSelectorHojaDocExcel();
            this._gbxFilas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).BeginInit();
            this._gbxColumnas.SuspendLayout();
            this._gbxAnios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbxFilas
            // 
            this._gbxFilas.Controls.Add(this._nudFilaInicio);
            this._gbxFilas.Controls.Add(this.cndcLabel2);
            this._gbxFilas.Controls.Add(this._nudFilaFin);
            this._gbxFilas.Controls.Add(this.cndcLabel3);
            this._gbxFilas.Location = new System.Drawing.Point(188, 4);
            this._gbxFilas.Name = "_gbxFilas";
            this._gbxFilas.Size = new System.Drawing.Size(136, 59);
            this._gbxFilas.TabIndex = 18;
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
            this.cndcLabel2.Location = new System.Drawing.Point(11, 11);
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
            this.cndcLabel3.Location = new System.Drawing.Point(24, 34);
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
            this._gbxColumnas.Location = new System.Drawing.Point(325, 4);
            this._gbxColumnas.Name = "_gbxColumnas";
            this._gbxColumnas.Size = new System.Drawing.Size(136, 59);
            this._gbxColumnas.TabIndex = 19;
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
            this._txtColumna.Location = new System.Drawing.Point(59, 13);
            this._txtColumna.Name = "_txtColumna";
            this._txtColumna.Size = new System.Drawing.Size(66, 22);
            this._txtColumna.TabIndex = 20;
            this._txtColumna.TablaCampoBD = "";
            this._txtColumna.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtColumna_KeyPress);
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel4.Location = new System.Drawing.Point(14, 16);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel4.TabIndex = 10;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Inicio:";
            // 
            // _gbxAnios
            // 
            this._gbxAnios.Controls.Add(this._nudAnioInicio);
            this._gbxAnios.Controls.Add(this._nudAnioFin);
            this._gbxAnios.Controls.Add(this.label13);
            this._gbxAnios.Controls.Add(this.cndcLabel1);
            this._gbxAnios.Location = new System.Drawing.Point(50, 3);
            this._gbxAnios.Name = "_gbxAnios";
            this._gbxAnios.Size = new System.Drawing.Size(136, 59);
            this._gbxAnios.TabIndex = 21;
            this._gbxAnios.TabStop = false;
            this._gbxAnios.Text = "Años";
            // 
            // _nudAnioInicio
            // 
            this._nudAnioInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioInicio.Location = new System.Drawing.Point(63, 10);
            this._nudAnioInicio.Maximum = new decimal(new int[] {
            2999,
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
            this._nudAnioInicio.TabIndex = 11;
            this._nudAnioInicio.Value = new decimal(new int[] {
            1979,
            0,
            0,
            0});
            // 
            // _nudAnioFin
            // 
            this._nudAnioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudAnioFin.Location = new System.Drawing.Point(63, 33);
            this._nudAnioFin.Maximum = new decimal(new int[] {
            2999,
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
            this._nudAnioFin.TabIndex = 12;
            this._nudAnioFin.Value = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this._nudAnioFin.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(17, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 16);
            this.label13.TabIndex = 8;
            this.label13.TablaCampoBD = null;
            this.label13.Text = "Inicio:";
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel1.Location = new System.Drawing.Point(30, 35);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(29, 16);
            this.cndcLabel1.TabIndex = 10;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fin:";
            this.cndcLabel1.Visible = false;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(255, 130);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 29);
            this._btnCancelar.TabIndex = 26;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnModificar
            // 
            this._btnModificar.Location = new System.Drawing.Point(165, 130);
            this._btnModificar.Name = "_btnModificar";
            this._btnModificar.Size = new System.Drawing.Size(84, 29);
            this._btnModificar.TabIndex = 25;
            this._btnModificar.Text = "Modificar";
            this._btnModificar.UseVisualStyleBackColor = true;
            this._btnModificar.Click += new System.EventHandler(this._btnCrear_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _ctrlSelectorHojaDocExcel
            // 
            this._ctrlSelectorHojaDocExcel.Location = new System.Drawing.Point(9, 72);
            this._ctrlSelectorHojaDocExcel.Name = "_ctrlSelectorHojaDocExcel";
            this._ctrlSelectorHojaDocExcel.Size = new System.Drawing.Size(501, 48);
            this._ctrlSelectorHojaDocExcel.TabIndex = 28;
            // 
            // FormModificarRegistrosDesdeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 162);
            this.Controls.Add(this._ctrlSelectorHojaDocExcel);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnModificar);
            this.Controls.Add(this._gbxAnios);
            this.Controls.Add(this._gbxColumnas);
            this.Controls.Add(this._gbxFilas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormModificarRegistrosDesdeExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar registros ";
            this._gbxFilas.ResumeLayout(false);
            this._gbxFilas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).EndInit();
            this._gbxColumnas.ResumeLayout(false);
            this._gbxColumnas.PerformLayout();
            this._gbxAnios.ResumeLayout(false);
            this._gbxAnios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudAnioFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbxFilas;
        private System.Windows.Forms.NumericUpDown _nudFilaInicio;
        private Controles.CNDCLabel cndcLabel2;
        private System.Windows.Forms.NumericUpDown _nudFilaFin;
        private Controles.CNDCLabel cndcLabel3;
        private System.Windows.Forms.GroupBox _gbxColumnas;
        private Controles.CNDCTextBox _txtColumna;
        private Controles.CNDCLabel cndcLabel4;
        private System.Windows.Forms.GroupBox _gbxAnios;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnModificar;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.NumericUpDown _nudAnioInicio;
        private System.Windows.Forms.NumericUpDown _nudAnioFin;
        private Controles.CNDCLabel label13;
        private Controles.CNDCLabel cndcLabel1;
        private CtrlSelectorHojaDocExcel _ctrlSelectorHojaDocExcel;
    }
}