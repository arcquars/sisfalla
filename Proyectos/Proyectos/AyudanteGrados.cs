using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.UtilesComunes;

namespace Proyectos
{
    class AyudanteGrados
    {
        public static bool MinutosSegundosValidos(string dato)
        {
            bool resultado = true;
            string grados = dato.Substring(0, 2);
            string minutos = dato.Substring(4, 2);
            string segundosEnteros = dato.Substring(8, 2);
            string segundosDecimales = dato.Substring(11, 2);
            double segundos = int.Parse(segundosEnteros) + ((int.Parse(segundosDecimales)) / (100.0));

            if (int.Parse(minutos) >= 60)
            {
                resultado = false;
            }
            else if (segundos >= 60)
            {
                resultado = false;
            }
            return resultado;
        }

        public static string AsegurarFormato(string dato)
        {
            dato = ValidarNumero(dato, 0);
            dato = ValidarNumero(dato, 4);
            dato = ValidarNumero(dato, 8);
            dato = ValidarNumero(dato, 11);
            return dato;
        }

        private static string ValidarNumero(string p, int idx)
        {
            char[] c = p.ToArray();
            if (char.IsDigit(c[idx]))
            {
                if (!char.IsDigit(c[idx + 1]))
                {
                    Intercambiar(c, idx, idx + 1);
                    c[idx] = '0';
                }
            }
            else
            {
                c[idx] = '0';
                if (!char.IsDigit(c[idx + 1]))
                {
                    c[idx + 1] = '0';
                }
            }

            return new string(c);
        }

        private static void Intercambiar(char[] c, int a, int b)
        {
            char tmp = c[a];
            c[a] = c[b];
            c[b] = tmp;
        }
    }
}
