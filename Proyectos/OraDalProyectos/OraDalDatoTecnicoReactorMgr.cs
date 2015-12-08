using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using ModeloProyectos;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoReactorMgr : OraDalBaseMgr, IDatoTecnicoReactorMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoReactorMgr _instancia;
        static OraDalDatoTecnicoReactorMgr()
        {
            _instancia = new OraDalDatoTecnicoReactorMgr();
        }
        public static OraDalDatoTecnicoReactorMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoReactorMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoReactor.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoReactor obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecReactor = GetIdAutoNum("SQ_F_PR_DATO_TEC_REACTOR");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";
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
                "{16}=:{16}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoReactor.NOMBRE_TABLA, DatoTecnicoReactor.C_PK_DATO_TEC_REACTOR,
            DatoTecnicoReactor.C_FK_PROYECTO,
            DatoTecnicoReactor.C_TENSION_NOMINAL,
            DatoTecnicoReactor.C_POT_NOMINAL_TRIFASICA_REACTIVO,
            DatoTecnicoReactor.C_NODO_CONEXION,
            DatoTecnicoReactor.C_OBSERVACIONES,
            DatoTecnicoReactor.C_D_COD_TIPO_REACTOR,
            DatoTecnicoReactor.C_LINEA,
            DatoTecnicoReactor.C_SEC_LOG,
            DatoTecnicoReactor.C_FECHA_REGISTRO,
            DatoTecnicoReactor.C_FACTOR_CALIDAD,
            DatoTecnicoReactor.C_TENSION_NOMINAL_RN,
            DatoTecnicoReactor.C_POT_NOMINAL_TRIFASICA_RN,
            DatoTecnicoReactor.C_FACTOR_CALIDAD_RN,
            DatoTecnicoReactor.C_NODO_CONEXION_RN,
            DatoTecnicoReactor.C_OBSERVACIONES_RN );
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoReactor.C_PK_DATO_TEC_REACTOR, OracleDbType.Int64, obj.PkDatoTecReactor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_TENSION_NOMINAL, OracleDbType.Double, obj.TensionNominal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_POT_NOMINAL_TRIFASICA_REACTIVO, OracleDbType.Double, obj.PotNominalTrifasicaReactivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_NODO_CONEXION, OracleDbType.Varchar2, obj.NodoConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_OBSERVACIONES, OracleDbType.Varchar2, obj.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_D_COD_TIPO_REACTOR, OracleDbType.Int64, obj.DCodTipoReactor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_LINEA, OracleDbType.Varchar2, obj.Linea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_FACTOR_CALIDAD, OracleDbType.Double, obj.FactorCalidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_TENSION_NOMINAL_RN, OracleDbType.Double, obj.TensionNominalRn, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_POT_NOMINAL_TRIFASICA_RN, OracleDbType.Double, obj.PotNominalTrifasicaRn, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_FACTOR_CALIDAD_RN, OracleDbType.Double, obj.FactorCalidadRn, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_NODO_CONEXION_RN, OracleDbType.Varchar2, obj.NodoConexionRn, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoReactor.C_OBSERVACIONES_RN, OracleDbType.Varchar2, obj.ObservacionesRn, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoReactor.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoReactor> GetLista()
        {
            BindingList<DatoTecnicoReactor> resultado = new BindingList<DatoTecnicoReactor>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoReactor(row));
            }
            return resultado;
        }

        public DatoTecnicoReactor GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO ={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoReactor.NOMBRE_TABLA, DatoTecnicoReactor.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoReactor res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoReactor(row);
            }

            return res;
        }


    }
}
