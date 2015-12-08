using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace InstaladorSisfalla
{
    public partial class FormInstaldorBD : Form
    {
        string _rutaOracleBin = string.Empty;
        string _rutaDestino = "C:\\InstaladorQ\\Esquema";

        public FormInstaldorBD()
        {
            InitializeComponent();
        }

        private bool TestConnection(bool runfromPath)
        {
            bool resultado = false;
            string cadenaDeConexion = "USER ID={0};DBA Privilege=SYSDBA;DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=xe)));PASSWORD=\"{1}\";PERSIST SECURITY INFO=true;";
            cadenaDeConexion = string.Format(cadenaDeConexion, _txtUsuario.Text, _txtContrasena.Text);
            try
            {
                OracleConnection con = new OracleConnection(cadenaDeConexion);
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select sysdate from dual";
                DataTable tabla = new DataTable();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(tabla);
                con.Close();

                if (tabla.Rows.Count > 0)
                {
                    _lblMensaje.Text = "Hora Base de Datos: " + (DateTime)tabla.Rows[0][0];
                    resultado = true;
                }
                else
                {
                    _lblMensaje.Text = "...";
                }
            }
            catch (OracleException oex)
            {
                if (oex.Number == 1017)
                {
                    MessageBox.Show("Contraseña no valida");
                    _txtContrasena.Text = "";
                }
                else
                {
                    if (!runfromPath)
                    {
                        MessageBox.Show("Error en la conexión a la base de datos. Por favor aplique el PARCHE XE");
                        _btnParche.Enabled = true;
                    }
                }
            }
            return resultado;
        }

        private void _btnInstalarBD_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents(); 
            if (TestConnection(false))
            {
                CrearSilentinstall(_rutaDestino);
                CrearImportBat(_rutaDestino);
                CrearImportTxt(_rutaDestino);

                Process proceso = new Process();
                proceso.StartInfo.FileName = Path.Combine(_rutaDestino, "installBD.bat");
                proceso.EnableRaisingEvents = true;
                proceso.Exited += new EventHandler(p_Exited);
                proceso.StartInfo.UseShellExecute = false;
                proceso.StartInfo.CreateNoWindow = true;
                proceso.StartInfo.RedirectStandardOutput = true;

               
                string str = string.Empty;
                try
                {
                    proceso.Start();
                    str = proceso.StandardOutput.ReadToEnd();
                   PistaMgr.Instance.EscribirEnLocal("InslaladorBD", str);
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.EscribirEnLocal("InslaladorBD", ex);
                }
                proceso.WaitForExit();
                DialogResult = DialogResult.OK;
            }
            Cursor = Cursors.Default;
            Application.DoEvents();
        }

        void p_Exited(object sender, EventArgs e)
        {
         
        }

        private void CrearSilentinstall(string strDestino)
        {
            StreamWriter w = new StreamWriter(Path.Combine(strDestino, "installBD.bat "));
            string b = string.Format("{0}\\install_quantum\\import.bat", strDestino);
            w.WriteLine(b);
            w.Close();
        }

        private void CrearImportTxt(string strDestino)
        {
            string carpetaImport = Path.Combine(strDestino, "install_quantum");
            StreamWriter w = new StreamWriter(Path.Combine(carpetaImport, "import.txt "));
            string a = @"BUFFER=10000000  FILE=" + strDestino + @"\install_quantum\quantum.exp FULL=n  fromuser=quantum touser=quantum GRANTS=n";

            w.WriteLine(a);
            w.Close();
        }

        private void CrearImportBat(string strDestino)
        {
            string carpetaImport = Path.Combine(strDestino, "install_quantum");
            StreamWriter w = new StreamWriter(Path.Combine(carpetaImport, "import.bat "));

            string a = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\dropcreateUser.sql";
            string b = Path.Combine(_rutaOracleBin, "imp") + @" quantum/quantum@xe  parfile=" + strDestino + @"\install_quantum\import.txt";
            string c = Path.Combine(_rutaOracleBin, "sqlplus") + @" quantum/quantum@xe  @" + strDestino + @"\install_quantum\views.sql";
            string d = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\recompileall.sql";
            string e = Path.Combine(_rutaOracleBin, "sqlplus") + @" quantum/quantum@xe  @" + strDestino + @"\install_quantum\droptriggers.sql";
            string f = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\role.sql";
            string g = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba  @" + strDestino + @"\install_quantum\drop_public_synonym.sql";
            string h = Path.Combine(_rutaOracleBin, "sqlplus") + @" quantum/quantum@xe  @" + strDestino + @"\install_quantum\grant_role_sisfalla.sql";
            string i = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\create_public_synonym.sql";
            string j = Path.Combine(_rutaOracleBin, "sqlplus") + @" sys/sys@xe as sysdba @" + strDestino + @"\install_quantum\users.sql";
            string k = Path.Combine(_rutaOracleBin, "sqlplus") + @" quantum/quantum@xe @" + strDestino + @"\install_quantum\grants.sql";

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

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void FormInstaldorBD_Load(object sender, EventArgs e)
        {

            RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\KEY_XE");
            _rutaOracleBin = regKeyAppRoot.GetValue("ORACLE_HOME").ToString();
            if (string.IsNullOrEmpty(_rutaOracleBin))
            {
               
            }
            else
            {
                _rutaOracleBin = Path.Combine(_rutaOracleBin, "bin");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TestConnection(true))
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                Process proceso = new Process();
                proceso.StartInfo.FileName = Path.Combine(_rutaDestino, "oracleRecover.bat");
                proceso.StartInfo.Arguments = _txtContrasena.Text;
                proceso.EnableRaisingEvents = true;
                proceso.Exited += new EventHandler(p_Exited);
                

                proceso.Start();
                
                proceso.WaitForExit();
                Cursor = Cursors.Default;
            }
        }
    }
}