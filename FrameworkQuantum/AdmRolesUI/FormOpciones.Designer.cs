namespace AdmRolesUI
{
    partial class FormOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpciones));
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._lbxModulosDisp = new Controles.CNDCListBox();
            this._btnAdicionar = new Controles.CNDCButton();
            this._btnQuitar = new Controles.CNDCButton();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._lbxModulosAsig = new Controles.CNDCListBox();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._tvwOpciones = new Controles.CNDCTreeView();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnExpandir = new System.Windows.Forms.ToolStripButton();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this.cndcToolStrip2 = new Controles.CNDCToolStrip();
            this._btnGuardarPrioridad = new System.Windows.Forms.ToolStripButton();
            this._btnSubir = new System.Windows.Forms.ToolStripButton();
            this._btnBajar = new System.Windows.Forms.ToolStripButton();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.cndcPanelControl1.SuspendLayout();
            this.cndcToolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(9, 12);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(107, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Módulos Disponibles:";
            // 
            // _lbxModulosDisp
            // 
            this._lbxModulosDisp.FormattingEnabled = true;
            this._lbxModulosDisp.Location = new System.Drawing.Point(12, 28);
            this._lbxModulosDisp.Name = "_lbxModulosDisp";
            this._lbxModulosDisp.Size = new System.Drawing.Size(180, 173);
            this._lbxModulosDisp.TabIndex = 1;
            this._lbxModulosDisp.TablaCampoBD = null;
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.Location = new System.Drawing.Point(203, 77);
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this._btnAdicionar.TabIndex = 2;
            this._btnAdicionar.TablaCampoBD = null;
            this._btnAdicionar.Text = "Adicionar";
            this._btnAdicionar.UseVisualStyleBackColor = true;
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _btnQuitar
            // 
            this._btnQuitar.Location = new System.Drawing.Point(203, 106);
            this._btnQuitar.Name = "_btnQuitar";
            this._btnQuitar.Size = new System.Drawing.Size(75, 23);
            this._btnQuitar.TabIndex = 3;
            this._btnQuitar.TablaCampoBD = null;
            this._btnQuitar.Text = "Quitar";
            this._btnQuitar.UseVisualStyleBackColor = true;
            this._btnQuitar.Click += new System.EventHandler(this._btnQuitar_Click);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(281, 12);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(102, 13);
            this.cndcLabel2.TabIndex = 4;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Módulos Asignados:";
            // 
            // _lbxModulosAsig
            // 
            this._lbxModulosAsig.FormattingEnabled = true;
            this._lbxModulosAsig.Location = new System.Drawing.Point(284, 28);
            this._lbxModulosAsig.Name = "_lbxModulosAsig";
            this._lbxModulosAsig.Size = new System.Drawing.Size(180, 173);
            this._lbxModulosAsig.TabIndex = 5;
            this._lbxModulosAsig.TablaCampoBD = null;
            this._lbxModulosAsig.SelectedIndexChanged += new System.EventHandler(this._lbxModulosAsig_SelectedIndexChanged);
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cndcGroupBox1.Controls.Add(this._tvwOpciones);
            this.cndcGroupBox1.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox1.Location = new System.Drawing.Point(481, 3);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(395, 374);
            this.cndcGroupBox1.TabIndex = 6;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            // 
            // _tvwOpciones
            // 
            this._tvwOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tvwOpciones.CheckBoxes = true;
            this._tvwOpciones.Location = new System.Drawing.Point(7, 44);
            this._tvwOpciones.Name = "_tvwOpciones";
            this._tvwOpciones.Size = new System.Drawing.Size(383, 324);
            this._tvwOpciones.TabIndex = 1;
            this._tvwOpciones.TablaCampoBD = null;
            this._tvwOpciones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._tvwOpciones_AfterCheck);
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this._btnCancelar,
            this._btnExpandir});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(389, 25);
            this.cndcToolStrip1.TabIndex = 0;
            this.cndcToolStrip1.TablaCampoBD = null;
            this.cndcToolStrip1.Text = "cndcToolStrip1";
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Image = global::AdmRolesUI.Properties.Resources.save;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(66, 22);
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this._btnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Image = global::AdmRolesUI.Properties.Resources.Delete;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(69, 22);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
            // 
            // _btnExpandir
            // 
            this._btnExpandir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnExpandir.Image = ((System.Drawing.Image)(resources.GetObject("_btnExpandir.Image")));
            this._btnExpandir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnExpandir.Name = "_btnExpandir";
            this._btnExpandir.Size = new System.Drawing.Size(69, 22);
            this._btnExpandir.Text = "Expandir";
            this._btnExpandir.Click += new System.EventHandler(this._btnExpandir_Click);
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Controls.Add(this.cndcToolStrip2);
            this.cndcPanelControl1.Location = new System.Drawing.Point(381, 3);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(83, 25);
            this.cndcPanelControl1.TabIndex = 9;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // cndcToolStrip2
            // 
            this.cndcToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardarPrioridad,
            this._btnSubir,
            this._btnBajar});
            this.cndcToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.cndcToolStrip2.Name = "cndcToolStrip2";
            this.cndcToolStrip2.Size = new System.Drawing.Size(83, 25);
            this.cndcToolStrip2.TabIndex = 0;
            this.cndcToolStrip2.TablaCampoBD = null;
            this.cndcToolStrip2.Text = "cndcToolStrip2";
            // 
            // _btnGuardarPrioridad
            // 
            this._btnGuardarPrioridad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnGuardarPrioridad.Image = global::AdmRolesUI.Properties.Resources.save;
            this._btnGuardarPrioridad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardarPrioridad.Name = "_btnGuardarPrioridad";
            this._btnGuardarPrioridad.Size = new System.Drawing.Size(23, 22);
            this._btnGuardarPrioridad.Click += new System.EventHandler(this._btnGuardarPrioridad_Click);
            // 
            // _btnSubir
            // 
            this._btnSubir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnSubir.Image = global::AdmRolesUI.Properties.Resources.subir;
            this._btnSubir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSubir.Name = "_btnSubir";
            this._btnSubir.Size = new System.Drawing.Size(23, 22);
            this._btnSubir.Click += new System.EventHandler(this._btnSubir_Click);
            // 
            // _btnBajar
            // 
            this._btnBajar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnBajar.Image = global::AdmRolesUI.Properties.Resources.bajar;
            this._btnBajar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnBajar.Name = "_btnBajar";
            this._btnBajar.Size = new System.Drawing.Size(23, 20);
            this._btnBajar.Click += new System.EventHandler(this._btnBajar_Click);
            // 
            // FormOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 378);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._lbxModulosAsig);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._btnQuitar);
            this.Controls.Add(this._btnAdicionar);
            this.Controls.Add(this._lbxModulosDisp);
            this.Controls.Add(this.cndcLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de opciones a roles";
            this.Load += new System.EventHandler(this.FormOpciones_Load);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.cndcToolStrip2.ResumeLayout(false);
            this.cndcToolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCListBox _lbxModulosDisp;
        private Controles.CNDCButton _btnAdicionar;
        private Controles.CNDCButton _btnQuitar;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCListBox _lbxModulosAsig;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCTreeView _tvwOpciones;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnExpandir;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCToolStrip cndcToolStrip2;
        private System.Windows.Forms.ToolStripButton _btnGuardarPrioridad;
        private System.Windows.Forms.ToolStripButton _btnSubir;
        private System.Windows.Forms.ToolStripButton _btnBajar;
    }
}