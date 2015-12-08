using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using CNDC.Pistas;

namespace OraDalSisFalla
{
    public class OraDalP_GF_ConfiguracionMgr : OraDalBaseMgr, I_P_GF_ConfiguracionMgr
    {
        public DataTable GetConfiguraciones(long pkCodPersonaSeleccionada)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT a.pk_cod_persona,a.pk_cod_parametro, a.valor_CONFIGURACION , b.DESCRIPCION_DOMINIO as VAR_CONFIGURACION 
            FROM P_GF_CONFIG a,P_DEF_DOMINIOS b
            WHERE a.pk_cod_parametro = b.cod_dominio
            AND a.pk_cod_persona=:pk_cod_persona";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersonaSeleccionada, ParameterDirection.Input);

            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public void Guardar(P_GF_Configuracion obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3})" +
                "VALUES(:{1},:{2},:{3})";
            }
            else
            {
                sql = @"UPDATE {0} SET 
                {3}=:{3} 
                WHERE 
                {1}=:{1} AND 
                {2}=:{2} ";
            }

            sql = string.Format(sql,
            P_GF_Configuracion.NOMBRE_TABLA,
            P_GF_Configuracion.C_PK_COD_PERSONA,
            P_GF_Configuracion.C_PK_COD_PARAMETRO,
            P_GF_Configuracion.C_VALOR_CONFIGURACION);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(P_GF_Configuracion.C_PK_COD_PERSONA, OracleDbType.Int64, obj.CodPersona, ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Configuracion.C_PK_COD_PARAMETRO, OracleDbType.Int64, obj.CodDominio, ParameterDirection.Input);
            cmd.Parameters.Add(P_GF_Configuracion.C_VALOR_CONFIGURACION, OracleDbType.Varchar2, obj.Valor, ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
    }
}
