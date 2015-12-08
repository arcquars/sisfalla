using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MC
{
    public abstract class ILector
    {
        public abstract ResultadoLectura Leer(string archivo, ParametrosLectura param);

        public double? GetDouble(string dato)
        {
            double? resultado = null;
            try
            {
                resultado = double.Parse(dato);
            }
            catch
            {
            }
            return resultado;
        }
    }
}
