using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using ModeloDemandas;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace OraDalDemandas
{
    public class OraDalDemandaSalidaDetalleMgr : OraDalBaseMgr, IDemandaSalidaDetalleMgr
    {
        #region Singleton
        private static OraDalDemandaSalidaDetalleMgr _instancia;
        static OraDalDemandaSalidaDetalleMgr()
        {
            _instancia = new OraDalDemandaSalidaDetalleMgr();
        }
        public static OraDalDemandaSalidaDetalleMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDemandaSalidaDetalleMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DemandaSalidaDetalle.NOMBRE_TABLA;
            }
        }
        public void Guardar(DemandaSalidaDetalle obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demanda", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDemandaSalidaDetalle = GetIdAutoNum("SQ_F_DM_DEMANDA_SALIDA_DETALLE");
                sql = "INSERT INTO {0} ({1},{2},{3},{4})" +
                "VALUES(:{1},:{2},:{3},:{4})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DemandaSalidaDetalle.NOMBRE_TABLA, DemandaSalidaDetalle.C_PK_DEMANDA_SALIDA_DETALLE,
            DemandaSalidaDetalle.C_FK_DEMANDA_SALIDA_MAESTRO,
            DemandaSalidaDetalle.C_FK_NODO_DEMANDA,
            DemandaSalidaDetalle.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DemandaSalidaDetalle.C_PK_DEMANDA_SALIDA_DETALLE, OracleDbType.Int64, obj.PkDemandaSalidaDetalle, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaDetalle.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, obj.FkDemandaSalidaMaestro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaDetalle.C_FK_NODO_DEMANDA, OracleDbType.Int64, obj.FkNodoDemanda, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaDetalle.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DemandaSalidaDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DemandaSalidaDetalle> GetLista()
        {
            BindingList<DemandaSalidaDetalle> resultado = new BindingList<DemandaSalidaDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DemandaSalidaDetalle(row));
            }
            return resultado;
        }

        public void EliminarRegistro(long pkSalidaMaestro)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaDetalle.C_FK_DEMANDA_SALIDA_MAESTRO, pkSalidaMaestro);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public List<NodoDemanda> GetListaNodos(long pkDemandaSalidaMaestro)
        {
            string sql = "select * from {0} where {1}={2}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaDetalle.C_FK_DEMANDA_SALIDA_MAESTRO, pkDemandaSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            List<NodoDemanda> listaNodos = new List<NodoDemanda>();

            foreach (DataRow row in tabla.Rows)
            {
                NodoDemanda nodo = OraDalNodoDemandaMgr.Instancia.GetPorId<NodoDemanda>((long)row[DemandaSalidaMaestro.C_FK_NODO_DEMANDA], NodoDemanda.C_PK_NODO_DEMANDA);
                listaNodos.Add(nodo);
            }
            return listaNodos;
        }

        internal void EliminarRegistroDetalle(long pkSalidaMaestro,long pkNodo)
        {
            string sql = "delete from {0} where {1}={2} and {3}={4} ";
            sql = string.Format(sql, NombreTabla, DemandaSalidaDetalle.C_FK_DEMANDA_SALIDA_MAESTRO, pkSalidaMaestro, DemandaSalidaDetalle.C_FK_NODO_DEMANDA, pkNodo);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
