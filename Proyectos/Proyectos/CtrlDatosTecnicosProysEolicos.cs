using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using CNDC.UtilesComunes;
using System.Threading;

namespace Proyectos
{
    public partial class CtrlDatosTecnicosProysEolicos : CtrlDatosBase, IControles
    {
        string tipoProyecto = string.Empty;
        DataTable _tablaGeneracion = new DataTable();
        bool _esEditable = false;
        int _idx = -1;
        Proyecto _proyecto;
        ProyectoMaestro _proyectoMaestro;
        DefDominio _dominio;
        DatoTecnicoEolicoSolar _datoTecEolicoSolar;
        GeneracionProbableEolicoSolar _generacionProbable;
        int _idxGeneracion = 0;
        DataGridViewTextBoxEditingControl _dgvTxt = null;
        Type _tipoActual = null;
        bool _seGuardo = true;
        DataRow rowPromedio = null;
        DataRow rowMaximo = null;
        DataRow rowMinimo = null;
        DataRow rowDesvStd = null;
        public CtrlDatosTecnicosProysEolicos()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarHeadersTablaGeneracion();
                CargarCmbTecnologiaEolico();
                _dgvGeneracionPorAnio.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_dgvGeneracionPorAnio_EditingControlShowing);
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        void _dgvGeneracionPorAnio_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_dgvTxt != null)
            {
                _dgvTxt.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }

            if (_dgvGeneracionPorAnio.CurrentCell.ColumnIndex > 0)
            {
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                _dgvTxt = c;
                _tipoActual = _dgvGeneracionPorAnio.CurrentCell.ValueType;
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

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtNroUnidades.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPotenciaInstalada.Enabled = false;
            _txtTecnologia.Enabled = false;
            _cmbTecnologia.Enabled = false;
            _dgvGeneracionPorAnio.ReadOnly = true;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;

            _btnAdFilaInicio.Enabled = false;
            _btnAdFilaFin.Enabled = false;
            _btnElimFilaInicio.Enabled = false;
            _btnElimFilaFin.Enabled = false;

            _btnImportarDeExcel.Enabled = false;
            _btnPegarDeExcel.Enabled = false;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecEolicoSolar.EsNuevo ? true : false;
            _txtNroUnidades.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPotenciaInstalada.Enabled = true;
            _txtTecnologia.Enabled = true;
            _cmbTecnologia.Enabled = true;
            _dgvGeneracionPorAnio.ReadOnly = false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;

            _btnAdFilaInicio.Enabled = true;
            _btnAdFilaFin.Enabled = true;
            _btnElimFilaInicio.Enabled = true;
            _btnElimFilaFin.Enabled = true;

            _btnImportarDeExcel.Enabled = _dgvGeneracionPorAnio.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_btnImportarDeExcel.Enabled;
            FormatoDeLasFilasYColumnas();
        }

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        private void CargarCmbTecnologiaEolico()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTecnologia.DisplayMember = "Descripcion";
            _cmbTecnologia.ValueMember = "CodDominio";
            _cmbTecnologia.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TEC_EOLICA);
        }

        private void CargarHeadersTablaGeneracion()
        {
            DataColumn c_PkGeneracion = new DataColumn("PK_GEN_PROBABLE_EOLICO_SOLAR", typeof(long));
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
            DataColumn c_Promedio = new DataColumn("Promedio", typeof(decimal));
            DataColumn c_Maximo = new DataColumn("Máximo", typeof(decimal));
            DataColumn c_Minimo = new DataColumn("Mínimo", typeof(decimal));

            _tablaGeneracion.Columns.Add(c_PkGeneracion);
            _tablaGeneracion.Columns.Add(c_Anio);
            _tablaGeneracion.Columns.Add(c_Enero);
            _tablaGeneracion.Columns.Add(c_Febrero);
            _tablaGeneracion.Columns.Add(c_Marzo);
            _tablaGeneracion.Columns.Add(c_Abril);
            _tablaGeneracion.Columns.Add(c_Mayo);
            _tablaGeneracion.Columns.Add(c_Junio);
            _tablaGeneracion.Columns.Add(c_Julio);
            _tablaGeneracion.Columns.Add(c_Agosto);
            _tablaGeneracion.Columns.Add(c_Septiembre);
            _tablaGeneracion.Columns.Add(c_Octubre);
            _tablaGeneracion.Columns.Add(c_Noviembre);
            _tablaGeneracion.Columns.Add(c_Diciembre);
            _tablaGeneracion.Columns.Add(c_Anual);
            _tablaGeneracion.Columns.Add(c_Promedio);
            _tablaGeneracion.Columns.Add(c_Maximo);
            _tablaGeneracion.Columns.Add(c_Minimo);

            _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
            _dgvGeneracionPorAnio.Columns["Año"].Width = 55;
            _dgvGeneracionPorAnio.Columns["Enero"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Febrero"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Marzo"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Abril"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Mayo"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Junio"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Julio"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Agosto"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Septiembre"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Octubre"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Noviembre"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Diciembre"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Anual"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Promedio"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Máximo"].Width = 65;
            _dgvGeneracionPorAnio.Columns["Mínimo"].Width = 65;
            _dgvGeneracionPorAnio.Columns[1].Frozen = true;

            _dgvGeneracionPorAnio.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvGeneracionPorAnio.Columns[17].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            FormatoColumnas();
        }

        private void FormatoColumnas()
        {
            _dgvGeneracionPorAnio.Columns[0].Visible = false;
            _dgvGeneracionPorAnio.Columns[1].ReadOnly = true;
            _dgvGeneracionPorAnio.Columns[14].ReadOnly = true;
            _dgvGeneracionPorAnio.Columns[15].ReadOnly = true;
            _dgvGeneracionPorAnio.Columns[16].ReadOnly = true;
            _dgvGeneracionPorAnio.Columns[17].ReadOnly = true;

            //_dgvGeneracionPorAnio.Columns[1].DefaultCellStyle.BackColor = Color.LightBlue;
            //_dgvGeneracionPorAnio.Columns[14].DefaultCellStyle.BackColor = Color.LightBlue;
            //_dgvGeneracionPorAnio.Columns[15].DefaultCellStyle.BackColor = Color.LightBlue;
            //_dgvGeneracionPorAnio.Columns[16].DefaultCellStyle.BackColor = Color.LightBlue;
            //_dgvGeneracionPorAnio.Columns[17].DefaultCellStyle.BackColor = Color.LightBlue;
            int rowsCount = _dgvGeneracionPorAnio.RowCount;
            if (rowsCount == 0)
            {

            }
            else
            {
                _dgvGeneracionPorAnio.Rows[rowsCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 2].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 3].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 4].DefaultCellStyle.BackColor = Color.LightBlue;

                _dgvGeneracionPorAnio.Rows[rowsCount - 1].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 2].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 3].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 4].ReadOnly = true;

                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[2]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[3]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[4]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[5]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[6]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[7]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[8]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[9]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[10]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[11]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[12]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)_dgvGeneracionPorAnio.Columns[13]).MaxInputLength = 15;
            }
        }

        public void SetTipoProy(string tipoProy)
        {
            tipoProyecto = tipoProy;
            if (tipoProy == "Eólico")
            {
                _cmbTecnologia.Visible = true;
                _txtTecnologia.Visible = false;
            }
            else
            {
                _cmbTecnologia.Visible = false;
                _txtTecnologia.Visible = true;
            }
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;
                        
            DefDominioMgr mgr = new DefDominioMgr();
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_proyecto.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            _dominio = mgr.GetPorId<DefDominio>(_proyectoMaestro.DTipoProyecto, DefDominio.C_COD_DOMINIO);
            _datoTecEolicoSolar = OraDalDatoTecnicoEolicoSolarMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            LimpiarControles();

            if (_datoTecEolicoSolar == null)
            {
                _datoTecEolicoSolar = new DatoTecnicoEolicoSolar();
                _datoTecEolicoSolar.EsNuevo = true;
            }
            else
            {
                _datoTecEolicoSolar.EsNuevo = false;
                CargarDatos();
            }

            _tablaGeneracion.Rows.Clear();
            _tablaGeneracion = OraDalGeneracionProbableEolicoSolarMgr.Instancia.GetTablaGeneracionDePkProyecto(_proyecto.PkProyecto, _tablaGeneracion);
            if (_tablaGeneracion.Rows.Count == 0)
            {
                _btnImportarDeExcel.Enabled = true;
            }
            else
            {
                _btnImportarDeExcel.Enabled = false;
                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                CalcularMontos();
                CargarFilasCalculables();
                FormatoColumnas();
            }
            ActivarDesActivarControles();
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
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtNroUnidades.Text = _datoTecEolicoSolar.NroUnidades.ToString("N0");
            _txtObservaciones.Text = _datoTecEolicoSolar.Observaciones;
            _txtPotenciaInstalada.Text = _datoTecEolicoSolar.PotenciaInstalada.ToString("N2");
            _dtpFechaRegistro.Value = _datoTecEolicoSolar.FechaDeRegistro;
            if (_dominio.Descripcion.ToUpper() == "SOLAR")
            {
                _txtTecnologia.Visible = true;
                _cmbTecnologia.Visible = false;
                _txtTecnologia.Text = _datoTecEolicoSolar.Tecnologia;
            }
            else
            {
                _txtTecnologia.Visible = false;
                _cmbTecnologia.Visible = true;
                _cmbTecnologia.SelectedValue = _datoTecEolicoSolar.DCodTecnologiaEolico;
            }
        }


        private void GuardarTablaGeneracion()
        {
            _dgvGeneracionPorAnio.EndEdit();
            if (_dgvGeneracionPorAnio.Rows.Count > 0)
            {
                for (int i = 0; i < _dgvGeneracionPorAnio.Rows.Count-4; i++)
                {
                    DataRow row = ((DataRowView)_dgvGeneracionPorAnio.Rows[i].DataBoundItem).Row;
                    _generacionProbable = new GeneracionProbableEolicoSolar();
                    _generacionProbable.FkProyecto = _proyecto.PkProyecto;
                    if (row[0] is DBNull || row[0] == null)
                    {
                        _generacionProbable.EsNuevo = true;
                    }
                    else
                    {
                        _generacionProbable.EsNuevo = false;
                        _generacionProbable.PkGenProbableEolicoSolar = (long)row[0];
                    }
                    _generacionProbable.Anio = long.Parse(row[1].ToString());
                    _generacionProbable.GeneracionEnero = (decimal)row[2];
                    _generacionProbable.GeneracionFebrero = (decimal)row[3];
                    _generacionProbable.GeneracionMarzo = (decimal)row[4];
                    _generacionProbable.GeneracionAbril = (decimal)row[5];
                    _generacionProbable.GeneracionMayo = (decimal)row[6];
                    _generacionProbable.GeneracionJunio = (decimal)row[7];
                    _generacionProbable.GeneracionJulio = (decimal)row[8];
                    _generacionProbable.GeneracionAgosto = (decimal)row[9];
                    _generacionProbable.GeneracionSeptiembre = (decimal)row[10];
                    _generacionProbable.GeneracionOctubre = (decimal)row[11];
                    _generacionProbable.GeneracionNoviembre = (decimal)row[12];
                    _generacionProbable.GeneracionDiciembre = (decimal)row[13];

                    OraDalGeneracionProbableEolicoSolarMgr.Instancia.Guardar(_generacionProbable);
                }
            }
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtNroUnidades.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPotenciaInstalada.Value = 0;
            _txtTecnologia.Text = string.Empty;
            _dtpFechaRegistro.Value = DateTime.Now;
            _cmbTecnologia.SelectedIndex = 0;
            _tablaGeneracion.Rows.Clear();
            if (_dominio.Descripcion == "SOLAR")
            {
                _txtTecnologia.Visible = true;
                _cmbTecnologia.Visible = false;
            }
            else
            {
                _txtTecnologia.Visible = false;
                _cmbTecnologia.Visible = true;
            }
            _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
            _dgvGeneracionPorAnio.Columns[1].Frozen = true;
            _dgvGeneracionPorAnio.Columns[0].Visible = false;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos() && DatosValidosTabla())
            {
                _datoTecEolicoSolar.FkProyecto = _proyecto.PkProyecto;
                _datoTecEolicoSolar.NroUnidades = _txtNroUnidades.ValorLong;
                _datoTecEolicoSolar.Observaciones = _txtObservaciones.Text;
                _datoTecEolicoSolar.PotenciaInstalada = _txtPotenciaInstalada.ValDouble;
                if (_dominio.Descripcion.ToUpper() == "SOLAR")
                {
                    _datoTecEolicoSolar.Tecnologia = _txtTecnologia.Text;
                }
                else
                {
                    _datoTecEolicoSolar.DCodTecnologiaEolico = (Int64)_cmbTecnologia.SelectedValue;
                }
                if (_datoTecEolicoSolar.EsNuevo)
                {
                    _datoTecEolicoSolar.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoEolicoSolarMgr.Instancia.Guardar(_datoTecEolicoSolar);
                GuardarTablaGeneracion();
                _tablaGeneracion.Rows.Clear();
                _tablaGeneracion = OraDalGeneracionProbableEolicoSolarMgr.Instancia.GetTablaGeneracionDePkProyecto(_proyecto.PkProyecto, _tablaGeneracion);
                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                CalcularMontos();
                CargarFilasCalculables();
                FormatoColumnas();
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidosTabla()
        {
            bool res = true;
            _errorProvider.Clear();
            _dgvGeneracionPorAnio.EndEdit(0);
            for (int i = 0; i < _dgvGeneracionPorAnio.Rows.Count-4 ; i++)
            {
                DataRow row = ((DataRowView)_dgvGeneracionPorAnio.Rows[i].DataBoundItem).Row;
                for (int j = 1 ; j <= 13; j++)
                {
                    if ((row[j] is DBNull) || !Utiles.EsDecimalPositivoYCero(row[j].ToString()))
                    {
                        res = false;
                        _errorProvider.SetError(_dgvGeneracionPorAnio, "No se registraron todos los datos.");
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

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtNroUnidades.ValorLong<0)
            {
                _errorProvider.SetError(_txtNroUnidades, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtPotenciaInstalada.ValDouble < 0)
            {
                _errorProvider.SetError(_txtPotenciaInstalada, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }
            //if (_dominio.Descripcion == "SOLAR")
            //{
            //    if (_txtTecnologia.Text ==string.Empty)
            //    {
            //        _errorProvider.SetError(_txtTecnologia, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            //        res = false;
            //    }
            //}
            return res;
        }

        private void _cmbTecnologia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            FormatoColumnas();
            _seGuardo = false;
            _txtPotenciaInstalada.Focus();
        }

        private void _dgvGeneracionPorAnio_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _dgvGeneracionPorAnio.Rows[e.RowIndex].ErrorText = string.Empty;
            DataRow row = ((DataRowView)_dgvGeneracionPorAnio.Rows[e.RowIndex].DataBoundItem).Row;
            SumarMontos(row);
            CalcularPromedio(row);
            CalcularMaximo(row);
            CalcularMinimo(row);
            if (e.RowIndex < _tablaGeneracion.Rows.Count - 4 && e.ColumnIndex > 1 && e.ColumnIndex < _tablaGeneracion.Columns.Count - 4)
            {
                decimal promedio = GetPromedioDeColumna(_tablaGeneracion, e.ColumnIndex);
                rowPromedio[e.ColumnIndex] = promedio;
                rowMaximo[e.ColumnIndex] = GetMaxDeColumna(_tablaGeneracion, e.ColumnIndex);
                rowMinimo[e.ColumnIndex] = GetMinDeColumna(_tablaGeneracion, e.ColumnIndex);
                rowDesvStd[e.ColumnIndex] = GetDesvStdDeColumna(_tablaGeneracion, e.ColumnIndex, promedio);
                _dgvGeneracionPorAnio.Refresh();
            }
            CalcularMontosDeFilas();
        }

        private void CalcularMontosDeFilas()
        {
            decimal promedio = GetPromedioDeColumna(_tablaGeneracion, 14);
            rowPromedio[14] = promedio;
            rowMaximo[14] = GetMaxDeColumna(_tablaGeneracion, 14);
            rowMinimo[14] = GetMinDeColumna(_tablaGeneracion, 14);
            rowDesvStd[14] = GetDesvStdDeColumna(_tablaGeneracion, 14, promedio);

            promedio = GetPromedioDeColumna(_tablaGeneracion, 15);
            rowPromedio[15] = promedio;
            rowMaximo[15] = GetMaxDeColumna(_tablaGeneracion, 15);
            rowMinimo[15] = GetMinDeColumna(_tablaGeneracion, 15);
            rowDesvStd[15] = GetDesvStdDeColumna(_tablaGeneracion, 15, promedio);

            promedio = GetPromedioDeColumna(_tablaGeneracion, 16);
            rowPromedio[16] = promedio;
            rowMaximo[16] = GetMaxDeColumna(_tablaGeneracion, 16);
            rowMinimo[16] = GetMinDeColumna(_tablaGeneracion, 16);
            rowDesvStd[16] = GetDesvStdDeColumna(_tablaGeneracion, 16, promedio);

            promedio = GetPromedioDeColumna(_tablaGeneracion, 17);
            rowPromedio[17] = promedio;
            rowMaximo[17] = GetMaxDeColumna(_tablaGeneracion, 17);
            rowMinimo[17] = GetMinDeColumna(_tablaGeneracion, 15);
            rowDesvStd[17] = GetDesvStdDeColumna(_tablaGeneracion, 17, promedio);
            _dgvGeneracionPorAnio.Refresh();
        }

        private void SumarMontos(DataRow row)
        {
            decimal sumaAnual = 0;
            for (int i = 2; i <= 13; i++)
            {
                if (Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                {
                    sumaAnual = sumaAnual + (decimal)row[i];
                }
            }
            row["Anual"] = Math.Round(sumaAnual,2);
        }

        private void CalcularPromedio(DataRow row)
        {
            decimal promedio = 0;
            for (int i = 2; i <= 13; i++)
            {
                if (Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                {
                    promedio = promedio + (decimal)row[i];
                }
            }
            row["Promedio"] = Math.Round(promedio/12,2);
        }

        private void CalcularMaximo(DataRow row)
        {
            decimal maximo=0;
            for (int i = 2; i <= 13; i++)
            {
                if (!(row[i] is DBNull) && Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                {
                    decimal valor = (decimal)row[i];
                    if (valor > maximo)
                    {
                        maximo = valor;
                    }
                }
            }
            row["Máximo"] = maximo;
        }

        private void CalcularMinimo(DataRow row)
        {
            decimal minimo = 999999999;
            for (int i = 2; i <= 13; i++)
            {
                if (!(row[i] is DBNull) && Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                {
                    decimal valor = (decimal)row[i];
                    if (valor < minimo)
                    {
                        minimo = valor;
                    }
                }
            }
            row["Mínimo"] = minimo;
        }
        private void CargarFilasCalculables()
        {
            if (_tablaGeneracion.Rows.Count > 0)
            {
                rowPromedio = _tablaGeneracion.NewRow();
                rowPromedio["PK_GEN_PROBABLE_EOLICO_SOLAR"] = 0;
                rowPromedio["Año"] = "PROMEDIO";

                rowMaximo = _tablaGeneracion.NewRow();
                rowMaximo["PK_GEN_PROBABLE_EOLICO_SOLAR"] = 0;
                rowMaximo["Año"] = "MÁXIMO";

                rowMinimo = _tablaGeneracion.NewRow();
                rowMinimo["PK_GEN_PROBABLE_EOLICO_SOLAR"] = 0;
                rowMinimo["Año"] = "MÍNIMO";

                rowDesvStd = _tablaGeneracion.NewRow();
                rowDesvStd["PK_GEN_PROBABLE_EOLICO_SOLAR"] = 0;
                rowDesvStd["Año"] = "DESV. STD.";

                _tablaGeneracion.Rows.Add(rowPromedio);
                _tablaGeneracion.Rows.Add(rowMaximo);
                _tablaGeneracion.Rows.Add(rowMinimo);
                _tablaGeneracion.Rows.Add(rowDesvStd);

                ActualizarCamposCalculables();

                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[0].Visible = false;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                FormatoDeLasFilasYColumnas();
                _dgvGeneracionPorAnio.Refresh();
            }
        }

        private void ActualizarCamposCalculables()
        {
            CalcularPromedios(_tablaGeneracion, rowPromedio);
            CalcularMaximo(_tablaGeneracion, rowMaximo);
            CalcularMinimo(_tablaGeneracion, rowMinimo);
            CalcularDesvStd(_tablaGeneracion, rowDesvStd);
            // CalcularSerieAnual();
        }

        private void FormatoDeLasFilasYColumnas()
        {
            int rowsCount = _dgvGeneracionPorAnio.RowCount;
            if (rowsCount == 0)
            {
            }
            else
            {
                _dgvGeneracionPorAnio.Rows[rowsCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 2].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 3].DefaultCellStyle.BackColor = Color.LightBlue;
                _dgvGeneracionPorAnio.Rows[rowsCount - 4].DefaultCellStyle.BackColor = Color.LightBlue;

                _dgvGeneracionPorAnio.Rows[rowsCount - 1].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 2].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 3].ReadOnly = true;
                _dgvGeneracionPorAnio.Rows[rowsCount - 4].ReadOnly = true;
                _dgvGeneracionPorAnio.Columns["Año"].ReadOnly = true;
                _dgvGeneracionPorAnio.Columns["Anual"].ReadOnly = true;
                _dgvGeneracionPorAnio.Columns["Promedio"].ReadOnly = true;
                _dgvGeneracionPorAnio.Columns["Máximo"].ReadOnly = true;
                _dgvGeneracionPorAnio.Columns["Mínimo"].ReadOnly = true;
                //_dgvGeneracionPorAnio.Columns["Anual"].DefaultCellStyle.BackColor = Color.LightBlue;
                //_dgvGeneracionPorAnio.Columns["Año"].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_dgvGeneracionPorAnio.Rows.Count >= 4)
            {
                for (int i = 0; i < _dgvGeneracionPorAnio.Rows.Count; i++)
                {
                    _dgvGeneracionPorAnio.Rows[i].Frozen = false;
                }
               
                _dgvGeneracionPorAnio.Rows[_dgvGeneracionPorAnio.Rows.Count - 4].Frozen = true;
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
            }
            else
            {
                resultado = 0;
            }
            resultado = (decimal)Math.Sqrt((double)resultado);
            return resultado;
        }


        private void _dgvGeneracionPorAnio_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            _dgvGeneracionPorAnio.Rows[e.RowIndex].ErrorText = string.Empty;
            switch (e.ColumnIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                    {
                        _dgvGeneracionPorAnio.Rows[e.RowIndex].ErrorText = "Existen errores en el registro de datos.";
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void _dgvGeneracionPorAnio_SelectionChanged(object sender, EventArgs e)
        {
            _generacionProbable = null;
            _idxGeneracion = 0;
            _idx = -1;
            _dgvGeneracionPorAnio.EndEdit();
            if (_dgvGeneracionPorAnio.SelectedCells.Count > 0)
            {
                _idx = _dgvGeneracionPorAnio.SelectedCells[0].RowIndex;
            }
        }

        private void _tsbEliminar_Click(object sender, EventArgs e)
        {
            if (_generacionProbable != null)
            {
                if (_generacionProbable.EsNuevo)
                {
                    _dgvGeneracionPorAnio.Rows.RemoveAt(_idxGeneracion);
                }
                else
                {
                    foreach (DataRow row in _tablaGeneracion.Rows)
                    {
                        if ((long)row[0] == _generacionProbable.PkGenProbableEolicoSolar)
                        {
                            _tablaGeneracion.Rows.Remove(row);
                            break;
                        }
                    }
                }
                //SumarMontosCronograma();
            }
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecEolicoSolar.EsNuevo)
            {
                LimpiarControles();
              
            }
            else
            {
                CargarDatos();
            }
            _tablaGeneracion.Rows.Clear();
            _tablaGeneracion = OraDalGeneracionProbableEolicoSolarMgr.Instancia.GetTablaGeneracionDePkProyecto(_proyecto.PkProyecto, _tablaGeneracion);
            if (_tablaGeneracion.Rows.Count == 0)
            {
                _btnImportarDeExcel.Enabled = true;
            }
            else
            {
                _btnImportarDeExcel.Enabled = false;
                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                CalcularMontos();
                CargarFilasCalculables();
                FormatoColumnas();
            }
            ActivarDesActivarControles();
        }

        private void CrearGeneracionEnBlanco()
        {
            FormCrearSerieHidrologica form = new FormCrearSerieHidrologica();
            form.CrearSerieEnBanco(_proyecto, _tablaGeneracion);
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                _tablaGeneracion = form.GetTabla();
                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                CalcularMontos();
                CargarFilasCalculables();
                _btnImportarDeExcel.Enabled = false;
                HabilitarControles();
            }
            else
            {
                _btnImportarDeExcel.Enabled = true;
            }
        }

        private void CalcularMontos()
        {
            foreach (DataRow row in _tablaGeneracion.Rows)
            {
                CalcularMaximo(row);
                CalcularMinimo(row);
                CalcularPromedio(row);
                SumarMontos(row);
            }
        }

        private void _tsbEliminarSerie_Click(object sender, EventArgs e)
        {
            if (_dgvGeneracionPorAnio.Rows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar toda la generación probable de energía del proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    OraDalGeneracionProbableEolicoSolarMgr.Instancia.EliminarSerie(_proyecto.PkProyecto);
                    _tablaGeneracion.Rows.Clear();
                    _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                    _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                    _dgvGeneracionPorAnio.Refresh();
                    _btnImportarDeExcel.Enabled = true;
                    DeshabilitarControles();
                    _seGuardo = true;
                }
            }
        }

        private void _btnPegarDeExcel_Click(object sender, EventArgs e)
        {
            int fila = _dgvGeneracionPorAnio.SelectedCells[0].RowIndex;
            int columna = _dgvGeneracionPorAnio.SelectedCells[0].ColumnIndex;

            IDataObject data = Clipboard.GetDataObject();
            string mensaje = string.Empty;
            if (data.GetDataPresent(DataFormats.Text))
            {
                string datos = data.GetData(DataFormats.Text).ToString();
                try
                {
                    decimal[][] datosNum = ClipboardMgr.Instancia.GetDatos(datos);
                    if (columna == 1 || columna + datosNum[0].Length >= _tablaGeneracion.Columns.Count-3
                        || fila >= _tablaGeneracion.Rows.Count - 4 || fila + datosNum.Length > _tablaGeneracion.Rows.Count - 4)
                    {
                        mensaje = "No es posible pegar en esta ubicación.";
                    }
                    else
                    {
                        ClipboardMgr.Instancia.Copiar(_tablaGeneracion, fila, columna, datosNum);
                        CalcularMontos();
                        CalcularPromedios(_tablaGeneracion, rowPromedio);
                        CalcularMaximo(_tablaGeneracion, rowMaximo);
                        CalcularMinimo(_tablaGeneracion, rowMinimo);
                        CalcularDesvStd(_tablaGeneracion, rowDesvStd);
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
            }
            else
            {
                _toolStrip.Enabled = false;
            }
        }

        private void _btnAdFilaInicio_Click(object sender, EventArgs e)
        {
            if (_dgvGeneracionPorAnio.Rows.Count > 0)
            {
                DataRow row = _tablaGeneracion.NewRow();
                row[1] = int.Parse((string)_tablaGeneracion.Rows[0][1]) - 1;
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
                row[15] = 0;
                row[16] = 0;
                row[17] = 0;
                _tablaGeneracion.Rows.InsertAt(row, 0);
                ActualizarCamposCalculables();
            }
            else
            {
                CrearGeneracionEnBlanco();
            }
        }

        private void _btnAdFilaFin_Click(object sender, EventArgs e)
        {
            if (_dgvGeneracionPorAnio.Rows.Count > 0)
            {
                DataRow row = _tablaGeneracion.NewRow();
                row[1] = int.Parse((string)_tablaGeneracion.Rows[_tablaGeneracion.Rows.Count - 5][1]) + 1;
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
                row[15] = 0;
                row[16] = 0;
                row[17] = 0;
                _tablaGeneracion.Rows.InsertAt(row, _tablaGeneracion.Rows.Count - 4);
                ActualizarCamposCalculables();
            }
            else
            {
                CrearGeneracionEnBlanco();
            }
        }

        private void EliminarRow(DataRow row)
        {
            if (row[0] is DBNull || row[0] == null)
            {
            }
            else
            {
                long pkSerie = long.Parse(row[0].ToString());
                _generacionProbable = OraDalGeneracionProbableEolicoSolarMgr.Instancia.GetPorId<GeneracionProbableEolicoSolar>(pkSerie, GeneracionProbableEolicoSolar.C_PK_GEN_PROBABLE_EOLICO_SOLAR);
                OraDalGeneracionProbableEolicoSolarMgr.Instancia.EliminarSeriePorPkSerie(_proyecto.PkProyecto, _generacionProbable.PkGenProbableEolicoSolar);
                //DeshabilitarControles();
            }

            _tablaGeneracion.Rows.Remove(row);

            if (_tablaGeneracion.Rows.Count == 4)
            {
                _tablaGeneracion.Rows.Clear();
            }
            else
            {
                ActualizarCamposCalculables();
            }
        }

        private void _btnElimFilaInicio_Click(object sender, EventArgs e)
        {
            if (_tablaGeneracion.Rows.Count > 0)
            {
                DataRow row = _tablaGeneracion.Rows[0];
                EliminarRow(row);
            }

            _btnImportarDeExcel.Enabled = _dgvGeneracionPorAnio.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_btnImportarDeExcel.Enabled;
        }

        private void _btnElimFilaFin_Click(object sender, EventArgs e)
        {
            if (_tablaGeneracion.Rows.Count > 0)
            {
                DataRow row = _tablaGeneracion.Rows[_tablaGeneracion.Rows.Count - 5];
                EliminarRow(row);
            }

            _btnImportarDeExcel.Enabled = _dgvGeneracionPorAnio.RowCount == 0;
            _btnPegarDeExcel.Enabled = !_btnImportarDeExcel.Enabled;
        }

        private void _btnImportarDeExcel_Click(object sender, EventArgs e)
        {
            FormCrearSerieHidrologica form = new FormCrearSerieHidrologica();
            form.CrearSerieImpDocumento(_proyecto, _tablaGeneracion);
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                _tablaGeneracion = form.GetTabla();
                _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                _dgvGeneracionPorAnio.Columns[1].Frozen = true;
                CalcularMontos();
                CargarFilasCalculables();
                HabilitarControles();
                _btnImportarDeExcel.Enabled = false;
            }
            else
            {
                if (res == DialogResult.No)
                {
                    _tablaGeneracion.Rows.Clear();
                    _dgvGeneracionPorAnio.DataSource = _tablaGeneracion;
                    MessageBox.Show("La configuración de la migración de datos no fue correcta.");
                }
            }
        }
    }
}
