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
    public partial class FormAsigResp : BaseForm
    {
        AsignacionResposabilidad _tAsigResp;
        DataTable _tablaAgentes;
        Persona _agenteSeleccionado;
        List<long> listaCodPersonasNoUsuables;
        const int PK_COD_PERSONA_AE = 26;
        const int PK_COD_PERSONA_CNDC = 7;

        public FormAsigResp()
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
                _tablaAgentes = ModeloMgr.Instancia.PersonaMgr.GetAgentes();//ModeloMgr.Instancia.RegFallaMgr.GetAgentesInvolucrados(_tAsigResp.PkCodFalla);
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
                _tablaAgentes = ModeloMgr.Instancia.PersonaMgr.GetAgentes();//ModeloMgr.Instancia.PersonaMgr.GetAgentes(Sesion.Instancia.EmpresaActual.PkCodPersona);
            }
            _dgvAgentes.DataSource = _tablaAgentes;
            BaseForm.VisualizarColumnas(_dgvAgentes, ColumnStyleManger.GetEstilos("FormAdiTiempo", "_dgvAgentes"));
        }

        public DialogResult Editar(AsignacionResposabilidad a, List<long> codPersonas)
        {
            _tAsigResp = a;
            listaCodPersonasNoUsuables = codPersonas;
            CargarAgentes();
            VisualizarTiempo();
            return ShowDialog();
        }

        private void VisualizarTiempo()
        {
            BindingContext[_dgvAgentes.DataSource].Position = GetIdxAgente();
            _txtTAsigResp.Value = _tAsigResp.Tiempo;
            //_dgvAgentes.Enabled = _tAsigResp.EsNuevo;
        }

        private int GetIdxAgente()
        {
            int resultado = 0;
            if (_tAsigResp.PkCodPersonaResponsable == 0)
            {
                return resultado;
            }

            for (int i = 0; i < _tablaAgentes.Rows.Count; i++)
            {
                if ((long)_tablaAgentes.Rows[i][Persona.C_PK_COD_PERSONA] == _tAsigResp.PkCodPersonaResponsable)
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
                _tAsigResp.PkCodPersonaResponsable = _agenteSeleccionado.PkCodPersona;
                _tAsigResp.Tiempo = _txtTAsigResp.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();

            if (_txtTAsigResp.Value <= 0)
            {
                _errorProvider.SetError(_txtTAsigResp, MessageMgr.Instance.GetMessage("INGRESE_TIEMPO_POSITIVO"));
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

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void _dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvAgentes.SelectedRows[0].DataBoundItem;
                _agenteSeleccionado = new Persona(drView.Row);
            }
        }
    }
}
