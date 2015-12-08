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
using Proyectos;
using DemandasUI;
using CNDC.BaseForms;

namespace DemadasUI
{
    public partial class FormInsertarRegistros : BaseForm
    {
        DataTable _tabla;
        DataTable _tablaNueva= new DataTable();
        public FormInsertarRegistros()
        {
            if (Sesion.Instancia.SesionIniciada)
            {
                InitializeComponent();
            }
        }

        public void SetPararmetros(DataTable tabla)
        {
            _tabla = tabla;
            _rbtExcel.Checked = true;
            _rbtAlFinal.Checked = true;
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
                if (_rbtExcel.Checked)
                {
                    if (_txtColumna.Text != "")
                    {
                        LectorXls lector = new LectorXls();
                        Parser p = new Parser();
                        if (_rbtAlInicio.Checked)
                        {
                            _tabla = lector.LeerSeries(1, _tabla, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()) + 11, int.Parse(_txtAnioInicio.Text), int.Parse(_txtAnioFin.Text));
                        }
                        else
                        {
                            _tabla = lector.LeerSeries(0,_tabla, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()) + 11, int.Parse(_txtAnioInicio.Text), int.Parse(_txtAnioFin.Text));
                        
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tiene que registrar la columna a partir del cual se van a copiar los datos.");
                    }
                }
                else
                {
                    if (_rbtAlFinal.Checked)
                    {
                        for (int i = int.Parse(_txtAnioInicio.Text); i <= int.Parse(_txtAnioFin.Text); i++)
                        {
                            DataRow row = _tabla.NewRow();
                            row[1] = i.ToString();
                            row[2] = 0;
                            row[3] = 0;
                            row[4] = 0;
                            row[5] = 0;
                            row[6] = 0;
                            row[7] = 0;
                            row[8] = 0;
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            _tabla.Rows.Add(row);
                        }
                    }
                    else
                    {
                        for (int i = int.Parse(_txtAnioFin.Text); i >= int.Parse(_txtAnioInicio.Text); i--)
                        {
                            DataRow row = _tabla.NewRow();
                            row[1] = i.ToString();
                            row[2] = 0;
                            row[3] = 0;
                            row[4] = 0;
                            row[5] = 0;
                            row[6] = 0;
                            row[7] = 0;
                            row[8] = 0;
                            row[9] = 0;
                            row[10] = 0;
                            row[11] = 0;
                            row[12] = 0;
                            row[13] = 0;
                            _tabla.Rows.InsertAt(row,0);
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void AdicionarAniosAlInicio()
        {
            int anioFin = int.Parse(_txtAnioFin.Text);
            int fila = ObtenerNumFilaDataRow(anioFin+1);
            for (int k = fila-1; k >= 0; k--)
            {
                _tabla.Rows[k][1] = anioFin.ToString();
                anioFin--;
            }
        }

        private int ObtenerNumFilaDataRow( int anio)
        {
            int j = 0;

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow row = _tabla.Rows[i];
                if (int.Parse(row[1].ToString()) == anio)
                {
                    break;
                }
                j++;
            }
            return j;
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

            if (_rbtAlFinal.Checked)
            {

                if (!Utiles.EsEnteroPositivo(_txtAnioInicio.Text))
                {
                    _errorProvider.SetError(_txtAnioInicio, "Debe registrar un número entero.");
                    res = false;
                }
            }
            else
            {
                if (!Utiles.EsEnteroPositivo(_txtAnioFin.Text))
                {
                    _errorProvider.SetError(_txtAnioFin, "Debe registrar un número entero.");
                    res = false;
                }

            }
            if (_rbtExcel.Checked)
            {
                if (_txtDocumento.Text == "")
                {
                    _errorProvider.SetError(_txtDocumento, "Debe adjuntar el documento excel, del cual se copiaran los datos.");
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
            }

            return res;
        }

        public DataTable GetTabla()
        {
            return _tabla;
        }

        private void _rbtExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtExcel.Checked)
            {
                _btnDocumento.Enabled = true;
                _gbxFilas.Enabled = true;
                _gbxColumnas.Enabled = true;
            }
        }

        private void _rbtEnBlanco_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtEnBlanco.Checked)
            {
                _btnDocumento.Enabled = false;
                _gbxFilas.Enabled = false;
                _gbxColumnas.Enabled = false;
            }
        }

        private void _rbtAlInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtAlInicio.Checked)
            {
                _txtAnioFin.Text = (int.Parse(_tabla.Rows[0][1].ToString()) - 1).ToString();
                _txtAnioFin.ReadOnly = true;
                _txtAnioFin.BackColor = Color.Gainsboro;
                _txtAnioInicio.ReadOnly = false;
                _txtAnioInicio.Text = string.Empty;
                _txtAnioInicio.BackColor = Color.White;
                _txtAnioFin.Visible = true;
                _lblAnioFin.Visible = true;
                _txtAnioInicio.Visible = false;
                _lblAnioInicio.Visible = false;
                _txtAnioInicio.Text = "0";
            }
        }

        private void _rbtAlFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtAlFinal.Checked)
            {
                _txtAnioInicio.Text = (int.Parse(_tabla.Rows[_tabla.Rows.Count - 1][1].ToString()) + 1).ToString();
                _txtAnioInicio.ReadOnly = true;
                _txtAnioInicio.BackColor = Color.Gainsboro;
                _txtAnioFin.ReadOnly = false;
                _txtAnioFin.Text = string.Empty;
                _txtAnioFin.BackColor = Color.White;
                _txtAnioFin.Text = "0";
                _txtAnioFin.Visible = false;
                _lblAnioFin.Visible = false;
                _txtAnioInicio.Visible = true;
                _lblAnioInicio.Visible = true;
            }
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
