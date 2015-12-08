using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;

namespace SISFALLA.Informe
{
    public partial class DiferenciaFallas : ABMBaseForm
    {
        public DiferenciaFallas()
        {
            InitializeComponent();
        }

        private void _btnComponente_Click(object sender, EventArgs e)
        {
            SeleccionComponenteDialog s = new SeleccionComponenteDialog();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              
            }
        }


    }
}
