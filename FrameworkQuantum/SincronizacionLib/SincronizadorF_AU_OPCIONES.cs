using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AU_OPCIONES : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( NUM_OPCION )
            FROM F_AU_OPCIONES
            WHERE NUM_OPCION=:NUM_OPCION";
            cmd.BindByName = true;
            cmd.Parameters.Add("NUM_OPCION", row["NUM_OPCION"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO F_AU_OPCIONES
            (NUM_OPCION,DESCRIPCION_OPCION,D_TIPO_OPCION_MENU,NIVEL,NUM_OPCION_MADRE,ORDEN_VISTA,TIPO_OPCION,
            D_COD_ESTADO,SEC_LOG,SINC_VER,ENSAMBLADO,CLASE,ICON,PARAMETRO,FK_COD_MODULO) 
            VALUES(:NUM_OPCION,:DESCRIPCION_OPCION,:D_TIPO_OPCION_MENU,:NIVEL,:NUM_OPCION_MADRE,:ORDEN_VISTA,:TIPO_OPCION,
            :D_COD_ESTADO,:SEC_LOG,:SINC_VER,:ENSAMBLADO,:CLASE,:ICON,:PARAMETRO,:FK_COD_MODULO) ";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AU_OPCIONES SET 
            DESCRIPCION_OPCION=:DESCRIPCION_OPCION,
            D_TIPO_OPCION_MENU=:D_TIPO_OPCION_MENU,
            NIVEL=:NIVEL,
            NUM_OPCION_MADRE=:NUM_OPCION_MADRE,
            ORDEN_VISTA=:ORDEN_VISTA,
            TIPO_OPCION=:TIPO_OPCION,
            D_COD_ESTADO=:D_COD_ESTADO,
            SEC_LOG=:SEC_LOG,
            SINC_VER=:SINC_VER,
            ENSAMBLADO=:ENSAMBLADO,
            CLASE=:CLASE,
            ICON=:ICON,
            PARAMETRO=:PARAMETRO,
            FK_COD_MODULO=:FK_COD_MODULO
            WHERE NUM_OPCION=:NUM_OPCION";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AU_OPCIONES"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("NUM_OPCION", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DESCRIPCION_OPCION", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_TIPO_OPCION_MENU", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NIVEL", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NUM_OPCION_MADRE", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ORDEN_VISTA", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("TIPO_OPCION", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ENSAMBLADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("CLASE", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("ICON", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PARAMETRO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FK_COD_MODULO", OracleDbType.Int64, tabla));
            

            Actualizar(cmd);
        }
    }
}
