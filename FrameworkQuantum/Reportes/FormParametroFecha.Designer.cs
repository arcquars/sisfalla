namespace Reportes
{
    partial class FormParametroFecha
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
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._cbxFechasVigentes = new Controles.CNDCComboBox();
            this._lbldemo = new Controles.CNDCLabel();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnAceptar = new System.Windows.Forms.Button();
            this.cndcGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._cbxFechasVigentes);
            this.cndcGroupBox2.Controls.Add(this._lbldemo);
            this.cndcGroupBox2.Location = new System.Drawing.Point(28, 38);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(274, 55);
            this.cndcGroupBox2.TabIndex = 18;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Seleccionar la fecha ";
            // 
            // _cbxFechasVigentes
            // 
            this._cbxFechasVigentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxFechasVigentes.EnterComoTab = false;
            this._cbxFechasVigentes.Etiqueta = null;
            this._cbxFechasVigentes.FormattingEnabled = true;
            this._cbxFechasVigentes.Location = new System.Drawing.Point(142, 20);
            this._cbxFechasVigentes.Name = "_cbxFechasVigentes";
            this._cbxFechasVigentes.Size = new System.Drawing.Size(103, 21);
            this._cbxFechasVigentes.TabIndex = 9;
            this._cbxFechasVigentes.TablaCampoBD = null;
            // 
            // _lbldemo
            // 
            this._lbldemo.AutoSize = true;
            this._lbldemo.Location = new System.Drawing.Point(28, 24);
            this._lbldemo.Name = "_lbldemo";
            this._lbldemo.Size = new System.Drawing.Size(102, 13);
            this._lbldemo.TabIndex = 8;
            this._lbldemo.TablaCampoBD = null;
            this._lbldemo.Text = "Fecha de Consulta :";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Location = new System.Drawing.Point(170, 116);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 29);
            this._btnCancelar.TabIndex = 20;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(59, 116);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(84, 29);
            this._btnAceptar.TabIndex = 19;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // FormParametroFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 182);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this.cndcGroupBox2);
            this.Name = "FormParametroFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParametroFecha";
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCLabel _lbldemo;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnAceptar;
        private Controles.CNDCComboBox _cbxFechasVigentes;
    }
}