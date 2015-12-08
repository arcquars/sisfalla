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
    public class OraDalDatoEconomicoMgr : OraDalBaseMgr, IDatoEconomicoMgr
    {
        #region Singleton
        private static OraDalDatoEconomicoMgr _instancia;
        static OraDalDatoEconomicoMgr()
        {
            _instancia = new OraDalDatoEconomicoMgr();
        }
        public static OraDalDatoEconomicoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoEconomicoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoEconomico.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoEconomico obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoEconomico = GetIdAutoNum("SQ_F_PR_DATO_ECONOMICO");
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
                "{10}=:{10}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoEconomico.NOMBRE_TABLA, DatoEconomico.C_PK_DATO_ECONOMICO,
            DatoEconomico.C_FK_PROYECTO,
            DatoEconomico.C_TIEMPO_EJECUCION,
            DatoEconomico.C_VIDA_UTIL,
            DatoEconomico.C_ANIO_REF_INFORMACION,
            DatoEconomico.C_FECHA_MIN_INGRESO_OPERACION,
            DatoEconomico.C_COSTO_FIJO_OM,
            DatoEconomico.C_COSTO_VARIABLE_OM,
            DatoEconomico.C_FECHA_REGISTRO,
            DatoEconomico.C_SEC_LOG);
            cmd = CrearCommand();

            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoEconomico.C_PK_DATO_ECONOMICO, OracleDbType.Int64, obj.PkDatoEconomico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_TIEMPO_EJECUCION, OracleDbType.Int64, obj.TiempoEjecucion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_VIDA_UTIL, OracleDbType.Int64, obj.VidaUtil, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_ANIO_REF_INFORMACION, OracleDbType.Int64, obj.AnioRefInformacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_FECHA_MIN_INGRESO_OPERACION, OracleDbType.Date, obj.FechaMinIngresoOperacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_COSTO_FIJO_OM, OracleDbType.Double, obj.CostoFijoOm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_COSTO_VARIABLE_OM, OracleDbType.Double, obj.CostoVariableOm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoEconomico.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoEconomico.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoEconomico> GetLista()
        {
            BindingList<DatoEconomico> resultado = new BindingList<DatoEconomico>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoEconomico(row));
            }
            return resultado;
        }

        public DatoEconomico GetPorPkProyecto(long pkProyecto)
        {
            DatoEconomico res = null;
            string sql = @"SELECT {0}.* FROM {0},F_PR_PROYECTO 
            WHERE {1}={2} 
            AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} 
            AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoEconomico.NOMBRE_TABLA, DatoEconomico.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoEconomico(row);
            }
            return res;
        }
    }
}
