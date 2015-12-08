namespace DemandasUI
{
    partial class FormAgentesExistentes
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
            this._dgvAgentes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvAgentes
            // 
            this._dgvAgentes.AllowUserToAddRows = false;
            this._dgvAgentes.AllowUserToDeleteRows = false;
            this._dgvAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvAgentes.Location = new System.Drawing.Point(1, 12);
            this._dgvAgentes.Name = "_dgvAgentes";
            this._dgvAgentes.ReadOnly = true;
            this._dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvAgentes.Size = new System.Drawing.Size(711, 442);
            this._dgvAgentes.TabIndex = 5;
            this._dgvAgentes.SelectionChanged += new System.EventHandler(this._dgvAgentes_SelectionChanged);
            this._dgvAgentes.DoubleClick += new System.EventHandler(this._dgvAgentes_DoubleClick);
            // 
            // FormAgentesExistentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 456);
            this.Controls.Add(this._dgvAgentes);
            this.Name = "FormAgentesExistentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agentes existentes";
            ((System.ComponentModel.ISupportInitialize)(this._dgvAgentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvAgentes;
    }
}