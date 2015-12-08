 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AC_NODO : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( PK_COD_NODO )
            FROM F_AC_NODO
            WHERE PK_COD_NODO=:PK_COD_NODO";
            cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_NODO", row["PK_COD_NODO"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @" INSERT
INTO F_AC_NODO
  (
    PK_COD_NODO,
    PK_NIVEL_TENSION,
    D_COD_AREA,
    SIGLA_NODO,
    NOMBRE_NODO,
    DESCRIPCION_NODO,
    D_COD_ESTADO,
    SEC_LOG,
    SINC_VER,
    FECHA_INGRESO,
    FECHA_SALIDA
  )
  VALUES
  (
    :PK_COD_NODO,
    :PK_NIVEL_TENSION,
    :D_COD_AREA,
    :SIGLA_NODO,
    :NOMBRE_NODO,
    :DESCRIPCION_NODO,
    :D_COD_ESTADO,
    :SEC_LOG,
    :SINC_VER,
    :FECHA_INGRESO,
    :FECHA_SALIDA
  )";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AC_NODO
                            SET PK_NIVEL_TENSION = :PK_NIVEL_TENSION ,
                              D_COD_AREA         = :D_COD_AREA ,
                              SIGLA_NODO         = :SIGLA_NODO ,
                              NOMBRE_NODO        = :NOMBRE_NODO ,
                              DESCRIPCION_NODO   = :DESCRIPCION_NODO ,
                              D_COD_ESTADO       = :D_COD_ESTADO ,
                              SEC_LOG            = :SEC_LOG ,
                              SINC_VER           = :SINC_VER ,
                              FECHA_INGRESO      = :FECHA_INGRESO ,
                              FECHA_SALIDA       = :FECHA_SALIDA
                            WHERE PK_COD_NODO    = :PK_COD_NODO            ";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AC_NODO"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;

            /*
              :PK_COD_NODO,
    :PK_NIVEL_TENSION,
    :D_COD_AREA,
    :SIGLA_NODO,
    :NOMBRE_NODO,
    :DESCRIPCION_NODO,
    :D_COD_ESTADO,
    :SEC_LOG,
    :SINC_VER,
    :FECHA_INGRESO,
    :FECHA_SALIDA
             */
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_NODO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_NIVEL_TENSION", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_AREA", OracleDbType.Int64, tabla));

            cmd.Parameters.Add(CrearParametroEntrada("SIGLA_NODO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("NOMBRE_NODO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("DESCRIPCION_NODO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            cmd.Parameters.Add(CrearParametroEntrada("FECHA_INGRESO", OracleDbType.Date, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_SALIDA", OracleDbType.Date, tabla));

            Actualizar(cmd);
        }
    }
}