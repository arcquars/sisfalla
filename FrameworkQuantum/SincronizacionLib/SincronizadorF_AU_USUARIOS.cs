using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using System.Data;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AU_USUARIOS : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( LOGIN )
            FROM F_AU_USUARIOS
            WHERE LOGIN=:LOGIN";
            cmd.BindByName = true;
            cmd.Parameters.Add("LOGIN", row["LOGIN"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO F_AU_USUARIOS
            (LOGIN,CELULAR,D_COD_ESTADO,SEC_LOG,PIN,D_COD_ESTADO_AUT,PK_COD_USUARIO,SINC_VER) 
            VALUES(:LOGIN,:CELULAR,:D_COD_ESTADO,:SEC_LOG,:PIN,:D_COD_ESTADO_AUT,:PK_COD_USUARIO,:SINC_VER) ";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AU_USUARIOS SET 
            CELULAR=:CELULAR,
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            PIN=:PIN,
            D_COD_ESTADO_AUT=:D_COD_ESTADO_AUT,
            PK_COD_USUARIO=:PK_COD_USUARIO,
            SINC_VER=:SINC_VER
            WHERE LOGIN=:LOGIN";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "F_AU_USUARIOS"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("LOGIN", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("CELULAR", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PIN", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO_AUT", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_USUARIO", OracleDbType.Decimal, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
