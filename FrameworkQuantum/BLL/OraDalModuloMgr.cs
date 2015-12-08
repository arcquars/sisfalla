using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace CNDC.BLL
{
    public class OraDalModuloMgr : OraDalBaseMgr
    {
        #region Singleton
        private static OraDalModuloMgr _instancia;
        static OraDalModuloMgr()
        {
            _instancia = new OraDalModuloMgr();
        }
        public static OraDalModuloMgr Instancia
        {
            get { return _instancia; }
        }

        public OraDalModuloMgr()
        {

        }

        public OraDalModuloMgr(ConnexionOracleMgr c)
            : base(c)
        {
        }
        #endregion Singleton

        public BindingList<Modulo> GetModulos()
        {
            string sql = "SELECT * FROM f_au_modulo";
            BindingList<Modulo> resultado = GetBindingList(sql);
            return resultado;
        }

        private BindingList<Modulo> GetBindingList(string sql)
        {
            DataTable tabla = EjecutarSql(sql);
            BindingList<Modulo> resultado = GetBindingList(tabla);
            return resultado;
        }

        private BindingList<Modulo> GetBindingList(DataTable tabla)
        {
            BindingList<Modulo> resultado = new BindingList<Modulo>();
            foreach (DataRow r in tabla.Rows)
            {
                Modulo m = new Modulo(r);
                resultado.Add(m);
            }
            return resultado;
        }

        public BindingList<Modulo> GetModulosNOAsignados(Rol rol)
        {
            string sql = "SELECT * FROM f_au_modulo m WHERE m.pk_cod_modulo NOT IN(SELECT a.pk_cod_modulo FROM f_au_rrol_modulo a WHERE a.pk_num_rol ={0})";
            sql = string.Format(sql, rol.Num_Rol);
            BindingList<Modulo> resultado = GetBindingList(sql);
            return resultado;
        }

        public BindingList<Modulo> GetModulosAsignados(Rol rol)
        {
            string sql =
            @"SELECT m.*, a.prioridad
            FROM f_au_modulo m, f_au_rrol_modulo a 
            WHERE m.pk_cod_modulo=a.pk_cod_modulo AND a.pk_num_rol ={0}
            ORDER BY a.prioridad";
            sql = string.Format(sql, rol.Num_Rol);
            BindingList<Modulo> resultado = GetBindingList(sql);
            return resultado;
        }

        public bool AsignarModulo(long idModulo, Rol rol)
        {
            bool resultado = false;
            string sql = @"INSERT INTO F_AU_RROL_MODULO(pk_num_rol,pk_cod_modulo,d_cod_estado,sec_log) 
            VALUES(:pk_num_rol,:pk_cod_modulo,:d_cod_estado,:sec_log)";

            OracleCommand cmd = null;
            Pista p = PistaMgr.Instance.Info("OraDalModuloMgr", "Asignando modulo " + idModulo + " a rol " + rol.NombreCorto);
            long secLog = (long)p.PK_SecLog;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("pk_num_rol", OracleDbType.Int64, rol.Num_Rol, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_modulo", OracleDbType.Int64, idModulo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ESTADO", OracleDbType.Varchar2, "1", System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, secLog, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                resultado = true;
            }

            return resultado;
        }

        public bool QuitarModulo(long idModulo, Rol rol)
        {
            bool resultado = false;

            string sql = @"DELETE FROM F_AU_RROL_MODULO
            WHERE pk_num_rol=:pk_num_rol AND pk_cod_modulo=:pk_cod_modulo";

            OracleCommand cmd = null;
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("pk_num_rol", OracleDbType.Int64, rol.Num_Rol, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_modulo", OracleDbType.Int64, idModulo, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                resultado = true;
            }

            return resultado;
        }

        public bool PonerPrioridad(BindingList<Modulo> modulosAsignados, Rol rol)
        {
            bool resultado = false;
            for (int i = 0; i < modulosAsignados.Count; i++)
            {
                string sql =
                @"UPDATE F_AU_RROL_MODULO
                SET prioridad=:prioridad 
                WHERE pk_num_rol=:pk_num_rol AND pk_cod_modulo=:pk_cod_modulo";

                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.BindByName = true;
                cmd.Parameters.Add("pk_num_rol", OracleDbType.Int64, rol.Num_Rol, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("pk_cod_modulo", OracleDbType.Int64, modulosAsignados[i].PkCodModulo, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("prioridad", OracleDbType.Int16, i, System.Data.ParameterDirection.Input);
                if (Actualizar(cmd))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        public BindingList<Modulo> GetModulosAsignadosAUsuario(string p)
        {
            BindingList<Modulo> resultado = new BindingList<Modulo>();
            string sql =
            @"select distinct m.*, rrm.prioridad
            from f_au_modulo m, f_au_rrol_modulo rrm
            where 
            m.pk_cod_modulo=rrm.pk_cod_modulo
            and rrm.pk_num_rol in (Select ur.NUM_ROL from f_au_rusuarios_roles ur
            where ur.login=:login)
            ORDER BY rrm.prioridad";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("login", OracleDbType.Varchar2, p, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            resultado = GetBindingList(tabla);
            return resultado;
        }
    }
}
