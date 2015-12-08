using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using SISFALLA.Bbi;

namespace SISFALLA.Informe
{
    public partial class IngresarEditarInterruptor : ABMBaseForm
    {
        public IngresarEditarInterruptor()
        {
            InitializeComponent();
        }

        private void _btnComponente_Click(object sender, EventArgs e)
        {
            SeleccionComponenteDialog s = new SeleccionComponenteDialog();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _txtComponente.Text = s.ComponenteSeleccionado.ToString();
                //_txtComponente.Tag = s.ComponenteSeleccionado.Codigo;//TODO
            }
        }


    }
}
