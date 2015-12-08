using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using CNDC.BLL;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using MenuQuantum;

namespace repSisfalla
{
    //TODO falta la notificacion para la AE es la opcion 26 de F_AU_OPCIONES
    public class RptNotificacion : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();
            string sql = string.Empty;
            RptNotificacionParametroExtra parametro = (RptNotificacionParametroExtra)_parametroExtra;
            RegFalla regTemp = ModeloMgr.Instancia.RegFallaMgr.GetFalla(parametro.CodFalla);
            if ( regTemp.CodComponente != 0 )
            {
                sql = @"SELECT DISTINCT
                SUBSTR(F_GF_REGFALLA.PK_COD_FALLA,-4,4) || '-' || SUBSTR(to_char(F_GF_REGFALLA.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2) AS NUM_FALLA,
                TO_CHAR(F_GF_REGFALLA.FEC_INICIO,'DD/MM/YYYY HH24:MI:SS') AS FECHA_HORA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE || ' - ' || F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS COMPONENTE_FALLADO,
                DOM_ORIGEN.DESCRIPCION_DOMINIO AS ORIGEN,
                DOM_DESCONEX.DESCRIPCION_DOMINIO AS TIPODESCONEXION,
                DOM_CAUSA.DESCRIPCION_DOMINIO AS CAUSA,
                DOM_OPERADOR.NOM_PERSONA AS OPERADOR,
                F_GF_REGFALLA.DESCRIPCION_CORTA_FALLA AS DESCRIPCION_CORTO,
                F_GF_REGFALLA.DESCRIPCION_FALLA AS DESCRIPCION_LARGO,
                F_AP_PERSONA.SIGLA || ' - ' || F_AP_PERSONA.NOM_PERSONA EMPRESA
                FROM
                F_GF_REGFALLA
                INNER JOIN F_AC_COMPONENTE ON F_GF_REGFALLA.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                INNER JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
                INNER JOIN P_DEF_DOMINIOS DOM_CAUSA ON F_GF_REGFALLA.D_COD_CAUSA = DOM_CAUSA.COD_DOMINIO
                INNER JOIN P_DEF_DOMINIOS DOM_ORIGEN ON F_GF_REGFALLA.D_COD_ORIGEN = DOM_ORIGEN.COD_DOMINIO
                INNER JOIN P_DEF_DOMINIOS DOM_DESCONEX ON F_GF_REGFALLA.D_COD_TIPO_DESCONEXION = DOM_DESCONEX.COD_DOMINIO
                INNER JOIN F_AP_PERSONA DOM_OPERADOR ON F_GF_REGFALLA.FK_COD_SUPERVISOR = DOM_OPERADOR.PK_COD_PERSONA
                WHERE
                F_GF_REGFALLA.PK_COD_FALLA =:NUM_FALLA";
            }
            else
            {
                sql = @"SELECT DISTINCT
                SUBSTR(F_GF_REGFALLA.PK_COD_FALLA,-4,4) || '-' || SUBSTR(to_char(F_GF_REGFALLA.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2) AS NUM_FALLA,
                TO_CHAR(F_GF_REGFALLA.FEC_INICIO,'DD/MM/YYYY HH24:MI:SS') AS FECHA_HORA,
                P_DEF_DOMINIOS.DESCRIPCION_DOMINIO AS COMPONENTE_FALLADO,
                DOM_ORIGEN.DESCRIPCION_DOMINIO AS ORIGEN,
                DOM_DESCONEX.DESCRIPCION_DOMINIO AS TIPODESCONEXION,
                DOM_CAUSA.DESCRIPCION_DOMINIO AS CAUSA,
                DOM_OPERADOR.NOM_PERSONA AS OPERADOR,
                F_GF_REGFALLA.DESCRIPCION_CORTA_FALLA AS DESCRIPCION_CORTO,
                F_GF_REGFALLA.DESCRIPCION_FALLA AS DESCRIPCION_LARGO,
                '' EMPRESA
                FROM
                F_GF_REGFALLA
				INNER JOIN P_DEF_DOMINIOS ON F_GF_REGFALLA.D_COD_PROBLEMA_GEN = P_DEF_DOMINIOS.COD_DOMINIO
                INNER JOIN P_DEF_DOMINIOS DOM_CAUSA ON F_GF_REGFALLA.D_COD_CAUSA = DOM_CAUSA.COD_DOMINIO
                INNER JOIN P_DEF_DOMINIOS DOM_ORIGEN ON F_GF_REGFALLA.D_COD_ORIGEN = DOM_ORIGEN.COD_DOMINIO
                INNER JOIN P_DEF_DOMINIOS DOM_DESCONEX ON F_GF_REGFALLA.D_COD_TIPO_DESCONEXION = DOM_DESCONEX.COD_DOMINIO
                INNER JOIN F_AP_PERSONA DOM_OPERADOR ON F_GF_REGFALLA.FK_COD_SUPERVISOR = DOM_OPERADOR.PK_COD_PERSONA
                WHERE
                F_GF_REGFALLA.PK_COD_FALLA =:NUM_FALLA";
            }

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("NUM_FALLA", regTemp.CodFalla);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "Datos");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }

    public class RptNotificacionParametroExtra : ParametroExtra
    {
        public int CodFalla { get; private set; }

        public RptNotificacionParametroExtra(int codFalla)
        {
            CodFalla = codFalla;
        }
    }
}
