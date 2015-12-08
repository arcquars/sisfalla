using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Reportes;
using Oracle.DataAccess.Client;
using CNDC.Dominios;
using Proyectos;

namespace ReportesProyectos
{
    public class RptProysGeneracion: ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT f_pr_proyecto_maestro.nombre,f_pr_proyecto_maestro.codigo,
            f_pr_proyecto_maestro.fecha_registro, d.descripcion_dominio as TipoProyecto 
            FROM f_pr_proyecto_maestro , p_def_dominios d 
            WHERE f_pr_proyecto_maestro.d_tipo_proyecto= d.cod_dominio 
            AND f_pr_proyecto_maestro.d_tipo_proyecto_padre= {0} 
            ORDER BY d.descripcion_dominio,f_pr_proyecto_maestro.NOMBRE,f_pr_proyecto_maestro.FECHA_REGISTRO";
            sql = string.Format(sql, (int)D_COD_TIPO_PROYECTO.PROYECTOS_DE_GENERACIÓN);

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "ListaProyectosMaestro");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
