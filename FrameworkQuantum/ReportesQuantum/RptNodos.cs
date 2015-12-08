using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Reportes;
using Oracle.DataAccess.Client;
using CNDC.Dominios;

namespace ReportesQuantum
{
    public class RptNodos : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AC_NODO.NOMBRE_NODO,
            F_AC_NODO.SIGLA_NODO,
            F_AC_NODO.DESCRIPCION_NODO,
            F_AC_NODO.D_COD_AREA,
            F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION,
            F_AC_COMPONENTE.CODIGO_COMPONENTE,
            F_AC_COMPONENTE.NOMBRE_COMPONENTE,
            TO_CHAR(F_AC_COMPONENTE.FECHA_INGRESO,'DD/MM/YYYY HH24:MI:SS') AS FECHA_INGRESO
            FROM
            F_AC_NODO
            LEFT JOIN F_AC_RCOMPONENTE_NODO D_NODO ON F_AC_NODO.PK_COD_NODO = D_NODO.PK_COD_NODO AND D_NODO.D_COD_TIPO_RELACION IN (3602) AND D_NODO.FECHA_SALIDA is NULL
            LEFT JOIN F_AC_COMPONENTE ON D_NODO.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE AND F_AC_COMPONENTE.FECHA_SALIDA is NULL 
            WHERE
            sysdate between F_AC_NODO.FECHA_INGRESO and NVL(F_AC_NODO.FECHA_SALIDA, sysdate + 1)
            AND sysdate between F_AC_COMPONENTE.FECHA_INGRESO and NVL(F_AC_COMPONENTE.FECHA_SALIDA, sysdate + 1)
            ";

            OracleCommand cmd = CrearComando(sql);
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
