using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using CNDC.DAL;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class P_DEF_MensajeSincMgr : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( COD_MENSAJE )
            FROM P_DEF_MENSAJE
            WHERE COD_MENSAJE=:COD_MENSAJE";
            cmd.BindByName = true;
            cmd.Parameters.Add("COD_MENSAJE", row["COD_MENSAJE"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_DEF_MENSAJE
            (COD_MENSAJE,TEXTO_MENSAJE,SINC_VER) 
            VALUES(:COD_MENSAJE,:TEXTO_MENSAJE,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_DEF_MENSAJE SET 
            TEXTO_MENSAJE =:TEXTO_MENSAJE,
            SINC_VER=:SINC_VER
            WHERE COD_MENSAJE=:COD_MENSAJE
            ";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return P_DEF_Mensaje.NOMBRE_TABLA; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("COD_MENSAJE", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TEXTO_MENSAJE", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
