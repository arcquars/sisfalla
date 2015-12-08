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
using CNDC.ExceptionHandlerLib;
using CNDC.UtilesComunes;

namespace Proyectos
{
    public partial class CtrlDatosTecnicosProysTermicoAGasTurbinas : CtrlDatosBase, IControles
    {
        Proyecto _proyecto;
        bool _esEditable = false;
        DatoTecnicoTurbina _datoTecnicoTurbina;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProysTermicoAGasTurbinas()
        {
            InitializeComponent();
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCapacidadISO.Enabled = false;
            _txtCapacidadMaxEnSitio.Enabled = false;
            _txtCapacidadMediaEnSitio.Enabled = false;
            _txtISO100.Enabled = false;
            _txtISO50.Enabled = false;
            _txtISO75.Enabled = false;
            _txtModeloTurbina.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtTemMax100.Enabled = false;
            _txtTempISO.Enabled = false;
            _txtTempMax75.Enabled = false;
            _txtTempMaxEnSitio.Enabled = false;
            _txtTempMaxima50.Enabled = false;
            _txtTempMedia100.Enabled = false;
            _txtTempMedia50.Enabled = false;
            _txtTempMedia75.Enabled = false;
            _txtTempMediaEnSitio.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecnicoTurbina.EsNuevo ? true : false;
            _txtCapacidadISO.Enabled = true;
            _txtCapacidadMaxEnSitio.Enabled = true;
            _txtCapacidadMediaEnSitio.Enabled = true;
            _txtISO100.Enabled = true;
            _txtISO50.Enabled = true;
            _txtISO75.Enabled = true;
            _txtModeloTurbina.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtTemMax100.Enabled = true;
            _txtTempISO.Enabled = true;
            _txtTempMax75.Enabled = true;
            _txtTempMaxEnSitio.Enabled = true;
            _txtTempMaxima50.Enabled = true;
            _txtTempMedia100.Enabled = true;
            _txtTempMedia50.Enabled = true;
            _txtTempMedia75.Enabled = true;
            _txtTempMediaEnSitio.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;

            LimpiarControles();
            _datoTecnicoTurbina = OraDalDatoTecnicoTurbinaMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            LocalizacionProyectosGeneracion local = OraDalLocalizacionProyectosGeneracionMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            if (local == null)
            {
                _txtAltitud.Value = 0;
            }
            else
            {
                _txtAltitud.ValDouble = local.Altitud;
            }

            if (_datoTecnicoTurbina == null)
            {
                _datoTecnicoTurbina = new DatoTecnicoTurbina();
                _datoTecnicoTurbina.EsNuevo = true;
            }
            else
            {
                _datoTecnicoTurbina.EsNuevo = false;
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

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtCapacidadISO.Value = 0;
            _txtCapacidadMaxEnSitio.Value = 0;
            _txtCapacidadMediaEnSitio.Value = 0;
            _txtISO100.Value = 0;
            _txtISO50.Value = 0;
            _txtISO75.Value = 0;
            _txtModeloTurbina.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
            _txtTemMax100.Value = 0;
            _txtTempISO.Value = 15;
            _txtTempMax75.Value = 0;
            _txtTempMaxEnSitio.Value = 0;
            _txtTempMaxima50.Value = 0;
            _txtTempMedia100.Value = 0;
            _txtTempMedia50.Value = 0;
            _txtTempMedia75.Value = 0;
            _txtTempMediaEnSitio.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void CargarDatos()
        {
            LocalizacionProyectosGeneracion local = OraDalLocalizacionProyectosGeneracionMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            if (local == null)
            {
                _txtAltitud.Value = 0;
            }
            else
            {
                _txtAltitud.ValDouble = local.Altitud;
            }
            _dtpFechaRegistro.Enabled = false;
            _dtpFechaRegistro.Value = _datoTecnicoTurbina.FechaDeRegistro;
            _txtCapacidadISO.Text = _datoTecnicoTurbina.CapacidadInstaladaIso.ToString("N2");
            _txtCapacidadMaxEnSitio.Text = _datoTecnicoTurbina.CapacidadInstMaxSitio.ToString("N2");
            _txtCapacidadMediaEnSitio.Text = _datoTecnicoTurbina.CapacidadInstMediaSitio.ToString("N2");
            _txtISO100.Text = _datoTecnicoTurbina.HrIso100.ToString("N0");
            _txtISO50.Text = _datoTecnicoTurbina.HrIso50.ToString("N0");
            _txtISO75.Text = _datoTecnicoTurbina.HrIso75.ToString("N0");
            _txtModeloTurbina.Text = _datoTecnicoTurbina.ModeloTurbina;
            _txtObservaciones.Text = _datoTecnicoTurbina.Observaciones;
            _txtTemMax100.Text = _datoTecnicoTurbina.HrTemMax100.ToString("N0");
            _txtTempMax75.Text = _datoTecnicoTurbina.HrTemMax75.ToString("N0");
            _txtTempMaxima50.Text = _datoTecnicoTurbina.HrTemMax50.ToString("N0");
            _txtTempISO.Text = _datoTecnicoTurbina.TempIso.ToString("N2");
            _txtTempMaxEnSitio.Text = _datoTecnicoTurbina.TempMaxSitio.ToString("N2");
            _txtTempMedia100.Text = _datoTecnicoTurbina.HrTemMedia100.ToString("N0");
            _txtTempMedia50.Text = _datoTecnicoTurbina.HrTemMedia50.ToString("N0");
            _txtTempMedia75.Text = _datoTecnicoTurbina.HrTemMedia75.ToString("N0");
            _txtTempMediaEnSitio.Text = _datoTecnicoTurbina.TempMediaSitio.ToString("N2");
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecnicoTurbina.CapacidadInstaladaIso = _txtCapacidadISO.ValDouble;
                _datoTecnicoTurbina.CapacidadInstMaxSitio = _txtCapacidadMaxEnSitio.ValDouble;
                _datoTecnicoTurbina.CapacidadInstMediaSitio = _txtCapacidadMediaEnSitio.ValDouble;
                _datoTecnicoTurbina.TempIso = _txtTempISO.ValDouble;
                _datoTecnicoTurbina.TempMaxSitio = _txtTempMaxEnSitio.ValDouble;
                _datoTecnicoTurbina.TempMediaSitio = _txtTempMediaEnSitio.ValDouble;
                _datoTecnicoTurbina.FkProyecto = _proyecto.PkProyecto;
                _datoTecnicoTurbina.HrIso100 = _txtISO100.ValorLong;
                _datoTecnicoTurbina.HrIso50 = _txtISO50.ValorLong;
                _datoTecnicoTurbina.HrIso75 = _txtISO75.ValorLong;
                _datoTecnicoTurbina.HrTemMax100 = _txtTemMax100.ValorLong;
                _datoTecnicoTurbina.HrTemMax50 = _txtTempMaxima50.ValorLong;
                _datoTecnicoTurbina.HrTemMax75 = _txtTempMax75.ValorLong;
                _datoTecnicoTurbina.HrTemMedia100 = _txtTempMedia100.ValorLong;
                _datoTecnicoTurbina.HrTemMedia50 = _txtTempMedia50.ValorLong;
                _datoTecnicoTurbina.HrTemMedia75 = _txtTempMedia75.ValorLong;
                _datoTecnicoTurbina.ModeloTurbina = _txtModeloTurbina.Text;
                _datoTecnicoTurbina.Observaciones = _txtObservaciones.Text;
                if (_datoTecnicoTurbina.EsNuevo)
                {
                    _datoTecnicoTurbina.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoTurbinaMgr.Instancia.Guardar(_datoTecnicoTurbina);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtCapacidadISO.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidadISO, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCapacidadMaxEnSitio.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidadMaxEnSitio, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCapacidadMediaEnSitio.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidadMediaEnSitio, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtISO100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtISO100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtISO50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtISO50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtISO75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtISO75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }


            if (_txtTemMax100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTemMax100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempISO.ValDouble<0)
            {
                _errorProvider.SetError(_txtTempISO, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMax75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTempMax75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMaxEnSitio.ValDouble < 0)
            {
                _errorProvider.SetError(_txtTempMaxEnSitio, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMaxima50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTempMaxima50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMedia100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTempMedia100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMedia50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTempMedia50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTempMedia75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtTempMedia75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;

            }

            if (_txtTempMediaEnSitio.ValDouble < 0)
            {
                _errorProvider.SetError(_txtTempMediaEnSitio, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtModeloTurbina.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecnicoTurbina.EsNuevo)
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
