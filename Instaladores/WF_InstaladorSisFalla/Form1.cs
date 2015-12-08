using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WF_InstaladorSisFalla
{
    public partial class Form1 : Form
    {
        string strDestino = "c:\\InstaladorQ";

        public Form1()
        {
            InitializeComponent();
        }

        private void _btnInstalar_Click(object sender, EventArgs e)
        {
            try
            {
                //_lblMensaje.Text = "Iniciando instalación " + _lblOra.Text;
                //Application.DoEvents();

                //Process proceso = new Process();
                ////proceso.StartInfo.FileName = Path.Combine(strDestino, "silentinstall.bat");
                //proceso.StartInfo.FileName = Path.Combine(Application.StartupPath, "Instalador\\setup.exe");
                //proceso.EnableRaisingEvents = true;
                //proceso.Exited += new EventHandler(p_Exited);
                //proceso.Start();
                //proceso.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
        }

        private void CrearSilentinstall()
        {
            StreamWriter w = new StreamWriter(Path.Combine(strDestino, "silentinstall.bat "));
            string a = string.Format("{0}\\setup.exe /s /f1\"{0}\\response\\OracleXE-Install.iss\" /f2\"{0}\\setup.log\"", strDestino);
            string b = string.Format("{0}\\install_quantum\\import.bat", strDestino);
            //string c = string.Format("{0}\\cr2008sp4_redist\\CRRuntime_12_4_mlb.msi", strDestino);
            w.WriteLine(a);
            //w.WriteLine(b);
            //w.WriteLine(c);
            w.Close();
        }

        private void CrearImportTxt()
        {
            string carpetaImport = Path.Combine(strDestino, "install_quantum");
            StreamWriter w = new StreamWriter(Path.Combine(carpetaImport, "import.txt "));
            string a = @"BUFFER=10000000  FILE=" + strDestino + @"\install_quantum\quantum.exp FULL=n  fromuser=quantum touser=quantum GRANTS=n";

            w.WriteLine(a);
            w.Close();
        }

        private void CrearImportBat()
        {
            string carpetaImport = Path.Combine(strDestino, "install_quantum");
            StreamWriter w = new StreamWriter(Path.Combine(carpetaImport, "import.bat"));


            string a = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\dropcreateUser.sql";
            string b = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\imp quantum/quantum@xe  parfile=" + strDestino + @"\install_quantum\import.txt";
            string c = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe  @" + strDestino + @"\install_quantum\views.sql";
            string d = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\recompileall.sql";
            string e = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe  @" + strDestino + @"\install_quantum\droptriggers.sql";
            string f = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\role.sql";
            string g = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\drop_public_synonym.sql";
            string h = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe  @" + strDestino + @"\install_quantum\grant_role_sisfalla.sql";
            string i = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\create_public_synonym.sql";
      
            string j = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\users.sql";
            string k = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe @" + strDestino + @"\install_quantum\grants.sql";

            //string a = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/oraclexe@xe as sysdba  @" + strDestino + @"\install_quantum\dropcreateUser.sql";
            //string b = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\imp quantum/quantum@xe  parfile=" + strDestino + @"\install_quantum\import.txt";
            //string c = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe  @" + strDestino + @"\install_quantum\views.sql";
            //string d = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus sys/oraclexe@xe as sysdba  @" + strDestino + @"\install_quantum\recompileall.sql";
            //string e = @" C:\oraclexe\app\oracle\product\11.2.0\server\bin\sqlplus quantum/quantum@xe  @" + strDestino + @"\install_quantum\droptriggers.sql";

            w.WriteLine(a);
            w.WriteLine(b);
            w.WriteLine(c);
            w.WriteLine(d);
            w.WriteLine(e);
            w.WriteLine(f);
            w.WriteLine(g);
            w.WriteLine(h);
            w.WriteLine(i);
            w.WriteLine(j);
            w.WriteLine(k);
            w.Close();
        }

        public static int ContarArChivos(DirectoryInfo source)
        {
            int c = source.GetFiles().Length;

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                c += ContarArChivos(diSourceSubDir);
            }
            return c;
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

        private void _btnInstalarEsquema_Click(object sender, EventArgs e)
        {
            _lblMensaje.Text = "Preparando archivos para la instalación...";
            Application.DoEvents();

            string tmpPath = Path.GetTempPath();
            DirectoryInfo origen = new DirectoryInfo(Path.Combine(Application.StartupPath, "Esquema"));
            DirectoryInfo destino = new DirectoryInfo(strDestino);
            WF_InstaladorSisFalla.Form1.CopyAll(origen, destino);

            Process proceso = new Process();
            proceso.StartInfo.FileName = Path.Combine(strDestino, "Import.bat");
            proceso.EnableRaisingEvents = true;
            proceso.Start();
            proceso.WaitForExit();
        }

        private void InstalarEsquemaBeta()
        {
            _lblMensaje.Text = "Preparando archivos para la instalación...";
            Application.DoEvents();

            string tmpPath = Path.GetTempPath();
            DirectoryInfo origen = new DirectoryInfo(Path.Combine(Application.StartupPath, "Esquema"));
            DirectoryInfo destino = new DirectoryInfo(strDestino);
            CopyAll(origen, destino);
            //CrearSilentinstall();
            CrearImportBat();
            CrearImportTxt();

            _lblMensaje.Text = "Iniciando instalación " + _lblEsquema.Text;
            Application.DoEvents();
            FormInstaldorBD f = new FormInstaldorBD();
            f.ShowDialog();
        }

        private void _btnInstalarCR_Click(object sender, EventArgs e)
        {
            //_lblMensaje.Text = "Iniciando instalación " + _lblCR.Text;
            //Application.DoEvents();

            //Process proceso = new Process();
            ////proceso.StartInfo.FileName = Path.Combine(strDestino, "silentinstall.bat");
            //proceso.StartInfo.FileName = Path.Combine(Application.StartupPath, "Instalador\\cr2008sp4_redist\\CRRuntime_12_4_mlb.msi");
            //proceso.EnableRaisingEvents = true;
            //proceso.Exited += new EventHandler(p_Exited);
            //proceso.Start();
            //proceso.WaitForExit();
        }

        private void _btnInstalarSisFalla_Click(object sender, EventArgs e)
        {
            _lblMensaje.Text = "Iniciando instalación " + _lblSisFalla.Text;
            Application.DoEvents();
            Process proceso = new Process();
            //proceso.StartInfo.FileName = Path.Combine(strDestino, "silentinstall.bat");
            string PathInstalador = Path.Combine(Application.StartupPath, "Instalador\\SisFalla\\SetupSisFalla.msi");
            proceso.StartInfo.FileName = PathInstalador ;
            proceso.EnableRaisingEvents = true;
            proceso.Exited += new EventHandler(p_Exited);
            proceso.Start();
            proceso.WaitForExit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = "GUIA INSTALACION - SISFALLA V2 0.pdf";
                proceso.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la Guía de Instalación. Es posible que no tenga instalado un lector de archivos en formato PDF.");
            }
        }

        private void _btnLlaveCR_Click(object sender, EventArgs e)
        {
            //_lblMensaje.Text = "Iniciando instalación " + _lblCR.Text;
            //Application.DoEvents();
            //Process proceso = new Process();
            ////proceso.StartInfo.FileName = Path.Combine(strDestino, "silentinstall.bat");
            //proceso.StartInfo.FileName = Path.Combine(Application.StartupPath, "Instalador\\cr2008sp4_redist\\reportes_bug.reg");
            //proceso.EnableRaisingEvents = true;
            //proceso.Exited += new EventHandler(p_Exited);
            //proceso.Start();
            //proceso.WaitForExit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}