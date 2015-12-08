using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class Scanner
    {
        public List<TokenExpresion> GetTokens(string expresion)
        {
            List<TokenExpresion> resultado = new List<TokenExpresion>();
            string acum = string.Empty;
            foreach (char c in expresion)
            {
                if (c == ' ')
                {

                }
                else if (Char.IsLetterOrDigit(c) || c == '.')
                {
                    acum += c;
                }
                else
                {
                    if (acum != string.Empty)
                    {
                        resultado.Add(new TokenExpresion(acum));
                        acum = string.Empty;
                    }
                    resultado.Add(new TokenExpresion(c.ToString()));
                }
            }

            if (acum != string.Empty)
            {
                resultado.Add(new TokenExpresion(acum));
                acum = string.Empty;
            }

            return resultado;
        }
    }
}
