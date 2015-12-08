using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloDemandas;
using CNDC.BLL;
using OraDalDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormAsignacionNodosSalidas : BaseForm
    {
        NodoDemanda _nodoDemanda;
        Persona _persona;
        DemandaSalidaMaestro _salidaMaestro;
        DemandaSalidaDetalle _salidaDetalle;
        NodoDemanda _nodoDemandaSalida;
        DatosDemandaNodo _datosDemandaNodo;
        PersonaNodos _personaNodo;
        int _idx;
        int _codigoTipoSalida = 0;
        public FormAsignacionNodosSalidas()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
            }
        }

        private void _btnAdicionarNodoSalida_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            FormNodosProyectos form = new FormNodosProyectos();
            form.SetParametros(null,true,_personaNodo);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _nodoDemandaSalida = form.GetNodo();
                DemandaSalidaMaestro salidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida(_personaNodo.PkPersonaNodo, _nodoDemandaSalida.PkNodoDemanda,_codigoTipoSalida);
                if (salidaMaestro == null)
                {
                    _chkListaNodosConexion.Enabled = true;
                }
                else
                {
                    _errorProvider.SetError(_txtSiglaNodoSalida,"Ya existe este nodo salida registrado.");
                   _chkListaNodosConexion.Enabled= false;
                }
                _txtNodoSalida.Text = _nodoDemandaSalida.NombreNodo;
                _txtSiglaNodoSalida.Text = _nodoDemandaSalida.SiglaNodo;
            }
        }

        public void SetParametros(Persona persona, NodoDemanda nodoDemanda, PersonaNodos personaNodo)
        {

            _personaNodo = personaNodo;
            _nodoDemanda = nodoDemanda;
            _persona = persona;
            _txtAgente.Text = _persona.Nombre;
            _txtNombre.Text = _nodoDemanda.NombreNodo;
            _txtSigla.Text = _nodoDemanda.SiglaNodo;
            MostrarNodosConectados();
            CargarNodosSalida();
            _rbtOPTGEN.Checked = true;
            DeshabilitarControles();
        }

        private void CargarNodosSalida()
        {
            _dgvNodosSalida.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosSalidaDeNodoDemanda(_personaNodo.PkPersonaNodo,_codigoTipoSalida);
            _dgvNodosSalida.Columns[0].Visible = false;
            _dgvNodosSalida.Columns[1].Width = 190;
        }

        private void MostrarNodosConectados()
        {
            _chkListaNodosConexion.Items.Clear();
            //List<PersonaNodos> listaPersonaNodosDemanda = OraDalPersonaNodosMgr.Instancia.GetPersonaNodosDemanda(_persona.PkCodPersona);
            List<NodoDemanda> listaNodosConectados = new List<NodoDemanda>();
            //foreach (PersonaNodos personaNodo in listaPersonaNodosDemanda)
            //{
                listaNodosConectados = OraDalNodoDemandaMgr.Instancia.GetNodosConectados(_personaNodo.FkPersona, _personaNodo.PkPersonaNodo);
            //}

            foreach (NodoDemanda item in listaNodosConectados)
            {
                _chkListaNodosConexion.Items.Add(item);
            }
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            _btnAdicionarNodoSalida.Enabled = true;
            _chkListaNodosConexion.Enabled = true;
            _gbxTipoSalida.Enabled = true;

            _tsbGuardar.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbEditar.Enabled = false;
            _tsbNuevo.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            _btnAdicionarNodoSalida.Enabled = false;
            _chkListaNodosConexion.Enabled = false;
            _gbxTipoSalida.Enabled = true;

            _tsbGuardar.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbEditar.Enabled = _dgvNodosSalida.RowCount == 0 ? false : true;
            _tsbNuevo.Enabled = true;
        }

        private void MostrarDatos()
        {
            _txtNodoSalida.Text = _nodoDemandaSalida.NombreNodo;
            _txtSiglaNodoSalida.Text = _nodoDemandaSalida.SiglaNodo;
            List<NodoDemanda> listaNodosAgrupados = OraDalDemandaSalidaDetalleMgr.Instancia.GetListaNodos(_salidaMaestro.PkDemandaSalidaMaestro);

            LimpiarSeleccionados();
            foreach (NodoDemanda nodo in listaNodosAgrupados)
            {
                for (int j = 0; j < _chkListaNodosConexion.Items.Count; j++)
                {
                    if (((NodoDemanda)_chkListaNodosConexion.Items[j]).PkNodoDemanda == nodo.PkNodoDemanda)
                    {
                        _chkListaNodosConexion.SetItemChecked(j, true);
                    }
                }
            }
        }

        private void LimpiarControles()
        {
            _txtNodoSalida.Text = string.Empty;
            _txtSiglaNodoSalida.Text = string.Empty;
            LimpiarSeleccionados();
        }

        private void LimpiarSeleccionados()
        {
            for (int i = 0; i < _chkListaNodosConexion.Items.Count; i++)
            {
                _chkListaNodosConexion.SetItemChecked(i, false);
            }
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            bool esNuevo = false;
            if (DatosValidos())
            {
                _salidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida(_personaNodo.PkPersonaNodo,_nodoDemandaSalida.PkNodoDemanda,_codigoTipoSalida);
                if (_salidaMaestro == null)
                {
                    esNuevo = true;
                    _salidaMaestro = new DemandaSalidaMaestro();
                    _salidaMaestro.EsNuevo = true;
                    
                }
                else
                {
                    OraDalDemandaSalidaDetalleMgr.Instancia.EliminarRegistro(_salidaMaestro.PkDemandaSalidaMaestro);
                }
                _salidaMaestro.FkNodoDemanda = _nodoDemanda.PkNodoDemanda;
                _salidaMaestro.FkNodoSalida = _nodoDemandaSalida.PkNodoDemanda;
                _salidaMaestro.FkPersonaNodo = _personaNodo.PkPersonaNodo;
                _salidaMaestro.DCodTipoNodoSalida = _codigoTipoSalida;
                OraDalDemandaSalidaMaestroMgr.Instancia.Guardar(_salidaMaestro);

                foreach (NodoDemanda nodo in _chkListaNodosConexion.CheckedItems)
                {
                    _salidaDetalle = new DemandaSalidaDetalle();
                    _salidaDetalle.EsNuevo = true;
                    _salidaDetalle.FkDemandaSalidaMaestro = _salidaMaestro.PkDemandaSalidaMaestro;
                    _salidaDetalle.FkNodoDemanda = nodo.PkNodoDemanda;
                    OraDalDemandaSalidaDetalleMgr.Instancia.Guardar(_salidaDetalle);
                }
                int idx = _idx;
                CargarNodosSalida();
                if (esNuevo)
                {
                    BindingContext[_dgvNodosSalida.DataSource].Position = _dgvNodosSalida.Rows.Count - 1;
                }
                else
                {
                    BindingContext[_dgvNodosSalida.DataSource].Position = idx;
                }
                DeshabilitarControles();
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (_txtNodoSalida.Text == string.Empty || _txtSiglaNodoSalida.Text == string.Empty)
            {
                res = false;
                _errorProvider.SetError(_txtSiglaNodoSalida, "Tiene que asignar un nodo salida.");
            }

            if (_chkListaNodosConexion.CheckedItems.Count==0)
            {
                res = false;
                _errorProvider.SetError(_txtSiglaNodoSalida, "Tiene que seleccionar nodos de conexión.");
            }
            

            return res;
        }

        private void _dgvNodosSalida_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (_dgvNodosSalida.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvNodosSalida.SelectedRows[0].DataBoundItem).Row;
                _idx = _dgvNodosSalida.SelectedCells[0].RowIndex;
                int pkNodoSalida = int.Parse(row[0].ToString());
                _nodoDemandaSalida = OraDalNodoDemandaMgr.Instancia.GetPorId<NodoDemanda>(pkNodoSalida, NodoDemanda.C_PK_NODO_DEMANDA);
                _nodoDemandaSalida.EsNuevo = false;
                _salidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida( _personaNodo.PkPersonaNodo,pkNodoSalida,_codigoTipoSalida);
                _salidaMaestro.EsNuevo = false;
                MostrarDatos();
            }
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            _nodoDemandaSalida = null;
            _salidaMaestro = null;
            _salidaDetalle = null;
            HabilitarControles();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            //this.Close();
            _txtAgente.Text = _persona.Nombre;
            _txtNombre.Text = _nodoDemanda.NombreNodo;
            _txtSigla.Text = _nodoDemanda.SiglaNodo;
            MostrarNodosConectados();
            CargarNodosSalida();
            DeshabilitarControles();
        }

        private void _rbtSDDP_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtSDDP.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.SDDP;
                CargarNodosSalida();
                _btnCrearAutamaticamente.Enabled = _dgvNodosSalida.RowCount == 0 &&  (_tsbEditar.Enabled==false || _tsbNuevo.Enabled==false)? true : false;
            }
        }

        private void _rbtOPTGEN_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtOPTGEN.Checked)
            {
                _btnCrearAutamaticamente.Enabled = false;
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.OPTGEN;
                CargarNodosSalida();
            }
        }

        private void _rbtNCP_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtNCP.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.NCP;
                CargarNodosSalida();
                _btnCrearAutamaticamente.Enabled = _dgvNodosSalida.RowCount == 0 && (_tsbEditar.Enabled == false || _tsbNuevo.Enabled == false) ? true : false;
            }
        }

        private void _btnCrearAutamaticamente_Click(object sender, EventArgs e)
        {
            if (_rbtNCP.Checked || _rbtSDDP.Checked)
            {
                if (_dgvNodosSalida.RowCount == 0)
                {
                    LimpiarSeleccionados();
                    foreach (NodoDemanda nodo in _chkListaNodosConexion.Items)
                    {
                        DemandaSalidaMaestro salidaMaestro = new DemandaSalidaMaestro();
                        salidaMaestro.EsNuevo = true;
                        salidaMaestro.DCodTipoNodoSalida = _rbtSDDP.Checked ? (int)D_COD_TIPO_NODO_SALIDA.SDDP : (int)D_COD_TIPO_NODO_SALIDA.NCP;
                        salidaMaestro.FkNodoDemanda = _nodoDemanda.PkNodoDemanda;
                        salidaMaestro.FkNodoSalida = nodo.PkNodoDemanda;
                        salidaMaestro.FkPersonaNodo = _personaNodo.PkPersonaNodo;
                        OraDalDemandaSalidaMaestroMgr.Instancia.Guardar(salidaMaestro);

                        DemandaSalidaDetalle salidaDetalle = new DemandaSalidaDetalle();
                        salidaDetalle.EsNuevo = true;
                        salidaDetalle.FkDemandaSalidaMaestro = salidaMaestro.PkDemandaSalidaMaestro;
                        salidaDetalle.FkNodoDemanda = nodo.PkNodoDemanda;
                        OraDalDemandaSalidaDetalleMgr.Instancia.Guardar(salidaDetalle);
                    }
                    _btnCrearAutamaticamente.Enabled = false;
                }
            }
            _codigoTipoSalida = _rbtSDDP.Checked ? (int)D_COD_TIPO_NODO_SALIDA.SDDP : (int)D_COD_TIPO_NODO_SALIDA.NCP;
            CargarNodosSalida();
            DeshabilitarControles();
        }

        private void _tsbEliminarSalida_Click(object sender, EventArgs e)
        {
            if (_dgvNodosSalida.RowCount > 0)
            {
                if (_nodoDemandaSalida != null)
                {
                     DialogResult res = MessageBox.Show("Está seguro de eliminar el proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                     if (res == DialogResult.Yes)
                     {
                         List<NodoDemanda> listaNodosAgrupados = OraDalDemandaSalidaDetalleMgr.Instancia.GetListaNodos(_salidaMaestro.PkDemandaSalidaMaestro);
                         if (_salidaMaestro != null)
                         {
                             OraDalDemandaSalidaDetalleMgr.Instancia.EliminarRegistro(_salidaMaestro.PkDemandaSalidaMaestro);
                             //OraDalDemandaSalidaMaestroMgr.Instancia.EliminarSalidaMaestro(_personaNodo.PkPersonaNodo, _nodoDemanda.PkNodoDemanda, _codigoTipoSalida);
                             OraDalDemandaSalidaMaestroMgr.Instancia.EliminarRegistroSalidaMaestro(_salidaMaestro.PkDemandaSalidaMaestro);

                             //eliminar tablas series 
                             OraDalDatosDemandaNodoMgr.Instancia.EliminarDatosDeNodoSalida(_personaNodo.PkPersonaNodo, _salidaMaestro.PkDemandaSalidaMaestro);
                             //eliminar tablas identificadores
                             OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatosDeNodoSalida(_personaNodo.PkPersonaNodo, _salidaMaestro.PkDemandaSalidaMaestro);
                             // eliminar datos: bloque
                             OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatosDeNodoSalida(_personaNodo.PkPersonaNodo, _salidaMaestro.PkDemandaSalidaMaestro);
                             CargarNodosSalida();
                             DeshabilitarControles();
                         }
                     }
                }
            }
        }

        private void _rbtPowerFactory_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtPowerFactory.Checked)
            {
                _btnCrearAutamaticamente.Enabled = false;
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.POWER_FACTORY;
                CargarNodosSalida();
            }
        }
    }
}
