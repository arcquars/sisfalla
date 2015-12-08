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
    public class OraDalProyectoMaestroMgr : OraDalBaseMgr, IProyectoMaestroMgr
    {
        #region Singleton
        private static OraDalProyectoMaestroMgr _instancia;
        static OraDalProyectoMaestroMgr()
        {
            _instancia = new OraDalProyectoMaestroMgr();
        }
        public static OraDalProyectoMaestroMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalProyectoMaestroMgr()
        {

        }

        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return ProyectoMaestro.NOMBRE_TABLA;
            }
        }

        public void Guardar(ProyectoMaestro proyectoMaestro)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (proyectoMaestro.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", proyectoMaestro.GetEstadoString());
                proyectoMaestro.SecLog = (long)p.PK_SecLog;
                proyectoMaestro.PkProyectoMaestro = GetIdAutoNum("SQ_F_PR_PROYECTO_MAESTRO");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8}) ";//returning "+ProyectoMaestro.C_PK_PROYECTO_MAESTRO+" into :myOutputParameter";
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
                "{8}=:{8}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, ProyectoMaestro.NOMBRE_TABLA, ProyectoMaestro.C_PK_PROYECTO_MAESTRO,
            ProyectoMaestro.C_D_TIPO_PROYECTO,
            ProyectoMaestro.C_NOMBRE,
            ProyectoMaestro.C_SEC_LOG,
            ProyectoMaestro.C_CODIGO,
            ProyectoMaestro.C_FECHA_REGISTRO,
            ProyectoMaestro.C_D_TIPO_PROYECTO_PADRE,
            ProyectoMaestro.C_ESTADO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            if (proyectoMaestro.EsNuevo)
            {
                proyectoMaestro.Estado = "1";
            }
            cmd.Parameters.Add(ProyectoMaestro.C_PK_PROYECTO_MAESTRO, OracleDbType.Int64, proyectoMaestro.PkProyectoMaestro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_D_TIPO_PROYECTO, OracleDbType.Int64, proyectoMaestro.DTipoProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_NOMBRE, OracleDbType.Varchar2, proyectoMaestro.Nombre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_SEC_LOG, OracleDbType.Int64, proyectoMaestro.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_CODIGO, OracleDbType.Varchar2, proyectoMaestro.Codigo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_FECHA_REGISTRO, OracleDbType.Date, proyectoMaestro.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_D_TIPO_PROYECTO_PADRE, OracleDbType.Long, proyectoMaestro.DTipoProyectoPadre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ProyectoMaestro.C_ESTADO, OracleDbType.Varchar2, proyectoMaestro.Estado, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                if (proyectoMaestro.EsNuevo)
                {
                    //proyectoMaestro.PkProyectoMaestro = (long)(cmd.Parameters["myOutputParameter"].Value);
                    proyectoMaestro.EsNuevo = false;
                }
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(ProyectoMaestro.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<ProyectoMaestro> GetLista()
        {
            BindingList<ProyectoMaestro> resultado = new BindingList<ProyectoMaestro>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new ProyectoMaestro(row));
            }
            return resultado;
        }

        public DataTable GetTablaPorTipoProyecto(Int64 codDominio)
        {
            DataTable resultado=new DataTable();
            string sql = "SELECT {0}.{3} as COD_PROYECTO, {0}.{4},{0}.CODIGO FROM {0}, {5} WHERE {0}.{1}={2} AND {0}.{1} = {5}.{7} AND {0}.ESTADO=1 order by {4}";
            sql = string.Format(sql, ProyectoMaestro.NOMBRE_TABLA, ProyectoMaestro.C_D_TIPO_PROYECTO, codDominio, ProyectoMaestro.C_PK_PROYECTO_MAESTRO, ProyectoMaestro.C_NOMBRE, "P_DEF_DOMINIOS", "DESCRIPCION_DOMINIO","COD_DOMINIO");
            resultado = EjecutarSql(sql);
            return resultado;
        }

        public DataTable GetProyectosActivos()
        {
            DataTable resultado = null;
            string sql = "SELECT * FROM {0} WHERE {1}=1";
            sql = string.Format(sql, ProyectoMaestro.NOMBRE_TABLA,  ProyectoMaestro.C_ESTADO);
            resultado = EjecutarSql(sql);
            return resultado;
        }

        public DataTable GetProyectosPorCodTipoProyecto( string nombreProyecto, int pkTipoProyecto, long pkProyMaestro)
        {
            DataTable tabla = null;
            string sql = "SELECT {0}.{1}, {0}.{2}, {0}.{3} FROM {0} WHERE {0}.{4}={5} and {0}.ESTADO='1' and {0}.{6}<>{7}";

            if (nombreProyecto != string.Empty)
            {
                sql = sql + " and upper(" + ProyectoMaestro.C_NOMBRE + ") like '%" + nombreProyecto.Trim().ToUpper() + "%' ";
            }

            sql = string.Format(sql,ProyectoMaestro.NOMBRE_TABLA ,ProyectoMaestro.C_NOMBRE, ProyectoMaestro.C_CODIGO, ProyectoMaestro.C_PK_PROYECTO_MAESTRO, ProyectoMaestro.C_D_TIPO_PROYECTO,pkTipoProyecto, ProyectoMaestro.C_PK_PROYECTO_MAESTRO,pkProyMaestro);
            tabla = EjecutarSql(sql);
            DataRow row = tabla.NewRow();
            row[0] = "NINGUNO";
            row[1] = "NINGUNO";
            row[2] = 0;
            tabla.Rows.Add(row);
            return tabla;
        }

        public bool ExisteProyectoConEstaEtapa(long pkProyectoMaestro, Int64 pkProyecto, Int64 pkEtapa)
        {
            bool res = false;
            string sql = "SELECT {0}.* FROM {0},{1},{2} WHERE {1}.{3}={4} and {1}.{3}={0}.{5} and {2}.{6}={0}.{7} and F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, Proyecto.NOMBRE_TABLA, ProyectoMaestro.NOMBRE_TABLA, DefDominio.NOMBRE_TABLA, 
                                ProyectoMaestro.C_PK_PROYECTO_MAESTRO, pkProyectoMaestro,Proyecto.C_FK_PROYECTO_MAESTRO, DefDominio.C_COD_DOMINIO,Proyecto.C_D_COD_ETAPA);

            if (pkProyecto == 0)
            {
                sql = sql + " and " + Proyecto.NOMBRE_TABLA + "." + Proyecto.C_D_COD_ETAPA + " = " + pkEtapa;
            }
            else
            {
                sql = sql + " and " + Proyecto.NOMBRE_TABLA + "." + Proyecto.C_D_COD_ETAPA + " = " + pkEtapa + " and " + Proyecto.NOMBRE_TABLA + "." + Proyecto.C_PK_PROYECTO + " <> "+pkProyecto;
            }
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }

        public void CambiarEstadoProyectoMaestro(long pkProyectoMaestro, int estado)
        {
            string sql = "UPDATE {0} SET {3}={4} WHERE  {1}={2} ";
            sql = string.Format(sql, ProyectoMaestro.NOMBRE_TABLA, ProyectoMaestro.C_PK_PROYECTO_MAESTRO, pkProyectoMaestro, ProyectoMaestro.C_ESTADO, estado);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
            if (res)
            {
                OraDalProyectoMgr.Instancia.CambiarEstadoProyectoPorIdMaestro(pkProyectoMaestro, estado);
            }
        }

        public bool ExisteProyectoConEsteNombre(string nombre)
        {
            string sql = "SELECT {0}.* FROM {0} WHERE  upper({1})='{2}' AND {3}='1' ";
            sql = string.Format(sql, ProyectoMaestro.NOMBRE_TABLA, ProyectoMaestro.C_NOMBRE,nombre.ToUpper(), ProyectoMaestro.C_ESTADO);
            DataTable tabla = EjecutarSql(sql);
            bool res = tabla.Rows.Count == 0 ? false : true;
            return res;
        }
    }
}
