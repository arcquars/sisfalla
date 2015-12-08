namespace Proyectos
{
    partial class FormNuevoProyecto
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
            this._btnAceptar = new Controles.CNDCButton();
            this._rbtGeneracion = new Controles.CNDCRadioButton();
            this._btnTransmision = new Controles.CNDCRadioButton();
            this._cmbTiposProysGeneracion = new Controles.CNDCComboBox();
            this._cmbTipoProysTransmision = new Controles.CNDCComboBox();
            this.comboBox1 = new Controles.CNDCComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Location = new System.Drawing.Point(242, 104);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(99, 29);
            this._btnAceptar.TabIndex = 0;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
            // 
            // _rbtGeneracion
            // 
            this._rbtGeneracion.AutoSize = true;
            this._rbtGeneracion.Location = new System.Drawing.Point(42, 26);
            this._rbtGeneracion.Name = "_rbtGeneracion";
            this._rbtGeneracion.Size = new System.Drawing.Size(145, 17);
            this._rbtGeneracion.TabIndex = 1;
            this._rbtGeneracion.Text = "Proyectos de Generación";
            this._rbtGeneracion.UseVisualStyleBackColor = true;
            this._rbtGeneracion.CheckedChanged += new System.EventHandler(this._rbtGeneracion_CheckedChanged);
            // 
            // _btnTransmision
            // 
            this._btnTransmision.AutoSize = true;
            this._btnTransmision.Location = new System.Drawing.Point(42, 60);
            this._btnTransmision.Name = "_btnTransmision";
            this._btnTransmision.Size = new System.Drawing.Size(146, 17);
            this._btnTransmision.TabIndex = 2;
            this._btnTransmision.Text = "Proyectos de Transmisión";
            this._btnTransmision.UseVisualStyleBackColor = true;
            this._btnTransmision.CheckedChanged += new System.EventHandler(this._btnTransmision_CheckedChanged);
            // 
            // _cmbTiposProysGeneracion
            // 
            this._cmbTiposProysGeneracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTiposProysGeneracion.FormattingEnabled = true;
            this._cmbTiposProysGeneracion.Location = new System.Drawing.Point(203, 26);
            this._cmbTiposProysGeneracion.Name = "_cmbTiposProysGeneracion";
            this._cmbTiposProysGeneracion.Size = new System.Drawing.Size(202, 21);
            this._cmbTiposProysGeneracion.TabIndex = 3;
            // 
            // _cmbTipoProysTransmision
            // 
            this._cmbTipoProysTransmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoProysTransmision.FormattingEnabled = true;
            this._cmbTipoProysTransmision.Location = new System.Drawing.Point(203, 60);
            this._cmbTipoProysTransmision.Name = "_cmbTipoProysTransmision";
            this._cmbTipoProysTransmision.Size = new System.Drawing.Size(202, 21);
            this._cmbTipoProysTransmision.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(411, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(340, 344);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // FormNuevoProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 344);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this._cmbTipoProysTransmision);
            this.Controls.Add(this._cmbTiposProysGeneracion);
            this.Controls.Add(this._btnTransmision);
            this.Controls.Add(this._rbtGeneracion);
            this.Controls.Add(this._btnAceptar);
            this.Name = "FormNuevoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNuevoProyecto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnAceptar;
        private System.Windows.Forms.RadioButton _rbtGeneracion;
        private System.Windows.Forms.RadioButton _btnTransmision;
        private System.Windows.Forms.ComboBox _cmbTiposProysGeneracion;
        private System.Windows.Forms.ComboBox _cmbTipoProysTransmision;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TreeView treeView1;
    }
}