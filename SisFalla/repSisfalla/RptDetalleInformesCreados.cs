using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using ModeloSisFalla;

namespace repSisfalla
{
    class RptDetalleInformesCreados : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            string sql = @"SELECT
            F_GF_OPERACION.ID_OPERACION AS COD_OPERACION,
            P_GF_DEF_OPERACION.NOMBRE_OPERACION AS TIPO_OPERACION,
            transform_codfalla(F_GF_OPERACION.PK_COD_FALLA) AS NUM_FALLA,
            F_GF_OPERACION.PK_COD_ORIGEN_INFORME AS ORIGEN,
            F_AP_PERSONA.SIGLA AS AGENTE,
            '' AS NOT_CNDC,
            '' AS NOT_AGE,
            '' AS PRE_AGE,
            '' AS PRE_CNDC,
            '' AS FIN_AGE,
            '' AS FIN_CNDC,
            '' AS REC_CNDC,
            TO_DATE(TO_CHAR(F_SEC_LOG.FECHA_TRANSACCION,'DD/MM/YYYY hh24:mi:ss'),'DD/MM/YYYY hh24:mi:ss') AS FECHA_TRANSACCION,
            F_SEC_LOG.FK_LOGIN AS USU_TRANSACCION,
            '' AS CAMPO1,
            '' AS CAMPO2
            FROM
            F_GF_OPERACION ,
            P_GF_DEF_OPERACION ,
            F_SEC_LOG,
            F_AP_PERSONA
            WHERE
            F_GF_OPERACION.ID_OPERACION = P_GF_DEF_OPERACION.ID_OPERACION AND
            F_GF_OPERACION.SEC_LOG = F_SEC_LOG.COD_SEC_LOG AND
            F_GF_OPERACION.PK_COD_ORIGEN_INFORME = F_AP_PERSONA.PK_COD_PERSONA
            AND F_GF_OPERACION.PK_COD_FALLA = :NUM_FALLA 
            ORDER BY
            F_GF_OPERACION.PK_COD_FALLA asc, F_SEC_LOG.FECHA_TRANSACCION asc";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("NUM_FALLA", regFalla.CodFalla);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleInformes");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }        
    }
}
