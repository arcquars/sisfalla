using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LecturaArchivos
{
    class UtilitarioLectura
    {
        public static void LimpiarComillas(string[] datos)
        {
            for (int i = 0; i < datos.Length; i++)
            {
                datos[i] = datos[i].Replace("\"", "").Trim();
            }
        }
    }
}
