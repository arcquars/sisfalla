using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace CNDC.Pistas
{
    public class PistaMgr
    {
        #region Singleton
        private static PistaMgr _instance;

        public static PistaMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PistaMgr();
                }
                return _instance;
            }
        }

        private PistaMgr()
        {
            Inicializar();
        }
        #endregion

        #region Fields
        private bool _isDebugEnabled;
        private bool _isErrorEnabled;
        private bool _isFatalEnabled;
        private bool _isInfoEnabled;
        private bool _isWarnEnabled;
        private IRegistradorPista _dataBaseWriter;
        private IRegistradorPista _localFileWriter;
        #endregion

        bool IsDebugEnabled { get { return _isDebugEnabled; } }
        bool IsErrorEnabled { get { return _isErrorEnabled; } }
        bool IsFatalEnabled { get { return _isFatalEnabled; } }
        bool IsInfoEnabled { get { return _isInfoEnabled; } }
        bool IsWarnEnabled { get { return _isWarnEnabled; } }
        public string Usuario { get; set; }

        public IRegistradorPista RegistradorBD
        {
            get { return _dataBaseWriter; }
            set { _dataBaseWriter = value; }
        }

        public void EscribirLog(Pista element)
        {
            switch (element.Tipo)
            {
                case TipoPista.Debug:
                    if (_isDebugEnabled)
                    {
                        _localFileWriter.Registrar(element);
                    }
                    break;
                case TipoPista.Info:
                    if (_isInfoEnabled)
                    {
                        GuardarLog(element);
                    }
                    break;
                case TipoPista.Warn:
                    if (_isWarnEnabled)
                    {
                        GuardarLog(element);
                    }
                    break;
                case TipoPista.Error:
                    if (_isErrorEnabled)
                    {
                        GuardarLog(element);
                    }
                    break;
                case TipoPista.Fatal:
                    if (_isFatalEnabled)
                    {
                        GuardarLog(element);
                    }
                    break;
            }
        }

        public Pista EscribirLog(string module, string text, TipoPista type)
        {
            Pista element = CrearElementoLog(module, text);
            element.Tipo = type;
            EscribirLog(element);
            return element;
        }
       
        public void EscribirLog(string module, Exception e, TipoPista type)
        {
            Pista element = CrearElementoLog(module, e);
            element.Tipo = type;
            EscribirLog(element);
        }

        public void Debug(string module, string text)
        {
            EscribirLog(module, text, TipoPista.Debug);
        }

        public void Debug(string module, Exception e)
        {
            EscribirLog(module, e, TipoPista.Debug);
        }

        public Pista Info(string module, string text)
        {
            return EscribirLog(module, text, TipoPista.Info);
        }

        public void Info(string module, Exception e)
        {
            EscribirLog(module, e, TipoPista.Info);
        }

        public void Warn(string module, string text)
        {
            EscribirLog(module, text, TipoPista.Warn);
        }

        public void Warn(string module, Exception e)
        {
            EscribirLog(module, e, TipoPista.Warn);
        }

        public void Error(string module, string text)
        {
            EscribirLog(module, text, TipoPista.Error);
        }

        public void Error(string module, Exception e)
        {
            EscribirLog(module, e, TipoPista.Error);
        }

        public void Fatal(string module, string text)
        {
            EscribirLog(module, text, TipoPista.Fatal);
        }

        public void Fatal(string module, Exception e)
        {
            EscribirLog(module, e, TipoPista.Fatal);
        }

        private void Inicializar()
        {
            _localFileWriter = RegistradorArchLocal.Instancia;
            _isDebugEnabled = true;//TODO get this information from config file
            _isInfoEnabled = true;
            _isWarnEnabled = true;
            _isErrorEnabled = true;
            _isFatalEnabled = true;
            Usuario = string.Empty;
        }

        private Pista CrearElementoLog(string module, string text)
        {
            Pista element = new Pista();
            element.FechaHora = DateTime.Now;
            element.Detalle = text;
            element.Excepcion = string.Empty;
            element.IP = GetIP();
            element.Modulo = module;
            element.Tipo = TipoPista.Error;
            element.Usuario = Usuario;
            return element;
        }

        private Pista CrearElementoLog(string module, Exception e)
        {
            Pista element = new Pista();
            element.FechaHora = DateTime.Now;
            element.Detalle = e.ToString();
            element.Excepcion = e.GetType().Name;
            element.IP = GetIP();
            element.Modulo = module;
            element.Tipo = TipoPista.Error;
            element.Usuario = Usuario;
            return element;
        }

        private void GuardarLog(Pista data)
        {
            if (_dataBaseWriter != null)
            {
                _dataBaseWriter.Registrar(data);
            }

            if (_localFileWriter != null)
            {
                _localFileWriter.Registrar(data);
            }
        }

        private string GetIP()
        {
            string strIP = string.Empty;
            try
            {
                IPAddress ip = NetworkInterface.GetAllNetworkInterfaces()[0].GetIPProperties().UnicastAddresses[0].Address;
                strIP = ip.ToString();
            }
            catch
            {
            }
            return strIP;
        }

        public void EscribirEnLocal(string modulo, Exception exception)
        {
            Pista p = CrearElementoLog(modulo, exception);
            _localFileWriter.Registrar(p);
        }

        public void EscribirEnLocal(string modulo, string msg)
        {
            Pista p = CrearElementoLog(modulo, msg);
            _localFileWriter.Registrar(p);
        }
    }

    public enum LogLevel
    {

    }
}
