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
    public class OraDalDatoTecnicoEolicoSolarMgr : OraDalBaseMgr, IDatoTecnicoEolicoSolarMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoEolicoSolarMgr _instancia;
        static OraDalDatoTecnicoEolicoSolarMgr()
        {
            _instancia = new OraDalDatoTecnicoEolicoSolarMgr();
        }
        public static OraDalDatoTecnicoEolicoSolarMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoEolicoSolarMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoEolicoSolar.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoEolicoSolar datoTecnicoEolicoSolar)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoEolicoSolar.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", datoTecnicoEolicoSolar.GetEstadoString());
                datoTecnicoEolicoSolar.SecLog = (long)p.PK_SecLog;
                datoTecnicoEolicoSolar.PkDatoTecEolicoSolar = GetIdAutoNum("SQ_F_PR_DATO_TEC_EOLICO_SOLAR");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9})";
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
                "{9}=:{9}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DatoTecnicoEolicoSolar.NOMBRE_TABLA, DatoTecnicoEolicoSolar.C_PK_DATO_TEC_EOLICO_SOLAR,
            DatoTecnicoEolicoSolar.C_FK_PROYECTO,
            DatoTecnicoEolicoSolar.C_D_COD_TECNOLOGIA_EOLICO,
            DatoTecnicoEolicoSolar.C_POTENCIA_INSTALADA,
            DatoTecnicoEolicoSolar.C_NRO_UNIDADES,
            DatoTecnicoEolicoSolar.C_TECNOLOGIA,
            DatoTecnicoEolicoSolar.C_OBSERVACIONES,
            DatoTecnicoEolicoSolar.C_FECHA_REGISTRO,
            DatoTecnicoEolicoSolar.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_PK_DATO_TEC_EOLICO_SOLAR, OracleDbType.Int64, datoTecnicoEolicoSolar.PkDatoTecEolicoSolar, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_FK_PROYECTO, OracleDbType.Int64, datoTecnicoEolicoSolar.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_D_COD_TECNOLOGIA_EOLICO, OracleDbType.Int64, datoTecnicoEolicoSolar.DCodTecnologiaEolico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_POTENCIA_INSTALADA, OracleDbType.Double, datoTecnicoEolicoSolar.PotenciaInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_NRO_UNIDADES, OracleDbType.Int64, datoTecnicoEolicoSolar.NroUnidades, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_TECNOLOGIA, OracleDbType.Varchar2, datoTecnicoEolicoSolar.Tecnologia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoEolicoSolar.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoEolicoSolar.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoEolicoSolar.C_SEC_LOG, OracleDbType.Int64, datoTecnicoEolicoSolar.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoEolicoSolar.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoEolicoSolar.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoEolicoSolar> GetLista()
        {
            BindingList<DatoTecnicoEolicoSolar> resultado = new BindingList<DatoTecnicoEolicoSolar>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoEolicoSolar(row));
            }
            return resultado;
        }

        public DatoTecnicoEolicoSolar GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoEolicoSolar.NOMBRE_TABLA, DatoTecnicoEolicoSolar.C_FK_PROYECTO, pkProyecto);
            DatoTecnicoEolicoSolar res = null;
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoEolicoSolar(row);
            }
            return res;
        }
    }
}
