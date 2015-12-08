namespace DemadasUI
{
    partial class FormInsertarRegistros
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._rbtAlFinal = new System.Windows.Forms.RadioButton();
            this._rbtAlInicio = new System.Windows.Forms.RadioButton();
            this._lblAnioInicio = new Controles.CNDCLabel();
            this._txtAnioInicio = new Controles.CNDCTextBoxInt();
            this._lblAnioFin = new Controles.CNDCLabel();
            this._txtAnioFin = new Controles.CNDCTextBoxInt();
            this._gbxFilas = new System.Windows.Forms.GroupBox();
            this._nudFilaInicio = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._nudFilaFin = new System.Windows.Forms.NumericUpDown();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._gbxColumnas = new System.Windows.Forms.GroupBox();
            this._txtColumna = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._gbxAnios = new System.Windows.Forms.GroupBox();
            this._btnDocumento = new Controles.CNDCButton();
            this._txtDocumento = new Controles.CNDCTextBox();
            this._lblDocumento = new Controles.CNDCLabel();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnCrear = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._rbtExcel = new System.Windows.Forms.RadioButton();
            this._rbtEnBlanco = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this._gbxFilas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).BeginInit();
            this._gbxColumnas.SuspendLayout();
            this._gbxAnios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._rbtAlFinal);
            this.groupBox2.Controls.Add(this._rbtAlInicio);
            this.groupBox2.Location = new System.Drawing.Point(272, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insertar filas";
            // 
            // _rbtAlFinal
            // 
            this._rbtAlFinal.AutoSize = true;
            this._rbtAlFinal.Location = new System.Drawing.Point(152, 17);
            this._rbtAlFinal.Name = "_rbtAlFinal";
            this._rbtAlFinal.Size = new System.Drawing.Size(56, 17);
            this._rbtAlFinal.TabIndex = 1;
            this._rbtAlFinal.TabStop = true;
            this._rbtAlFinal.Text = "Al final";
            this._rbtAlFinal.UseVisualStyleBackColor = true;
            this._rbtAlFinal.CheckedChanged += new System.EventHandler(this._rbtAlFinal_CheckedChanged);
            // 
            // _rbtAlInicio
            // 
            this._rbtAlInicio.AutoSize = true;
            this._rbtAlInicio.Location = new System.Drawing.Point(26, 17);
            this._rbtAlInicio.Name = "_rbtAlInicio";
            this._rbtAlInicio.Size = new System.Drawing.Size(61, 17);
            this._rbtAlInicio.TabIndex = 0;
            this._rbtAlInicio.TabStop = true;
            this._rbtAlInicio.Text = "Al inicio";
            this._rbtAlInicio.UseVisualStyleBackColor = true;
            this._rbtAlInicio.CheckedChanged += new System.EventHandler(this._rbtAlInicio_CheckedChanged);
            // 
            // _lblAnioInicio
            // 
            this._lblAnioInicio.AutoSize = true;
            this._lblAnioInicio.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this._lblAnioInicio.Location = new System.Drawing.Point(14, 15);
            this._lblAnioInicio.Name = "_lblAnioInicio";
            this._lblAnioInicio.Size = new System.Drawing.Size(42, 16);
            this._lblAnioInicio.TabIndex = 8;
            this._lblAnioInicio.TablaCampoBD = null;
            this._lblAnioInicio.Text = "Inicio:";
            // 
            // _txtAnioInicio
            // 
            this._txtAnioInicio.BackColor = System.Drawing.Color.Gainsboro;
            this._txtAnioInicio.EnterComoTab = false;
            this._txtAnioInicio.Etiqueta = null;
            this._txtAnioInicio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAnioInicio.Location = new System.Drawing.Point(59, 13);
            this._txtAnioInicio.MaxDigitosDecimales = 0;
            this._txtAnioInicio.MaxDigitosEnteros = 0;
            this._txtAnioInicio.Name = "_txtAnioInicio";
            this._txtAnioInicio.ReadOnly = true;
            this._txtAnioInicio.Size = new System.Drawing.Size(83, 22);
            this._txtAnioInicio.TabIndex = 9;
            this._txtAnioInicio.TablaCampoBD = "";
            this._txtAnioInicio.Text = "0";
            this._txtAnioInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtAnioInicio.Value = 0;
            // 
            // _lblAnioFin
            // 
            this._lblAnioFin.AutoSize = true;
            this._lblAnioFin.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this._lblAnioFin.Location = new System.Drawing.Point(27, 37);
            this._lblAnioFin.Name = "_lblAnioFin";
            this._lblAnioFin.Size = new System.Drawing.Size(29, 16);
            this._lblAnioFin.TabIndex = 10;
            this._lblAnioFin.TablaCampoBD = null;
            this._lblAnioFin.Text = "Fin:";
            // 
            // _txtAnioFin
            // 
            this._txtAnioFin.BackColor = System.Drawing.Color.White;
            this._txtAnioFin.EnterComoTab = false;
            this._txtAnioFin.Etiqueta = null;
            this._txtAnioFin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtAnioFin.Location = new System.Drawing.Point(59, 35);
            this._txtAnioFin.MaxDigitosDecimales = 0;
            this._txtAnioFin.MaxDigitosEnteros = 0;
            this._txtAnioFin.Name = "_txtAnioFin";
            this._txtAnioFin.Size = new System.Drawing.Size(83, 22);
            this._txtAnioFin.TabIndex = 11;
            this._txtAnioFin.TablaCampoBD = "";
            this._txtAnioFin.Text = "0";
            this._txtAnioFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtAnioFin.Value = 0;
            // 
            // _gbxFilas
            // 
            this._gbxFilas.Controls.Add(this._nudFilaInicio);
            this._gbxFilas.Controls.Add(this.cndcLabel2);
            this._gbxFilas.Controls.Add(this._nudFilaFin);
            this._gbxFilas.Controls.Add(this.cndcLabel3);
            this._gbxFilas.Location = new System.Drawing.Point(272, 61);
            this._gbxFilas.Name = "_gbxFilas";
            this._gbxFilas.Size = new System.Drawing.Size(131, 57);
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
            this._nudFilaInicio.Size = new System.Drawing.Size(69, 22);
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
            this._nudFilaFin.Size = new System.Drawing.Size(69, 22);
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
            this._gbxColumnas.Location = new System.Drawing.Point(409, 61);
            this._gbxColumnas.Name = "_gbxColumnas";
            this._gbxColumnas.Size = new System.Drawing.Size(131, 57);
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
            this._txtColumna.Location = new System.Drawing.Point(59, 12);
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
            this.cndcLabel4.Location = new System.Drawing.Point(14, 14);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(42, 16);
            this.cndcLabel4.TabIndex = 10;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Inicio:";
            // 
            // _gbxAnios
            // 
            this._gbxAnios.Controls.Add(this._txtAnioInicio);
            this._gbxAnios.Controls.Add(this._lblAnioInicio);
            this._gbxAnios.Controls.Add(this._lblAnioFin);
            this._gbxAnios.Controls.Add(this._txtAnioFin);
            this._gbxAnios.Location = new System.Drawing.Point(13, 59);
            this._gbxAnios.Name = "_gbxAnios";
            this._gbxAnios.Size = new System.Drawing.Size(239, 62);
            this._gbxAnios.TabIndex = 21;
            this._gbxAnios.TabStop = false;
            this._gbxAnios.Text = "Años";
            // 
            // _btnDocumento
            // 
            this._btnDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDocumento.Location = new System.Drawing.Point(542, 119);
            this._btnDocumento.Name = "_btnDocumento";
            this._btnDocumento.Size = new System.Drawing.Size(75, 24);
            this._btnDocumento.TabIndex = 24;
            this._btnDocumento.TablaCampoBD = null;
            this._btnDocumento.Text = "Examinar";
            this._btnDocumento.UseVisualStyleBackColor = true;
            this._btnDocumento.Click += new System.EventHandler(this._btnDocumento_Click);
            // 
            // _txtDocumento
            // 
            this._txtDocumento.BackColor = System.Drawing.Color.Gainsboro;
            this._txtDocumento.EnterComoTab = false;
            this._txtDocumento.Etiqueta = null;
            this._txtDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDocumento.Location = new System.Drawing.Point(98, 121);
            this._txtDocumento.Name = "_txtDocumento";
            this._txtDocumento.ReadOnly = true;
            this._txtDocumento.Size = new System.Drawing.Size(442, 22);
            this._txtDocumento.TabIndex = 23;
            this._txtDocumento.TablaCampoBD = "";
            // 
            // _lblDocumento
            // 
            this._lblDocumento.AutoSize = true;
            this._lblDocumento.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this._lblDocumento.Location = new System.Drawing.Point(22, 123);
            this._lblDocumento.Name = "_lblDocumento";
            this._lblDocumento.Size = new System.Drawing.Size(73, 16);
            this._lblDocumento.TabIndex = 22;
            this._lblDocumento.TablaCampoBD = null;
            this._lblDocumento.Text = "Documento:";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(362, 149);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 29);
            this._btnCancelar.TabIndex = 26;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnCrear
            // 
            this._btnCrear.Location = new System.Drawing.Point(251, 149);
            this._btnCrear.Name = "_btnCrear";
            this._btnCrear.Size = new System.Drawing.Size(84, 29);
            this._btnCrear.TabIndex = 25;
            this._btnCrear.Text = "Crear";
            this._btnCrear.UseVisualStyleBackColor = true;
            this._btnCrear.Click += new System.EventHandler(this._btnCrear_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _rbtExcel
            // 
            this._rbtExcel.AutoSize = true;
            this._rbtExcel.Location = new System.Drawing.Point(26, 17);
            this._rbtExcel.Name = "_rbtExcel";
            this._rbtExcel.Size = new System.Drawing.Size(89, 17);
            this._rbtExcel.TabIndex = 0;
            this._rbtExcel.TabStop = true;
            this._rbtExcel.Text = "Leer de excel";
            this._rbtExcel.UseVisualStyleBackColor = true;
            this._rbtExcel.CheckedChanged += new System.EventHandler(this._rbtExcel_CheckedChanged);
            // 
            // _rbtEnBlanco
            // 
            this._rbtEnBlanco.AutoSize = true;
            this._rbtEnBlanco.Location = new System.Drawing.Point(152, 17);
            this._rbtEnBlanco.Name = "_rbtEnBlanco";
            this._rbtEnBlanco.Size = new System.Drawing.Size(73, 17);
            this._rbtEnBlanco.TabIndex = 1;
            this._rbtEnBlanco.TabStop = true;
            this._rbtEnBlanco.Text = "En blanco";
            this._rbtEnBlanco.UseVisualStyleBackColor = true;
            this._rbtEnBlanco.Visible = false;
            this._rbtEnBlanco.CheckedChanged += new System.EventHandler(this._rbtEnBlanco_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rbtEnBlanco);
            this.groupBox1.Controls.Add(this._rbtExcel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo creación";
            // 
            // FormInsertarRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 180);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnCrear);
            this.Controls.Add(this._btnDocumento);
            this.Controls.Add(this._txtDocumento);
            this.Controls.Add(this._lblDocumento);
            this.Controls.Add(this._gbxAnios);
            this.Controls.Add(this._gbxColumnas);
            this.Controls.Add(this._gbxFilas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormInsertarRegistros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insertar registros ";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._gbxFilas.ResumeLayout(false);
            this._gbxFilas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudFilaFin)).EndInit();
            this._gbxColumnas.ResumeLayout(false);
            this._gbxColumnas.PerformLayout();
            this._gbxAnios.ResumeLayout(false);
            this._gbxAnios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _rbtAlFinal;
        private System.Windows.Forms.RadioButton _rbtAlInicio;
        private Controles.CNDCLabel _lblAnioInicio;
        private Controles.CNDCTextBoxInt _txtAnioInicio;
        private Controles.CNDCLabel _lblAnioFin;
        private Controles.CNDCTextBoxInt _txtAnioFin;
        private System.Windows.Forms.GroupBox _gbxFilas;
        private System.Windows.Forms.NumericUpDown _nudFilaInicio;
        private Controles.CNDCLabel cndcLabel2;
        private System.Windows.Forms.NumericUpDown _nudFilaFin;
        private Controles.CNDCLabel cndcLabel3;
        private System.Windows.Forms.GroupBox _gbxColumnas;
        private Controles.CNDCTextBox _txtColumna;
        private Controles.CNDCLabel cndcLabel4;
        private System.Windows.Forms.GroupBox _gbxAnios;
        private Controles.CNDCButton _btnDocumento;
        private Controles.CNDCTextBox _txtDocumento;
        private Controles.CNDCLabel _lblDocumento;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnCrear;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _rbtEnBlanco;
        private System.Windows.Forms.RadioButton _rbtExcel;
    }
}