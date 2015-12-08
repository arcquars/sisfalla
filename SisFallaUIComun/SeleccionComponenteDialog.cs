using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.Dominios;
using CNDC.DAL;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class SeleccionComponenteDialog : BaseForm
    {
        Componente _componenteSeleccionado;
        Persona _personaSeleccionada;
        private List<long> _componenteNoSeleccionables;

        DataView _dvwComponente;
        long _pkCodPersona = 0;
        long _tipoComponente = 0;
        long _pkcodNodo = 0;
        string _filtroComponente = string.Empty;
        List<D_TIPO_COMPONENTE> _filtroTipo;

        public SeleccionComponenteDialog()
        {
            InitializeComponent();

            //if (Sesion.Instancia.RolSIN == "AE" || Sesion.Instancia.RolSIN == "CNDC")
            {
                _dvwComponente = new DataView(ModeloMgr.Instancia.ComponenteMgr.GetComponenteCompleto());
            }
            //else
            //{
            //    _dvwComponente = new DataView(ModeloMgr.Instancia.ComponenteMgr.GetComponenteCompleto(Sesion.Instancia.EmpresaActual.PkCodPersona));
            //    _cbAgente.Enabled = false;
            //}

            _cmbAgente.DisplayMember = Persona.C_NOM_COD_AGENTE;
            _cmbAgente.ValueMember = Persona.C_PK_COD_PERSONA;

            _cmbAgente.DataSource = ModeloMgr.Instancia.PersonaMgr.GetAgentes();

            _cmbTipoComponente.DisplayMember = DefDominio.C_DESCRIPCION;
            _cmbTipoComponente.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbTipoComponente.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetTipoComponente("D_TIPO_COMPONENTE");

            _cmbNodo.ValueMember = "pk_cod_nodo";
            _cmbNodo.DisplayMember = "valor";
            _cmbNodo.DataSource = GetNodos();

            _dgvComponentes.DataSource = _dvwComponente;
            formatDatagrids(_dgvComponentes);
            BaseForm.VisualizarColumnas(_dgvComponentes, ColumnStyleManger.GetEstilos(this.Name, _dgvComponentes.Name));
            _txtNombreComponente.KeyPress += new KeyPressEventHandler(_txtNombreComponente_KeyPress);
        }

        void _txtNombreComponente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar =='\'')
            {
                e.Handled = true;
            }
            
        }

        private DataTable GetNodos()
        {
            Oracle.DataAccess.Client.OracleCommand ocm = Sesion.Instancia.Conexion.CrearCommand();
            ocm.CommandText = "select pk_cod_nodo, sigla_nodo || '-'||descripcion_nodo valor from f_ac_nodo";
            DataTable table = Sesion.Instancia.Conexion.EjecutarCmd(ocm);       
            return table;
        }
        public Persona AgenteComponente
        { get { return _personaSeleccionada; } }

        public Componente ComponenteSeleccionado
        {
            get { return _componenteSeleccionado; }
        }

        private void _cmbAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbAgente.SelectedValue == null)
            {
                _pkCodPersona = 0;
            }
            else
            {
                _pkCodPersona = (long)_cmbAgente.SelectedValue;
            }
            Filtrar();
        }

        private void _cmbTipoComponente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbTipoComponente.SelectedValue == null)
            {
                _tipoComponente = 0;
            }
            else
            {
                _tipoComponente = (long)_cmbTipoComponente.SelectedValue;
            }
            Filtrar();
        }

        private void Filtrar()
        {
            string fCompo = "NOMBRE_COMPONENTE LIKE '%" + _filtroComponente + "%' ";
            if (_cbAgente.Checked)
            {
                fCompo += " AND " + Componente.C_PROPIETARIO + "=" + _pkCodPersona;
            }
            if (_cbTipoCompo.Checked)
            {
                fCompo += " AND " + Componente.C_D_TIPO_COMPONENTE + "=" + _tipoComponente;
            }
            else if (_filtroTipo != null)
            {
                string tmp = string.Empty;
                foreach (var item in _filtroTipo)
                {
                    if (tmp != string.Empty)
                    {
                        tmp += " OR ";
                    }
                    tmp += Componente.C_D_TIPO_COMPONENTE + "=" + (int)item;
                }
                if (tmp != string.Empty)
                {
                    fCompo += " AND(" + tmp + ")";
                }
            }

            if (_cbNodo.Checked)
            {
                fCompo += " AND  ( PK_COD_NODO_ORIGEN ="  + _pkcodNodo + " or PK_COD_NODO_DESTINO =" +_pkcodNodo + ") " ;
            }
            _dvwComponente.RowFilter = fCompo;
            _componenteSeleccionado = null;
            _dgvComponentes.ClearSelection();
         }

        private void _txtNombreComponente_TextChanged(object sender, EventArgs e)
        {
            _filtroComponente = _txtNombreComponente.Text;
            Filtrar();
        }
        
        private void _dgvComponentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvComponentes.SelectedRows.Count > 0)
            {
                DataRow r = ((DataRowView)_dgvComponentes.SelectedRows[0].DataBoundItem).Row;
                decimal idComponente =(decimal ) r["PK_COD_COMPONENTE"];
                GetComponente(idComponente);
            }
        }

        private void GetComponente(decimal idComponente)
        {
            Oracle.DataAccess.Client.OracleCommand ocm = Sesion.Instancia.Conexion.CrearCommand();
            ocm.CommandText = "select * from f_ac_componente where pk_cod_componente = :ppk_cod_componente AND d_cod_estado = 'VI'"; //AND FECHA_SALIDA is null";
            ocm.Parameters.Add("ppk_cod_componente", idComponente);
            DataTable table = Sesion.Instancia.Conexion.EjecutarCmd(ocm);
            if (table.Rows.Count > 0)
            {
                _componenteSeleccionado = new Componente(table.Rows[0]);
            }
        }

        private void GetPropietario(decimal idComponente)
        {
            Oracle.DataAccess.Client.OracleCommand ocm = Sesion.Instancia.Conexion.CrearCommand();
            ocm.CommandText = 
            @"select sigla || '-'  || NOM_PERSONA NOM_COD_AGENTE, PK_COD_PERSONA, NOM_PERSONA, 
            SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, D_COD_ESTADO, SEC_LOG, SINC_VER 
            from f_ap_persona 
            where pk_cod_persona =(select propietario from f_ac_componente 
                                   where pk_cod_componente = :ppk_cod_componente)";
            ocm.Parameters.Add("ppk_cod_componente", idComponente);
            DataTable table = Sesion.Instancia.Conexion.EjecutarCmd(ocm);
            if (table.Rows.Count > 0)
            {
                _personaSeleccionada = new Persona(table.Rows[0]);
            }
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (_componenteSeleccionado == null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("SELEC_COMPONENTE"));
            }
            //else if (_componenteNoSeleccionables.Contains((long)_componenteSeleccionado.PkCodComponente))
            //{
            //    MessageBox.Show("El componente seleccionado está en uso.");
            //}
            else
            {
                GetPropietario(_componenteSeleccionado.PkCodComponente);
                DialogResult = DialogResult.OK;
            }
        }

        private void cndcButton1_Click(object sender, EventArgs e)
        {
            _componenteSeleccionado = null;
            DialogResult = DialogResult.Cancel;
        }

        private void SeleccionComponenteDialog_Load(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void _cbTipoCompo_CheckedChanged(object sender, EventArgs e)
        {
            _cmbTipoComponente.Visible = _cbTipoCompo.Checked;
            Filtrar();
        }

        private void _cbAgente_CheckedChanged(object sender, EventArgs e)
        {
            _cmbAgente.Visible = _cbAgente.Checked;
            Filtrar();
        }

        private void cndcCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            _cmbNodo.Visible = _cbNodo.Checked;
            Filtrar();
        }

        private void _cmbNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbNodo.SelectedValue == null)
            {
                _pkcodNodo = 0;
            }
            else
            {
                _pkcodNodo = (long)_cmbNodo.SelectedValue;
            }
            Filtrar();
        }

        public void SetFiltroTipo(List<D_TIPO_COMPONENTE> filtroTipo, List<long> componenteNoSeleccionables)
        {
            _filtroTipo = filtroTipo;
            _cbTipoCompo.Enabled = (_filtroTipo == null);
            _componenteNoSeleccionables = componenteNoSeleccionables;
        }

        private void _cbTipoCompo_Click(object sender, EventArgs e)
        {
        }
    }
}