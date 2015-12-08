using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using CNDC.UtilesComunes;

namespace Proyectos
{
    public partial class CtrlDatosTecnicosProysGeotermico : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoGeotermico _datoTecnicoGeotermico;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProysGeotermico()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTecnologia();
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtGeneracionMediaAnual.Enabled = false;
            _txtNroUnidades.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPoderCalorifico.Enabled = false;
            _txtPotenciaInstalada.Enabled = false;
            _txtProductividad.Enabled = false;
            _cmbTecnologia.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecnicoGeotermico.EsNuevo ? true : false;
            _txtGeneracionMediaAnual.Enabled = true;
            _txtNroUnidades.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPoderCalorifico.Enabled = true;
            _txtPotenciaInstalada.Enabled = true;
            _txtProductividad.Enabled = true;
            _cmbTecnologia.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        private void CargarCmbTecnologia()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTecnologia.DisplayMember = "Descripcion";
            _cmbTecnologia.ValueMember = "CodDominio";
            _cmbTecnologia.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TEC_GEOTERMICA);
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;

            LimpiarControles();
            _datoTecnicoGeotermico = OraDalDatoTecnicoGeotermicoMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_datoTecnicoGeotermico == null)
            {
                _datoTecnicoGeotermico = new DatoTecnicoGeotermico();
                _datoTecnicoGeotermico.EsNuevo = true;
            }
            else
            {
                _datoTecnicoGeotermico.EsNuevo = false;
                CargarDatos();
            }

            ActivarDesActivarControles();
        }

        private void ActivarDesActivarControles()
        {
            if (_esEditable)
            {
                HabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtGeneracionMediaAnual.Text = _datoTecnicoGeotermico.GeneracionMediaAnual.ToString();
            _txtNroUnidades.Text = _datoTecnicoGeotermico.NroUnidades.ToString("N0");
            _txtObservaciones.Text = _datoTecnicoGeotermico.Observaciones;
            _txtPoderCalorifico.Text = _datoTecnicoGeotermico.PoderCalorifico.ToString("N2");
            _txtPotenciaInstalada.Text = _datoTecnicoGeotermico.PotenciaInstalada.ToString("N2");
            _txtProductividad.Text = _datoTecnicoGeotermico.Productividad.ToString("N4");
            _cmbTecnologia.SelectedValue = _datoTecnicoGeotermico.DCodTecnologiaGeotermica;
            _dtpFechaRegistro.Value = _datoTecnicoGeotermico.FechaDeRegistro;
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtGeneracionMediaAnual.Value = 0;
            _txtNroUnidades.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPoderCalorifico.Value = 0;
            _txtPotenciaInstalada.Value = 0;
            _txtProductividad.Value = 0;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecnicoGeotermico.DCodTecnologiaGeotermica = (Int64) _cmbTecnologia.SelectedValue;
                _datoTecnicoGeotermico.FkProyecto = _proyecto.PkProyecto;
                _datoTecnicoGeotermico.GeneracionMediaAnual = _txtGeneracionMediaAnual.ValDouble;
                _datoTecnicoGeotermico.NroUnidades = _txtNroUnidades.ValorLong;
                _datoTecnicoGeotermico.Observaciones = _txtObservaciones.Text;
                _datoTecnicoGeotermico.PoderCalorifico = _txtPoderCalorifico.ValDouble;
                _datoTecnicoGeotermico.PotenciaInstalada = _txtPotenciaInstalada.ValDouble;
                _datoTecnicoGeotermico.Productividad = _txtProductividad.ValDouble;
                if (_datoTecnicoGeotermico.EsNuevo)
                {
                    _datoTecnicoGeotermico.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoGeotermicoMgr.Instancia.Guardar(_datoTecnicoGeotermico);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtNroUnidades.ValorLong<0)
            {
                _errorProvider.SetError(_txtNroUnidades, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtPotenciaInstalada.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPotenciaInstalada, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtPoderCalorifico.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPoderCalorifico, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtGeneracionMediaAnual.ValDouble < 0)
            {
                _errorProvider.SetError(_txtGeneracionMediaAnual, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtProductividad.ValDouble < 0)
            {
                _errorProvider.SetError(_txtProductividad, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtPotenciaInstalada.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecnicoGeotermico.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
        }

        public void SetEstadoToolBar(bool estado)
        {
            if (estado)
            {
                _toolStrip.Enabled = true;
            }
            else
            {
                _toolStrip.Enabled = false;
            }
        }
    }
}
