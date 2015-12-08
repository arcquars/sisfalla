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
    public class RptOperacionEdac : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string strSql = string.Empty;
            string sql =
            @"SELECT A.*,B.ORDEN AS ETAPA_EDAC, C.CAUSA AS CAUSA, C.DESCONEXION_COMPONENTE AS DESCONEX_DE, C.OBSERVACIONES AS OBSERVACIONES, D.DESCRIPCION_DOMINIO AS CAUSA_TIPO
            FROM
            (
            SELECT 
            A.PK_COD_FALLA AS NUM_FALLA,						
            F.SIGLA AS AGENTE,
            B.NOMBRE_COMPONENTE AS ALIMENTADOR,
            A.FECHA_APERTURA as FECHA_TOTAL,
            to_date(to_char(A.FECHA_APERTURA,'DD/MM/YYYY'),'DD/MM/YYYY') as FECHA,
            to_char(A.FECHA_APERTURA, 'HH24:MI') AS HORA,
            E.TIPO_EDAC AS ETAPA,
            E.AJUSTE_EDAC AS FREC,
						            nvl(A.POT_DESC,0) AS POTENCIA,
            DECODE(B.Propietario,9,1,3,2,8,3,10,4,2,5,4,6,22,7,19,8,5,9,18,10,100,11, NULL) AS ORDEN_PLAN

                        FROM 
            F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B,  f_gf_param_edac E,  F_AP_PERSONA F
                        WHERE A.PK_ORIGEN_INFORME={0} 
                        AND (A.PK_COD_FALLA, A.PK_D_COD_TIPOINFORME) IN 
            (
            SELECT R.PK_COD_FALLA, R.ULTIMO_ESTADO AS PK_D_COD_TIPOINFORME from v_gf_rregfalla_ultimoestado R
            WHERE
            R.ultimo_estado in (21,22)
            )
						            AND a.pk_cod_componente=B.PK_COD_COMPONENTE AND 
                        A.COD_EDAC = E.PK_COD_EDAC AND 
						            B.PROPIETARIO = F.PK_COD_PERSONA
						

            ORDER BY F.SIGLA
            ) A, P_DEF_DOMINIOS B, F_GF_INFORMEFALLA F, P_DEF_DOMINIOS D, F_GF_DOC_ANALISIS C
            WHERE
            A.ETAPA = B.DESCRIPCION_DOMINIO
            AND A.NUM_FALLA = F.PK_COD_FALLA
            AND F.PK_ORIGEN_INFORME ={0}
            AND (F.PK_COD_FALLA, F.PK_D_COD_TIPOINFORME) IN 
            (
            SELECT R.PK_COD_FALLA, R.ULTIMO_ESTADO AS PK_D_COD_TIPOINFORME from v_gf_rregfalla_ultimoestado R
            WHERE
            R.ultimo_estado in (21,22)
            )
            AND F.D_COD_ORIGEN = D.COD_DOMINIO
            AND A.NUM_FALLA = C.PK_COD_FALLA(+)";

            sql = string.Format(sql, "7");
            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "OperacionEdac");
            resultado.Add(tablaDetalleDominio);

            strSql =
            @"SELECT
            M.FECHA,
            M.HORA,
            M.ETAPA_EDAC,
            M.ETAPA,
            M.FREC,
            M.CAUSA,
            M.DESCONEX_DE,
            M.OBSERVACIONES,
            sum(M.POTENCIA) AS SUBTOTAL
            FROM
            (
                        {0}
            ) M
            GROUP BY 
            M.FECHA,
            M.HORA,
            M.ETAPA_EDAC,
            M.ETAPA,
            M.FREC,
            M.CAUSA,
            M.DESCONEX_DE,
            M.OBSERVACIONES
            ORDER BY 1,2,3";

            strSql = string.Format(strSql, sql);
            OracleCommand cmdDetalle = CrearComando(strSql);
            DataTable tablaDetalle = EjecutarComando(cmdDetalle, "DetalleAgrupado");
            resultado.Add(tablaDetalle);

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
