using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;

namespace SISFALLA.Informe
{
    public partial class IngresarEditarComponenteCompro : ABMBaseForm
    {
        Componente _componenteComprometido;
        public IngresarEditarComponenteCompro()
        {
            InitializeComponent();
        }

        private void _btnComponente_Click(object sender, EventArgs e)
        {
            SeleccionComponenteDialog s = new SeleccionComponenteDialog();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _componenteComprometido = s.ComponenteSeleccionado;
                _txtComponente.Text = _componenteComprometido.ToString();
                _txtComponente.Tag = _componenteComprometido.PkCodComponente;
            }
        }


    }
}
