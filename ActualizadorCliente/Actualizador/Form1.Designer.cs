namespace Actualizador
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._btnActualizar = new System.Windows.Forms.Button();
            this._pgbActualizacion = new System.Windows.Forms.ProgressBar();
            this._lblActualizando = new System.Windows.Forms.Label();
            this.tbError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnActualizar
            // 
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.Location = new System.Drawing.Point(207, 35);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(75, 23);
            this._btnActualizar.TabIndex = 2;
            this._btnActualizar.Text = "Actualizar";
            this._btnActualizar.UseVisualStyleBackColor = true;
            this._btnActualizar.Click += new System.EventHandler(this._btnActualizar_Click);
            // 
            // _pgbActualizacion
            // 
            this._pgbActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pgbActualizacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this._pgbActualizacion.Location = new System.Drawing.Point(99, 54);
            this._pgbActualizacion.Name = "_pgbActualizacion";
            this._pgbActualizacion.Size = new System.Drawing.Size(194, 20);
            this._pgbActualizacion.TabIndex = 3;
            this._pgbActualizacion.Visible = false;
            // 
            // _lblActualizando
            // 
            this._lblActualizando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblActualizando.AutoSize = true;
            this._lblActualizando.Location = new System.Drawing.Point(12, 58);
            this._lblActualizando.Name = "_lblActualizando";
            this._lblActualizando.Size = new System.Drawing.Size(71, 13);
            this._lblActualizando.TabIndex = 4;
            this._lblActualizando.Text = "Actualizando:";
            this._lblActualizando.Visible = false;
            // 
            // tbError
            // 
            this.tbError.Location = new System.Drawing.Point(-1, 37);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(10, 10);
            this.tbError.TabIndex = 6;
            this.tbError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hay una nueva versión de Sisfalla disponible.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(294, 86);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this._btnActualizar);
            this.Controls.Add(this._lblActualizando);
            this.Controls.Add(this._pgbActualizacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizador...";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.ProgressBar _pgbActualizacion;
        private System.Windows.Forms.Label _lblActualizando;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Label label1;
    }
}

