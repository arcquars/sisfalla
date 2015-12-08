using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace ModeloProyectos
{
    public class OraDalTipoProyectoControlesMgr : OraDalBaseMgr, ITipoProyectoControlesMgr
    {
        #region Singleton
        private static OraDalTipoProyectoControlesMgr _instancia;
        static OraDalTipoProyectoControlesMgr()
        {
            _instancia = new OraDalTipoProyectoControlesMgr();
        }
        public static OraDalTipoProyectoControlesMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalTipoProyectoControlesMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return TipoProyectoControles.NOMBRE_TABLA;
            }
        }

        public void Guardar(TipoProyectoControles obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
               // Pista p = PistaMgr.Instance.Info("DALProyectos", obj.GetEstadoString());
               // obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({2},{3},{4})" +
                "VALUES(:{2},:{3},:{4})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, TipoProyectoControles.NOMBRE_TABLA, TipoProyectoControles.C_PK_TIPO_PROY_CONTROLES,
            TipoProyectoControles.C_D_COD_TIPO_PROYECTO,
            TipoProyectoControles.C_NOMBRE_CONTROL,
            TipoProyectoControles.C_ORDEN);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            if (!obj.EsNuevo)
            {
                cmd.Parameters.Add(TipoProyectoControles.C_PK_TIPO_PROY_CONTROLES, OracleDbType.Int64, obj.PkTipoProyControles, System.Data.ParameterDirection.Input);
            }
            cmd.Parameters.Add(TipoProyectoControles.C_D_COD_TIPO_PROYECTO, OracleDbType.Int64, obj.DCodTipoProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TipoProyectoControles.C_NOMBRE_CONTROL, OracleDbType.Varchar2, obj.NombreControl, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TipoProyectoControles.C_ORDEN, OracleDbType.Int16, obj.Orden, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(TipoProyectoControles.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<TipoProyectoControles> GetLista()
        {
            BindingList<TipoProyectoControles> resultado = new BindingList<TipoProyectoControles>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new TipoProyectoControles(row));
            }
            return resultado;
        }

        public List<string> GetPorIdTipoProyecto(long codTipoProyecto)
        {
            string sql = "SELECT * FROM {0} where {1}={2}";
            sql = string.Format(sql, TipoProyectoControles.NOMBRE_TABLA, TipoProyectoControles.C_D_COD_TIPO_PROYECTO, codTipoProyecto);
            DataTable tabla = EjecutarSql(sql);
            List<string> listaControles = new List<string>();
            string nombreCtrl = string.Empty;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nombreCtrl= row[2].ToString();
                    listaControles.Add(nombreCtrl);
                }
            }
            return listaControles;
        }
    }
}
