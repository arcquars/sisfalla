namespace SISFALLA
{
    partial class CtrlComponente
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
            this._txtDescComponente = new Controles.CNDCTextBox();
            this._txtNombreComponente = new Controles.CNDCTextBox();
            this._btnSeleccionarComponente = new Controles.CNDCButton();
            this._txtAgente = new Controles.CNDCTextBox();
            this.SuspendLayout();
            // 
            // _txtDescComponente
            // 
            this._txtDescComponente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescComponente.BackColor = System.Drawing.Color.White;
            this._txtDescComponente.EnterComoTab = true;
            this._txtDescComponente.Etiqueta = null;
            this._txtDescComponente.ForeColor = System.Drawing.Color.Black;
            this._txtDescComponente.Location = new System.Drawing.Point(231, 0);
            this._txtDescComponente.Name = "_txtDescComponente";
            this._txtDescComponente.ReadOnly = true;
            this._txtDescComponente.Size = new System.Drawing.Size(248, 20);
            this._txtDescComponente.TabIndex = 2;
            this._txtDescComponente.TablaCampoBD = "F_AC_COMPONENTE.DESCRIPCION_COMPONENTE";
            this._txtDescComponente.DoubleClick += new System.EventHandler(this._btnSeleccionarComponente_Click);
            // 
            // _txtNombreComponente
            // 
            this._txtNombreComponente.BackColor = System.Drawing.Color.White;
            this._txtNombreComponente.EnterComoTab = true;
            this._txtNombreComponente.Etiqueta = null;
            this._txtNombreComponente.ForeColor = System.Drawing.Color.Black;
            this._txtNombreComponente.Location = new System.Drawing.Point(147, 0);
            this._txtNombreComponente.Name = "_txtNombreComponente";
            this._txtNombreComponente.ReadOnly = true;
            this._txtNombreComponente.Size = new System.Drawing.Size(84, 20);
            this._txtNombreComponente.TabIndex = 1;
            this._txtNombreComponente.TablaCampoBD = "F_AC_COMPONENTE.NOMBRE_COMPONENTE";
            this._txtNombreComponente.DoubleClick += new System.EventHandler(this._btnSeleccionarComponente_Click);
            // 
            // _btnSeleccionarComponente
            // 
            this._btnSeleccionarComponente.Location = new System.Drawing.Point(0, 0);
            this._btnSeleccionarComponente.Margin = new System.Windows.Forms.Padding(0);
            this._btnSeleccionarComponente.Name = "_btnSeleccionarComponente";
            this._btnSeleccionarComponente.Size = new System.Drawing.Size(145, 21);
            this._btnSeleccionarComponente.TabIndex = 0;
            this._btnSeleccionarComponente.TablaCampoBD = null;
            this._btnSeleccionarComponente.Text = "Componente Comprometido";
            this._btnSeleccionarComponente.UseVisualStyleBackColor = true;
            this._btnSeleccionarComponente.Click += new System.EventHandler(this._btnSeleccionarComponente_Click);
            // 
            // _txtAgente
            // 
            this._txtAgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAgente.BackColor = System.Drawing.Color.White;
            this._txtAgente.EnterComoTab = true;
            this._txtAgente.Etiqueta = null;
            this._txtAgente.ForeColor = System.Drawing.Color.Black;
            this._txtAgente.Location = new System.Drawing.Point(479, 0);
            this._txtAgente.Name = "_txtAgente";
            this._txtAgente.ReadOnly = true;
            this._txtAgente.Size = new System.Drawing.Size(228, 20);
            this._txtAgente.TabIndex = 3;
            this._txtAgente.TablaCampoBD = "F_AC_COMPONENTE.PROPIETARIO";
            this._txtAgente.DoubleClick += new System.EventHandler(this._btnSeleccionarComponente_Click);
            // 
            // CtrlComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtAgente);
            this.Controls.Add(this._btnSeleccionarComponente);
            this.Controls.Add(this._txtDescComponente);
            this.Controls.Add(this._txtNombreComponente);
            this.Name = "CtrlComponente";
            this.Size = new System.Drawing.Size(708, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtDescComponente;
        private Controles.CNDCTextBox _txtNombreComponente;
        private Controles.CNDCButton _btnSeleccionarComponente;
        private Controles.CNDCTextBox _txtAgente;
    }
}
