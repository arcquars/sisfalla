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
    public class OraDalMC_RPuntoMedicionFormatoDetalleMgr : OraDalBaseMgr, IRMedidorCanalMgr
    {
        #region Singleton
        private static OraDalMC_RPuntoMedicionFormatoDetalleMgr _instancia;
        static OraDalMC_RPuntoMedicionFormatoDetalleMgr()
        {
            _instancia = new OraDalMC_RPuntoMedicionFormatoDetalleMgr();
        }
        public static OraDalMC_RPuntoMedicionFormatoDetalleMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_RPuntoMedicionFormatoDetalleMgr()
        {

        }
        #endregion Singleton

        public bool Guardar(MC_RPuntoMedicionFormatoDetalle obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodRPtoMedFtoDetalle = GetIdAutoNum("SEC_PK_RMED_CANAL");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} " +
                "WHERE {1}=:{1}";
            }

            sql = string.Format(sql, MC_RPuntoMedicionFormatoDetalle.NOMBRE_TABLA,
            MC_RPuntoMedicionFormatoDetalle.C_PK_RPTO_MED_FTO_DET,
            MC_RPuntoMedicionFormatoDetalle.C_FK_COD_RPTO_MED_FTO,
            MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC,
            MC_RPuntoMedicionFormatoDetalle.C_CANAL,
            MC_RPuntoMedicionFormatoDetalle.C_COL_ARCHIVO,
            MC_RPuntoMedicionFormatoDetalle.C_KC,
            MC_RPuntoMedicionFormatoDetalle.C_KCT,
            MC_RPuntoMedicionFormatoDetalle.C_KPT,
            MC_RPuntoMedicionFormatoDetalle.C_D_COD_ESTADO,
            MC_RPuntoMedicionFormatoDetalle.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_PK_RPTO_MED_FTO_DET, OracleDbType.Int64, obj.PkCodRPtoMedFtoDetalle, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_FK_COD_RPTO_MED_FTO, OracleDbType.Int64, obj.FkCodRPtoMedFto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.FkCodMagnitudElec, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_CANAL, OracleDbType.Int64, obj.Canal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_COL_ARCHIVO, OracleDbType.Varchar2, obj.ColArchivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_KC, OracleDbType.Double, obj.Kc, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_KCT, OracleDbType.Double, obj.Kct, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_KPT, OracleDbType.Double, obj.Kpt, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormatoDetalle.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);


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
            DataTable tabla = GetTabla(MC_RPuntoMedicionFormatoDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_RPuntoMedicionFormatoDetalle> GetLista()
        {
            BindingList<MC_RPuntoMedicionFormatoDetalle> resultado = new BindingList<MC_RPuntoMedicionFormatoDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_RPuntoMedicionFormatoDetalle(row));
            }
            return resultado;
        }

        public DataTable GetMagnitudesElectricas(MC_RPuntoMedicionFormato rMedFto)
        {
            return GetMagnitudesElectricas(rMedFto.PkCodRptoMedFto);
        }

        public DataTable GetMagnitudesElectricas(long codRptoMedFto)
        {
            string sql =
            @"SELECT * FROM f_mc_rpto_med_fto_det WHERE fk_cod_rpto_med_fto=:codRptoMedFto";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("codRptoMedFto", OracleDbType.Int64, codRptoMedFto, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public List<MC_RPuntoMedicionFormatoDetalle> GetListaDefMagElec(long codRptoMedFto)
        {
            List<MC_RPuntoMedicionFormatoDetalle> resultado = new List<MC_RPuntoMedicionFormatoDetalle>();
            DataTable tabla = GetMagnitudesElectricas(codRptoMedFto);
            foreach (DataRow r in tabla.Rows)
            {
                MC_RPuntoMedicionFormatoDetalle rmc = new MC_RPuntoMedicionFormatoDetalle(r);
                resultado.Add(rmc);
            }
            return resultado;
        }

        public DataTable GetMagnitudesPorPuntoMedicion(long codPuntoMedicion)
        {
            string sql =
            @"SELECT me.pk_cod_magnitud_elec,
              me.nombre_magnitud_elec
            FROM p_mc_def_magnitud_elec me
            WHERE me.pk_cod_magnitud_elec IN
              (SELECT DISTINCT(r.FK_COD_MAGNITUD_ELEC)
              FROM f_mc_rpto_med_fto_det r
              WHERE r.fk_cod_rpto_med_fto IN
                (SELECT f.PK_COD_RPTO_MED_FTO
                FROM f_mc_rpto_med_fto f
                WHERE f.fk_cod_punto_medicion=:cod_punto_medicion
                )
              )";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}