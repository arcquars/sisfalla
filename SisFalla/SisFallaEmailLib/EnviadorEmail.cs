using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data;
using CNDC.BLL;
using CNDC.Pistas;
using CNDC.UtilesComunes;
using System.IO;
using System.Windows.Forms;

namespace SisFallaEmailLib
{
    public class EnviadorEmail
    {
        //Este método usara los datos del usuario actual para obtener informacion del remitente
        //retorma como resultado una lista de los destinatarios a los que no se pudo enviar el email
        public ResultadoEnvio Enviar(string asunto, string cuerpo, List<string> destinatarios, List<string> archivosAdjuntos)
        {
            DataRow ConfiguracionCliente;
            List<string> destinatariosNoEnviados = new List<string>();
            PistaMgr.Instance.Info("SisFallaEmailLib.Enviar", string.Format("Asunto: {0} | Cuerpo:{1}", asunto, cuerpo));

            if (Sesion.Instancia.ConfiguracionCorreo == null)
            {
                return null;
            }
            else
            {
                ConfiguracionCliente = Sesion.Instancia.ConfiguracionCorreo;
            }
            return EnviarCorreo(asunto, cuerpo, destinatarios, archivosAdjuntos, "_SisFalla", ConfiguracionCliente);
        }

        public List<string> Enviar(string asunto, string cuerpo, List<string> destinatarios, List<string> archivosAdjuntos, bool esQuantum)
        {
            DataRow ConfiguracionCliente;
            List<string> destinatariosNoEnviados = new List<string>();
            if (esQuantum)
            {
                PistaMgr.Instance.Info("SisFallaEmailLib.Enviar", string.Format("Asunto: {0} | Cuerpo:{1}", asunto, cuerpo));

                if (Sesion.Instancia.ConfigEnvioQuantum == null)
                {
                    return null;
                }
                else
                {
                    ConfiguracionCliente = Sesion.Instancia.ConfigEnvioQuantum;
                }
                destinatariosNoEnviados = EnviarCorreo(asunto, cuerpo, destinatarios, archivosAdjuntos, "", ConfiguracionCliente).NoEnviados;
            }
            return destinatariosNoEnviados;
        }

        private ResultadoEnvio EnviarCorreo(string asunto, string cuerpo, List<string> destinatarios, List<string> archivosAdjuntos, string sufijo, DataRow ConfiguracionCliente)
        {
            List<string> destinatariosNoEnviados = new List<string>();
            string mensaje = string.Empty;
            
            var fromAddress = new MailAddress(ConfiguracionCliente["NOM_CUENTA"].ToString(), ConfiguracionCliente["ETIQUETA_ENVIO"].ToString() + sufijo);
            string fromPassword = Codifica.DecodeFrom64(ConfiguracionCliente["CUENTA_PASSWD"].ToString());
            destinatarios = AsegurarSinRepetidos(destinatarios);

     
            if (ConfiguracionCliente["ETIQUETA_ENVIO"].ToString() == "CNDC" && sufijo == "_SisFalla")
            {

                    if (MessageBox.Show("Por favor verificar que el Outlook, se esta habilitado.", "Alerta", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        int i = 0;
                    }


                string destinos = UtilesString.ToString(destinatarios, ";");
                PistaMgr.Instance.Info("SisFallaEmailLib.Enviar ", string.Format("Destino: {0}; {1}; {2} ", destinos, ConfiguracionCliente["NOM_CUENTA"].ToString(), fromPassword));
                 OutlookMail outlook = new OutlookMail();
                if (outlook.IniciarSesion(ConfiguracionCliente["NOM_CUENTA"].ToString(), fromPassword))
                //if (outlook.IniciarSesion("arc.quars@hotmail.com", "654321pedro"))
                {
                    outlook.addToOutBox(destinos, asunto, cuerpo, archivosAdjuntos);
                }
                else
                {
                    destinatariosNoEnviados = destinatarios;
                    mensaje = "Al parecer Outlook no ha sido iniciado...";
                }
            }
            else
            {
                foreach (var d in destinatarios)
                {
                    PistaMgr.Instance.Info("SisFallaEmailLib.Enviar ", string.Format("Destino: {0} ", d));

                    var smtp = GetSMTP_CNDC(fromAddress, fromPassword, ConfiguracionCliente);
                    var message = new MailMessage();
                    message.From = fromAddress;
                    List<Stream> streams = new List<Stream>();
                    foreach (var adjunto in archivosAdjuntos)
                    {
                        Stream stream = File.OpenRead(adjunto);
                        message.Attachments.Add(new Attachment(stream, Path.GetFileName(adjunto)));
                        streams.Add(stream);
                        PistaMgr.Instance.Info("SisFallaEmailLib.Enviar ", string.Format("Adjunto: {0} ", adjunto));
                    }
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    message.Subject = asunto;
                    message.Body = cuerpo;
                    message.IsBodyHtml = true;
                    message.To.Clear();
                    message.To.Add(d);
                    message.Priority = MailPriority.High;
                    try
                    {
                        smtp.ServicePoint.MaxIdleTime = 10000;
                        
                        smtp.Send(message);
                    }
                    catch (Exception e)
                    {
                        destinatariosNoEnviados.Add(d);
                        PistaMgr.Instance.Error("SisFallaEmailLib.Enviar-NO ENVIADO", string.Format("D: {0} Exp :{1}", d, e.ToString()));
                    }
                    finally
                    {
                        foreach (var s in streams)
                        {
                            s.Close();
                        }
                    }
                }
            }

            return new ResultadoEnvio() { Msg=mensaje, NoEnviados = destinatariosNoEnviados };
        }

        private List<string> AsegurarSinRepetidos(List<string> destinatarios)
        {
            List<string> resultado = new List<string>();
            foreach (string item in destinatarios)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string tmp = item.Replace(',', ';');
                    string[] destSeparados = tmp.Split(';');
                    foreach (var d in destSeparados)
                    {
                        if (!resultado.Contains(d))
                        {
                            resultado.Add(d);
                        }
                    }
                }
            }
            return resultado;
        }

        private SmtpClient GetSMTP_CNDC(MailAddress fromAddress, string fromPassword, DataRow ConfiguracionCliente)
        {
            bool ssl_servicio = false;
            string servidor = ConfiguracionCliente["NOMBRE_URI"].ToString();
            if (servidor.ToUpper() == "NO")
            {
                servidor = ConfiguracionCliente["DIRECCION_IP"].ToString();
            }
            if (Int32.Parse(ConfiguracionCliente["SSL_ACTIVO"].ToString()) == 1)
            {
                ssl_servicio = true;
            }

            SmtpClient client = new SmtpClient(servidor);
            client.Port = Convert.ToInt32(ConfiguracionCliente["NUM_PUERTO"].ToString());
            client.EnableSsl = ssl_servicio;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            return client;
        }
    }

    public class ResultadoEnvio
    {
        public string Msg { get; set; }
        public List<string> NoEnviados { get; set; }
    }
}
