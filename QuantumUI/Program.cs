using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CNDC.Pistas;
using System.Reflection;
using System.Threading;
using CNDC.UtilesComunes;

namespace QuantumUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool created=true;
            string name = "SisFallaV2";
            //Mutex mutex = new Mutex(true, name, out created);
            if (created)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                CNDC.Config.Config.Intance.DirectorioConfiguracion = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Instanciador.Instancia.StartupPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                try
                {
                    Application.Run(new QuantumPrincipal());
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("Quantum", ex);
                }
                finally
                {
                    //mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("La aplicación ya esta en ejecución.","SisFalla V2");
                Application.Exit();
            }
        }
       
    }
}
