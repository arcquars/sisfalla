using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace WcfServicioActualizacion
{
    public class ServicioActualizacion : IServActualizacion
    {
        public ServicioActualizacion()
        {
        }

        public Archivo[] GetVersiones(string modulo)
        {
            List<Archivo> resultado = new List<Archivo>();
            string dirActulizacion = ConfigurationManager.AppSettings["DirActualizacion"];
            string directorioModulo = Path.Combine(dirActulizacion, modulo);
            string pathArchivoVersiones = Path.Combine(directorioModulo, "versiones.txt");
            StreamReader r = new StreamReader(pathArchivoVersiones);

            while (!r.EndOfStream)
            {
                string linea = r.ReadLine();
                string[] datos = linea.Split('=');
                Archivo arch = new Archivo();
                arch.Nombre = datos[0];
                arch.Version = int.Parse(datos[1]);
                string pathArchivo = Path.Combine(directorioModulo, arch.Nombre);

                if (File.Exists(pathArchivo))
                {
                    resultado.Add(arch);
                }
            }

            r.Close();
            return resultado.ToArray();
        }

        public byte[] GetArchivo(string modulo, string archivo)
        {
            byte[] resultado = null;
            string dirActulizacion = ConfigurationManager.AppSettings["DirActualizacion"];
            string directorioModulo = Path.Combine(dirActulizacion, modulo);
            string pathArchivo = Path.Combine(directorioModulo, archivo);
            resultado = File.ReadAllBytes(pathArchivo);
            resultado = CNDC.UtilesComunes.GZip.Comprimir(resultado);
            return resultado;
        }
    }
}