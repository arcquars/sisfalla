using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using System.Windows.Forms;

namespace MedicionComercialUI
{
    public class PluginMC : IPlugin
    {
        Panel _pnlPrincipal = new Panel();
        public string GetTitulo()
        {
            return "Medición Comercial";
        }

        public Control GetPanelPrincipal()
        {
            return _pnlPrincipal;
        }

        public void AbrirSplash()
        {
        }

        public void CerrarSplash()
        {
        }

        public void CargarDatosDeInicio()
        {
        }

        public bool CerrarPlugin()
        {
            return true;
        }

        public void RecargarControlPrincipal()
        { }
    }
}
