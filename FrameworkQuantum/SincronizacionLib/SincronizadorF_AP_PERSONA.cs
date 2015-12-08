using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AP_PERSONA : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( PK_COD_PERSONA )
            FROM F_AP_PERSONA
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
            string sql = @"INSERT INTO F_AP_PERSONA
            (PK_COD_PERSONA,NOM_PERSONA,SIGLA,D_COD_TIPO_PERSONA,DIRECCION,TELEFONO,
            IDENTIFICACION,D_COD_ESTADO,SEC_LOG,SINC_VER) 
            VALUES(:PK_COD_PERSONA,:NOM_PERSONA,:SIGLA,:D_COD_TIPO_PERSONA,:DIRECCION,:TELEFONO,
            :IDENTIFICACION,:D_COD_ESTADO,:SEC_LOG,:SINC_VER) ";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AP_PERSONA SET 
            NOM_PERSONA =:NOM_PERSONA,
            SIGLA=:SIGLA,
            D_COD_TIPO_PERSONA=:D_COD_TIPO_PERSONA,
            DIRECCION=:DIRECCION,
            TELEFONO=:TELEFONO,
            IDENTIFICACION=:IDENTIFICACION,
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            SINC_VER=:SINC_VER
            WHERE PK_COD_PERSONA=:PK_COD_PERSONA
            ";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AP_PERSONA"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_PERSONA", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NOM_PERSONA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SIGLA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_TIPO_PERSONA", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DIRECCION", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TELEFONO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("IDENTIFICACION", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
