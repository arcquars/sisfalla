using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using MenuQuantum;
using ModeloDemandas;
using OraDalDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormAsignarNodosDeConexion : BaseForm, IFuncionalidad
    {
        Persona _persona;
        NodosReales _nodoReal;
        NodoDemanda _nodoDemanda;
        NodoDemanda _nodoConexion;
        int _idxNodoReal = 0;
        int _idxNodoConexion = 0;
        int _idxNodoDemanda = 0;
        int _codTipoAgente = 0;
        Dictionary<long, List<NodoDemanda>> _dicNodosAgentes = new Dictionary<long, List<NodoDemanda>>();
        List<NodoDemanda> _listaNodosConexion = new List<NodoDemanda>();
        List<NodoDemanda> _listaNodosDemanda = new List<NodoDemanda>();
        List<NodoDemanda> _listaNodosDeConexionABorrar = new List<NodoDemanda>();
        List<NodoDemanda> _listaNodosDemandaABorrar = new List<NodoDemanda>();

        public FormAsignarNodosDeConexion()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarAgentes();
            }
        }

        private void CargarAgentes()
        {
            _dgvAgentes.DataSource = OraDalPersonaMgr.Instancia.GetTablaAgentesDeTipoDemandas(_codTipoAgente);
            _dgvAgentes.Columns[0].Visible = false;
            _dgvAgentes.Columns[1].Width = 260;
        }

        #region Miembros de IFuncionalidad

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            _rbtDistribucion.Checked = true;
            DeshabilitarControles();
            ShowDialog();
        }

        #endregion

        private void _tsbAdicionar_Click(object sender, EventArgs e)
        {
            //FormNodosReales form = new FormNodosReales();
            //DialogResult res = form.ShowDialog();
            //if (res == DialogResult.OK)
            //{
            //    _nodoReal = form.GetNodo();
            //    if (!ExisteEnListaNodosReales(_nodoReal))
            //    {
            //        _dicNodosAgentesDistribucion[_nodoReal.PkCodNodo] = new List<NodoDemanda>();
            //        _lbxNodosReales.Items.Add(_nodoReal);
            //        _lbxNodosReales.SelectedIndex = _lbxNodosReales.Items.Count - 1;
            //    }
            //    else
            //    {
            //        _lbxNodosReales.SelectedIndex = _idxNodoReal;
            //    }
            //}
        }


        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            _listaNodosDemandaABorrar.Clear();
            _listaNodosDeConexionABorrar.Clear();
            HabilitarControles();
            _errorProvider.Clear();
        }

        private void HabilitarControles()
        {
            _lbxNodosDemanda.Enabled = true;
            _lbxNodosConectados.Enabled = true;
            _tsbNodosHijosProyectos.Enabled = true;
            _tsbNodosDemanda.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            _lbxNodosDemanda.Enabled = false;
            _lbxNodosConectados.Enabled = false;
            _tsbNodosHijosProyectos.Enabled = false;
            _tsbNodosDemanda.Enabled = false;
            _tsbNodosHijosProyectos.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                GuardarNodos();
                DeshabilitarControles();
            }
        }

        private void GuardarNodos()
        {
            //OraDalPersonaNodosMgr.Instancia.EliminarDatos(_persona.PkCodPersona);
            foreach (long pkNodoDeConexion in _dicNodosAgentes.Keys)
            {
                PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, pkNodoDeConexion);
                if (personaNodo == null)
                {
                    personaNodo = new PersonaNodos();
                    personaNodo.EsNuevo = true;
                    personaNodo.FkNodoReal = 0;
                    personaNodo.FkNodoProyecto = pkNodoDeConexion;
                    personaNodo.FkPersona = _persona.PkCodPersona;
                    personaNodo.PkPersonaNodoPadre = 0;
                    OraDalPersonaNodosMgr.Instancia.Guardar(personaNodo);
                }
                else
                {
                    personaNodo.EsNuevo = false;
                }
                
                List<NodoDemanda> listaNodos = _dicNodosAgentes[pkNodoDeConexion];
                foreach (NodoDemanda item in listaNodos)
                {
                    PersonaNodos personaNodoHijo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoHijo(_persona.PkCodPersona, item.PkNodoDemanda);
                    if (personaNodoHijo == null)
                    {
                        personaNodoHijo = new PersonaNodos();
                        personaNodoHijo.EsNuevo = true;
                        personaNodoHijo.FkNodoReal = 0;
                        personaNodoHijo.FkNodoProyecto = item.PkNodoDemanda;
                        personaNodoHijo.FkPersona = _persona.PkCodPersona;
                        personaNodoHijo.PkPersonaNodoPadre = personaNodo.PkPersonaNodo;
                        OraDalPersonaNodosMgr.Instancia.Guardar(personaNodoHijo);
                    }
                    else
                    {
                        personaNodoHijo.EsNuevo = false;
                    }
                }
            }
        }

        private bool DatosValidos()
        {
            return true;
        }

        private void _rbtDistribucion_CheckedChanged(object sender, EventArgs e)
        {
            _listaNodosDemandaABorrar.Clear();
            _listaNodosDeConexionABorrar.Clear();
            if (_rbtDistribucion.Checked)
            {
                _errorProvider.Clear();
                _lbxNodosConectados.Items.Clear();
                _lbxNodosConectados.Items.Clear();
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.DISTRIBUCIÓN;
                _gbxNodosConectados.Visible = true;
                _gbxNodosDemanda.Visible = true;
                CargarAgentes();
            }
        }

        private void _rbtSisAislados_CheckedChanged(object sender, EventArgs e)
        {
            _listaNodosDemandaABorrar.Clear();
            _listaNodosDeConexionABorrar.Clear();
            if (_rbtSisAislados.Checked)
            {
                _errorProvider.Clear();
                _lbxNodosConectados.Items.Clear();
                _lbxNodosConectados.Items.Clear();
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.SISTEMA_AISLADO;
                _gbxNodosConectados.Visible = true;
                _gbxNodosDemanda.Visible = true;
                CargarAgentes();
            }
        }

        private void _rbtProyectos_CheckedChanged(object sender, EventArgs e)
        {
            _listaNodosDemandaABorrar.Clear();
            _listaNodosDeConexionABorrar.Clear();
            if (_rbtProyectos.Checked)
            {
                _errorProvider.Clear();
                _lbxNodosConectados.Items.Clear();
                _lbxNodosConectados.Items.Clear();
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.PROYECTO;
                _gbxNodosConectados.Visible = true;
                _gbxNodosDemanda.Visible = true;
                CargarAgentes();
            } 
        }

        private void _tsbAdicionarNodoConexion_Click(object sender, EventArgs e)
        {
            if (_lbxNodosDemanda.Items.Count > 0)
            {
                FormNodosDemanda form = new FormNodosDemanda();
                form.SetParametros(_nodoDemanda,false,null);
                DialogResult res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    _listaNodosDemanda = form.GetLista();
                    foreach (NodoDemanda nodoDemanda in _listaNodosDemanda)
                    {
                        if (!ExisteEnListaNodosDeConexion(nodoDemanda))
                        {
                            _dicNodosAgentes[_nodoDemanda.PkNodoDemanda].Add(nodoDemanda);
                            _lbxNodosConectados.Items.Add(nodoDemanda);
                            _lbxNodosConectados.SelectedIndex = _lbxNodosConectados.Items.Count - 1;
                        }
                        else
                        {
                            _lbxNodosConectados.SelectedIndex = _idxNodoConexion;
                        }
                    }
                }
            }
        }

        private bool ExisteEnListaNodosDeDemanda(NodoDemanda nodo)
        {
            bool res = false;
            int i = 0;
            foreach (NodoDemanda n in _lbxNodosDemanda.Items)
            {
                if (n.PkNodoDemanda == nodo.PkNodoDemanda)
                {
                    _idxNodoDemanda = i;
                    res = true;
                    break;
                }
                i++;
            }
            return res;
        }

        private bool ExisteEnListaNodosDeConexion(NodoDemanda nodo)
        {
            bool res = false;
            int i = 0;
            foreach (NodoDemanda n in _lbxNodosConectados.Items)
            {
                if (n.PkNodoDemanda == nodo.PkNodoDemanda)
                {
                    _idxNodoConexion = i;
                    res = true;
                    break;
                }
                i++;
            }
            return res;
        }

        private void CargarNodosHijosDeNodoReal()
        {
            if (_rbtDistribucion.Checked)
            {
                //_lbxNodosConectados.Items.Clear();
                ////_nodoReal = (NodosReales)_lbxNodosReales.SelectedItem;
                //List<NodoDemanda> lista = _dicNodosAgentesDistribucion[_nodoReal.PkCodNodo];
                //foreach (NodoDemanda item in lista)
                //{
                //    _lbxNodosConectados.Items.Add(item);
                //}
            }
            else if (_rbtSisAislados.Checked)
            {
               // _nodoReal = (NodosReales)_lbxNodosReales.SelectedItem;
            }
        }

        private void _tsbAdicionarNodoProy_Click(object sender, EventArgs e)
        {
            if (_persona!=null)
            {
                FormNodosDemanda form = new FormNodosDemanda();
                form.SetParametros(null,false,null);
                DialogResult res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    //_nodoDemanda = form.GetNodo();
                    _listaNodosConexion = form.GetLista();
                    foreach (NodoDemanda  nodoConexion  in _listaNodosConexion)
                    {
                        if (!ExisteEnListaNodosDeDemanda(nodoConexion))
                        {
                            _dicNodosAgentes[nodoConexion.PkNodoDemanda] = new List<NodoDemanda>();
                            _lbxNodosDemanda.Items.Add(nodoConexion);
                            _lbxNodosDemanda.SelectedIndex = _lbxNodosDemanda.Items.Count - 1;
                        }
                        else
                        {
                            _lbxNodosDemanda.SelectedIndex = _idxNodoDemanda;
                        }
                    }
                }               
            }
        }

        private bool ExisteEnListaNodosProyectos(NodoDemanda nodoProy)
        {
            bool res = false;
            int i = 0;
            foreach (NodoDemanda nodo in _lbxNodosDemanda.Items)
            {
                if (nodo.PkNodoDemanda == nodoProy.PkNodoDemanda)
                {
                    _idxNodoDemanda = i;
                    res = true;
                    break;
                }
                i++;
            }
            return res;
        }

        private void _dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            _lbxNodosConectados.Items.Clear();
            _lbxNodosDemanda.Items.Clear();
            _errorProvider.Clear();

            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvAgentes.SelectedRows[0].DataBoundItem).Row;
                int pkPersona = int.Parse(row[0].ToString());
                _persona = OraDalPersonaMgr.Instancia.GetPorId<Persona>(pkPersona, Persona.C_PK_COD_PERSONA);
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            _lbxNodosDemanda.Items.Clear();
            _dicNodosAgentes.Clear();
            List<NodoDemanda> listaNodosDemanda = OraDalNodoDemandaMgr.Instancia.GetNodosDemanda(_persona.PkCodPersona);
            List<PersonaNodos> listaPersonaNodosDemanda = OraDalPersonaNodosMgr.Instancia.GetPersonaNodosDemanda(_persona.PkCodPersona);
            List<NodoDemanda> listaNodosConectados = new List<NodoDemanda>();
            foreach (PersonaNodos personaNodo in listaPersonaNodosDemanda)
            {
                listaNodosConectados = OraDalNodoDemandaMgr.Instancia.GetNodosConectados(_persona.PkCodPersona,personaNodo.PkPersonaNodo );
                _dicNodosAgentes[personaNodo.FkNodoProyecto] = listaNodosConectados;
            }

            foreach (NodoDemanda nodo in listaNodosDemanda)
            {
                _lbxNodosDemanda.Items.Add(nodo);
            }

            foreach (NodoDemanda np in listaNodosConectados)
            {
                _lbxNodosConectados.Items.Add(np);
            }

            if (_lbxNodosDemanda.Items.Count > 0)
            {
                _lbxNodosDemanda.SelectedIndex = 0;
            }
        }

        private void _tsbEliminarNodosProy_Click(object sender, EventArgs e)
        {
            if (_lbxNodosDemanda.SelectedItem != null)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar el proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {

                    PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, _nodoDemanda.PkNodoDemanda);
                    NodoDemanda nodo = (NodoDemanda)_lbxNodosDemanda.SelectedItem;
                    _lbxNodosDemanda.Items.Remove(_lbxNodosDemanda.SelectedItem);
                    _lbxNodosDemanda.SelectedIndex = _lbxNodosDemanda.Items.Count > 0 ? 0 : -1;
                    List<NodoDemanda> lista = _dicNodosAgentes[nodo.PkNodoDemanda];
                    foreach (NodoDemanda n in lista)
                    {
                        OraDalPersonaNodosMgr.Instancia.EliminarRegistroHijo(_persona.PkCodPersona, n.PkNodoDemanda, nodo.PkNodoDemanda);
                    }
                    _dicNodosAgentes.Remove(nodo.PkNodoDemanda);

                    if (personaNodo != null)
                    {
                        OraDalDemandaSalidaMaestroMgr.Instancia.EliminarSalidaMaestro(personaNodo.PkPersonaNodo, nodo.PkNodoDemanda);
                        
                        //eliminar tablas series 
                        OraDalDatosDemandaNodoMgr.Instancia.EliminarTablaDatosPersonaNodo(personaNodo.PkPersonaNodo);
                        //eliminar tablas identificadores
                        OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatos(personaNodo.PkPersonaNodo);
                        // eliminar datos: bloque
                        OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatos(personaNodo.PkPersonaNodo);
                    }
                    OraDalPersonaNodosMgr.Instancia.EliminarRegistroPadre(_persona.PkCodPersona, nodo.PkNodoDemanda);

                    DeshabilitarControles();
                }
            }
        }


        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _tsbEliminarNodoHijoProy_Click(object sender, EventArgs e)
        {
            if (_lbxNodosConectados.SelectedItem != null)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar el proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    NodoDemanda nodo = (NodoDemanda)_lbxNodosConectados.SelectedItem;
                    _listaNodosDemandaABorrar.Add(nodo);
                    _lbxNodosConectados.Items.Remove(_lbxNodosConectados.SelectedItem);
                    //_lbxNodosConectados.Items.Clear();
                    _lbxNodosConectados.SelectedIndex = _lbxNodosConectados.Items.Count > 0 ? 0 : -1;
                    OraDalPersonaNodosMgr.Instancia.EliminarRegistroHijo(_persona.PkCodPersona, nodo.PkNodoDemanda,_nodoDemanda.PkNodoDemanda);
                    EliminarDeDiccionario(nodo);
                    DeshabilitarControles();
                }
            }
        }

        private void EliminarDeDiccionario(NodoDemanda nodo)
        {
            List<NodoDemanda> lista = _dicNodosAgentes[_nodoDemanda.PkNodoDemanda];
            foreach (NodoDemanda n in lista)
            {
                if (n.PkNodoDemanda == nodo.PkNodoDemanda)
                {
                    _dicNodosAgentes[_nodoDemanda.PkNodoDemanda].Remove(n);
                    break;
                }
            }
        }

        private void _dgvAgentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _rbtNoRegulados_CheckedChanged(object sender, EventArgs e)
        {
            _listaNodosDemandaABorrar.Clear();
            _listaNodosDeConexionABorrar.Clear();
            if (_rbtNoRegulados.Checked)
            {
                _errorProvider.Clear();
                _lbxNodosConectados.Items.Clear();
                _lbxNodosConectados.Items.Clear();
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.CONSUMIDOR_NO_REGULADO;
                _gbxNodosConectados.Visible = true;
                _gbxNodosDemanda.Visible = true;
                CargarAgentes();
            }
        }

        private void FormAsignarNodosDeConexion_Load(object sender, EventArgs e)
        {

        }

        private void _lbxNodosDemanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            _lbxNodosConectados.Items.Clear();
            if (_lbxNodosDemanda.SelectedItem != null)
            {
                _nodoDemanda = (NodoDemanda)_lbxNodosDemanda.SelectedItem;
                List<NodoDemanda> lista = _dicNodosAgentes[_nodoDemanda.PkNodoDemanda];
                foreach (NodoDemanda item in lista)
                {
                    _lbxNodosConectados.Items.Add(item);
                }
            }
        }

        private void _lbxNodosConectados_SelectedIndexChanged(object sender, EventArgs e)
        {
            _errorProvider.Clear();
        }

        private void _tsbAsignarNodosSalida_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            FormAsignacionNodosSalidas form = new FormAsignacionNodosSalidas();
            if (_nodoDemanda == null)
            {
                MessageBox.Show("No existen nodos registrados.");
            }
            else
            {
                PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, _nodoDemanda.PkNodoDemanda);
                if (personaNodo == null)
                {
                    _errorProvider.SetError(_lbxNodosDemanda, "No se guardo el nodo seleccionado.");
                }
                else
                {
                    if (_lbxNodosConectados.Items.Count == 0)
                    {
                        _errorProvider.SetError(_lbxNodosConectados, "No existen nodos conectados al nodo demanda.");
                    }
                    else
                    {
                        form.SetParametros(_persona, _nodoDemanda, personaNodo);
                        DialogResult res = form.ShowDialog();

                    }
                }
            }
        }

        private void _gbxNodosConectados_Enter(object sender, EventArgs e)
        {

        }
    }
}
