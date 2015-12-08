using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;

namespace DifusionInformacion
{
    class ConfigPublicacion
    {


        public static long idCategoria { get; set; }
        public static string descripcionCategoria { get; set; }
        public static string cuentaWeb { get; set; }
        public static string claveWeb { get; set; }
        public static string nombreServidorWeb { get; set; }
        public static string formatoNombreArchivo { get; set; }
        public static string rutaLocal { get; set; }
        public static string rutaServidorOrigen { get; set; }
        public static string rutaServidorDestino { get; set; }
        public static string rutaServidorWeb { get; set; }
        public static string rutaServidorIntranet { get; set; }
        public static string rutaServidorInfocndc { get; set; }
        public static string rutaAreaPrivada { get; set; }
        public static string rutaAreaPublica { get; set; }
        public static string rutaCapertaIntranet { get; set; }
        public static string rutaCapertaIntranetEstadistica { get; set; }
        public static string rutaCarpetaInfocndc { get; set; }
        public static string rutaVerificacionWeb { get; set; }
        public static string rutaVerificacionIntranet { get; set; }

        public static string conexionWeb { get; set; }
        public static string conexionIntranet { get; set; }
        public static string conexionSpectrum { get; set; }

        public ConfigPublicacion(DataRow dataRow)
        { Leer(dataRow); }

        public static void Leer(DataRow dataRow)
        {
            idCategoria = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA"]);
            descripcionCategoria = ObjetoDeNegocio.GetValor<string>(dataRow["DESCRIPCION_CATEGORIA"]);
            cuentaWeb = ObjetoDeNegocio.GetValor<string>(dataRow["USUARIO"]);
            claveWeb = ObjetoDeNegocio.GetValor<string>(dataRow["PASSWORD"]);
            nombreServidorWeb = ObjetoDeNegocio.GetValor<string>(dataRow["NOMBRE_SERVIDOR"]);
            rutaLocal = ObjetoDeNegocio.GetValor<string>(dataRow["CARPETA_LOCAL"]);
            rutaServidorOrigen = ObjetoDeNegocio.GetValor<string>(dataRow["CARPETA_ORIGEN"]);
            rutaServidorDestino = ObjetoDeNegocio.GetValor<string>(dataRow["CARPETA_DESTINO"]);
            rutaServidorWeb = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_SERVIDOR_WEB"]);
            rutaServidorIntranet = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_SERVIDOR_INTRANET"]);
            rutaServidorInfocndc = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_SERVIDOR_INFOCNDC"]);
            rutaAreaPrivada = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_AREA_PRIVADA"]);
            rutaAreaPublica = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_AREA_PUBLICA"]);
            rutaCapertaIntranet = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_CARPINTRANET"]);
            rutaCapertaIntranetEstadistica = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_CARPESTADISTICA"]);
            rutaCarpetaInfocndc = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_CARPINFOCNDC"]);
            formatoNombreArchivo = ObjetoDeNegocio.GetValor<string>(dataRow["FORMATO_NOMBRE"]);
            conexionWeb = ObjetoDeNegocio.GetValor<string>(dataRow["CADENA_CONEXION_WEB"]);
            conexionIntranet = ObjetoDeNegocio.GetValor<string>(dataRow["CADENA_CONEXION_INTRANET"]);
            rutaVerificacionWeb = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_VERIFICACION_WEB"]);
            rutaVerificacionIntranet = ObjetoDeNegocio.GetValor<string>(dataRow["RUTA_VERIFICACION_INTRANET"]);
            if (dataRow.Table.Columns.Contains("CADENA_CONEXION_SPECTRUM"))
            {
                conexionSpectrum = ObjetoDeNegocio.GetValor<string>(dataRow["CADENA_CONEXION_SPECTRUM"]);
            }
        }

    }
}
