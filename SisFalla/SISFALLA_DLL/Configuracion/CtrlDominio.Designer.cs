namespace SISFALLA
{
    partial class CtrlDominio
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._cbxCategorias = new Controles.CNDCComboBox();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.ctrlDominios3 = new SISFALLA.CtrlDominios();
            this._tStripInformeFalla = new Controles.CNDCToolStrip();
            this._tbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this._tbtnCancelar = new System.Windows.Forms.ToolStripButton();
            this.cndcPanelControl1.SuspendLayout();
            this._tStripInformeFalla.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabel1.Location = new System.Drawing.Point(61, 41);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(85, 15);
            this.cndcLabel1.TabIndex = 9;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Elegir categoría :";
            // 
            // _cbxCategorias
            // 
            this._cbxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxCategorias.EnterComoTab = false;
            this._cbxCategorias.Etiqueta = null;
            this._cbxCategorias.FormattingEnabled = true;
            this._cbxCategorias.Location = new System.Drawing.Point(184, 41);
            this._cbxCategorias.Name = "_cbxCategorias";
            this._cbxCategorias.Size = new System.Drawing.Size(357, 21);
            this._cbxCategorias.TabIndex = 8;
            this._cbxCategorias.TablaCampoBD = null;
            this._cbxCategorias.SelectedIndexChanged += new System.EventHandler(this._cbxCategorias_SelectedIndexChanged);
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this.ctrlDominios3);
            this.cndcPanelControl1.Location = new System.Drawing.Point(3, 68);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(820, 244);
            this.cndcPanelControl1.TabIndex = 10;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // ctrlDominios3
            // 
            this.ctrlDominios3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlDominios3.Location = new System.Drawing.Point(7, 12);
            this.ctrlDominios3.MaximumSize = new System.Drawing.Size(800, 220);
            this.ctrlDominios3.MinimumSize = new System.Drawing.Size(800, 220);
            this.ctrlDominios3.Name = "ctrlDominios3";
            this.ctrlDominios3.PanelToolVisible = true;
            this.ctrlDominios3.Size = new System.Drawing.Size(800, 220);
            this.ctrlDominios3.TabIndex = 0;
            // 
            // _tStripInformeFalla
            // 
            this._tStripInformeFalla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tbtnGuardar,
            this._tbtnCancelar});
            this._tStripInformeFalla.Location = new System.Drawing.Point(0, 0);
            this._tStripInformeFalla.Name = "_tStripInformeFalla";
            this._tStripInformeFalla.Size = new System.Drawing.Size(830, 25);
            this._tStripInformeFalla.TabIndex = 11;
            this._tStripInformeFalla.TablaCampoBD = null;
            this._tStripInformeFalla.Text = "cndcToolStrip1";
            // 
            // _tbtnGuardar
            // 
            this._tbtnGuardar.Image = global::SISFALLA.Properties.Resources.save;
            this._tbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnGuardar.Name = "_tbtnGuardar";
            this._tbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this._tbtnGuardar.Text = "Guardar";
            this._tbtnGuardar.Click += new System.EventHandler(this._tbtnGuardar_Click);
            // 
            // _tbtnCancelar
            // 
            this._tbtnCancelar.Image = global::SISFALLA.Properties.Resources.Delete;
            this._tbtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbtnCancelar.Name = "_tbtnCancelar";
            this._tbtnCancelar.Size = new System.Drawing.Size(73, 22);
            this._tbtnCancelar.Text = "Cancelar";
            // 
            // CtrlDominio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tStripInformeFalla);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._cbxCategorias);
            this.Controls.Add(this.cndcPanelControl1);
            this.Name = "CtrlDominio";
            this.Size = new System.Drawing.Size(830, 324);
            this.cndcPanelControl1.ResumeLayout(false);
            this._tStripInformeFalla.ResumeLayout(false);
            this._tStripInformeFalla.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cbxCategorias;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private CtrlDominios ctrlDominios3;
        private Controles.CNDCToolStrip _tStripInformeFalla;
        private System.Windows.Forms.ToolStripButton _tbtnGuardar;
        private System.Windows.Forms.ToolStripButton _tbtnCancelar;
    }
}
