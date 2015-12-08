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
    public class OraDalNodosRealesMgr : OraDalBaseMgr, INodosRealesMgr
    {
        #region Singleton
        private static OraDalNodosRealesMgr _instancia;
        static OraDalNodosRealesMgr()
        {
            _instancia = new OraDalNodosRealesMgr();
        }
        public static OraDalNodosRealesMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalNodosRealesMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return NodosReales.NOMBRE_TABLA;
            }
        }
        public void Guardar(NodosReales obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11})";
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
                "{11}=:{11}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, NodosReales.NOMBRE_TABLA, NodosReales.C_PK_COD_NODO,
            NodosReales.C_PK_NIVEL_TENSION,
            NodosReales.C_D_COD_AREA,
            NodosReales.C_SIGLA_NODO,
            NodosReales.C_NOMBRE_NODO,
            NodosReales.C_DESCRIPCION_NODO,
            NodosReales.C_D_COD_ESTADO,
            NodosReales.C_SEC_LOG,
            NodosReales.C_SINC_VER,
            NodosReales.C_FECHA_INGRESO,
            NodosReales.C_FECHA_SALIDA);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(NodosReales.C_PK_COD_NODO, OracleDbType.Int64, obj.PkCodNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_PK_NIVEL_TENSION, OracleDbType.Single, obj.PkNivelTension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_D_COD_AREA, OracleDbType.Int64, obj.DCodArea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_SIGLA_NODO, OracleDbType.Varchar2, obj.SiglaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_NOMBRE_NODO, OracleDbType.Varchar2, obj.NombreNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_DESCRIPCION_NODO, OracleDbType.Varchar2, obj.DescripcionNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_SEC_LOG, OracleDbType.Decimal, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_FECHA_INGRESO, OracleDbType.Date, obj.FechaIngreso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodosReales.C_FECHA_SALIDA, OracleDbType.Date, obj.FechaSalida, System.Data.ParameterDirection.Input);


        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(NodosReales.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<NodosReales> GetLista()
        {
            BindingList<NodosReales> resultado = new BindingList<NodosReales>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new NodosReales(row));
            }
            return resultado;
        }

        public DataTable GetNodosReales(string sigla)
        {
            string sql;
            if (sigla.Trim() == string.Empty)
            {
                sql = "select n.pk_cod_nodo, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo from f_ac_nodo n order by n.nombre_nodo";
            }
            else
            {
                sql = "select n.pk_cod_nodo, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo from f_ac_nodo n Where upper(n.sigla_nodo) like '%{0}%' order by n.nombre_nodo";
                sql = string.Format(sql, sigla.Trim().ToUpper());
            }
            
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public List<NodosReales> GetNodosReales(long pkPersona)
        {
            List<NodosReales> lista = new List<NodosReales>();
            string sql = @"select n.* from F_DM_R_PERSONA_NODO np, f_ac_nodo n
                           where np.pk_persona_nodo_padre = 0 and np.fk_nodo_real =n.pk_cod_nodo and np.fk_persona={0}";
            sql = string.Format(sql, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            NodosReales nodo = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodosReales(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }
    }
}
