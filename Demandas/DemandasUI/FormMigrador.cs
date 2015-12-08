using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MenuQuantum;
using CNDC.BLL;
using OraDalDemandas;
using ModeloDemandas;
using Proyectos;
using ParserABNumber;
using CNDC.UtilesComunes;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormMigrador : BaseForm, IFuncionalidad
    {
        int _codTipoAgente = 0;
        int _codigoTipoSalida = 0;
        Persona _persona;
        DataTable _tablaEnergiaPotencia = new DataTable();
        DataTable _tablaBloque = new DataTable();
        DataTable _tablaIdentificadorSemanal = new DataTable();
        List<D_COD_DIA_SEMANA> _listaDiasSemana = new List<D_COD_DIA_SEMANA>();

        public FormMigrador()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                _rbtDistribucion.Checked = true;
                CargarListaDiasDeSemana();
                CargarTablaTipoDato();
                CargarHeadersTabla();
                CargarHeadersTablaBolque();
                CargarHeadersTablaIdentificadores();
                _cbxNodoDeConexion.Checked = true;
            }
        }

        private void LimpiarTablas()
        {
            _errorProvider.Clear();
            _dgvDatos.DataSource = null;
            _tablaBloque.Rows.Clear();
            _tablaEnergiaPotencia.Rows.Clear();
            _tablaIdentificadorSemanal.Rows.Clear();
        }

        private void CargarHeadersTablaBolque()
        {
            DataColumn c_PkSerie = new DataColumn("Pk_dato", typeof(long));
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Secuencia = new DataColumn("Bloque", typeof(string));
            DataColumn c_Enero = new DataColumn("Enero", typeof(double));
            DataColumn c_Febrero = new DataColumn("Febrero", typeof(double));
            DataColumn c_Marzo = new DataColumn("Marzo", typeof(double));
            DataColumn c_Abril = new DataColumn("Abril", typeof(double));
            DataColumn c_Mayo = new DataColumn("Mayo", typeof(double));
            DataColumn c_Junio = new DataColumn("Junio", typeof(double));
            DataColumn c_Julio = new DataColumn("Julio", typeof(double));
            DataColumn c_Agosto = new DataColumn("Agosto", typeof(double));
            DataColumn c_Septiembre = new DataColumn("Septiembre", typeof(double));
            DataColumn c_Octubre = new DataColumn("Octubre", typeof(double));
            DataColumn c_Noviembre = new DataColumn("Noviembre", typeof(double));
            DataColumn c_Diciembre = new DataColumn("Diciembre", typeof(double));

            _tablaBloque.Columns.Add(c_PkSerie);
            _tablaBloque.Columns.Add(c_Anio);
            _tablaBloque.Columns.Add(c_Secuencia);
            _tablaBloque.Columns.Add(c_Enero);
            _tablaBloque.Columns.Add(c_Febrero);
            _tablaBloque.Columns.Add(c_Marzo);
            _tablaBloque.Columns.Add(c_Abril);
            _tablaBloque.Columns.Add(c_Mayo);
            _tablaBloque.Columns.Add(c_Junio);
            _tablaBloque.Columns.Add(c_Julio);
            _tablaBloque.Columns.Add(c_Agosto);
            _tablaBloque.Columns.Add(c_Septiembre);
            _tablaBloque.Columns.Add(c_Octubre);
            _tablaBloque.Columns.Add(c_Noviembre);
            _tablaBloque.Columns.Add(c_Diciembre);

            _dgvDatos.DataSource = _tablaBloque;
            _dgvDatos.Columns[1].Frozen = true;
            FormatearDatosBloque();
        }

        private void CargarHeadersTablaIdentificadores()
        {
            DataColumn c_PkSerie = new DataColumn("Pk_dato", typeof(long));
            DataColumn c_PkDia = new DataColumn("PkDia", typeof(long));
            DataColumn c_Dia = new DataColumn("Dia", typeof(string));
            DataColumn c_Hora1 = new DataColumn("Hora_1", typeof(double));
            DataColumn c_Hora2 = new DataColumn("Hora_2", typeof(double));
            DataColumn c_Hora3 = new DataColumn("Hora_3", typeof(double));
            DataColumn c_Hora4 = new DataColumn("Hora_4", typeof(double));
            DataColumn c_Hora5 = new DataColumn("Hora_5", typeof(double));
            DataColumn c_Hora6 = new DataColumn("Hora_6", typeof(double));
            DataColumn c_Hora7 = new DataColumn("Hora_7", typeof(double));
            DataColumn c_Hora8 = new DataColumn("Hora_8", typeof(double));
            DataColumn c_Hora9 = new DataColumn("Hora_9", typeof(double));
            DataColumn c_Hora10 = new DataColumn("Hora_10", typeof(double));
            DataColumn c_Hora11 = new DataColumn("Hora_11", typeof(double));
            DataColumn c_Hora12 = new DataColumn("Hora_12", typeof(double));
            DataColumn c_Hora13 = new DataColumn("Hora_13", typeof(double));
            DataColumn c_Hora14 = new DataColumn("Hora_14", typeof(double));
            DataColumn c_Hora15 = new DataColumn("Hora_15", typeof(double));
            DataColumn c_Hora16 = new DataColumn("Hora_16", typeof(double));
            DataColumn c_Hora17 = new DataColumn("Hora_17", typeof(double));
            DataColumn c_Hora18 = new DataColumn("Hora_18", typeof(double));
            DataColumn c_Hora19 = new DataColumn("Hora_19", typeof(double));
            DataColumn c_Hora20 = new DataColumn("Hora_20", typeof(double));
            DataColumn c_Hora21 = new DataColumn("Hora_21", typeof(double));
            DataColumn c_Hora22 = new DataColumn("Hora_22", typeof(double));
            DataColumn c_Hora23 = new DataColumn("Hora_23", typeof(double));
            DataColumn c_Hora24 = new DataColumn("Hora_24", typeof(double));

            _tablaIdentificadorSemanal.Columns.Add(c_PkSerie);
            _tablaIdentificadorSemanal.Columns.Add(c_PkDia);
            _tablaIdentificadorSemanal.Columns.Add(c_Dia);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora1);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora2);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora3);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora4);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora5);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora6);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora7);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora8);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora9);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora10);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora11);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora12);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora13);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora14);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora15);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora16);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora17);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora18);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora19);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora20);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora21);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora22);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora23);
            _tablaIdentificadorSemanal.Columns.Add(c_Hora24);

            _dgvDatos.DataSource = _tablaIdentificadorSemanal;
            _dgvDatos.Columns[1].Frozen = true;
            FormatearDatosIdentificadores();
        }

        private void CargarHeadersTabla()
        {
            DataColumn c_PkSerie = new DataColumn("Pk_dato", typeof(long));
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Enero = new DataColumn("Enero", typeof(double));
            DataColumn c_Febrero = new DataColumn("Febrero", typeof(double));
            DataColumn c_Marzo = new DataColumn("Marzo", typeof(double));
            DataColumn c_Abril = new DataColumn("Abril", typeof(double));
            DataColumn c_Mayo = new DataColumn("Mayo", typeof(double));
            DataColumn c_Junio = new DataColumn("Junio", typeof(double));
            DataColumn c_Julio = new DataColumn("Julio", typeof(double));
            DataColumn c_Agosto = new DataColumn("Agosto", typeof(double));
            DataColumn c_Septiembre = new DataColumn("Septiembre", typeof(double));
            DataColumn c_Octubre = new DataColumn("Octubre", typeof(double));
            DataColumn c_Noviembre = new DataColumn("Noviembre", typeof(double));
            DataColumn c_Diciembre = new DataColumn("Diciembre", typeof(double));

            _tablaEnergiaPotencia.Columns.Add(c_PkSerie);
            _tablaEnergiaPotencia.Columns.Add(c_Anio);
            _tablaEnergiaPotencia.Columns.Add(c_Enero);
            _tablaEnergiaPotencia.Columns.Add(c_Febrero);
            _tablaEnergiaPotencia.Columns.Add(c_Marzo);
            _tablaEnergiaPotencia.Columns.Add(c_Abril);
            _tablaEnergiaPotencia.Columns.Add(c_Mayo);
            _tablaEnergiaPotencia.Columns.Add(c_Junio);
            _tablaEnergiaPotencia.Columns.Add(c_Julio);
            _tablaEnergiaPotencia.Columns.Add(c_Agosto);
            _tablaEnergiaPotencia.Columns.Add(c_Septiembre);
            _tablaEnergiaPotencia.Columns.Add(c_Octubre);
            _tablaEnergiaPotencia.Columns.Add(c_Noviembre);
            _tablaEnergiaPotencia.Columns.Add(c_Diciembre);

            _dgvDatos.DataSource = _tablaEnergiaPotencia;
            _dgvDatos.Columns[1].Frozen = true;
            FormatearDatos();
        }

        private void FormatearDatosIdentificadores()
        {
            _dgvDatos.Columns[0].Width = 70;
            _dgvDatos.Columns[1].Width = 70;
            _dgvDatos.Columns[2].Width = 75;
            _dgvDatos.Columns[3].Width = 75;
            _dgvDatos.Columns[4].Width = 75;
            _dgvDatos.Columns[5].Width = 75;
            _dgvDatos.Columns[6].Width = 75;
            _dgvDatos.Columns[7].Width = 75;
            _dgvDatos.Columns[8].Width = 75;
            _dgvDatos.Columns[9].Width = 75;
            _dgvDatos.Columns[10].Width = 75;
            _dgvDatos.Columns[11].Width = 75;
            _dgvDatos.Columns[12].Width = 75;
            _dgvDatos.Columns[13].Width = 75;

            _dgvDatos.Columns[14].Width = 70;
            _dgvDatos.Columns[15].Width = 70;
            _dgvDatos.Columns[16].Width = 75;
            _dgvDatos.Columns[17].Width = 75;
            _dgvDatos.Columns[18].Width = 75;
            _dgvDatos.Columns[19].Width = 75;
            _dgvDatos.Columns[20].Width = 75;
            _dgvDatos.Columns[21].Width = 75;
            _dgvDatos.Columns[22].Width = 75;
            _dgvDatos.Columns[23].Width = 75;
            _dgvDatos.Columns[24].Width = 75;
            //_dgvDatos.Columns[25].Width = 75;
            //_dgvDatos.Columns[26].Width = 75;
        }

        private void FormatearDatosBloque()
        {
            _dgvDatos.Columns[0].Width = 70;
            _dgvDatos.Columns[1].Width = 70;
            _dgvDatos.Columns[2].Width = 75;
            _dgvDatos.Columns[3].Width = 75;
            _dgvDatos.Columns[4].Width = 75;
            _dgvDatos.Columns[5].Width = 75;
            _dgvDatos.Columns[6].Width = 75;
            _dgvDatos.Columns[7].Width = 75;
            _dgvDatos.Columns[8].Width = 75;
            _dgvDatos.Columns[9].Width = 75;
            _dgvDatos.Columns[10].Width = 75;
            _dgvDatos.Columns[11].Width = 75;
            _dgvDatos.Columns[12].Width = 75;
            _dgvDatos.Columns[13].Width = 75;
            _dgvDatos.Columns[14].Width = 75;
            _dgvDatos.Columns[0].Visible = false;
        }

        private void FormatearDatos()
        {
            _dgvDatos.Columns[0].Width = 70;
            _dgvDatos.Columns[1].Width = 70;
            _dgvDatos.Columns[2].Width = 75;
            _dgvDatos.Columns[3].Width = 75;
            _dgvDatos.Columns[4].Width = 75;
            _dgvDatos.Columns[5].Width = 75;
            _dgvDatos.Columns[6].Width = 75;
            _dgvDatos.Columns[7].Width = 75;
            _dgvDatos.Columns[8].Width = 75;
            _dgvDatos.Columns[9].Width = 75;
            _dgvDatos.Columns[10].Width = 75;
            _dgvDatos.Columns[11].Width = 75;
            _dgvDatos.Columns[12].Width = 75;
            _dgvDatos.Columns[13].Width = 75;
        }

        private void CargarTablaTipoDato()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoTabla.DisplayMember = DefDominio.C_DESCRIPCION;
            _cmbTipoTabla.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbTipoTabla.DataSource = mgr.GetCategoriaDatos();
        }

        private void _cbxNodo_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_cbxNodo.Checked)
            {
                _cmbNodos.Enabled = true;
                _cbxNodoSalida.Enabled = false;
                _cmbNodoSalida.Enabled = false;
                _gbxNodoSalida.Enabled = false;
            }
            else
            {
                _cmbNodos.Enabled = false;
                _cbxNodoSalida.Enabled = true;
                _cmbNodoSalida.Enabled = false;
                _gbxNodoSalida.Enabled = false;
            }
        }

        #region Miembros de IFuncionalidad

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            HabilitarControles();
            ShowDialog();
        }

        #endregion

        private void _rbtDistribucion_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();

            _cbxNodo.Checked = false;
            _cbxNodoSalida.Checked = false;
            _cbxNodo.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cmbNodos.Enabled = false;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;

            _txtDocumento.Text = string.Empty;
            _tablaEnergiaPotencia.Rows.Clear();
            _dgvDatos.DataSource = null;
            if (_rbtDistribucion.Checked)
            {
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.DISTRIBUCIÓN;
            }
            CargarCmbAgentes();
        }

        private void CargarCmbAgentes()
        {
            _cmbAgente.DisplayMember = Persona.C_NOM_PERSONA;
            _cmbAgente.ValueMember = Persona.C_PK_COD_PERSONA;
            _cmbAgente.DataSource = OraDalPersonaMgr.Instancia.GetListaAgentesDeTipoDemandas(_codTipoAgente);
        }

        private void _rbtSisAislados_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _cbxNodo.Checked = false;
            _cbxNodoSalida.Checked = false;
            _cbxNodo.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cmbNodos.Enabled = false;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;
            _txtDocumento.Text = string.Empty;
            _tablaEnergiaPotencia.Rows.Clear();
            _dgvDatos.DataSource = null;
            if (_rbtSisAislados.Checked)
            {
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.SISTEMA_AISLADO;
            }
            CargarCmbAgentes();
        }

        private void _rbtProyectos_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _cbxNodo.Checked = false;
            _cbxNodoSalida.Checked = false;
            _cbxNodo.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cmbNodos.Enabled = false;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;
            _txtDocumento.Text = string.Empty;
            _tablaEnergiaPotencia.Rows.Clear();
            _dgvDatos.DataSource = _tablaEnergiaPotencia;
            FormatearDatos();
            if (_rbtProyectos.Checked)
            {
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.PROYECTO;
            }
            CargarCmbAgentes();
        }

        private void _cmbAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _cmbNodoDeConexion.DataSource = null;
            _cmbNodos.DataSource = null;
            if (_cmbAgente.SelectedItem != null)
            {
                _persona = OraDalPersonaMgr.Instancia.GetPorId<Persona>((long)_cmbAgente.SelectedValue, Persona.C_PK_COD_PERSONA);
                if (_persona != null)
                {
                    _cmbNodoDeConexion.ValueMember = "PkNodoDemanda";
                    _cmbNodoDeConexion.DisplayMember = "NomSigla";
                    _cmbNodoDeConexion.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosDemanda(_persona.PkCodPersona);
                }
            }
        }

        private void _cmbNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_cmbNodoDeConexion.SelectedItem != null)
            {

                PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                if (personaNodo != null)
                {
                    _cmbNodos.ValueMember = "PkNodoDemanda";
                    _cmbNodos.DisplayMember = "NomSigla";
                    _cmbNodos.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosConectados(_persona.PkCodPersona, personaNodo.PkPersonaNodo);

                    _rbtSDDP.Checked=true;
                    CargarNodosSalida();
                }
            }
        }

        private void _btnCrear_Click(object sender, EventArgs e)
        {
            
            LimpiarTablas();
            _dgvDatos.DataSource = null;
            if (_cmbAgente.SelectedItem != null)
            {
                _persona = OraDalPersonaMgr.Instancia.GetPorId<Persona>((long)_cmbAgente.SelectedValue, Persona.C_PK_COD_PERSONA);
                if (DatosValidos())
                {
                    if (_cmbNodoDeConexion.SelectedItem != null && _cmbTipoTabla.SelectedItem != null && _txtDocumento.Text != string.Empty)
                    {
                        LectorXls lector = new LectorXls();
                        Parser p = new Parser();
                        long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                        {
                            _tablaEnergiaPotencia = lector.LeerSeries(0, _tablaEnergiaPotencia, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text) + 11, (int)_nudAnioInicio.Value, (int)_nudAnioFin.Value);
                            if (lector.GetResultado())
                            {
                                _dgvDatos.DataSource = _tablaEnergiaPotencia;
                                _dgvDatos.Columns[1].Frozen = true;
                                _dgvDatos.Columns[0].Visible = false;
                                FormatoDeCeldas();
                                FormatearDatos();
                            }
                            else
                            {
                                _tablaEnergiaPotencia.Rows.Clear();
                                MessageBox.Show("Existen errores en la configuración de migración de datos.");
                            }
                        }
                        else
                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                            {
                                _tablaIdentificadorSemanal = lector.LeerSeriesIdentificadores(0,_tablaIdentificadorSemanal, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text) + 23);
                                if (lector.GetResultado())
                                {
                                    _dgvDatos.DataSource = _tablaIdentificadorSemanal;
                                    AdicionarDiaSemana();
                                    _dgvDatos.Columns[2].Frozen = true;
                                    _dgvDatos.Columns[0].Visible = false;
                                    _dgvDatos.Columns[1].Visible = false;
                                    FormatoDeCeldas();
                                    FormatearDatosIdentificadores();
                                }
                                else
                                {
                                    _tablaIdentificadorSemanal.Rows.Clear();
                                    MessageBox.Show("Existen errores en la configuración de migración de datos.");
                                }
                            }
                            else
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                {
                                    _tablaBloque = lector.LeerSeriesBloques(0, _tablaBloque, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text) + 11, (int)_nudAnioInicio.Value, (int)_nudAnioFin.Value, int.Parse(_txtCriterioBloque.Text));
                                    if (lector.GetResultado())
                                    {
                                        _dgvDatos.DataSource = _tablaBloque;
                                        _dgvDatos.Columns[1].Frozen = true;
                                        _dgvDatos.Columns[0].Visible = false;
                                        FormatoDeCeldas();
                                        FormatearDatosBloque();
                                    }
                                    else
                                    {
                                        _tablaBloque.Rows.Clear();
                                        MessageBox.Show("Existen errores en la configuración de migración de datos.");
                                    }
                                }
                    }
                }
            }
        }

        private void AdicionarDiaSemana()
        {
            int i=0;
            foreach (DataRow row  in _tablaIdentificadorSemanal.Rows)
            {
                row[1] = (long)_listaDiasSemana[i];
                row[2] = _listaDiasSemana[i].ToString();
                i++;
            }
        }

        private void CargarListaDiasDeSemana()
        {
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.SABADO);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.DOMINGO);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.LUNES);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.MARTES);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.MIERCOLES);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.JUEVES);
            _listaDiasSemana.Add(D_COD_DIA_SEMANA.VIERNES);
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;

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

            if (_cmbTipoTabla.SelectedItem != null)
            {
                if ((long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                {
                    if (!Utiles.EsEnteroPositivo(_txtCriterioBloque.Text))
                    {
                        _errorProvider.SetError(_txtCriterioBloque, "Debe de ingresar un el número de bloques año.");
                        res = false;
                    }
                    
                }
            }

            if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
            {
                if (_cmbNodoDeConexion.SelectedItem == null)
                {
                    _errorProvider.SetError(_cbxNodoDeConexion, "No existen nodos de conexión.");
                    res = false;
                }
            }
            else
            {
                if (_cbxNodoDeConexion.Checked && _cbxNodo.Checked && !_cbxNodoSalida.Checked)
                {
                    if (_cmbNodoDeConexion.SelectedItem == null)
                    {
                        _errorProvider.SetError(_cbxNodoDeConexion, "No existen nodos de conexión.");
                        res = false;
                    }
                    else
                    {
                        if (_cmbNodos.SelectedItem == null)
                        {
                            _errorProvider.SetError(_cmbNodos, "No existen nodos.");
                            res = false;
                        }
                    }
                }
                else
                {
                    if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && _cbxNodoSalida.Checked)
                    {
                        if (_cmbNodoDeConexion.SelectedItem == null)
                        {
                            _errorProvider.SetError(_cbxNodoDeConexion, "No existen nodos de conexión.");
                            res = false;
                        }
                        else
                        {
                            if (_cmbNodoSalida.SelectedItem == null)
                            {
                                _errorProvider.SetError(_cmbNodoSalida, "No existen nodos salida.");
                                res = false;
                            }
                        }
                    }
                }
            }

            return res;
        }

        private void _btnExaminar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _txtDocumento.Text = openFileDialog1.FileName;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            bool res = true;
            PersonaNodos personaNodo = new PersonaNodos();

            if (DatosValidos())
            {
                if (_cmbAgente.SelectedItem != null)
                {
                    long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
                    //  PARA GUARDAR TABLAS REFERIDAS POR AGENTE UNICAMENTE
                    if (!_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                    {
                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                        {
                           
                        }
                        else
                        {
                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                            {
                                // guardar datos: identificadores
                                if (OraDalDemandaPersonaIdentidicacionSemanaMgr.Instancia.GetDatos(_persona.PkCodPersona, codTipoTabla).Rows.Count == 0)
                                {
                                    OraDalDemandaPersonaIdentidicacionSemanaMgr.Instancia.GuardarTabla(_tablaIdentificadorSemanal, _persona.PkCodPersona, codTipoTabla);
                                }
                                else
                                {
                                    res = false;
                                    MessageBox.Show("Ya existen datos registrados.");
                                }
                            }
                            else
                            {
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                {
                                    // guardar datos: bloque
                                    if (OraDalDatosDemandaPersonaBloqueMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo).Rows.Count == 0)
                                    {
                                        OraDalDatosDemandaPersonaBloqueMgr.Instancia.GuardarTablaBloque(_tablaBloque, _persona.PkCodPersona, codTipoTabla);
                                    }
                                    else
                                    {
                                        res = false;
                                        MessageBox.Show("Ya existen datos registrados.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // GUARDAR DATOS POR NODOS

                        if ((_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked) || (_cbxNodoDeConexion.Checked && _cbxNodo.Checked && !_cbxNodoSalida.Checked))
                        {
                            //********** GUARDAR DATOS PARA NODOS CONEXION y NODOS*********//
                            if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                            {
                                personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                            }
                            else
                            {
                                if (_cbxNodoDeConexion.Checked && _cbxNodo.Checked && !_cbxNodoSalida.Checked)
                                {
                                    personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoHijo(_persona.PkCodPersona, ((NodoDemanda)_cmbNodos.SelectedItem).PkNodoDemanda);
                                }
                            }

                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                            {
                                // guardar datos: bloque, energia, potencia maxima, potencia coincidental
                                if (OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla).Rows.Count == 0)
                                {
                                    OraDalDatosDemandaNodoMgr.Instancia.GuardarDemandaNodo(_tablaEnergiaPotencia, personaNodo.PkPersonaNodo, codTipoTabla, 0);
                                }
                                else
                                {
                                    res = false;
                                    MessageBox.Show("Ya existen datos registrados.");
                                }
                            }
                            else
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                {
                                    // guardar datos: identificadores
                                    if (OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla).Rows.Count == 0)
                                    {
                                        OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GuardarTabla(_tablaIdentificadorSemanal, personaNodo.PkPersonaNodo, codTipoTabla, 0, 0);
                                    }
                                    else
                                    {
                                        res = false;
                                        MessageBox.Show("Ya existen datos registrados.");
                                    }
                                }
                                else
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                    {
                                        // guardar datos: bloque
                                        if (OraDalDatosDemandaNodoBLoqueMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo).Rows.Count == 0)
                                        {
                                            OraDalDatosDemandaNodoBLoqueMgr.Instancia.GuardarTablaBloque(_tablaBloque, personaNodo.PkPersonaNodo, codTipoTabla, 0);
                                        }
                                        else
                                        {
                                            res = false;
                                            MessageBox.Show("Ya existen datos registrados.");
                                        }
                                    }
                        }
                        else
                        {
                            //********** GUARDAR DATOS PARA NODOS SALIDA *********//

                            if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && _cbxNodoSalida.Checked)
                            {
                                // guardar datos para nodo de salida
                                personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                                DemandaSalidaMaestro demandaSalidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida(personaNodo.PkPersonaNodo, (long)_cmbNodoSalida.SelectedValue, _codigoTipoSalida);

                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                                {
                                    // guardar datos: bloque, energia, potencia maxima, potencia coincidental
                                    if (OraDalDatosDemandaNodoMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro).Rows.Count == 0)
                                    {
                                        OraDalDatosDemandaNodoMgr.Instancia.GuardarDemandaNodo(_tablaEnergiaPotencia, personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                    }
                                    else
                                    {
                                        res = false;
                                        MessageBox.Show("Ya existen datos registrados.");
                                    }
                                }
                                else
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                    {
                                        // guardar datos: identificadores
                                        if (OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro).Rows.Count == 0)
                                        {
                                            OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GuardarTabla(_tablaIdentificadorSemanal, personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro, 0);
                                        }
                                        else
                                        {
                                            res = false;
                                            MessageBox.Show("Ya existen datos registrados.");
                                        }
                                    }
                                    else
                                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                        {
                                            // guardar datos: bloque
                                            if (OraDalDatosDemandaNodoBLoqueMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro).Rows.Count == 0)
                                            {
                                                OraDalDatosDemandaNodoBLoqueMgr.Instancia.GuardarTablaBloque(_tablaBloque, personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                            }
                                            else
                                            {
                                                res = false;
                                                MessageBox.Show("Ya existen datos registrados.");
                                            }
                                        }
                            }
                        }
                    }
                    if (res)
                    {
                        MessageBox.Show("Los datos se guardaron de manera correcta.");
                        DeshabilitarControles();
                    }

                }
            }
        }

        private void DeshabilitarControles()
        {
            _cmbAgente.Enabled = false;
            _cmbNodoDeConexion.Enabled = false;
            _nudDecimales.Enabled = false;
            _cmbNodos.Enabled = false;
            _cmbTipoTabla.Enabled = false;
            _nudFilaFin.Enabled = false;
            _nudFilaInicio.Enabled = false;
            _nudAnioInicio.Enabled = false;
            _nudAnioFin.Enabled = false;
            _btnCrear.Enabled = false;
            _btnExaminar.Enabled = false;
            _cbxNodoSalida.Enabled = false;
            _cbxNodo.Enabled = false;
            _txtColumna.Enabled = false;
            _tsbNuevo.Enabled = true;
            _tsbGuardar.Enabled = false;
            _tsbCancelar.Enabled = false;
        }

        private void HabilitarControles()
        {
            _cmbAgente.Enabled = true;
            _cmbNodoDeConexion.Enabled = true;
            _nudDecimales.Enabled = true;
            _cmbNodos.Enabled = true;
            _cmbTipoTabla.Enabled = true;
            _nudFilaFin.Enabled = true;
            _nudFilaInicio.Enabled = true;
            _nudAnioInicio.Enabled = true;
            _nudAnioFin.Enabled = true;
            _btnCrear.Enabled = true;
            _btnExaminar.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cbxNodo.Enabled = true;
            _txtColumna.Enabled = true;

            _tsbNuevo.Enabled = false;
            _tsbGuardar.Enabled = true;
            _tsbCancelar.Enabled = true;
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _dgvDatos.DataSource = null;
            _tablaEnergiaPotencia.Rows.Clear();
            _txtDocumento.Text = string.Empty;
            HabilitarControles();
        }

        private void _cbxNodoDeConexion_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _cbxNodoSalida.Enabled = true;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;
            if (_cbxNodoDeConexion.Checked)
            {
                _cbxNodo.Checked = false;
                _cmbNodos.Enabled = false;
                _cmbNodoDeConexion.Enabled = true;
            }
            else
            {
                _cmbNodoDeConexion.Enabled = false;
            }
        }

        private void _nudDecimales_ValueChanged(object sender, EventArgs e)
        {
            if (_dgvDatos.RowCount > 0)
            {
                FormatoDeCeldas();
            }
        }

        private void FormatoDeCeldas()
        {
            switch ((int)_nudDecimales.Value)
            {
                case 0:
                    _dgvDatos.DefaultCellStyle.Format = "N0";
                    break;
                case 1:
                    _dgvDatos.DefaultCellStyle.Format = "N1";
                    break;
                case 2:
                    _dgvDatos.DefaultCellStyle.Format = "N2";
                    break;
                case 3:
                    _dgvDatos.DefaultCellStyle.Format = "N3";
                    break;
                case 4:
                    _dgvDatos.DefaultCellStyle.Format = "N4";
                    break;
                default:
                    break;
            }
            _dgvDatos.Refresh();
        }

        private void _rbtNoRegulados_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _cbxNodo.Checked = false;
            _cbxNodoSalida.Checked = false;
            _cbxNodo.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cmbNodos.Enabled = false;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;
            _tablaEnergiaPotencia.Rows.Clear();
            _dgvDatos.DataSource = null;
            if (_rbtNoRegulados.Checked)
            {
               
                _codTipoAgente = (int)D_COD_TIPO_AGENTE.CONSUMIDOR_NO_REGULADO;
            }
            CargarCmbAgentes();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void _cbxNodoSalida_CheckedChanged_1(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_cbxNodoSalida.Checked)
            {
                _cbxNodo.Enabled = false;
                _cmbNodos.Enabled = false;
                _gbxNodoSalida.Enabled = true;
                _cmbNodoSalida.Enabled = true;

                //cargando nodos salida por tipo de salida
                CargarNodosSalida();
                _rbtSDDP.Checked = true;
            }
            else
            {
                _cbxNodo.Enabled = true;
                _cmbNodos.Enabled = true;
                _gbxNodoSalida.Enabled = false;
                _cmbNodoSalida.Enabled = false;
            }
        }

        private void CargarNodosSalida()
        {
            PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
            if (personaNodo != null)
            {
                _cmbNodoSalida.ValueMember = NodoDemanda.C_PK_NODO_DEMANDA;
                _cmbNodoSalida.DisplayMember = NodoDemanda.C_NOMBRE_NODO;
                _cmbNodoSalida.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosSalidaDeNodoDemanda(personaNodo.PkPersonaNodo, _codigoTipoSalida);
            }
        }

        private void _rbtSDDP_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_rbtSDDP.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.SDDP;
                CargarNodosSalida();
            }
        }

        private void _rbtOPTGEN_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_rbtOPTGEN.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.OPTGEN;
                CargarNodosSalida();
            }
        }

        private void _rbtNCP_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_rbtNCP.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.NCP;
                CargarNodosSalida();
            }
        }

        private void _cmbTipoTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            _txtCriterioBloque.Text = string.Empty;
            _gbxAnios.Visible = true;

            if (_cmbTipoTabla.SelectedItem != null)
            {
                if ((long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                {
                    _lblCantidadBloques.Visible = true;
                    _txtCriterioBloque.Visible = true;
                    //_txtCriterioBloque.Enabled = true;
                    //_txtCriterioBloque.BackColor = Color.White;
                }
                else
                {
                    _lblCantidadBloques.Visible = false;
                    _txtCriterioBloque.Visible = false;
                   // _txtCriterioBloque.Enabled = false;
                   // _txtCriterioBloque.BackColor = Color.WhiteSmoke;
                    if ((long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || (long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || (long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                    {
                        _gbxAnios.Visible = false;
                    }
                }
            }
        }

        private void _btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTablas();
            _txtCriterioBloque.Text = string.Empty;
            _txtDocumento.Text = string.Empty;
            _txtColumna.Text = string.Empty;
        }

        private void _dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void _dgvDatos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (_cmbTipoTabla.SelectedItem != null)
            {
                if ((long)_cmbTipoTabla.SelectedValue == (long)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                {
                    if (_dgvDatos.RowCount > 0)
                    {
                        int idx = e.RowIndex;
                        int anio= int.Parse(_dgvDatos.Rows[idx].Cells[1].Value.ToString());
                        if (anio % 2 == 0)
                        {
                            _dgvDatos.Rows[idx].DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else
                        {
                            _dgvDatos.Rows[idx].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void _cmbNodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTablas();

        }

        private void _cmbNodoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
        }

        private void _gbxNodoSalida_Enter(object sender, EventArgs e)
        {

        }

        private void _rbtPowerFactory_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();
            if (_rbtPowerFactory.Checked)
            {
                _codigoTipoSalida = (int)D_COD_TIPO_NODO_SALIDA.POWER_FACTORY;
                CargarNodosSalida();
            }
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
