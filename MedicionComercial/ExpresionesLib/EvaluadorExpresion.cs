using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class EvaluadorExpresion
    {
        string _expresion;
        List<ArbolExpresion> arboles;
        bool tieneIF;
        public EvaluadorExpresion(string expresion)
        {
            _expresion=expresion;

            if (expresion.StartsWith("IF"))
            {
                tieneIF = true;
                ParserIf parser = new ParserIf();
                arboles = parser.GetArbolesExpresion(expresion);
            }
            else
            {
                tieneIF = false;
                ParserExpresion parser = new ParserExpresion();
                ArbolExpresion a = parser.GetArbolExpresion(expresion);
                arboles = new List<ArbolExpresion>() { a };
            }
        }
        public double Evaluar(IProveedorDatos proveedorDatos)
        {
            double resultado = 0;
            if (tieneIF)
            {
                bool condicion = (bool)arboles[0].Evaluar(proveedorDatos);
                if (condicion)
                {
                    resultado = (double)arboles[1].Evaluar(proveedorDatos);
                }
                else
                {
                    resultado = (double)arboles[2].Evaluar(proveedorDatos);
                }
            }
            else
            {
                resultado = (double)arboles[0].Evaluar(proveedorDatos);
            }
            return resultado;
        }
    }
}
