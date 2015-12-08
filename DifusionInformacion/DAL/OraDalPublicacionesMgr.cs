using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using System.Data;
using System.ComponentModel;
using DifusionInformacion;

namespace SISFALLA
{
    class OraDalPublicacionesMgr
    {
        string consultaArchivosPorCategoria = @"SELECT
                                A.COD_CATEGORIA,
                                A.DESCRIPCION_FORMATO AS TITULO,
                                A.NOMBRE_ORIGEN_FORMATO,
                                A.NOMBRE_ORIGEN_EXT,
                                A.ARCHIVO_FORMATO,
                                A.ARCHIVO_FORMATO_EXT,
                                A.NOMBRE_HOJA,
                                A.RANGO_HOJA,
                                A.ARCHIVO_FORMATO_ZIP,
                                A.ARCHIVO_GENERADO,
                                A.ARCHIVO_RENOMBRADO,
                                A.DESTINO_AREA_PUB_WEB,
                                A.DESTINO_AREA_PRI_WEB,
                                A.DESTINO_INTRANET,
                                A.DESTINO_INTRANET_ESTADISTICA,
                                A.DESTINO_INFOCNDC,
                                A.COD_CATEGORIA_WEB_PUB,
                                A.TABLA_WEB_PUB,
                                A.COD_CATEGORIA_WEB_PRI,
                                A.TABLA_WEB_PRI,
                                A.COD_CATEGORIA_INTRANET,
                                A.TABLA_INTRANET,
                                A.COD_CATEGORIA_INTRANET_ESTAD,
                                A.TABLA_INTRANET_ESTAD
                                FROM
                                P_DEF_ARCHIVOSPUBLICADOS A
            ";
        private bool PrepararCategoria(int num)
        {
            bool val = false;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = @"SELECT
                                C.COD_CATEGORIA,
                                B.USUARIO,
                                B.PASSWORD,
                                A.NOMBRE_SERVIDOR,
                                A.DIRECCION AS DIRECCION_SERVIDOR,
                                C.DESCRIPCION_CATEGORIA,
                                C.FORMATO_NOMBRE,
                                C.CARPETA_ORIGEN,
                                C.DIR_INTRANET,
                                C.CARPETA_DESTINO,
                                C.TABLA_INTRANET,
                                C.PK_COD_INTRANET,
                                C.CARPETA_AUX AS NOM_INTRANET
                                FROM
                                QUANTUM.P_DEF_SERVIDOR A,
                                QUANTUM.P_DEF_CONEXION B,
                                QUANTUM.P_DEF_CATPUBLICACION C
                                WHERE
                                B.COD_SERVIDOR = A.COD_SERVIDOR AND B.COD_CONEXION = C.COD_CONEXION AND C.COD_DESCRIPCION=:COD_CATEGORIA";
            cmd.Parameters.Add("COD_CATEGORIA", num);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                //_regServidor = new RegistroServidor();
                //_regServidor.llenaRegistro(tabla.Rows[0]);
                val = true;
            }
            else
            {
             
            }
            return val;
        }
        /*
        public BindingList<OperacionAlimentador> GetLista()
        {
            BindingList<OperacionAlimentador> resultado = new BindingList<OperacionAlimentador>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new OperacionAlimentador(row));
            }
            return resultado;
        }*/


        public List<Archivo> GetArchivosAreaPublicaGeneracionHtml(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_AREA_PUB_WEB = 1
            AND
            A.ARCHIVO_FORMATO_EXT LIKE '%htm%'
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosAreaPublicaGeneracionXls(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.ARCHIVO_GENERADO = 1
            AND
            A.ARCHIVO_FORMATO_EXT LIKE '%xls%'
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }

        public List<Archivo> GetArchivosAreaPublicaPublicacion(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_AREA_PUB_WEB = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosAreaPrivadaPublicacion(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_AREA_PRI_WEB = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosIntranetEstadisticasPublicacion(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_INTRANET_ESTADISTICA = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosIntranetPublicacion(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_INTRANET = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosInfocndcPublicacion(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.DESTINO_INFOCNDC = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<Archivo> GetArchivosRenombrados(int categoria)
        {
            List<Archivo> resultado = new List<Archivo>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = consultaArchivosPorCategoria + @" WHERE
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.ARCHIVO_RENOMBRADO = 1
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Archivo(row));
            }
            return resultado;
        }
        public List<detallePublicado> GetUltimaPublicacionPorCategoria(int categoria, DateTime fecha)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = @"SELECT *
            FROM
            (
            SELECT
            'Base de Datos' AS DESTINO, A.ID_OPERACION, A.DETALLE AS ARCHIVO, A.MOTIVO_PUBLICACION AS MOTIVO, B.FECHA_TRANSACCION AS ULTIMA_PUBLICACION
            FROM
            F_DI_OPERACION A, F_SEC_LOG B
            WHERE
            A.SEC_LOG = B.COD_SEC_LOG
            AND
            A.COD_CATEGORIA = :COD_CATEGORIA
            AND
            A.FECHA_OPERACION = :FECHA

            ORDER BY B.FECHA_TRANSACCION DESC
            )
            WHERE ROWNUM < 2
            ";
            cmd.Parameters.Add("COD_CATEGORIA", OracleDbType.Decimal, categoria, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA", OracleDbType.Date, fecha.Date, ParameterDirection.Input);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new detallePublicado(row["ARCHIVO"].ToString(), row["DESTINO"].ToString(), "Ultima Publicacion :" + row["ULTIMA_PUBLICACION"] + " - " + row["MOTIVO"].ToString()));
            }
            return resultado;
        }
        public DataRow GetConfiguracionCategoria(int categoria)
        {
            DataRow resultado = null;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = @"SELECT
                        A.COD_CATEGORIA,
                        A.DESCRIPCION_CATEGORIA,
                        'http://' || SERVER_WEB.NOMBRE_SERVIDOR || DOM_WEB.RUTA_SERVIDOR AS RUTA_SERVIDOR_WEB_HTTP,
                        A.CARPETA_ORIGEN,
                        A.CARPETA_DESTINO,
                        A.CARPETA_AUX AS CARPETA_LOCAL,
                        A.FORMATO_NOMBRE,
                        A.RUTA_VERIFICACION_WEB,
                        A.RUTA_VERIFICACION_INTRANET,
                        SERVER_WEB.NOMBRE_SERVIDOR,
                        DOM_WEB.USUARIO,
                        DOM_WEB.PASSWORD,
                        DOM_WEB.RUTA_SERVIDOR AS RUTA_SERVIDOR_WEB,
                        'http://' || SERVER_INTRA.NOMBRE_SERVIDOR || DOM_INTRA.RUTA_SERVIDOR AS RUTA_SERVIDOR_INTRANET,
                        'http://' || SERVER_INFOCNDC.NOMBRE_SERVIDOR || DOM_INFOCNDC.RUTA_SERVIDOR AS RUTA_SERVIDOR_INFOCNDC,
                        DOM_INTRA.CADENA_CONEXION AS CADENA_CONEXION_INTRANET,
                        DOM_WEB.CADENA_CONEXION AS CADENA_CONEXION_WEB,
                        A.RUTA_AREA_PRIVADA,
                        A.RUTA_AREA_PUBLICA,
                        A.RUTA_CARPINTRANET,
                        A.RUTA_CARPESTADISTICA,
                        A.RUTA_CARPINFOCNDC
                        FROM
                        P_DEF_CATPUBLICACION A
                        LEFT JOIN P_DEF_CONEXION DOM_WEB ON A.COD_CONEXION = DOM_WEB.COD_CONEXION
                        LEFT JOIN P_DEF_SERVIDOR SERVER_WEB ON DOM_WEB.COD_SERVIDOR = SERVER_WEB.COD_SERVIDOR
                        LEFT JOIN P_DEF_CONEXION DOM_INTRA ON A.COD_CONEXION_INTRANET = DOM_INTRA.COD_CONEXION
                        LEFT JOIN P_DEF_CONEXION DOM_INFOCNDC ON A.COD_CONEXION_INFOCNDC = DOM_INFOCNDC.COD_CONEXION
                        LEFT JOIN P_DEF_SERVIDOR SERVER_INTRA ON SERVER_INTRA.COD_SERVIDOR = DOM_INTRA.COD_SERVIDOR
                        LEFT JOIN P_DEF_SERVIDOR SERVER_INFOCNDC ON SERVER_INFOCNDC.COD_SERVIDOR = DOM_INFOCNDC.COD_SERVIDOR
                        WHERE
                        A.COD_CATEGORIA = :COD_CATEGORIA
            ";
            cmd.Parameters.Add("COD_CATEGORIA", categoria);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = tabla.Rows[0];
            }
            return resultado;
            
        }
    }
}
