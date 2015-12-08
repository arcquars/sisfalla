using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using CNDC.Pistas;
using CNDC.DAL;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoCapacitorMgr : OraDalBaseMgr, IDatoTecnicoCapacitorMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoCapacitorMgr _instancia;
        static OraDalDatoTecnicoCapacitorMgr()
        {
            _instancia = new OraDalDatoTecnicoCapacitorMgr();
        }
        public static OraDalDatoTecnicoCapacitorMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoCapacitorMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoCapacitor.NOMBRE_TABLA;
            }
        }
        public void Guardar(DatoTecnicoCapacitor obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecCapacitor = GetIdAutoNum("SQ_F_PR_DATO_TEC_CAPACITOR");
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
                "{11}=:{11}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DatoTecnicoCapacitor.NOMBRE_TABLA, DatoTecnicoCapacitor.C_PK_DATO_TEC_CAPACITOR,
            DatoTecnicoCapacitor.C_FK_PROYECTO,
            DatoTecnicoCapacitor.C_D_COD_TIPO_BANCO_CAPACITOR,
            DatoTecnicoCapacitor.C_POT_NOMINAL_TRIFASICA_REAC,
            DatoTecnicoCapacitor.C_NODO_CONEXION_ORIGEN,
            DatoTecnicoCapacitor.C_NODO_CONEXION_DESTINO,
            DatoTecnicoCapacitor.C_OBSERVACIONES,
            DatoTecnicoCapacitor.C_XC_REACTANCIA_CAPACITIVA,
            DatoTecnicoCapacitor.C_TENSION_NOMINAL,
            DatoTecnicoCapacitor.C_SEC_LOG,
            DatoTecnicoCapacitor.C_FECHA_REGISTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(DatoTecnicoCapacitor.C_PK_DATO_TEC_CAPACITOR, OracleDbType.Int64, obj.PkDatoTecCapacitor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_D_COD_TIPO_BANCO_CAPACITOR, OracleDbType.Int64, obj.DCodTipoBancoCapacitor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_POT_NOMINAL_TRIFASICA_REAC, OracleDbType.Double, obj.PotNominalTrifasicaReac, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_NODO_CONEXION_ORIGEN, OracleDbType.Varchar2, obj.NodoConexionOrigen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_NODO_CONEXION_DESTINO, OracleDbType.Varchar2, obj.NodoConexionDestino, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_OBSERVACIONES, OracleDbType.Varchar2, obj.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_XC_REACTANCIA_CAPACITIVA, OracleDbType.Double, obj.XcReactanciaCapacitiva, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_TENSION_NOMINAL, OracleDbType.Double, obj.TensionNominal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoCapacitor.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaRegistro, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoCapacitor.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoCapacitor> GetLista()
        {
            BindingList<DatoTecnicoCapacitor> resultado = new BindingList<DatoTecnicoCapacitor>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoCapacitor(row));
            }
            return resultado;
        }

        public DatoTecnicoCapacitor GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0},F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoCapacitor.NOMBRE_TABLA, DatoTecnicoCapacitor.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoCapacitor res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoCapacitor(row);
            }
            return res;
        }
    }
}
