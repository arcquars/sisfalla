using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrlFormulasPtoMed : CtrlDatosPuntoMedicionBase
    {
        DataGridViewComboBoxColumn _cmbMagnitudes;
        DataTable _tablaFormulas;
        public CtrlFormulasPtoMed()
        {
            InitializeComponent();
            _dgvFormulas.VirtualMode = true;
        }

        public override void Visualizar()
        {
            _tablaFormulas = MC_FormulaPuntoMedicionMgr.Instancia.GetFormulasPorCodPuntoMed(_puntoMedicion.PkCodPtoMedicion);
            _dgvFormulas.DataSource = _tablaFormulas;

            _dgvFormulas.Columns.Remove(_dgvFormulas.Columns[MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC]);
            _cmbMagnitudes = new DataGridViewComboBoxColumn();
            _cmbMagnitudes.Name = MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.HeaderText = "Magnitud";
            _cmbMagnitudes.DataPropertyName = MC_RPuntoMedicionFormatoDetalle.C_FK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.DisplayMember = MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC;
            _cmbMagnitudes.ValueMember = MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC;
            _cmbMagnitudes.DataSource = OraDalMagnitudElectricaMgr.Instancia.GetTabla();
            _dgvFormulas.Columns.Add(_cmbMagnitudes);            
        }

        private void _btnAdicionarMagnitud_Click(object sender, EventArgs e)
        {
            MC_FormulaPuntoMedicion f = _puntoMedicion.GetNuevaFormula();
            FormFormula form = new FormFormula();
            if (form.Editar(f))
            {
                Visualizar();
            }
        }

        private void _btnEditarMagnitud_Click(object sender, EventArgs e)
        {
            if (_dgvFormulas.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvFormulas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                MC_FormulaPuntoMedicion formula = new MC_FormulaPuntoMedicion(r);
                FormFormula form = new FormFormula();
                if (form.Editar(formula))
                {
                    Visualizar();
                }
            }
        }
    }
}
