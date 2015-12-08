namespace SisFallaUIInforme
{
    partial class FormModificarSupervisor
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
            this.cndcLabelCombo1 = new Controles.CNDCLabelCombo();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnCancel = new Controles.CNDCButton();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._lblInforme = new Controles.CNDCLabel();
            this.SuspendLayout();
            // 
            // cndcLabelCombo1
            // 
            this.cndcLabelCombo1.LabelText = "Supervisor:";
            this.cndcLabelCombo1.Location = new System.Drawing.Point(28, 33);
            this.cndcLabelCombo1.Name = "cndcLabelCombo1";
            this.cndcLabelCombo1.Size = new System.Drawing.Size(268, 34);
            this.cndcLabelCombo1.TabIndex = 0;
            this.cndcLabelCombo1.TablaCampoBD = null;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(177, 95);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(95, 25);
            this._btnAceptar.TabIndex = 1;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(278, 95);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(95, 25);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.TablaCampoBD = null;
            this._btnCancel.Text = "Cancelar";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(40, 17);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(85, 13);
            this.cndcLabel1.TabIndex = 3;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Informe de Falla:";
            // 
            // _lblInforme
            // 
            this._lblInforme.AutoSize = true;
            this._lblInforme.Location = new System.Drawing.Point(166, 17);
            this._lblInforme.Name = "_lblInforme";
            this._lblInforme.Size = new System.Drawing.Size(63, 13);
            this._lblInforme.TabIndex = 4;
            this._lblInforme.TablaCampoBD = null;
            this._lblInforme.Text = "cndcLabel2";
            // 
            // FormModificarSupervisor
            // 
            this.AcceptButton = this._btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 134);
            this.Controls.Add(this._lblInforme);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this.cndcLabelCombo1);
            this.Name = "FormModificarSupervisor";
            this.Text = "Modificación de Supervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabelCombo cndcLabelCombo1;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnCancel;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel _lblInforme;
    }
}