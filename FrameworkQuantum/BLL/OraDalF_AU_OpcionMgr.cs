using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;

namespace CNDC.BLL
{
    public class OraDalF_AU_OpcionMgr : OraDalBaseMgr
    {
        #region Singleton
        private static OraDalF_AU_OpcionMgr _instancia;
        static OraDalF_AU_OpcionMgr()
        {
            _instancia = new OraDalF_AU_OpcionMgr();
        }
        public static OraDalF_AU_OpcionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalF_AU_OpcionMgr()
        {

        }
        #endregion Singleton

        public bool TieneOpcion(string login, long numOpcion)
        {
            bool resultado = false;
            string sql = @"SELECT COUNT(*) FROM F_AU_RROL_OPCIONES rOp WHERE rOP.num_opcion=:num_opcion
            AND Rop.num_rol IN (SELECT ur.num_rol FROM f_au_rusuarios_roles ur WHERE ur.login=:login)";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("num_opcion", numOpcion);
            cmd.Parameters.Add("login", login);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                decimal cantidad = (decimal)tabla.Rows[0][0];
                resultado = cantidad > 0;
            }
            return resultado;
        }

        public DataTable GetOpcionesDeModulo(Modulo m)
        {
            string sql = "SELECT * FROM f_au_opciones WHERE fk_cod_modulo={0} ORDER BY orden_vista";
            sql = string.Format(sql, m.PkCodModulo);
            DataTable resultado = EjecutarSql(sql);
            return resultado;
        }

        public bool AsignacioOpciones(Rol r, List<long> opcionesNuevas)
        {
            bool resultado = false;
            if (opcionesNuevas.Count > 0)
            {
                Pista p = PistaMgr.Instance.Info("OraDalModuloMgr", "Asignando opciones a rol " + r.NombreCorto);
                long secLog = (long)p.PK_SecLog;

                foreach (long idOp in opcionesNuevas)
                {
                    string sql = @"INSERT INTO f_au_rrol_opciones(num_rol,num_opcion,d_cod_estado,sec_log) 
                    VALUES(:num_rol,:num_opcion,:d_cod_estado,:sec_log) ";

                    OracleCommand cmd = CrearCommand();
                    cmd.CommandText = sql;
                    cmd.BindByName = true;
                    cmd.Parameters.Add("num_rol", OracleDbType.Int64, r.Num_Rol, System.Data.ParameterDirection.Input);
                    cmd.Parameters.Add("num_opcion", OracleDbType.Int64, idOp, System.Data.ParameterDirection.Input);
                    cmd.Parameters.Add("D_COD_ESTADO", OracleDbType.Varchar2, "1", System.Data.ParameterDirection.Input);
                    cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, secLog, System.Data.ParameterDirection.Input);
                    if (Actualizar(cmd))
                    {
                        resultado = true;
                    }
                }
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }

        public bool QuitarOpciones(Rol r, List<long> opcionesEliminadas)
        {
            bool resultado = false;
            if (opcionesEliminadas.Count > 0)
            {
                string sql = "DELETE FROM f_au_rrol_opciones WHERE num_rol={0} AND num_opcion IN ({1})";
                sql = string.Format(sql, r.Num_Rol, GetSeparadorPorComa(opcionesEliminadas));
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                if (Actualizar(cmd))
                {
                    resultado = true;
                }
            }
            else
            {
                resultado = true;
            }
            return resultado;
        }

        private string GetSeparadorPorComa(List<long> opcionesEliminadas)
        {
            string resultado = string.Empty;
            foreach (long i in opcionesEliminadas)
            {
                if (!string.IsNullOrEmpty(resultado))
                {
                    resultado += ",";
                }
                resultado += i;
            }
            return resultado;
        }

        public List<long> GetOpcionesAsignadasAlRolPorModulo(Rol rol, Modulo moduloSeleccionado)
        {
            List<long> resultado = new List<long>();
            string sql = @"SELECT r.num_opcion FROM f_au_rrol_opciones r WHERE r.num_rol={0} AND r.num_opcion IN 
            (SELECT o.num_opcion FROM f_au_opciones o WHERE fk_cod_modulo={1})";
            sql = string.Format(sql, rol.Num_Rol,moduloSeleccionado.PkCodModulo);
            DataTable tabla = EjecutarSql(sql);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r["num_opcion"]);
            }
            return resultado;
        }

        public DataTable GetTablaOpcionesPorUsuarioModulo(Usuario u, Modulo moduloSeleccionado)
        {
            string sql =
            @"SELECT o.* FROM f_au_opciones o
            WHERE o.fk_cod_modulo=:fk_cod_modulo
            AND o.num_opcion IN 
            (SELECT ro.num_opcion FROM f_au_rrol_opciones ro 
             WHERE ro.num_rol IN 
             (SELECT ur.num_rol FROM f_au_rusuarios_roles ur
              WHERE ur.login=:login
              )
            )
            ORDER BY o.orden_vista";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fk_cod_modulo", moduloSeleccionado.PkCodModulo);
            cmd.Parameters.Add("login", u.Login);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}
