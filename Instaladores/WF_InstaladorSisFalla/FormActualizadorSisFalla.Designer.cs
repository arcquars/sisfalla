namespace InstaladorSisFallaBeta
{
    partial class FormActualizadorSisFalla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActualizadorSisFalla));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this._lblSisFalla = new System.Windows.Forms.Label();
            this._btnInstalarSisFalla = new System.Windows.Forms.Button();
            this._lblEsquema = new System.Windows.Forms.Label();
            this._btnInstalarEsquema = new System.Windows.Forms.Button();
            this._lblMensaje = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 58);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Programa de Instalación de SisFalla V2 - Versión Beta";
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
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(11, 201);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 15);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ver Guia de Instalación.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // _lblSisFalla
            // 
            this._lblSisFalla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblSisFalla.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSisFalla.Location = new System.Drawing.Point(72, 136);
            this._lblSisFalla.Name = "_lblSisFalla";
            this._lblSisFalla.Size = new System.Drawing.Size(319, 23);
            this._lblSisFalla.TabIndex = 18;
            this._lblSisFalla.Text = "SisFalla V2 BETA";
            this._lblSisFalla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnInstalarSisFalla
            // 
            this._btnInstalarSisFalla.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInstalarSisFalla.Location = new System.Drawing.Point(397, 136);
            this._btnInstalarSisFalla.Name = "_btnInstalarSisFalla";
            this._btnInstalarSisFalla.Size = new System.Drawing.Size(87, 23);
            this._btnInstalarSisFalla.TabIndex = 19;
            this._btnInstalarSisFalla.Text = "Instalar";
            this._btnInstalarSisFalla.UseVisualStyleBackColor = true;
            this._btnInstalarSisFalla.Click += new System.EventHandler(this._btnInstalarSisFalla_Click);
            // 
            // _lblEsquema
            // 
            this._lblEsquema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblEsquema.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEsquema.Location = new System.Drawing.Point(72, 104);
            this._lblEsquema.Name = "_lblEsquema";
            this._lblEsquema.Size = new System.Drawing.Size(319, 23);
            this._lblEsquema.TabIndex = 14;
            this._lblEsquema.Text = "Esquema de Base de Datos SisFalla v2";
            this._lblEsquema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnInstalarEsquema
            // 
            this._btnInstalarEsquema.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInstalarEsquema.Location = new System.Drawing.Point(397, 104);
            this._btnInstalarEsquema.Name = "_btnInstalarEsquema";
            this._btnInstalarEsquema.Size = new System.Drawing.Size(87, 23);
            this._btnInstalarEsquema.TabIndex = 15;
            this._btnInstalarEsquema.Text = "Instalar";
            this._btnInstalarEsquema.UseVisualStyleBackColor = true;
            this._btnInstalarEsquema.Click += new System.EventHandler(this._btnInstalarEsquema_Click);
            // 
            // _lblMensaje
            // 
            this._lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblMensaje.Location = new System.Drawing.Point(0, 227);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(517, 20);
            this._lblMensaje.TabIndex = 20;
            this._lblMensaje.Text = "[...]";
            // 
            // FormActualizadorSisFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 247);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this._lblSisFalla);
            this.Controls.Add(this._btnInstalarSisFalla);
            this.Controls.Add(this._lblEsquema);
            this.Controls.Add(this._btnInstalarEsquema);
            this.Controls.Add(this._lblMensaje);
            this.Controls.Add(this.panel1);
            this.Name = "FormActualizadorSisFalla";
            this.Text = "Actualizador SisFalla";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label _lblSisFalla;
        private System.Windows.Forms.Button _btnInstalarSisFalla;
        private System.Windows.Forms.Label _lblEsquema;
        private System.Windows.Forms.Button _btnInstalarEsquema;
        private System.Windows.Forms.Label _lblMensaje;
    }
}