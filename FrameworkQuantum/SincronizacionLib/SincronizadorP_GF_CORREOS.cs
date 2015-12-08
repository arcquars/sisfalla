using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorP_GF_CORREOS : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( PK_COD_CORREO )
            FROM P_GF_CORREOS
            WHERE PK_COD_CORREO=:PK_COD_CORREO";
            cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_CORREO", row["PK_COD_CORREO"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_GF_CORREOS
            (PK_COD_CORREO,D_COD_SECC_CORREO,FK_TRANSACCION,D_COD_ESTADO,TEXTO,SINC_VER) 
            VALUES(:PK_COD_CORREO,:D_COD_SECC_CORREO,:FK_TRANSACCION,:D_COD_ESTADO,:TEXTO,:SINC_VER) ";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_GF_CORREOS SET 
            D_COD_SECC_CORREO=:D_COD_SECC_CORREO,
            FK_TRANSACCION=:FK_TRANSACCION,
            D_COD_ESTADO=:D_COD_ESTADO,
            TEXTO=:TEXTO,
            SINC_VER=:SINC_VER
            WHERE PK_COD_CORREO=:PK_COD_CORREO";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "P_GF_CORREOS"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_CORREO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_SECC_CORREO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FK_TRANSACCION", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TEXTO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
