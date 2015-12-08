using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using ModeloProyectos;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoBiomasaMgr : OraDalBaseMgr, IDatoTecnicoBiomasaMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoBiomasaMgr _instancia;
        static OraDalDatoTecnicoBiomasaMgr()
        {
            _instancia = new OraDalDatoTecnicoBiomasaMgr();
        }
        public static OraDalDatoTecnicoBiomasaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoBiomasaMgr()
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
        public void Guardar(DatoTecnicoBiomasa obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecBiomasa = GetIdAutoNum("SQ_F_PR_DATO_TEC_BIOMASA");
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
                "{13}=:{13}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DatoTecnicoBiomasa.NOMBRE_TABLA, DatoTecnicoBiomasa.C_PK_DATO_TEC_BIOMASA,
            DatoTecnicoBiomasa.C_FK_PROYECTO,
            DatoTecnicoBiomasa.C_D_COD_TECNOLOGIA_BIOMASA,
            DatoTecnicoBiomasa.C_POTENCIA_INSTALADA,
            DatoTecnicoBiomasa.C_NRO_UNIDADES,
            DatoTecnicoBiomasa.C_PERIODO_OPERACION_MES_DE,
            DatoTecnicoBiomasa.C_PERIODO_OPERACION_MES_A,
            DatoTecnicoBiomasa.C_BIOMADA_DISPONIBLE,
            DatoTecnicoBiomasa.C_CONSUMO_ESPECIFICO,
            DatoTecnicoBiomasa.C_PORDER_CALORIFICO,
            DatoTecnicoBiomasa.C_OBSERVACIONES,
            DatoTecnicoBiomasa.C_SEC_LOG,
            DatoTecnicoBiomasa.C_FECHA_REGISTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_PK_DATO_TEC_BIOMASA, OracleDbType.Int64, obj.PkDatoTecBiomasa, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_D_COD_TECNOLOGIA_BIOMASA, OracleDbType.Int64, obj.DCodTecnologiaBiomasa, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_POTENCIA_INSTALADA, OracleDbType.Double, obj.PotenciaInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_NRO_UNIDADES, OracleDbType.Int64, obj.NroUnidades, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_PERIODO_OPERACION_MES_DE, OracleDbType.Date, obj.PeriodoOperacionMesDe, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_PERIODO_OPERACION_MES_A, OracleDbType.Date, obj.PeriodoOperacionMesA, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_BIOMADA_DISPONIBLE, OracleDbType.Double, obj.BiomadaDisponible, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_CONSUMO_ESPECIFICO, OracleDbType.Double, obj.ConsumoEspecifico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_PORDER_CALORIFICO, OracleDbType.Double, obj.PorderCalorifico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_OBSERVACIONES, OracleDbType.Varchar2, obj.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoBiomasa.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaRegistro, System.Data.ParameterDirection.Input);
            
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoBiomasa.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoBiomasa> GetLista()
        {
            BindingList<DatoTecnicoBiomasa> resultado = new BindingList<DatoTecnicoBiomasa>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoBiomasa(row));
            }
            return resultado;
        }


        public DatoTecnicoBiomasa GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoBiomasa.NOMBRE_TABLA, DatoTecnicoBiomasa.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoBiomasa res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoBiomasa(row);
            }
            return res;
        }
    }
}
