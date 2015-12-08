using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using ModeloProyectos;
using DevExpress.XtraTreeList.Nodes;

namespace Proyectos
{
    public partial class CtrlPrincipalIzquierda : UserControl
    {
        TreeNode _nodoAnterior = null;
        public event EventHandler<TipoProySelecEventArgs> TipoProyectoSeleccionado;
        public CtrlPrincipalIzquierda()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarArbol();
            }
        }

        public void CargarArbol()
        {
            TipoProyectoUIMgr.Instancia.CargarNodos();
            treeList1.BeginUpdate();
            treeList1.Columns.Add();
            treeList1.Columns[0].Caption = "Customer";
            treeList1.Columns[0].VisibleIndex = 0;
            treeList1.EndUpdate();

            treeList1.BeginUnboundLoad();
            CargarNodos(TipoProyectoUIMgr.Instancia.Nodos, null);
            treeList1.EndUnboundLoad();
            //treeView1.Nodes.AddRange(TipoProyectoUIMgr.Instancia.Nodos);
        }

        Dictionary<TreeListNode, NodoDominio> _nodosDominio = new Dictionary<TreeListNode, NodoDominio>();
        public void CargarNodos(NodoDominio[] nodos, TreeListNode n)
        {
            foreach (NodoDominio nodo in nodos)
            {
                TreeListNode nodoList = treeList1.AppendNode(new object[] { nodo }, n);
                _nodosDominio[nodoList] = nodo;
                CargarNodos(nodo.Nodes.ToArray(), nodoList);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //NodoDominio nodoSeleccionado = (NodoDominio)e.Node;
            //NodoDominio nodoPadre = TipoProyectoUIMgr.Instancia.GetNodoPadre(nodoSeleccionado);
            //OnTipoProyectoSeleccionado(nodoSeleccionado.Dominio, nodoPadre.Dominio);
        }

        private void OnTipoProyectoSeleccionado(DefDominio tipoProy, DefDominio tipoProyPadre)
        {
            if (TipoProyectoSeleccionado != null)
            {
                TipoProyectoSeleccionado(this, new TipoProySelecEventArgs(tipoProy, tipoProyPadre));
            }
        }

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            NodoDominio nodoSeleccionado = _nodosDominio[e.Node];
            NodoDominio nodoPadre = TipoProyectoUIMgr.Instancia.GetNodoPadre(nodoSeleccionado);
            OnTipoProyectoSeleccionado(nodoSeleccionado.Dominio, nodoPadre.Dominio);
        }
    }

    public class TipoProySelecEventArgs : EventArgs
    {
        private DefDominio _tipoProyecto;
        private DefDominio _tipoProyectoPadre;

        public TipoProySelecEventArgs(DefDominio tipoProy,DefDominio tipoProyPadre) 
        {
            _tipoProyecto = tipoProy;
            _tipoProyectoPadre = tipoProyPadre;
        }

        public DefDominio TipoProyectoSeleccionado
        {
            get { return _tipoProyecto; } 
        }

        public DefDominio TipoProyectoPadreSeleccionado
        {
            get { return _tipoProyectoPadre; }
        }
    }
}
