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
    public class OraDalMC_LecturaDetalleMgr : OraDalBaseMgr, IMC_LecturaDetalleMgr
    {
        #region Singleton
        private static OraDalMC_LecturaDetalleMgr _instancia;
        static OraDalMC_LecturaDetalleMgr()
        {
            _instancia = new OraDalMC_LecturaDetalleMgr();
        }
        public static OraDalMC_LecturaDetalleMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_LecturaDetalleMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MC_LecturaDetalle obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO F_MC_LECTURA_DETALLE (PK_COD_LECTURA,PK_FECHA,PK_COD_INTERVALO,PK_COD_MAGNITUD_ELEC,VALOR,ESTADO,SEC_LOG,D_COD_ORIGEN,FK_COD_PUNTO_MEDICION)" +
                "VALUES(:PK_COD_LECTURA,:PK_FECHA,:PK_COD_INTERVALO,:PK_COD_MAGNITUD_ELEC,:VALOR,:ESTADO,:SEC_LOG,:D_COD_ORIGEN,:FK_COD_PUNTO_MEDICION)";
            }
            else
            {
                sql = @"UPDATE F_MC_LECTURA_DETALLE SET 
                VALOR=:VALOR ,
                ESTADO=:ESTADO ,
                SEC_LOG=:SEC_LOG ,
                D_COD_ORIGEN=:D_COD_ORIGEN  
                WHERE 
                PK_COD_LECTURA=:PK_COD_LECTURA 
                AND PK_FECHA=:PK_FECHA 
                AND PK_COD_INTERVALO=:PK_COD_INTERVALO 
                AND PK_COD_MAGNITUD_ELEC=:PK_COD_MAGNITUD_ELEC";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_LecturaDetalle.C_PK_COD_LECTURA, OracleDbType.Int64, obj.PkCodLectura, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_PK_FECHA, OracleDbType.Date, obj.PkFecha, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_PK_COD_INTERVALO, OracleDbType.Int64, obj.PkCodIntervalo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_PK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.PkCodMagnitudElec, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_VALOR, OracleDbType.Double, obj.Valor, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_ESTADO, OracleDbType.Int32, obj.Estado, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_D_COD_ORIGEN, OracleDbType.Int64, obj.DCodOrigen, ParameterDirection.Input);
            cmd.Parameters.Add(MC_LecturaDetalle.C_FK_COD_PUNTO_MEDICION, OracleDbType.Int64, obj.FkCodPuntoMedicion, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MC_LecturaDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_LecturaDetalle> GetLista()
        {
            BindingList<MC_LecturaDetalle> resultado = new BindingList<MC_LecturaDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_LecturaDetalle(row));
            }
            return resultado;
        }

        public DataTable GetDatos(long codPuntoMedicion, DateTime desde, DateTime hasta)
        {
            string sql =
            @"SELECT lec.pk_fecha,
              i.hora_intervalo,
              lec.pk_cod_intervalo,
              me.nombre_magnitud_elec ,
              lec.pk_cod_magnitud_elec,
              lec.valor
            FROM f_mc_lectura_detalle lec,
              p_mc_intervalo_detalle i,
              p_mc_def_magnitud_elec me
            WHERE lec.fk_cod_punto_medicion=:codPuntoMedicion
            AND lec.pk_fecha BETWEEN :desde AND :hasta
            AND lec.pk_cod_intervalo    =i.pk_cod_intervalo
            AND lec.pk_cod_magnitud_elec=me.pk_cod_magnitud_elec
            ORDER BY lec.pk_fecha, lec.pk_cod_intervalo,lec.pk_cod_magnitud_elec";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("codPuntoMedicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            cmd.Parameters.Add("desde", OracleDbType.Date, desde, ParameterDirection.Input);
            cmd.Parameters.Add("hasta", OracleDbType.Date, hasta, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}