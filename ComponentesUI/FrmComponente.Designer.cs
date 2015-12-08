namespace ComponentesUI
{
    partial class FrmComponente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComponente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rbNoVigentes = new Controles.CNDCRadioButton();
            this._rbVigentes = new Controles.CNDCRadioButton();
            this._rbTodos = new Controles.CNDCRadioButton();
            this._cndcTS = new Controles.CNDCToolStrip();
            this._tSBNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this._cbNodo = new Controles.CNDCCheckBox();
            this._cmbNodo = new Controles.CNDCComboBox();
            this._cbAgente = new Controles.CNDCCheckBox();
            this._cbTipoCompo = new Controles.CNDCCheckBox();
            this._txtNombreComponente = new Controles.CNDCTextBox();
            this._cmbTipoComponente = new Controles.CNDCComboBox();
            this._cmbAgente = new Controles.CNDCComboBox();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._dgvDatos = new Controles.CNDCGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._cndcTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this._cndcTS);
            this.splitContainer1.Panel1.Controls.Add(this._cbNodo);
            this.splitContainer1.Panel1.Controls.Add(this._cmbNodo);
            this.splitContainer1.Panel1.Controls.Add(this._cbAgente);
            this.splitContainer1.Panel1.Controls.Add(this._cbTipoCompo);
            this.splitContainer1.Panel1.Controls.Add(this._txtNombreComponente);
            this.splitContainer1.Panel1.Controls.Add(this._cmbTipoComponente);
            this.splitContainer1.Panel1.Controls.Add(this._cmbAgente);
            this.splitContainer1.Panel1.Controls.Add(this.cndcLabelControl3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dgvDatos);
            this.splitContainer1.Size = new System.Drawing.Size(871, 562);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rbNoVigentes);
            this.groupBox1.Controls.Add(this._rbVigentes);
            this.groupBox1.Controls.Add(this._rbTodos);
            this.groupBox1.Location = new System.Drawing.Point(672, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 94);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // _rbNoVigentes
            // 
            this._rbNoVigentes.AutoSize = true;
            this._rbNoVigentes.Location = new System.Drawing.Point(7, 61);
            this._rbNoVigentes.Name = "_rbNoVigentes";
            this._rbNoVigentes.Size = new System.Drawing.Size(83, 17);
            this._rbNoVigentes.TabIndex = 2;
            this._rbNoVigentes.TablaCampoBD = null;
            this._rbNoVigentes.Text = "No Vigentes";
            this._rbNoVigentes.UseVisualStyleBackColor = true;
            // 
            // _rbVigentes
            // 
            this._rbVigentes.AutoSize = true;
            this._rbVigentes.Location = new System.Drawing.Point(7, 38);
            this._rbVigentes.Name = "_rbVigentes";
            this._rbVigentes.Size = new System.Drawing.Size(66, 17);
            this._rbVigentes.TabIndex = 1;
            this._rbVigentes.TablaCampoBD = null;
            this._rbVigentes.Text = "Vigentes";
            this._rbVigentes.UseVisualStyleBackColor = true;
            this._rbVigentes.CheckedChanged += new System.EventHandler(this._rbVigentes_CheckedChanged);
            // 
            // _rbTodos
            // 
            this._rbTodos.AutoSize = true;
            this._rbTodos.Checked = true;
            this._rbTodos.Location = new System.Drawing.Point(7, 15);
            this._rbTodos.Name = "_rbTodos";
            this._rbTodos.Size = new System.Drawing.Size(55, 17);
            this._rbTodos.TabIndex = 0;
            this._rbTodos.TablaCampoBD = null;
            this._rbTodos.TabStop = true;
            this._rbTodos.Text = "Todos";
            this._rbTodos.UseVisualStyleBackColor = true;
            this._rbTodos.CheckedChanged += new System.EventHandler(this._rbTodos_CheckedChanged);
            // 
            // _cndcTS
            // 
            this._cndcTS.AutoSize = false;
            this._cndcTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tSBNuevo,
            this.tsEditar,
            this.tsEliminar});
            this._cndcTS.Location = new System.Drawing.Point(0, 0);
            this._cndcTS.Name = "_cndcTS";
            this._cndcTS.Size = new System.Drawing.Size(871, 32);
            this._cndcTS.TabIndex = 25;
            this._cndcTS.TablaCampoBD = null;
            this._cndcTS.Text = "cndcToolStrip1";
            // 
            // _tSBNuevo
            // 
            this._tSBNuevo.Image = ((System.Drawing.Image)(resources.GetObject("_tSBNuevo.Image")));
            this._tSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBNuevo.Name = "_tSBNuevo";
            this._tSBNuevo.Size = new System.Drawing.Size(58, 29);
            this._tSBNuevo.Text = "Nuevo";
            this._tSBNuevo.Click += new System.EventHandler(this._tSBNuevo_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.Image = global::ComponentesUI.Properties.Resources.Edit;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(55, 29);
            this.tsEditar.Text = "Editar";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.Image = global::ComponentesUI.Properties.Resources.Delete;
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(63, 29);
            this.tsEliminar.Text = "Eliminar";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // _cbNodo
            // 
            this._cbNodo.AutoSize = true;
            this._cbNodo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbNodo.Location = new System.Drawing.Point(25, 136);
            this._cbNodo.Name = "_cbNodo";
            this._cbNodo.Size = new System.Drawing.Size(56, 20);
            this._cbNodo.TabIndex = 24;
            this._cbNodo.TablaCampoBD = null;
            this._cbNodo.Text = "Nodo:";
            this._cbNodo.UseVisualStyleBackColor = true;
            this._cbNodo.CheckedChanged += new System.EventHandler(this._cbNodo_CheckedChanged);
            // 
            // _cmbNodo
            // 
            this._cmbNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNodo.EnterComoTab = false;
            this._cmbNodo.Etiqueta = null;
            this._cmbNodo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbNodo.FormattingEnabled = true;
            this._cmbNodo.Location = new System.Drawing.Point(145, 133);
            this._cmbNodo.Name = "_cmbNodo";
            this._cmbNodo.Size = new System.Drawing.Size(506, 24);
            this._cmbNodo.TabIndex = 23;
            this._cmbNodo.TablaCampoBD = null;
            this._cmbNodo.Visible = false;
            this._cmbNodo.SelectedIndexChanged += new System.EventHandler(this._cmbNodo_SelectedIndexChanged);
            // 
            // _cbAgente
            // 
            this._cbAgente.AutoSize = true;
            this._cbAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbAgente.Location = new System.Drawing.Point(25, 105);
            this._cbAgente.Name = "_cbAgente";
            this._cbAgente.Size = new System.Drawing.Size(63, 20);
            this._cbAgente.TabIndex = 22;
            this._cbAgente.TablaCampoBD = null;
            this._cbAgente.Text = "Agente:";
            this._cbAgente.UseVisualStyleBackColor = true;
            this._cbAgente.CheckedChanged += new System.EventHandler(this._cbAgente_CheckedChanged);
            // 
            // _cbTipoCompo
            // 
            this._cbTipoCompo.AutoSize = true;
            this._cbTipoCompo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbTipoCompo.Location = new System.Drawing.Point(25, 75);
            this._cbTipoCompo.Name = "_cbTipoCompo";
            this._cbTipoCompo.Size = new System.Drawing.Size(114, 20);
            this._cbTipoCompo.TabIndex = 21;
            this._cbTipoCompo.TablaCampoBD = null;
            this._cbTipoCompo.Text = "Tipo Componente:";
            this._cbTipoCompo.UseVisualStyleBackColor = true;
            this._cbTipoCompo.CheckedChanged += new System.EventHandler(this._cbTipoCompo_CheckedChanged);
            // 
            // _txtNombreComponente
            // 
            this._txtNombreComponente.EnterComoTab = false;
            this._txtNombreComponente.Etiqueta = null;
            this._txtNombreComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._txtNombreComponente.Location = new System.Drawing.Point(145, 45);
            this._txtNombreComponente.Name = "_txtNombreComponente";
            this._txtNombreComponente.Size = new System.Drawing.Size(506, 22);
            this._txtNombreComponente.TabIndex = 20;
            this._txtNombreComponente.TablaCampoBD = null;
            this._txtNombreComponente.TextChanged += new System.EventHandler(this._txtNombreComponente_TextChanged);
            // 
            // _cmbTipoComponente
            // 
            this._cmbTipoComponente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoComponente.EnterComoTab = false;
            this._cmbTipoComponente.Etiqueta = null;
            this._cmbTipoComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbTipoComponente.FormattingEnabled = true;
            this._cmbTipoComponente.Location = new System.Drawing.Point(145, 73);
            this._cmbTipoComponente.Name = "_cmbTipoComponente";
            this._cmbTipoComponente.Size = new System.Drawing.Size(506, 24);
            this._cmbTipoComponente.TabIndex = 19;
            this._cmbTipoComponente.TablaCampoBD = null;
            this._cmbTipoComponente.Visible = false;
            this._cmbTipoComponente.SelectedIndexChanged += new System.EventHandler(this._cmbTipoComponente_SelectedIndexChanged);
            // 
            // _cmbAgente
            // 
            this._cmbAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAgente.EnterComoTab = false;
            this._cmbAgente.Etiqueta = null;
            this._cmbAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbAgente.FormattingEnabled = true;
            this._cmbAgente.Location = new System.Drawing.Point(145, 103);
            this._cmbAgente.Name = "_cmbAgente";
            this._cmbAgente.Size = new System.Drawing.Size(506, 24);
            this._cmbAgente.TabIndex = 18;
            this._cmbAgente.TablaCampoBD = null;
            this._cmbAgente.Visible = false;
            this._cmbAgente.SelectedIndexChanged += new System.EventHandler(this._cmbAgente_SelectedIndexChanged);
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.cndcLabelControl3.Location = new System.Drawing.Point(30, 48);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(108, 16);
            this.cndcLabelControl3.TabIndex = 17;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Código Componente:";
            // 
            // _dgvDatos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDatos.Location = new System.Drawing.Point(0, 0);
            this._dgvDatos.Name = "_dgvDatos";
            this._dgvDatos.NombreContenedor = null;
            this._dgvDatos.ReadOnly = true;
            this._dgvDatos.RowHeadersWidth = 25;
            this._dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDatos.Size = new System.Drawing.Size(871, 390);
            this._dgvDatos.TabIndex = 0;
            this._dgvDatos.TablaCampoBD = null;
            // 
            // FrmComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 562);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmComponente";
            this.Text = "Componentes";
            this.Load += new System.EventHandler(this.FrmComponente_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._cndcTS.ResumeLayout(false);
            this._cndcTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.CNDCCheckBox _cbNodo;
        private Controles.CNDCComboBox _cmbNodo;
        private Controles.CNDCCheckBox _cbAgente;
        private Controles.CNDCCheckBox _cbTipoCompo;
        private Controles.CNDCTextBox _txtNombreComponente;
        private Controles.CNDCComboBox _cmbTipoComponente;
        private Controles.CNDCComboBox _cmbAgente;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCToolStrip _cndcTS;
        private System.Windows.Forms.ToolStripButton _tSBNuevo;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private Controles.CNDCGridView _dgvDatos;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.CNDCRadioButton _rbTodos;
        private Controles.CNDCRadioButton _rbVigentes;
        private Controles.CNDCRadioButton _rbNoVigentes;
    }
}