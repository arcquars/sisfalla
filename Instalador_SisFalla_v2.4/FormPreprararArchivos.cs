using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Instalador_SisFalla_v2._4
{
    public partial class FormPreprararArchivos : Form
    {
        public FormPreprararArchivos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormPreprararArchivos_Load);
        }

        void FormPreprararArchivos_Load(object sender, EventArgs e)
        {
          
        }
        private void incrementar(int v)
        {
            if ((prgTaskProgress.Value + v) > prgTaskProgress.Maximum)
            {
                prgTaskProgress.Value = prgTaskProgress.Minimum;
            }

            prgTaskProgress.Value += v;
        }
        private bool CopiarDirectorios()
        {
            bool rtn = true;

            try
            {
                prgTaskProgress.Value += 5;
                string ruta = string.Empty;
                FileInfo finfo = new FileInfo(Application.ExecutablePath);
                ruta = Path.Combine(finfo.DirectoryName, "Instalacion");

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(ruta, "*",
                    SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(ruta, FormInstalador24.rutaDestino));
                    
                    incrementar( 5);
                }
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(ruta, "*.*",
                    SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(ruta, FormInstalador24.rutaDestino), true);
                    incrementar(5); 
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rtn;
        }
        private bool CrearDirectorios()
        {
            bool rtn = true;
            try
            {
                prgTaskProgress.Value += 10;
                if (!System.IO.Directory.Exists(FormInstalador24.rutaDestino))
                {
                    System.IO.Directory.CreateDirectory(FormInstalador24.rutaDestino);
                    incrementar(5);
                }
                DirectoryInfo myDirInfo = new DirectoryInfo(FormInstalador24.rutaDestino);

                foreach (FileInfo file in myDirInfo.GetFiles())
                {
                    file.Delete();
                    incrementar(1);
                }
                foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                {
                    dir.Delete(true);
                    incrementar(3);
                }
            }
            catch (Exception)
            {

                rtn = false;
            }
            return rtn;

        }

        public void Iniciar()
        {
            label1.Visible = true;
            label1.Text = "Creando Directorios";
            this.Refresh();
            if (!CrearDirectorios())
            {
                string msg = string.Format("No se pudo borrar la carpeta :{0}. Por favor eliminela manualmente.", FormInstalador24.rutaDestino);
                MessageBox.Show(msg);
                Application.Exit();
            }
            label1.Text = "Copiando Archivos";
            this.Refresh();
            if (!CopiarDirectorios())
            {
                string msg = string.Format("No se pudo borrar la carpeta :{0}. Por favor eliminela manualmente.", FormInstalador24.rutaDestino);
                MessageBox.Show(msg);
                Application.Exit();
            }
            prgTaskProgress.Value = prgTaskProgress.Maximum ;
            this.Close();
        }

        private void cndcPanelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
