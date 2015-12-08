using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using CNDC.UtilesComunes;
using CNDC.ExceptionHandlerLib;
using OraDalProyectos;
using CNDC.BLL;
using System.Threading;

namespace Proyectos
{
    public partial class CtrlDatosEconomicosYCronogramaInversion : CtrlDatosBase, IControles 
    {
        DataTable _tablaCronograma = new DataTable();
        DataTable _tablaHistoricoCronograma = new DataTable();
        Proyecto _proyectoActual;
        ProyectoMaestro _proyectoMaestro;
        DefDominio _tipoProyecto;
        DatoEconomico _datoEconomico;
        bool _esEditable = false;
        CronogramaDeInversion _cronogramaInv;
        int _idxCronograma = 0;
        const string  MOSTRAR="Mostrar Historico";
        const string  OCULTAR="Ocultar Historico";
        DataGridViewTextBoxEditingControl _dgvTxt = null;
        Type _tipoActual = null;
        bool _seGuardo = true;

        public CtrlDatosEconomicosYCronogramaInversion()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarHeadersTablaCronograma();
                CargarHeadersTablaHistorico();
                _nudAnioRefInformacion.Value = 2012;
                _dgvCronograma.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_dgvCronograma_EditingControlShowing);
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        void _dgvCronograma_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_dgvTxt != null)
            {
                _dgvTxt.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }

            if (_dgvCronograma.CurrentCell.ColumnIndex > 0)
            {
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                _dgvTxt = c;
                _tipoActual = _dgvCronograma.CurrentCell.ValueType;
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
                    isValidChar = false;
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
                //if (txt.Text.Length != 0 || (txt.Text.IndexOf('-') >= 0))
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

        private void CargarHeadersTablaHistorico()
        {
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Monto = new DataColumn("Monto (MMUS$)", typeof(double));

            _tablaHistoricoCronograma.Columns.Add(c_Anio);
            _tablaHistoricoCronograma.Columns.Add(c_Monto);

            _dgvHistoricoCronograma.DataSource = _tablaHistoricoCronograma;
            _dgvHistoricoCronograma.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvHistoricoCronograma.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
           
        }

        private void CargarHeadersTablaCronograma()
        {
            DataColumn c_PkCronograma = new DataColumn("Pk_Cronograma", typeof(long));
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Monto = new DataColumn("Monto (MMUS$)", typeof(double));

            _tablaCronograma.Columns.Add(c_PkCronograma);
            _tablaCronograma.Columns.Add(c_Anio);
            _tablaCronograma.Columns.Add(c_Monto);

            _dgvCronograma.DataSource = _tablaCronograma;
            _dgvCronograma.Columns["Pk_Cronograma"].Visible = false;
            _dgvCronograma.Columns[1].Width = 50;
            _dgvCronograma.Columns[1].ReadOnly = true;
            ((DataGridViewTextBoxColumn)_dgvCronograma.Columns[2]).MaxInputLength = 10;
            _dgvCronograma.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvCronograma.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvCronograma.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtCostoFijoOM.Enabled = false;
            _txtCostovariableOM.Enabled = false;
            _txtInversionTotal.Enabled = false;
            _txtTiempoEjecucion.Enabled = false;
            _txtVidaUtil.Enabled = false;
            _nudAnioRefInformacion.Enabled = false;
            _dtpFechaInicio.Enabled = false;
            _dgvCronograma.ReadOnly = true;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
            _tsbCronograma.Enabled = false;
            _btnEliminarHistorico.Enabled = false;
            _dgvCronograma.AllowUserToAddRows = false;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoEconomico.EsNuevo ? true : false;
            _txtCostoFijoOM.Enabled = true;
            _txtCostovariableOM.Enabled = true;
            _txtInversionTotal.Enabled = true;
            _txtTiempoEjecucion.Enabled = true;
            _txtVidaUtil.Enabled = true;
            _nudAnioRefInformacion.Enabled = true;
            _dtpFechaInicio.Enabled = true;
            _dgvCronograma.ReadOnly = false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
            _tsbCronograma.Enabled = true;
            _btnEliminarHistorico.Enabled = true;
            _dgvCronograma.AllowUserToAddRows = true;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos() && DatosValidosTablaCronograma())
            {
                long anioAntiguo = _datoEconomico.AnioRefInformacion;
                _datoEconomico.AnioRefInformacion = int.Parse(_nudAnioRefInformacion.Value.ToString());
                _datoEconomico.CostoFijoOm = _txtCostoFijoOM.ValDouble;
                _datoEconomico.CostoVariableOm = _txtCostovariableOM.ValDouble;
                _datoEconomico.FechaMinIngresoOperacion = _dtpFechaInicio.Value;
                _datoEconomico.FkProyecto = _proyectoActual.PkProyecto;
                _datoEconomico.TiempoEjecucion = _txtTiempoEjecucion.ValorLong;
                _datoEconomico.VidaUtil = _txtVidaUtil.ValorLong;
                if (_datoEconomico.EsNuevo)
                {
                    _datoEconomico.FechaDeRegistro = _dtpFechaInicio.Value;
                }
                OraDalDatoEconomicoMgr.Instancia.Guardar(_datoEconomico);
                GuardarTablaCronograma(anioAntiguo);
                CargarDatos();
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidosTablaCronograma()
        {
            _errorProvider.Clear();
            _dgvCronograma.EndEdit();
            LimpiarErroresDeTablaCronograma();
            bool res = true;

            for (int i = 0; i < _dgvCronograma.Rows.Count - 1; i++)
            {
                DataRow row = ((DataRowView)_dgvCronograma.Rows[i].DataBoundItem).Row;

                if (row[2] is DBNull || !Utiles.EsDecimalPositivoYCero(row[2].ToString()))
                {
                    res = false;
                    _errorProvider.SetError(_dgvCronograma, "No se registraron todos los datos.");
                    break;
                }

                if (_dgvCronograma.Rows[i].ErrorText != string.Empty)
                {
                    res = false;
                    _errorProvider.SetError(_dgvCronograma, "Existen errores en el ingreso de datos.");
                    break;
                }
            }

            return res;
        }


        private void GuardarTablaCronograma(long anioAntiguo)
        {
            _dgvCronograma.EndEdit();
            if (OraDalCronogramaDeInversionMgr.Instancia.ExisteCronogramaConAnioRef(_datoEconomico.AnioRefInformacion.ToString(), _datoEconomico.PkDatoEconomico))
            {
                OraDalCronogramaDeInversionMgr.Instancia.EliminarCronogramaInv(_datoEconomico.AnioRefInformacion.ToString(), _datoEconomico.PkDatoEconomico);
                OraDalCronogramaDeInversionMgr.Instancia.CambiarRegistrosAEstadoAHistorico(_datoEconomico.PkDatoEconomico);
            }
            else
            {
                OraDalCronogramaDeInversionMgr.Instancia.CambiarEstadoAHistorico(_datoEconomico.PkDatoEconomico, anioAntiguo);
            }
            
            if (_dgvCronograma.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < _dgvCronograma.Rows.Count-1; i++)
                {
                    DataRow row = ((DataRowView)_dgvCronograma.Rows[i].DataBoundItem).Row;
                    _cronogramaInv = new CronogramaDeInversion();
                    _cronogramaInv.EsNuevo = true;
                    _cronogramaInv.Anio = row[1].ToString();
                    _cronogramaInv.Monto = double.Parse(row[2].ToString());
                    _cronogramaInv.FkDatoEconomico = _datoEconomico.PkDatoEconomico;
                    _cronogramaInv.AnioRef = _datoEconomico.AnioRefInformacion;
                    OraDalCronogramaDeInversionMgr.Instancia.Guardar(_cronogramaInv);
                }
                CargarHistoricoCronograma();
            }
            SumarMontosCronograma();
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if ( _txtTiempoEjecucion.ValorLong<0)
            {
                resultado = false;
                _errorProvider.SetError(_txtTiempoEjecucion, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtVidaUtil.ValorLong < 0)
            {
                resultado = false;
                _errorProvider.SetError(_txtVidaUtil, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
            }

            if (_txtCostovariableOM.Visible == true)
            {
                if (_txtCostovariableOM.ValDouble < 0)
                {
                    resultado = false;
                    _errorProvider.SetError(_txtCostovariableOM, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                }
            }

            if (_txtCostoFijoOM.Visible == true)
            {
                if (_txtCostoFijoOM.ValDouble < 0)
                {
                    resultado = false;
                    _errorProvider.SetError(_txtCostoFijoOM, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                }
            }
           
            return resultado;
        }
      
        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtCostoFijoOM.Text = _datoEconomico.CostoFijoOm.ToString("N2");
            _txtCostovariableOM.Text = _datoEconomico.CostoVariableOm.ToString("N2");
            _txtTiempoEjecucion.Text = _datoEconomico.TiempoEjecucion.ToString("N0");
            _txtVidaUtil.Text = _datoEconomico.VidaUtil.ToString("N0");
            _dtpFechaRegistro.Value = _datoEconomico.FechaDeRegistro;
            _dtpFechaInicio.Value = _datoEconomico.FechaMinIngresoOperacion;

            _nudAnioRefInformacion.Value = _datoEconomico.AnioRefInformacion;
            CargarDatosTablaCronograma();
            CargarHistoricoCronograma();
            SumarMontosCronograma();
        }

        private void CargarHistoricoCronograma()
        {
            _tablaHistoricoCronograma.Rows.Clear();
            _tablaHistoricoCronograma = OraDalCronogramaDeInversionMgr.Instancia.GetHistorico(_datoEconomico.PkDatoEconomico);
            DataRow row = _tablaHistoricoCronograma.NewRow();
            decimal suma = 0;
            row[0] = "INV. TOTAL";
            decimal monto = 0;
            for (int i = 1; i < _tablaHistoricoCronograma.Columns.Count; i++)
            {
                suma = 0;
                foreach (DataRow r in _tablaHistoricoCronograma.Rows)
                {
                    if (r[i] is DBNull)
                    {

                    }
                    else
                    {
                        monto = (decimal)r[i];
                        suma = suma + monto;
                    }
                }
                row[i] = (double)suma;
            }
            _tablaHistoricoCronograma.Rows.Add(row);
            _dgvHistoricoCronograma.DataSource = _tablaHistoricoCronograma;
            _dgvHistoricoCronograma.Columns[0].Frozen = true;
            _dgvHistoricoCronograma.Columns[0].Width = 70;

            for (int i = 0; i < _dgvHistoricoCronograma.Columns.Count; i++)
            {
                _dgvHistoricoCronograma.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CargarDatosTablaCronograma()
        {
            int i = 0;
            _tablaCronograma.Rows.Clear();
            List<CronogramaDeInversion> listaDatos = OraDalCronogramaDeInversionMgr.Instancia.GetListPorPkDatoEconomico(_datoEconomico.PkDatoEconomico);
            foreach (CronogramaDeInversion cron in listaDatos)
            {
                i++;
                DataRow row = _tablaCronograma.NewRow();
                row[0] = cron.PkCronogramaInversion;
                row[1] = i;
                row[2] = cron.Monto;
                _tablaCronograma.Rows.Add(row);
            }
            _dgvCronograma.DataSource = _tablaCronograma;
            _dgvCronograma.Columns["Pk_Cronograma"].Visible = false;
            _dgvCronograma.Columns[1].Width = 50;
            _dgvCronograma.Columns[1].ReadOnly = true;
            ((DataGridViewTextBoxColumn)_dgvCronograma.Columns[2]).MaxInputLength = 10;
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtCostoFijoOM.Value = 0;
            _txtCostovariableOM.Value = 0;
            _txtInversionTotal.Value = 0;
            _txtTiempoEjecucion.Value = 0;
            _txtVidaUtil.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _dtpFechaInicio.Value = DateTime.Now.Date;
            _tablaCronograma.Rows.Clear();
            _tablaHistoricoCronograma.Clear();
            _dgvCronograma.Columns["Pk_Cronograma"].Visible = false;
        }

        #region Miembros de IControles

        public string Titulo
        {
            get { return "DATOS ECONOMICOS Y CRONOGRAMA DE INVERSION"; }
        }

        void IControles.SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyectoActual = proyecto;
            _dgvHistoricoCronograma.DataSource = null;
            LimpiarControles();
            _seGuardo = true;
            _datoEconomico = OraDalDatoEconomicoMgr.Instancia.GetPorPkProyecto(_proyectoActual.PkProyecto);
            
            if (_datoEconomico == null)
            {
                _datoEconomico = new DatoEconomico();
                _datoEconomico.EsNuevo = true;
            }
            else
            {
                _datoEconomico.EsNuevo = false;
                CargarDatos();
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
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_proyectoActual.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            DefDominioMgr mgr = new DefDominioMgr();
            _tipoProyecto = mgr.GetPorId<DefDominio>(_proyectoMaestro.DTipoProyecto, DefDominio.C_COD_DOMINIO);
            DefDominio tipoPadre= TipoProyectoUIMgr.Instancia.GetTipoProyPadre(_tipoProyecto);
            if (tipoPadre.CodDominio == 3643)
            {
                _txtCostovariableOM.Visible = false;
                _lblCostoVariable.Visible = false;
            }
            else
            {
                _txtCostovariableOM.Visible = true;
                _lblCostoVariable.Visible = true;
            }
            _dgvCronograma.Columns[0].Visible = false;
        }

        #endregion

        private void _dgvCronograma_SelectionChanged(object sender, EventArgs e)
        {
            _cronogramaInv = null;
            _idxCronograma = -1;
            if (_dgvCronograma.SelectedCells.Count > 0)
            {
                _idxCronograma = _dgvCronograma.SelectedCells[0].RowIndex;
            }
        }

        private void _tsbEliminarCronograma_Click(object sender, EventArgs e)
        {
            if (_dgvCronograma.Rows.Count-1 > 0)
            {
                if (_idxCronograma >= 0 && _idxCronograma <= _dgvCronograma.Rows.Count - 2)
                {
                    DialogResult res = MessageBox.Show("Está seguro de eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        DataRow row = ((DataRowView)_dgvCronograma.Rows[_idxCronograma].DataBoundItem).Row;
                        //if (row["Pk_Cronograma"] is DBNull || row["Pk_Cronograma"]==null)
                        //{
                            _dgvCronograma.Rows.RemoveAt(_idxCronograma);
                        //}
                        //else
                        //{
                        //    long pkCronograma = long.Parse(row["Pk_Cronograma"].ToString());
                        //    _cronogramaInv = OraDalCronogramaDeInversionMgr.Instancia.GetPorId<CronogramaDeInversion>(pkCronograma, CronogramaDeInversion.C_PK_CRONOGRAMA_INVERSION);
                        //    OraDalCronogramaDeInversionMgr.Instancia.EliminarRegistro(_cronogramaInv.PkCronogramaInversion);
                        //    _tablaCronograma.Rows.RemoveAt(_idxCronograma);
                        //}
                        SumarMontosCronograma();
                    }
                }
            }
        }

        private void ActualizarIndicesVolumenVsArea()
        {
            int i = 0;
            foreach (DataRow row in _tablaCronograma.Rows)
            {
                i++;
                row[1] = i;
            }
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _dgvCronograma.Columns["Pk_Cronograma"].Visible = false;
            _dgvCronograma.Columns[1].Width = 50;
            _dgvCronograma.Columns[1].ReadOnly = true;
            ((DataGridViewTextBoxColumn)_dgvCronograma.Columns[2]).MaxInputLength = 10;
            _dgvCronograma.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvCronograma.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvCronograma.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            _seGuardo = false;
            _txtTiempoEjecucion.Focus();
        }

        private void _dgvCronograma_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void _dgvCronograma_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _dgvCronograma.Rows[e.RowIndex].ErrorText = string.Empty;
            if (_dgvCronograma.ReadOnly == false)
            {
                SumarMontosCronograma();
            }
        }

        private void SumarMontosCronograma()
        {
            _dgvCronograma.EndEdit();
            double suma = 0;
            int c = 0;
            if (!_dgvCronograma.ReadOnly)
            {
                c = 1;
            }
            if (_dgvCronograma.Rows.Count - c > 0)
            {
                for (int i = 0; i < _dgvCronograma.Rows.Count - c; i++)
                {
                    DataRow row = ((DataRowView)_dgvCronograma.Rows[i].DataBoundItem).Row;
                    suma = suma + (double)row[2];
                }
            }
            _txtInversionTotal.Text = suma.ToString("N2");
        }

        private void _dgvCronograma_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            _dgvCronograma.Rows[e.RowIndex].ErrorText = string.Empty;
            _dgvCronograma.Rows[_dgvCronograma.Rows.Count - 1].ErrorText = string.Empty;
            LimpiarErroresDeTablaCronograma();
            if (_dgvCronograma.ReadOnly == false)
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                        {
                            _dgvCronograma.Rows[e.RowIndex].ErrorText = "Existen errores en el registro de datos.";
                            e.Cancel = true;
                        }
                        break;
                }
            }
        }

        private void LimpiarErroresDeTablaCronograma()
        {
            for (int i = 0; i < _dgvCronograma.Rows.Count - 1; i++)
            {
                _dgvCronograma.Rows[i].ErrorText = string.Empty;
            }
        }

        private void _tsbVerHistorico_Click(object sender, EventArgs e)
        {
            _dgvHistoricoCronograma.Enabled = true;
            _dgvHistoricoCronograma.Visible = true;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoEconomico.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
        }

        private void _dgvHistoricoCronograma_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == _dgvHistoricoCronograma.Rows.Count - 1)
            {
                _dgvHistoricoCronograma.Rows[_dgvHistoricoCronograma.Rows.Count-1].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void _btnEliminarHistorico_Click(object sender, EventArgs e)
        {
            List<long> aniosRef = OraDalCronogramaDeInversionMgr.Instancia.GetAniosRefHistorico(_datoEconomico.PkDatoEconomico);
            FormElimHistoCronogramaInversion fElimHisto = new FormElimHistoCronogramaInversion();
            if (fElimHisto.Eliminar(_datoEconomico.PkDatoEconomico,aniosRef))
            {
                CargarHistoricoCronograma();
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
    }
}
