namespace AdmRolesUI
{
    partial class FormUsuariosRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvUsuarios = new Controles.CNDCGridView();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._txtEstado = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtUsuario = new Controles.CNDCTextBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this._chlbxRoles = new Controles.CNDCCheckedListBox();
            this.cndcToolStrip1 = new Controles.CNDCToolStrip();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsuarios)).BeginInit();
            this.cndcGroupBox1.SuspendLayout();
            this.cndcGroupBox2.SuspendLayout();
            this.cndcToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvUsuarios
            // 
            this._dgvUsuarios.AllowUserToAddRows = false;
            this._dgvUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvUsuarios.Location = new System.Drawing.Point(20, 230);
            this._dgvUsuarios.Name = "_dgvUsuarios";
            this._dgvUsuarios.ReadOnly = true;
            this._dgvUsuarios.RowHeadersWidth = 25;
            this._dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvUsuarios.Size = new System.Drawing.Size(743, 304);
            this._dgvUsuarios.TabIndex = 0;
            this._dgvUsuarios.TablaCampoBD = null;
            this._dgvUsuarios.SelectionChanged += new System.EventHandler(this._dgvUsuarios_SelectionChanged);
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._txtEstado);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel3);
            this.cndcGroupBox1.Controls.Add(this._txtNombre);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel2);
            this.cndcGroupBox1.Controls.Add(this._txtUsuario);
            this.cndcGroupBox1.Controls.Add(this.cndcLabel1);
            this.cndcGroupBox1.Location = new System.Drawing.Point(20, 19);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(372, 194);
            this.cndcGroupBox1.TabIndex = 1;
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Datos del Usuario";
            // 
            // _txtEstado
            // 
            this._txtEstado.EnterComoTab = false;
            this._txtEstado.Etiqueta = null;
            this._txtEstado.Location = new System.Drawing.Point(79, 89);
            this._txtEstado.Name = "_txtEstado";
            this._txtEstado.Size = new System.Drawing.Size(164, 20);
            this._txtEstado.TabIndex = 5;
            this._txtEstado.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(30, 92);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(43, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Estado:";
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(79, 63);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(270, 20);
            this._txtNombre.TabIndex = 3;
            this._txtNombre.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(26, 66);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Nombre:";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.EnterComoTab = false;
            this._txtUsuario.Etiqueta = null;
            this._txtUsuario.Location = new System.Drawing.Point(79, 41);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(164, 20);
            this._txtUsuario.TabIndex = 1;
            this._txtUsuario.TablaCampoBD = null;
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(27, 44);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(46, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Usuario:";
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this._chlbxRoles);
            this.cndcGroupBox2.Controls.Add(this.cndcToolStrip1);
            this.cndcGroupBox2.Location = new System.Drawing.Point(398, 19);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(365, 194);
            this.cndcGroupBox2.TabIndex = 2;
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Roles";
            // 
            // _chlbxRoles
            // 
            this._chlbxRoles.CheckOnClick = true;
            this._chlbxRoles.ColumnWidth = 168;
            this._chlbxRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chlbxRoles.FormattingEnabled = true;
            this._chlbxRoles.Location = new System.Drawing.Point(3, 41);
            this._chlbxRoles.MultiColumn = true;
            this._chlbxRoles.Name = "_chlbxRoles";
            this._chlbxRoles.Size = new System.Drawing.Size(359, 150);
            this._chlbxRoles.TabIndex = 1;
            this._chlbxRoles.TablaCampoBD = null;
            // 
            // cndcToolStrip1
            // 
            this.cndcToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGuardar,
            this._btnCancelar});
            this.cndcToolStrip1.Location = new System.Drawing.Point(3, 16);
            this.cndcToolStrip1.Name = "cndcToolStrip1";
            this.cndcToolStrip1.Size = new System.Drawing.Size(359, 25);
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
            // FormUsuariosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 558);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this._dgvUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormUsuariosRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUsuariosRoles";
            this.Load += new System.EventHandler(this.FormUsuariosRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsuarios)).EndInit();
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.cndcToolStrip1.ResumeLayout(false);
            this.cndcToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCGridView _dgvUsuarios;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCTextBox _txtEstado;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtUsuario;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCCheckedListBox _chlbxRoles;
        private Controles.CNDCToolStrip cndcToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
    }
}