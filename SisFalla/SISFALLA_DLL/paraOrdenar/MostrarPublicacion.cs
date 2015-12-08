using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using CNDC.UtilesComunes;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Dominios;
using CNDC.BaseForms;

namespace SISFALLA
{
    public partial class MostrarPublicacion : BaseForm
    {
        string _idCategoria = string.Empty;
        ProgressBar barra = new ProgressBar();
        ProgressBar barraDown = new ProgressBar();
        Label a = new Label();
        Label b = new Label();
        Label c = new Label();
        Label d = new Label();
        RegFalla _regFalla = null;
        RegistroServidor _regServidor = null;
        RegistroPublica pub = null;
        RegistroPublica pubIntra = null;
        public MostrarPublicacion()
        {
            InitializeComponent();
        }
        public void publicarCategoria(string cat)
        {
            _idCategoria = cat;
        }
        private bool PrepararCategoria(string num)
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
            cmd.Parameters.Add("COD_CATEGORIA", num.ToUpper());
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                _regServidor = new RegistroServidor();
                _regServidor.llenaRegistro(tabla.Rows[0]);
                val = true;
            }
            else
            {
                MessageBox.Show("No se encontro Registro de la categoria a publicar...");
                
            }
            return val;
        }
        private void preparaArchivo() 
        { 
        if (PrepararCategoria(_idCategoria))
                {
                    string nFalla = string.Empty;
                    _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
                    nFalla = _regFalla.CodFalla.ToString();
                    pub = new RegistroPublica();
                    pubIntra = new RegistroPublica();
                    string archivo = _regServidor.formato_nombre;
                    archivo = Path.Combine(Application.StartupPath,archivo.Replace("#NUMFALLA#", RegFalla.FormatearCodFalla(nFalla)));
                    pub.idCategoria = _regServidor.idCategoria;
                    pub.titulo = _regServidor.descripcion_categoria.Replace("#NUMFALLA#", RegFalla.FormatearCodFalla(nFalla));
                    pub.archivo_zip = new FileInfo(archivo).Name;
                    pub.fecha = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    pub.fechadoc = String.Format("{0:yyyy-MM-dd}", _regFalla.FecInicio);
                    pub.num = int.Parse(nFalla.Substring(2,4));

                    pubIntra.idCategoria = _regServidor.codIntranet;
                    pubIntra.tabla = _regServidor.tablaIntranet;
                    InformeFalla informe = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, 7, (long)PK_D_COD_TIPOINFORME.FINAL);
                    if (informe.CodComponenteFallado != 0)
                    {
                        Componente compo = ModeloMgr.Instancia.ComponenteMgr.GetComponente(informe.CodComponenteFallado);
                        pubIntra.titulo = _regServidor.descripcion_categoria.Replace("#NUMFALLA#", RegFalla.FormatearCodFalla(nFalla))
                        + " Componente: " + compo.Descripcion;
                    }
                    else
                    {
                        pubIntra.titulo = _regServidor.descripcion_categoria.Replace("#NUMFALLA#", RegFalla.FormatearCodFalla(nFalla));//+ " Fecha Apertura : " + _regFalla.FecInicio.ToString("dd/MMM/yyyy HH:mm");
                    }
                    pubIntra.archivo = new FileInfo(archivo).Name;
                    pubIntra.fecha = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    pubIntra.fechadoc = String.Format("{0:yyyy-MM-dd}", _regFalla.FecInicio);

                    a.Text = "SUBIR - " + pubIntra.archivo;
                    c.Text = "BAJAR - " + pubIntra.archivo;

                    repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
                    p.informeDesplegado("", "", 29, "", nFalla, ((int)PK_D_COD_TIPOINFORME.FINAL).ToString(), "7");
                    p.Refresh();
                    p.exportarpdf(pubIntra.archivo);
        }
        }
        private void subirArchivo()
        {
            try
            {
                    string archivo = pubIntra.archivo;
                    if (archivo != string.Empty)
                    {
                        long up = SubirArchivoAFTP(_regServidor.nombre_servidor, _regServidor.usuario, Codifica.DecodeFrom64(_regServidor.password), archivo, _regServidor.carpetaDestino, new FileInfo(archivo).Name);
                        if (up == BajarArchivoDeFTP(_regServidor.nombre_servidor, _regServidor.usuario, Codifica.DecodeFrom64(_regServidor.password), archivo, _regServidor.carpetaDestino, new FileInfo(archivo).Name))
                        {
                            if (copiarIntranet(_regServidor.dirIntranet, new FileInfo(archivo).Name))
                            {


                                _btnEnviarWeb.Enabled = false;
                                _btnPublicarWeb.Enabled = true;
                                _btnPublicarWeb.Tag = "publicar";
                                _btnPublicarWeb.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El archivo no se envio correctamente a la Intranet, volver a intentar...");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("El archivo no se envio correctamente al sitio web, volver a intentar...");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
        private bool copiarIntranet(string rutadestino,string nombredestino)
        {
            bool copiado = false;
            string serverDestino = _regServidor.nombreIntranet + @"www\media\archivos\20" +  _regFalla.CodFalla.ToString().Substring(0,2)+ rutadestino + nombredestino;
            File.Copy(pubIntra.archivo,serverDestino,true);
            if (File.Exists(serverDestino))
            {
                copiado = true;
            }
            return copiado;
        
        }
        public void generaBarra() 
        {
            a.AutoSize = true;
            a.Location = new System.Drawing.Point(20, 10);
            a.Width = 250;
            a.Height = 10;
            a.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            a.Text = "";

            barra.Location = new System.Drawing.Point(20, 30);
            barra.Width = 250;
            barra.Height = 30;
            barra.Minimum = 0;
            barra.Value = 0;


            b.AutoSize = true;
            b.Location = new System.Drawing.Point(20, 62);
            b.Width = 250;
            b.Height = 10;
            b.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.Text = "";

            c.AutoSize = true;
            c.Location = new System.Drawing.Point(290, 10);
            c.Width = 250;
            c.Height = 10;
            c.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            c.Text = "";

            barraDown.Location = new System.Drawing.Point(290, 30);
            barraDown.Width = 250;
            barraDown.Height = 30;
            barraDown.Minimum = 0;
            barraDown.Value = 0;


            d.AutoSize = true;
            d.Location = new System.Drawing.Point(290, 62);
            d.Width = 250;
            d.Height = 10;
            d.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            d.Text = "";

            _btnPublicarWeb.Enabled = false;
            

            this.Controls.Add(a);
            this.Controls.Add(b);
            this.Controls.Add(c);
            this.Controls.Add(d);
            this.Controls.Add(barra);
            this.Controls.Add(barraDown);
            _btnEnviarWeb.Focus();
        }
        
        private void MostrarPublicacion_Load(object sender, EventArgs e)
        {
            generaBarra();
            preparaArchivo();
        }
        



        private long SubirArchivoAFTP(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + server + "/" + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = false;
                request.UseBinary = true;
                request.KeepAlive = false;
                FileStream stream = File.OpenRead(origen);
                Stream reqStream = request.GetRequestStream();

                barra.Value = 0;
                barra.MarqueeAnimationSpeed = 30;
                b.Text = "CONEXION - OK ";

                int halfAMeg = 512;//(int)(1024 * 1024 * 0.5);
                byte[] buf = new byte[halfAMeg];
                while (stream.Position < stream.Length)
                {
                    int len = stream.Read(buf, 0, buf.Length);
                    reqStream.Write(buf, 0, len);
                    Application.DoEvents();
                    
                    SetProBar(stream.Position, stream.Length);
                    Application.DoEvents();

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

                barraDown.Value = 0;
                barraDown.MarqueeAnimationSpeed = 30;
                d.Text = "CONEXION - OK";


                int Length = 512;//(int)stream.Length/20;
                Byte[] buffer = new Byte[Length];
                int bytesRead = reqStream.Read(buffer, 0, Length);
                long down = bytesRead;
                while (bytesRead > 0)
                {
                    //stream.Write(buffer, 0, Length);
                    bytesRead = reqStream.Read(buffer, 0, Length);
                    down += bytesRead;
                    Application.DoEvents();

                    SetProBarDown(down, responseFileDownload.ContentLength);
                    //barra.PerformStep();
                    //barra.Show();
                    Application.DoEvents();


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

        private delegate void SetProBar_CallBack(long val, long max);
        private void SetProBar(long val, long max)

        {
            try
            {
                if (barra.InvokeRequired)
                {
                    SetProBar_CallBack callBack = new SetProBar_CallBack(SetProBar);
                    this.Invoke(callBack, new object[] { val, max });
                }
                else
                {
                    barra.Maximum = 100;
                    barra.Value = (int)(100.0 / (double)((double)max / (double)val));
                    b.Text = "Total Datos : " + val.ToString() + " bytes - Porcentaje : " + barra.Value.ToString() + " %";
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void SetProBarDown(long val, long max)
        {
            try
            {

                barraDown.Maximum = 100;
                barraDown.Value = (int)(100.0 / (double)((double)max / (double)val));
                d.Text = "Total Datos : " + val.ToString() + " bytes - Porcentaje : " + barraDown.Value.ToString() + " %";
            }
            catch (Exception)
            {

                throw;
            }

        }
        private string seleccionarArchivo()
        {
            try
            {
                OpenFileDialog abrir = new OpenFileDialog();


                abrir.InitialDirectory = Application.StartupPath;
                abrir.Title = "Elegir Archivo";
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

        private void _btnPublicarWeb_Click(object sender, EventArgs e)
        {
            switch (_btnPublicarWeb.Tag.ToString())
            {

                case "publicar":
                        DBWeb web = new DBWeb();
                        DBIntranet intranet = new DBIntranet();
                        web.Guardar(pub);
                        intranet.Guardar(pubIntra);
                        _btnEnviarWeb.Enabled = false;
                     _btnPublicarWeb.Tag = "salir";
                    _btnPublicarWeb.Text = "Publicado Satisfactoriamente - Salir";
                    break;
                case "salir":
                    this.Dispose();
                    break;
                default:
                    break;
            }
            
        }

        private void _btnEnviarWeb_Click(object sender, EventArgs e)
        {
            subirArchivo();
        }


        
    }
}
