namespace MedicionComercialUI
{
    partial class CtrlDefCanal
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
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._txtNombre = new Controles.CNDCTextBox();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._txtUnidades = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtEstado = new Controles.CNDCTextBox();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(34, 6);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(47, 13);
            this.cndcLabel1.TabIndex = 0;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Nombre:";
            // 
            // _txtNombre
            // 
            this._txtNombre.EnterComoTab = false;
            this._txtNombre.Etiqueta = null;
            this._txtNombre.Location = new System.Drawing.Point(81, 3);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(284, 20);
            this._txtNombre.TabIndex = 1;
            this._txtNombre.TablaCampoBD = null;
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(81, 24);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(284, 52);
            this._txtDescripcion.TabIndex = 3;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(15, 27);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(66, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Descripción:";
            // 
            // _txtUnidades
            // 
            this._txtUnidades.EnterComoTab = false;
            this._txtUnidades.Etiqueta = null;
            this._txtUnidades.Location = new System.Drawing.Point(81, 77);
            this._txtUnidades.Name = "_txtUnidades";
            this._txtUnidades.Size = new System.Drawing.Size(164, 20);
            this._txtUnidades.TabIndex = 5;
            this._txtUnidades.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(26, 80);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(55, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Unidades:";
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(38, 101);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(43, 13);
            this.cndcLabel4.TabIndex = 6;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Estado:";
            // 
            // _txtEstado
            // 
            this._txtEstado.EnterComoTab = false;
            this._txtEstado.Etiqueta = null;
            this._txtEstado.Location = new System.Drawing.Point(81, 98);
            this._txtEstado.Name = "_txtEstado";
            this._txtEstado.Size = new System.Drawing.Size(100, 20);
            this._txtEstado.TabIndex = 7;
            this._txtEstado.TablaCampoBD = null;
            // 
            // CtrlDefCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtEstado);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._txtUnidades);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "CtrlDefCanal";
            this.Size = new System.Drawing.Size(389, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCTextBox _txtNombre;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCTextBox _txtUnidades;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBox _txtEstado;
    }
}
