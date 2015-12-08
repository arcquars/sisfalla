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
    public class OraDalRMedidorCanalMgr : OraDalBaseMgr, IRMedidorCanalMgr
    {
        #region Singleton
        private static OraDalRMedidorCanalMgr _instancia;
        static OraDalRMedidorCanalMgr()
        {
            _instancia = new OraDalRMedidorCanalMgr();
        }
        public static OraDalRMedidorCanalMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalRMedidorCanalMgr()
        {

        }
        #endregion Singleton

        public bool Guardar(RMedidorCanal obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodRmedCanal = GetIdAutoNum("SEC_PK_RMED_CANAL");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11})";
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
                "{10}=:{10} ," +
                "{11}=:{11}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, RMedidorCanal.NOMBRE_TABLA, RMedidorCanal.C_PK_COD_RMED_CANAL,
            RMedidorCanal.C_CANAL,
            RMedidorCanal.C_FK_COD_INFCANAL,
            RMedidorCanal.C_KC,
            RMedidorCanal.C_KCT,
            RMedidorCanal.C_KPT,
            RMedidorCanal.C_D_COD_ESTADO,
            RMedidorCanal.C_SEC_LOG,
            RMedidorCanal.C_FK_COD_MEDIDOR,
            RMedidorCanal.C_COL_ARCHIVO,
            RMedidorCanal.C_FK_COD_FORMATO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(RMedidorCanal.C_PK_COD_RMED_CANAL, OracleDbType.Int64, obj.PkCodRmedCanal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_CANAL, OracleDbType.Int64, obj.Canal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_FK_COD_INFCANAL, OracleDbType.Int64, obj.FkCodInfcanal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_KC, OracleDbType.Double, obj.Kc, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_KCT, OracleDbType.Double, obj.Kct, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_KPT, OracleDbType.Double, obj.Kpt, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_FK_COD_MEDIDOR, OracleDbType.Int64, obj.FkCodMedidor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_COL_ARCHIVO, OracleDbType.Varchar2, obj.ColArchivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RMedidorCanal.C_FK_COD_FORMATO, OracleDbType.Int64, obj.FkCodFormato, System.Data.ParameterDirection.Input);

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
            DataTable tabla = GetTabla(RMedidorCanal.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<RMedidorCanal> GetLista()
        {
            BindingList<RMedidorCanal> resultado = new BindingList<RMedidorCanal>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new RMedidorCanal(row));
            }
            return resultado;
        }

        public DataTable GetDefCanales(AC_Medidor medidor)
        {
            DataTable resultado = null;
            string sql = @"SELECT rmc.*,dc.nombre_magnitud_elec
            FROM f_mc_rmedidor_canales rmc, p_mc_def_magnitud_elec dc
            WHERE rmc.fk_cod_medidor=:fk_cod_medidor 
            AND rmc.d_cod_estado='1'
            AND rmc.fk_cod_infcanal=dc.pk_cod_magnitud_elec";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("fk_cod_medidor", OracleDbType.Int64, medidor.PkCodMedidor, System.Data.ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public DataTable GetMagnitudesElectricas(MC_RMedidorFto rMedFto)
        {
            return GetMagnitudesElectricas(rMedFto.PkCodMedidor, rMedFto.PkCodFormato);
        }

        public DataTable GetMagnitudesElectricas(long pkCodMedidor, long pkCodFormato)
        {
            string sql =
            @"SELECT r.* FROM f_mc_rmedidor_canales r
            WHERE r.fk_cod_medidor=:fk_cod_medidor AND r.fk_cod_formato=:fk_cod_formato";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("fk_cod_medidor", OracleDbType.Int64, pkCodMedidor, ParameterDirection.Input);
            cmd.Parameters.Add("fk_cod_formato", OracleDbType.Int64, pkCodFormato, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public List<RMedidorCanal> GetListaDefCanales(long pkCodMedidor, long pkCodFormato)
        {
            List<RMedidorCanal> resultado = new List<RMedidorCanal>();
            DataTable tabla = GetMagnitudesElectricas(pkCodMedidor, pkCodFormato);
            foreach (DataRow r in tabla.Rows)
            {
                RMedidorCanal rmc = new RMedidorCanal(r);
                resultado.Add(rmc);
            }
            return resultado;
        }
    }
}