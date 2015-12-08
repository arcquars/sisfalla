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

namespace Proyectos
{
    public partial class CtrlDatosTecnicosProysLineaTransmision : CtrlDatosBase, IControles
    {
        Proyecto _proyecto;
        bool _esEditable = false;
        DataTable tabla = new DataTable();
        DatoTecnicoLineaTransmision _datoTecLineaTransmision;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProysLineaTransmision()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoEstructuraSoporte();
                CargarCmbConfiguracionBahias();
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void CargarCmbConfiguracionBahias()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbConfBahiaDestino.DisplayMember = "Descripcion";
            _cmbConfBahiaDestino.ValueMember = "CodDominio";
            _cmbConfBahiaDestino.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_CONF_BAHIA);

            _cmbConfBahiaOrigen.DisplayMember = "Descripcion";
            _cmbConfBahiaOrigen.ValueMember = "CodDominio";
            _cmbConfBahiaOrigen.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_CONF_BAHIA);
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }
        
        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCalibreTipoConductor.Enabled = false;
            _txtCapacidadTransmision.Enabled = false;
            _txtLongitudLinea.Enabled = false;
            _txtNivelTension.Enabled = false;
            _txtObservacion.ReadOnly = true;
            _txtReactancia.Enabled = false;
            _txtResistencia.Enabled = false;
            _txtSubestacionDestino.Enabled = false;
            _txtSubestacionOrigen.Enabled = false;
            _txtSusceptancia.Enabled = false;
            _cmbConfBahiaDestino.Enabled = false;
            _cmbConfBahiaOrigen.Enabled = false;
            _cmbTipoSoporte.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _txtNodoDestino.Enabled = false;
            _txtNodoOrigen.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecLineaTransmision.EsNuevo ? true : false;
            _txtCalibreTipoConductor.Enabled = true;
            _txtCapacidadTransmision.Enabled = true;
            _txtLongitudLinea.Enabled = true;
            _txtNivelTension.Enabled = true;
            _txtObservacion.ReadOnly = false;
            _txtReactancia.Enabled = true;
            _txtResistencia.Enabled = true;
            _txtSubestacionDestino.Enabled = true;
            _txtSubestacionOrigen.Enabled = true;
            _txtSusceptancia.Enabled = true;
            _cmbConfBahiaDestino.Enabled = true;
            _cmbConfBahiaOrigen.Enabled = true;
            _cmbTipoSoporte.Enabled = true;
            _txtNodoOrigen.Enabled = true;
            _txtNodoDestino.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void CargarCmbTipoEstructuraSoporte()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoSoporte.DisplayMember = "Descripcion";
            _cmbTipoSoporte.ValueMember = "CodDominio";
            _cmbTipoSoporte.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TIPO_ESTRUC_SOPORTE);
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;

            LimpiarControles();
            _datoTecLineaTransmision = OraDalDatoTecnicoLineaTransmisionMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_datoTecLineaTransmision == null)
            {
                _datoTecLineaTransmision = new DatoTecnicoLineaTransmision();
                _datoTecLineaTransmision.EsNuevo = true;
            }
            else
            {
                _datoTecLineaTransmision.EsNuevo = false;
                CargarDatos();
            }
            List<LocalizacionProyectosTransmision> lista = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_proyecto.PkProyecto);
            if (lista.Count == 2)
            {
                _txtSubestacionOrigen.Text = lista[0].Subestacion;
                _txtSubestacionDestino.Text = lista[1].Subestacion;
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
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtCalibreTipoConductor.Text = string.Empty;
            _txtCapacidadTransmision.Value = 0;
            _txtLongitudLinea.Value = 0;
            _txtNivelTension.Value = 0;
            _txtObservacion.Text = string.Empty;
            _txtQvacio.Value = 0;
            _txtR1.Value = 0;
            _txtReactancia.Value = 0;
            _txtResistencia.Value = 0;
            _txtSubestacionDestino.Text = string.Empty;
            _txtSubestacionOrigen.Text = string.Empty;
            _txtSusceptancia.Value = 0;
            _txtX1.Value = 0;
            _txtNodoDestino.Text = string.Empty;
            _txtNodoOrigen.Text = string.Empty;
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _dtpFechaRegistro.Value = _datoTecLineaTransmision.FechaRegistro;
            _txtCalibreTipoConductor.Text = _datoTecLineaTransmision.CalibreTipoConductor;
            _txtCapacidadTransmision.Text = _datoTecLineaTransmision.CapacidadTransmision.ToString();
            _txtLongitudLinea.Text = _datoTecLineaTransmision.LongitudLinea.ToString();
            _txtNivelTension.Text = _datoTecLineaTransmision.NivelTension.ToString();
            _txtObservacion.Text = _datoTecLineaTransmision.Observacion;
            _txtReactancia.Text = _datoTecLineaTransmision.Reactancia.ToString();
            _txtResistencia.Text = _datoTecLineaTransmision.Resistencia.ToString();
            _txtSubestacionDestino.Text = string.Empty;
            _txtSubestacionOrigen.Text = string.Empty;
            _txtSusceptancia.Text = _datoTecLineaTransmision.Susceptancia.ToString();
            _cmbConfBahiaDestino.SelectedValue = _datoTecLineaTransmision.DCodConfBahiaDestino;
            _cmbConfBahiaOrigen.SelectedValue = _datoTecLineaTransmision.DCodConfBahiaOrigen;
            _cmbTipoSoporte.SelectedValue = _datoTecLineaTransmision.DCodTipoEstructuraSoporte;
            _txtNodoOrigen.Text = _datoTecLineaTransmision.NodoOrigen;
            _txtNodoDestino.Text = _datoTecLineaTransmision.NodoDestino;
            CalcularQVacio();
            CalcularR1();
            CalcularX1();
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecLineaTransmision.CalibreTipoConductor = _txtCalibreTipoConductor.Text;
                _datoTecLineaTransmision.CapacidadTransmision = _txtCapacidadTransmision.ValDouble;
                _datoTecLineaTransmision.DCodConfBahiaDestino = (long)_cmbConfBahiaDestino.SelectedValue;
                _datoTecLineaTransmision.DCodConfBahiaOrigen = (long) _cmbConfBahiaOrigen.SelectedValue;
                _datoTecLineaTransmision.DCodTipoEstructuraSoporte = (long)_cmbTipoSoporte.SelectedValue;
                _datoTecLineaTransmision.FkLocProyTransDestino = 1;
                _datoTecLineaTransmision.FkLocProyTransOrigen = 1;
                _datoTecLineaTransmision.FkProyecto = _proyecto.PkProyecto;
                _datoTecLineaTransmision.LongitudLinea = _txtLongitudLinea.ValDouble;
                _datoTecLineaTransmision.NivelTension = _txtNivelTension.ValDouble;
                _datoTecLineaTransmision.Observacion = _txtObservacion.Text;
                _datoTecLineaTransmision.Resistencia = _txtResistencia.ValDouble;
                _datoTecLineaTransmision.Reactancia = _txtReactancia.ValDouble;
                _datoTecLineaTransmision.Susceptancia = _txtSusceptancia.ValDouble;
                _datoTecLineaTransmision.NodoDestino = _txtNodoDestino.Text;
                _datoTecLineaTransmision.NodoOrigen = _txtNodoOrigen.Text;
                if (_datoTecLineaTransmision.EsNuevo)
                {
                    _datoTecLineaTransmision.FechaRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoLineaTransmisionMgr.Instancia.Guardar(_datoTecLineaTransmision);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

            if (_txtNivelTension.ValDouble <= 0)
            {
                _errorProvider.SetError(_txtNivelTension, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCapacidadTransmision.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidadTransmision, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtLongitudLinea.ValDouble <= 0)
            {
                _errorProvider.SetError(_txtLongitudLinea, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtNivelTension.ValDouble < 0)
            {
                _errorProvider.SetError(_txtNivelTension, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtReactancia.ValDouble < 0)
            {
                _errorProvider.SetError(_txtReactancia, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtResistencia.ValDouble < 0)
            {
                _errorProvider.SetError(_txtResistencia, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtSusceptancia.ValDouble < 0)
            {
                _errorProvider.SetError(_txtSusceptancia, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            return res;
        }

        private void _txtResistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
            }
        }

        private void CalcularR1()
        {
            double r1 = 0;
            if (_txtNivelTension.ValDouble > 0 && _txtResistencia.ValDouble > 0 && _txtLongitudLinea.ValDouble > 0)
            {
                r1 = ((_txtResistencia.ValDouble * _txtLongitudLinea.ValDouble) / ((_txtNivelTension.ValDouble * _txtNivelTension.ValDouble) / 100)) * 100;
                //r1 = Math.Round(r1, 4);
            }
            _txtR1.Text = r1.ToString("N4");
        }

        private void _txtReactancia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularX1();
            }
        }

        private void CalcularX1()
        {
            double x1 = 0;
            if (_txtNivelTension.ValDouble > 0 && _txtReactancia.ValDouble > 0 && _txtLongitudLinea.ValDouble > 0)
            {
                x1 = ((_txtReactancia.ValDouble * _txtLongitudLinea.ValDouble) / ((_txtNivelTension.ValDouble * _txtNivelTension.ValDouble) / 100)) * 100;
                //x1 = Math.Round(x1, 4);
            }
            _txtX1.Text = x1.ToString("N4");
        }

        private void _txtSusceptancia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularQVacio();
            }
        }

        private void CalcularQVacio()
        {
            double q = 0;
            if (_txtNivelTension.ValDouble > 0 && _txtSusceptancia.ValDouble > 0 && _txtLongitudLinea.ValDouble > 0)
            {
                q = ((_txtSusceptancia.ValDouble * ((_txtNivelTension.ValDouble * _txtNivelTension.ValDouble)/100)) * (_txtLongitudLinea.ValDouble) *100)/1000000;
               // q = Math.Round(q, 4);
            }
            _txtQvacio.Text = q.ToString("N4");
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtNivelTension.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecLineaTransmision.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
        }

        private void _txtResistencia_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
        }

        private void _txtReactancia_Validating(object sender, CancelEventArgs e)
        {
            CalcularX1();
        }

        private void _txtSusceptancia_Validating(object sender, CancelEventArgs e)
        {
            CalcularQVacio();
        }

        private void _txtNivelTension_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtLongitudLinea_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtNivelTension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
                CalcularX1();
                CalcularQVacio();
            }
        }

        private void _txtLongitudLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
                CalcularX1();
                CalcularQVacio();
            }
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
