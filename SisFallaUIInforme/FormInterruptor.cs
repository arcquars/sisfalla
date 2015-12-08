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
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class FormInterruptor : ABMBaseForm, IOperacionInterruptores
    {
        RelesOperados _releSeleccionado;
        OperacionInterruptores _opInterruptor;
        BindingList<RelesOperados> _listaRelesOperados;
        List<RelesOperados> _listaRelesBorrados = new List<RelesOperados>();
        RegFalla _regFalla;
        public FormInterruptor()
        {
            InitializeComponent();
            _cbxTipoOpeAper.DisplayMember = DefDominio.C_DESCRIPCION;
            _cbxTipoOpeAper.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxTipoOpeAper.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_TIPO_OPERACION);

            _cbxTipoOpeCierre.DisplayMember = DefDominio.C_DESCRIPCION;
            _cbxTipoOpeCierre.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxTipoOpeCierre.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_TIPO_OPERACION);

            List<D_TIPO_COMPONENTE> filtroInterruptores = new List<D_TIPO_COMPONENTE>();
            filtroInterruptores.Add(D_TIPO_COMPONENTE.IG);
            filtroInterruptores.Add(D_TIPO_COMPONENTE.IT);
            _ctrlComponenteComprometido.SetFiltroTipo(filtroInterruptores);

            _txtMiliSegApertura.MaxLength = 3;
            _txtMiliSegCierre.MaxLength = 3;
        }

        public DialogResult Editar(OperacionInterruptores opInterruptor, List<long> listaInterruptoresUsados)
        {
            _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            _opInterruptor = opInterruptor;
            _ctrlComponenteComprometido.SetComponenteNoSeleccionables(listaInterruptoresUsados);
            VisualizarInterruptor();
            return ShowDialog();
        }

        private void VisualizarInterruptor()
        {
            _ctrlComponenteComprometido.VisualizarComponente(_opInterruptor.PkCodComponente);
            _ctrlComponenteComprometido.Enabled = _opInterruptor.EsNuevo;
            _txtFechaHoraAp.Value = _opInterruptor.FechaApertura;
            _txtFechaHoraCi.Value = _opInterruptor.FechaCierre;

            _txtMiliSegApertura.Value = _opInterruptor.FechaApertura.Millisecond;
            _txtMiliSegCierre.Value = _opInterruptor.FechaCierre.Millisecond;
            _listaRelesOperados = ModeloMgr.Instancia.RelesOperadosMgr.GetLista(_opInterruptor);
            _dgvRelesOperados.AutoGenerateColumns = true;
            _dgvRelesOperados.DataSource = _listaRelesOperados;
            _dgvRelesOperados.AutoGenerateColumns = false ;

            BaseForm.VisualizarColumnas(_dgvRelesOperados, ColumnStyleManger.GetEstilos("FormIngresarEditarInterruptor", "_dgvRelesOperados"));
            _cbxTipoOpeAper.SelectedValue = _opInterruptor.PkDCodTipoOperAper;
            _cbxTipoOpeCierre.SelectedValue = _opInterruptor.PkDCodTipoOperCierre;

            _rbtnSI.Checked = _opInterruptor.Reconectado == 1;
            _rbtnNo.Checked = _opInterruptor.Reconectado == 0;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosValidos())
            {
                DateTime fechaAperturaAnterior = _opInterruptor.FechaApertura;
                _opInterruptor.FechaApertura = GetConMilisegundos(_txtFechaHoraAp.Value, _txtMiliSegApertura.Value);
                _opInterruptor.FechaCierre = GetConMilisegundos(_txtFechaHoraCi.Value, _txtMiliSegCierre.Value);
                _opInterruptor.PkCodComponente = (long)_ctrlComponenteComprometido.Componente.PkCodComponente;
                _opInterruptor.PkDCodTipoOperAper = (long)_cbxTipoOpeAper.SelectedValue;
                _opInterruptor.PkDCodTipoOperCierre = (long)_cbxTipoOpeCierre.SelectedValue;
                _opInterruptor.Reconectado = (short)(_rbtnSI.Checked ? 1 : 0);

                if (ModeloMgr.Instancia.OperacionInterruptoresMgr.SolapaTiempos(_opInterruptor))
                {
                    _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("SOLAPA_FECH_INTERRUP"));
                    _errorProvider.SetError(_txtFechaHoraCi, MessageMgr.Instance.GetMessage("SOLAPA_FECH_INTERRUP"));
                }
                else
                {
                    if (!_opInterruptor.EsNuevo && fechaAperturaAnterior != _opInterruptor.FechaApertura)
                    {
                        DateTime fechaTemp = _opInterruptor.FechaApertura;
                        _opInterruptor.FechaApertura = fechaAperturaAnterior;
                        ModeloMgr.Instancia.OperacionInterruptoresMgr.Borrar(_opInterruptor);
                        _opInterruptor.FechaApertura = fechaTemp;
                        _opInterruptor.EsNuevo = true;
                        foreach (var item in _listaRelesOperados)
                        {
                            item.EsNuevo = true;
                        }
                    }

                    ModeloMgr.Instancia.OperacionInterruptoresMgr.Guardar(_opInterruptor);

                    foreach (var item in _listaRelesBorrados)
                    {
                        ModeloMgr.Instancia.RelesOperadosMgr.Borrar(item);
                    }

                    foreach (var item in _listaRelesOperados)
                    {
                        item.PkCodComponente = (long)_opInterruptor.PkCodComponente;
                        item.FecApertura = _opInterruptor.FechaApertura;
                        ModeloMgr.Instancia.RelesOperadosMgr.Guardar(item);
                    }

                    resultado = true;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            return resultado;
        }

        private DateTime GetConMilisegundos(DateTime d, int m)
        {
            d = d.AddMilliseconds(-d.Millisecond);
            d = d.AddMilliseconds(m);
            return d;
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            int deltaTiempo = ModeloMgr.Instancia.InformeFallaMgr.DeltaTiempoIngresoComponentesMinutos;
            if (_ctrlComponenteComprometido.Componente == null)
            {
                _errorProvider.SetError(_ctrlComponenteComprometido, MessageMgr.Instance.GetMessage("SELEC_INTERRUP"));
                resultado = false;
            }

            if (_cbxTipoOpeAper.SelectedIndex < 0)
            {
                _errorProvider.SetError(_cbxTipoOpeAper, MessageMgr.Instance.GetMessage("SELEC_TIPO_APERTURA"));
                resultado = false;
            }

            if (_cbxTipoOpeCierre.SelectedIndex < 0)
            {
                _errorProvider.SetError(_cbxTipoOpeCierre, MessageMgr.Instance.GetMessage("SELEC_TIPO_CIERRE"));
                resultado = false;
            }

            DateTime fechaApertura = GetFecha(_txtFechaHoraAp.Value, _txtMiliSegApertura.Value);
            DateTime fechaCierre = GetFecha(_txtFechaHoraCi.Value, _txtMiliSegCierre.Value);
            bool compararAperturaCierre = true;
            if (fechaApertura < _regFalla.FecInicio.AddMinutes(-1 * deltaTiempo))
            {
                _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("NO_FECH_HORA_AP_ANTERIOR"));
                resultado = false;
                compararAperturaCierre = false;
            }

            if (fechaCierre > DateTime.Now)
            {
                _errorProvider.SetError(_txtFechaHoraCi, MessageMgr.Instance.GetMessage("NO_FECHA_HORA_CI_POSTERIOR"));
                resultado = false;
                compararAperturaCierre = false;
            }

            if (compararAperturaCierre && fechaApertura > fechaCierre)
            {
                _errorProvider.SetError(_txtFechaHoraAp, MessageMgr.Instance.GetMessage("NO_FECHA_HORA_AP_POSTERIOR"));
                resultado = false;
            }

            return resultado;
        }

        private DateTime GetFecha(DateTime dateTime, int milisegundos)
        {
            dateTime = dateTime.AddMilliseconds(-dateTime.Millisecond);
            dateTime = dateTime.AddMilliseconds(milisegundos);
            return dateTime;
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            if (_ctrlComponenteComprometido.Componente == null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("SELEC_INTERRUP"));
                return;
            }

            RelesOperados rele = _opInterruptor.CrearNuevoReleOperado();
            FormReleOperado frm = new FormReleOperado();
            List<string> NoFiltroFunciones = new List<string>();
            if (frm.Editar(rele, NoFiltroFunciones) == DialogResult.OK)
            {
                _listaRelesOperados.Add(rele);
            }
        }

        public List<string> GetFuncionesUsadas()
        {
            List<string> resultado = new List<string>();
            foreach (RelesOperados r in _listaRelesOperados)
            {
                resultado.Add(r.Funcion);
            }
            return resultado;
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_releSeleccionado != null)
            {
                FormReleOperado frm = new FormReleOperado();
                if (frm.Editar(_releSeleccionado, new List<string>()) == DialogResult.OK)
                {
                    _dgvRelesOperados.Refresh();
                    //_listaRelesOperados.Add(rele);
                }
            }
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            if (_releSeleccionado != null && BaseForm.EstaSeguro())
            {
                if (!_releSeleccionado.EsNuevo)
                {
                    _listaRelesBorrados.Add(_releSeleccionado);
                }
                _listaRelesOperados.Remove(_releSeleccionado);
            }
        }

        private void _dgvRelesOperados_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvRelesOperados.SelectedRows.Count > 0)
            {
                _releSeleccionado = (RelesOperados)_dgvRelesOperados.SelectedRows[0].DataBoundItem;
            }
            else
            {
                _releSeleccionado = null;
            }
        }

        #region OperacionInterruptores
        public DateTime FechaApertura
        {
            get { return GetConMilisegundos(_txtFechaHoraAp.Value, _txtMiliSegApertura.Value); }
            set { _txtFechaHoraAp.Value = value; }
        }

        public DateTime FechaCierre
        {
            get { return GetConMilisegundos(_txtFechaHoraCi.Value, _txtMiliSegCierre.Value); }
            set { _txtFechaHoraCi.Value = value; }
        }

        public long PkCodComponente
        {
            get { return (long)_ctrlComponenteComprometido.PkCodComponente; }
            set { _ctrlComponenteComprometido.PkCodComponente = value; }
        }

        public long PkDCodTipoOperAper
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cbxTipoOpeAper.SelectedValue); }
            set { _cbxTipoOpeAper.SelectedValue = value; }
        }

        public long PkDCodTipoOperCierre
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cbxTipoOpeCierre.SelectedValue); }
            set { _cbxTipoOpeCierre.SelectedValue = value; }
        }

        public short Reconectado
        {
            get { return (short)(_rbtnSI.Checked ? 1 : 0); }
            set
            {
                _rbtnSI.Checked = value == 1;
                _rbtnNo.Checked = value == 0;
                
            }
        }
        #endregion OperacionInterruptores

        protected override bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (FechaApertura!=_opInterruptor.FechaApertura)
            {
                resultado = true;
            }

            if (FechaCierre != _opInterruptor.FechaCierre)
            {
                resultado = true;
            }

            if (PkCodComponente != _opInterruptor.PkCodComponente)
            {
                resultado = true;
            }

            if (PkDCodTipoOperAper != _opInterruptor.PkDCodTipoOperAper)
            {
                resultado = true;
            }

            if (PkDCodTipoOperCierre != _opInterruptor.PkDCodTipoOperCierre)
            {
                resultado = true;
            }

            if (Reconectado != _opInterruptor.Reconectado)
            {
                resultado = true;
            }
            return resultado;
        }

    }
}
