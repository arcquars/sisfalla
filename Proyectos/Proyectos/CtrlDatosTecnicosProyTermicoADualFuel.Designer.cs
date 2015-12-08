namespace Proyectos
{
    partial class CtrlDatosTecnicosProyTermicoADualFuel
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
            this._gbxDatosProyectos = new Controles.CNDCGroupBox();
            this.label14 = new Controles.CNDCLabel();
            this._txtObservaciones = new Controles.CNDCTextBox();
            this.label3 = new Controles.CNDCLabel();
            this._txtModelo = new Controles.CNDCTextBox();
            this.label2 = new Controles.CNDCLabel();
            this._txtHRDiesel50 = new Controles.CNDCTextBoxInt();
            this._txtHRDiesel75 = new Controles.CNDCTextBoxInt();
            this._txtHRDiesel100 = new Controles.CNDCTextBoxInt();
            this.label1 = new Controles.CNDCLabel();
            this.label9 = new Controles.CNDCLabel();
            this.label11 = new Controles.CNDCLabel();
            this._txtCapacidadInstalada = new Controles.CNDCTextBoxFloat();
            this._txtHRGasNatural50 = new Controles.CNDCTextBoxInt();
            this.label19 = new Controles.CNDCLabel();
            this._txtHRGasNatural75 = new Controles.CNDCTextBoxInt();
            this.label18 = new Controles.CNDCLabel();
            this._txtHRGasNatural100 = new Controles.CNDCTextBoxInt();
            this.label17 = new Controles.CNDCLabel();
            this.label16 = new Controles.CNDCLabel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this._tsbEditar = new System.Windows.Forms.ToolStripButton();
            this._tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._dtpFechaRegistro = new Controles.CNDCDateTimePicker();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._gbxDatosProyectos.SuspendLayout();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbxDatosProyectos
            // 
            this._gbxDatosProyectos.BackColor = System.Drawing.SystemColors.Control;
            this._gbxDatosProyectos.Controls.Add(this.label14);
            this._gbxDatosProyectos.Controls.Add(this._txtObservaciones);
            this._gbxDatosProyectos.Controls.Add(this.label3);
            this._gbxDatosProyectos.Controls.Add(this._txtModelo);
            this._gbxDatosProyectos.Controls.Add(this.label2);
            this._gbxDatosProyectos.Controls.Add(this._txtHRDiesel50);
            this._gbxDatosProyectos.Controls.Add(this._txtHRDiesel75);
            this._gbxDatosProyectos.Controls.Add(this._txtHRDiesel100);
            this._gbxDatosProyectos.Controls.Add(this.label1);
            this._gbxDatosProyectos.Controls.Add(this.label9);
            this._gbxDatosProyectos.Controls.Add(this.label11);
            this._gbxDatosProyectos.Controls.Add(this._txtCapacidadInstalada);
            this._gbxDatosProyectos.Controls.Add(this._txtHRGasNatural50);
            this._gbxDatosProyectos.Controls.Add(this.label19);
            this._gbxDatosProyectos.Controls.Add(this._txtHRGasNatural75);
            this._gbxDatosProyectos.Controls.Add(this.label18);
            this._gbxDatosProyectos.Controls.Add(this._txtHRGasNatural100);
            this._gbxDatosProyectos.Controls.Add(this.label17);
            this._gbxDatosProyectos.Controls.Add(this.label16);
            this._gbxDatosProyectos.Location = new System.Drawing.Point(2, 20);
            this._gbxDatosProyectos.Name = "_gbxDatosProyectos";
            this._gbxDatosProyectos.Size = new System.Drawing.Size(843, 285);
            this._gbxDatosProyectos.TabIndex = 0;
            this._gbxDatosProyectos.TablaCampoBD = null;
            this._gbxDatosProyectos.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(177, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 16);
            this.label14.TabIndex = 17;
            this.label14.TablaCampoBD = null;
            this.label14.Text = "Observaciones:";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.BackColor = System.Drawing.Color.White;
            this._txtObservaciones.EnterComoTab = false;
            this._txtObservaciones.Etiqueta = null;
            this._txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtObservaciones.Location = new System.Drawing.Point(297, 195);
            this._txtObservaciones.Multiline = true;
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(529, 59);
            this._txtObservaciones.TabIndex = 18;
            this._txtObservaciones.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.OBSERVACIONES";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 34);
            this.label3.TabIndex = 4;
            this.label3.TablaCampoBD = null;
            this.label3.Text = "Heat Rate (BTU/kWh)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtModelo
            // 
            this._txtModelo.BackColor = System.Drawing.Color.White;
            this._txtModelo.EnterComoTab = true;
            this._txtModelo.Etiqueta = null;
            this._txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtModelo.Location = new System.Drawing.Point(297, 19);
            this._txtModelo.MaxLength = 500;
            this._txtModelo.Name = "_txtModelo";
            this._txtModelo.Size = new System.Drawing.Size(529, 22);
            this._txtModelo.TabIndex = 1;
            this._txtModelo.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.MODELO";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 34);
            this.label2.TabIndex = 5;
            this.label2.TablaCampoBD = null;
            this.label2.Text = "Porcentaje carga (%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtHRDiesel50
            // 
            this._txtHRDiesel50.AceptaNegativo = false;
            this._txtHRDiesel50.BackColor = System.Drawing.Color.White;
            this._txtHRDiesel50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRDiesel50.EnterComoTab = true;
            this._txtHRDiesel50.Etiqueta = null;
            this._txtHRDiesel50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRDiesel50.Location = new System.Drawing.Point(421, 172);
            this._txtHRDiesel50.MaxDigitosDecimales = 0;
            this._txtHRDiesel50.MaxDigitosEnteros = 0;
            this._txtHRDiesel50.MaxLength = 30;
            this._txtHRDiesel50.Name = "_txtHRDiesel50";
            this._txtHRDiesel50.Size = new System.Drawing.Size(124, 22);
            this._txtHRDiesel50.TabIndex = 16;
            this._txtHRDiesel50.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_DIESEL_50";
            this._txtHRDiesel50.Text = "0";
            this._txtHRDiesel50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRDiesel50.UsarFormatoNumerico = true;
            this._txtHRDiesel50.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRDiesel50.ValorDouble = 0D;
            this._txtHRDiesel50.ValorFloat = 0F;
            this._txtHRDiesel50.ValorInt = 0;
            this._txtHRDiesel50.ValorLong = ((long)(0));
            this._txtHRDiesel50.Value = 0;
            // 
            // _txtHRDiesel75
            // 
            this._txtHRDiesel75.AceptaNegativo = false;
            this._txtHRDiesel75.BackColor = System.Drawing.Color.White;
            this._txtHRDiesel75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRDiesel75.EnterComoTab = true;
            this._txtHRDiesel75.Etiqueta = null;
            this._txtHRDiesel75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRDiesel75.Location = new System.Drawing.Point(421, 151);
            this._txtHRDiesel75.MaxDigitosDecimales = 0;
            this._txtHRDiesel75.MaxDigitosEnteros = 0;
            this._txtHRDiesel75.MaxLength = 30;
            this._txtHRDiesel75.Name = "_txtHRDiesel75";
            this._txtHRDiesel75.Size = new System.Drawing.Size(124, 22);
            this._txtHRDiesel75.TabIndex = 13;
            this._txtHRDiesel75.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_DIESEL_75";
            this._txtHRDiesel75.Text = "0";
            this._txtHRDiesel75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRDiesel75.UsarFormatoNumerico = true;
            this._txtHRDiesel75.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRDiesel75.ValorDouble = 0D;
            this._txtHRDiesel75.ValorFloat = 0F;
            this._txtHRDiesel75.ValorInt = 0;
            this._txtHRDiesel75.ValorLong = ((long)(0));
            this._txtHRDiesel75.Value = 0;
            // 
            // _txtHRDiesel100
            // 
            this._txtHRDiesel100.AceptaNegativo = false;
            this._txtHRDiesel100.BackColor = System.Drawing.Color.White;
            this._txtHRDiesel100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRDiesel100.EnterComoTab = true;
            this._txtHRDiesel100.Etiqueta = null;
            this._txtHRDiesel100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRDiesel100.Location = new System.Drawing.Point(421, 130);
            this._txtHRDiesel100.MaxDigitosDecimales = 0;
            this._txtHRDiesel100.MaxDigitosEnteros = 0;
            this._txtHRDiesel100.MaxLength = 30;
            this._txtHRDiesel100.Name = "_txtHRDiesel100";
            this._txtHRDiesel100.Size = new System.Drawing.Size(124, 22);
            this._txtHRDiesel100.TabIndex = 10;
            this._txtHRDiesel100.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_DIESEL_100";
            this._txtHRDiesel100.Text = "0";
            this._txtHRDiesel100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRDiesel100.UsarFormatoNumerico = true;
            this._txtHRDiesel100.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRDiesel100.ValorDouble = 0D;
            this._txtHRDiesel100.ValorFloat = 0F;
            this._txtHRDiesel100.ValorInt = 0;
            this._txtHRDiesel100.ValorLong = ((long)(0));
            this._txtHRDiesel100.Value = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 34);
            this.label1.TabIndex = 7;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "diesel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(98, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 16);
            this.label9.TabIndex = 2;
            this.label9.TablaCampoBD = null;
            this.label9.Text = "Capacidad instalada (MW):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 0;
            this.label11.TablaCampoBD = null;
            this.label11.Text = "Modelo:";
            // 
            // _txtCapacidadInstalada
            // 
            this._txtCapacidadInstalada.AceptaNegativo = false;
            this._txtCapacidadInstalada.BackColor = System.Drawing.Color.White;
            this._txtCapacidadInstalada.EnterComoTab = true;
            this._txtCapacidadInstalada.Etiqueta = null;
            this._txtCapacidadInstalada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCapacidadInstalada.Location = new System.Drawing.Point(297, 41);
            this._txtCapacidadInstalada.MaxDigitosDecimales = 0;
            this._txtCapacidadInstalada.MaxDigitosEnteros = 0;
            this._txtCapacidadInstalada.MaxLength = 30;
            this._txtCapacidadInstalada.Name = "_txtCapacidadInstalada";
            this._txtCapacidadInstalada.Size = new System.Drawing.Size(117, 22);
            this._txtCapacidadInstalada.TabIndex = 3;
            this._txtCapacidadInstalada.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.CAPACIDAD_INSTALADA";
            this._txtCapacidadInstalada.Text = "0";
            this._txtCapacidadInstalada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtCapacidadInstalada.UsarFormatoNumerico = true;
            this._txtCapacidadInstalada.ValDouble = 0D;
            this._txtCapacidadInstalada.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtCapacidadInstalada.ValorDouble = 0D;
            this._txtCapacidadInstalada.ValorFloat = 0F;
            this._txtCapacidadInstalada.ValorInt = 0;
            this._txtCapacidadInstalada.ValorLong = ((long)(0));
            this._txtCapacidadInstalada.Value = 0F;
            // 
            // _txtHRGasNatural50
            // 
            this._txtHRGasNatural50.AceptaNegativo = false;
            this._txtHRGasNatural50.BackColor = System.Drawing.Color.White;
            this._txtHRGasNatural50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRGasNatural50.EnterComoTab = true;
            this._txtHRGasNatural50.Etiqueta = null;
            this._txtHRGasNatural50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRGasNatural50.Location = new System.Drawing.Point(297, 172);
            this._txtHRGasNatural50.MaxDigitosDecimales = 0;
            this._txtHRGasNatural50.MaxDigitosEnteros = 0;
            this._txtHRGasNatural50.MaxLength = 30;
            this._txtHRGasNatural50.Name = "_txtHRGasNatural50";
            this._txtHRGasNatural50.Size = new System.Drawing.Size(125, 22);
            this._txtHRGasNatural50.TabIndex = 15;
            this._txtHRGasNatural50.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_GAS_NATURAL_50";
            this._txtHRGasNatural50.Text = "0";
            this._txtHRGasNatural50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRGasNatural50.UsarFormatoNumerico = true;
            this._txtHRGasNatural50.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRGasNatural50.ValorDouble = 0D;
            this._txtHRGasNatural50.ValorFloat = 0F;
            this._txtHRGasNatural50.ValorInt = 0;
            this._txtHRGasNatural50.ValorLong = ((long)(0));
            this._txtHRGasNatural50.Value = 0;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(160, 172);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 22);
            this.label19.TabIndex = 14;
            this.label19.TablaCampoBD = null;
            this.label19.Text = "50%";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtHRGasNatural75
            // 
            this._txtHRGasNatural75.AceptaNegativo = false;
            this._txtHRGasNatural75.BackColor = System.Drawing.Color.White;
            this._txtHRGasNatural75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRGasNatural75.EnterComoTab = true;
            this._txtHRGasNatural75.Etiqueta = null;
            this._txtHRGasNatural75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRGasNatural75.Location = new System.Drawing.Point(297, 151);
            this._txtHRGasNatural75.MaxDigitosDecimales = 0;
            this._txtHRGasNatural75.MaxDigitosEnteros = 0;
            this._txtHRGasNatural75.MaxLength = 30;
            this._txtHRGasNatural75.Name = "_txtHRGasNatural75";
            this._txtHRGasNatural75.Size = new System.Drawing.Size(125, 22);
            this._txtHRGasNatural75.TabIndex = 12;
            this._txtHRGasNatural75.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_GAS_NATURAL_75";
            this._txtHRGasNatural75.Text = "0";
            this._txtHRGasNatural75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRGasNatural75.UsarFormatoNumerico = true;
            this._txtHRGasNatural75.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRGasNatural75.ValorDouble = 0D;
            this._txtHRGasNatural75.ValorFloat = 0F;
            this._txtHRGasNatural75.ValorInt = 0;
            this._txtHRGasNatural75.ValorLong = ((long)(0));
            this._txtHRGasNatural75.Value = 0;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(160, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 22);
            this.label18.TabIndex = 11;
            this.label18.TablaCampoBD = null;
            this.label18.Text = "75%";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtHRGasNatural100
            // 
            this._txtHRGasNatural100.AceptaNegativo = false;
            this._txtHRGasNatural100.BackColor = System.Drawing.Color.White;
            this._txtHRGasNatural100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtHRGasNatural100.EnterComoTab = true;
            this._txtHRGasNatural100.Etiqueta = null;
            this._txtHRGasNatural100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtHRGasNatural100.Location = new System.Drawing.Point(297, 130);
            this._txtHRGasNatural100.MaxDigitosDecimales = 0;
            this._txtHRGasNatural100.MaxDigitosEnteros = 0;
            this._txtHRGasNatural100.MaxLength = 30;
            this._txtHRGasNatural100.Name = "_txtHRGasNatural100";
            this._txtHRGasNatural100.Size = new System.Drawing.Size(125, 22);
            this._txtHRGasNatural100.TabIndex = 9;
            this._txtHRGasNatural100.TablaCampoBD = "F_PR_DATO_TEC_GAS_DUAL_FUEL.HEAT_RATE_GAS_NATURAL_100";
            this._txtHRGasNatural100.Text = "0";
            this._txtHRGasNatural100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtHRGasNatural100.UsarFormatoNumerico = true;
            this._txtHRGasNatural100.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._txtHRGasNatural100.ValorDouble = 0D;
            this._txtHRGasNatural100.ValorFloat = 0F;
            this._txtHRGasNatural100.ValorInt = 0;
            this._txtHRGasNatural100.ValorLong = ((long)(0));
            this._txtHRGasNatural100.Value = 0;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(160, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 22);
            this.label17.TabIndex = 8;
            this.label17.TablaCampoBD = null;
            this.label17.Text = "100% ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(297, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 34);
            this.label16.TabIndex = 6;
            this.label16.TablaCampoBD = null;
            this.label16.Text = "gas natural";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbGuardar,
            this._tsbEditar,
            this._tsbCancelar});
            this._toolStrip.Location = new System.Drawing.Point(2, 1);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(200, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _tsbGuardar
            // 
            this._tsbGuardar.Image = global::Proyectos.Properties.Resources.save;
            this._tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbGuardar.Name = "_tsbGuardar";
            this._tsbGuardar.Size = new System.Drawing.Size(66, 22);
            this._tsbGuardar.Text = "Guardar";
            this._tsbGuardar.Click += new System.EventHandler(this._tsbGuardar_Click);
            // 
            // _tsbEditar
            // 
            this._tsbEditar.Image = global::Proyectos.Properties.Resources.Edit;
            this._tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbEditar.Name = "_tsbEditar";
            this._tsbEditar.Size = new System.Drawing.Size(55, 22);
            this._tsbEditar.Text = "Editar";
            this._tsbEditar.Click += new System.EventHandler(this._tsbEditar_Click);
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
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _dtpFechaRegistro
            // 
            this._dtpFechaRegistro.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this._dtpFechaRegistro.CustomFormat = "dd/MMM/yyyy";
            this._dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFechaRegistro.Location = new System.Drawing.Point(735, 2);
            this._dtpFechaRegistro.Name = "_dtpFechaRegistro";
            this._dtpFechaRegistro.Size = new System.Drawing.Size(109, 22);
            this._dtpFechaRegistro.TabIndex = 3;
            this._dtpFechaRegistro.TablaCampoBD = null;
            this._dtpFechaRegistro.Visible = false;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cndcLabel1.Location = new System.Drawing.Point(609, 3);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(123, 20);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Fecha de Registro:";
            this.cndcLabel1.Visible = false;
            // 
            // CtrlDatosTecnicosProyTermicoADualFuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dtpFechaRegistro);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._gbxDatosProyectos);
            this.Name = "CtrlDatosTecnicosProyTermicoADualFuel";
            this.Size = new System.Drawing.Size(846, 308);
            this._gbxDatosProyectos.ResumeLayout(false);
            this._gbxDatosProyectos.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _tsbGuardar;
        private System.Windows.Forms.ToolStripButton _tsbCancelar;
        private Controles.CNDCGroupBox _gbxDatosProyectos;
        private Controles.CNDCLabel label2;
        private Controles.CNDCTextBoxInt _txtHRDiesel50;
        private Controles.CNDCTextBoxInt _txtHRDiesel75;
        private Controles.CNDCTextBoxInt _txtHRDiesel100;
        private Controles.CNDCLabel label1;
        private Controles.CNDCLabel label9;
        private Controles.CNDCLabel label11;
        private Controles.CNDCTextBoxFloat _txtCapacidadInstalada;
        private Controles.CNDCTextBoxInt _txtHRGasNatural50;
        private Controles.CNDCLabel label19;
        private Controles.CNDCTextBoxInt _txtHRGasNatural75;
        private Controles.CNDCLabel label18;
        private Controles.CNDCTextBoxInt _txtHRGasNatural100;
        private Controles.CNDCLabel label17;
        private Controles.CNDCLabel label16;
        private Controles.CNDCTextBox _txtModelo;
        private Controles.CNDCLabel label3;
        private Controles.CNDCLabel label14;
        private Controles.CNDCTextBox _txtObservaciones;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ToolStripButton _tsbEditar;
        protected Controles.CNDCDateTimePicker _dtpFechaRegistro;
        private Controles.CNDCLabel cndcLabel1;
    }
}
