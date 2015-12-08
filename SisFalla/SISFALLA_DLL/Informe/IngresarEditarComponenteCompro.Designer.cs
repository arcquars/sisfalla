namespace SISFALLA.Informe
{
    partial class IngresarEditarComponenteCompro
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
            this._btnComponente = new Controles.CNDCButton();
            this._txtComponente = new Controles.CNDCTextBox();
            this.cndcLabelControl4 = new Controles.CNDCLabel();
            this.cndcGroupBox1 = new Controles.CNDCGroupBox();
            this._rbtNegativo = new Controles.CNDCRadioButton();
            this._rbtPositivo = new Controles.CNDCRadioButton();
            this._txtPotDesc = new Controles.CNDCTextBox();
            this._lblTotalSistemaConex = new Controles.CNDCLabel();
            this.cndcLabelControl30 = new Controles.CNDCLabel();
            this.cndcLabelControl31 = new Controles.CNDCLabel();
            this._lblTotalSistemaPrecon = new Controles.CNDCLabel();
            this.cndcLabelControl26 = new Controles.CNDCLabel();
            this.cndcLabelControl27 = new Controles.CNDCLabel();
            this._lblTiempoSisIndisponibilidad = new Controles.CNDCLabel();
            this.cndcLabelControl23 = new Controles.CNDCLabel();
            this.cndcLabelControl20 = new Controles.CNDCLabel();
            this.cndcLabelControl19 = new Controles.CNDCLabel();
            this._lblIndisponibilidad = new Controles.CNDCLabel();
            this.cndcLabelControl18 = new Controles.CNDCLabel();
            this._lblTotalSistemaAsig = new Controles.CNDCLabel();
            this.cndcLabelControl34 = new Controles.CNDCLabel();
            this.cndcLabelControl22 = new Controles.CNDCLabel();
            this._txtFecHoraFalla = new Controles.CNDCTextBox();
            this.cndcLabelControl1 = new Controles.CNDCLabel();
            this._txtTotalIndis = new Controles.CNDCTextBox();
            this._txtTotalPrecon = new Controles.CNDCTextBox();
            this._txtTotalConex = new Controles.CNDCTextBox();
            this.cndcLabelControl3 = new Controles.CNDCLabel();
            this._lblTotalTiempoDesc = new Controles.CNDCLabel();
            this._dgvIndisponibilidad = new Controles.CNDCGridView();
            this._colUsuario = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._colTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dgvPreconexion = new Controles.CNDCGridView();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dgvConexion = new Controles.CNDCGridView();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dgvAsignacion = new Controles.CNDCGridView();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cndcGroupBox2 = new Controles.CNDCGroupBox();
            this.cndcRadioButton2 = new Controles.CNDCRadioButton();
            this._ = new Controles.CNDCRadioButton();
            this.cndcGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndisponibilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPreconexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvConexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAsignacion)).BeginInit();
            this.cndcGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnComponente
            // 
            this._btnComponente.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._btnComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnComponente.TablaCampoBD = null;
            this._btnComponente.Location = new System.Drawing.Point(127, 40);
            this._btnComponente.Name = "_btnComponente";
            this._btnComponente.Size = new System.Drawing.Size(153, 23);
            this._btnComponente.TabIndex = 3;
            this._btnComponente.Text = "Componente Comprometido ";
            this._btnComponente.UseVisualStyleBackColor = false;
            this._btnComponente.Click += new System.EventHandler(this._btnComponente_Click);
            // 
            // _txtComponente
            // 
            this._txtComponente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtComponente.TablaCampoBD = null;
            this._txtComponente.Location = new System.Drawing.Point(306, 41);
            this._txtComponente.Name = "_txtComponente";
            this._txtComponente.Size = new System.Drawing.Size(424, 22);
            this._txtComponente.TabIndex = 9;
            // 
            // cndcLabelControl4
            // 
            this.cndcLabelControl4.AutoSize = true;
            this.cndcLabelControl4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl4.TablaCampoBD = null;
            this.cndcLabelControl4.Location = new System.Drawing.Point(319, 85);
            this.cndcLabelControl4.Name = "cndcLabelControl4";
            this.cndcLabelControl4.Size = new System.Drawing.Size(88, 16);
            this.cndcLabelControl4.TabIndex = 10;
            this.cndcLabelControl4.Text = "Pot. Desc (MW) :";
            // 
            // cndcGroupBox1
            // 
            this.cndcGroupBox1.Controls.Add(this._rbtNegativo);
            this.cndcGroupBox1.Controls.Add(this._rbtPositivo);
            this.cndcGroupBox1.TablaCampoBD = null;
            this.cndcGroupBox1.Location = new System.Drawing.Point(41, 76);
            this.cndcGroupBox1.Name = "cndcGroupBox1";
            this.cndcGroupBox1.Size = new System.Drawing.Size(153, 67);
            this.cndcGroupBox1.TabIndex = 11;
            this.cndcGroupBox1.TabStop = false;
            this.cndcGroupBox1.Text = "Flujo de Nodo 1 a Nodo 2:";
            // 
            // _rbtNegativo
            // 
            this._rbtNegativo.AutoSize = true;
            this._rbtNegativo.TablaCampoBD = null;
            this._rbtNegativo.Location = new System.Drawing.Point(41, 43);
            this._rbtNegativo.Name = "_rbtNegativo";
            this._rbtNegativo.Size = new System.Drawing.Size(68, 17);
            this._rbtNegativo.TabIndex = 1;
            this._rbtNegativo.Text = "Negativo";
            this._rbtNegativo.UseVisualStyleBackColor = true;
            // 
            // _rbtPositivo
            // 
            this._rbtPositivo.AutoSize = true;
            this._rbtPositivo.Checked = true;
            this._rbtPositivo.TablaCampoBD = null;
            this._rbtPositivo.Location = new System.Drawing.Point(41, 19);
            this._rbtPositivo.Name = "_rbtPositivo";
            this._rbtPositivo.Size = new System.Drawing.Size(62, 17);
            this._rbtPositivo.TabIndex = 0;
            this._rbtPositivo.TabStop = true;
            this._rbtPositivo.Text = "Positivo";
            this._rbtPositivo.UseVisualStyleBackColor = true;
            // 
            // _txtPotDesc
            // 
            this._txtPotDesc.TablaCampoBD = null;
            this._txtPotDesc.Location = new System.Drawing.Point(414, 85);
            this._txtPotDesc.Name = "_txtPotDesc";
            this._txtPotDesc.Size = new System.Drawing.Size(60, 20);
            this._txtPotDesc.TabIndex = 12;
            // 
            // _lblTotalSistemaConex
            // 
            this._lblTotalSistemaConex.AutoSize = true;
            this._lblTotalSistemaConex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTotalSistemaConex.TablaCampoBD = null;
            this._lblTotalSistemaConex.Location = new System.Drawing.Point(611, 213);
            this._lblTotalSistemaConex.Name = "_lblTotalSistemaConex";
            this._lblTotalSistemaConex.Size = new System.Drawing.Size(32, 13);
            this._lblTotalSistemaConex.TabIndex = 98;
            this._lblTotalSistemaConex.Text = "0.00";
            // 
            // cndcLabelControl30
            // 
            this.cndcLabelControl30.AutoSize = true;
            this.cndcLabelControl30.TablaCampoBD = null;
            this.cndcLabelControl30.Location = new System.Drawing.Point(520, 213);
            this.cndcLabelControl30.Name = "cndcLabelControl30";
            this.cndcLabelControl30.Size = new System.Drawing.Size(88, 13);
            this.cndcLabelControl30.TabIndex = 96;
            this.cndcLabelControl30.Text = "Tiempo Sistema :";
            // 
            // cndcLabelControl31
            // 
            this.cndcLabelControl31.AutoSize = true;
            this.cndcLabelControl31.TablaCampoBD = null;
            this.cndcLabelControl31.Location = new System.Drawing.Point(500, 192);
            this.cndcLabelControl31.Name = "cndcLabelControl31";
            this.cndcLabelControl31.Size = new System.Drawing.Size(108, 13);
            this.cndcLabelControl31.TabIndex = 95;
            this.cndcLabelControl31.Text = "Tiempo Total Conex :";
            // 
            // _lblTotalSistemaPrecon
            // 
            this._lblTotalSistemaPrecon.AutoSize = true;
            this._lblTotalSistemaPrecon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTotalSistemaPrecon.TablaCampoBD = null;
            this._lblTotalSistemaPrecon.Location = new System.Drawing.Point(377, 213);
            this._lblTotalSistemaPrecon.Name = "_lblTotalSistemaPrecon";
            this._lblTotalSistemaPrecon.Size = new System.Drawing.Size(32, 13);
            this._lblTotalSistemaPrecon.TabIndex = 93;
            this._lblTotalSistemaPrecon.Text = "0.00";
            // 
            // cndcLabelControl26
            // 
            this.cndcLabelControl26.AutoSize = true;
            this.cndcLabelControl26.TablaCampoBD = null;
            this.cndcLabelControl26.Location = new System.Drawing.Point(286, 213);
            this.cndcLabelControl26.Name = "cndcLabelControl26";
            this.cndcLabelControl26.Size = new System.Drawing.Size(88, 13);
            this.cndcLabelControl26.TabIndex = 91;
            this.cndcLabelControl26.Text = "Tiempo Sistema :";
            // 
            // cndcLabelControl27
            // 
            this.cndcLabelControl27.AutoSize = true;
            this.cndcLabelControl27.TablaCampoBD = null;
            this.cndcLabelControl27.Location = new System.Drawing.Point(274, 192);
            this.cndcLabelControl27.Name = "cndcLabelControl27";
            this.cndcLabelControl27.Size = new System.Drawing.Size(94, 13);
            this.cndcLabelControl27.TabIndex = 90;
            this.cndcLabelControl27.Text = "Tiempo Total Pre :";
            // 
            // _lblTiempoSisIndisponibilidad
            // 
            this._lblTiempoSisIndisponibilidad.AutoSize = true;
            this._lblTiempoSisIndisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTiempoSisIndisponibilidad.TablaCampoBD = null;
            this._lblTiempoSisIndisponibilidad.Location = new System.Drawing.Point(142, 213);
            this._lblTiempoSisIndisponibilidad.Name = "_lblTiempoSisIndisponibilidad";
            this._lblTiempoSisIndisponibilidad.Size = new System.Drawing.Size(32, 13);
            this._lblTiempoSisIndisponibilidad.TabIndex = 88;
            this._lblTiempoSisIndisponibilidad.Text = "0.00";
            // 
            // cndcLabelControl23
            // 
            this.cndcLabelControl23.AutoSize = true;
            this.cndcLabelControl23.TablaCampoBD = null;
            this.cndcLabelControl23.Location = new System.Drawing.Point(51, 213);
            this.cndcLabelControl23.Name = "cndcLabelControl23";
            this.cndcLabelControl23.Size = new System.Drawing.Size(88, 13);
            this.cndcLabelControl23.TabIndex = 86;
            this.cndcLabelControl23.Text = "Tiempo Sistema :";
            // 
            // cndcLabelControl20
            // 
            this.cndcLabelControl20.AutoSize = true;
            this.cndcLabelControl20.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl20.TablaCampoBD = null;
            this.cndcLabelControl20.Location = new System.Drawing.Point(533, 170);
            this.cndcLabelControl20.Name = "cndcLabelControl20";
            this.cndcLabelControl20.Size = new System.Drawing.Size(96, 16);
            this.cndcLabelControl20.TabIndex = 85;
            this.cndcLabelControl20.Text = "CONEXION (min)";
            // 
            // cndcLabelControl19
            // 
            this.cndcLabelControl19.AutoSize = true;
            this.cndcLabelControl19.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl19.TablaCampoBD = null;
            this.cndcLabelControl19.Location = new System.Drawing.Point(289, 171);
            this.cndcLabelControl19.Name = "cndcLabelControl19";
            this.cndcLabelControl19.Size = new System.Drawing.Size(118, 16);
            this.cndcLabelControl19.TabIndex = 84;
            this.cndcLabelControl19.Text = "PRECONEXION (min)";
            // 
            // _lblIndisponibilidad
            // 
            this._lblIndisponibilidad.AutoSize = true;
            this._lblIndisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIndisponibilidad.TablaCampoBD = null;
            this._lblIndisponibilidad.Location = new System.Drawing.Point(43, 173);
            this._lblIndisponibilidad.Name = "_lblIndisponibilidad";
            this._lblIndisponibilidad.Size = new System.Drawing.Size(151, 13);
            this._lblIndisponibilidad.TabIndex = 83;
            this._lblIndisponibilidad.Text = "INDISPONIBILIDAD (min)";
            // 
            // cndcLabelControl18
            // 
            this.cndcLabelControl18.AutoSize = true;
            this.cndcLabelControl18.TablaCampoBD = null;
            this.cndcLabelControl18.Location = new System.Drawing.Point(39, 193);
            this.cndcLabelControl18.Name = "cndcLabelControl18";
            this.cndcLabelControl18.Size = new System.Drawing.Size(100, 13);
            this.cndcLabelControl18.TabIndex = 82;
            this.cndcLabelControl18.Text = "Tiempo Total Indis :";
            // 
            // _lblTotalSistemaAsig
            // 
            this._lblTotalSistemaAsig.AutoSize = true;
            this._lblTotalSistemaAsig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTotalSistemaAsig.TablaCampoBD = null;
            this._lblTotalSistemaAsig.Location = new System.Drawing.Point(850, 213);
            this._lblTotalSistemaAsig.Name = "_lblTotalSistemaAsig";
            this._lblTotalSistemaAsig.Size = new System.Drawing.Size(32, 13);
            this._lblTotalSistemaAsig.TabIndex = 104;
            this._lblTotalSistemaAsig.Text = "0.00";
            // 
            // cndcLabelControl34
            // 
            this.cndcLabelControl34.AutoSize = true;
            this.cndcLabelControl34.TablaCampoBD = null;
            this.cndcLabelControl34.Location = new System.Drawing.Point(759, 213);
            this.cndcLabelControl34.Name = "cndcLabelControl34";
            this.cndcLabelControl34.Size = new System.Drawing.Size(75, 13);
            this.cndcLabelControl34.TabIndex = 102;
            this.cndcLabelControl34.Text = "Tiempo Total :";
            // 
            // cndcLabelControl22
            // 
            this.cndcLabelControl22.AutoSize = true;
            this.cndcLabelControl22.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl22.TablaCampoBD = null;
            this.cndcLabelControl22.Location = new System.Drawing.Point(737, 189);
            this.cndcLabelControl22.Name = "cndcLabelControl22";
            this.cndcLabelControl22.Size = new System.Drawing.Size(159, 16);
            this.cndcLabelControl22.TabIndex = 100;
            this.cndcLabelControl22.Text = "ASIGNACION DE RESP.(min)";
            // 
            // _txtFecHoraFalla
            // 
            this._txtFecHoraFalla.TablaCampoBD = null;
            this._txtFecHoraFalla.Location = new System.Drawing.Point(678, 84);
            this._txtFecHoraFalla.Name = "_txtFecHoraFalla";
            this._txtFecHoraFalla.Size = new System.Drawing.Size(146, 20);
            this._txtFecHoraFalla.TabIndex = 107;
            // 
            // cndcLabelControl1
            // 
            this.cndcLabelControl1.AutoSize = true;
            this.cndcLabelControl1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcLabelControl1.TablaCampoBD = null;
            this.cndcLabelControl1.Location = new System.Drawing.Point(527, 85);
            this.cndcLabelControl1.Name = "cndcLabelControl1";
            this.cndcLabelControl1.Size = new System.Drawing.Size(132, 16);
            this.cndcLabelControl1.TabIndex = 106;
            this.cndcLabelControl1.Text = "Fecha y Hora de la Falla :";
            // 
            // _txtTotalIndis
            // 
            this._txtTotalIndis.TablaCampoBD = null;
            this._txtTotalIndis.Location = new System.Drawing.Point(145, 190);
            this._txtTotalIndis.Name = "_txtTotalIndis";
            this._txtTotalIndis.Size = new System.Drawing.Size(60, 20);
            this._txtTotalIndis.TabIndex = 108;
            // 
            // _txtTotalPrecon
            // 
            this._txtTotalPrecon.TablaCampoBD = null;
            this._txtTotalPrecon.Location = new System.Drawing.Point(379, 189);
            this._txtTotalPrecon.Name = "_txtTotalPrecon";
            this._txtTotalPrecon.Size = new System.Drawing.Size(60, 20);
            this._txtTotalPrecon.TabIndex = 109;
            // 
            // _txtTotalConex
            // 
            this._txtTotalConex.TablaCampoBD = null;
            this._txtTotalConex.Location = new System.Drawing.Point(611, 189);
            this._txtTotalConex.Name = "_txtTotalConex";
            this._txtTotalConex.Size = new System.Drawing.Size(60, 20);
            this._txtTotalConex.TabIndex = 110;
            // 
            // cndcLabelControl3
            // 
            this.cndcLabelControl3.AutoSize = true;
            this.cndcLabelControl3.TablaCampoBD = null;
            this.cndcLabelControl3.Location = new System.Drawing.Point(253, 123);
            this.cndcLabelControl3.Name = "cndcLabelControl3";
            this.cndcLabelControl3.Size = new System.Drawing.Size(155, 13);
            this.cndcLabelControl3.TabIndex = 111;
            this.cndcLabelControl3.Text = "Tiempo Total de Desconexión :";
            // 
            // _lblTotalTiempoDesc
            // 
            this._lblTotalTiempoDesc.AutoSize = true;
            this._lblTotalTiempoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTotalTiempoDesc.TablaCampoBD = null;
            this._lblTotalTiempoDesc.Location = new System.Drawing.Point(415, 122);
            this._lblTotalTiempoDesc.Name = "_lblTotalTiempoDesc";
            this._lblTotalTiempoDesc.Size = new System.Drawing.Size(32, 13);
            this._lblTotalTiempoDesc.TabIndex = 113;
            this._lblTotalTiempoDesc.Text = "0.00";
            // 
            // _dgvIndisponibilidad
            // 
            this._dgvIndisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvIndisponibilidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colUsuario,
            this._colTiempo});
            this._dgvIndisponibilidad.TablaCampoBD = null;
            this._dgvIndisponibilidad.Location = new System.Drawing.Point(26, 245);
            this._dgvIndisponibilidad.MultiSelect = false;
            this._dgvIndisponibilidad.Name = "_dgvIndisponibilidad";
            this._dgvIndisponibilidad.RowHeadersWidth = 15;
            this._dgvIndisponibilidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvIndisponibilidad.Size = new System.Drawing.Size(187, 110);
            this._dgvIndisponibilidad.TabIndex = 114;
            // 
            // _colUsuario
            // 
            this._colUsuario.HeaderText = "Usuario";
            this._colUsuario.Name = "_colUsuario";
            this._colUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._colUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _colTiempo
            // 
            this._colTiempo.HeaderText = "Tiempo";
            this._colTiempo.Name = "_colTiempo";
            this._colTiempo.Width = 70;
            // 
            // _dgvPreconexion
            // 
            this._dgvPreconexion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvPreconexion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this._dgvPreconexion.TablaCampoBD = null;
            this._dgvPreconexion.Location = new System.Drawing.Point(260, 245);
            this._dgvPreconexion.MultiSelect = false;
            this._dgvPreconexion.Name = "_dgvPreconexion";
            this._dgvPreconexion.RowHeadersWidth = 15;
            this._dgvPreconexion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvPreconexion.Size = new System.Drawing.Size(187, 110);
            this._dgvPreconexion.TabIndex = 118;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Usuario";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tiempo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // _dgvConexion
            // 
            this._dgvConexion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvConexion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn2,
            this.dataGridViewTextBoxColumn2});
            this._dgvConexion.TablaCampoBD = null;
            this._dgvConexion.Location = new System.Drawing.Point(493, 245);
            this._dgvConexion.MultiSelect = false;
            this._dgvConexion.Name = "_dgvConexion";
            this._dgvConexion.RowHeadersWidth = 15;
            this._dgvConexion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvConexion.Size = new System.Drawing.Size(187, 110);
            this._dgvConexion.TabIndex = 119;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "Usuario";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tiempo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // _dgvAsignacion
            // 
            this._dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn3,
            this.dataGridViewTextBoxColumn3});
            this._dgvAsignacion.TablaCampoBD = null;
            this._dgvAsignacion.Location = new System.Drawing.Point(718, 245);
            this._dgvAsignacion.MultiSelect = false;
            this._dgvAsignacion.Name = "_dgvAsignacion";
            this._dgvAsignacion.RowHeadersWidth = 15;
            this._dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAsignacion.Size = new System.Drawing.Size(187, 110);
            this._dgvAsignacion.TabIndex = 120;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.HeaderText = "Usuario";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tiempo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // cndcGroupBox2
            // 
            this.cndcGroupBox2.Controls.Add(this.cndcRadioButton2);
            this.cndcGroupBox2.Controls.Add(this._);
            this.cndcGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cndcGroupBox2.TablaCampoBD = null;
            this.cndcGroupBox2.Location = new System.Drawing.Point(735, 115);
            this.cndcGroupBox2.Name = "cndcGroupBox2";
            this.cndcGroupBox2.Size = new System.Drawing.Size(149, 66);
            this.cndcGroupBox2.TabIndex = 121;
            this.cndcGroupBox2.TabStop = false;
            this.cndcGroupBox2.Text = "Tipo de Asignación :";
            // 
            // cndcRadioButton2
            // 
            this.cndcRadioButton2.AutoSize = true;
            this.cndcRadioButton2.TablaCampoBD = null;
            this.cndcRadioButton2.Location = new System.Drawing.Point(35, 42);
            this.cndcRadioButton2.Name = "cndcRadioButton2";
            this.cndcRadioButton2.Size = new System.Drawing.Size(68, 17);
            this.cndcRadioButton2.TabIndex = 116;
            this.cndcRadioButton2.TabStop = true;
            this.cndcRadioButton2.Text = "Usuario";
            this.cndcRadioButton2.UseVisualStyleBackColor = true;
            // 
            // _
            // 
            this._.AutoSize = true;
            this._.TablaCampoBD = null;
            this._.Location = new System.Drawing.Point(35, 19);
            this._.Name = "_";
            this._.Size = new System.Drawing.Size(69, 17);
            this._.TabIndex = 115;
            this._.TabStop = true;
            this._.Text = "Sistema";
            this._.UseVisualStyleBackColor = true;
            // 
            // IngresarEditarComponenteCompro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 406);
            this.Controls.Add(this.cndcGroupBox2);
            this.Controls.Add(this._dgvAsignacion);
            this.Controls.Add(this._dgvConexion);
            this.Controls.Add(this._dgvPreconexion);
            this.Controls.Add(this._dgvIndisponibilidad);
            this.Controls.Add(this._lblTotalTiempoDesc);
            this.Controls.Add(this.cndcLabelControl3);
            this.Controls.Add(this._txtTotalConex);
            this.Controls.Add(this._txtTotalPrecon);
            this.Controls.Add(this._txtTotalIndis);
            this.Controls.Add(this._txtFecHoraFalla);
            this.Controls.Add(this.cndcLabelControl1);
            this.Controls.Add(this._lblTotalSistemaAsig);
            this.Controls.Add(this.cndcLabelControl34);
            this.Controls.Add(this.cndcLabelControl22);
            this.Controls.Add(this._lblTotalSistemaConex);
            this.Controls.Add(this.cndcLabelControl30);
            this.Controls.Add(this.cndcLabelControl31);
            this.Controls.Add(this._lblTotalSistemaPrecon);
            this.Controls.Add(this.cndcLabelControl26);
            this.Controls.Add(this.cndcLabelControl27);
            this.Controls.Add(this._lblTiempoSisIndisponibilidad);
            this.Controls.Add(this.cndcLabelControl23);
            this.Controls.Add(this.cndcLabelControl20);
            this.Controls.Add(this.cndcLabelControl19);
            this.Controls.Add(this._lblIndisponibilidad);
            this.Controls.Add(this.cndcLabelControl18);
            this.Controls.Add(this._txtPotDesc);
            this.Controls.Add(this.cndcGroupBox1);
            this.Controls.Add(this.cndcLabelControl4);
            this.Controls.Add(this._txtComponente);
            this.Controls.Add(this._btnComponente);
            this.Name = "IngresarEditarComponenteCompro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Editar Componente Comprometido";
            this.Controls.SetChildIndex(this._btnComponente, 0);
            this.Controls.SetChildIndex(this._txtComponente, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl4, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox1, 0);
            this.Controls.SetChildIndex(this._txtPotDesc, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl18, 0);
            this.Controls.SetChildIndex(this._lblIndisponibilidad, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl19, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl20, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl23, 0);
            this.Controls.SetChildIndex(this._lblTiempoSisIndisponibilidad, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl27, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl26, 0);
            this.Controls.SetChildIndex(this._lblTotalSistemaPrecon, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl31, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl30, 0);
            this.Controls.SetChildIndex(this._lblTotalSistemaConex, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl22, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl34, 0);
            this.Controls.SetChildIndex(this._lblTotalSistemaAsig, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl1, 0);
            this.Controls.SetChildIndex(this._txtFecHoraFalla, 0);
            this.Controls.SetChildIndex(this._txtTotalIndis, 0);
            this.Controls.SetChildIndex(this._txtTotalPrecon, 0);
            this.Controls.SetChildIndex(this._txtTotalConex, 0);
            this.Controls.SetChildIndex(this.cndcLabelControl3, 0);
            this.Controls.SetChildIndex(this._lblTotalTiempoDesc, 0);
            this.Controls.SetChildIndex(this._dgvIndisponibilidad, 0);
            this.Controls.SetChildIndex(this._dgvPreconexion, 0);
            this.Controls.SetChildIndex(this._dgvConexion, 0);
            this.Controls.SetChildIndex(this._dgvAsignacion, 0);
            this.Controls.SetChildIndex(this.cndcGroupBox2, 0);
            this.cndcGroupBox1.ResumeLayout(false);
            this.cndcGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndisponibilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPreconexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvConexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAsignacion)).EndInit();
            this.cndcGroupBox2.ResumeLayout(false);
            this.cndcGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCButton _btnComponente;
        private Controles.CNDCTextBox _txtComponente;
        private Controles.CNDCLabel cndcLabelControl4;
        private Controles.CNDCGroupBox cndcGroupBox1;
        private Controles.CNDCRadioButton _rbtPositivo;
        private Controles.CNDCRadioButton _rbtNegativo;
        private Controles.CNDCTextBox _txtPotDesc;
        private Controles.CNDCLabel _lblTotalSistemaConex;
        private Controles.CNDCLabel cndcLabelControl30;
        private Controles.CNDCLabel cndcLabelControl31;
        private Controles.CNDCLabel _lblTotalSistemaPrecon;
        private Controles.CNDCLabel cndcLabelControl26;
        private Controles.CNDCLabel cndcLabelControl27;
        private Controles.CNDCLabel _lblTiempoSisIndisponibilidad;
        private Controles.CNDCLabel cndcLabelControl23;
        private Controles.CNDCLabel cndcLabelControl20;
        private Controles.CNDCLabel cndcLabelControl19;
        private Controles.CNDCLabel _lblIndisponibilidad;
        private Controles.CNDCLabel cndcLabelControl18;
        private Controles.CNDCLabel _lblTotalSistemaAsig;
        private Controles.CNDCLabel cndcLabelControl34;
        private Controles.CNDCLabel cndcLabelControl22;
        private Controles.CNDCTextBox _txtFecHoraFalla;
        private Controles.CNDCLabel cndcLabelControl1;
        private Controles.CNDCTextBox _txtTotalIndis;
        private Controles.CNDCTextBox _txtTotalPrecon;
        private Controles.CNDCTextBox _txtTotalConex;
        private Controles.CNDCLabel cndcLabelControl3;
        private Controles.CNDCLabel _lblTotalTiempoDesc;
        private Controles.CNDCGridView _dgvIndisponibilidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTiempo;
        private Controles.CNDCGridView _dgvPreconexion;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Controles.CNDCGridView _dgvConexion;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Controles.CNDCGridView _dgvAsignacion;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Controles.CNDCGroupBox cndcGroupBox2;
        private Controles.CNDCRadioButton cndcRadioButton2;
        private Controles.CNDCRadioButton _;
    }
}