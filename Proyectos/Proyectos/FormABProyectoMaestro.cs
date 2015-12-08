using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using CNDC.BLL;
using OraDalProyectos;
using CNDC.ExceptionHandlerLib;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormABProyectoMaestro : BaseForm
    {
        ProyectoMaestro _proyectoMaestro;
        Proyecto _proyecto;
        DataTable _proyectosDeProyectoMaestro = new DataTable();
        public FormABProyectoMaestro()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoProyectos();
                CargarEtapasDelProyecto();
            }
        }

        private void CargarEtapasDelProyecto()
        {
            _cmbEtapa.DisplayMember = "Descripcion";
            _cmbEtapa.ValueMember = "CodDominio";
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbEtapa.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_ETAPA_PROYECTO);
        }

        private void CargarCmbTipoProyectos()
        {
            _cmbTipoProyecto.DisplayMember = "Descripcion";
            _cmbTipoProyecto.ValueMember = "CodDominio";
            _cmbTipoProyecto.DataSource = TipoProyectoUIMgr.Instancia.GetTipoProyectosHoja();
        }

        public void Editar(ProyectoMaestro proyectoMaestro)
        {
            _proyectoMaestro = proyectoMaestro;
            if (_proyectoMaestro.EsNuevo)
            {
                LimpiarDatos();
                _cmbTipoProyecto.Enabled = false;
                _cmbEtapa.Visible = true;
                _proyecto = new Proyecto();
                _proyecto.EsNuevo = true;
                _proyecto.FechaDeRegistro = DateTime.Now;
                
            }
            else
            {
                _proyectosDeProyectoMaestro = OraDalProyectoMgr.Instancia.GetProyectosPorPkMaestro(_proyectoMaestro.PkProyectoMaestro);
                CargarDatos();
                _cmbEtapa.Visible = false;
                _lblEtapa.Visible = false;
                if (_proyectosDeProyectoMaestro.Rows.Count == 0)
                {
                    _cmbTipoProyecto.Enabled = true;
                }
                else
                {
                    _cmbTipoProyecto.Enabled = false;
                }
            }
            _cmbTipoProyecto.SelectedValue = _proyectoMaestro.DTipoProyecto;
            ShowDialog();
        }

        private string GetPrefijoDeTipoDominio(int codDomino)
        {
            DefDominioMgr mgr = new DefDominioMgr();
            DefDominio dominio = mgr.GetDominioPorPkDominio(codDomino);
            string prefijo = string.Empty;
            if (dominio != null)
            {
                prefijo = dominio.Aux1_dom;
            }
            return prefijo;
        }
        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtNombre.Text = _proyectoMaestro.Nombre;
            _cmbTipoProyecto.SelectedValue = _proyectoMaestro.DTipoProyecto;
            _dtpFechaRegistro.Value = _proyectoMaestro.FechaDeRegistro;
        }

        private void LimpiarDatos()
        {
            _txtNombre.Text = string.Empty;
            _cmbTipoProyecto.SelectedIndex = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            string prefijoTipoProy= string.Empty;
            if (DatosValidos())
            {
                _proyectoMaestro.Nombre = _txtNombre.Text;
                _proyectoMaestro.DTipoProyecto = (long)_cmbTipoProyecto.SelectedValue;
                if (_proyectoMaestro.EsNuevo)
                {
                    _proyectoMaestro.FechaDeRegistro = _dtpFechaRegistro.Value;
                    prefijoTipoProy = GetPrefijoDeTipoDominio(int.Parse(_proyectoMaestro.DTipoProyecto.ToString()));
                    GeneradorCodigoProyectoMaestro.Instancia.AsignarCodigo(_proyectoMaestro, prefijoTipoProy);
                }
                
                OraDalProyectoMaestroMgr.Instancia.Guardar(_proyectoMaestro);
                
                if (_proyecto != null)
                {
                    _proyecto.FkProyectoMaestro = _proyectoMaestro.PkProyectoMaestro;
                    _proyecto.DCodEtapa = (long)_cmbEtapa.SelectedValue;
                }
                
                DialogResult = DialogResult.OK;
            }
        }

        public Proyecto GetProyecto()
        {
            return _proyecto;
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

            if (_txtNombre.Text == string.Empty)
            {
                res = false;
                _errorProvider.SetError(_txtNombre, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }
            else
            {
                if (OraDalProyectoMaestroMgr.Instancia.ExisteProyectoConEsteNombre(_txtNombre.Text.Trim()))
                {
                    res = false;
                    _errorProvider.SetError(_txtNombre, "Existe un proyecto maestro registrado con este nombre.");
                }
            }
            return res;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            if (_proyectoMaestro.EsNuevo)
            {
                LimpiarDatos();
            }
            else
            {
                CargarDatos();
            }
            DeshabilitarControles();
            DialogResult = DialogResult.Cancel;
        }

        private void DeshabilitarControles()
        {
            _txtNombre.Enabled = false;
            _cmbTipoProyecto.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _cmbTipoProyecto.Enabled = _proyectosDeProyectoMaestro.Rows.Count == 0 ? true : false;
        }

        private void HabilitarControles()
        {
            _txtNombre.Enabled = true;
            _cmbTipoProyecto.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }
    }
}
