using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using ModeloSisFalla;
using CNDC.Dominios;
using CNDC.UtilesComunes;

namespace DifusionInformacion
{
    class PredespachoCurvaDiaria: Generador
    {
        public static List<ConfigCurvasAlerta> _config = new List<ConfigCurvasAlerta>();
        public override void GenerarArchivosAreaPublicaExtra()
        {
            
        }
        public static void IniciarConfiguracion()
        {
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "SUBTOTAL HIDRO", EtiquetaDestino = "THID", ColumnaBuscar = 1});
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "SUBTOTAL EOLICO", EtiquetaDestino = "TEOL", ColumnaBuscar = 1 });
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "SUBTOTAL TERMO", EtiquetaDestino = "TTER", ColumnaBuscar = 1});
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "RESERVA ROTANTE",EtiquetaDestino = "RROT" , ColumnaBuscar = 1});
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "RESERVA PARADA", EtiquetaDestino = "RPAR" , ColumnaBuscar = 1});
            _config.Add(new ConfigCurvasAlerta { NombreHoja = "PRED", EtiquetaOrigen = "Déficit de Potencia del SIN", EtiquetaDestino = "DEF" , ColumnaBuscar = 1});
        }

        public override List<detallePublicado> CopiarArchivosOrigenExtra()
        {
            return new List<detallePublicado>();
        }

        public override List<detallePublicado> CopiarArchivosOrigen(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosRenombrados(categoria))
            {
                resultado.AddRange(UtilPublicar.CopiarArchivoLocalmente(UtilesExtraFecha.GetArchivoDeCarpeta(ConfigPublicacion.rutaServidorOrigen, archivo.nombreArchivo + archivo.extensionArchivo), archivo.archivoGenerado + archivo.extensionArchivoGenerado, archivo.generarZIP, true));
            }
            return resultado;
        }

        public override List<detallePublicado> PublicarArchivosExtra(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            IniciarConfiguracion();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosRenombrados(categoria))
            {
                resultado.AddRange(UtilExcel.ParsearHojaExcelCargaCurva(archivo,ConfigPublicacion.rutaLocal, _config));
                UtilPublicar.LimpiarArchivoOrigen(UtilesExtraFecha.GetArchivoDeCarpeta(ConfigPublicacion.rutaServidorOrigen, archivo.nombreArchivo + archivo.extensionArchivo));
            }
            return resultado;
        }

        public override void SetOperacionPublicacion(DateTime fecha,string motivo)
        {
            Operacion opn = new Operacion();
            opn.RegistrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION.PUBLICACION_CURVAS_PRE_DIARIO, UtilesExtraFecha.FormatearRutaArchivo(ConfigPublicacion.formatoNombreArchivo), ConfigPublicacion.idCategoria, fecha, motivo);
        }
        
    }
    public class ConfigCurvasAlerta
    {
        public string NombreHoja { get; set; }
        public string EtiquetaOrigen { get; set; }
        public string EtiquetaDestino { get; set; }
        public int ColumnaBuscar { get; set; }
    }
}
