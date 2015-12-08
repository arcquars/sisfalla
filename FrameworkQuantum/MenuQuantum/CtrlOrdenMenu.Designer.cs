namespace MenuQuantum
{
    partial class CtrlOrdenMenu
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnSubir = new System.Windows.Forms.ToolStripButton();
            this._btnBajar = new System.Windows.Forms.ToolStripButton();
            this._tvwMenu = new Controles.CNDCTreeView();
            this._lbxOpciones = new Controles.CNDCListBox();
            this.cndcPanelControl1.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cndcPanelControl1.Controls.Add(this.cndcToolStrip1);
            this.cndcPanelControl1.Location = new System.Drawing.Point(370, 1);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(296, 25);
            this.cndcPanelControl1.TabIndex = 5;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this._btnCancelar,
            this._btnSubir,
            this._btnBajar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(296, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnGuardar
            // 
            this._btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnGuardar.Image = global::MenuQuantum.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(23, 22);
            this._btnGuardar.Text = "toolStripButton1";
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnCancelar.Image = global::MenuQuantum.Properties.Resources.Clear;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(23, 22);
            this._btnCancelar.Text = "toolStripButton2";
            // 
            // _btnSubir
            // 
            this._btnSubir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnSubir.Image = global::MenuQuantum.Properties.Resources.subir;
            this._btnSubir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSubir.Name = "_btnSubir";
            this._btnSubir.Size = new System.Drawing.Size(23, 22);
            this._btnSubir.Text = "toolStripButton3";
            this._btnSubir.Click += new System.EventHandler(this._btnSubir_Click);
            // 
            // _btnBajar
            // 
            this._btnBajar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnBajar.Image = global::MenuQuantum.Properties.Resources.bajar;
            this._btnBajar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnBajar.Name = "_btnBajar";
            this._btnBajar.Size = new System.Drawing.Size(23, 22);
            this._btnBajar.Text = "toolStripButton4";
            this._btnBajar.Click += new System.EventHandler(this._btnBajar_Click);
            // 
            // _tvwMenu
            // 
            this._tvwMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._tvwMenu.Location = new System.Drawing.Point(0, 29);
            this._tvwMenu.Name = "_tvwMenu";
            this._tvwMenu.Size = new System.Drawing.Size(365, 342);
            this._tvwMenu.TabIndex = 4;
            this._tvwMenu.TablaCampoBD = null;
            this._tvwMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvwMenu_AfterSelect);
            // 
            // _lbxOpciones
            // 
            this._lbxOpciones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._lbxOpciones.FormattingEnabled = true;
            this._lbxOpciones.Location = new System.Drawing.Point(368, 29);
            this._lbxOpciones.Name = "_lbxOpciones";
            this._lbxOpciones.Size = new System.Drawing.Size(302, 342);
            this._lbxOpciones.TabIndex = 3;
            this._lbxOpciones.TablaCampoBD = null;
            // 
            // CtrlOrdenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this._tvwMenu);
            this.Controls.Add(this._lbxOpciones);
            this.Name = "CtrlOrdenMenu";
            this.Size = new System.Drawing.Size(675, 375);
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnSubir;
        private System.Windows.Forms.ToolStripButton _btnBajar;
        private Controles.CNDCTreeView _tvwMenu;
        private Controles.CNDCListBox _lbxOpciones;
    }
}
