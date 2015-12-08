using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using ModeloComponentes;
using OraDalComponentes;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraNavBar.ViewInfo;


namespace ComponentesUI
{
    public partial class CtrlPanelTipoComponente : QuantumBaseControl
    {
        public event EventHandler<NodoClickEventArgs> NodoClick;
        public event EventHandler<NodoClickEventArgs> GrupoClick;
        TreeNode _nodoAnterior = new TreeNode();
        TipoComponenteMgr mgr = new TipoComponenteMgr();
       
        
        public CtrlPanelTipoComponente()
        {
            InitializeComponent();
           
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Sesion.Instancia.SesionIniciada)
            {

               crearPanel();

            }
            base.OnLoad(e);
        }

        public void crearPanel()
        {
            DataTable tClaseComponente = new DataTable();
            tClaseComponente = mgr.GetClaseComponente();
            DataView dataViewHijos = new DataView(tClaseComponente);
            int iClaseComponente;
            int indiceInicio;

            for (int i = 0; i < navBarControl1.AvailableNavBarViews.Count; i++)
            {
                BaseViewInfoRegistrator vir = navBarControl1.AvailableNavBarViews[i] as BaseViewInfoRegistrator;
                if (vir.ViewName == "SkinNav:VS2010")
                {
                    navBarControl1.View = vir;
                }
            }
            
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                iClaseComponente=Convert.ToInt16(dataRowCurrent.Row["clase"].ToString());
                TreeView _arbolComponente = new TreeView();
                indiceInicio = iClaseComponente * 1000 ;
                CrearNodosDelPadre(indiceInicio,null,_arbolComponente);
              /// NavBarGroup _nuevoGrupo = new NavBarGroup();
               //prueba
                long ltipo=long.Parse(dataRowCurrent.Row["PK_COD_TIPO_COMPONENTE"].ToString());
                string sdescripcion = dataRowCurrent.Row["DESCRIPCION_TIPO"].ToString();
                    int iestado=int.Parse(dataRowCurrent.Row["ESTADO"].ToString());
                GrupoBarNav _nuevoGrupo = new GrupoBarNav(ltipo,sdescripcion, iestado);

                //
                _nuevoGrupo.Name = dataRowCurrent.Row["DESCRIPCION_TIPO"].ToString().Trim();
                _nuevoGrupo.Caption= dataRowCurrent.Row["DESCRIPCION_TIPO"].ToString().Trim();
                navBarControl1.Groups.Add(_nuevoGrupo);
                _nuevoGrupo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                _nuevoGrupo.ControlContainer.Controls.Add(_arbolComponente);
                _arbolComponente.BackColor = Color.Lavender;
                //prueba

              //  navBarControl1.ActiveGroupChanged += new NavBarGroupEventHandler(navBarControl1_GroupExpanded);
               // TreeView10.ForeColor = Color.SteelBlue;
                _arbolComponente.Dock = DockStyle.Fill;
                _arbolComponente.NodeMouseClick += new TreeNodeMouseClickEventHandler(_arbolComponente_NodeMouseClick);
                
            }

        }
        void EstablecerColorNodo(NodoArbol e) //TreeNodeMouseClickEventArgs
        {
            if (_nodoAnterior != null)
            {
                _nodoAnterior.BackColor = Color.Lavender;
                _nodoAnterior.ForeColor = Color.Black;
                
            }
            
            //e.Node.BackColor = Color.SteelBlue;
            //e.Node.ForeColor = Color.WhiteSmoke;
            e.BackColor = Color.SteelBlue;
            e.ForeColor = Color.WhiteSmoke;
            //_nodoAnterior = e.Node;
            _nodoAnterior = e;
        }

   
        void _arbolComponente_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string sDescripcion = (e.Node as NodoArbol).DescripcionTipo; 
            long codigo_tipo_componente = (e.Node as NodoArbol).TipoComponente;
            int estado_componente = (e.Node as NodoArbol).EstadoComponente;
            
            OnNodoClick(codigo_tipo_componente,estado_componente);
            EstablecerColorNodo(e.Node as NodoArbol);
        }

        private void OnNodoClick(long codigo_tipo_componente, int estadocomponente)
        {
            if (NodoClick != null )
            {
                NodoClick(this, new NodoClickEventArgs(codigo_tipo_componente, estadocomponente));
            }
        }
      

        private void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre, TreeView arbolV)
        {
            DataTable tClaseComponente = new DataTable();
            TreeView _treeView = arbolV;
            tClaseComponente = mgr.GetComponente();
            DataView dataViewHijos = new DataView(tClaseComponente);
            dataViewHijos.RowFilter = tClaseComponente.Columns["COD_TIPO_PADRE"].ColumnName + " = " + indicePadre;
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                NodoArbol nuevoNodo = new NodoArbol(Convert.ToInt64(dataRowCurrent["PK_COD_TIPO_COMPONENTE"].ToString()), dataRowCurrent["DESCRIPCION_TIPO"].ToString().Trim(), Convert.ToInt32(dataRowCurrent["ESTADO"].ToString()));
                nuevoNodo.Text = dataRowCurrent["DESCRIPCION_TIPO"].ToString().Trim();
                if (nodePadre == null)
                {
                    _treeView.Nodes.Add(nuevoNodo);
                }
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                CrearNodosDelPadre(Int32.Parse(dataRowCurrent["ORDEN"].ToString()), nuevoNodo,_treeView);
            }
        }
// es prueba
      
        private void OnGrupoClick(long codigo_tipo_componente, int estadocomponente)
        {
            if (GrupoClick != null)
            {
                GrupoClick(this, new NodoClickEventArgs(codigo_tipo_componente, estadocomponente));
            }
        }

        private void navBarControl1_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group != null)
            {

                long codigo_tipo_componente = (e.Group as GrupoBarNav).TipoComponente;
                int estado_componente = (e.Group as GrupoBarNav).EstadoComponente;

                OnGrupoClick(codigo_tipo_componente, estado_componente);
            }
        }
    }
    // hasta quí

    public class NodoClickEventArgs : EventArgs
    {
        private long _tipoComponente;
        private int _estadoComponente;
        public NodoClickEventArgs(long tipoC, int estadoC)
        {
            _tipoComponente = tipoC;
            _estadoComponente = estadoC;
        }
        public long TipoComponente
        { get { return _tipoComponente; } }

        public int EstadoComponente
        { get { return _estadoComponente; } }

    }
}
