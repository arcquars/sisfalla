using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using System.Data;

namespace CNDC.BLL
{
    public class OraDalRolMgr : OraDalBaseMgr
    {
        #region Singleton
        private static OraDalRolMgr _instancia;
        static OraDalRolMgr()
        {
            _instancia = new OraDalRolMgr();
        }
        public static OraDalRolMgr Instancia
        {
            get { return _instancia; }
        }

        public OraDalRolMgr()
        {

        }

        public OraDalRolMgr(ConnexionOracleMgr c)
            : base(c)
        {
        }
        #endregion Singleton

        public override string NombreTabla
        {
            get { return "F_AU_ROLES"; }
        }

        public bool Guardar(Rol obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            obj.CodEstado = "1";

            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("OraDalRolMgr", "Creando Nuevo Rol " + obj.NombreCorto);
                obj.SecLog = (long)p.PK_SecLog;
                obj.Num_Rol = GetIdAutoNum("sec_f_au_roles");
                sql = @"INSERT INTO f_au_roles (num_rol,nombre_corto,descripcion,jerarquia,d_cod_estado,sec_log)
                VALUES(:num_rol,:nombre_corto,:descripcion,:jerarquia,:d_cod_estado,:sec_log)";
            }
            else
            {
                sql = @"UPDATE f_au_roles SET 
                nombre_corto=:nombre_corto,
                descripcion=:descripcion,
                jerarquia=:jerarquia,
                d_cod_estado=:d_cod_estado,
                sec_log=:sec_log
                WHERE num_rol=:num_rol";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("NUM_ROL", OracleDbType.Int64, obj.Num_Rol, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("NOMBRE_CORTO", OracleDbType.Varchar2, obj.NombreCorto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, obj.Descripcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("JERARQUIA", OracleDbType.Int16, obj.Jerarquia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ESTADO", OracleDbType.Varchar2, obj.CodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
            return resultado;
        }

        public DataTable GetTabla()
        {
            DataTable resultado = null;
            string sql = "SELECT * FROM f_au_roles ORDER BY NUM_ROL";
            resultado = EjecutarSql(sql);
            return resultado;
        }

        public List<Rol> GetRolesActivos()
        {
            List<Rol> resultado = new List<Rol>();
            string sql = "SELECT * FROM f_au_roles WHERE d_cod_estado='1' ORDER BY num_rol";
            DataTable tabla = EjecutarSql(sql);
            foreach (DataRow r in tabla.Rows)
            {
                Rol rol = new Rol(r);
                resultado.Add(rol);
            }
            return resultado;
        }

        public List<long> GetRolesDeUsuario(string login)
        {
            List<long> resultado = new List<long>();
            string sql = "SELECT num_Rol FROM f_au_rusuarios_roles WHERE login='{0}'";
            sql = string.Format(sql, login);
            DataTable tabla = EjecutarSql(sql);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r["num_Rol"]);
            }
            return resultado;
        }

        public bool Asignar(List<long> rolesNuevos, string login)
        {
            bool resultado = false;
            foreach (long r in rolesNuevos)
            {
                string sql = @"INSERT INTO f_au_rusuarios_roles(login,num_rol,d_cod_estado,sec_log)
                VALUES(:login,:num_rol,:d_cod_estado,:sec_log)";
                OracleCommand cmd = null;
                Pista p = PistaMgr.Instance.Info("OraDalModuloMgr", "Asignando Rol " + r + " a Usuario " + login);
                long secLog = (long)p.PK_SecLog;

                cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.BindByName = true;
                cmd.Parameters.Add("login", OracleDbType.Varchar2, login, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("num_rol", OracleDbType.Int64, r, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("d_cod_estado", OracleDbType.Varchar2, "1", System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("sec_log", OracleDbType.Int64, secLog, System.Data.ParameterDirection.Input);
                if (Actualizar(cmd))
                {
                    resultado = true;
                }
            }

            return resultado;
        }

        public bool Quitar(List<long> rolesQuitados, string login)
        {
            bool resultado = false;
            foreach (long r in rolesQuitados)
            {
                string sql = @"DELETE FROM f_au_rusuarios_roles
                WHERE login=:login AND num_rol=:num_rol";
                OracleCommand cmd = null;
                
                cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.BindByName = true;
                cmd.Parameters.Add("login", OracleDbType.Varchar2, login, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("num_rol", OracleDbType.Int64, r, System.Data.ParameterDirection.Input);
                
                if (Actualizar(cmd))
                {
                    resultado = true;
                }
            }

            return resultado;
        }
    }
}
