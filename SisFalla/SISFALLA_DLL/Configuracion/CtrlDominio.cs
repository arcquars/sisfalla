using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;

namespace SISFALLA
{
    public partial class CtrlDominio : UserControl
    {
        public CtrlDominio()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            _cbxCategorias.DisplayMember = DefDominio.C_DESCRIPCION_DOMINIO;
            _cbxCategorias.ValueMember = DefDominio.C_D_COD_TIPO_DOMINIO;
            _cbxCategorias.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetCategorias();
        }

        private void _cbxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctrlDominios3.esGuardar == false)
            {
                ctrlDominios3.VisualizarDominios(_cbxCategorias.SelectedValue.ToString());
            }
            else if (BaseForm.EstaSeguro("Desea Guardar los Cambios?"))
            {
                Guardar();
            }
            else
            {
                ctrlDominios3.esGuardar = false;
            }
        }

        protected bool Guardar()
        {
            ctrlDominios3.Guardar();
            return true;
        }

        private void _tbtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
