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
    public class OraDalMC_IntervaloMaestroMgr : OraDalBaseMgr, IMC_IntervaloMaestroMgr
    {
        public const int MINUTOS_POR_DIA = 1440;
        public bool Guardar(MC_IntervaloMaestro obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7})";
                obj.PkCodIntervaloMaestro = GetIdAutoNum("SEC_PK_COD_INTERVALO_M");
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}, {7}=:{7}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, MC_IntervaloMaestro.NOMBRE_TABLA, MC_IntervaloMaestro.C_PK_COD_INTERVALO_MAESTRO,
            MC_IntervaloMaestro.C_NOMBRE,
            MC_IntervaloMaestro.C_PERIODO_TIEMPO,
            MC_IntervaloMaestro.C_FECHA_DESDE,
            MC_IntervaloMaestro.C_FECHA_HASTA,
            MC_IntervaloMaestro.C_D_COD_ESTADO,
            MC_IntervaloMaestro.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_IntervaloMaestro.C_PK_COD_INTERVALO_MAESTRO, OracleDbType.Int64, obj.PkCodIntervaloMaestro, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_NOMBRE, OracleDbType.Varchar2, obj.Nombre, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_PERIODO_TIEMPO, OracleDbType.Int32, obj.PeriodoTiempo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_FECHA_DESDE, OracleDbType.Date, obj.FechaDesde, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_FECHA_HASTA, OracleDbType.Date, obj.FechaHasta, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_D_COD_ESTADO, OracleDbType.Int16, obj.DCodEstado, ParameterDirection.Input);
            cmd.Parameters.Add(MC_IntervaloMaestro.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                if (obj.EsNuevo)
                {
                    obj.EsNuevo = false;
                    int totalPeriodosDia = MINUTOS_POR_DIA / obj.PeriodoTiempo;
                    int minutos = 0;
                    for (int i = 1; i <= totalPeriodosDia; i++)
                    {
                        minutos += obj.PeriodoTiempo;
                        MC_IntervaloDetalle detalle = new MC_IntervaloDetalle();
                        detalle.FkCodIntervaloMaestro = obj.PkCodIntervaloMaestro;
                        detalle.EsNuevo = true;
                        detalle.HoraIntervalo = GetHora(minutos);
                        detalle.NumeroIntervalo = i;
                        MC_IntervaloDetalleMgr.Instancia.Guardar(detalle);
                    }
                }
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

        private string GetHora(int minutos)
        {
            string resultado = string.Empty;
            int hora = minutos / 60;
            minutos = minutos % 60;
            resultado = (hora < 10 ? "0" + hora : "" + hora) + ":" + (minutos < 10 ? "0" + minutos : "" + minutos);
            return resultado;
        }
        public DataTable GetTabla()
        {
            DataTable tabla = EjecutarSql("SELECT * FROM p_mc_intervalo_maestro ORDER BY pk_cod_intervalo_maestro");
            return tabla;
        }

        public BindingList<MC_IntervaloMaestro> GetLista()
        {
            BindingList<MC_IntervaloMaestro> resultado = new BindingList<MC_IntervaloMaestro>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_IntervaloMaestro(row));
            }
            return resultado;
        }

        public MC_IntervaloMaestro GetIntervaloPorFecha(DateTime fecha)
        {
            MC_IntervaloMaestro resultado = null;
            string sql = @"SELECT *
            FROM p_mc_intervalo_maestro 
            WHERE :fecha between fecha_desde AND NVL(fecha_hasta,sysdate)";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new MC_IntervaloMaestro(tabla.Rows[0]);
            }
            return resultado;
        }
    }
}