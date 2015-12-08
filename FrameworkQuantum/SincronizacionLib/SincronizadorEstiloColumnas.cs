using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.Pistas;
using CNDC.BLL;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorEstiloColumnas :  OraDalBaseMgr, IMgrLocal
    {
        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_GF_ESTILOCOLUMNAS(DGVCOLUMN,TEXTO_COLUMNA,FORMATO_COLUMNA,
            ALINEACION_COLUMNA,ANCHO_COLUMNA,MULTILINEA_COLUMNA,SINC_VER) 
            VALUES(:DGVCOLUMN,:TEXTO_COLUMNA,:FORMATO_COLUMNA,
            :ALINEACION_COLUMNA,:ANCHO_COLUMNA,:MULTILINEA_COLUMNA,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_GF_ESTILOCOLUMNAS 
            SET 
            TEXTO_COLUMNA=:TEXTO_COLUMNA,
            FORMATO_COLUMNA=:FORMATO_COLUMNA,
            ALINEACION_COLUMNA=:ALINEACION_COLUMNA,
            ANCHO_COLUMNA=:ANCHO_COLUMNA,
            MULTILINEA_COLUMNA=:MULTILINEA_COLUMNA,
            SINC_VER=:SINC_VER
            WHERE DGVCOLUMN=:DGVCOLUMN";
            InsertUpdate(rows, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("DGVCOLUMN", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TEXTO_COLUMNA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FORMATO_COLUMNA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ALINEACION_COLUMNA", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ANCHO_COLUMNA", OracleDbType.Int32, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("MULTILINEA_COLUMNA", OracleDbType.Int32, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return "P_GF_ESTILOCOLUMNAS"; }
        }

        public bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = true;
            return resultado;
        }
    }
}
