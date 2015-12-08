using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.UtilesComunes;
using CNDC.ExceptionHandlerLib;
using Oracle.DataAccess.Client;
using ModeloDemandas;
using MenuQuantum;
using OraDalDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormABMNodosDemanda : BaseForm,IFuncionalidad
    {
        NodoDemanda _nodo;
        int _idx = 0;
        bool _esNuevo = true;
        NodoDemanda _nodoConexion;
        public FormABMNodosDemanda()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoNodo();
                CargarCmdArea();
                CargarDatos();
            }
        }

        private void CargarCmdArea()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbArea.DisplayMember = "Descripcion";
            _cmbArea.ValueMember = "CodDominio";
            _cmbArea.DataSource = mgr.GetListaDominio("D_COD_AREA_NODO");
        }

        private void CargarCmbTipoNodo()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoNodo.DisplayMember = "Descripcion";
            _cmbTipoNodo.ValueMember = "CodDominio";
            _cmbTipoNodo.DataSource = mgr.GetListaDominio("D_COD_TIPO_NODO");
        }

        public void RegistrarEntidadResponsable()
        {
            _esNuevo = true;
            _txtNombre.Focus();
            DeshabilitarControles();
            LimpiarControles();
            _nodo = new NodoDemanda();
            _nodo.EsNuevo = true;
        }

        private void DeshabilitarControles()
        {
            _btnAdicionarNodo.Enabled = false;
            _btnEliminarNodoConexion.Enabled = false;
            _txtCriterioDeAsignacion.Enabled = false;
            _dtpFechaIngreso.Enabled = false;
            _dtpFechaSalida.Enabled = false;
            _cmbTipoNodo.Enabled = false;
            _txtDescripcion.Enabled = false;
            _txtNombre.Enabled = false;
            _txtSigla.Enabled = false;
            _txtTension.Enabled = false;
            _txtNroDeNodoDeConexion.Enabled = false;
            _cmbArea.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            _btnAdicionarNodo.Enabled = true;
            _btnEliminarNodoConexion.Enabled = true;
            _txtCriterioDeAsignacion.Enabled = true;
            _dtpFechaIngreso.Enabled = true;
            _dtpFechaSalida.Enabled = true;
            _cmbTipoNodo.Enabled = true;
            _txtDescripcion.Enabled = true;
            _txtNombre.Enabled = true;
            _txtSigla.Enabled = true;
            _txtTension.Enabled = true;
            _txtNroDeNodoDeConexion.Enabled = true;
            _cmbArea.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void LimpiarControles()
        {
            _txtNroDeNodoDeConexion.Text = string.Empty;
            _txtSiglaNodoDeConexion.Text = string.Empty;
            _txtCriterioDeAsignacion.Text = string.Empty;
            _txtDescripcion.Text = string.Empty;
            _txtNroDeNodoDeConexion.Text = string.Empty;
            _txtNombre.Text = string.Empty;
            _txtSigla.Text = string.Empty;
            _txtTension.Text = "0";
            _dtpFechaIngreso.Value = DateTime.Now;
            _dtpFechaSalida.Value = DateTime.Now;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _esNuevo = _nodo.EsNuevo;
                _nodo.DCodTipoNodo = (long)_cmbTipoNodo.SelectedValue;
                _nodo.DCodArea = (long)_cmbArea.SelectedValue;
                _nodo.DCodEstado = "1";
                _nodo.DescripcionNodo = _txtDescripcion.Text;
                _nodo.FechaIngreso = _dtpFechaIngreso.Value;
                _nodo.FechaSalida = _dtpFechaSalida.Value;
                _nodo.NivelTension = (int)_txtTension.ValorInt;
                _nodo.NombreNodo = _txtNombre.Text;
                _nodo.SiglaNodo = _txtSigla.Text;
                _nodo.CriterioAgregacion = _txtCriterioDeAsignacion.Text;
                _nodo.FkNodoDemandaConexion = _nodoConexion == null ? 0 : _nodoConexion.PkNodoDemanda;
                OraDalNodoDemandaMgr.Instancia.Guardar(_nodo);
                int idx = _idx;
                CargarDatos();
                if (_esNuevo)
                {
                    BindingContext[_dgvNodos.DataSource].Position = _dgvNodos.Rows.Count - 1;
                }
                else
                {
                    BindingContext[_dgvNodos.DataSource].Position = idx;
                }
                DeshabilitarControles();
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (Utiles.EsCadenaVacia(_txtNombre.Text))
            {
                res = false;
                _errorProvider.SetError(_txtNombre, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }

            if (Utiles.EsCadenaVacia(_txtSigla.Text))
            {
                res = false;
                _errorProvider.SetError(_txtSigla, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }
            
            long pkNodoDemanda= _nodo.EsNuevo? 0: _nodo.PkNodoDemanda;
           /* if (OraDalNodoDemandaMgr.Instancia.ExisteNodo(NodoDemanda.C_NOMBRE_NODO,_txtNombre.Text,pkNodoDemanda,(long)_cmbTipoNodo.SelectedValue))
            {
                res = false;
                _errorProvider.SetError(_txtNombre, "Existe un registro con este nombre.");
            }*/

            if (OraDalNodoDemandaMgr.Instancia.ExisteNodo(NodoDemanda.C_SIGLA_NODO, _txtSigla.Text, pkNodoDemanda,(long)_cmbTipoNodo.SelectedValue))
            {
                res = false;
                _errorProvider.SetError(_txtSigla, "Existe un registro con esta sigla.");
            }

            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }


        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            _dgvNodos.DataSource =OraDalNodoDemandaMgr.Instancia.GetNodos((long) _cmbTipoNodo.SelectedValue);
            _dgvNodos.Columns[1].Width = 320;
            _dgvNodos.Columns[4].Width = 250;
            _dgvNodos.Columns[0].Visible = false;
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (_dgvNodos.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvNodos.SelectedRows[0].DataBoundItem).Row;
                int pkNodo = int.Parse(row[0].ToString());
                _idx = _dgvNodos.SelectedCells[0].RowIndex;
                _nodo = OraDalNodoDemandaMgr.Instancia.GetPorId<NodoDemanda>(pkNodo, NodoDemanda.C_PK_NODO_DEMANDA);
                _nodo.EsNuevo = false;
                MostrarDatos();
            }
            DeshabilitarControles();
        }

        private void MostrarDatos()
        {
            _nodoConexion = _nodo.FkNodoDemandaConexion == 0 ? null : OraDalNodoDemandaMgr.Instancia.GetPorId<NodoDemanda>(_nodo.FkNodoDemandaConexion, NodoDemanda.C_PK_NODO_DEMANDA);
            _txtNroDeNodoDeConexion.Text = _nodoConexion == null ? string.Empty : _nodoConexion.NombreNodo;
            _txtSiglaNodoDeConexion.Text = _nodoConexion == null ? string.Empty : _nodoConexion.SiglaNodo;
            _txtCriterioDeAsignacion.Text = _nodo.CriterioAgregacion;
            _txtDescripcion.Text = _nodo.DescripcionNodo;
            _txtNombre.Text = _nodo.NombreNodo;
            _txtSigla.Text = _nodo.SiglaNodo;
            _txtTension.Text = _nodo.NivelTension.ToString("N0");
            _cmbTipoNodo.SelectedValue = _nodo.DCodTipoNodo;
            _cmbArea.SelectedValue = _nodo.DCodArea;
            _dtpFechaIngreso.Value = _nodo.FechaIngreso;
            _dtpFechaSalida.Value = _nodo.FechaSalida;
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _nodo = new NodoDemanda();
            _nodo.EsNuevo = true;
            LimpiarControles();
            HabilitarControles();
            _txtNombre.Focus();
        }

        #region Miembros de IFuncionalidad

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            DeshabilitarControles();
            ShowDialog();
        }

        #endregion

        private void _btnAdicionarNodo_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            FormNodosProyectos form = new FormNodosProyectos();
            form.SetParametros(null, false, null);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _nodoConexion = form.GetNodo();
                _txtNroDeNodoDeConexion.Text = _nodoConexion.NombreNodo;
                _txtSiglaNodoDeConexion.Text = _nodoConexion.SiglaNodo;
            }
        }

        private void _btnEliminarNodoConexion_Click(object sender, EventArgs e)
        {
            _nodoConexion = null;
            _txtNroDeNodoDeConexion.Text = string.Empty;
            _txtSiglaNodoDeConexion.Text = string.Empty;
        }

        private void _cmbTipoNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
            HabilitarControles();
        }

        private void _tsbEliminar_Click(object sender, EventArgs e)
        {
            if (_nodo != null && _dgvNodos.Rows.Count>0)
            {
                  DialogResult res = MessageBox.Show("Está seguro de eliminar el nodo?", "Confirmación", MessageBoxButtons.YesNo);
                  if (res == DialogResult.Yes)
                  {
                      OraDalNodoDemandaMgr.Instancia.DarDeBajaNodoDemanda(_nodo.PkNodoDemanda);
                      CargarDatos();
                  }
            }
        }
    }
}
