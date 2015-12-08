using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CNDC.UtilesComunes;
using WcfServicioActualizacion;
using SisFallaEmailLib;
using System.Data;
using CNDC.BLL;



namespace Actualizador
{

    public partial class Form1 : Form
    {
        string _nombreModulo = "SisFalla";
        FormSplash _splash;
        IServActualizacion _servActualizacion;
        Dictionary<string, float> _dicArchivosLocales;
        Dictionary<string, float> _dicArchivosServidor;
        List<string> _archivosParaActualizar;
        string pathLog;
        public Form1()
        {
            InitializeComponent();
            try
            {
                _splash = new FormSplash();
                _dicArchivosLocales = new Dictionary<string, float>();
                _dicArchivosServidor = new Dictionary<string, float>();
                _archivosParaActualizar = new List<string>();
                Text = "Actualizador " + _nombreModulo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString ()   );
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            try
            {
                _splash.Show();
                Application.DoEvents();
                _servActualizacion = new ServActualizacionClient();
                
                
                CargarArchivosLocales();
                WcfServicioActualizacion.Archivo[] archivosServidor = _servActualizacion.GetVersiones(_nombreModulo);
                _dicArchivosServidor = GetDiccionario(archivosServidor);

             Dictionary<string, Version > versiones=GetDllVersion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el Servicio de actualización." + Environment.NewLine + ex.ToString());
            }

            _splash.Close();
            CargarListaArchivosParaActualizar();
            if (_archivosParaActualizar.Count > 0)
            {
            }
            else
            {
                IniciarAplicacion();
            }
        }
        private Dictionary<string, Version> GetDllVersion()
        {
            string dirApp = GetLocalFolder();

            Dictionary<string, Version > versiones= new Dictionary<string, Version >();
            DirectoryInfo oDirectorio = new DirectoryInfo(dirApp);

            //obtengo ls ficheros contenidos en la ruta
            foreach (FileInfo file in oDirectorio.GetFiles("*.dll"))
            {
                Assembly  asm = Assembly.LoadFile(file.FullName);
                versiones.Add(asm.GetName().Name,asm.GetName().Version);
             
            }
            return versiones;
        }
        private void CargarListaArchivosParaActualizar()
        {
            foreach (KeyValuePair<string, float> kv in _dicArchivosServidor)
            {
                if (_dicArchivosLocales.ContainsKey(kv.Key))
                {
                    if (kv.Value > _dicArchivosLocales[kv.Key])
                    {
                        _archivosParaActualizar.Add(kv.Key);
                    }
                }
                else
                {
                    _archivosParaActualizar.Add(kv.Key);
                }
            }
        }

        private Dictionary<string, float> GetDiccionario(WcfServicioActualizacion.Archivo[] archivosServidor)
        {
            Dictionary<string, float> resultado = new Dictionary<string, float>();
            foreach (var a in archivosServidor)
            {
                resultado[a.Nombre] = a.Version;
            }
            return resultado;
        }

        private string GetLocalFolder()
        {
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
            return dirApp;
        }
        public void CargarArchivosLocales()
        {
            string dirApp = GetLocalFolder();

            AsegurarModuloLocal();
            if (Directory.Exists(dirApp))
            {
                string pathArchivoVersiones = Path.Combine(dirApp, "versiones.txt");
                if (File.Exists(pathArchivoVersiones))
                {
                    StreamReader r = new StreamReader(pathArchivoVersiones);

                    while (!r.EndOfStream)
                    {
                        string linea = r.ReadLine();
                        string[] datos = linea.Split('=');
                        _dicArchivosLocales[datos[0]] = int.Parse(datos[1]);
                    }
                    r.Close();
                }
            }
        }

        private void AsegurarModuloLocal()
        {
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dirAplicacion = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
            if (!Directory.Exists(dirAplicacion))
            {
                Directory.CreateDirectory(dirAplicacion);
                string archivosDePrograma = GetFolderArchivosDePrograma();
                string dirAppInstalacion = Path.Combine(Path.Combine(archivosDePrograma, "CNDC"), _nombreModulo);

                DirectoryInfo destino = new DirectoryInfo(dirAplicacion);
                DirectoryInfo origen = new DirectoryInfo(dirAppInstalacion);
                CopiarTodo(origen, destino);
                CrearArchivoVersionInicial();
            }
        }

        private string GetFolderArchivosDePrograma()
        {
            return Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }

        private void CrearArchivoVersionInicial()
        {
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dirAplicacion = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
            string archivoVersion = Path.Combine(dirAplicacion, "versiones.txt");

            string[] archivos = Directory.GetFiles(dirAplicacion);
            StreamWriter w = new StreamWriter(archivoVersion);
            foreach (string pathArchivo in archivos)
            {
                string archivo = Path.GetFileName(pathArchivo);
                w.WriteLine(archivo + "=1");
            }
            w.Close();
            w.Dispose();
        }

        public static void CopiarTodo(DirectoryInfo origen, DirectoryInfo destino)
        {
            if (Directory.Exists(destino.FullName) == false)
            {
                Directory.CreateDirectory(destino.FullName);
            }

            string archivoDestino = string.Empty;
            if (origen.Exists)
            {
                foreach (FileInfo fi in origen.GetFiles())
                {
                    archivoDestino = Path.Combine(destino.ToString(), fi.Name);
                    fi.CopyTo(archivoDestino, true);
                    FileInfo f = new FileInfo(archivoDestino);
                    f.IsReadOnly = false;
                }

                foreach (DirectoryInfo diSourceSubDir in origen.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir = destino.CreateSubdirectory(diSourceSubDir.Name);
                    CopiarTodo(diSourceSubDir, nextTargetSubDir);
                }
            }
        }

        private void _btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _btnActualizar.Enabled = false;
                _lblActualizando.Visible = true;
                _pgbActualizacion.Visible = true;
                this.Height += 30;
                if (ActualizarAplicacion())
                {

                    IniciarAplicacion();
                }
                
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.ToString ());
            }
        }

        private void _btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarAplicacion();
        }
    

      
       
        public bool  ActualizarAplicacion()
        {
            bool actualizacionCorrecta = true ;
            try
            {

                string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
               
                string nombreLog = string.Format("logActualizacion_{0}.txt", System.DateTime.Now.ToString("ddMMyy_HHmm"));
                pathLog = Path.Combine(dirApp, nombreLog);
                System.IO.StreamWriter log = new StreamWriter(pathLog , true);

                log.AutoFlush = true;
                _pgbActualizacion.Maximum = _archivosParaActualizar.Count;
                _pgbActualizacion.Update();
                Application.DoEvents();
                ConexionBD conexion = new ConexionBD("USER ID=quantum;DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=xe)));PASSWORD=quantum;PERSIST SECURITY INFO=true;");
                foreach (string archi in _archivosParaActualizar)
                {
                    byte[] datos = _servActualizacion.GetArchivo(_nombreModulo, archi);
                    datos = GZip.DesComprimir(datos);
                    string pathBack = Path.Combine (dirApp ,"BKFiles") ;

                    if (!Directory.Exists (pathBack ))
                    {
                        Directory.CreateDirectory(pathBack);
                    }
                    string destino = Path.Combine(dirApp, archi);

                    string backup = destino + ".back";

                    if (File.Exists(destino))
                    {
                        if (File.Exists(backup))
                        {
                            File.Delete(backup);
                        }
                        File.Copy(destino, backup);
                    }
                    try
                    {
                        File.WriteAllBytes(destino, datos);
                    }
                    catch (Exception ex)
                    {
                        log.WriteLine(archi);
                        log.WriteLine(string.Format("{0} - {1}", System.DateTime.Now.ToString("dd/MM/yyyy"), ex.ToString ()));
                        tbError.Text += ex.ToString();
                        actualizacionCorrecta = false;
                    }
                    _pgbActualizacion.Value++;
                    _pgbActualizacion.Update();

                    if (archi.EndsWith(".sql"))
                    {
                        string sql = GetTexto(destino);
                        string elog = conexion.EjecutarSql(sql);
                       
                        log.WriteLine(archi);
                        log.WriteLine(string.Format("{0} - {1}   {2} {3} {4} {5} {6} ", 
                            archi, 
                            System.DateTime.Now.ToString("dd/MM/yyyy"), 
                            Environment.NewLine,
                            sql, 
                            Environment.NewLine,
                            elog, 
                            Environment.NewLine, "-----------------------------------------"));
                       tbError.Text += elog;
                       actualizacionCorrecta = false;
                       tbError.Visible = false ;
                        
                    }

                    Application.DoEvents();
                }

                _pgbActualizacion.Value = _pgbActualizacion.Maximum;
                _pgbActualizacion.Update();
                Application.DoEvents();

                ActualizarVersion();
                _pgbActualizacion.Value = _pgbActualizacion.Maximum;
                _pgbActualizacion.Update();
                log.Flush();
                log.Close();
                if (actualizacionCorrecta)
                {
                  string archivoNotas = Path.Combine(dirApp, "notasActualizacion.txt");
                    if (File.Exists(archivoNotas))
                    {
                        
                        FormNotas fNotas = new FormNotas();
                        fNotas.VisualizarNotas(archivoNotas);
                    }
                }
                else
                {
                    FrmEnvioCorreo frm = new FrmEnvioCorreo();
                    frm.EnviarEmail(tbError.Text, pathLog);
                    frm.ShowDialog();
                    
                    this.Close();
                    
                }
               

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los archivos." + Environment.NewLine + ex.ToString());
            }
            return actualizacionCorrecta;
        }

        private string GetTexto(string archivo)
        {
            string resultado = string.Empty;
            try
            {
                StreamReader r = new StreamReader(archivo);
                resultado = r.ReadToEnd();
            }
            catch (Exception)
            {
            }

            return resultado;
        }

        private void ActualizarVersion()
        {
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
            string archivoVersion = Path.Combine(dirApp, "versiones.txt");

            StreamWriter w = new StreamWriter(archivoVersion,false);
            foreach (KeyValuePair<string, float> arch in _dicArchivosServidor)
            {
                w.WriteLine(string.Format("{0}={1}", arch.Key, (int)arch.Value));
            }
            w.Close();
        }

        private void IniciarAplicacion()
        {
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dirApp = Path.Combine(Path.Combine(misDocumentos, "AppsCNDC"), _nombreModulo);
            string aplicacion = Path.Combine(dirApp, _nombreModulo + ".exe");

            if (File.Exists(aplicacion))
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = aplicacion;
                proceso.Start();
            }
            else
            {
                MessageBox.Show("No se pudo inicializar la aplicación","Error",MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
            Application.Exit();
        }
    }
}