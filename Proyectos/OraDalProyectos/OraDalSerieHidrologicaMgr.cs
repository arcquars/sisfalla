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
    public class OraDalSerieHidrologicaMgr : OraDalBaseMgr, ISerieHidrologicaMgr
    {
        #region Singleton
        private static OraDalSerieHidrologicaMgr _instancia;
        static OraDalSerieHidrologicaMgr()
        {
            _instancia = new OraDalSerieHidrologicaMgr();
        }
        public static OraDalSerieHidrologicaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalSerieHidrologicaMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return SerieHidrologica.NOMBRE_TABLA;
            }
        }
        public void Guardar(SerieHidrologica serieHidrologica)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (serieHidrologica.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", serieHidrologica.GetEstadoString());
                serieHidrologica.SecLog = (long)p.PK_SecLog;
                serieHidrologica.PkSerieHidrologica = GetIdAutoNum("SQ_F_PR_SERIE_HIDROLOGICA");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";
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
                "{17}=:{17}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, SerieHidrologica.NOMBRE_TABLA, SerieHidrologica.C_PK_SERIE_HIDROLOGICA,
            SerieHidrologica.C_FK_PROYECTO,
            SerieHidrologica.C_ANIO,
            SerieHidrologica.C_CAPACIDAD_ENERO,
            SerieHidrologica.C_CAPACIDAD_FEBRERO,
            SerieHidrologica.C_CAPACIDAD_MARZO,
            SerieHidrologica.C_CAPACIDAD_ABRIL,
            SerieHidrologica.C_CAPACIDAD_MAYO,
            SerieHidrologica.C_CAPACIDAD_JUNIO,
            SerieHidrologica.C_CAPACIDAD_JULIO,
            SerieHidrologica.C_CAPACIDAD_AGOSTO,
            SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE,
            SerieHidrologica.C_CAPACIDAD_OCTUBRE,
            SerieHidrologica.C_CAPACIDAD_NOVIEMBRE,
            SerieHidrologica.C_CAPACIDAD_DICIEMBRE,
            SerieHidrologica.C_FECHA_REGISTRO,
            SerieHidrologica.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(SerieHidrologica.C_PK_SERIE_HIDROLOGICA, OracleDbType.Int64, serieHidrologica.PkSerieHidrologica, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FK_PROYECTO, OracleDbType.Int64, serieHidrologica.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_ANIO, OracleDbType.Varchar2, serieHidrologica.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ENERO, OracleDbType.Decimal, serieHidrologica.CapacidadEnero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_FEBRERO, OracleDbType.Decimal, serieHidrologica.CapacidadFebrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MARZO, OracleDbType.Decimal, serieHidrologica.CapacidadMarzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ABRIL, OracleDbType.Decimal, serieHidrologica.CapacidadAbril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MAYO, OracleDbType.Decimal, serieHidrologica.CapacidadMayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JUNIO, OracleDbType.Decimal, serieHidrologica.CapacidadJunio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JULIO, OracleDbType.Decimal, serieHidrologica.CapacidadJulio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_AGOSTO, OracleDbType.Decimal, serieHidrologica.CapacidadAgosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE, OracleDbType.Decimal, serieHidrologica.CapacidadSeptiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_OCTUBRE, OracleDbType.Decimal, serieHidrologica.CapacidadOctubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_NOVIEMBRE, OracleDbType.Decimal, serieHidrologica.CapacidadNoviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_DICIEMBRE, OracleDbType.Decimal, serieHidrologica.CapacidadDiciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FECHA_REGISTRO, OracleDbType.Date, serieHidrologica.FechaRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_SEC_LOG, OracleDbType.Int64, serieHidrologica.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                serieHidrologica.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(SerieHidrologica.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<SerieHidrologica> GetLista()
        {
            BindingList<SerieHidrologica> resultado = new BindingList<SerieHidrologica>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new SerieHidrologica(row));
            }
            return resultado;
        }

        public List<SerieHidrologica> GetSeriesDePkProyecto(long pkProyecto)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2}";
            sql = string.Format(sql,SerieHidrologica.NOMBRE_TABLA, SerieHidrologica.C_FK_PROYECTO, pkProyecto);
            List<SerieHidrologica> lista = new List<SerieHidrologica>();
            DataTable tabla = EjecutarSql(sql);
            SerieHidrologica serie;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    serie = new SerieHidrologica(row);
                    lista.Add(serie);
                }
            }
            return lista;
        }

        public void SetTablaSeriesDePkProyecto(long pkProyecto, DataTable tablaSeries)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, SerieHidrologica.NOMBRE_TABLA, SerieHidrologica.C_FK_PROYECTO, pkProyecto, SerieHidrologica.C_ANIO);
            DataTable tabla = EjecutarSql(sql);
            tablaSeries.Rows.Clear();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow r in tabla.Rows)
                {
                    DataRow row = tablaSeries.NewRow();
                    row[0] = r["PK_SERIE_HIDROLOGICA"];
                    row[1] = r["ANIO"];
                    row[2] = r["CAPACIDAD_ENERO"];
                    row[3] = r["CAPACIDAD_FEBRERO"];
                    row[4] = r["CAPACIDAD_MARZO"];
                    row[5] = r["CAPACIDAD_ABRIL"];
                    row[6] = r["CAPACIDAD_MAYO"];
                    row[7] = r["CAPACIDAD_JUNIO"];
                    row[8] = r["CAPACIDAD_JULIO"];
                    row[9] = r["CAPACIDAD_AGOSTO"];
                    row[10] = r["CAPACIDAD_SEPTIEMBRE"];
                    row[11] = r["CAPACIDAD_OCTUBRE"];
                    row[12] = r["CAPACIDAD_NOVIEMBRE"];
                    row[13] = r["CAPACIDAD_DICIEMBRE"];
                    tablaSeries.Rows.Add(row);
                }
            }
        }

        public DataTable CrearSeriesHidrologicas(long pkProyecto,DataTable tablaSeries)
        {
            for (int i = 1979; i <= DateTime.Now.Year; i++ )
            {
                SerieHidrologica serie = new SerieHidrologica();
                serie.EsNuevo = true;
                serie.FechaRegistro = DateTime.Now;
                serie.FkProyecto = pkProyecto;
                serie.Anio = i.ToString();
                serie.CapacidadAbril = 0;
                serie.CapacidadAgosto = 0;
                serie.CapacidadDiciembre = 0;
                serie.CapacidadEnero = 0;
                serie.CapacidadFebrero = 0;
                serie.CapacidadJulio = 0;
                serie.CapacidadJunio = 0;
                serie.CapacidadMarzo = 0;
                serie.CapacidadMayo = 0;
                serie.CapacidadNoviembre = 0;
                serie.CapacidadOctubre = 0;
                serie.CapacidadSeptiembre = 0;
                Guardar(serie);
            }
            DataTable tabla = tablaSeries;
            List<SerieHidrologica> listaSeries = GetSeriesDePkProyecto(pkProyecto);
            foreach (SerieHidrologica serie in listaSeries)
            {
                DataRow row = tabla.NewRow();
                row["PK_SERIE_HIDROLOGICA"] = serie.PkSerieHidrologica;
                row["Año"] = serie.Anio;
                row["Enero"] = serie.CapacidadEnero;
                row["Febrero"] = serie.CapacidadFebrero;
                row["Marzo"] = serie.CapacidadMarzo;
                row["Abril"] = serie.CapacidadAbril;
                row["Mayo"] = serie.CapacidadMayo;
                row["Junio"] = serie.CapacidadJunio;
                row["Julio"] = serie.CapacidadJulio;
                row["Agosto"] = serie.CapacidadAgosto;
                row["Septiembre"] = serie.CapacidadSeptiembre;
                row["Octubre"] = serie.CapacidadOctubre;
                row["Noviembre"] = serie.CapacidadNoviembre;
                row["Diciembre"] = serie.CapacidadDiciembre;
                tabla.Rows.Add(row);
            }

            return tabla;
        }
        public DataTable CrearSeriesHidrologicasDesdeHasta(int anioDesde, int anioHasta, long pkProyecto, DataTable tablaSeries)
        {
            DataTable tabla = tablaSeries;
            for (int i = anioDesde; i <= anioHasta; i++)
            {
                DataRow row = tabla.NewRow();
                row[0] = GetIdAutoNum("SQ_F_PR_SERIE_HIDROLOGICA");
                row[1] = i;
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
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";
            
            sql = string.Format(sql, SerieHidrologica.NOMBRE_TABLA, 
            SerieHidrologica.C_PK_SERIE_HIDROLOGICA,
            SerieHidrologica.C_FK_PROYECTO,
            SerieHidrologica.C_ANIO,
            SerieHidrologica.C_CAPACIDAD_ENERO,
            SerieHidrologica.C_CAPACIDAD_FEBRERO,
            SerieHidrologica.C_CAPACIDAD_MARZO,
            SerieHidrologica.C_CAPACIDAD_ABRIL,
            SerieHidrologica.C_CAPACIDAD_MAYO,
            SerieHidrologica.C_CAPACIDAD_JUNIO,
            SerieHidrologica.C_CAPACIDAD_JULIO,
            SerieHidrologica.C_CAPACIDAD_AGOSTO,
            SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE,
            SerieHidrologica.C_CAPACIDAD_OCTUBRE,
            SerieHidrologica.C_CAPACIDAD_NOVIEMBRE,
            SerieHidrologica.C_CAPACIDAD_DICIEMBRE,
            SerieHidrologica.C_FECHA_REGISTRO,
            SerieHidrologica.C_SEC_LOG);
            
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(SerieHidrologica.C_PK_SERIE_HIDROLOGICA, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FK_PROYECTO, OracleDbType.Int64, GetArray(tabla, -1, pkProyecto), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_ANIO, OracleDbType.Int64, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ENERO, OracleDbType.Decimal, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_FEBRERO, OracleDbType.Decimal, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MARZO, OracleDbType.Decimal, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ABRIL, OracleDbType.Decimal, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MAYO, OracleDbType.Decimal, GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JUNIO, OracleDbType.Decimal, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JULIO, OracleDbType.Decimal, GetArray(tabla, 8), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_AGOSTO, OracleDbType.Decimal, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE, OracleDbType.Decimal, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_OCTUBRE, OracleDbType.Decimal, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_NOVIEMBRE, OracleDbType.Decimal, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_DICIEMBRE, OracleDbType.Decimal, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FECHA_REGISTRO, OracleDbType.Date, GetArray(tabla, 14), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 15), ParameterDirection.Input);

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



        public DataTable  GuardarTabla(DataTable tabla, long pkProyecto)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";

            sql = string.Format(sql, SerieHidrologica.NOMBRE_TABLA,
            SerieHidrologica.C_PK_SERIE_HIDROLOGICA,
            SerieHidrologica.C_FK_PROYECTO,
            SerieHidrologica.C_ANIO,
            SerieHidrologica.C_CAPACIDAD_ENERO,
            SerieHidrologica.C_CAPACIDAD_FEBRERO,
            SerieHidrologica.C_CAPACIDAD_MARZO,
            SerieHidrologica.C_CAPACIDAD_ABRIL,
            SerieHidrologica.C_CAPACIDAD_MAYO,
            SerieHidrologica.C_CAPACIDAD_JUNIO,
            SerieHidrologica.C_CAPACIDAD_JULIO,
            SerieHidrologica.C_CAPACIDAD_AGOSTO,
            SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE,
            SerieHidrologica.C_CAPACIDAD_OCTUBRE,
            SerieHidrologica.C_CAPACIDAD_NOVIEMBRE,
            SerieHidrologica.C_CAPACIDAD_DICIEMBRE,
            SerieHidrologica.C_FECHA_REGISTRO,
            SerieHidrologica.C_SEC_LOG);

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(SerieHidrologica.C_PK_SERIE_HIDROLOGICA, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FK_PROYECTO, OracleDbType.Int64, GetArray(tabla, -1, pkProyecto), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_ANIO, OracleDbType.Int64, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ENERO, OracleDbType.Decimal, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_FEBRERO, OracleDbType.Decimal, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MARZO, OracleDbType.Decimal, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_ABRIL, OracleDbType.Decimal, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_MAYO, OracleDbType.Decimal, GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JUNIO, OracleDbType.Decimal, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_JULIO, OracleDbType.Decimal, GetArray(tabla, 8), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_AGOSTO, OracleDbType.Decimal, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_SEPTIEMBRE, OracleDbType.Decimal, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_OCTUBRE, OracleDbType.Decimal, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_NOVIEMBRE, OracleDbType.Decimal, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_CAPACIDAD_DICIEMBRE, OracleDbType.Decimal, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_FECHA_REGISTRO, OracleDbType.Date, GetArray(tabla, 14), ParameterDirection.Input);
            cmd.Parameters.Add(SerieHidrologica.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 15), ParameterDirection.Input);

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
            sql = string.Format(sql, NombreTabla, SerieHidrologica.C_FK_PROYECTO, pkProyecto);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarSeriePorPkSerie(long pkProyecto, long pkSerie)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} and {3}={4}";
            sql = string.Format(sql, NombreTabla, SerieHidrologica.C_FK_PROYECTO, pkProyecto,SerieHidrologica.C_PK_SERIE_HIDROLOGICA,pkSerie);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
