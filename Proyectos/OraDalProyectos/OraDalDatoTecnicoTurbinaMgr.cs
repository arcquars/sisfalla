using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using ModeloProyectos;
using CNDC.Pistas;
using Oracle.DataAccess.Client;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoTurbinaMgr : OraDalBaseMgr, IDatoTecnicoTurbinaMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoTurbinaMgr _instancia;
        static OraDalDatoTecnicoTurbinaMgr()
        {
            _instancia = new OraDalDatoTecnicoTurbinaMgr();
        }
        public static OraDalDatoTecnicoTurbinaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoTurbinaMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoTurbina.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoTurbina obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecGasTurbina = GetIdAutoNum("SQ_F_PR_DATO_TEC_GAS_TURBINA");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21})";
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
                "{13}=:{13} ," +
                "{14}=:{14} ," +
                "{15}=:{15} ," +
                "{16}=:{16} ," +
                "{17}=:{17} ," +
                "{18}=:{18} ," +
                "{19}=:{19} ," +
                "{20}=:{20} ," +
                "{21}=:{21}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoTurbina.NOMBRE_TABLA, DatoTecnicoTurbina.C_PK_DATO_TEC_GAS_TURBINA,
            DatoTecnicoTurbina.C_FK_PROYECTO,
            DatoTecnicoTurbina.C_MODELO_TURBINA,
            DatoTecnicoTurbina.C_TEMP_ISO,
            DatoTecnicoTurbina.C_TEMP_MAX_SITIO,
            DatoTecnicoTurbina.C_TEMP_MEDIA_SITIO,
            DatoTecnicoTurbina.C_CAPACIDAD_INSTALADA_ISO,
            DatoTecnicoTurbina.C_CAPACIDAD_INST_MEDIA_SITIO,
            DatoTecnicoTurbina.C_HR_ISO_100,
            DatoTecnicoTurbina.C_HR_ISO_75,
            DatoTecnicoTurbina.C_HR_ISO_50,
            DatoTecnicoTurbina.C_CAPACIDAD_INST_MAX_SITIO,
            DatoTecnicoTurbina.C_OBSERVACIONES,
            DatoTecnicoTurbina.C_SEC_LOG,
            DatoTecnicoTurbina.C_HR_TEM_MAX_100,
            DatoTecnicoTurbina.C_HR_TEM_MAX_75,
            DatoTecnicoTurbina.C_HR_TEM_MAX_50,
            DatoTecnicoTurbina.C_HR_TEM_MEDIA_100,
            DatoTecnicoTurbina.C_HR_TEM_MEDIA_75,
            DatoTecnicoTurbina.C_FECHA_REGISTRO,
            DatoTecnicoTurbina.C_HR_TEM_MEDIA_50);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoTurbina.C_PK_DATO_TEC_GAS_TURBINA, OracleDbType.Int64, obj.PkDatoTecGasTurbina, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_MODELO_TURBINA, OracleDbType.Varchar2, obj.ModeloTurbina, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_TEMP_ISO, OracleDbType.Double, obj.TempIso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_TEMP_MAX_SITIO, OracleDbType.Double, obj.TempMaxSitio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_TEMP_MEDIA_SITIO, OracleDbType.Double, obj.TempMediaSitio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_CAPACIDAD_INSTALADA_ISO, OracleDbType.Double, obj.CapacidadInstaladaIso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_CAPACIDAD_INST_MEDIA_SITIO, OracleDbType.Double, obj.CapacidadInstMediaSitio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_ISO_100, OracleDbType.Int64, obj.HrIso100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_ISO_75, OracleDbType.Int64, obj.HrIso75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_ISO_50, OracleDbType.Int64, obj.HrIso50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_CAPACIDAD_INST_MAX_SITIO, OracleDbType.Double, obj.CapacidadInstMaxSitio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_OBSERVACIONES, OracleDbType.Varchar2, obj.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MAX_100, OracleDbType.Int64, obj.HrTemMax100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MAX_75, OracleDbType.Int64, obj.HrTemMax75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MAX_50, OracleDbType.Int64, obj.HrTemMax50, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MEDIA_100, OracleDbType.Int64, obj.HrTemMedia100, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MEDIA_75, OracleDbType.Int64, obj.HrTemMedia75, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTurbina.C_HR_TEM_MEDIA_50, OracleDbType.Int64, obj.HrTemMedia50, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoTurbina.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoTurbina> GetLista()
        {
            BindingList<DatoTecnicoTurbina> resultado = new BindingList<DatoTecnicoTurbina>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoTurbina(row));
            }
            return resultado;
        }

        public DatoTecnicoTurbina GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0}, F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoTurbina.NOMBRE_TABLA, DatoTecnicoTurbina.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoTurbina res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoTurbina(row);
            }
            return res;
        }
    }
}
