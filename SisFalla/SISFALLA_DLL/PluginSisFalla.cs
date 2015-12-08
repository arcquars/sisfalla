using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using System.Windows.Forms;

namespace SISFALLA
{
    public class PluginSisFalla: IPlugin
    {
        SisFallaPrincipal _panelPrincipal;

        public PluginSisFalla()
        {
            AsegurarPanelPrincipal();
        }

        public string GetTitulo()
        {
            return "Sistema de Registro de Fallas - CNDC  Versión 2.1";
        }

        public Control GetPanelPrincipal()
        {
            return _panelPrincipal;
        }

        private void AsegurarPanelPrincipal()
        {
            if (_panelPrincipal == null)
            {
                _panelPrincipal = new SisFallaPrincipal();
            }
        }

        public void AbrirSplash()
        {
            _panelPrincipal.AbrirSplash();
        }

        public void CerrarSplash()
        {
            _panelPrincipal.CerrarSplash();
        }

        public void CargarDatosDeInicio()
        {
            _panelPrincipal.CargarDatosInicio();
        }

        public void CerrarPlugin()
        {
            _panelPrincipal.CerrarSisFalla();
        }
    }
}
