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
    class Predespacho: Generador
    {

        public override void GenerarArchivosAreaPublicaExtra()
        {
            
        }
        public override void LLamarSiguienteOpcion()
        {
            EjecutarCurvas();
        }

        public override List<detallePublicado> CopiarArchivosOrigenExtra()
        {
            return UtilPublicar.CopiarArchivoLocalmente(UtilesExtraFecha.GetDatosZipPredespacho(ConfigPublicacion.rutaServidorOrigen), "dpre#DIA##MES##ANIO#.zip",false,false);
        }
        public override List<detallePublicado> CopiarArchivosOrigen(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosRenombrados(categoria))
            {
                resultado.AddRange(UtilPublicar.CopiarArchivoLocalmente(Path.Combine(ConfigPublicacion.rutaServidorOrigen, archivo.nombreArchivo + archivo.extensionArchivo), archivo.archivoGenerado + archivo.extensionArchivoGenerado,archivo.generarZIP,false));
            }
            return resultado;
        }
        public override List<detallePublicado> PublicarArchivosExtra(int categoria)
        {
            return new List<detallePublicado>();
        }

        
        public override void SetOperacionPublicacion(DateTime fecha, string motivo)
        {

                Operacion opn = new Operacion();
                opn.RegistrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION.PUBLICACION_PREDESPACHO_DIARIO, UtilesExtraFecha.FormatearRutaArchivo(ConfigPublicacion.formatoNombreArchivo), ConfigPublicacion.idCategoria, fecha, motivo);

        }
    }
}
