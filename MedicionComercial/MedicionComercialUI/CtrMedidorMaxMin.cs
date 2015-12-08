using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrMedidorMaxMin : CtrlDatosMedidorBase
    {
        MedidorFlujoMaxMin _maxminActual;
        MedidorFlujoMaxMinDetalle _maxminDetalleActual;

        public CtrMedidorMaxMin()
        {
            InitializeComponent();
        }

        public override void Visualizar()
        {
            _dgvMaxMin.DataSource = OraDalMedidorFlujoMaxMinMgr.Instancia.GetMaxMin(_medidor.PkCodMedidor);
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            FormMedidorFlujoMaxMin f = new FormMedidorFlujoMaxMin();
            MedidorFlujoMaxMin maxmin = new MedidorFlujoMaxMin();
            maxmin.EsNuevo = true;
            maxmin.FkCodMedidor = _medidor.PkCodMedidor;
            maxmin.Desde = DateTime.Now;
            if (f.Editar(maxmin))
            {
                Visualizar();
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_maxminDetalleActual != null)
            {
                FormMedidorFlujoMaxMinDetalle f = new FormMedidorFlujoMaxMinDetalle();
                if (f.Editar(_maxminDetalleActual))
                {
                    VisualizarDetalle();
                }
            }
        }

        private void _dgvMaxMinDetalle_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMaxMinDetalle.SelectedRows.Count > 0)
            {
                DataRow row = (_dgvMaxMinDetalle.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _maxminDetalleActual = new MedidorFlujoMaxMinDetalle(row);
            }
        }

        private void _dgvMaxMin_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMaxMin.SelectedRows.Count > 0)
            {
                DataRow row = (_dgvMaxMin.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _maxminActual = new MedidorFlujoMaxMin(row);
                VisualizarDetalle();
            }
        }

        private void VisualizarDetalle()
        {
            _dgvMaxMinDetalle.DataSource = OraDalMedidorFlujoMaxMinDetalleMgr.Instancia.GetMaxMinDetalle(_maxminActual.PkCodMedMaxMin);
        }
    }
}
