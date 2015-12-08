using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BaseForms;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class CtrlTiempoDetalle : UserControl
    {
        private TiempoDetalle _tiempoSeleccionado = null;
        private RRegFallaComponente _compComprometido;
        private DataRow _rowSeleccionado = null;
        List<DataRow> _nuevos = new List<DataRow>();
        List<DataRow> _eliminados = new List<DataRow>();
        List<DataRow> _modificados = new List<DataRow>();
        Dictionary<DataRow, TiempoDetalle> _dicTiemposDetalle = new Dictionary<DataRow, TiempoDetalle>();
        List<TiempoDetalle> _tiemposEliminados = new List<TiempoDetalle>();
        DataTable _tablaTiempos;

        public CtrlTiempoDetalle()
        {
            InitializeComponent();
            _dgvTiempos.Name = "_dgvTiempos";
        }

        private bool _soloLectura;
        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                _txtTiempoTotalIndis.Enabled = !_soloLectura;
                _txtTiempoTotalPre.Enabled = !_soloLectura;
                _txtTiempoTotalCon.Enabled = !_soloLectura;
            }
        }

        public bool PanelToolVisible
        {
            get { return _pnlTool.Visible; }
            set { _pnlTool.Visible = value; }
        }

        public float TiempoTotalDesconexion
        {
            get { return TiempoIndisponibilidad + TiempoPreconexion + TiempoConexion; }
        }

        public event EventHandler<TiempoTotalDesconexionEventArgs> TiempoTotalDesconexionModificado;
        protected void OnTiempoTotalDesconexionModificado()
        {
            if (TiempoTotalDesconexionModificado != null)
            {
                TiempoTotalDesconexionModificado(this, new TiempoTotalDesconexionEventArgs(TiempoTotalDesconexion));
            }
        }

        public void VisualizarTiempos(RRegFallaComponente compComprometido)
        {
            _compComprometido = compComprometido;

            _tablaTiempos = ModeloMgr.Instancia.TiempoDetalleMgr.GetTiempos(_compComprometido);
            CargarDiccionarioTiempos();
            _dgvTiempos.DataSource = _tablaTiempos;
            BaseForm.VisualizarColumnas(_dgvTiempos, ColumnStyleManger.GetEstilos("CtrlTiempoDetalle", _dgvTiempos.Name));

            _txtTiempoTotalIndis.Value = _compComprometido.TiempoIndisponibilidad;
            _txtTiempoTotalPre.Value = _compComprometido.TiempoPreconexion;
            _txtTiempoTotalCon.Value = _compComprometido.TiempoConexion;
        }

        private void CargarDiccionarioTiempos()
        {
            foreach (DataRow r in _tablaTiempos.Rows)
            {
                _dicTiemposDetalle[r] = new TiempoDetalle(r);
            }
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            if (TiemposValidos())
            {
                TiempoDetalle tiempo = _compComprometido.GetNuevoTiempo();
                FormTiempo frmAdTiempo = new FormTiempo();
                if (frmAdTiempo.Editar(tiempo, _txtTSisIndis.Value, _txtTSisPre.Value, _txtTSisCon.Value, GetCodPersonaAsignadas()) == DialogResult.OK)
                {
                    DataRow r = _tablaTiempos.NewRow();
                    tiempo.Llenar(r);
                    r[Persona.C_SIGLA] = frmAdTiempo.AgenteSeleccionado.Sigla;
                    _nuevos.Add(r);
                    _tablaTiempos.Rows.Add(r);
                }
                AjustarTiemposSistema();
            }
        }

        public List<long> GetCodPersonaAsignadas()
        {
            List<long> resultado = new List<long>();

            foreach (DataRow r in _tablaTiempos.Rows)
            {
                long pkcodPersona = (long)r[Persona.C_PK_COD_PERSONA];
                resultado.Add(pkcodPersona);
            }
            return resultado;
        }

        private void AjustarTiemposSistema()
        {
            _errorProvider.Clear();
            _txtTSisIndis.Value = _txtTiempoTotalIndis.Value - Sumatoria(TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD);
            if (_txtTSisIndis.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalIndis, MessageMgr.Instance.GetMessage("TTOTAL_INDIS_INVALIDO"));
            }

            _txtTSisPre.Value = _txtTiempoTotalPre.Value - Sumatoria(TiempoDetalle.C_TIEMPO_PRECONEXION);
            if (_txtTSisPre.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalPre, MessageMgr.Instance.GetMessage("TTOTAL_PRE_INVALIDO"));
            }

            _txtTSisCon.Value = _txtTiempoTotalCon.Value - Sumatoria(TiempoDetalle.C_TIEMPO_CONEXION);
            if (_txtTSisCon.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalCon, MessageMgr.Instance.GetMessage("TTOTAL_CON_INVALIDO"));
            }

        }

        private bool TiemposValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_txtTiempoTotalIndis.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalIndis, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                resultado = false;
            }

            if (_txtTiempoTotalPre.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalPre, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                resultado = false;
            }

            if (_txtTiempoTotalCon.Value < 0)
            {
                _errorProvider.SetError(_txtTiempoTotalCon, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                resultado = false;
            }
            return resultado;
        }

        public void SetNuevo()
        {
            _modificados.Clear();
             foreach (KeyValuePair<DataRow,TiempoDetalle> t in _dicTiemposDetalle)
            { 
                t.Value.EsNuevo  = true ;
                if (!_nuevos.Contains(t.Key) && !_eliminados.Contains(t.Key))
                {
                    _nuevos.Add(t.Key);
                }
            }

        }
        public void Guardar()
        {
            foreach (DataRow r in _nuevos)
            {
                TiempoDetalle t = new TiempoDetalle(r);
                t.PkCodComponente = _compComprometido.PkCodComponente;
                t.FecApertura = _compComprometido.FecApertura;
                t.EsNuevo = true;
                ModeloMgr.Instancia.TiempoDetalleMgr.Guardar(t);
            }

            foreach (DataRow r in _modificados)
            {
                TiempoDetalle t = _dicTiemposDetalle[r];
                if (t.PkCodPersonaAnterior != t.PkCodPersona)
                {
                    long pkCodPersonaTmp = t.PkCodPersona;
                    t.PkCodPersona = t.PkCodPersonaAnterior;
                    ModeloMgr.Instancia.TiempoDetalleMgr.Eliminar(t);
                    t.PkCodPersona = pkCodPersonaTmp;
                    t.EsNuevo = true;
                }
                ModeloMgr.Instancia.TiempoDetalleMgr.Guardar(t);
            }

            foreach (TiempoDetalle t in _tiemposEliminados)
            {
                t.PkCodComponente = _compComprometido.PkCodComponente;
                t.EsNuevo = false;
                ModeloMgr.Instancia.TiempoDetalleMgr.Eliminar(t);
            }
        }

        private void _dgvTiempos_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvTiempos.SelectedRows.Count > 0)
            {
                _rowSeleccionado = ((DataRowView)_dgvTiempos.SelectedRows[0].DataBoundItem).Row;
                if (_dicTiemposDetalle.ContainsKey(_rowSeleccionado))
                {
                    _tiempoSeleccionado = _dicTiemposDetalle[_rowSeleccionado];
                }
                else
                {
                    _tiempoSeleccionado = new TiempoDetalle(_rowSeleccionado);
                    _tiempoSeleccionado.EsNuevo = _nuevos.Contains(_rowSeleccionado);
                }
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_tiempoSeleccionado != null)
            {
                FormTiempo frmAdTiempo = new FormTiempo();
                float maxIndis = _txtTSisIndis.Value + _tiempoSeleccionado.TiempoIndisponibilidad;
                float maxPreCon = _txtTSisPre.Value + _tiempoSeleccionado.TiempoPreconexion;
                float maxCon = _txtTSisCon.Value + _tiempoSeleccionado.TiempoConexion;

                List<long> personasAsignadas = GetCodPersonaAsignadas();
                personasAsignadas.Remove(_tiempoSeleccionado.PkCodPersona);
                if (frmAdTiempo.Editar(_tiempoSeleccionado, maxIndis, maxPreCon, maxCon, personasAsignadas) == DialogResult.OK)
                {
                    _tiempoSeleccionado.Llenar(_rowSeleccionado);
                    _rowSeleccionado[Persona.C_SIGLA] = frmAdTiempo.AgenteSeleccionado.Sigla;
                    if (!_nuevos.Contains(_rowSeleccionado) && !_modificados.Contains(_rowSeleccionado))
                    {
                        _modificados.Add(_rowSeleccionado);
                    }
                    AjustarTiemposSistema();
                }
            }
        }

        private void _txtTiempoTotalIndis_TextChanged(object sender, EventArgs e)
        {
            AjustarTiemposSistema();
            OnTiempoTotalDesconexionModificado();
        }

        private float Sumatoria(string p)
        {
            float resultado = 0;
            if (_tablaTiempos != null)
            {
                foreach (DataRow r in _tablaTiempos.Rows)
                {
                    resultado += ObjetoDeNegocio.GetValor<float>(r[p]);
                }
            }
            return resultado;
        }

        public float TiempoIndisponibilidad
        {
            get { return _txtTiempoTotalIndis.Value; }
            set { _txtTiempoTotalIndis.Value = value; }
        }
        public float TiempoPreconexion
        {
            get { return _txtTiempoTotalPre.Value; }
            set { _txtTiempoTotalPre.Value = value; }
        }
        public float TiempoConexion
        {
            get { return _txtTiempoTotalCon.Value; }
            set { _txtTiempoTotalCon.Value = value; }
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            if (_rowSeleccionado != null && BaseForm.EstaSeguro())
            {
                _nuevos.Remove(_rowSeleccionado);
                _modificados.Remove(_rowSeleccionado);
                _eliminados.Add(_rowSeleccionado);
                _tiemposEliminados.Add(_tiempoSeleccionado);
                _tiempoSeleccionado = null;
                _tablaTiempos.Rows.Remove(_rowSeleccionado);
            }
        }

        private void _dgvTiempos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.Value is float)
            {
                float valor = (float)e.Value;
                if (valor == 0f)
                {
                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }
    }

    public class TiempoTotalDesconexionEventArgs : EventArgs
    {
        float _dato;
        public TiempoTotalDesconexionEventArgs(float dato)
        {
            _dato = dato;
        }

        public float Dato
        { get { return _dato; } }
    }
}
