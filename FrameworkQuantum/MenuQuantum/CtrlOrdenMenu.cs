using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using Oracle.DataAccess.Client;

namespace MenuQuantum
{
    public partial class CtrlOrdenMenu : UserControl
    {
        TreeNode _nodoSeleccionado = null;
        Dictionary<long, NodoMenu> dicNodos = new Dictionary<long, NodoMenu>();
        public CtrlOrdenMenu()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Sesion.Instancia.Conexion != null)
            {
                CargarMenu();
            }
        }

        private void CargarMenu()
        {
            DataTable tablaOpciones = Sesion.Instancia.Conexion.EjecutarSql("SELECT * FROM f_au_opciones ORDER BY orden_vista, num_opcion_madre");
            TreeNode menu = new TreeNode("Menú");
            int contadorOrdenVista = 0;
            foreach (DataRow r in tablaOpciones.Rows)
            {
                NodoMenu nodo = new NodoMenu(r);
                dicNodos[nodo.NumOpcion] = nodo;
                if (nodo.NumOpcionPadre == 0)
                {
                    menu.Nodes.Add(nodo);
                }
                else
                {
                    dicNodos[nodo.NumOpcionPadre].Nodes.Add(nodo);
                }
                if (nodo.OrdenVista == 0)
                {
                    contadorOrdenVista++;
                }
            }

            if (contadorOrdenVista > 0)
            {
                AsignarOrdenVista(menu, 0);
            }

            _tvwMenu.Nodes.Add(menu);
        }

        private void AsignarOrdenVista(TreeNode menu, long p)
        {
            int valor = 11;
            foreach (NodoMenu n in menu.Nodes)
            {
                n.OrdenVista = p * 100 + valor;
                AsignarOrdenVista(n, n.OrdenVista);
                valor++;
            }
        }

        private void _tvwMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _lbxOpciones.Items.Clear();
            _nodoSeleccionado = e.Node;
            foreach (NodoMenu n in e.Node.Nodes)
            {
                _lbxOpciones.Items.Add(n);
            }
        }

        private void _btnSubir_Click(object sender, EventArgs e)
        {
            if (_lbxOpciones.SelectedIndex > 0)
            {
                int idx = _lbxOpciones.SelectedIndex;
                object obj = _lbxOpciones.SelectedItem;
                _lbxOpciones.Items.RemoveAt(idx);
                _lbxOpciones.Items.Insert(idx - 1, obj);
                _lbxOpciones.SelectedIndex = idx - 1;
            }
        }

        private void _btnBajar_Click(object sender, EventArgs e)
        {
            if (_lbxOpciones.SelectedIndex < _lbxOpciones.Items.Count-1)
            {
                int idx = _lbxOpciones.SelectedIndex;
                object obj = _lbxOpciones.SelectedItem;
                _lbxOpciones.Items.RemoveAt(idx);
                _lbxOpciones.Items.Insert(idx + 1, obj);
                _lbxOpciones.SelectedIndex = idx + 1;
            }
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            if (_nodoSeleccionado == null)
            {
                return;
            }

            _nodoSeleccionado.Nodes.Clear();
            foreach (NodoMenu n in _lbxOpciones.Items)
            {
                _nodoSeleccionado.Nodes.Add(n);
            }

            if (_nodoSeleccionado is NodoMenu)
            {
                AsignarOrdenVista(_nodoSeleccionado, (_nodoSeleccionado as NodoMenu).OrdenVista);
            }
            else
            {
                AsignarOrdenVista(_nodoSeleccionado, 0);
            }
            GuardarEnBD();
        }

        private void GuardarEnBD()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (NodoMenu item in dicNodos.Values)
            {
                rows.Add(item.Row);
            }

            string sql =
            @"UPDATE f_au_opciones 
            SET orden_vista=:orden_vista 
            WHERE num_opcion=:num_opcion";

            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = rows.Count;
            cmd.Parameters.Add("num_opcion", OracleDbType.Int64, OraDalBaseMgr.GetArray(rows, "num_opcion"), ParameterDirection.Input);
            cmd.Parameters.Add("orden_vista", OracleDbType.Int64, OraDalBaseMgr.GetArray(rows, "orden_vista"), ParameterDirection.Input);

            Sesion.Instancia.Conexion.Actualizar(cmd);
        }
    }

    public class NodoMenu : TreeNode
    {
        private long _numOpcion;
        private long _numOpcionPadre;
        public long OrdenVista { get; set; }
        private DataRow _row;
        public NodoMenu(DataRow r)
        {
            _row = r;
            _numOpcion = ObjetoDeNegocio.GetValor<long>(r["num_opcion"]);
            _numOpcionPadre = ObjetoDeNegocio.GetValor<long>(r["num_opcion_madre"]);
            OrdenVista = ObjetoDeNegocio.GetValor<long>(r["orden_vista"]);
            Text = ObjetoDeNegocio.GetValor<string>(r["descripcion_opcion"]);
        }

        public long NumOpcion
        { get { return _numOpcion; } }

        public long NumOpcionPadre
        { get { return _numOpcionPadre; } }

        public override string ToString()
        {
            return Text;
        }

        public DataRow Row
        {
            get
            {
                _row["orden_vista"] = OrdenVista;
                return _row;
            }
        }
    }
}
