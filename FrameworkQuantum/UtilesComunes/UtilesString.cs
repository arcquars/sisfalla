using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.UtilesComunes
{
    public class UtilesString
    {
        public static string ToString(List<string> lista, string separador)
        {
            string str = string.Empty;

            if (lista == null)
            {
                str = null;
            }
            else
            {
                foreach (string s in lista)
                {
                    str += s + separador;
                }

                if (str.Length > separador.Length)
                {
                    str = str.Substring(0, str.Length - separador.Length);
                }
            }

            return str;
        }

        public static List<string> ToListString(string cadena, char separador)
        {
            List<string> lista = cadena.Split(separador).ToList();
            return lista;
        }
    }
}
