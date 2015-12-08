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
    public partial class CtrlDatosTecnicosProysCicloCombinado : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoCicloCombinado _datoTecCicloCombinado;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProysCicloCombinado()
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
            _txtModeloTurbina.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecCicloCombinado.EsNuevo ? true : false;
            _txtCapacidadInstalada.Enabled = true;
            _txtHR100.Enabled = true;
            _txtHR50.Enabled = true;
            _txtHR75.Enabled = true;
            _txtModeloTurbina.Enabled = true;
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
            _datoTecCicloCombinado = OraDalDatoTecnicoCicloCombinadoMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);

            if (_datoTecCicloCombinado == null)
            {
                _datoTecCicloCombinado = new DatoTecnicoCicloCombinado();
                _datoTecCicloCombinado.EsNuevo = true;
            }
            else
            {
                _datoTecCicloCombinado.EsNuevo = false;
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
            _txtModeloTurbina.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _dtpFechaRegistro.Value = _datoTecCicloCombinado.FechaDeRegistro;
            _txtModeloTurbina.Text = _datoTecCicloCombinado.CapacidadInstalda.ToString();
            _txtHR100.Text = _datoTecCicloCombinado.HeatRate100.ToString("N0");
            _txtHR50.Text = _datoTecCicloCombinado.HeatRate50.ToString("N0");
            _txtHR75.Text = _datoTecCicloCombinado.HeatRate75.ToString("N0");
            _txtObservaciones.Text = _datoTecCicloCombinado.Observaciones;
            _txtModeloTurbina.Text = _datoTecCicloCombinado.ModeloTurbina;
            _txtCapacidadInstalada.Text = _datoTecCicloCombinado.CapacidadInstalda.ToString("N2");
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

            if (_txtHR100.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHR100, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHR50.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHR50, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtHR75.ValorLong < 0)
            {
                _errorProvider.SetError(_txtHR75, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            return res;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecCicloCombinado.CapacidadInstalda = _txtCapacidadInstalada.ValDouble;
                _datoTecCicloCombinado.FkProyecto = _proyecto.PkProyecto;
                _datoTecCicloCombinado.HeatRate100 = _txtHR100.ValorLong;
                _datoTecCicloCombinado.HeatRate50 = _txtHR50.ValorLong;
                _datoTecCicloCombinado.HeatRate75 = _txtHR75.ValorLong;
                _datoTecCicloCombinado.ModeloTurbina = _txtModeloTurbina.Text;
                _datoTecCicloCombinado.Observaciones = _txtObservaciones.Text;
                if (_datoTecCicloCombinado.EsNuevo)
                {
                    _datoTecCicloCombinado.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoCicloCombinadoMgr.Instancia.Guardar(_datoTecCicloCombinado);
                DeshabilitarControles();
                _seGuardo = true;
            }
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

            if (_datoTecCicloCombinado.EsNuevo)
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
