﻿namespace CNDC.BaseForms
{
    partial class AdvancedConfigFilterForm
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
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._statusStrip.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblMessage});
            this._statusStrip.Location = new System.Drawing.Point(0, 246);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(579, 22);
            this._statusStrip.TabIndex = 4;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _lblMessage
            // 
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(58, 17);
            this._lblMessage.Text = "Messages";
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this._btnCancelar});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(579, 25);
            this._toolStrip.TabIndex = 3;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Image = global::CNDC.BaseForms.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(69, 22);
            this._btnGuardar.Text = "Guardar";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::CNDC.BaseForms.Properties.Resources.cancel;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(73, 22);
            this._btnCancelar.Text = "Cancelar";
            // 
            // AdvancedConfigFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 268);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._toolStrip);
            this.Name = "AdvancedConfigFilterForm";
            this.Text = "AdvancedConfigFilterForm";
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _lblMessage;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
    }
}