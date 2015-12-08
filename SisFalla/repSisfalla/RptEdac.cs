using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Reportes;
using Oracle.DataAccess.Client;

namespace repSisfalla
{
    public class RptEdac : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();
            
            string sql = 
            @"SELECT
            A.PK_COD_COMPONENTE AS ID_COMPONENTE,
            A.CODIGO_COMPONENTE AS CODIGO_COMPONENTE,
            A.NOMBRE_COMPONENTE AS ALIMENTADOR,
            A.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
            B.TIPO_EDAC,
            to_char(B.AJUSTE_EDAC,'90.99') || '[Hz]' AS AJUSTE_EDAC,
            B.ETAPA_EDAC,
            to_char(to_date(nvl(to_char(C.FECHA_INICIO,'DD/MM/YYYY'),to_char(sysdate,'DD/MM/YYYY')),'DD/MM/YYYY'),'YYYY/MM/DD') AS INTERVALO,
            to_date(nvl(to_char(C.FECHA_INICIO,'DD/MM/YYYY'),to_char(sysdate,'DD/MM/YYYY')),'DD/MM/YYYY') AS FECHA_INICIO,
            D.SIGLA AS CAMPO1,
            '' AS CAMPO2
            FROM
            F_AC_COMPONENTE A ,
            F_GF_PARAM_EDAC B ,
            F_GF_RCOMPONENTE_EDAC C,
            F_AP_PERSONA D 
            WHERE
            A.PK_COD_COMPONENTE = C.PK_COD_COMPONENTE 
            AND A.PROPIETARIO = D.PK_COD_PERSONA
            AND B.PK_COD_EDAC = C.PK_COD_EDAC 

            ORDER BY
            INTERVALO DESC, ALIMENTADOR ASC";
            
            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleEdac");
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
