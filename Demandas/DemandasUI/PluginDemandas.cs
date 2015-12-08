using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using System.Windows.Forms;

namespace DemandasUI
{
    public class PluginDemandas : IPlugin
    {
        private CtrlPrincipal _panelPrincipal;

        public PluginDemandas()
        {
        }

        #region Miembros de IPlugin

        public string GetTitulo()
        {
            return "Sistema de Demandas";
        }

        public Control GetPanelPrincipal()
        {
            if (_panelPrincipal == null)
            {
                _panelPrincipal = new CtrlPrincipal();
            }
            return _panelPrincipal;
        }

        public void AbrirSplash()
        {
        }

        public void CerrarSplash()
        {
        }

        public void CargarDatosDeInicio()
        {
           // ModeloMgr.Instancia.IdMgr = new OraDalProyectos.IdMgr();
        }

        public bool CerrarPlugin()
        {
            return true;
        }

        public void RecargarControlPrincipal()
        { }

        #endregion
    }
}
