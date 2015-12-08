namespace ComponentesUI
{
    partial class FormNuevoComponente
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
            this.label1 = new System.Windows.Forms.Label();
            this._cmbTipoComponente = new System.Windows.Forms.ComboBox();
            this._ctrlDatosGenerales = new ComponentesUI.CtrlDatosGenerales();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Componente";
            // 
            // _cmbTipoComponente
            // 
            this._cmbTipoComponente.FormattingEnabled = true;
            this._cmbTipoComponente.Location = new System.Drawing.Point(340, 16);
            this._cmbTipoComponente.Name = "_cmbTipoComponente";
            this._cmbTipoComponente.Size = new System.Drawing.Size(121, 21);
            this._cmbTipoComponente.TabIndex = 2;
            this._cmbTipoComponente.SelectedIndexChanged += new System.EventHandler(this._cmbTipoComponente_SelectedIndexChanged);
            // 
            // _ctrlDatosGenerales
            // 
            this._ctrlDatosGenerales.Location = new System.Drawing.Point(2, 1);
            this._ctrlDatosGenerales.Name = "_ctrlDatosGenerales";
            this._ctrlDatosGenerales.Size = new System.Drawing.Size(478, 186);
            this._ctrlDatosGenerales.TabIndex = 0;
            this._ctrlDatosGenerales.AccionEjecutada += new System.EventHandler<ComponentesUI.AccionEjecutadaEventArgs>(this._ctrlDatosGenerales_AccionEjecutada);
            // 
            // FormNuevoComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 191);
            this.Controls.Add(this._cmbTipoComponente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._ctrlDatosGenerales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormNuevoComponente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNuevoComponente";
            this.Load += new System.EventHandler(this.FormNuevoComponente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlDatosGenerales _ctrlDatosGenerales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cmbTipoComponente;
    }
}