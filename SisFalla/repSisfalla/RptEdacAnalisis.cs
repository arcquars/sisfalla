using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Reportes;
using System.Data;


namespace repSisfalla
{
    public class RptEdacAnalisis : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();
            string strSql = string.Empty;
            //string fechaMaxima = string.Empty;
            DateTime fechaMaxima = new DateTime();
            string sql = @"SELECT MAX(A.FECHA_INICIO) AS FECHAMAX FROM F_GF_RCOMPONENTE_EDAC A";
            OracleCommand cmd = CrearComando(sql);
            DataTable maxima = EjecutarComando(cmd, "fechaMaxima");

            if (maxima.Rows.Count > 0)
            {
                fechaMaxima = ((DateTime)maxima.Rows[0]["FECHAMAX"]).Date;

                sql = string.Empty;
                sql =
                @"
            SELECT * FROM
            (
                   SELECT 
                    '1' AS CAT,
                    FEC_INICIO,
                    ETAPAS,
                    FRECUENCIA,
                    TIEMPO,
                    T_FORMATO, 
                    ORDEN_PLAN AS ORD_PLAN,
						        NOMBRE_COMPONENTE AS NOMBRE_COMPONENTE,
						        '' AS CAMPO1,
						        '' AS CAMPO2
                    FROM
                    (
            
                    SELECT
		        to_date(to_char(fecha_inicio,'dd/mm/yyyy'),'dd/mm/yyyy') as FEC_INICIO,
		        to_number(SUBSTR(tipo_edac, 3, 2),'99') AS ETAPAS,
		        ajuste_edac AS FRECUENCIA, to_char(etapa_edac) AS TIEMPO, etapa_edac AS T_FORMATO, tipo_edac,
                        A.Pk_Cod_Componente, A.Pk_Cod_Edac,
                        B.Propietario as Propietario,
                        B.NOMBRE_COMPONENTE as NOMBRE_COMPONENTE,
                        d.SIGLA as SIGLA,
		        DECODE(B.Propietario,9,1,3,2,8,3,10,4,2,5,4,6,22,7,19,8,5,9,18,10,100,11,163,12,170,13,172,14, NULL) AS ORDEN_PLAN
                        FROM F_Gf_Rcomponente_Edac A,
                        F_Ac_Componente B ,
               	        F_gf_param_edac c,
		        F_AP_PERSONA d
                        WHERE 
						trunc(A.FECHA_INICIO) = :fechaMaxima
                        AND C.Pk_Cod_Edac = A.Pk_Cod_Edac
                        AND a.pk_cod_edac IN ( 12,13,14,15,16,17,18,19,20,21,22,23)
                        AND A.Pk_Cod_Componente = B.Pk_Cod_Componente
		        AND B.PROPIETARIO = d.PK_COD_PERSONA
		
           
            
                    ) D1
                    ORDER BY 2,3,4,6

                    ) A
                    UNION
                    SELECT * FROM
                    (
                    SELECT 
                    '2' AS CAT,
                    FEC_INICIO,
                    ETAPAS,
                    FRECUENCIA,
                    TIEMPO,
                    T_FORMATO, 
                    ORDEN_PLAN AS ORD_PLAN,
						        NOMBRE_COMPONENTE AS NOMBRE_COMPONENTE,
						        '' AS CAMPO1,
						        '' AS CAMPO2
                    FROM
                    (
            
                    SELECT
		        to_date(to_char(fecha_inicio,'dd/mm/yyyy'),'dd/mm/yyyy') as FEC_INICIO,
		        to_number(SUBSTR(tipo_edac, 3, 2),'99') AS ETAPAS,
		        ajuste_edac AS FRECUENCIA, to_char(etapa_edac) AS TIEMPO, etapa_edac AS T_FORMATO, tipo_edac,
                        A.Pk_Cod_Componente, A.Pk_Cod_Edac,
                        B.Propietario as Propietario,
                        B.NOMBRE_COMPONENTE as NOMBRE_COMPONENTE,
                        d.SIGLA as SIGLA,
		        DECODE(B.Propietario,9,1,3,2,8,3,10,4,2,5,4,6,22,7,19,8,5,9,18,10,100,11,163,12,170,13,172,14, NULL) AS ORDEN_PLAN
                        FROM F_Gf_Rcomponente_Edac A,
                        F_Ac_Componente B ,
               	        F_gf_param_edac c,
		        F_AP_PERSONA d
                        WHERE 
						trunc(A.FECHA_INICIO) = :fechaMaxima
                        AND C.Pk_Cod_Edac = A.Pk_Cod_Edac
                        AND a.pk_cod_edac IN ( 6,7,8,9,10,11 )
                        AND A.Pk_Cod_Componente = B.Pk_Cod_Componente
		        AND B.PROPIETARIO = d.PK_COD_PERSONA
		
           
            
                    ) D1
                    ORDER BY 2,3,4,6

                    ) B
                    UNION

                        SELECT * FROM
                    (
                    SELECT 
                    '3' AS CAT,
                    FEC_INICIO,
                    ETAPAS,
                    FRECUENCIA,
                    TIEMPO,
                    T_FORMATO, 
                    ORDEN_PLAN AS ORD_PLAN,
						        NOMBRE_COMPONENTE AS NOMBRE_COMPONENTE,
						        '' AS CAMPO1,
						        '' AS CAMPO2
                    FROM
                    (
            
                    SELECT
		        to_date(to_char(fecha_inicio,'dd/mm/yyyy'),'dd/mm/yyyy') as FEC_INICIO,
		        to_number(SUBSTR(tipo_edac, 3, 2),'99') AS ETAPAS,
		        ajuste_edac AS FRECUENCIA, to_char(etapa_edac) AS TIEMPO, etapa_edac AS T_FORMATO, tipo_edac,
                        A.Pk_Cod_Componente, A.Pk_Cod_Edac,
                        B.Propietario as Propietario,
                        B.NOMBRE_COMPONENTE as NOMBRE_COMPONENTE,
                        d.SIGLA as SIGLA,
		        DECODE(B.Propietario,9,1,3,2,8,3,10,4,2,5,4,6,22,7,19,8,5,9,18,10,100,11,163,12,170,13,172,14, NULL) AS ORDEN_PLAN
                        FROM F_Gf_Rcomponente_Edac A,
                        F_Ac_Componente B ,
               	        F_gf_param_edac c,
		        F_AP_PERSONA d
                        WHERE 
						trunc(A.FECHA_INICIO) = :fechaMaxima
                        AND C.Pk_Cod_Edac = A.Pk_Cod_Edac
                        AND a.pk_cod_edac IN ( 1,2,3,4,5 )
                        AND A.Pk_Cod_Componente = B.Pk_Cod_Componente
		        AND B.PROPIETARIO = d.PK_COD_PERSONA

                    ) D1
                    ORDER BY 2,3,4,6

            ) C
            ";

                //sql = string.Format(sql, fechaMaxima);

                cmd = CrearComando(sql);
                cmd.Parameters.Add("fechaMaxima", OracleDbType.Date, fechaMaxima.Date, ParameterDirection.Input);
                DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleEDAC");
                resultado.Add(tablaDetalleDominio);

                strSql =
                @"SELECT DISTINCT
            M.CAT,
            M.FEC_INICIO,
            M.ETAPAS,
            M.FRECUENCIA,
            M.TIEMPO,
            M.T_FORMATO
            FROM
            (
                        {0}
            ) M
            ORDER BY 1,2,3,4,5
            ";

                strSql = string.Format(strSql, sql);
                cmd = CrearComando(strSql);
                cmd.Parameters.Add("fechaMaxima", OracleDbType.Date, fechaMaxima.Date, ParameterDirection.Input);
                DataTable tablaDetalle = EjecutarComando(cmd, "DetalleAgrupado");
                resultado.Add(tablaDetalle);
            }
            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Ninguno;
        }
    }
}
