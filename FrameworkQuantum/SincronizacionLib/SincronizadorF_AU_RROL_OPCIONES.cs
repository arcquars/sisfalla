using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using System.Data;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AU_RROL_OPCIONES : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( * )
            FROM F_AU_RROL_OPCIONES
            WHERE NUM_ROL=:NUM_ROL
            AND NUM_OPCION=:NUM_OPCION";
            cmd.BindByName = true;
            cmd.Parameters.Add("NUM_ROL", row["NUM_ROL"]);
            cmd.Parameters.Add("NUM_OPCION", row["NUM_OPCION"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO F_AU_RROL_OPCIONES(NUM_ROL,NUM_OPCION,D_COD_ESTADO,SEC_LOG,SINC_VER)
            VALUES(:NUM_ROL,:NUM_OPCION,:D_COD_ESTADO,:SEC_LOG,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AU_RROL_OPCIONES SET 
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            SINC_VER=:SINC_VER
            WHERE NUM_ROL=:NUM_ROL
            AND NUM_OPCION=:NUM_OPCION";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AU_RROL_OPCIONES"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("NUM_ROL", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NUM_OPCION", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));


            Actualizar(cmd);
        }
    }
}
