using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoMotorDieselMgr : OraDalBaseMgr, IDatoTecnicoMotorDieselMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoMotorDieselMgr _instancia;
        static OraDalDatoTecnicoMotorDieselMgr()
        {
            _instancia = new OraDalDatoTecnicoMotorDieselMgr();
        }
        public static OraDalDatoTecnicoMotorDieselMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoMotorDieselMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoMotorDiesel.NOMBRE_TABLA;
            }
        }


        public void Guardar(DatoTecnicoMotorDiesel datoTecnicoMotorDiesel)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoMotorDiesel.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", datoTecnicoMotorDiesel.GetEstadoString());
                datoTecnicoMotorDiesel.SecLog = (long)p.PK_SecLog;
                datoTecnicoMotorDiesel.PkDatoTecGasMotorDiesel = GetIdAutoNum("SQ_F_PR_DATO_TEC_MOTOR_DIESEL");
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
                "{10}=:{10}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DatoTecnicoMotorDiesel.NOMBRE_TABLA, DatoTecnicoMotorDiesel.C_PK_DATO_TEC_GAS_MOTOR_DIESEL,
            DatoTecnicoMotorDiesel.C_FK_PROYECTO,
            DatoTecnicoMotorDiesel.C_MODELO,
            DatoTecnicoMotorDiesel.C_CAPACIDAD_INSTALADA,
            DatoTecnicoMotorDiesel.C_HEAT_RATE100,
            DatoTecnicoMotorDiesel.C_HEAT_RATE75,
            DatoTecnicoMotorDiesel.C_HEAT_RATE50,
            DatoTecnicoMotorDiesel.C_OBSERVACIONES,
            DatoTecnicoMotorDiesel.C_FECHA_REGISTRO,
            DatoTecnicoMotorDiesel.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_PK_DATO_TEC_GAS_MOTOR_DIESEL, OracleDbType.Int64, datoTecnicoMotorDiesel.PkDatoTecGasMotorDiesel, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_FK_PROYECTO, OracleDbType.Int64, datoTecnicoMotorDiesel.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_MODELO, OracleDbType.Varchar2, datoTecnicoMotorDiesel.Modelo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_CAPACIDAD_INSTALADA, OracleDbType.Double, datoTecnicoMotorDiesel.CapacidadInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_HEAT_RATE100, OracleDbType.Int64, datoTecnicoMotorDiesel.HeatRate100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_HEAT_RATE75, OracleDbType.Int64, datoTecnicoMotorDiesel.HeatRate75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_HEAT_RATE50, OracleDbType.Int64, datoTecnicoMotorDiesel.HeatRate50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoMotorDiesel.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoMotorDiesel.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoMotorDiesel.C_SEC_LOG, OracleDbType.Int64, datoTecnicoMotorDiesel.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoMotorDiesel.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoMotorDiesel.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoMotorDiesel> GetLista()
        {
            BindingList<DatoTecnicoMotorDiesel> resultado = new BindingList<DatoTecnicoMotorDiesel>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoMotorDiesel(row));
            }
            return resultado;
        }

        public DatoTecnicoMotorDiesel GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql,DatoTecnicoMotorDiesel.NOMBRE_TABLA, DatoTecnicoMotorDiesel.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoMotorDiesel res = null;
            if (tabla.Rows.Count > 0)
            { 
                DataRow row= tabla.Rows[0];
                res = new DatoTecnicoMotorDiesel(row);
            }
            return res;
        }
    }
}
