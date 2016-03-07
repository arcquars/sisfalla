using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using CNDC.BLL;
using WcfDalSisFalla;
using System.Windows.Forms;
using CNDC.Pistas;

namespace SISFALLA
{
    public class PluginSisFalla : IPlugin
    {
        SplashQuantum _splash;
        SisFallaPrincipal _ctrlPrincipal;
        public string GetTitulo()
        {
            return "Sistema de Registro de Fallas - CNDC  Versión 2.3";
        }

        public Control GetPanelPrincipal()
        {
            if (_ctrlPrincipal == null)
            {
                _ctrlPrincipal = new SisFallaPrincipal();
            }
            return _ctrlPrincipal;
        }

        public void AbrirSplash()
        {
            _splash = new SplashQuantum();
            _splash.Show();
        }

        public void CerrarSplash()
        {
            PistaMgr.Instance.EscribirLog("CerrarSplash", String.Format("{0} - Punto 2 ", DateTime.Now.ToString(" H:mm:ss ")), TipoPista.Debug);
           
            _splash.Close();
            _splash = null;
            PistaMgr.Instance.EscribirLog("CerrarSplash", String.Format("{0} - Punto 2 ", DateTime.Now.ToString(" H:mm:ss ")), TipoPista.Debug);
      
        }

        public void CargarDatosDeInicio()
        {
            _ctrlPrincipal.CargarDatosInicio(_splash);
        }

        public bool CerrarPlugin()
        {
            if (Sesion.Instancia.SesionIniciada && Sesion.Instancia.ConfigConexion.TipoBD != CNDC.DAL.TipoBaseDatos.Centralizada)
            {
                WcfServicioMgr.Instancia.CerrarSesion(Sesion.Instancia.TokenSession);
            }
            return true;
        }

        public void RecargarControlPrincipal()
        {
            _ctrlPrincipal.Recargar();
        }
    }
}
