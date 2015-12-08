using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;

namespace CNDC.Sincronizacion
{
    public class SincronizadorImagenesSistema : OraDalBaseMgr, IMgrLocal
    {
        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO P_IMAGENES_SISTEMA(ID,DESCRIPCION,TIPO,ARCHIVO,SINC_VER) 
            VALUES(:ID,:DESCRIPCION,:TIPO,:ARCHIVO,:SINC_VER)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE P_IMAGENES_SISTEMA SET 
            DESCRIPCION=:DESCRIPCION,
            TIPO=:TIPO,
            ARCHIVO=:ARCHIVO,
            SINC_VER=:SINC_VER
            WHERE ID=:ID";
            InsertUpdate(rows, sql);
        }

        public string NombreTabla
        {
            get { return "P_IMAGENES_SISTEMA"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("ID", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DESCRIPCION", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TIPO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ARCHIVO", OracleDbType.Blob, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
