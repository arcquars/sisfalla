using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF_EstresServicioSisFalla
{
    public partial class FormLogin : Form
    {
        WCF_SisFalla.IServicioSISFALLA _servicio;
        public static long PkCodPersona { get; set; }
        public static string TokenSesion { get; set; }
        public FormLogin()
        {
            InitializeComponent();
        }
        public string Usuario
        {
            get { return _txtUs.Text; }
        }
        private void _btnIngresar_Click(object sender, EventArgs e)
        {
            TokenSesion = string.Format("Usuario={0}|Contrasena={1}", _txtUs.Text, _txtPas.Text);
            _servicio = new WCF_SisFalla.ServicioSISFALLAClient();
            PkCodPersona = _servicio.IniciarSesion(TokenSesion);
            if (PkCodPersona > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Hay errores al iniciar la sesión.");
            }
        }
    }
}
