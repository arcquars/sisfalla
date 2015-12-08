using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using OraDalComponentes;

namespace ComponentesUI
{
    public partial class FormNuevoComponente : BaseForm
    {
        public FormNuevoComponente()
        {
            InitializeComponent();
        }

        private void FormNuevoComponente_Load(object sender, EventArgs e)
        {
            _ctrlDatosGenerales._esNuevo = true;
            _ctrlDatosGenerales._tSBEditar_Click(null, e);
            
           // _ctrlDatosGenerales.Habilitar();
            
           DataTable tComponente= TipoComponenteMgr.Instancia.GetTipoComponente();
           _cmbTipoComponente.ValueMember = "pk_cod_tipo_componente";
           _cmbTipoComponente.DisplayMember = "descripcion_tipo";
           _cmbTipoComponente.DataSource = tComponente;
           
           
        }

        private void _cmbTipoComponente_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ctrlDatosGenerales._tipoComponente = long.Parse(_cmbTipoComponente.SelectedValue.ToString());
        }

        private void _ctrlDatosGenerales_AccionEjecutada(object sender, AccionEjecutadaEventArgs e)
        {
            if (e.AccionEjecutada != Accion.Editar )
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        
    }
}
