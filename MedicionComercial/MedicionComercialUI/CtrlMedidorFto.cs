using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;
using CNDC.BLL;

namespace MedicionComercialUI
{
    public partial class CtrlMedidorFto : CtrlDatosMedidorBase
    {
        DataGridViewComboBoxColumn _cmbMagnitudes;
        MC_RMedidorFto _rMedidorFto;
        RMedidorCanal _rMedCanal;
        public CtrlMedidorFto()
        {
            InitializeComponent();
            _dgvDetMagnitudesElectricas.VirtualMode = true;
            if (Sesion.Instancia.SesionIniciada)
            {
                
            }
        }

        public override void Visualizar()
        {
            base.Visualizar();
            DataTable tabla = OraDalMC_RMedidorFtoMgr.Instancia.GetFormatos(_medidor);
            _dgvFormatos.DataSource = tabla;
            _dgvFormatos.AsegurarColumnas();
        }

        private void _dgvFormatos_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvFormatos.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvFormatos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rMedidorFto = new MC_RMedidorFto(r);
                VisualizarMagnitudes();

                _btnAdicionarMagnitud.Enabled = true;

                _btnEditarFormato.Enabled = true;
                _btnEliminarFormato.Enabled = true;
            }
            else
            {
                _rMedidorFto = null;
                _dgvDetMagnitudesElectricas.DataSource = null;
                _btnAdicionarMagnitud.Enabled = false;

                _btnEditarFormato.Enabled = false;
                _btnEliminarFormato.Enabled = false;
            }
        }

        private void VisualizarMagnitudes()
        {
            DataTable tablaMagnitudes = OraDalRMedidorCanalMgr.Instancia.GetMagnitudesElectricas(_rMedidorFto);
            _dgvDetMagnitudesElectricas.DataSource = tablaMagnitudes;

            _dgvDetMagnitudesElectricas.Columns.Remove(_dgvDetMagnitudesElectricas.Columns[RMedidorCanal.C_FK_COD_INFCANAL]);
            _cmbMagnitudes = new DataGridViewComboBoxColumn();
            _cmbMagnitudes.Name = RMedidorCanal.C_FK_COD_INFCANAL;
            _cmbMagnitudes.HeaderText = "Magnitud";
            _cmbMagnitudes.DataPropertyName = RMedidorCanal.C_FK_COD_INFCANAL;
            _cmbMagnitudes.DisplayMember = MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC;
            _cmbMagnitudes.ValueMember = MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.DataSource = OraDalMagnitudElectricaMgr.Instancia.GetTabla();
            _dgvDetMagnitudesElectricas.Columns.Add(_cmbMagnitudes);
            _dgvDetMagnitudesElectricas.AsegurarColumnas(false);
        }

        private void _dgvDetMagnitudesElectricas_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvDetMagnitudesElectricas.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvDetMagnitudesElectricas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rMedCanal = new RMedidorCanal(r);
                _btnEditarMagnitud.Enabled = true;
                _btnEliminarMagnitud.Enabled = true;
            }
            else
            {
                _rMedCanal = null;
                _btnEditarMagnitud.Enabled = false;
                _btnEliminarMagnitud.Enabled = false;
            }
        }

        private void _btnAdicionarMagnitud_Click(object sender, EventArgs e)
        {
            RMedidorCanal r = _medidor.GetNuevoRMedidorCanal();
            r.FkCodFormato = _rMedidorFto.PkCodFormato;
            FormRMedidorCanal f = new FormRMedidorCanal();
            if (f.Editar(r))
            {
                VisualizarMagnitudes();
            }
        }

        private void _btnEditarMagnitud_Click(object sender, EventArgs e)
        {
            FormRMedidorCanal f = new FormRMedidorCanal();
            if (f.Editar(_rMedCanal))
            {
                VisualizarMagnitudes();
            }
        }

        private void _btnAdicionarFormato_Click(object sender, EventArgs e)
        {
            MC_RMedidorFto r = new MC_RMedidorFto();
            r.PkCodMedidor = _medidor.PkCodMedidor;
            r.EsNuevo = true;
            r.DCodEstado = "1";
            FormRMedidorFormato f = new FormRMedidorFormato();
            if (f.Editar(r))
            {
                Visualizar();
            }
        }

        private void _btnEditarFormato_Click(object sender, EventArgs e)
        {
            FormRMedidorFormato f = new FormRMedidorFormato();
            if (f.Editar(_rMedidorFto))
            {
                Visualizar();
            }
        }
    }
}
