using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using OraDalProyectos;
using ModeloProyectos;
using OraDalProyectos;

namespace Proyectos
{
    public partial class CtrlPrincipal : UserControl
    {
        public CtrlPrincipal()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ctrlPrincipalTop1.CtrlIzq = ctrlPrincipalIzquierda1;
            
        }

        private void ctrlPrincipalIzquierda1_TipoProyectoSeleccionado(object sender, TipoProySelecEventArgs e)
        {
            ctrlPrincipalTop1.FiltrarPorTipoProy(e.TipoProyectoSeleccionado, e.TipoProyectoPadreSeleccionado);
        }

        public bool Editando()
        {
            return !ctrlPrincipalIzquierda1.Enabled;
        }
    }
}
