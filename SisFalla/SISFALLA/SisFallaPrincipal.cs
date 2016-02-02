using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using OraDalSisFalla;
using repSisfalla;
using System.Security.Principal;
using CNDC.Dominios;
using CNDC.BLL;

using System.Runtime.InteropServices;
using MenuQuantum;
using BLL;
using CNDC.Sincronizacion;
using CNDC.ExceptionHandlerLib;
using WcfDalSisFalla;
using System.IO;
using CNDC.Pistas;

using System.Configuration;

namespace SISFALLA
{
    public partial class SisFallaPrincipal : QuantumBaseControl
    {
        private RegFalla _fallaSeleccionada = null;
        private Persona _usuarioSeleccionado = null;
        private DataRow _rowFallaSeleccionada = null;
        private DataView _dvwUsuarios;
        private long _idUsuarioSeleccionado = -1;
        private IProveedorTablaRegFalla _proveedorVistaSeleccionado;
        private const int MaxFallasVisibles = 22;

        private bool refreshSisFalla;

        public SisFallaPrincipal()
        {
            InitializeComponent();
            _dgvFallas.MultiSelect = false;
            _txtFiltroNumeroFalla.LostFocus +=new EventHandler(FiltroNumeroFalla_LostFocus);
            _txtFiltroNumeroFalla.KeyPress += new KeyPressEventHandler(FiltroNumeroFalla_KeyPress);
            _txtFiltroNumeroFalla.KeyDown += new KeyEventHandler(_txtFiltroNumeroFalla_KeyDown);
            ActualizadorDelActualizador.Actualizar();
            _dgvFallas.MouseUp += new MouseEventHandler(_dgvFallas_MouseUp);
            bgwSincronizadorFallas.DoWork += bgwSincronizadorFallas_DoWork;
            bgwSincronizadorFallas.WorkerReportsProgress = true;
            bgwSincronizadorFallas.ProgressChanged += bgwSincronizadorFallas_ProgressChanged;

            refreshSisFalla = false;
        }

        void bgwSincronizadorFallas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int c = SincronizadorCliente.Instancia.Actualizar.Count;
            int l = e.ProgressPercentage;
            int UltimaFalla = (int)e.UserState;
            string cod = string.Empty;
            if (UltimaFalla > 12000)
            {
                cod = InformeFalla.Transform_codfalla(UltimaFalla);
            }
            this.label1.Text = string.Format("{0} de {1}:Ultima Falla: {2} ", c,l,cod);           
        }

        void bgwSincronizadorFallas_DoWork(object sender, DoWorkEventArgs e)
        {
            if (SincronizadorCliente.Instancia.PingHost())
            {
                CNDC.Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "ActualizarFallas " + DateTime.Now.ToString(), TipoPista.Debug);
                
                    if (SincronizadorCliente.Instancia.SincronizarInformesFalla())
                    {
                        ActualizarFallas();
                    }
                    else
                    {
                        
                    }
                    CNDC.Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "ActualizarFallas Terminado " + DateTime.Now.ToString(), TipoPista.Debug);
                
            }
            else
            {
                
            }
        }

        void _dgvFallas_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {

                foreach (DataGridViewRow row in _dgvFallas.Rows)
                {
                    row.Selected = false;
                }

                // Get the selected Row 
                DataGridView.HitTestInfo info = _dgvFallas.HitTest(e.X, e.Y);

                // Set as selected 
                _dgvFallas.Rows[info.RowIndex].Selected = true; 

                hitTestInfo = _dgvFallas.HitTest(e.X, e.Y);
                
                if ((hitTestInfo.Type == DataGridViewHitTestType.Cell)  && (  Sesion.Instancia.RolSIN != "CNDC"))
                {    
                    // Preguntamos si es Diferente de Jefe de Division para no mostrar la opcion de 
                    // borrado del informe
                    if (!isJefeDivisionCndc())
                    {
                        this._tbsBorrarInformesDeFalla.Visible = false;
                    }
                    _cmDescargarFalla.Show(_dgvFallas, e.Location); 
                }
                Console.WriteLine("dddddd:: "+ Sesion.Instancia.RolSIN+"; "+ hitTestInfo.Type);
                if ((  Sesion.Instancia.RolSIN == "CNDC") && isJefeDivisionCndc())
                {
                    this._tbsBorrarInformesDeFalla.Visible = true;
                    this._tbsDescargarInformesDeFalla.Visible = false;
                    _cmDescargarFalla.Show(_dgvFallas, e.Location);
                }
                
            }

        }

        private bool isJefeDivisionCndc()
        {
            bool rolCNDC = false;
            foreach (Rol value in Sesion.Instancia.RolesActuales)
            {
                if (value.Num_Rol == 2)
                    rolCNDC = true;
            }

            return rolCNDC;
        }

        void _txtFiltroNumeroFalla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            } 

        }

        private bool HasMenos()
        {
            bool rtn = false;

            if (_txtFiltroNumeroFalla.Text.IndexOf('-') != -1)
            {
                rtn = true;
            }
            return rtn;
        }

        void FiltroNumeroFalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar)) && ((e.KeyChar != (char)45) || HasMenos()))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                Control c = GetNextControl((Control)sender, true);
                if (c != null)
                    c.Focus();
            }
        }

        private void AsegurarCmbVista()
        {
            IProveedorTablaRegFalla agente = new ProveedorPorAgente ("Agente: " + Sesion.Instancia.EmpresaActual.Sigla,Sesion.Instancia.EmpresaActual.PkCodPersona );
            IProveedorTablaRegFalla todos = new ProveedorPorEstado("Todos los agentes", null);
            IProveedorTablaRegFalla enElab = new ProveedorPorEstado(Sesion.Instancia.EmpresaActual.Sigla +": En Elaboración", D_COD_ESTADO_INF.EN_ELABORACION);
            IProveedorTablaRegFalla enRevision = new ProveedorPorEstado(Sesion.Instancia.EmpresaActual.Sigla +": En Revisión", D_COD_ESTADO_INF.ELABORADO);
            IProveedorTablaRegFalla enEnviados = new ProveedorPorEstado(Sesion.Instancia.EmpresaActual.Sigla + ": Enviados", D_COD_ESTADO_INF.ENVIADO);
            _cmbVista.Items.Add(agente);

            _cmbVista.Items.Add(todos);
                        _cmbVista.Items.Add(enElab);
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _cmbVista.Items.Add(enRevision);
            }
            _cmbVista.Items.Add(enEnviados);
            _cmbVista.Items.Add(new ProveedorPorNotif(Sesion.Instancia.EmpresaActual.Sigla + ": Notificaciones"));
            _cmbVista.SelectedIndex = 0;
            _proveedorVistaSeleccionado = agente;
        }

        SplashQuantum _splash;
        public void CargarDatosInicio(SplashQuantum splash)
        {
            CargarImagenFondo();
            _splash = splash;
            Sesion.Instancia.Conexion.ConexionPerdida += new EventHandler(Conexion_ConexionPerdida);
            Application.DoEvents();

           
            try
            {
                Inicializador.Inicializar();
                PistaMgr.Instance.Debug("CargarDatosInicio", string.Format("TipoBD:{0}", Sesion.Instancia.ConfigConexion.TipoBD));
                if (Sesion.Instancia.ConfigConexion.TipoBD == CNDC.DAL.TipoBaseDatos.Local)
                {
                    PistaMgr.Instance.Debug("CargarDatosInicio", "Iniciando Sincronizacion");
                    SincronizadorCliente.Instancia.Sincronizando += new EventHandler<SincEventArgs>(Sincronizador_Sincronizando);
                    bool offline = CNDC.BLL.Sesion.Instancia.ConfigConexion.IsConnection;
                    if (SincronizadorCliente.Instancia.PingHost())
                    {
                        if (SincronizadorCliente.Instancia.PingHost())
                        {
                            if (SincronizadorCliente.Instancia.SincronizarDatos())
                            {
                                List<MensajeEmergente> mensajes = new List<MensajeEmergente>();
                                mensajes = MensajeEmergenteMgr.Intancia.GetMensajes();
                                _ctrlSincronizacion.Finalizar(mensajes);
                            }
                            PistaMgr.Instance.Debug("CargarDatosInicio", "Fin Sincronizacion");
                        }
                        else
                        {
                            MessageBox.Show("No hay conexion con la vpn.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Trabajo fuera de linea..");
                    }
                }

            }
            catch (Exception exc)
            {

                PistaMgr.Instance.EscribirLog("ActualizarFallas",exc, TipoPista.Error); 
            }
          
            AsegurarCmbVista();
         
            _pnlPrincipal.Visible = true;
            _splash = null;
            AjustarPanelPrincipal();
            
            cargarConfiguracionCorreo();
            if (bgwSincronizadorFallas.IsBusy != true)
            {
                bgwSincronizadorFallas.RunWorkerAsync();
            }
            _timerSinc.Enabled = true;

        }

        private void ActualizarFallas()
        {
            try
            {
                _timerSinc.Enabled = false;
                int i = 0;
                int LastCodfalla = 0;

                

                if (SincronizadorCliente.Instancia != null)
                {
                    int l = SincronizadorCliente.Instancia.Actualizar.Count;

                    try
                    {
                        foreach (SincronizadorRegistroFallas item in SincronizadorCliente.Instancia.Actualizar)
                        {
                            i++;
                            PistaMgr.Instance.EscribirLog("ActualizarFallas", "Sincronizando : " + i + item.ToString() + " de " + l.ToString() + " Registros.", TipoPista.Debug);
                            bool dummy;
                            byte[] informe = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, item.PkCodFalla, item.PkOrigenFalla, item.PkDCodTipoInforme);
                            PistaMgr.Instance.EscribirLog("ActualizarFallas", "Tamaño : " + informe.Length.ToString(), TipoPista.Debug);
                            FormDescargaInformeBatch.ImportarInforme(informe, out dummy);
                            SincronizadorCliente.Instancia.OnSincronizando(i, l, "Sincronizando Fallas");
                            if (i % 10 == 0)
                            {
                                int p = (100 * i) / l;
                                //bgwSincronizadorFallas.ReportProgress(p, item.PkCodFalla);
                            }
                            LastCodfalla = item.PkCodFalla;
                        }
                    }
                    catch (Exception ex )
                    {

                        PistaMgr.Instance.EscribirLog("ActualizarFallas", ex, TipoPista.Error);
                    }
                    
                    SincronizadorCliente.Instancia.Actualizar.Clear();
                    //bgwSincronizadorFallas.ReportProgress(100, LastCodfalla);
                    _timerSinc.Enabled = true;
                }
                else
                {
                    PistaMgr.Instance.EscribirLog("ActualizarFallas", "Error: no se definió : SincronizadorCliente.Instancia.Actualizar.Count ", TipoPista.Error);
                }
            }
            catch (Exception ex )
            {
                PistaMgr.Instance.EscribirLog("ActualizarFallas", ex, TipoPista.Error);
                throw;
            }
      
        }
        private void CargarImagenFondo()
        {
            string dirEjecucion = Path.GetDirectoryName(Application.ExecutablePath);
            string archFondo = Path.Combine(dirEjecucion, "wall1.jpg");
            if (File.Exists(archFondo))
            {
                Image img = Bitmap.FromFile(archFondo);
                this.BackgroundImage = img;
            }
        }

        void Conexion_ConexionPerdida(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler eh = new EventHandler(Conexion_ConexionPerdida);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                MessageBox.Show("Se ha perdido la conexión con la Base de Datos. Se procedera a Cerrar la aplicación. Consulte con el Administrador.");//MessageMgr.Instance.GetMessage("CONEXION_PERDIDA"));
                Application.Exit();
            }
        }

        private void cargarConfiguracionCorreo()
        {
            long cod = Sesion.Instancia.EmpresaActual.PkCodPersona;
            string codDominio = "D_COD_ENVIO_QUANTUM";
            EnvioCorreo envio = new EnvioCorreo();
            try
            {
                if (envio.existeConfiguracion(cod))
                {
                    Sesion.Instancia.ConfiguracionCorreo = envio.consultaConfiguracion(cod);
                }
                else
                {
                    envio.Ejecutar();
                    Sesion.Instancia.ConfiguracionCorreo = envio.consultaConfiguracion(cod);
                }
                if (envio.existeConfiguracion(cod,codDominio))
                {
                    Sesion.Instancia.ConfigEnvioQuantum = envio.consultaConfiguracion(cod, codDominio);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void Sincronizador_Sincronizando(object sender, SincEventArgs e)
        {
            if (_splash != null)
            {
                _splash.SetEstadoSincronizacion(e.Actual, e.Total, e.Texto );
            }
        }

        public void Recargar()
        {
            
            RegFalla fallaTemp = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            long usuarioTmp = _idUsuarioSeleccionado;

            
            CargarFallas();
            
            formatDatagrids(_dgvFallas);
            
            _dgvFallas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            formatDatagrids(_dgvUsuarios);
            
            if (fallaTemp != null)
            {
                SeleccionarFallaEnGrid(fallaTemp);
                OnFallaSeleccionada();
            }

            if (usuarioTmp != 0)
            {
                SeleccionarUsuarioEnGrid(usuarioTmp);
            }
            
        }

        private void SeleccionarUsuarioEnGrid(long usuarioTmp)
        {
            
            for (int i = 0; i < _dgvUsuarios.Rows.Count; i++)
            {
                DataRow r = ((DataRowView)_dgvUsuarios.Rows[i].DataBoundItem).Row;
                if (usuarioTmp == (long)r["pk_cod_persona"])
                {
                    _dgvUsuarios.Rows[i].Selected = true;
                    _dgvUsuarios.BindingContext[_dvwUsuarios].Position = i;
                }
                else
                {
                    _dgvUsuarios.Rows[i].Selected = false;
                }
            }
        }

        private void CargarFallas()
        {
            DataTable tabla = ModeloMgr.Instancia.RegFallaMgr.GetAgentesInvolucrados();
            if (tabla.Columns.Count > 0)
            {
                _dvwUsuarios = new DataView(tabla);
                _dgvUsuarios.DataSource = _dvwUsuarios;
                _dgvUsuarios.AsegurarColumnas();
                _dvwUsuarios.RowFilter = " PK_COD_FALLA = 0";

                DataTable tablaFallasActualizado = _proveedorVistaSeleccionado.GetTablaRegFalla();
                if (_dgvFallas.DataSource == null)
                {
                    _dgvFallas.DataSource = tablaFallasActualizado;
                    _dgvFallas.AsegurarColumnas();
                    _dgvFallas.Sort(_dgvFallas.Columns[RegFalla.C_PK_COD_FALLA], ListSortDirection.Descending);

                    if (_dgvFallas.Rows.Count > 0)
                    {
                        _dgvFallas.Rows[0].Selected = true;
                    }
                }
                else
                {
                    ActualizadorTablaRegFalla.Actualizar(tablaFallasActualizado, _dgvFallas.DataSource as DataTable);
                }
            }
        }

        private void CargarFallas1()
        {
            DataTable tabla = ModeloMgr.Instancia.RegFallaMgr.GetAgentesInvolucrados();
            if (tabla.Columns.Count > 0)
            {
                _dvwUsuarios = new DataView(tabla);
                _dgvUsuarios.DataSource = _dvwUsuarios;
                _dgvUsuarios.AsegurarColumnas();
                _dvwUsuarios.RowFilter = " PK_COD_FALLA = 0";

                DataTable tablaFallasActualizado = _proveedorVistaSeleccionado.GetTablaRegFalla();
                
                    _dgvFallas.DataSource = tablaFallasActualizado;
                    _dgvFallas.AsegurarColumnas();
                    _dgvFallas.Sort(_dgvFallas.Columns[RegFalla.C_PK_COD_FALLA], ListSortDirection.Descending);

                    if (_dgvFallas.Rows.Count > 0)
                    {
                        _dgvFallas.Rows[0].Selected = true;
                    }
            }
        }
        private void _dgvFallas_SelectionChanged(object sender, EventArgs e)
        {
            OnFallaSeleccionada();
        }

        private void OnFallaSeleccionada()
        {
            if (_dgvFallas.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvFallas.SelectedRows[0].DataBoundItem;
                _rowFallaSeleccionada = drView.Row;
                AsegurarFallaSeleccionda();
                FiltarAgentesFallaSeleccionada();
                SeleccionarUsuarioEnGrid(Sesion.Instancia.EmpresaActual.PkCodPersona);
            }
            else
            {
                _dvwUsuarios.RowFilter = " PK_COD_FALLA = 0";
            }
           
        }

        private void AsegurarFallaSeleccionda()
        {
            _fallaSeleccionada = new RegFalla(_rowFallaSeleccionada);
            
            Sesion.Instancia.SetObjetoGlobal("Principal.FallaActual", _fallaSeleccionada);
        }

        private void FiltarAgentesFallaSeleccionada()
        {
            if (_dvwUsuarios != null)
            {
                int idFalla = (int)_rowFallaSeleccionada["PK_COD_FALLA"];
                try
                {
                    _dvwUsuarios.RowFilter = " PK_COD_FALLA = " + idFalla;
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void _dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dgvUsuarios.SelectedRows.Count > 0)
                {
                    DataRowView drView = (DataRowView)_dgvUsuarios.SelectedRows[0].DataBoundItem;
                    _idUsuarioSeleccionado = (long)drView.Row["pk_cod_persona"];
                    AsegurarBotonPublicar(drView);
                    AsegurarBoton(_btnVerInfPreliminar, drView.Row["estado_pre"]);
                    AsegurarBoton(_btnVerInfFinal, drView.Row["estado_fin"]);
                    AsegurarBoton(_btnVerInfRectificatorio, drView.Row["estado_rec"]);
                }
                else
                {
                    _idUsuarioSeleccionado = 0;
                    _btnVerInfPreliminar.Enabled = false;
                    _btnVerInfFinal.Enabled = false;
                    _btnVerInfRectificatorio.Enabled = false;
                }
            }
            catch
            {
                _idUsuarioSeleccionado = 0;
            }
            AsegurarUsuarioSelecciondo();
        }

        private void AsegurarBotonPublicar(DataRowView drView)
        {
            Operacion op = new Operacion();

            if (Sesion.Instancia.RolSIN == "CNDC" && _idUsuarioSeleccionado == 7
                && drView.Row["estado_fin"].ToString() == "3594"
                && op.ExisteRegistro(DOMINIOS_OPERACION.CNDC_PUBLICA_INFORME_FINAL, _fallaSeleccionada.CodFalla, 7) == -1)//TODO
            {
                _btnPublicar.Visible = OraDalF_AU_OpcionMgr.Instancia.TieneOpcion(Sesion.Instancia.UsuarioActual.Login, 66);
            }
            else
            {
                _btnPublicar.Visible = false;
            }
        }

        private void AsegurarBoton(ToolStripButton btn, object p)
        {
            long valor = (long)ObjetoDeNegocio.GetValor<decimal>(p);
            if (valor > 0)
            {
                D_COD_ESTADO_INF estadoInforme = (D_COD_ESTADO_INF)valor;
                btn.Enabled = _idUsuarioSeleccionado == Sesion.Instancia.EmpresaActual.PkCodPersona || estadoInforme == D_COD_ESTADO_INF.ENVIADO;
            }
            else
            {
                btn.Enabled = false;
            }
        }

        private void AsegurarUsuarioSelecciondo()
        {
            if (_idUsuarioSeleccionado == 0)
            {
                _usuarioSeleccionado = null;
            }
            else
            {
                _usuarioSeleccionado = OraDalPersonaMgr.Instancia.GetAgente(_idUsuarioSeleccionado);
            }
            Sesion.Instancia.SetObjetoGlobal("Principal.Persona", _usuarioSeleccionado);
        }

        private void _btnVerInfPreliminar_Click(object sender, EventArgs e)
        {
            _btnVerInfPreliminar.Enabled = false;
            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            CNDCMenu.Instancia.EjecutarOpcion(29, new RptInformeFallaParametroExtra(regFalla.CodFalla, _idUsuarioSeleccionado, PK_D_COD_TIPOINFORME.PRELIMINAR));
            _btnVerInfPreliminar.Enabled = true;
        }

        private void _btnVerInfFinal_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click en final ....................... ver ");
            _btnVerInfFinal.Enabled = false;
            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            CNDCMenu.Instancia.EjecutarOpcion(29, new RptInformeFallaParametroExtra(regFalla.CodFalla, _idUsuarioSeleccionado, PK_D_COD_TIPOINFORME.FINAL));
            _btnVerInfFinal.Enabled = true;
        }

        private void _btnVerInfRectificatorio_Click(object sender, EventArgs e)
        {
            _btnVerInfRectificatorio.Enabled = false;
            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            CNDCMenu.Instancia.EjecutarOpcion(29, new RptInformeFallaParametroExtra(regFalla.CodFalla, _idUsuarioSeleccionado, PK_D_COD_TIPOINFORME.RECTIFICATORIO));
            _btnVerInfRectificatorio.Enabled = true;
        }

        private void _dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Dictionary<string, string> cols = new Dictionary<string, string>();
            cols["ColNotif"] = "d_cod_estado_notificacion";
            cols["ColPrelim"] = "estado_pre";
            cols["ColFinal"] = "estado_fin";
            cols["ColRectif"] = "estado_rec";

            if (cols.ContainsKey(_dgvUsuarios.Columns[e.ColumnIndex].Name))
            {
                try
                {
                    DataRow r = ((DataRowView)_dgvUsuarios.Rows[e.RowIndex].DataBoundItem).Row;
                    object obj = r[cols[_dgvUsuarios.Columns[e.ColumnIndex].Name]];
                    if (obj is DBNull)
                    {
                        return;
                    }

                    if (obj is long)
                    {
                        e.Value = GetImageNotif(obj);
                    }
                    else if (obj is decimal)
                    {
                        e.Value = GetImagemEstadoInforme(obj);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private Bitmap GetImageNotif(object obj)
        {
            Bitmap resultado = null;
            long eNotif = (long)obj;
            D_COD_ESTADO_NOTIFICACION estadoNotif = (D_COD_ESTADO_NOTIFICACION)eNotif;
            switch (estadoNotif)
            {
                case D_COD_ESTADO_NOTIFICACION.REGISTRADO:
                    resultado = global::SISFALLA.Properties.Resources.notifRegistrada1;
                    break;
                case D_COD_ESTADO_NOTIFICACION.ENVIADO:
                    resultado = global::SISFALLA.Properties.Resources.notifEnviada1;
                    break;
                case D_COD_ESTADO_NOTIFICACION.RECIBIDO:
                    resultado = global::SISFALLA.Properties.Resources.notifRecibida;
                    break;
            }
            return resultado;
        }

        private Bitmap GetImagemEstadoInforme(object obj)
        {
            Bitmap resultado = null;
            decimal estadoInf = (decimal)obj;
            if (estadoInf > 0)
            {
                D_COD_ESTADO_INF estadoInforme = (D_COD_ESTADO_INF)estadoInf;
                switch (estadoInforme)
                {
                    case D_COD_ESTADO_INF.EN_ELABORACION:
                        resultado = global::SISFALLA.Properties.Resources.ElaborarInf;
                        break;
                    case D_COD_ESTADO_INF.ELABORADO:
                        resultado = global::SISFALLA.Properties.Resources.InformeListo;
                        break;
                    case D_COD_ESTADO_INF.ENVIADO:
                        resultado = global::SISFALLA.Properties.Resources.InformeEnviado;
                        break;
                    case D_COD_ESTADO_INF.ENVIADO_ERROR:
                        resultado = global::SISFALLA.Properties.Resources.InformeEnviadoError;
                        break;
                }
            }
            else
            {
                resultado = global::SISFALLA.Properties.Resources.InformeBlanco1;
            }
            return resultado;
        }

        private void _dgvFallas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string valor = RegFalla.FormatearCodFalla(e.Value.ToString());
                e.FormattingApplied = true;
                e.Value = valor;
            }
        }

        private void SisFallaPrincipal_Resize(object sender, EventArgs e)
        {
            AjustarPanelPrincipal();
        }

        private void AjustarPanelPrincipal()
        {
            int anchoPrincipal = 0;
            int altoPrincipal = 0;
            string tmpancho = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Principal", "Width", "");
            string tmpalto = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Principal", "height", "");

            if (!int.TryParse(tmpancho, out anchoPrincipal))
            {
                anchoPrincipal = 750;
            }

            if (!int.TryParse(tmpalto, out altoPrincipal))
            {
                altoPrincipal = 550;
            }

            _pnlPrincipal.Width = Math.Min(anchoPrincipal, this.Width);
            _pnlPrincipal.Height = Math.Min(altoPrincipal,
                this.Height);

            int x, y;

            x = (this.Width / 2) - (_pnlPrincipal.Width / 2);
            y = (this.Height / 2) - (_pnlPrincipal.Height / 2);
            _pnlPrincipal.Location = new Point(x, y);
        }

        private void SeleccionarFallaEnGrid(RegFalla fallaTemp)
        {
            for (int i = 0; i < _dgvFallas.Rows.Count; i++)
            {
                DataRow r = ((DataRowView)_dgvFallas.Rows[i].DataBoundItem).Row;
                if (fallaTemp.CodFalla == (int)r[RegFalla.C_PK_COD_FALLA])
                {
                    _dgvFallas.Rows[i].Selected = true;
                    _dgvFallas.BindingContext[_dgvFallas.DataSource].Position = i;
                    if (i < _dgvFallas.FirstDisplayedScrollingRowIndex )                    
                    {
                        _dgvFallas.FirstDisplayedScrollingRowIndex = i;
                    }
                    else if (i >= _dgvFallas.FirstDisplayedScrollingRowIndex + MaxFallasVisibles)
                    {
                        _dgvFallas.FirstDisplayedScrollingRowIndex = i - MaxFallasVisibles + 1;
                    }
                    break;
                }
            }
        }

        private void _dgvFallas_DoubleClick(object sender, EventArgs e)
        {
            if (_fallaSeleccionada != null)
            {
                //CNDCMenu.Instancia.EjecutarOpcion(4, new ParametroExtra());
                ABMRegistroFallaForm abmRegFalla = new ABMRegistroFallaForm();
                abmRegFalla.Parametros = new ParametrosFuncionalidad("TAG=NOTIFICACION.VISUALIZAR");
                abmRegFalla.Ejecutar();
            }
        }

        private void _btnPublicar_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                 InformeFalla infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_fallaSeleccionada.CodFalla, 7, 21);
                 if (infFalla != null)
                 {
                     MostrarPublicacion publi = new MostrarPublicacion();
                     publi.publicarCategoria("INF_FINAL");
                     publi.ShowDialog();
                 }
            }
        }

        private void _btnSincronizar_Click(object sender, EventArgs e)
        {
            CNDC.Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "ActualizarFallas Desde boton actualizar " + DateTime.Now.ToString(), TipoPista.Debug);
            if (SincronizadorCliente.Instancia.PingHost())
            {
                Console.WriteLine("Hiso ping al ping virtual");
                if (SincronizadorCliente.Instancia.SincronizarInformesFalla())
                {
                    ActualizarFallas();
                    Recargar();
                    _dgvFallas.Refresh();
                    Console.WriteLine("Se hiso la actualizacion de fallas");
                }
                CNDC.Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "ActualizarFallas Terminado Desde boton actualizar" + DateTime.Now.ToString(), TipoPista.Debug);
            }
            else
            {
                MessageBox.Show("No hay conexion con la vpn.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void messageNotConectionVpn()
        {
            this.mensajeConexion = "No hay conexion con la vpn.";
            //MessageBox.Show("No hay conexion con la vpn.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        RegFalla _fallaSeleccionadaTemp;
        private void _sincTimer_Tick(object sender, EventArgs e)
        {
            if (Sesion.Instancia.ConfigConexion.TipoBD == CNDC.DAL.TipoBaseDatos.Local)
            {
                //PistaMgr.Instance.Debug("_sincTimer_Tick", "Iniciando Sincronizacion");
                if (!FormInformeFalla.FormularioVisible)
                {
                    _timerSinc.Start();
                    _fallaSeleccionadaTemp = _fallaSeleccionada;
                    _ctrlSincronizacion.Iniciar();
                    _bgWorker.RunWorkerAsync();

                    if (refreshSisFalla)
                    {
                        refreshSisFalla = false;
                        Recargar();
                        _dgvFallas.Refresh();
                    }
                }
                else
                {
                    _timerSinc.Stop();
                    refreshSisFalla = true;
                }

            }
            else
            {
                if (!FormInformeFalla.FormularioVisible)
                {
                    if (refreshSisFalla)
                    {
                        refreshSisFalla = false;
                        CargarFallas1();
                        _dgvFallas.Refresh();
                    }
                }
                else
                {
                    refreshSisFalla = true;
                }
            }
        }
        
        bool _huboCambiosEnSincronizacion = false;
        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (SincronizadorCliente.Instancia.PingHost())
            {
                this.mensajeConexion = string.Empty;
                _huboCambiosEnSincronizacion = CNDC.Sincronizacion.SincronizadorCliente.Instancia.SincronizarDatos();
            }
            else
            {

                messageNotConectionVpn();
            }
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.label1.Text = this.mensajeConexion;
            this.label1.Refresh();
            List<MensajeEmergente> mensajes = new List<MensajeEmergente>();
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                Recargar();
            }
            else if (_huboCambiosEnSincronizacion)
            {
                ActualizarFallas();
                mensajes = MensajeEmergenteMgr.Intancia.GetMensajes();
                Recargar();
                if (_fallaSeleccionadaTemp != null)
                {
                    SeleccionarFallaEnGrid(_fallaSeleccionadaTemp);
                }
            }

            _ctrlSincronizacion.Finalizar(mensajes);
            _timerSinc.Enabled = true;
        }

        private void _cmbVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbVista.SelectedItem != null)
            {
                _proveedorVistaSeleccionado = (IProveedorTablaRegFalla)_cmbVista.SelectedItem;
                _dgvFallas.DataSource = null;
                Recargar();
            }
        }

        private int GetNumFallaComoInt(string numFallaFormateado)
        {
            string strNumFalla, strAnioFalla;
            strNumFalla = string.Empty;
            strAnioFalla = string.Empty;
            int resultado = 0;
            if (numFallaFormateado.IndexOf("-") != -1)
            {
                strNumFalla = numFallaFormateado.Substring(0, numFallaFormateado.IndexOf("-"));
                strAnioFalla = numFallaFormateado.Substring(numFallaFormateado.IndexOf("-") + 1);
                int numFalla, anioFalla;
                numFalla = 0;
                anioFalla = 0;
                if (int.TryParse(strNumFalla, out numFalla) && int.TryParse(strAnioFalla, out anioFalla))
                {
                    resultado = (anioFalla * 10000) + numFalla;
                }
            }
            return resultado;
        }

        private void FiltroNumeroFalla_LostFocus(object sender, EventArgs e)
        {
            int text_filtro = GetNumFallaComoInt(_txtFiltroNumeroFalla.Text);
            bool encontrado = false;
            try
            {
                foreach (DataGridViewRow item in _dgvFallas.Rows)
                {
                    if (text_filtro == (int)item.Cells[0].Value)
                    {
                        item.Selected = true;
                        _dgvFallas.FirstDisplayedScrollingRowIndex = item.Index;
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    string msg = MessageMgr.Instance.GetMessage("NUM_FALLA_NO_REGISTRADO");

                    if (_txtFiltroNumeroFalla.Text.Length != 0)
                    {
                        MessageBox.Show(string.Format(msg, _txtFiltroNumeroFalla.Text));

                        _txtFiltroNumeroFalla.Focus();
                    }
                }
            }
            catch (Exception exx)
            {
            }

            _txtFiltroNumeroFalla.Text = string.Empty;
        }

        private void _dgvUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            PistaMgr.Instance.Debug("SisFallaPrincipal._dgvUsuarios_DataError", e.Exception);
            e.ThrowException = false;
        }

        private void _tbsDescargarInformesDeFalla_Click(object sender, EventArgs e)
        {
            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");

            FormDescargaInfFalla frm = new FormDescargaInfFalla(regFalla.CodFalla, false);
            frm.Show();
        }

        private void _tbsBorrarInformesDeFalla_Click(object sender, EventArgs e)
        {
            RegFalla regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            if (ModeloSisFalla.ModeloMgr.Instancia.RegFallaMgr.isDelete(regFalla.CodFalla))
            {
                CtrlAgentesInvolucrados ctrlAgentesIn = new CtrlAgentesInvolucrados();
                ctrlAgentesIn.VisualizarAgentesInvolucrados(regFalla);
                ResultadoEnvioEmail r = ctrlAgentesIn.EnviarEmailBorrarRegFalla("");
                string msg = string.Empty;
                MessageBoxIcon icono = MessageBoxIcon.None;
                switch (r)
                {
                    case ResultadoEnvioEmail.Enviado:
                        msg = MessageMgr.Instance.GetMessage("NOTIFICACION_ENVIADA_FALLA");
                        deleteRegistroFallaAndRefresh(regFalla);
                        icono = MessageBoxIcon.Information;
                        break;
                    case ResultadoEnvioEmail.NoEnviado:
                        msg = MessageMgr.Instance.GetMessage("NOTIF_NO_ENVIADA");
                        icono = MessageBoxIcon.Error;
                        break;
                    case ResultadoEnvioEmail.EnviadoConError:
                        msg = MessageMgr.Instance.GetMessage("NOTIF_ENVIADA_PARCIAL_FALLA");
                        deleteRegistroFallaAndRefresh(regFalla);
                        icono = MessageBoxIcon.Warning;
                        break;
                    case ResultadoEnvioEmail.EnvioCanceladoPorUs:
                        msg = MessageMgr.Instance.GetMessage("NOTIF_CANCELADA_US");
                        icono = MessageBoxIcon.Warning;
                        break;
                }
                MessageBox.Show(msg, "Envío Notificación", MessageBoxButtons.OK, icono);
                //System.Windows.Forms.DialogResult= System.Windows.Forms.DialogResult.OK;

            }else
            {
                MessageBox.Show("Registro de Falla no se puede eliminar.", "Envío Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteRegistroFallaAndRefresh(RegFalla regFalla)
        {
            ModeloSisFalla.ModeloMgr.Instancia.RegFallaMgr.DeleteRegFallaById(regFalla.CodFalla);
            Recargar();
            _dgvFallas.Refresh();
        }
    }
}
