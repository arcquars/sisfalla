using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using ModeloProyectos;
using CNDC.UtilesComunes;
using OraDalProyectos;
using System.Threading;
using CNDC.ExceptionHandlerLib;

namespace Proyectos
{
    public partial class CtrlSeriesHidrolologicas : CtrlDatosBase, IControles
    {
        DataTable _tabla = new DataTable();
        bool _esEditable = false;
        bool _seGuardo = true;
        int _idx = -1;
        SerieHidrologica _serieHidrologica;
        Proyecto _proyecto;
        DataRow rowPromedio = null;
        DataRow rowMaximo = null;
        DataRow rowMinimo = null;
        DataRow rowDesvStd = null;
        DataGridViewTextBoxEditingControl _dgvTxtEditingCtrl = null;
        Type _tipoActual = null;

        public CtrlSeriesHidrolologicas()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarHeadersTabla();
                _dgvSerieHidrologica.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_dgvSerieHidrologica_EditingControlShowing);
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void CargarHeadersTabla()
        {
            DataColumn c_PkSerie = new DataColumn("Pk_Serie", typeof(long));
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Enero = new DataColumn("Enero", typeof(decimal));
            DataColumn c_Febrero = new DataColumn("Febrero", typeof(decimal));
            DataColumn c_Marzo = new DataColumn("Marzo", typeof(decimal));
            DataColumn c_Abril = new DataColumn("Abril", typeof(decimal));
            DataColumn c_Mayo = new DataColumn("Mayo", typeof(decimal));
            DataColumn c_Junio = new DataColumn("Junio", typeof(decimal));
            DataColumn c_Julio = new DataColumn("Julio", typeof(decimal));
            DataColumn c_Agosto = new DataColumn("Agosto", typeof(decimal));
            DataColumn c_Septiembre = new DataColumn("Septiembre", typeof(decimal));
            DataColumn c_Octubre = new DataColumn("Octubre", typeof(decimal));
            DataColumn c_Noviembre = new DataColumn("Noviembre", typeof(decimal));
            DataColumn c_Diciembre = new DataColumn("Diciembre", typeof(decimal));
            DataColumn c_Anual = new DataColumn("Anual", typeof(decimal));

            _tabla.Columns.Add(c_PkSerie);
            _tabla.Columns.Add(c_Anio);
            _tabla.Columns.Add(c_Enero);
            _tabla.Columns.Add(c_Febrero);
            _tabla.Columns.Add(c_Marzo);
            _tabla.Columns.Add(c_Abril);
            _tabla.Columns.Add(c_Mayo);
            _tabla.Columns.Add(c_Junio);
            _tabla.Columns.Add(c_Julio);
            _tabla.Columns.Add(c_Agosto);
            _tabla.Columns.Add(c_Septiembre);
            _tabla.Columns.Add(c_Octubre);
            _tabla.Columns.Add(c_Noviembre);
            _tabla.Columns.Add(c_Diciembre);
            _tabla.Columns.Add(c_Anual);

            _dgvSerieHidrologica.DataSource = _tabla;
            _dgvSerieHidrologica.Columns[0].Width = 70;
            _dgvSerieHidrologica.Columns[1].Width = 75;
            _dgvSerieHidrologica.Columns[2].Width = 75;
            _dgvSerieHidrologica.Columns[3].Width = 75;
            _dgvSerieHidrologica.Columns[4].Width = 75;
            _dgvSerieHidrologica.Columns[5].Width = 75;
            _dgvSerieHidrologica.Columns[6].Width = 75;
            _dgvSerieHidrologica.Columns[7].Width = 75;
            _dgvSerieHidrologica.Columns[8].Width = 75;
            _dgvSerieHidrologica.Columns[9].Width = 75;
            _dgvSerieHidrologica.Columns[10].Width = 75;
            _dgvSerieHidrologica.Columns[11].Width = 75;
            _dgvSerieHidrologica.Columns[12].Width = 75;
            _dgvSerieHidrologica.Columns[13].Width = 75;
            _dgvSerieHidrologica.Columns[14].Width = 75;
            _dgvSerieHidrologica.Columns[1].Frozen = true;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[2]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[3]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[4]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[5]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[6]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[7]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[8]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[9]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[10]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[11]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[12]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)_dgvSerieHidrologica.Columns[13]).MaxInputLength = 15;
            _dgvSerieHidrologica.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvSerieHidrologica.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        void _dgvSerieHidrologica_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_dgvTxtEditingCtrl != null)
            {
                _dgvTxtEditingCtrl.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }

            if (_dgvSerieHidrologica.CurrentCell.ColumnIndex > 0)
            {
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                _dgvTxtEditingCtrl = c;
                _tipoActual = _dgvSerieHidrologica.CurrentCell.ValueType;
            }
        }

        void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDecimal = false, isMinus = false, isValidChar = false;
            string separadorDecimal = string.Empty;

            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    separadorDecimal = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    e.KeyChar = separadorDecimal[0];
                    isDecimal = true;
                    isValidChar = true;
                    break;
                case '-':
                    isMinus = true;
                    isValidChar = true;
                    break;
                default:
                    bool isDigit = Char.IsDigit(e.KeyChar);
                    bool isControl = Char.IsControl(e.KeyChar);

                    if (isDigit || isControl)
                    {
                        isValidChar = true;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }

                    break;
            }

            TextBox txt = (TextBox)sender;

            if (txt == null)
            {
                e.Handled = true;
                return;
            }

            if (isValidChar && txt.SelectionLength == txt.TextLength)
            {
                txt.Text = string.Empty;
            }

            if (isMinus)
            {
                if (txt.Text.Length != 0 || (txt.Text.IndexOf('-') >= 0))
                {
                    e.Handled = true;
                    return;
                }
            }


            if (isDecimal)
            {
                if (_tipoActual.FullName == typeof(int).FullName
                    || _tipoActual.FullName == typeof(long).FullName
                    || _tipoActual.FullName == typeof(short).FullName)
                {
                    e.Handled = true;
                    return;
                }

                if (txt.Text.IndexOf(separadorDecimal) >= 0)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        public void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dgvSerieHidrologica.ReadOnly = false;
            _dtpFechaRegistro.Enabled = _proyecto.EsNuevo ? true : false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
            _btnAdFilaInicio.Enabled = true;
            _btnAdFilaFin.Enabled = true;
            _btnElimFilaInicio.Enabled = true;
            _btnElimFilaFin.Enabled = true;

            _tsbCrearSerieHidrologicaImpExcel.Enabled = _dgvSerieHidrologica.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_tsbCrearSerieHidrologicaImpExcel.Enabled;
            FormatoDeLasFilasYColumnas();
        }

        public void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
            
            _btnAdFilaInicio.Enabled = false;
            _btnAdFilaFin.Enabled = false;
            _btnElimFilaInicio.Enabled = false;
            _btnElimFilaFin.Enabled = false;

            _tsbCrearSerieHidrologicaImpExcel.Enabled = false;
            _btnPegarDeExcel.Enabled = false;

            _dgvSerieHidrologica.ReadOnly = true;
        }

        private void ActivarDesActivarControles()
        {
            if (_esEditable)
            {
                HabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
            _dgvSerieHidrologica.Columns[0].Visible = false;
        }
        #region Miembros de IControles

        public string Titulo
        {
            get { return "SERIES HIDROLOGICAS"; }
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;
            ActivarDesActivarControles();
            OraDalSerieHidrologicaMgr.Instancia.SetTablaSeriesDePkProyecto(_proyecto.PkProyecto, _tabla);
            if (_tabla.Rows.Count == 0)
            {
                _tsbCrearSerieHidrologicaImpExcel.Enabled = true;
            }
            else
            {
                _tsbCrearSerieHidrologicaImpExcel.Enabled = false;
                CargarFilasCalculables();
            }
        }

        #endregion

        private void CargarFilasCalculables()
        {
            if (_tabla.Rows.Count > 0)
            {
                rowPromedio = _tabla.NewRow();
                rowPromedio["Pk_Serie"] = 0;
                rowPromedio["Año"] = "PROMEDIO";

                rowMaximo = _tabla.NewRow();
                rowMaximo["Pk_Serie"] = 0;
                rowMaximo["Año"] = "MÁXIMO";

                rowMinimo = _tabla.NewRow();
                rowMinimo["Pk_Serie"] = 0;
                rowMinimo["Año"] = "MÍNIMO";

                rowDesvStd = _tabla.NewRow();
                rowDesvStd["Pk_Serie"] = 0;
                rowDesvStd["Año"] = "DESV. STD.";

                _tabla.Rows.Add(rowPromedio);
                _tabla.Rows.Add(rowMaximo);
                _tabla.Rows.Add(rowMinimo);
                _tabla.Rows.Add(rowDesvStd);

                CalcularPromedios(_tabla, rowPromedio);
                CalcularMaximo(_tabla, rowMaximo);
                CalcularMinimo(_tabla, rowMinimo);
                CalcularDesvStd(_tabla, rowDesvStd);
                CalcularSerieAnual();

                _dgvSerieHidrologica.DataSource = _tabla;
                _dgvSerieHidrologica.Columns[1].Frozen = true;
                _dgvSerieHidrologica.Columns[0].Visible = false;
                FormatoDeLasFilasYColumnas();
            }
        }

        private void CalcularPromedios(DataTable tabla, DataRow rowPromedio)
        {
            for (int i = 2; i < tabla.Columns.Count; i++)
            {
                rowPromedio[i] = Math.Round(GetPromedioDeColumna(tabla, i), 2);
            }
        }

        private decimal GetPromedioDeColumna(DataTable tabla, int col)
        {
            decimal resultado = 0;
            decimal sumatoria = 0;
            for (int i = 0; i < tabla.Rows.Count - 4; i++)
            {
                DataRow r = tabla.Rows[i];
                if (!(r[col] is DBNull))
                {
                    sumatoria += (decimal)r[col];
                }
            }
            if (sumatoria != 0)
            {
                resultado = sumatoria / (tabla.Rows.Count - 4);
            }
            return resultado;
        }

        private void CalcularMaximo(DataTable tabla, DataRow rowMaximo)
        {
            for (int i = 2; i < tabla.Columns.Count; i++)
            {
                rowMaximo[i] = Math.Round(GetMaxDeColumna(tabla, i), 2);
            }
        }

        private decimal GetMaxDeColumna(DataTable tabla, int col)
        {
            decimal resultado = 0;
            for (int i = 0; i < tabla.Rows.Count - 4; i++)
            {
                DataRow r = tabla.Rows[i];
                if (!(r[col] is DBNull))
                {
                    decimal valor = (decimal)r[col];
                    if (valor > resultado)
                    {
                        resultado = valor;
                    }
                }
            }
            return resultado;
        }

        private void CalcularMinimo(DataTable tabla, DataRow rowMinimo)
        {
            for (int i = 2; i < tabla.Columns.Count; i++)
            {
                rowMinimo[i] = Math.Round(GetMinDeColumna(tabla, i), 2);
            }
        }

        private decimal GetMinDeColumna(DataTable tabla, int col)
        {
            decimal resultado = 9999999;
            for (int i = 0; i < tabla.Rows.Count - 4; i++)
            {
                DataRow r = tabla.Rows[i];
                if (!(r[col] is DBNull))
                {
                    decimal valor = (decimal)r[col];
                    if (valor < resultado)
                    {
                        resultado = valor;
                    }
                }
            }
            return resultado;
        }

        private void CalcularDesvStd(DataTable tabla, DataRow rowDesvStd)
        {
            for (int i = 2; i < tabla.Columns.Count; i++)
            {
                rowDesvStd[i] = Math.Round(GetDesvStdDeColumna(tabla, i, GetPromedioDeColumna(tabla, i)), 2);
            }
        }

        private decimal GetDesvStdDeColumna(DataTable tabla, int col, decimal promedio)
        {
            decimal resultado = 0;
            decimal sumatoria = 0;
            for (int i = 0; i < tabla.Rows.Count - 4; i++)
            {
                DataRow r = tabla.Rows[i];
                if (!(r[col] is DBNull))
                {
                    decimal valor = (decimal)r[col];
                    sumatoria += (decimal)Math.Pow((double)(valor - promedio), 2);
                }
            }

            if (tabla.Rows.Count > 5)
            {
                resultado = sumatoria / (tabla.Rows.Count - 5);
                resultado = (decimal)Math.Sqrt((double)resultado);
            }
            else
            {
                resultado = 0;
            }
            return resultado;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (!_dgvSerieHidrologica.EndEdit())
            {
                return;
            }
            if (DatosValidos())
            {
                if (_dgvSerieHidrologica.Rows.Count - 4 > 0)
                {
                    for (int i = 0; i < _dgvSerieHidrologica.Rows.Count - 4; i++)
                    {
                        DataRow row = ((DataRowView)_dgvSerieHidrologica.Rows[i].DataBoundItem).Row;
                        _serieHidrologica = new SerieHidrologica();

                        _serieHidrologica.FkProyecto = _proyecto.PkProyecto;
                        if (row[0] is DBNull || row[0] == null)
                        {
                            _serieHidrologica.EsNuevo = true;
                        }
                        else
                        {
                            _serieHidrologica.EsNuevo = false;
                            _serieHidrologica.PkSerieHidrologica = (long)row[0];
                        }
                        _serieHidrologica.Anio = row[1].ToString();
                        _serieHidrologica.CapacidadEnero = (decimal)row[2];
                        _serieHidrologica.CapacidadFebrero = (decimal)row[3];
                        _serieHidrologica.CapacidadMarzo = (decimal)row[4];
                        _serieHidrologica.CapacidadAbril = (decimal)row[5];
                        _serieHidrologica.CapacidadMayo = (decimal)row[6];
                        _serieHidrologica.CapacidadJunio = (decimal)row[7];
                        _serieHidrologica.CapacidadJulio = (decimal)row[8];
                        _serieHidrologica.CapacidadAgosto = (decimal)row[9];
                        _serieHidrologica.CapacidadSeptiembre = (decimal)row[10];
                        _serieHidrologica.CapacidadOctubre = (decimal)row[11];
                        _serieHidrologica.CapacidadNoviembre = (decimal)row[12];
                        _serieHidrologica.CapacidadDiciembre = (decimal)row[13];

                        OraDalSerieHidrologicaMgr.Instancia.Guardar(_serieHidrologica);
                    }
                }
                OraDalSerieHidrologicaMgr.Instancia.SetTablaSeriesDePkProyecto(_proyecto.PkProyecto, _tabla);
                _dgvSerieHidrologica.DataSource = _tabla;
                _dgvSerieHidrologica.Columns[1].Frozen = true;
                CargarFilasCalculables();
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            _dgvSerieHidrologica.EndEdit();
            for (int i = 0; i < _dgvSerieHidrologica.Rows.Count - 4; i++)
            {
                DataRow row = ((DataRowView)_dgvSerieHidrologica.Rows[i].DataBoundItem).Row;
                for (int j = 1; j <= 13; j++)
                {
                    if ((row[j] is DBNull) || !Utiles.EsDecimalPositivoYCero(row[j].ToString()))
                    {
                        res = false;
                        _errorProvider.SetError(_dgvSerieHidrologica, "No se registraron todos los datos.");
                        break;
                    }
                }
                if (!res)
                {
                    break;
                }
            }
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            FormatoDeLasFilasYColumnas();
            _seGuardo = false;
        }

        private void _dgvSerieHidrologica_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _dgvSerieHidrologica.Rows[e.RowIndex].ErrorText = string.Empty;
            int fila = e.RowIndex;
            int columna = e.ColumnIndex;
            ActualizarCamposCalculables(fila, columna);
        }

        private void ActualizarCamposCalculables(int fila, int columna)
        {
            if (fila < _tabla.Rows.Count - 4 && columna > 1 && columna < _tabla.Columns.Count - 1)
            {
                decimal promedio = GetPromedioDeColumna(_tabla, columna);
                rowPromedio[columna] = promedio;
                rowMaximo[columna] = GetMaxDeColumna(_tabla, columna);
                rowMinimo[columna] = GetMinDeColumna(_tabla, columna);
                rowDesvStd[columna] = GetDesvStdDeColumna(_tabla, columna, promedio);
                CalcularAnual(fila);
                _dgvSerieHidrologica.Refresh();
            }
        }

        public void CalcularSerieAnual()
        {
            for (int i = 0; i < _tabla.Rows.Count - 4; i++)
            {
                CalcularAnual(i);
            }
        }

        private void CalcularAnual(int fila)
        {
            decimal sumatoria = 0;
            for (int i = 2; i < _tabla.Columns.Count - 1; i++)
            {
                if (!(_tabla.Rows[fila][i] is DBNull))
                {
                    sumatoria += (decimal)_tabla.Rows[fila][i];
                }
            }
            _tabla.Rows[fila][_tabla.Columns.Count - 1] = sumatoria;

            rowPromedio["Anual"] = GetPromedioDeColumna(_tabla, 14);
            rowMaximo["Anual"] = GetMaxDeColumna(_tabla, 14);
            rowMinimo["Anual"] = GetMinDeColumna(_tabla, 14);
            rowDesvStd["Anual"] = GetDesvStdDeColumna(_tabla, 14, GetPromedioDeColumna(_tabla, 14));
        }

        private void _dgvSerieHidrologica_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            _dgvSerieHidrologica.Rows[e.RowIndex].ErrorText = string.Empty;
            if (e.RowIndex < _tabla.Rows.Count - 4 && e.ColumnIndex > 1 && e.ColumnIndex < _tabla.Columns.Count - 1)
            {

                if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                {
                    _dgvSerieHidrologica.Rows[e.RowIndex].ErrorText = "Existen errores en el registro de datos.";
                    e.Cancel = true;
                }
            }
        }

        private void _dgvSerieHidrologica_SelectionChanged(object sender, EventArgs e)
        {
            _serieHidrologica = null;
            _idx = -1;
            if (_dgvSerieHidrologica.SelectedCells.Count > 0)
            {
                _idx = _dgvSerieHidrologica.SelectedCells[0].RowIndex;
            }
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            OraDalSerieHidrologicaMgr.Instancia.SetTablaSeriesDePkProyecto(_proyecto.PkProyecto, _tabla);
            if (_tabla.Rows.Count == 0)
            {
                _tsbCrearSerieHidrologicaImpExcel.Enabled = true;
            }
            else
            {
                _tsbCrearSerieHidrologicaImpExcel.Enabled = false;
                CargarFilasCalculables();
            }
            ActivarDesActivarControles();
        }

        private void _dgvSerieHidrologica_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string valor = e.Value.ToString();
            _dgvSerieHidrologica.Rows[e.RowIndex].ErrorText = string.Empty;
            if (e.RowIndex < _tabla.Rows.Count - 4 && e.ColumnIndex > 1 && e.ColumnIndex < _tabla.Columns.Count - 1)
            {
                if (!Utiles.EsDecimalPositivoYCero(valor))
                {
                    _dgvSerieHidrologica.Rows[e.RowIndex].ErrorText = "Existen errores en el registro de datos.";
                    e.ParsingApplied = false;
                }
            }
        }

        private void FormatoDeLasFilasYColumnas()
        {
            int rowsCount = _dgvSerieHidrologica.RowCount;
            if (rowsCount == 0)
            {
            }
            else
            {
                _dgvSerieHidrologica.Rows[rowsCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvSerieHidrologica.Rows[rowsCount - 2].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvSerieHidrologica.Rows[rowsCount - 3].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvSerieHidrologica.Rows[rowsCount - 4].DefaultCellStyle.BackColor = Color.LightBlue;

                _dgvSerieHidrologica.Rows[rowsCount - 1].ReadOnly = true;
                _dgvSerieHidrologica.Rows[rowsCount - 2].ReadOnly = true;
                _dgvSerieHidrologica.Rows[rowsCount - 3].ReadOnly = true;
                _dgvSerieHidrologica.Rows[rowsCount - 4].ReadOnly = true;
                _dgvSerieHidrologica.Columns["Anual"].ReadOnly = true;
                _dgvSerieHidrologica.Columns["Año"].ReadOnly = true;
               // _dgvSerieHidrologica.Columns["Anual"].DefaultCellStyle.BackColor = Color.LightBlue;
               // _dgvSerieHidrologica.Columns["Año"].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void _tsbCrearSerieHidrologicaImpExcel_Click(object sender, EventArgs e)
        {
            FormCrearSerieHidrologica form = new FormCrearSerieHidrologica();
            form.CrearSerieImpDocumento(_proyecto, _tabla);
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                _tabla = form.GetTabla();
                _dgvSerieHidrologica.DataSource = _tabla;
                _dgvSerieHidrologica.Columns[1].Frozen = true;
                CargarFilasCalculables();
                _tsbCrearSerieHidrologicaImpExcel.Enabled = false;
                HabilitarControles();
            }
            else
            {
                if (res == DialogResult.No)
                {
                    _tabla.Rows.Clear();
                    _dgvSerieHidrologica.DataSource = _tabla;
                    MessageBox.Show("La configuración de la migración de datos no fue correcta.");
                }
                _tsbCrearSerieHidrologicaImpExcel.Enabled = true;
            }
        }

        private void _tsbEliminarSerie_Click(object sender, EventArgs e)
        {
            if (_dgvSerieHidrologica.Rows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar toda la serie hidrológica del proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    OraDalSerieHidrologicaMgr.Instancia.EliminarSerie(_proyecto.PkProyecto);
                    _tabla.Rows.Clear();
                    _dgvSerieHidrologica.DataSource = _tabla;
                    _dgvSerieHidrologica.Columns[1].Frozen = true;
                    _dgvSerieHidrologica.Refresh();

                    _tsbCrearSerieHidrologicaImpExcel.Enabled = true;

                    DeshabilitarControles();
                    _seGuardo = true;
                }
            }
        }

        private void ActualizarCamposCalculables()
        {
            CalcularPromedios(_tabla, rowPromedio);
            CalcularMaximo(_tabla, rowMaximo);
            CalcularMinimo(_tabla, rowMinimo);
            CalcularDesvStd(_tabla, rowDesvStd);
            CalcularSerieAnual();
        }

        private void _btnPegarDeExcel_Click(object sender, EventArgs e)
        {
            int fila = _dgvSerieHidrologica.SelectedCells[0].RowIndex;
            int columna = _dgvSerieHidrologica.SelectedCells[0].ColumnIndex;

            IDataObject data = Clipboard.GetDataObject();
            string mensaje = string.Empty;
            if (data.GetDataPresent(DataFormats.Text))
            {
                string datos = data.GetData(DataFormats.Text).ToString();
                try
                {
                    decimal[][] datosNum = ClipboardMgr.Instancia.GetDatos(datos);
                    if (columna == 1 || columna + datosNum[0].Length >= _tabla.Columns.Count
                        || fila >= _tabla.Rows.Count - 4 || fila + datosNum.Length > _tabla.Rows.Count - 4)
                    {
                        mensaje = "No es posible pegar en esta ubicación.";
                    }
                    else
                    {
                        ClipboardMgr.Instancia.Copiar(_tabla, fila, columna, datosNum);
                        ActualizarCamposCalculables();
                    }
                }
                catch (FormatException fEx)
                {
                    mensaje = fEx.Message;
                }
                catch (Exception ex)
                {
                }

                if (!string.IsNullOrEmpty(mensaje))
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        public void SetEstadoToolBar(bool estado)
        {
            if (estado)
            {
                _toolStrip.Enabled = true;
                _tsbOpcionesDeEdicion.Enabled = true;
            }
            else
            {
                _toolStrip.Enabled = false;
                _tsbOpcionesDeEdicion.Enabled = false;
            }
        }

        private void CrearSerieHidroEnBlanco()
        {
            FormCrearSerieHidrologica form = new FormCrearSerieHidrologica();
            form.CrearSerieEnBanco(_proyecto, _tabla);
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                _tabla = form.GetTabla();
                _dgvSerieHidrologica.DataSource = _tabla;
                _dgvSerieHidrologica.Columns[1].Frozen = true;
                CargarFilasCalculables();
                _tsbCrearSerieHidrologicaImpExcel.Enabled = false;
                HabilitarControles();
                _seGuardo = false;
            }
            else
            {
                _tsbCrearSerieHidrologicaImpExcel.Enabled = true;
            }
        }

        private void _btnAdFilaInicio_Click(object sender, EventArgs e)
        {
            if (_dgvSerieHidrologica.Rows.Count > 0)
            {
                DataRow row = _tabla.NewRow();
                row[1] = int.Parse((string)_tabla.Rows[0][1]) - 1;
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
                row[14] = 0;
                _tabla.Rows.InsertAt(row, 0);
                ActualizarCamposCalculables();
            }
            else
            {
                CrearSerieHidroEnBlanco();
            }
        }

        private void _btnAdFilaFin_Click(object sender, EventArgs e)
        {
            if (_dgvSerieHidrologica.Rows.Count > 0)
            {
                DataRow row = _tabla.NewRow();
                row[1] = int.Parse((string)_tabla.Rows[_tabla.Rows.Count - 5][1]) + 1;
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
                row[14] = 0;
                row[13] = 0;
                _tabla.Rows.InsertAt(row, _tabla.Rows.Count - 4);
                ActualizarCamposCalculables();
            }
            else
            {
                CrearSerieHidroEnBlanco();
            }
        }

        private void EliminarRow(DataRow row)
        {
            if (row["Pk_Serie"] is DBNull || row["Pk_Serie"] == null)
            {
            }
            else
            {
                long pkSerie = long.Parse(row["Pk_Serie"].ToString());
                _serieHidrologica = OraDalSerieHidrologicaMgr.Instancia.GetPorId<SerieHidrologica>(pkSerie, SerieHidrologica.C_PK_SERIE_HIDROLOGICA);
                OraDalSerieHidrologicaMgr.Instancia.EliminarSeriePorPkSerie(_proyecto.PkProyecto, _serieHidrologica.PkSerieHidrologica);
                //DeshabilitarControles();
            }

            _tabla.Rows.Remove(row);

            if (_tabla.Rows.Count == 4)
            {
                _tabla.Rows.Clear();
            }
            else
            {
                ActualizarCamposCalculables();
            }
        }

        private void _btnElimFilaInicio_Click(object sender, EventArgs e)
        {
            if (_tabla.Rows.Count > 0)
            {
                DataRow row = _tabla.Rows[0];
                EliminarRow(row);
            }

            _tsbCrearSerieHidrologicaImpExcel.Enabled = _dgvSerieHidrologica.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_tsbCrearSerieHidrologicaImpExcel.Enabled;
        }

        private void _btnElimFilaFin_Click(object sender, EventArgs e)
        {
            if (_tabla.Rows.Count > 0)
            {
                DataRow row = _tabla.Rows[_tabla.Rows.Count - 5];
                EliminarRow(row);               
            }

            _tsbCrearSerieHidrologicaImpExcel.Enabled = _dgvSerieHidrologica.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_tsbCrearSerieHidrologicaImpExcel.Enabled;
        }
    }
}
