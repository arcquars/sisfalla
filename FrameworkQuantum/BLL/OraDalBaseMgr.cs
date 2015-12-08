using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Data;

namespace CNDC.BLL
{
    public class OraDalBaseMgr
    {
        ConnexionOracleMgr _conexion;
        public OraDalBaseMgr()
        {
            _conexion = Sesion.Instancia.Conexion;
        }

        public OraDalBaseMgr(ConnexionOracleMgr c)
        {
            _conexion = c;
        }


        protected OracleCommand CrearCommand()
        {
            return _conexion.CrearCommand(); 
        }

        protected OracleCommand CrearCommand(string sql)
        {
            OracleCommand resultado = _conexion.CrearCommand();
            resultado.CommandText = sql;
            resultado.BindByName = true;
            return resultado;
        }

        protected DataTable EjecutarCmd(OracleCommand cmd)
        {
            DataTable tabla = _conexion.EjecutarCmd(cmd);
            return tabla;
        }

        protected DataTable GetTabla(string nombreTabla)
        {
            return _conexion.GetTabla(nombreTabla); 
        }

        protected void DisposeCommand(OracleCommand cmd)
        {
            _conexion.DisposeCommand(cmd);
        }

        protected bool Actualizar(OracleCommand cmd)
        {
            return _conexion.Actualizar(cmd);
        }

        public static Array GetArray(List<DataRow> rows, string campo)
        {
            object[] resultado = new object[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Table.Columns.Contains(campo))
                {
                    resultado[i] = rows[i][campo];
                }
                else
                {
                    resultado[i] = null;
                }
            }
            return resultado;
        }

        protected DataTable EjecutarSql(string sql)
        {
            return _conexion.EjecutarSql(sql);
        }

        /// <summary>
        /// Verifica si el registro row existe en la tabla nombreTabla
        /// </summary>
        /// <param name="nombreTabla">Tabla de la Base de Datos</param>
        /// <param name="row">un registro a ser verificado</param>
        /// <returns>true si row existe en la tabla nombreTabla</returns>
        public virtual bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            DataTable primaryKey = GetPrimarykey(nombreTabla);
            OracleCommand cmd = CrearCommand();
            string condicion = string.Empty;
            string columna = string.Empty;

            foreach (DataRow r in primaryKey.Rows)
            {
                if (condicion != string.Empty)
                {
                    condicion += " AND ";
                }
                columna = (string)r["column_name"];
                condicion += columna + "=:" + columna;
                cmd.Parameters.Add((string)r["column_name"], row[columna]);
            }
            cmd.CommandText =
            "SELECT COUNT(" + columna + ")" +
            " FROM " + nombreTabla +
            " WHERE " + condicion;
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene los campos llave de la tabla cuyo nombre es pasado como parámetro
        /// </summary>
        /// <param name="nombreTabla">nombre de la tabla, de la cual se quiere obtener información</param>
        /// <returns>El resultado es un DataTable en el que cada Row es un campo que forma parte del
        /// primaryKey de la tabla</returns>
        private DataTable GetPrimarykey(string nombreTabla)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @" SELECT cols.table_name, cols.column_name, cols.position,  cons.owner
             FROM all_constraints cons, all_cons_columns cols
             WHERE cons.constraint_type = 'P'
             AND cons.constraint_name = cols.constraint_name
             AND cons.owner = cols.owner
             AND cols.owner IN ( select db_schema from p_quantum )
             AND cols.table_name= :nombreTabla
             AND cons.status ='ENABLED'
             ORDER BY cols.position";

            cmd.Parameters.Add("nombreTabla", OracleDbType.Varchar2, nombreTabla, System.Data.ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);

            return resultado;
        }

        public OracleParameter CrearParametroEntrada(string campo, OracleDbType tipo, List<DataRow> rows)
        {
            OracleParameter resultado = new OracleParameter(campo, tipo, GetArray(rows, campo), ParameterDirection.Input);
            return resultado;
        }

        public T GetPorId<T>(long id, string campoLlave) where T : ObjetoDeNegocio, new()
        {
            T resultado = null;
            string sql = "SELECT * FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, NombreTabla,campoLlave, id);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count == 1)
            {
                resultado = new T();
                resultado.Leer(tabla.Rows[0]);
            }
            return resultado;
        }

        public virtual string NombreTabla
        { get { return null; } }

        public long GetIdAutoNum(string nombreSecuencia)
        {
            long num = 0;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = "select " + nombreSecuencia + ".NEXTVAL from dual";
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                num = (long)(decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Pistas.PistaMgr.Instance.Error("OraDalBaseMgr", ex);
            }
            finally
            {
                Sesion.Instancia.Conexion.DisposeCommand(cmd);
            }
            return num;
        }

        public long GetIdActual(string nombreSecuencia)
        {
            long num = 0;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = "select " + nombreSecuencia + ".CURRVAL from dual";
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                num = (long)(decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Pistas.PistaMgr.Instance.Error("OraDalBaseMgr", ex);
            }
            finally
            {
                Sesion.Instancia.Conexion.DisposeCommand(cmd);
            }
            return num;
        }
    }
}
