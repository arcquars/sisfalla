namespace MedicionComercialUI
{
    partial class CtrlLecturaMedidor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._txtNombreMedidor = new Controles.CNDCTextBox();
            this._txtDescripcion = new Controles.CNDCTextBox();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtArchivosPrevistos = new Controles.CNDCTextBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._txtArchivosEncontrados = new Controles.CNDCTextBox();
            this._dgvDatos = new Controles.CNDCGridView();
            this._chbxSeleccionado = new Controles.CNDCCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtNombreMedidor
            // 
            this._txtNombreMedidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNombreMedidor.EnterComoTab = false;
            this._txtNombreMedidor.Etiqueta = null;
            this._txtNombreMedidor.Location = new System.Drawing.Point(68, 3);
            this._txtNombreMedidor.Name = "_txtNombreMedidor";
            this._txtNombreMedidor.Size = new System.Drawing.Size(63, 20);
            this._txtNombreMedidor.TabIndex = 1;
            this._txtNombreMedidor.TablaCampoBD = null;
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtDescripcion.EnterComoTab = false;
            this._txtDescripcion.Etiqueta = null;
            this._txtDescripcion.Location = new System.Drawing.Point(137, 3);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(199, 20);
            this._txtDescripcion.TabIndex = 3;
            this._txtDescripcion.TablaCampoBD = null;
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(34, 26);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(97, 13);
            this.cndcLabel3.TabIndex = 4;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Archivos Previstos:";
            // 
            // _txtArchivosPrevistos
            // 
            this._txtArchivosPrevistos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtArchivosPrevistos.EnterComoTab = false;
            this._txtArchivosPrevistos.Etiqueta = null;
            this._txtArchivosPrevistos.Location = new System.Drawing.Point(137, 24);
            this._txtArchivosPrevistos.Name = "_txtArchivosPrevistos";
            this._txtArchivosPrevistos.Size = new System.Drawing.Size(47, 20);
            this._txtArchivosPrevistos.TabIndex = 5;
            this._txtArchivosPrevistos.TablaCampoBD = null;
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(213, 27);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(70, 13);
            this.cndcLabel4.TabIndex = 6;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Encontrados:";
            // 
            // _txtArchivosEncontrados
            // 
            this._txtArchivosEncontrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtArchivosEncontrados.EnterComoTab = false;
            this._txtArchivosEncontrados.Etiqueta = null;
            this._txtArchivosEncontrados.Location = new System.Drawing.Point(289, 24);
            this._txtArchivosEncontrados.Name = "_txtArchivosEncontrados";
            this._txtArchivosEncontrados.Size = new System.Drawing.Size(47, 20);
            this._txtArchivosEncontrados.TabIndex = 7;
            this._txtArchivosEncontrados.TablaCampoBD = null;
            // 
            // _dgvDatos
            // 
            this._dgvDatos.AllowUserToAddRows = false;
            this._dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this._dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this._dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(242)))));
            this._dgvDatos.Location = new System.Drawing.Point(343, 2);
            this._dgvDatos.Name = "_dgvDatos";
            this._dgvDatos.NombreContenedor = "CtrlLecturaMedidor";
            this._dgvDatos.ReadOnly = true;
            this._dgvDatos.RowHeadersVisible = false;
            this._dgvDatos.RowHeadersWidth = 25;
            this._dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dgvDatos.Size = new System.Drawing.Size(443, 42);
            this._dgvDatos.TabIndex = 8;
            this._dgvDatos.TablaCampoBD = null;
            // 
            // _chbxSeleccionado
            // 
            this._chbxSeleccionado.AutoSize = true;
            this._chbxSeleccionado.Checked = true;
            this._chbxSeleccionado.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chbxSeleccionado.Location = new System.Drawing.Point(3, 4);
            this._chbxSeleccionado.Name = "_chbxSeleccionado";
            this._chbxSeleccionado.Size = new System.Drawing.Size(64, 17);
            this._chbxSeleccionado.TabIndex = 9;
            this._chbxSeleccionado.TablaCampoBD = null;
            this._chbxSeleccionado.Text = "Medidor";
            this._chbxSeleccionado.UseVisualStyleBackColor = true;
            this._chbxSeleccionado.Click += new System.EventHandler(this._chbxSeleccionado_Click);
            // 
            // CtrlLecturaMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._chbxSeleccionado);
            this.Controls.Add(this._dgvDatos);
            this.Controls.Add(this._txtArchivosEncontrados);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this._txtArchivosPrevistos);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this._txtNombreMedidor);
            this.Name = "CtrlLecturaMedidor";
            this.Size = new System.Drawing.Size(791, 49);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCTextBox _txtNombreMedidor;
        private Controles.CNDCTextBox _txtDescripcion;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtArchivosPrevistos;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCTextBox _txtArchivosEncontrados;
        private Controles.CNDCGridView _dgvDatos;
        private Controles.CNDCCheckBox _chbxSeleccionado;
    }
}
