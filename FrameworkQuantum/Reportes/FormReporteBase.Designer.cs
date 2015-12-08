namespace Reportes
{
    partial class FormReporteBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteBase));
            this.panel1 = new System.Windows.Forms.Panel();
            this._crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._ImprimirDirecto = new System.Windows.Forms.ToolStripButton();
            this._btnExportarPdf = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnExportarXls = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnExportarCSV = new System.Windows.Forms.ToolStripButton();
            this._separadorAnalisis = new System.Windows.Forms.ToolStripSeparator();
            this._btnCerrar = new System.Windows.Forms.ToolStripButton();
            this._btnParametros = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._crViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 276);
            this.panel1.TabIndex = 4;
            // 
            // _crViewer
            // 
            this._crViewer.ActiveViewIndex = -1;
            this._crViewer.AutoScroll = true;
            this._crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this._crViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._crViewer.Location = new System.Drawing.Point(0, 0);
            this._crViewer.Name = "crystalReportViewer1";
            this._crViewer.Size = new System.Drawing.Size(747, 276);
            this._crViewer.TabIndex = 0;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ImprimirDirecto,
            this._btnExportarPdf,
            this.toolStripSeparator1,
            this._btnExportarXls,
            this.toolStripSeparator2,
            this._btnExportarCSV,
            this._separadorAnalisis,
            this._btnCerrar,
            this._btnParametros});
            this._toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(747, 25);
            this._toolStrip.TabIndex = 3;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _ImprimirDirecto
            // 
            this._ImprimirDirecto.Image = ((System.Drawing.Image)(resources.GetObject("_ImprimirDirecto.Image")));
            this._ImprimirDirecto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ImprimirDirecto.Name = "_ImprimirDirecto";
            this._ImprimirDirecto.Size = new System.Drawing.Size(73, 22);
            this._ImprimirDirecto.Text = "Imprimir";
            this._ImprimirDirecto.Click += new System.EventHandler(this._ImprimirDirecto_Click);
            // 
            // _btnExportarPdf
            // 
            this._btnExportarPdf.Image = global::Reportes.Properties.Resources.pdf;
            this._btnExportarPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnExportarPdf.Name = "_btnExportarPdf";
            this._btnExportarPdf.Size = new System.Drawing.Size(94, 22);
            this._btnExportarPdf.Text = "Exportar PDF";
            this._btnExportarPdf.Click += new System.EventHandler(this._btnExportarPdf_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnExportarXls
            // 
            this._btnExportarXls.Image = global::Reportes.Properties.Resources.xls;
            this._btnExportarXls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnExportarXls.Name = "_btnExportarXls";
            this._btnExportarXls.Size = new System.Drawing.Size(99, 22);
            this._btnExportarXls.Text = "Exportar Excel";
            this._btnExportarXls.ToolTipText = "Exportar Excel con Formato y Estilos";
            this._btnExportarXls.Click += new System.EventHandler(this._btnExportarXls_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnExportarCSV
            // 
            this._btnExportarCSV.Image = global::Reportes.Properties.Resources.xls;
            this._btnExportarCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnExportarCSV.Name = "_btnExportarCSV";
            this._btnExportarCSV.Size = new System.Drawing.Size(94, 22);
            this._btnExportarCSV.Text = "Exportar CSV";
            this._btnExportarCSV.ToolTipText = "Exportar CSV - sin Formato";
            this._btnExportarCSV.Click += new System.EventHandler(this._btnExportarCSV_Click);
            // 
            // _separadorAnalisis
            // 
            this._separadorAnalisis.Name = "_separadorAnalisis";
            this._separadorAnalisis.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnCerrar
            // 
            this._btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._btnCerrar.Image = global::Reportes.Properties.Resources.cancel;
            this._btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(103, 22);
            this._btnCerrar.Text = "Cerrar Reporte";
            this._btnCerrar.Click += new System.EventHandler(this._btnCerrar_Click);
            // 
            // _btnParametros
            // 
            this._btnParametros.Image = global::Reportes.Properties.Resources.parametros;
            this._btnParametros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnParametros.Name = "_btnParametros";
            this._btnParametros.Size = new System.Drawing.Size(87, 22);
            this._btnParametros.Text = "Parametros";
            this._btnParametros.Click += new System.EventHandler(this._btnParametros_Click);
            // 
            // FormReporteBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 301);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._toolStrip);
            this.Name = "FormReporteBase";
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _ImprimirDirecto;
        private System.Windows.Forms.ToolStripButton _btnExportarPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btnExportarXls;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _btnExportarCSV;
        private System.Windows.Forms.ToolStripSeparator _separadorAnalisis;
        private System.Windows.Forms.ToolStripButton _btnCerrar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _crViewer;
        private System.Windows.Forms.ToolStripButton _btnParametros;
        //private repSisfalla.CachedplantillaReporte cachedplantillaReporte1;
    }
}