using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptUsuarioRolOpciones : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AP_PERSONA.SIGLA AS SIGLA,
            F_AP_PERSONA.NOM_PERSONA AS NOMBRE,
            DOM_MENUS.NUM_OPCION AS COD_PERSONA,
            F_AU_USUARIOS.LOGIN AS LOGIN,
            NULL AS DIRECCION,
            F_AU_ROLES.NOMBRE_CORTO AS ROL_SISTEMA,
            DOM_MENUS.DESCRIPCION_OPCION AS CAMPO1,
            F_AU_OPCIONES.DESCRIPCION_OPCION AS CAMPO2
            
            FROM
            F_AU_ROLES
            INNER JOIN F_AU_RROL_OPCIONES ON F_AU_ROLES.NUM_ROL = F_AU_RROL_OPCIONES.NUM_ROL
            INNER JOIN F_AU_OPCIONES ON F_AU_RROL_OPCIONES.NUM_OPCION = F_AU_OPCIONES.NUM_OPCION
            INNER JOIN F_AU_OPCIONES DOM_MENUS ON F_AU_OPCIONES.NUM_OPCION_MADRE = DOM_MENUS.NUM_OPCION
            INNER JOIN F_AU_RUSUARIOS_ROLES ON F_AU_RUSUARIOS_ROLES.NUM_ROL = F_AU_ROLES.NUM_ROL
            INNER JOIN F_AU_USUARIOS ON F_AU_USUARIOS.LOGIN = F_AU_RUSUARIOS_ROLES.LOGIN
            INNER JOIN F_AP_PERSONA ON F_AU_USUARIOS.PK_COD_USUARIO = F_AP_PERSONA.PK_COD_PERSONA
			INNER JOIN F_AU_RROL_MODULO ON F_AU_ROLES.NUM_ROL = F_AU_RROL_MODULO.PK_NUM_ROL

            WHERE
            F_AU_USUARIOS.D_COD_ESTADO = '1'
            AND F_AU_RROL_MODULO.PK_COD_MODULO = 1

            ORDER BY
            COD_PERSONA ASC,
            F_AU_OPCIONES.ORDEN_VISTA ASC";

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaUsuarioporRol = EjecutarComando(cmd, "UsuarioporRol");
            resultado.Add(tablaUsuarioporRol);

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
