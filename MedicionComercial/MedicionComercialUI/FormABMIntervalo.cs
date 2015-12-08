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
    public partial class FormABMIntervalo : BaseForm, IFuncionalidad
    {
        DataTable _tablaIntervalo;
        MC_IntervaloMaestro _intervaloMaestro;
        MC_IntervaloMaestro _anterior;

        public FormABMIntervalo()
        {
            InitializeComponent();
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _tablaIntervalo = MC_IntervaloMaestroMgr.Instancia.GetTabla();
            _dgvIntervalos.DataSource = _tablaIntervalo;
        }

        private void _dgvIntervalos_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvIntervalos.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvIntervalos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _intervaloMaestro = new MC_IntervaloMaestro(r);
                _ctrlIntervalo.Visualizar(_intervaloMaestro);
                _dgvDetalleIntervalo.DataSource = MC_IntervaloDetalleMgr.Instancia.GetPorPkCodMaestro(_intervaloMaestro.PkCodIntervaloMaestro);
            }
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            _anterior = _intervaloMaestro;
            _intervaloMaestro = new MC_IntervaloMaestro();
            _intervaloMaestro.EsNuevo = true;
            _intervaloMaestro.DCodEstado = 1;
            _ctrlIntervalo.Visualizar(_intervaloMaestro);
            _ctrlIntervalo.HabilitarEdicion();

            HabilitarBotonesEdicion();
        }

        private void HabilitarBotonesEdicion()
        {
            _btnAdicionar.Enabled = false;
            _btnGuardar.Enabled = true;
            _btnEditar.Enabled = false;
            _btnDarBaja.Enabled = false;
            _btnCancelar.Enabled = true;
        }

        private void DeshabilitarBotonesEdicion()
        {
            _btnAdicionar.Enabled = true;
            _btnGuardar.Enabled = false;
            _btnEditar.Enabled = true;
            _btnDarBaja.Enabled = true;
            _btnCancelar.Enabled = false;
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            bool esNuevo = _intervaloMaestro.EsNuevo;
            if (_ctrlIntervalo.Guardar())
            {
                _ctrlIntervalo.DeshabilitarEdicion();
                DeshabilitarBotonesEdicion();
                if (esNuevo)
                {
                    DataRow r = _tablaIntervalo.NewRow();
                    _intervaloMaestro.Llenar(r);
                    _tablaIntervalo.Rows.Add(r);
                    BindingContext[_tablaIntervalo].Position = _tablaIntervalo.Rows.Count - 1;
                }
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            _ctrlIntervalo.HabilitarEdicion();
            HabilitarBotonesEdicion();
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            _ctrlIntervalo.DeshabilitarEdicion();
            if (_intervaloMaestro.EsNuevo)
            {
                _intervaloMaestro = _anterior;
            }

            _ctrlIntervalo.Visualizar(_intervaloMaestro);
            DeshabilitarBotonesEdicion();
        }
    }
}
