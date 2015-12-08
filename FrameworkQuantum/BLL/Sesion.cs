using System;
using System.Collections.Generic;
using System.Text;
using CNDC.Pistas;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Data;

namespace CNDC.BLL
{
    public class Sesion
    {
        #region Singleton
        private static Sesion _intance;
        public static Sesion Instancia
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new Sesion();
                }
                return _intance;
            }
        }

        private Sesion()
        {
            _configConexion = new ConfigConexionMgr();
        }
        #endregion

        #region Fields
        private Usuario _usuarioActual;
        private Persona _empresaActual;
        private List<Rol> _rolesActuales;
        private long _secLogSesion;
        private Dictionary<string, object> _objetosGlobales;
        private DateTime Logontime;
        private string Hostname;
        private string IpName;
        private string _rolSIN;
        private string _tokenSesion;
        private int _idSesion;
        private bool _sesionIniciada = false;
        #endregion Fields

        public const string FORMATO_FECHA = "dd/MM/yyyy HH:mm:ss";
        public Modulo ModuloActual { get; set; }
        public Usuario UsuarioActual
        { get { return _usuarioActual; } }

        public List<Rol> RolesActuales
        { get { return _rolesActuales; } }

        public Persona EmpresaActual
        { get { return _empresaActual; } }

        public long SecLogSesion
        { get { return _secLogSesion; } }

        public string RolSIN
        { get { return _rolSIN; } }

        public string TokenSession
        { get { return _tokenSesion; } }

        public bool SesionIniciada
        { get { return _sesionIniciada; } }

        public int IdSesion
        {
            get { return _idSesion; }
        }

        public DataRow ConfiguracionCorreo
        { get; set; }
        public DataRow ConfigEnvioQuantum
        { get; set; }
        ConfigConexionMgr _configConexion;
        public ConfigConexionMgr ConfigConexion
        {
            get { return _configConexion; } 
        }

        ConnexionOracleMgr _conexion;
        public ConnexionOracleMgr Conexion
        {
            get { return _conexion; }
        }

        public DateTime? FechaHoraServidor { get; set; }

      
        public ErrorInicioSession IniciarSesion(string login, string pass)
        {
            ErrorInicioSession resultado = ErrorInicioSession.SinError;
            PistaMgr.Instance.RegistradorBD = new DBLogWriter();
            _objetosGlobales = new Dictionary<string, object>();
            OracleCommand cmd = null;
            try
            {
                _configConexion.Inicializar(login, pass);
                _conexion = new ConnexionOracleMgr(_configConexion.CadenaConexion);
                AsegurarDatosInicioSesion();

                decimal num = 0;
                cmd = _conexion.CrearCommand();
                cmd.CommandText = "STARTSESSION";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("RETURN", OracleDbType.Decimal).Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                num = ((Oracle.DataAccess.Types.OracleDecimal)(cmd.Parameters["RETURN"].Value)).Value;
                _secLogSesion = (long)num;
                PistaMgr.Instance.Usuario = login;
                PistaMgr.Instance.Info("BLL", "Inicio Sesion: SecLogSesion = " + _secLogSesion);
                _tokenSesion = string.Format("Usuario={0}|Contrasena={1}", login, pass);
                _sesionIniciada = true;

                  
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1017 || ex.Number == 1005)
                {
                    resultado = ErrorInicioSession.UsuarioNoValido;
                }
                else if (ex.Number == 28009)
                {
                    resultado = ErrorInicioSession.UsuarioNoValidoParaSisFalla;
                }
                else
                {
                    resultado = ErrorInicioSession.ErrorConexionBD;
                }
                PistaMgr.Instance.Error("DALSisFalla", ex);
            }
            catch (Exception ex)
            {
                
                PistaMgr.Instance.Error("DALSisFalla", ex);
                resultado = ErrorInicioSession.OtroError;
            }
            finally
            {
                _conexion.DisposeCommand(cmd);
            }

            return resultado;
        }

        private void AsegurarDatosInicioSesion()
        {
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = "INICIOSESSION.InformacionSession";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter p_refcursorAgente = new OracleParameter();
            OracleParameter p_refcursorRol = new OracleParameter();
            OracleParameter p_refcursorDatosUsuario = new OracleParameter();
            OracleParameter p_refcursorSession = new OracleParameter();
            OracleParameter p_refcursorRolEmpresa = new OracleParameter();

            p_refcursorAgente.OracleDbType = OracleDbType.RefCursor;
            p_refcursorRol.OracleDbType = OracleDbType.RefCursor;
            p_refcursorDatosUsuario.OracleDbType = OracleDbType.RefCursor;
            p_refcursorSession.OracleDbType = OracleDbType.RefCursor;
            p_refcursorRolEmpresa.OracleDbType = OracleDbType.RefCursor;

            p_refcursorAgente.Direction = ParameterDirection.Output;
            p_refcursorRol.Direction = ParameterDirection.Output;
            p_refcursorDatosUsuario.Direction = ParameterDirection.Output;
            p_refcursorSession.Direction = ParameterDirection.Output;
            p_refcursorRolEmpresa.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(p_refcursorAgente);
            cmd.Parameters.Add(p_refcursorRol);
            cmd.Parameters.Add(p_refcursorDatosUsuario);
            cmd.Parameters.Add(p_refcursorSession);
            cmd.Parameters.Add(p_refcursorRolEmpresa);

            PistaMgr.Instance.Debug("Sesion", "Previo Sesion");
            PistaMgr.Instance.Debug("Sesion", "Iniciando Sesion");

            DataSet ds = new DataSet();
            OracleDataAdapter da = null;
            try
            {
                PistaMgr.Instance.Debug("Sesion", "Iniciando TRY");

                da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                PistaMgr.Instance.Debug("Sesion", "Fin TRY");
            }
            catch (Exception excep)
            {
                PistaMgr.Instance.Error("Sesion", excep);
            }
            foreach (DataTable tabla in ds.Tables)
            {
                PistaMgr.Instance.Debug("Sesion", string.Format("TABLA: {0} REGISTROS:{1}", tabla.TableName, tabla.Rows.Count));
            }
            _empresaActual = new Persona(ds.Tables[0].Rows[0]);
            _rolesActuales = readRoles(ds.Tables[1]);
            _usuarioActual = new Usuario(ds.Tables[2].Rows[0]);
            _rolSIN = ObjetoDeNegocio.GetValor<string>(ds.Tables[4].Rows[0]["NOM_ROL"]);
            ReadValuesSession(ds.Tables[3]);

            _conexion.DisposeCommand(cmd);
            if (da != null)
            {
                da.Dispose();
            }

            _idSesion = GetIdSesionBD();
            PistaMgr.Instance.Debug("Sesion", "Sesion Iniciada IdSesion = " + _idSesion);
        }

        private int GetIdSesionBD()
        {
            int resultado = 0;
            string sql = "select userenv('sessionid') from dual";
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = sql;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                resultado = (int)reader.GetDecimal(0);
            }
            _conexion.DisposeCommand(cmd);
            return resultado;
        }

        private List<Rol> readRoles(DataTable dt)
        {
            List<Rol> roles = new List<Rol>();

            foreach (DataRow dr in dt.Rows)
            {
                Rol rol = new Rol(dr);
                roles.Add(rol);
            }

            return roles;
        }

        private void ReadValuesSession(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                SetObjetoGlobal("host", dr["host"]);
                SetObjetoGlobal("ipclient", dr["ip"]);
                SetObjetoGlobal("logontime", dr["SYSDATE"]);
            }
        }

        public void SetObjetoGlobal(string nombre, object valor)
        {
            _objetosGlobales[nombre] = valor;
        }

        public T GetObjetoGlobal<T>(string nombre)
        {
            T resultado = default(T);
            if (_objetosGlobales.ContainsKey(nombre))
            {
                resultado = (T)_objetosGlobales[nombre];
            }
            return resultado;
        }

        public object[] RoleToObjectArray()
        {
            System.Collections.ArrayList a = new System.Collections.ArrayList();

            foreach (Rol rol in RolesActuales)
            {
                a.Add(rol.Descripcion);
            }
            return (a.ToArray());
        }

        public bool UsuarioActualTieneRol(Roles Rol)
        {
            return UsuarioActualTieneRol((int)Rol);
        }

        public bool UsuarioActualTieneRol(int idRol)
        {
            bool resultado = false;
            foreach (var r in _rolesActuales)
            {
                if (r.Num_Rol == idRol)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }
    }

    public enum ErrorInicioSession
    {
        SinError,
        UsuarioNoValido,
        ErrorConexionBD,
        OtroError,
        UsuarioNoValidoParaSisFalla
    }
}