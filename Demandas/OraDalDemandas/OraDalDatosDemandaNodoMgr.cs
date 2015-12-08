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
    public class OraDalDatosDemandaNodoMgr : OraDalBaseMgr, IDatosDemandaNodoMgr
    {
        #region Singleton
        private static OraDalDatosDemandaNodoMgr _instancia;
        static OraDalDatosDemandaNodoMgr()
        {
            _instancia = new OraDalDatosDemandaNodoMgr();
        }
        public static OraDalDatosDemandaNodoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatosDemandaNodoMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DatosDemandaNodo.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatosDemandaNodo obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatosDemadaNodo = GetIdAutoNum("SQ_F_DM_DATOS_DEMADA_NODO");

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

            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_PK_DATOS_DEMADA_NODO,
            DatosDemandaNodo.C_ANIO,
            DatosDemandaNodo.C_ENERO,
            DatosDemandaNodo.C_FEBRERO,
            DatosDemandaNodo.C_MARZO,
            DatosDemandaNodo.C_ABRIL,
            DatosDemandaNodo.C_MAYO,
            DatosDemandaNodo.C_JUNIO,
            DatosDemandaNodo.C_JULIO,
            DatosDemandaNodo.C_AGOSTO,
            DatosDemandaNodo.C_SEPTIEMBRE,
            DatosDemandaNodo.C_OCTUBRE,
            DatosDemandaNodo.C_NOVIEMBRE,
            DatosDemandaNodo.C_DICIEMBRE,
            DatosDemandaNodo.C_FK_PERSONA_NODO,
            DatosDemandaNodo.C_SEC_LOG,
            DatosDemandaNodo.C_D_COD_CATEGORIA_DATO,
            DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatosDemandaNodo.C_PK_DATOS_DEMADA_NODO, OracleDbType.Int64, obj.PkDatosDemadaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ANIO, OracleDbType.Int64, obj.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ENERO, OracleDbType.Double, obj.Enero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FEBRERO, OracleDbType.Double, obj.Febrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_MARZO, OracleDbType.Double, obj.Marzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ABRIL, OracleDbType.Double, obj.Abril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_MAYO, OracleDbType.Double, obj.Mayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_JUNIO, OracleDbType.Double, obj.Junio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_JULIO, OracleDbType.Double, obj.Julio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_AGOSTO, OracleDbType.Double, obj.Agosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_SEPTIEMBRE, OracleDbType.Double, obj.Septiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_OCTUBRE, OracleDbType.Double, obj.Octubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_NOVIEMBRE, OracleDbType.Double, obj.Noviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_DICIEMBRE, OracleDbType.Double, obj.Diciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FK_PERSONA_NODO, OracleDbType.Int64, obj.FkPersonaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, obj.DCodCategoriaDato, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, obj.FkDemandaSalidaMaestro, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatosDemandaNodo.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatosDemandaNodo> GetLista()
        {
            BindingList<DatosDemandaNodo> resultado = new BindingList<DatosDemandaNodo>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatosDemandaNodo(row));
            }
            return resultado;
        }

        public void GuardarDemandaNodo(DataTable tabla, long pkPersonaNodo, long pkCategoriaDato, long pkDemandaSalidaMaestro)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18})";

            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_PK_DATOS_DEMADA_NODO,
            DatosDemandaNodo.C_ANIO,
            DatosDemandaNodo.C_ENERO,
            DatosDemandaNodo.C_FEBRERO,
            DatosDemandaNodo.C_MARZO,
            DatosDemandaNodo.C_ABRIL,
            DatosDemandaNodo.C_MAYO,
            DatosDemandaNodo.C_JUNIO,
            DatosDemandaNodo.C_JULIO,
            DatosDemandaNodo.C_AGOSTO,
            DatosDemandaNodo.C_SEPTIEMBRE,
            DatosDemandaNodo.C_OCTUBRE,
            DatosDemandaNodo.C_NOVIEMBRE,
            DatosDemandaNodo.C_DICIEMBRE,
            DatosDemandaNodo.C_FK_PERSONA_NODO,
            DatosDemandaNodo.C_SEC_LOG,
            DatosDemandaNodo.C_D_COD_CATEGORIA_DATO,
            DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DatosDemandaNodo.C_PK_DATOS_DEMADA_NODO, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ANIO, OracleDbType.Int64, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ENERO, OracleDbType.Double, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FEBRERO, OracleDbType.Double, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_MARZO, OracleDbType.Double, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_ABRIL, OracleDbType.Double, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_MAYO, OracleDbType.Double, GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_JUNIO, OracleDbType.Double, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_JULIO, OracleDbType.Double, GetArray(tabla, 8), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_AGOSTO, OracleDbType.Double, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_SEPTIEMBRE, OracleDbType.Double, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_OCTUBRE, OracleDbType.Double, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_NOVIEMBRE, OracleDbType.Double, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_DICIEMBRE, OracleDbType.Double, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FK_PERSONA_NODO, OracleDbType.Int64, GetArray(tabla, -1,pkPersonaNodo), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 17), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, GetArray(tabla, -1, pkCategoriaDato), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, GetArray(tabla, -1, pkDemandaSalidaMaestro), ParameterDirection.Input);
            Actualizar(cmd);
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DATOS_DEMADA_NODO");
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

        public DataTable GetDatos( long pkPersonaNodo, long pkCatDato)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4} order by anio";
            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, pkCatDato);
            DataTable tabla= EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetDatosSalida(long pkPersonaNodo, long pkCatDato, long pkDatosSalidaMaestro)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4} AND {5}={6} order by anio";
            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, pkCatDato, DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO,pkDatosSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void EliminarTablaDatosPersonaNodo( long pkPersonaNodo, long pkTipoTabla)
        {
            string sql = "delete from {0} where {1}={2} and {3}={4} ";
            sql = string.Format(sql, NombreTabla, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, pkTipoTabla);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarTablaDatosPersonaNodo(long pkPersonaNodo)
        {
            string sql = "delete from {0} where {1}={2} ";
            sql = string.Format(sql, NombreTabla, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }


        public void EliminarRegistro(long pkDato)
        {
            string sql = "delete from {0} where {1}={2}  ";
            sql = string.Format(sql, NombreTabla, DatosDemandaNodo.C_PK_DATOS_DEMADA_NODO, pkDato);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatosDeNodoSalida(long pkPersonaNodo, long pkCatDato, long pkDatosSalidaMaestro)
        {
            string sql = "DELETE  FROM {0} WHERE {1}={2} AND {3} ={4} AND {5}={6} ";
            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo, DatosDemandaNodo.C_D_COD_CATEGORIA_DATO, pkCatDato, DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO, pkDatosSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatosDeNodoSalida(long pkPersonaNodo, long pkDatosSalidaMaestro)
        {
            string sql = "DELETE  FROM {0} WHERE {1}={2} AND {3} ={4}  ";
            sql = string.Format(sql, DatosDemandaNodo.NOMBRE_TABLA, DatosDemandaNodo.C_FK_PERSONA_NODO, pkPersonaNodo,DatosDemandaNodo.C_FK_DEMANDA_SALIDA_MAESTRO, pkDatosSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
