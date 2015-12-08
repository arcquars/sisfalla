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
    public partial class CtrlDatostecnicosProysTermicoADiesel : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoMotorDiesel _datoTecnicoMotorDiesel;
        bool _seGuardo = true;

        public CtrlDatostecnicosProysTermicoADiesel()
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
            _txtCapacidadInstalada.Enabled = false;
            _txtHR100.Enabled = false;
            _txtHR50.Enabled = false;
            _txtHR75.Enabled = false;
            _txtModelo.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecnicoMotorDiesel.EsNuevo ? true : false;
            _txtCapacidadInstalada.Enabled = true;
            _txtHR100.Enabled = true;
            _txtHR50.Enabled = true;
            _txtHR75.Enabled = true;
            _txtModelo.Enabled = true;
            _txtObservaciones.ReadOnly = false;
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
            _datoTecnicoMotorDiesel = OraDalDatoTecnicoMotorDieselMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_datoTecnicoMotorDiesel == null)
            {
                _datoTecnicoMotorDiesel = new DatoTecnicoMotorDiesel();
                _datoTecnicoMotorDiesel.EsNuevo = true;
            }
            else
            {
                _datoTecnicoMotorDiesel.EsNuevo = false;
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
            _txtCapacidadInstalada.Value = 0;
            _txtHR100.Value = 0;
            _txtHR50.Value = 0;
            _txtHR75.Value = 0;
            _txtModelo.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _dtpFechaRegistro.Value = _datoTecnicoMotorDiesel.FechaDeRegistro;
            _txtCapacidadInstalada.Text = _datoTecnicoMotorDiesel.CapacidadInstalada.ToString("N2");
            _txtHR100.Text = _datoTecnicoMotorDiesel.HeatRate100.ToString("N0");
            _txtHR50.Text = _datoTecnicoMotorDiesel.HeatRate50.ToString("N0");
            _txtHR75.Text = _datoTecnicoMotorDiesel.HeatRate75.ToString("N0");
            _txtModelo.Text = _datoTecnicoMotorDiesel.Modelo;
            _txtObservaciones.Text = _datoTecnicoMotorDiesel.Observaciones;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecnicoMotorDiesel.CapacidadInstalada = _txtCapacidadInstalada.ValDouble;
                _datoTecnicoMotorDiesel.FkProyecto = _proyecto.PkProyecto;
                _datoTecnicoMotorDiesel.HeatRate100 = _txtHR100.ValorLong;
                _datoTecnicoMotorDiesel.HeatRate50 = _txtHR50.ValorLong;
                _datoTecnicoMotorDiesel.HeatRate75 = _txtHR75.ValorLong;
                _datoTecnicoMotorDiesel.Modelo = _txtModelo.Text;
                _datoTecnicoMotorDiesel.Observaciones = _txtObservaciones.Text;
                if (_datoTecnicoMotorDiesel.EsNuevo)
                {
                    _datoTecnicoMotorDiesel.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoMotorDieselMgr.Instancia.Guardar(_datoTecnicoMotorDiesel);
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
                res = false;
                _errorProvider.SetError(_txtCapacidadInstalada, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtHR100.ValorLong<0)
            {
                res = false;
                _errorProvider.SetError(_txtHR100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtHR50.ValorLong<0)
            {
                res = false;
                _errorProvider.SetError(_txtHR50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtHR75.ValorLong < 0)
            {
                res = false;
                _errorProvider.SetError(_txtHR75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
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

            if (_datoTecnicoMotorDiesel.EsNuevo)
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
