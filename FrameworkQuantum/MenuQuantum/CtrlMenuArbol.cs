using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CNDC.BLL;
using CNDC.Dominios;
using CNDC.Pistas;
using Oracle.DataAccess.Client;

namespace MenuQuantum
{
    public partial class CtrlMenuArbol : UserControl
    {
        Dictionary<long, NodoMenuPrincipal> _dicItems = new Dictionary<long, NodoMenuPrincipal>();
        Dictionary<string, Assembly> _dicEnsamblados = new Dictionary<string, Assembly>();
        private IFormPrincipal _padre;
        public IFormPrincipal Padre
        {
            get  {return _padre;}
            set { _padre = value; }
        }

        #region Singleton
        private static CtrlMenuArbol _instancia;
        static CtrlMenuArbol()
        {
            _instancia = new CtrlMenuArbol();
        }

        public static CtrlMenuArbol Instancia
        { get { return _instancia; } }

        public static CtrlMenuArbol CrearInstancia()
        {
            _instancia = new CtrlMenuArbol();
            return _instancia;
        }

        #endregion Singleton

        public CtrlMenuArbol()
        {
            InitializeComponent();
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

        private void CrearMenu(DataTable odr)
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
            NodoMenuPrincipal item = null;
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

                item = new NodoMenuPrincipal(Descripcion, ensamblado, clase, parametro, icon, new EventHandler(formClick), font, false);
                _dicItems[(long)NumOpcion] = item;
                if ((D_TIPO_OPCION_MENU)d_tipo_opcion_menu == D_TIPO_OPCION_MENU.OPCION_INTERNA)
                {
                    
                }
                else if (OpcionMadre == 0)
                {
                    _tvwMenu.Nodes.Add(item);
                }
                else
                {
                    _dicItems[(long)OpcionMadre].Nodes.Add(item);
                }
            }
        }

        private void salirClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CargarMenu()
        {
            try
            {
                DataTable tablaOpciones = OraDalF_AU_OpcionMgr.Instancia.GetTablaOpcionesPorUsuarioModulo(Sesion.Instancia.UsuarioActual, Sesion.Instancia.ModuloActual);
                CrearMenu(tablaOpciones);
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

        private void _tvwMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NodoMenuPrincipal mi = (NodoMenuPrincipal)e.Node;
            if (mi.Nodes.Count > 0)
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

                    PistaMgr.Instance.Debug("MenuQuantum", "Ejecutando Funcionalidad " + mi.Clase);
                    form.Ejecutar();
                    PistaMgr.Instance.Debug("MenuQuantum", "Ejecucion Funcionalidad [" + mi.Clase + "] Finalizada");
                    if (_padre != null)
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
    }
}
