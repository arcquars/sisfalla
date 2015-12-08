namespace Proyectos
{
    partial class CtrlSelectorHojaDocExcel
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
            this._cmbHoja = new Controles.CNDCComboBox();
            this.cndcLabel6 = new Controles.CNDCLabel();
            this._btnDocumento = new Controles.CNDCButton();
            this._txtDocumento = new Controles.CNDCTextBox();
            this._lblDocumento = new Controles.CNDCLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmbHoja
            // 
            this._cmbHoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbHoja.EnterComoTab = false;
            this._cmbHoja.Etiqueta = null;
            this._cmbHoja.FormattingEnabled = true;
            this._cmbHoja.Location = new System.Drawing.Point(79, 26);
            this._cmbHoja.Name = "_cmbHoja";
            this._cmbHoja.Size = new System.Drawing.Size(186, 21);
            this._cmbHoja.TabIndex = 33;
            this._cmbHoja.TablaCampoBD = null;
            // 
            // cndcLabel6
            // 
            this.cndcLabel6.AutoSize = true;
            this.cndcLabel6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.cndcLabel6.Location = new System.Drawing.Point(40, 26);
            this.cndcLabel6.Name = "cndcLabel6";
            this.cndcLabel6.Size = new System.Drawing.Size(36, 16);
            this.cndcLabel6.TabIndex = 32;
            this.cndcLabel6.TablaCampoBD = null;
            this.cndcLabel6.Text = "Hoja:";
            // 
            // _btnDocumento
            // 
            this._btnDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnDocumento.Location = new System.Drawing.Point(366, 1);
            this._btnDocumento.Name = "_btnDocumento";
            this._btnDocumento.Size = new System.Drawing.Size(75, 24);
            this._btnDocumento.TabIndex = 31;
            this._btnDocumento.TablaCampoBD = null;
            this._btnDocumento.Text = "Examinar";
            this._btnDocumento.UseVisualStyleBackColor = true;
            this._btnDocumento.Click += new System.EventHandler(this._btnDocumento_Click);
            // 
            // _txtDocumento
            // 
            this._txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDocumento.BackColor = System.Drawing.Color.Gainsboro;
            this._txtDocumento.EnterComoTab = false;
            this._txtDocumento.Etiqueta = null;
            this._txtDocumento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDocumento.Location = new System.Drawing.Point(79, 2);
            this._txtDocumento.Name = "_txtDocumento";
            this._txtDocumento.ReadOnly = true;
            this._txtDocumento.Size = new System.Drawing.Size(285, 22);
            this._txtDocumento.TabIndex = 30;
            this._txtDocumento.TablaCampoBD = "";
            // 
            // _lblDocumento
            // 
            this._lblDocumento.AutoSize = true;
            this._lblDocumento.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this._lblDocumento.Location = new System.Drawing.Point(3, 4);
            this._lblDocumento.Name = "_lblDocumento";
            this._lblDocumento.Size = new System.Drawing.Size(73, 16);
            this._lblDocumento.TabIndex = 29;
            this._lblDocumento.TablaCampoBD = null;
            this._lblDocumento.Text = "Documento:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // CtrlSelectorHojaDocExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cmbHoja);
            this.Controls.Add(this.cndcLabel6);
            this.Controls.Add(this._btnDocumento);
            this.Controls.Add(this._txtDocumento);
            this.Controls.Add(this._lblDocumento);
            this.Name = "CtrlSelectorHojaDocExcel";
            this.Size = new System.Drawing.Size(444, 48);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbHoja;
        private Controles.CNDCLabel cndcLabel6;
        private Controles.CNDCButton _btnDocumento;
        private Controles.CNDCTextBox _txtDocumento;
        private Controles.CNDCLabel _lblDocumento;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}
