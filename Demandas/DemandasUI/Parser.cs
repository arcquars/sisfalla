using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserABNumber
{
    class Parser
    {
        string variables = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<char, int> _dicValores = new Dictionary<char, int>();
        public Parser()
        {
            int i = 1;
            foreach (char c in variables)
            {
                _dicValores[c] = i;
                i++;
            }
        }

        public int GetValor(string dato)
        {
            int resultado = 0;
            int j = 0;
            for (int i = dato.Length - 1; i >= 0; i--)
            {
                int v = _dicValores[dato[i]];
                resultado += v * (int)Math.Pow(26, j);
                j++;
            }
            return resultado;
        }
    }
}
