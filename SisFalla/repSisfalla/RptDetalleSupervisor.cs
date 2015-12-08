using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace repSisfalla
{
    class RptDetalleSupervisor : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            CONCAT(CONCAT(SUBSTR(F_GF_REGFALLA.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_REGFALLA.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
            F_GF_REGFALLA.PK_COD_FALLA AS ORDEN_FALLA,
            F_GF_REGFALLA.FEC_INICIO AS FECHA,
            trunc(F_GF_REGFALLA.FEC_INICIO) AS FECHA_FALLA,
            F_GF_REGFALLA.DESCRIPCION_CORTA_FALLA AS DESCRIPCION,
            DOM_SUPER.NOM_PERSONA AS SUPERVISOR,
            DOM_OPERADOR.NOM_PERSONA AS OPERADOR
            FROM
            F_GF_REGFALLA
            INNER JOIN F_AP_PERSONA DOM_SUPER ON F_GF_REGFALLA.FK_COD_SUPERVISOR = DOM_SUPER.PK_COD_PERSONA
            INNER JOIN F_AP_PERSONA DOM_OPERADOR ON F_GF_REGFALLA.FK_COD_OPERADOR = DOM_OPERADOR.PK_COD_PERSONA
            ORDER BY
            F_GF_REGFALLA.PK_COD_FALLA ASC";

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleSupervisor");
            resultado.Add(tablaDetalleDominio);

            string sql2 =
            @"SELECT 
	                DOM_SUPER.NOM_PERSONA AS RESPONSABLE_INFORME,
A.FEC_INICIO AS FECHA_FALLA,'Supervisor' AS RESPONSABLE, 1 AS ITEM
                FROM
	                F_GF_REGFALLA A
                INNER JOIN F_AP_PERSONA DOM_SUPER ON A.FK_COD_SUPERVISOR = DOM_SUPER.PK_COD_PERSONA
UNION
	                SELECT 
		                DOM_OPERADOR.NOM_PERSONA AS RESPONSABLE_INFORME,
A.FEC_INICIO AS FECHA_FALLA,'Operador' AS RESPONSABLE, 1 AS ITEM
	                FROM
		                F_GF_REGFALLA A
	                INNER JOIN F_AP_PERSONA DOM_OPERADOR ON A.FK_COD_OPERADOR = DOM_OPERADOR.PK_COD_PERSONA";

            cmd = CrearComando(sql2);
            DataTable tablaDetalleResponsable = EjecutarComando(cmd, "DetalleResponsable");
            resultado.Add(tablaDetalleResponsable);

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
