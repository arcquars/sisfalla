namespace WF_EstresServicioSisFalla
{
    partial class CtrlEnvioInforme
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._timerEnvio = new System.Windows.Forms.Timer(this.components);
            this._pnlArriba = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this._lblFallasInvolucradas = new System.Windows.Forms.Label();
            this._btnIniciar = new System.Windows.Forms.Button();
            this._pnlAbajo = new System.Windows.Forms.Panel();
            this._pnlCentro = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._lblPromedio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblMinimo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblMaximo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lblCantEnvios = new System.Windows.Forms.Label();
            this._dgvEnvios = new System.Windows.Forms.DataGridView();
            this._bgWorker = new System.ComponentModel.BackgroundWorker();
            this._pnlArriba.SuspendLayout();
            this._pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEnvios)).BeginInit();
            this.SuspendLayout();
            // 
            // _timerEnvio
            // 
            this._timerEnvio.Interval = 500;
            this._timerEnvio.Tick += new System.EventHandler(this._timerEnvio_Tick);
            // 
            // _pnlArriba
            // 
            this._pnlArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlArriba.Controls.Add(this.label5);
            this._pnlArriba.Controls.Add(this._lblFallasInvolucradas);
            this._pnlArriba.Controls.Add(this._btnIniciar);
            this._pnlArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlArriba.Location = new System.Drawing.Point(0, 0);
            this._pnlArriba.Name = "_pnlArriba";
            this._pnlArriba.Size = new System.Drawing.Size(712, 35);
            this._pnlArriba.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fallas involucradas:";
            // 
            // _lblFallasInvolucradas
            // 
            this._lblFallasInvolucradas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblFallasInvolucradas.Location = new System.Drawing.Point(244, 3);
            this._lblFallasInvolucradas.Name = "_lblFallasInvolucradas";
            this._lblFallasInvolucradas.Size = new System.Drawing.Size(55, 23);
            this._lblFallasInvolucradas.TabIndex = 10;
            this._lblFallasInvolucradas.Text = "0";
            this._lblFallasInvolucradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _btnIniciar
            // 
            this._btnIniciar.Location = new System.Drawing.Point(2, 3);
            this._btnIniciar.Name = "_btnIniciar";
            this._btnIniciar.Size = new System.Drawing.Size(75, 23);
            this._btnIniciar.TabIndex = 0;
            this._btnIniciar.Text = "Iniciar";
            this._btnIniciar.UseVisualStyleBackColor = true;
            this._btnIniciar.Click += new System.EventHandler(this._btnIniciar_Click);
            // 
            // _pnlAbajo
            // 
            this._pnlAbajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnlAbajo.Location = new System.Drawing.Point(0, 448);
            this._pnlAbajo.Name = "_pnlAbajo";
            this._pnlAbajo.Size = new System.Drawing.Size(712, 30);
            this._pnlAbajo.TabIndex = 1;
            // 
            // _pnlCentro
            // 
            this._pnlCentro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlCentro.Controls.Add(this.label3);
            this._pnlCentro.Controls.Add(this._lblPromedio);
            this._pnlCentro.Controls.Add(this.label4);
            this._pnlCentro.Controls.Add(this._lblMinimo);
            this._pnlCentro.Controls.Add(this.label2);
            this._pnlCentro.Controls.Add(this._lblMaximo);
            this._pnlCentro.Controls.Add(this.label1);
            this._pnlCentro.Controls.Add(this._lblCantEnvios);
            this._pnlCentro.Controls.Add(this._dgvEnvios);
            this._pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlCentro.Location = new System.Drawing.Point(0, 35);
            this._pnlCentro.Name = "_pnlCentro";
            this._pnlCentro.Size = new System.Drawing.Size(712, 413);
            this._pnlCentro.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Promedio:";
            // 
            // _lblPromedio
            // 
            this._lblPromedio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblPromedio.Location = new System.Drawing.Point(84, 362);
            this._lblPromedio.Name = "_lblPromedio";
            this._lblPromedio.Size = new System.Drawing.Size(110, 23);
            this._lblPromedio.TabIndex = 10;
            this._lblPromedio.Text = "0";
            this._lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mínimo:";
            // 
            // _lblMinimo
            // 
            this._lblMinimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblMinimo.Location = new System.Drawing.Point(84, 313);
            this._lblMinimo.Name = "_lblMinimo";
            this._lblMinimo.Size = new System.Drawing.Size(110, 23);
            this._lblMinimo.TabIndex = 8;
            this._lblMinimo.Text = "0";
            this._lblMinimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Máximo:";
            // 
            // _lblMaximo
            // 
            this._lblMaximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblMaximo.Location = new System.Drawing.Point(84, 338);
            this._lblMaximo.Name = "_lblMaximo";
            this._lblMaximo.Size = new System.Drawing.Size(110, 23);
            this._lblMaximo.TabIndex = 6;
            this._lblMaximo.Text = "0";
            this._lblMaximo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cant. Envios:";
            // 
            // _lblCantEnvios
            // 
            this._lblCantEnvios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblCantEnvios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblCantEnvios.Location = new System.Drawing.Point(84, 289);
            this._lblCantEnvios.Name = "_lblCantEnvios";
            this._lblCantEnvios.Size = new System.Drawing.Size(50, 23);
            this._lblCantEnvios.TabIndex = 4;
            this._lblCantEnvios.Text = "0";
            this._lblCantEnvios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dgvEnvios
            // 
            this._dgvEnvios.AllowUserToAddRows = false;
            this._dgvEnvios.AllowUserToDeleteRows = false;
            this._dgvEnvios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEnvios.Location = new System.Drawing.Point(4, 5);
            this._dgvEnvios.Name = "_dgvEnvios";
            this._dgvEnvios.ReadOnly = true;
            this._dgvEnvios.Size = new System.Drawing.Size(701, 277);
            this._dgvEnvios.TabIndex = 0;
            // 
            // _bgWorker
            // 
            this._bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bgWorker_DoWork);
            this._bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bgWorker_RunWorkerCompleted);
            // 
            // CtrlEnvioInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pnlCentro);
            this.Controls.Add(this._pnlAbajo);
            this.Controls.Add(this._pnlArriba);
            this.Name = "CtrlEnvioInforme";
            this.Size = new System.Drawing.Size(712, 478);
            this._pnlArriba.ResumeLayout(false);
            this._pnlArriba.PerformLayout();
            this._pnlCentro.ResumeLayout(false);
            this._pnlCentro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEnvios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _timerEnvio;
        private System.Windows.Forms.Panel _pnlArriba;
        private System.Windows.Forms.Button _btnIniciar;
        private System.Windows.Forms.Panel _pnlAbajo;
        private System.Windows.Forms.Panel _pnlCentro;
        private System.Windows.Forms.DataGridView _dgvEnvios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblCantEnvios;
        private System.ComponentModel.BackgroundWorker _bgWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblMinimo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblMaximo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lblPromedio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblFallasInvolucradas;
    }
}
