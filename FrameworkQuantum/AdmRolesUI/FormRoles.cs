using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using CNDC.BLL;

namespace AdmRolesUI
{
    public partial class FormRoles : BaseForm, IFuncionalidad
    {
        Rol _rolSeleccionado = null;
        public FormRoles()
        {
            InitializeComponent();
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            _dgvRoles.DataSource = OraDalRolMgr.Instancia.GetTabla();
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol.EsNuevo = true;
            Editar(rol);
        }

        private void Editar(Rol rol)
        {
            FormRol fRol = new FormRol();
            if (fRol.Editar(rol))
            {
                CargarDatos();
            }
        }

        private void _dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvRoles.SelectedRows.Count > 0)
            {
                DataRow r = (_dgvRoles.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _rolSeleccionado = new Rol(r);
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_rolSeleccionado != null)
            {
                Editar(_rolSeleccionado);
            }
        }

        private void _btnOpciones_Click(object sender, EventArgs e)
        {
            if (_rolSeleccionado != null)
            {
                FormOpciones fOpciones = new FormOpciones();
                fOpciones.Editar(_rolSeleccionado);
            }
        }
    }
}