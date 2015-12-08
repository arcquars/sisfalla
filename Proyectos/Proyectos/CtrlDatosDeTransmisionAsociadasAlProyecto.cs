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

namespace Proyectos
{
    public partial class CtrlDatosDeTransmisionAsociadasAlProyecto : CtrlDatosBase, IControles
    {
        bool _esEditable = false;
        Proyecto _proyecto;
        TransmisionAsociadaAlProyecto _transmisionAsociadaAlProy;
        bool _seGuardo = true;

        public CtrlDatosDeTransmisionAsociadasAlProyecto()
        {
            InitializeComponent();
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            if (_transmisionAsociadaAlProy==null)
            {
                return;
            }
            _txtCapacidad.Text = _transmisionAsociadaAlProy.CapacidadConexion.ToString();
            _txtCosto.Text = _transmisionAsociadaAlProy.Costo.ToString("N2");
            _txtLongitud.Text = _transmisionAsociadaAlProy.Longitud.ToString("N2");
            _txtNodo.Text = _transmisionAsociadaAlProy.NodoDeConexion;
            _txtObservaciones.Text = _transmisionAsociadaAlProy.Observaciones;
            _txtTension.Text = _transmisionAsociadaAlProy.Tension.ToString("N2");
            if (_transmisionAsociadaAlProy.FechaDeRegistro >= _dtpFechaRegistro.MinDate && _transmisionAsociadaAlProy.FechaDeRegistro <= _dtpFechaRegistro.MaxDate)
            {
                _dtpFechaRegistro.Value = _transmisionAsociadaAlProy.FechaDeRegistro;
            }
            _txtSusceptancia.Text = _transmisionAsociadaAlProy.Susceptancia.ToString("N4");
            _txtResistencia.ValorDouble = _transmisionAsociadaAlProy.Resistencia;
            _txtReactancia.ValDouble = _transmisionAsociadaAlProy.Reactancia;
            //_txtResistencia.Text = _transmisionAsociadaAlProy.Resistencia.ToString("N4");
            //_txtReactancia.Text = _transmisionAsociadaAlProy.Reactancia.ToString("N4");
            CalcularQVacio();
            CalcularR1();
            CalcularX1();
        }

        protected void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCapacidad.Enabled = false;
            _txtCosto.Enabled = false;
            _txtLongitud.Enabled = false;
            _txtNodo.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtTension.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _txtReactancia.Enabled = false;
            _txtResistencia.Enabled = false;
            _txtSusceptancia.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        protected void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtCapacidad.Enabled = true;
            _txtCosto.Enabled = true;
            _txtLongitud.Enabled = true;
            _txtNodo.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtTension.Enabled = true;
            _dtpFechaRegistro.Enabled = _transmisionAsociadaAlProy.EsNuevo?true : false;
            _txtReactancia.Enabled = true;
            _txtResistencia.Enabled = true;
            _txtSusceptancia.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();

            _txtCapacidad.Value = 0;
            _txtCosto.Value = 0;
            _txtLongitud.Value = 0;
            _txtNodo.Text = string.Empty;
            _txtObservaciones.Text = string.Empty;
            _txtTension.Value = 0;
            _txtReactancia.Value = 0;
            _txtResistencia.Value = 0;
            _txtSusceptancia.Value = 0;
            _txtR1.Value = 0;
            _txtQvacio.Value = 0;
            _txtX1.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _transmisionAsociadaAlProy.CapacidadConexion = _txtCapacidad.ValDouble;
                _transmisionAsociadaAlProy.Costo = _txtCosto.ValDouble;
                _transmisionAsociadaAlProy.FkProyecto = _proyecto.PkProyecto;
                _transmisionAsociadaAlProy.Longitud = _txtLongitud.ValDouble;
                _transmisionAsociadaAlProy.NodoDeConexion = _txtNodo.Text;
                _transmisionAsociadaAlProy.Observaciones = _txtObservaciones.Text;
                _transmisionAsociadaAlProy.Tension = _txtTension.ValDouble;
                _transmisionAsociadaAlProy.Reactancia = _txtReactancia.ValDouble;
                _transmisionAsociadaAlProy.Resistencia = _txtResistencia.ValDouble;
                _transmisionAsociadaAlProy.Susceptancia = _txtSusceptancia.ValDouble;
                if (_transmisionAsociadaAlProy.EsNuevo)
                {
                    _transmisionAsociadaAlProy.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalTransmisionAsociadaAlProyectoMgr.Instancia.Guardar( _transmisionAsociadaAlProy);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtCapacidad.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCapacidad, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCosto.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCosto, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtLongitud.ValDouble < 0)
            {
                _errorProvider.SetError(_txtLongitud, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtTension.ValDouble < 0)
            {
                _errorProvider.SetError(_txtTension, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            return res;
        }

        #region Miembros de IControles

        public string Titulo
        {
            get { return "TRANSMISION ASOCIADA AL PROYECTO"; }
        }

        void IControles.SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;
            LimpiarControles();
            ActivarDesActivarControles();

            _transmisionAsociadaAlProy = OraDalTransmisionAsociadaAlProyectoMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            if (_transmisionAsociadaAlProy == null)
            {
                _transmisionAsociadaAlProy = new TransmisionAsociadaAlProyecto();
                _transmisionAsociadaAlProy.EsNuevo = true;
            }
            else
            {
                _transmisionAsociadaAlProy.EsNuevo = false;
                CargarDatos();
            }
            _txtNodo.Focus();
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

        #endregion

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtNodo.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _esEditable = false;
            _seGuardo = true;
            _errorProvider.Clear();

            if (_transmisionAsociadaAlProy.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
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
            if (_txtTension.ValDouble > 0 && _txtResistencia.ValDouble > 0 && _txtLongitud.ValDouble > 0)
            {
                r1 = ((_txtResistencia.ValDouble * _txtLongitud.ValDouble) / ((_txtTension.ValDouble * _txtTension.ValDouble) / 100)) * 100;
              //  r1 = Math.Round(r1, 4);
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
            if (_txtTension.ValDouble > 0 && _txtReactancia.ValDouble > 0 && _txtLongitud.ValDouble > 0)
            {
                x1 = ((_txtReactancia.ValDouble * _txtLongitud.ValDouble) / ((_txtTension.ValDouble * _txtTension.ValDouble) / 100)) * 100;
               // x1 = Math.Round(x1, 4);
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
            if (_txtTension.ValDouble > 0 && _txtSusceptancia.ValDouble > 0 && _txtLongitud.ValDouble > 0)
            {
                q = ((_txtSusceptancia.ValDouble * ((_txtTension.ValDouble * _txtTension.ValDouble) / 100)) * (_txtLongitud.ValDouble) * 100) / 1000000;
               // q = Math.Round(q, 4);
            }
            _txtQvacio.Text = q.ToString("N4");
        }

        private void _txtTension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
                CalcularX1();
                CalcularQVacio();
            }
        }

        private void _txtLongitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
                CalcularX1();
                CalcularQVacio();
            }
        }

        private void _txtLongitud_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtTension_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtResistencia_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtReactancia_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }

        private void _txtSusceptancia_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
            CalcularX1();
            CalcularQVacio();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatos();
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
