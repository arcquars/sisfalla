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
    public class OraDalDatoTecnicoTransformadorMgr : OraDalBaseMgr, IDatoTecnicoTransformadorMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoTransformadorMgr _instancia;
        static OraDalDatoTecnicoTransformadorMgr()
        {
            _instancia = new OraDalDatoTecnicoTransformadorMgr();
        }
        public static OraDalDatoTecnicoTransformadorMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoTransformadorMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoTransformador.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoTransformador datoTecnicoTransformador)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (datoTecnicoTransformador.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", datoTecnicoTransformador.GetEstadoString());
                datoTecnicoTransformador.SecLog = (long)p.PK_SecLog;
                datoTecnicoTransformador.PkDatoTecTranformador = GetIdAutoNum("SQ_F_PR_DATO_TEC_TRANSFORMADOR");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19})";
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
                "{19}=:{19}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DatoTecnicoTransformador.NOMBRE_TABLA, DatoTecnicoTransformador.C_PK_DATO_TEC_TRANFORMADOR,
            DatoTecnicoTransformador.C_FK_COD_PROYECTO,
            DatoTecnicoTransformador.C_D_COD_TIPO_TRANSFORMADOR,
            DatoTecnicoTransformador.C_NIVEL_DE_TENSION_LADO_AT,
            DatoTecnicoTransformador.C_NIVEL_DE_TENSION_LADO_BT,
            DatoTecnicoTransformador.C_NIVEL_DE_TENSION_TERCIARIO,
            DatoTecnicoTransformador.C_CAPACIDAD,
            DatoTecnicoTransformador.C_R1_RESISTENCIA_BASE_PPOPIA,
            DatoTecnicoTransformador.C_X1_REACTANCIA_BASE_PROPIA,
            DatoTecnicoTransformador.C_PASO_TAP,
            DatoTecnicoTransformador.C_TAP_MINIMO,
            DatoTecnicoTransformador.C_TAP_MAXIMO,
            DatoTecnicoTransformador.C_GRUPO_CONEXION,
            DatoTecnicoTransformador.C_OBSERVACIONES,
            DatoTecnicoTransformador.C_FECHA_REGISTRO,
            DatoTecnicoTransformador.C_NODO_AT,
            DatoTecnicoTransformador.C_NODO_BT,
            DatoTecnicoTransformador.C_NODO_TERCIARIO,
            DatoTecnicoTransformador.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoTransformador.C_PK_DATO_TEC_TRANFORMADOR, OracleDbType.Int64, datoTecnicoTransformador.PkDatoTecTranformador, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_FK_COD_PROYECTO, OracleDbType.Int64, datoTecnicoTransformador.FkCodProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_D_COD_TIPO_TRANSFORMADOR, OracleDbType.Int64, datoTecnicoTransformador.DCodTipoTransformador, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NIVEL_DE_TENSION_LADO_AT, OracleDbType.Double, datoTecnicoTransformador.NivelDeTensionLadoAt, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NIVEL_DE_TENSION_LADO_BT, OracleDbType.Double, datoTecnicoTransformador.NivelDeTensionLadoBt, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NIVEL_DE_TENSION_TERCIARIO, OracleDbType.Double, datoTecnicoTransformador.NivelDeTensionTerciario, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_CAPACIDAD, OracleDbType.Double, datoTecnicoTransformador.Capacidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_R1_RESISTENCIA_BASE_PPOPIA, OracleDbType.Double, datoTecnicoTransformador.R1ResistenciaBasePpopia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_X1_REACTANCIA_BASE_PROPIA, OracleDbType.Double, datoTecnicoTransformador.X1ReactanciaBasePropia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_PASO_TAP, OracleDbType.Double, datoTecnicoTransformador.PasoTap, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_TAP_MINIMO, OracleDbType.Double, datoTecnicoTransformador.TapMinimo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_TAP_MAXIMO, OracleDbType.Double, datoTecnicoTransformador.TapMaximo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_GRUPO_CONEXION, OracleDbType.Varchar2, datoTecnicoTransformador.GrupoConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_OBSERVACIONES, OracleDbType.Varchar2, datoTecnicoTransformador.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_FECHA_REGISTRO, OracleDbType.Date, datoTecnicoTransformador.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NODO_AT, OracleDbType.Varchar2, datoTecnicoTransformador.NodoAT, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NODO_BT, OracleDbType.Varchar2, datoTecnicoTransformador.NodoBT, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_NODO_TERCIARIO, OracleDbType.Varchar2, datoTecnicoTransformador.NodoTerciario, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoTransformador.C_SEC_LOG, OracleDbType.Int64, datoTecnicoTransformador.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                datoTecnicoTransformador.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoTransformador.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoTransformador> GetLista()
        {
            BindingList<DatoTecnicoTransformador> resultado = new BindingList<DatoTecnicoTransformador>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoTransformador(row));
            }
            return resultado;
        }

        public DatoTecnicoTransformador GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND  F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql,DatoTecnicoTransformador.NOMBRE_TABLA, DatoTecnicoTransformador.C_FK_COD_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoTransformador res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row= tabla.Rows[0];
                res = new DatoTecnicoTransformador(row);
            }
            return res;
        }
    }
}
