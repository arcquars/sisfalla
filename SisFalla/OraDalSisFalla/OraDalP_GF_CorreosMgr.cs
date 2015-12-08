using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.Dominios;
using CNDC.BLL;

namespace OraDalSisFalla
{
    public class OraDalP_GF_CorreosMgr : OraDalBaseMgr, IP_GF_CorreosMgr
    {
        public OraDalP_GF_CorreosMgr()
        {

        }
        public OraDalP_GF_CorreosMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(P_GF_Correos obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{1}=:{1} ," +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE ";
            }

            sql = string.Format(sql, P_GF_Correos.NOMBRE_TABLA, P_GF_Correos.C_PK_COD_CORREO,
            P_GF_Correos.C_D_COD_SECC_CORREO,
            P_GF_Correos.C_FK_TRANSACCION,
            P_GF_Correos.C_D_COD_ESTADO,
            P_GF_Correos.C_TEXTO,
            P_GF_Correos.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(P_GF_Correos.C_PK_COD_CORREO, OracleDbType.Int64, obj.PkCodCorreo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Correos.C_D_COD_SECC_CORREO, OracleDbType.Int64, obj.DCodSeccCorreo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Correos.C_FK_TRANSACCION, OracleDbType.Int64, obj.FkTransaccion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Correos.C_D_COD_ESTADO, OracleDbType.Int64, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Correos.C_TEXTO, OracleDbType.Varchar2, obj.Texto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Correos.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(P_GF_Correos.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<P_GF_Correos> GetLista()
        {
            BindingList<P_GF_Correos> resultado = new BindingList<P_GF_Correos>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new P_GF_Correos(row));
            }
            return resultado;
        }

        public P_GF_Correos Get(long pkCodTransac, D_COD_SECC_CORREO d_COD_SECC_CORREO)
        {
            P_GF_Correos resultado = null;
            string sql =
            @"SELECT a.*
            FROM P_GF_CORREOS a
            WHERE 
            a.fk_transaccion=:fk_transaccion
            AND a.d_cod_secc_correo=:d_cod_secc_correo";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("fk_transaccion", OracleDbType.Int64, pkCodTransac, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_secc_correo", OracleDbType.Int64, (long) d_COD_SECC_CORREO, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new P_GF_Correos(tabla.Rows[0]);
            }

            return resultado;
        }
    }
}
