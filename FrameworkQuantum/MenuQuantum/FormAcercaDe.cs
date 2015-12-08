using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MenuQuantum
{
    public partial class FormAcercaDe : Form, IFuncionalidad
    {
        public FormAcercaDe()
        {
            InitializeComponent();
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormAcercaDe_Load(object sender, EventArgs e)
        {
            string archivoVersioModulo = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "versionModulo.txt");
            try
            {
                StreamReader r = new StreamReader(archivoVersioModulo);
                _lblModulo.Text = r.ReadLine();
                _lblVersionModulo.Text = r.ReadLine();
                _lblFecha.Text = r.ReadLine();
            }
            catch (Exception)
            {
            }
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }
    }
}
