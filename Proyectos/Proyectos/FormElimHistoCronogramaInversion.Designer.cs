namespace Proyectos
{
    partial class FormElimHistoCronogramaInversion
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
            this._chlbxHistoricos = new Controles.CNDCCheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnEliminarHistorico = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _chlbxHistoricos
            // 
            this._chlbxHistoricos.CheckOnClick = true;
            this._chlbxHistoricos.FormattingEnabled = true;
            this._chlbxHistoricos.Location = new System.Drawing.Point(12, 37);
            this._chlbxHistoricos.Name = "_chlbxHistoricos";
            this._chlbxHistoricos.Size = new System.Drawing.Size(194, 139);
            this._chlbxHistoricos.TabIndex = 0;
            this._chlbxHistoricos.TablaCampoBD = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnEliminarHistorico,
            this._btnCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(215, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btnEliminarHistorico
            // 
            this._btnEliminarHistorico.Image = global::Proyectos.Properties.Resources.cancel;
            this._btnEliminarHistorico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEliminarHistorico.Name = "_btnEliminarHistorico";
            this._btnEliminarHistorico.Size = new System.Drawing.Size(63, 22);
            this._btnEliminarHistorico.Text = "Eliminar";
            this._btnEliminarHistorico.Click += new System.EventHandler(this._btnEliminarHistorico_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::Proyectos.Properties.Resources.Delete;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // FormElimHistoCronogramaInversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 188);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._chlbxHistoricos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormElimHistoCronogramaInversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Historico";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCCheckedListBox _chlbxHistoricos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnEliminarHistorico;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
    }
}