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
using MenuQuantum;
using OraDalDemandas;
using ModeloDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormEntidadResponsable : BaseForm, IFuncionalidad
    {
        Persona _persona;
        bool _esNuevo = true;
        int _idx = 0;
        DefDominio _tipoAgente;
        PersonaTipoAgente _personaTipo;
        bool _esPersonaAsociada = false;
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
            _btnEliminarNodoConexion.Enabled = false;
            _btnTipoAgente.Enabled = false;
            _txtDireccion.Enabled = false;
            _txtNombre.Enabled = false;
            _txtSigla.Enabled = false;
            _txtTelefono.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbNuevo.Enabled = true;
            _tsbAsociarAgente.Enabled = true;
            _tsbEliminar.Enabled = true;
            _tsbEditar.Enabled = true;

        }

        private void HabilitarControles()
        {
            _btnEliminarNodoConexion.Enabled = true;
            _btnTipoAgente.Enabled = true;
            _txtDireccion.Enabled = true;
            _txtNombre.Enabled = true;
            _txtSigla.Enabled = true;
            _txtTelefono.Enabled = true;
            _dgvAgentes.Enabled = true;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbNuevo.Enabled = false;
            _tsbAsociarAgente.Enabled = false;
            _tsbEditar.Enabled = false;
            _tsbEliminar.Enabled = false;
        }

        private void LimpiarControles()
        {
            _txtDireccion.Text = string.Empty;
            _txtNombre.Text = string.Empty;
            _txtSigla.Text = string.Empty;
            _txtTelefono.Text = string.Empty;
            _errorProvider.Clear();
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                bool _esNuevo = _persona.EsNuevo;
                if (_esPersonaAsociada)
                {
                    if (_persona != null)
                    {
                        if (!OraDalPersonaTipoAgenteMgr.Instancia.ExisteRegistro(_persona.PkCodPersona))
                        {
                            OraDalPersonaMgr.Instancia.GuardarPersonaDemanda(_persona);
                            OraDalPersonaMgr.Instancia.GuardarRPersonaRolSINDemanda(_persona.PkCodPersona);
                            _personaTipo = new PersonaTipoAgente();
                            _personaTipo.EsNuevo = true;
                            _personaTipo.DCodTipoPersona = _tipoAgente.CodDominio;
                            _personaTipo.FkPersonsa = _persona.PkCodPersona;
                            OraDalPersonaTipoAgenteMgr.Instancia.Guardar(_personaTipo);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe registrado el agente.");
                        }
                    }
                }
                else
                {
                    OracleCommand cmd = null;
                    string sql = string.Empty;
                    _persona.Direccion = _txtDireccion.Text;
                    _persona.Nombre = _txtNombre.Text;
                    _persona.Sigla = _txtSigla.Text;
                    _persona.Telefono = _txtTelefono.Text;
                    _persona.DCodTipoPersona = 19;
                    OraDalPersonaMgr.Instancia.GuardarPersonaDemanda(_persona);

                    if (_personaTipo == null)
                    {
                        _personaTipo = new PersonaTipoAgente();
                        _personaTipo.EsNuevo = true;
                        _personaTipo.FkPersonsa = _persona.PkCodPersona;
                        _personaTipo.DCodTipoPersona = _tipoAgente.CodDominio;
                    }
                    else
                    {
                        _personaTipo.EsNuevo = false;
                        _personaTipo.FkPersonsa = _persona.PkCodPersona;
                        _personaTipo.DCodTipoPersona = _tipoAgente.CodDominio;
                    }
                    OraDalPersonaTipoAgenteMgr.Instancia.Guardar(_personaTipo);

                   
                }
                int idx = _idx;
                CargarDatos();
                DeshabilitarControles();
                if (_esNuevo)
                {
                    BindingContext[_dgvAgentes.DataSource].Position = _dgvAgentes.Rows.Count - 1;
                }
                else
                {
                    BindingContext[_dgvAgentes.DataSource].Position = idx;
                }
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (_txtTipoAgente.Text == "" || _tipoAgente==null)
            {
                res = false;
                _errorProvider.SetError(_txtTipoAgente, "Tiene que asignar un tipo de agente");
            }

            if (Utiles.EsCadenaVacia(_txtNombre.Text))
            {
                res = false;
                _errorProvider.SetError(_txtNombre, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }

            if (Utiles.EsCadenaVacia(_txtSigla.Text))
            {
                res = false;
                _errorProvider.SetError(_txtSigla, MessageMgr.Instance.GetMessage("INGRESE_VALOR_DISTINTO_A_VACIO"));
            }
            long pkPersona = _persona.EsNuevo ? 0 : _persona.PkCodPersona;
            if (!_esPersonaAsociada)
            {
                if (OraDalPersonaMgr.Instancia.ExistePersonaConEsteCampoYDato(Persona.C_NOM_PERSONA, _txtNombre.Text.Trim(), pkPersona))
                {
                    res = false;
                    _errorProvider.SetError(_txtNombre, "Ya existe una entidad registrada con este nombre.");
                }
            }
            return res;
        }

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            _esPersonaAsociada = false;
            HabilitarControles();
        }

        public Persona GetPersona()
        {
            return _persona;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            LimpiarControles();
            CargarDatos();
            DeshabilitarControles();
        }

        private void CargarDatos()
        {
            _dgvAgentes.DataSource = OraDalPersonaMgr.Instancia.GetEntidadResponsableDemandas();
            _dgvAgentes.Columns[1].Width = 320;
            _dgvAgentes.Columns[3].Width = 250;
            _dgvAgentes.Columns[0].Visible = false;
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                _idx = _dgvAgentes.SelectedCells[0].RowIndex;
                DataRow row = ((DataRowView)_dgvAgentes.SelectedRows[0].DataBoundItem).Row;
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
            _personaTipo = OraDalPersonaTipoAgenteMgr.Instancia.GetPorIdPersona(_persona.PkCodPersona);
            _tipoAgente = null;
            if (_personaTipo == null)
            {
                _txtTipoAgente.Text = string.Empty;
            }
            else
            {
                DefDominioMgr mgr = new DefDominioMgr();
                _tipoAgente = mgr.GetPorId<DefDominio>((long)_personaTipo.DCodTipoPersona, DefDominio.C_COD_DOMINIO);
                _txtTipoAgente.Text = _tipoAgente.Descripcion;
            }
        }

        private void _tsbNuevo_Click(object sender, EventArgs e)
        {
            _esPersonaAsociada = false;
            _persona = new Persona();
            _persona.EsNuevo = true;
            _personaTipo = null;
            _tipoAgente = null;
            LimpiarControles();
            HabilitarControles();
            _txtNombre.Focus();
            _txtTipoAgente.Text = string.Empty;
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            DeshabilitarControles();
            ShowDialog();
        }

        private void _tsbEliminar_Click(object sender, EventArgs e)
        {
            if (_dgvAgentes.RowCount > 0)
            {
                if (_persona != null)
                {
                     DialogResult res = MessageBox.Show("Está seguro de eliminar el agente?", "Confirmación", MessageBoxButtons.YesNo);
                     if (res == DialogResult.Yes)
                     {
                         if (OraDalPersonaNodosMgr.Instancia.GetPersonaNodo(_persona.PkCodPersona).Rows.Count == 0)
                         {
                             OraDalPersonaMgr.Instancia.EliminarAgenteDeSisDemanda(_persona.PkCodPersona);
                             OraDalPersonaTipoAgenteMgr.Instancia.EliminarRegistro(_persona.PkCodPersona);
                             CargarDatos();
                             DeshabilitarControles();
                         }
                         else
                         {
                             MessageBox.Show("No se puede eliminar el agente porque tiene asignación de nodos.");
                         }
                     }
                }
            }
        }

        private void _btnTipoAgente_Click(object sender, EventArgs e)
        {
            FormTiposDeAgentes form = new FormTiposDeAgentes();
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                _tipoAgente = form.GetTipoAgente();
                _txtTipoAgente.Text = _tipoAgente.Descripcion;
            }
        }

        private void _btnEliminarNodoConexion_Click(object sender, EventArgs e)
        {
            _tipoAgente = null;
            _txtTipoAgente.Text = string.Empty;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            _tipoAgente = null;
            _txtTipoAgente.Text = string.Empty;
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
    }
}
