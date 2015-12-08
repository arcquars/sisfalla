using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;
using CNDC.DAL;

namespace CNDC.ExceptionHandlerLib
{
    public class MessageMgr
    {
        #region Singleton
        private static MessageMgr _instance;
        private MessageMgr()
        {
            Initialize();
        }
        public static MessageMgr Instance
        {
            get 
            {
                if (_instance==null)
                {
                    _instance = new MessageMgr();
                }
                return _instance;
            }
        }
        #endregion

        #region Fields
        Dictionary<string, string> _messages;
        #endregion Fields

        #region Methods

        ConnexionOracleMgr _conexion;
        public void SetConexion(ConnexionOracleMgr c)
        {
            _conexion = c;
        }

        public string GetMessage(string errorCode)
        {
            string result = string.Empty;
            if (_messages.ContainsKey(errorCode))
            {
                result = _messages[errorCode];
            }
            else
            {
                if (_conexion != null)
                {

                    string msg = GetFromDB(errorCode);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        result = msg;
                        _messages.Add(errorCode, result);
                    }
                }
                else
                {
                    result = "Error al conectarse a la Base de Datos";
                }
            }
            return result;
        }

        private void Initialize()
        {
            _messages = new Dictionary<string, string>();
            LoadLocalMessages();
        }

        private void LoadLocalMessages()
        {
            try
            {
                StreamReader reader = new StreamReader("MessageCatalog.txt");
                string errorCode = string.Empty, message = string.Empty;
                string data = string.Empty;
                int idx = 0;

                while (!reader.EndOfStream)
                {
                    data = reader.ReadLine();
                    idx = data.IndexOf("=");
                    errorCode = data.Substring(0, idx);
                    message = data.Substring(idx + 1);
                    _messages.Add(errorCode, message);
                }

                reader.Close();
            }
            catch (Exception)
            {
            }
        }

        const string TABLA_MENSAJES = "P_DEF_MENSAJE";
        private string GetFromDB(string errorCode)
        {
            string result = string.Empty;
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = string.Format("SELECT TEXTO_MENSAJE FROM {0} WHERE COD_MENSAJE = :COD_MENSAJE", TABLA_MENSAJES);
            cmd.Parameters.Add("COD_MENSAJE", OracleDbType.Varchar2, errorCode, ParameterDirection.Input);
            OracleDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("ExceptionHandlerLib", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                _conexion.DisposeCommand(cmd);
            }
            return result;
        }

        #endregion Methods
    }
}
