using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.UtilesComunes;
using CNDC.BLL;
using ParserABNumber;
using DemandasUI;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormModificarRegistrosDesdeExcel : BaseForm
    {
        DataTable _tabla;
        public FormModificarRegistrosDesdeExcel()
        {
            if (Sesion.Instancia.SesionIniciada)
            {
                InitializeComponent();
            }
        }

        public void SetPararmetros(DataTable tabla)
        {
            _tabla = tabla;
            _nudAnioFin.Maximum = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            _nudAnioFin.Minimum = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioInicio.Maximum = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            _nudAnioInicio.Minimum = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioInicio.Value = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioFin.Value = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            this.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _txtDocumento.Text = openFileDialog1.FileName;
        }

        private void _btnDocumento_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void _btnCrear_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                LectorXls lector = new LectorXls();
                Parser p = new Parser();
                _tabla = lector.LeerSeriesParaModificacionDatos(_tabla, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()) + 11,(int) _nudAnioInicio.Value, (int)_nudAnioFin.Value);
                DialogResult = DialogResult.OK;
            }
        }


        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

            if (_txtDocumento.Text == "")
            {
                _errorProvider.SetError(_txtColumna, "Debe ingresar la columna inicio, a partir del cual se copiaran los datos");
                res = false;
            }

            if (_txtColumna.Text == "")
            {
                _errorProvider.SetError(_txtColumna, "Debe ingresar la columna inicio, a partir del cual se copiaran los datos");
                res = false;
            }

            if ((int)_nudFilaInicio.Value > (int)_nudFilaFin.Value)
            {
                _errorProvider.SetError(_nudFilaFin, "Debe ser un número mayor a fila inicio.");
                res = false;
            }

            return res;
        }

        public DataTable GetTabla()
        {
            return _tabla;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
           DialogResult= DialogResult.Cancel;
        }

        private void _txtColumna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            { }
            else
            {
                e.Handled = true;
            }
        }
    }
}
