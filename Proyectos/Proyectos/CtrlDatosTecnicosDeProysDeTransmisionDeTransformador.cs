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
    public partial class CtrlDatosTecnicosDeProysDeTransmisionDeTransformador : CtrlDatosBase, IControles
    {
        bool _esEditable= false;
        Proyecto _proyecto;
        DatoTecnicoTransformador _datoTecTransformador;
        bool _seGuardo = true;

        public CtrlDatosTecnicosDeProysDeTransmisionDeTransformador()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTiposTransformador();
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCapacidad.Enabled = false;
            _txtGrupoConexion.Enabled = false;
            _txtNivelTensionLadoAT.Enabled = false;
            _txtNivelTensionLadoBT.Enabled = false;
            _txtNivelTensionTerciario.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPasoTap.Enabled = false;
            _txtR1ResistenciaBase.Enabled = false;
            _txtTapMaximo.Enabled = false;
            _txtTapMinimo.Enabled = false;
            _txtX1ReactanciaBase.Enabled = false;
            _cmbTipoTransformador.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _txtNodoAT.Enabled = false;
            _txtNodoBT.Enabled = false;
            _txtNodoTerciario.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecTransformador.EsNuevo ? true : false;
            _txtCapacidad.Enabled = true;
            _txtGrupoConexion.Enabled = true;
            _txtNivelTensionLadoAT.Enabled = true;
            _txtNivelTensionLadoBT.Enabled = true;
            _txtNivelTensionTerciario.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPasoTap.Enabled = true;
            _txtR1ResistenciaBase.Enabled = true;
            _txtTapMaximo.Enabled = true;
            _txtTapMinimo.Enabled = true;
            _txtX1ReactanciaBase.Enabled = true;
            _cmbTipoTransformador.Enabled = true;
            _txtNodoAT.Enabled = true;
            _txtNodoBT.Enabled = true;
            _txtNodoTerciario.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        private void CargarCmbTiposTransformador()
        {
            DefDominioMgr mgr = new DefDominioMgr();

            _cmbTipoTransformador.DisplayMember = "Descripcion";
            _cmbTipoTransformador.ValueMember = "CodDominio";
            _cmbTipoTransformador.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TIPO_TRANSFORMADOR);
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            LimpiarControles();
            _seGuardo = true;
            _datoTecTransformador = OraDalDatoTecnicoTransformadorMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            List<LocalizacionProyectosTransmision> lista = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_proyecto.PkProyecto);
            if (lista.Count > 0)
            {
                _txtSubestacionOrigen.Text = lista[0].Subestacion;
            }
            if (_datoTecTransformador == null)
            {
                _datoTecTransformador = new DatoTecnicoTransformador();
                _datoTecTransformador.EsNuevo = true;
            }
            else
            {
                _datoTecTransformador.EsNuevo = false;
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
            _txtCapacidad.Value = 0;
            _txtGrupoConexion.Text = string.Empty;
            _txtNivelTensionLadoAT.Value = 0;
            _txtNivelTensionLadoBT.Value = 0;
            _txtNivelTensionTerciario.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPasoTap.Value = 0;
            _txtR1ResistenciaBase.Value = 0;
            _txtTapMaximo.Value = 0;
            _txtTapMinimo.Value = 0;
            _txtX1ReactanciaBase.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _txtNodoAT.Text = string.Empty;
            _txtNodoBT.Text = string.Empty;
            _txtNodoTerciario.Text = string.Empty;
            _txtX1.Value = 0;
            _txtR1.Value = 0;
        }

        private void CargarDatos()
        {
          
            _dtpFechaRegistro.Enabled = false;
            _txtCapacidad.Text = _datoTecTransformador.Capacidad.ToString("N2");
            _txtGrupoConexion.Text = _datoTecTransformador.GrupoConexion;
            _txtNivelTensionLadoAT.Text = _datoTecTransformador.NivelDeTensionLadoAt.ToString("N2");
            _txtNivelTensionLadoBT.Text = _datoTecTransformador.NivelDeTensionLadoBt.ToString("N2");
            _txtNivelTensionTerciario.Text = _datoTecTransformador.NivelDeTensionTerciario.ToString("N2");
            _txtObservaciones.Text = _datoTecTransformador.Observaciones;
            _txtPasoTap.Text = _datoTecTransformador.PasoTap.ToString("N2");
            _txtR1ResistenciaBase.Text = _datoTecTransformador.R1ResistenciaBasePpopia.ToString("N4");
            _txtTapMaximo.Text = _datoTecTransformador.TapMaximo.ToString("N2");
            _txtTapMinimo.Text = _datoTecTransformador.TapMinimo.ToString("N2");
            _txtX1ReactanciaBase.Text = _datoTecTransformador.X1ReactanciaBasePropia.ToString("N4");
            _cmbTipoTransformador.SelectedValue = _datoTecTransformador.DCodTipoTransformador;
            _dtpFechaRegistro.Value = _datoTecTransformador.FechaDeRegistro;
            _txtNodoAT.Text = _datoTecTransformador.NodoAT;
            _txtNodoBT.Text = _datoTecTransformador.NodoBT;
            _txtNodoTerciario.Text = _datoTecTransformador.NodoTerciario;
            CalcularR1();
            CalcularX1();
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            // estas lineas son temporales solo para probar las altas

            if (DatosValidos())
            {
                _datoTecTransformador.Capacidad = _txtCapacidad.ValDouble;
                _datoTecTransformador.DCodTipoTransformador = (Int64) _cmbTipoTransformador.SelectedValue;
                _datoTecTransformador.FkCodProyecto = _proyecto.PkProyecto;
                _datoTecTransformador.NivelDeTensionLadoAt = _txtNivelTensionLadoAT.ValDouble;
                _datoTecTransformador.NivelDeTensionLadoBt = _txtNivelTensionLadoBT.ValDouble;
                _datoTecTransformador.NivelDeTensionTerciario = _txtNivelTensionTerciario.ValDouble;
                _datoTecTransformador.Observaciones = _txtObservaciones.Text;
                _datoTecTransformador.PasoTap = _txtPasoTap.ValDouble;
                _datoTecTransformador.R1ResistenciaBasePpopia = _txtR1ResistenciaBase.ValDouble;
                _datoTecTransformador.TapMaximo = _txtTapMaximo.ValDouble;
                _datoTecTransformador.TapMinimo = _txtTapMinimo.ValDouble;
                _datoTecTransformador.X1ReactanciaBasePropia = _txtX1ReactanciaBase.ValDouble;
                _datoTecTransformador.GrupoConexion = _txtGrupoConexion.Text;
                _datoTecTransformador.NodoAT = _txtNodoAT.Text;
                _datoTecTransformador.NodoBT = _txtNodoBT.Text;
                _datoTecTransformador.NodoTerciario = _txtNodoTerciario.Text;
                if (_datoTecTransformador.EsNuevo)
                {
                    _datoTecTransformador.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoTransformadorMgr.Instancia.Guardar(_datoTecTransformador);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (_txtCapacidad.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtCapacidad, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            //if (_txtGrupoConexion.Text == string.Empty)
            //{
            //    res = false;
            //    _errorProvider.SetError(_txtGrupoConexion, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            //}

            if (_txtNivelTensionLadoAT.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtNivelTensionLadoAT, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtNivelTensionLadoBT.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtNivelTensionLadoBT, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtNivelTensionTerciario.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtNivelTensionTerciario, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtPasoTap.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtPasoTap, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtR1ResistenciaBase.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtR1ResistenciaBase, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtTapMaximo.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtTapMaximo, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtTapMinimo.ValDouble < 0)
            {
                res = false;
                _errorProvider.SetError(_txtTapMinimo, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _cmbTipoTransformador.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecTransformador.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
        }

        private void _txtR1ResistenciaBase_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
            }
        }

        private void CalcularR1()
        {
            double r1 = 0;
            if ( _txtR1ResistenciaBase.ValDouble > 0 && _txtCapacidad.ValDouble > 0)
            {
                r1 = _txtR1ResistenciaBase.ValDouble * (100 /_txtCapacidad.ValDouble) * 100;
               // r1 = Math.Round(r1, 4);
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
            if (_txtX1ReactanciaBase.ValDouble > 0 && _txtCapacidad.ValDouble > 0)
            {
                x1 = _txtX1ReactanciaBase.ValDouble * (100 / _txtCapacidad.ValDouble) * 100;
               // x1 = Math.Round(x1, 4);
            }
            _txtX1.Text = x1.ToString("N4");
        }

        private void _txtR1ResistenciaBase_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
        }

        private void _txtX1ReactanciaBase_Validating(object sender, CancelEventArgs e)
        {
            CalcularX1();
        }

        private void _txtCapacidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularR1();
                CalcularX1();
            }
        }

        private void _txtCapacidad_Validating(object sender, CancelEventArgs e)
        {
            CalcularR1();
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
