using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class ParserExpresion
    {
        public ArbolExpresion GetArbolExpresion(string expresion)
        {
            ArbolExpresion resultado = new ArbolExpresion();
            Stack<NodoArbol<TokenExpresion>> pilaVariables = new Stack<NodoArbol<TokenExpresion>>();
            Stack<TokenExpresion> pilaOperadores = new Stack<TokenExpresion>();
            Scanner s = new Scanner();
            List<TokenExpresion> tokens = s.GetTokens(expresion);

            foreach (TokenExpresion t in tokens)
            {
                if (t.EsSimboloAgrupacionApertura())
                {
                    pilaOperadores.Push(t);
                }
                else if (t.EsSimboloAgrupacionCierre())
                {
                    bool continuar = true;
                    while (continuar)
                    {
                        TokenExpresion t1 = pilaOperadores.Pop();
                        if (t1.EsSimboloAgrupacionApertura())
                        {
                            continuar = false;
                        }
                        else
                        {
                            NodoArbol<TokenExpresion> n = new NodoArbol<TokenExpresion>();
                            n.Valor = t1;
                            n.Der = pilaVariables.Pop();
                            n.Izq = pilaVariables.Pop();
                            pilaVariables.Push(n);
                        }
                    }
                }
                else if (t.EsOperador())
                {
                    bool continuar = true;
                    while (continuar)
                    {
                        if (pilaOperadores.Count == 0)
                        {
                            break;
                        }

                        TokenExpresion t1 = pilaOperadores.Peek();
                        if (t1.EsSimboloAgrupacionApertura())
                        {
                            continuar = false;
                        }
                        else if (t1.GetPrecedencia() > t.GetPrecedencia())
                        {
                            t1 = pilaOperadores.Pop();
                            NodoArbol<TokenExpresion> n1 = new NodoArbol<TokenExpresion>();
                            n1.Valor = t1;
                            n1.Der = pilaVariables.Pop();
                            n1.Izq = pilaVariables.Pop();
                            pilaVariables.Push(n1);
                        }
                        else
                        {
                            continuar = false;
                        }
                    }
                    pilaOperadores.Push(t);
                }
                else
                {
                    NodoArbol<TokenExpresion> n = new NodoArbol<TokenExpresion>();
                    n.Valor = t;
                    pilaVariables.Push(n);
                }
            }

            while (pilaOperadores.Count > 0)
            {
                TokenExpresion operador = pilaOperadores.Pop();
                NodoArbol<TokenExpresion> n = new NodoArbol<TokenExpresion>();
                n.Valor = operador;
                n.Der = pilaVariables.Pop();
                n.Izq = pilaVariables.Pop();
                pilaVariables.Push(n);
            }

            if (pilaVariables.Count > 0)
            {
                resultado.Raiz = pilaVariables.Pop();
            }
            return resultado;
        }
    }
}
