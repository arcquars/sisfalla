using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;
using System.IO;


namespace CNDC.DAL
{
    #region Enumerations

    public enum TipoFinTransaccion
    {
        Commit = 1, RollBack = 2
    }

    #endregion Enumerations

    public sealed class ConnexionOracleMgr : IDisposable
    {
        #region Fields
        private OracleConnection _connexion = null;
        private string _cadenaConexion = null;
        private bool _transaccionIniciada = false;
        private OracleTransaction _transaccionActual = null;
        private bool _conexionPerdida = false;
        #endregion Fields

        #region Constructors

        public ConnexionOracleMgr(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        #endregion Constructors

        #region Properties

        public string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }

        public ConnectionState EstadoConexion
        {
            get
            {
                if (_connexion == null)
                {
                    return ConnectionState.Closed;
                }
                return _connexion.State;
            }
        }

        #endregion Properties

        #region Methods
        public void DisposeCommand(OracleCommand cmd)
        {
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
        }

        public void FinalizarConexion()
        {
            if (_connexion != null && _connexion.State == ConnectionState.Open)
            {
                _connexion.Close();
                _connexion.Dispose();
                _connexion = null;
                PistaMgr.Instance.Debug("CNDC.DAL.ConnexionOracleMgr", "Conexion a BD Cerrada");
            }
        }

        public void FinalizarTransaccion(TipoFinTransaccion endTrx)
        {
            if (_transaccionIniciada)
            {
                switch (endTrx)
                {
                    case TipoFinTransaccion.Commit:
                        _transaccionActual.Commit();
                        break;
                    case TipoFinTransaccion.RollBack:
                        _transaccionActual.Rollback();
                        break;
                }
                _transaccionIniciada = false;
                _transaccionActual = null;

            }
        }

        public void AsegurarConexion()
        {
            //FinalizarConexion();
            if (_connexion == null || _connexion.State != ConnectionState.Open)
            {
                PistaMgr.Instance.Debug("CNDC.DAL.ConnexionOracleMgr", "Abriendo Conexion a BD");
                if (_cadenaConexion == "")
                {
                    //Log.Instance.write("No se ha definido cadena de conexión");
                    throw new Exception("No se ha definido cadena de conexión");
                }
                try
                {
                    _connexion = new OracleConnection(_cadenaConexion);
                    _connexion.Open();
                    PistaMgr.Instance.Debug("CNDC.DAL.ConnexionOracleMgr", "Conexion a BD abierta");
                }
                catch (Exception exception)
                {
                    PistaMgr.Instance.EscribirEnLocal("DAL", exception);
                }
            }
        }

        public OracleTransaction IniciarTransaccion()
        {
            if (_transaccionIniciada)
            {
                throw new Exception("Transaccion ya iniciada");
            }
            _transaccionActual = _connexion.BeginTransaction();
            _transaccionIniciada = true;
            return _transaccionActual;
        }

        public OracleCommand CrearCommand()
        {
            OracleCommand command = null;
            try
            {
                AsegurarConexion();
                command = _connexion.CreateCommand();
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DAL", exception);
            }

            return command;
        }

        public DataTable GetTabla(string nombreTabla)
        {
            DataTable resultado = EjecutarSql("SELECT * FROM " + nombreTabla);
            resultado.TableName = nombreTabla;
            return resultado;
        }

        #endregion Methods

        public event EventHandler ConexionPerdida;

        int _contador = 0;

        private string GetContador()
        {
            if (_contador == 0)
            {
                return string.Empty;
            }
            else
            {
                return "-" + _contador;
                _contador ++ ;
            }
        }

         public void EscribirLogDetalle(string module, Exception e, OracleCommand  ocm)
        {
            string directorioLog = RegistradorArchLocal.Instancia.GetCarpetaLog;

           
            string directorioPistas = Path.Combine(directorioLog, "Logs_orcl");

            if (!Directory.Exists(directorioPistas))
            {
                Directory.CreateDirectory(directorioPistas);
            }
            string NombreArchivo = string.Empty;
             if (string.IsNullOrEmpty(NombreArchivo))
            {
                NombreArchivo = string.Format("{0}\\Log{1}{2}.log", directorioPistas, DateTime.Now.ToString("yyyyMMMddhhmmss"), GetContador());
            }
            else
            {
                NombreArchivo = string.Format("{0}\\{1}{2}{3}.log", directorioPistas, NombreArchivo, DateTime.Now.ToString("yyyyMMMddhhmmss"), GetContador());
            }

             using (System.IO.StreamWriter file = new System.IO.StreamWriter(NombreArchivo))
            {
                file.WriteLine(e.Message );
                file.WriteLine(e.StackTrace);
                file.WriteLine(ocm.CommandText);
                foreach (OracleParameter prm in ocm.Parameters)
                {
                     file.WriteLine(string.Format ("{0} : {1}" , prm.ParameterName , prm.Value ));
                }
            }
        }
        public DataTable EjecutarCmd(OracleCommand cmd)
        {
            DataTable resultado = new DataTable();
            OracleDataAdapter adap = null;
            bool continuar = true;
            int contadorIntentos = 0;
            bool disposeCmd = false;
            if (_conexionPerdida)
            {
                return resultado;
            }

            while (continuar && contadorIntentos < 3)
            {
                continuar = false;
                try
                {
                    adap = new OracleDataAdapter(cmd);
                    adap.Fill(resultado);
                    disposeCmd = true;
                }
                catch (OracleException oraEx)
                {                    
                    switch (oraEx.Number)
                    {
                        case 3114:
                            _connexion.Dispose();
                            _connexion = null;
                            AsegurarConexion();
                            cmd.Connection = _connexion;
                            continuar = true;
                            break;
                        case 3113:
                        case 3135:
                        case -2:
                            OnConexionPerdida();
                            break;
                    }
                    PistaMgr.Instance.Error("CNDC.DAL", oraEx);
                    PistaMgr.Instance.Error("CNDC.DAL", cmd.CommandText);
                    PistaMgr.Instance.Error("CNDC.DAL", CNDC.UtilesComunes.CallStackMgr.GetPilaLlamadas());

                    EscribirLogDetalle("CNDC.DAL", (Exception)oraEx, cmd);

                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("CNDC.DAL", ex);
                    PistaMgr.Instance.Error("CNDC.DAL", cmd.CommandText);

                    EscribirLogDetalle("CNDC.DAL", ex, cmd);
                }
                finally
                {
                    if (disposeCmd || contadorIntentos == 2)
                    {
                        DisposeCommand(cmd);
                    }

                    if (adap != null)
                    {
                        adap.Dispose();
                    }
                }
                contadorIntentos++;
            }
            return resultado;
        }

        private void OnConexionPerdida()
        {
            _conexionPerdida = true;
            if (ConexionPerdida != null)
            {
                ConexionPerdida(this, EventArgs.Empty);
            }
        }

        public DataTable EjecutarSql(string sql)
        {
            DataTable resultado = new DataTable();
            try
            {
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                resultado = EjecutarCmd(cmd);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("CNDC.DAL", ex);
            }
            return resultado;
        }

        private static OracleDbType GetOracleDbType(object o)
        {
            if (o is string) return OracleDbType.Varchar2;
            if (o is DateTime) return OracleDbType.Date;
            if (o is Int64) return OracleDbType.Int64;
            if (o is Int32) return OracleDbType.Int32;
            if (o is Int16) return OracleDbType.Int16;
            if (o is byte) return OracleDbType.Byte;
            if (o is decimal) return OracleDbType.Decimal;
            if (o is float) return OracleDbType.Single;
            if (o is double) return OracleDbType.Double;
            if (o is byte[]) return OracleDbType.Blob;
            return OracleDbType.Varchar2;
        }

        public bool Actualizar(OracleCommand cmd)
        {
            bool resultado = true;
            if (_conexionPerdida)
            {
                DisposeCommand(cmd);
                return false;
            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException oraEx)
            {
                resultado = false;
                switch (oraEx.Number)
                {
                    case 3114:
                        break;
                    case 3113:
                    case 3135:
                    case -2:
                        OnConexionPerdida();
                        break;
                }
                PistaMgr.Instance.Error("CNDC.DAL", oraEx);
                PistaMgr.Instance.Error("CNDC.DAL", cmd.CommandText);


                foreach (OracleParameter opr in cmd.Parameters)
                {
                    object o = opr.Value;
                    string s = string.Empty;
                    if (o is Array)
                    {
                        foreach (object it in o as Array )
                        {
                            s += it.ToString() + " - ";
                        }

                    }
                    else
                    {
                        s = o.ToString();
                    }

                    PistaMgr.Instance.Error ( "CNDC.DAL", string.Format ("Parametro:{0} - Val {1}", opr.ParameterName ,s  ));
                }
                PistaMgr.Instance.Error("CNDC.DAL", CNDC.UtilesComunes.CallStackMgr.GetPilaLlamadas());
            }
            catch (Exception ex)
            {
                resultado = false;
                PistaMgr.Instance.Error("CNDC.DAL", ex);
                PistaMgr.Instance.Error("CNDC.DAL1", ex.ToString());
                PistaMgr.Instance.Error("CNDC.DAL", cmd.CommandText);
            }
            finally
            {
                DisposeCommand(cmd);
            }

            return resultado;
        }

        public DataTable GetEsquema(string nombreTabla)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "SELECT * FROM " + nombreTabla + " WHERE rownum=0";            
            DataTable resultado = EjecutarCmd(cmd);
            resultado.TableName = nombreTabla;
            return resultado;
        }

        public DateTime? GetFechaHora()
        {
            DateTime? resultado = null;
            DataTable tabla = EjecutarSql("select sysdate from dual");
            if (tabla.Rows.Count > 0)
            {
                resultado = (DateTime)tabla.Rows[0][0];
            }
            return resultado;
        }

        public void Dispose()
        {
            FinalizarConexion();
        }

        public void Actualizar(string sql)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            Actualizar(cmd);
        }

        public Array GetArray(List<DataRow> rows, string campo)
        {
            IConvertible[] resultado = new IConvertible[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                resultado[i] = (IConvertible)rows[i][campo];
            }
            return resultado;
        }
    }
}
