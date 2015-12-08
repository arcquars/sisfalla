using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using ModeloProyectos;
using CNDC.DAL;

namespace OraDalProyectos
{
    public class IdMgr : OraDalBaseMgr, IIdMgr
    {
        public IdMgr()
        {

        }

        public IdMgr(ConnexionOracleMgr c):base(c)
        {

        }


        public int GetID(string nombreTabla)
        {
            OracleCommand cmd = null;
            int idResultado = 1;
            string sql = "SELECT * FROM F_PR_INDICE WHERE PK_NOMBRE_INDICE='{0}'";
            sql = string.Format(sql, nombreTabla);
            try
            {
                DataTable tabla = EjecutarSql(sql);
                if (tabla.Rows.Count > 0)
                {
                    int Indice = int.Parse(tabla.Rows[0][1].ToString());
                    idResultado = Indice;
                }
                else
                {
                    cmd = CrearCommand();
                    sql = "INSERT INTO F_PR_INDICE (PK_NOMBRE_INDICE,INDICE) Values('{0}',{1})";
                    sql = string.Format(sql, nombreTabla, 1);
                    cmd.CommandText = sql;
                    bool res = Actualizar(cmd);
                }
                IncrementarId(nombreTabla);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return idResultado;
        }

        private void IncrementarId( string nombreTabla)
        {
            OracleCommand cmd = null;

            string sql = "UPDATE F_PR_INDICE "
            + "SET INDICE=(INDICE + 1) "
            + "WHERE PK_NOMBRE_INDICE='{0}'";

            sql = string.Format(sql, nombreTabla);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
       
    }
}
