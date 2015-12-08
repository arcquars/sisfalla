namespace SISFALLA
{
    partial class FrmAlimentador
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
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtFechaHoraAp = new Controles.CNDCTextBoxDateTime();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._cbxTipoOpeAper = new Controles.CNDCComboBox();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._lblTiempoRele = new Controles.CNDCLabel();
            this._lblFrecuencia = new Controles.CNDCLabel();
            this._lblEtapa = new Controles.CNDCLabel();
            this._cbxReleOperado = new Controles.CNDCComboBox();
            this.cndcLabelControl8 = new Controles.CNDCLabel();
            this.cndcLabelControl7 = new Controles.CNDCLabel();
            this.cndcLabelControl6 = new Controles.CNDCLabel();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcGroupBox3 = new Controles.CNDCGroupBox();
            this._txtTiempoTDesc = new Controles.CNDCLabel();
            this._txtPotDesc = new Controles.CNDCTextBoxFloat();
            this._lblEnergiaNoSuminis = new Controles.CNDCLabel();
            this.cndcLabelControl12 = new Controles.CNDCLabel();
            this.cndcLabelControl10 = new Controles.CNDCLabel();
            this.cndcLabelControl9 = new Controles.CNDCLabel();
            this.cndcGroupBox4 = new Controles.CNDCGroupBox();
            this._txtFechaHoraCierre = new Controles.CNDCTextBoxDateTime();
            this.cndcLabelControl5 = new Controles.CNDCLabel();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._cbxTipoOperCierre = new Controles.CNDCComboBox();
            this._ctrlComponenteComprometido = new SISFALLA.CtrlComponente();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            this.cndcGroupBox3.SuspendLayout();
            this.cndcGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtFechaHoraAp);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl4);
            this.cndcGroupBox1.Controls.Add(this.cndcLabelControl2);
            this.cndcGroupBox1.Controls.Add(this._cbxTipoOpeAper);
            this.cndcGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox1.Location = new System.Drawing.Point(45, 62);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(310, 77);
            this.cndcGroupBox1.TabIndex = 4;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Apertura :";
            // 
            // _txtFechaHoraAp
            // 
            this._txtFechaHoraAp.Etiqueta = null;
            this._txtFechaHoraAp.Location = new System.Drawing.Point(127, 23);
            this._txtFechaHoraAp.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraAp.Name = "_txtFechaHoraAp";
            this._txtFechaHoraAp.Size = new System.Drawing.Size(112, 20);
            this._txtFechaHoraAp.TabIndex = 1;
            this._txtFechaHoraAp.TablaCampoBD = "F_GF_OP_ALIMENTADOR.FECHA_APERTURA";
            this._txtFechaHoraAp.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraAp.ValidadorFormatoFecha = null;
            this._txtFechaHoraAp.ValidadorIngresoOnline = null;
            this._txtFechaHoraAp.Value = new System.DateTime(((long)(0)));
            this._txtFechaHoraAp.TextChanged += new System.EventHandler(this._txtFechaHoraAp_TextChanged);
            this._txtFechaHoraAp.Validating += new System.ComponentModel.CancelEventHandler(this._txtFechaHoraAp_Validating);
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.Location = new System.Drawing.Point(24, 47);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(99, 16);
            this.cndcLabelControl4.TabIndex = 2;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Tipo de Operación:";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.Location = new System.Drawing.Point(43, 24);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl2.TabIndex = 0;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "Fecha y Hora :";
            // 
            // _cbxTipoOpeAper
            // 
            this._cbxTipoOpeAper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxTipoOpeAper.EnterComoTab = false;
            this._cbxTipoOpeAper.Etiqueta = null;
            this._cbxTipoOpeAper.FormattingEnabled = true;
            this._cbxTipoOpeAper.Location = new System.Drawing.Point(127, 46);
            this._cbxTipoOpeAper.Name = "_cbxTipoOpeAper";
            this._cbxTipoOpeAper.Size = new System.Drawing.Size(161, 21);
            this._cbxTipoOpeAper.TabIndex = 3;
            this._cbxTipoOpeAper.TablaCampoBD = "F_GF_OP_ALIMENTADOR.D_COD_TIPO_OPER_APER";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._lblTiempoRele);
            this.cndcGroupBox2.Controls.Add(this._lblFrecuencia);
            this.cndcGroupBox2.Controls.Add(this._lblEtapa);
            this.cndcGroupBox2.Controls.Add(this._cbxReleOperado);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl8);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl7);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl6);
            this.cndcGroupBox2.Controls.Add(this.cndcLabelControl1);
            this.cndcGroupBox2.Location = new System.Drawing.Point(148, 150);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(207, 108);
            this.cndcGroupBox2.TabIndex = 6;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Relé Operado :";
            // 
            // _lblTiempoRele
            // 
            this._lblTiempoRele.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblTiempoRele.Location = new System.Drawing.Point(152, 76);
            this._lblTiempoRele.Name = "_lblTiempoRele";
            this._lblTiempoRele.Size = new System.Drawing.Size(40, 20);
            this._lblTiempoRele.TabIndex = 7;
            this._lblTiempoRele.TablaCampoBD = null;
            this._lblTiempoRele.Text = "00:00";
            this._lblTiempoRele.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblFrecuencia
            // 
            this._lblFrecuencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblFrecuencia.Location = new System.Drawing.Point(80, 76);
            this._lblFrecuencia.Name = "_lblFrecuencia";
            this._lblFrecuencia.Size = new System.Drawing.Size(65, 20);
            this._lblFrecuencia.TabIndex = 6;
            this._lblFrecuencia.TablaCampoBD = null;
            this._lblFrecuencia.Text = "0.00";
            this._lblFrecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblEtapa
            // 
            this._lblEtapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblEtapa.Location = new System.Drawing.Point(33, 76);
            this._lblEtapa.Name = "_lblEtapa";
            this._lblEtapa.Size = new System.Drawing.Size(40, 20);
            this._lblEtapa.TabIndex = 5;
            this._lblEtapa.TablaCampoBD = null;
            this._lblEtapa.Text = "0";
            this._lblEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cbxReleOperado
            // 
            this._cbxReleOperado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxReleOperado.EnterComoTab = false;
            this._cbxReleOperado.Etiqueta = null;
            this._cbxReleOperado.FormattingEnabled = true;
            this._cbxReleOperado.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this._cbxReleOperado.Location = new System.Drawing.Point(121, 30);
            this._cbxReleOperado.Name = "_cbxReleOperado";
            this._cbxReleOperado.Size = new System.Drawing.Size(73, 21);
            this._cbxReleOperado.TabIndex = 1;
            this._cbxReleOperado.TablaCampoBD = null;
            this._cbxReleOperado.SelectedIndexChanged += new System.EventHandler(this._cbxReleOperado_SelectedIndexChanged);
            // 
            // cndcLabelControl8
            // 
            this.cndcLabelControl8.AutoSize = true;
            this.cndcLabelControl8.Location = new System.Drawing.Point(151, 58);
            this.cndcLabelControl8.Name = "cndcLabelControl8";
            this.cndcLabelControl8.Size = new System.Drawing.Size(48, 13);
            this.cndcLabelControl8.TabIndex = 4;
            this.cndcLabelControl8.TablaCampoBD = null;
            this.cndcLabelControl8.Text = "Tiempo :";
            // 
            // cndcLabelControl7
            // 
            this.cndcLabelControl7.AutoSize = true;
            this.cndcLabelControl7.Location = new System.Drawing.Point(79, 58);
            this.cndcLabelControl7.Name = "cndcLabelControl7";
            this.cndcLabelControl7.Size = new System.Drawing.Size(66, 13);
            this.cndcLabelControl7.TabIndex = 3;
            this.cndcLabelControl7.TablaCampoBD = null;
            this.cndcLabelControl7.Text = "Frecuencia :";
            // 
            // cndcLabelControl6
            // 
            this.cndcLabelControl6.AutoSize = true;
            this.cndcLabelControl6.Location = new System.Drawing.Point(32, 58);
            this.cndcLabelControl6.Name = "cndcLabelControl6";
            this.cndcLabelControl6.Size = new System.Drawing.Size(41, 13);
            this.cndcLabelControl6.TabIndex = 2;
            this.cndcLabelControl6.TablaCampoBD = null;
            this.cndcLabelControl6.Text = "Etapa :";
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(76, 33);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(39, 13);
            this.cndcLabelControl1.TabIndex = 0;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "EDAC:";
            // 
            // cndcGroupBox3
            // 
            this.cndcGroupBox3.Controls.Add(this._txtTiempoTDesc);
            this.cndcGroupBox3.Controls.Add(this._txtPotDesc);
            this.cndcGroupBox3.Controls.Add(this._lblEnergiaNoSuminis);
            this.cndcGroupBox3.Controls.Add(this.cndcLabelControl12);
            this.cndcGroupBox3.Controls.Add(this.cndcLabelControl10);
            this.cndcGroupBox3.Controls.Add(this.cndcLabelControl9);
            this.cndcGroupBox3.Location = new System.Drawing.Point(365, 150);
            this.cndcGroupBox3.Name = "cndcGroupBox3";
            this.cndcGroupBox3.Size = new System.Drawing.Size(287, 108);
            this.cndcGroupBox3.TabIndex = 7;
            this.cndcGroupBox3.TablaCampoBD = null;
            this.cndcGroupBox3.TabStop = false;
            this.cndcGroupBox3.Text = "Inf Adicional :";
            // 
            // _txtTiempoTDesc
            // 
            this._txtTiempoTDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTiempoTDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTiempoTDesc.Location = new System.Drawing.Point(183, 52);
            this._txtTiempoTDesc.Name = "_txtTiempoTDesc";
            this._txtTiempoTDesc.Size = new System.Drawing.Size(77, 20);
            this._txtTiempoTDesc.TabIndex = 3;
            this._txtTiempoTDesc.TablaCampoBD = null;
            this._txtTiempoTDesc.Text = "0.00";
            this._txtTiempoTDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtPotDesc
            // 
            this._txtPotDesc.EnterComoTab = false;
            this._txtPotDesc.Etiqueta = null;
            this._txtPotDesc.Location = new System.Drawing.Point(183, 27);
            this._txtPotDesc.Name = "_txtPotDesc";
            this._txtPotDesc.Size = new System.Drawing.Size(77, 20);
            this._txtPotDesc.TabIndex = 1;
            this._txtPotDesc.TablaCampoBD = "F_GF_OP_ALIMENTADOR.POT_DESC";
            this._txtPotDesc.Text = ",00";
            this._txtPotDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPotDesc.ValDouble = 0D;
            this._txtPotDesc.Value = 0F;
            this._txtPotDesc.TextChanged += new System.EventHandler(this._txtPotDesc_TextChanged);
            // 
            // _lblEnergiaNoSuminis
            // 
            this._lblEnergiaNoSuminis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblEnergiaNoSuminis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEnergiaNoSuminis.Location = new System.Drawing.Point(183, 77);
            this._lblEnergiaNoSuminis.Name = "_lblEnergiaNoSuminis";
            this._lblEnergiaNoSuminis.Size = new System.Drawing.Size(77, 20);
            this._lblEnergiaNoSuminis.TabIndex = 5;
            this._lblEnergiaNoSuminis.TablaCampoBD = null;
            this._lblEnergiaNoSuminis.Text = "0.00";
            this._lblEnergiaNoSuminis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cndcLabelControl12
            // 
            this.cndcLabelControl12.AutoSize = true;
            this.cndcLabelControl12.Location = new System.Drawing.Point(13, 82);
            this.cndcLabelControl12.Name = "cndcLabelControl12";
            this.cndcLabelControl12.Size = new System.Drawing.Size(166, 13);
            this.cndcLabelControl12.TabIndex = 4;
            this.cndcLabelControl12.TablaCampoBD = null;
            this.cndcLabelControl12.Text = "Energía No Suministrada (MWh) :";
            // 
            // cndcLabelControl10
            // 
            this.cndcLabelControl10.AutoSize = true;
            this.cndcLabelControl10.Location = new System.Drawing.Point(49, 55);
            this.cndcLabelControl10.Name = "cndcLabelControl10";
            this.cndcLabelControl10.Size = new System.Drawing.Size(128, 13);
            this.cndcLabelControl10.TabIndex = 2;
            this.cndcLabelControl10.TablaCampoBD = null;
            this.cndcLabelControl10.Text = "Tiempo Total Desc (min) :";
            // 
            // cndcLabelControl9
            // 
            this.cndcLabelControl9.AutoSize = true;
            this.cndcLabelControl9.Location = new System.Drawing.Point(88, 30);
            this.cndcLabelControl9.Name = "cndcLabelControl9";
            this.cndcLabelControl9.Size = new System.Drawing.Size(89, 13);
            this.cndcLabelControl9.TabIndex = 0;
            this.cndcLabelControl9.TablaCampoBD = null;
            this.cndcLabelControl9.Text = "Pot. Desc (MW) :";
            // 
            // cndcGroupBox4
            // 
            this.cndcGroupBox4.Controls.Add(this._txtFechaHoraCierre);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl5);
            this.cndcGroupBox4.Controls.Add(this.cndcLabelControl3);
            this.cndcGroupBox4.Controls.Add(this._cbxTipoOperCierre);
            this.cndcGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox4.Location = new System.Drawing.Point(366, 62);
            this.cndcGroupBox4.Name = "cndcGroupBox4";
            this.cndcGroupBox4.Size = new System.Drawing.Size(302, 78);
            this.cndcGroupBox4.TabIndex = 5;
            this.cndcGroupBox4.TablaCampoBD = null;
            this.cndcGroupBox4.TabStop = false;
            this.cndcGroupBox4.Text = "Cierre :";
            // 
            // _txtFechaHoraCierre
            // 
            this._txtFechaHoraCierre.Etiqueta = null;
            this._txtFechaHoraCierre.Location = new System.Drawing.Point(117, 23);
            this._txtFechaHoraCierre.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraCierre.Name = "_txtFechaHoraCierre";
            this._txtFechaHoraCierre.Size = new System.Drawing.Size(112, 20);
            this._txtFechaHoraCierre.TabIndex = 1;
            this._txtFechaHoraCierre.TablaCampoBD = "F_GF_OP_ALIMENTADOR.FECHA_CIERRE";
            this._txtFechaHoraCierre.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraCierre.ValidadorFormatoFecha = null;
            this._txtFechaHoraCierre.ValidadorIngresoOnline = null;
            this._txtFechaHoraCierre.Value = new System.DateTime(((long)(0)));
            this._txtFechaHoraCierre.TextChanged += new System.EventHandler(this._txtFechaHoraAp_TextChanged);
            this._txtFechaHoraCierre.Validating += new System.ComponentModel.CancelEventHandler(this._txtFechaHoraCierre_Validating);
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.AutoSize = true;
            this.cndcLabelControl5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl5.Location = new System.Drawing.Point(14, 47);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(99, 16);
            this.cndcLabelControl5.TabIndex = 2;
            this.cndcLabelControl5.TablaCampoBD = null;
            this.cndcLabelControl5.Text = "Tipo de Operación:";
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl3.Location = new System.Drawing.Point(33, 24);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(80, 16);
            this.cndcLabelControl3.TabIndex = 0;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Fecha y Hora :";
            // 
            // _cbxTipoOperCierre
            // 
            this._cbxTipoOperCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxTipoOperCierre.EnterComoTab = false;
            this._cbxTipoOperCierre.Etiqueta = null;
            this._cbxTipoOperCierre.FormattingEnabled = true;
            this._cbxTipoOperCierre.Location = new System.Drawing.Point(117, 46);
            this._cbxTipoOperCierre.Name = "_cbxTipoOperCierre";
            this._cbxTipoOperCierre.Size = new System.Drawing.Size(161, 21);
            this._cbxTipoOperCierre.TabIndex = 3;
            this._cbxTipoOperCierre.TablaCampoBD = "F_GF_OP_ALIMENTADOR.D_COD_TIPO_OP_CIERRE";
            // 
            // _ctrlComponenteComprometido
            // 
            this._ctrlComponenteComprometido.AnchoBoton = 145;
            this._ctrlComponenteComprometido.Componente = null;
            this._ctrlComponenteComprometido.Location = new System.Drawing.Point(16, 28);
            this._ctrlComponenteComprometido.Name = "_ctrlComponenteComprometido";
            this._ctrlComponenteComprometido.PkCodComponente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._ctrlComponenteComprometido.Size = new System.Drawing.Size(705, 23);
            this._ctrlComponenteComprometido.TabIndex = 3;
            this._ctrlComponenteComprometido.TextoBoton = "Alimentador";
            // 
            // FrmAlimentador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 293);
            this.Controls.Add(this._ctrlComponenteComprometido);
            this.Controls.Add(this.cndcGroupBox4);
            this.Controls.Add(this.cndcGroupBox3);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAlimentador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Editar Alimentador";
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox3, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox4, 0);
            this.Controls.SetChildIndex(this._ctrlComponenteComprometido, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.cndcGroupBox3.ResumeLayout(false);
            this.cndcGroupBox3.PerformLayout();
            this.cndcGroupBox4.ResumeLayout(false);
            this.cndcGroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCComboBox _cbxTipoOpeAper;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCComboBox _cbxReleOperado;
        private Controles.CNDCLabel cndcLabelControl8;
        private Controles.CNDCLabel cndcLabelControl7;
        private Controles.CNDCLabel cndcLabelControl6;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCGroupBox cndcGroupBox3;
        private Controles.CNDCLabel _lblEnergiaNoSuminis;
        private Controles.CNDCLabel cndcLabelControl12;
        private Controles.CNDCLabel cndcLabelControl10;
        private Controles.CNDCLabel cndcLabelControl9;
        private Controles.CNDCGroupBox cndcGroupBox4;
        private Controles.CNDCComboBox _cbxTipoOperCierre;
        private Controles.CNDCLabel _lblTiempoRele;
        private Controles.CNDCLabel _lblFrecuencia;
        private Controles.CNDCLabel _lblEtapa;
        private CtrlComponente _ctrlComponenteComprometido;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCLabel cndcLabelControl5;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCTextBoxFloat _txtPotDesc;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraAp;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraCierre;
        private Controles.CNDCLabel _txtTiempoTDesc;
    }
}