using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using Controles;
using CNDC.Dominios;
using ModeloSisFalla;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormCompComprometido : ABMBaseForm, IRRegFallaComponente
    {
        RRegFallaComponente _compComprometido;
        public FormCompComprometido()
        {
            InitializeComponent();
            _ctrlTiemposDetalle.TiempoTotalDesconexionModificado += new EventHandler<TiempoTotalDesconexionEventArgs>(_ctrlTiemposDetalle_TiempoTotalDesconexionModificado);
        }

        void _ctrlTiemposDetalle_TiempoTotalDesconexionModificado(object sender, TiempoTotalDesconexionEventArgs e)
        {
            _txtTiempoTotalDesconexion.Value = e.Dato;
        }

        List<long> _componentesYaUsados = new List<long>();
        public DialogResult Editar(RRegFallaComponente componenteCompr, List<long> componentesUsados)
        {
            _compComprometido = componenteCompr;
            _componentesYaUsados = componentesUsados;
            _ctrlCompCompr.SetComponenteNoSeleccionables(_componentesYaUsados);
            VisualizarCompCompro();
            _ctrlTiemposDetalle.VisualizarTiempos(_compComprometido);
            _ctrlAsignacionResponsabilidad.VisualizarAsigResp(_compComprometido);
            return ShowDialog();
        }

        private void VisualizarCompCompro()
        {
            _txtFechaHoraFalla.Value = _compComprometido.FecApertura;
            _ctrlCompCompr.VisualizarComponente(_compComprometido.PkCodComponente);
            if (_compComprometido.FlujoN1N2 == TipoFlujoNodo.Positivo)
            {
                _rbtnPositivo.Checked = true;
            }
            else
            {
                _rbtnNegativo.Checked = true;
            }

            _ctrlCompCompr.Enabled = _compComprometido.EsNuevo;
            _txtPotDesc.Value = _compComprometido.PotenciaDesconectada;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosValidos())
            {
                _compComprometido.DCodEstado = "1";
                _compComprometido.EtapaEdac = string.Empty;
                _compComprometido.FlujoN1N2 = _rbtnPositivo.Checked ? TipoFlujoNodo.Positivo : TipoFlujoNodo.Negativo;
                _compComprometido.PkCodComponente = (long)_ctrlCompCompr.Componente.PkCodComponente;
                _compComprometido.TiempoIndisponibilidad = _ctrlTiemposDetalle.TiempoIndisponibilidad;
                _compComprometido.TiempoPreconexion = _ctrlTiemposDetalle.TiempoPreconexion;
                _compComprometido.TiempoConexion = _ctrlTiemposDetalle.TiempoConexion;
                _compComprometido.PotenciaDesconectada = _txtPotDesc.Value;
                _compComprometido.FecApertura = _txtFechaHoraFalla.Value;
                _compComprometido.TiempoSistema = TiempoSistema;
                _compComprometido.TtotalDesconexion = _compComprometido.TiempoIndisponibilidad +
                    _compComprometido.TiempoPreconexion + _compComprometido.TiempoConexion;

                _compComprometido.TiempoPOper = _ctrlAsignacionResponsabilidad.TiempoPOper;
                _compComprometido.TiempoPSist = _ctrlAsignacionResponsabilidad.TiempoPSist;
                
                _compComprometido.FecCierre = _txtFechaHoraFalla.Value.AddMinutes(_txtTiempoTotalDesconexion.Value);
                if (ModeloMgr.Instancia.RRegFallaComponenteMgr.SolapaTiempos(_compComprometido))
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("SOLAPA_FECH_COMPO"));
                }
                else
                {
                    ModeloMgr.Instancia.RRegFallaComponenteMgr.Guardar(_compComprometido);

                    _ctrlTiemposDetalle.Guardar();
                    _ctrlAsignacionResponsabilidad.Guardar();
                    resultado = true;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            return resultado;
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_ctrlCompCompr.Componente == null)
            {
                _errorProvider.SetError(_ctrlCompCompr, MessageMgr.Instance.GetMessage("DEFINA_COMPO_COMPRO"));
                resultado = false;
            }

            if (!_txtFechaHoraFalla.EsFechaValida())            
            {
                _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA"));
                resultado = false;
            }

            if (_txtPotDesc.Value < 0)
            {
                _errorProvider.SetError(_txtPotDesc, MessageMgr.Instance.GetMessage("POT_DESC_POSITIVO"));
                resultado = false;
            }

            return resultado;
        }

        private void _txtFechaHoraFalla_Validating(object sender, CancelEventArgs e)
        {
            _errorProvider.SetError(_txtFechaHoraFalla, string.Empty);
            if (_txtFechaHoraFalla.EsFechaValida())
            {
                if (_txtFechaHoraFalla.Value > DateTime.Now)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("NO_FECHA_POSTERIOR"));
                    e.Cancel = true;
                }
            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA"));
                e.Cancel = true;
            }
        }

        #region IRRegFallaComponente
        public DateTime FecApertura
        {
            get { return _txtFechaHoraFalla.Value; }
            set { _txtFechaHoraFalla.Value = value; }
        }

        public TipoFlujoNodo FlujoN1N2
        {
            get { return _rbtnPositivo.Checked ? TipoFlujoNodo.Positivo : TipoFlujoNodo.Negativo; }
            set
            {
                _rbtnPositivo.Checked = value == TipoFlujoNodo.Positivo;
                _rbtnNegativo.Checked = value == TipoFlujoNodo.Negativo;
            }
        }

        public long PkCodComponente
        {
            get { return (long)_ctrlCompCompr.PkCodComponente; }
            set { _ctrlCompCompr.PkCodComponente = value; }
        }

        public float PotenciaDesconectada
        {
            get { return _txtPotDesc.Value; }
            set { _txtPotDesc.Value = value; }
        }

        public float TiempoConexion
        {
            get { return _ctrlTiemposDetalle.TiempoConexion; }
            set { _ctrlTiemposDetalle.TiempoConexion = value; }
        }

        public float TiempoIndisponibilidad
        {
            get { return _ctrlTiemposDetalle.TiempoIndisponibilidad; }
            set { _ctrlTiemposDetalle.TiempoIndisponibilidad = value; }
        }

        public float TiempoPreconexion
        {
            get { return _ctrlTiemposDetalle.TiempoPreconexion; }
            set { _ctrlTiemposDetalle.TiempoPreconexion = value; }
        }

        public float TiempoSistema
        {
            get { return _ctrlAsignacionResponsabilidad.TiempoTotalSistema; }
            set { _ctrlAsignacionResponsabilidad.TiempoTotalSistema = value; }
        }
        #endregion IRRegFallaComponente

        protected override bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (FecApertura!=_compComprometido.FecApertura)
            {
                resultado = true;
            }

            if (FlujoN1N2 != _compComprometido.FlujoN1N2)
            {
                resultado = true;
            }

            if (PkCodComponente != _compComprometido.PkCodComponente)
            {
                resultado = true;
            }

            if (PotenciaDesconectada != _compComprometido.PotenciaDesconectada)
            {
                resultado = true;
            }

            if (TiempoConexion != _compComprometido.TiempoConexion)
            {
                resultado = true;
            }

            if (TiempoIndisponibilidad != _compComprometido.TiempoIndisponibilidad)
            {
                resultado = true;
            }

            if (TiempoPreconexion != _compComprometido.TiempoPreconexion)
            {
                resultado = true;
            }

            if (TiempoSistema != _compComprometido.TiempoSistema)
            {
                resultado = true;
            }
            
            return resultado;
        }
    }
}
