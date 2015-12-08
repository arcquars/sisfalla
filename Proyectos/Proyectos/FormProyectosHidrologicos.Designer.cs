namespace Proyectos
{
    partial class FormProyectosHidrologicos
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
            this._dgvProyectos = new System.Windows.Forms.DataGridView();
            this._txtNombreCodigoProyecto = new Controles.CNDCTextBox();
            this.label1 = new Controles.CNDCLabel();
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvProyectos
            // 
            this._dgvProyectos.AllowUserToAddRows = false;
            this._dgvProyectos.AllowUserToDeleteRows = false;
            this._dgvProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvProyectos.Location = new System.Drawing.Point(1, 29);
            this._dgvProyectos.Name = "_dgvProyectos";
            this._dgvProyectos.ReadOnly = true;
            this._dgvProyectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvProyectos.Size = new System.Drawing.Size(590, 396);
            this._dgvProyectos.TabIndex = 3;
            this._dgvProyectos.SelectionChanged += new System.EventHandler(this._dgvProyectos_SelectionChanged);
            this._dgvProyectos.DoubleClick += new System.EventHandler(this._dgvProyectos_DoubleClick);
            // 
            // _txtNombreCodigoProyecto
            // 
            this._txtNombreCodigoProyecto.EnterComoTab = false;
            this._txtNombreCodigoProyecto.Etiqueta = null;
            this._txtNombreCodigoProyecto.Location = new System.Drawing.Point(178, 4);
            this._txtNombreCodigoProyecto.Name = "_txtNombreCodigoProyecto";
            this._txtNombreCodigoProyecto.Size = new System.Drawing.Size(264, 20);
            this._txtNombreCodigoProyecto.TabIndex = 9;
            this._txtNombreCodigoProyecto.TablaCampoBD = null;
            this._txtNombreCodigoProyecto.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtNombreCodigoProyecto_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 8;
            this.label1.TablaCampoBD = null;
            this.label1.Text = "Nombre del Proyecto:";
            // 
            // FormProyectosHidrologicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 426);
            this.Controls.Add(this._txtNombreCodigoProyecto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._dgvProyectos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormProyectosHidrologicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de Proyectos";
            ((System.ComponentModel.ISupportInitialize)(this._dgvProyectos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvProyectos;
        private Controles.CNDCTextBox _txtNombreCodigoProyecto;
        private Controles.CNDCLabel label1;
    }
}