using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISFALLA;
using CNDC.BaseForms;
using MenuQuantum;
using System.Windows.Forms;
using SisFallaEmailLib;
using System.IO;
using CNDC.Pistas;
using CNDC.BLL;
using CNDC.UtilesComunes;

namespace DifusionInformacion
{
    abstract class Generador
    {
        public OraDalPublicacionesMgr PublicacionesMgr = new OraDalPublicacionesMgr();
        public ParametrosFuncionalidad Parametros {get;set;}

        public List<detallePublicado> GenerarArchivosLocalmente(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            resultado.AddRange(CopiarArchivosOrigen(categoria));
            resultado.AddRange(CopiarArchivosOrigenExtra());
            resultado.AddRange(GenerarArchivosHtmHojaExcel(categoria));
            //GenerarArchivosAreaPublicaExtra();
            //GenerarArchivosAreaPrivada();
            return resultado;
        }
        public abstract List<detallePublicado> CopiarArchivosOrigenExtra();
        public abstract List<detallePublicado> CopiarArchivosOrigen(int categoria);
        public abstract List<detallePublicado> PublicarArchivosExtra(int categoria);
        
        public virtual void LLamarSiguienteOpcion()
        {
        }

        protected void EjecutarCurvas()
        {
            if (MessageBox.Show("Desea publicar las Curvas Correspondientes ?","Consulta",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CNDCMenu.Instancia.EjecutarOpcion(105, null);    
            }
        }

        public virtual void SetOperacionPublicacion(List<detallePublicado> resultado, DateTime fecha,string motivo)
        {
            if (!ExisteErrorProceso(resultado))
            {
                    SetOperacionPublicacion(fecha,motivo);
            }
        }
        public abstract void SetOperacionPublicacion(DateTime fecha, string motivo);

        public abstract void GenerarArchivosAreaPublicaExtra();

        public virtual void GenerarArchivosAreaPrivada() { }

        public virtual List<detallePublicado> GetArchivosPreparados(DateTime fechaInicio, DateTime fechaFinal,int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            InvocadorEnvioArchivos invocador = new InvocadorEnvioArchivos();
            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
            {
                UtilesExtraFecha.SetFechas(fecha, fechaFinal, fecha);
                
                invocador.Categoria = categoria;
                invocador.Generador = this;
                FormTareaAsincrona tarea = new FormTareaAsincrona();
                tarea.Visualizar("Preparando archivos...", "Preparando...", invocador.Preparar);
                resultado.AddRange(invocador.Detalle);
                
            }
            return resultado;
        }
        public virtual List<detallePublicado> GetArchivosCopiados(DateTime fechaInicio, DateTime fechaFinal,int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            InvocadorEnvioArchivos invocador = new InvocadorEnvioArchivos();

            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
            {
                UtilesExtraFecha.SetFechas(fecha, fechaFinal, fecha);
                invocador.Categoria = categoria;
                invocador.Generador = this;
                FormTareaAsincrona tarea = new FormTareaAsincrona();
                tarea.Visualizar("Enviando archivos...", "Enviando...", invocador.Enviar);
                resultado.AddRange(invocador.Detalle);
            }
            return resultado;

        }
        public virtual List<detallePublicado> GetArchivosPublicados(DateTime fechaInicio, DateTime fechaFinal,int categoria, string motivo)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            InvocadorEnvioArchivos invocador = new InvocadorEnvioArchivos();

            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
            {
                UtilesExtraFecha.SetFechas(fecha, fechaFinal, fecha);
                invocador.Categoria = categoria;
                invocador.Generador = this;
                FormTareaAsincrona tarea = new FormTareaAsincrona();
                tarea.Visualizar("Publicando archivos...", "Publicando...", invocador.Publicar);
                resultado.AddRange(invocador.Detalle);
            }
            if (!ExisteErrorProceso(resultado))
            {
                enviarMail(fechaInicio, fechaFinal, categoria);
                foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
                {
                    UtilesExtraFecha.SetFechas(fecha, fechaFinal, fecha);
                    SetOperacionPublicacion(resultado, fecha,motivo);
                }
            }
            return resultado;
        }

        public List<detallePublicado> GenerarArchivosHtmHojaExcel(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPublicaGeneracionXls(categoria))
            {
                resultado.AddRange(UtilExcel.GenerarXlsHojaPublica(archivo,ConfigPublicacion.rutaLocal));
                
            }
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPublicaGeneracionHtml(categoria))
            {
                resultado.AddRange(UtilExcel.GenerarHtmHojaPublica(archivo, ConfigPublicacion.rutaLocal));
            }
            
            return resultado;
        }


        public List<detallePublicado> EnviarArchivos(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            resultado.AddRange(EnviarWebPrivada(categoria));
            resultado.AddRange(EnviarWebPublica(categoria));
            resultado.AddRange(EnviarIntranet(categoria));
            resultado.AddRange(EnviarInfocndc(categoria));
            return resultado;
        }

        private List<detallePublicado> EnviarInfocndc(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosInfocndcPublicacion(categoria))
            {
                resultado.AddRange(UtilPublicar.PublicarServidorLocal(ConfigPublicacion.rutaCarpetaInfocndc, archivo,true));
                PistaMgr.Instance.Info("DifInfo:Envio Infocndc", string.Format("Envio InfoCNDC: {0}",UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            }
            return resultado;
        }

        private List<detallePublicado> EnviarWebPublica(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPublicaPublicacion(categoria))
            {
                resultado.AddRange(UtilPublicar.EnviarArchivosHaciaWeb(ConfigPublicacion.rutaAreaPublica,archivo));
                PistaMgr.Instance.Info("DifInfo:Envio Web Publica", string.Format("Envio Web Publica: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            }
            return resultado;
        }

        private List<detallePublicado> EnviarWebPrivada(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPrivadaPublicacion(categoria))
            {
                resultado.AddRange(UtilPublicar.EnviarArchivosHaciaWeb(ConfigPublicacion.rutaAreaPrivada, archivo));
                PistaMgr.Instance.Info("DifInfo:Envio Web Privada", string.Format("Envio Web Privada: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            }
            return resultado;
        }
        private List<detallePublicado> EnviarIntranet(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosIntranetPublicacion(categoria))
            {
                resultado.AddRange(UtilPublicar.PublicarServidorLocal(ConfigPublicacion.rutaCapertaIntranet,archivo,false));
                PistaMgr.Instance.Info("DifInfo:Envio Intranet", string.Format("Envio Intranet: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            }
            foreach (Archivo archivo in PublicacionesMgr.GetArchivosIntranetEstadisticasPublicacion(categoria))
            {
                resultado.AddRange(UtilPublicar.PublicarServidorLocal(ConfigPublicacion.rutaCapertaIntranetEstadistica, archivo,false)); 
            }
            return resultado;
        }
        public List<detallePublicado> PublicarArchivos(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            resultado.AddRange(PublicarWebPrivada(categoria));
            resultado.AddRange(PublicarWebPublica(categoria));
            resultado.AddRange(PublicarIntranet(categoria));
            resultado.AddRange(PublicarIntranetEstadisticas(categoria));
            resultado.AddRange(PublicarArchivosExtra(categoria));
            return resultado;
        }

        private List<detallePublicado> PublicarIntranetEstadisticas(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
                foreach (Archivo archivo in PublicacionesMgr.GetArchivosIntranetEstadisticasPublicacion(categoria))
                {
                    resultado.Add(UtilPublicar.PublicarBaseDatosIntranet(archivo.tablaIntranetEstadistica, archivo.numeroCategoriaIntranetEstadistica, archivo));
                    PistaMgr.Instance.Info("DifInfo:Pub IntraEstadis", string.Format("Publicado Intranet Estadistica: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
                }
            return resultado;
        }

        private List<detallePublicado> PublicarIntranet(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
                foreach (Archivo archivo in PublicacionesMgr.GetArchivosIntranetPublicacion(categoria))
                {
                    resultado.Add(UtilPublicar.PublicarBaseDatosIntranet(archivo.tablaIntranet, archivo.numeroCategoriaIntranet, archivo));
                    PistaMgr.Instance.Info("DifInfo:Pub Intranet", string.Format("Publicado Intranet: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
                }
            return resultado;
        }

        private List<detallePublicado> PublicarWebPublica(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();

                foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPublicaPublicacion(categoria))
                {
                    resultado.Add(UtilPublicar.PublicarBaseDatosWeb(archivo.tablaWebPublica, archivo.numeroCategoriaWebPub,archivo));
                    PistaMgr.Instance.Info("DifInfo:Pub Web Publica", string.Format("Publicado Web Publica: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
                }
            return resultado;
        }

        private List<detallePublicado> PublicarWebPrivada(int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
                foreach (Archivo archivo in PublicacionesMgr.GetArchivosAreaPrivadaPublicacion(categoria))
                {
                    resultado.Add(UtilPublicar.PublicarBaseDatosWeb(archivo.tablaWebPrivada, archivo.numeroCategoriaWebPri,archivo));
                    PistaMgr.Instance.Info("DifInfo:Pub Web Privada", string.Format("Publicado Web Privada: {0}", UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
                }
            return resultado;
        }

        public List<detallePublicado> GetArchivosPublicadosPorCategoria(DateTime fechaInicio, DateTime fechaFin, int categoria)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFin))
            {
                resultado.AddRange(PublicacionesMgr.GetUltimaPublicacionPorCategoria(categoria, fecha));
            }
            return resultado;
        }

        public List<DateTime> GenerarListaFechas(DateTime ini, DateTime fin)
        {
            List<DateTime> dateList = new List<DateTime>();
            while (ini <= fin)
            {
                dateList.Add(ini);
                ini = ini.AddDays(1);

            }
            return dateList;
        }
        public bool ExisteErrorProceso(List<detallePublicado> publicados)
        {
            bool resultado = false;
            if (publicados.Count > 0)
            {
                foreach (detallePublicado item in publicados)
                {
                    if (!item.Detalle.StartsWith("OK"))
                    {
                        resultado = true;
                    }
                }
            }
            return resultado;

        }
        protected void enviarMail(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            if (Parametros.ExiteParametro("ENVIOCORREO"))
            {
                if (Parametros.ExiteParametro("DESTINATARIO") && Parametros.ExiteParametro("TITULOMAIL"))
                {

                    EnviadorEmail email = new EnviadorEmail();
                    string contenido = string.Empty;
                    bool enviado = false;
                    List<string> destinatarios = new List<string>();

                    List<string> archivosAdjuntos = new List<string>();
                    destinatarios = GetListaDestinatarios(fechaInicio, fechaFinal, categoria);
                    archivosAdjuntos = GetArchivosAdjuntos(fechaInicio,fechaFinal,categoria);
                    try
                    {
                        contenido = "Procesado por : " + Sesion.Instancia.UsuarioActual.Nombre + "<br/>Fecha y Hora : " +Sesion.Instancia.FechaHoraServidor;
                        List<string> destinosNoEnviados = email.Enviar(Parametros.DiccionarioParametros["TITULOMAIL"], contenido, destinatarios, archivosAdjuntos,true);
                        if (destinosNoEnviados.Count == 0)
                        {
                            enviado = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        PistaMgr.Instance.Error("Difusion Información", ex);
                    }
                    if (!enviado)
                    {
                        MessageBox.Show("No se pudo enviar el correo, revisar su configuración ...", "Envío Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PistaMgr.Instance.Info("Difusion Información", "Envio sin exito a destinatario");
                    }
                    else
                    {
                        MessageBox.Show("Se envío el mensaje de Publicación, favor verificar la llegada en el buzón de correo ...", "Envío Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro parametros para proceder con el envio ...", "Envío Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private List<string> GetArchivosAdjuntos(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            List<string> adjuntos = new List<string>();

            foreach (string archivo in GetArchivosAdjuntosPorCategoria(fechaInicio, fechaFinal, categoria))
            {
                if (File.Exists(Path.Combine(ConfigPublicacion.rutaLocal, archivo)))
                {
                    File.Copy(Path.Combine(ConfigPublicacion.rutaLocal, archivo),Path.Combine(Path.GetTempPath(),archivo),true);
                    if (File.Exists(Path.Combine(Path.GetTempPath(), archivo)))
                    {
                        if (!adjuntos.Exists(x => { return x == Path.Combine(Path.GetTempPath(), archivo); }))
                        {

                            adjuntos.Add(Path.Combine(Path.GetTempPath(), archivo));
                        }
                    }
                }
            }
            return adjuntos;
        }

        public virtual List<string> GetArchivosAdjuntosPorCategoria(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            List<string> resultado = new List<string>();
            foreach (DateTime fecha in GenerarListaFechas(fechaInicio, fechaFinal))
            {
                UtilesExtraFecha.SetFechas(fecha, fechaFinal, fecha);
                resultado.Add(UtilesExtraFecha.FormatearRutaArchivo(ConfigPublicacion.formatoNombreArchivo));
            }
            return resultado;
        }

        private List<string> GetParamDestinatario(string p)
        {
            char[] delimitador = { ';' };
            List<string> resultado = new List<string>();
            string[] dest = p.Split(delimitador);
            foreach (string item in dest)
            {
                resultado.Add(item);
            }
            return resultado;
        }
        private List<string> QuitarDestinatariosListaNegra(List<string> destinos, List<string> listaNegra)
        {
            foreach (string valor in listaNegra)
            {
                destinos.RemoveAll(x => { return x == valor; });
            }
            return destinos;
        }
        private List<string> GetListaDestinatarios(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {

            List<string> resultado = new List<string>();
            if (Parametros.ExiteParametro("DESTINATARIO"))
            {
                resultado = GetParamDestinatario(Parametros.DiccionarioParametros["DESTINATARIO"]);

                if (VerificarPublicacionCategoria(fechaInicio, fechaFinal, categoria))
                {
                    if (Parametros.ExiteParametro("LISTANEGRA"))
                    {
                        List<string> listaNegra = new List<string>();
                        listaNegra = GetParamDestinatario(Parametros.DiccionarioParametros["LISTANEGRA"]);
                        resultado = QuitarDestinatariosListaNegra(resultado, listaNegra);
                    }
                }
            }
            return resultado;
        }
        public bool VerificarPublicacionCategoria(DateTime fechaInicio, DateTime fechaFinal, int categoria)
        {
            bool respuesta = false;
            List<detallePublicado> resultado = new List<detallePublicado>();
            resultado = GetArchivosPublicadosPorCategoria(fechaInicio, fechaFinal, categoria);
            if (resultado.Count > 0)
            {
                respuesta = true;
            }
            return respuesta;
        }

        internal void SetConfiguracion(int categoria)
        {
            ConfigPublicacion.Leer(PublicacionesMgr.GetConfiguracionCategoria(categoria));
        }
    }

    public class InvocadorEnvioArchivos
    {
        public int Categoria { get; set; }
        internal List<detallePublicado> Detalle { get; private set; }
        internal Generador Generador { get; set; }

        public void Enviar()
        {
            Detalle = Generador.EnviarArchivos(Categoria);
        }
        public void Preparar()
        {
            Detalle = Generador.GenerarArchivosLocalmente(Categoria);
        }
        public void Publicar()
        {
            Detalle= Generador.PublicarArchivos(Categoria);
        }
    }
}
