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
    public class OraDalDatosDemandaNodoBLoqueMgr : OraDalBaseMgr, IDatosDemandaNodoBLoqueMgr
    {
        #region Singleton
        private static OraDalDatosDemandaNodoBLoqueMgr _instancia;
        static OraDalDatosDemandaNodoBLoqueMgr()
        {
            _instancia = new OraDalDatosDemandaNodoBLoqueMgr();
        }
        public static OraDalDatosDemandaNodoBLoqueMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatosDemandaNodoBLoqueMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DemandaNodoIdentificadorSemana.NOMBRE_TABLA;
            }
        }
        public void Guardar(DatosDemandaNodoBLoque obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.PkDatosDemandaNodoBolque = GetIdAutoNum("SQ_F_DM_DATOS_DEM_NODO_BOLQUE");
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18})";
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
                "{18}=:{18}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_PK_DATOS_DEMANDA_NODO_BOLQUE,
            DatosDemandaNodoBLoque.C_ANIO,
            DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO,
            DatosDemandaNodoBLoque.C_ENERO,
            DatosDemandaNodoBLoque.C_FEBRERO,
            DatosDemandaNodoBLoque.C_MARZO,
            DatosDemandaNodoBLoque.C_ABRIL,
            DatosDemandaNodoBLoque.C_MAYO,
            DatosDemandaNodoBLoque.C_JUNIO,
            DatosDemandaNodoBLoque.C_JULIO,
            DatosDemandaNodoBLoque.C_AGOSTO,
            DatosDemandaNodoBLoque.C_SEPTIEMBRE,
            DatosDemandaNodoBLoque.C_OCTUBRE,
            DatosDemandaNodoBLoque.C_NOVIEMBRE,
            DatosDemandaNodoBLoque.C_DICIEMBRE,
            DatosDemandaNodoBLoque.C_FK_PERSONA_NODO,
            DatosDemandaNodoBLoque.C_SEC_LOG,
            DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_PK_DATOS_DEMANDA_NODO_BOLQUE, OracleDbType.Int64, obj.PkDatosDemandaNodoBolque, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ANIO, OracleDbType.Int32, obj.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO, OracleDbType.Int16, obj.NumeroPorAnio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ENERO, OracleDbType.Double, obj.Enero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FEBRERO, OracleDbType.Double, obj.Febrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_MARZO, OracleDbType.Double, obj.Marzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ABRIL, OracleDbType.Double, obj.Abril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_MAYO, OracleDbType.Double, obj.Mayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_JUNIO, OracleDbType.Double, obj.Junio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_JULIO, OracleDbType.Double, obj.Julio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_AGOSTO, OracleDbType.Double, obj.Agosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_SEPTIEMBRE, OracleDbType.Double, obj.Septiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_OCTUBRE, OracleDbType.Double, obj.Octubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_NOVIEMBRE, OracleDbType.Double, obj.Noviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_DICIEMBRE, OracleDbType.Double, obj.Diciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, OracleDbType.Decimal, obj.FkPersonaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Decimal, obj.FkDemandaSalidaMaestro, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatosDemandaNodoBLoque.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatosDemandaNodoBLoque> GetLista()
        {
            BindingList<DatosDemandaNodoBLoque> resultado = new BindingList<DatosDemandaNodoBLoque>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatosDemandaNodoBLoque(row));
            }
            return resultado;
        }

        public void GuardarTablaBloque(DataTable tabla, long pkPersonaNodo, long pkCategoriaDato, long pkDemandaSalidaMaestro)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            DatosDemandaNodoBLoque obj = new DatosDemandaNodoBLoque();
            obj.EsNuevo = true;

            string sql = "";
           
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18})";
          
              

            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_PK_DATOS_DEMANDA_NODO_BOLQUE,
            DatosDemandaNodoBLoque.C_ANIO,
            DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO,
            DatosDemandaNodoBLoque.C_ENERO,
            DatosDemandaNodoBLoque.C_FEBRERO,
            DatosDemandaNodoBLoque.C_MARZO,
            DatosDemandaNodoBLoque.C_ABRIL,
            DatosDemandaNodoBLoque.C_MAYO,
            DatosDemandaNodoBLoque.C_JUNIO,
            DatosDemandaNodoBLoque.C_JULIO,
            DatosDemandaNodoBLoque.C_AGOSTO,
            DatosDemandaNodoBLoque.C_SEPTIEMBRE,
            DatosDemandaNodoBLoque.C_OCTUBRE,
            DatosDemandaNodoBLoque.C_NOVIEMBRE,
            DatosDemandaNodoBLoque.C_DICIEMBRE,
            DatosDemandaNodoBLoque.C_FK_PERSONA_NODO,
            DatosDemandaNodoBLoque.C_SEC_LOG,
            DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_PK_DATOS_DEMANDA_NODO_BOLQUE, OracleDbType.Int64, GetArray(tabla, 0), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ANIO, OracleDbType.Int32, GetArray(tabla, 1), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO, OracleDbType.Int16, GetArray(tabla, 2), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ENERO, OracleDbType.Double, GetArray(tabla, 3), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FEBRERO, OracleDbType.Double, GetArray(tabla, 4), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_MARZO, OracleDbType.Double, GetArray(tabla, 5), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_ABRIL, OracleDbType.Double, GetArray(tabla, 6), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_MAYO, OracleDbType.Double, GetArray(tabla, 7), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_JUNIO, OracleDbType.Double, GetArray(tabla, 8), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_JULIO, OracleDbType.Double, GetArray(tabla, 9), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_AGOSTO, OracleDbType.Double, GetArray(tabla, 10), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_SEPTIEMBRE, OracleDbType.Double, GetArray(tabla, 11), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_OCTUBRE, OracleDbType.Double, GetArray(tabla, 12), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_NOVIEMBRE, OracleDbType.Double, GetArray(tabla, 13), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_DICIEMBRE, OracleDbType.Double, GetArray(tabla, 14), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, OracleDbType.Decimal, GetArray(tabla, -1, pkPersonaNodo), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 24), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Decimal, GetArray(tabla, -1, pkDemandaSalidaMaestro), System.Data.ParameterDirection.Input);
            Actualizar(cmd);
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DATOS_DEM_NODO_BOLQUE");
            }
        }

        private Array GetArray(DataTable tabla, int campo)
        {
            return GetArray(tabla, campo, null);
        }

        private Array GetArray(DataTable tabla, int campo, object valorDefecto)
        {
            object[] resultado = new object[tabla.Rows.Count];

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (campo >= 0 && campo < tabla.Rows[i].Table.Columns.Count)
                {
                    resultado[i] = tabla.Rows[i][campo];
                }
                else
                {
                    resultado[i] = valorDefecto;
                }
            }
            return resultado;
        }

        public DataTable GetDatos(long pkPersonaNodo)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2}  order by {3},{4}";
            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodoBLoque.C_ANIO, DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetDatosSalida(long pkPersonaNodo,long pkSalidaMaestro)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4}  order by {5},{6}";
            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO, pkSalidaMaestro, DatosDemandaNodoBLoque.C_ANIO, DatosDemandaNodoBLoque.C_NUMERO_POR_ANIO);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void EliminarDatos(long pkPersonaNodo)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}  ";
            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, pkPersonaNodo);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatosDeNodoSalida(long pkPersonaNodo, long pkSalidaMaestro)
        {
            string sql = "DELETE  FROM {0} WHERE {1}={2} AND {3} ={4} ";
            sql = string.Format(sql, DatosDemandaNodoBLoque.NOMBRE_TABLA, DatosDemandaNodoBLoque.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodoBLoque.C_FK_DEMANDA_SALIDA_MAESTRO, pkSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarRegistro(long pkDato)
        {
            string sql = "delete from {0} where {1}={2}  ";
            sql = string.Format(sql, NombreTabla, DatosDemandaNodoBLoque.C_PK_DATOS_DEMANDA_NODO_BOLQUE, pkDato);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
