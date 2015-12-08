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
    public partial class FormABMPuntosMedicion : BaseForm, IFuncionalidad
    {
        MC_PuntoMedicion _puntoMedicionSeleccionado = null;
        CtrlDatosPuntoMedicionBase _ctrlActual;
        DataTable _tablaPuntoMedicion;
        DataRow _rowSeleccionado;
        public FormABMPuntosMedicion()
        {
            InitializeComponent();
            _ctrlActual = ctrlPuntoMedicion1;
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            _tablaPuntoMedicion = OraDalMC_PuntoMedicionMgr.Instancia.GetTabla();
            _dgvPuntosMedicion.DataSource = _tablaPuntoMedicion;
            //_dgvPuntosMedicion.AsegurarColumnas();
            base.OnLoad(e);
        }

        private void _dgvPuntosMedicion_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvPuntosMedicion.SelectedRows.Count > 0)
            {
                _rowSeleccionado = (_dgvPuntosMedicion.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _puntoMedicionSeleccionado = new MC_PuntoMedicion(_rowSeleccionado);
                VisualizarDatosEnControlActual();
            }
        }

        private void VisualizarDatosEnControlActual()
        {
            if (_ctrlActual != null)
            {
                _ctrlActual.PuntoMedicion = _puntoMedicionSeleccionado;
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

        private CtrlDatosPuntoMedicionBase GetControl(Control.ControlCollection controles)
        {
            CtrlDatosPuntoMedicionBase resultado = null;
            foreach (Control c in controles)
            {
                if (c is CtrlDatosPuntoMedicionBase)
                {
                    resultado = c as CtrlDatosPuntoMedicionBase;
                    break;
                }
            }
            return resultado;
        }

        private void ctrlPuntoMedicion1_PuntoMedicionCreado(object sender, PuntoMedicionEventArgs e)
        {
            DataRow r = _tablaPuntoMedicion.NewRow();
            e.PuntoMedicion.Llenar(r);
            _tablaPuntoMedicion.Rows.Add(r);
            this.BindingContext[_tablaPuntoMedicion].Position = this.BindingContext[_tablaPuntoMedicion].Count - 1;
        }

        private void ctrlPuntoMedicion1_PuntoMedicionModificado(object sender, PuntoMedicionEventArgs e)
        {
            e.PuntoMedicion.Llenar(_rowSeleccionado);
        }
    }
}
