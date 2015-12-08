using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;

namespace CNDC.BLL
{
    public class CommentMgr
    {
        #region Singleton
        private static CommentMgr _intance;
        public static CommentMgr Instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new CommentMgr();
                }
                return _intance;
            }
        }

        private CommentMgr()
        { 
        }
        #endregion Singleton

        Dictionary<string, Dictionary<string, string>> _comments = new Dictionary<string, Dictionary<string, string>>();
        public string GetMessage(string tableName, string column)
        {
            string result = string.Empty;
            Ensure(tableName);
            result = _comments[tableName][column];
            return result;
        }

        public Dictionary<string, string> GetMessage(string tableName)
        {
            Dictionary<string, string> resultado = null;
            Ensure(tableName);
            if (_comments.ContainsKey(tableName))
            {
                resultado = _comments[tableName];
            }
            return resultado;
        }

        const string COMMENTS_TABLE_NAME = "all_col_comments";
        private void Ensure(string tableName)
        {
            if (!_comments.ContainsKey(tableName))
            {
                OracleCommand command = Sesion.Instancia.Conexion.CrearCommand();
                command.CommandText = string.Format("SELECT * FROM {0} WHERE (owner IN (SELECT db_schema from p_quantum)) AND table_name = :table_name", COMMENTS_TABLE_NAME);
                command.Parameters.Add("table_name", OracleDbType.Varchar2, tableName, ParameterDirection.Input);
                try
                {
                    DataTable tablaComentarios = Sesion.Instancia.Conexion.EjecutarCmd(command);
                    Dictionary<string,string> columnComments=new Dictionary<string,string>();
                    _comments.Add(tableName, columnComments);
                    foreach (DataRow r in tablaComentarios.Rows)
                    {
                        if (!(r[3] is DBNull))
                        {
                            columnComments[(string)r[2]] = (string)r[3];
                        }
                    }
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("CNDC.DAL", ex);
                }
            }
        }
    }
}
