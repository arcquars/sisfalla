using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace ModeloProyectos
{
    public class OraDalDatoTecnicoLineaTransmisionMgr : OraDalBaseMgr, IDatoTecnicoLineaTransmisionMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoLineaTransmisionMgr _instancia;
        static OraDalDatoTecnicoLineaTransmisionMgr()
        {
            _instancia = new OraDalDatoTecnicoLineaTransmisionMgr();
        }
        public static OraDalDatoTecnicoLineaTransmisionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoLineaTransmisionMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoLineaTransmision.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoLineaTransmision obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecLinTransmision = GetIdAutoNum("SQ_F_PR_DATO_TEC_LINEA_TRANS");
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
                "{19}=:{19}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoLineaTransmision.NOMBRE_TABLA, DatoTecnicoLineaTransmision.C_PK_DATO_TEC_LIN_TRANSMISION,
            DatoTecnicoLineaTransmision.C_FK_PROYECTO,
            DatoTecnicoLineaTransmision.C_NIVEL_TENSION,
            DatoTecnicoLineaTransmision.C_CAPACIDAD_TRANSMISION,
            DatoTecnicoLineaTransmision.C_CALIBRE_TIPO_CONDUCTOR,
            DatoTecnicoLineaTransmision.C_D_COD_TIPO_ESTRUCTURA_SOPORTE,
            DatoTecnicoLineaTransmision.C_FK_LOC_PROY_TRANS_ORIGEN,
            DatoTecnicoLineaTransmision.C_FK_LOC_PROY_TRANS_DESTINO,
            DatoTecnicoLineaTransmision.C_D_COD_CONF_BAHIA_ORIGEN,
            DatoTecnicoLineaTransmision.C_D_COD_CONF_BAHIA_DESTINO,
            DatoTecnicoLineaTransmision.C_OBSERVACION,
            DatoTecnicoLineaTransmision.C_SEC_LOG,
            DatoTecnicoLineaTransmision.C_LONGITUD_LINEA,
            DatoTecnicoLineaTransmision.C_RESISTENCIA,
            DatoTecnicoLineaTransmision.C_REACTANCIA,
            DatoTecnicoLineaTransmision.C_SUSCEPTANCIA,
            DatoTecnicoLineaTransmision.C_FECHA_REGISTRO,
            DatoTecnicoLineaTransmision.C_NODO_ORIGEN,
            DatoTecnicoLineaTransmision.C_NODO_DESTINO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_PK_DATO_TEC_LIN_TRANSMISION, OracleDbType.Int64, obj.PkDatoTecLinTransmision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_NIVEL_TENSION, OracleDbType.Double, obj.NivelTension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_CAPACIDAD_TRANSMISION, OracleDbType.Double, obj.CapacidadTransmision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_CALIBRE_TIPO_CONDUCTOR, OracleDbType.Varchar2, obj.CalibreTipoConductor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_D_COD_TIPO_ESTRUCTURA_SOPORTE, OracleDbType.Int64, obj.DCodTipoEstructuraSoporte, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_FK_LOC_PROY_TRANS_ORIGEN, OracleDbType.Int64, obj.FkLocProyTransOrigen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_FK_LOC_PROY_TRANS_DESTINO, OracleDbType.Int64, obj.FkLocProyTransDestino, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_D_COD_CONF_BAHIA_ORIGEN, OracleDbType.Int64, obj.DCodConfBahiaOrigen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_D_COD_CONF_BAHIA_DESTINO, OracleDbType.Int64, obj.DCodConfBahiaDestino, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_OBSERVACION, OracleDbType.Varchar2, obj.Observacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_LONGITUD_LINEA, OracleDbType.Double, obj.LongitudLinea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_RESISTENCIA, OracleDbType.Double, obj.Resistencia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_REACTANCIA, OracleDbType.Double, obj.Reactancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_SUSCEPTANCIA, OracleDbType.Double, obj.Susceptancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_NODO_ORIGEN, OracleDbType.Varchar2, obj.NodoOrigen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoLineaTransmision.C_NODO_DESTINO, OracleDbType.Varchar2, obj.NodoDestino, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoLineaTransmision.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoLineaTransmision> GetLista()
        {
            BindingList<DatoTecnicoLineaTransmision> resultado = new BindingList<DatoTecnicoLineaTransmision>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoLineaTransmision(row));
            }
            return resultado;
        }

        public DatoTecnicoLineaTransmision GetPorPkProyecto(long pkProyecto)
        {
            DatoTecnicoLineaTransmision res = null;
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoLineaTransmision.NOMBRE_TABLA, DatoTecnicoLineaTransmision.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoLineaTransmision(row);
            }
            return res;
        }

    }
}
