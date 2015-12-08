using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;

namespace MC
{
    public class OraDalMC_MedidorMaxMinMgr : OraDalBaseMgr, IMC_MedidorMaxMinMgr
    {
        #region Singleton
        private static OraDalMC_MedidorMaxMinMgr _instancia;
        static OraDalMC_MedidorMaxMinMgr()
        {
            _instancia = new OraDalMC_MedidorMaxMinMgr();
        }
        public static OraDalMC_MedidorMaxMinMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_MedidorMaxMinMgr()
        {

        }
        #endregion Singleton

        public bool Guardar(MC_MedidorMaxMin obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
            }

            sql = string.Format(sql, MC_MedidorMaxMin.NOMBRE_TABLA,
            MC_MedidorMaxMin.C_PK_COD_MEDIDOR,
            MC_MedidorMaxMin.C_PK_COD_MAGNITUD_ELEC,
            MC_MedidorMaxMin.C_PK_DESDE,
            MC_MedidorMaxMin.C_HASTA,
            MC_MedidorMaxMin.C_MINIMO,
            MC_MedidorMaxMin.C_MAXIMO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_MedidorMaxMin.C_PK_COD_MEDIDOR, OracleDbType.Int64, obj.PkCodMedidor, ParameterDirection.Input);
            cmd.Parameters.Add(MC_MedidorMaxMin.C_PK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.PkCodMagnitudElec, ParameterDirection.Input);
            cmd.Parameters.Add(MC_MedidorMaxMin.C_PK_DESDE, OracleDbType.Date, obj.PkDesde, ParameterDirection.Input);
            cmd.Parameters.Add(MC_MedidorMaxMin.C_HASTA, OracleDbType.Date, obj.Hasta, ParameterDirection.Input);
            cmd.Parameters.Add(MC_MedidorMaxMin.C_MINIMO, OracleDbType.Double, obj.Minimo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_MedidorMaxMin.C_MAXIMO, OracleDbType.Double, obj.Maximo, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                obj.EsNuevo = false;
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
                resultado = false;
            }
            finally
            {
                DisposeCommand(cmd);
            }

            return resultado;
        }

        public DataTable GetTabla()
        {            
            DataTable tabla = GetTabla(MC_MedidorMaxMin.NOMBRE_TABLA);
            return tabla;
        }

        public DataTable GetMaxMin(long pkCodMedidor)
        {
            string sql = @"SELECT mm.*, me.NOMBRE_MAGNITUD_ELEC 
            FROM F_MC_MEDIDOR_FLUJO_MAX_MIN mm, P_MC_DEF_MAGNITUD_ELEC me
            WHERE mm.PK_COD_MEDIDOR=:PK_COD_MEDIDOR AND mm.PK_COD_MAGNITUD_ELEC=me.PK_COD_MAGNITUD_ELEC";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("PK_COD_MEDIDOR", OracleDbType.Int64, pkCodMedidor, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            return tabla;
        }

        public BindingList<MC_MedidorMaxMin> GetLista()
        {
            BindingList<MC_MedidorMaxMin> resultado = new BindingList<MC_MedidorMaxMin>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_MedidorMaxMin(row));
            }
            return resultado;
        }
    }
}