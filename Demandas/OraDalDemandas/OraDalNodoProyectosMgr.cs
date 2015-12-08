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
    public class OraDalNodoProyectosMgr : OraDalBaseMgr, INodoProyectosMgr
    {
        #region Singleton
        private static OraDalNodoProyectosMgr _instancia;
        static OraDalNodoProyectosMgr()
        {
            _instancia = new OraDalNodoProyectosMgr();
        }
        public static OraDalNodoProyectosMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalNodoProyectosMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return NodoProyectos.NOMBRE_TABLA;
            }
        }

        public void Guardar(NodoProyectos obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkNodoProyectos = GetIdAutoNum("SQ_F_DM_NODO_PROYECTOS");
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
                "{11}=:{11}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, NodoProyectos.NOMBRE_TABLA, NodoProyectos.C_PK_NODO_PROYECTOS,
            NodoProyectos.C_NIVEL_TENSION,
            NodoProyectos.C_D_COD_AREA,
            NodoProyectos.C_SIGLA_NODO,
            NodoProyectos.C_NOMBRE_NODO,
            NodoProyectos.C_DESCRIPCION_NODO,
            NodoProyectos.C_D_COD_ESTADO,
            NodoProyectos.C_SEC_LOG,
            NodoProyectos.C_FECHA_INGRESO,
            NodoProyectos.C_FECHA_SALIDA,
            NodoProyectos.C_D_COD_TIPO_NODO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(NodoProyectos.C_PK_NODO_PROYECTOS, OracleDbType.Int64, obj.PkNodoProyectos, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_NIVEL_TENSION, OracleDbType.Single, obj.NivelTension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_D_COD_AREA, OracleDbType.Int64, obj.DCodArea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_SIGLA_NODO, OracleDbType.Varchar2, obj.SiglaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_NOMBRE_NODO, OracleDbType.Varchar2, obj.NombreNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_DESCRIPCION_NODO, OracleDbType.Varchar2, obj.DescripcionNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_FECHA_INGRESO, OracleDbType.Date, obj.FechaIngreso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_FECHA_SALIDA, OracleDbType.Date, obj.FechaSalida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoProyectos.C_D_COD_TIPO_NODO, OracleDbType.Int64, obj.DCodTipoNodo, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(NodoProyectos.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<NodoProyectos> GetLista()
        {
            BindingList<NodoProyectos> resultado = new BindingList<NodoProyectos>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new NodoProyectos(row));
            }
            return resultado;
        }


        public DataTable GetNodos()
        {
            string sql = "select n.pk_nodo_proyectos, n.nombre_nodo, n.sigla_nodo, n.nivel_tension, n.descripcion_nodo from f_dm_nodo_proyectos n";
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetNodosReales(string sigla)
        {
            string sql;
            if (sigla.Trim() == string.Empty)
            {
                sql = "select n.pk_nodo_proyectos, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo from f_dm_nodo_proyectos n order by n.nombre_nodo";
            }
            else
            {
                sql = "select n.pk_nodo_proyectos, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo from f_dm_nodo_proyectos n Where upper(n.sigla_nodo) like '%{0}%' order by n.nombre_nodo";
                sql = string.Format(sql, sigla.Trim().ToUpper());
            }

            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public List<NodoProyectos> GetNodosProyectos(long pkPersona, long pkPersonaNodoPadre)
        {
            List<NodoProyectos> lista = new List<NodoProyectos>();
            string sql = @"select n.* from f_dm_persona_nodo np, f_dm_nodo_proyectos n
                            where np.pk_persona_nodo_padre <> 0 and np.fk_nodo_proyecto =n.pk_nodo_proyectos and np.fk_persona={0}  and np.pk_persona_nodo_padre={1}";
            sql = string.Format(sql, pkPersona, pkPersonaNodoPadre);
            DataTable tabla = EjecutarSql(sql);
            NodoProyectos nodo = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoProyectos(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }

        public List<NodoProyectos> GetNodos(long pkPersona)
        {
            List<NodoProyectos> lista = new List<NodoProyectos>();
            string sql = @"select n.* from f_dm_persona_nodo np, f_dm_nodo_proyectos n
                            where np.pk_persona_nodo_padre = 0 and np.fk_nodo_proyecto =n.pk_nodo_proyectos and np.fk_persona={0}  ";
            sql = string.Format(sql, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            NodoProyectos nodo = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoProyectos(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }
       
    }
}
