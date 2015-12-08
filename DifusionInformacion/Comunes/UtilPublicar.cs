using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using CNDC.UtilesComunes;
using CNDC.Pistas;


namespace DifusionInformacion
{
    class UtilPublicar
    {
        public UtilPublicar()
        {

        }
        public static string[] GetArchivosMultiplesExtensiones(string path, string extensionList, string delimeter)
        {
            List<string> strFiles = new List<string>();

            foreach (string strExt in extensionList.Split(delimeter.ToCharArray()))
            {
                strFiles.AddRange(Directory.GetFiles(path, strExt));
            }
            return strFiles.ToArray();
        }


        public static List<detallePublicado> EnviarArchivosHaciaWeb(string rutaAreaCategoria, Archivo archivo)
        {
            string[] files;
            List<detallePublicado> listaPublicados = new List<detallePublicado>();
            try
            {
                string nombredestino = UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado);
                if (archivo.generarZIP)
                {
                    files = GetArchivosMultiplesExtensiones(ConfigPublicacion.rutaLocal, Path.GetFileName(nombredestino) + ";" + Path.GetFileNameWithoutExtension(nombredestino) + ".zip", ";");
                }
                else
                {
                    files = GetArchivosMultiplesExtensiones(ConfigPublicacion.rutaLocal, Path.GetFileName(nombredestino), ";");
                }
                
                //    Directory.GetFiles(ConfigPublicacion.rutaLocal, Path.GetFileNameWithoutExtension(nombredestino) + ".zip");
                
                for (int i = 0; i < files.Length; i++)
                {
                    listaPublicados.Add(new detallePublicado(Path.GetFileName(files[i]), "Remoto Web", SubirArchivoAFTP(ConfigPublicacion.nombreServidorWeb, ConfigPublicacion.cuentaWeb, CNDC.UtilesComunes.Codifica.DecodeFrom64(ConfigPublicacion.claveWeb), ConfigPublicacion.rutaServidorWeb, rutaAreaCategoria, files[i])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Envio destino Web : " + ex.Message);
            }
            return listaPublicados;
        }

        public static string SubirArchivoAFTP(string server, string user, string pass, string rutadestino, string rutacategoria, string nombredestino)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + server + "/" + rutadestino + rutacategoria + Path.GetFileName(nombredestino));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = false;
                request.UseBinary = true;
                request.KeepAlive = false;
                FileStream stream = File.OpenRead(nombredestino);
                Stream reqStream = request.GetRequestStream();

                int halfAMeg = (int)(1024 * 1024 * 0.5);//(int)(1024 * 1024 * 0.5);
                byte[] buf = new byte[halfAMeg];
                    while (stream.Position < stream.Length)
                    {
                        int len = stream.Read(buf, 0, buf.Length);
                        reqStream.Write(buf, 0, len);
                    }
                    long up = stream.Position;
                    
                stream.Flush();
                stream.Close();
                reqStream.Flush();
                reqStream.Close();

                return "OK Peso : " + up.ToString() + " B.";
            }
            catch (Exception ex)
            {
                return "Error FTP, " + ex.Message;
            }
        }

        public static long SubirArchivoSoloAFTP(string server, string user, string pass, string rutadestino, string rutacategoria, string nombredestino)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + server + "/" + rutadestino + rutacategoria + Path.GetFileName(nombredestino));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = false;
                request.UseBinary = true;
                request.KeepAlive = false;

                FileStream stream = File.OpenRead(nombredestino);
                Stream reqStream = request.GetRequestStream();

                int halfAMeg = 512;//(int)(1024 * 1024 * 0.5);
                byte[] buf = new byte[halfAMeg];
                while (stream.Position < stream.Length)
                {
                    int len = stream.Read(buf, 0, buf.Length);
                    reqStream.Write(buf, 0, len);
                }
                long up = stream.Position;
                stream.Flush();
                stream.Close();
                reqStream.Flush();
                reqStream.Close();

                return up;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private long BajarArchivoDeFTP(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {

                FtpWebRequest request1 = (FtpWebRequest)FtpWebRequest.Create("ftp://" + server + "/" + rutadestino + "/" + nombredestino);

                request1.Method = WebRequestMethods.Ftp.DownloadFile;
                request1.Credentials = new NetworkCredential(user, pass);
                request1.UsePassive = false;
                request1.UseBinary = true;
                request1.KeepAlive = false;
                //FileStream stream = File.OpenWrite(origen);

                FtpWebResponse responseFileDownload = (FtpWebResponse)request1.GetResponse();
                Stream reqStream = responseFileDownload.GetResponseStream();

                int Length = 512;//(int)stream.Length/20;
                Byte[] buffer = new Byte[Length];
                int bytesRead = reqStream.Read(buffer, 0, Length);
                long down = bytesRead;
                while (bytesRead > 0)
                {
                    //stream.Write(buffer, 0, Length);
                    bytesRead = reqStream.Read(buffer, 0, Length);
                    down += bytesRead;

                }
                responseFileDownload.Close();
                reqStream.Close();
                //stream.Flush();
                //stream.Close();
                return down;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<detallePublicado> PublicarServidorLocal(string carpeta, Archivo archivo, bool infocndc)
        {
            List<detallePublicado> listaPublicados = new List<detallePublicado>();
            string[] files;
            string nombredestino = UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado);
            if (archivo.generarZIP)
            {
                files = GetArchivosMultiplesExtensiones(ConfigPublicacion.rutaLocal, Path.GetFileName(nombredestino) + ";" + Path.GetFileNameWithoutExtension(nombredestino) + ".zip", ";");
            }
            else
            {
                files = GetArchivosMultiplesExtensiones(ConfigPublicacion.rutaLocal, Path.GetFileName(nombredestino), ";");
            }            
  
             for (int i = 0; i < files.Length; i++)
            {
                if (!infocndc)
                {
                    listaPublicados.Add(EnviarServidorLocal(ConfigPublicacion.rutaServidorIntranet, UtilesExtraFecha.FormatearRutaArchivo(carpeta), files[i], infocndc));     
                }
                else
                {
                    listaPublicados.Add(EnviarServidorLocal(ConfigPublicacion.rutaServidorInfocndc, UtilesExtraFecha.FormatearRutaArchivo(carpeta), files[i], infocndc));
                }
               
            }
             return listaPublicados;

        }
        public static detallePublicado EnviarServidorLocal(string rutaServidor, string carpeta, string archivo, bool infocndc)
        {
            try
            {
                System.Net.WebClient Client = new System.Net.WebClient();
                Client.Headers.Add("Content-Type", "binary/octet-stream");
                byte[] result = Client.UploadFile(rutaServidor + carpeta, "POST", archivo);
                String s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                //MessageBox.Show(s);
                if (!infocndc)
                {
                    return new detallePublicado(Path.GetFileName(archivo), "Servidor Intranet", s);    
                }
                else
                {
                    return new detallePublicado(Path.GetFileName(archivo), "Servidor Infocndc", s);
                }
                
            }
            catch (Exception ex)
            {
                if (!infocndc)
                {
                    return new detallePublicado(Path.GetFileName(archivo), "Servidor Intranet", "Error : " + ex.Message);    
                }
                else
                {
                    return new detallePublicado(Path.GetFileName(archivo), "Servidor Infocndc", "Error : " + ex.Message);
                }
                
            }
        }
        public static bool EsVerdadero(long esValor)
        {
                return (esValor == 1)?true:false;
        }
        
        public static List<detallePublicado> CopiarArchivoDestinoCurvas(string origen, bool generarZip)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            string archivoLocal = UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ConfigPublicacion.rutaLocal, origen));
            try
            {
                Thread.Sleep(2000);
                if (File.Exists(archivoLocal))
                {
                    File.Copy(archivoLocal, Path.Combine(ConfigPublicacion.rutaServidorDestino, Path.GetFileName(archivoLocal)), true);
                    resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal), "Copia Destino", "OK, enviado satisfactoriamente"));
                }
                Thread.Sleep(10000);
                if (File.Exists(Path.Combine(ConfigPublicacion.rutaServidorDestino, Path.GetFileName(archivoLocal))))
                {
                    resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal), "Verificacion Destino", "Error, no se proceso satisfactoriamente"));
                }
            }
            catch (Exception ex)
            {
                resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal), "Copia Destino", "Error al copiar : " + ex.Message));
            }
            return resultado;
        }

        public static void LimpiarArchivoOrigen(string nombreOrigen)
        {
            try
            {
                if (File.Exists(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen)))
                {
                    File.Delete(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen));
                    PistaMgr.Instance.Info("DifInfo: Limpiar Origen", string.Format("Archivo {0} eliminado remoto: OK", Path.GetFileName(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen))));
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Info("DifInfo: Limpiar Origen", string.Format("Archivo {0} error: No se pudo eliminar: {1} ", Path.GetFileName(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen)),ex.Message));
            }
        }

        public static List<detallePublicado> CopiarArchivoLocalmente(string nombreOrigen,string archivo, bool generarZip, bool borrarOrigen)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            string archivoLocal = UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ConfigPublicacion.rutaLocal, archivo));
            try
            {
                if (borrarOrigen)
                {
                    //File.Move(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen), archivoLocal);
                    File.Copy(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen), archivoLocal, true);
                    //File.Delete(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen));
                }
                else
                {
                    File.Copy(UtilesExtraFecha.FormatearRutaArchivo(nombreOrigen), archivoLocal, true);
                }
                if (File.Exists(archivoLocal))
                {
                    resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal),"Local", "OK"));
                    PistaMgr.Instance.Info("DifInfo: Recuperar Origen", string.Format("Archivo {0} copiado localmente: OK", Path.GetFileName(archivoLocal)));
                }
                else
                {
                    resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal), "Local", "Error : al copiar localmente"));
                    PistaMgr.Instance.Info("DifInfo: Recuperar Origen", string.Format("Archivo {0} Error : al copiar localmente", Path.GetFileName(archivoLocal)));
                }
                if (generarZip)
                {
                    CNDC.UtilesComunes.UtilZip.ComprimirArchivoFuente(archivoLocal);
                    if (File.Exists(Path.Combine(ConfigPublicacion.rutaLocal, Path.GetFileNameWithoutExtension(archivoLocal) + ".zip")))
                    {
                        resultado.Add(new detallePublicado(Path.GetFileNameWithoutExtension(archivoLocal) + ".zip", "Local", "OK"));
                    }
                    else
                    {
                        resultado.Add(new detallePublicado(Path.GetFileNameWithoutExtension(archivoLocal) + ".zip", "Local", "Error : al copiar localmente"));
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Add(new detallePublicado(Path.GetFileName(archivoLocal), "Local", string.Format("Archivo origen no encontrado en ruta: {0}: {1}", ConfigPublicacion.rutaServidorOrigen, ex.Message)));
                PistaMgr.Instance.Info("DifInfo: Recuperar Origen", string.Format("Preparando Archivo {0} Error : Archivo origen no encontrado en ruta: {1}: {2}", Path.GetFileName(archivoLocal), ConfigPublicacion.rutaServidorOrigen, ex.Message));
            }
            return resultado;
        }
        public static detallePublicado PublicarBaseDatosWeb(string tablaDestino, long numeroCategoria, Archivo archivo)
        {
            RegistroPublica pubWeb = GenerarRegistroPublicar(tablaDestino, numeroCategoria, archivo);
            WebDBManager web = new WebDBManager(ConfigPublicacion.conexionWeb);
            return web.Guardar(pubWeb);
        }       
        public static detallePublicado PublicarBaseDatosIntranet(string tablaDestino, long numeroCategoria, Archivo archivo)
        {
            RegistroPublica pubWeb = GenerarRegistroPublicar(tablaDestino, numeroCategoria, archivo);
            IntranetDBManager intra = new IntranetDBManager(ConfigPublicacion.conexionIntranet);
            return intra.Guardar(pubWeb);
        }

        private static RegistroPublica GenerarRegistroPublicar(string tablaDestino, long numeroCategoria, Archivo archivo)
        {
            RegistroPublica pubWeb = new RegistroPublica();
            pubWeb.tabla = tablaDestino;
            pubWeb.idCategoria = numeroCategoria;
            pubWeb.titulo = UtilesExtraFecha.FormatearRutaArchivo(archivo.tituloArchivo);
            pubWeb.archivo = UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + archivo.extensionArchivoGenerado);
            if (archivo.generarZIP && archivo.publicarWebPrivada)
            {
                    pubWeb.archivo_zip = UtilesExtraFecha.FormatearRutaArchivo(archivo.archivoGenerado + ".zip");                    
            }
            else
            {
                pubWeb.archivo_zip = "";
            }
            pubWeb.fechadoc = String.Format("{0:yyyy-MM-dd}", UtilesExtraFecha.GetFechaPublicable());
            pubWeb.esPublico = archivo.publicarWebPublica;
            return pubWeb;
        }
        public static void VerificarEnlace(string URI)
        {
            try
            {
                //System.Diagnostics.Process.Start(ruta);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = URI;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abrir Enlace : " + ex.Message);
            }
        }
        public static string GetCadConexSpectrum()
        {
            return OraDalSpectrumMgr.GetCadConexionSpectrum();
        }
    }
    public class detallePublicado
    {
        string _archivo;
        string _destino;
        string _detalle;
        public detallePublicado(string arch, string destino, string det)
        {
            _archivo = arch;
            _destino = destino;
            _detalle = det;
        }
        public string Archivo
        {
            get { return _archivo; }
            set { _archivo = value; }
        }
        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }
        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }


    }

}
