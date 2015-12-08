using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalVolumenVsAreaMgr : OraDalBaseMgr, IVolumenVsAreaMgr
    {
        #region Singleton
        private static OraDalVolumenVsAreaMgr _instancia;
        static OraDalVolumenVsAreaMgr()
        {
            _instancia = new OraDalVolumenVsAreaMgr();
        }
        public static OraDalVolumenVsAreaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalVolumenVsAreaMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return VolumenVsArea.NOMBRE_TABLA;
            }
        }

        public void Guardar(VolumenVsArea volumenVsArea)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (volumenVsArea.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", volumenVsArea.GetEstadoString());
                volumenVsArea.SecLog = (long)p.PK_SecLog;
                volumenVsArea.PkVolumenVsArea = GetIdAutoNum("SQ_F_PR_VOLUMEN_VS_AREA");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, VolumenVsArea.NOMBRE_TABLA, VolumenVsArea.C_PK_VOLUMEN_VS_AREA,
            VolumenVsArea.C_FK_DATO_TEC_HIDROELECTRICO,
            VolumenVsArea.C_VOLUMEN,
            VolumenVsArea.C_AREA,
            VolumenVsArea.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(VolumenVsArea.C_PK_VOLUMEN_VS_AREA, OracleDbType.Int64, volumenVsArea.PkVolumenVsArea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsArea.C_FK_DATO_TEC_HIDROELECTRICO, OracleDbType.Int64, volumenVsArea.FkDatoTecHidroelectrico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsArea.C_VOLUMEN, OracleDbType.Double, volumenVsArea.Volumen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsArea.C_AREA, OracleDbType.Double, volumenVsArea.Area, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(VolumenVsArea.C_SEC_LOG, OracleDbType.Int64, volumenVsArea.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                volumenVsArea.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(VolumenVsArea.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<VolumenVsArea> GetLista()
        {
            BindingList<VolumenVsArea> resultado = new BindingList<VolumenVsArea>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new VolumenVsArea(row));
            }
            return resultado;
        }

        public List<VolumenVsArea> GetListPorPkDatoTecnico(long pkDatoTecnico)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} order by {3}";
            sql = string.Format(sql, VolumenVsArea.NOMBRE_TABLA, VolumenVsArea.C_FK_DATO_TEC_HIDROELECTRICO, pkDatoTecnico, VolumenVsArea.C_VOLUMEN);
            DataTable tabla = EjecutarSql(sql);
            List<VolumenVsArea> resultado = new List<VolumenVsArea>();
            VolumenVsArea vol;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    vol = new VolumenVsArea(row);
                    resultado.Add(vol);
                }
            }

            return resultado;
        }

        public void EliminarRegistros(long pkDatoTecnico)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, VolumenVsArea.NOMBRE_TABLA, VolumenVsArea.C_FK_DATO_TEC_HIDROELECTRICO, pkDatoTecnico);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res=Actualizar(cmd);
        }
    }
}
