using System;
using System.Collections.Generic;
using System.Text;

namespace CNDC.DAL
{
    public class ConfigConexionMgr
    {
        private string _cadenaConexion;
        private TipoBaseDatos _tipoBD;
        private TipoAutenticacion _tipoAutenticacion;

        private bool _isConnection;

        private string _pathDefault;

        public ConfigConexionMgr()
        {
            LeerConfiguracion();
        }

        private void LeerConfiguracion()
        {
            try
            {
                _cadenaConexion = Config.Config.Intance.Read("Configuracion/Conexiones/ConexionBD", "Local", "Cadena", "");
                _tipoBD = TipoBaseDatos.Local;
                _tipoAutenticacion = DAL.TipoAutenticacion.BaseDatos;
                if (string.IsNullOrEmpty(_cadenaConexion))
                {
                    LeerTipoAutenticacionDeRegistro();
                    _tipoBD = TipoBaseDatos.Centralizada;
                }
                LeerConnectionDeRegistro();
            }
            catch (Exception ex)
            {
                Pistas.PistaMgr.Instance.Error("ConfigConexionMgr", ex);
            }
        }

        private void GuardarTipoAutenticacionEnRegistro()
        {
            UtilesComunes.LlaveDeRegistro.EscribirValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "TipoAutenticacion", _tipoAutenticacion.ToString());
        }

        private void GuardarConnectionEnRegistro()
        {
            UtilesComunes.LlaveDeRegistro.EscribirValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "Connection", _isConnection.ToString());
        }

        private void GuardarPathDefaultEnRegistro()
        {
            UtilesComunes.LlaveDeRegistro.EscribirValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "PathDefault", _pathDefault);
        }

        private void LeerTipoAutenticacionDeRegistro()
        {
            string valorLlave = UtilesComunes.LlaveDeRegistro.LeerValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "TipoAutenticacion");
            if (string.IsNullOrEmpty(valorLlave))
            {
                _tipoAutenticacion = DAL.TipoAutenticacion.BaseDatos;
            }
            else
            {
                _tipoAutenticacion = (TipoAutenticacion)Enum.Parse(typeof(TipoAutenticacion), valorLlave);
            }
        }

        private void LeerConnectionDeRegistro()
        {
            string valorLlave = UtilesComunes.LlaveDeRegistro.LeerValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "Connection");
            if (string.IsNullOrEmpty(valorLlave))
            {
                UtilesComunes.LlaveDeRegistro.EscribirValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "Connection", "1");
                _isConnection = false;
            }
            else
            {
                _isConnection = Convert.ToBoolean(valorLlave);
            }
        }

        private void LeerPathDefaultDeRegistro()
        {
            string valorLlave = UtilesComunes.LlaveDeRegistro.LeerValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "PathDefault");
            if (string.IsNullOrEmpty(valorLlave))
            {
                UtilesComunes.LlaveDeRegistro.EscribirValorDeRegistro(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\\SisFallaV2", "PathDefault", "1");
                _pathDefault = "";
            }
            else
            {
                _pathDefault = valorLlave;
            }
        }

        public string CadenaConexion
        {
            get { return _cadenaConexion; }
        }

        public TipoBaseDatos TipoBD
        {
            get { return _tipoBD; }
        }

        public TipoAutenticacion TipoAutenticacion
        {
            get { return _tipoAutenticacion; }
            set
            {
                _tipoAutenticacion = value;
                GuardarTipoAutenticacionEnRegistro();
            }
        }

        public bool IsConnection
        {
            get { return _isConnection; }
            set
            {
                _isConnection = value;
                GuardarConnectionEnRegistro();
            }
        }

        public string PathDefault
        {
            get { return _pathDefault; }
            set
            {
                _pathDefault = value;
                GuardarPathDefaultEnRegistro();
            }
        }

        public void Inicializar(string us, string pass)
        {
            Pistas.PistaMgr.Instance.Debug("CNDC.DAL.ConfigConexionMgr.Inicializar", "Iniciando ConfiguradorMgr");
            try
            {
                Pistas.PistaMgr.Instance.Debug("CNDC.DAL.ConfigConexionMgr.Inicializar", "_tipoAutenticacion:" + _tipoAutenticacion);

                if (_tipoBD == TipoBaseDatos.Centralizada)
                {
                    _cadenaConexion = Config.Config.Intance.Read("Configuracion/Conexiones/ConexionBD", _tipoAutenticacion.ToString(), "Cadena", "");
                }
                else
                {
                    _cadenaConexion = Config.Config.Intance.Read("Configuracion/Conexiones/ConexionBD", "Local", "Cadena", "");
                }
                _cadenaConexion = string.Format(_cadenaConexion, us, pass);
            }
            catch (Exception ex)
            {
                Pistas.PistaMgr.Instance.Error("ConfigConexionMgr.Inicializar", ex);
            }
            Pistas.PistaMgr.Instance.Debug("ConfigConexionMgr.Inicializar", " _cadenaConexion=" + _cadenaConexion);
        }
    }

    public enum TipoBaseDatos
    {
        Local,
        Centralizada
    }

    public enum TipoAutenticacion
    {
        NoDefinido,
        BaseDatos,
        Dominio
    }
}
