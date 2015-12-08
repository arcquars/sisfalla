namespace QuantumUI
{
    partial class QuantumPrincipal
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
            this.components = new System.ComponentModel.Container();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this.cndcToolTip1 = new Controles.CNDCToolTip();
            this._bscFailures = new System.Windows.Forms.BindingSource(this.components);
            this._bscUsers = new System.Windows.Forms.BindingSource(this.components);
            this.cndcPanelControl2 = new Controles.CNDCPanelControl();
            this._timerHora = new System.Windows.Forms.Timer(this.components);
            this._timerHoraCNDC = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._bscFailures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscUsers)).BeginInit();
            this.cndcPanelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statusStrip.Location = new System.Drawing.Point(0, 0);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(753, 28);
            this._statusStrip.TabIndex = 2;
            this._statusStrip.Text = "statusStrip1";
            // 
            // cndcToolTip1
            // 
            this.cndcToolTip1.TablaCampoBD = null;
            // 
            // cndcPanelControl2
            // 
            this.cndcPanelControl2.Controls.Add(this._statusStrip);
            this.cndcPanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cndcPanelControl2.Location = new System.Drawing.Point(0, 345);
            this.cndcPanelControl2.Name = "cndcPanelControl2";
            this.cndcPanelControl2.Size = new System.Drawing.Size(753, 28);
            this.cndcPanelControl2.TabIndex = 4;
            this.cndcPanelControl2.TablaCampoBD = null;
            // 
            // _timerHora
            // 
            this._timerHora.Interval = 1000;
            this._timerHora.Tick += new System.EventHandler(this._timerHora_Tick);
            // 
            // _timerHoraCNDC
            // 
            this._timerHoraCNDC.Interval = 30000;
            this._timerHoraCNDC.Tick += new System.EventHandler(this._timerHoraCNDC_Tick);
            // 
            // QuantumPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 373);
            this.CloseButtonDisable = true;
            this.Controls.Add(this.cndcPanelControl2);
            this.DoubleBuffered = true;
            this.Name = "QuantumPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Titulo]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuantumPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.QuantumPrincipal_Load);
            this.Resize += new System.EventHandler(this.SisFallaPrincipal_Resize);
            ((System.ComponentModel.ISupportInitialize)(this._bscFailures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bscUsers)).EndInit();
            this.cndcPanelControl2.ResumeLayout(false);
            this.cndcPanelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.BindingSource _bscFailures;
        private System.Windows.Forms.BindingSource _bscUsers;
        private Controles.CNDCToolTip cndcToolTip1;
        private Controles.CNDCPanelControl cndcPanelControl2;
        private System.Windows.Forms.Timer _timerHora;
        private System.Windows.Forms.Timer _timerHoraCNDC;

    }
}

