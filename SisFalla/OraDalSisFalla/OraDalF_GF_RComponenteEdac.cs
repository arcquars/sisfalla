using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using CNDC.Sincronizacion;
using CNDC.DAL;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraDalSisFalla
{
    public class OraDalF_GF_RComponenteEdac: OraDalBaseMgr, IMgrLocal
    {
        public OraDalF_GF_RComponenteEdac()
        {

        }
        public OraDalF_GF_RComponenteEdac(ConnexionOracleMgr c)
            : base(c)
        { }


        public void Insertar(List<DataRow> rows)
        {
            string sql =
            @"INSERT INTO F_GF_RCOMPONENTE_EDAC
              (
                PK_COD_COMPONENTE,
                PK_COD_EDAC,
                FECHA_INICIO,
                FECHA_FIN,
                SINC_VER
              )
              VALUES
              (
                :PK_COD_COMPONENTE,
                :PK_COD_EDAC,
                :FECHA_INICIO,
                :FECHA_FIN,
                :SINC_VER
              )"; 
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql =
            @"UPDATE F_GF_RCOMPONENTE_EDAC
            SET FECHA_FIN           =:FECHA_FIN,
            SINC_VER=:SINC_VER
            WHERE 
            PK_COD_COMPONENTE       = :PK_COD_COMPONENTE
            AND PK_COD_EDAC         = :PK_COD_EDAC
            AND FECHA_INICIO        = :FECHA_INICIO";
            InsertUpdate(rows, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_COMPONENTE", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_EDAC", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_INICIO", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_FIN", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return "F_GF_RCOMPONENTE_EDAC"; }
        }
    }
}
