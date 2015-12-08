using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class CtrlSelectorHojaDocExcel : UserControl
    {
        public CtrlSelectorHojaDocExcel()
        {
            InitializeComponent();
        }

        public int NumHojaSeleccionada
        {
            get { return _cmbHoja.SelectedIndex + 1; }
        }

        public string Documento
        {
            get { return _txtDocumento.Text; }
        }

        private void _btnDocumento_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _txtDocumento.Text = openFileDialog1.FileName;
            LectorXls lector = new LectorXls();
            List<string> nombresHojas = lector.GetNombresHojas(openFileDialog1.FileName);
            _cmbHoja.Items.Clear();
            _cmbHoja.Items.AddRange(nombresHojas.ToArray());
        }

        public bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_txtDocumento.Text == string.Empty)
            {
                _errorProvider.SetError(_txtDocumento, "Debe seleccionar un documento excel.");
                resultado = false;
            }

            if (_cmbHoja.SelectedIndex < 0)
            {
                _errorProvider.SetError(_cmbHoja, "Debe seleccionar una hoja del documento excel");
                resultado = false;
            }
            return resultado;
        }
    }
}
