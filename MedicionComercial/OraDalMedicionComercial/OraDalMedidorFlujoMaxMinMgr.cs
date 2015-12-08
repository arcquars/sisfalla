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
    public class OraDalMedidorFlujoMaxMinMgr : OraDalBaseMgr, IMedidorFlujoMaxMinMgr
    {
        #region Singleton
        private static OraDalMedidorFlujoMaxMinMgr _instancia;
        static OraDalMedidorFlujoMaxMinMgr()
        {
            _instancia = new OraDalMedidorFlujoMaxMinMgr();
        }
        public static OraDalMedidorFlujoMaxMinMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMedidorFlujoMaxMinMgr()
        {

        }
        #endregion Singleton

        public bool Guardar(MedidorFlujoMaxMin obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                obj.PkCodMedMaxMin = GetIdAutoNum("SEC_PKCODMEDMAXMIN");
                sql = "INSERT INTO {0} ({1},{2},{3},{4})" +
                "VALUES(:{1},:{2},:{3},:{4})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{1}=:{1} ," +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4}  WHERE ";
            }

            sql = string.Format(sql, MedidorFlujoMaxMin.NOMBRE_TABLA, MedidorFlujoMaxMin.C_PK_COD_MED_MAX_MIN,
            MedidorFlujoMaxMin.C_FK_COD_MEDIDOR,
            MedidorFlujoMaxMin.C_DESDE,
            MedidorFlujoMaxMin.C_HASTA);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MedidorFlujoMaxMin.C_PK_COD_MED_MAX_MIN, OracleDbType.Int64, obj.PkCodMedMaxMin, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMin.C_FK_COD_MEDIDOR, OracleDbType.Int64, obj.FkCodMedidor, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMin.C_DESDE, OracleDbType.Date, obj.Desde, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMin.C_HASTA, OracleDbType.Date, obj.Hasta, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MedidorFlujoMaxMin.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MedidorFlujoMaxMin> GetLista()
        {
            BindingList<MedidorFlujoMaxMin> resultado = new BindingList<MedidorFlujoMaxMin>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MedidorFlujoMaxMin(row));
            }
            return resultado;
        }

        public DataTable GetMaxMin(long pkCodMedidor)
        {
            DataTable resultado = null;
            string sql = "SELECT * FROM f_mc_medidor_flujo_max_min WHERE fk_cod_medidor=:fk_cod_medidor ORDER BY DESDE DESC";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("fk_cod_medidor", OracleDbType.Int64, pkCodMedidor, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);

            return resultado;
        }
    }
}