using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CNDC.BLL;

namespace ExceptionHandlerTest
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
            Sesion.Instancia.IniciarSesion(Environment.UserName, string.Empty);
            Application.Run(new Form1());
        }
    }
}
