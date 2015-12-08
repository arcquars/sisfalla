using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemandasUI
{
    public partial class CtrlPrincipal : UserControl
    {
        public CtrlPrincipal()
        {
            InitializeComponent();
            ctrlMenuArbol1.CargarMenu();
        }

        private void cndcButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Demandas");
        }

        private void _btnAsignarTipoProy_Click(object sender, EventArgs e)
        {
        }
    }
}
