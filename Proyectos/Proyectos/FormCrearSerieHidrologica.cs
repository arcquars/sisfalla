using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.BLL;
using ParserABNumber;
using CNDC.UtilesComunes;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormCrearSerieHidrologica : BaseForm
    {
        Proyecto _proyecto;
        DataTable _tabla;
        bool _serieEnBlanco = true;
        Parser _parser = new Parser();
        public FormCrearSerieHidrologica()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                _tabla = new DataTable();
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public DataTable GetTabla()
        {
            return _tabla;
        }

        private void _btnCrear_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                if (_serieEnBlanco)
                {
                    CrearSerieHidrologicaEnBlanco();//OraDalSerieHidrologicaMgr.Instancia.CrearSeriesHidrologicasDesdeHasta((int)_nudAnioInicio.Value, (int)_nudAnioFin.Value, _proyecto.PkProyecto, _tabla);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    CrearSerieHidrologicaImpDatosExcel();
                }
            }
        }

        private void CrearSerieHidrologicaEnBlanco()
        {
            for (int i = (int)_nudAnioInicio.Value; i <= (int)_nudAnioFin.Value; i++)
            {
                DataRow row = _tabla.NewRow();
                row[1] = i;
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

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (!Utiles.EsEnteroPositivo(_nudAnioInicio.Value.ToString()))
            {
                res = false;
                _errorProvider.SetError(_nudAnioInicio, "Año Inicio tiene que ser un número.");
            }
            if ((int)_nudFilaFin.Value < (int)_nudFilaInicio.Value)
            {
                res = false;
                _errorProvider.SetError(_nudFilaFin, "Fila inicio tiene que ser menor o igual a fila fin.");
            }

            if (!_serieEnBlanco)
            {
                if (!_ctrlSelectorHojaDocExcel.DatosSonValidos())
                {
                    res = false;
                }
                if (Utiles.EsCadenaVacia(_txtColumna.Text))
                {
                    res = false;
                    _errorProvider.SetError(_txtColumna, "Columna inicio tiene que contener el nombre de la columna inicio.");
                }
            }

            if (_serieEnBlanco)
            {
                if ((int)_nudAnioFin.Value < (int)_nudAnioInicio.Value)
                {
                    res = false;
                    _errorProvider.SetError(_nudAnioFin, "Anio fin tiene que ser mayor o igual a fila inicio.");
                }
            }
            return res;
        }

        private void CrearSerieHidrologicaImpDatosExcel()
        {
            LectorXls lector = new LectorXls();
            Parser p = new Parser();
            _tabla = lector.LeerSeries(0, _tabla, _ctrlSelectorHojaDocExcel.Documento, _ctrlSelectorHojaDocExcel.NumHojaSeleccionada, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text.Trim().ToUpper()) + 11, (int)_nudAnioInicio.Value, (int)_nudAnioFin.Value);
            if (lector.GetResultado())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.No;
            }

            // _tabla = OraDalSerieHidrologicaMgr.Instancia.GuardarTabla(_tabla, _proyecto.PkProyecto);
        }

        public void CrearSerieEnBanco(Proyecto proyecto, DataTable tabla)
        {
            _tabla = tabla;
            _serieEnBlanco = true;
            _proyecto = proyecto;
            _ctrlSelectorHojaDocExcel.Visible = false;
            _pnlPanelAnios.Visible = true;
            _gbxFilas.Visible = false;
            _gbxColumnas.Visible = false;
            _lblAnioFin.Visible = true;
            _nudAnioFin.Visible = true;
            _nudAnioFin.Value = DateTime.Now.Year;
            this.Width = 200;
            this.Height = _pnlPanelAnios.Height + _btnCancelar.Height + 40;
            _pnlPanelAnios.Location = new Point(this.Width / 2 - _pnlPanelAnios.Width / 2, 0);
            _btnCrear.Location = new Point(this.Width / 2 - _btnCrear.Width - 3, _pnlPanelAnios.Bottom + 5);
            _btnCancelar.Location = new Point(_btnCrear.Right + 6, _pnlPanelAnios.Bottom + 5);
            ShowDialog();
        }

        public void CrearSerieImpDocumento(Proyecto proyecto, DataTable tabla)
        {
            _tabla = tabla;
            _serieEnBlanco = false;
            _proyecto = proyecto;
            _ctrlSelectorHojaDocExcel.Visible = true;
            _pnlPanelAnios.Visible = true;
            _gbxFilas.Visible = true;
            _gbxColumnas.Visible = true;
            ShowDialog();
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
