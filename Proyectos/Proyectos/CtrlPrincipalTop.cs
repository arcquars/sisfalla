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

namespace Proyectos
{
    public partial class CtrlPrincipalTop : CNDC.BaseForms.QuantumBaseControl
    {
        DataTable _tablaEstadosProyecto = new DataTable();
        DefDominio _tipoProyecto;
        DefDominio _etapaProyectoACrear;
        DefDominio _tipoProyectoPadre;
        Proyecto _proyectoActual;
        ProyectoMaestro _proyectoMaestro;
        Dictionary<string, IControles> _dicControles;
        Dictionary<string, TabPage> _dicPaginas;
        IControles _ctrlDatosGenerales;
        bool _esNuevo = false;
        bool _estadoToolBar = true;
        IControles _iCtrl;
        bool _cargandoTabs = false;
        bool _tieneEtapa = false;
        public CtrlPrincipalIzquierda CtrlIzq { get; set; }
        public CtrlPrincipalTop()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                _estadoToolBar = OraDalF_AU_OpcionMgr.Instancia.TieneOpcion(Sesion.Instancia.UsuarioActual.Login, 1010);
                CargarHeadersEstadoProyecto();
                _dicControles = new Dictionary<string, IControles>();
                _dicPaginas = new Dictionary<string, TabPage>();
                _ctrlDatosGenerales = new CtrlDatosGenerales();
                ((CtrlDatosGenerales)_ctrlDatosGenerales).ProyectoGuardado += new EventHandler(CtrlPrincipalTop_ProyectoGuardado);
                AdicionarControlesAlTabABM();
               
            }
            habilitarboton(_estadoToolBar);
        }

        private void habilitarboton(bool estado)
        {
            if (estado)
            {
                this.toolStrip1.Enabled = true;
                this.toolStrip2.Enabled = true;
            }
            else
            {
                this.toolStrip1.Enabled = false;
                this.toolStrip2.Enabled = false;
            }
        }
        private void AdicionarControlesAlTabABM()
        {
            AdicionarADic(_ctrlDatosGenerales);
            AdicionarADic(new CtrlDatosTecnicosDeProyBiomasa());
            AdicionarADic(new CtrlDatosTecnicosDeProysCapacitores());
            AdicionarADic(new CtrlDatosTecnicosDeProysDeTransmisionDeTransformador());
            AdicionarADic(new CtrlDatosTecnicosHidroelectricos());
            AdicionarADic(new CtrlDatosTecnicosProysCicloCombinado());
            AdicionarADic(new CtrlDatosTecnicosProysEolicos());
            AdicionarADic(new CtrlDatosTecnicosProysGeotermico());
            AdicionarADic(new CtrlDatosTecnicosProysLineaTransmision());
            AdicionarADic(new CtrlDatosTecnicosProysReactores());
            AdicionarADic(new CtrlDatostecnicosProysTermicoADiesel());
            AdicionarADic(new CtrlDatosTecnicosProysTermicoAGasTurbinas());
            AdicionarADic(new CtrlDatosTecnicosProyTermicoADualFuel());
            AdicionarADic(new CtrlSeriesHidrolologicas());
            AdicionarADic(new CtrlDatosEconomicosYCronogramaInversion());
            AdicionarADic(new CtrlDatosDeTransmisionAsociadasAlProyecto());
            AdicionarADic(new CtrlDatosDeRduccionDeEmisores());


        }

        void CtrlPrincipalTop_ProyectoGuardado(object sender, EventArgs e)
        {
            if (!_proyectoActual.EsNuevo)
            {
                ActualizarTablaEstados();
            }
        }

        private void ActualizarTablaEstados()
        {
            if (_proyectoActual != null)
            {
                long pkProyecto = _proyectoActual.PkProyecto;
                _proyectoActual = OraDalProyectoMgr.Instancia.GetPorId<Proyecto>(pkProyecto, Proyecto.C_PK_PROYECTO);
                DataRow row = _tablaEstadosProyecto.Rows[0];
                DefDominioMgr mgr = new DefDominioMgr();
                DefDominio etapa = mgr.GetPorId<DefDominio>(_proyectoActual.DCodEtapa, DefDominio.C_COD_DOMINIO);
                _listaEtapasProyecto[etapa] = _proyectoActual.PkProyecto;
                foreach (DataColumn colum in _tablaEstadosProyecto.Columns)
                {
                    if (etapa.Aux1_dom == colum.ColumnName)
                    {
                        row[colum.ColumnName] = global::Proyectos.Properties.Resources.informe4;
                    }
                }

                _dgvEstadosDeProyecto.DataSource = _tablaEstadosProyecto;
                _dgvEstadosDeProyecto.Refresh();
                for (int i = 0; i < _dgvEstadosDeProyecto.Columns.Count; i++)
                {
                    string descDefDominio = _dgvEstadosDeProyecto.Columns[i].HeaderText;
                    long idProyecto = GetIdProyectoPorDescDefDominio(descDefDominio);
                    _dgvEstadosDeProyecto.CurrentRow.Cells[i].Selected = false;
                    if (idProyecto == pkProyecto)
                    {
                        _dgvEstadosDeProyecto.CurrentRow.Cells[i].Selected = true;
                        if (!_tabABM.Visible)
                        {
                            _tabABM.Visible = true;
                        }
                        break;
                    }
                }
                _tabABM.SelectedIndex = 0;
                _proyectoActual = OraDalProyectoMgr.Instancia.GetPorId<Proyecto>(pkProyecto, Proyecto.C_PK_PROYECTO);
                ((CtrlDatosGenerales)_ctrlDatosGenerales).SetTipoProyecto(_tipoProyecto, _tipoProyectoPadre);
                _ctrlDatosGenerales.SetParametros(true, _proyectoActual);
            }
        }

        private void AdicionarADic(IControles c)
        {
            TabPage pag = new TabPage(c.Titulo);
            Control ctrl = c as Control;
            c.SetEstadoToolBar(_estadoToolBar);
            ctrl.Location = new Point(0, 0);
            if (ctrl.Width> _tabABM.Width)
            {
                _tabABM.Width = ctrl.Width+20;
            }
            if (ctrl.Height > _tabABM.Height)
            {
                _tabABM.Height = ctrl.Height+20;
            }
            
            //pag.AutoScroll = true;
            ctrl.Dock = DockStyle.Fill;
            pag.Controls.Add(ctrl);
            _dicControles[c.GetType().FullName] = c;
            _dicPaginas[c.GetType().FullName] = pag;
            if (c is CtrlDatosBase)
            {
                (c as CtrlDatosBase).EstadoDeEdicionModificado += new EventHandler<EstadoDeEdicionEventArgs>(CtrlPrincipalTop_EstadoDeEdicionModificado);
            }
        }

        void CtrlPrincipalTop_EstadoDeEdicionModificado(object sender, EstadoDeEdicionEventArgs e)
        {
            _gbxProyectos.Enabled = !e.Editando;
            _gbxProyectosMaestro.Enabled = !e.Editando;
            if (CtrlIzq !=null)
            {
                CtrlIzq.Enabled = !e.Editando;
                if (_tabABM.Visible==false)
                {
                    _gbxProyectos.Enabled = true;
                    _gbxProyectosMaestro.Enabled = true;
                    CtrlIzq.Enabled = true;
                }
            }
        }

        private void CargarControlesPorTipoProyecto()
        {
            _cargandoTabs = true;
            if (TipoProyectoUIMgr.Instancia.EsNodoHoja(_tipoProyecto))
            {
                List<string> listaDeNombresDeControles = OraDalTipoProyectoControlesMgr.Instancia.GetPorIdTipoProyecto(_tipoProyecto.CodDominio);
                if (listaDeNombresDeControles.Count > 0)
                {
                    int idx = 0;

                    foreach (KeyValuePair<string, TabPage> kv in _dicPaginas)
                    {
                        if (!listaDeNombresDeControles.Contains(kv.Key))
                        {
                            _tabABM.TabPages.Remove(kv.Value);
                        }
                    }

                    foreach (KeyValuePair<string, TabPage> kv in _dicPaginas)
                    {
                        if (listaDeNombresDeControles.Contains(kv.Key))
                        {
                            if (!_tabABM.TabPages.Contains(kv.Value))
                            {
                                _tabABM.TabPages.Insert(idx, kv.Value);
                            }
                            idx++;
                        }
                    }
                }
            }
            _cargandoTabs = false;
        }

        private void CargarHeadersEstadoProyecto()
        {
            _tablaEstadosProyecto = new DataTable();
            DefDominioMgr mgr = new DefDominioMgr();
            BindingList<DefDominio> lista = mgr.GetListaDominio(DominiosProyectos.D_COD_ETAPA_PROYECTO);

            foreach (DefDominio etapa in lista)
            {
                DataColumn c_Columna = new DataColumn(etapa.Aux1_dom, typeof(Bitmap));
                _tablaEstadosProyecto.Columns.Add(c_Columna);
            }

            _dgvEstadosDeProyecto.DataSource = _tablaEstadosProyecto;
        }

        Dictionary<DefDominio, long> _listaEtapasProyecto;
        private void CargarEstadosDelProyecto()
        {
            _tablaEstadosProyecto.Rows.Clear();
            DefDominioMgr mgr= new DefDominioMgr();
            _listaEtapasProyecto = mgr.GetListaEstapasProyectoPorPkProyMaestro(_proyectoMaestro.PkProyectoMaestro);
            _tabABM.Visible = true;

            if (_listaEtapasProyecto.Count == 0)
            {
                _tabABM.Visible = false;
                DataRow row = _tablaEstadosProyecto.NewRow();
                _tablaEstadosProyecto.Rows.Add(row);
                _dgvEstadosDeProyecto.DataSource = _tablaEstadosProyecto;
            }
            else
            {
                DataRow row = _tablaEstadosProyecto.NewRow();
                foreach (KeyValuePair<DefDominio, long> kv in _listaEtapasProyecto)
                {
                    DefDominio etapa = kv.Key;
                    foreach (DataColumn colum in _tablaEstadosProyecto.Columns)
                    {
                        if (etapa.Aux1_dom == colum.ColumnName)
                        {
                            row[colum.ColumnName] = global::Proyectos.Properties.Resources.informe4;//Bitmap.FromFile("InformeListoA.png");
                        }
                    }
                }
                
                _tablaEstadosProyecto.Rows.Add(row);
                _dgvEstadosDeProyecto.DataSource = _tablaEstadosProyecto;
            }
        }

        private long GetIdProyectoPorDescDefDominio(string descDefDominio)
        {
            long resultado = 0;
            foreach (KeyValuePair<DefDominio, long> kv in _listaEtapasProyecto)
            {
                if (descDefDominio== kv.Key.Aux1_dom)
                {
                    resultado = kv.Value;
                    break;
                }
            }
            return resultado;
        }

        private void CargarDatos()
        {
            _dgvProyectos.DataSource = OraDalProyectoMaestroMgr.Instancia.GetTablaPorTipoProyecto(int.Parse(_tipoProyecto.CodDominio.ToString()));
            _dgvProyectos.Columns[ProyectoMaestro.C_NOMBRE].Width = 325;
            _dgvProyectos.Columns["CODIGO"].Width = 110;
            _dgvProyectos.Columns[0].Visible = false;
            _btnEditar.Enabled = _dgvProyectos.RowCount > 0 ? true : false;
            _btnEliminar.Enabled = _dgvProyectos.RowCount > 0 ? true : false;
            _tsbEliminarProyecto.Enabled = _dgvProyectos.RowCount > 0 && _dgvEstadosDeProyecto.RowCount>0 ? true : false;
            _tsbInsertarProyecto.Enabled = _dgvProyectos.RowCount > 0 && !_tieneEtapa ? true : false;
            _tabABM.Visible = _dgvProyectos.RowCount > 0 && _proyectoActual!=null? true : false;
        }

        private void _btnInsertar_Click(object sender, EventArgs e)
        {
            ProyectoMaestro proyMaestroSelPrevio = _proyectoMaestro;
            DefDominioMgr mgr= new DefDominioMgr();
            FormABProyectoMaestro form = new FormABProyectoMaestro();
            _proyectoMaestro = new ProyectoMaestro();
            _proyectoMaestro.EsNuevo = true;
            _proyectoMaestro.DTipoProyecto = _tipoProyecto.CodDominio;
            _proyectoMaestro.DTipoProyectoPadre = _tipoProyectoPadre.CodDominio;
            form.Editar(_proyectoMaestro);
            DialogResult res = form.DialogResult;
            DefDominio tipoProyecto = mgr.GetPorId<DefDominio>(_proyectoMaestro.DTipoProyecto, DefDominio.C_COD_DOMINIO);
            ProyectoMaestro proyMaestro = _proyectoMaestro;
            if (res == DialogResult.OK)
            {
                _proyectoActual = form.GetProyecto();
                DefDominio etapaProyecto = mgr.GetPorId<DefDominio>(_proyectoActual.DCodEtapa, DefDominio.C_COD_DOMINIO);
                if (!_proyectoMaestro.EsNuevo)
                {
                    FiltrarPorTipoProy(_tipoProyecto, _tipoProyectoPadre);
                    _proyectoMaestro = proyMaestro;
                    ActualizarPosicionDelControl();
                    _proyectoActual = _proyectoMaestro.CrearNuevoProyecto();
                    _proyectoActual.DCodEtapa = etapaProyecto.CodDominio;
                    ActualizarPunteroTablaEstados();
                    _proyectoActual = _proyectoMaestro.CrearNuevoProyecto();
                    _proyectoActual.DCodEtapa = etapaProyecto.CodDominio;
                    if (!_tabABM.Visible)
                    {
                        _tabABM.Visible = true;
                    }
                    _tabABM.SelectedIndex = 0;
                    // Cargando Datos generales del Proyecto
                    ((CtrlDatosGenerales)_ctrlDatosGenerales).SetTipoProyecto(_tipoProyecto, _tipoProyectoPadre);
                    _ctrlDatosGenerales.SetParametros(true, _proyectoActual);
                }
            }
            else
            {
                _proyectoMaestro = proyMaestroSelPrevio;
            }
          
        }

        private void ActualizarPunteroTablaEstados()
        {
            if (_proyectoActual != null)
            {
                DefDominioMgr mgr= new DefDominioMgr();
                string etapaProyecto=(mgr.GetPorId<DefDominio>(_proyectoActual.DCodEtapa, DefDominio.C_COD_DOMINIO)).Aux1_dom;
                for (int i = 0; i < _dgvEstadosDeProyecto.Columns.Count; i++)
                {
                    string descDefDominio = _dgvEstadosDeProyecto.Columns[i].HeaderText;
                    _dgvEstadosDeProyecto.CurrentRow.Cells[i].Selected = false;
                    if (descDefDominio == etapaProyecto )
                    {
                        _dgvEstadosDeProyecto.CurrentRow.Cells[i].Selected = true;
                        break;
                    }
                }
            }
        }

        public void DesHabilitarPaneles()
        {
            _gbxProyectos.Enabled = false;
            _gbxProyectosMaestro.Enabled = false;
        }

        public void HabilitarPaneles()
        {
            _gbxProyectos.Enabled = true;
            _gbxProyectosMaestro.Enabled = true;
        }

        private void _dgvProyectos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvProyectos.RowCount > 0)
            {
                int idx = e.RowIndex;
                if (idx > 0)
                {
                    if (idx % 2 != 0)
                    {
                        e.CellStyle.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }

            }
        }

        private void _dgvEstadosDeProyecto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _dgvEstadosDeProyecto.Rows[0].HeaderCell.Value = "CNDC";
            _dgvEstadosDeProyecto.RowHeadersWidth = 65;
            for (int i = 0; i < _dgvEstadosDeProyecto.ColumnCount; i++)
            {
                _dgvEstadosDeProyecto.Columns[i].Width = 63;
            }
        }

        public void FiltrarPorTipoProy(DefDominio tipoDeProyecto, DefDominio tipoDeProyectoPadre)
        {
            idxActual = 0;
            _tipoProyecto = tipoDeProyecto;
            if (TipoProyectoUIMgr.Instancia.EsNodoHoja(_tipoProyecto))
            {
                _btnInsertar.Enabled = true;
                _tipoProyectoPadre = tipoDeProyectoPadre;
                CargarControlesPorTipoProyecto();
                CargarDatos();
            }
            else
            {
                _dgvProyectos.DataSource = null;
                _dgvEstadosDeProyecto.DataSource = null;
                _btnInsertar.Enabled = false;
                _btnEliminar.Enabled = false;
                _btnEditar.Enabled = false;
                _tsbEliminarProyecto.Enabled = false;
                _tsbInsertarProyecto.Enabled = false;
                _tabABM.Visible = false;
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            DefDominioMgr mgr = new DefDominioMgr();
            FormABProyectoMaestro form = new FormABProyectoMaestro();
            form.Editar(_proyectoMaestro);
            DefDominio tipoProyecto = mgr.GetPorId<DefDominio>(_proyectoMaestro.DTipoProyecto, DefDominio.C_COD_DOMINIO);
            ProyectoMaestro proyMaestro = _proyectoMaestro;
            if (!_proyectoMaestro.EsNuevo)
            {
                FiltrarPorTipoProy(_tipoProyecto, _tipoProyectoPadre);
                _proyectoMaestro = proyMaestro;
                ActualizarPosicionDelControl();
            }
        }

        private void _tsbInsertarProyecto_Click(object sender, EventArgs e)
        {
            _esNuevo = true;
            if (_proyectoMaestro == null)
            {
                if (_tabABM.Visible)
                {
                    _tabABM.Visible = false;
                }
            }
            else
            {
                _proyectoActual = _proyectoMaestro.CrearNuevoProyecto();
                _proyectoActual.DCodEtapa = _etapaProyectoACrear.CodDominio;
                FormCopiarDatosDeOtraEtapa form = new FormCopiarDatosDeOtraEtapa();
                form.CargarEtapasDelProyecto(_proyectoActual);
                DialogResult res = form.DialogResult;
                idxActual = 0;
                _tabABM.SelectedIndex = 0;
                if (res == DialogResult.OK)
                {
                    if (!_tabABM.Visible)
                    {
                        _tabABM.Visible = true;
                    }

                    _proyectoActual = form.GetProyectoActual();
                    ActualizarTablaEstados();
                    // Cargando Datos generales del Proyecto
                    ((CtrlDatosGenerales)_ctrlDatosGenerales).SetTipoProyecto(_tipoProyecto, _tipoProyectoPadre);
                    _ctrlDatosGenerales.SetParametros(true, _proyectoActual);
                }
                else if (res == DialogResult.No)
                {
                    if (!_tabABM.Visible)
                    {
                        _tabABM.Visible = true;
                    }

                    _proyectoActual = form.GetProyectoActual();
                    // Cargando Datos generales del Proyecto
                    ((CtrlDatosGenerales)_ctrlDatosGenerales).SetTipoProyecto(_tipoProyecto, _tipoProyectoPadre);
                    _ctrlDatosGenerales.SetParametros(true, _proyectoActual);
                }
                else if (res == DialogResult.Cancel)
                {
                    if (_tabABM.Visible)
                    {
                        _tabABM.Visible = false;
                    }
                }
            }
        }

        private void _tsbEliminarProyecto_Click(object sender, EventArgs e)
        {
            bool eliminado = false;
            if (_proyectoActual != null)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar el proyecto?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    eliminado = true;
                    OraDalProyectoMgr.Instancia.CambiarEstadoProyecto(_proyectoActual.PkProyecto, 0);
                    CargarEstadosDelProyecto();
                    ActualizarPosicionDelControl();
                    SeleccionarEtapaActual();
                }
            }
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            _esNuevo = false;
            _tablaEstadosProyecto.Rows.Clear();
            _proyectoActual = null;
            idxActual = 0;
            if (_dgvProyectos.SelectedRows.Count == 0)
            {
                _proyectoMaestro = null;
            }
            else
            {
                DataRow row = ((DataRowView)_dgvProyectos.SelectedRows[0].DataBoundItem).Row;
                int pkProyMaestro = int.Parse(row[0].ToString());
                _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(pkProyMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
                CargarEstadosDelProyecto();
            }

            if (_proyectoMaestro == null)
            {
                _btnEditar.Enabled = false;
            }
            else
            {
                //Inicializar Todos 
                if (_dgvEstadosDeProyecto.Rows.Count == 0)
                {
                    if (_tabABM.Visible)
                    {
                        _tabABM.Visible = false;
                    }
                }
                else
                {
                    SeleccionarEtapaActual();
                }
            }
            _btnEditar.Enabled = true;//_listaEtapasProyecto.Count == 0 ? true : false;
        }

        private void SeleccionarEtapaActual()
        {
            int idxCol = -1;
            for (int i = 0; i < _dgvEstadosDeProyecto.ColumnCount; i++)
            {
                if (!(_dgvEstadosDeProyecto.Rows[0].Cells[i].Value is DBNull))
                {
                    idxCol = i;
                }
            }

            if (idxCol != -1)
            {
                _dgvEstadosDeProyecto.Rows[0].Cells[idxCol].Selected = true;
                VisualizarDatosDeEtapaSeleccionada();
            }
        }

        public void ActualizarPosicionDelControl()
        {
            int posicion = 0;
            for (int i = 0; i < _dgvProyectos.RowCount; i++)
            {
                DataRow row = ((DataRowView)_dgvProyectos.Rows[i].DataBoundItem).Row;
                int pkProyMaestro = int.Parse(row[0].ToString());
                if (pkProyMaestro == _proyectoMaestro.PkProyectoMaestro)
                {
                    posicion = i;
                    break;
                }
            }
            BindingContext[_dgvProyectos.DataSource].Position = posicion;
        }

        private void _dgvEstadosDeProyecto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void _dgvEstadosDeProyecto_SelectionChanged(object sender, EventArgs e)
        {
            VisualizarDatosDeEtapaSeleccionada();
        }

        private void VisualizarDatosDeEtapaSeleccionada()
        {
            _tabABM.Visible = true;

            if (_dgvEstadosDeProyecto.SelectedCells.Count > 0)
            {
                if (_dgvEstadosDeProyecto.CurrentCell.Value is DBNull)
                {
                    _tabABM.Visible = false;
                    _proyectoActual = null;
                    string descDefDominio = _dgvEstadosDeProyecto.Columns[_dgvEstadosDeProyecto.CurrentCell.ColumnIndex].HeaderText;
                    DefDominioMgr mgr = new DefDominioMgr();
                    _etapaProyectoACrear = mgr.GetEtapaPorDescDefDominio(descDefDominio);
                    _tsbInsertarProyecto.Enabled = true;
                    _tsbEliminarProyecto.Enabled = false;
                    _tieneEtapa = false;
                }
                else
                {
                    _tieneEtapa = true;
                    _tsbInsertarProyecto.Enabled = false;
                    _tsbEliminarProyecto.Enabled = true;
                    string descDefDominio = _dgvEstadosDeProyecto.Columns[_dgvEstadosDeProyecto.CurrentCell.ColumnIndex].HeaderText;
                    long idProyecto = GetIdProyectoPorDescDefDominio(descDefDominio);
                    _proyectoActual = OraDalProyectoMgr.Instancia.GetPorId<Proyecto>(idProyecto, Proyecto.C_PK_PROYECTO);
                    DefDominioMgr mgr = new DefDominioMgr();
                    _etapaProyectoACrear = mgr.GetEtapaPorDescDefDominio(descDefDominio);
                }
                CargarProyectoActual();
            }
        }

        private void CargarProyectoActual()
        {
            if (_proyectoActual == null)
            {
                if (_tabABM.Visible)
                {
                    _tabABM.Visible = false;
                }
            }
            else
            {
                if (!_tabABM.Visible)
                {
                    _tabABM.Visible = true;
                }
                _tabABM.SelectedIndex=0;
                // Cargando Datos generales del Proyecto
                ((CtrlDatosGenerales)_ctrlDatosGenerales).SetTipoProyecto(_tipoProyecto, _tipoProyectoPadre);
                _ctrlDatosGenerales.SetParametros(false, _proyectoActual);
            }
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            bool eliminado = false;
            if (_proyectoMaestro != null)
            {
                DialogResult res = MessageBox.Show("Está seguro de eliminar el proyecto maestro?", "Confirmación", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    eliminado = true;
                    OraDalProyectoMaestroMgr.Instancia.CambiarEstadoProyectoMaestro(_proyectoMaestro.PkProyectoMaestro, 0);
                    FiltrarPorTipoProy(_tipoProyecto,_tipoProyectoPadre);
                }
            }
        }

        int idxActual = 0;

        private void _tabABM_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_cargandoTabs)
            {
                idxActual = 0;
                return;
            }

            _iCtrl = (IControles)_tabABM.TabPages[idxActual].Controls[0];
            if (_iCtrl.Guardado)
            {
                idxActual = e.TabPageIndex;
                _iCtrl = (IControles)_tabABM.TabPages[idxActual].Controls[0];
                _iCtrl.SetParametros(false, _proyectoActual);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
