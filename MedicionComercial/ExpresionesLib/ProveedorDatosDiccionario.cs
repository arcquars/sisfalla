using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class ProveedorDatosDiccionario : IProveedorDatos
    {
        Dictionary<string, double> _dicValores = new Dictionary<string, double>();
        public ProveedorDatosDiccionario(Dictionary<string, double> v)
        {
            _dicValores = v;
        }

        public double GetValor(string variable)
        {
            return _dicValores[variable];
        }
    }
}