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
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class FormTiempo : BaseForm
    {
        TiempoDetalle _tiempo;
        DataTable _tablaAgentes;
        Persona _agenteSeleccionado;
        List<long> listaCodPersonasNoUsuables;
        float _maxIndis;
        float _maxPre;
        float _maxCon;
        const int PK_COD_PERSONA_AE = 26;
        const int PK_COD_PERSONA_CNDC = 7;
        public FormTiempo()
        {
            InitializeComponent();
            listaCodPersonasNoUsuables = new List<long>();
        }

        public Persona AgenteSeleccionado
        {
            get { return _agenteSeleccionado; }
        }

        private void CargarAgentes()
        {
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _tablaAgentes = ModeloMgr.Instancia.RegFallaMgr.GetAgentesInvolucrados(_tiempo.PkCodFalla);//ModeloMgr.Instancia.PersonaMgr.GetAgentes();
                long pkCodPersona = 0;
                for (int i = _tablaAgentes.Rows.Count - 1; i >= 0; i--)
                {
                    pkCodPersona = (long)_tablaAgentes.Rows[i]["PK_COD_PERSONA"];
                    if (pkCodPersona == PK_COD_PERSONA_AE || pkCodPersona == PK_COD_PERSONA_CNDC)
                    {
                        _tablaAgentes.Rows.RemoveAt(i);
                    }
                }
            }
            else
            {
                _tablaAgentes = ModeloMgr.Instancia.PersonaMgr.GetAgentes(Sesion.Instancia.EmpresaActual.PkCodPersona);
            }
            _dgvAgentes.DataSource = _tablaAgentes;
            BaseForm.VisualizarColumnas(_dgvAgentes, ColumnStyleManger.GetEstilos("FormAdiTiempo", "_dgvAgentes"));
        }

        public DialogResult Editar(TiempoDetalle tiempo, float maxIndis, float maxPre, float maxCon,List<long> codPersonas)
        {
            _tiempo = tiempo;
            _maxCon = maxCon;
            _maxIndis = maxIndis;
            _maxPre = maxPre;
            listaCodPersonasNoUsuables = codPersonas;
            CargarAgentes();
            VisualizarTiempo();
            return ShowDialog();
        }

        private void VisualizarTiempo()
        {
            BindingContext[_dgvAgentes.DataSource].Position = GetIdxAgente();

            _dgvAgentes.Enabled = _tiempo.EsNuevo;
            _txtTCon.Value = _tiempo.TiempoConexion;
            _txtTIndis.Value = _tiempo.TiempoIndisponibilidad;
            _txtTPreCon.Value = _tiempo.TiempoPreconexion;
        }

        private int GetIdxAgente()
        {
            int resultado = 0;
            if (_tiempo.PkCodPersona == 0)
            {
                return resultado;
            }

            for (int i = 0; i < _tablaAgentes.Rows.Count; i++)
            {
                if ((long)_tablaAgentes.Rows[i][Persona.C_PK_COD_PERSONA] == _tiempo.PkCodPersona)
                {
                    resultado = i;
                    break;
                }
            }
            return resultado;
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _tiempo.PkCodPersona = _agenteSeleccionado.PkCodPersona;
                _tiempo.TiempoConexion = _txtTCon.Value;
                _tiempo.TiempoIndisponibilidad = _txtTIndis.Value;
                _tiempo.TiempoPreconexion = _txtTPreCon.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_txtTIndis.Value > _maxIndis)
            {
                _errorProvider.SetError(_txtTIndis, MessageMgr.Instance.GetMessage("SUMA_TIEMPO_EXCEDE_TOTAL"));
                resultado = false;
            }

            if (_txtTPreCon.Value > _maxPre)
            {
                _errorProvider.SetError(_txtTPreCon, MessageMgr.Instance.GetMessage("SUMA_TIEMPO_EXCEDE_TOTAL"));
                resultado = false;
            }

            if (_txtTCon.Value > _maxCon)
            {
                _errorProvider.SetError(_txtTCon, MessageMgr.Instance.GetMessage("SUMA_TIEMPO_EXCEDE_TOTAL"));
                resultado = false;
            }

            if (_agenteSeleccionado == null)
            {
                _errorProvider.SetError(_dgvAgentes, MessageMgr.Instance.GetMessage("SELECCIONE_AGENTE"));
                resultado = false;
            }
            else if (listaCodPersonasNoUsuables.Contains(_agenteSeleccionado.PkCodPersona))
            {
                _errorProvider.SetError(_dgvAgentes, MessageMgr.Instance.GetMessage("AGENTE_YA_USADO"));
                resultado = false;
            }
            return resultado;
        }

        private void _dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvAgentes.SelectedRows[0].DataBoundItem;
                _agenteSeleccionado = new Persona(drView.Row);
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
