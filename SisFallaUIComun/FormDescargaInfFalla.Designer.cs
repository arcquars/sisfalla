namespace SISFALLA
{
    partial class FormDescargaInfFalla
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._cmbRegistrosFalla = new Controles.CNDCComboBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._btnDecargar = new Controles.CNDCButton();
            this._btnCancelar = new Controles.CNDCButton();
            this._chlbxAgentes = new Controles.CNDCListBox();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(18, 7);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(89, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Registro de Falla:";
            // 
            // _cmbRegistrosFalla
            // 
            this._cmbRegistrosFalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRegistrosFalla.EnterComoTab = false;
            this._cmbRegistrosFalla.Etiqueta = null;
            this._cmbRegistrosFalla.FormattingEnabled = true;
            this._cmbRegistrosFalla.Location = new System.Drawing.Point(113, 4);
            this._cmbRegistrosFalla.Name = "_cmbRegistrosFalla";
            this._cmbRegistrosFalla.Size = new System.Drawing.Size(121, 21);
            this._cmbRegistrosFalla.TabIndex = 1;
            this._cmbRegistrosFalla.TablaCampoBD = null;
            this._cmbRegistrosFalla.SelectedIndexChanged += new System.EventHandler(this._cmbRegistrosFalla_SelectedIndexChanged);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(18, 39);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(113, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Agentes Involucrados:";
            // 
            // _btnDecargar
            // 
            this._btnDecargar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnDecargar.Location = new System.Drawing.Point(83, 195);
            this._btnDecargar.Name = "_btnDecargar";
            this._btnDecargar.Size = new System.Drawing.Size(75, 23);
            this._btnDecargar.TabIndex = 4;
            this._btnDecargar.TablaCampoBD = null;
            this._btnDecargar.Text = "Descargar";
            this._btnDecargar.UseVisualStyleBackColor = true;
            this._btnDecargar.Click += new System.EventHandler(this._btnDecargar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancelar.Location = new System.Drawing.Point(169, 195);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 5;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            //this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _chlbxAgentes
            // 
            this._chlbxAgentes.FormattingEnabled = true;
            this._chlbxAgentes.Location = new System.Drawing.Point(21, 55);
            this._chlbxAgentes.Name = "_chlbxAgentes";
            this._chlbxAgentes.Size = new System.Drawing.Size(222, 134);
            this._chlbxAgentes.TabIndex = 7;
            this._chlbxAgentes.TablaCampoBD = null;
            // 
            // FormDescargaInfFalla
            // 
            this.AcceptButton = this._btnDecargar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this._chlbxAgentes);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnDecargar);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._cmbRegistrosFalla);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormDescargaInfFalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarga de Informes de Falla";
            this.Load += new System.EventHandler(this.FormDescargaInfFalla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cmbRegistrosFalla;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCButton _btnDecargar;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCListBox _chlbxAgentes;
    }
}