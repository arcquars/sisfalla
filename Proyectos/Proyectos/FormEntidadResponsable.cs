using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.UtilesComunes;
using CNDC.ExceptionHandlerLib;
using Oracle.DataAccess.Client;
using OraDalProyectos;

namespace Proyectos
{
    public partial class FormEntidadResponsable : Form
    {
        Persona _persona;
        bool _esNuevo = true;
        int _idx = 0;
        bool _esPersonaAsociada=false;
        public FormEntidadResponsable()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarDatos();
            }
        }

        public void RegistrarEntidadResponsable()
        {
            _esNuevo = true;
            _txtNombre.Focus();
            DeshabilitarControles();
            LimpiarControles();
            _persona = new Persona();
            _persona.EsNuevo = true;
        }

        private void DeshabilitarControles()
        {
            _txtDireccion.Enabled = false;
            _txtNombre.Enabled = false;
            _txtSigla.Enabled = false;
            _txtTelefono.Enabled = false;
            //_dgvProyectos.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = true;
        }

        private void HabilitarControles()
        {
            _txtDireccion.Enabled = true;
            _txtNombre.Enabled = true;
            _txtSigla.Enabled = true;
            _txtTelefono.Enabled = true;
            //_dgvProyectos.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbNuevo.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        private void LimpiarControles()
        {
            _txtDireccion.Text = string.Empty;
            _txtNombre.Text = string.Empty;
            _txtSigla.Text = string.Empty;
            _txtTelefono.Text = string.Empty;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                if (_esPersonaAsociada)
                {
                    if (_persona != null)
                    {
                        OraDalPersonaMgr.Instancia.GuardarPersonaDemanda(_persona);
                        if (!OraDalPersonaMgr.Instancia.ExisteEsteRegistroParaSisProyectos(_persona.PkCodPersona))
                        {
                            OraDalPersonaMgr.Instancia.GuardarRPersonaRolSINProyectos(_persona.PkCodPersona);
                        }
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    bool _esNuevo = _persona.EsNuevo;
                    OracleCommand cmd = null;
                    string sql = string.Empty;
                    _persona.Direccion = _txtDireccion.Text;
                    _persona.Nombre = _txtNombre.Text;
                    _persona.Sigla = _txtSigla.Text;
                    _persona.Telefono = _txtTelefono.Text;
                    _persona.DCodTipoPersona = 19;
                    OraDalPersonaMgr.Instancia.Guardar(_persona);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (Utiles.EsCadenaVacia(_txtNombre.Text))
            {
                res = false;
                _errorProvider.SetError(_txtNombre, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }

            //if (Utiles.EsCadenaVacia(_txtSigla.Text))
            //{
            //    res = false;
            //    _errorProvider.SetError(_txtSigla, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            //}

            if (!_esPersonaAsociada)
            {
                if (OraDalPersonaMgr.Instancia.ExistePersonaConEsteCampoYDato(Persona.C_NOM_PERSONA, _txtNombre.Text.Trim(), _persona.PkCodPersona))
                {
                    res = false;
                    _errorProvider.SetError(_txtNombre, "Ya existe una entidad registrada con este nombre.");
                }
            }

            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        public Persona GetPersona()
        {
            return _persona;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CargarDatos()
        {
            _dgvProyectos.DataSource = OraDalPersonaMgr.Instancia.GetEntidadResponsable();
            _dgvProyectos.Columns[1].Width = 320;
            _dgvProyectos.Columns[3].Width = 250;
            _dgvProyectos.Columns[0].Visible = false;
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (_dgvProyectos.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvProyectos.SelectedRows[0].DataBoundItem).Row;
                int pkEntidadResponsable = int.Parse(row[0].ToString());
                _persona = OraDalPersonaMgr.Instancia.GetPorId<Persona>(pkEntidadResponsable, Persona.C_PK_COD_PERSONA);
                _persona.EsNuevo = false;
                MostrarDatos();
            }
        }

        private void MostrarDatos()
        {
            _txtDireccion.Text = _persona.Direccion;
            _txtNombre.Text = _persona.Nombre;
            _txtSigla.Text = _persona.Sigla;
            _txtTelefono.Text = _persona.Telefono;
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _persona = new Persona();
            _persona.EsNuevo = true;
            LimpiarControles();
            HabilitarControles();
            _txtNombre.Focus();
        }

        private void _tsbAgregarAgenteExistente_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            _esPersonaAsociada = true;
            HabilitarControles();
            FormAgentesExistentes form = new FormAgentesExistentes();
            form.ShowDialog();
            DialogResult res = form.DialogResult;
            if (res == DialogResult.OK)
            {
                _persona = form.GetAgente();
                if (_persona == null)
                {
                    _txtDireccion.Text = "";
                    _txtNombre.Text = "";
                    _txtSigla.Text = "";
                    _txtTelefono.Text = "";
                }
                else
                {
                    _txtDireccion.Text = _persona.Direccion;
                    _txtNombre.Text = _persona.Nombre;
                    _txtSigla.Text = _persona.Sigla;
                    _txtTelefono.Text = _persona.Telefono;

                    _txtDireccion.Enabled = false;
                    _txtNombre.Enabled = false;
                    _txtSigla.Enabled = false;
                    _txtTelefono.Enabled = false;
                }
            }
            else
            {
                _persona = null;
                _txtDireccion.Text = "";
                _txtNombre.Text = "";
                _txtSigla.Text = "";
                _txtTelefono.Text = "";
            }
        }

        private void _dgvProyectos_DoubleClick(object sender, EventArgs e)
        {
            if (_persona != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void _tsbEliminarAgente_Click(object sender, EventArgs e)
        {
            if (_dgvProyectos.RowCount > 0)
            {
                if (_persona != null)
                {
                     DialogResult res = MessageBox.Show("Está seguro de eliminar el agente seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
                     if (res == DialogResult.Yes)
                     {
                         if (OraDalProyectoMgr.Instancia.GetProyectosPorPkPersona(_persona.PkCodPersona).Rows.Count == 0)
                         {
                             OraDalPersonaMgr.Instancia.EliminarAgenteDeSisProyectos(_persona.PkCodPersona);
                             CargarDatos();
                         }
                         else
                         {
                             MessageBox.Show("No sepuede eliminar el registro, porque existen proyectos asociados a esta entidad.");
                         }
                     }
                }
            }
        }
    }
}
