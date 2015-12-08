using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using CNDC.Pistas;
using System.ComponentModel;

namespace CNDC.BLL
{
    public class DefDominioMgr : OraDalBaseMgr, IDefDominioMgr
    {
        public DefDominioMgr()
        {

        }
        public DefDominioMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public DataTable GetDominio(string dominio)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from P_DEF_DOMINIOS where D_COD_TIPO=:D_COD_TIPO AND D_COD_ESTADO=1 order by COD_DOMINIO";
            cmd.Parameters.Add("D_COD_TIPO", dominio);
            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = dominio;
            return tabla;
        }

        public DataTable GetTipoComponente(string tipoComponente)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select pk_cod_tipo_componente as COD_DOMINIO, descripcion_tipo as DESCRIPCION_DOMINIO from P_AC_TIPOCOMPONENTE WHERE PK_COD_TIPO_COMPONENTE != 0 order by pk_cod_tipo_componente";
            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = tipoComponente;
            return tabla;
        }

        public DataTable GetDominioOrdenado(string dominio)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from P_DEF_DOMINIOS where D_COD_TIPO=:D_COD_TIPO AND D_COD_ESTADO=1 order by ORDEN";
            cmd.Parameters.Add("D_COD_TIPO", dominio);
            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = dominio;
            return tabla;
        }

        public DataTable GetCategorias()
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "SELECT DESCRIPCION_DOMINIO, D_COD_TIPO_DOMINIO FROM P_DEF_CAT_DOMINIOS";
            DataTable tabla = EjecutarCmd(cmd);
            return tabla;
        }

        public DataTable GetRegistros(long codOrigen,long codTdesconex, long codcausa)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from P_DEF_DOMINIOS where COD_DOMINIO IN (:COD_ORIGEN, :COD_TDESCONEX, :CODCAUSA) AND D_COD_ESTADO=1";
            cmd.Parameters.Add("COD_ORIGEN", codOrigen);
            cmd.Parameters.Add("COD_TDESCONEX", codTdesconex);
            cmd.Parameters.Add("CODCAUSA", codcausa);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = DefDominio.NOMBRE_TABLA;

            return tabla;
        }

        public BindingList<DefDominio> GetListaDominio(string dominio)
        {
            BindingList<DefDominio> resultado = new BindingList<DefDominio>();
            DataTable tablaAgentes = GetDominio(dominio);
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DefDominio(row));
            }
            return resultado;
        }

        public BindingList<DefDominio> GetListaDominioOrdenado(string dominio)
        {
            BindingList<DefDominio> resultado = new BindingList<DefDominio>();
            DataTable tablaAgentes = GetDominioOrdenado(dominio);
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DefDominio(row));
            }
            return resultado;
        }

        public bool Existe(DataRow row, DataTable tablaLocal)
        {
            bool resultado = false;
            DataRow[] registrosEncontrador = tablaLocal.Select(DefDominio.C_COD_DOMINIO + "=" + row[DefDominio.C_COD_DOMINIO]);
            resultado = registrosEncontrador.Length > 0;
            return resultado;
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla("P_DEF_DOMINIOS");
            return tabla;
        }

        public void Guardar(DefDominio obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} , " +
                "{6}=:{6} , " +
                "{7}=:{7} , " +
                "{8}=:{8} , " +
                "{9}=:{9} , " +
                "{10}=:{10} , " +
                "{11}=:{11} , " +
                "{12}=:{12} , " +
                "{13}=:{13} , " +
                "{14}=:{14} WHERE " +
                "{1}=:{1} ";
            }

            sql = string.Format(sql, DefDominio.NOMBRE_TABLA,
            DefDominio.C_COD_DOMINIO,
            DefDominio.C_DESCRIPCION,
            DefDominio.C_D_COD_TIPO,
            DefDominio.C_D_COD_ESTADO,
            DefDominio.C_SEC_LOG,
            DefDominio.C_ORDEN,
            DefDominio.C_COD_DOMINIO_PADRE,
            DefDominio.C_SINC_VER,
            DefDominio.C_DESCRIPCION2,
            DefDominio.C_AUX1_DOM,
            DefDominio.C_AUX2_DOM,
            DefDominio.C_FEC_INICIO_DOM,
            DefDominio.C_FEC_FIN_DOM,
            DefDominio.C_COMENTARIO_DOM);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(DefDominio.C_COD_DOMINIO, OracleDbType.Int32, obj.CodDominio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_DESCRIPCION, OracleDbType.Varchar2, obj.Descripcion.ToUpper(), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_D_COD_TIPO, OracleDbType.Varchar2, obj.DCodTipo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_SEC_LOG, OracleDbType.Int32, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_ORDEN, OracleDbType.Int32, obj.Orden, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_COD_DOMINIO_PADRE, OracleDbType.Int32, obj.CodDominioPadre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_SINC_VER, OracleDbType.Int32, obj.SincVer, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_DESCRIPCION2, OracleDbType.Varchar2, obj.Descripcion2, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_AUX1_DOM, OracleDbType.Varchar2, obj.Aux1_dom, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DefDominio.C_AUX2_DOM, OracleDbType.Varchar2, obj.Aux2_dom, System.Data.ParameterDirection.Input);
            if (!(obj.Fec_inicio_dom == DateTime.MinValue))
            {
                cmd.Parameters.Add(DefDominio.C_FEC_INICIO_DOM, OracleDbType.Date, obj.Fec_inicio_dom, System.Data.ParameterDirection.Input);
            }
            else
            {
                cmd.Parameters.Add(DefDominio.C_FEC_INICIO_DOM, DBNull.Value);
            }
            if (obj.Fec_fin_dom != obj.Fec_inicio_dom)
            {
                cmd.Parameters.Add(DefDominio.C_FEC_FIN_DOM, OracleDbType.Date, obj.Fec_fin_dom, System.Data.ParameterDirection.Input);
            }
            else
            {
                cmd.Parameters.Add(DefDominio.C_FEC_FIN_DOM, DBNull.Value);
            }
            cmd.Parameters.Add(DefDominio.C_COMENTARIO_DOM, OracleDbType.Varchar2, obj.Comentario_dom, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public void Borrar(DefDominio Dominio)
        {
            string sql = @"DELETE
                            FROM P_DEF_DOMINIOS
                            WHERE 
                            COD_DOMINIO = :PK_COD_DOMINIO";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add("PK_COD_DOMINIO", OracleDbType.Int32, Dominio.CodDominio, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public override string NombreTabla
        {
            get { return DefDominio.NOMBRE_TABLA; }
        }

        public DefDominio GetDominioPorPkDominio(long pkDominio)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2}";
            sql = string.Format(sql,DefDominio.NOMBRE_TABLA,DefDominio.C_COD_DOMINIO,pkDominio);
            DataTable tabla = EjecutarSql(sql);
            DefDominio res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row= tabla.Rows[0];
                res = new DefDominio(row);
            }
            return res;
        }

        public Dictionary<DefDominio,long> GetListaEstapasProyectoPorPkProyMaestro(long pkProyecto)
        {
            string sql = @" SELECT {0}.*,F_PR_PROYECTO.PK_PROYECTO FROM {0},F_PR_PROYECTO_MAESTRO,F_PR_PROYECTO  " +
                          " WHERE {0}.{1}=F_PR_PROYECTO.D_COD_ETAPA "+
                          " AND F_PR_PROYECTO.FK_PROYECTO_MAESTRO=F_PR_PROYECTO_MAESTRO.PK_PROYECTO_MAESTRO" +
                          " AND F_PR_PROYECTO_MAESTRO.PK_PROYECTO_MAESTRO={2} AND F_PR_PROYECTO.ESTADO=1 ";
            sql = string.Format(sql, DefDominio.NOMBRE_TABLA, DefDominio.C_COD_DOMINIO,pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DefDominio res = null;
            Dictionary<DefDominio, long> resultado = new Dictionary<DefDominio,long>();
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row  in tabla.Rows)
                {
                    res = new DefDominio(row);
                    resultado[res]=(long)row["PK_PROYECTO"];
                }
            }
            return resultado;
        }

        public DefDominio GetEtapaPorDescDefDominio(string descDefDominio)
        {
            string sql = "SELECT * FROM {0} WHERE {1}='{2}'";
            sql = string.Format(sql, DefDominio.NOMBRE_TABLA, DefDominio.C_AUX1_DOM, descDefDominio);
            DataTable tabla = EjecutarSql(sql);
            DefDominio dominio = null;
            if (tabla.Rows.Count > 0)
            { 
               DataRow row= tabla.Rows[0];
               dominio = new DefDominio(row);
            }
            return dominio;
        }

        public List<DefDominio> GetListaEtapasDeProyectosVigentes(string dominio, long pkProyectoMaestro)
        {
            List<DefDominio> resultado = new List<DefDominio>();
            DataTable tabla = new DataTable();
            OracleCommand cmd = CrearCommand();
            string sql = @" SELECT P_DEF_DOMINIOS.* FROM P_DEF_DOMINIOS,F_PR_PROYECTO 
                          WHERE D_COD_TIPO='{0}' AND D_COD_ESTADO='1' 
                          AND P_DEF_DOMINIOS.COD_DOMINIO=F_PR_PROYECTO.D_COD_ETAPA
                          AND F_PR_PROYECTO.FK_PROYECTO_MAESTRO={1} AND F_PR_PROYECTO.ESTADO='1'";
            sql = string.Format(sql, dominio,pkProyectoMaestro);
            tabla = EjecutarSql(sql);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new DefDominio(row));
            }
            return resultado;
        }

        public DataTable GetTiposAgentes()
        {
            string sql = "select  p_def_dominios.cod_dominio,p_def_dominios.descripcion_dominio as TIPO_DE_DEMANDA from p_def_dominios where p_def_dominios.d_cod_tipo='D_COD_TIPO_AGENTE' ORDER BY p_def_dominios.cod_dominio ";
            DataTable tabla = EjecutarSql(sql);
            DataRow row = tabla.NewRow();
            row[0] = 0;
            row[1] = "NINGUNO";
            tabla.Rows.Add(row);
            return tabla;
        }

        public DataTable GetCategoriaDatos()
        {
            string sql = @"select  p_def_dominios.cod_dominio,p_def_dominios.descripcion_dominio  
                            from p_def_dominios 
                            where p_def_dominios.d_cod_tipo='D_COD_CATEGORIA_DATO' ORDER BY p_def_dominios.cod_dominio ";
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }
    }
}
