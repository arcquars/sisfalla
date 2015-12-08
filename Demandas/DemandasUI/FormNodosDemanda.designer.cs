namespace DemandasUI
{
    partial class FormNodosDemanda
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
            this.label1 = new System.Windows.Forms.Label();
            this._txtSigla = new System.Windows.Forms.TextBox();
            this._cmbTipoNodo = new Controles.CNDCComboBox();
            this.label4 = new Controles.CNDCLabel();
            this._cbxListaNodos = new System.Windows.Forms.CheckedListBox();
            this._btnAdjuntar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sigla:";
            // 
            // _txtSigla
            // 
            this._txtSigla.Location = new System.Drawing.Point(48, 14);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(143, 20);
            this._txtSigla.TabIndex = 2;
            this._txtSigla.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSigla_KeyDown);
            // 
            // _cmbTipoNodo
            // 
            this._cmbTipoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoNodo.EnterComoTab = false;
            this._cmbTipoNodo.Etiqueta = null;
            this._cmbTipoNodo.FormattingEnabled = true;
            this._cmbTipoNodo.Location = new System.Drawing.Point(278, 14);
            this._cmbTipoNodo.Name = "_cmbTipoNodo";
            this._cmbTipoNodo.Size = new System.Drawing.Size(160, 21);
            this._cmbTipoNodo.TabIndex = 37;
            this._cmbTipoNodo.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            this._cmbTipoNodo.SelectedIndexChanged += new System.EventHandler(this._cmbTipoNodo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 36;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tipo Nodo:";
            // 
            // _cbxListaNodos
            // 
            this._cbxListaNodos.CheckOnClick = true;
            this._cbxListaNodos.FormattingEnabled = true;
            this._cbxListaNodos.Location = new System.Drawing.Point(9, 41);
            this._cbxListaNodos.Name = "_cbxListaNodos";
            this._cbxListaNodos.Size = new System.Drawing.Size(526, 574);
            this._cbxListaNodos.TabIndex = 38;
            // 
            // _btnAdjuntar
            // 
            this._btnAdjuntar.Location = new System.Drawing.Point(445, 13);
            this._btnAdjuntar.Name = "_btnAdjuntar";
            this._btnAdjuntar.Size = new System.Drawing.Size(75, 23);
            this._btnAdjuntar.TabIndex = 39;
            this._btnAdjuntar.Text = "Adjuntar";
            this._btnAdjuntar.UseVisualStyleBackColor = true;
            this._btnAdjuntar.Click += new System.EventHandler(this._btnAdjuntar_Click);
            // 
            // FormNodosDemanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 627);
            this.Controls.Add(this._btnAdjuntar);
            this.Controls.Add(this._cbxListaNodos);
            this.Controls.Add(this._cmbTipoNodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtSigla);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormNodosDemanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nodos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtSigla;
        private Controles.CNDCComboBox _cmbTipoNodo;
        private Controles.CNDCLabel label4;
        private System.Windows.Forms.CheckedListBox _cbxListaNodos;
        private System.Windows.Forms.Button _btnAdjuntar;
    }
}