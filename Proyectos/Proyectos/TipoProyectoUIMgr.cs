using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using ModeloProyectos;
using CNDC.BLL;

namespace Proyectos
{
    public class TipoProyectoUIMgr
    {
        #region Singleton
        private static TipoProyectoUIMgr _instancia;
        static TipoProyectoUIMgr()
        {
            _instancia = new TipoProyectoUIMgr(); 
        }

        public static TipoProyectoUIMgr Instancia
        {
            get { return _instancia; }
        }

        private TipoProyectoUIMgr()
        {
            CargarNodos();
        }
        #endregion Singleton

        private NodoDominio[] _nodos;
        private Dictionary<DefDominio, NodoDominio> _dicNodos;
        public NodoDominio[] Nodos
        {
            get { return _nodos; } 
        }

        public void CargarNodos()
        {
            _dicNodos = new Dictionary<DefDominio, NodoDominio>();
            DefDominioMgr mgr = new DefDominioMgr();
            BindingList<DefDominio> listaTipoProy = mgr.GetListaDominioOrdenado(DominiosProyectos.D_COD_TIPO_PROYECTO);
            _nodos= GetNodos(listaTipoProy);
        }

        private NodoDominio[] GetNodos(BindingList<DefDominio> listaTipoProy)
        {
            NodoDominio[] resultado = null;
            List<NodoDominio> nodos = new List<NodoDominio>();
            Dictionary<long, NodoDominio> dicNodos = new Dictionary<long, NodoDominio>();

            foreach (DefDominio defDom in listaTipoProy)
            {
                NodoDominio n = new NodoDominio(defDom);
                nodos.Add(n);
                dicNodos[n.Dominio.CodDominio] = n;
                _dicNodos[defDom] = n;
            }

            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Dominio.CodDominioPadre != 0)
                {
                    NodoDominio nodoPadre = dicNodos[nodos[i].Dominio.CodDominioPadre];
                    nodoPadre.Nodes.Add(nodos[i]);
                    nodos.Remove(nodos[i]);
                    i--;
                }
            }

            resultado = nodos.ToArray();
            return resultado;
        }

        public List<DefDominio> GetTipoProyectosHoja()
        {
            List<DefDominio> resultado = new List<DefDominio>();
            foreach (NodoDominio n in _nodos)
            {
                CargarNodosHoja(n, resultado);
            }
            return resultado;
        }

        private void CargarNodosHoja(NodoDominio n, List<DefDominio> resultado)
        {
            if (n.Nodes.Count == 0)
            {
                resultado.Add(n.Dominio);
            }
            else
            {
                foreach (NodoDominio hijo in n.Nodes)
                {
                    CargarNodosHoja(hijo, resultado);
                }
            }
        }

        public NodoDominio GetNodoPadre(NodoDominio tNode)
        {
            while (tNode.Parent != null)
            {
                tNode = (NodoDominio)tNode.Parent;
            }

            return tNode;
        }

        public DefDominio GetTipoProyPadre(DefDominio tipoProy)
        {
            DefDominio resultado = null;
            DefDominio defDomOriginal = GetDefDominioOriginal(tipoProy);
            NodoDominio nodo = _dicNodos[defDomOriginal];
            NodoDominio nodoPadre = GetNodoPadre(nodo);
            resultado = nodoPadre.Dominio;
            return resultado;
        }

        private DefDominio GetDefDominioOriginal(DefDominio tipoProy)
        {
            DefDominio resultado = null;
            foreach (DefDominio d in _dicNodos.Keys)
            {
                if (d.CodDominio == tipoProy.CodDominio)
                {
                    resultado = d;
                    break;
                }
            }
            return resultado;
        }

        public bool EsNodoHoja(DefDominio _tipoProyecto)
        {
            bool res = false;
            List<DefDominio> nodosHojas = GetTipoProyectosHoja();
            foreach (DefDominio tipoProy in nodosHojas)          
            {
                if (tipoProy.CodDominio == _tipoProyecto.CodDominio)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }

    public class NodoDominio 
    {
        public DefDominio Dominio { get; set; }
        public NodoDominio Parent { get; set; }
        public ColeccionNodosDominio Nodes { get; private set; }
        public NodoDominio(DefDominio dom)
        {
            Dominio = dom;
            Nodes = new ColeccionNodosDominio();
            Nodes.NodoAdicionado += new EventHandler<NodoEventArgs>(Nodes_NodoAdicionado);
            Nodes.NodoEliminado += new EventHandler<NodoEventArgs>(Nodes_NodoEliminado);
            //Text = dom.Descripcion;
        }

        void Nodes_NodoEliminado(object sender, NodoEventArgs e)
        {
            e.Nodo.Parent = null;
        }

        void Nodes_NodoAdicionado(object sender, NodoEventArgs e)
        {
            e.Nodo.Parent = this;
        }

        public override string ToString()
        {
            return Dominio.Descripcion;
        }
    }

    public class ColeccionNodosDominio: IEnumerable<NodoDominio>
    {
        private List<NodoDominio> _nodos;
        public event EventHandler<NodoEventArgs> NodoAdicionado;
        public event EventHandler<NodoEventArgs> NodoEliminado;

        public ColeccionNodosDominio()
        {
            _nodos = new List<NodoDominio>();
        }

        public int Count
        { get { return _nodos.Count; } }

        public void Add(NodoDominio n)
        {
            if (!_nodos.Contains(n))
            {
                _nodos.Add(n);
                OnNodoAdicionado(n);
            }
        }

        private void OnNodoAdicionado(NodoDominio n)
        {
            if (NodoAdicionado != null)
            {
                NodoAdicionado(this, new NodoEventArgs(n));
            }
        }

        public void Remove(NodoDominio n)
        {
            if (_nodos.Contains(n))
            {
                _nodos.Remove(n);
                OnNodoEliminado(n);
            }
        }

        private void OnNodoEliminado(NodoDominio n)
        {
            if (NodoEliminado != null)
            {
                NodoEliminado(this, new NodoEventArgs(n));
            }
        }

        public IEnumerator<NodoDominio> GetEnumerator()
        {
            return _nodos.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _nodos.GetEnumerator();
        }
    }

    public class NodoEventArgs : EventArgs
    {
        private NodoDominio _nodo;
        public NodoEventArgs(NodoDominio n)
        {
            _nodo = n;
        }

        public NodoDominio Nodo
        { get { return _nodo; } }
    }
}
