using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using CNDC.BLL;

namespace CNDC.Sincronizacion
{
    public class AyudanteSincronizacion
    {
        ConnexionOracleMgr _conexion;
        /*
         * @jjla:26/Marzo/2014 ; mejora sincronización
         */
        public DataTable GetSincronizacionInformesFalla()
        {
            string sql = @"SELECT pk_cod_falla,
                              pk_origen_informe,
                              pk_d_cod_tipoinforme ,
                              sec_log,
                              sinc_ver
                            FROM f_gf_informefalla
                            ORDER BY pk_cod_falla DESC ,
                              pk_origen_informe ASC ,
                              pk_d_cod_tipoinforme ASC";
            Pistas.PistaMgr.Instance.Debug("SISFALLA","EJECUTANDO Sincronizacion Informes");
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = sql;
            DataTable tb = _conexion.EjecutarCmd(cmd);
            if (tb != null)
            {
                tb.TableName = "SINC";
                Pistas.PistaMgr.Instance.Debug("SISFALLA", "Informes Falla" + tb.Rows.Count );
            }
            return tb;
        }

         
        public AyudanteSincronizacion(ConnexionOracleMgr c)
        {
            _conexion = c;
        }

        public DataTable GetRegistros(string tabla, decimal versionCliente, long pkCodPersona)
        {
            string sql = "select * from {0} where {1}>:SINC_VER";
            sql = string.Format(sql, tabla, "SINC_VER");

            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("SINC_VER", OracleDbType.Decimal, versionCliente, System.Data.ParameterDirection.Input);

            DataTable tb = _conexion.EjecutarCmd(cmd);
            tb.TableName = tabla;
            return tb;
        }

        public Dictionary<string, decimal> TablesColumns()
        { 
             //string sql = "SELECT SINC_ORDER, NOMBRE_TABLA as tablename, GET_P_SINC (NOMBRE_TABLA) MAX FROM P_SINC_TABLAS ORDER BY SINC_ORDER";
            string sql = @"SELECT COUNT(*) num_columns,
                              table_name    
                            FROM all_tab_columns a,
                              p_sinc_tablas b
                            WHERE owner    = 'QUANTUM'
                            AND table_name =b.nombre_tabla
                            GROUP BY table_name
                            ORDER BY 2 ";
            Dictionary<string, decimal> resultado = new Dictionary<string, decimal>();

            DataTable tb = _conexion.EjecutarSql(sql);

            foreach (DataRow row in tb.Rows)
            {
                resultado[(string)row["TABLE_NAME"]] = ObjetoDeNegocio.GetValor<decimal>(row["NUM_COLUMNS"]);
            }
            return resultado;
        }

        public Dictionary<string, decimal> GetMaxSincVer()
        {
            Console.WriteLine("GetMaxSincVer:::::::::::::::::::::::::::::::::::::::::::::::");
            //string sql = "SELECT SINC_ORDER, NOMBRE_TABLA as tablename, GET_P_SINC (NOMBRE_TABLA) MAX FROM P_SINC_TABLAS ORDER BY SINC_ORDER";
            string sql = "SELECT SINC_ORDER, NOMBRE_TABLA as tablename, GET_P_SINC (NOMBRE_TABLA) MAX FROM P_SINC_TABLAS ORDER BY SINC_ORDER";
            Dictionary<string, decimal> resultado = new Dictionary<string, decimal>();

            DataTable tb = _conexion.EjecutarSql(sql);

            foreach (DataRow row in tb.Rows)
            {
                resultado[(string)row["TABLENAME"]] = ObjetoDeNegocio.GetValor<decimal>(row["MAX"]);
            }
            return resultado;
        }
    }
}
