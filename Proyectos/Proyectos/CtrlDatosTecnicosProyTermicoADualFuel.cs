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
    public partial class CtrlDatosTecnicosProyTermicoADualFuel : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoDualFuel _datoTecnicoDualFuel;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProyTermicoADualFuel()
        {
            InitializeComponent();
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCapacidadInstalada.Enabled = false;
            _txtHRDiesel100.Enabled = false;
            _txtHRDiesel50.Enabled = false;
            _txtHRDiesel75.Enabled = false;
            _txtHRGasNatural100.Enabled = false;
            _txtHRGasNatural50.Enabled = false;
            _txtHRGasNatural75.Enabled = false;
            _txtModelo.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _dtpFechaRegistro.Enabled = _datoTecnicoDualFuel.EsNuevo?true: false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = true;
            _txtCapacidadInstalada.Enabled = true;
            _txtHRDiesel100.Enabled = true;
            _txtHRDiesel50.Enabled = true;
            _txtHRDiesel75.Enabled = true;
            _txtHRGasNatural100.Enabled = true;
            _txtHRGasNatural50.Enabled = true;
            _txtHRGasNatural75.Enabled = true;
            _txtModelo.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;

            LimpiarControles();
            _datoTecnicoDualFuel = OraDalDatoTecnicoDualFuelMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_datoTecnicoDualFuel == null)
            {
                _datoTecnicoDualFuel = new DatoTecnicoDualFuel();
                _datoTecnicoDualFuel.EsNuevo = true;
            }
            else
            {
                _datoTecnicoDualFuel.EsNuevo = false;
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
            _dtpFechaRegistro.Value = _datoTecnicoDualFuel.FechaDeRegistro;
            _txtCapacidadInstalada.Text = _datoTecnicoDualFuel.CapacidadInstalada.ToString("N2");
            _txtHRDiesel100.Text = _datoTecnicoDualFuel.HeatRateDiesel100.ToString("N0");
            _txtHRDiesel50.Text = _datoTecnicoDualFuel.HeatRateDiesel50.ToString("N0");
            _txtHRDiesel75.Text = _datoTecnicoDualFuel.HeatRateDiesel75.ToString("N0");
            _txtHRGasNatural100.Text = _datoTecnicoDualFuel.HeatRateGasNatural100.ToString("N0");
            _txtHRGasNatural50.Text = _datoTecnicoDualFuel.HeatRateGasNatural50.ToString("N0");
            _txtHRGasNatural75.Text = _datoTecnicoDualFuel.HeatRateGasNatural75.ToString("N0");
            _txtModelo.Text = _datoTecnicoDualFuel.Modelo;
            _txtObservaciones.Text = _datoTecnicoDualFuel.Observaciones;
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtCapacidadInstalada.Value = 0;
            _txtHRDiesel50.Value = 0;
            _txtHRDiesel75.Value = 0;
            _txtHRDiesel100.Value = 0;
            _txtHRGasNatural100.Value = 0;
            _txtHRGasNatural50.Value = 0;
            _txtHRGasNatural75.Value = 0;
            _txtModelo.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            
            if (DatosValidos())
            {
                _datoTecnicoDualFuel.CapacidadInstalada = _txtCapacidadInstalada.ValDouble;
                _datoTecnicoDualFuel.FkProyecto = _proyecto.PkProyecto;
                _datoTecnicoDualFuel.HeatRateDiesel100 = _txtHRDiesel100.ValorLong;
                _datoTecnicoDualFuel.HeatRateDiesel50 = _txtHRDiesel50.ValorLong;
                _datoTecnicoDualFuel.HeatRateDiesel75 = _txtHRDiesel75.ValorLong;
                _datoTecnicoDualFuel.HeatRateGasNatural100 = _txtHRGasNatural100.ValorLong;
                _datoTecnicoDualFuel.HeatRateGasNatural50 = _txtHRGasNatural50.ValorLong;
                _datoTecnicoDualFuel.HeatRateGasNatural75 = _txtHRGasNatural75.ValorLong;
                _datoTecnicoDualFuel.Modelo = _txtModelo.Text;
                _datoTecnicoDualFuel.Observaciones = _txtObservaciones.Text;
                if (_datoTecnicoDualFuel.EsNuevo)
                {
                    _datoTecnicoDualFuel.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoDualFuelMgr.Instancia.Guardar(_datoTecnicoDualFuel);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtCapacidadInstalada.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidadInstalada, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRDiesel100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRDiesel100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRDiesel50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRDiesel50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRDiesel75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRDiesel75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRGasNatural100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRGasNatural100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRGasNatural50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRGasNatural50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHRGasNatural75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHRGasNatural75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtModelo.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecnicoDualFuel.EsNuevo)
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
