using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.BLL;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalCronogramaDeInversionMgr : OraDalBaseMgr, ICronogramaDeInversionMgr
    {
        #region Singleton
        private static OraDalCronogramaDeInversionMgr _instancia;
        static OraDalCronogramaDeInversionMgr()
        {
            _instancia = new OraDalCronogramaDeInversionMgr();
        }
        public static OraDalCronogramaDeInversionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalCronogramaDeInversionMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return CronogramaDeInversion.NOMBRE_TABLA;
            }
        }

        public void Guardar(CronogramaDeInversion cronogramaInv)
        {
//            if (!cronogramaInv.EsNuevo)
//            {
//                string sql =
//                @"UPDATE F_PR_CRONOGRAMA_INVERSION 
//                SET historico=1
//                WHERE PK_CRONOGRAMA_INVERSION=" + cronogramaInv.PkCronogramaInversion;
//                OracleCommand cmd = CrearCommand();
//                cmd.CommandText = sql;
//                Actualizar(cmd);
//                cronogramaInv.EsNuevo = true;
//            }

            GuardarPrivado(cronogramaInv);
        }
        private void GuardarPrivado(CronogramaDeInversion cronogramaInv)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (cronogramaInv.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", cronogramaInv.GetEstadoString());
                cronogramaInv.SecLog = (long)p.PK_SecLog;
                cronogramaInv.PkCronogramaInversion = GetIdAutoNum("SQ_F_PR_CRONOGRAMA_INVERSION");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA,
            CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION,
            CronogramaDeInversion.C_FK_DATO_ECONOMICO,
            CronogramaDeInversion.C_ANIO,
            CronogramaDeInversion.C_MONTO,
            CronogramaDeInversion.C_SEC_LOG,
            CronogramaDeInversion.C_ANIO_REF,
            CronogramaDeInversion.C_HISTORICO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION, OracleDbType.Int64, cronogramaInv.PkCronogramaInversion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_FK_DATO_ECONOMICO, OracleDbType.Int64, cronogramaInv.FkDatoEconomico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_ANIO, OracleDbType.Varchar2, cronogramaInv.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_MONTO, OracleDbType.Double, cronogramaInv.Monto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_SEC_LOG, OracleDbType.Int64, cronogramaInv.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_ANIO_REF, OracleDbType.Int64, cronogramaInv.AnioRef, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(CronogramaDeInversion.C_HISTORICO, OracleDbType.Int16, cronogramaInv.Historico, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                cronogramaInv.EsNuevo = false;
            }

        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(CronogramaDeInversion.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<CronogramaDeInversion> GetLista()
        {
            BindingList<CronogramaDeInversion> resultado = new BindingList<CronogramaDeInversion>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new CronogramaDeInversion(row));
            }
            return resultado;
        }

        public List<CronogramaDeInversion> GetListPorPkDatoEconomico(long pkDatoEconomico)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} AND historico=0 order by {3}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, 
                CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico, CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION);
            DataTable tabla = EjecutarSql(sql);
            List<CronogramaDeInversion> resultado = new List<CronogramaDeInversion>();
            CronogramaDeInversion vol;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    vol = new CronogramaDeInversion(row);
                    resultado.Add(vol);
                }
            }

            return resultado;
        }

        public void CambiarEstadoAHistorico(long pkDatoEconomico, long anioAntiguo)
        {
            string sql = "UPDATE {0} SET historico=1 WHERE {1}={2} AND anio_ref={3}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico, anioAntiguo);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public DataTable GetHistorico(long pkDataEconomico)
        {
            DataTable resultado = new DataTable();
            string sql = @"SELECT * FROM F_PR_CRONOGRAMA_INVERSION 
            WHERE FK_DATO_ECONOMICO={0} 
            ORDER BY PK_CRONOGRAMA_INVERSION";
            sql = string.Format(sql, pkDataEconomico);
            DataTable tablaCronograma = EjecutarSql(sql);
            List<long> anios = GetAnios(tablaCronograma);
            anios.Sort();

            DataColumn autoNum = new DataColumn("Año",typeof(string));
            resultado.Columns.Add(autoNum);
            int contAnio = 1;
            foreach (long a in anios)
            {
                DataColumn col = new DataColumn(a.ToString(), typeof(decimal));
                resultado.Columns.Add(col);
            }

            foreach (long a in anios)
            {
                List<DataRow> rows = GetRowsPorAnio(tablaCronograma, a);
                while (resultado.Rows.Count < rows.Count)
                {
                    DataRow row = resultado.NewRow();
                    row["Año"] = contAnio.ToString();
                    contAnio++;
                    resultado.Rows.Add(row);
                }

                int idx = 0;
                foreach (DataRow r in rows)
                {
                    resultado.Rows[idx][a.ToString()] = r["MONTO"];
                    idx++;
                }
            }

            return resultado;
        }

        private List<DataRow> GetRowsPorAnio(DataTable tablaCronograma, long a)
        {
            List<DataRow> resultado = new List<DataRow>();
            foreach (DataRow r in tablaCronograma.Rows)
            {
                if (a == (long)r["ANIO_REF"])
                {
                    resultado.Add(r);
                }
            }
            return resultado;
        }

        private List<long> GetAnios(DataTable tablaCronograma)
        {
            List<long> resultado = new List<long>();
            foreach (DataRow r in tablaCronograma.Rows)
            {
                long a = (long)r["ANIO_REF"];
                if (!resultado.Contains(a))
                {
                    resultado.Add(a);
                }
            }
            return resultado;
        }

        public bool ExisteCronogramaConAnioRef(string anio, long pkDatoEconomico)
        {
            bool res = false;
            string sql = "SELECT * FROM {0} WHERE {1}='{2}' AND {3}={4}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, CronogramaDeInversion.C_ANIO_REF,anio, CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }

        public void EliminarCronogramaInv(string anio, long pkDatoEconomico)
        {
            string sql = "DELETE FROM {0} WHERE {1}='{2}' AND {3}={4}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, CronogramaDeInversion.C_ANIO_REF, anio, CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void CambiarRegistrosAEstadoAHistorico(long pkDatoEconomico)
        {
            string sql = "UPDATE {0} SET historico=1 WHERE {1}={2} ";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarRegistro(long pkCronograma)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA, CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION,pkCronograma);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public List<CronogramaDeInversion> GetTodoElCronogramaPorPkDatoEconomico(long pkDatoEconomico)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, CronogramaDeInversion.NOMBRE_TABLA,
                CronogramaDeInversion.C_FK_DATO_ECONOMICO, pkDatoEconomico, CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION);
            DataTable tabla = EjecutarSql(sql);
            List<CronogramaDeInversion> resultado = new List<CronogramaDeInversion>();
            CronogramaDeInversion vol;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    vol = new CronogramaDeInversion(row);
                    resultado.Add(vol);
                }
            }

            return resultado;
        }

        public List<long> GetAniosRefHistorico(long pkDatoEconomico)
        {
            List<long> resultado = new List<long>();
            string sql = @"SELECT DISTINCT anio_ref FROM f_pr_cronograma_inversion 
            WHERE fk_dato_economico=:fk_dato_economico
            AND historico=1";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fk_dato_economico", OracleDbType.Int64, pkDatoEconomico, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r["anio_ref"]);
            }
            return resultado;
        }

        public void EliminarHistorico(long pkDatoEconomico, List<long> seleccionados)
        {
            string sql = @"DELETE f_pr_cronograma_inversion 
            WHERE fk_dato_economico=:fk_dato_economico
            AND anio_ref IN(" + GetSeparadosPorComa(seleccionados) + ")";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fk_dato_economico", OracleDbType.Int64, pkDatoEconomico, ParameterDirection.Input);
            Actualizar(cmd);
        }

        private string GetSeparadosPorComa(List<long> seleccionados)
        {
            string resultado = string.Empty;
            foreach (long dato in seleccionados)
            {
                if (!string.IsNullOrEmpty(resultado))
                {
                    resultado += ",";
                }
                resultado += dato;
            }
            return resultado;
        }
    }
}
