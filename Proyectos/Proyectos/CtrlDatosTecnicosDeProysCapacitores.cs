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
    public partial class CtrlDatosTecnicosDeProysCapacitores : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoCapacitor _datoTecCapacitor;
        bool _seGuardo = true;

        public CtrlDatosTecnicosDeProysCapacitores()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbCapacitores();
                _cmbTipoCapacitor.SelectedIndex = 0;
            }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txTensionNominal.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPotenciaNominalTrifasica.Enabled = false;
            _cmbTipoCapacitor.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _txtXcReactanciaCapcitiva.Enabled = false;
            _txtNodoOrigen.Enabled = false;
            _txtNodoDestino.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txTensionNominal.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPotenciaNominalTrifasica.Enabled = true;
            _txtNodoOrigen.Enabled = true;
            _cmbTipoCapacitor.Enabled = true;
            _dtpFechaRegistro.Enabled = _datoTecCapacitor.EsNuevo? true:false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void CargarCmbCapacitores()
        {
            DefDominioMgr mgr = new DefDominioMgr();

            _cmbTipoCapacitor.DisplayMember = "Descripcion";
            _cmbTipoCapacitor.ValueMember = "CodDominio";
            _cmbTipoCapacitor.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TIPO_CAPACITORES);
        }

        private void _cmbTipoCapacitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarControlesPorTipoCapacitor();
        }

        private void ActivarControlesPorTipoCapacitor()
        {
            if ((DefDominio)_cmbTipoCapacitor.SelectedItem != null)
            {
                if (((DefDominio)_cmbTipoCapacitor.SelectedItem).Descripcion == "CAPACITOR EN PARALELO")
                {
                    _txtNodoOrigen.Enabled = true;
                    _txtNodoDestino.Enabled = false;
                    _txtXcReactanciaCapcitiva.Enabled = false;
                    _txtXcReactanciaCapcitiva.Text = string.Empty;
                    _txtNodoDestino.Text = string.Empty;
                    _txtXcReactanciaCapcitiva.BackColor = Color.Gainsboro;
                    _txtNodoDestino.BackColor = Color.Gainsboro;
                    _txtXcReactanciaCapcitiva.Text = "0.0000";
                    CalcularX1();
                }
                else
                {
                    _txtXcReactanciaCapcitiva.Text = _datoTecCapacitor == null ? "0.0000" : _datoTecCapacitor.XcReactanciaCapacitiva.ToString("N4") ;
                    CalcularX1();
                    _txtXcReactanciaCapcitiva.Enabled = true;
                    _txtNodoOrigen.Enabled = true;
                    _txtNodoDestino.Enabled = true;
                    _txtXcReactanciaCapcitiva.BackColor = Color.White;
                    _txtNodoDestino.BackColor = Color.White;
                }
            }
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;
            LimpiarControles();
            _datoTecCapacitor = OraDalDatoTecnicoCapacitorMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            List<LocalizacionProyectosTransmision> lista = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_proyecto.PkProyecto);
            if (lista.Count > 0)
            {
                _txtSubestacionOrigen.Text = lista[0].Subestacion;
            }

            if (_datoTecCapacitor == null)
            {
                _datoTecCapacitor = new DatoTecnicoCapacitor();
                _datoTecCapacitor.EsNuevo = true;
            }
            else
            {
                _datoTecCapacitor.EsNuevo = false;
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
            _txTensionNominal.Text = _datoTecCapacitor.TensionNominal.ToString("N2");
            _txtObservaciones.Text = _datoTecCapacitor.Observaciones;
            _txtPotenciaNominalTrifasica.Text = _datoTecCapacitor.PotNominalTrifasicaReac.ToString("N2");
            _txtXcReactanciaCapcitiva.Text = _datoTecCapacitor.XcReactanciaCapacitiva.ToString("N4");
            _cmbTipoCapacitor.SelectedValue = _datoTecCapacitor.DCodTipoBancoCapacitor;
            _dtpFechaRegistro.Value = _datoTecCapacitor.FechaRegistro;
            _txtNodoOrigen.Text = _datoTecCapacitor.NodoConexionOrigen;
            _txtNodoDestino.Text = _datoTecCapacitor.NodoConexionDestino;
            CalcularX1();
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtSubestacionOrigen.Text = string.Empty;
            _txTensionNominal.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPotenciaNominalTrifasica.Value = 0;
            _txtXcReactanciaCapcitiva.Value = 0;
            _txtNodoDestino.Text = string.Empty;
            _txtNodoOrigen.Text = string.Empty;
            _txtX1.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecCapacitor.DCodTipoBancoCapacitor = (Int64)_cmbTipoCapacitor.SelectedValue;
                _datoTecCapacitor.NodoConexionOrigen = _txtNodoOrigen.Text;
                _datoTecCapacitor.NodoConexionDestino = _txtNodoDestino.Text;
                _datoTecCapacitor.FkProyecto = _proyecto.PkProyecto;
                _datoTecCapacitor.Observaciones = _txtObservaciones.Text;
                _datoTecCapacitor.PotNominalTrifasicaReac = _txtPotenciaNominalTrifasica.ValDouble;
                _datoTecCapacitor.TensionNominal = _txTensionNominal.ValDouble;
                _datoTecCapacitor.XcReactanciaCapacitiva = _txtXcReactanciaCapcitiva.ValDouble;
                if (_datoTecCapacitor.EsNuevo)
                {
                    _datoTecCapacitor.FechaRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoCapacitorMgr.Instancia.Guardar(_datoTecCapacitor);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (_txTensionNominal.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txTensionNominal, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtPotenciaNominalTrifasica.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtPotenciaNominalTrifasica, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtXcReactanciaCapcitiva.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtXcReactanciaCapcitiva, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            ActivarControlesPorTipoCapacitor();
            _seGuardo = false;
            _cmbTipoCapacitor.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecCapacitor.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
        }

        private void _txtXcReactanciaCapcitiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularX1();
            }
        }

        private void CalcularX1()
        {
            double x1 = 0;
            if (_txTensionNominal.ValDouble > 0 && _txtXcReactanciaCapcitiva.ValDouble > 0 )
            {
                x1 = _txtXcReactanciaCapcitiva.ValDouble /((( _txTensionNominal.ValDouble)*( _txTensionNominal.ValDouble)) / 100) * 100;
               // x1 = Math.Round(x1, 4);
            }
            _txtX1.Text = x1.ToString("N4");
        }

        private void _txTensionNominal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularX1();
            }
        }

        private void _txTensionNominal_Validating(object sender, CancelEventArgs e)
        {
            CalcularX1();
        }

        private void _txtXcReactanciaCapcitiva_Validating(object sender, CancelEventArgs e)
        {
            CalcularX1();
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
