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
    public class SincronizadorUiControl : OraDalBaseMgr, IMgrLocal
    {
        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_GF_UI_CONTROL(COD_CONTROL,NOMBRE_CONTROL,TIPO_CONTROL,COD_PADRE_CONTROL,SINC_VER) 
            VALUES(:COD_CONTROL,:NOMBRE_CONTROL,:TIPO_CONTROL,:COD_PADRE_CONTROL,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_GF_UI_CONTROL SET 
            COD_CONTROL=:COD_CONTROL,
            COD_PADRE_CONTROL=:COD_PADRE_CONTROL,
            SINC_VER=:SINC_VER
            WHERE NOMBRE_CONTROL=:NOMBRE_CONTROL
            AND TIPO_CONTROL=:TIPO_CONTROL";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "P_GF_UI_CONTROL"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("COD_CONTROL", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NOMBRE_CONTROL", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TIPO_CONTROL", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("COD_PADRE_CONTROL", OracleDbType.Int32, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
