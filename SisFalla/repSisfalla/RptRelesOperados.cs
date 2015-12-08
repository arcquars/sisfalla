using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.Dominios;

namespace repSisfalla
{
    class RptRelesOperados : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_APERTURA, 'DD/MM/YYYY hh24:mi:ss') AS FECHA_APERTURA,
            transform_codfalla(F_GF_OP_INTERRUPTOR.PK_COD_FALLA) AS NUM_FALLA,
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS COD_INTERRUP,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESC_INTERRUP,
            F_GF_RELES_OPER.TIPO_RELE AS RELE,
            F_GF_RELES_OPER.TIEMPO_RELE AS TIEMPO_RELE,
            F_GF_RELES_OPER.ZONA_RELE AS ZONA_RELE,
            F_GF_RELES_OPER.DISTANCIA_RELE AS DISTANCIA_RELE,
            F_GF_RELES_OPER.FUNCION_RELE AS FUNCION_RELE,
            F_AP_PERSONA.SIGLA AS AGENTE,
            TO_DATE(TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_APERTURA,'DD/MM/YYYY hh24:mi:ss'),'DD/MM/YYYY hh24:mi:ss') AS FECHAINI_FILTRO,
            '' AS CAMPO1,
            '' AS CAMPO2
            FROM
            F_GF_OP_INTERRUPTOR
            LEFT JOIN F_GF_RELES_OPER ON F_GF_OP_INTERRUPTOR.PK_COD_FALLA = F_GF_RELES_OPER.PK_COD_FALLA AND F_GF_OP_INTERRUPTOR.PK_ORIGEN_INFORME = F_GF_RELES_OPER.PK_ORIGEN_INFORME AND F_GF_OP_INTERRUPTOR.PK_COD_COMPONENTE = F_GF_RELES_OPER.PK_COD_COMPONENTE AND F_GF_OP_INTERRUPTOR.PK_D_COD_TIPOINFORME = F_GF_RELES_OPER.PK_D_COD_TIPOINFORME AND F_GF_OP_INTERRUPTOR.FECHA_APERTURA = F_GF_RELES_OPER.FEC_APERTURA 
            LEFT JOIN F_AC_COMPONENTE ON F_GF_OP_INTERRUPTOR.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
            LEFT JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            WHERE
            F_GF_OP_INTERRUPTOR.PK_ORIGEN_INFORME = :COD_ORIGEN 
            AND (F_GF_OP_INTERRUPTOR.PK_COD_FALLA, F_GF_OP_INTERRUPTOR.PK_D_COD_TIPOINFORME) IN 
            (
            SELECT R.PK_COD_FALLA, R.ULTIMO_ESTADO AS PK_D_COD_TIPOINFORME from v_gf_rregfalla_ultimoestado R
            WHERE
            R.ultimo_estado in (21,22)
            )
            ";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_ORIGEN", 7);
            //cmd.Parameters.Add("COD_TIPOINFORME", (long)PK_D_COD_TIPOINFORME.FINAL);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "RelesOperados");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Parametros;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
