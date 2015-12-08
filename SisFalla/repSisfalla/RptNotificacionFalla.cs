using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using ModeloSisFalla;
using CNDC.BLL;

namespace repSisfalla
{
    public class RptNotificacionFalla : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();
            RegFalla _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");

            string sql =
            @"SELECT
            CONCAT(F_GF_NOTIFICACION.PK_COD_FALLA,' ') AS NUM_FALLA,
            F_AP_PERSONA.SIGLA AS AGENTE,
            P_DEF_DOMINIOS.DESCRIPCION_DOMINIO AS ESTADO_NOTIFICACION,
            F_GF_INFORMEFALLA.DESCRIPCION_INFORME,
            TO_CHAR(F_GF_INFORMEFALLA.FEC_INICIO,'DD/MM/YYYY HH24:MI:SS') AS FEC_FALLA,
            TO_CHAR(F_GF_INFORMEFALLA.FEC_FINAL,'DD/MM/YYYY HH24:MI:SS') AS FEC_ENVIO
            FROM
            F_GF_NOTIFICACION
            LEFT JOIN P_DEF_DOMINIOS ON F_GF_NOTIFICACION.D_COD_ESTADO_NOTIFICACION = P_DEF_DOMINIOS.COD_DOMINIO
            LEFT JOIN F_AP_PERSONA ON F_AP_PERSONA.PK_COD_PERSONA = F_GF_NOTIFICACION.PK_COD_PERSONA
            LEFT JOIN F_GF_INFORMEFALLA ON F_GF_NOTIFICACION.PK_COD_FALLA = F_GF_INFORMEFALLA.PK_COD_FALLA
            WHERE
            F_GF_NOTIFICACION.PK_COD_FALLA = :COD_FALLA";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("COD_FALLA", _regFalla.CodFalla);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "Datos");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
