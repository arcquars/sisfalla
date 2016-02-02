using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using CNDC.BLL;
using CNDC.Dominios;
using CNDC.Pistas;
using System.IO;
using System.Data;

namespace MenuQuantum
{
    public partial class CNDCMenu : MenuStrip
    {
        Dictionary<long, CNDCMenuItemOracle> _dicItems = new Dictionary<long, CNDCMenuItemOracle>();
        Dictionary<string, Assembly> _dicEnsamblados = new Dictionary<string, Assembly>();
        private IFormPrincipal _padre;
        public IFormPrincipal Padre
        {
            get  {return _padre;}
            set { _padre = value; }
        }

        #region Singleton
        private static CNDCMenu _instancia;
        static CNDCMenu()
        {
            _instancia = new CNDCMenu();
        }

        public static CNDCMenu Instancia
        { get { return _instancia; } }

        public static CNDCMenu CrearInstancia()
        {
            _instancia = new CNDCMenu();
            return _instancia;
        }

        #endregion Singleton

        private CNDCMenu()
        {
            InitializeComponent();
            LoadComponets();
        }

        public void EjecutarOpcion(long numOpcion, ParametroExtra p)
        {
            if (_dicItems.ContainsKey(numOpcion))
            {
                formClick(_dicItems[numOpcion], p);
            }
        }

        private void formClick(object sender, System.EventArgs e)
        {
            CNDCMenuItemOracle mi = (CNDCMenuItemOracle)sender;
            if (mi.DropDownItems.Count > 0)
            {
                return;
            }
        
            if (mi.Ensamblado.Trim() == string.Empty || mi.Clase.Trim() == string.Empty)
            {
                MessageBox.Show("Opcion no implementada");
            }
            else
            {
                try
                {
                    Assembly asm = null;
                    if (_dicEnsamblados.ContainsKey(mi.Ensamblado))
                    {
                        asm = _dicEnsamblados[mi.Ensamblado];
                    }
                    else
                    {
                        PistaMgr.Instance.Debug("MenuQuantum", "Cargando assembly " + mi.Ensamblado);
                        asm = Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, mi.Ensamblado));
                        _dicEnsamblados[mi.Ensamblado] = asm;
                    }

                    PistaMgr.Instance.Debug("MenuQuantum", "Instanciando Clase " + mi.Clase);
                    IFuncionalidad form = (IFuncionalidad)asm.CreateInstance(mi.Clase);
                    form.Parametros = new ParametrosFuncionalidad(mi.Parametro);
                    if (e is ParametroExtra)
                    {
                        form.Parametros.ParametroExtra = (ParametroExtra)e;
                        
                    }
                    
                    PistaMgr.Instance.Debug("MenuQuantum", "Ejecutando Funcionalidad " + mi.Clase);
                    form.Ejecutar();
                    PistaMgr.Instance.Debug("MenuQuantum", "Ejecucion Funcionalidad [" + mi.Clase + "] Finalizada");
                    if (_padre != null && !(e is ParametroExtra))
                    {
                        _padre.Recargar();
                    }
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("MenuQuantum", ex);
                    PistaMgr.Instance.Debug("MenuQuantum", ex);
                }
            }
        }

        private Font GetFontBase()
        {
            string fontName = CNDC.Config.Config.Intance.Read("Configuracion/Visualizacion/fonts", "general", "fontfamily", "");
            string fontSizes = CNDC.Config.Config.Intance.Read("Configuracion/Visualizacion/fonts", "general", "fontsize", "");
            System.Drawing.Font font = null;
            try
            {
                int fontSize = 0;
                if (!int.TryParse(fontSizes, out fontSize))
                {
                    fontSize = 10;
                }

                font = new System.Drawing.Font(fontName, fontSize);
            }
            catch (Exception e)
            { font = new System.Drawing.Font("Arial", 10); }
            return font;
        }

        private void CrearMenus(DataTable odr)
        {
            decimal NumOpcion = 0;
            string Descripcion = string.Empty;
            decimal OpcionMadre = 0;
            string ensamblado = string.Empty;
            string clase = string.Empty;
            string parametro = string.Empty;
            decimal icon = 0;
            string param = string.Empty;
            long d_tipo_opcion_menu = 0;
            System.Drawing.Font font = GetFontBase();
            CNDCMenuItemOracle item = null;
            foreach (DataRow r in odr.Rows)
            {
                NumOpcion = ObjetoDeNegocio.GetValor<long>(r["num_opcion"]);
                OpcionMadre = ObjetoDeNegocio.GetValor<long>(r["num_opcion_madre"]);
                Descripcion = ObjetoDeNegocio.GetValor<string>(r["descripcion_opcion"]);
                ensamblado = ObjetoDeNegocio.GetValor<string>(r["ensamblado"]);
                clase = ObjetoDeNegocio.GetValor<string>(r["clase"]);
                parametro = ObjetoDeNegocio.GetValor<string>(r["parametro"]);
                icon = ObjetoDeNegocio.GetValor<long>(r["icon"]);
                d_tipo_opcion_menu = ObjetoDeNegocio.GetValor<long>(r["d_tipo_opcion_menu"]);

                item = new CNDCMenuItemOracle(Descripcion, ensamblado, clase, parametro, icon, new EventHandler(formClick), font, false);
                _dicItems[(long)NumOpcion] = item;
                if ((D_TIPO_OPCION_MENU)d_tipo_opcion_menu == D_TIPO_OPCION_MENU.OPCION_INTERNA)
                {
                    
                }
                else if (OpcionMadre == 0)
                {
                    this.Items.Add(item);
                }
                else
                {
                    _dicItems[(long)OpcionMadre].DropDownItems.Add(item);
                }
            }

            Items.Add(new CNDCMenuItemOracle("Salir", "", "", "", 0, new EventHandler(salirClick), font, true));
        }

        private void salirClick(object sender, EventArgs e)
        {
            if (_padre != null && _padre.Cerrar())
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("No puede cerrarse la aplicación debido a que hay datos sin guardar.");
            }
        }

        private void LoadComponets()
        {
            try
            {
                DataTable tablaOpciones = OraDalF_AU_OpcionMgr.Instancia.GetTablaOpcionesPorUsuarioModulo(Sesion.Instancia.UsuarioActual, Sesion.Instancia.ModuloActual);
                CrearMenus(tablaOpciones);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("MenuQuantum.CNDCMenu", ex);
            }
            finally
            {
            }
        }

        public string GetParametro(long numOpcion)
        {
            string resultado = string.Empty;
            string sql = @"SELECT
            F_AU_OPCIONES.NUM_OPCION AS NUM_OPCION,
            F_AU_OPCIONES.PARAMETRO AS PARAMETRO
            FROM
            F_AU_OPCIONES
            WHERE
            F_AU_OPCIONES.NUM_OPCION = :NUM_OPCION";
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("NUM_OPCION", numOpcion.ToString());
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = tabla.Rows[0]["PARAMETRO"].ToString();
            }
            return resultado;
        }
    }
}
