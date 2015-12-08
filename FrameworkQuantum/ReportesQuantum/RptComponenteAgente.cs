using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Dominios;
using System.Windows.Forms;

namespace ReportesQuantum
{
    public class RptComponenteAgente : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT F_AP_PERSONA.NOM_PERSONA AS NOM_EMPRESA, F_AP_PERSONA.SIGLA, 
            F_AC_COMPONENTE.CODIGO_COMPONENTE, F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION, 
            F_AC_COMPONENTE.NOMBRE_COMPONENTE AS NOMBRE_PORAGENTE, 
            P_AC_TIPOCOMPONENTE.DESCRIPCION_TIPO AS TIPO_COMPONENTE 
            FROM F_AC_COMPONENTE 
			INNER JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA 
            INNER JOIN P_AC_TIPOCOMPONENTE ON F_AC_COMPONENTE.D_TIPO_COMPONENTE = P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE AND P_AC_TIPOCOMPONENTE.PK_COD_TIPO_COMPONENTE != 0
            WHERE 
			sysdate between F_AC_COMPONENTE.FECHA_INGRESO and NVL(F_AC_COMPONENTE.FECHA_SALIDA, sysdate + 1)
            AND F_AP_PERSONA.D_COD_TIPO_PERSONA =" + ((int)D_COD_TIPO_PERSONA.PERSONA_JURIDICA).ToString();

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "ComponentesAgente");
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
