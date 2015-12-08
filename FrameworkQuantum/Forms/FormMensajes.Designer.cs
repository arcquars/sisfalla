namespace CNDC.BaseForms
{
    partial class FormMensajes
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
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnSi = new Controles.CNDCButton();
            this._btnAbortar = new Controles.CNDCButton();
            this._btnReintentar = new Controles.CNDCButton();
            this._btnIgnorar = new Controles.CNDCButton();
            this._btnNo = new Controles.CNDCButton();
            this._btnCacnelar = new Controles.CNDCButton();
            this.cndcPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cndcPanelControl1.Controls.Add(this._btnAceptar);
            this.cndcPanelControl1.Controls.Add(this._btnSi);
            this.cndcPanelControl1.Controls.Add(this._btnAbortar);
            this.cndcPanelControl1.Controls.Add(this._btnReintentar);
            this.cndcPanelControl1.Controls.Add(this._btnIgnorar);
            this.cndcPanelControl1.Controls.Add(this._btnNo);
            this.cndcPanelControl1.Controls.Add(this._btnCacnelar);
            this.cndcPanelControl1.Location = new System.Drawing.Point(12, 242);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(530, 25);
            this.cndcPanelControl1.TabIndex = 0;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnAceptar.Location = new System.Drawing.Point(5, 0);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(75, 25);
            this._btnAceptar.TabIndex = 6;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Visible = false;
            this._btnAceptar.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnSi
            // 
            this._btnSi.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnSi.Location = new System.Drawing.Point(80, 0);
            this._btnSi.Name = "_btnSi";
            this._btnSi.Size = new System.Drawing.Size(75, 25);
            this._btnSi.TabIndex = 5;
            this._btnSi.TablaCampoBD = null;
            this._btnSi.Text = "Si";
            this._btnSi.UseVisualStyleBackColor = true;
            this._btnSi.Visible = false;
            this._btnSi.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnAbortar
            // 
            this._btnAbortar.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnAbortar.Location = new System.Drawing.Point(155, 0);
            this._btnAbortar.Name = "_btnAbortar";
            this._btnAbortar.Size = new System.Drawing.Size(75, 25);
            this._btnAbortar.TabIndex = 4;
            this._btnAbortar.TablaCampoBD = null;
            this._btnAbortar.Text = "Abortar";
            this._btnAbortar.UseVisualStyleBackColor = true;
            this._btnAbortar.Visible = false;
            this._btnAbortar.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnReintentar
            // 
            this._btnReintentar.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnReintentar.Location = new System.Drawing.Point(230, 0);
            this._btnReintentar.Name = "_btnReintentar";
            this._btnReintentar.Size = new System.Drawing.Size(75, 25);
            this._btnReintentar.TabIndex = 3;
            this._btnReintentar.TablaCampoBD = null;
            this._btnReintentar.Text = "Reintentar";
            this._btnReintentar.UseVisualStyleBackColor = true;
            this._btnReintentar.Visible = false;
            this._btnReintentar.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnIgnorar
            // 
            this._btnIgnorar.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnIgnorar.Location = new System.Drawing.Point(305, 0);
            this._btnIgnorar.Name = "_btnIgnorar";
            this._btnIgnorar.Size = new System.Drawing.Size(75, 25);
            this._btnIgnorar.TabIndex = 2;
            this._btnIgnorar.TablaCampoBD = null;
            this._btnIgnorar.Text = "Ignorar";
            this._btnIgnorar.UseVisualStyleBackColor = true;
            this._btnIgnorar.Visible = false;
            this._btnIgnorar.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnNo
            // 
            this._btnNo.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnNo.Location = new System.Drawing.Point(380, 0);
            this._btnNo.Name = "_btnNo";
            this._btnNo.Size = new System.Drawing.Size(75, 25);
            this._btnNo.TabIndex = 1;
            this._btnNo.TablaCampoBD = null;
            this._btnNo.Text = "No";
            this._btnNo.UseVisualStyleBackColor = true;
            this._btnNo.Visible = false;
            this._btnNo.Click += new System.EventHandler(this._btn_Click);
            // 
            // _btnCacnelar
            // 
            this._btnCacnelar.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnCacnelar.Location = new System.Drawing.Point(455, 0);
            this._btnCacnelar.Name = "_btnCacnelar";
            this._btnCacnelar.Size = new System.Drawing.Size(75, 25);
            this._btnCacnelar.TabIndex = 0;
            this._btnCacnelar.TablaCampoBD = null;
            this._btnCacnelar.Text = "Cancelar";
            this._btnCacnelar.UseVisualStyleBackColor = true;
            this._btnCacnelar.Visible = false;
            this._btnCacnelar.Click += new System.EventHandler(this._btn_Click);
            // 
            // FormMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 285);
            this.CloseButtonDisable = true;
            this.Controls.Add(this.cndcPanelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMensajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantum";
            this.cndcPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCButton _btnCacnelar;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnSi;
        private Controles.CNDCButton _btnAbortar;
        private Controles.CNDCButton _btnReintentar;
        private Controles.CNDCButton _btnIgnorar;
        private Controles.CNDCButton _btnNo;
    }
}