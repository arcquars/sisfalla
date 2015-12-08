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
    public class OraDalLocalizacionProyectosGeneracionMgr : OraDalBaseMgr, ILocalizacionProyectosGeneracionMgr
    {
        #region Singleton
        private static OraDalLocalizacionProyectosGeneracionMgr _instancia;
        static OraDalLocalizacionProyectosGeneracionMgr()
        {
            _instancia = new OraDalLocalizacionProyectosGeneracionMgr();
        }
        public static OraDalLocalizacionProyectosGeneracionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalLocalizacionProyectosGeneracionMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return LocalizacionProyectosGeneracion.NOMBRE_TABLA;
            }
        }

        public void Guardar(LocalizacionProyectosGeneracion localizacionProyGeneracion)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (localizacionProyGeneracion.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", localizacionProyGeneracion.GetEstadoString());
                localizacionProyGeneracion.SecLog = (long)p.PK_SecLog;
                localizacionProyGeneracion.PkLocalProyGeneracion = GetIdAutoNum("SQ_F_PR_LOCAL_PROYS_GENERACION");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12})";
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
                "{12}=:{12}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, LocalizacionProyectosGeneracion.NOMBRE_TABLA, LocalizacionProyectosGeneracion.C_PK_LOCAL_PROY_GENERACION,
            LocalizacionProyectosGeneracion.C_FK_PROYECTO,
            LocalizacionProyectosGeneracion.C_LOCALIDAD,
            LocalizacionProyectosGeneracion.C_PROVINCIA,
            LocalizacionProyectosGeneracion.C_D_COD_DEPARTAMENTO,
            LocalizacionProyectosGeneracion.C_LATITUD,
            LocalizacionProyectosGeneracion.C_ALTITUD,
            LocalizacionProyectosGeneracion.C_LONGITUD,
            LocalizacionProyectosGeneracion.C_UNIDAD_MEDIDA,
            LocalizacionProyectosGeneracion.C_LATITUD_UTM,
            LocalizacionProyectosGeneracion.C_LONGITUD_UTM,
            LocalizacionProyectosGeneracion.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_PK_LOCAL_PROY_GENERACION, OracleDbType.Int64, localizacionProyGeneracion.PkLocalProyGeneracion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_FK_PROYECTO, OracleDbType.Int64, localizacionProyGeneracion.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_LOCALIDAD, OracleDbType.Varchar2, localizacionProyGeneracion.Localidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_PROVINCIA, OracleDbType.Varchar2, localizacionProyGeneracion.Provincia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_D_COD_DEPARTAMENTO, OracleDbType.Int64, localizacionProyGeneracion.DCodDepartamento, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_LATITUD, OracleDbType.Varchar2, localizacionProyGeneracion.Latitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_ALTITUD, OracleDbType.Int32, localizacionProyGeneracion.Altitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_LONGITUD, OracleDbType.Varchar2, localizacionProyGeneracion.Longitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_UNIDAD_MEDIDA, OracleDbType.Varchar2, localizacionProyGeneracion.UnidadMedida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_LATITUD_UTM, OracleDbType.Double, localizacionProyGeneracion.LatitudUtm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_LONGITUD_UTM, OracleDbType.Double, localizacionProyGeneracion.LongitudUtm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosGeneracion.C_SEC_LOG, OracleDbType.Int64, localizacionProyGeneracion.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                localizacionProyGeneracion.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(LocalizacionProyectosGeneracion.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<LocalizacionProyectosGeneracion> GetLista()
        {
            BindingList<LocalizacionProyectosGeneracion> resultado = new BindingList<LocalizacionProyectosGeneracion>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new LocalizacionProyectosGeneracion(row));
            }
            return resultado;
        }

        public LocalizacionProyectosGeneracion GetPorPkProyecto(long pkProyecto)
        {
            LocalizacionProyectosGeneracion localizacion = null;
            string sql = "SELECT {0}.* FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, LocalizacionProyectosGeneracion.NOMBRE_TABLA, LocalizacionProyectosGeneracion.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                localizacion = new LocalizacionProyectosGeneracion(row);
            }
            return localizacion;
        }
    }
}
