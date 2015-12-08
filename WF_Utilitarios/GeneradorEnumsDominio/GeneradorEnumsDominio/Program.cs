using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.DAL;
using CNDC.Config;
using System.Windows.Forms;

namespace GeneradorEnumsDominio
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Intance.DirectorioConfiguracion = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            DataTable tablaDominio = ConnexionOracleMgr.Instancia.GetTabla("P_DEF_DOMINIOS");

            GeneradorEnum generador = new GeneradorEnum();
            generador.CargarDatos(tablaDominio);
            generador.CrearEnums("CNDC.Dominios", "..\\..\\..\\..\\Utils\\BLL\\Dominios.cs");

        }
    }
}
