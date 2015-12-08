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
    public partial class CtrlPtoMedicionFto : CtrlDatosPuntoMedicionBase
    {
        DataGridViewComboBoxColumn _cmbMagnitudes;
        MC_RPuntoMedicionFormato _rPtoMedFto;
        MC_RPuntoMedicionFormatoDetalle _rPtoMedFtoDetalle;
        public CtrlPtoMedicionFto()
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
            DataTable tabla = OraDalMC_RPtoMedFtoMgr.Instancia.GetFormatos(_puntoMedicion);
            _dgvFormatos.DataSource = tabla;
            //_dgvFormatos.AsegurarColumnas();
        }

        private void _dgvFormatos_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvFormatos.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvFormatos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rPtoMedFto = new MC_RPuntoMedicionFormato(r);
                VisualizarMagnitudes();

                _btnAdicionarMagnitud.Enabled = true;

                _btnEditarFormato.Enabled = true;
                _btnEliminarFormato.Enabled = true;
            }
            else
            {
                _rPtoMedFto = null;
                _dgvDetMagnitudesElectricas.DataSource = null;
                _btnAdicionarMagnitud.Enabled = false;

                _btnEditarFormato.Enabled = false;
                _btnEliminarFormato.Enabled = false;
            }
        }

        private void VisualizarMagnitudes()
        {
            DataTable tablaMagnitudes = OraDalMC_RPuntoMedicionFormatoDetalleMgr.Instancia.GetMagnitudesElectricas(_rPtoMedFto);
            _dgvDetMagnitudesElectricas.DataSource = tablaMagnitudes;

            _dgvDetMagnitudesElectricas.Columns.Remove(_dgvDetMagnitudesElectricas.Columns[MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC]);
            _cmbMagnitudes = new DataGridViewComboBoxColumn();
            _cmbMagnitudes.Name = MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.HeaderText = "Magnitud";
            _cmbMagnitudes.DataPropertyName = MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.DisplayMember = MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC;
            _cmbMagnitudes.ValueMember = MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.DataSource = OraDalMagnitudElectricaMgr.Instancia.GetTabla();
            _dgvDetMagnitudesElectricas.Columns.Add(_cmbMagnitudes);
            //_dgvDetMagnitudesElectricas.AsegurarColumnas(false);
        }

        private void _dgvDetMagnitudesElectricas_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvDetMagnitudesElectricas.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvDetMagnitudesElectricas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rPtoMedFtoDetalle = new MC_RPuntoMedicionFormatoDetalle(r);
                _btnEditarMagnitud.Enabled = true;
                _btnEliminarMagnitud.Enabled = true;
            }
            else
            {
                _rPtoMedFtoDetalle = null;
                _btnEditarMagnitud.Enabled = false;
                _btnEliminarMagnitud.Enabled = false;
            }
        }

        private void _btnAdicionarMagnitud_Click(object sender, EventArgs e)
        {
            MC_RPuntoMedicionFormatoDetalle r = _rPtoMedFto.GetNuevoRMedidorCanal();
            FormRMedidorCanal f = new FormRMedidorCanal();
            if (f.Editar(r))
            {
                VisualizarMagnitudes();
            }
        }

        private void _btnEditarMagnitud_Click(object sender, EventArgs e)
        {
            FormRMedidorCanal f = new FormRMedidorCanal();
            if (f.Editar(_rPtoMedFtoDetalle))
            {
                VisualizarMagnitudes();
            }
        }

        private void _btnAdicionarFormato_Click(object sender, EventArgs e)
        {
            MC_RPuntoMedicionFormato r = new MC_RPuntoMedicionFormato();
            r.FkCodPuntoMedicion = _puntoMedicion.PkCodPtoMedicion;
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
            if (f.Editar(_rPtoMedFto))
            {
                Visualizar();
            }
        }
    }
}
