using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;

namespace Reportes
{
    public partial class FormParametroFecha : BaseForm
    {
        DateTime _fechaVigencia = DateTime.Now.Date;
        public FormParametroFecha()
        {
            InitializeComponent();
            
        }


        public DateTime GetfechaVigencia()
        {
            return _fechaVigencia;
        }
        public void SetFechaVigencia(DataTable fechas)
        {
            _cbxFechasVigentes.DataSource = fechas;
            _cbxFechasVigentes.DisplayMember = "FECHA_VIGENCIA";
            _cbxFechasVigentes.ValueMember = "FECHA_VALOR";
        }
        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            _fechaVigencia = Convert.ToDateTime(_cbxFechasVigentes.SelectedValue);
            DialogResult = DialogResult.OK;
        }
    }
}
