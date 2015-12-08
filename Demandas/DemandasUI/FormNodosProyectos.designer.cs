namespace DemandasUI
{
    partial class FormNodosProyectos
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
            this._dgvNodos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._txtSigla = new System.Windows.Forms.TextBox();
            this._cmbTipoNodo = new Controles.CNDCComboBox();
            this.label4 = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodos)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvNodos
            // 
            this._dgvNodos.AllowUserToAddRows = false;
            this._dgvNodos.AllowUserToDeleteRows = false;
            this._dgvNodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvNodos.Location = new System.Drawing.Point(1, 38);
            this._dgvNodos.Name = "_dgvNodos";
            this._dgvNodos.ReadOnly = true;
            this._dgvNodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvNodos.Size = new System.Drawing.Size(764, 342);
            this._dgvNodos.TabIndex = 0;
            this._dgvNodos.SelectionChanged += new System.EventHandler(this._dgvNodos_SelectionChanged);
            this._dgvNodos.DoubleClick += new System.EventHandler(this._dgvNodos_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(46, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sigla:";
            // 
            // _txtSigla
            // 
            this._txtSigla.Location = new System.Drawing.Point(88, 12);
            this._txtSigla.Name = "_txtSigla";
            this._txtSigla.Size = new System.Drawing.Size(176, 20);
            this._txtSigla.TabIndex = 2;
            this._txtSigla.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSigla_KeyDown);
            // 
            // _cmbTipoNodo
            // 
            this._cmbTipoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoNodo.EnterComoTab = false;
            this._cmbTipoNodo.Etiqueta = null;
            this._cmbTipoNodo.FormattingEnabled = true;
            this._cmbTipoNodo.Location = new System.Drawing.Point(367, 12);
            this._cmbTipoNodo.Name = "_cmbTipoNodo";
            this._cmbTipoNodo.Size = new System.Drawing.Size(160, 21);
            this._cmbTipoNodo.TabIndex = 37;
            this._cmbTipoNodo.TablaCampoBD = "P_DEF_CAT_DOMINIOS.DESCRIPCION_DOMINIO";
            this._cmbTipoNodo.SelectedIndexChanged += new System.EventHandler(this._cmbTipoNodo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(297, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 36;
            this.label4.TablaCampoBD = null;
            this.label4.Text = "Tipo Nodo:";
            // 
            // FormNodosProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 380);
            this.Controls.Add(this._cmbTipoNodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtSigla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._dgvNodos);
            this.Name = "FormNodosProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nodos";
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvNodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtSigla;
        private Controles.CNDCComboBox _cmbTipoNodo;
        private Controles.CNDCLabel label4;
    }
}