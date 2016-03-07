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
    public class Sincronizador_F_QNT_SYNC : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( pk_cod_sync )
            FROM f_qnt_sync
            WHERE pk_cod_sync=:pk_cod_sync";
            cmd.BindByName = true;
            cmd.Parameters.Add("pk_cod_sync", row["pk_cod_sync"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO f_qnt_sync
            (pk_cod_sync,comando_sincro,fecha_publicacion_sincro,fecha_ejecucion,
            estado,sinc_ver) 
            values(:pk_cod_sync,:comando_sincro,:fecha_publicacion_sincro,:fecha_ejecucion,
            :estado,:sinc_ver)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE f_qnt_sync SET 
            comando_sincro=:comando_sincro,
            fecha_publicacion_sincro=:fecha_publicacion_sincro,
            fecha_ejecucion=:fecha_ejecucion,
            estado=:estado,
            sinc_ver=:sinc_ver
            WHERE pk_cod_sync=:pk_cod_sync";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_QNT_SYNC"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("pk_cod_sync", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("comando_sincro", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("fecha_publicacion_sincro", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("fecha_ejecucion", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("estado", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("sinc_ver", OracleDbType.Int64, tabla));

            if (Actualizar(cmd))
            {
                PistaMgr.Instance.Error("Sincronizador_F_QNT_SYNC", "Actualizando f_qnt_sync");
                bool resultado = true;
                CNDC.DAL.ConnexionOracleMgr conexion = new DAL.ConnexionOracleMgr("USER ID=quantum;DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=xe)));PASSWORD=quantum;PERSIST SECURITY INFO=true;");
                cmd = conexion.CrearCommand();
                cmd.CommandText = "ejecutar_f_qnt_sync";
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("Sincronizador_F_QNT_SYNC", ex);
                    resultado = false;
                }
                finally
                {
                    conexion.DisposeCommand(cmd);
                }
            }
        }
    }
}
