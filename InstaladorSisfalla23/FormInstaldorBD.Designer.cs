namespace InstaladorSisfalla
{
    partial class FormInstaldorBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstaldorBD));
            this.label1 = new System.Windows.Forms.Label();
            this._txtContrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._btnInstalarBD = new System.Windows.Forms.Button();
            this._lblMensaje = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnParche = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // _txtContrasena
            // 
            this._txtContrasena.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtContrasena.Location = new System.Drawing.Point(211, 121);
            this._txtContrasena.Name = "_txtContrasena";
            this._txtContrasena.PasswordChar = '*';
            this._txtContrasena.Size = new System.Drawing.Size(220, 23);
            this._txtContrasena.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtUsuario.Location = new System.Drawing.Point(211, 96);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.ReadOnly = true;
            this._txtUsuario.Size = new System.Drawing.Size(220, 23);
            this._txtUsuario.TabIndex = 3;
            this._txtUsuario.Text = "sys";
            // 
            // _btnInstalarBD
            // 
            this._btnInstalarBD.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInstalarBD.Location = new System.Drawing.Point(356, 147);
            this._btnInstalarBD.Name = "_btnInstalarBD";
            this._btnInstalarBD.Size = new System.Drawing.Size(75, 23);
            this._btnInstalarBD.TabIndex = 7;
            this._btnInstalarBD.Text = "Instalar BD";
            this._btnInstalarBD.UseVisualStyleBackColor = true;
            this._btnInstalarBD.Click += new System.EventHandler(this._btnInstalarBD_Click);
            // 
            // _lblMensaje
            // 
            this._lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblMensaje.Location = new System.Drawing.Point(0, 209);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(542, 23);
            this._lblMensaje.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 58);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(270, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Programa de Instalación  de SisFalla - Versión 2.3";
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
            // _btnParche
            // 
            this._btnParche.Enabled = false;
            this._btnParche.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnParche.Location = new System.Drawing.Point(275, 147);
            this._btnParche.Name = "_btnParche";
            this._btnParche.Size = new System.Drawing.Size(75, 23);
            this._btnParche.TabIndex = 6;
            this._btnParche.Text = "Parche XE";
            this._btnParche.UseVisualStyleBackColor = true;
            this._btnParche.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormInstaldorBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 232);
            this.Controls.Add(this._btnParche);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._lblMensaje);
            this.Controls.Add(this._btnInstalarBD);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtContrasena);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInstaldorBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalación de Base de Datos";
            this.Load += new System.EventHandler(this.FormInstaldorBD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtContrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Button _btnInstalarBD;
        private System.Windows.Forms.Label _lblMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btnParche;
    }
}