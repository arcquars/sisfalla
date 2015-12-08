using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.Pistas;

namespace SISFALLA
{
    public partial class FormEnvioNotif : BaseForm
    {
        public FormEnvioNotif()
        {
            InitializeComponent();
        }

        public string Asunto
        {
            get { return _txtAsunto.Text; }
            set { _txtAsunto.Text = value; }
        }

        public string Cuerpo
        {
            get { return _txtContenido.Text; }
            set { _txtContenido.Text = value; }
        }

        public DialogResult Visualizar(string asunto, string cuerpo)
        {
            _txtAsunto.Text = asunto;
            _txtContenido.Text = cuerpo;
            return ShowDialog();
        }

        private void _btnEnviar_Click(object sender, EventArgs e)
        {
            PistaMgr.Instance.Info("Sisfalla  " ,"FormEnvioNotif - DatosSonValidos"); 
            if (DatosSonValidos())
            {
                PistaMgr.Instance.Info("Sisfalla  ", "FormEnvioNotif :Result ok"); 
                DialogResult = DialogResult.OK;
            }
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _txtAsunto.Text = _txtAsunto.Text.Trim();
            _txtContenido.Text = _txtContenido.Text.Trim();
            _errorProvider.Clear();

            if (string.IsNullOrEmpty(_txtAsunto.Text))
            {
                _errorProvider.SetError(_txtAsunto, "Ingrese el Asunto.");
                resultado = false;
            }

            if (string.IsNullOrEmpty(_txtContenido.Text))
            {
                _errorProvider.SetError(_txtContenido, "Ingrese el Cuerpo.");
                resultado = false;
            }
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}