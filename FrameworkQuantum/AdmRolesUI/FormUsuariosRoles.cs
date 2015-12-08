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
    public partial class FormUsuariosRoles : BaseForm, IFuncionalidad
    {
        public ParametrosFuncionalidad Parametros { get; set; }
        List<Rol> _roles = null;
        DataRow _usuarioSeleccionado = null;
        List<long> _rolesUsuarioSeleccionado;
        public FormUsuariosRoles()
        {
            InitializeComponent();
        }

        private void FormUsuariosRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarDatos();
        }

        private void CargarRoles()
        {
            _roles = OraDalRolMgr.Instancia.GetRolesActivos();
            foreach (Rol r in _roles)
            {
                _chlbxRoles.Items.Add(r);
            }
        }

        private void CargarDatos()
        {
            _dgvUsuarios.DataSource = OraDalUsuarioMgr.Instancia.GetUsuariosConNombres();
        }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void _dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvUsuarios.SelectedRows.Count > 0)
            {
                _usuarioSeleccionado = (_dgvUsuarios.SelectedRows[0].DataBoundItem as DataRowView).Row;
                VisualizarDatos();
            }
        }

        private void VisualizarDatos()
        {
            if (_usuarioSeleccionado != null)
            {
                _txtUsuario.Text = ObjetoDeNegocio.GetValor<string>(_usuarioSeleccionado["login"]);
                _txtNombre.Text = ObjetoDeNegocio.GetValor<string>(_usuarioSeleccionado["nom_persona"]);
                _txtEstado.Text = ObjetoDeNegocio.GetValor<string>(_usuarioSeleccionado["d_cod_estado"]);
                CargarRolesUsuarioSeleccionado();
            }
        }

        private void CargarRolesUsuarioSeleccionado()
        {
            for (int i = 0; i < _roles.Count; i++)
            {
                _chlbxRoles.SetItemChecked(i, false);
            }

            _rolesUsuarioSeleccionado = OraDalRolMgr.Instancia.GetRolesDeUsuario((string)_usuarioSeleccionado["login"]);
            for (int i = 0; i < _roles.Count; i++)
            {
                foreach (long numRol in _rolesUsuarioSeleccionado)
                {
                    if (_roles[i].Num_Rol == numRol)
                    {
                        _chlbxRoles.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            List<long> rolesModificado = GetRolesAsignados();
            if (!SonIguales(_rolesUsuarioSeleccionado,rolesModificado))
            {
                List<long> rolesNuevos = Diferencia(rolesModificado, _rolesUsuarioSeleccionado);
                List<long> rolesQuitados = Diferencia(_rolesUsuarioSeleccionado, rolesModificado);
                OraDalRolMgr.Instancia.Asignar(rolesNuevos, (string)_usuarioSeleccionado["login"]);
                OraDalRolMgr.Instancia.Quitar(rolesQuitados, (string)_usuarioSeleccionado["login"]);
            }
        }

        private List<long> Diferencia(List<long> a, List<long> b)
        {
            List<long> resultado = new List<long>();
            foreach (long i in a)
            {
                if (!b.Contains(i))
                {
                    resultado.Add(i);
                }
            }
            return resultado;
        }

        private bool SonIguales(List<long> a, List<long> b)
        {
            bool resultado = false;
            a.Sort();
            b.Sort();
            if (a.Count == b.Count)
            {
                resultado = true;
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != b[i])
                    {
                        resultado = false;
                        break;
                    }
                }
            }
            return resultado;
        }

        private List<long> GetRolesAsignados()
        {
            List<long> resultado = new List<long>();
            foreach (Rol r in _chlbxRoles.CheckedItems)
            {
                resultado.Add(r.Num_Rol);
            }
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            CargarRolesUsuarioSeleccionado();
        }
    }
}
