using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class ParserIf
    {
        public List<ArbolExpresion> GetArbolesExpresion(string expresion)
        {
            List<ArbolExpresion> resultado = new List<ArbolExpresion>();
            int idxInicioIf = expresion.IndexOf("[") + 1;
            int idxFinIf = expresion.IndexOf("]") - 1;
            string condicion = expresion.Substring(idxInicioIf, idxFinIf - idxInicioIf + 1);
            int idxInicioA = expresion.IndexOf("{");
            int idxFinA = expresion.IndexOf("}");
            string expresionA = expresion.Substring(idxInicioA + 1, idxFinA - idxInicioA - 1);

            int idxInicioB = expresion.LastIndexOf("{");
            int idxFinB = expresion.LastIndexOf("}");
            string expresionB = expresion.Substring(idxInicioB + 1, idxFinB - idxInicioB - 1);
            ParserExpresion parserExp = new ParserExpresion();
            ArbolExpresion arbolCondicion = parserExp.GetArbolExpresion(condicion);
            ArbolExpresion arbolA = parserExp.GetArbolExpresion(expresionA);
            ArbolExpresion arbolB = parserExp.GetArbolExpresion(expresionB);
            resultado.Add(arbolCondicion);
            resultado.Add(arbolA);
            resultado.Add(arbolB);
            return resultado;
        }
    }
}
