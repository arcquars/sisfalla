using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;

namespace SISFALLA
{
    public partial class FormEditarConfig : BaseForm
    {
        P_GF_Configuracion _configuracion;
        DataTable tablaDomConfig;
        public FormEditarConfig()
        {
            InitializeComponent();
        }

        public DialogResult Editar(P_GF_Configuracion conf)
        {
            _configuracion = conf;
            AsegurarTablaDomConfig();
            VisualizarConfiguracion();
            return ShowDialog();
        }

        private void AsegurarTablaDomConfig()
        {
            if (tablaDomConfig == null)
            {
                tablaDomConfig = ModeloMgr.Instancia.DefDominioMgr.GetDominio("D_COD_CONFIG");
                _cmbConfiguracion.DisplayMember = "DESCRIPCION_DOMINIO";
                _cmbConfiguracion.ValueMember = "COD_DOMINIO";
                _cmbConfiguracion.DataSource = tablaDomConfig;
            }
        }

        private void VisualizarConfiguracion()
        {
            _cmbConfiguracion.SelectedValue = _configuracion.CodDominio;
            _txtValorConfig.Text = _configuracion.Valor;
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _configuracion.CodDominio = (long)_cmbConfiguracion.SelectedValue;
                _configuracion.Valor = _txtValorConfig.Text;
                ModeloMgr.Instancia.P_GF_ConfiguracionMgr.Guardar(_configuracion);
                DialogResult = DialogResult.OK;
            }
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
