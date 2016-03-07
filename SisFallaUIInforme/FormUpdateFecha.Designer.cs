using System;

namespace SISFALLA
{
    partial class FormUpdateFecha
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
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this._txtFechaHoraFalla = new Controles.CNDCTextBoxDateTime();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fecha.Location = new System.Drawing.Point(59, 12);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(200, 20);
            this.dtp_fecha.TabIndex = 0;
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Location = new System.Drawing.Point(13, 15);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(40, 13);
            this.lbl_fecha.TabIndex = 1;
            this.lbl_fecha.Text = "Fecha:";
            // 
            // btn_grabar
            // 
            this.btn_grabar.Location = new System.Drawing.Point(95, 82);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(75, 23);
            this.btn_grabar.TabIndex = 2;
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(197, 83);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // _txtFechaHoraFalla
            // 
            this._txtFechaHoraFalla.Etiqueta = null;
            this._txtFechaHoraFalla.Font = new System.Drawing.Font("Arial", 9F);
            this._txtFechaHoraFalla.Location = new System.Drawing.Point(59, 39);
            this._txtFechaHoraFalla.Mask = "00/00/0000 00:00:00";
            this._txtFechaHoraFalla.Name = "_txtFechaHoraFalla";
            this._txtFechaHoraFalla.Size = new System.Drawing.Size(199, 21);
            this._txtFechaHoraFalla.TabIndex = 4;
            this._txtFechaHoraFalla.TablaCampoBD = "F_GF_REGFALLA.FEC_INICIO";
            this._txtFechaHoraFalla.Tag = "dd/mm/yyyy hh:mi:ss";
            this._txtFechaHoraFalla.Text = "01/01/0001-00:00:00";
            this._txtFechaHoraFalla.ValidadorFormatoFecha = null;
            this._txtFechaHoraFalla.ValidadorIngresoOnline = null;
            this._txtFechaHoraFalla.Value = new System.DateTime(((long)(0)));
            this._txtFechaHoraFalla.Visible = false;
            this._txtFechaHoraFalla.TextChanged += new System.EventHandler(this._txtFechaHoraFalla_TextChanged);
            this._txtFechaHoraFalla.Validating += new System.ComponentModel.CancelEventHandler(this._txtFechaHoraFalla_Validating);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(60, 66);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 5;
            // 
            // FormUpdateFecha
            // 
            this.AcceptButton = this.btn_grabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this._txtFechaHoraFalla);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.dtp_fecha);
            this.Name = "FormUpdateFecha";
            this.Text = "Actualizar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Button btn_grabar;
        private System.Windows.Forms.Button btn_cancel;

        private DateTime fecha;
        private long regFalla;
        private Controles.CNDCTextBoxDateTime _txtFechaHoraFalla;

        protected System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Label lblError;
    }
}