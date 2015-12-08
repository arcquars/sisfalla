using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;

namespace QuantumUI
{
    public partial class CtrlModulos : UserControl
    {
        BindingList<Modulo> modulos;
        public CtrlModulos()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            modulos = PluginMgr.Instancia.GetModulos();
            _cmbModulos.DisplayMember = "Nombre";
            _cmbModulos.ValueMember = "PkCodModulo";
            _cmbModulos.DataSource = modulos;
        }

        private void _cmbModulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbModulos.SelectedValue != null)
            {
                PluginMgr.Instancia.SetModuloActual(modulos[_cmbModulos.SelectedIndex]);
            }
        }
    }
}
