namespace ComponentesUI
{
    partial class FormBajaComponente
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
            this._cndcLBComponentes = new Controles.CNDCListBox();
            this._cndcLBParaBaja = new Controles.CNDCListBox();
            this.SuspendLayout();
            // 
            // _cndcLBComponentes
            // 
            this._cndcLBComponentes.FormattingEnabled = true;
            this._cndcLBComponentes.Location = new System.Drawing.Point(2, 1);
            this._cndcLBComponentes.Name = "_cndcLBComponentes";
            this._cndcLBComponentes.Size = new System.Drawing.Size(182, 225);
            this._cndcLBComponentes.TabIndex = 0;
            this._cndcLBComponentes.TablaCampoBD = null;
            // 
            // _cndcLBParaBaja
            // 
            this._cndcLBParaBaja.FormattingEnabled = true;
            this._cndcLBParaBaja.Location = new System.Drawing.Point(280, 4);
            this._cndcLBParaBaja.Name = "_cndcLBParaBaja";
            this._cndcLBParaBaja.Size = new System.Drawing.Size(189, 225);
            this._cndcLBParaBaja.TabIndex = 1;
            this._cndcLBParaBaja.TablaCampoBD = null;
            // 
            // FormBajaComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 361);
            this.Controls.Add(this._cndcLBParaBaja);
            this.Controls.Add(this._cndcLBComponentes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormBajaComponente";
            this.Text = "FormBajaComponente";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCListBox _cndcLBComponentes;
        private Controles.CNDCListBox _cndcLBParaBaja;

    }
}