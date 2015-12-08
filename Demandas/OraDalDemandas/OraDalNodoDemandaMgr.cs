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
    public class OraDalNodoDemandaMgr : OraDalBaseMgr, INodoDemandaMgr
    {
        #region Singleton
        private static OraDalNodoDemandaMgr _instancia;
        static OraDalNodoDemandaMgr()
        {
            _instancia = new OraDalNodoDemandaMgr();
        }
        public static OraDalNodoDemandaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalNodoDemandaMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return NodoDemanda.NOMBRE_TABLA;
            }
        }

        public void Guardar(NodoDemanda obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkNodoDemanda = GetIdAutoNum("SQ_F_DM_NODO_PROYECTOS");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13})";
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
                "{13}=:{13}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, NodoDemanda.NOMBRE_TABLA, NodoDemanda.C_PK_NODO_DEMANDA,
            NodoDemanda.C_NIVEL_TENSION,
            NodoDemanda.C_D_COD_AREA,
            NodoDemanda.C_SIGLA_NODO,
            NodoDemanda.C_NOMBRE_NODO,
            NodoDemanda.C_DESCRIPCION_NODO,
            NodoDemanda.C_D_COD_ESTADO,
            NodoDemanda.C_SEC_LOG,
            NodoDemanda.C_FECHA_INGRESO,
            NodoDemanda.C_FECHA_SALIDA,
            NodoDemanda.C_CRITERIO_AGREGACION,
            NodoDemanda.C_FK_NODO_DEMANDA_CONEXION,
            NodoDemanda.C_D_COD_TIPO_NODO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(NodoDemanda.C_PK_NODO_DEMANDA, OracleDbType.Int64, obj.PkNodoDemanda, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_NIVEL_TENSION, OracleDbType.Int32, obj.NivelTension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_D_COD_AREA, OracleDbType.Int64, obj.DCodArea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_SIGLA_NODO, OracleDbType.Varchar2, obj.SiglaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_NOMBRE_NODO, OracleDbType.Varchar2, obj.NombreNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_DESCRIPCION_NODO, OracleDbType.Varchar2, obj.DescripcionNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_FECHA_INGRESO, OracleDbType.Date, obj.FechaIngreso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_FECHA_SALIDA, OracleDbType.Date, obj.FechaSalida, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_CRITERIO_AGREGACION, OracleDbType.Varchar2, obj.CriterioAgregacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_FK_NODO_DEMANDA_CONEXION, OracleDbType.Long, obj.FkNodoDemandaConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(NodoDemanda.C_D_COD_TIPO_NODO, OracleDbType.Int64, obj.DCodTipoNodo, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(NodoDemanda.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<NodoDemanda> GetLista()
        {
            BindingList<NodoDemanda> resultado = new BindingList<NodoDemanda>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new NodoDemanda(row));
            }
            return resultado;
        }


        public DataTable GetNodos(long pkTipoNodo)
        {
            string sql = @" select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.nivel_tension, tn.descripcion_dominio as TIPO_NODO, na.descripcion_dominio as AREA
                             from f_dm_nodo_demanda n , p_def_dominios tn, p_def_dominios na
                             where n.{0}={1}  
                             and n.d_cod_tipo_nodo=tn.cod_dominio 
                             and n.d_cod_area = na.cod_dominio and n.d_cod_estado ='1'
                             order by pk_nodo_demanda ";
            sql = string.Format(sql, NodoDemanda.C_D_COD_TIPO_NODO, pkTipoNodo);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetNodosParaAsignacionDeNodosSalida(long codTipoNodo, long pkPersonaNodo, long pkPersona)
        {
            string sql;
//            string sql2 = @"select F_DM_NODO_DEMANDA.PK_NODO_DEMANDA
//                            from F_DM_NODO_DEMANDA,F_DM_DEMANDA_SALIDA_MAESTRO where F_DM_NODO_DEMANDA.PK_NODO_DEMANDA=F_DM_DEMANDA_SALIDA_MAESTRO.FK_NODO_SALIDA 
//                            and F_DM_DEMANDA_SALIDA_MAESTRO.FK_PERSONA_NODO={0}";
            //            string sql3 = @"select n.PK_NODO_DEMANDA from F_DM_R_PERSONA_NODO np, F_DM_NODO_DEMANDA n
//                            where np.pk_persona_nodo_padre <> 0 and np.FK_NODO_PROYECTO =n.PK_NODO_DEMANDA and np.fk_persona={0} ";
//            sql2 = string.Format(sql2, pkPersonaNodo);
//            sql3 = string.Format(sql3, pkPersona);
//            sql = @"select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo
//                        from f_dm_nodo_demanda n, p_def_dominios d 
//                        where n.d_cod_tipo_nodo=d.cod_dominio  
//                        and d.cod_dominio={0}  
//                        and n.pk_nodo_demanda not in ({1}) 
//                        order by n.nombre_nodo";
            sql = @"select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo
                        from f_dm_nodo_demanda n, p_def_dominios d 
                        where n.d_cod_tipo_nodo=d.cod_dominio  and n.d_cod_estado='1' 
                        and d.cod_dominio={0}  
                        order by n.nombre_nodo";

            // sql = string.Format(sql, codTipoNodo,sql2);
             sql = string.Format(sql, codTipoNodo);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public List<NodoDemanda> GetListaNodosParaAsignacionDeNodosSalida(long codTipoNodo, long pkPersonaNodo, long pkPersona)
        {
            string sql;
            List<NodoDemanda> lista = new List<NodoDemanda>();
            string sql2 = @"select F_DM_NODO_DEMANDA.*
                            from F_DM_NODO_DEMANDA,F_DM_DEMANDA_SALIDA_MAESTRO where F_DM_NODO_DEMANDA.PK_NODO_DEMANDA=F_DM_DEMANDA_SALIDA_MAESTRO.FK_NODO_SALIDA 
                            and F_DM_DEMANDA_SALIDA_MAESTRO.FK_PERSONA_NODO={0}";
            string sql3 = @"select n.PK_NODO_DEMANDA from F_DM_R_PERSONA_NODO np, F_DM_NODO_DEMANDA n
                            where np.pk_persona_nodo_padre <> 0 and np.FK_NODO_PROYECTO =n.PK_NODO_DEMANDA and np.fk_persona={0} ";
            sql2 = string.Format(sql2, pkPersonaNodo);
            sql3 = string.Format(sql3, pkPersona);
            sql = @"select n.*
                        from f_dm_nodo_demanda n, p_def_dominios d 
                        where n.d_cod_tipo_nodo=d.cod_dominio  
                        and d.cod_dominio={0}  
                        and n.pk_nodo_demanda not in ({1}) 
                        order by n.nombre_nodo";

            sql = string.Format(sql, codTipoNodo, sql2);
            DataTable tabla = EjecutarSql(sql);
            NodoDemanda nodo;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoDemanda(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }


        public DataTable GetNodosProySalida(string sigla, long codTipoNodo, long pkNodoDemanda)
        {
            string sql;
            /*string condicionOpcional = " and n.PK_NODO_DEMANDA<>"+pkNodoDemanda;
            if (pkNodoDemanda == 0)
            {
                condicionOpcional = string.Empty;
            }
            if (sigla.Trim() == string.Empty)
            {
                sql = @"select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo
                        from f_dm_nodo_demanda n, p_def_dominios d
                        where n.d_cod_tipo_nodo=d.cod_dominio and d.cod_dominio={0} {1} order by n.nombre_nodo";

                sql = string.Format(sql, codTipoNodo,condicionOpcional);
            }
            else
            {
                sql = @"select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo 
                        from f_dm_nodo_demanda n, p_def_dominios d Where n.d_cod_tipo_nodo=d.cod_dominio 
                        and d.cod_dominio={1} and  upper(n.sigla_nodo) like '%{0}%'  {2} order by n.nombre_nodo";
                sql = string.Format(sql, sigla.Trim().ToUpper(), codTipoNodo,condicionOpcional);
            }*/
            sql = @"select n.pk_nodo_demanda, n.nombre_nodo, n.sigla_nodo, n.descripcion_nodo
                        from f_dm_nodo_demanda n, p_def_dominios d 
                        where n.d_cod_tipo_nodo=d.cod_dominio  
                        and d.cod_dominio={0}  and n.d_cod_estado='1' 
                        order by n.nombre_nodo";
            sql = string.Format(sql,codTipoNodo);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public List<NodoDemanda> GetListaNodosProySalida(string sigla, long codTipoNodo, long pkNodoDemanda)
        {
            string sql;
            string condicionOpcional = " and n.PK_NODO_DEMANDA<>" + pkNodoDemanda;
            List<NodoDemanda> lista = new List<NodoDemanda>();
            if (pkNodoDemanda == 0)
            {
                condicionOpcional = string.Empty;
            }
            if (sigla.Trim() == string.Empty)
            {
                sql = @"select n.*
                        from f_dm_nodo_demanda n, p_def_dominios d
                        where n.d_cod_tipo_nodo=d.cod_dominio and d.cod_dominio={0} {1}  and n.d_cod_estado='1' order by n.nombre_nodo";

                sql = string.Format(sql, codTipoNodo, condicionOpcional);
            }
            else
            {
                sql = @"select n.*
                        from f_dm_nodo_demanda n, p_def_dominios d Where n.d_cod_tipo_nodo=d.cod_dominio 
                        and d.cod_dominio={1} and  upper(n.sigla_nodo) like '%{0}%' and n.d_cod_estado='1' {2} order by n.nombre_nodo";
                sql = string.Format(sql, sigla.Trim().ToUpper(), codTipoNodo, condicionOpcional);
            }

            DataTable tabla = EjecutarSql(sql);
            NodoDemanda nodo;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoDemanda(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }

        public List<NodoDemanda> GetNodosConectados(long pkPersona, long pkPersonaNodoPadre)
        {
            List<NodoDemanda> lista = new List<NodoDemanda>();
            string sql = @"select n.* from F_DM_R_PERSONA_NODO np, f_dm_nodo_demanda n
                            where np.pk_persona_nodo_padre <> 0 and np.fk_nodo_proyecto =n.pk_nodo_demanda and np.fk_persona={0}  and np.pk_persona_nodo_padre={1}";
            sql = string.Format(sql, pkPersona, pkPersonaNodoPadre);
            DataTable tabla = EjecutarSql(sql);
            NodoDemanda nodo = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoDemanda(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }

        public List<NodoDemanda> GetNodosDemanda(long pkPersona)
        {
            List<NodoDemanda> lista = new List<NodoDemanda>();
            string sql = @"select n.* from F_DM_R_PERSONA_NODO np, f_dm_nodo_demanda n
                            where np.pk_persona_nodo_padre = 0 and np.fk_nodo_proyecto =n.pk_nodo_demanda and np.fk_persona={0}  ";
            sql = string.Format(sql, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            NodoDemanda nodo = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    nodo = new NodoDemanda(row);
                    lista.Add(nodo);
                }
            }
            return lista;
        }

        public DataTable GetNodosSalidaDeNodoDemanda(long pkPersonaNodo, int codTipoSalida)
        {
            string sql = "select {0}.PK_NODO_DEMANDA,{0}.NOMBRE_NODO,{0}.SIGLA_NODO  from {0},{1} where {0}.{2}={1}.{3} and {1}.{4}={5} and {1}.{6}={7} order by  {1}.PK_DEMANDA_SALIDA_MAESTRO";
            sql = string.Format(sql, NombreTabla, DemandaSalidaMaestro.NOMBRE_TABLA, NodoDemanda.C_PK_NODO_DEMANDA, DemandaSalidaMaestro.C_FK_NODO_SALIDA,DemandaSalidaMaestro.C_FK_PERSONA_NODO,pkPersonaNodo, DemandaSalidaMaestro.C_D_COD_TIPO_NODO_SALIDA, codTipoSalida);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }



        public bool ExisteNodo(string nombreCampo, string valorCampo, long pkNodoDemanda, long pkTipoNodo)
        {
            bool res = false;
            string sql="";
            if (pkNodoDemanda == 0)
            {
                sql = "SELECT * FROM {0} WHERE {1}='{2}' and {3}={4}";
                sql = string.Format(sql,NombreTabla ,nombreCampo.Trim(), valorCampo, NodoDemanda.C_D_COD_TIPO_NODO, pkTipoNodo);
            }
            else
            {
                sql = "SELECT * FROM {0} WHERE {1}='{2}' AND {3}<>{4} and {5}={6}";
                sql = string.Format(sql, NombreTabla, nombreCampo, valorCampo.Trim(), NodoDemanda.C_PK_NODO_DEMANDA, pkNodoDemanda, NodoDemanda.C_D_COD_TIPO_NODO, pkTipoNodo);
            }

            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }

        public void DarDeBajaNodoDemanda(long pkNodoDemanda)
        {
            string sql = " update {0} set {1}='{2}' where {3}={4}";
            sql = string.Format(sql, NodoDemanda.NOMBRE_TABLA, NodoDemanda.C_D_COD_ESTADO, "0", NodoDemanda.C_PK_NODO_DEMANDA, pkNodoDemanda);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
