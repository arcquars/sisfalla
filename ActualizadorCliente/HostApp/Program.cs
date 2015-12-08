using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfServicioActualizacion;

namespace HostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ServicioActualizacion)))
            {
                host.Open();

                Console.WriteLine("CNDC");
                Console.WriteLine("Servicio de Actualización de Aplicaciones.");
                Console.ReadKey(true);

                host.Close();
            }
        }
    }
}
