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
    class Contingencias: Generador
    {

        public override void GenerarArchivosAreaPublicaExtra()
        {
            
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
                resultado.AddRange(UtilPublicar.CopiarArchivoLocalmente(UtilesExtraFecha.GetArchivoDeCarpeta(ConfigPublicacion.rutaServidorOrigen, archivo.nombreArchivo + archivo.extensionArchivo), archivo.archivoGenerado + archivo.extensionArchivoGenerado, archivo.generarZIP, false));
            }
            return resultado;
        }
        public override List<detallePublicado> PublicarArchivosExtra(int categoria)
        {
            return new List<detallePublicado>();
        }

        public override List<string> GetArchivosAdjuntosPorCategoria(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            List<string> resultado = new List<string>();
            UtilesExtraFecha.SetFechas(fechaInicio, fechaFinal, fechaInicio);
            resultado.Add(UtilesExtraFecha.FormatearRutaArchivo(ConfigPublicacion.formatoNombreArchivo));
            return resultado;
        }

        public override List<detallePublicado> GetArchivosPreparados(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            UtilesExtraFecha.SetFechas(fechaInicio, fechaFinal, fechaInicio);
                resultado.AddRange(GenerarArchivosLocalmente(categoria));

            return resultado;

        }
        public override List<detallePublicado> GetArchivosPublicados(DateTime fechaInicio, DateTime fechaFinal, int categoria,string motivo)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
            {
                UtilesExtraFecha.SetFechas(fechaInicio, fechaFinal,fecha);
                resultado.AddRange(PublicarArchivos(categoria));
            }
                if (!ExisteErrorProceso(resultado))
                {
                    enviarMail(fechaInicio, fechaFinal, categoria);
                    foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
                    {
                        UtilesExtraFecha.SetFechas(fechaInicio, fechaFinal,fecha);
                        SetOperacionPublicacion(resultado, fecha, motivo);
                    }
                }
            return resultado;

        }
        public override void SetOperacionPublicacion(DateTime fecha, string motivo)
        {
                Operacion opn = new Operacion();
                opn.RegistrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION.PUBLICACION_CONTINGENCIAS_DIARIO, UtilesExtraFecha.FormatearRutaArchivo(ConfigPublicacion.formatoNombreArchivo), ConfigPublicacion.idCategoria, fecha, motivo);
        }
    }
}
