namespace CNDC.BaseForms
{
    partial class GridConfigForm
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
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this.cndcLabelControl2 = new Controles.CNDCLabel();
            this._chbxNoVisibles = new Controles.CNDCListBox();
            this._chbxVisibles = new Controles.CNDCListBox();
            this._btnHacerVisible = new Controles.CNDCButton();
            this._btnHacerNoVisible = new Controles.CNDCButton();
            this._btnSubir = new Controles.CNDCButton();
            this._btnBajar = new Controles.CNDCButton();
            this._toolStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this._btnCancelar});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(570, 25);
            this._toolStrip.TabIndex = 1;
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
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblMessage});
            this._statusStrip.Location = new System.Drawing.Point(0, 287);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(570, 22);
            this._statusStrip.TabIndex = 2;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _lblMessage
            // 
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(58, 17);
            this._lblMessage.Text = "Messages";
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(12, 28);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(149, 15);
            this.cndcLabelControl1.TabIndex = 3;
            this.cndcLabelControl1.Text = "Columnas NO Visibles";
            // 
            // cndcLabelControl2
            // 
            this.cndcLabelControl2.AutoSize = true;
            this.cndcLabelControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl2.TablaCampoBD = null;
            this.cndcLabelControl2.Location = new System.Drawing.Point(290, 28);
            this.cndcLabelControl2.Name = "cndcLabelControl2";
            this.cndcLabelControl2.Size = new System.Drawing.Size(125, 15);
            this.cndcLabelControl2.TabIndex = 4;
            this.cndcLabelControl2.Text = "Columnas Visibles";
            // 
            // _chbxNoVisibles
            // 
            this._chbxNoVisibles.FormattingEnabled = true;
            this._chbxNoVisibles.TablaCampoBD = null;
            this._chbxNoVisibles.Location = new System.Drawing.Point(12, 45);
            this._chbxNoVisibles.Name = "_chbxNoVisibles";
            this._chbxNoVisibles.Size = new System.Drawing.Size(211, 186);
            this._chbxNoVisibles.TabIndex = 5;
            // 
            // _chbxVisibles
            // 
            this._chbxVisibles.FormattingEnabled = true;
            this._chbxVisibles.TablaCampoBD = null;
            this._chbxVisibles.Location = new System.Drawing.Point(293, 45);
            this._chbxVisibles.Name = "_chbxVisibles";
            this._chbxVisibles.Size = new System.Drawing.Size(211, 186);
            this._chbxVisibles.TabIndex = 6;
            // 
            // _btnHacerVisible
            // 
            this._btnHacerVisible.TablaCampoBD = null;
            this._btnHacerVisible.Location = new System.Drawing.Point(229, 111);
            this._btnHacerVisible.Name = "_btnHacerVisible";
            this._btnHacerVisible.Size = new System.Drawing.Size(56, 23);
            this._btnHacerVisible.TabIndex = 7;
            this._btnHacerVisible.Text = ">>";
            this._btnHacerVisible.UseVisualStyleBackColor = true;
            // 
            // _btnHacerNoVisible
            // 
            this._btnHacerNoVisible.TablaCampoBD = null;
            this._btnHacerNoVisible.Location = new System.Drawing.Point(229, 140);
            this._btnHacerNoVisible.Name = "_btnHacerNoVisible";
            this._btnHacerNoVisible.Size = new System.Drawing.Size(56, 23);
            this._btnHacerNoVisible.TabIndex = 8;
            this._btnHacerNoVisible.Text = "<<";
            this._btnHacerNoVisible.UseVisualStyleBackColor = true;
            // 
            // _btnSubir
            // 
            this._btnSubir.TablaCampoBD = null;
            this._btnSubir.Location = new System.Drawing.Point(510, 111);
            this._btnSubir.Name = "_btnSubir";
            this._btnSubir.Size = new System.Drawing.Size(54, 23);
            this._btnSubir.TabIndex = 9;
            this._btnSubir.Text = "Subir";
            this._btnSubir.UseVisualStyleBackColor = true;
            // 
            // _btnBajar
            // 
            this._btnBajar.TablaCampoBD = null;
            this._btnBajar.Location = new System.Drawing.Point(510, 140);
            this._btnBajar.Name = "_btnBajar";
            this._btnBajar.Size = new System.Drawing.Size(53, 23);
            this._btnBajar.TabIndex = 10;
            this._btnBajar.Text = "Bajar";
            this._btnBajar.UseVisualStyleBackColor = true;
            // 
            // GridConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 309);
            this.Controls.Add(this._btnBajar);
            this.Controls.Add(this._btnSubir);
            this.Controls.Add(this._btnHacerNoVisible);
            this.Controls.Add(this._btnHacerVisible);
            this.Controls.Add(this._chbxVisibles);
            this.Controls.Add(this._chbxNoVisibles);
            this.Controls.Add(this.cndcLabelControl2);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._toolStrip);
            this.Name = "GridConfigForm";
            this.Text = "ColumnConfigForm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _lblMessage;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCLabel cndcLabelControl2;
        private Controles.CNDCListBox _chbxNoVisibles;
        private Controles.CNDCListBox _chbxVisibles;
        private Controles.CNDCButton _btnHacerVisible;
        private Controles.CNDCButton _btnHacerNoVisible;
        private Controles.CNDCButton _btnSubir;
        private Controles.CNDCButton _btnBajar;
    }
}