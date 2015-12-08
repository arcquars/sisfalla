using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class ArbolExpresion
    {
        public NodoArbol<TokenExpresion> Raiz { get; set; }

        public void PosOrden()
        {
            PosOrden(Raiz);
            Console.WriteLine();
        }

        private void PosOrden(NodoArbol<TokenExpresion> n)
        {
            if (n == null)
            {
                return;
            }

            PosOrden(n.Izq);
            PosOrden(n.Der);
            Console.Write(n.Valor.ToString()+" ");
        }

        public object Evaluar(IProveedorDatos proveedorDatos)
        {
            return Evaluar(Raiz, proveedorDatos);
        }

        private object Evaluar(NodoArbol<TokenExpresion> n, IProveedorDatos proveedorDatos)
        {
            if (n == null)
            {
                return 0;
            }
            if (n.EsHoja())
            {
                return n.Valor.Evaluar(proveedorDatos);
            }

            object resultado = 0;
            object izq = Evaluar(n.Izq, proveedorDatos);
            object der = Evaluar(n.Der, proveedorDatos);

            switch (n.Valor.Token)
            {
                case ">":
                    resultado = (double)izq > (double)der;
                    break;
                case "<":
                    resultado = (double)izq < (double)der;
                    break;
                case "+":
                    resultado = (double)izq + (double)der;
                    break;
                case "-":
                    resultado = (double)izq - (double)der;
                    break;
                case "*":
                    resultado = (double)izq * (double)der;
                    break;
                case "/":
                    resultado = (double)izq / (double)der;
                    break;
            }

            return resultado;
        }
    }
}
