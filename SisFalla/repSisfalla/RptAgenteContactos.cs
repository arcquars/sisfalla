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
    class RptAgenteContactos : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AP_PERSONA.SIGLA AS SIGLA,
            F_AP_PERSONA.NOM_PERSONA AS NOM_PERSONA,
            DOM_CONTACTO.NOM_PERSONA AS PERSONA,
            F_AP_RCONTACTO.EMAIL AS DIRECCION
            FROM
            F_AP_RCONTACTO
            INNER JOIN F_AP_PERSONA ON F_AP_RCONTACTO.PK_COD_EMPRESA = F_AP_PERSONA.PK_COD_PERSONA
            INNER JOIN F_AP_PERSONA DOM_CONTACTO ON F_AP_RCONTACTO.PK_COD_CONTACTO = DOM_CONTACTO.PK_COD_PERSONA
            WHERE
            F_AP_PERSONA.D_COD_TIPO_PERSONA = :COD_PERSONAJURI AND
            F_AP_RCONTACTO.D_COD_ESTADO = 1 AND
            F_AP_RCONTACTO.PK_COD_EMPRESA != 7 
            ORDER BY
            1 ASC,
            3 ASC";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_PERSONAJURI", (long)D_COD_TIPO_PERSONA.PERSONA_JURIDICA);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "Agentes");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Ninguno;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
