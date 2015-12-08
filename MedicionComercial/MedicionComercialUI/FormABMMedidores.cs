using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using MC;

namespace MedicionComercialUI
{
    public partial class FormABMMedidores : BaseForm, IFuncionalidad
    {
        AC_Medidor _medidorSeleccionado = null;
        CtrlDatosMedidorBase _ctrlActual;
        DataTable _tablaMedidor;
        DataRow _rowSeleccionado;
        public FormABMMedidores()
        {
            InitializeComponent();
            _ctrlActual = _ctrlResumenMedidor;
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            _tablaMedidor = OraDalMedidorMgr.Instancia.GetTabla();
            _dgvMedidores.DataSource = _tablaMedidor;
            _dgvMedidores.AsegurarColumnas();
            base.OnLoad(e);
        }

        private void _dgvMedidores_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMedidores.SelectedRows.Count > 0)
            {
                _rowSeleccionado = (_dgvMedidores.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _medidorSeleccionado = new AC_Medidor(_rowSeleccionado);
                VisualizarDatosEnControlActual();
            }
        }

        private void VisualizarDatosEnControlActual()
        {
            if (_ctrlActual != null)
            {
                _ctrlActual.Medidor = _medidorSeleccionado;
                _ctrlActual.Visualizar();
            }
        }

        private void cndcTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cndcTabControl1.SelectedTab.Controls.Count > 0)
            {
                _ctrlActual = GetControl(cndcTabControl1.SelectedTab.Controls);
                VisualizarDatosEnControlActual();
            }
        }

        private CtrlDatosMedidorBase GetControl(Control.ControlCollection controles)
        {
            CtrlDatosMedidorBase resultado = null;
            foreach (Control c in controles)
            {
                if (c is CtrlDatosMedidorBase)
                {
                    resultado = c as CtrlDatosMedidorBase;
                    break;
                }
            }
            return resultado;
        }

        private void _ctrlResumenMedidor_MedidorCreado(object sender, MedidorEventArgs e)
        {
            DataRow r = _tablaMedidor.NewRow();
            e.Medidor.Llenar(r);
            _tablaMedidor.Rows.Add(r);
            this.BindingContext[_tablaMedidor].Position = this.BindingContext[_tablaMedidor].Count - 1;
        }

        private void _ctrlResumenMedidor_MedidorModificado(object sender, MedidorEventArgs e)
        {
            e.Medidor.Llenar(_rowSeleccionado);
        }
    }
}