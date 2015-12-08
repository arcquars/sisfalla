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
    public class OraDalGeneracionProbableEolicoSolarMgr : OraDalBaseMgr, IGeneracionProbableEolicoSolarMgr
    {
        #region Singleton
        private static OraDalGeneracionProbableEolicoSolarMgr _instancia;
        static OraDalGeneracionProbableEolicoSolarMgr()
        {
            _instancia = new OraDalGeneracionProbableEolicoSolarMgr();
        }
        public static OraDalGeneracionProbableEolicoSolarMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalGeneracionProbableEolicoSolarMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return GeneracionProbableEolicoSolar.NOMBRE_TABLA;
            }
        }

        public void Guardar(GeneracionProbableEolicoSolar generacionProbEolicoSolar)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (generacionProbEolicoSolar.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", generacionProbEolicoSolar.GetEstadoString());
                generacionProbEolicoSolar.SecLog = (long)p.PK_SecLog;
                generacionProbEolicoSolar.PkGenProbableEolicoSolar = GetIdAutoNum("SQ_F_PR_GEN_PROB_EOLICO_SOLAR");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";
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
                "{16}=:{16}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, GeneracionProbableEolicoSolar.NOMBRE_TABLA, GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR,
            GeneracionProbableEolicoSolar.C_FK_PROYECTO,
            GeneracionProbableEolicoSolar.C_ANIO,
            GeneracionProbableEolicoSolar.C_GENERACION_ENERO,
            GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO,
            GeneracionProbableEolicoSolar.C_GENERACION_MARZO,
            GeneracionProbableEolicoSolar.C_GENERACION_ABRIL,
            GeneracionProbableEolicoSolar.C_GENERACION_MAYO,
            GeneracionProbableEolicoSolar.C_GENERACION_JUNIO,
            GeneracionProbableEolicoSolar.C_GENERACION_JULIO,
            GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO,
            GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE,
            GeneracionProbableEolicoSolar.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR, OracleDbType.Int64, generacionProbEolicoSolar.PkGenProbableEolicoSolar, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_FK_PROYECTO, OracleDbType.Int64, generacionProbEolicoSolar.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_ANIO, OracleDbType.Int64, generacionProbEolicoSolar.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ENERO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionEnero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionFebrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MARZO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionMarzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ABRIL, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionAbril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MAYO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionMayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JUNIO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionJunio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JULIO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionJulio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionAgosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionSeptiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionOctubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionNoviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE, OracleDbType.Decimal, generacionProbEolicoSolar.GeneracionDiciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_SEC_LOG, OracleDbType.Int64, generacionProbEolicoSolar.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                generacionProbEolicoSolar.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(GeneracionProbableEolicoSolar.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<GeneracionProbableEolicoSolar> GetLista()
        {
            BindingList<GeneracionProbableEolicoSolar> resultado = new BindingList<GeneracionProbableEolicoSolar>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new GeneracionProbableEolicoSolar(row));
            }
            return resultado;
        }

        public List<GeneracionProbableEolicoSolar> GetListPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2}";
            sql = string.Format(sql,GeneracionProbableEolicoSolar.NOMBRE_TABLA, GeneracionProbableEolicoSolar.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            GeneracionProbableEolicoSolar item;
            List<GeneracionProbableEolicoSolar> lista = new List<GeneracionProbableEolicoSolar>();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    item = new GeneracionProbableEolicoSolar(row);
                    lista.Add(item);
                }
            }

            return lista;
        }

        public void EliminarRegistros(long pkProyecto)
        {
            string sql = "DELETE {0} WHERE {1}={2}";
            sql = string.Format(sql,GeneracionProbableEolicoSolar.NOMBRE_TABLA, GeneracionProbableEolicoSolar.C_FK_PROYECTO, pkProyecto);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public DataTable CrearGeneracionProbableEnergiaDesdeHasta(int anioDesde, int anioHasta, long pkProyecto, DataTable tablaSeries)
        {
            DataTable tabla = tablaSeries;
            for (int i = anioDesde; i <= anioHasta; i++)
            {
                DataRow row = tabla.NewRow();
                row[0] = GetIdAutoNum("SQ_F_PR_GEN_PROB_EOLICO_SOLAR");
                row[1] = i.ToString();
                row[2] = 0;
                row[3] = 0;
                row[4] = 0;
                row[5] = 0;
                row[6] = 0;
                row[7] = 0;
                row[8] = 0;
                row[9] = 0;
                row[10] = 0;
                row[11] = 0;
                row[12] = 0;
                row[13] = 0;
                tabla.Rows.Add(row);
            }

            OracleCommand cmd = null;
            string sql = "";
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";

            sql = string.Format(sql, GeneracionProbableEolicoSolar.NOMBRE_TABLA, GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR,
            GeneracionProbableEolicoSolar.C_FK_PROYECTO,
            GeneracionProbableEolicoSolar.C_ANIO,
            GeneracionProbableEolicoSolar.C_GENERACION_ENERO,
            GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO,
            GeneracionProbableEolicoSolar.C_GENERACION_MARZO,
            GeneracionProbableEolicoSolar.C_GENERACION_ABRIL,
            GeneracionProbableEolicoSolar.C_GENERACION_MAYO,
            GeneracionProbableEolicoSolar.C_GENERACION_JUNIO,
            GeneracionProbableEolicoSolar.C_GENERACION_JULIO,
            GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO,
            GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE,
            GeneracionProbableEolicoSolar.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_FK_PROYECTO, OracleDbType.Int64, GetArray(tabla, -1, pkProyecto), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_ANIO, OracleDbType.Varchar2, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ENERO, OracleDbType.Decimal, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO, OracleDbType.Decimal, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MARZO, OracleDbType.Decimal, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ABRIL, OracleDbType.Decimal, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MAYO, OracleDbType.Decimal, GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JUNIO, OracleDbType.Decimal, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JULIO, OracleDbType.Decimal, GetArray(tabla, 8), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO, OracleDbType.Decimal, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE, OracleDbType.Decimal, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE, OracleDbType.Decimal, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE, OracleDbType.Decimal, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE, OracleDbType.Decimal, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 14), ParameterDirection.Input);

            Actualizar(cmd);

            return tabla;
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

        public DataTable GetTablaGeneracionDePkProyecto(long pkProyecto, DataTable _tablaGen)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, GeneracionProbableEolicoSolar.NOMBRE_TABLA, GeneracionProbableEolicoSolar.C_FK_PROYECTO, pkProyecto, GeneracionProbableEolicoSolar.C_ANIO);
            DataTable tabla = EjecutarSql(sql);
            DataTable tablaSeries = _tablaGen;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow r in tabla.Rows)
                {
                    DataRow row = tablaSeries.NewRow();
                    row[0] = r["PK_GEN_PROBABLE_EOLICO_SOLAR"];
                    row[1] = r["ANIO"].ToString();
                    row[2] = r["GENERACION_ENERO"];
                    row[3] = r["GENERACION_FEBRERO"];
                    row[4] = r["GENERACION_MARZO"];
                    row[5] = r["GENERACION_ABRIL"];
                    row[6] = r["GENERACION_MAYO"];
                    row[7] = r["GENERACION_JUNIO"];
                    row[8] = r["GENERACION_JULIO"];
                    row[9] = r["GENERACION_AGOSTO"];
                    row[10] = r["GENERACION_SEPTIEMBRE"];
                    row[11] = r["GENERACION_OCTUBRE"];
                    row[12] = r["GENERACION_NOVIEMBRE"];
                    row[13] = r["GENERACION_DICIEMBRE"];
                    tablaSeries.Rows.Add(row);
                }
            }
            return tablaSeries;
        }

        public DataTable GuardarTabla(DataTable tabla, long pkProyecto)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";

            sql = string.Format(sql, GeneracionProbableEolicoSolar.NOMBRE_TABLA,
            GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR,
            GeneracionProbableEolicoSolar.C_FK_PROYECTO,
            GeneracionProbableEolicoSolar.C_ANIO,
            GeneracionProbableEolicoSolar.C_GENERACION_ENERO,
            GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO,
            GeneracionProbableEolicoSolar.C_GENERACION_MARZO,
            GeneracionProbableEolicoSolar.C_GENERACION_ABRIL,
            GeneracionProbableEolicoSolar.C_GENERACION_MAYO,
            GeneracionProbableEolicoSolar.C_GENERACION_JUNIO,
            GeneracionProbableEolicoSolar.C_GENERACION_JULIO,
            GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO,
            GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE,
            GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE,
            GeneracionProbableEolicoSolar.C_SEC_LOG);

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_FK_PROYECTO, OracleDbType.Int64, GetArray(tabla, -1, pkProyecto), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_ANIO, OracleDbType.Int64, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ENERO, OracleDbType.Decimal, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_FEBRERO, OracleDbType.Decimal, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MARZO, OracleDbType.Decimal, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_ABRIL, OracleDbType.Decimal, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_MAYO, OracleDbType.Decimal, GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JUNIO, OracleDbType.Decimal, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_JULIO, OracleDbType.Decimal, GetArray(tabla, 8), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_AGOSTO, OracleDbType.Decimal, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_SEPTIEMBRE, OracleDbType.Decimal, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_OCTUBRE, OracleDbType.Decimal, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_NOVIEMBRE, OracleDbType.Decimal, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_GENERACION_DICIEMBRE, OracleDbType.Decimal, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(GeneracionProbableEolicoSolar.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 15), ParameterDirection.Input);
            Actualizar(cmd);
            return tabla;
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_PR_SERIE_HIDROLOGICA");
            }
        }

        public void EliminarSerie(long pkProyecto)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, NombreTabla, GeneracionProbableEolicoSolar.C_FK_PROYECTO, pkProyecto);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarSeriePorPkSerie(long pkProyecto, long pkSerie)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} and {3}={4}";
            sql = string.Format(sql, NombreTabla, GeneracionProbableEolicoSolar.C_FK_PROYECTO, pkProyecto, GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR, pkSerie);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
