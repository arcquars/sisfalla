namespace ComponentesUI
{
    partial class CtrlDatosRed
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
            this.cndcLabel2 = new Controles.CNDCLabel();
            this._rbSi = new Controles.CNDCRadioButton();
            this.cndcPanelControl1 = new Controles.CNDCPanelControl();
            this._rbNo = new Controles.CNDCRadioButton();
            this._tSBEditar = new System.Windows.Forms.ToolStripButton();
            this.cndcLabel3 = new Controles.CNDCLabel();
            this._txtReferencia = new Controles.CNDCTextBox();
            this._ctrlDescNodoOrigen = new ComponentesUI.CtrlDescNodo();
            this.cndcPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cndcLabel1
            // 
            this.cndcLabel1.AutoSize = true;
            this.cndcLabel1.Location = new System.Drawing.Point(4, 52);
            this.cndcLabel1.Name = "cndcLabel1";
            this.cndcLabel1.Size = new System.Drawing.Size(95, 13);
            this.cndcLabel1.TabIndex = 1;
            this.cndcLabel1.TablaCampoBD = null;
            this.cndcLabel1.Text = "Nodo de Conexión";
            // 
            // cndcLabel2
            // 
            this.cndcLabel2.AutoSize = true;
            this.cndcLabel2.Location = new System.Drawing.Point(4, 78);
            this.cndcLabel2.Name = "cndcLabel2";
            this.cndcLabel2.Size = new System.Drawing.Size(96, 13);
            this.cndcLabel2.TabIndex = 2;
            this.cndcLabel2.TablaCampoBD = null;
            this.cndcLabel2.Text = "Pertenece al STI ?";
            // 
            // _rbSi
            // 
            this._rbSi.AutoSize = true;
            this._rbSi.Location = new System.Drawing.Point(3, 3);
            this._rbSi.Name = "_rbSi";
            this._rbSi.Size = new System.Drawing.Size(34, 17);
            this._rbSi.TabIndex = 3;
            this._rbSi.TablaCampoBD = null;
            this._rbSi.TabStop = true;
            this._rbSi.Text = "Si";
            this._rbSi.UseVisualStyleBackColor = true;
            // 
            // cndcPanelControl1
            // 
            this.cndcPanelControl1.AutoSize = true;
            this.cndcPanelControl1.Controls.Add(this._rbNo);
            this.cndcPanelControl1.Controls.Add(this._rbSi);
            this.cndcPanelControl1.Location = new System.Drawing.Point(105, 73);
            this.cndcPanelControl1.Name = "cndcPanelControl1";
            this.cndcPanelControl1.Size = new System.Drawing.Size(91, 25);
            this.cndcPanelControl1.TabIndex = 4;
            this.cndcPanelControl1.TablaCampoBD = null;
            // 
            // _rbNo
            // 
            this._rbNo.AutoSize = true;
            this._rbNo.Location = new System.Drawing.Point(43, 3);
            this._rbNo.Name = "_rbNo";
            this._rbNo.Size = new System.Drawing.Size(39, 17);
            this._rbNo.TabIndex = 5;
            this._rbNo.TablaCampoBD = null;
            this._rbNo.TabStop = true;
            this._rbNo.Text = "No";
            this._rbNo.UseVisualStyleBackColor = true;
            // 
            // _tSBEditar
            // 
            this._tSBEditar.Image = global::ComponentesUI.Properties.Resources.Edit;
            this._tSBEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tSBEditar.Name = "_tSBEditar";
            this._tSBEditar.Size = new System.Drawing.Size(57, 22);
            this._tSBEditar.Text = "Editar";
            // 
            // cndcLabel3
            // 
            this.cndcLabel3.AutoSize = true;
            this.cndcLabel3.Location = new System.Drawing.Point(201, 80);
            this.cndcLabel3.Name = "cndcLabel3";
            this.cndcLabel3.Size = new System.Drawing.Size(59, 13);
            this.cndcLabel3.TabIndex = 6;
            this.cndcLabel3.TablaCampoBD = null;
            this.cndcLabel3.Text = "Referencia";
            // 
            // _txtReferencia
            // 
            this._txtReferencia.EnterComoTab = false;
            this._txtReferencia.Etiqueta = null;
            this._txtReferencia.Location = new System.Drawing.Point(266, 75);
            this._txtReferencia.Name = "_txtReferencia";
            this._txtReferencia.Size = new System.Drawing.Size(287, 20);
            this._txtReferencia.TabIndex = 7;
            this._txtReferencia.TablaCampoBD = null;
            // 
            // _ctrlDescNodoOrigen
            // 
            this._ctrlDescNodoOrigen.Location = new System.Drawing.Point(101, 45);
            this._ctrlDescNodoOrigen.Name = "_ctrlDescNodoOrigen";
            this._ctrlDescNodoOrigen.Size = new System.Drawing.Size(457, 26);
            this._ctrlDescNodoOrigen.TabIndex = 0;
            // 
            // CtrlDatosRed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtReferencia);
            this.Controls.Add(this.cndcLabel3);
            this.Controls.Add(this.cndcPanelControl1);
            this.Controls.Add(this.cndcLabel2);
            this.Controls.Add(this.cndcLabel1);
            this.Controls.Add(this._ctrlDescNodoOrigen);
            this.Name = "CtrlDatosRed";
            this.Size = new System.Drawing.Size(559, 107);
            this.Controls.SetChildIndex(this._ctrlDescNodoOrigen, 0);
            this.Controls.SetChildIndex(this.cndcLabel1, 0);
            this.Controls.SetChildIndex(this.cndcLabel2, 0);
            this.Controls.SetChildIndex(this.cndcPanelControl1, 0);
            this.Controls.SetChildIndex(this.cndcLabel3, 0);
            this.Controls.SetChildIndex(this._txtReferencia, 0);
            this.cndcPanelControl1.ResumeLayout(false);
            this.cndcPanelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlDescNodo _ctrlDescNodoOrigen;
        private Controles.CNDCLabel cndcLabel1;
        private Controles.CNDCLabel cndcLabel2;
        private Controles.CNDCRadioButton _rbSi;
        private Controles.CNDCPanelControl cndcPanelControl1;
        private Controles.CNDCRadioButton _rbNo;
        private Controles.CNDCLabel cndcLabel3;
        private Controles.CNDCTextBox _txtReferencia;
        private System.Windows.Forms.ToolStripButton _tSBEditar;
    }
}
