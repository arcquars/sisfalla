using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModeloComponentes
{
    public class  NodoArbol : TreeNode
    {
        public NodoArbol()
        { 
        }
        public long TipoComponente { get; private set; }
        public int EstadoComponente { get; private set; }
        public string DescripcionTipo{get; private set;}
        public NodoArbol(long tipoComponente, string descripcionTipo, int estadoComponente)
        {
            TipoComponente = tipoComponente;
            DescripcionTipo = descripcionTipo;
            EstadoComponente = estadoComponente;
        }
    }
}
