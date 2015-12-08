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
using MenuQuantum;

namespace MedicionComercialUI
{
    public partial class FormABMDefCanales : BaseForm, IFuncionalidad
    {
        MagnitudElectrica _magnitudElec = null;
        public FormABMDefCanales()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _dgvMagnitudElectrica.DataSource = OraDalMagnitudElectricaMgr.Instancia.GetTabla();
            base.OnLoad(e);
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void _dgvDefCanales_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMagnitudElectrica.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvMagnitudElectrica.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _magnitudElec = new MagnitudElectrica(r);
                _ctrlDefCanal.Visualizar(_magnitudElec);
            }
        }

        private void _btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
