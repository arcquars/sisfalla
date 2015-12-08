using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class TokenExpresion
    {
        public string Token { get; set; }

        public TokenExpresion(string t)
        {
            Token = t;
        }

        public bool EsSimboloAgrupacionApertura()
        {
            return Token == "(";
        }

        public bool EsSimboloAgrupacionCierre()
        {
            return Token == ")";
        }

        public bool EsOperador()
        {
            return "><=+-*/".Contains(Token);
        }

        public int GetPrecedencia()
        {
            return "><=+-*/".IndexOf(Token);
        }

        public override string ToString()
        {
            return Token;
        }

        public double Evaluar(IProveedorDatos proveedorDatos)
        {
            double resultado = 0;
            if (char.IsDigit(Token[0]))
            {
                resultado = double.Parse(Token);
            }
            else
            {
                resultado = proveedorDatos.GetValor(Token);
            }
            return resultado;
        }
    }
}
