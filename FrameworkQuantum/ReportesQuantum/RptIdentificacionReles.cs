using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using CNDC.Dominios;
using Oracle.DataAccess.Client;
using System.Data;

namespace ReportesQuantum
{
    class RptIdentificacionReles : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql = 
            @"SELECT
            P_DEF_DOMINIOS.DESCRIPCION_DOMINIO_2 || '-' || P_DEF_DOMINIOS.DESCRIPCION_DOMINIO AS DESCRIPCION,
            P_DEF_DOMINIOS.DESCRIPCION_DOMINIO  AS DESC_ORD
            FROM
            P_DEF_DOMINIOS
            WHERE
            P_DEF_DOMINIOS.D_COD_TIPO = '" + Dominios.D_COD_FUNCION + "' " +
            "ORDER BY 2";

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleDominio");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
