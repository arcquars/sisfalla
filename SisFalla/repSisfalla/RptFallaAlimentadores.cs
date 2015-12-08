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
    class RptFallaAlimentadores : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS ALIMENTADOR,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESC_ALIMENTADOR,
            CONCAT(CONCAT(SUBSTR(F_GF_OP_ALIMENTADOR.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_OP_ALIMENTADOR.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
            DECODE(F_GF_OP_ALIMENTADOR.RELE_OPERADO,0,'NO',1,'SI','-') AS RELE_OPERADO,
            TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS') AS FECHA_APERTURA,
            TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS') AS FECHA_CIERRE,
            F_GF_OP_ALIMENTADOR.POT_DESC AS POT_DESC,
            ROUND(24*60*(to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') - to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS')),2) AS TIEMPO_DESC,
            ROUND((ROUND((ROUND(24*60*(to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') - to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS')),2)*F_GF_OP_ALIMENTADOR.POT_DESC),2)/60),2) AS ENERGIA_NOSUMIN,
            DOM_PROPIETARIO.SIGLA AS AGENTE_PROPI,
            TO_DATE(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY hh24:mi:ss'),'DD/MM/YYYY hh24:mi:ss') AS FECHAINI_FILTRO,
            F_GF_PARAM_EDAC.TIPO_EDAC AS CAMPO1,
            '' AS CAMPO2

            FROM
            F_GF_OP_ALIMENTADOR
            LEFT JOIN F_AC_COMPONENTE ON F_GF_OP_ALIMENTADOR.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
            LEFT JOIN F_AP_PERSONA DOM_PROPIETARIO ON F_AC_COMPONENTE.PROPIETARIO = DOM_PROPIETARIO.PK_COD_PERSONA
            LEFT JOIN F_GF_PARAM_EDAC ON F_GF_OP_ALIMENTADOR.COD_EDAC = F_GF_PARAM_EDAC.PK_COD_EDAC
            LEFT JOIN F_GF_REGFALLA ON F_GF_OP_ALIMENTADOR.PK_COD_FALLA = F_GF_REGFALLA.PK_COD_FALLA
            WHERE
            F_GF_OP_ALIMENTADOR.PK_ORIGEN_INFORME=:COD_ORIGEN 
            AND (F_GF_OP_ALIMENTADOR.PK_COD_FALLA, F_GF_OP_ALIMENTADOR.PK_D_COD_TIPOINFORME) IN 
            (
            SELECT R.PK_COD_FALLA, R.ULTIMO_ESTADO AS PK_D_COD_TIPOINFORME from v_gf_rregfalla_ultimoestado R
            WHERE
            R.ultimo_estado in (21,22)
            )
            ";


            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_ORIGEN", 7);
            //cmd.Parameters.Add("COD_TIPOINFORME", (long)PK_D_COD_TIPOINFORME.FINAL);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "FallaAlimentadores");
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
