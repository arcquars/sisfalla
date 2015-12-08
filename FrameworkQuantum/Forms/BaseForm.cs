using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Controles;
using CNDC.BLL;
using BLL;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using CNDC.Pistas;

/*
 * Cambio: 
 * JJLA :01/02/2012: comentada línea 39 ; para permitir el resize de la ventana.
 */
namespace CNDC.BaseForms
{
    public partial class BaseForm : Form
    {
        const int MF_BYPOSITION = 0x400;
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                CargarAyuda(this.Controls);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("Quantum", ex);
            }
        }
        private bool _closeButtonDisable = false;
        [Category("Properties")]
        [Description("BaseFomrproperties")]
        public bool CloseButtonDisable
        {
            get { return _closeButtonDisable; }
            set
            {
                _closeButtonDisable = value;
                if (value == true)
                {
                    IntPtr hMenu = GetSystemMenu(this.Handle, false);
                    int menuItemCount = GetMenuItemCount(hMenu);
                    RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
                }
            }
        }

        public void CargarAyuda(Control.ControlCollection controlCollection)
        {
            
      
            IElementoBD c = null;
            foreach (Control ctrl in controlCollection)
            {
                if (ctrl is IElementoBD)
                {
                    c = (IElementoBD)ctrl;
                    if (!string.IsNullOrEmpty(c.TablaCampoBD))
                    {
                        _helpProvider.SetHelpString(ctrl, AdministradorAyuda.Instance.ObtenerPorNombreCampo(c.TablaCampoBD));
                        _helpProvider.SetShowHelp(ctrl, true);
                        _toolTip.SetToolTip(ctrl, AdministradorAyuda.Instance.ObtenerPorNombreCampo(c.TablaCampoBD));
                        ctrl.Enter += new EventHandler(ctrl_Enter);
                        ctrl.Leave += new EventHandler(ctrl_Leave);
                        ModeloQuantum.AdministradorControles.Instance.DefinirConfiguracionControl(this.Name, ctrl, c.TablaCampoBD);
                    }
                }

                if (ctrl is CNDCGridView)
                {
                    (ctrl as CNDCGridView).AplicarEstilo();
                }

                if (ctrl is IControlCNDC)
                {
                    IControlCNDC iControl = ctrl as IControlCNDC;
                    if (iControl.EnterComoTab)
                    {
                        ctrl.KeyUp += new KeyEventHandler(ctrl_KeyUp);
                    }
                }

                if (ctrl is CNDCLabel)
                {
                    CNDCLabel lbl = (ctrl as CNDCLabel);
                    CargarFont(lbl.Font);
                    lbl.Font = _fuenteQuantum;
                }

                if (ctrl is TabControl)
                {
                    TabControl tabControl= ctrl as TabControl;
                    foreach (TabPage p in tabControl.TabPages)
                    {
                        CargarAyuda(p.Controls);
                    }
                }
                else if (ctrl.Controls.Count > 0)
                {
                    CargarAyuda(ctrl.Controls);
                }
            }
             
      
        }

        Font _fuenteQuantum = null;
        PrivateFontCollection _coleccionFonts;
        FontFamily _familiaFont;

        private void CargarFont(Font f)
        {
            if (_coleccionFonts == null)
            {
                _familiaFont = aLoadFontFamily("ARIALN.TTF", out _coleccionFonts);
            }
            _fuenteQuantum = new Font(_familiaFont, 9.75f, f.Style);
        }

        public static FontFamily aLoadFontFamily(string fileName, out PrivateFontCollection fontCollection)
        {
            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(fileName);
            return fontCollection.Families[0];
        }

        void ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Control ctrl = sender as Control;
                this.SelectNextControl(ctrl, true, true, true, true);
            }
        }

        //private Form GetParentForm(Control c)
        //{
        //    while (!(c.Parent is Form))
        //    {
        //        c = c.Parent;
        //    }
        //    return (Form)c.Parent;
        //}

        private void ctrl_Leave(object sender, EventArgs e)
        {
            SetAyudaEnLinea(string.Empty);
        }

        private void ctrl_Enter(object sender, EventArgs e)
        {
            if (sender is IElementoBD)
            {
                IElementoBD c = (IElementoBD)sender;
                string extra = string.Empty;
                if (sender is TextBox && (sender as TextBox).ReadOnly)
                {
                    extra = " (Sólo Lectura)";
                }
                SetAyudaEnLinea(AdministradorAyuda.Instance.ObtenerPorNombreCampo(c.TablaCampoBD) + extra);
            }
        }

        protected virtual void SetAyudaEnLinea(string ayuda)
        {
            
        }

        public static void VisualizarColumnas(DataGridView grid, Dictionary<string, int> columnas)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Visible = false;
            }

            int indice = 0;
            foreach (var item in columnas)
            {
                grid.Columns[item.Key].Visible = true;
                grid.Columns[item.Key].DisplayIndex = indice++;
                grid.Columns[item.Key].Width = item.Value;
            }
        }

        public static void VisualizarColumnas(DataGridView grid, List<EstiloColumna> columnas)
        {
            VisualizarColumnas(grid, columnas, true);
        }

        protected void formatDatagrids(DataGridView dgv)
        {
            FormatDatagrids(dgv);
        }

        public static void FormatDatagrids(DataGridView dgv)
        {
            string fontName = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Config", "fontfamily", "");
            string fontSizes = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Config", "fontsize", "");
            string borderStyle = CNDC.Config.Config.Intance.Read("Configuracion/Grids/Grid", "Config", "borderStyle", "");
            try
            {
                int fontSize = 0;
                if (!int.TryParse(fontSizes, out fontSize))
                { fontSize = 10; }

                Font f = new Font(fontName, fontSize);
                dgv.Font = f;
            }
            catch (Exception e) { }
            try
            {
                switch (borderStyle.ToUpper())
                {
                    case "FIXED3D":
                        dgv.BorderStyle = BorderStyle.Fixed3D;
                        break;
                    case "FIXEDSINGLE":
                        dgv.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "NONE":
                        dgv.BorderStyle = BorderStyle.None;
                        break;

                }
                //dgv.GridColor = Color.BlueViolet;
                //dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            }
            catch (Exception e) { }
        }

        public static void SeleccionarFila(DataGridView grid, string campo, object valor)
        {

        }

        public static bool EstaSeguro()
        { return EstaSeguro("Esta seguro ?"); }

        public static bool EstaSeguro(string msg)
        {
            bool resultado = true;
            DialogResult r = MessageBox.Show(msg, "Sistema Quantum - Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            resultado = r == DialogResult.Yes;
            return resultado;
        }

        public static void VisualizarColumnas(DataGridView grid, List<EstiloColumna> columnas, bool ultimaColRellena)
        {
            CNDCGridView.VisualizarColumnas(grid, columnas, ultimaColRellena);
        }
    }
}
