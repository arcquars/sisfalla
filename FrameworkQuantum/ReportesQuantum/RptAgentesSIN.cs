using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.Dominios;

namespace ReportesQuantum
{
    public class RptAgentesSIN : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql = 
            @"SELECT F_AP_PERSONA.PK_COD_PERSONA, F_AP_PERSONA.NOM_PERSONA, F_AP_PERSONA.SIGLA,  F_AP_PERSONA.DIRECCION, F_AP_PERSONA.TELEFONO  FROM F_AP_PERSONA F_AP_PERSONA WHERE  F_AP_PERSONA.D_COD_TIPO_PERSONA=" + ((int)D_COD_TIPO_PERSONA.PERSONA_JURIDICA).ToString() + "  ORDER BY F_AP_PERSONA.NOM_PERSONA";
            
            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "Agentes");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
