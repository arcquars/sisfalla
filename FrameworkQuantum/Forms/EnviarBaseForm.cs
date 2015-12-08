using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNDC.BaseForms
{
    public partial class EnviarBaseForm : BaseForm
    {
        protected bool _preguntarCancelar = false;

        public EnviarBaseForm()
        {
            InitializeComponent();
        }

        private void _btnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        protected virtual void Enviar()
        {
        }

        private void Cancelar()
        {
            if (_preguntarCancelar)
            {
                DialogResult r = MessageBox.Show("Seguro que desea cancelar la operación ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
