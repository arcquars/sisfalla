using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class FormMedidorCanales : BaseForm
    {
        AC_Medidor _medidorSeleccionado;
        RMedidorCanal _rMedidorCanalSeleccionado;
        public FormMedidorCanales()
        {
            InitializeComponent();
        }

        public void EditarDefCanales(AC_Medidor medidorSeleccionado)
        {
            _medidorSeleccionado = medidorSeleccionado;
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            DataTable tablaMedidorCanales = OraDalRMedidorCanalMgr.Instancia.GetDefCanales(_medidorSeleccionado);
            _dgvMedidorCanales.DataSource = tablaMedidorCanales;
            _ctrlResumenMedidor.Medidor = _medidorSeleccionado;
            _ctrlResumenMedidor.Visualizar();
            base.OnLoad(e);
        }

        private void _dgvMedidorCanales_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMedidorCanales.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvMedidorCanales.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rMedidorCanalSeleccionado = new RMedidorCanal(r);
                ctrlMedidorCanal1.Visualizar(_rMedidorCanalSeleccionado);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _rMedidorCanalSeleccionado = _medidorSeleccionado.GetNuevoRMedidorCanal();
            FormRMedidorCanal fMedidorCanal = new FormRMedidorCanal();
            fMedidorCanal.Editar(_rMedidorCanalSeleccionado);
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_rMedidorCanalSeleccionado != null)
            {
                FormRMedidorCanal fMedidorCanal = new FormRMedidorCanal();
                fMedidorCanal.Editar(_rMedidorCanalSeleccionado);
            }
        }
    }
}
