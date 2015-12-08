using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AP_RCONTACTO : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( PK_COD_CONTACTO )
            FROM F_AP_RCONTACTO
            WHERE PK_COD_EMPRESA=:PK_COD_EMPRESA
            AND PK_COD_CONTACTO=:PK_COD_CONTACTO";
            cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_EMPRESA", row["PK_COD_EMPRESA"]);
            cmd.Parameters.Add("PK_COD_CONTACTO", row["PK_COD_CONTACTO"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO F_AP_RCONTACTO
            (PK_COD_EMPRESA,PK_COD_CONTACTO,D_COD_ESTADO,CARGO,CELULAR,
            EMAIL,EMAIL2,FEC_SALIDA,FEC_INGRESO,FK_COD_MODULO,SEC_LOG,SINC_VER) 
            VALUES(:PK_COD_EMPRESA,:PK_COD_CONTACTO,:D_COD_ESTADO,:CARGO,:CELULAR,
            :EMAIL,:EMAIL2,:FEC_SALIDA,:FEC_INGRESO,:FK_COD_MODULO,:SEC_LOG,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AP_RCONTACTO SET 
            CARGO=:CARGO,
            CELULAR=:CELULAR,
            EMAIL=:EMAIL,
            EMAIL2=:EMAIL2,
            FEC_SALIDA=:FEC_SALIDA,
            FEC_INGRESO=:FEC_INGRESO,
            FK_COD_MODULO=:FK_COD_MODULO,
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            SINC_VER=:SINC_VER
            WHERE PK_COD_EMPRESA=:PK_COD_EMPRESA
            AND PK_COD_CONTACTO=:PK_COD_CONTACTO";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "F_AP_RCONTACTO"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_EMPRESA", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_CONTACTO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("CARGO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("CELULAR", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("EMAIL", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("EMAIL2", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FEC_SALIDA", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FEC_INGRESO", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FK_COD_MODULO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}