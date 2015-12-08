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
using BLL;

namespace SISFALLA
{
    public partial class CtrlAsignacionResponsabilidad : UserControl
    {
        private RRegFallaComponente _compComprometido;
        private DataTable _tablaAsigResp;
        private DataRow _rowSeleccionado = null;
        private List<DataRow> _nuevos = new List<DataRow>();
        private List<DataRow> _eliminados = new List<DataRow>();
        private List<DataRow> _modificados = new List<DataRow>();
        private List<AsignacionResposabilidad> _asignacionesEliminadas = new List<AsignacionResposabilidad>();
        private AsignacionResposabilidad _asignacionSeleccionada;

        public CtrlAsignacionResponsabilidad()
        {
            InitializeComponent();
        }

        public bool PanelToolVisible
        {
            get { return _pnlTool.Visible; }
            set { _pnlTool.Visible = value; }
        }
        
        float _tiempoTotalSistema;
        public float TiempoTotalSistema
        {
            get { return _tiempoTotalSistema; }
            set { _tiempoTotalSistema = value; }
        }
        
        private bool _soloLectura;
        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                _txtPorOperacion.Enabled = !_soloLectura;
                _txtPorSistema.Enabled = !_soloLectura;
            }
        }

        public float TiempoPOper
        {
            get { return _txtPorOperacion.Value; }
            set { _txtPorOperacion.Value = value; }
        }

        public float TiempoPSist
        {
            get { return _txtPorSistema.Value; }
            set { _txtPorSistema.Value = value; }
        }

        public void VisualizarAsigResp(RRegFallaComponente compComprometido)
        {
            _compComprometido = compComprometido;
            _tablaAsigResp = ModeloMgr.Instancia.AsignacionResposabilidadMgr.GetAsigResp(_compComprometido);
            _dgvAsigResp.DataSource = _tablaAsigResp;
            BaseForm.VisualizarColumnas(_dgvAsigResp, ColumnStyleManger.GetEstilos("CtrlAsignacionResponsabilidad", "_dgvAsigResp"));
            _txtPorOperacion.Value = compComprometido.TiempoPOper;
            _txtPorSistema.Value = compComprometido.TiempoPSist;
            CalcularTiempoTotal();
        }

        private void CalcularTiempoTotal()
        {
            _tiempoTotalSistema = 0;
            foreach (DataRow r in _tablaAsigResp.Rows)
            {
                _tiempoTotalSistema += ObjetoDeNegocio.GetValor<float>(r[AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD]);
            }
            _tiempoTotalSistema += _txtPorOperacion.Value;
            _tiempoTotalSistema += _txtPorSistema.Value;
            _txtTTotal.Value = _tiempoTotalSistema;
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            AsignacionResposabilidad tiempo = _compComprometido.GetNuevoAsignacionResp();
            FormAsigResp frmAdAsigResp = new FormAsigResp();
            if (frmAdAsigResp.Editar(tiempo, GetCodPersonaAsignadas()) == DialogResult.OK)
            {
                DataRow r = _tablaAsigResp.NewRow();
                tiempo.Llenar(r);
                r[Persona.C_SIGLA] = frmAdAsigResp.AgenteSeleccionado.Sigla;
                _nuevos.Add(r);
                _tablaAsigResp.Rows.Add(r);
                CalcularTiempoTotal();
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_asignacionSeleccionada != null)
            {
                FormAsigResp frmAsigResp = new FormAsigResp();
                if (frmAsigResp.Editar(_asignacionSeleccionada, new List<long>()) == DialogResult.OK)
                {
                    _asignacionSeleccionada.Llenar(_rowSeleccionado);
                    _rowSeleccionado[Persona.C_SIGLA] = frmAsigResp.AgenteSeleccionado.Sigla;
                    if (!_nuevos.Contains(_rowSeleccionado) && !_modificados.Contains(_rowSeleccionado))
                    {
                        _modificados.Add(_rowSeleccionado);
                    }
                    CalcularTiempoTotal();
                }
            }
        }

        public List<long> GetCodPersonaAsignadas()
        {
            List<long> resultado = new List<long>();

            foreach (DataRow r in _tablaAsigResp.Rows)
            {
                long pkcodPersona = (long)r[AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE];
                resultado.Add(pkcodPersona);
            }
            return resultado;
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            if (_asignacionSeleccionada != null && BaseForm.EstaSeguro())
            {
                _nuevos.Remove(_rowSeleccionado);
                _modificados.Remove(_rowSeleccionado);
                _eliminados.Add(_rowSeleccionado);
                _asignacionesEliminadas.Add(_asignacionSeleccionada);
                _asignacionSeleccionada = null;
                _tablaAsigResp.Rows.Remove(_rowSeleccionado);
            }
        }

        private void _dgvAsigResp_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAsigResp.SelectedRows.Count > 0)
            {
                _rowSeleccionado = ((DataRowView)_dgvAsigResp.SelectedRows[0].DataBoundItem).Row;
                _asignacionSeleccionada = new AsignacionResposabilidad(_rowSeleccionado);
                _asignacionSeleccionada.EsNuevo = _nuevos.Contains(_rowSeleccionado);
            }
        }

        public void Guardar()
        {
            foreach (DataRow r in _nuevos)
            {
                AsignacionResposabilidad asignacion = new AsignacionResposabilidad(r);
                asignacion.PkCodComponente = _compComprometido.PkCodComponente;
                asignacion.FecApertura = _compComprometido.FecApertura;
                asignacion.EsNuevo = true;
                ModeloMgr.Instancia.AsignacionResposabilidadMgr.Guardar(asignacion);
            }

            foreach (DataRow r in _modificados)
            {
                AsignacionResposabilidad asignacion = new AsignacionResposabilidad(r);
                asignacion.PkCodComponente = _compComprometido.PkCodComponente;
                asignacion.EsNuevo = false;
                ModeloMgr.Instancia.AsignacionResposabilidadMgr.Guardar(asignacion);
            }

            foreach (AsignacionResposabilidad a in _asignacionesEliminadas)
            {
                a.PkCodComponente = _compComprometido.PkCodComponente;
                a.EsNuevo = false;
                ModeloMgr.Instancia.AsignacionResposabilidadMgr.Eliminar(a);
            }
        }

        private void _txtPorOperacion_Validated(object sender, EventArgs e)
        {
            CalcularTiempoTotal();
        }
    }
}
