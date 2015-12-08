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
    class RptEleCompometidos : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS COMPONENTE,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
            CONCAT(CONCAT(SUBSTR(F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
            TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS') AS FECHA_FALLA,
            F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DESC,
            DECODE(UPPER(F_GF_RREGFALLA_COMPONENTE.FLUJO_N1_N2),'NEGATIVO','-' || F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA,F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA) AS POT_DESC_REP,
            F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD AS INDISP,
            F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION AS PRECONEX,
            F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS CONEX,
            F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD + F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION + F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS TTOTAL_DESCONEXION,
            F_AP_PERSONA.SIGLA AS AGENTE,
            F_AC_COMPONENTE.PK_COD_COMPONENTE AS COD_COMPONENTE,
            P_AC_TIPOCOMPONENTE.DESCRIPCION_TIPO AS TIPO_COMPONENTE,
            TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY'),'DD/MM/YYYY') AS CAMPO1,
            '' AS CAMPO2
            FROM
            F_GF_RREGFALLA_COMPONENTE
            LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
            LEFT JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            LEFT JOIN P_AC_TIPOCOMPONENTE ON F_AC_COMPONENTE.D_TIPO_COMPONENTE = P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE AND P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE != 0
            WHERE
            F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME=:COD_ORIGEN 
            AND (F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA, F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME) IN 
            (
            SELECT R.PK_COD_FALLA, R.ULTIMO_ESTADO AS PK_D_COD_TIPOINFORME from v_gf_rregfalla_ultimoestado R
            WHERE
            R.ultimo_estado in (21,22)
            )
            ";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_ORIGEN", 7);
            //cmd.Parameters.Add("COD_TIPOINFORME", (long)PK_D_COD_TIPOINFORME.FINAL);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "ElementosComprometidos");
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
