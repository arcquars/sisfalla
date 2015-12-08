namespace WF_InstaladorSisFalla
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
            this._lblMensaje = new System.Windows.Forms.Label();
            this._btnInstalarEsquema = new System.Windows.Forms.Button();
            this._lblEsquema = new System.Windows.Forms.Label();
            this._btnInstalarSisFalla = new System.Windows.Forms.Button();
            this._lblSisFalla = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblMensaje
            // 
            this._lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblMensaje.Location = new System.Drawing.Point(0, 175);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(553, 20);
            this._lblMensaje.TabIndex = 8;
            this._lblMensaje.Text = "[...]";
            // 
            // _btnInstalarEsquema
            // 
            this._btnInstalarEsquema.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnInstalarEsquema.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInstalarEsquema.Location = new System.Drawing.Point(397, 80);
            this._btnInstalarEsquema.Name = "_btnInstalarEsquema";
            this._btnInstalarEsquema.Size = new System.Drawing.Size(87, 23);
            this._btnInstalarEsquema.TabIndex = 3;
            this._btnInstalarEsquema.Text = "Instalar";
            this._btnInstalarEsquema.UseVisualStyleBackColor = true;
            this._btnInstalarEsquema.Click += new System.EventHandler(this._btnInstalarEsquema_Click);
            // 
            // _lblEsquema
            // 
            this._lblEsquema.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblEsquema.BackColor = System.Drawing.Color.White;
            this._lblEsquema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblEsquema.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEsquema.Location = new System.Drawing.Point(72, 80);
            this._lblEsquema.Name = "_lblEsquema";
            this._lblEsquema.Size = new System.Drawing.Size(319, 23);
            this._lblEsquema.TabIndex = 2;
            this._lblEsquema.Text = "Esquema de Base de Datos SisFalla v2.1.1";
            this._lblEsquema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnInstalarSisFalla
            // 
            this._btnInstalarSisFalla.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnInstalarSisFalla.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInstalarSisFalla.Location = new System.Drawing.Point(397, 109);
            this._btnInstalarSisFalla.Name = "_btnInstalarSisFalla";
            this._btnInstalarSisFalla.Size = new System.Drawing.Size(87, 23);
            this._btnInstalarSisFalla.TabIndex = 7;
            this._btnInstalarSisFalla.Text = "Instalar";
            this._btnInstalarSisFalla.UseVisualStyleBackColor = true;
            this._btnInstalarSisFalla.Click += new System.EventHandler(this._btnInstalarSisFalla_Click);
            // 
            // _lblSisFalla
            // 
            this._lblSisFalla.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblSisFalla.BackColor = System.Drawing.Color.White;
            this._lblSisFalla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblSisFalla.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSisFalla.Location = new System.Drawing.Point(72, 109);
            this._lblSisFalla.Name = "_lblSisFalla";
            this._lblSisFalla.Size = new System.Drawing.Size(319, 23);
            this._lblSisFalla.TabIndex = 6;
            this._lblSisFalla.Text = "SisFalla V2.1";
            this._lblSisFalla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 58);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Programa de Actualización de SisFalla - Versión 2.1.1";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(12, 153);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 15);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ver Guia de Instalación.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 195);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._lblSisFalla);
            this.Controls.Add(this._btnInstalarSisFalla);
            this.Controls.Add(this._lblEsquema);
            this.Controls.Add(this._btnInstalarEsquema);
            this.Controls.Add(this._lblMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizador SisFalla - Versión 2.1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblMensaje;
        private System.Windows.Forms.Button _btnInstalarEsquema;
        private System.Windows.Forms.Label _lblEsquema;
        private System.Windows.Forms.Button _btnInstalarSisFalla;
        private System.Windows.Forms.Label _lblSisFalla;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

