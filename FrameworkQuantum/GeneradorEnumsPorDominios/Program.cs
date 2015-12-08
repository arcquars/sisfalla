using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeneradorEnumsPorDominios
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
            Application.Run(new Form1());
        }
    }
}
