using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using OraDalProyectos;

namespace Proyectos
{
    public partial class FormElimHistoCronogramaInversion : BaseForm
    {
        long _pkDatoEconomico;
        public FormElimHistoCronogramaInversion()
        {
            InitializeComponent();
        }

        public bool Eliminar(long pkDatoEconomico, List<long> aniosRef)
        {
            bool resultado = true;
            _pkDatoEconomico = pkDatoEconomico;
            foreach (long a in aniosRef)
            {
                _chlbxHistoricos.Items.Add(a);
            }
            DialogResult r = ShowDialog();
            resultado = (r == DialogResult.OK);
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _btnEliminarHistorico_Click(object sender, EventArgs e)
        {
            List<long> seleccionados = new List<long>();
            foreach (long a in _chlbxHistoricos.CheckedItems)
            {
                seleccionados.Add(a);
            }
            OraDalCronogramaDeInversionMgr.Instancia.EliminarHistorico(_pkDatoEconomico, seleccionados);
            DialogResult = DialogResult.OK;
        }
    }
}
