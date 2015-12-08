using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.BLL;
using BLL;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalTransmisionAsociadaAlProyectoMgr : OraDalBaseMgr, ITransmisionAsociadaAlProyectoMgr
    {
        #region Singleton
        private static OraDalTransmisionAsociadaAlProyectoMgr _instancia;
        static OraDalTransmisionAsociadaAlProyectoMgr()
        {
            _instancia = new OraDalTransmisionAsociadaAlProyectoMgr();
        }
        public static OraDalTransmisionAsociadaAlProyectoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalTransmisionAsociadaAlProyectoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return TransmisionAsociadaAlProyecto.NOMBRE_TABLA;
            }
        }

        public void Guardar(TransmisionAsociadaAlProyecto trasAsociadaAlProyecto)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (trasAsociadaAlProyecto.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", trasAsociadaAlProyecto.GetEstadoString());
                trasAsociadaAlProyecto.SecLog = (long)p.PK_SecLog;
                trasAsociadaAlProyecto.PkTransAsociadaAlProy = GetIdAutoNum("SQ_F_PR_TRANS_ASOCIADA_AL_PROY");
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

            sql = string.Format(sql, TransmisionAsociadaAlProyecto.NOMBRE_TABLA, TransmisionAsociadaAlProyecto.C_PK_TRANS_ASOCIADA_AL_PROY,
            TransmisionAsociadaAlProyecto.C_FK_PROYECTO,
            TransmisionAsociadaAlProyecto.C_NODO_DE_CONEXION,
            TransmisionAsociadaAlProyecto.C_TENSION,
            TransmisionAsociadaAlProyecto.C_LONGITUD,
            TransmisionAsociadaAlProyecto.C_COSTO,
            TransmisionAsociadaAlProyecto.C_CAPACIDAD_CONEXION,
            TransmisionAsociadaAlProyecto.C_OBSERVACIONES,
            TransmisionAsociadaAlProyecto.C_FECHA_REGISTRO,
            TransmisionAsociadaAlProyecto.C_REACTANCIA,
            TransmisionAsociadaAlProyecto.C_RESISTENCIA,
            TransmisionAsociadaAlProyecto.C_SUSCEPTANCIA,
            TransmisionAsociadaAlProyecto.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_PK_TRANS_ASOCIADA_AL_PROY, OracleDbType.Int64, trasAsociadaAlProyecto.PkTransAsociadaAlProy, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_FK_PROYECTO, OracleDbType.Int64, trasAsociadaAlProyecto.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_NODO_DE_CONEXION, OracleDbType.Varchar2, trasAsociadaAlProyecto.NodoDeConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_TENSION, OracleDbType.Double, trasAsociadaAlProyecto.Tension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_LONGITUD, OracleDbType.Double, trasAsociadaAlProyecto.Longitud, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_COSTO, OracleDbType.Double, trasAsociadaAlProyecto.Costo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_CAPACIDAD_CONEXION, OracleDbType.Double, trasAsociadaAlProyecto.CapacidadConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_OBSERVACIONES, OracleDbType.Varchar2, trasAsociadaAlProyecto.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_FECHA_REGISTRO, OracleDbType.Date, trasAsociadaAlProyecto.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_REACTANCIA, OracleDbType.Double, trasAsociadaAlProyecto.Reactancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_RESISTENCIA, OracleDbType.Double, trasAsociadaAlProyecto.Resistencia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_SUSCEPTANCIA, OracleDbType.Double, trasAsociadaAlProyecto.Susceptancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TransmisionAsociadaAlProyecto.C_SEC_LOG, OracleDbType.Int64, trasAsociadaAlProyecto.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                trasAsociadaAlProyecto.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(TransmisionAsociadaAlProyecto.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<TransmisionAsociadaAlProyecto> GetLista()
        {
            BindingList<TransmisionAsociadaAlProyecto> resultado = new BindingList<TransmisionAsociadaAlProyecto>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new TransmisionAsociadaAlProyecto(row));
            }
            return resultado;
        }

        public TransmisionAsociadaAlProyecto GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, TransmisionAsociadaAlProyecto.NOMBRE_TABLA, TransmisionAsociadaAlProyecto.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            TransmisionAsociadaAlProyecto res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new TransmisionAsociadaAlProyecto(row);
            }
            return res;
        }
    }
}
