using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormDetalleBorradoRegFalla : ABMBaseForm
    {
        public FormDetalleBorradoRegFalla()
        {
            InitializeComponent();
        }

        private void FormDetalleBorradoRegFalla_Load(object sender, EventArgs e)
        {
            _txtUsuario.Text = Sesion.Instancia.UsuarioActual.Nombre;
        }

        protected override bool Guardar()
        {
            bool resultado = false;

            if (DatosValidos())
            {
                resultado = true;
                DialogResult = DialogResult.OK;
            }
            return resultado;
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (string.IsNullOrEmpty(_txtMotivo.Text))
            {
                _errorProvider.SetError(_txtMotivo, MessageMgr.Instance.GetMessage("INGRESE_MOTIVO_BORRADO"));
                resultado = false;
            }
            return resultado;
        }

        public string Motivo
        {
            get { return _txtMotivo.Text; }
        }
    }
}
