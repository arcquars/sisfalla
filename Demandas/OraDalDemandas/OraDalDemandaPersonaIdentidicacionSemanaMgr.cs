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
    public class OraDalDemandaPersonaIdentidicacionSemanaMgr : OraDalBaseMgr, IDemandaPersonaIdentidicacionSemanaMgr
    {
        #region Singleton
        private static OraDalDemandaPersonaIdentidicacionSemanaMgr _instancia;
        static OraDalDemandaPersonaIdentidicacionSemanaMgr()
        {
            _instancia = new OraDalDemandaPersonaIdentidicacionSemanaMgr();
        }
        public static OraDalDemandaPersonaIdentidicacionSemanaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDemandaPersonaIdentidicacionSemanaMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DemandaPersonaIdentidicacionSemana.NOMBRE_TABLA;
            }
        }
        public void Guardar(DemandaPersonaIdentidicacionSemana obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.PkDemPersonaIdentSemana = GetIdAutoNum("SQ_F_DM_DEM_PERSONA_IDENT_SEM");
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23},:{24},:{25},:{26},:{27},:{28},:{29})";
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
                "{29}=:{29}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DemandaPersonaIdentidicacionSemana.NOMBRE_TABLA, DemandaPersonaIdentidicacionSemana.C_PK_DEM_PERSONA_IDENT_SEMANA,
            DemandaPersonaIdentidicacionSemana.C_D_COD_DIA_SEMANA,
            DemandaPersonaIdentidicacionSemana.C_HORA_1,
            DemandaPersonaIdentidicacionSemana.C_HORA_2,
            DemandaPersonaIdentidicacionSemana.C_HORA_3,
            DemandaPersonaIdentidicacionSemana.C_HORA_4,
            DemandaPersonaIdentidicacionSemana.C_HORA_5,
            DemandaPersonaIdentidicacionSemana.C_HORA_6,
            DemandaPersonaIdentidicacionSemana.C_HORA_7,
            DemandaPersonaIdentidicacionSemana.C_HORA_8,
            DemandaPersonaIdentidicacionSemana.C_HORA_9,
            DemandaPersonaIdentidicacionSemana.C_HORA_10,
            DemandaPersonaIdentidicacionSemana.C_HORA_11,
            DemandaPersonaIdentidicacionSemana.C_HORA_12,
            DemandaPersonaIdentidicacionSemana.C_HORA_13,
            DemandaPersonaIdentidicacionSemana.C_HORA_14,
            DemandaPersonaIdentidicacionSemana.C_HORA_15,
            DemandaPersonaIdentidicacionSemana.C_HORA_16,
            DemandaPersonaIdentidicacionSemana.C_HORA_17,
            DemandaPersonaIdentidicacionSemana.C_HORA_18,
            DemandaPersonaIdentidicacionSemana.C_HORA_19,
            DemandaPersonaIdentidicacionSemana.C_HORA_20,
            DemandaPersonaIdentidicacionSemana.C_HORA_21,
            DemandaPersonaIdentidicacionSemana.C_HORA_22,
            DemandaPersonaIdentidicacionSemana.C_HORA_23,
            DemandaPersonaIdentidicacionSemana.C_HORA_24,
            DemandaPersonaIdentidicacionSemana.C_FK_PERSONA,
            DemandaPersonaIdentidicacionSemana.C_SEC_LOG,
            DemandaPersonaIdentidicacionSemana.C_D_COD_CATEGORIA_DATO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_PK_DEM_PERSONA_IDENT_SEMANA, OracleDbType.Int64, obj.PkDemPersonaIdentSemana, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_D_COD_DIA_SEMANA, OracleDbType.Int64, obj.DCodDiaSemana, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_1, OracleDbType.Decimal, obj.Hora1, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_2, OracleDbType.Decimal, obj.Hora2, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_3, OracleDbType.Decimal, obj.Hora3, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_4, OracleDbType.Decimal, obj.Hora4, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_5, OracleDbType.Decimal, obj.Hora5, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_6, OracleDbType.Decimal, obj.Hora6, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_7, OracleDbType.Decimal, obj.Hora7, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_8, OracleDbType.Double, obj.Hora8, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_9, OracleDbType.Decimal, obj.Hora9, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_10, OracleDbType.Double, obj.Hora10, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_11, OracleDbType.Double, obj.Hora11, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_12, OracleDbType.Double, obj.Hora12, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_13, OracleDbType.Double, obj.Hora13, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_14, OracleDbType.Double, obj.Hora14, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_15, OracleDbType.Double, obj.Hora15, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_16, OracleDbType.Double, obj.Hora16, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_17, OracleDbType.Double, obj.Hora17, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_18, OracleDbType.Double, obj.Hora18, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_19, OracleDbType.Double, obj.Hora19, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_20, OracleDbType.Double, obj.Hora20, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_21, OracleDbType.Double, obj.Hora21, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_22, OracleDbType.Double, obj.Hora22, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_23, OracleDbType.Double, obj.Hora23, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_24, OracleDbType.Double, obj.Hora24, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_FK_PERSONA, OracleDbType.Int64, obj.FkPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, obj.DCodCategoriaDato, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DemandaPersonaIdentidicacionSemana.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DemandaPersonaIdentidicacionSemana> GetLista()
        {
            BindingList<DemandaPersonaIdentidicacionSemana> resultado = new BindingList<DemandaPersonaIdentidicacionSemana>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DemandaPersonaIdentidicacionSemana(row));
            }
            return resultado;
        }

        public DataTable GetDatos(long pkPersona, long codTipoTabla)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2} AND {3} ={4} order by {5}";
            sql = string.Format(sql, DemandaPersonaIdentidicacionSemana.NOMBRE_TABLA, DemandaPersonaIdentidicacionSemana.C_FK_PERSONA, pkPersona, DemandaPersonaIdentidicacionSemana.C_D_COD_CATEGORIA_DATO, codTipoTabla, DemandaPersonaIdentidicacionSemana.C_PK_DEM_PERSONA_IDENT_SEMANA);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DEM_PERSONA_IDENT_SEM");
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

        public void GuardarTabla(DataTable tabla, long pkPersona, long codTipoTabla)
        {
             OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            sql  = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23},:{24},:{25},:{26},:{27},:{28},:{29})";

            sql = string.Format(sql, DemandaPersonaIdentidicacionSemana.NOMBRE_TABLA, DemandaPersonaIdentidicacionSemana.C_PK_DEM_PERSONA_IDENT_SEMANA,
            DemandaPersonaIdentidicacionSemana.C_D_COD_DIA_SEMANA,
            DemandaPersonaIdentidicacionSemana.C_HORA_1,
            DemandaPersonaIdentidicacionSemana.C_HORA_2,
            DemandaPersonaIdentidicacionSemana.C_HORA_3,
            DemandaPersonaIdentidicacionSemana.C_HORA_4,
            DemandaPersonaIdentidicacionSemana.C_HORA_5,
            DemandaPersonaIdentidicacionSemana.C_HORA_6,
            DemandaPersonaIdentidicacionSemana.C_HORA_7,
            DemandaPersonaIdentidicacionSemana.C_HORA_8,
            DemandaPersonaIdentidicacionSemana.C_HORA_9,
            DemandaPersonaIdentidicacionSemana.C_HORA_10,
            DemandaPersonaIdentidicacionSemana.C_HORA_11,
            DemandaPersonaIdentidicacionSemana.C_HORA_12,
            DemandaPersonaIdentidicacionSemana.C_HORA_13,
            DemandaPersonaIdentidicacionSemana.C_HORA_14,
            DemandaPersonaIdentidicacionSemana.C_HORA_15,
            DemandaPersonaIdentidicacionSemana.C_HORA_16,
            DemandaPersonaIdentidicacionSemana.C_HORA_17,
            DemandaPersonaIdentidicacionSemana.C_HORA_18,
            DemandaPersonaIdentidicacionSemana.C_HORA_19,
            DemandaPersonaIdentidicacionSemana.C_HORA_20,
            DemandaPersonaIdentidicacionSemana.C_HORA_21,
            DemandaPersonaIdentidicacionSemana.C_HORA_22,
            DemandaPersonaIdentidicacionSemana.C_HORA_23,
            DemandaPersonaIdentidicacionSemana.C_HORA_24,
            DemandaPersonaIdentidicacionSemana.C_FK_PERSONA,
            DemandaPersonaIdentidicacionSemana.C_SEC_LOG,
            DemandaPersonaIdentidicacionSemana.C_D_COD_CATEGORIA_DATO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_PK_DEM_PERSONA_IDENT_SEMANA, OracleDbType.Int64, GetArray(tabla, 0), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_D_COD_DIA_SEMANA, OracleDbType.Int64, GetArray(tabla, 1), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_1, OracleDbType.Decimal, GetArray(tabla,3), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_2, OracleDbType.Decimal, GetArray(tabla, 4), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_3, OracleDbType.Decimal, GetArray(tabla, 5), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_4, OracleDbType.Decimal, GetArray(tabla, 6), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_5, OracleDbType.Decimal, GetArray(tabla, 7), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_6, OracleDbType.Decimal, GetArray(tabla, 8), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_7, OracleDbType.Decimal, GetArray(tabla, 9), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_8, OracleDbType.Double, GetArray(tabla, 10), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_9, OracleDbType.Decimal, GetArray(tabla, 11), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_10, OracleDbType.Double, GetArray(tabla, 12), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_11, OracleDbType.Double, GetArray(tabla, 13), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_12, OracleDbType.Double, GetArray(tabla, 14), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_13, OracleDbType.Double, GetArray(tabla,15), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_14, OracleDbType.Double, GetArray(tabla, 16), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_15, OracleDbType.Double, GetArray(tabla, 17), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_16, OracleDbType.Double, GetArray(tabla, 18), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_17, OracleDbType.Double, GetArray(tabla, 19), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_18, OracleDbType.Double, GetArray(tabla, 20), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_19, OracleDbType.Double, GetArray(tabla, 21), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_20, OracleDbType.Double, GetArray(tabla, 22), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_21, OracleDbType.Double, GetArray(tabla, 23), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_22, OracleDbType.Double, GetArray(tabla, 24), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_23, OracleDbType.Double, GetArray(tabla, 25), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_HORA_24, OracleDbType.Double, GetArray(tabla, 26), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_FK_PERSONA, OracleDbType.Int64, GetArray(tabla, -1, pkPersona), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 35), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DemandaPersonaIdentidicacionSemana.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, GetArray(tabla, -1, codTipoTabla), System.Data.ParameterDirection.Input);
            Actualizar(cmd);
        }
    }
}
