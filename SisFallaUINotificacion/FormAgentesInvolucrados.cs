using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BaseForms;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormAgentesInvolucrados : BaseForm
    {
        BindingList<Persona> _listaAgentesDisponibles;
        BindingList<Persona> _listaAgentesNotificar;
        BindingList<Persona> _listaAgentes;
        public FormAgentesInvolucrados()
        {
            InitializeComponent();
            _listaAgentesDisponibles = ModeloMgr.Instancia.PersonaMgr.GetListaAgentes();
            _dgvAgentesDisponibles.DataSource = _listaAgentesDisponibles;
            BaseForm.VisualizarColumnas(_dgvAgentesDisponibles, GetConfColAgentes());
        }

        public DialogResult SeleccionarAgentes(BindingList<Persona> listaAgentes)
        {
            SetListaAgentesNotificar(listaAgentes);
            _dgvAgentesANotificar.DataSource = _listaAgentesNotificar;
            BaseForm.VisualizarColumnas(_dgvAgentesANotificar, GetConfColAgentes());
            return ShowDialog();
        }

        private void SetListaAgentesNotificar(BindingList<Persona> listaAgentes)
        {
            _listaAgentes = listaAgentes;
            _listaAgentesNotificar = new BindingList<Persona>();
            int ind = 0;
            foreach (Persona item in _listaAgentes)
            {
                _listaAgentesNotificar.Add(item);
                ind = _listaAgentesDisponibles.IndexOf(item);

                if (ind >= 0)
                {
                    _listaAgentesDisponibles.RemoveAt(ind);
                }
            }

            _dgvAgentesDisponibles.Refresh();
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
                MoverElementos(_listaAgentesDisponibles, _listaAgentesNotificar, _dgvAgentesDisponibles, _dgvAgentesANotificar);
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
                MoverElementos(_listaAgentesNotificar, _listaAgentesDisponibles, _dgvAgentesANotificar, _dgvAgentesDisponibles);
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
                if (origen == _listaAgentesDisponibles || _listaAgentesNotificar.IndexOf(p) > 1)
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
            _listaAgentes.Clear();
            foreach (var item in _listaAgentesNotificar)
            {
                _listaAgentes.Add(item);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
