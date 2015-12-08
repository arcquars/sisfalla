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
    public class OraDalDatoTecnicoCicloCombinadoMgr : OraDalBaseMgr, IDatoTecnicoCicloCombinadoMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoCicloCombinadoMgr _instancia;
        static OraDalDatoTecnicoCicloCombinadoMgr()
        {
            _instancia = new OraDalDatoTecnicoCicloCombinadoMgr();
        }
        public static OraDalDatoTecnicoCicloCombinadoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoCicloCombinadoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoCicloCombinado.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoCicloCombinado datoTecnicoCicloCombinado)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoCicloCombinado.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", datoTecnicoCicloCombinado.GetEstadoString());
                datoTecnicoCicloCombinado.SecLog = (long)p.PK_SecLog;
                datoTecnicoCicloCombinado.PkDatoTecCicloCombinado = GetIdAutoNum("SQ_F_PR_DATO_TEC_CIC_COMBINADO");
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

            sql = string.Format(sql, DatoTecnicoCicloCombinado.NOMBRE_TABLA, DatoTecnicoCicloCombinado.C_PK_DATO_TEC_CICLO_COMBINADO,
            DatoTecnicoCicloCombinado.C_FK_PROYECTO,
            DatoTecnicoCicloCombinado.C_MODELO_TURBINA,
            DatoTecnicoCicloCombinado.C_CAPACIDAD_INSTALDA,
            DatoTecnicoCicloCombinado.C_HEAT_RATE_100,
            DatoTecnicoCicloCombinado.C_HEAT_RATE_75,
            DatoTecnicoCicloCombinado.C_HEAT_RATE_50,
            DatoTecnicoCicloCombinado.C_OBSERVACIONES,
            DatoTecnicoCicloCombinado.C_FECHA_REGISTRO,
            DatoTecnicoCicloCombinado.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_PK_DATO_TEC_CICLO_COMBINADO, OracleDbType.Int64, datoTecnicoCicloCombinado.PkDatoTecCicloCombinado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_FK_PROYECTO, OracleDbType.Int64, datoTecnicoCicloCombinado.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_MODELO_TURBINA, OracleDbType.Varchar2, datoTecnicoCicloCombinado.ModeloTurbina, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_CAPACIDAD_INSTALDA, OracleDbType.Double, datoTecnicoCicloCombinado.CapacidadInstalda, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_HEAT_RATE_100, OracleDbType.Int64, datoTecnicoCicloCombinado.HeatRate100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_HEAT_RATE_75, OracleDbType.Int64, datoTecnicoCicloCombinado.HeatRate75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_HEAT_RATE_50, OracleDbType.Int64, datoTecnicoCicloCombinado.HeatRate50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoCicloCombinado.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoCicloCombinado.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCicloCombinado.C_SEC_LOG, OracleDbType.Int64, datoTecnicoCicloCombinado.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoCicloCombinado.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoCicloCombinado.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoCicloCombinado> GetLista()
        {
            BindingList<DatoTecnicoCicloCombinado> resultado = new BindingList<DatoTecnicoCicloCombinado>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoCicloCombinado(row));
            }
            return resultado;
        }

        public DatoTecnicoCicloCombinado GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoCicloCombinado.NOMBRE_TABLA, DatoTecnicoCicloCombinado.C_FK_PROYECTO, pkProyecto);
            DatoTecnicoCicloCombinado res = null;
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            { 
                DataRow row= tabla.Rows[0];
                res = new DatoTecnicoCicloCombinado(row);
            }
            return res;
        }
    }
}
