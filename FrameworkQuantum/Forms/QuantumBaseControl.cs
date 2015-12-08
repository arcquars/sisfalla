using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;
using CNDC.BLL;

namespace CNDC.BaseForms
{
    public partial class QuantumBaseControl : UserControl
    {
        public QuantumBaseControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarAyuda(this.Controls);
            }
        }

        protected void formatDatagrids(DataGridView dgv)
        {
            BaseForm.FormatDatagrids(dgv);
        }

        private void CargarAyuda(Control.ControlCollection controlCollection)
        {
            IElementoBD c = null;
            foreach (Control ctrl in controlCollection)
            {
                if (ctrl is IElementoBD)
                {
                    c = (IElementoBD)ctrl;
                    if (!string.IsNullOrEmpty(c.TablaCampoBD))
                    {
                        string help = AdministradorAyuda.Instance.ObtenerPorNombreCampo(c.TablaCampoBD);
                        _helpProvider.SetHelpString(ctrl, help);
                        _helpProvider.SetShowHelp(ctrl, true);
                        _toolTip.SetToolTip(ctrl, help);
                        ctrl.Enter += new EventHandler(ctrl_Enter);
                        ctrl.Leave += new EventHandler(ctrl_Leave);
                        ModeloQuantum.AdministradorControles.Instance.DefinirConfiguracionControl(this.Name, ctrl, c.TablaCampoBD);
                    }
                }

                if (ctrl is CNDCGridView)
                {
                    (ctrl as CNDCGridView).AplicarEstilo();
                }

                if (ctrl is IControlCNDC)
                {
                    IControlCNDC iControl = ctrl as IControlCNDC;
                    if (iControl.EnterComoTab)
                    {
                        ctrl.KeyUp += new KeyEventHandler(ctrl_KeyUp);
                    }
                }

                if (ctrl.Controls.Count > 0)
                {
                    CargarAyuda(ctrl.Controls);
                }
            }
        }

        private void ctrl_Leave(object sender, EventArgs e)
        {
            SetAyudaEnLinea(string.Empty);
        }

        private void ctrl_Enter(object sender, EventArgs e)
        {
            if (sender is IElementoBD)
            {
                IElementoBD c = (IElementoBD)sender;
                string extra = string.Empty;
                if (sender is TextBox && (sender as TextBox).ReadOnly)
                {
                    extra = " (Sólo Lectura)";
                }
                SetAyudaEnLinea(AdministradorAyuda.Instance.ObtenerPorNombreCampo(c.TablaCampoBD) + extra);
            }
        }

        protected virtual void SetAyudaEnLinea(string ayuda)
        {

        }

        void ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Control ctrl = sender as Control;
                this.SelectNextControl(ctrl, true, true, true, true);
            }
        }
    }
}
