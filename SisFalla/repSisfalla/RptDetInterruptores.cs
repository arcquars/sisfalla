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
    class RptDetInterruptores : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS INTERRUPTOR,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_INTERRUP,
            CONCAT(CONCAT(SUBSTR(F_GF_OP_INTERRUPTOR.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_OP_INTERRUPTOR.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
            TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_APERTURA, 'DD/MM/YYYY hh24:mi:ss:FF3') AS FECHA_APERTURA,
            DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_APER,79,'M',80,'A',81,'R','-') AS TIPO_APERTURA,
            TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_CIERRE, 'DD/MM/YYYY hh24:mi:ss:FF3') AS FECHA_CIERRE,
            DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_CIERRE,79,'M',80,'A',81,'R','-') AS TIPO_CIERRE,
            DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_CIERRE,79,'NO',80,DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_APER,80,'SI','NO'),81,'NO','-') AS RECONECTADO,
            F_AP_PERSONA.SIGLA AS AGENTE,
            F_AC_COMPONENTE.PK_COD_COMPONENTE AS COD_COMPONENTE,
            P_AC_TIPOCOMPONENTE.DESCRIPCION_TIPO AS TIPO_COMPONENTE,
            TO_DATE(TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_APERTURA,'DD/MM/YYYY'),'DD/MM/YYYY') AS FECHAINI_FILTRO,
            '' AS CAMPO1,
            '' AS CAMPO2
            FROM
            F_GF_OP_INTERRUPTOR
            LEFT JOIN F_AC_COMPONENTE ON F_GF_OP_INTERRUPTOR.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
            LEFT JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            LEFT JOIN P_AC_TIPOCOMPONENTE ON F_AC_COMPONENTE.D_TIPO_COMPONENTE = P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE AND P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE != 0
            WHERE
            F_GF_OP_INTERRUPTOR.PK_ORIGEN_INFORME=:COD_ORIGEN
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
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "FallasInterruptores");
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
