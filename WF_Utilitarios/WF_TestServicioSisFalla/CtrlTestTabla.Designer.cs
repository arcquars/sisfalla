namespace WF_TestServicioSisFalla
{
    partial class CtrlTestTabla
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
            this.label1 = new System.Windows.Forms.Label();
            this._lblTabla = new System.Windows.Forms.Label();
            this._dgvDatos = new System.Windows.Forms.DataGridView();
            this._btnIniciar = new System.Windows.Forms.Button();
            this._btnSiguiente = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this._lblSolicitudes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lblHoraCNDC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblMinimo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._lblMaximo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._lblPromedio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla:";
            // 
            // _lblTabla
            // 
            this._lblTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblTabla.Location = new System.Drawing.Point(209, 14);
            this._lblTabla.Name = "_lblTabla";
            this._lblTabla.Size = new System.Drawing.Size(392, 23);
            this._lblTabla.TabIndex = 1;
            this._lblTabla.Text = "label2";
            this._lblTabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            this._dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDatos.Location = new System.Drawing.Point(11, 40);
            this._dgvDatos.Name = "_dgvDatos";
            this._dgvDatos.ReadOnly = true;
            this._dgvDatos.Size = new System.Drawing.Size(783, 343);
            this._dgvDatos.TabIndex = 2;
            // 
            // _btnIniciar
            // 
            this._btnIniciar.Location = new System.Drawing.Point(87, 14);
            this._btnIniciar.Name = "_btnIniciar";
            this._btnIniciar.Size = new System.Drawing.Size(75, 23);
            this._btnIniciar.TabIndex = 3;
            this._btnIniciar.Text = "Iniciar";
            this._btnIniciar.UseVisualStyleBackColor = true;
            this._btnIniciar.Click += new System.EventHandler(this._btnIniciar_Click);
            // 
            // _btnSiguiente
            // 
            this._btnSiguiente.Location = new System.Drawing.Point(607, 14);
            this._btnSiguiente.Name = "_btnSiguiente";
            this._btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this._btnSiguiente.TabIndex = 4;
            this._btnSiguiente.Text = "Siguiente>>";
            this._btnSiguiente.UseVisualStyleBackColor = true;
            this._btnSiguiente.Click += new System.EventHandler(this._btnSiguiente_Click);
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _dgvSolicitudes
            // 
            this._dgvSolicitudes.AllowUserToAddRows = false;
            this._dgvSolicitudes.AllowUserToDeleteRows = false;
            this._dgvSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSolicitudes.Location = new System.Drawing.Point(11, 389);
            this._dgvSolicitudes.Name = "_dgvSolicitudes";
            this._dgvSolicitudes.ReadOnly = true;
            this._dgvSolicitudes.Size = new System.Drawing.Size(559, 122);
            this._dgvSolicitudes.TabIndex = 5;
            // 
            // _lblSolicitudes
            // 
            this._lblSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSolicitudes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblSolicitudes.Location = new System.Drawing.Point(686, 393);
            this._lblSolicitudes.Name = "_lblSolicitudes";
            this._lblSolicitudes.Size = new System.Drawing.Size(109, 23);
            this._lblSolicitudes.TabIndex = 7;
            this._lblSolicitudes.Text = "label2";
            this._lblSolicitudes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad. Solicitudes:";
            // 
            // _lblHoraCNDC
            // 
            this._lblHoraCNDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblHoraCNDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblHoraCNDC.Location = new System.Drawing.Point(686, 419);
            this._lblHoraCNDC.Name = "_lblHoraCNDC";
            this._lblHoraCNDC.Size = new System.Drawing.Size(109, 23);
            this._lblHoraCNDC.TabIndex = 9;
            this._lblHoraCNDC.Text = "label2";
            this._lblHoraCNDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hora CNDC:";
            // 
            // _lblMinimo
            // 
            this._lblMinimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblMinimo.Location = new System.Drawing.Point(686, 470);
            this._lblMinimo.Name = "_lblMinimo";
            this._lblMinimo.Size = new System.Drawing.Size(109, 23);
            this._lblMinimo.TabIndex = 13;
            this._lblMinimo.Text = "label2";
            this._lblMinimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Minimo:";
            // 
            // _lblMaximo
            // 
            this._lblMaximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblMaximo.Location = new System.Drawing.Point(686, 444);
            this._lblMaximo.Name = "_lblMaximo";
            this._lblMaximo.Size = new System.Drawing.Size(109, 23);
            this._lblMaximo.TabIndex = 11;
            this._lblMaximo.Text = "label2";
            this._lblMaximo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Maximo:";
            // 
            // _lblPromedio
            // 
            this._lblPromedio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblPromedio.Location = new System.Drawing.Point(686, 495);
            this._lblPromedio.Name = "_lblPromedio";
            this._lblPromedio.Size = new System.Drawing.Size(109, 23);
            this._lblPromedio.TabIndex = 15;
            this._lblPromedio.Text = "label8";
            this._lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(575, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Promedio:";
            // 
            // CtrlTestTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._lblPromedio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._lblMinimo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._lblMaximo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._lblHoraCNDC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._lblSolicitudes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._dgvSolicitudes);
            this.Controls.Add(this._btnSiguiente);
            this.Controls.Add(this._btnIniciar);
            this.Controls.Add(this._dgvDatos);
            this.Controls.Add(this._lblTabla);
            this.Controls.Add(this.label1);
            this.Name = "CtrlTestTabla";
            this.Size = new System.Drawing.Size(807, 526);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblTabla;
        private System.Windows.Forms.DataGridView _dgvDatos;
        private System.Windows.Forms.Button _btnIniciar;
        private System.Windows.Forms.Button _btnSiguiente;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.DataGridView _dgvSolicitudes;
        private System.Windows.Forms.Label _lblSolicitudes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lblHoraCNDC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblMinimo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblMaximo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _lblPromedio;
        private System.Windows.Forms.Label label9;
    }
}
