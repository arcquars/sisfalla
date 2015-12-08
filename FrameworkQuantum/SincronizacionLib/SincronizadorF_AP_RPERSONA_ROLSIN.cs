using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AP_RPERSONA_ROLSIN : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( PK_COD_PERSONA )
            FROM F_AP_RPERSONA_ROLSIN
            WHERE PK_COD_PERSONA=:PK_COD_PERSONA";
            cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_PERSONA", row["PK_COD_PERSONA"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            /*
             * PK_COD_PERSONA
PK_COD_ROL
D_COD_ESTADO
FEC_INGRESO
FEC_SALIDA
SEC_LOG
SINC_VER
             * 
             * PK_COD_PERSONA
PK_COD_ROL
D_COD_ESTADO
FEC_INGRESO
FEC_SALIDA
SEC_LOG
SINC_VER
             */
            string sql = @"INSERT
                    INTO F_AP_RPERSONA_ROLSIN
                      (
                        PK_COD_PERSONA,
                        PK_COD_ROL,
                        D_COD_ESTADO,
                        FEC_INGRESO,
                        FEC_SALIDA,
                        SEC_LOG,
                        SINC_VER
                      )
                      VALUES
                      (
                        :PK_COD_PERSONA,
                        :PK_COD_ROL,
                        :D_COD_ESTADO,
                        :FEC_INGRESO,
                        :FEC_SALIDA,
                        :SEC_LOG,
                        :SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AP_RPERSONA_ROLSIN SET 
            FEC_INGRESO=:FEC_INGRESO,
            FEC_SALIDA=:FEC_SALIDA,
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            SINC_VER=:SINC_VER
            WHERE PK_COD_PERSONA=:PK_COD_PERSONA
            and PK_COD_ROL=:PK_COD_ROL
";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "F_AP_RPERSONA_ROLSIN"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            /*:PK_COD_PERSONA,
                        :PK_COD_ROL,
                        :D_COD_ESTADO,
                        :FEC_INGRESO,
                        :FEC_SALIDA,
                        :SEC_LOG,
                        :SINC_VER
             * */
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_PERSONA", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_ROL", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FEC_INGRESO", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FEC_SALIDA", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
