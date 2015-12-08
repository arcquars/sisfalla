namespace ComponentesUI
{
    partial class CtrlBaseComponente
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
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._tSBGuardar = new System.Windows.Forms.ToolStripButton();
            this._tSBEditar = new System.Windows.Forms.ToolStripButton();
            this._tSBCancelar = new System.Windows.Forms.ToolStripButton();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tSBGuardar,
            this._tSBEditar,
            this._tSBCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(9, 10);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(211, 25);
            this.cndcToolStrip1.TabIndex = 2;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _tSBGuardar
            // 
            this._tSBGuardar.Enabled = false;
            this._tSBGuardar.Image = global::ComponentesUI.Properties.Resources.save;
            this._tSBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBGuardar.Name = "_tSBGuardar";
            this._tSBGuardar.Size = new System.Drawing.Size(69, 22);
            this._tSBGuardar.Text = "Guardar";
            this._tSBGuardar.Click += new System.EventHandler(this._tSBGuardar_Click);
            // 
            // _tSBEditar
            // 
            this._tSBEditar.Image = global::ComponentesUI.Properties.Resources.Edit;
            this._tSBEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBEditar.Name = "_tSBEditar";
            this._tSBEditar.Size = new System.Drawing.Size(57, 22);
            this._tSBEditar.Text = "Editar";
            this._tSBEditar.Click += new System.EventHandler(this._tSBEditar_Click);
            // 
            // _tSBCancelar
            // 
            this._tSBCancelar.Enabled = false;
            this._tSBCancelar.Image = global::ComponentesUI.Properties.Resources.cancel;
            this._tSBCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBCancelar.Name = "_tSBCancelar";
            this._tSBCancelar.Size = new System.Drawing.Size(73, 22);
            this._tSBCancelar.Text = "Cancelar";
            this._tSBCancelar.Click += new System.EventHandler(this._tSBCancelar_Click);
            // 
            // CtrlBaseComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcToolStrip1);
            this.Name = "CtrlBaseComponente";
            this.Size = new System.Drawing.Size(489, 354);
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton _tSBGuardar;
        private System.Windows.Forms.ToolStripButton _tSBCancelar;
        public System.Windows.Forms.ToolStripButton _tSBEditar;
        public Controles.CNDCToolStrip cndcToolStrip1;
    }
}