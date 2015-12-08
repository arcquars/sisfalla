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
    public class OraDalMedidorFlujoMaxMinDetalleMgr : OraDalBaseMgr, IMedidorFlujoMaxMinDetalleMgr
    {
        #region Singleton
        private static OraDalMedidorFlujoMaxMinDetalleMgr _instancia;
        static OraDalMedidorFlujoMaxMinDetalleMgr()
        {
            _instancia = new OraDalMedidorFlujoMaxMinDetalleMgr();
        }
        public static OraDalMedidorFlujoMaxMinDetalleMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMedidorFlujoMaxMinDetalleMgr()
        {

        }
        #endregion Singleton

        public bool Guardar(MedidorFlujoMaxMinDetalle obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3},{4})" +
                "VALUES(:{1},:{2},:{3},:{4})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{3}=:{3} ," +
                "{4}=:{4}  WHERE {1}=:{1} AND {2}=:{2}";
            }

            sql = string.Format(sql, MedidorFlujoMaxMinDetalle.NOMBRE_TABLA, MedidorFlujoMaxMinDetalle.C_PK_COD_MED_MAX_MIN,
            MedidorFlujoMaxMinDetalle.C_PK_COD_MAGNITUD_ELEC,
            MedidorFlujoMaxMinDetalle.C_MINIMO,
            MedidorFlujoMaxMinDetalle.C_MAXIMO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MedidorFlujoMaxMinDetalle.C_PK_COD_MED_MAX_MIN, OracleDbType.Int64, obj.PkCodMedMaxMin, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMinDetalle.C_PK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.PkCodMagnitudElec, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMinDetalle.C_MINIMO, OracleDbType.Double, obj.Minimo, ParameterDirection.Input);
            cmd.Parameters.Add(MedidorFlujoMaxMinDetalle.C_MAXIMO, OracleDbType.Double, obj.Maximo, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MedidorFlujoMaxMinDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MedidorFlujoMaxMinDetalle> GetLista()
        {
            BindingList<MedidorFlujoMaxMinDetalle> resultado = new BindingList<MedidorFlujoMaxMinDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MedidorFlujoMaxMinDetalle(row));
            }
            return resultado;
        }

        public bool CrearDetalle(MedidorFlujoMaxMin medidorMaxMin)
        {
            bool resultado = true;
            List<long> magnitudesAsociadas = OraDalMagnitudElectricaMgr.Instancia.GetMagnitudesAsociadas(medidorMaxMin.FkCodMedidor);
            foreach (long pkCodMagnitudElec in magnitudesAsociadas)
            {
                MedidorFlujoMaxMinDetalle detalle = new MedidorFlujoMaxMinDetalle();
                detalle.EsNuevo = true;
                detalle.PkCodMedMaxMin = medidorMaxMin.PkCodMedMaxMin;
                detalle.PkCodMagnitudElec = pkCodMagnitudElec;
                OraDalMedidorFlujoMaxMinDetalleMgr.Instancia.Guardar(detalle);
            }
            return resultado;
        }

        public DataTable GetMaxMinDetalle(long codMedMaxMin)
        {
            DataTable resultado = null;
            string sql = @"SELECT mm.*, me.NOMBRE_MAGNITUD_ELEC 
            FROM f_mc_medidor_flujo_max_min_det mm, P_MC_DEF_MAGNITUD_ELEC me
            WHERE mm.PK_COD_MAGNITUD_ELEC=me.PK_COD_MAGNITUD_ELEC
            AND pk_cod_med_max_min=:pk_cod_med_max_min";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_med_max_min", OracleDbType.Int64, codMedMaxMin, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);

            return resultado;
        }
    }
}