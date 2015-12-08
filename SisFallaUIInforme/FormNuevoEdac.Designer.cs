namespace SisFallaUIInforme
{
    partial class FormNuevoEdac
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
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnAceptar = new System.Windows.Forms.Button();
            this._cmbEtapa = new Controles.CNDCComboBox();
            this._cmbAlimentador = new Controles.CNDCComboBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this.SuspendLayout();
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(205, 151);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 29);
            this._btnCancelar.TabIndex = 17;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(94, 151);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(84, 29);
            this._btnAceptar.TabIndex = 16;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _cmbEtapa
            // 
            this._cmbEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEtapa.EnterComoTab = false;
            this._cmbEtapa.Etiqueta = null;
            this._cmbEtapa.FormattingEnabled = true;
            this._cmbEtapa.Location = new System.Drawing.Point(139, 37);
            this._cmbEtapa.Name = "_cmbEtapa";
            this._cmbEtapa.Size = new System.Drawing.Size(189, 21);
            this._cmbEtapa.TabIndex = 18;
            this._cmbEtapa.TablaCampoBD = null;
            // 
            // _cmbAlimentador
            // 
            this._cmbAlimentador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAlimentador.EnterComoTab = false;
            this._cmbAlimentador.Etiqueta = null;
            this._cmbAlimentador.FormattingEnabled = true;
            this._cmbAlimentador.Location = new System.Drawing.Point(139, 86);
            this._cmbAlimentador.Name = "_cmbAlimentador";
            this._cmbAlimentador.Size = new System.Drawing.Size(189, 21);
            this._cmbAlimentador.TabIndex = 19;
            this._cmbAlimentador.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(81, 42);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(38, 13);
            this.cndcLabel1.TabIndex = 20;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Etapa:";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(54, 89);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(65, 13);
            this.cndcLabel2.TabIndex = 21;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Alimentador:";
            // 
            // FormNuevoEdac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 194);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._cmbAlimentador);
            this.Controls.Add(this._cmbEtapa);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormNuevoEdac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNuevoEdac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnAceptar;
        private Controles.CNDCComboBox _cmbEtapa;
        private Controles.CNDCComboBox _cmbAlimentador;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
    }
}