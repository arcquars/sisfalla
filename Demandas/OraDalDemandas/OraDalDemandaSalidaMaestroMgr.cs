using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using ModeloDemandas;

namespace OraDalDemandas
{
    public class OraDalDemandaSalidaMaestroMgr : OraDalBaseMgr, IDemandaSalidaMaestroMgr
    {
        #region Singleton
        private static OraDalDemandaSalidaMaestroMgr _instancia;
        static OraDalDemandaSalidaMaestroMgr()
        {
            _instancia = new OraDalDemandaSalidaMaestroMgr();
        }
        public static OraDalDemandaSalidaMaestroMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDemandaSalidaMaestroMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DemandaSalidaMaestro.NOMBRE_TABLA;
            }
        }

        public void Guardar(DemandaSalidaMaestro obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demanda", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDemandaSalidaMaestro = GetIdAutoNum("SQ_F_DM_DEMANDA_SALIDA_MAESTRO");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DemandaSalidaMaestro.NOMBRE_TABLA, DemandaSalidaMaestro.C_PK_DEMANDA_SALIDA_MAESTRO,
            DemandaSalidaMaestro.C_FK_NODO_SALIDA,
            DemandaSalidaMaestro.C_D_COD_TIPO_NODO_SALIDA,
            DemandaSalidaMaestro.C_FK_NODO_DEMANDA,
            DemandaSalidaMaestro.C_FK_PERSONA_NODO,
            DemandaSalidaMaestro.C_SEG_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DemandaSalidaMaestro.C_PK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, obj.PkDemandaSalidaMaestro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaMaestro.C_FK_NODO_SALIDA, OracleDbType.Int64, obj.FkNodoSalida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaMaestro.C_D_COD_TIPO_NODO_SALIDA, OracleDbType.Int64, obj.DCodTipoNodoSalida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaMaestro.C_FK_NODO_DEMANDA, OracleDbType.Int64, obj.FkNodoDemanda, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaMaestro.C_FK_PERSONA_NODO, OracleDbType.Int64, obj.FkPersonaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaSalidaMaestro.C_SEG_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DemandaSalidaMaestro.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DemandaSalidaMaestro> GetLista()
        {
            BindingList<DemandaSalidaMaestro> resultado = new BindingList<DemandaSalidaMaestro>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DemandaSalidaMaestro(row));
            }
            return resultado;
        }

        public DemandaSalidaMaestro GetDemandaSalida(long pkPersonaNodo, long pkNodoDemandaSalida, int pkTipoSalida)
        {
            string sql = "SELECT * FROM {0}  WHERE {1}={2} and {3}={4} and {5}={6}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.C_FK_NODO_SALIDA, pkNodoDemandaSalida, DemandaSalidaMaestro.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaSalidaMaestro.C_D_COD_TIPO_NODO_SALIDA, pkTipoSalida);
            DataTable tabla = EjecutarSql(sql);
            DemandaSalidaMaestro demandaSalidaMaestro = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                demandaSalidaMaestro = new DemandaSalidaMaestro(row);
            }
            return demandaSalidaMaestro;
        }

        public DemandaSalidaMaestro GetDemandaSalidaDeNodoDemanda(long pkPersonaNodo, long pkNodoDemanda)
        {
            string sql = "SELECT * FROM {0}  WHERE {1}={2} and {3}={4}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.C_FK_NODO_DEMANDA, pkNodoDemanda, DemandaSalidaMaestro.C_FK_PERSONA_NODO, pkPersonaNodo);
            DataTable tabla = EjecutarSql(sql);
            DemandaSalidaMaestro demandaSalidaMaestro = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                demandaSalidaMaestro = new DemandaSalidaMaestro(row);
            }
            return demandaSalidaMaestro;
        }

        public void EliminarSalidaMaestro(long pkPersonaNodo, long pkNodoDemanda)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} AND {3}={4}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaSalidaMaestro.C_FK_NODO_DEMANDA, pkNodoDemanda);
            DataTable tabla = EjecutarSql(sql);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {

                    DemandaSalidaMaestro demandaSalidaMaestro = new DemandaSalidaMaestro(row);

                    //eliminar tablas series 
                    OraDalDatosDemandaNodoMgr.Instancia.EliminarDatosDeNodoSalida(pkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                    //eliminar tablas identificadores
                    OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatosDeNodoSalida(pkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                    // eliminar datos: bloque
                    OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatosDeNodoSalida(pkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                }
                sql = "delete from {0} where {1}={2} and {3}={4}";
                sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaSalidaMaestro.C_FK_NODO_DEMANDA, pkNodoDemanda);
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                bool res = Actualizar(cmd);
            }
        }

        public void EliminarRegistroSalidaMaestro(long pkSalidaMaestro)
        {
            string sql = "delete from {0} where {1}={2}";
            sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.C_PK_DEMANDA_SALIDA_MAESTRO, pkSalidaMaestro);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}