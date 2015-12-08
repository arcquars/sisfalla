using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;
using Ionic.Zlib;
using Ionic.Zip ;


namespace DescargaBaseDatos
{
  


    public partial class dialogoDescarga : Form
    {
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed

        string destino=string.Empty ;
        public dialogoDescarga()
        {
            InitializeComponent();
        }

        public void DownloadFile(string urlAddress, string location)
        {
            destino = location ;
            panel1.Visible = true;
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                { 

                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }
        int numarchvos=0 ;
        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();
            numarchvos++;
            if (numarchvos == 2)
            {
                btnUnzip.Enabled = true;
            }


           
        }

        public static void Decompress(FileInfo fi, ToolStripStatusLabel l)
        {
            l.Text = fi.FullName;
            
            using (ZipFile zip1 = ZipFile.Read(fi.FullName))
            {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.  
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(fi.Directory.FullName, ExtractExistingFileAction.OverwriteSilently);
                }
            }

        }
        public string Ruta { get; set; }
        private void dialogoDescarga_Load(object sender, EventArgs e)
        {
            DownloadFile("http://www.cndc.bo/media/archivos/archivos/qnt_esquema.zip", Path.Combine(Ruta, "qnt_esquema.zip")); 
            DownloadFile ("http://www.cndc.bo/media/archivos/archivos/qnt_bd.zip", Path.Combine (Ruta,"qnt_0512.zip"));

            Decompress(new FileInfo(Path.Combine(Ruta, "qnt_esquema.zip")), toolStripStatusLabel1);
            Decompress(new FileInfo(Path.Combine(Ruta, "qnt_bd.zip")), toolStripStatusLabel1);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {

        }
    }
}
