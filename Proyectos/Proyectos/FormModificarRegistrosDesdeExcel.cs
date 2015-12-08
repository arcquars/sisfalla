using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.UtilesComunes;
using OraDalProyectos;
using ModeloProyectos;
using CNDC.BLL;
using ParserABNumber;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormModificarRegistrosDesdeExcel : BaseForm
    {
        DataTable _tabla;
        Proyecto _proyecto;
        SerieHidrologica _serieHidrologica;
        public FormModificarRegistrosDesdeExcel()
        {
            if (Sesion.Instancia.SesionIniciada)
            {
                InitializeComponent();
                _nudAnioFin.Value = DateTime.Now.Year;
            }
        }

        public void SetPararmetros(DataTable tabla, Proyecto proyecto)
        {
            _tabla = tabla;
            EliminarFilasCalculables();
            _proyecto = proyecto;
            _nudAnioFin.Maximum = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            _nudAnioFin.Minimum = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioInicio.Maximum = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            _nudAnioInicio.Minimum = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioInicio.Value = int.Parse(_tabla.Rows[0][1].ToString());
            _nudAnioFin.Value = int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString());
            this.ShowDialog();
        }

        private void EliminarFilasCalculables()
        {
            for (int i = 0; i < 4; i++)
            {
                _tabla.Rows.RemoveAt(_tabla.Rows.Count-1);
            }
        }

        private void _btnCrear_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                LectorXls lector = new LectorXls();
                Parser p = new Parser();
                _tabla = lector.LeerSeriesParaModificacionDatos(_tabla, _ctrlSelectorHojaDocExcel.Documento, _ctrlSelectorHojaDocExcel.NumHojaSeleccionada, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()) + 11,(int) _nudAnioInicio.Value, (int)_nudAnioFin.Value);
                if (lector.GetResultado())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.No;
                }
            }
        }


        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

            //if (_nudAnioFin.Value < _nudAnioInicio.Value)
            //{
            //    _errorProvider.SetError(_nudAnioFin, "Año fin debe ser mayor o igual a año inicio."); ;
            //    res = false;
            //}
            if (!_ctrlSelectorHojaDocExcel.DatosSonValidos())
            {
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
