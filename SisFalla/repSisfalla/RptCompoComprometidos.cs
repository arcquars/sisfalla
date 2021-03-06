﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.Dominios;

namespace repSisfalla
{
    class RptCompoComprometidos : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            CONCAT(CONCAT(SUBSTR(F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
            F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME AS ORIGEN_INFORME,
            F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME AS TIPOINFORME,
            TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY hh24:mi:ss'),'DD/MM/YYYY hh24:mi:ss') AS FECHAHORA,                                        
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS COD_COMPONENTE,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIP_COMPONENTE,
            F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DESC,
            F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD + F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION + F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS TTOTAL_DESCONEXION,
            DOM_RESPONSABLE.SIGLA AS SIGLA_RESPONSABLE,
            NVL(F_GF_RESPONSABILIDAD.TIEMPO_RESPONSABILIDAD,0) AS TRESPONSABILIDAD,
            F_AP_PERSONA.SIGLA AS SIGLA_PROPIETARIO,
            DOM_ORIGEN.DESCRIPCION_DOMINIO AS ORIGEN,
            DOM_TDESCONEX.DESCRIPCION_DOMINIO AS CAUSA,
            DOM_CAUSA.DESCRIPCION_DOMINIO AS ESPECIFICACION,
            DECODE(F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD + F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION + F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION,0, DECODE(NVL(F_GF_RESPONSABILIDAD.TIEMPO_RESPONSABILIDAD,0),0, 'SI'), 'NO') AS RECONEX_AUTO,
            DOM_COMPO.DESCRIPCION_TIPO AS TIPO_COMPONENTE
            FROM
            F_GF_RREGFALLA_COMPONENTE
            LEFT JOIN F_GF_RESPONSABILIDAD ON F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_RESPONSABILIDAD.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_RESPONSABILIDAD.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_RESPONSABILIDAD.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_RESPONSABILIDAD.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_RESPONSABILIDAD.FEC_APERTURA
            LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
            LEFT JOIN F_AP_PERSONA DOM_RESPONSABLE ON F_GF_RESPONSABILIDAD.PK_COD_PERSONA_RESPONSABLE = DOM_RESPONSABLE.PK_COD_PERSONA
            LEFT JOIN P_AC_TIPOCOMPONENTE DOM_COMPO ON F_AC_COMPONENTE.D_TIPO_COMPONENTE = DOM_COMPO.PK_COD_TIPO_COMPONENTE AND DOM_COMPO.PK_COD_TIPO_COMPONENTE != 0
            LEFT JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            INNER JOIN F_GF_INFORMEFALLA ON F_GF_INFORMEFALLA.PK_COD_FALLA = F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AND F_GF_INFORMEFALLA.PK_ORIGEN_INFORME = F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME AND F_GF_INFORMEFALLA.PK_D_COD_TIPOINFORME = F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME
            LEFT JOIN P_DEF_DOMINIOS DOM_ORIGEN ON F_GF_INFORMEFALLA.D_COD_ORIGEN = DOM_ORIGEN.COD_DOMINIO
            LEFT JOIN P_DEF_DOMINIOS DOM_TDESCONEX ON F_GF_INFORMEFALLA.D_COD_TIPO_DESCONEXION = DOM_TDESCONEX.COD_DOMINIO
            LEFT JOIN P_DEF_DOMINIOS DOM_CAUSA ON F_GF_INFORMEFALLA.D_COD_CAUSA = DOM_CAUSA.COD_DOMINIO
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
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleInfCompoComprometidos");
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
