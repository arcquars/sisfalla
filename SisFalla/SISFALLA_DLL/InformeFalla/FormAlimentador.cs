using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.Dominios;
using CNDC.ExceptionHandlerLib;
using CNDC.BLL;

namespace SISFALLA
{
    public partial class FrmAlimentador : ABMBaseForm, IOperacionAlimentador
    {
        OperacionAlimentador _opAlimentador;
        RegFalla _regFalla;
        Edac _edacAsociado;
        public FrmAlimentador()
        {
            InitializeComponent();

            _cbxTipoOpeAper.DisplayMember = DefDominio.C_DESCRIPCION;
            _cbxTipoOpeAper.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxTipoOpeAper.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_TIPO_OPERACION);

            _cbxTipoOperCierre.DisplayMember = DefDominio.C_DESCRIPCION;
            _cbxTipoOperCierre.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxTipoOperCierre.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_TIPO_OPERACION);

            List<D_TIPO_COMPONENTE> filtroAlimentadores = new List<D_TIPO_COMPONENTE>();
            filtroAlimentadores.Add(D_TIPO_COMPONENTE.AL);
            _ctrlComponenteComprometido.SetFiltroTipo(filtroAlimentadores);
        }

        public DialogResult Editar(OperacionAlimentador opAlimentador, List<long> alimentadoresUsados)
        {
            _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            _opAlimentador = opAlimentador;
            _ctrlComponenteComprometido.SetComponenteNoSeleccionables(alimentadoresUsados);
            Visualizar();
            return ShowDialog();
        }

        private void Visualizar()
        {
            _ctrlComponenteComprometido.VisualizarComponente(_opAlimentador.PkCodComponente);
            _ctrlComponenteComprometido.Enabled = _opAlimentador.EsNuevo;
            _txtFechaHoraAp.Value = _opAlimentador.FechaApertura;
            _txtFechaHoraCierre.Value = _opAlimentador.FechaCierre;

            _txtPotDesc.Value = _opAlimentador.PotDesc;
            _cbxTipoOpeAper.SelectedValue = _opAlimentador.DCodTipoOperAper;
            _cbxTipoOperCierre.SelectedValue = _opAlimentador.DCodTipoOpCierre;
            _cbxReleOperado.SelectedIndex = _opAlimentador.ReleOperado;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosValidos())
            {
                _opAlimentador.PkCodComponente = (long)_ctrlComponenteComprometido.Componente.PkCodComponente;
                _opAlimentador.FechaApertura = _txtFechaHoraAp.Value;
                _opAlimentador.FechaCierre = _txtFechaHoraCierre.Value;
                _opAlimentador.DCodTipoOperAper = (long)_cbxTipoOpeAper.SelectedValue;
                _opAlimentador.DCodTipoOpCierre = (long)_cbxTipoOperCierre.SelectedValue;
                _opAlimentador.PotDesc = _txtPotDesc.Value;
                _opAlimentador.ReleOperado = (short)(_cbxReleOperado.SelectedIndex == 1 ? 1 : 0);
                _opAlimentador.CodEdac = _edacAsociado == null ? 0 : _edacAsociado.PkCodEdac;

                if (ModeloMgr.Instancia.OperacionAlimentadorMgr.SolapaTiempos(_opAlimentador))
                {
                    _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("SOLAPA_FECH_ALIM"));
                    _errorProvider.SetError(_txtFechaHoraCierre, MessageMgr.Instance.GetMessage("SOLAPA_FECH_ALIM"));
                }
                else
                {
                    ModeloMgr.Instancia.OperacionAlimentadorMgr.Guardar(_opAlimentador);
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
            
            if (_ctrlComponenteComprometido.Componente == null)
            {
                _errorProvider.SetError(_ctrlComponenteComprometido, MessageMgr.Instance.GetMessage("INGRESE_ALIMENTADOR"));
                resultado = false;
            }

            if (_cbxTipoOpeAper.SelectedValue == null)
            {
                _errorProvider.SetError(_cbxTipoOpeAper, MessageMgr.Instance.GetMessage("SELECCIONE_TIPO_OPER"));
                resultado = false;
            }

            if (_cbxTipoOperCierre.SelectedValue == null)
            {
                _errorProvider.SetError(_cbxTipoOperCierre, MessageMgr.Instance.GetMessage("SELECCIONE_TIPO_OPER"));
                resultado = false;
            }

            bool compararAperturaConCierre = true;
            if (_txtFechaHoraAp.EsFechaValida())
            {
                if (_txtFechaHoraAp.Value < _regFalla.FecInicio)
                {
                    _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("NO_FECH_AP_ANTERIOR"));
                    resultado = false;
                    compararAperturaConCierre = false;
                }
            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA_HORA_AP"));
                compararAperturaConCierre = false;
                resultado = false;
            }

            if (_txtFechaHoraCierre.EsFechaValida())
            {
                if (_txtFechaHoraCierre.Value > DateTime.Now)
                {
                    _errorProvider.SetError(_txtFechaHoraCierre, MessageMgr.Instance.GetMessage("NO_FECH_CI_POSTERIOR"));
                    compararAperturaConCierre = false;
                    resultado = false;
                }
            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraCierre, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA_HORA_CIERRE"));
                compararAperturaConCierre = false;
                resultado = false;
            }

            if (compararAperturaConCierre && _txtFechaHoraCierre.Value < _txtFechaHoraAp.Value)
            {
                _errorProvider.SetError(_txtFechaHoraCierre, MessageMgr.Instance.GetMessage("CIERRE_DEBE_SER_POST_APERTURA"));
                resultado = false;
            }

            return resultado;
        }

        private void _cbxReleOperado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbxReleOperado.SelectedIndex > 0 && _ctrlComponenteComprometido.Componente == null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("INGRESE_ALIMENTADOR"));
                _cbxReleOperado.SelectedIndex = -1;
                return;
            }

            if (_cbxReleOperado.SelectedIndex == 1)
            {
                _edacAsociado = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetEdac(_ctrlComponenteComprometido.Componente.PkCodComponente, _txtFechaHoraAp.Value);
                if (_edacAsociado == null)
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("NO_RELE_ASOCIADO_ALIM"));
                    _cbxReleOperado.SelectedIndex = 0;
                }
                else
                {
                    _lblEtapa.Text = _edacAsociado.Etapa;
                    _lblFrecuencia.Text = _edacAsociado.Frecuencia;
                    _lblTiempoRele.Text = _edacAsociado.Tiempo.ToString("N2");
                }
            }
            else
            {
                _lblEtapa.Text = string.Empty;
                _lblTiempoRele.Text = string.Empty;
                _lblFrecuencia.Text = string.Empty;
            }
        }

        private void _dtpFechaHoraAp_ValueChanged(object sender, EventArgs e)
        {
            CalcularTiempoTotalDesc();
        }

        private void _dtpFechaHoraCierre_ValueChanged(object sender, EventArgs e)
        {
            CalcularTiempoTotalDesc();
        }

        private void CalcularTiempoTotalDesc()
        {
            TimeSpan t = _txtFechaHoraCierre.Value - _txtFechaHoraAp.Value;
            float minutos=(float)(t.TotalMinutes);
            _txtTiempoTDesc.Text = minutos.ToString("N2");
            float energiaNoSuministrada = (minutos / 60) * _txtPotDesc.Value;
            _lblEnergiaNoSuminis.Text = energiaNoSuministrada.ToString("N2");
        }

        private void _txtPotDesc_TextChanged(object sender, EventArgs e)
        {
            CalcularTiempoTotalDesc();
        }

        private void _txtFechaHoraAp_Validating(object sender, CancelEventArgs e)
        {
            _errorProvider.SetError(_txtFechaHoraAp, string.Empty);
            if (_txtFechaHoraAp.EsFechaValida())
            {

            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA_HORA_AP"));
                e.Cancel = true;
            }
        }

        private void _txtFechaHoraCierre_Validating(object sender, CancelEventArgs e)
        {
            _errorProvider.SetError(_txtFechaHoraCierre, string.Empty);
            if (_txtFechaHoraCierre.EsFechaValida())
            {

            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraCierre, MessageMgr.Instance.GetMessage("VERIFIQUE_FECHA_HORA_CIERRE"));
                e.Cancel = true;
            }
        }

        #region IOperacionAlimentador
        public decimal DCodTipoOpCierre
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cbxTipoOperCierre.SelectedValue); }
            set { _cbxTipoOperCierre.SelectedValue = value; }
        }

        public decimal DCodTipoOperAper
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cbxTipoOpeAper.SelectedValue); }
            set { _cbxTipoOpeAper.SelectedValue = value; }
        }

        public DateTime FechaApertura
        {
            get { return _txtFechaHoraAp.Value; }
            set { _txtFechaHoraAp.Value = value; }
        }

        public DateTime FechaCierre
        {
            get { return _txtFechaHoraCierre.Value; }
            set { _txtFechaHoraCierre.Value = value; }
        }

        public long PkCodComponente
        {
            get { return (long)_ctrlComponenteComprometido.PkCodComponente; }
            set { _ctrlComponenteComprometido.PkCodComponente = value; }
        }

        public float PotDesc
        {
            get { return _txtPotDesc.Value; }
            set { _txtPotDesc.Value = value; }
        }

        public short ReleOperado
        {
            get { return (short)_cbxReleOperado.SelectedIndex; }
            set { _cbxReleOperado.SelectedIndex = value; }
        }
        #endregion IOperacionAlimentador

        protected override bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (DCodTipoOpCierre != _opAlimentador.DCodTipoOpCierre)
            {
                resultado = true;
            }

            if (DCodTipoOperAper != _opAlimentador.DCodTipoOperAper)
            {
                resultado = true;
            }

            if (FechaApertura != _opAlimentador.FechaApertura)
            {
                resultado = true;
            }

            if (FechaCierre != _opAlimentador.FechaCierre)
            {
                resultado = true;
            }

            if (PkCodComponente != _opAlimentador.PkCodComponente)
            {
                resultado = true;
            }

            if (PotDesc != _opAlimentador.PotDesc)
            {
                resultado = true;
            } 
            
            if (ReleOperado != _opAlimentador.ReleOperado)
            {
                resultado = true;
            } 
            
            return resultado;
        }

        private void _txtFechaHoraAp_TextChanged(object sender, EventArgs e)
        {
            if (_txtFechaHoraAp.EsFechaValida()&&_txtFechaHoraCierre.EsFechaValida())
            {
                CalcularTiempoTotalDesc();
            }
        }
    }
}
