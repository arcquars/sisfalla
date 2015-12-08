namespace SISFALLA
{
    partial class FormCompComprometido
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
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this._txtPotDesc = new Controles.CNDCTextBoxFloat();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._rbtnNegativo = new Controles.CNDCRadioButton();
            this._rbtnPositivo = new Controles.CNDCRadioButton();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._lblFechaHora = new Controles.CNDCLabel();
            this._txtFechaHoraFalla = new Controles.CNDCTextBoxDateTime();
            this._txtTiempoTotalDesconexion = new Controles.CNDCLabelFloat();
            this._ctrlAsignacionResponsabilidad = new SISFALLA.CtrlAsignacionResponsabilidad();
            this._ctrlTiemposDetalle = new SISFALLA.CtrlTiempoDetalle();
            this._ctrlCompCompr = new SISFALLA.CtrlComponente();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.cndcPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Location = new System.Drawing.Point(463, 94);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(146, 13);
            this.cndcLabelControl4.TabIndex = 11;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Tiempo total de desconexión:";
            // 
            // _txtPotDesc
            // 
            this._txtPotDesc.EnterComoTab = false;
            this._txtPotDesc.Etiqueta = null;
            this._txtPotDesc.Location = new System.Drawing.Point(390, 91);
            this._txtPotDesc.Name = "_txtPotDesc";
            this._txtPotDesc.Size = new System.Drawing.Size(71, 20);
            this._txtPotDesc.TabIndex = 10;
            this._txtPotDesc.TablaCampoBD = "F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA";
            this._txtPotDesc.Text = ",00";
            this._txtPotDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtPotDesc.ValDouble = 0D;
            this._txtPotDesc.Value = 0F;
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Location = new System.Drawing.Point(305, 94);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(81, 13);
            this.cndcLabelControl3.TabIndex = 9;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Pot. desc.(MW)";
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cndcPanelControl1.Controls.Add(this._rbtnNegativo);
            this.cndcPanelControl1.Controls.Add(this._rbtnPositivo);
            this.cndcPanelControl1.Location = new System.Drawing.Point(157, 90);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(141, 21);
            this.cndcPanelControl1.TabIndex = 8;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _rbtnNegativo
            // 
            this._rbtnNegativo.AutoSize = true;
            this._rbtnNegativo.Location = new System.Drawing.Point(68, 1);
            this._rbtnNegativo.Name = "_rbtnNegativo";
            this._rbtnNegativo.Size = new System.Drawing.Size(68, 17);
            this._rbtnNegativo.TabIndex = 1;
            this._rbtnNegativo.TablaCampoBD = null;
            this._rbtnNegativo.Text = "Negativo";
            this._rbtnNegativo.UseVisualStyleBackColor = true;
            // 
            // _rbtnPositivo
            // 
            this._rbtnPositivo.AutoSize = true;
            this._rbtnPositivo.Checked = true;
            this._rbtnPositivo.Location = new System.Drawing.Point(3, 1);
            this._rbtnPositivo.Name = "_rbtnPositivo";
            this._rbtnPositivo.Size = new System.Drawing.Size(62, 17);
            this._rbtnPositivo.TabIndex = 0;
            this._rbtnPositivo.TablaCampoBD = null;
            this._rbtnPositivo.TabStop = true;
            this._rbtnPositivo.Text = "Positivo";
            this._rbtnPositivo.UseVisualStyleBackColor = true;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(32, 94);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(122, 13);
            this.cndcLabelControl1.TabIndex = 7;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Flujo de nodo1 a nodo2:";
            // 
            // _lblFechaHora
            // 
            this._lblFechaHora.AutoSize = true;
            this._lblFechaHora.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFechaHora.Location = new System.Drawing.Point(31, 37);
            this._lblFechaHora.Name = "_lblFechaHora";
            this._lblFechaHora.Size = new System.Drawing.Size(122, 16);
            this._lblFechaHora.TabIndex = 4;
            this._lblFechaHora.TablaCampoBD = null;
            this._lblFechaHora.Text = "Fecha y hora de la falla:";
            // 
            // _txtFechaHoraFalla
            // 
            this._txtFechaHoraFalla.Etiqueta = this._lblFechaHora;
            this._txtFechaHoraFalla.Location = new System.Drawing.Point(157, 37);
            this._txtFechaHoraFalla.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraFalla.Name = "_txtFechaHoraFalla";
            this._txtFechaHoraFalla.Size = new System.Drawing.Size(109, 20);
            this._txtFechaHoraFalla.TabIndex = 5;
            this._txtFechaHoraFalla.TablaCampoBD = "F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA";
            this._txtFechaHoraFalla.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraFalla.ValidadorFormatoFecha = null;
            this._txtFechaHoraFalla.ValidadorIngresoOnline = null;
            this._txtFechaHoraFalla.Value = new System.DateTime(((long)(0)));
            this._txtFechaHoraFalla.Validating += new System.ComponentModel.CancelEventHandler(this._txtFechaHoraFalla_Validating);
            // 
            // _txtTiempoTotalDesconexion
            // 
            this._txtTiempoTotalDesconexion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTiempoTotalDesconexion.Location = new System.Drawing.Point(615, 91);
            this._txtTiempoTotalDesconexion.Margin = new System.Windows.Forms.Padding(0);
            this._txtTiempoTotalDesconexion.Name = "_txtTiempoTotalDesconexion";
            this._txtTiempoTotalDesconexion.Size = new System.Drawing.Size(71, 20);
            this._txtTiempoTotalDesconexion.TabIndex = 16;
            this._txtTiempoTotalDesconexion.Text = "0,00";
            this._txtTiempoTotalDesconexion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._txtTiempoTotalDesconexion.Value = 0F;
            // 
            // _ctrlAsignacionResponsabilidad
            // 
            this._ctrlAsignacionResponsabilidad.Location = new System.Drawing.Point(555, 117);
            this._ctrlAsignacionResponsabilidad.MaximumSize = new System.Drawing.Size(180, 220);
            this._ctrlAsignacionResponsabilidad.Name = "_ctrlAsignacionResponsabilidad";
            this._ctrlAsignacionResponsabilidad.PanelToolVisible = true;
            this._ctrlAsignacionResponsabilidad.Size = new System.Drawing.Size(180, 214);
            this._ctrlAsignacionResponsabilidad.SoloLectura = false;
            this._ctrlAsignacionResponsabilidad.TabIndex = 14;
            this._ctrlAsignacionResponsabilidad.TiempoPOper = 0F;
            this._ctrlAsignacionResponsabilidad.TiempoPSist = 0F;
            this._ctrlAsignacionResponsabilidad.TiempoTotalSistema = 0F;
            // 
            // _ctrlTiemposDetalle
            // 
            this._ctrlTiemposDetalle.Location = new System.Drawing.Point(34, 117);
            this._ctrlTiemposDetalle.Name = "_ctrlTiemposDetalle";
            this._ctrlTiemposDetalle.PanelToolVisible = true;
            this._ctrlTiemposDetalle.Size = new System.Drawing.Size(521, 214);
            this._ctrlTiemposDetalle.SoloLectura = false;
            this._ctrlTiemposDetalle.TabIndex = 13;
            this._ctrlTiemposDetalle.TiempoConexion = 0F;
            this._ctrlTiemposDetalle.TiempoIndisponibilidad = 0F;
            this._ctrlTiemposDetalle.TiempoPreconexion = 0F;
            // 
            // _ctrlCompCompr
            // 
            this._ctrlCompCompr.AnchoBoton = 145;
            this._ctrlCompCompr.Componente = null;
            this._ctrlCompCompr.Location = new System.Drawing.Point(9, 63);
            this._ctrlCompCompr.Name = "_ctrlCompCompr";
            this._ctrlCompCompr.PkCodComponente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._ctrlCompCompr.Size = new System.Drawing.Size(744, 23);
            this._ctrlCompCompr.TabIndex = 6;
            this._ctrlCompCompr.TextoBoton = "Componente Comprometido";
            // 
            // FormCompComprometido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 360);
            this.Controls.Add(this._txtTiempoTotalDesconexion);
            this.Controls.Add(this._txtFechaHoraFalla);
            this.Controls.Add(this._ctrlAsignacionResponsabilidad);
            this.Controls.Add(this._ctrlTiemposDetalle);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._txtPotDesc);
            this.Controls.Add(this.cndcLabelControl3);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._ctrlCompCompr);
            this.Controls.Add(this._lblFechaHora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCompComprometido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Componente Comprometido";
            this.Controls.SetChildIndex(this._lblFechaHora, 0);
            this.Controls.SetChildIndex(this._ctrlCompCompr, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this.cndcPanelControl1, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl3, 0);
            this.Controls.SetChildIndex(this._txtPotDesc, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl4, 0);
            this.Controls.SetChildIndex(this._ctrlTiemposDetalle, 0);
            this.Controls.SetChildIndex(this._ctrlAsignacionResponsabilidad, 0);
            this.Controls.SetChildIndex(this._txtFechaHoraFalla, 0);
            this.Controls.SetChildIndex(this._txtTiempoTotalDesconexion, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCTextBoxFloat _txtPotDesc;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCRadioButton _rbtnNegativo;
        private Controles.CNDCRadioButton _rbtnPositivo;
        private Controles.CNDCLabel cndcLabelControl1;
        private CtrlComponente _ctrlCompCompr;
        private Controles.CNDCLabel _lblFechaHora;
        private CtrlTiempoDetalle _ctrlTiemposDetalle;
        private CtrlAsignacionResponsabilidad _ctrlAsignacionResponsabilidad;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraFalla;
        private Controles.CNDCLabelFloat _txtTiempoTotalDesconexion;
    }
}