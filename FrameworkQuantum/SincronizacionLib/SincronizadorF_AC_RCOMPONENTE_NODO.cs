using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AC_RCOMPONENTE_NODO : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( * )
            FROM F_AC_RCOMPONENTE_NODO
             WHERE PK_COD_COMPONENTE = :PK_COD_COMPONENTE
                            AND PK_COD_NODO         = :PK_COD_NODO
                            AND D_COD_TIPO_RELACION = :D_COD_TIPO_RELACION
                            AND FECHA_INGRESO       = :FECHA_INGRESO";
            cmd.BindByName = true;

             
            cmd.Parameters.Add("PK_COD_COMPONENTE", row["PK_COD_COMPONENTE"]);
            cmd.Parameters.Add("PK_COD_NODO", row["PK_COD_NODO"]);
            cmd.Parameters.Add("D_COD_TIPO_RELACION", row["D_COD_TIPO_RELACION"]);
            cmd.Parameters.Add("FECHA_INGRESO", row["FECHA_INGRESO"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT
                            INTO F_AC_RCOMPONENTE_NODO
                              (
                                PK_COD_COMPONENTE,
                                PK_COD_NODO,
                                D_COD_TIPO_RELACION,
                                FECHA_INGRESO,
                                FECHA_SALIDA,
                                SEC_LOG,
                                SINC_VER
                              )
                              VALUES
                              (
                                :PK_COD_COMPONENTE,
                                :PK_COD_NODO,
                                :D_COD_TIPO_RELACION,
                                :FECHA_INGRESO,
                                :FECHA_SALIDA,
                                :SEC_LOG,
                                :SINC_VER
                              ) ";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE F_AC_RCOMPONENTE_NODO
                            SET  FECHA_SALIDA        = :FECHA_SALIDA        
                            , SEC_LOG             = :SEC_LOG
                            , SINC_VER            = :SINC_VER
                            WHERE PK_COD_COMPONENTE = :PK_COD_COMPONENTE
                            AND PK_COD_NODO         = :PK_COD_NODO
                            AND D_COD_TIPO_RELACION = :D_COD_TIPO_RELACION
                            AND FECHA_INGRESO       = :FECHA_INGRESO
                                        ";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AC_RCOMPONENTE_NODO"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;

            /*
             *  :PK_COD_COMPONENTE,
                                :PK_COD_NODO,
                                :D_COD_TIPO_RELACION,
                                :FECHA_INGRESO,
                                :FECHA_SALIDA,
                                :SEC_LOG,
                                :SINC_VER
             */
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_COMPONENTE", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("PK_COD_NODO", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_TIPO_RELACION", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_INGRESO", OracleDbType.Date , tabla));
            cmd.Parameters.Add(CrearParametroEntrada("FECHA_SALIDA", OracleDbType.Date, tabla));

          
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));

            Actualizar(cmd);
        }
    }
}
