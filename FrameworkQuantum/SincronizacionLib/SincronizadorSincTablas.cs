using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace CNDC.Sincronizacion
{
    public class SincronizadorSincTablas : OraDalBaseMgr, IMgrLocal
    {
        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_SINC_TABLAS(SINC_ORDER,NOMBRE_TABLA,SINC_VER)
            VALUES(:SINC_ORDER,:NOMBRE_TABLA,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_SINC_TABLAS SET 
            SINC_ORDER=:SINC_ORDER,
            SINC_VER=:SINC_VER
            WHERE NOMBRE_TABLA=:NOMBRE_TABLA";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "P_SINC_TABLAS"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("SINC_ORDER", OracleDbType.Decimal, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NOMBRE_TABLA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
