using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using CNDC.Pistas;
using CNDC.Sincronizacion;
using MenuQuantum;
using QuantumPluginLib;
using System.Configuration;
namespace QuantumUI
{
    public partial class QuantumPrincipal : BaseForm, IFormPrincipal
    {
        private ToolStripLabel _lblHoraLocal;
        private ToolStripLabel _lblHoraCNDC;
        private IPlugin _pluginActual;
        private CtrlModulos _panelModulos;
        private Control _pnlPrincipal = null;
        private Panel _pnlMenu;
        private bool _barraDeEstadoCargada = false;
        public QuantumPrincipal()
        {
            InitializeComponent();
            
            //Reportes.FormReporteBase f = new Reportes.FormReporteBase();
            //f.CargarReporte("rptBlanco", null, false);
            //f.Close();

            _panelModulos = new CtrlModulos();
            _panelModulos.Dock = DockStyle.Right;
       
        }

       
        private void CargarBarraDeEstado()
        {
            
            if (_barraDeEstadoCargada)
            {
                return;
            }
            _barraDeEstadoCargada = true;

            _statusStrip.Dock = System.Windows.Forms.DockStyle.Top;
            _statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;

            ToolStripLabel nombreUsuario = new ToolStripLabel();
            ToolStripLabel rol = new ToolStripLabel();
            nombreUsuario.Text = " Usuario : " + CNDC.BLL.Sesion.Instancia.UsuarioActual.Nombre;
            //CNDC.BLL.Sesion.Instancia.ConfigConexion.IsConnection = false;
            //Console.WriteLine("wwwwwww::: " + CNDC.BLL.Sesion.Instancia.ConfigConexion.IsConnection);
            rol.Text = " Rol: ";
            ToolStripComboBox tcmp = new ToolStripComboBox();

            tcmp.ComboBox.DataSource = CNDC.BLL.Sesion.Instancia.RolesActuales;
            _statusStrip.Items.Add(nombreUsuario);
            _statusStrip.Items.Add(new ToolStripSeparator());
            _statusStrip.Items.Add(rol);
            _statusStrip.Items.Add(tcmp);
            _statusStrip.Items.Add(new ToolStripSeparator());
            //_statusStrip.Items.Add(new ToolStripLabel(" Equipo : " + CNDC.BLL.Sesion.Instancia.GetObjetoGlobal<string>("host")));
            //_statusStrip.Items.Add(new ToolStripSeparator());
            _statusStrip.Items.Add(new ToolStripLabel(" Empresa : " + CNDC.BLL.Sesion.Instancia.EmpresaActual.Nombre));
            _statusStrip.Items.Add(new ToolStripSeparator());

            _lblHoraLocal = new ToolStripLabel();
            _statusStrip.Items.Add(_lblHoraLocal);
            _statusStrip.Items.Add(new ToolStripSeparator());
            _lblHoraCNDC = new ToolStripLabel();
            _lblHoraCNDC.Font = new System.Drawing.Font(_lblHoraCNDC.Font, FontStyle.Bold);
            _statusStrip.Items.Add(_lblHoraCNDC);

            SetLblHoraCNDC();
            
           
        }

        private void SetLblHoraCNDC()
        {
            if (Sesion.Instancia.ConfigConexion.TipoBD == CNDC.DAL.TipoBaseDatos.Centralizada)
            {
                DateTime? fechaHoraServ = Sesion.Instancia.Conexion.GetFechaHora();
                if (fechaHoraServ == null)
                {
                    _lblHoraCNDC.Text = "Sin Conexión a BD";
                    _lblHoraCNDC.ForeColor = Color.Red;
                }
                else
                {
                    _lblHoraCNDC.Text = " CNDC: " + fechaHoraServ.Value.ToString("dd/MM/yyyy HH:mm");
                    Sesion.Instancia.FechaHoraServidor = fechaHoraServ;
                }
            }
            else
            {
                bool offline = CNDC.BLL.Sesion.Instancia.ConfigConexion.IsConnection;
                if (offline)
                {
                    if (SincronizadorCliente.Instancia.PingHost())
                    {
                        Sesion.Instancia.FechaHoraServidor = CNDC.Sincronizacion.SincronizadorCliente.Instancia.MgrServidor.GetFechaHoraServ();
                    }
                    
                }
                if (Sesion.Instancia.FechaHoraServidor == null)
                {
                    _lblHoraCNDC.Text = MessageMgr.Instance.GetMessage("SIN_CONEX_CNDC");
                    _timerHoraCNDC.Enabled = false;
                }
                else
                {
                    _lblHoraCNDC.Text = " CNDC: " + Sesion.Instancia.FechaHoraServidor.Value.ToString("dd/MM/yyyy HH:mm");
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
          //  GetDllVersion();
        }

        private void QuantumPrincipal_Load(object sender, EventArgs e)
        {           
            FormIngreso loginF = new FormIngreso();
            if (loginF.ShowDialog() == DialogResult.OK)
            {
                CargarPlugin();
                PluginMgr.Instancia.ModuloCambiado += new EventHandler(Instancia_ModuloCambiado);
            }
            else
            {
                Application.Exit();
            }


        }


        private Dictionary<string, Version> GetDllVersion()
        {
            
      
            string dirApp = Application.StartupPath;

            Dictionary<string, Version> versiones = new Dictionary<string, Version>();
            DirectoryInfo oDirectorio = new DirectoryInfo(dirApp);

            foreach (FileInfo file in oDirectorio.GetFiles("*.dll"))
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(file.FullName);
                    versiones.Add(asm.GetName().Name, asm.GetName().Version);
                }
                catch (Exception e)
                {
                    PistaMgr.Instance.Error("SisFalla", e);
                    
                  
                }
                
            }
         
            return versiones;
        }

        void Instancia_ModuloCambiado(object sender, EventArgs e)
        {
            CargarPlugin();
        }

        private void CargarPlugin()
        {
            if (_pluginActual != null)
            {
                _pluginActual.CerrarPlugin();
            }
            _pluginActual = PluginMgr.Instancia.GetPlugin();
            if (_pluginActual == null)
            {
                MessageBox.Show("No se ha definido ningun Plugin.");
                Application.Exit();
            }
            else
            {
                Text = _pluginActual.GetTitulo();
                AjustarPanelPrincipal();
                _pluginActual.AbrirSplash();
                AdministradorAyuda.Instance.ProveedorAyuda = new OraDalProveedorAyuda();
                _pluginActual.CargarDatosDeInicio();
                
                CargarMenu();
                _timerHora.Enabled = true;
                _timerHoraCNDC.Enabled = true;
                CargarBarraDeEstado();
                _pluginActual.CerrarSplash();
            }
        }

        private void CargarMenu()
        {
            PistaMgr.Instance.EscribirLog("CargarMenu", String.Format("{0} - Punto 1 ", DateTime.Now.ToString(" H:mm:ss ")), TipoPista.Debug);
            if (_pnlMenu != null)
            {
                this.Controls.Remove(_pnlMenu);
            }
            _pnlMenu = new Panel();
            _pnlMenu.Dock = DockStyle.Top;

            CNDCMenu menu = CNDCMenu.CrearInstancia();
            this.MainMenuStrip = menu;
            this.Controls.Add(_pnlMenu);
            _pnlMenu.Controls.Add(menu);
            _pnlMenu.Controls.Add(_panelModulos);
            _pnlMenu.Height = menu.Height;
            menu.Padre = this;
            PistaMgr.Instance.EscribirLog("CargarMenu", String.Format("{0} - Punto 2 ", DateTime.Now.ToString(" H:mm:ss ")), TipoPista.Debug);
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
                MessageBox.Show("Se ha perdido la conexión con la Base de Datos. Se procedera a Cerrar la aplicación. Consulte con el Administrador.");
                Application.Exit();
            }
        }

        void Instancia_Sincronizando(object sender, SincEventArgs e)
        {
        }

        public void Recargar()
        {
            _pluginActual.RecargarControlPrincipal();
        }

        public bool Cerrar()
        {
            return _pluginActual.CerrarPlugin();
        }

        private void SisFallaPrincipal_Resize(object sender, EventArgs e)
        {
            //AjustarPanelPrincipal();
        }

        private void AjustarPanelPrincipal()
        {
            if (_pluginActual != null)
            {
                if (_pnlPrincipal != null)
                {
                    this.Controls.Remove(_pnlPrincipal);
                    _pnlPrincipal.Dispose();
                }
                _pnlPrincipal = _pluginActual.GetPanelPrincipal();
                _pnlPrincipal.Top = 25;                
                _pnlPrincipal.Dock = DockStyle.Fill;
                this.Controls.Add(_pnlPrincipal);
                this.Controls.Remove(cndcPanelControl2);
                this.Controls.Add(cndcPanelControl2);
            }
        }

        private void _timerHora_Tick(object sender, EventArgs e)
        {
            _lblHoraLocal.Text = " Hora local: " + DateTime.Now.ToString("HH:mm");
        }

        private void QuantumPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_pluginActual != null)
            {
                _pluginActual.CerrarPlugin();
            }
        }

        private void _timerHoraCNDC_Tick(object sender, EventArgs e)
        {
            SetLblHoraCNDC();
        }

    }
}
