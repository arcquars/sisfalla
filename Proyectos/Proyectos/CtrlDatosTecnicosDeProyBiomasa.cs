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
    public partial class CtrlDatosTecnicosDeProyBiomasa : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoBiomasa _datoTecBiomasa;
        bool _seGuardo = true;

        public CtrlDatosTecnicosDeProyBiomasa()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTecnologia();
            }
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtBiomasaDisponible.Enabled = false;
            _txtConsumoEspecifico.Enabled = false;
            _txtNroUnidades.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPoderCalorifico.Enabled = false;
            _txtPotenciaInstalada.Enabled = false;
            _cmbTecnologia.Enabled = false;
            _dtpFechaDesde.Enabled = false;
            _dtpFechaHasta.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtBiomasaDisponible.Enabled = true;
            _txtConsumoEspecifico.Enabled = true;
            _txtNroUnidades.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPoderCalorifico.Enabled = true;
            _txtPotenciaInstalada.Enabled = true;
            _cmbTecnologia.Enabled = true;
            _dtpFechaDesde.Enabled = true;
            _dtpFechaHasta.Enabled = true;
            _dtpFechaRegistro.Enabled = _datoTecBiomasa.EsNuevo? true: false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void CargarCmbTecnologia()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTecnologia.DisplayMember = "Descripcion";
            _cmbTecnologia.ValueMember = "CodDominio";
            _cmbTecnologia.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TEC_BIOMASA);
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;

            LimpiarControles();
            _datoTecBiomasa = OraDalDatoTecnicoBiomasaMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_datoTecBiomasa == null)
            {
                _datoTecBiomasa = new DatoTecnicoBiomasa();
                _datoTecBiomasa.EsNuevo = true;
            }
            else
            {
                _datoTecBiomasa.EsNuevo = false;
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
            _txtBiomasaDisponible.Text = _datoTecBiomasa.BiomadaDisponible.ToString("N2");
            _txtConsumoEspecifico.Text = _datoTecBiomasa.ConsumoEspecifico.ToString("N2");
            _txtNroUnidades.Text = _datoTecBiomasa.NroUnidades.ToString("N0");
            _txtObservaciones.Text = _datoTecBiomasa.Observaciones;
            _txtPoderCalorifico.Text = _datoTecBiomasa.PorderCalorifico.ToString("N2");
            _txtPotenciaInstalada.Text = _datoTecBiomasa.PotenciaInstalada.ToString("N2");
            _dtpFechaDesde.Value = _datoTecBiomasa.PeriodoOperacionMesDe;
            _dtpFechaHasta.Value = _datoTecBiomasa.PeriodoOperacionMesA;
            _dtpFechaRegistro.Value = _datoTecBiomasa.FechaRegistro;
            _cmbTecnologia.SelectedValue = _datoTecBiomasa.DCodTecnologiaBiomasa;
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtBiomasaDisponible.Value = 0;
            _txtConsumoEspecifico.Value = 0;
            _txtNroUnidades.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPoderCalorifico.Value = 0;
            _txtPotenciaInstalada.Value = 0;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecBiomasa.BiomadaDisponible = _txtBiomasaDisponible.ValDouble;
                _datoTecBiomasa.ConsumoEspecifico = _txtConsumoEspecifico.ValDouble;
                _datoTecBiomasa.DCodTecnologiaBiomasa = (Int64) _cmbTecnologia.SelectedValue;
                _datoTecBiomasa.FkProyecto = _proyecto.PkProyecto;
                _datoTecBiomasa.NroUnidades = _txtNroUnidades.ValorLong;
                _datoTecBiomasa.Observaciones = _txtObservaciones.Text;
                _datoTecBiomasa.PeriodoOperacionMesA = _dtpFechaDesde.Value;
                _datoTecBiomasa.PeriodoOperacionMesDe = _dtpFechaHasta.Value;
                _datoTecBiomasa.PorderCalorifico = _txtPoderCalorifico.ValDouble;
                _datoTecBiomasa.PotenciaInstalada = _txtPotenciaInstalada.ValDouble;
                if (_datoTecBiomasa.EsNuevo)
                {
                    _datoTecBiomasa.FechaRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoBiomasaMgr.Instancia.Guardar(_datoTecBiomasa);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if ( _txtNroUnidades.ValorLong<0)
            {
                _errorProvider.SetError(_txtNroUnidades, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtPotenciaInstalada.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPotenciaInstalada, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtBiomasaDisponible.ValDouble < 0)
            {
                _errorProvider.SetError(_txtBiomasaDisponible, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtConsumoEspecifico.ValDouble < 0)
            {
                _errorProvider.SetError(_txtConsumoEspecifico, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtPoderCalorifico.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPoderCalorifico, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
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

            if (_datoTecBiomasa.EsNuevo)
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
