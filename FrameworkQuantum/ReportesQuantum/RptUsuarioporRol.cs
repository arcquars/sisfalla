using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptUsuarioporRol : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            F_AP_PERSONA.SIGLA AS SIGLA,
            F_AP_PERSONA.NOM_PERSONA AS NOMBRE,

            F_AP_PERSONA.D_COD_TIPO_PERSONA AS COD_PERSONA,
            F_AU_USUARIOS.LOGIN AS LOGIN,
            F_AU_ROLES.DESCRIPCION AS DIRECCION,
            F_AU_ROLES.NOMBRE_CORTO AS ROL_SISTEMA
            FROM
            F_AP_PERSONA
            INNER JOIN F_AU_USUARIOS ON F_AU_USUARIOS.PK_COD_USUARIO = F_AP_PERSONA.PK_COD_PERSONA
            INNER JOIN F_AU_RUSUARIOS_ROLES ON F_AU_USUARIOS.LOGIN = F_AU_RUSUARIOS_ROLES.LOGIN
            INNER JOIN F_AU_ROLES ON F_AU_RUSUARIOS_ROLES.NUM_ROL = F_AU_ROLES.NUM_ROL";

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
