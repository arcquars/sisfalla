using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptRolOpciones : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql = 
            @"SELECT
            NULL AS SIGLA,
            NULL AS NOMBRE,
            DOM_MENUS.NUM_OPCION AS COD_PERSONA,
            NULL AS LOGIN,
            NULL AS DIRECCION,
            F_AU_ROLES.NOMBRE_CORTO AS ROL_SISTEMA,
            F_AU_OPCIONES.DESCRIPCION_OPCION AS OPCIONES_ROL,
            DOM_MENUS.DESCRIPCION_OPCION AS TIPO_OPCION
            FROM
            F_AU_ROLES
            INNER JOIN F_AU_RROL_OPCIONES ON F_AU_ROLES.NUM_ROL = F_AU_RROL_OPCIONES.NUM_ROL
            INNER JOIN F_AU_OPCIONES ON F_AU_RROL_OPCIONES.NUM_OPCION = F_AU_OPCIONES.NUM_OPCION
            INNER JOIN F_AU_OPCIONES DOM_MENUS ON F_AU_OPCIONES.NUM_OPCION_MADRE = DOM_MENUS.NUM_OPCION
            ORDER BY
            COD_PERSONA ASC,
            F_AU_OPCIONES.ORDEN_VISTA ASC";

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaOpcionesporRol = EjecutarComando(cmd, "OpcionesporRol");
            resultado.Add(tablaOpcionesporRol);

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
