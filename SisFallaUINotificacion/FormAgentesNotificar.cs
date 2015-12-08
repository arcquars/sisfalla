using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.BaseForms;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormAgentesNotificar : BaseForm
    {
        BindingList<Persona> _agentesNotificados;
        BindingList<Persona> _agentesSinNotificar;
        int _idxSinNotificar;
        public FormAgentesNotificar()
        {
            InitializeComponent();
        }

        public BindingList<Persona> Visualizar(BindingList<Persona> notificados, BindingList<Persona> sinNotificar)
        {
            _dgvAgentesDisponibles.DataSource = notificados;
            BaseForm.VisualizarColumnas(_dgvAgentesDisponibles, GetConfColAgentes());
            _dgvAgentesANotificar.DataSource = sinNotificar;
            BaseForm.VisualizarColumnas(_dgvAgentesANotificar, GetConfColAgentes());
            _idxSinNotificar = sinNotificar.Count;
            _agentesSinNotificar = sinNotificar;
            _agentesNotificados = notificados;

            _lblAgentesYaNotificados.Text = MessageMgr.Instance.GetMessage("AGENTES_YA_NOTIFICADOS");
            _lblAgentesPorNotificar.Text = MessageMgr.Instance.GetMessage("AGENTES_POR_NOTIFICAR");
            if (ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return _agentesSinNotificar;
            }
            else
            {
                return null;
            }
        }

        private Dictionary<string, int> GetConfColAgentes()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            resultado["Sigla"] = 70;
            resultado["Nombre"] = 240;
            return resultado;
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            LimpiarLblsMensaje();
            
            if (_dgvAgentesDisponibles.SelectedRows.Count == 0)
            {
                _lblMensajeLista1.Text = MessageMgr.Instance.GetMessage("SELECCION_UN_ELEM");
            }
            else
            {
                MoverElementos(_agentesNotificados ,_agentesSinNotificar, _dgvAgentesDisponibles, _dgvAgentesANotificar);
            }
        }

        private void _btnQuitar_Click(object sender, EventArgs e)
        {
            LimpiarLblsMensaje();
            if (_dgvAgentesANotificar.SelectedRows.Count == 0)
            {
                _lblMensajeLista2.Text = MessageMgr.Instance.GetMessage("SELECCION_UN_ELEM");
            }
            else
            {
                MoverElementos(_agentesSinNotificar, _agentesNotificados, _dgvAgentesANotificar, _dgvAgentesDisponibles);
            }
        }

        private void LimpiarLblsMensaje()
        {
            _lblMensajeLista1.Text = string.Empty;
            _lblMensajeLista2.Text = string.Empty;
        }

        private void MoverElementos(BindingList<Persona> origen, BindingList<Persona> destino, DataGridView dgvOrigen, DataGridView dgvDestino)
        {
            foreach (DataGridViewRow row in dgvOrigen.SelectedRows)
            {
                Persona p = (Persona)row.DataBoundItem;
                if (origen == _agentesNotificados || _agentesSinNotificar.IndexOf(p) >=_idxSinNotificar )
                {
                    destino.Add(p);
                    origen.Remove(p);
                }
            }
            dgvOrigen.Refresh();
            dgvDestino.Refresh();
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (_agentesSinNotificar.Count == 0)
            {
                _lblMensajeLista2.Text = "No ha seleccionado Agentes a noticar.";
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
