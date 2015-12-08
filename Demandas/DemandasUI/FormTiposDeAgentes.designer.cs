namespace DemandasUI
{
    partial class FormTiposDeAgentes
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
            this._dgvTiposAgentes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTiposAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvTiposAgentes
            // 
            this._dgvTiposAgentes.AllowUserToAddRows = false;
            this._dgvTiposAgentes.AllowUserToDeleteRows = false;
            this._dgvTiposAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvTiposAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvTiposAgentes.Location = new System.Drawing.Point(0, 2);
            this._dgvTiposAgentes.Name = "_dgvTiposAgentes";
            this._dgvTiposAgentes.ReadOnly = true;
            this._dgvTiposAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvTiposAgentes.Size = new System.Drawing.Size(395, 160);
            this._dgvTiposAgentes.TabIndex = 4;
            this._dgvTiposAgentes.SelectionChanged += new System.EventHandler(this._dgvTiposAgentes_SelectionChanged);
            this._dgvTiposAgentes.DoubleClick += new System.EventHandler(this._dgvTiposAgentes_DoubleClick);
            // 
            // FormTiposDeAgentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 163);
            this.Controls.Add(this._dgvTiposAgentes);
            this.Name = "FormTiposDeAgentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipos de agentes";
            ((System.ComponentModel.ISupportInitialize)(this._dgvTiposAgentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvTiposAgentes;

    }
}