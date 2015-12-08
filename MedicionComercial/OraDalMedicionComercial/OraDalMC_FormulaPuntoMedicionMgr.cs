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
    public class OraDalMC_FormulaPuntoMedicionMgr : OraDalBaseMgr, IMC_FormulaPuntoMedicionMgr
    {
        public void Guardar(MC_FormulaPuntoMedicion obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodFormula = GetIdAutoNum("SEC_PK_COD_FORMULA");
                sql = 
                @"INSERT
                INTO F_MC_PTO_MED_FORMULA
                  (
                    PK_COD_FORMULA,
                    FK_COD_PUNTO_MEDICION,
                    FK_COD_MAGNITUD_ELEC,
                    FORMULA,
                    FECHA_INICIO,
                    FECHA_FIN,
                    SEC_LOG
                  )
                  VALUES
                  (
                    :PK_COD_FORMULA,
                    :FK_COD_PUNTO_MEDICION,
                    :FK_COD_MAGNITUD_ELEC,
                    :FORMULA,
                    :FECHA_INICIO,
                    :FECHA_FIN,
                    :SEC_LOG
                  )";
            }
            else
            {
                sql =
                @"UPDATE F_MC_PTO_MED_FORMULA
                SET FK_COD_PUNTO_MEDICION=:FK_COD_PUNTO_MEDICION,
                  FK_COD_MAGNITUD_ELEC   =:FK_COD_MAGNITUD_ELEC,
                  FORMULA                =:FORMULA,
                  FECHA_INICIO           =:FECHA_INICIO,
                  FECHA_FIN              =:FECHA_FIN,
                  SEC_LOG                =:SEC_LOG
                WHERE PK_COD_FORMULA     =:PK_COD_FORMULA";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_PK_COD_FORMULA, OracleDbType.Int64, obj.PkCodFormula, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_FK_COD_PUNTO_MEDICION, OracleDbType.Int64, obj.FkCodPuntoMedicion, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_FK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.FkCodMagnitudElec, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_FORMULA, OracleDbType.Clob, obj.Formula, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_FECHA_INICIO, OracleDbType.Date, obj.FechaInicio, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_FECHA_FIN, OracleDbType.Date, obj.FechaFin, ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormulaPuntoMedicion.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MC_FormulaPuntoMedicion.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_FormulaPuntoMedicion> GetLista()
        {
            BindingList<MC_FormulaPuntoMedicion> resultado = new BindingList<MC_FormulaPuntoMedicion>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_FormulaPuntoMedicion(row));
            }
            return resultado;
        }


        public DataTable GetFormulasPorCodPuntoMed(long codPuntoMedicion)
        {
            DataTable resultado = null;
            string sql = "SELECT * FROM f_mc_pto_med_formula WHERE fk_cod_punto_medicion=:cod_punto_medicion";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }


        public List<MC_FormulaPuntoMedicion> GetFormulasPorCodPuntoMed(long codPuntoMedicion, DateTime desde, DateTime hasta)
        {
            List<MC_FormulaPuntoMedicion> resultado = new List<MC_FormulaPuntoMedicion>();
            string sql = @"SELECT *
            FROM f_mc_pto_med_formula
            WHERE fk_cod_punto_medicion=:cod_punto_medicion
            AND :fecha BETWEEN fecha_inicio AND NVL(fecha_fin,sysdate+1)";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            cmd.Parameters.Add("fecha", OracleDbType.Date, desde, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add(new MC_FormulaPuntoMedicion(r));
            }
            return resultado;
        }
    }
}