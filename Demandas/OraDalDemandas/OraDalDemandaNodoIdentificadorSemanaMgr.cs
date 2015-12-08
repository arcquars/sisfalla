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
    public class OraDalDemandaNodoIdentificadorSemanaMgr : OraDalBaseMgr, IDemandaNodoIdentificadorSemanaMgr
    {
        #region Singleton
        private static OraDalDemandaNodoIdentificadorSemanaMgr _instancia;
        static OraDalDemandaNodoIdentificadorSemanaMgr()
        {
            _instancia = new OraDalDemandaNodoIdentificadorSemanaMgr();
        }
        public static OraDalDemandaNodoIdentificadorSemanaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDemandaNodoIdentificadorSemanaMgr()
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

        public void Guardar(DemandaNodoIdentificadorSemana obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.PkDemandaNodoIdentSemana = GetIdAutoNum("SQ_F_DM_DEM_NODO_IDENT_SEMANA");
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23},:{24},:{25},:{26},:{27},:{28},:{29},:{30},:{31})";
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
                "{19}=:{19} ," +
                "{20}=:{20} ," +
                "{21}=:{21} ," +
                "{22}=:{22} ," +
                "{23}=:{23} ," +
                "{24}=:{24} ," +
                "{25}=:{25} ," +
                "{26}=:{26} ," +
                "{27}=:{27} ," +
                "{28}=:{28} ," +
                "{29}=:{29} ," +
                "{30}=:{30} ," +
                "{31}=:{31}   WHERE {1}=:{1}";
            }

            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA,
            DemandaNodoIdentificadorSemana.C_D_COD_DIA_SEMANA,
            DemandaNodoIdentificadorSemana.C_HORA_1,
            DemandaNodoIdentificadorSemana.C_HORA_2,
            DemandaNodoIdentificadorSemana.C_HORA_3,
            DemandaNodoIdentificadorSemana.C_HORA_4,
            DemandaNodoIdentificadorSemana.C_HORA_5,
            DemandaNodoIdentificadorSemana.C_HORA_6,
            DemandaNodoIdentificadorSemana.C_HORA_7,
            DemandaNodoIdentificadorSemana.C_HORA_8,
            DemandaNodoIdentificadorSemana.C_HORA_9,
            DemandaNodoIdentificadorSemana.C_HORA_10,
            DemandaNodoIdentificadorSemana.C_HORA_11,
            DemandaNodoIdentificadorSemana.C_HORA_12,
            DemandaNodoIdentificadorSemana.C_HORA_13,
            DemandaNodoIdentificadorSemana.C_HORA_14,
            DemandaNodoIdentificadorSemana.C_HORA_15,
            DemandaNodoIdentificadorSemana.C_HORA_16,
            DemandaNodoIdentificadorSemana.C_HORA_17,
            DemandaNodoIdentificadorSemana.C_HORA_18,
            DemandaNodoIdentificadorSemana.C_HORA_19,
            DemandaNodoIdentificadorSemana.C_HORA_20,
            DemandaNodoIdentificadorSemana.C_HORA_21,
            DemandaNodoIdentificadorSemana.C_HORA_22,
            DemandaNodoIdentificadorSemana.C_HORA_23,
            DemandaNodoIdentificadorSemana.C_HORA_24,
            DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO,
            DemandaNodoIdentificadorSemana.C_SEC_LOG,
            DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO,
            DemandaNodoIdentificadorSemana.C_FK_PERSONA,
            DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA, OracleDbType.Int64, obj.PkDemandaNodoIdentSemana, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_D_COD_DIA_SEMANA, OracleDbType.Int64, obj.DCodDiaSemana, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_1, OracleDbType.Double, obj.Hora1, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_2, OracleDbType.Double, obj.Hora2, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_3, OracleDbType.Double, obj.Hora3, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_4, OracleDbType.Double, obj.Hora4, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_5, OracleDbType.Double, obj.Hora5, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_6, OracleDbType.Double, obj.Hora6, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_7, OracleDbType.Double, obj.Hora7, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_8, OracleDbType.Double, obj.Hora8, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_9, OracleDbType.Double, obj.Hora9, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_10, OracleDbType.Double, obj.Hora10, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_11, OracleDbType.Double, obj.Hora11, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_12, OracleDbType.Double, obj.Hora12, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_13, OracleDbType.Double, obj.Hora13, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_14, OracleDbType.Double, obj.Hora14, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_15, OracleDbType.Double, obj.Hora15, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_16, OracleDbType.Double, obj.Hora16, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_17, OracleDbType.Double, obj.Hora17, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_18, OracleDbType.Double, obj.Hora18, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_19, OracleDbType.Double, obj.Hora19, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_20, OracleDbType.Double, obj.Hora20, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_21, OracleDbType.Double, obj.Hora21, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_22, OracleDbType.Double, obj.Hora22, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_23, OracleDbType.Double, obj.Hora23, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_24, OracleDbType.Double, obj.Hora24, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, OracleDbType.Int64, obj.FkPersonaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, obj.DCodCategoriaDato, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_PERSONA, OracleDbType.Int64, obj.FkPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, obj.FkDemandaSalidaMaestro, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DEM_NODO_IDENT_SEMANA");
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

        public void GuardarTabla(DataTable tabla, long pkPersonaNodo, long pkCategoriaDato, long pkDemandaSalidaMaestro, long pkPersona)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23},:{24},:{25},:{26},:{27},:{28},:{29},:{30},:{31})";
          

            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA,
            DemandaNodoIdentificadorSemana.C_D_COD_DIA_SEMANA,
            DemandaNodoIdentificadorSemana.C_HORA_1,
            DemandaNodoIdentificadorSemana.C_HORA_2,
            DemandaNodoIdentificadorSemana.C_HORA_3,
            DemandaNodoIdentificadorSemana.C_HORA_4,
            DemandaNodoIdentificadorSemana.C_HORA_5,
            DemandaNodoIdentificadorSemana.C_HORA_6,
            DemandaNodoIdentificadorSemana.C_HORA_7,
            DemandaNodoIdentificadorSemana.C_HORA_8,
            DemandaNodoIdentificadorSemana.C_HORA_9,
            DemandaNodoIdentificadorSemana.C_HORA_10,
            DemandaNodoIdentificadorSemana.C_HORA_11,
            DemandaNodoIdentificadorSemana.C_HORA_12,
            DemandaNodoIdentificadorSemana.C_HORA_13,
            DemandaNodoIdentificadorSemana.C_HORA_14,
            DemandaNodoIdentificadorSemana.C_HORA_15,
            DemandaNodoIdentificadorSemana.C_HORA_16,
            DemandaNodoIdentificadorSemana.C_HORA_17,
            DemandaNodoIdentificadorSemana.C_HORA_18,
            DemandaNodoIdentificadorSemana.C_HORA_19,
            DemandaNodoIdentificadorSemana.C_HORA_20,
            DemandaNodoIdentificadorSemana.C_HORA_21,
            DemandaNodoIdentificadorSemana.C_HORA_22,
            DemandaNodoIdentificadorSemana.C_HORA_23,
            DemandaNodoIdentificadorSemana.C_HORA_24,
            DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO,
            DemandaNodoIdentificadorSemana.C_SEC_LOG,
            DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO,
            DemandaNodoIdentificadorSemana.C_FK_PERSONA,
            DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA, OracleDbType.Int64, GetArray(tabla, 0), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_D_COD_DIA_SEMANA, OracleDbType.Int64, GetArray(tabla, 1), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_1, OracleDbType.Double, GetArray(tabla, 3), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_2, OracleDbType.Double, GetArray(tabla, 4), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_3, OracleDbType.Double, GetArray(tabla, 5), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_4, OracleDbType.Double, GetArray(tabla, 6), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_5, OracleDbType.Double, GetArray(tabla, 7), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_6, OracleDbType.Double, GetArray(tabla, 8), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_7, OracleDbType.Double, GetArray(tabla, 9), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_8, OracleDbType.Double, GetArray(tabla,10), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_9, OracleDbType.Double, GetArray(tabla, 11), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_10, OracleDbType.Double, GetArray(tabla, 12), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_11, OracleDbType.Double, GetArray(tabla, 13), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_12, OracleDbType.Double, GetArray(tabla, 14), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_13, OracleDbType.Double, GetArray(tabla, 15), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_14, OracleDbType.Double, GetArray(tabla, 16), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_15, OracleDbType.Double, GetArray(tabla, 17), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_16, OracleDbType.Double, GetArray(tabla, 18), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_17, OracleDbType.Double, GetArray(tabla, 19), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_18, OracleDbType.Double, GetArray(tabla, 20), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_19, OracleDbType.Double, GetArray(tabla, 21), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_20, OracleDbType.Double, GetArray(tabla, 22), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_21, OracleDbType.Double, GetArray(tabla, 23), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_22, OracleDbType.Double, GetArray(tabla, 24), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_23, OracleDbType.Double, GetArray(tabla, 25), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_HORA_24, OracleDbType.Double, GetArray(tabla, 26), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, OracleDbType.Int64, GetArray(tabla, -1, pkPersonaNodo), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 30), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, GetArray(tabla, -1, pkCategoriaDato), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_PERSONA, OracleDbType.Int64, GetArray(tabla, -1, pkPersona), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO, OracleDbType.Int64, GetArray(tabla, -1, pkDemandaSalidaMaestro), System.Data.ParameterDirection.Input);
            Actualizar(cmd);
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DemandaNodoIdentificadorSemana.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DemandaNodoIdentificadorSemana> GetLista()
        {
            BindingList<DemandaNodoIdentificadorSemana> resultado = new BindingList<DemandaNodoIdentificadorSemana>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DemandaNodoIdentificadorSemana(row));
            }
            return resultado;
        }

        public DataTable GetDatos(long pkPersonaNodo, long codTipoTabla)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4} order by {5}";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, codTipoTabla, DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetDatosSalida(long pkPersonaNodo, long codTipoTabla,long codPkSalidaMaestro)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4} AND {5}={6} order by {7}";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, codTipoTabla, DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO, codPkSalidaMaestro, DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void EliminarDatos(long pkPersonaNodo, long codTipoTabla)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} AND {3} ={4}";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, codTipoTabla);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatos(long pkPersonaNodo)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatosDeNodoSalida(long pkPersonaNodo, long codTipoTabla, long codPkSalidaMaestro)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} AND {3} ={4} AND {5}={6} ";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaNodoIdentificadorSemana.C_D_COD_CATEGORIA_DATO, codTipoTabla, DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO, codPkSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }


        public void EliminarDatosDeNodoSalida(long pkPersonaNodo, long codPkSalidaMaestro)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} AND {3} ={4}  ";
            sql = string.Format(sql, DemandaNodoIdentificadorSemana.NOMBRE_TABLA, DemandaNodoIdentificadorSemana.C_FK_PERSONA_NODO, pkPersonaNodo, DemandaNodoIdentificadorSemana.C_FK_DEMANDA_SALIDA_MAESTRO, codPkSalidaMaestro);
            DataTable tabla = EjecutarSql(sql);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarRegistro(long pkDato)
        {
            string sql = "delete from {0} where {1}={2}  ";
            sql = string.Format(sql, NombreTabla, DemandaNodoIdentificadorSemana.C_PK_DEMANDA_NODO_IDENT_SEMANA, pkDato);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
