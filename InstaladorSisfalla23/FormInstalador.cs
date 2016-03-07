using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Threading;
using InstaladorSisfalla.Properties;
using System.Diagnostics;

namespace InstaladorSisfalla
{
    public partial class FormInstalador : Form
    {
        public static string rutaDestino = @"c:\InstaladorQ\";
        delegate void TaskDelegate();
        private string deInstallSisfalla = string.Empty;

        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }


        public FormInstalador()
        {
            InitializeComponent();
            if (!IsUserAdministrator())
            {
                MessageBox.Show("El programa se debe ejecutar como administrador", "Ejecutar como administrador");
                this.Close();
                Application.Exit();
            }
            else
            {
                this.Load += new EventHandler(FormInstalador_Load);
            }


        }

        void FormInstalador_Load(object sender, EventArgs e)
        {

            TaskDelegate td = new TaskDelegate(new ThreadStart(TheLongRunningTask));
            td.BeginInvoke(null, null); // Runs on a worker thread from the pool

            Dictionary <string ,string > d = new Dictionary<string,string> ();
            if (!(Instalado.Installed(out d, "ORACLE DATABASE 11G EXPRESS")))
            {
                pbBd.Image = Resources.si;    
            }
            

            if (Instalado.Installed(out d, "SISFALLA"))
            {
                
                button4.Text = "Desinstalar";
                if (d.ContainsKey("UninstallString"))
                {
                    string deinstall = d["UninstallString"];
                    deInstallSisfalla = deinstall.Replace("/I", "/x");
                }
            }
            else
            {
              
                button4.Visible = false;
            }
            
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cndcPanelControl1_Paint(object sender, PaintEventArgs e)
        {




        }

        private void TheLongRunningTask()
        {
            FormPreprararArchivos f = new FormPreprararArchivos();
            f.Show();
            f.Refresh();

            f.Iniciar();
            f.Hide();
            f.Dispose();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string parametros = deInstallSisfalla.Substring(deInstallSisfalla.IndexOf(" "));
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = parametros;
            try
            {
            // Start the process with the info we specified.        
            // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }

        private void _btnInstalarEsquema_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\InstaladorQ\Instalador\setup.exe";
            string parametros = string.Empty;
            if (deInstallSisfalla.Length > 0)
            {
                parametros = deInstallSisfalla.Substring(deInstallSisfalla.IndexOf(" "));
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (File.Exists (fileName))
            {
                startInfo.FileName = @"C:\InstaladorQ\Instalador\setup.exe";
                _lblMensaje.Text = string.Format("{0} {1}", startInfo.FileName, parametros);
                startInfo.Arguments = parametros;
                try
                {
                    // Start the process with the info we specified.        
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch
                {
                    // Log error.
                }
            }
            else
            {
                MessageBox.Show(string.Format("No se encontro el Archivo {0}.  Por favor ejecute de nuevamente el instalador. ", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _lblMensaje.Text = "[...]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInstaldorBD f = new FormInstaldorBD();
            f.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string parametros =string.Empty ;
            if (deInstallSisfalla.Length > 0)
            {
                parametros = deInstallSisfalla.Substring(deInstallSisfalla.IndexOf(" "));
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\InstaladorQ\Instalador\cr2008sp4_redist\CRRuntime_12_4_mlb.msi";
            startInfo.Arguments = "";
            try
            {
                // Start the process with the info we specified.        
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string parametros =string.Empty;

            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\InstaladorQ\SetupActualizador\SetupActualizador.msi";
            startInfo.Arguments = "";
            try
            {
                // Start the process with the info we specified.        
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }

            try
            {
                string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), "Sisfalla");
                
                if (Directory.Exists (dirApp))
                {
                    Directory.Delete(dirApp, true);
                }
                Directory.CreateDirectory (dirApp);

                FileInfo finfo = new FileInfo(Application.ExecutablePath);
               string  rutaOrigen =Path.Combine ( Path.Combine(finfo.DirectoryName, "Instalacion"),"Sisfalla23");
               CrearDirectorios(rutaOrigen, dirApp);
               CopiarDirectorios(rutaOrigen, dirApp);
            }
            catch (Exception s)
            {
                
                throw;
            }
        }

        private bool CopiarDirectorios(string rutaOrigen , string rutaDestino)
        {
            bool rtn = true;

            try
            {
             
          

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(rutaOrigen, "*",
                    SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(rutaOrigen,rutaDestino));    
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(rutaOrigen, "*.*",
                    SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(rutaOrigen, rutaDestino), true);
                   
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rtn;
        }
        private bool CrearDirectorios(string rutaOrigen , string rutaDestino)
        {
            bool rtn = true;
            try
            {
            
                if (!System.IO.Directory.Exists(rutaDestino))
                {
                    System.IO.Directory.CreateDirectory(rutaDestino);
                  
                }
                DirectoryInfo myDirInfo = new DirectoryInfo(rutaDestino);

                foreach (FileInfo file in myDirInfo.GetFiles())
                {
                    file.Delete();
                  
                }
                foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                {
                    dir.Delete(true);
                
                }
            }
            catch (Exception)
            {

                rtn = false;
            }
            return rtn;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"c:\InstaladorQ\Instalador\cr2008sp4_redist\reportes_bug.reg";
            startInfo.Arguments = "";
            try
            {
                // Start the process with the info we specified.        
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
    }
}
