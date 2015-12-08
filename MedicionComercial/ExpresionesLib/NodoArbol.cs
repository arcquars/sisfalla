using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpresionesLib
{
    public class NodoArbol<T>
    {
        public T Valor { get; set; }
        public NodoArbol<T> Izq { get; set; }
        public NodoArbol<T> Der { get; set; }

        public bool EsHoja()
        {
            return Izq == Der;
        }
    }
}
