namespace Controles

    {
    partial class CNDCPasswordEye
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
            {
            if ( disposing && ( components != null ) )
                {
                components.Dispose ( );
                }
            base.Dispose ( disposing );
            }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
            {
            this.panel = new System.Windows.Forms.Panel();
            this.textbox = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button);
            this.panel.Controls.Add(this.textbox);
            this.panel.ForeColor = System.Drawing.Color.Black;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(133, 27);
            this.panel.TabIndex = 3;
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.Color.White;
            this.textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox.ForeColor = System.Drawing.Color.Black;
            this.textbox.Location = new System.Drawing.Point(1, 7);
            this.textbox.MaxLength = 20;
            this.textbox.Name = "textbox";
            this.textbox.PasswordChar = '*';
            this.textbox.Size = new System.Drawing.Size(94, 20);
            this.textbox.TabIndex = 0;
            // 
            // button
            // 
            this.button.BackgroundImage = global::Controles.Properties.Resources.PasswordEyeImage;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.ForeColor = System.Drawing.Color.Black;
            this.button.Location = new System.Drawing.Point(101, 3);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(21, 21);
            this.button.TabIndex = 1;
            this.button.UseVisualStyleBackColor = false;
            // 
            // CNDCPasswordEye
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel);
            this.Name = "CNDCPasswordEye";
            this.Size = new System.Drawing.Size(135, 29);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textbox;

        }
    }
