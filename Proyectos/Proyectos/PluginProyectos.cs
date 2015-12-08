using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using System.Windows.Forms;
using ModeloProyectos;

namespace Proyectos
{
    public class PluginProyectos : IPlugin
    {
        private CtrlPrincipal _panelPrincipal;

        public PluginProyectos()
        {
        }

        #region Miembros de IPlugin

        public string GetTitulo()
        {
            return "Sistema de Proyectos";
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
            ModeloMgr.Instancia.IdMgr = new OraDalProyectos.IdMgr();
        }

        public bool CerrarPlugin()
        {
            return !_panelPrincipal.Editando();
        }

        public void RecargarControlPrincipal()
        { 
        }

        #endregion
    }
}
