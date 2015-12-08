using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace DescargaBaseDatos
{
    public partial class Form1 : Form
    {

        string dirFile = string.Empty;

        string dirApp = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }


        private bool  SetFolfer()
        {
            bool rtn = false;
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), "ActBaseDatos");

            DirectoryInfo dr = new DirectoryInfo(dirApp);
            try
            {
                if (dr.Exists)
                {
                    dr.Delete(true);
                }
             
                dr.Create();
             
                rtn = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo eliminar la carpeta :" + dirApp + ".","Error", MessageBoxButtons.OK ,MessageBoxIcon.Error );

            }
            return rtn;
        }
     

   

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _lblEsquema_Click(object sender, EventArgs e)
        {

        }

        private void _btnInstalarEsquema_Click(object sender, EventArgs e)
        {
            dialogoDescarga dialog = new dialogoDescarga();
            dialog.Ruta= dirApp;
              if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dirFile = dirApp;
                label1.Text = dirFile;
                

                _btnInstalarEsquema.Enabled = false;
                button1.Enabled = false;
            }
        }
        private bool generarArchivos()
        {
            bool rtn = true;
          //  dirApp = Path.Combine(dirApp, "Esquema");
            CambiarRuta(Path.Combine(dirFile, "import.bas"), Path.Combine(dirFile, "import.bat"));
            CambiarRuta(Path.Combine(dirFile, "import.txs"), Path.Combine(dirFile, "import.txt"));
            return rtn;
        }
        private bool CambiarRuta(string archivo , string destino)
        {
            bool rtn = true;
            string str = File.ReadAllText(archivo);
            str = str.Replace("{PATH_INSTALACION}", dirApp);
            File.WriteAllText(destino, str);

            return rtn;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // _lblMensaje.Text = "Preparando archivos para la instalación...";
            Application.DoEvents();

            string tmpPath = Path.GetTempPath();
            DirectoryInfo origen = new DirectoryInfo(dirFile);
            DirectoryInfo destino = new DirectoryInfo(dirApp);
         //   CopyAll(origen, destino);

            generarArchivos();
            Process proceso = new Process();
            proceso.StartInfo.FileName = Path.Combine(dirFile, "Import.bat");
            proceso.EnableRaisingEvents = true;
            proceso.Start();
            proceso.WaitForExit();
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            string archivoDestino = string.Empty;
            foreach (FileInfo fi in source.GetFiles())
            {
                archivoDestino = Path.Combine(target.ToString(), fi.Name);
                fi.CopyTo(archivoDestino, true);
                FileInfo f = new FileInfo(archivoDestino);
                f.IsReadOnly = false;
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!SetFolfer())
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files (.zip)|*.zip|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo finfo = new FileInfo (openFileDialog1.FileName);
                label1.Text = finfo.DirectoryName ;
               
                dialogoDescarga.Decompress( new FileInfo(Path.Combine(finfo.DirectoryName, "qnt_esquema.zip")), toolStripStatusLabel1);
                dialogoDescarga.Decompress(new FileInfo(Path.Combine(finfo.DirectoryName, "qnt_bd.zip")), toolStripStatusLabel1);
                dirFile = Path.Combine(finfo.DirectoryName, "Esquema");
                _btnInstalarEsquema.Enabled = false;
                button1.Enabled = false;
            }

         
        }
    }
}
