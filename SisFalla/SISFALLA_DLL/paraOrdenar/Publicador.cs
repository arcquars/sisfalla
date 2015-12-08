using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace SISFALLA
{
    class Publicador:MostrarPublicacion
    {
        public Publicador() { }
        public Publicador(int a)
        {
            string archivo = seleccionarArchivo();
            if (archivo!=string.Empty)
            {
                //Upload("ftp://www.cndc.bo", "cndc", "b0l1v14", archivo);
                //SubirArchivoAFTP("ftp://www.cndc.bo", "cndc", "b0l1v14",archivo, "/nuevo",new FileInfo(archivo).Name);
                BajarArchivoDeFTP("ftp://www.cndc.bo", "cndc", "b0l1v14", archivo, "/nuevo", new FileInfo(archivo).Name);     
            }
           
        }
        public string seleccionarArchivo()
        {
            try
            {
                OpenFileDialog abrir = new OpenFileDialog();
                
                
                abrir.InitialDirectory = Application.StartupPath;
                abrir.Title = "Importar Registro desde archivo Comprimido";
                abrir.Filter = "Archivos GZ|*.gz|Todos Archivos|*.*";
                abrir.FileName = string.Empty;
                if (abrir.ShowDialog() != DialogResult.Cancel)
                {
                    return abrir.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void Upload(string ftpServer, string userName, string password, string filename)
        {
            try
            {


                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.Credentials = new System.Net.NetworkCredential(userName, password);
                    client.BaseAddress = ftpServer;
                    client.UploadFile("../../../nuevo/" + new FileInfo(filename).Name, "STOR", filename);
                    client.Dispose();

                }


            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public bool SubirArchivoAFTP( string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {
                MostrarPublicacion formPub = new MostrarPublicacion();

                //barra.Show();
                //barra.MarqueeAnimationSpeed = 30;

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(origen);
                //byte[] buffer = new byte[stream.Length];
                //stream.Read(buffer, 0, buffer.Length);
                //stream.Close();
                Stream reqStream = request.GetRequestStream();

                

                int Length = 200;
                Byte[] buffer = new Byte[Length];
                int bytesRead = stream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    reqStream.Write(buffer, 0, bytesRead);
                    bytesRead = stream.Read(buffer, 0, Length);

                    base.incrementar();
                    //barra.PerformStep();
                    //barra.Show();
                    
                }
                stream.Close();
                //reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

            public bool BajarArchivoDeFTP(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenWrite(origen);
                
                FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse();
                Stream reqStream = responseFileDownload.GetResponseStream();

                int Length = 20;//(int)stream.Length/20;
                Byte[] buffer = new Byte[Length];
                int bytesRead = reqStream.Read(buffer, 0, Length);
                
                while (bytesRead > 0)
                {
                    stream.Write(buffer, 0, Length);
                    reqStream.Read(buffer, 0, bytesRead);
                    
                }
                stream.Close();
                
                reqStream.Flush();
                reqStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        } 


    }
}
