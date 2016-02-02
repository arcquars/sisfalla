using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;
using MenuQuantum;
using CNDC.Dominios;
using ModeloSisFalla;
using System.Windows.Forms;
using System.IO;

using System.Net;

namespace repSisfalla
{
    public class RptInformeFalla : ProveedorDatosBase
    {
        private ToolStripButton _btnAnalisisFalla;
        private DataTable _tablaAnalisis;
        public RptInformeFalla()
        {
            _btnAnalisisFalla = new ToolStripButton("Análisis de Falla", global::repSisfalla.Properties.Resources.InfPrelim, _btnAnalisisFalla_Click);
        }

        private void _btnAnalisisFalla_Click(object sender, EventArgs e)
        {
            RptInformeFallaParametroExtra parametro = (RptInformeFallaParametroExtra)_parametroExtra;
            if ( _tablaAnalisis.Rows.Count > 0 )
                //if (_tablaAnalisis.Rows.Count < 0)
            {

                byte[] contenido = (byte[])(_tablaAnalisis.Rows[0]["ARCHIVO"]);
                string sNombreArchivo = string.Format("analisisdefalla_{0}_{1}_{2}.pdf" ,parametro.CodFalla ,parametro.Origen ,parametro.TipoInforme );
                string sRutaAnalisis = Path.Combine(@"C:\WCFSISFALLA", sNombreArchivo);
                FileStream archivopdf = new FileStream(sRutaAnalisis, FileMode.Create, FileAccess.Write);
                archivopdf.Write(contenido, 0, contenido.Length);
                archivopdf.Close();
                System.Diagnostics.Process.Start(sRutaAnalisis);
            }
            else
            {
                if(parametro.TipoInforme == PK_D_COD_TIPOINFORME.FINAL)
                {
                    byte[] contenido = InsertAnalisisFalla(parametro);
                    if (contenido != null)
                    {
                        string sNombreArchivo = string.Format("analisisdefalla_{0}_{1}_{2}.pdf", parametro.CodFalla, parametro.Origen, parametro.TipoInforme);
                        string sRutaAnalisis = Path.Combine(@"C:\WCFSISFALLA", sNombreArchivo);
                        FileStream archivopdf = new FileStream(sRutaAnalisis, FileMode.Create, FileAccess.Write);
                        archivopdf.Write(contenido, 0, contenido.Length);
                        archivopdf.Close();
                        System.Diagnostics.Process.Start(sRutaAnalisis);
                    }
                }
                else
                {
                    byte[] contenido = InsertAnalisisFallaRectifocatorio(parametro);
                    if (contenido != null)
                    {
                        string sNombreArchivo = string.Format("analisisdefalla_{0}_{1}_{2}.pdf", parametro.CodFalla, parametro.Origen, parametro.TipoInforme);
                        string sRutaAnalisis = Path.Combine(@"C:\WCFSISFALLA", sNombreArchivo);
                        FileStream archivopdf = new FileStream(sRutaAnalisis, FileMode.Create, FileAccess.Write);
                        archivopdf.Write(contenido, 0, contenido.Length);
                        archivopdf.Close();
                        System.Diagnostics.Process.Start(sRutaAnalisis);
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra el archivo en el local, tampoco existe archivo para descargar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                
            }
        }

        private byte[] InsertAnalisisFalla(RptInformeFallaParametroExtra parametro)
        {
            WebClient myWebClient = new WebClient();
            byte[] bytes = null;
            try
            {
                bytes = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_"+parametro.CodFalla+"_7_FINAL.pdf");
                //bytes = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_150360_7_FINAL.pdf");

            }
            catch (WebException webEx)
            {
                CNDC.Pistas.PistaMgr.Instance.EscribirLog("InsertAnalisisFallaRectifocatorio", "Error: no se encuentra el archivo en la url: " + webEx.Message, CNDC.Pistas.TipoPista.Error);
                MessageBox.Show("No se encuentra el archivo en el local, tampoco existe archivo para descargar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            if (bytes != null)
            {
                int tipo = Convert.ToInt32(parametro.TipoInforme);
                this.saveDocAnalisis(bytes, parametro.CodFalla, tipo, parametro.Origen);
            }
            return bytes;
        }

        private byte[] InsertAnalisisFallaRectifocatorio(RptInformeFallaParametroExtra parametro)
        {
            WebClient myWebClient = new WebClient();
            byte[] bytesFinal = null;
            byte[] bytesRectificatorio = null;
            try
            {
                //bytesRectificatorio = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_" + parametro.CodFalla + "_7_RECTIFICATORIO.pdf");
                bytesRectificatorio = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_150360_7_FINAL.pdf");
            }
            catch (WebException webEx)
            {
                CNDC.Pistas.PistaMgr.Instance.EscribirLog("InsertAnalisisFallaRectifocatorio", "Error: no se encuentra el archivo en la url para el rectificatorio: "+webEx.Message, CNDC.Pistas.TipoPista.Error);
            }
            try
            {
                bytesFinal = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_" + parametro.CodFalla + "_7_FINAL.pdf");
                //bytesFinal = myWebClient.DownloadData("http://www.cndc.bo/media/archivos/archivos/analisisdefalla_150360_7_FINAL.pdf");
            }
            catch (WebException webEx)
            {
                CNDC.Pistas.PistaMgr.Instance.EscribirLog("InsertAnalisisFallaRectifocatorio", "Error: no se encuentra el archivo en la url para el final: " + webEx.Message, CNDC.Pistas.TipoPista.Error);
            }
            if (bytesRectificatorio != null)
            {
                int tipoInforme = Convert.ToInt32(parametro.TipoInforme);
                this.saveDocAnalisis(bytesRectificatorio, parametro.CodFalla, tipoInforme, parametro.Origen);
                return bytesRectificatorio;
            }
            else
            {
                if(bytesFinal != null)
                {
                    int tipoInforme = Convert.ToInt32(parametro.TipoInforme);
                    this.saveDocAnalisis(bytesFinal, parametro.CodFalla, tipoInforme, parametro.Origen);
                    return bytesFinal;
                }

            }
            return bytesRectificatorio;
        }

        private void saveDocAnalisis(byte[] bytes, int codFalla, int tipoInforme, long origen)
        {
            string sql = string.Empty;

            sql = @"
                INSERT INTO F_GF_DOC_ANALISIS(
                    PK_COD_FALLA, ARCHIVO, SINC_VER, 
                    NOMBRE_DOC_ANALISIS, CAUSA, OBSERVACIONES, 
                    DESCONEXION_COMPONENTE, PK_D_COD_TIPOINFORME, PK_ORIGEN_INFORME
                ) VALUES(
                    :NUM_INFORME, :ARCHIVO, null,
                    :NOMBRE_DOC_ANALISIS, null, :OBSERVACIONES,
                    null, :PK_D_COD_TIPOINFORME, :LPK_ORIGEN_INFORME
                )";

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("NUM_INFORME", codFalla);
            if(tipoInforme == 21)
                cmd.Parameters.Add("NOMBRE_DOC_ANALISIS", "analisisdefalla_" + codFalla + "_7_FINAL.pdf");
            else
                cmd.Parameters.Add("NOMBRE_DOC_ANALISIS", "analisisdefalla_" + codFalla + "_7_RECTIFICATORIO.pdf");
            cmd.Parameters.Add("OBSERVACIONES", "bajo desde web cndc");
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", tipoInforme);
            cmd.Parameters.Add("LPK_ORIGEN_INFORME", origen);

            OracleParameter param = cmd.Parameters.Add("ARCHIVO", OracleDbType.Blob);
            param.Direction = ParameterDirection.Input;
            param.Value = bytes;
            EjecutarComando(cmd, "ANALISIS");

        }

        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();
            RptInformeFallaParametroExtra parametro = (RptInformeFallaParametroExtra)_parametroExtra;
            string sql = string.Empty;
            InformeFalla informe = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(parametro.CodFalla,parametro.Origen, (long)parametro.TipoInforme);
            
            if ( informe.CodComponenteFallado != 0 )
            {
                sql =
                @"SELECT
                CONCAT(CONCAT(SUBSTR(F_GF_REGFALLA.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_REGFALLA.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
                TO_CHAR(F_GF_REGFALLA.FEC_INICIO,'DD/MM/YYYY HH24:MI:SS') AS FEC_INICIO,
                CONCAT( COMPO_FALLADO.NOMBRE_COMPONENTE,CONCAT('   ', COMPO_FALLADO.DESCRIPCION_COMPONENTE)) AS COMPONENTE_FALLADO,
                DOM_CAUSA.DESCRIPCION_DOMINIO AS CAUSA,
                DOM_ORIGEN.DESCRIPCION_DOMINIO AS ORIGEN,
                DOM_TIPODESCONEX.DESCRIPCION_DOMINIO AS TIPO_DESCONEX,
                F_GF_INFORMEFALLA.ELABORADO_POR AS NOM_OPERADOR,
                F_GF_INFORMEFALLA.DESCRIPCION_INFORME AS DESCRIPCION_FALLA,
                ORIGEN_INFORME.SIGLA AS AGENTE,
                DOM_TIPOINFORME.DESCRIPCION_DOMINIO AS TIPO_INFORME,
                TO_CHAR(F_GF_INFORMEFALLA.FECHA_REGISTRO,'DD/MM/YYYY HH24:MI:SS') AS FEC_ENVIO,
                F_GF_INFORMEFALLA.DESCRIPCION_INFORME AS DESCRIPCION_INFORME,
                F_GF_INFORMEFALLA.RESTITUCION AS RESTITUCION_INFORME,
                F_GF_INFORMEFALLA.INFORMACION_ADICIONAL AS INFADI_INFORME,
                F_GF_INFORMEFALLA.OPERACION_PROTECCIONES AS OPERARELES_INFORME,
                F_GF_INFORMEFALLA.NUM_FALLA_AGENTE AS NUM_FALLA_AGE,
                '' AS CAMPO1,
                '' AS CAMPO2
                FROM
                                        
                F_GF_INFORMEFALLA
                LEFT JOIN F_GF_REGFALLA ON F_GF_REGFALLA.PK_COD_FALLA = F_GF_INFORMEFALLA.PK_COD_FALLA
                LEFT JOIN F_AC_COMPONENTE COMPO_FALLADO ON F_GF_INFORMEFALLA.COD_COMPONENTE_FALLADO = COMPO_FALLADO.PK_COD_COMPONENTE
                LEFT JOIN P_DEF_DOMINIOS DOM_CAUSA ON DOM_CAUSA.COD_DOMINIO = F_GF_INFORMEFALLA.D_COD_CAUSA
                LEFT JOIN P_DEF_DOMINIOS DOM_ORIGEN ON F_GF_INFORMEFALLA.D_COD_ORIGEN = DOM_ORIGEN.COD_DOMINIO
                LEFT JOIN P_DEF_DOMINIOS DOM_TIPODESCONEX ON F_GF_INFORMEFALLA.D_COD_TIPO_DESCONEXION = DOM_TIPODESCONEX.COD_DOMINIO
                LEFT JOIN F_AP_PERSONA ORIGEN_INFORME ON F_GF_INFORMEFALLA.PK_ORIGEN_INFORME = ORIGEN_INFORME.PK_COD_PERSONA
                LEFT JOIN P_DEF_DOMINIOS DOM_TIPOINFORME ON F_GF_INFORMEFALLA.PK_D_COD_TIPOINFORME = DOM_TIPOINFORME.COD_DOMINIO                                        
                WHERE
                F_GF_INFORMEFALLA.PK_COD_FALLA = :NUM_INFORME AND  F_GF_INFORMEFALLA.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME AND F_GF_INFORMEFALLA.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME";
            }
            else
            {
                sql =
                @"SELECT
                CONCAT(CONCAT(SUBSTR(F_GF_REGFALLA.PK_COD_FALLA,-4,4),'-'),SUBSTR(to_char(F_GF_REGFALLA.PK_COD_FALLA, '099999', 'nls_numeric_characters='', '''),-6,2)) AS NUM_FALLA,
                TO_CHAR(F_GF_REGFALLA.FEC_INICIO,'DD/MM/YYYY HH24:MI:SS') AS FEC_INICIO,
                DOM_DESCRI.DESCRIPCION_DOMINIO AS COMPONENTE_FALLADO,
                DOM_CAUSA.DESCRIPCION_DOMINIO AS CAUSA,
                DOM_ORIGEN.DESCRIPCION_DOMINIO AS ORIGEN,
                DOM_TIPODESCONEX.DESCRIPCION_DOMINIO AS TIPO_DESCONEX,
                F_GF_INFORMEFALLA.ELABORADO_POR AS NOM_OPERADOR,
                F_GF_INFORMEFALLA.DESCRIPCION_INFORME AS DESCRIPCION_FALLA,
                ORIGEN_INFORME.SIGLA AS AGENTE,
                DOM_TIPOINFORME.DESCRIPCION_DOMINIO AS TIPO_INFORME,
                TO_CHAR(F_GF_INFORMEFALLA.FECHA_REGISTRO,'DD/MM/YYYY HH24:MI:SS') AS FEC_ENVIO,
                F_GF_INFORMEFALLA.DESCRIPCION_INFORME AS DESCRIPCION_INFORME,
                F_GF_INFORMEFALLA.RESTITUCION AS RESTITUCION_INFORME,
                F_GF_INFORMEFALLA.INFORMACION_ADICIONAL AS INFADI_INFORME,
                F_GF_INFORMEFALLA.OPERACION_PROTECCIONES AS OPERARELES_INFORME,
                F_GF_INFORMEFALLA.NUM_FALLA_AGENTE AS NUM_FALLA_AGE,
                '' AS CAMPO1,
                '' AS CAMPO2
                FROM
                                        
                F_GF_INFORMEFALLA
                LEFT JOIN F_GF_REGFALLA ON F_GF_REGFALLA.PK_COD_FALLA = F_GF_INFORMEFALLA.PK_COD_FALLA
                LEFT JOIN P_DEF_DOMINIOS DOM_DESCRI ON F_GF_REGFALLA.D_COD_PROBLEMA_GEN = DOM_DESCRI.COD_DOMINIO
                LEFT JOIN P_DEF_DOMINIOS DOM_CAUSA ON DOM_CAUSA.COD_DOMINIO = F_GF_INFORMEFALLA.D_COD_CAUSA
                LEFT JOIN P_DEF_DOMINIOS DOM_ORIGEN ON F_GF_INFORMEFALLA.D_COD_ORIGEN = DOM_ORIGEN.COD_DOMINIO
                LEFT JOIN P_DEF_DOMINIOS DOM_TIPODESCONEX ON F_GF_INFORMEFALLA.D_COD_TIPO_DESCONEXION = DOM_TIPODESCONEX.COD_DOMINIO
                LEFT JOIN F_AP_PERSONA ORIGEN_INFORME ON F_GF_INFORMEFALLA.PK_ORIGEN_INFORME = ORIGEN_INFORME.PK_COD_PERSONA
                LEFT JOIN P_DEF_DOMINIOS DOM_TIPOINFORME ON F_GF_INFORMEFALLA.PK_D_COD_TIPOINFORME = DOM_TIPOINFORME.COD_DOMINIO                                        
                WHERE
                F_GF_INFORMEFALLA.PK_COD_FALLA = :NUM_INFORME AND  F_GF_INFORMEFALLA.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME AND F_GF_INFORMEFALLA.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME";

            }

            OracleCommand cmd = CrearComando(sql);
            cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
            DataTable datos = EjecutarComando(cmd, "Datos");
            if ( datos.Rows.Count > 0 )
            {
                resultado.Add(datos);
                sql =
                @"SELECT C.* FROM
                (SELECT  A.* FROM
                (SELECT
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AS NUM_FALLA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS CODIGO,
                '' AS AGENTE,
                '' AS TIPO_INFORME,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
                F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DES,
                TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') AS FEC_APER,
                'TOTAL' AS USUARIO_INDIS,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD AS T_INDIS,
                F_AP_PERSONA.SIGLA AS USUARIO_PRECO,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION AS T_PRECO,
                F_AP_PERSONA.SIGLA AS USUARIO_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS T_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD + F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION + F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS TTOTAL_DESCONEXION,
                '' AS USUARIO_TOTAL,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_SISTEMA AS TIEMPO_SISTEMA,
                '' AS RESPONSABLE,
                '' AS NUM_FALLA_TD,
                UPPER(F_GF_RREGFALLA_COMPONENTE.FLUJO_N1_N2) AS CODIGO_TD,
                F_AP_PERSONA.SIGLA AS ASIGNADO,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_INDISPONIBILIDAD,0) AS T_INDIS_TD,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_PRECONEXION,0) AS T_PRECO_TD,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_CONEXION,0) AS T_CONEX_TD,
                0.0 AS T_SISTEMA_TD
                FROM
                F_GF_RREGFALLA_COMPONENTE
                LEFT JOIN F_GF_TIEMPOSDETALLE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_TIEMPOSDETALLE.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_TIEMPOSDETALLE.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_TIEMPOSDETALLE.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_TIEMPOSDETALLE.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_TIEMPOSDETALLE.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                LEFT JOIN F_AP_PERSONA ON F_GF_TIEMPOSDETALLE.PK_COD_PERSONA = F_AP_PERSONA.PK_COD_PERSONA
                WHERE
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
                    ) A
                UNION
                SELECT B.* FROM
                (
                SELECT

                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AS NUM_FALLA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS CODIGO,
                F_AP_PERSONA.SIGLA AS AGENTE,
                NULL AS TIPO_INFORME,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
                F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DES,
                TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') AS FEC_APER,
                NULL AS USUARIO_INDIS,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD AS T_INDIS,
                NULL AS USUARIO_PRECO,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION AS T_PRECO,
                NULL AS USUARIO_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS T_CONEX,
                0.00 AS TTOTAL_DESCONEXION,
                NULL AS USUARIO_TOTAL,
                0.00 AS TIEMPO_SISTEMA,
                NULL AS RESPONSABLE,
                NULL AS NUM_FALLA_TD,
                NULL AS  CODIGO_TD,
                NULL AS ASIGNADO,
                0.00 AS T_INDIS_TD,
                0.00 AS T_PRECO_TD,
                0.00 AS T_CONEX_TD,
                NULL AS T_SISTEMA_TD

                FROM
                F_GF_RREGFALLA_COMPONENTE
                LEFT JOIN F_GF_RESPONSABILIDAD ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_RESPONSABILIDAD.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_RESPONSABILIDAD.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_RESPONSABILIDAD.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_RESPONSABILIDAD.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_RESPONSABILIDAD.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                LEFT JOIN F_AP_PERSONA ON F_GF_RESPONSABILIDAD.PK_COD_PERSONA_RESPONSABLE = F_AP_PERSONA.PK_COD_PERSONA
                WHERE
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
                AND F_GF_RESPONSABILIDAD.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_RESPONSABILIDAD.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_RESPONSABILIDAD.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME                                            

                ) B
                UNION
                SELECT D.* FROM
                                            
                (

                SELECT DISTINCT
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AS NUM_FALLA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS CODIGO,
                '' AS AGENTE,
                '' AS TIPO_INFORME,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
                F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DES,
                TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') AS FEC_APER,
                '' AS USUARIO_INDIS,

                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD AS T_INDIS,
                '' AS USUARIO_PRECO,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION AS T_PRECO,
                '' AS USUARIO_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS T_CONEX,


                0.0 AS TTOTAL_DESCONEXION,
                '' AS USUARIO_TOTAL,
                0.0 AS TIEMPO_SISTEMA,
                '' AS RESPONSABLE,
                '' AS NUM_FALLA_TD,
                '' AS CODIGO_TD,
                '' AS ASIGNADO,
                0.0 AS T_INDIS_TD,
                0.0 AS T_PRECO_TD,
                0.0 AS T_CONEX_TD,
                0.0 AS T_SISTEMA_TD
                FROM
                F_GF_RREGFALLA_COMPONENTE
                LEFT JOIN F_GF_TIEMPOSDETALLE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_TIEMPOSDETALLE.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_TIEMPOSDETALLE.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_TIEMPOSDETALLE.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_TIEMPOSDETALLE.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_TIEMPOSDETALLE.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                WHERE
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME

                ) D
                ) C
                ORDER BY C.FEC_APER ASC,C.CODIGO ASC,C.USUARIO_INDIS ASC,C.AGENTE ASC";

                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
                cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
                DataTable compoCompro = EjecutarComando(cmd, "Compo_comprometidos");
                resultado.Add(compoCompro);

                sql =
                @"SELECT
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AS NUM_FALLA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS COD_COMPONENTE,
                TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') AS FEC_APER,
                F_AP_PERSONA.SIGLA AS RESPONSABLE_B,
                F_GF_RESPONSABILIDAD.TIEMPO_RESPONSABILIDAD AS TIEMPO_RESPON_B
                FROM
                F_GF_RREGFALLA_COMPONENTE
                INNER JOIN F_GF_RESPONSABILIDAD ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_RESPONSABILIDAD.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_RESPONSABILIDAD.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_RESPONSABILIDAD.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_RESPONSABILIDAD.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_RESPONSABILIDAD.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                LEFT JOIN F_AP_PERSONA ON F_GF_RESPONSABILIDAD.PK_COD_PERSONA_RESPONSABLE = F_AP_PERSONA.PK_COD_PERSONA
                WHERE
                    F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = :NUM_INFORME AND
                    F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                    F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
                ORDER BY F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA ASC,F_AC_COMPONENTE.NOMBRE_COMPONENTE ASC,F_AP_PERSONA.SIGLA ASC";

                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
                cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
                DataTable compoResponsables = EjecutarComando(cmd, "Compo_Responsables");
                resultado.Add(compoResponsables);

                sql =
                @"SELECT A.codigo, A.fec_aper, (a.t_indis - sum(a.T_indis_td)) AS T_indis_sum, (a.t_preco - sum(a.T_preco_td)) AS T_PRECO_sum, (a.t_conex - sum(a.T_conex_td)) AS T_conex_sum
                FROM
                (SELECT
                F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA AS NUM_FALLA,
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS CODIGO,
                '' AS AGENTE,
                '' AS TIPO_INFORME,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
                F_GF_RREGFALLA_COMPONENTE.POTENCIA_DESCONECTADA AS POT_DES,
                TO_DATE(TO_CHAR(F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') AS FEC_APER,
                'TOTAL' AS USUARIO_INDIS,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD AS T_INDIS,
                '' AS USUARIO_PRECO,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION AS T_PRECO,
                '' AS USUARIO_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS T_CONEX,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_INDISPONIBILIDAD + F_GF_RREGFALLA_COMPONENTE.TIEMPO_PRECONEXION + F_GF_RREGFALLA_COMPONENTE.TIEMPO_CONEXION AS TTOTAL_DESCONEXION,
                '' AS USUARIO_TOTAL,
                F_GF_RREGFALLA_COMPONENTE.TIEMPO_SISTEMA AS TIEMPO_SISTEMA,
                '' AS RESPONSABLE,
                '' AS NUM_FALLA_TD,
                UPPER(F_GF_RREGFALLA_COMPONENTE.FLUJO_N1_N2) AS CODIGO_TD,
                F_AP_PERSONA.SIGLA AS ASIGNADO,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_INDISPONIBILIDAD,0) AS T_INDIS_TD,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_PRECONEXION,0) AS T_PRECO_TD,
                nvl(F_GF_TIEMPOSDETALLE.TIEMPO_CONEXION,0) AS T_CONEX_TD,
                0.0 AS T_SISTEMA_TD
                FROM
                F_GF_RREGFALLA_COMPONENTE
                LEFT JOIN F_GF_TIEMPOSDETALLE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = F_GF_TIEMPOSDETALLE.PK_COD_FALLA AND F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = F_GF_TIEMPOSDETALLE.PK_ORIGEN_INFORME AND F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = F_GF_TIEMPOSDETALLE.PK_D_COD_TIPOINFORME AND F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_GF_TIEMPOSDETALLE.PK_COD_COMPONENTE AND F_GF_RREGFALLA_COMPONENTE.FEC_APERTURA = F_GF_TIEMPOSDETALLE.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_RREGFALLA_COMPONENTE.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                LEFT JOIN F_AP_PERSONA ON F_GF_TIEMPOSDETALLE.PK_COD_PERSONA = F_AP_PERSONA.PK_COD_PERSONA
                WHERE
                    F_GF_RREGFALLA_COMPONENTE.PK_COD_FALLA = :NUM_INFORME AND
                    F_GF_RREGFALLA_COMPONENTE.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                    F_GF_RREGFALLA_COMPONENTE.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME

                ) A
                GROUP BY A.fec_aper, A.codigo,a.t_indis,a.t_preco,a.t_conex
                ORDER BY a.FEC_APER ASC, a.CODIGO ASC";

                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
                cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
                DataTable compoSubtotales = EjecutarComando(cmd, "Compo_Subtotales");
                resultado.Add(compoSubtotales);

                foreach (DataRow rowCompo in compoCompro.Rows)
                {
                    bool esEliminado = false;
                    foreach (DataRow rowResp in compoResponsables.Rows)
                    {
                        if ( !esEliminado && rowCompo["CODIGO"].ToString() == rowResp["COD_COMPONENTE"].ToString() && rowCompo["FEC_APER"].ToString() == rowResp["FEC_APER"].ToString() )
                        {
                            rowCompo["RESPONSABLE"] = rowResp["RESPONSABLE_B"];
                            rowCompo["T_SISTEMA_TD"] = rowResp["TIEMPO_RESPON_B"];
                            rowResp.Delete();
                            esEliminado = true;
                        }
                    }
                    if ( esEliminado )
                    {
                        compoResponsables.AcceptChanges();
                    }
                }

                foreach (DataRow rowTot in compoSubtotales.Rows)
                {
                    bool esEliminado = false;
                    bool sisIndis = false;
                    bool sisPreco = false;
                    bool sisConex = false;
                    foreach (DataRow rowCompo in compoCompro.Rows)
                    {
                        if ( !esEliminado )
                        {
                            if ( !sisIndis && rowCompo["CODIGO"].ToString() == rowTot["CODIGO"].ToString() && rowCompo["FEC_APER"].ToString() == rowTot["FEC_APER"].ToString() && Decimal.Parse(rowCompo["T_INDIS_TD"].ToString()) == 0 )
                            {
                                rowCompo["ASIGNADO"] = "SISTEMA";
                                rowCompo["T_INDIS_TD"] = rowTot["T_INDIS_SUM"];
                                sisIndis = true;
                            }
                            if ( !sisPreco && rowCompo["CODIGO"].ToString() == rowTot["CODIGO"].ToString() && rowCompo["FEC_APER"].ToString() == rowTot["FEC_APER"].ToString() && Decimal.Parse(rowCompo["T_PRECO_TD"].ToString()) == 0 )
                            {
                                rowCompo["USUARIO_PRECO"] = "SISTEMA";
                                rowCompo["T_PRECO_TD"] = rowTot["T_PRECO_SUM"];
                                sisPreco = true;
                            }
                            if ( !sisConex && rowCompo["CODIGO"].ToString() == rowTot["CODIGO"].ToString() && rowCompo["FEC_APER"].ToString() == rowTot["FEC_APER"].ToString() && Decimal.Parse(rowCompo["T_CONEX_TD"].ToString()) == 0 )
                            {
                                rowCompo["USUARIO_CONEX"] = "SISTEMA";
                                rowCompo["T_CONEX_TD"] = rowTot["T_CONEX_SUM"];
                                sisConex = true;
                            }
                            if ( sisIndis && sisPreco && sisConex )
                            {
                                esEliminado = true;
                            }
                        }
                    }
                }

                sql =
                @"SELECT
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS CODIGO,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIPCION_COMPONENTE,
                TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_APERTURA, 'DD/MM/YYYY hh24:mi:ss:FF3') AS FECHA_APERTURA,
                DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_APER,79,'M',80,'A',81,'R','-') AS TIPO_APERTURA,
                TO_CHAR(F_GF_OP_INTERRUPTOR.FECHA_CIERRE, 'DD/MM/YYYY hh24:mi:ss:FF3') AS FECHA_CIERRE,
                DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_CIERRE,79,'M',80,'A',81,'R','-') AS TIPO_CIERRE,
                DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_CIERRE,79,'NO',80,DECODE(F_GF_OP_INTERRUPTOR.PK_D_COD_TIPO_OPER_APER,80,'SI','NO'),81,'NO','-') AS RECONECTADO,
                F_GF_RELES_OPER.TIPO_RELE AS TIPO_RELE,
                F_GF_RELES_OPER.FUNCION_RELE AS FUNCION_RELE,
                F_GF_RELES_OPER.TIEMPO_RELE AS TIEMPO_RELE,
                F_GF_RELES_OPER.ZONA_RELE AS ZONA_RELE,
                F_GF_RELES_OPER.DISTANCIA_RELE AS DISTANCIA_RELE,
                '' AS CAMPO1,
                '' AS CAMPO2
                FROM
                F_GF_OP_INTERRUPTOR
                LEFT JOIN F_GF_RELES_OPER ON F_GF_OP_INTERRUPTOR.PK_COD_FALLA = F_GF_RELES_OPER.PK_COD_FALLA AND F_GF_RELES_OPER.PK_COD_COMPONENTE = F_GF_OP_INTERRUPTOR.PK_COD_COMPONENTE AND F_GF_OP_INTERRUPTOR.PK_ORIGEN_INFORME = F_GF_RELES_OPER.PK_ORIGEN_INFORME AND F_GF_OP_INTERRUPTOR.PK_D_COD_TIPOINFORME = F_GF_RELES_OPER.PK_D_COD_TIPOINFORME AND F_GF_OP_INTERRUPTOR.FECHA_APERTURA = F_GF_RELES_OPER.FEC_APERTURA
                LEFT JOIN F_AC_COMPONENTE ON F_GF_OP_INTERRUPTOR.PK_COD_COMPONENTE = F_AC_COMPONENTE.PK_COD_COMPONENTE
                WHERE
                F_GF_OP_INTERRUPTOR.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_OP_INTERRUPTOR.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_OP_INTERRUPTOR.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME";

                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
                cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
                DataTable interrruptoresReles = EjecutarComando(cmd, "Interrruptores_reles");
                resultado.Add(interrruptoresReles);

                sql = @"SELECT
                F_AC_COMPONENTE.NOMBRE_COMPONENTE AS COD_ALIMENTADOR,
                F_AC_COMPONENTE.DESCRIPCION_COMPONENTE AS DESCRIP_ALIMENTADOR,
                TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS') AS FECHA_APERTURA,
                DECODE(F_GF_OP_ALIMENTADOR.D_COD_TIPO_OPER_APER,79,'M',80,'A',81,'R','-') AS TIPO_APERTURA,
                F_GF_PARAM_EDAC.TIPO_EDAC AS ETAPA_EDAC,
                to_char(F_GF_PARAM_EDAC.AJUSTE_EDAC,'90.99') || ' [Hz] ' AS FRECUENCIA_EDAC,
                F_GF_PARAM_EDAC.ETAPA_EDAC AS TIEMPO_EDAC,
                TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS') AS FECHA_CIERRE,
                DECODE(F_GF_OP_ALIMENTADOR.D_COD_TIPO_OP_CIERRE,79,'M',80,'A',81,'R','-') AS TIPO_CIERRE,
                DECODE(F_GF_OP_ALIMENTADOR.RELE_OPERADO,0,'NO',1,'SI','-') AS RELE_OPERADO,
                F_GF_OP_ALIMENTADOR.POT_DESC,
                ROUND(24*60*(to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') - to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS')),2) AS MINUTOS_POTENCIA,
                ROUND((ROUND((ROUND(24*60*(to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_CIERRE,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS') - to_date(TO_CHAR(F_GF_OP_ALIMENTADOR.FECHA_APERTURA,'DD/MM/YYYY HH24:MI:SS'),'DD/MM/YYYY HH24:MI:SS')),2)*F_GF_OP_ALIMENTADOR.POT_DESC),2)/60),2) AS ENERGIA_NOSUMIN,
                '' AS CAMPO1,
                '' AS CAMPO2
                FROM
                F_GF_OP_ALIMENTADOR
                LEFT JOIN F_GF_PARAM_EDAC ON F_GF_OP_ALIMENTADOR.COD_EDAC = F_GF_PARAM_EDAC.PK_COD_EDAC
                LEFT JOIN F_AC_COMPONENTE ON F_AC_COMPONENTE.PK_COD_COMPONENTE = F_GF_OP_ALIMENTADOR.PK_COD_COMPONENTE
                WHERE
                F_GF_OP_ALIMENTADOR.PK_COD_FALLA = :NUM_INFORME AND
                F_GF_OP_ALIMENTADOR.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME AND
                F_GF_OP_ALIMENTADOR.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME";

                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("PK_D_COD_TIPOINFORME", (long)parametro.TipoInforme);
                cmd.Parameters.Add("PK_ORIGEN_INFORME", parametro.Origen);
                DataTable alimentadores = EjecutarComando(cmd, "Alimentadores");
                resultado.Add(alimentadores);

                sql = @"SELECT
                F_GF_DOC_ANALISIS.PK_COD_FALLA,
                F_GF_DOC_ANALISIS.ARCHIVO AS ARCHIVO
                FROM
                F_GF_DOC_ANALISIS
                WHERE
                F_GF_DOC_ANALISIS.PK_COD_FALLA = :NUM_INFORME
                AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme";
                cmd = CrearComando(sql);
                cmd.Parameters.Add("NUM_INFORME", parametro.CodFalla);
                cmd.Parameters.Add("pk_d_cod_tipoinforme", (long)parametro.TipoInforme);
                _tablaAnalisis = EjecutarComando(cmd, "Analisis");
                resultado.Add(_tablaAnalisis);
            }
            return resultado;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }

        public override List<ToolStripButton> GetBotonesAdicionales()
        {
            List<ToolStripButton> resultado = new List<ToolStripButton>();
            RptInformeFallaParametroExtra parametro = (RptInformeFallaParametroExtra)_parametroExtra;
            //if ( _tablaAnalisis.Rows.Count > 0 && parametro.TipoInforme != PK_D_COD_TIPOINFORME.PRELIMINAR )
            if (parametro.TipoInforme != PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                resultado.Add(_btnAnalisisFalla);
            }
            return resultado;
        }
    }

    public class RptInformeFallaParametroExtra : ParametroExtra
    {
        public int CodFalla { get; private set; }
        public long Origen { get; private set; }
        public PK_D_COD_TIPOINFORME TipoInforme { get; private set; }

        public RptInformeFallaParametroExtra(int codFalla, long origen, PK_D_COD_TIPOINFORME tipoInf)
        {
            CodFalla = codFalla;
            Origen = origen;
            TipoInforme = tipoInf;
        }
    }
}
