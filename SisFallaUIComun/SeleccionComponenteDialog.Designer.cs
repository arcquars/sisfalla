namespace SISFALLA
{
    partial class SeleccionComponenteDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._cmbAgente = new Controles.CNDCComboBox();
            this._cmbTipoComponente = new Controles.CNDCComboBox();
            this._txtNombreComponente = new Controles.CNDCTextBox();
            this._dgvComponentes = new Controles.CNDCGridView();
            this._cancelButton = new Controles.CNDCButton();
            this._btnAceptar = new Controles.CNDCButton();
            this._cbTipoCompo = new Controles.CNDCCheckBox();
            this._cbAgente = new Controles.CNDCCheckBox();
            this._cbNodo = new Controles.CNDCCheckBox();
            this._cmbNodo = new Controles.CNDCComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgvComponentes)).BeginInit();
            this.SuspendLayout();
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.cndcLabelControl3.Location = new System.Drawing.Point(97, 30);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(108, 16);
            this.cndcLabelControl3.TabIndex = 4;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Text = "Código Componente:";
            // 
            // _cmbAgente
            // 
            this._cmbAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbAgente.EnterComoTab = false;
            this._cmbAgente.Etiqueta = null;
            this._cmbAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbAgente.FormattingEnabled = true;
            this._cmbAgente.Location = new System.Drawing.Point(212, 85);
            this._cmbAgente.Name = "_cmbAgente";
            this._cmbAgente.Size = new System.Drawing.Size(506, 24);
            this._cmbAgente.TabIndex = 5;
            this._cmbAgente.TablaCampoBD = null;
            this._cmbAgente.Visible = false;
            this._cmbAgente.SelectedIndexChanged += new System.EventHandler(this._cmbAgente_SelectedIndexChanged);
            // 
            // _cmbTipoComponente
            // 
            this._cmbTipoComponente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoComponente.EnterComoTab = false;
            this._cmbTipoComponente.Etiqueta = null;
            this._cmbTipoComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbTipoComponente.FormattingEnabled = true;
            this._cmbTipoComponente.Location = new System.Drawing.Point(212, 55);
            this._cmbTipoComponente.Name = "_cmbTipoComponente";
            this._cmbTipoComponente.Size = new System.Drawing.Size(506, 24);
            this._cmbTipoComponente.TabIndex = 6;
            this._cmbTipoComponente.TablaCampoBD = null;
            this._cmbTipoComponente.Visible = false;
            this._cmbTipoComponente.SelectedIndexChanged += new System.EventHandler(this._cmbTipoComponente_SelectedIndexChanged);
            // 
            // _txtNombreComponente
            // 
            this._txtNombreComponente.EnterComoTab = false;
            this._txtNombreComponente.Etiqueta = null;
            this._txtNombreComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._txtNombreComponente.Location = new System.Drawing.Point(212, 27);
            this._txtNombreComponente.Name = "_txtNombreComponente";
            this._txtNombreComponente.Size = new System.Drawing.Size(506, 22);
            this._txtNombreComponente.TabIndex = 7;
            this._txtNombreComponente.TablaCampoBD = null;
            this._txtNombreComponente.TextChanged += new System.EventHandler(this._txtNombreComponente_TextChanged);
            // 
            // _dgvComponentes
            // 
            this._dgvComponentes.AllowUserToAddRows = false;
            this._dgvComponentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvComponentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvComponentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvComponentes.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvComponentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvComponentes.Location = new System.Drawing.Point(12, 158);
            this._dgvComponentes.MultiSelect = false;
            this._dgvComponentes.Name = "_dgvComponentes";
            this._dgvComponentes.ReadOnly = true;
            this._dgvComponentes.RowHeadersWidth = 25;
            this._dgvComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvComponentes.Size = new System.Drawing.Size(812, 266);
            this._dgvComponentes.TabIndex = 8;
            this._dgvComponentes.TablaCampoBD = null;
            this._dgvComponentes.SelectionChanged += new System.EventHandler(this._dgvComponentes_SelectionChanged);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(425, 431);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(132, 35);
            this._cancelButton.TabIndex = 10;
            this._cancelButton.TablaCampoBD = null;
            this._cancelButton.Text = "Cancelar";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.cndcButton1_Click);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(287, 431);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(132, 35);
            this._btnAceptar.TabIndex = 9;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _cbTipoCompo
            // 
            this._cbTipoCompo.AutoSize = true;
            this._cbTipoCompo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbTipoCompo.Location = new System.Drawing.Point(92, 57);
            this._cbTipoCompo.Name = "_cbTipoCompo";
            this._cbTipoCompo.Size = new System.Drawing.Size(114, 20);
            this._cbTipoCompo.TabIndex = 12;
            this._cbTipoCompo.TablaCampoBD = null;
            this._cbTipoCompo.Text = "Tipo Componente:";
            this._cbTipoCompo.UseVisualStyleBackColor = true;
            this._cbTipoCompo.CheckedChanged += new System.EventHandler(this._cbTipoCompo_CheckedChanged);
            this._cbTipoCompo.Click += new System.EventHandler(this._cbTipoCompo_Click);
            // 
            // _cbAgente
            // 
            this._cbAgente.AutoSize = true;
            this._cbAgente.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbAgente.Location = new System.Drawing.Point(92, 87);
            this._cbAgente.Name = "_cbAgente";
            this._cbAgente.Size = new System.Drawing.Size(63, 20);
            this._cbAgente.TabIndex = 13;
            this._cbAgente.TablaCampoBD = null;
            this._cbAgente.Text = "Agente:";
            this._cbAgente.UseVisualStyleBackColor = true;
            this._cbAgente.CheckedChanged += new System.EventHandler(this._cbAgente_CheckedChanged);
            // 
            // _cbNodo
            // 
            this._cbNodo.AutoSize = true;
            this._cbNodo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cbNodo.Location = new System.Drawing.Point(92, 117);
            this._cbNodo.Name = "_cbNodo";
            this._cbNodo.Size = new System.Drawing.Size(56, 20);
            this._cbNodo.TabIndex = 16;
            this._cbNodo.TablaCampoBD = null;
            this._cbNodo.Text = "Nodo:";
            this._cbNodo.UseVisualStyleBackColor = true;
            this._cbNodo.CheckedChanged += new System.EventHandler(this.cndcCheckBox1_CheckedChanged);
            // 
            // _cmbNodo
            // 
            this._cmbNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbNodo.EnterComoTab = false;
            this._cmbNodo.Etiqueta = null;
            this._cmbNodo.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this._cmbNodo.FormattingEnabled = true;
            this._cmbNodo.Location = new System.Drawing.Point(212, 115);
            this._cmbNodo.Name = "_cmbNodo";
            this._cmbNodo.Size = new System.Drawing.Size(506, 24);
            this._cmbNodo.TabIndex = 15;
            this._cmbNodo.TablaCampoBD = null;
            this._cmbNodo.Visible = false;
            this._cmbNodo.SelectedIndexChanged += new System.EventHandler(this._cmbNodo_SelectedIndexChanged);
            // 
            // SeleccionComponenteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(836, 476);
            this.CloseButtonDisable = true;
            this.Controls.Add(this._cbNodo);
            this.Controls.Add(this._cmbNodo);
            this.Controls.Add(this._cbAgente);
            this.Controls.Add(this._cbTipoCompo);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._dgvComponentes);
            this.Controls.Add(this._txtNombreComponente);
            this.Controls.Add(this._cmbTipoComponente);
            this.Controls.Add(this._cmbAgente);
            this.Controls.Add(this.cndcLabelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionComponenteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionando componente";
            this.Load += new System.EventHandler(this.SeleccionComponenteDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgvComponentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCComboBox _cmbAgente;
        private Controles.CNDCComboBox _cmbTipoComponente;
        private Controles.CNDCTextBox _txtNombreComponente;
        private Controles.CNDCGridView _dgvComponentes;
        private Controles.CNDCButton _cancelButton;
        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCCheckBox _cbTipoCompo;
        private Controles.CNDCCheckBox _cbAgente;
        private Controles.CNDCCheckBox _cbNodo;
        private Controles.CNDCComboBox _cmbNodo;
    }
}