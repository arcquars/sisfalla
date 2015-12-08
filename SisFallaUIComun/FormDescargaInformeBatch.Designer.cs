namespace SISFALLA
{
    partial class FormDescargaInformeBatch
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
            this._cmbRegistrosFallaInicio = new Controles.CNDCComboBox();
            this.cndcLabel1 = new Controles.CNDCLabel();
            this._cmbRegistrosFallaFin = new Controles.CNDCComboBox();
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._btnCancelar = new Controles.CNDCButton();
            this._btnDecargar = new Controles.CNDCButton();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._cmbGestiones = new Controles.CNDCComboBox();
            this.cndcLabel4 = new Controles.CNDCLabel();
            this._cbTodos = new Controles.CNDCCheckBox();
            this.SuspendLayout();
            // 
            // _cmbRegistrosFallaInicio
            // 
            this._cmbRegistrosFallaInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRegistrosFallaInicio.EnterComoTab = false;
            this._cmbRegistrosFallaInicio.Etiqueta = null;
            this._cmbRegistrosFallaInicio.FormattingEnabled = true;
            this._cmbRegistrosFallaInicio.Location = new System.Drawing.Point(134, 33);
            this._cmbRegistrosFallaInicio.Name = "_cmbRegistrosFallaInicio";
            this._cmbRegistrosFallaInicio.Size = new System.Drawing.Size(121, 21);
            this._cmbRegistrosFallaInicio.TabIndex = 3;
            this._cmbRegistrosFallaInicio.TablaCampoBD = null;
            this._cmbRegistrosFallaInicio.SelectedIndexChanged += new System.EventHandler(this._cmbRegistrosFallaInicio_SelectedIndexChanged);
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(16, 36);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(115, 13);
            this.cndcLabel1.TabIndex = 2;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Número de Falla Inicio:";
            // 
            // _cmbRegistrosFallaFin
            // 
            this._cmbRegistrosFallaFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRegistrosFallaFin.EnterComoTab = false;
            this._cmbRegistrosFallaFin.Etiqueta = null;
            this._cmbRegistrosFallaFin.FormattingEnabled = true;
            this._cmbRegistrosFallaFin.Location = new System.Drawing.Point(134, 60);
            this._cmbRegistrosFallaFin.Name = "_cmbRegistrosFallaFin";
            this._cmbRegistrosFallaFin.Size = new System.Drawing.Size(121, 21);
            this._cmbRegistrosFallaFin.TabIndex = 5;
            this._cmbRegistrosFallaFin.TablaCampoBD = null;
            this._cmbRegistrosFallaFin.SelectedIndexChanged += new System.EventHandler(this._cmbRegistrosFallaFin_SelectedIndexChanged);
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(16, 63);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(104, 13);
            this.cndcLabel2.TabIndex = 4;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Número de Falla Fin:";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancelar.Location = new System.Drawing.Point(235, 116);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 7;
            this._btnCancelar.TablaCampoBD = null;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            // 
            // _btnDecargar
            // 
            this._btnDecargar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnDecargar.Location = new System.Drawing.Point(149, 116);
            this._btnDecargar.Name = "_btnDecargar";
            this._btnDecargar.Size = new System.Drawing.Size(75, 23);
            this._btnDecargar.TabIndex = 6;
            this._btnDecargar.TablaCampoBD = null;
            this._btnDecargar.Text = "Descargar";
            this._btnDecargar.UseVisualStyleBackColor = true;
            this._btnDecargar.Click += new System.EventHandler(this._btnDecargar_Click);
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(1, 101);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(10, 13);
            this.cndcLabel3.TabIndex = 8;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = ".";
            // 
            // _cmbGestiones
            // 
            this._cmbGestiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbGestiones.EnterComoTab = false;
            this._cmbGestiones.Etiqueta = null;
            this._cmbGestiones.FormattingEnabled = true;
            this._cmbGestiones.Location = new System.Drawing.Point(134, 6);
            this._cmbGestiones.Name = "_cmbGestiones";
            this._cmbGestiones.Size = new System.Drawing.Size(121, 21);
            this._cmbGestiones.TabIndex = 10;
            this._cmbGestiones.TablaCampoBD = null;
            this._cmbGestiones.SelectedIndexChanged += new System.EventHandler(this._cmbGestiones_SelectedIndexChanged);
            // 
            // cndcLabel4
            // 
            this.cndcLabel4.AutoSize = true;
            this.cndcLabel4.Location = new System.Drawing.Point(16, 9);
            this.cndcLabel4.Name = "cndcLabel4";
            this.cndcLabel4.Size = new System.Drawing.Size(46, 13);
            this.cndcLabel4.TabIndex = 9;
            this.cndcLabel4.TablaCampoBD = null;
            this.cndcLabel4.Text = "Gestión:";
            // 
            // _cbTodos
            // 
            this._cbTodos.AutoSize = true;
            this._cbTodos.Location = new System.Drawing.Point(272, 9);
            this._cbTodos.Name = "_cbTodos";
            this._cbTodos.Size = new System.Drawing.Size(56, 17);
            this._cbTodos.TabIndex = 11;
            this._cbTodos.TablaCampoBD = null;
            this._cbTodos.Text = "Todos";
            this._cbTodos.UseVisualStyleBackColor = true;
            this._cbTodos.CheckedChanged += new System.EventHandler(this._cbTodos_CheckedChanged);
            // 
            // FormDescargaInformeBatch
            // 
            this.AcceptButton = this._btnDecargar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(340, 144);
            this.Controls.Add(this._cbTodos);
            this.Controls.Add(this._cmbGestiones);
            this.Controls.Add(this.cndcLabel4);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnDecargar);
            this.Controls.Add(this._cmbRegistrosFallaFin);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this._cmbRegistrosFallaInicio);
            this.Controls.Add(this.cndcLabel1);
            this.Name = "FormDescargaInformeBatch";
            this.Text = "Descarga de Informes de Falla";
            this.Load += new System.EventHandler(this.FormDescargaInformeBatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.CNDCComboBox _cmbRegistrosFallaInicio;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCComboBox _cmbRegistrosFallaFin;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCButton _btnCancelar;
        private Controles.CNDCButton _btnDecargar;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCComboBox _cmbGestiones;
        private Controles.CNDCLabel cndcLabel4;
        private Controles.CNDCCheckBox _cbTodos;
    }
}