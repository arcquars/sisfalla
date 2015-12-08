using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using Controles;
using MenuQuantum;

namespace AdmRolesUI
{
    public partial class FormOpciones : BaseForm
    {
        Rol _rol;
        BindingList<Modulo> _modulosDisponibles;
        BindingList<Modulo> _modulosAsignados;
        Modulo _moduloSeleccionado = null;
        List<long> _opcionesAsignadasOriginal = new List<long>();
        Dictionary<long, NodoMenu> _nodos = new Dictionary<long, NodoMenu>();

        public FormOpciones()
        {
            InitializeComponent();
            _modulosDisponibles = new BindingList<Modulo>();
            _modulosAsignados = new BindingList<Modulo>();
        }

        public void Editar(Rol rolSeleccionado)
        {
            _rol = rolSeleccionado;
            ShowDialog();
        }

        private void FormOpciones_Load(object sender, EventArgs e)
        {
            _modulosDisponibles = OraDalModuloMgr.Instancia.GetModulosNOAsignados(_rol);
            _modulosAsignados = OraDalModuloMgr.Instancia.GetModulosAsignados(_rol);

            Enlazar(_lbxModulosDisp, _modulosDisponibles);
            Enlazar(_lbxModulosAsig, _modulosAsignados);
        }

        private void Enlazar(CNDCListBox lbx, BindingList<Modulo> lista)
        {
            lbx.DisplayMember = "Nombre";
            lbx.ValueMember = "PkCodModulo";
            lbx.DataSource = lista;
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            if (_lbxModulosDisp.SelectedValue != null)
            {
                long idModulo = (long)_lbxModulosDisp.SelectedValue;
                if (OraDalModuloMgr.Instancia.AsignarModulo(idModulo, _rol))
                {
                    Modulo m = (Modulo)_lbxModulosDisp.SelectedItem;
                    _modulosDisponibles.Remove(m);
                    _modulosAsignados.Add(m);
                }
            }
        }

        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            if (_lbxModulosAsig.SelectedValue != null)
            {
                long idModulo = (long)_lbxModulosAsig.SelectedValue;
                if (OraDalModuloMgr.Instancia.QuitarModulo(idModulo, _rol))
                {
                    Modulo m = (Modulo)_lbxModulosAsig.SelectedItem;
                    _modulosAsignados.Remove(m);
                    _modulosDisponibles.Add(m);
                }
            }
        }

        private void _lbxModulosAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lbxModulosAsig.SelectedValue != null)
            {
                _moduloSeleccionado = (Modulo)_lbxModulosAsig.SelectedItem;
                CargarOpciones();
            }
        }

        private void CargarOpciones()
        {
            _tvwOpciones.Nodes.Clear();
            DataTable tablaOpcionesModulo = OraDalF_AU_OpcionMgr.Instancia.GetOpcionesDeModulo(_moduloSeleccionado);
            _opcionesAsignadasOriginal = OraDalF_AU_OpcionMgr.Instancia.GetOpcionesAsignadasAlRolPorModulo(_rol, _moduloSeleccionado);
            _nodos = new Dictionary<long, NodoMenu>();

            foreach (DataRow r in tablaOpcionesModulo.Rows)
            {
                NodoMenu n = new NodoMenu(r);
                _nodos.Add(n.NumOpcion, n);
                n.Checked = _opcionesAsignadasOriginal.Contains(n.NumOpcion);

                if (n.NumOpcionPadre == 0)
                {
                    _tvwOpciones.Nodes.Add(n);
                }
                else
                {
                    _nodos[n.NumOpcionPadre].Nodes.Add(n);
                }
            }
        }

        private void _btnExpandir_Click(object sender, EventArgs e)
        {
            _tvwOpciones.ExpandAll();
        }

        bool bloqueado = false;
        private void _tvwOpciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (bloqueado)
            {
                return;
            }
            bloqueado = true;
            if (e.Node.Checked)
            {
                TreeNode n = e.Node.Parent;
                while (n != null && !n.Checked)
                {
                    n.Checked = true;
                    n = n.Parent;
                }
            }
            else
            {
                TreeNode parent = e.Node.Parent;
                bool continuar = true;
                while (continuar && parent != null)
                {
                    bool sw = true;
                    foreach (TreeNode n in parent.Nodes)
                    {
                        if (n.Checked)
                        {
                            sw = false;
                        }
                    }

                    if (sw)
                    {
                        parent.Checked = false;
                    }
                    else
                    {
                        continuar = false;
                    }
                    parent = parent.Parent;
                }
            }
            SetChecked(e.Node.Nodes, e.Node.Checked);
            bloqueado = false;
        }

        private void SetChecked(TreeNodeCollection nodos, bool p)
        {
            foreach (TreeNode n in nodos)
            {
                n.Checked = p;
                SetChecked(n.Nodes, p);
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            if (HayModificacionesEnOpciones())
            {
                if (EstaSeguro("Esta seguro de candelar las modificaciones ?"))
                {
                    CargarOpciones();
                }
            }
        }

        private bool HayModificacionesEnOpciones()
        {
            return true;
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            List<long> opcionesAsignadasActual = GetOpcionesSeleccionadas();
            opcionesAsignadasActual.Sort();
            _opcionesAsignadasOriginal.Sort();
            if (!SonIguales(_opcionesAsignadasOriginal, opcionesAsignadasActual))
            {
                List<long> opcionesNuevas = Diferencia(opcionesAsignadasActual, _opcionesAsignadasOriginal);
                List<long> opcionesEliminadas = Diferencia(_opcionesAsignadasOriginal, opcionesAsignadasActual);
                OraDalF_AU_OpcionMgr.Instancia.AsignacioOpciones(_rol, opcionesNuevas);
                OraDalF_AU_OpcionMgr.Instancia.QuitarOpciones(_rol, opcionesEliminadas);
            }
        }

        private List<long> Diferencia(List<long> a, List<long> b)
        {
            List<long> resultado = new List<long>();
            foreach (long idOp in a)
            {
                if (!b.Contains(idOp))
                {
                    resultado.Add(idOp);
                }
            }
            return resultado;
        }

        private bool SonIguales(List<long> a, List<long> b)
        {
            bool resultado = true;
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != b[i])
                    {
                        resultado = false;
                        break;
                    }
                }
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        private List<long> GetOpcionesSeleccionadas()
        {
            List<long> resultado = new List<long>();
            foreach (KeyValuePair<long, NodoMenu> n in _nodos)
            {
                if (n.Value.Checked)
                {
                    resultado.Add(n.Key);
                }
            }
            return resultado;
        }

        private void _btnSubir_Click(object sender, EventArgs e)
        {
            if (_lbxModulosAsig.SelectedIndex > 0)
            {
                int idx = _lbxModulosAsig.SelectedIndex;
                Modulo m = _modulosAsignados[idx];
                _modulosAsignados.Remove(m);
                _modulosAsignados.Insert(idx - 1, m);
                _lbxModulosAsig.SelectedIndex = idx - 1;
            }
        }

        private void _btnBajar_Click(object sender, EventArgs e)
        {
            if (_lbxModulosAsig.SelectedIndex >= 0 && _lbxModulosAsig.SelectedIndex < _modulosAsignados.Count - 1)
            {
                int idx = _lbxModulosAsig.SelectedIndex;
                Modulo m = _modulosAsignados[idx];
                _modulosAsignados.Remove(m);
                _modulosAsignados.Insert(idx + 1, m);
                _lbxModulosAsig.SelectedIndex = idx + 1;
            }
        }

        private void _btnGuardarPrioridad_Click(object sender, EventArgs e)
        {
            OraDalModuloMgr.Instancia.PonerPrioridad(_modulosAsignados, _rol);
        }
    }
}
