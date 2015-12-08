using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.DAL;
using Oracle.DataAccess.Client;

namespace CNDC.BLL
{
    public class OraDalUsuarioMgr : OraDalBaseMgr, IUsuarioMgr
    {
        #region Singleton
        private static OraDalUsuarioMgr _instancia;
        static OraDalUsuarioMgr()
        {
            _instancia = new OraDalUsuarioMgr();
        }
        public static OraDalUsuarioMgr Instancia
        {
            get { return _instancia; }
        }

        public OraDalUsuarioMgr()
        {

        }

        public OraDalUsuarioMgr(ConnexionOracleMgr c):base(c)
        {
        }
        #endregion Singleton

        public const string NOMBRE_TABLA = "F_AU_USUARIOS";

        public void Guardar(Usuario obj)
        {
        }

        public override string NombreTabla
        { get { return NOMBRE_TABLA; } }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<Usuario> GetLista()
        {
            BindingList<Usuario> resultado = new BindingList<Usuario>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new Usuario(row));
            }
            return resultado;
        }

        const string PREFIJO = "OPS$";
        public Usuario GetUsuarioPorLogin(string login)
        {
            string sql = "SELECT * FROM {0} WHERE {1}=:{1}";
            sql = string.Format(sql, NOMBRE_TABLA, Usuario.C_LOGIN);
            Usuario resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(Usuario.C_LOGIN, OracleDbType.Varchar2, PREFIJO + login.ToUpper(), ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);

            if (tabla.Rows.Count > 0)
            {
                resultado = new Usuario(tabla.Rows[0]);
            }

            return resultado;
        }

        public DataTable GetOperadores()
        {
            DataTable resultado = null;
            string sql = 
            @"SELECT p.PK_COD_PERSONA,p.NOM_PERSONA,p.SIGLA,p.D_COD_TIPO_PERSONA,p.DIRECCION,p.TELEFONO,p.IDENTIFICACION,p.D_COD_ESTADO,p.SEC_LOG,p.SINC_VER
            FROM f_ap_persona p , 
              (SELECT u.*
               FROM f_au_usuarios u , f_au_rusuarios_roles ur, f_au_roles r
               WHERE u.login = ur.login 
               AND ur.num_rol = r.num_rol 
               AND r.d_cod_estado = 1 
               AND u.d_cod_estado = 1 
               AND r.nombre_corto ='OPERADOR'
              ) b
            WHERE b.pk_cod_usuario = p.pk_cod_persona ";

            resultado = EjecutarSql(sql);
            resultado.TableName = NOMBRE_TABLA;
            return resultado;
        }

        public DataTable GetSupervisores()
        {
            DataTable resultado = null;
            string sql =
            @"SELECT p.PK_COD_PERSONA,p.NOM_PERSONA,p.SIGLA,p.D_COD_TIPO_PERSONA,p.DIRECCION,p.TELEFONO,p.IDENTIFICACION,p.D_COD_ESTADO,p.SEC_LOG,p.SINC_VER
            FROM f_ap_persona p , 
              (SELECT u.*
               FROM f_au_usuarios u , f_au_rusuarios_roles ur, f_au_roles r
               WHERE u.login = ur.login 
               AND ur.num_rol = r.num_rol 
               AND r.d_cod_estado = 1 
               AND u.d_cod_estado = 1 
               AND r.nombre_corto ='SUPERVISOR'
              ) b
            WHERE b.pk_cod_usuario = p.pk_cod_persona ";

            resultado = EjecutarSql(sql);
            resultado.TableName = NOMBRE_TABLA;
            return resultado;
        }
        public DataTable GetUsuariosConNombres()
        {
            string sql =
            @"SELECT u.login,p.nom_persona,u.d_cod_estado 
            FROM F_AP_PERSONA p,F_AU_USUARIOS u
            WHERE u.PK_COD_USUARIO=p.PK_COD_PERSONA";
            DataTable resultado = EjecutarSql(sql);
            return resultado;
        }
    }
}
