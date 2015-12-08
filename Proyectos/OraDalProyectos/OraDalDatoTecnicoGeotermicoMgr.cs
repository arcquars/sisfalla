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
    public class OraDalDatoTecnicoGeotermicoMgr : OraDalBaseMgr, IDatoTecnicoGeotermicoMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoGeotermicoMgr _instancia;
        static OraDalDatoTecnicoGeotermicoMgr()
        {
            _instancia = new OraDalDatoTecnicoGeotermicoMgr();
        }
        public static OraDalDatoTecnicoGeotermicoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoGeotermicoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoGeotermico.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoGeotermico datoTecnicoGeotermico)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoGeotermico.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", datoTecnicoGeotermico.GetEstadoString());
                datoTecnicoGeotermico.SecLog = (long)p.PK_SecLog;
                datoTecnicoGeotermico.PkDatoTecGeotermico = GetIdAutoNum("SQ_F_PR_DATO_TEC_GEOTERMICO");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11})";
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
                "{11}=:{11}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoGeotermico.NOMBRE_TABLA, DatoTecnicoGeotermico.C_PK_DATO_TEC_GEOTERMICO,
            DatoTecnicoGeotermico.C_FK_PROYECTO,
            DatoTecnicoGeotermico.C_POTENCIA_INSTALADA,
            DatoTecnicoGeotermico.C_NRO_UNIDADES,
            DatoTecnicoGeotermico.C_D_COD_TECNOLOGIA_GEOTERMICA,
            DatoTecnicoGeotermico.C_GENERACION_MEDIA_ANUAL,
            DatoTecnicoGeotermico.C_PODER_CALORIFICO,
            DatoTecnicoGeotermico.C_PRODUCTIVIDAD,
            DatoTecnicoGeotermico.C_OBSERVACIONES,
            DatoTecnicoGeotermico.C_FECHA_REGISTRO,
            DatoTecnicoGeotermico.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(DatoTecnicoGeotermico.C_PK_DATO_TEC_GEOTERMICO, OracleDbType.Int64, datoTecnicoGeotermico.PkDatoTecGeotermico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_FK_PROYECTO, OracleDbType.Int64, datoTecnicoGeotermico.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_POTENCIA_INSTALADA, OracleDbType.Double, datoTecnicoGeotermico.PotenciaInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_NRO_UNIDADES, OracleDbType.Int64, datoTecnicoGeotermico.NroUnidades, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_D_COD_TECNOLOGIA_GEOTERMICA, OracleDbType.Int64, datoTecnicoGeotermico.DCodTecnologiaGeotermica, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_GENERACION_MEDIA_ANUAL, OracleDbType.Double, datoTecnicoGeotermico.GeneracionMediaAnual, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_PODER_CALORIFICO, OracleDbType.Double, datoTecnicoGeotermico.PoderCalorifico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_PRODUCTIVIDAD, OracleDbType.Double, datoTecnicoGeotermico.Productividad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoGeotermico.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoGeotermico.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoGeotermico.C_SEC_LOG, OracleDbType.Int64, datoTecnicoGeotermico.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoGeotermico.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoGeotermico.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoGeotermico> GetLista()
        {
            BindingList<DatoTecnicoGeotermico> resultado = new BindingList<DatoTecnicoGeotermico>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoGeotermico(row));
            }
            return resultado;
        }

        public DatoTecnicoGeotermico GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO ={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoGeotermico.NOMBRE_TABLA, DatoTecnicoGeotermico.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoGeotermico res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoGeotermico(row);
            }

            return res;
        }
    }
}
