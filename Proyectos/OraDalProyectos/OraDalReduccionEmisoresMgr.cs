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
    public class OraDalReduccionEmisoresMgr : OraDalBaseMgr, IReduccionEmisoresMgr
    {
        #region Singleton
        private static OraDalReduccionEmisoresMgr _instancia;
        static OraDalReduccionEmisoresMgr()
        {
            _instancia = new OraDalReduccionEmisoresMgr();
        }
        public static OraDalReduccionEmisoresMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalReduccionEmisoresMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return ReduccionEmisores.NOMBRE_TABLA;
            }
        }

        public void Guardar(ReduccionEmisores reduccionDeEmisores)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (reduccionDeEmisores.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", reduccionDeEmisores.GetEstadoString());
                reduccionDeEmisores.SecLog = (long)p.PK_SecLog;
                reduccionDeEmisores.PkReduccionEmisores = GetIdAutoNum("SQ_F_PR_RECUCCION_EMISORES");
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

            sql = string.Format(sql, ReduccionEmisores.NOMBRE_TABLA, ReduccionEmisores.C_PK_REDUCCION_EMISORES,
            ReduccionEmisores.C_FK_PROYECTO,
            ReduccionEmisores.C_REDUCCION_CO2,
            ReduccionEmisores.C_FECHA_REGISTRO,
            ReduccionEmisores.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            
            cmd.Parameters.Add(ReduccionEmisores.C_PK_REDUCCION_EMISORES, OracleDbType.Int64, reduccionDeEmisores.PkReduccionEmisores, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ReduccionEmisores.C_FK_PROYECTO, OracleDbType.Int64, reduccionDeEmisores.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ReduccionEmisores.C_REDUCCION_CO2, OracleDbType.Double, reduccionDeEmisores.ReduccionCo2, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ReduccionEmisores.C_FECHA_REGISTRO, OracleDbType.Date, reduccionDeEmisores.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ReduccionEmisores.C_SEC_LOG, OracleDbType.Int64, reduccionDeEmisores.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                reduccionDeEmisores.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(ReduccionEmisores.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<ReduccionEmisores> GetLista()
        {
            BindingList<ReduccionEmisores> resultado = new BindingList<ReduccionEmisores>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new ReduccionEmisores(row));
            }
            return resultado;
        }

        public ReduccionEmisores GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0}, F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, ReduccionEmisores.NOMBRE_TABLA, ReduccionEmisores.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            ReduccionEmisores res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new ReduccionEmisores(row);
            }
            return res;
        }
    }
}
