using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controles;
using System.Windows.Forms;

namespace QuantumPluginLib
{
    public interface IPlugin
    {
        string GetTitulo();
        Control GetPanelPrincipal();

        void AbrirSplash();

        void CerrarSplash();

        void CargarDatosDeInicio();

        bool CerrarPlugin();

        void RecargarControlPrincipal();
    }
}
