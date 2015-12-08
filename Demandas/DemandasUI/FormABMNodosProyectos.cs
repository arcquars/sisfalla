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

namespace DemandasUI
{
    public partial class FormABMNodosProyectos : Form,IFuncionalidad
    {
        NodoProyectos _nodo;
        int _idx = 0;
        bool _esNuevo = true;
        public FormABMNodosProyectos()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoNodo();
                CargarDatos();
            }
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
            _nodo = new NodoProyectos();
            _nodo.EsNuevo = true;
        }

        private void DeshabilitarControles()
        {
            _dtpFechaIngreso.Enabled = false;
            _dtpFechaSalida.Enabled = false;
            _cmbTipoNodo.Enabled = false;
            _txtDescripcion.Enabled = false;
            _txtNombre.Enabled = false;
            _txtSigla.Enabled = false;
            _txtTension.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            _dtpFechaIngreso.Enabled = true;
            _dtpFechaSalida.Enabled = true;
            _cmbTipoNodo.Enabled = true;
            _txtDescripcion.Enabled = true;
            _txtNombre.Enabled = true;
            _txtSigla.Enabled = true;
            _txtTension.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void LimpiarControles()
        {
            _txtDescripcion.Text = string.Empty;
            _txtNombre.Text = string.Empty;
            _txtSigla.Text = string.Empty;
            _txtTension.Text = ".00";
            _dtpFechaIngreso.Value = DateTime.Now;
            _dtpFechaSalida.Value = DateTime.Now;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _esNuevo = _nodo.EsNuevo;
                _nodo.DCodTipoNodo = (long)_cmbTipoNodo.SelectedValue;
                _nodo.DCodArea = 1;
                _nodo.DCodEstado = "1";
                _nodo.DescripcionNodo = _txtDescripcion.Text;
                _nodo.FechaIngreso = _dtpFechaIngreso.Value;
                _nodo.FechaSalida = _dtpFechaSalida.Value;
                _nodo.NivelTension = (float)_txtTension.ValDouble;
                _nodo.NombreNodo = _txtNombre.Text;
                _nodo.SiglaNodo = _txtSigla.Text;
                OraDalNodoProyectosMgr.Instancia.Guardar(_nodo);
                CargarDatos();
                if (_esNuevo)
                {
                    BindingContext[_dgvProyectos.DataSource].Position = _dgvProyectos.Rows.Count - 1;
                }
                //else
                //{
                //    BindingContext[_dgvProyectos.DataSource].Position = _idx;
                //}
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
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }


        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDatos()
        {
            _dgvProyectos.DataSource =OraDalNodoProyectosMgr.Instancia.GetNodos();
            _dgvProyectos.Columns[1].Width = 320;
            _dgvProyectos.Columns[4].Width = 250;
            _dgvProyectos.Columns[0].Visible = false;
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (_dgvProyectos.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvProyectos.SelectedRows[0].DataBoundItem).Row;
                int pkNodo = int.Parse(row[0].ToString());
                _nodo = OraDalNodoProyectosMgr.Instancia.GetPorId<NodoProyectos>(pkNodo, NodoProyectos.C_PK_NODO_PROYECTOS);
                _nodo.EsNuevo = false;
                MostrarDatos();
            }
        }

        private void MostrarDatos()
        {
            _txtDescripcion.Text = _nodo.DescripcionNodo;
            _txtNombre.Text = _nodo.NombreNodo;
            _txtSigla.Text = _nodo.SiglaNodo;
            _txtTension.Text = _nodo.NivelTension.ToString();
            _cmbTipoNodo.SelectedValue = _nodo.DCodTipoNodo;
            _dtpFechaIngreso.Value = _nodo.FechaIngreso;
            _dtpFechaSalida.Value = _nodo.FechaSalida;
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _nodo = new NodoProyectos();
            _nodo.EsNuevo = true;
            LimpiarControles();
            HabilitarControles();
            _txtNombre.Focus();
        }

        #region Miembros de IFuncionalidad

        public Dictionary<string, string> Parametros { get; set; }

        public void Ejecutar()
        {
            DeshabilitarControles();
            Show();
        }

        #endregion
    }
}
