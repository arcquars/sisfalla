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
    public class OraDalProyectoMgr : OraDalBaseMgr, IProyectoMgr
    {
        #region Singleton
        private static OraDalProyectoMgr _instancia;
        static OraDalProyectoMgr()
        {
            _instancia = new OraDalProyectoMgr();
        }
        public static OraDalProyectoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalProyectoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return Proyecto.NOMBRE_TABLA;
            }
        }

        public void Guardar(Proyecto proyecto)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (proyecto.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", proyecto.GetEstadoString());
                proyecto.SecLog = (long)p.PK_SecLog;
                proyecto.PkProyecto = GetIdAutoNum("SQ_F_PR_PROYECTO");
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

            sql = string.Format(sql, Proyecto.NOMBRE_TABLA,
            Proyecto.C_PK_PROYECTO,
            Proyecto.C_FK_PROYECTO_MAESTRO,
            Proyecto.C_D_COD_ETAPA,
            Proyecto.C_D_COD_PERSONA,
            Proyecto.C_DESCRIPCION,
            Proyecto.C_ESQUEMA,
            Proyecto.C_SEC_LOG,
            Proyecto.C_CODIGO,
            Proyecto.C_ESTADO,
            Proyecto.C_FECHA_REGISTRO,
            Proyecto.C_NOMBRE_ESQUEMA);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            if (proyecto.EsNuevo)
            {
                proyecto.Estado = "1";
            }
            cmd.Parameters.Add(Proyecto.C_PK_PROYECTO, OracleDbType.Int64, proyecto.PkProyecto, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_FK_PROYECTO_MAESTRO, OracleDbType.Int64, proyecto.FkProyectoMaestro, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_D_COD_ETAPA, OracleDbType.Int64, proyecto.DCodEtapa, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_D_COD_PERSONA, OracleDbType.Int64, proyecto.DCodPersona, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_DESCRIPCION, OracleDbType.Varchar2, proyecto.Descripcion, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_ESQUEMA, OracleDbType.Blob, proyecto.Esquema, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_SEC_LOG, OracleDbType.Int64, proyecto.SecLog, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_CODIGO, OracleDbType.Varchar2, proyecto.Codigo, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_ESTADO, OracleDbType.Varchar2, proyecto.Estado, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_FECHA_REGISTRO, OracleDbType.Date, proyecto.FechaDeRegistro, ParameterDirection.Input);
            cmd.Parameters.Add(Proyecto.C_NOMBRE_ESQUEMA, OracleDbType.Varchar2, proyecto.NombreEsquema, ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                proyecto.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(Proyecto.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<Proyecto> GetLista()
        {
            BindingList<Proyecto> resultado = new BindingList<Proyecto>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new Proyecto(row));
            }
            return resultado;
        }

        public void CambiarEstadoProyecto(long pkProyecto, int estado)
        {
            OracleCommand cmd = CrearCommand();
            string sql = "UPDATE {0} SET {1}={2} WHERE {3}={4}";
            sql = string.Format(sql, Proyecto.NOMBRE_TABLA, Proyecto.C_ESTADO, estado, Proyecto.C_PK_PROYECTO, pkProyecto);
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public Proyecto GetProyectoPorEtapa(long pkEtapa, long pkProyectoMaestro)
        {
            Proyecto proy = null;
            OracleCommand cmd = CrearCommand();
            string sql = "SELECT {0}.* FROM {0} WHERE {1}={2} AND {3}={4} AND ESTADO='1'";
            sql = string.Format(sql, Proyecto.NOMBRE_TABLA, Proyecto.C_D_COD_ETAPA, pkEtapa, Proyecto.C_FK_PROYECTO_MAESTRO, pkProyectoMaestro);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            { 
              DataRow row= tabla.Rows[0];
              proy = new Proyecto(row);
            }
            return proy;
        }

        public void CopiarDatos(Proyecto _proyectoSeleccionado, Proyecto _proyectoNuevo)
        {
            _proyectoSeleccionado.EsNuevo = true;
            _proyectoSeleccionado.DCodEtapa = _proyectoNuevo.DCodEtapa;
            Guardar(_proyectoNuevo);
        }

        public DataTable GetProyectosPorPkMaestro(long pkProyMaestro)
        {
            string sql = "SELECT {0}.* FROM {0} WHERE {1}={2} AND  ESTADO='1'";
            sql = string.Format(sql, Proyecto.NOMBRE_TABLA, Proyecto.C_FK_PROYECTO_MAESTRO, pkProyMaestro);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetProyectosPorPkPersona(long pkPersona)
        {
            string sql = "SELECT {0}.* FROM {0} WHERE {1}={2} AND  ESTADO='1'";
            sql = string.Format(sql, Proyecto.NOMBRE_TABLA, Proyecto.C_D_COD_PERSONA, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void CambiarEstadoProyectoPorIdMaestro(long pkProyectoMaestro, int estado)
        {
            string sql = "UPDATE f_pr_proyecto SET estado=:estado WHERE fk_proyecto_maestro=:fk_proyecto_maestro";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fk_proyecto_maestro", OracleDbType.Int64, pkProyectoMaestro, ParameterDirection.Input);
            cmd.Parameters.Add("estado", OracleDbType.Int16, estado, ParameterDirection.Input);
            Actualizar(cmd);
        }
    }
}