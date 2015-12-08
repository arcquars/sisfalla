using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BaseForms;
using BLL;

namespace SISFALLA
{
    public partial class CtrlConfiguracion : UserControl
    {
        long _pkCodPersonaSeleccionada;
        
        public CtrlConfiguracion()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            DataTable tablaAgentes = ModeloMgr.Instancia.PersonaMgr.GetAgentes();
            _dgvAgentes.DataSource = tablaAgentes;
            BaseForm.VisualizarColumnas(_dgvAgentes, ColumnStyleManger.GetEstilos("CtrlConfiguracion", "_dgvAgentes"));
        }

        private void _dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                DataRow row = (_dgvAgentes.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _pkCodPersonaSeleccionada = (long)row["PK_COD_PERSONA"];
                VisualizarConfiguracionPersonaActual();
            }
        }

        private void VisualizarConfiguracionPersonaActual()
        {
            DataTable tablaConfig = ModeloMgr.Instancia.P_GF_ConfiguracionMgr.GetConfiguraciones(_pkCodPersonaSeleccionada);
            _dgvConfiguracion.DataSource = tablaConfig;
            BaseForm.VisualizarColumnas(_dgvConfiguracion, ColumnStyleManger.GetEstilos("CtrlConfiguracion", "_dgvConfiguracion"));
        }

        private void _tspAdConfig_Click(object sender, EventArgs e)
        {
            P_GF_Configuracion config = new P_GF_Configuracion();
            config.EsNuevo = true;
            config.CodPersona = _pkCodPersonaSeleccionada;
            FormEditarConfig fEditConfig = new FormEditarConfig();
            if (fEditConfig.Editar(config) == DialogResult.OK)
            {
                VisualizarConfiguracionPersonaActual();
            }
        }

        DataRow _rowConfigSeleccionado = null;
        private void _dgvConfiguracion_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvConfiguracion.SelectedRows.Count > 0)
            {
                _rowConfigSeleccionado = (_dgvConfiguracion.SelectedRows[0].DataBoundItem as DataRowView).Row;
            }
        }

        private void _tspEditarConfig_Click(object sender, EventArgs e)
        {
            if (_rowConfigSeleccionado != null)
            {
                P_GF_Configuracion config = new P_GF_Configuracion(_rowConfigSeleccionado);
                FormEditarConfig fEditConfig = new FormEditarConfig();
                if (fEditConfig.Editar(config) == DialogResult.OK)
                {
                    VisualizarConfiguracionPersonaActual();
                }
            }
        }
    }
}
