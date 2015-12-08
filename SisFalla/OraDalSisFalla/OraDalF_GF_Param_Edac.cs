using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.Sincronizacion;
using CNDC.BLL;
using System.Data;
using CNDC.DAL;
using Oracle.DataAccess.Client;

namespace OraDalSisFalla
{
    public class OraDalF_GF_Param_Edac : OraDalBaseMgr, IMgrLocal
    {
        public OraDalF_GF_Param_Edac()
        {

        }
        public OraDalF_GF_Param_Edac(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Insertar(List<DataRow> rows)
        {
            string sqlInsert =
            @"INSERT INTO F_GF_PARAM_EDAC
            (
                PK_COD_EDAC,
                TIPO_EDAC,
                AJUSTE_EDAC,
                ETAPA_EDAC,
                FECHA_EDAC,
            )
            VALUES
            (
                :PK_COD_EDAC,
                :TIPO_EDAC,
                :AJUSTE_EDAC,
                :ETAPA_EDAC,
                :FECHA_EDAC,
            )";

            InsertUpdate(rows, sqlInsert);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sqlUpdate =
            @"UPDATE F_GF_PARAM_EDAC
            SET 
            TIPO_EDAC     = :TIPO_EDAC,
            AJUSTE_EDAC   = :AJUSTE_EDAC,
            ETAPA_EDAC    = :ETAPA_EDAC,
            FECHA_EDAC    = :FECHA_EDAC
            WHERE PK_COD_EDAC = :PK_COD_EDAC
            ";
            InsertUpdate(rows, sqlUpdate);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_EDAC", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TIPO_EDAC", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("AJUSTE_EDAC", OracleDbType.Single, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ETAPA_EDAC", OracleDbType.Single, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_EDAC", OracleDbType.Date, tabla));

            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return "F_GF_PARAM_EDAC"; }
        }
    }
}
