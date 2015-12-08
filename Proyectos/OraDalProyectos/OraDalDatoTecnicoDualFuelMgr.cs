using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using CNDC.Pistas;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoDualFuelMgr : OraDalBaseMgr, IDatoTecnicoDualFuelMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoDualFuelMgr _instancia;
        static OraDalDatoTecnicoDualFuelMgr()
        {
            _instancia = new OraDalDatoTecnicoDualFuelMgr();
        }
        public static OraDalDatoTecnicoDualFuelMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoDualFuelMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoDualFuel.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoDualFuel datoTecnicoDualFuel)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoDualFuel.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyetcos", datoTecnicoDualFuel.GetEstadoString());
                datoTecnicoDualFuel.SecLog = (long)p.PK_SecLog;
                datoTecnicoDualFuel.PkDatoTecGasDualFuel = GetIdAutoNum("SQ_F_PR_DATO_TEC_DUAL_FUEL");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13})";
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
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoDualFuel.NOMBRE_TABLA, DatoTecnicoDualFuel.C_PK_DATO_TEC_GAS_DUAL_FUEL,
            DatoTecnicoDualFuel.C_FK_PROYECTO,
            DatoTecnicoDualFuel.C_MODELO,
            DatoTecnicoDualFuel.C_CAPACIDAD_INSTALADA,
            DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_100,
            DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_75,
            DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_50,
            DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_100,
            DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_75,
            DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_50,
            DatoTecnicoDualFuel.C_OBSERVACIONES,
            DatoTecnicoDualFuel.C_FECHA_REGISTRO,
            DatoTecnicoDualFuel.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(DatoTecnicoDualFuel.C_PK_DATO_TEC_GAS_DUAL_FUEL, OracleDbType.Int64, datoTecnicoDualFuel.PkDatoTecGasDualFuel, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_FK_PROYECTO, OracleDbType.Int64, datoTecnicoDualFuel.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_MODELO, OracleDbType.Varchar2, datoTecnicoDualFuel.Modelo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_CAPACIDAD_INSTALADA, OracleDbType.Double, datoTecnicoDualFuel.CapacidadInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_100, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateGasNatural100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_75, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateGasNatural75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_GAS_NATURAL_50, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateGasNatural50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_100, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateDiesel100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_75, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateDiesel75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_HEAT_RATE_DIESEL_50, OracleDbType.Int64, datoTecnicoDualFuel.HeatRateDiesel50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoDualFuel.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoDualFuel.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoDualFuel.C_SEC_LOG, OracleDbType.Int64, datoTecnicoDualFuel.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoDualFuel.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoDualFuel.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoDualFuel> GetLista()
        {
            BindingList<DatoTecnicoDualFuel> resultado = new BindingList<DatoTecnicoDualFuel>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoDualFuel(row));
            }
            return resultado;
        }

        public DatoTecnicoDualFuel GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoDualFuel.NOMBRE_TABLA, DatoTecnicoDualFuel.C_FK_PROYECTO, pkProyecto);
            DatoTecnicoDualFuel res = null;
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoDualFuel(row);
            }
            return res;
        }
    }
}
