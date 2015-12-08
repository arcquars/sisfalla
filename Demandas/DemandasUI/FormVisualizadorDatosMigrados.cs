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
using DemadasUI;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormVisualizadorDatosMigrados : BaseForm, IFuncionalidad
    {
        int _idx = 0;
        int _codTipoAgente = 0;
        int _codigoTipoSalida = 0;
        Persona _persona;
        DataTable _tablaEnergiaPotencia = new DataTable();
        DataTable _tablaBloque = new DataTable();
        DataTable _tablaIdentificadorSemanal = new DataTable();
        List<D_COD_DIA_SEMANA> _listaDiasSemana = new List<D_COD_DIA_SEMANA>();

        public FormVisualizadorDatosMigrados()
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
            DataColumn c_Anual= new DataColumn("Anual", typeof(double));

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
            _tablaEnergiaPotencia.Columns.Add(c_Anual);

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
            FormatoDeCeldas();
            long codTipoTabla = (long) _cmbTipoTabla.SelectedValue;

            if (codTipoTabla == (long)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (long)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
            {
                _dgvDatos.Columns[14].Visible = true;
            }
            else
            {
                if (codTipoTabla == (long)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL)
                {
                    _dgvDatos.Columns[14].Visible = false;
                }
            }
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
            _btnRecalcular.Enabled = false;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;

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
                //if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked && codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                //{
                //    _btnRecalcular.Enabled = true;
                //}
            }

            MostrarMenuEdicionTablas();
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

                    _rbtSDDP.Checked = true;
                    CargarNodosSalida();
                }
            }
        }

        private void AdicionarDiaSemana()
        {
            int i = 0;
            foreach (DataRow row in _tablaIdentificadorSemanal.Rows)
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


        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarTablaDemandaPersonaNodos(PersonaNodos personaNodo, long pkDemandaSalidaMaestro)
        {
            _dgvDatos.EndEdit();
            if (_dgvDatos.Rows.Count > 0)
            {
                for (int i = 0; i < _dgvDatos.Rows.Count; i++)
                {
                    DataRow row = ((DataRowView)_dgvDatos.Rows[i].DataBoundItem).Row;
                    DatosDemandaNodo demandaNodo = new DatosDemandaNodo();
                    demandaNodo.FkPersonaNodo = personaNodo.PkPersonaNodo;
                    demandaNodo.DCodCategoriaDato = (long)_cmbTipoTabla.SelectedValue;
                    demandaNodo.FkDemandaSalidaMaestro = pkDemandaSalidaMaestro;
                    if (row[0] is DBNull || row[0] == null)
                    {
                        demandaNodo.EsNuevo = true;
                    }
                    else
                    {
                        demandaNodo.EsNuevo = false;
                        demandaNodo.PkDatosDemadaNodo = (long)row[0];
                    }
                    demandaNodo.Anio = long.Parse(row[1].ToString());
                    demandaNodo.Enero = (double)row[2];
                    demandaNodo.Febrero = (double)row[3];
                    demandaNodo.Marzo = (double)row[4];
                    demandaNodo.Abril = (double)row[5];
                    demandaNodo.Mayo = (double)row[6];
                    demandaNodo.Junio = (double)row[7];
                    demandaNodo.Julio = (double)row[8];
                    demandaNodo.Agosto = (double)row[9];
                    demandaNodo.Septiembre = (double)row[10];
                    demandaNodo.Octubre = (double)row[11];
                    demandaNodo.Noviembre = (double)row[12];
                    demandaNodo.Diciembre = (double)row[13];
                    OraDalDatosDemandaNodoMgr.Instancia.Guardar(demandaNodo);
                }
            }
        }

        private void GuardarTablaDemandaPersona( )
        {
            _dgvDatos.EndEdit();
            if (_dgvDatos.Rows.Count > 0)
            {
                for (int i = 0; i < _dgvDatos.Rows.Count; i++)
                {
                    DataRow row = ((DataRowView)_dgvDatos.Rows[i].DataBoundItem).Row;
                    DatosDemandaPersona demandaNodo = new DatosDemandaPersona();
                    demandaNodo.FkPersona = _persona.PkCodPersona;
                    demandaNodo.DCodCategoriaDato = (long)_cmbTipoTabla.SelectedValue;
                    if (row[0] is DBNull || row[0] == null)
                    {
                        demandaNodo.EsNuevo = true;
                    }
                    else
                    {
                        demandaNodo.EsNuevo = false;
                        demandaNodo.PkDatosDemadaPersona = (long)row[0];
                    }
                    demandaNodo.Anio = int.Parse(row[1].ToString());
                    demandaNodo.Enero = (double)row[2];
                    demandaNodo.Febrero = (double)row[3];
                    demandaNodo.Marzo = (double)row[4];
                    demandaNodo.Abril = (double)row[5];
                    demandaNodo.Mayo = (double)row[6];
                    demandaNodo.Junio = (double)row[7];
                    demandaNodo.Julio = (double)row[8];
                    demandaNodo.Agosto = (double)row[9];
                    demandaNodo.Septiembre = (double)row[10];
                    demandaNodo.Octubre = (double)row[11];
                    demandaNodo.Noviembre = (double)row[12];
                    demandaNodo.Diciembre = (double)row[13];
                    OraDalDatosDemandaPersonaMgr.Instancia.Guardar(demandaNodo);
                }
            }
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
                    
                    if (!_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                    {
                        if (OraDalDatosDemandaPersonaMgr.Instancia.GetDatos(_persona.PkCodPersona, codTipoTabla).Rows.Count > 0)
                        {
                            if (_dgvDatos.RowCount > 0 && !(_tablaEnergiaPotencia.Rows[0][0] is DBNull))
                            {
                                OraDalDatosDemandaPersonaMgr.Instancia.EliminarTablaDatosPersonaNodo(_persona.PkCodPersona, codTipoTabla);
                            }
                        }
                        GuardarTablaDemandaPersona();
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
                                if (OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla).Rows.Count > 0)
                                {
                                    if (_dgvDatos.RowCount > 0 )
                                    {
                                        //OraDalDatosDemandaNodoMgr.Instancia.EliminarTablaDatosPersonaNodo(personaNodo.PkPersonaNodo, codTipoTabla);
                                        GuardarTablaDemandaPersonaNodos(personaNodo, 0);
                                    }
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
                                GuardarTablaDemandaPersonaNodos(personaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                            }
                        }

                    }
                    DeshabilitarControles();
                    _tsbObcionesDeEdicion.Enabled = false;
                }
            }
        }

        private void DeshabilitarControles()
        {
            _cmbAgente.Enabled = false;
            _btnRecalcular.Enabled = false;
            _cmbNodoDeConexion.Enabled = false;
            _nudDecimales.Enabled = false;
            _cmbNodos.Enabled = false;
            _cmbTipoTabla.Enabled = false;
            _btnCrear.Enabled = false;
            _cbxNodoSalida.Enabled = false;
            _cbxNodo.Enabled = false;
            _tsbEditar.Enabled = true;
            _tsbGuardar.Enabled = false;
            _tsbCancelar.Enabled = false;
        }

        private void HabilitarControles()
        {
            _cmbAgente.Enabled = true;
            _btnRecalcular.Enabled = false;
            _cmbNodoDeConexion.Enabled = true;
            _nudDecimales.Enabled = true;
            _cmbNodos.Enabled = true;
            _cmbTipoTabla.Enabled = true;
            _btnCrear.Enabled = true;
            _cbxNodoSalida.Enabled = true;
            _cbxNodo.Enabled = true;

            _tsbEditar.Enabled = false;
            _tsbGuardar.Enabled = true;
            _tsbCancelar.Enabled = true;
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _dgvDatos.DataSource = null;
            _tablaEnergiaPotencia.Rows.Clear();
            HabilitarControles();
            _tsbObcionesDeEdicion.Enabled = true;
        }

        private void _cbxNodoDeConexion_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarTablas();

            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            _cbxNodoSalida.Enabled = true;
            _cmbNodoSalida.Enabled = false;
            _gbxNodoSalida.Enabled = false;
            _btnRecalcular.Enabled = false;
            if (_cbxNodoDeConexion.Checked)
            {
                _cbxNodo.Checked = false;
                _cmbNodos.Enabled = false;
                _cmbNodoDeConexion.Enabled = true;
                //if (!_cbxNodo.Checked && !_cbxNodoSalida.Checked && codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                //{
                //    _btnRecalcular.Enabled = true;
                //}
            }
            else
            {
                _cmbNodoDeConexion.Enabled = false;
            }
            MostrarMenuEdicionTablas();
        }

        private void _nudDecimales_ValueChanged(object sender, EventArgs e)
        {
            if (_dgvDatos.RowCount > 0)
            {
                FormatoDeCeldas();
            }
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
            if (_rbtNoRegulado.Checked)
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
            _btnRecalcular.Enabled = false;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;

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
                //if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked && codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                //{
                //    _btnRecalcular.Enabled = true;
                //}
            }
            MostrarMenuEdicionTablas();
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
            MostrarMenuEdicionTablas();
        }

        private void MostrarMenuEdicionTablas()
        {
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            LimpiarTablas();
            _btnRecalcular.Enabled = false;

            if (_cmbTipoTabla.SelectedItem != null)
            {
                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                {
                    _tsbInsertarRegistros.Enabled = true;
                    _tsbModificarRegistros.Enabled = true;
                    _tsbEliminarRegistro.Enabled = true;
                    _tsbEliminarSerie.Enabled = true;
                    _tsbGuardar.Enabled = true;
                    if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked || !_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                    {
                        //_btnRecalcular.Enabled = true;
                        _tsbInsertarRegistros.Enabled = false;
                        _tsbModificarRegistros.Enabled = false;
                        _tsbEliminarRegistro.Enabled = false;
                        _tsbEliminarSerie.Enabled = false;
                    }
                }
                else
                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                    {
                        _tsbInsertarRegistros.Enabled = false;
                        _tsbModificarRegistros.Enabled = false;
                        _tsbEliminarRegistro.Enabled = false;
                        _tsbGuardar.Enabled = false;
                    }
            }
        }

        private void _btnLimpiar_Click(object sender, EventArgs e)
        {
            _tablaBloque.Rows.Clear();
            _tablaEnergiaPotencia.Rows.Clear();
            _tablaIdentificadorSemanal.Rows.Clear();
            _dgvDatos.DataSource = null;
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
                        int anio = int.Parse(_dgvDatos.Rows[idx].Cells[1].Value.ToString());
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

        private void CopiarDatosATablaBloque(DataTable tabla)
        {
            _tablaBloque.Rows.Clear();
            foreach (DataRow r in tabla.Rows)
            {
                DataRow row = _tablaBloque.NewRow();
                row[0] = r[0];
                row[1] = r[1];
                row[2] = r[2];
                row[3] = r[3];
                row[4] = r[4];
                row[5] = r[5];
                row[6] = r[6];
                row[7] = r[7];
                row[8] = r[8];
                row[9] = r[9];
                row[10] = r[10];
                row[11] = r[11];
                row[12] = r[12];
                row[13] = r[13];
                row[14] = r[14];
                _tablaBloque.Rows.Add(row);
            }
        }

        private string GetDiaSemana(long pkDia)
        {
            string dia = string.Empty;
            for (int i = 0; i < _listaDiasSemana.Count; i++)
            {
                if ((long)_listaDiasSemana[i] == pkDia)
                {
                    dia = _listaDiasSemana[i].ToString();
                    break;
                }
            }
            return dia;
        }

        private void CopiarDatosATablaIdentificadores(DataTable tabla)
        {
            _tablaIdentificadorSemanal.Rows.Clear();
            foreach (DataRow r in tabla.Rows)
            {
                DataRow row = _tablaIdentificadorSemanal.NewRow();
                row[0] = r[0];
                row[1] = r[1];
                row[2] = GetDiaSemana((long)r[1]);
                row[3] = r[2];
                row[4] = r[3];
                row[5] = r[4];
                row[6] = r[5];
                row[7] = r[6];
                row[8] = r[7];
                row[9] = r[8];
                row[10] = r[9];
                row[11] = r[10];
                row[12] = r[11];
                row[13] = r[12];
                row[14] = r[13];
                row[15] = r[14];
                row[16] = r[15];
                row[17] = r[16];
                row[18] = r[17];
                row[19] = r[18];
                row[20] = r[19];
                row[21] = r[20];
                row[22] = r[21];
                row[23] = r[22];
                row[24] = r[23];
                row[25] = r[24];
                row[26] = r[25];
                _tablaIdentificadorSemanal.Rows.Add(row);
            }
        }

        private void CopiarDatosATablaSerie(DataTable tabla)
        {
            _tablaEnergiaPotencia.Rows.Clear();
            foreach (DataRow r in tabla.Rows)
            {
                DataRow row = _tablaEnergiaPotencia.NewRow();
                row[0] = r[0];
                row[1] = r[1];
                row[2] = r[2];
                row[3] = r[3];
                row[4] = r[4];
                row[5] = r[5];
                row[6] = r[6];
                row[7] = r[7];
                row[8] = r[8];
                row[9] = r[9];
                row[10] = r[10];
                row[11] = r[11];
                row[12] = r[12];
                row[13] = r[13];
                _tablaEnergiaPotencia.Rows.Add(row);
            }
        }

        private void CalcularSumatoriaTablasPorAgente()
        {
            _tablaEnergiaPotencia.Rows.Clear();
            DataTable tabla;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            _btnRecalcular.Enabled = false;
            List<NodoDemanda> listaNodosDeConexion = OraDalNodoDemandaMgr.Instancia.GetNodosDemanda(_persona.PkCodPersona);
            foreach (NodoDemanda nodoConexion in listaNodosDeConexion)
            {
                PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, nodoConexion.PkNodoDemanda);
                if (personaNodo != null)
                {
                    if (OraDalDatosDemandaPersonaMgr.Instancia.GetDatos(_persona.PkCodPersona, codTipoTabla).Rows.Count == 0)
                    {
                        CalcularSumariaValoresDeTablasPorAgente();
                    }
                    else
                    {
                        tabla = OraDalDatosDemandaPersonaMgr.Instancia.GetDatos(_persona.PkCodPersona, codTipoTabla);
                        CopiarDatosATablaSerie(tabla);
                        _dgvDatos.DataSource = _tablaEnergiaPotencia;
                        _dgvDatos.Columns[1].Frozen = true;
                        _dgvDatos.Columns[0].Visible = false;
                        SumarMontos();
                        FormatearDatos();
                    }

                    if (_tablaEnergiaPotencia.Rows.Count > 0)
                    {
                        _btnRecalcular.Enabled = true;
                    }
                }
            }
        }

        private void CalcularSumariaValoresDeTablasPorAgente()
        {
            _tablaEnergiaPotencia.Rows.Clear();
            DataTable tablaSumatoria = new DataTable();
            DataTable tabla;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            double valor = 0;
            bool res = true;
            List<NodoDemanda> listaNodosConexion = OraDalNodoDemandaMgr.Instancia.GetNodosDemanda(_persona.PkCodPersona);
            Dictionary<long, DataTable> dicNodosTablas = new Dictionary<long, DataTable>();

            foreach (NodoDemanda nodo in listaNodosConexion)
            {
                PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, nodo.PkNodoDemanda);
                DataTable tablaSum = OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                if (tablaSum.Rows.Count > 0)
                {
                    dicNodosTablas[nodo.PkNodoDemanda] = tablaSum;
                }
            }

            if (dicNodosTablas.Count > 0)
            {
                int i = 0;
                foreach (long pkNodo in dicNodosTablas.Keys)
                {
                    if (i == 0)
                    {
                        tablaSumatoria = dicNodosTablas[pkNodo];
                        i++;
                        continue;
                    }

                    tabla = dicNodosTablas[pkNodo];
                    if (tabla.Rows.Count > 0 && tablaSumatoria.Rows.Count == tabla.Rows.Count)
                    {
                        for (int j = 0; j < tabla.Rows.Count; j++)
                        {
                            tablaSumatoria.Rows[j][0] = DBNull.Value;
                            for (int k = 2; k < 14; k++)
                            {
                                if (tabla.Rows[j][k] is DBNull)
                                {
                                    valor = 0;
                                }
                                else
                                {
                                    valor = (double)tabla.Rows[j][k];
                                }
                                tablaSumatoria.Rows[j][k] = (double)tablaSumatoria.Rows[j][k] + valor;
                            }
                        }
                    }
                    else
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    for (int j = 0; j < tablaSumatoria.Rows.Count; j++)
                    {
                        tablaSumatoria.Rows[j][0] = DBNull.Value;
                    }
                    CopiarDatosATablaSerie(tablaSumatoria);
                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                    _dgvDatos.Columns[1].Frozen = true;
                    _dgvDatos.Columns[0].Visible = false;
                    SumarMontos();
                    FormatearDatos();
                }
                else
                {
                    _tablaEnergiaPotencia.Rows.Clear();
                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                }
            }
        }


        private void _btnVisualizar_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            bool res = true;
            PersonaNodos personaNodo = new PersonaNodos();
            DataTable tabla = new DataTable();
            LimpiarTablas();
            if (DatosValidos())
            {
                if (_cmbAgente.SelectedItem != null)
                {
                    long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
                    // DATOS POR AGENTE 
                    if (!_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                    {
                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                        {
                            CalcularSumatoriaTablasPorAgente();
                        }
                        else
                        {
                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                            {
                                tabla = OraDalDemandaPersonaIdentidicacionSemanaMgr.Instancia.GetDatos(_persona.PkCodPersona, codTipoTabla);
                                CopiarDatosATablaIdentificadores(tabla);
                                _dgvDatos.DataSource = _tablaIdentificadorSemanal;
                                _dgvDatos.Columns[2].Frozen = true;
                                _dgvDatos.Columns[0].Visible = false;
                                _dgvDatos.Columns[1].Visible = false;

                                FormatearDatosIdentificadores();
                                FormatoDeCeldas();
                            }
                            else
                            {
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                {
                                    // datos: bloque
                                    tabla = OraDalDatosDemandaPersonaBloqueMgr.Instancia.GetDatos(_persona.PkCodPersona);
                                    CopiarDatosATablaBloque(tabla);
                                    _dgvDatos.DataSource = _tablaBloque;
                                    _dgvDatos.Columns[1].Frozen = true;
                                    _dgvDatos.Columns[0].Visible = false;
                                    FormatearDatosBloque();
                                    FormatoDeCeldas();
                                }
                            }
                        }
                    }
                    else
                    {

                        // DATOS POR NODOS

                        if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked)
                        {
                            //********** DATOS PARA NODOS CONEXION *********//

                            personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                            {
                                CalcularSumatoriaTablas();
                            }
                            else
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                {
                                    //  datos: identificadores
                                    tabla = OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                                    CopiarDatosATablaIdentificadores(tabla);
                                    _dgvDatos.DataSource = _tablaIdentificadorSemanal;
                                    _dgvDatos.Columns[2].Frozen = true;
                                    _dgvDatos.Columns[0].Visible = false;
                                    _dgvDatos.Columns[1].Visible = false;

                                    FormatearDatosIdentificadores();
                                    FormatoDeCeldas();
                                }
                                else
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                    {
                                        // datos: bloque
                                        tabla = OraDalDatosDemandaNodoBLoqueMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo);
                                        CopiarDatosATablaBloque(tabla);
                                        _dgvDatos.DataSource = _tablaBloque;
                                        _dgvDatos.Columns[1].Frozen = true;
                                        _dgvDatos.Columns[0].Visible = false;
                                        FormatearDatosBloque();
                                        FormatoDeCeldas();
                                    }
                        }
                        else
                        {
                            //********** DATOS PARA NODOS  *********//
                            if (_cbxNodoDeConexion.Checked && _cbxNodo.Checked && !_cbxNodoSalida.Checked)
                            {
                                personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoHijo(_persona.PkCodPersona, ((NodoDemanda)_cmbNodos.SelectedItem).PkNodoDemanda);

                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                                {
                                    //  datos: bloque, energia, potencia maxima, potencia coincidental
                                    tabla = OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                                    CopiarDatosATablaSerie(tabla);
                                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                                    _dgvDatos.Columns[1].Frozen = true;
                                    _dgvDatos.Columns[0].Visible = false;
                                    SumarMontos();
                                    FormatearDatos();
                                }
                                else
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                    {
                                        //  datos: identificadores
                                        tabla = OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                                        CopiarDatosATablaIdentificadores(tabla);
                                        _dgvDatos.DataSource = _tablaIdentificadorSemanal;
                                        _dgvDatos.Columns[2].Frozen = true;
                                        _dgvDatos.Columns[0].Visible = false;
                                        _dgvDatos.Columns[1].Visible = false;

                                        FormatearDatosIdentificadores();
                                        FormatoDeCeldas();
                                    }
                                    else
                                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                        {
                                            //  datos: bloque
                                            tabla = OraDalDatosDemandaNodoBLoqueMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo);
                                            CopiarDatosATablaBloque(tabla);
                                            _dgvDatos.DataSource = _tablaBloque;
                                            _dgvDatos.Columns[1].Frozen = true;
                                            _dgvDatos.Columns[0].Visible = false;
                                            FormatearDatosBloque();
                                            FormatoDeCeldas();
                                        }
                            }
                            else
                            {
                                //********** GUARDAR DATOS PARA NODOS SALIDA *********//

                                if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && _cbxNodoSalida.Checked)
                                {
                                    //  datos para nodo de salida

                                    personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                                    DemandaSalidaMaestro demandaSalidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida(personaNodo.PkPersonaNodo, (long)_cmbNodoSalida.SelectedValue, _codigoTipoSalida);

                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                                    {
                                        // guardar datos: bloque, energia, potencia maxima, potencia coincidental
                                        tabla = OraDalDatosDemandaNodoMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                        CopiarDatosATablaSerie(tabla);
                                        _dgvDatos.DataSource = _tablaEnergiaPotencia;
                                        _dgvDatos.Columns[1].Frozen = true;
                                        _dgvDatos.Columns[0].Visible = false;
                                        SumarMontos();
                                        FormatearDatos();
                                    }
                                    else
                                    {
                                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                        {
                                            //  datos: identificadores
                                            tabla = OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                            CopiarDatosATablaIdentificadores(tabla);
                                            _dgvDatos.DataSource = _tablaIdentificadorSemanal;
                                            _dgvDatos.Columns[2].Frozen = true;
                                            _dgvDatos.Columns[0].Visible = false;
                                            _dgvDatos.Columns[1].Visible = false;
                                            FormatearDatosIdentificadores();
                                            FormatoDeCeldas();
                                        }
                                        else
                                            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                            {
                                                //  datos: bloque
                                                tabla = OraDalDatosDemandaNodoBLoqueMgr.Instancia.GetDatosSalida(personaNodo.PkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                                CopiarDatosATablaBloque(tabla);
                                                _dgvDatos.DataSource = _tablaBloque;
                                                _dgvDatos.Columns[1].Frozen = true;
                                                _dgvDatos.Columns[0].Visible = false;
                                                FormatearDatosBloque();
                                                FormatoDeCeldas();
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void CalcularSumatoriaTablas()
        {
            _tablaEnergiaPotencia.Rows.Clear();
            DataTable tabla;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            _btnRecalcular.Enabled = false;

            PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
            if (personaNodo != null)
            {
                if (OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla).Rows.Count == 0)
                {
                     CalcularSumariaValoresDeTablas();
                }
                else
                {
                    tabla = OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                    CopiarDatosATablaSerie(tabla);
                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                    _dgvDatos.Columns[1].Frozen = true;
                    _dgvDatos.Columns[0].Visible = false;
                    SumarMontos();
                    FormatearDatos();
                }

                if (_tablaEnergiaPotencia.Rows.Count > 0)
                {
                    _btnRecalcular.Enabled = true;
                }
            }
        }

        private void CalcularSumariaValoresDeTablas()
        {
            _tablaEnergiaPotencia.Rows.Clear();
            DataTable tablaSumatoria = new DataTable();
            DataTable tabla;
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            double valor = 0;
            bool res = true;
            PersonaNodos personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
            List<NodoDemanda> listaNodosConectados = OraDalNodoDemandaMgr.Instancia.GetNodosConectados(_persona.PkCodPersona, personaNodo.PkPersonaNodo);
            List<DataTable> listaDeTablas = new List<DataTable>();
            Dictionary<long, DataTable> dicNodosTablas = new Dictionary<long, DataTable>();

            foreach (NodoDemanda nodo in listaNodosConectados)
            {
                PersonaNodos personaNodoHijo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoHijo(_persona.PkCodPersona, nodo.PkNodoDemanda);
                DataTable tablaSum = OraDalDatosDemandaNodoMgr.Instancia.GetDatos(personaNodoHijo.PkPersonaNodo, codTipoTabla);
                if (tablaSum.Rows.Count>0)
                {
                    dicNodosTablas[nodo.PkNodoDemanda] = tablaSum;
                }
            }

            if (dicNodosTablas.Count > 0)
            {
                int i = 0;
                foreach (long pkNodo in dicNodosTablas.Keys)
                {
                    if (i == 0)
                    {
                        tablaSumatoria = dicNodosTablas[pkNodo];
                        i++;
                        continue;
                    }

                    tabla = dicNodosTablas[pkNodo];
                    if (tabla.Rows.Count > 0 && tablaSumatoria.Rows.Count == tabla.Rows.Count)
                    {
                        for (int j = 0; j < tabla.Rows.Count; j++)
                        {
                            tablaSumatoria.Rows[j][0] = DBNull.Value;
                            for (int k = 2; k < 14; k++)
                            {
                                if (tabla.Rows[j][k] is DBNull)
                                {
                                    valor = 0;
                                }
                                else
                                {
                                    valor = (double)tabla.Rows[j][k];
                                }
                                tablaSumatoria.Rows[j][k] = (double)tablaSumatoria.Rows[j][k] + valor;

                            }
                        }
                    }
                    else
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    for (int j = 0; j < tablaSumatoria.Rows.Count; j++)
                    {
                        tablaSumatoria.Rows[j][0] = DBNull.Value;
                    }
                    CopiarDatosATablaSerie(tablaSumatoria);
                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                    _dgvDatos.Columns[1].Frozen = true;
                    _dgvDatos.Columns[0].Visible = false;
                    SumarMontos();
                    FormatearDatos();
                }
                else
                {
                    _tablaEnergiaPotencia.Rows.Clear();
                    _dgvDatos.DataSource = _tablaEnergiaPotencia;
                }
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

        private void _tsbEliminarSerie_Click(object sender, EventArgs e)
        {
            PersonaNodos personaNodo= new PersonaNodos();
            long codTipoTabla = (long) _cmbTipoTabla.SelectedValue;
            if (_dgvDatos.RowCount > 0)
            {
                if (_cmbAgente.SelectedItem != null)
                {
                    DialogResult res = MessageBox.Show("Está seguro de eliminar toda la tabla?", "Confirmación", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        if ((_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && !_cbxNodoSalida.Checked) || (_cbxNodoDeConexion.Checked && _cbxNodo.Checked && !_cbxNodoSalida.Checked))
                        {
                            //********** ELIMINAR TABLAS DE NODOS CONEXION y NODOS*********//
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
                                // elimnar  datos:  energia, potencia maxima, potencia coincidental
                                OraDalDatosDemandaNodoMgr.Instancia.EliminarTablaDatosPersonaNodo(personaNodo.PkPersonaNodo, codTipoTabla);
                            }
                            else
                            {
                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                {
                                    // eliminar datos: identificadores
                                    OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatos(personaNodo.PkPersonaNodo, codTipoTabla);
                                }
                                else
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                    {
                                        // eliminar datos: bloque
                                        OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatos(personaNodo.PkPersonaNodo);
                                    }
                            }
                            _tablaEnergiaPotencia.Rows.Clear();
                        }
                        else
                        {
                            //********** ELIMINAR TABLAS DE NODOS SALIDA *********//

                            if (_cbxNodoDeConexion.Checked && !_cbxNodo.Checked && _cbxNodoSalida.Checked)
                            {
                                // guardar datos para nodo de salida
                                personaNodo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoPadre(_persona.PkCodPersona, ((NodoDemanda)_cmbNodoDeConexion.SelectedItem).PkNodoDemanda);
                                DemandaSalidaMaestro demandaSalidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalida(personaNodo.PkPersonaNodo, (long)_cmbNodoSalida.SelectedValue, _codigoTipoSalida);

                                if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                                {
                                    // eliminar datos:  energia, potencia maxima, potencia coincidental
                                    OraDalDatosDemandaNodoMgr.Instancia.EliminarDatosDeNodoSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                }
                                else
                                {
                                    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                                    {
                                        // ELIMINAR datos: identificadores
                                        OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatosDeNodoSalida(personaNodo.PkPersonaNodo, codTipoTabla, demandaSalidaMaestro.PkDemandaSalidaMaestro);

                                    }
                                    else
                                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES)
                                        {
                                            // ELIMINAR datos: bloque
                                            OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatosDeNodoSalida(personaNodo.PkPersonaNodo, demandaSalidaMaestro.PkDemandaSalidaMaestro);
                                        }
                                }
                                _tablaEnergiaPotencia.Rows.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            long codTipoTabla = (long) _cmbTipoTabla.SelectedValue;
            if (_dgvDatos.RowCount > 0)
            {
                if (_idx == 0 || _idx == _dgvDatos.RowCount - 1)
                {
                    DataRow row = ((DataRowView)_dgvDatos.Rows[_idx].DataBoundItem).Row;
                    DialogResult res = MessageBox.Show("Está seguro de eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        long pkTabla = long.Parse(row[0].ToString());
                        if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                        {
                            OraDalDatosDemandaNodoMgr.Instancia.EliminarRegistro(pkTabla);
                            _tablaEnergiaPotencia.Rows.RemoveAt(_idx);
                        }
                        else
                        {
                            //if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_LLUVIOSA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_PROMEDIO || codTipoTabla == (int)D_COD_CATEGORIA_DATO.IDENTIFICACION_SEMANA_SECA)
                            //{
                            //    // eliminar datos: identificadores
                            //    OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarRegistro(pkTabla);
                            //}
                            //else
                            //    if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.BLOQUE)
                            //    {
                            //        // eliminar datos: bloque
                            //        OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarRegistro(pkTabla);
                            //    }
                        }
                    }
                }
            }  
        }

        private void _dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            _idx = -1;
            if (_dgvDatos.SelectedCells.Count > 0)
            {
                _idx = _dgvDatos.SelectedCells[0].RowIndex;
            }
        }

        private void SumarMontos()
        {
            double potMax = -1;
            double pot = 0;
            long codTipoTabla=(long)_cmbTipoTabla.SelectedValue;
            if (codTipoTabla == (long)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA)
            {
                foreach (DataRow row in _tablaEnergiaPotencia.Rows)
                {
                    double sumaAnual = 0;
                    for (int i = 2; i <= 13; i++)
                    {
                        if (Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                        {
                            sumaAnual = sumaAnual + (double)row[i];
                        }
                    }
                    //row["Anual"] = Math.Round(sumaAnual, 4);
                    row["Anual"] = sumaAnual;
                }
            }
            else 
            {
                if (codTipoTabla == (long)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
                {
                    foreach (DataRow row in _tablaEnergiaPotencia.Rows)
                    {
                        potMax = -1;
                        for (int i = 2; i <= 13; i++)
                        {
                            if (Utiles.EsDecimalPositivoYCero(row[i].ToString()))
                            {
                                pot= (double)row[i];
                                if (pot > potMax)
                                {
                                    potMax = pot;
                                }
                            }
                        }
                        row["Anual"] = potMax;
                    }
                }
            }
        }

        private void _tsbInsertarRegistros_Click(object sender, EventArgs e)
        {
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
            {
                if (_dgvDatos.RowCount > 0)
                {
                    FormInsertarRegistros form = new FormInsertarRegistros();
                    form.SetPararmetros(_tablaEnergiaPotencia);
                    DialogResult res = form.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        _tablaEnergiaPotencia = form.GetTabla();
                        _dgvDatos.DataSource = _tablaEnergiaPotencia;
                        _dgvDatos.Columns[1].Frozen = true;
                        _dgvDatos.Refresh();
                        SumarMontos();
                        FormatearDatos();
                    }
                }
            }
        }

        private void _tsbModificarRegistros_Click(object sender, EventArgs e)
        {
            long codTipoTabla = (long)_cmbTipoTabla.SelectedValue;
            if (codTipoTabla == (int)D_COD_CATEGORIA_DATO.ENERGIA_MENSUAL_HISTORICA || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_COINCIDENTAL || codTipoTabla == (int)D_COD_CATEGORIA_DATO.POTENCIA_MAXIMA)
            {
                if (_dgvDatos.RowCount > 0)
                {
                    FormModificarRegistrosDesdeExcel form = new FormModificarRegistrosDesdeExcel();
                    form.SetPararmetros(_tablaEnergiaPotencia);
                    DialogResult res = form.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        _tablaEnergiaPotencia = form.GetTabla();
                        _dgvDatos.DataSource = _tablaEnergiaPotencia;
                        _dgvDatos.Columns[1].Frozen = true;
                        _dgvDatos.Refresh();
                        SumarMontos();
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

        private void _btnRecalcular_Click(object sender, EventArgs e)
        {
            if (_cbxNodoDeConexion.Checked && !_cbxNodoSalida.Checked && !_cbxNodo.Checked)
            {
                CalcularSumariaValoresDeTablas();
            }else
            {
                if (!_cbxNodoDeConexion.Checked && !_cbxNodoSalida.Checked && !_cbxNodo.Checked)
                {
                    CalcularSumariaValoresDeTablasPorAgente();
                }
            }
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
    }
}
