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

namespace SISFALLA
{
    public partial class SisFallaPrincipal : UserControl, IFormPrincipal
    {
        private RegFalla _fallaSeleccionada = null;
        private Persona _usuarioSeleccionado = null;
        private DataRow _rowFallaSeleccionada = null;
        private DataView _dvwUsuarios;
        private long _idUsuarioSeleccionado = -1;
        private Size _tamanioGrillaPrincial;
        private IProveedorTablaRegFalla _proveedorVistaSeleccionado;
        private SplashQuantum _splash;
        
        public SisFallaPrincipal()
        {
            InitializeComponent();
            _dgvFallas.MultiSelect = false;
            _txtFiltroNumeroFalla.LostFocus +=new EventHandler(FiltroNumeroFalla_LostFocus);
            _txtFiltroNumeroFalla.KeyPress += new KeyPressEventHandler(FiltroNumeroFalla_KeyPress);
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
            IProveedorTablaRegFalla todos = new ProveedorPorEstado("Todos", null);
            IProveedorTablaRegFalla enElab = new ProveedorPorEstado("En Elaboración", D_COD_ESTADO_INF.EN_ELABORACION);
            IProveedorTablaRegFalla enRevision = new ProveedorPorEstado("En Revisión", D_COD_ESTADO_INF.ELABORADO);
            IProveedorTablaRegFalla enEnviados = new ProveedorPorEstado("Enviados", D_COD_ESTADO_INF.ENVIADO);
            _cmbVista.Items.Add(todos);
            _cmbVista.Items.Add(enElab);
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _cmbVista.Items.Add(enRevision);
            }
            _cmbVista.Items.Add(enEnviados);
            _cmbVista.Items.Add(new ProveedorPorNotif());
            _cmbVista.SelectedIndex = 0;
            _proveedorVistaSeleccionado = todos;
        }

        public void CargarDatosInicio()
        {
            int anchoPrincipal = 0;
            int altoPrincipal = 0;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            string tmpancho = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Principal", "height", "");
            string tmpalto = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Principal", "Width", "");

            if (!int.TryParse(tmpancho, out anchoPrincipal))
            {
                anchoPrincipal = 150;
            }

            if (!int.TryParse(tmpalto, out altoPrincipal))
            {
                altoPrincipal = 150;
            }
            _tamanioGrillaPrincial = new Size(anchoPrincipal, altoPrincipal);

            Sesion.Instancia.Conexion.ConexionPerdida += new EventHandler(Conexion_ConexionPerdida);
            Application.DoEvents();
            Inicializador.Inicializar();
            SincronizadorCliente.Instancia.Sincronizando += new EventHandler<SincEventArgs>(Instancia_Sincronizando);
            if (SincronizadorCliente.Instancia.SincronizarDatos())
            {
                List<MensajeEmergente> mensajes = new List<MensajeEmergente>();
                mensajes = MensajeEmergenteMgr.Intancia.GetMensajes();
                _ctrlSincronizacion.Finalizar(mensajes);
            }
            AsegurarCmbVista();
            _timerSinc.Enabled = true;
            _pnlPrincipal.Visible = true;
            AjustarPanelPrincipal();
            ConfiguraEmail();
        }

        public void AbrirSplash()
        {
            _splash = new SplashQuantum();
            _splash.Show();
        }

        public void CerrarSplash()
        {
            _splash.Close();
            _splash = null;
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

        private void ConfiguraEmail()
        {
            long cod = Sesion.Instancia.EmpresaActual.PkCodPersona;
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

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        void Instancia_Sincronizando(object sender, SincEventArgs e)
        {
            if (_splash != null)
            {
                _splash.SetEstadoSincronizacion(e.Actual, e.Total);
            }
        }

        public void Recargar()
        {
            RegFalla fallaTemp = _fallaSeleccionada;
            long usuarioTmp = _idUsuarioSeleccionado;

            CargarFallas();
            BaseForm.formatDatagrids(_dgvFallas);
            BaseForm.formatDatagrids(_dgvUsuarios);

            if (fallaTemp != null)
            {
                SeleccionarFallaEnGrid(fallaTemp);
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
                BaseForm.VisualizarColumnas(_dgvUsuarios, ColumnStyleManger.GetEstilos(this.Name, _dgvUsuarios.Name));
                _dvwUsuarios.RowFilter = " PK_COD_FALLA = 0";

                _dgvFallas.DataSource = _proveedorVistaSeleccionado.GetTablaRegFalla();
                BaseForm.VisualizarColumnas(_dgvFallas, ColumnStyleManger.GetEstilos(this.Name, _dgvFallas.Name));
                _dgvFallas.Sort(_dgvFallas.Columns[RegFalla.C_PK_COD_FALLA], ListSortDirection.Descending);

                if (_dgvFallas.Rows.Count > 0)
                {
                    _dgvFallas.Rows[0].Selected = true;
                }
            }
        }

        private void _dgvFallas_SelectionChanged(object sender, EventArgs e)
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
            if (_dgvUsuarios.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvUsuarios.SelectedRows[0].DataBoundItem;
                _idUsuarioSeleccionado = (long)drView.Row["pk_cod_persona"];
                if (Sesion.Instancia.RolSIN == "CNDC" && _idUsuarioSeleccionado == 7 && drView.Row["estado_fin"].ToString() == "3594")//TODO
                {
                    _btnPublicar.Visible = true;
                }
                else
                {
                    _btnPublicar.Visible = false;
                }
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
            AsegurarUsuarioSelecciondo();
        }

        private void AsegurarBoton(ToolStripButton btn, object p)
        {
            long valor = (long)(decimal)p;
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
            //DataRowView drView = (DataRowView)_dgvUsuarios.SelectedRows[0].DataBoundItem;
            RegFalla _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
            p.informeDesplegado("", "", 29, _regFalla.CodFalla.ToString(), _regFalla.CodFalla.ToString(), ((int)PK_D_COD_TIPOINFORME.PRELIMINAR).ToString(), _idUsuarioSeleccionado.ToString());
            p.Refresh();
            p.Show();
            _btnVerInfPreliminar.Enabled = true;
        }

        private void _btnVerInfFinal_Click(object sender, EventArgs e)
        {
            _btnVerInfFinal.Enabled = false;
            RegFalla _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
            p.informeDesplegado("", "", 29, _regFalla.CodFalla.ToString(), _regFalla.CodFalla.ToString(), ((int)PK_D_COD_TIPOINFORME.FINAL).ToString(), _idUsuarioSeleccionado.ToString());
            p.Refresh();
            p.Show();
            _btnVerInfFinal.Enabled = true;
        }

        private void _btnVerInfRectificatorio_Click(object sender, EventArgs e)
        {
            _btnVerInfRectificatorio.Enabled = false;
            RegFalla _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
            p.informeDesplegado("", "", 29, _regFalla.CodFalla.ToString(), _regFalla.CodFalla.ToString(), ((int)PK_D_COD_TIPOINFORME.RECTIFICATORIO).ToString(), _idUsuarioSeleccionado.ToString());
            p.Refresh();
            p.Show();
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
            decimal l = (decimal)obj;
            if (l > 0)
            {
                D_COD_ESTADO_INF estado = (D_COD_ESTADO_INF)l;
                switch (estado)
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
            Size tamanoPanel = new Size(this.Width, this.Height);
            int x, y, z, w;
            x = 0;
            y = 0;
            if (_pnlPrincipal.Width < this.Width)
            {
                x = (this.Width / 2) - (_tamanioGrillaPrincial.Width / 2);
                z = _tamanioGrillaPrincial.Width;
            }
            else
            {
                z = this.Width;
            }

            if (_pnlPrincipal.Height < this.Height)
            {
                y = (this.Height / 2) - (_tamanioGrillaPrincial.Height / 2);
                w = _tamanioGrillaPrincial.Height;
            }
            else
            {
                w = this.Height;
            }

            _pnlPrincipal.Location = new Point(x, y);
            _pnlPrincipal.Size = new Size(z, w);
        }

        private void SeleccionarFallaEnGrid(RegFalla fallaTemp)
        {
            for (int i = 0; i < _dgvFallas.Rows.Count; i++)
            {
                DataRow r = ((DataRowView)_dgvFallas.Rows[i].DataBoundItem).Row;
                if (fallaTemp.CodFalla == (int)r[RegFalla.C_PK_COD_FALLA])
                {
                    _dgvFallas.Rows[i].Selected = true;
                    _dgvFallas.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void _dgvFallas_DoubleClick(object sender, EventArgs e)
        {
            if (_fallaSeleccionada != null)
            {
                ABMRegistroFallaForm abmRegFalla = new ABMRegistroFallaForm();
                abmRegFalla.Parametros = new Dictionary<string, string>();
                abmRegFalla.Parametros["TAG"] = "NOTIFICACION.VISUALIZAR";
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

        RegFalla _fallaSeleccionadaTemp;
        private void _sincTimer_Tick(object sender, EventArgs e)
        {
            _timerSinc.Enabled = false;
            _fallaSeleccionadaTemp = _fallaSeleccionada;
            _ctrlSincronizacion.Iniciar();
            _bgWorker.RunWorkerAsync();
        }

        bool _huboCambiosEnSincronizacion = false;
        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _huboCambiosEnSincronizacion = CNDC.Sincronizacion.SincronizadorCliente.Instancia.SincronizarDatos();
        }

        private void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<MensajeEmergente> mensajes = new List<MensajeEmergente>();
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                Recargar();
            }
            else if (_huboCambiosEnSincronizacion)
            {
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

        private void _pnlNotificaciones_Click(object sender, EventArgs e)
        {

        }

        private void _cmbVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbVista.SelectedItem != null)
            {
                _proveedorVistaSeleccionado = (IProveedorTablaRegFalla)_cmbVista.SelectedItem;
                Recargar();
            }
        }

        private int FormatoNumeroFalla(string codigo)
        {
            string num, anno;
            num = string.Empty;
            anno = string.Empty;
            int rtn = 0;
            if (codigo.IndexOf("-") != -1)
            {
                num = codigo.Substring(0, codigo.IndexOf("-"));
                anno = codigo.Substring(codigo.IndexOf("-") + 1);
                int nnum, nanno;
                nnum = 0;
                nanno = 0;
                if (int.TryParse(num, out nnum) && int.TryParse(anno, out nanno))
                {
                    rtn = (nanno * 10000) + nnum;
                }
            }
            return rtn;
        }

        private void FiltroNumeroFalla_LostFocus(object sender, EventArgs e)
        {
            int text_filtro = FormatoNumeroFalla(_txtFiltroNumeroFalla.Text);
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
                    MessageBox.Show(string.Format(msg, _txtFiltroNumeroFalla.Text));
                    _txtFiltroNumeroFalla.Focus();
                }
            }
            catch (Exception exx)
            {
            }

            _txtFiltroNumeroFalla.Text = string.Empty;
        }

        public void CerrarSisFalla()
        {
            if (Sesion.Instancia.SesionIniciada && Sesion.Instancia.ConfigConexion.TipoBD != CNDC.DAL.TipoBaseDatos.Centralizada)
            {
                WcfServicioMgr.Instancia.CerrarSesion(Sesion.Instancia.TokenSession);
            }
        }
    }
}
