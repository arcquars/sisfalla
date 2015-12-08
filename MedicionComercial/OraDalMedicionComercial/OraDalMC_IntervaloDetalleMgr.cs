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
    public class OraDalMC_IntervaloDetalleMgr : OraDalBaseMgr, IMC_IntervaloDetalleMgr
    {
        public void Guardar(MC_IntervaloDetalle obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3},{4})" +
                "VALUES(:{1},:{2},:{3},:{4})";
                obj.PkCodIntervalo = GetIdAutoNum("SEC_PK_COD_INTERVALO_D");
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{1}=:{1} ," +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} WHERE ";
            }

            sql = string.Format(sql, MC_IntervaloDetalle.NOMBRE_TABLA, 
            MC_IntervaloDetalle.C_PK_COD_INTERVALO,
            MC_IntervaloDetalle.C_HORA_INTERVALO,
            MC_IntervaloDetalle.C_NUMERO_INTERVALO,
            MC_IntervaloDetalle.C_FK_COD_INTERVALO_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_IntervaloDetalle.C_PK_COD_INTERVALO, OracleDbType.Int64, obj.PkCodIntervalo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloDetalle.C_HORA_INTERVALO, OracleDbType.Varchar2, obj.HoraIntervalo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloDetalle.C_NUMERO_INTERVALO, OracleDbType.Int32, obj.NumeroIntervalo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloDetalle.C_FK_COD_INTERVALO_MAESTRO, OracleDbType.Int64, obj.FkCodIntervaloMaestro, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                obj.EsNuevo = false;
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
                DisposeCommand(cmd);
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(MC_IntervaloDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_IntervaloDetalle> GetLista()
        {
            BindingList<MC_IntervaloDetalle> resultado = new BindingList<MC_IntervaloDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_IntervaloDetalle(row));
            }
            return resultado;
        }

        public DataTable GetPorPkCodMaestro(long pkCodIntervaloMaestro)
        {
            DataTable resultado = null;
            string sql = @"SELECT numero_intervalo, hora_intervalo, pk_cod_intervalo FROM p_mc_intervalo_detalle
            WHERE fk_cod_intervalo_maestro=:fk_cod_intervalo_maestro
            ORDER BY numero_intervalo";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_IntervaloDetalle.C_FK_COD_INTERVALO_MAESTRO, OracleDbType.Int64, pkCodIntervaloMaestro, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }


        public List<MC_IntervaloDetalle> GetLista(DateTime desde, DateTime hasta)
        {
            List<MC_IntervaloDetalle> resultado = new List<MC_IntervaloDetalle>();
            string sql = @"SELECT *
            FROM P_MC_INTERVALO_DETALLE
            WHERE fk_cod_intervalo_maestro IN
              (SELECT PK_COD_INTERVALO_MAESTRO
              FROM P_MC_INTERVALO_MAESTRO
              WHERE :fecha BETWEEN FECHA_DESDE AND NVL(FECHA_HASTA,Sysdate+1)
              )";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fecha", OracleDbType.Date, desde, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new MC_IntervaloDetalle(row));
            }
            return resultado;
        }
    }
}