namespace SISFALLA
{
    partial class FormReleOperado
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
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this.cndcLabelControl5 = new Controles.CNDCLabel();
            this._txtDistancia = new Controles.CNDCTextBoxFloat();
            this._cmbFuncion = new Controles.CNDCComboBox();
            this._txtTipoRele = new Controles.CNDCTextBox();
            this._txtZona = new Controles.CNDCTextBoxInt();
            this._txtTiempo = new Controles.CNDCTextBoxInt();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Location = new System.Drawing.Point(177, 40);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(48, 13);
            this.cndcLabelControl1.TabIndex = 4;
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Text = "Función:";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Location = new System.Drawing.Point(154, 71);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(71, 13);
            this.cndcLabelControl2.TabIndex = 6;
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Text = "Tipo de Relé:";
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Location = new System.Drawing.Point(158, 93);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(67, 13);
            this.cndcLabelControl3.TabIndex = 8;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Tiempo(MS):";
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Location = new System.Drawing.Point(190, 119);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(35, 13);
            this.cndcLabelControl4.TabIndex = 10;
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Text = "Zona:";
            // 
            // cndcLabelControl5
            // 
            this.cndcLabelControl5.AutoSize = true;
            this.cndcLabelControl5.Location = new System.Drawing.Point(150, 145);
            this.cndcLabelControl5.Name = "cndcLabelControl5";
            this.cndcLabelControl5.Size = new System.Drawing.Size(75, 13);
            this.cndcLabelControl5.TabIndex = 12;
            this.cndcLabelControl5.TablaCampoBD = null;
            this.cndcLabelControl5.Text = "Distancia(Km):";
            // 
            // _txtDistancia
            // 
            this._txtDistancia.EnterComoTab = false;
            this._txtDistancia.Etiqueta = null;
            this._txtDistancia.Location = new System.Drawing.Point(231, 142);
            this._txtDistancia.MaxLength = 15;
            this._txtDistancia.Name = "_txtDistancia";
            this._txtDistancia.Size = new System.Drawing.Size(100, 20);
            this._txtDistancia.TabIndex = 4;
            this._txtDistancia.TablaCampoBD = "F_GF_RELES_OPER.DISTANCIA_RELE";
            this._txtDistancia.Text = ",00";
            this._txtDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtDistancia.ValDouble = 0D;
            this._txtDistancia.Value = 0F;
            // 
            // _cmbFuncion
            // 
            this._cmbFuncion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFuncion.EnterComoTab = false;
            this._cmbFuncion.Etiqueta = null;
            this._cmbFuncion.FormattingEnabled = true;
            this._cmbFuncion.Location = new System.Drawing.Point(231, 37);
            this._cmbFuncion.Name = "_cmbFuncion";
            this._cmbFuncion.Size = new System.Drawing.Size(415, 21);
            this._cmbFuncion.TabIndex = 0;
            this._cmbFuncion.TablaCampoBD = "F_GF_RELES_OPER.FUNCION_RELE";
            // 
            // _txtTipoRele
            // 
            this._txtTipoRele.EnterComoTab = false;
            this._txtTipoRele.Etiqueta = null;
            this._txtTipoRele.Location = new System.Drawing.Point(231, 65);
            this._txtTipoRele.MaxLength = 20;
            this._txtTipoRele.Name = "_txtTipoRele";
            this._txtTipoRele.Size = new System.Drawing.Size(100, 20);
            this._txtTipoRele.TabIndex = 1;
            this._txtTipoRele.TablaCampoBD = "F_GF_RELES_OPER.TIPO_RELE";
            // 
            // _txtZona
            // 
            this._txtZona.EnterComoTab = false;
            this._txtZona.Etiqueta = null;
            this._txtZona.Location = new System.Drawing.Point(231, 116);
            this._txtZona.MaxLength = 9;
            this._txtZona.Name = "_txtZona";
            this._txtZona.Size = new System.Drawing.Size(100, 20);
            this._txtZona.TabIndex = 3;
            this._txtZona.TablaCampoBD = "F_GF_RELES_OPER.ZONA_RELE";
            this._txtZona.Text = "0";
            this._txtZona.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtZona.Value = 0;
            // 
            // _txtTiempo
            // 
            this._txtTiempo.EnterComoTab = false;
            this._txtTiempo.Etiqueta = null;
            this._txtTiempo.Location = new System.Drawing.Point(231, 90);
            this._txtTiempo.MaxLength = 9;
            this._txtTiempo.Name = "_txtTiempo";
            this._txtTiempo.Size = new System.Drawing.Size(100, 20);
            this._txtTiempo.TabIndex = 2;
            this._txtTiempo.TablaCampoBD = "F_GF_RELES_OPER.TIEMPO_RELE";
            this._txtTiempo.Text = "0";
            this._txtTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTiempo.Value = 0;
            // 
            // FormReleOperado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 195);
            this.Controls.Add(this._txtTiempo);
            this.Controls.Add(this._txtZona);
            this.Controls.Add(this._txtTipoRele);
            this.Controls.Add(this._cmbFuncion);
            this.Controls.Add(this._txtDistancia);
            this.Controls.Add(this.cndcLabelControl5);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this.cndcLabelControl3);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this.cndcLabelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormReleOperado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Relé Operado";
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl2, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl3, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl4, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl5, 0);
            this.Controls.SetChildIndex(this._txtDistancia, 0);
            this.Controls.SetChildIndex(this._cmbFuncion, 0);
            this.Controls.SetChildIndex(this._txtTipoRele, 0);
            this.Controls.SetChildIndex(this._txtZona, 0);
            this.Controls.SetChildIndex(this._txtTiempo, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCLabel cndcLabelControl5;
        private Controles.CNDCTextBoxFloat _txtDistancia;
        private Controles.CNDCComboBox _cmbFuncion;
        private Controles.CNDCTextBox _txtTipoRele;
        private Controles.CNDCTextBoxInt _txtZona;
        private Controles.CNDCTextBoxInt _txtTiempo;
    }
}