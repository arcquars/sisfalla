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
 
using CNDC.UtilesComunes;
using ModeloComponentes;
using CNDC.Dominios;
using CNDC.BLL;
using ModeloSisFalla;
using System.Globalization;

using CNDC.Pistas;

namespace ComponentesUI
{
    public partial class FrmComponente : Form, IFuncionalidad

    {
        public FrmComponente()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        string _filtroComponente = string.Empty;
        long _pkCodPersona = 0;
        long _tipoComponente = 0;
        long _pkcodNodo = 0;
        List<D_TIPO_COMPONENTE> _filtroTipo =null ;
        DataView _dvwComponente;

        private void CargarDatos()
        {   
            try
            {
                _dvwComponente = new DataView(OraDalComponentes.ComponenteMgr.Instancia.GetComponentesAbm());
                _dgvDatos.DataSource = _dvwComponente;
                _dgvDatos.AllowUserToAddRows = false;
                _dgvDatos.AllowUserToDeleteRows = false;
                _dgvDatos.AllowUserToResizeColumns = false;

                _dgvDatos.MultiSelect = false;
                if (_dgvDatos.RowCount > 0)
                {
                    _dgvDatos.Rows[0].Selected = true;
                    _dgvDatos.BindingContext[_dgvDatos.DataSource].Position = 0;
                }

                foreach (DataGridViewColumn c in _dgvDatos.Columns)
                {
                    Console.WriteLine(c.Name);
                }
                FormatDGV();
                Filtrar();
            }
            catch (Exception e)
            { 
                 PistaMgr.Instance.Error("COMPONENTES.ComponentesUI",e.ToString ());
            }
        }


        private void FormatDGV()
        {
            _dgvDatos.Columns["PK_CMP"].Visible = false;
            _dgvDatos.Columns["ID_COMP"].Visible = true;
            _dgvDatos.Columns["ID_COMP"].HeaderText = "Id. Universal";
            _dgvDatos.Columns["ID_COMP"].Width = 150;
            _dgvDatos.Columns["COD_COMP"].Visible = true;
            _dgvDatos.Columns["COD_COMP"].HeaderText = "Nombre";

            _dgvDatos.Columns["TIPO_COMP"].Visible = false;
            
            _dgvDatos.Columns["PK_AGENTE"].Visible = false;
            _dgvDatos.Columns["PK_COD_NODO_ORIGEN"].Visible = false;
            _dgvDatos.Columns["PK_COD_NODO_DESTINO"].Visible = false;
            _dgvDatos.Columns["SIGLA"].HeaderText = "Tipo";
            _dgvDatos.Columns["SIGLA"].Width = 150;
            _dgvDatos.Columns["COD_AGENTE"].HeaderText = "Agente";

            _dgvDatos.Columns["DESCRIPCION"].HeaderText = "Descripción";
            _dgvDatos.Columns["DESCRIPCION"].Width = 250;
            _dgvDatos.Columns["FECHA_INI"].HeaderText = "Fecha Inicio";
            _dgvDatos.Columns["FECHA_BAJA"].HeaderText = "Fecha Baja";

            _dgvDatos.Columns["NODO_ORIGEN"].HeaderText = "Nodo Origen";
            _dgvDatos.Columns["NODO_DESTINO"].HeaderText = "Nodo Destino";

        }
        private void FrmComponente_Load(object sender, EventArgs e)
        {
            CargarDatos();
          

            _cmbAgente.DisplayMember = Persona.C_NOM_COD_AGENTE;
            _cmbAgente.ValueMember = Persona.C_PK_COD_PERSONA;
            _cmbAgente.DataSource = ModeloMgr.Instancia.PersonaMgr.GetAgentes();

            _cmbTipoComponente.DisplayMember = "descripcion_tipo";
            _cmbTipoComponente.ValueMember = "pk_cod_tipo_componente";
            _cmbTipoComponente.DataSource = OraDalComponentes.ComponenteMgr.Instancia.GetTipoComponentes();

            _cmbNodo.ValueMember = "pk_cod_nodo";
            _cmbNodo.DisplayMember = "valor";
            _cmbNodo.DataSource = OraDalComponentes.ComponenteMgr.Instancia.GetNodos();
            
            
          
        }

     


        private void Filtrar()
        {
            try
            {
                string fCompo = "id_comp LIKE '%" + _filtroComponente + "%' ";
                if (_cbAgente.Checked)
                {
                    fCompo += " AND  pk_agente=" + _pkCodPersona;
                }
                if (_cbTipoCompo.Checked)
                {
                    fCompo += " AND  TIPO_COMP =" + _tipoComponente;
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
                        tmp += ModeloComponentes.Componente.C_D_TIPO_COMPONENTE + "=" + (int)item;
                    }
                    if (tmp != string.Empty)
                    {
                        fCompo += " AND(" + tmp + ")";
                    }
                }

                if (_cbNodo.Checked)
                {
                    fCompo += " AND  ( pk_cod_nodo_origen =" + _pkcodNodo + " or PK_COD_NODO_DESTINO =" + _pkcodNodo + ") ";
                }

                if (_rbVigentes.Checked)
                {

                    
                    string s = string.Format("fecha_ini <= Convert('{0}',System.DateTime) and ( fecha_baja >=  Convert('{0}',System.DateTime)  or fecha_baja is null )", System.DateTime.Now.Date);
                    fCompo += " AND   " + s + "  ";

                }

                if (_rbNoVigentes.Checked )
                {
                    string s = string.Format("fecha_ini >  Convert('{0}',System.DateTime) or  ( fecha_baja <=  Convert('{0}',System.DateTime)  ) ", System.DateTime.Now.Date);
                    fCompo += " AND (  " + s + " ) ";

                }
                
                _dvwComponente.RowFilter = fCompo;
                //_componenteSeleccionado = null;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



        }

        private void _cbAgente_CheckedChanged(object sender, EventArgs e)
        {
            _cmbAgente.Visible = _cbAgente.Checked;
            Filtrar();
        }
        private void _cbTipoCompo_CheckedChanged(object sender, EventArgs e)
        {
            _cmbTipoComponente.Visible = _cbTipoCompo.Checked;
            Filtrar();
        }

        private void _cbNodo_CheckedChanged(object sender, EventArgs e)
        {
            _cmbNodo.Visible = _cbNodo.Checked;
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

        private void _tSBNuevo_Click(object sender, EventArgs e)
        {
            FrmAbmComponente nuevo = new FrmAbmComponente();
            nuevo.Nuevo  = true;
            nuevo.ShowDialog();
            CargarDatos();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (_dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = _dgvDatos.SelectedRows[0];

                FrmAbmComponente editar = new FrmAbmComponente();
                editar.Nuevo = false;

                editar.Componente = new ModeloComponentes.Componente(row);
                editar.ShowDialog();
                CargarDatos();
            }
            else {
                MessageBox.Show("Por favor seleccione un componente ");
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = _dgvDatos.SelectedRows[0];
            ModeloComponentes.Componente Componente = new ModeloComponentes.Componente(row);

            if (System.Windows.Forms.DialogResult.Yes == MessageBox.Show("¿Desea eliminar el componente: " + Componente.ToString() + "?", "Eliminar Componente", MessageBoxButtons.YesNo))
            {
                if (Componente.DTipoComponente == 0)
                {
                    OraDalComponentes.NodoMgr.Instancia.Eliminar(Componente);
                }
                else
                {
                    OraDalComponentes.ComponenteMgr.Instancia.Eliminar(Componente);
                }
            }
            CargarDatos();
                
        }


        public ParametrosFuncionalidad Parametros
        {
            get
            ;
            set
            ;
        }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void _txtNombreComponente_TextChanged(object sender, EventArgs e)
        {
            _filtroComponente = _txtNombreComponente.Text;
            Filtrar();
        }

        private void _cbSoloVigente_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void _rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void _rbVigentes_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}
