namespace SISFALLA
{
    partial class FormAgentesNotificar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._btnAceptar = new Controles.CNDCButton();
            this._btnQuitar = new Controles.CNDCButton();
            this._btnAdicionar = new Controles.CNDCButton();
            this._dgvAgentesANotificar = new Controles.CNDCGridView();
            this._dgvAgentesDisponibles = new Controles.CNDCGridView();
            this._lblMensajeLista2 = new Controles.CNDCLabel();
            this._lblMensajeLista1 = new Controles.CNDCLabel();
            this._lblAgentesYaNotificados = new Controles.CNDCLabel();
            this._lblAgentesPorNotificar = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesANotificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(625, 321);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(132, 35);
            this._btnAceptar.TabIndex = 10;
            this._btnAceptar.TablaCampoBD = null;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _btnQuitar
            // 
            this._btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnQuitar.Location = new System.Drawing.Point(364, 165);
            this._btnQuitar.Name = "_btnQuitar";
            this._btnQuitar.Size = new System.Drawing.Size(32, 26);
            this._btnQuitar.TabIndex = 9;
            this._btnQuitar.TablaCampoBD = null;
            this._btnQuitar.Text = "<";
            this._btnQuitar.UseVisualStyleBackColor = true;
            this._btnQuitar.Click += new System.EventHandler(this._btnQuitar_Click);
            // 
            // _btnAdicionar
            // 
            this._btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAdicionar.Location = new System.Drawing.Point(364, 133);
            this._btnAdicionar.Name = "_btnAdicionar";
            this._btnAdicionar.Size = new System.Drawing.Size(32, 26);
            this._btnAdicionar.TabIndex = 8;
            this._btnAdicionar.TablaCampoBD = null;
            this._btnAdicionar.Text = ">";
            this._btnAdicionar.UseVisualStyleBackColor = true;
            this._btnAdicionar.Click += new System.EventHandler(this._btnAdicionar_Click);
            // 
            // _dgvAgentesANotificar
            // 
            this._dgvAgentesANotificar.AllowUserToAddRows = false;
            this._dgvAgentesANotificar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentesANotificar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvAgentesANotificar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentesANotificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentesANotificar.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvAgentesANotificar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentesANotificar.Location = new System.Drawing.Point(399, 54);
            this._dgvAgentesANotificar.Name = "_dgvAgentesANotificar";
            this._dgvAgentesANotificar.ReadOnly = true;
            this._dgvAgentesANotificar.RowHeadersWidth = 20;
            this._dgvAgentesANotificar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentesANotificar.Size = new System.Drawing.Size(358, 246);
            this._dgvAgentesANotificar.TabIndex = 7;
            this._dgvAgentesANotificar.TablaCampoBD = null;
            // 
            // _dgvAgentesDisponibles
            // 
            this._dgvAgentesDisponibles.AllowUserToAddRows = false;
            this._dgvAgentesDisponibles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvAgentesDisponibles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvAgentesDisponibles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvAgentesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvAgentesDisponibles.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvAgentesDisponibles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvAgentesDisponibles.Location = new System.Drawing.Point(2, 54);
            this._dgvAgentesDisponibles.Name = "_dgvAgentesDisponibles";
            this._dgvAgentesDisponibles.ReadOnly = true;
            this._dgvAgentesDisponibles.RowHeadersWidth = 20;
            this._dgvAgentesDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentesDisponibles.Size = new System.Drawing.Size(358, 246);
            this._dgvAgentesDisponibles.TabIndex = 6;
            this._dgvAgentesDisponibles.TablaCampoBD = null;
            // 
            // _lblMensajeLista2
            // 
            this._lblMensajeLista2.ForeColor = System.Drawing.Color.Red;
            this._lblMensajeLista2.Location = new System.Drawing.Point(519, 303);
            this._lblMensajeLista2.Name = "_lblMensajeLista2";
            this._lblMensajeLista2.Size = new System.Drawing.Size(238, 13);
            this._lblMensajeLista2.TabIndex = 12;
            this._lblMensajeLista2.TablaCampoBD = null;
            this._lblMensajeLista2.Text = "...";
            this._lblMensajeLista2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblMensajeLista1
            // 
            this._lblMensajeLista1.ForeColor = System.Drawing.Color.Red;
            this._lblMensajeLista1.Location = new System.Drawing.Point(5, 303);
            this._lblMensajeLista1.Name = "_lblMensajeLista1";
            this._lblMensajeLista1.Size = new System.Drawing.Size(238, 13);
            this._lblMensajeLista1.TabIndex = 11;
            this._lblMensajeLista1.TablaCampoBD = null;
            this._lblMensajeLista1.Text = "...";
            this._lblMensajeLista1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblAgentesYaNotificados
            // 
            this._lblAgentesYaNotificados.Location = new System.Drawing.Point(2, 4);
            this._lblAgentesYaNotificados.Name = "_lblAgentesYaNotificados";
            this._lblAgentesYaNotificados.Size = new System.Drawing.Size(358, 41);
            this._lblAgentesYaNotificados.TabIndex = 13;
            this._lblAgentesYaNotificados.TablaCampoBD = null;
            this._lblAgentesYaNotificados.Text = "[...]";
            this._lblAgentesYaNotificados.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // _lblAgentesPorNotificar
            // 
            this._lblAgentesPorNotificar.Location = new System.Drawing.Point(399, 4);
            this._lblAgentesPorNotificar.Name = "_lblAgentesPorNotificar";
            this._lblAgentesPorNotificar.Size = new System.Drawing.Size(358, 41);
            this._lblAgentesPorNotificar.TabIndex = 14;
            this._lblAgentesPorNotificar.TablaCampoBD = null;
            this._lblAgentesPorNotificar.Text = "[...]";
            this._lblAgentesPorNotificar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FormAgentesNotificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 359);
            this.Controls.Add(this._lblAgentesPorNotificar);
            this.Controls.Add(this._lblAgentesYaNotificados);
            this.Controls.Add(this._lblMensajeLista2);
            this.Controls.Add(this._lblMensajeLista1);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._btnQuitar);
            this.Controls.Add(this._btnAdicionar);
            this.Controls.Add(this._dgvAgentesANotificar);
            this.Controls.Add(this._dgvAgentesDisponibles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAgentesNotificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agentes a notificar...";
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesANotificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentesDisponibles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CNDCButton _btnAceptar;
        private Controles.CNDCButton _btnQuitar;
        private Controles.CNDCButton _btnAdicionar;
        private Controles.CNDCGridView _dgvAgentesANotificar;
        private Controles.CNDCGridView _dgvAgentesDisponibles;
        private Controles.CNDCLabel _lblMensajeLista2;
        private Controles.CNDCLabel _lblMensajeLista1;
        private Controles.CNDCLabel _lblAgentesYaNotificados;
        private Controles.CNDCLabel _lblAgentesPorNotificar;
    }
}