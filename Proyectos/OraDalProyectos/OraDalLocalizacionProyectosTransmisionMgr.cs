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
    public class OraDalLocalizacionProyectosTransmisionMgr : OraDalBaseMgr, ILocalizacionProyectosTransmisionMgr
    {
        #region Singleton
        private static OraDalLocalizacionProyectosTransmisionMgr _instancia;
        static OraDalLocalizacionProyectosTransmisionMgr()
        {
            _instancia = new OraDalLocalizacionProyectosTransmisionMgr();
        }
        public static OraDalLocalizacionProyectosTransmisionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalLocalizacionProyectosTransmisionMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return LocalizacionProyectosTransmision.NOMBRE_TABLA;
            }
        }

        public void Guardar(LocalizacionProyectosTransmision obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkLocalProysTransmision = GetIdAutoNum("SQ_F_PR_LOCAL_PROY_TRANSMISION");
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

            sql = string.Format(sql, LocalizacionProyectosTransmision.NOMBRE_TABLA, LocalizacionProyectosTransmision.C_PK_LOCAL_PROYS_TRANSMISION,
            LocalizacionProyectosTransmision.C_FK_PROYECTO,
            LocalizacionProyectosTransmision.C_SUBESTACION,
            LocalizacionProyectosTransmision.C_LOCALIDAD,
            LocalizacionProyectosTransmision.C_D_COD_DEPARTAMENTO,
            LocalizacionProyectosTransmision.C_LATITUD,
            LocalizacionProyectosTransmision.C_LONGITUD,
            LocalizacionProyectosTransmision.C_ALTITUD,
            LocalizacionProyectosTransmision.C_UNIDAD_MEDIDA,
            LocalizacionProyectosTransmision.C_SEC_LOG,
            LocalizacionProyectosTransmision.C_LATITUD_UTM,
            LocalizacionProyectosTransmision.C_LONGITUD_UTM,
            LocalizacionProyectosTransmision.C_ORIGEN_DESTINO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_PK_LOCAL_PROYS_TRANSMISION, OracleDbType.Int64, obj.PkLocalProysTransmision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_SUBESTACION, OracleDbType.Varchar2, obj.Subestacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_LOCALIDAD, OracleDbType.Varchar2, obj.Localidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_D_COD_DEPARTAMENTO, OracleDbType.Int64, obj.DCodDepartamento, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_LATITUD, OracleDbType.Varchar2, obj.Latitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_LONGITUD, OracleDbType.Varchar2, obj.Longitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_ALTITUD, OracleDbType.Int32, obj.Altitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_UNIDAD_MEDIDA, OracleDbType.Varchar2, obj.UnidadMedida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_LATITUD_UTM, OracleDbType.Double, obj.LatitudUtm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_LONGITUD_UTM, OracleDbType.Double, obj.LongitudUtm, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(LocalizacionProyectosTransmision.C_ORIGEN_DESTINO, OracleDbType.Varchar2, obj.OrigenDestino, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(LocalizacionProyectosTransmision.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<LocalizacionProyectosTransmision> GetLista()
        {
            BindingList<LocalizacionProyectosTransmision> resultado = new BindingList<LocalizacionProyectosTransmision>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new LocalizacionProyectosTransmision(row));
            }
            return resultado;
        }

        public DataTable GetLocalizacionSubestacionesPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, LocalizacionProyectosTransmision.NOMBRE_TABLA, LocalizacionProyectosTransmision.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            LocalizacionProyectosTransmision local;
            DefDominioMgr mgr= new DefDominioMgr();
            if (tabla.Rows.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    local = new LocalizacionProyectosTransmision();
                    local.EsNuevo = true;
                    local.FkProyecto = pkProyecto;
                    local.Altitud = 0;
                    local.Latitud = "0.00";
                    local.Localidad = "";
                    local.Longitud = "0.00";
                    local.OrigenDestino = i.ToString();
                    local.Subestacion = "";
                    local.UnidadMedida = "1";
                    local.DCodDepartamento = mgr.GetListaDominio(DominiosProyectos.D_COD_DEPARTAMENTOS)[0].CodDominio;
                    Guardar(local);
                }
            }
            tabla = EjecutarSql(sql);
            return tabla;
        }

        public List<LocalizacionProyectosTransmision> GetListPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, LocalizacionProyectosTransmision.NOMBRE_TABLA, LocalizacionProyectosTransmision.C_FK_PROYECTO, pkProyecto, LocalizacionProyectosTransmision.C_ORIGEN_DESTINO);
            DataTable tabla = EjecutarSql(sql);
            LocalizacionProyectosTransmision item;
            List<LocalizacionProyectosTransmision> lista = new List<LocalizacionProyectosTransmision>();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    item = new LocalizacionProyectosTransmision(row);
                    lista.Add(item);
                }
            }

            return lista;
        }

        public object GetTablaPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, LocalizacionProyectosTransmision.NOMBRE_TABLA, LocalizacionProyectosTransmision.C_FK_PROYECTO, pkProyecto, LocalizacionProyectosTransmision.C_ORIGEN_DESTINO);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }
    }
}
