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

namespace AdmRolesUI
{
    public partial class FormRol : ABMBaseForm
    {
        Rol _rol;
        public FormRol()
        {
            InitializeComponent();
        }

        public bool Editar(Rol rol)
        {
            bool resultado = true;
            _rol = rol;
            VisualizarDatos();
            DialogResult r = ShowDialog();
            resultado = r == DialogResult.OK;
            return resultado;
        }

        private void VisualizarDatos()
        {
            _txtNombre.Text = _rol.NombreCorto;
            _txtDescripcion.Text = _rol.Descripcion;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _rol.NombreCorto = _txtNombre.Text;
                _rol.Descripcion = _txtDescripcion.Text;
                if (OraDalRolMgr.Instancia.Guardar(_rol))
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (string.IsNullOrEmpty(_txtNombre.Text))
            {
                resultado = false;
                _errorProvider.SetError(_txtNombre, "Ingrese el nombre del Rol");
            }
            return resultado;
        }
    }
}
