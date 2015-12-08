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
    public class OraDalVolumenVsFactorDeProduccionMgr : OraDalBaseMgr, IVolumenVsFactorDeProduccionMgr
    {
        #region Singleton
        private static OraDalVolumenVsFactorDeProduccionMgr _instancia;
        static OraDalVolumenVsFactorDeProduccionMgr()
        {
            _instancia = new OraDalVolumenVsFactorDeProduccionMgr();
        }
        public static OraDalVolumenVsFactorDeProduccionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalVolumenVsFactorDeProduccionMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return VolumenVsFactorDeProduccion.NOMBRE_TABLA;
            }
        }

        public void Guardar(VolumenVsFactorDeProduccion volVsFactorProduccion)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (volVsFactorProduccion.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", volVsFactorProduccion.GetEstadoString());
                volVsFactorProduccion.SecLog = (long)p.PK_SecLog;
                volVsFactorProduccion.PkVolVsFactProduccion = GetIdAutoNum("SQ_F_PR_VOL_VS_FACT_PRODUCCION");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, VolumenVsFactorDeProduccion.NOMBRE_TABLA, VolumenVsFactorDeProduccion.C_PK_VOL_VS_FACT_PRODUCCION,
            VolumenVsFactorDeProduccion.C_FK_DATO_TEC_HIDROELECTRICO,
            VolumenVsFactorDeProduccion.C_VOLUMEN,
            VolumenVsFactorDeProduccion.C_FACTOR_PRODUCTIVIDAD,
            VolumenVsFactorDeProduccion.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(VolumenVsFactorDeProduccion.C_PK_VOL_VS_FACT_PRODUCCION, OracleDbType.Int64, volVsFactorProduccion.PkVolVsFactProduccion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsFactorDeProduccion.C_FK_DATO_TEC_HIDROELECTRICO, OracleDbType.Int64, volVsFactorProduccion.FkDatoTecHidroelectrico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsFactorDeProduccion.C_VOLUMEN, OracleDbType.Double, volVsFactorProduccion.Volumen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsFactorDeProduccion.C_FACTOR_PRODUCTIVIDAD, OracleDbType.Double, volVsFactorProduccion.FactorProductividad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsFactorDeProduccion.C_SEC_LOG, OracleDbType.Int64, volVsFactorProduccion.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                volVsFactorProduccion.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(VolumenVsFactorDeProduccion.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<VolumenVsFactorDeProduccion> GetLista()
        {
            BindingList<VolumenVsFactorDeProduccion> resultado = new BindingList<VolumenVsFactorDeProduccion>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new VolumenVsFactorDeProduccion(row));
            }
            return resultado;
        }

        public List<VolumenVsFactorDeProduccion> GetListPorPkDatoTecnico(long pkDatoTecnico)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql,VolumenVsFactorDeProduccion.NOMBRE_TABLA, VolumenVsFactorDeProduccion.C_FK_DATO_TEC_HIDROELECTRICO, pkDatoTecnico, VolumenVsFactorDeProduccion.C_VOLUMEN);
            DataTable tabla = EjecutarSql(sql);
            List<VolumenVsFactorDeProduccion> resultado = new List<VolumenVsFactorDeProduccion>();
            VolumenVsFactorDeProduccion vol;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    vol = new VolumenVsFactorDeProduccion(row);
                    resultado.Add(vol);
                }
            }

            return resultado;
        }

        public void EliminarRegistros(long pkDatoTecnico)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql,VolumenVsFactorDeProduccion.NOMBRE_TABLA, VolumenVsFactorDeProduccion.C_FK_DATO_TEC_HIDROELECTRICO, pkDatoTecnico);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
