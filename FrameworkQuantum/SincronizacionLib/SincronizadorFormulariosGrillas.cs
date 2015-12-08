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
    public class SincronizadorFormulariosGrillas : OraDalBaseMgr, IMgrLocal
    {
        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_GF_FORMULARIOSGRILLAS(FORM,DATAGRIDVIEW,DGVCOLUMN,DISLPLAYINDEX,SINC_VER) 
            VALUES(:FORM,:DATAGRIDVIEW,:DGVCOLUMN,:DISLPLAYINDEX,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_GF_FORMULARIOSGRILLAS SET 
            DISLPLAYINDEX=:DISLPLAYINDEX,
            SINC_VER=:SINC_VER
            WHERE FORM=:FORM
            AND DATAGRIDVIEW=:DATAGRIDVIEW
            AND DGVCOLUMN=:DGVCOLUMN";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "P_GF_FORMULARIOSGRILLAS"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("FORM", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DATAGRIDVIEW", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DGVCOLUMN", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DISLPLAYINDEX", OracleDbType.Int32, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }

    }
}
