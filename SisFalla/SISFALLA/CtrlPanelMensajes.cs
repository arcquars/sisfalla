using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SISFALLA
{
    public partial class CtrlPanelMensajes : UserControl
    {
        BindingList<MensajeEmergente> _mensajes;
        MensajeEmergente _mensajeSeleccionado;
        public CtrlPanelMensajes()
        {
            InitializeComponent();
            _mensajes = new BindingList<MensajeEmergente>();
            _dgvMensajes.DataSource = _mensajes;
            AsegurarGrid();
        }

        public void Visualizar(List<MensajeEmergente> mensajes)
        {
            foreach (var item in mensajes)
            {
                _mensajes.Add(item);
            }
        }

        private void AsegurarGrid()
        {
            _dgvMensajes.Columns["FechaHora"].Width = 120;
            _dgvMensajes.Columns["FechaHora"].HeaderText = "FechaHora";
            _dgvMensajes.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            _dgvMensajes.Columns["Cabecera"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgvMensajes.Columns["Cabecera"].HeaderText = "Aviso";

            _dgvMensajes.Columns["Detalle"].Visible = false;
            _dgvMensajes.Columns["Leido"].Visible = false;
            _dgvMensajes.Columns["Resaltado"].Visible = false;
        }

        private void _dgvMensajes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMensajes.SelectedRows.Count > 0)
            {
                _mensajeSeleccionado = (MensajeEmergente)_dgvMensajes.SelectedRows[0].DataBoundItem;
                _txtDetalleMensaje.Text = _mensajeSeleccionado.Detalle;
                _mensajeSeleccionado.Leido = true;
            }
            else
            {
                _mensajeSeleccionado = null;
                _txtDetalleMensaje.Text = string.Empty;
            }
        }

        private void _btnBorrarMensaje_Click(object sender, EventArgs e)
        {
            if (_mensajeSeleccionado != null)
            {
                _mensajeSeleccionado.Borrar();
                _mensajes.Remove(_mensajeSeleccionado);
            }
        }

        private void _dgvMensajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MensajeEmergente m = (MensajeEmergente)_dgvMensajes.Rows[e.RowIndex].DataBoundItem;
            if (m.Resaltado)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }
    }
}
