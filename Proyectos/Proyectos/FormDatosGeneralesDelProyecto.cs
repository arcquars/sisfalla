using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class FormDatosGeneralesDelProyecto : Form
    {
        string tipoProyecto = string.Empty;
        public FormDatosGeneralesDelProyecto()
        {
            InitializeComponent();
        }

        private void ctrlDatosGenerales1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDatosGenerales1_Load_1(object sender, EventArgs e)
        {

        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            FormABMProyectos form = new FormABMProyectos();
            form.Show();
            form.setTipoProyecto(ctrlDatosGenerales1.GetTipoProyecto());
            this.Close();
        }

        public void setTipoProyecto(string tipoProy)
        {
            ctrlDatosGenerales1.SetTipoProyecto(tipoProy);
            tipoProyecto = tipoProy;
        }
    }
}
