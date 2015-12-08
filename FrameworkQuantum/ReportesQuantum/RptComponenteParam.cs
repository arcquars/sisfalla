using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptComponenteParam : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT DISTINCT
            F_AP_PERSONA.SIGLA,
            F_AP_PERSONA.NOM_PERSONA,
            F_AC_COMPONENTE.NOMBRE_COMPONENTE,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION,
            F_AC_COMPONENTE.CODIGO_COMPONENTE,
            P_AC_TIPOCOMPONENTE.DESCRIPCION_TIPO AS DESCRIPCION_DOM,
            ORIGEN.NOMBRE_NODO AS SIGLA_NODO
            FROM
            F_AC_COMPONENTE
            LEFT JOIN P_AC_TIPOCOMPONENTE ON F_AC_COMPONENTE.D_TIPO_COMPONENTE = P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE AND P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE != 0
            LEFT JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            LEFT JOIN F_AC_RCOMPONENTE_NODO N_ORIGEN ON F_AC_COMPONENTE.PK_COD_COMPONENTE = N_ORIGEN.PK_COD_COMPONENTE AND N_ORIGEN.D_COD_TIPO_RELACION IN (3602)  AND N_ORIGEN.FECHA_SALIDA is NULL
			LEFT JOIN F_AC_NODO ORIGEN ON N_ORIGEN.PK_COD_NODO = ORIGEN.PK_COD_NODO   
            WHERE
			sysdate between F_AC_COMPONENTE.FECHA_INGRESO and NVL(F_AC_COMPONENTE.FECHA_SALIDA, sysdate + 1)
            AND P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE = :COD_DOMINIO";
            
            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_DOMINIO", _parametrosFuncionalidad.DiccionarioParametros["PARAM"]);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "datos");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Grupos;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
