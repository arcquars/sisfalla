using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CNDC.Pistas;

namespace WF_BorradorFallas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CNDC.Config.Config.Intance.DirectorioConfiguracion = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("SisFalla", ex);
            }
        }
    }
}
