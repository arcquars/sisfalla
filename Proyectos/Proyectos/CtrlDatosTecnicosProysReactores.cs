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
    public partial class CtrlDatosTecnicosProysReactores : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        DatoTecnicoReactor _datoTecnicoReactor;
        bool _seGuardo = true;

        public CtrlDatosTecnicosProysReactores()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoReactor();
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }
        
        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtLinea.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPotenciaNominalTrifasica.Enabled = false;
            _txtPotenciaNominalTrifasica.Enabled = false;
            _txtNodoConexion.Enabled = false;
            _cmbTipoReactor.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _txtTensionNominal.Enabled = false;
            _txtFactorDeCalidad.Enabled = false;

            _txtTensionNominalRN.Enabled = false;
            _txtPotenciaTrifasicaRN.Enabled = false;
            _txtFactorCalidadRN.Enabled = false;
            _txtNodoConexionRN.Enabled = false;
            _txtObservacionesRN.Enabled = false;

            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtLinea.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPotenciaNominalTrifasica.Enabled = true;
            _txtPotenciaNominalTrifasica.Enabled = true;
            _txtNodoConexion.Enabled = true;
            _cmbTipoReactor.Enabled = true;
            _txtTensionNominal.Enabled = true;
            _txtFactorDeCalidad.Enabled = true;

            _txtTensionNominalRN.Enabled = true;
            _txtPotenciaTrifasicaRN.Enabled = true;
            _txtFactorCalidadRN.Enabled = true;
            _txtNodoConexionRN.Enabled = true;
            _txtObservacionesRN.Enabled = true;

            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
            AsegurarTxtLinea();
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        private void CargarCmbTipoReactor()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoReactor.DisplayMember = "Descripcion";
            _cmbTipoReactor.ValueMember = "CodDominio";
            _cmbTipoReactor.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TIPO_REACTOR);
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            LimpiarControles();
            _seGuardo = true;

            _datoTecnicoReactor = OraDalDatoTecnicoReactorMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            List<LocalizacionProyectosTransmision> lista = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_proyecto.PkProyecto);
            if (lista.Count > 0)
            {
                _txtSubestacionOrigen.Text = lista[0].Subestacion;
            }
            if (_datoTecnicoReactor == null)
            {
                _datoTecnicoReactor = new DatoTecnicoReactor();
                _datoTecnicoReactor.EsNuevo = true;
            }
            else
            {
                _datoTecnicoReactor.EsNuevo = false;
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
            _dtpFechaRegistro.Value = _datoTecnicoReactor.FechaRegistro;
            _txtLinea.Text = _datoTecnicoReactor.Linea;
            _txtObservaciones.Text = _datoTecnicoReactor.Observaciones;
            _txtPotenciaNominalTrifasica.Text = _datoTecnicoReactor.PotNominalTrifasicaReactivo.ToString("N2");
            _txtTensionNominal.Text = _datoTecnicoReactor.TensionNominal.ToString("N2");
            _cmbTipoReactor.SelectedValue = _datoTecnicoReactor.DCodTipoReactor;
            _txtNodoConexion.Text = _datoTecnicoReactor.NodoConexion;
            _txtFactorDeCalidad.Text = _datoTecnicoReactor.FactorCalidad.ToString("N2");

            _txtFactorCalidadRN.Text = _datoTecnicoReactor.FactorCalidadRn.ToString("N2");
            _txtNodoConexionRN.Text = _datoTecnicoReactor.NodoConexionRn;
            _txtObservacionesRN.Text = _datoTecnicoReactor.ObservacionesRn;
            _txtPotenciaTrifasicaRN.Text = _datoTecnicoReactor.PotNominalTrifasicaRn.ToString("N2");
            _txtTensionNominalRN.Text = _datoTecnicoReactor.TensionNominalRn.ToString("N2");
            AsegurarTxtLinea();
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtLinea.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
            _txtPotenciaNominalTrifasica.Value = 0;
            _txtTensionNominal.Value = 0;
            _txtFactorDeCalidad.Value = 0;
            _txtNodoConexion.Text = string.Empty;

            _txtTensionNominalRN.Value = 0;
            _txtPotenciaTrifasicaRN.Value = 0;
            _txtFactorCalidadRN.Value = 0;
            _txtNodoConexionRN.Text = string.Empty;
            _txtObservacionesRN.Text = string.Empty;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _datoTecnicoReactor.DCodTipoReactor = (Int64)_cmbTipoReactor.SelectedValue;
                _datoTecnicoReactor.NodoConexion = _txtNodoConexion.Text;
                _datoTecnicoReactor.FkProyecto = _proyecto.PkProyecto;
                _datoTecnicoReactor.Linea = _txtLinea.Text;
                _datoTecnicoReactor.Observaciones = _txtObservaciones.Text;
                _datoTecnicoReactor.PotNominalTrifasicaReactivo = _txtPotenciaNominalTrifasica.ValDouble;
                _datoTecnicoReactor.TensionNominal = _txtTensionNominal.ValDouble;
                
                if (_datoTecnicoReactor.EsNuevo)
                {
                    _datoTecnicoReactor.FechaRegistro = _dtpFechaRegistro.Value;
                }
                
                _datoTecnicoReactor.TensionNominalRn = _txtTensionNominalRN.ValDouble;
                _datoTecnicoReactor.PotNominalTrifasicaRn = _txtPotenciaTrifasicaRN.ValDouble;
                _datoTecnicoReactor.FactorCalidadRn = _txtFactorCalidadRN.ValDouble;
                _datoTecnicoReactor.NodoConexionRn = _txtNodoConexionRN.Text;
                _datoTecnicoReactor.ObservacionesRn = _txtObservacionesRN.Text;
                OraDalDatoTecnicoReactorMgr.Instancia.Guardar(_datoTecnicoReactor);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            
            if (_cmbTipoReactor.SelectedItem != null)
            {
                DefDominioMgr mgr = new DefDominioMgr();

                if (mgr.GetPorId<DefDominio>(((long)_cmbTipoReactor.SelectedValue), DefDominio.C_COD_DOMINIO).Descripcion == "DE LINEA")
                {
                    if (_txtLinea.Text == "")
                    {
                        _errorProvider.SetError(_txtLinea, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
                        res = false;
                    }
                }
            }

            if (_txtPotenciaNominalTrifasica.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPotenciaNominalTrifasica, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTensionNominal.ValDouble < 0)
            {
                _errorProvider.SetError(_txtTensionNominal, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            return res;
        }

        private void _cmbTipoReactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AsegurarTxtLinea();
        }

        private void AsegurarTxtLinea()
        {
            if ((DefDominio)_cmbTipoReactor.SelectedItem != null)
            {
                if (((DefDominio)_cmbTipoReactor.SelectedItem).Descripcion == "LINEA")
                {
                    _txtLinea.Enabled = true;
                    _txtLinea.BackColor = Color.White;
                    _txtLinea.Text = _datoTecnicoReactor == null ? string.Empty : _datoTecnicoReactor.Linea;
                }
                else
                {
                    _txtLinea.Enabled = false;
                    _txtLinea.Text = string.Empty;
                    _txtLinea.BackColor = Color.Gainsboro;
                }
            }
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _cmbTipoReactor.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecnicoReactor.EsNuevo)
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
