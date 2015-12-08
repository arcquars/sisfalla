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
using CNDCZedGraphLib;

namespace Proyectos
{
    public partial class CtrlDatosTecnicosHidroelectricos : CtrlDatosBase, IControles
    {
        DataTable _tablaVoumenVsProduccion = new DataTable();
        DataTable _tablaVoumenVsArea = new DataTable();
        DataTable tablaEntidades = new DataTable();
        ProyectoMaestro _proyVertimiento;
        ProyectoMaestro _proyTurbinamiento;
        ProyectoMaestro _proyInfiltracion;
        DefDominio _tipoProyecto;
        bool _esEditable = false;
        Proyecto _proyecto;
        ProyectoMaestro _proyectoMaestro;
        DatoTecnicoHidroelectrico _datoTecHidroelectrico;
        VolumenVsArea _volumenArea;
        VolumenVsFactorDeProduccion _volumenProduccion;
        int _idxVolumenArea = 0;
        int _idxVolumenProduccion = 0;
        DataGridViewTextBoxEditingControl _dgvTxt = null;
        Type _tipoActual = null;
        bool _seGuardo = true;
        public CtrlDatosTecnicosHidroelectricos()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbTipoTurbina();
                CargarHedersTablaVolumenVsArea();
                CargarHeadersTablaVolumenVsProductividad();
                _dgvVolVsArea.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_dgvVolVsArea_EditingControlShowing);
                _dgvVolVsProduccion.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_dgvVolVsProduccion_EditingControlShowing);
            }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }
        void _dgvVolVsProduccion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_dgvTxt != null)
            {
                _dgvTxt.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }

            if (_dgvVolVsProduccion.CurrentCell.ColumnIndex > 0)
            {
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                _dgvTxt = c;
                _tipoActual = _dgvVolVsProduccion.CurrentCell.ValueType;
            }
        }

        void _dgvVolVsArea_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (_dgvTxt != null)
            {
                _dgvTxt.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }

            if (_dgvVolVsArea.CurrentCell.ColumnIndex > 0)
            {
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                _dgvTxt = c;
                _tipoActual = _dgvVolVsArea.CurrentCell.ValueType;
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

        private void CargarHedersTablaVolumenVsArea()
        {
            _tablaVoumenVsArea.Rows.Clear();
            DataColumn c_PkVolumen = new DataColumn("Pk.", typeof(long));
            DataColumn c_Nro = new DataColumn("Nro.", typeof(string));
            DataColumn c_Volumen = new DataColumn("Volumen (hm3)", typeof(double));
            DataColumn c_Area = new DataColumn("Área (Km2)", typeof(double));

            _tablaVoumenVsArea.Columns.Add(c_PkVolumen);
            _tablaVoumenVsArea.Columns.Add(c_Nro);
            _tablaVoumenVsArea.Columns.Add(c_Volumen);
            _tablaVoumenVsArea.Columns.Add(c_Area);

            _dgvVolVsArea.DataSource = _tablaVoumenVsArea;
            FormatoColumnasVsArea();
            _dgvVolVsArea.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsArea.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsArea.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsArea.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void CargarHeadersTablaVolumenVsProductividad()
        {
            _tablaVoumenVsProduccion.Rows.Clear();
            DataColumn c_PkVolumen = new DataColumn("Pk.", typeof(long));
            DataColumn c_Nro = new DataColumn("Nro.", typeof(string));
            DataColumn c_Volumen = new DataColumn("Volumen (hm3)", typeof(double));
            DataColumn c_Produccion = new DataColumn("Factor de producción (MW/m3/s)", typeof(double));

            _tablaVoumenVsProduccion.Columns.Add(c_PkVolumen);
            _tablaVoumenVsProduccion.Columns.Add(c_Nro);
            _tablaVoumenVsProduccion.Columns.Add(c_Volumen);
            _tablaVoumenVsProduccion.Columns.Add(c_Produccion);

            _dgvVolVsProduccion.DataSource = _tablaVoumenVsProduccion;
            FormatoColumnasVolumenVsProduccion();
            _dgvVolVsProduccion.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsProduccion.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsProduccion.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            _dgvVolVsProduccion.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtAreaCuenca.Enabled = false;
            _txtCaidaBruta.Enabled = false;
            _txtCaudalDiseno.Enabled = false;
            //_txtCodigoProyInfiltracion.Enabled = false;
            //_txtCodigoProyTurbinamiento.Enabled = false;
            //_txtCodigoProyVertimiento.Enabled = false;
            _txtCuenca.Enabled = false;
            _txtFactorProductividad.Enabled = false;
            _txtGeneracionMediaAnual.Enabled = false;
            //_txtInfiltracion.Enabled = false;
            _txtNroUnidades.Enabled = false;
            _txtObservaciones.ReadOnly = true;
            _txtPotenciaInstalada.Enabled = false;
            //_txtTurbinamiento.Enabled = false;
            //_txtVertimiento.Enabled = false;
            _txtVolumenTotal.Enabled = false;
            _txtVolumenUtil.Enabled = false;
            _cmbTipoTurbinas.Enabled = false;
            _dgvVolVsArea.ReadOnly = true;
            _dgvVolVsProduccion.ReadOnly = true;
            _btnInfiltracion.Enabled = false;
            _btnTurbinamiento.Enabled = false;
            _btnVertimiento.Enabled = false;
            _tsbEliminarVolumenProduccion.Enabled = false;
            _tsbElimnarVolumenVsArea.Enabled = false;
            //_tsbMostrarVolumentVsAreaGrafica.Enabled = false;
            //_tsbMostrarGraficaVolumenProduccion.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
            _btnEliminarInfiltracion.Enabled = false;
            _btnEliminarTurbinamiento.Enabled = false;
            _btnEliminarVertimiento.Enabled = false;
            _dgvVolVsProduccion.AllowUserToAddRows = false;
            _dgvVolVsArea.AllowUserToAddRows = false;
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _dtpFechaRegistro.Enabled = _datoTecHidroelectrico.EsNuevo ? true : false;
            _txtAreaCuenca.Enabled = true;
            _txtCaidaBruta.Enabled = true;
            _txtCaudalDiseno.Enabled = true;
            //_txtCodigoProyInfiltracion.Enabled = true;
            //_txtCodigoProyTurbinamiento.Enabled = true;
            //_txtCodigoProyVertimiento.Enabled = true;
            _txtCuenca.Enabled = true;
            _txtFactorProductividad.Enabled = true;
            _txtGeneracionMediaAnual.Enabled = true;
            //_txtInfiltracion.Enabled = true;
            _txtNroUnidades.Enabled = true;
            _txtObservaciones.ReadOnly = false;
            _txtPotenciaInstalada.Enabled = true;
            //_txtTurbinamiento.Enabled = true;
            //_txtVertimiento.Enabled = true;
            _txtVolumenTotal.Enabled = true;
            _txtVolumenUtil.Enabled = true;
            _cmbTipoTurbinas.Enabled = true;
            _dgvVolVsArea.ReadOnly = false;
            _dgvVolVsProduccion.ReadOnly = false;
            _btnInfiltracion.Enabled = true;
            _btnTurbinamiento.Enabled = true;
            _btnVertimiento.Enabled = true;
            _tsbEliminarVolumenProduccion.Enabled = true;
            _tsbElimnarVolumenVsArea.Enabled = true;
            _tsbMostrarVolumentVsAreaGrafica.Enabled = true;
            _tsbMostrarGraficaVolumenProduccion.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
            _btnEliminarInfiltracion.Enabled = true;
            _btnEliminarTurbinamiento.Enabled = true;
            _btnEliminarVertimiento.Enabled = true;

            _dgvVolVsProduccion.AllowUserToAddRows = true;
            _dgvVolVsArea.AllowUserToAddRows = true;
        }

        private void CargarCmbTipoTurbina()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoTurbinas.DisplayMember = "Descripcion";
            _cmbTipoTurbinas.ValueMember = "CodDominio";
            _cmbTipoTurbinas.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_TIPO_TURBINA_HIDRO);
        }

        private void _btnVertimiento_Click(object sender, EventArgs e)
        {
            FormProyectosHidrologicos form = new FormProyectosHidrologicos();
            form.SetTipoProyecto(_tipoProyecto, _proyectoMaestro);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _proyVertimiento = form.GetProySeleccionado();
                _txtVertimiento.Text = _proyVertimiento.Nombre;
                _txtCodigoProyVertimiento.Text = _proyVertimiento.Codigo;
            }
        }

        private void _btnTurbinamiento_Click_1(object sender, EventArgs e)
        {
            FormProyectosHidrologicos form = new FormProyectosHidrologicos();
            form.SetTipoProyecto(_tipoProyecto, _proyectoMaestro);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _proyTurbinamiento = form.GetProySeleccionado();
                _txtTurbinamiento.Text = _proyTurbinamiento.Nombre;
                _txtCodigoProyTurbinamiento.Text = _proyTurbinamiento.Codigo;
            }
        }

        private void _btnInfiltracion_Click(object sender, EventArgs e)
        {
            FormProyectosHidrologicos form = new FormProyectosHidrologicos();
            form.SetTipoProyecto(_tipoProyecto, _proyectoMaestro);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _proyInfiltracion = form.GetProySeleccionado();
                _txtInfiltracion.Text = _proyInfiltracion.Nombre;
                _txtCodigoProyInfiltracion.Text = _proyInfiltracion.Codigo;
            }
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _dtpFechaRegistro.Value = _datoTecHidroelectrico.FechaDeRegistro;

            if (_datoTecHidroelectrico.FkProyInfiltracion == 0)
            {
                _proyInfiltracion = new ProyectoMaestro();
                _proyInfiltracion.Nombre = "";
                _proyInfiltracion.Codigo = "";
            }
            else
            {
                _proyInfiltracion = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_datoTecHidroelectrico.FkProyInfiltracion, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            }

            if (_datoTecHidroelectrico.FkProyTurbinamiento == 0)
            {
                _proyTurbinamiento = new ProyectoMaestro();
                _proyTurbinamiento.Nombre = "";
                _proyTurbinamiento.Codigo = "";
            }
            else
            {
                _proyTurbinamiento = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_datoTecHidroelectrico.FkProyTurbinamiento, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            }

            if (_datoTecHidroelectrico.FkProyVertimiento == 0)
            {
                _proyVertimiento = new ProyectoMaestro();
                _proyVertimiento.Nombre = "";
                _proyVertimiento.Codigo = "";
            }
            else
            {
                _proyVertimiento = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_datoTecHidroelectrico.FkProyVertimiento, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            }

            _txtAreaCuenca.Text = _datoTecHidroelectrico.AreaCuenca.ToString("N2");
            _txtCaidaBruta.Text = _datoTecHidroelectrico.CaidaBruta.ToString("N2");
            _txtCaudalDiseno.Text = _datoTecHidroelectrico.CaudalDiseno.ToString("N2");
            _txtCodigoProyInfiltracion.Text = _proyInfiltracion.Codigo.ToString();
            _txtCodigoProyTurbinamiento.Text = _proyTurbinamiento.Codigo.ToString();
            _txtCodigoProyVertimiento.Text = _proyVertimiento.Codigo.ToString();
            _txtCuenca.Text = _datoTecHidroelectrico.Cuenca;
            _txtFactorProductividad.Text = _datoTecHidroelectrico.FactorProductividad.ToString("N2");
            _txtGeneracionMediaAnual.Text = _datoTecHidroelectrico.GeneracionMediaAnual.ToString("N2");
            _txtInfiltracion.Text = _proyInfiltracion.Nombre;
            _txtNroUnidades.Text = _datoTecHidroelectrico.NroUnidades.ToString("N0");
            _txtObservaciones.Text = _datoTecHidroelectrico.Observaciones;
            _txtPotenciaInstalada.Text = _datoTecHidroelectrico.PotenciaInstalada.ToString("N2");
            _txtTurbinamiento.Text = _proyTurbinamiento.Nombre;
            _txtVertimiento.Text = _proyVertimiento.Nombre;
            _txtVolumenTotal.Text = _datoTecHidroelectrico.VolumenTotal.ToString("N2");
            _txtVolumenUtil.Text = _datoTecHidroelectrico.VolumenUtil.ToString("N2");
            _cmbTipoTurbinas.SelectedValue = _datoTecHidroelectrico.DCodTurbinaHidroelectrica;
            CargarDatosVolumenVsProduccion();
            CargarDatosVolumenVsArea();
        }

        private void CargarDatosVolumenVsProduccion()
        {
            int i = 0;
            _tablaVoumenVsProduccion.Rows.Clear();
            List<VolumenVsFactorDeProduccion> listaDatos = OraDalVolumenVsFactorDeProduccionMgr.Instancia.GetListPorPkDatoTecnico(_datoTecHidroelectrico.PkDatoTecHidroelectrico);
            foreach (VolumenVsFactorDeProduccion vol in listaDatos)
            {
                i++;
                DataRow row = _tablaVoumenVsProduccion.NewRow();
                row[0] = vol.PkVolVsFactProduccion;
                row[1] = i;
                row[2] = vol.Volumen;
                row[3] = vol.FactorProductividad;
                _tablaVoumenVsProduccion.Rows.Add(row);
            }
            _dgvVolVsProduccion.DataSource = _tablaVoumenVsProduccion;
            FormatoColumnasVolumenVsProduccion();
            MostrarGraficaVolumenVsProduccion();
        }

        private void CargarDatosVolumenVsArea()
        {
            int i = 0;
            _tablaVoumenVsArea.Rows.Clear();
            List<VolumenVsArea> listaDatos = OraDalVolumenVsAreaMgr.Instancia.GetListPorPkDatoTecnico(_datoTecHidroelectrico.PkDatoTecHidroelectrico);
            foreach (VolumenVsArea vol in listaDatos)
            {
                i++;
                DataRow row = _tablaVoumenVsArea.NewRow();
                row[0] = vol.PkVolumenVsArea;
                row[1] = i;
                row[2] = vol.Volumen;
                row[3] = vol.Area;
                _tablaVoumenVsArea.Rows.Add(row);
            }
            _dgvVolVsArea.DataSource = _tablaVoumenVsArea;
            FormatoColumnasVsArea();
            MostrarGraficaVolumenVsArea();
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtAreaCuenca.Value = 0;
            _txtCaidaBruta.Value = 0;
            _txtCaudalDiseno.Value = 0;
            _txtCodigoProyInfiltracion.Text = string.Empty;
            _txtCodigoProyTurbinamiento.Text = string.Empty;
            _txtCodigoProyVertimiento.Text = string.Empty;
            _txtCuenca.Text = string.Empty;
            _txtFactorProductividad.Value = 0;
            _txtGeneracionMediaAnual.Value = 0;
            _txtInfiltracion.Text = string.Empty;
            _txtNroUnidades.Value = 0;
            _txtObservaciones.Text = string.Empty;
            _txtPotenciaInstalada.Value = 0;
            _txtTurbinamiento.Text = string.Empty;
            _txtVertimiento.Text = string.Empty;
            _txtVolumenTotal.Value = 0;
            _txtVolumenUtil.Value = 0;
            _tablaVoumenVsArea.Rows.Clear();
            _tablaVoumenVsProduccion.Rows.Clear();
            _dtpFechaRegistro.Value = DateTime.Now.Date;
            _ctrlZGArea.Limpiar();
            _ctrlZGProduccion.Limpiar();
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos() && DatosValidosTablaVolumenProduccion() && DatosValidosTablaVolumenArea())
            {
                _datoTecHidroelectrico.AreaCuenca = _txtAreaCuenca.ValDouble;
                _datoTecHidroelectrico.CaidaBruta = _txtCaidaBruta.ValDouble;
                _datoTecHidroelectrico.CaudalDiseno = _txtCaudalDiseno.ValDouble;
                _datoTecHidroelectrico.Cuenca = _txtCuenca.Text;
                _datoTecHidroelectrico.DCodTurbinaHidroelectrica = (Int64)_cmbTipoTurbinas.SelectedValue;
                _datoTecHidroelectrico.FactorProductividad = _txtFactorProductividad.ValDouble;
                _datoTecHidroelectrico.FkProyecto = _proyecto.PkProyecto;
                _datoTecHidroelectrico.FkProyInfiltracion = _proyInfiltracion.PkProyectoMaestro;
                _datoTecHidroelectrico.FkProyTurbinamiento = _proyTurbinamiento.PkProyectoMaestro;
                _datoTecHidroelectrico.FkProyVertimiento = _proyVertimiento.PkProyectoMaestro;
                _datoTecHidroelectrico.GeneracionMediaAnual = _txtGeneracionMediaAnual.ValDouble;
                _datoTecHidroelectrico.NroUnidades = _txtNroUnidades.ValorLong;
                _datoTecHidroelectrico.Observaciones = _txtObservaciones.Text;
                _datoTecHidroelectrico.PotenciaInstalada = _txtPotenciaInstalada.ValDouble;
                _datoTecHidroelectrico.VolumenTotal = _txtVolumenTotal.ValDouble;
                _datoTecHidroelectrico.VolumenUtil = _txtVolumenUtil.ValDouble;
                if (_datoTecHidroelectrico.EsNuevo)
                {
                    _datoTecHidroelectrico.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalDatoTecnicoHidroelectricoMgr.Instancia.Guardar(_datoTecHidroelectrico);
                GuardarTablaVolumenVsArea();
                GuardarTablaVolumenVsProductividad();
                CargarDatosVolumenVsArea();
                CargarDatosVolumenVsProduccion();
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidosTablaVolumenArea()
        {
            _errorProvider.Clear();
            _dgvVolVsArea.EndEdit();
            LimpiarMensajesDeErroresArea();
            bool res = true;
            for (int i = 0; i < _dgvVolVsArea.Rows.Count - 1; i++)
            {
                DataRow row = ((DataRowView)_dgvVolVsArea.Rows[i].DataBoundItem).Row;
                for (int j = 2; j <= 3; j++)
                {
                    if ((row[j] is DBNull) || !Utiles.EsDecimalPositivoYCero(row[j].ToString()))
                    {
                        res = false;
                        _errorProvider.SetError(_dgvVolVsArea, "No se registraron todos los datos.");
                        break;
                    }
                }

                if (_dgvVolVsArea.Rows[i].ErrorText != string.Empty)
                {
                    res = false;
                    _errorProvider.SetError(_dgvVolVsArea, "Existen errores en el ingreso de datos.");
                    break;
                }
            }

            if (res)
            {
                if (_dgvVolVsArea.Rows.Count - 1 > 1)
                {

                    for (int i = 1; i < _dgvVolVsArea.Rows.Count - 1; i++)
                    {
                        // columna 2
                        if (Math.Round( double.Parse(_dgvVolVsArea[2, i].Value.ToString()),2) <= Math.Round(double.Parse(_dgvVolVsArea[2, i - 1].Value.ToString()),2))
                        {
                            res = false;
                            _errorProvider.SetError(_dgvVolVsArea, "Existen errores en el ingreso de datos.");
                            break;
                        }
                    }
                }
            }
            return res;
        }

        private bool DatosValidosTablaVolumenProduccion()
        {
            _errorProvider.Clear();
            bool res = true;
            _dgvVolVsProduccion.EndEdit();
            LimpiarMensajesDeErroresProduccion();
            for (int i = 0; i < _dgvVolVsProduccion.Rows.Count - 1; i++)
            {
                DataRow row = ((DataRowView)_dgvVolVsProduccion.Rows[i].DataBoundItem).Row;
                for (int j = 2; j <= 3; j++)
                {
                    if ((row[j] is DBNull) || !Utiles.EsDecimalPositivoYCero(row[j].ToString()))
                    {
                        res = false;
                        _errorProvider.SetError(_dgvVolVsProduccion, "No se registraron todos los datos.");
                        break;
                    }
                }

                if (_dgvVolVsProduccion.Rows[i].ErrorText != string.Empty)
                {
                    res = false;
                    _errorProvider.SetError(_dgvVolVsProduccion, "Existen errores en el ingreso de datos.");
                    break;
                }
            }
            if (res)
            {
                if (_dgvVolVsProduccion.Rows.Count - 1 > 1)
                {

                    for (int i = 1; i < _dgvVolVsProduccion.Rows.Count - 1; i++)
                    {
                        // columna 2
                        if (Math.Round(double.Parse(_dgvVolVsProduccion[2, i].Value.ToString()),2) <= Math.Round(double.Parse(_dgvVolVsProduccion[2, i - 1].Value.ToString()),2))
                        {
                            res = false;
                            _errorProvider.SetError(_dgvVolVsProduccion, "Existen errores en el ingreso de datos.");
                            break;
                        }

                        //columna 3
                        if (Math.Round(double.Parse(_dgvVolVsProduccion[3, i].Value.ToString()),2) <= Math.Round(double.Parse(_dgvVolVsProduccion[3, i - 1].Value.ToString()),2))
                        {
                            res = false;
                            _errorProvider.SetError(_dgvVolVsProduccion, "Existen errores en el ingreso de datos.");
                            break;
                        }
                    }
                }
            }
           
            return res;
        }

        private void GuardarTablaVolumenVsProductividad()
        {
            _dgvVolVsProduccion.EndEdit();
            OraDalVolumenVsFactorDeProduccionMgr.Instancia.EliminarRegistros(_datoTecHidroelectrico.PkDatoTecHidroelectrico);
            if (_dgvVolVsProduccion.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < _dgvVolVsProduccion.Rows.Count - 1; i++)
                {
                    DataRow row = ((DataRowView)_dgvVolVsProduccion.Rows[i].DataBoundItem).Row;
                    _volumenProduccion = new VolumenVsFactorDeProduccion();
                    _volumenProduccion.EsNuevo = true;
                    _volumenProduccion.Volumen = double.Parse(row[2].ToString());
                    _volumenProduccion.FactorProductividad = double.Parse(row[3].ToString());
                    _volumenProduccion.FkDatoTecHidroelectrico = _datoTecHidroelectrico.PkDatoTecHidroelectrico;
                    OraDalVolumenVsFactorDeProduccionMgr.Instancia.Guardar(_volumenProduccion);
                }
            }
        }

        private void GuardarTablaVolumenVsArea()
        {
            _dgvVolVsArea.EndEdit();
            OraDalVolumenVsAreaMgr.Instancia.EliminarRegistros(_datoTecHidroelectrico.PkDatoTecHidroelectrico);
            if (_dgvVolVsArea.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < _dgvVolVsArea.Rows.Count - 1; i++)
                {
                    DataRow row = ((DataRowView)_dgvVolVsArea.Rows[i].DataBoundItem).Row;
                    _volumenArea = new VolumenVsArea();
                    _volumenArea.EsNuevo = true;
                    _volumenArea.Volumen = double.Parse(row[2].ToString());
                    _volumenArea.Area = double.Parse(row[3].ToString());
                    _volumenArea.FkDatoTecHidroelectrico = _datoTecHidroelectrico.PkDatoTecHidroelectrico;
                    OraDalVolumenVsAreaMgr.Instancia.Guardar(_volumenArea);
                }
            }
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

            if (_txtAreaCuenca.ValDouble < 0)
            {
                _errorProvider.SetError(_txtAreaCuenca, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCaidaBruta.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCaidaBruta, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCaudalDiseno.ValDouble < 0)
            {
                _errorProvider.SetError(_txtCaudalDiseno, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtFactorProductividad.ValDouble < 0)
            {
                _errorProvider.SetError(_txtFactorProductividad, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtGeneracionMediaAnual.ValDouble < 0)
            {
                _errorProvider.SetError(_txtGeneracionMediaAnual, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtVolumenTotal.ValDouble < 0)
            {
                _errorProvider.SetError(_txtVolumenTotal, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtVolumenUtil.ValDouble < 0)
            {
                _errorProvider.SetError(_txtVolumenUtil, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                res = false;
            }

            if (_txtCodigoProyInfiltracion.Text == string.Empty)
            {
                _proyInfiltracion = new ProyectoMaestro();
                _proyInfiltracion.EsNuevo = true;
                _proyInfiltracion.PkProyectoMaestro = 0;
            }

            if (_txtCodigoProyTurbinamiento.Text == string.Empty)
            {
                _proyTurbinamiento = new ProyectoMaestro();
                _proyTurbinamiento.EsNuevo = true;
                _proyTurbinamiento.PkProyectoMaestro = 0;
            }

            if (_txtCodigoProyVertimiento.Text == string.Empty)
            {
                _proyVertimiento = new ProyectoMaestro();
                _proyVertimiento.EsNuevo = true;
                _proyVertimiento.PkProyectoMaestro = 0;
            }

            return res;
        }


        #region Miembros de IControles

        public string Titulo
        {
            get { return "DATOS TECNICOS"; }
        }

        void IControles.SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _seGuardo = true;
            LimpiarControles();
            DefDominioMgr mgr = new DefDominioMgr();
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_proyecto.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            _tipoProyecto = mgr.GetPorId<DefDominio>(_proyectoMaestro.DTipoProyecto, DefDominio.C_COD_DOMINIO);
            _datoTecHidroelectrico = OraDalDatoTecnicoHidroelectricoMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);

            if (_datoTecHidroelectrico == null)
            {
                _datoTecHidroelectrico = new DatoTecnicoHidroelectrico();
                _datoTecHidroelectrico.EsNuevo = true;
            }
            else
            {
                _datoTecHidroelectrico.EsNuevo = false;
                CargarDatos();
            }

            ActivarDesActivarControles();
        }

        private void ActivarDesActivarControles()
        {
            _dgvVolVsArea.Columns[0].Visible = false;
            _dgvVolVsProduccion.Columns[0].Visible = false;
            if (_esEditable)
            {
                HabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
        }

        #endregion

        private void _dgvVolVsArea_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //_dgvVolVsArea.EndEdit();
            _dgvVolVsArea.Rows[e.RowIndex].ErrorText = string.Empty;
            LimpiarMensajesDeErroresArea();
            if (_dgvVolVsArea.ReadOnly == false)
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                        {
                            _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Tiene que registrar un número.";
                            e.Cancel = true;
                        }
                        else if (e.RowIndex > 0)
                        {
                            if (!Utiles.EsDecimalPositivoYCero(_dgvVolVsArea[2, e.RowIndex - 1].Value.ToString()) || !Utiles.EsDecimalPositivoYCero(_dgvVolVsArea[3, e.RowIndex - 1].Value.ToString()))
                            {
                                _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Tiene que registrar el volumen y el área del registro anterior.";
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Math.Round(double.Parse(e.FormattedValue.ToString()), 2) <= Math.Round(double.Parse(_dgvVolVsArea[2, e.RowIndex - 1].Value.ToString()), 2))
                                {
                                    _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Volumen registrado tiene que ser mayor al volumen anterior.";
                                    e.Cancel = true;
                                }
                            }
                        }
                        break;
                    case 3:
                        if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                        {
                            _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Tiene que registrar un número.";
                            e.Cancel = true;
                        }
                        else if (e.RowIndex > 0)
                        {
                            if (!Utiles.EsDecimalPositivoYCero(_dgvVolVsArea[2, e.RowIndex - 1].Value.ToString()) || !Utiles.EsDecimalPositivoYCero(_dgvVolVsArea[3, e.RowIndex - 1].Value.ToString()))
                            {
                                _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Tiene que registrar el volumen y el área del registro anterior.";
                                e.Cancel = true;
                            }

                            if (Math.Round(double.Parse(e.FormattedValue.ToString()), 2) <= Math.Round(double.Parse(_dgvVolVsArea[3, e.RowIndex - 1].Value.ToString()), 2))
                            {
                                _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "El Area registrada tiene que ser mayor al area anterior.";
                                e.Cancel = true;
                            }
                            //if (double.Parse(e.FormattedValue.ToString()) <= double.Parse(_dgvVolVsArea[3, e.RowIndex - 1].Value.ToString()))
                            //{
                            //    _dgvVolVsArea.Rows[e.RowIndex].ErrorText = "Existen errores en el registro de datos.";
                            //    e.Cancel = true;
                            //}
                        }
                        break;
                }
            }
        }

        private void _dgvVolVsProduccion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // _dgvVolVsProduccion.EndEdit();
            _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = string.Empty;
            LimpiarMensajesDeErroresProduccion();
            if (!_dgvVolVsProduccion.ReadOnly)
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                        {
                            _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "Tiene que registrar un número.";
                            e.Cancel = true;
                        }
                        else if (e.RowIndex > 0)
                        {
                            if (!Utiles.EsDecimalPositivoYCero(_dgvVolVsProduccion[2, e.RowIndex - 1].Value.ToString()) || !Utiles.EsDecimalPositivoYCero(_dgvVolVsProduccion[3, e.RowIndex - 1].Value.ToString()))
                            {
                                _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "Tiene que registrar el Volumen y el Factor de producción del registro anterior.";
                                e.Cancel = true;
                            }
                            else if (Math.Round(double.Parse(e.FormattedValue.ToString()), 2) <= Math.Round(double.Parse(_dgvVolVsProduccion[2, e.RowIndex - 1].Value.ToString()), 2))
                            {
                                _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "Volumen registrado tiene que ser mayor al volumen anterior.";
                                e.Cancel = true;
                            }
                        }
                        break;

                    case 3:
                        if (!Utiles.EsDecimalPositivoYCero(e.FormattedValue.ToString()))
                        {
                            _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "Tiene que registrar un número.";
                            e.Cancel = true;
                        }
                        else if (e.RowIndex > 0)
                        {
                            if (!Utiles.EsDecimalPositivoYCero(_dgvVolVsProduccion[2, e.RowIndex - 1].Value.ToString()) || !Utiles.EsDecimalPositivoYCero(_dgvVolVsProduccion[3, e.RowIndex - 1].Value.ToString()))
                            {
                                _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "Tiene que registrar el volumen y el factor de producción del registro anterior.";
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Math.Round(double.Parse(e.FormattedValue.ToString()), 2) <= Math.Round(double.Parse(_dgvVolVsProduccion[3, e.RowIndex - 1].Value.ToString()), 2))
                                {
                                    _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = "El factor de producción registrado tiene que ser mayor al factor de producción anterior.";
                                    e.Cancel = true;
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void LimpiarMensajesDeErroresProduccion()
        {
            for (int i = 0; i < _dgvVolVsProduccion.RowCount; i++)
            {
                _dgvVolVsProduccion.Rows[i].ErrorText = string.Empty;
            }
        }

        private void LimpiarMensajesDeErroresArea()
        {
            for (int i = 0; i < _dgvVolVsArea.RowCount; i++)
            {
                _dgvVolVsArea.Rows[i].ErrorText = string.Empty;
            }
        }

        private void _tsbEliminarVolumenProduccion_Click(object sender, EventArgs e)
        {
            if (_dgvVolVsProduccion.Rows.Count - 1 > 0)
            {
                if (_idxVolumenProduccion >= 0 && _idxVolumenProduccion <= _dgvVolVsProduccion.Rows.Count - 2)
                {
                    DialogResult res = MessageBox.Show("Está seguro de eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        //if (_volumenProduccion.EsNuevo)
                        //{
                            _dgvVolVsProduccion.Rows.RemoveAt(_idxVolumenProduccion);
                        //}
                        //else
                        //{
                            //OraDalVolumenVsFactorDeProduccionMgr.Instancia.EliminarRegistros(_volumenProduccion.PkVolVsFactProduccion);
                            //_tablaVoumenVsProduccion.Rows.RemoveAt(_idxVolumenProduccion);
                        //}
                        _dgvVolVsProduccion.Refresh();
                        MostrarGraficaVolumenVsProduccion();
                    }
                }
            }
        }

        private void _dgvVolVsProduccion_SelectionChanged(object sender, EventArgs e)
        {
            _volumenProduccion = null;
            _idxVolumenProduccion = -1;
            _dgvVolVsProduccion.EndEdit();
            if (_dgvVolVsProduccion.SelectedCells.Count > 0)
            {
                _idxVolumenProduccion = _dgvVolVsProduccion.SelectedCells[0].RowIndex;
                if (_dgvVolVsProduccion.Rows[_idxVolumenProduccion].DataBoundItem != null)
                {
                    DataRow row = ((DataRowView)_dgvVolVsProduccion.Rows[_idxVolumenProduccion].DataBoundItem).Row;
                    if ((row["pk."] is DBNull))
                    {
                        _volumenProduccion = new VolumenVsFactorDeProduccion();
                        _volumenProduccion.EsNuevo = true;
                    }
                    else
                    {
                        long pkVolumen = long.Parse(row["pk."].ToString());
                        _volumenProduccion = OraDalVolumenVsFactorDeProduccionMgr.Instancia.GetPorId<VolumenVsFactorDeProduccion>(pkVolumen, VolumenVsFactorDeProduccion.C_PK_VOL_VS_FACT_PRODUCCION);
                        _volumenProduccion.EsNuevo = false;
                    }
                }
            }
        }

        private void _tsbEliminarVolumenArea_Click(object sender, EventArgs e)
        {
            if (_dgvVolVsArea.Rows.Count - 1 > 0)
            {
                if (_idxVolumenArea >= 0 && _idxVolumenArea <= _dgvVolVsArea.Rows.Count - 2)
                {
                    DialogResult res = MessageBox.Show("Está seguro de eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        //if (_volumenArea.EsNuevo)
                        //{
                        _dgvVolVsArea.Rows.RemoveAt(_idxVolumenArea);
                        //}
                        //else
                        //{
                        //    //OraDalVolumenVsAreaMgr.Instancia.EliminarRegistros(_volumenArea.PkVolumenVsArea);
                        //    //_tablaVoumenVsArea.Rows.RemoveAt(_idxVolumenArea);
                        //}
                        _dgvVolVsArea.Refresh();
                        MostrarGraficaVolumenVsArea();
                    }
                }
            }
        }

        private DataTable ActualizarIndicesVolumenVsArea(DataTable tabla)
        {
            int i = 0;
            DataTable tablaVolumen = tabla;
            foreach (DataRow row in tablaVolumen.Rows)
            {
                i++;
                row[1] = i;
            }
            return tablaVolumen;
        }

        private void _dgvVolVsArea_SelectionChanged(object sender, EventArgs e)
        {
            _volumenArea = null;
            _idxVolumenArea = -1;
            _dgvVolVsArea.EndEdit();
            if (_dgvVolVsArea.SelectedCells.Count > 0)
            {
                _idxVolumenArea = _dgvVolVsArea.SelectedCells[0].RowIndex;
                if (_dgvVolVsArea.Rows[_idxVolumenArea].DataBoundItem != null)
                {
                    DataRow row = ((DataRowView)_dgvVolVsArea.Rows[_idxVolumenArea].DataBoundItem).Row;
                    if ((row["pk."] is DBNull))
                    {
                        _volumenArea = new VolumenVsArea();
                        _volumenArea.EsNuevo = true;
                    }
                    else
                    {
                        long pkVolumen = long.Parse(row[0].ToString());
                        _volumenArea = OraDalVolumenVsAreaMgr.Instancia.GetPorId<VolumenVsArea>(pkVolumen, VolumenVsArea.C_PK_VOLUMEN_VS_AREA);
                        _volumenArea.EsNuevo = false;
                    }
                }
            }
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            FormatoColumnasVolumenVsProduccion();
            FormatoColumnasVsArea();
            _seGuardo = false;
            _cmbTipoTurbinas.Focus();
        }

        private void FormatoColumnasVolumenVsProduccion()
        {
            _dgvVolVsProduccion.Columns[0].Visible = false;
            _dgvVolVsProduccion.Columns[1].ReadOnly = true;
            _dgvVolVsProduccion.Columns[1].Width = 50;
            ((DataGridViewTextBoxColumn)_dgvVolVsProduccion.Columns[2]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)_dgvVolVsProduccion.Columns[3]).MaxInputLength = 10;
        }

        private void FormatoColumnasVsArea()
        {
            _dgvVolVsArea.Columns[1].ReadOnly = true;
            _dgvVolVsArea.Columns[0].Visible = false;
            _dgvVolVsArea.Columns[1].Width = 50;
            ((DataGridViewTextBoxColumn)_dgvVolVsArea.Columns[2]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)_dgvVolVsArea.Columns[3]).MaxInputLength = 10;
        }

        private void _dgvVolVsArea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value =  (int.Parse(e.RowIndex.ToString())+ 1).ToString();
            }
        }

        private void _dgvVolVsArea_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _dgvVolVsArea.Rows[e.RowIndex].ErrorText = string.Empty;
            LimpiarMensajesDeErroresArea();
        }

        private void _dgvVolVsProduccion_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _dgvVolVsProduccion.Rows[e.RowIndex].ErrorText = string.Empty;
            LimpiarMensajesDeErroresProduccion();
            _dgvVolVsProduccion.Rows[_dgvVolVsProduccion.Rows.Count - 1].ErrorText = string.Empty;
        }

        private void _tabTablasVolumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tabTablasVolumen.SelectedIndex == 1)
            {
                _dgvVolVsArea.Columns[0].Visible = false;
            }
            if (_tabTablasVolumen.SelectedIndex == 0)
            {
                _dgvVolVsProduccion.Columns[0].Visible = false;
            }
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();

            if (_datoTecHidroelectrico.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            ActivarDesActivarControles();
            _ctrlZGArea.Limpiar();
            _ctrlZGProduccion.Limpiar();
        }

        private void _tsbMostrarVolumentVsAreaGrafica_Click(object sender, EventArgs e)
        {
            if (DatosValidosTablaVolumenProduccion())
            {
                MostrarGraficaVolumenVsArea();
            }
        }

        private void MostrarGraficaVolumenVsArea()
        {
            _dgvVolVsArea.EndEdit();
            _ctrlZGArea.Limpiar();
            _ctrlZGArea.Visible = true;
            _ctrlZGArea.Titulo = "Volumen vs. área";
            _ctrlZGArea.TituloX = "Volumen (hm3)";
            _ctrlZGArea.TituloY = "Área (km2)";
            List<PuntoZG> puntos = new List<PuntoZG>();
            if (_tablaVoumenVsArea.Rows.Count > 0)
            {
                for (int i = 0; i < _tablaVoumenVsArea.Rows.Count; i++)
                {
                    DataRow row = ((DataRowView)_dgvVolVsArea.Rows[i].DataBoundItem).Row;
                    puntos.Add(new PuntoZG() { X = double.Parse(row[2].ToString()), Y = double.Parse(row[3].ToString()) });
                }
            }
            _ctrlZGArea.SetPuntos(puntos, "");
            _ctrlZGArea.Refresh();
        }

        private void _tsbMostrarGraficaVolumenProduccion_Click(object sender, EventArgs e)
        {
            if (DatosValidosTablaVolumenProduccion())
            {
                MostrarGraficaVolumenVsProduccion();
            }
        }

        private void MostrarGraficaVolumenVsProduccion()
        {
            _dgvVolVsProduccion.EndEdit();
            _ctrlZGProduccion.Limpiar();
            _ctrlZGProduccion.Visible = true;
            _ctrlZGProduccion.Titulo = "Volumen vs. factor de producción";
            _ctrlZGProduccion.TituloX = "Volumen (hm3)";
            _ctrlZGProduccion.TituloY = "Factor de producción (MW/m3/s)";
            List<PuntoZG> puntos = new List<PuntoZG>();
            if (_tablaVoumenVsProduccion.Rows.Count > 0)
            {
                for (int i = 0; i < _tablaVoumenVsProduccion.Rows.Count; i++)
                {
                    DataRow row = ((DataRowView)_dgvVolVsProduccion.Rows[i].DataBoundItem).Row;
                    puntos.Add(new PuntoZG() { X = double.Parse(row[2].ToString()), Y = double.Parse(row[3].ToString()) });
                }
            }
            _ctrlZGProduccion.SetPuntos(puntos, "");
            _ctrlZGProduccion.Refresh();
        }

        private void _btnEliminarVertimiento_Click(object sender, EventArgs e)
        {
            _proyVertimiento = new ProyectoMaestro();
            _proyVertimiento.EsNuevo = true;
            _proyVertimiento.Nombre = "";
            _proyVertimiento.Codigo = "";
            _proyVertimiento.PkProyectoMaestro = 0;
            _txtCodigoProyVertimiento.Text = string.Empty;
            _txtVertimiento.Text = string.Empty;
        }

        private void _btnEliminarTurbinamiento_Click(object sender, EventArgs e)
        {
            _proyTurbinamiento = new ProyectoMaestro();
            _proyTurbinamiento.EsNuevo = true;
            _proyTurbinamiento.Nombre = "";
            _proyTurbinamiento.Codigo = "";
            _proyTurbinamiento.PkProyectoMaestro = 0;
            _txtCodigoProyTurbinamiento.Text = string.Empty;
            _txtTurbinamiento.Text = string.Empty;
        }

        private void _btnEliminarInfiltracion_Click(object sender, EventArgs e)
        {
            _proyInfiltracion = new ProyectoMaestro();
            _proyInfiltracion.EsNuevo = true;
            _proyInfiltracion.Nombre = "";
            _proyInfiltracion.Codigo = "";
            _proyInfiltracion.PkProyectoMaestro = 0;
            _txtCodigoProyInfiltracion.Text = string.Empty;
            _txtInfiltracion.Text = string.Empty;
        }

        private void _dgvVolVsProduccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
