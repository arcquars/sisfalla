using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumPluginLib;
using System.Windows.Forms;
using CNDC.Config;
using System.Reflection;
using System.IO;
using CNDC.BLL;
using System.ComponentModel;
using CNDC.Pistas;

namespace QuantumUI
{
    public class PluginMgr
    {
        #region Singleton
        private static PluginMgr _instancia;

        public static PluginMgr Instancia
        {
            get { return _instancia; }
        }

        static PluginMgr()
        { _instancia = new PluginMgr(); }

        private PluginMgr()
        { }
        #endregion Singleton
        BindingList<Modulo> _modulos;
        Modulo _moduloActual;

        public event EventHandler ModuloCambiado;

        public IPlugin GetPlugin()
        {
            IPlugin resultado = null;
            CargarListaModulos();
            try
            {
                Assembly asm = Assembly.LoadFile(Path.Combine(Config.Intance.DirectorioConfiguracion, _moduloActual.DllPlugin));
                resultado = (IPlugin)asm.CreateInstance(_moduloActual.Clase);
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("SisFalla", e);
            }

            return resultado;
        }

        private void CargarListaModulos()
        {
            if (_moduloActual == null)
            {
                _modulos = OraDalModuloMgr.Instancia.GetModulosAsignadosAUsuario(Sesion.Instancia.UsuarioActual.Login);
                if (_modulos.Count > 0)
                {
                    _moduloActual = _modulos[0];
                    Sesion.Instancia.ModuloActual = _moduloActual;
                }
            }
        }

        public BindingList<Modulo> GetModulos()
        {
            return _modulos;
        }

        public void SetModuloActual(Modulo modulo)
        {
            if (modulo != _moduloActual)
            {
                _moduloActual = modulo;
                Sesion.Instancia.ModuloActual = _moduloActual;
                if (ModuloCambiado != null)
                {
                    ModuloCambiado(this, EventArgs.Empty);
                }
            }
        }
    }

    class PluginDemo : IPlugin
    {
        public string GetTitulo()
        {
            return "Plugin demo";
        }

        public Control GetPanelPrincipal()
        {
            return new Controles.CNDCPanelControl();
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
        { return true; }

        public void RecargarControlPrincipal()
        { }
    }
}
