using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using OraDalDemandas;
using ModeloDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormNodosProyectos : BaseForm
    {
        NodoDemanda _nodo;
        NodoDemanda _nodoDemanda;
        bool _nodosSalida = true;
        PersonaNodos _personaNodo;
        public FormNodosProyectos()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
               // CargarCmbTipoNodo();
            }
        }

        private void CargarCmbTipoNodo()
        {
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbTipoNodo.DisplayMember = "Descripcion";
            _cmbTipoNodo.ValueMember = "CodDominio";
            _cmbTipoNodo.DataSource = mgr.GetListaDominio("D_COD_TIPO_NODO");
        }

        private void CargarNodosProyectos()
        {
            if (_nodosSalida == true)
            {
                _dgvNodos.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosParaAsignacionDeNodosSalida((long)_cmbTipoNodo.SelectedValue, _personaNodo.PkPersonaNodo, _personaNodo.FkPersona);
                _dgvNodos.Columns[0].Visible = false;
                _dgvNodos.Columns[1].Width = 220;
                _dgvNodos.Columns[3].Width = 350;
            }
            else
            {
                long pkDemanda = 0;
                if (_nodoDemanda != null)
                {
                    pkDemanda = _nodoDemanda.PkNodoDemanda;
                }
                _dgvNodos.DataSource = OraDalNodoDemandaMgr.Instancia.GetNodosProySalida(_txtSigla.Text, (long)_cmbTipoNodo.SelectedValue, pkDemanda);
                _dgvNodos.Columns[0].Visible = false;
                _dgvNodos.Columns[1].Width = 220;
                _dgvNodos.Columns[3].Width = 350;
            }
        }

        private void _txtSigla_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                CargarNodosProyectos();
            }
        }

        private void _dgvNodos_SelectionChanged(object sender, EventArgs e)
        {
            _nodo = null;
            if (_dgvNodos.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvNodos.SelectedRows[0].DataBoundItem).Row;
                int pkNodo = int.Parse(row[0].ToString());
                _nodo = OraDalNodoDemandaMgr.Instancia.GetPorId<NodoDemanda>(pkNodo, NodoDemanda.C_PK_NODO_DEMANDA);
            }
        }

        private void _dgvNodos_DoubleClick(object sender, EventArgs e)
        {
            if (_nodo != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }


        public NodoDemanda GetNodo()
        {
            return _nodo;
        }

        private void _cmbTipoNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbTipoNodo.SelectedItem != null)
            {
                CargarNodosProyectos();
            }
        }

        public void SetParametros(NodoDemanda nodoDemanda, bool nodosSalida, PersonaNodos personaNodo)
        {
            _personaNodo = personaNodo;
            _nodosSalida = nodosSalida;
            _nodoDemanda = nodoDemanda;
            CargarCmbTipoNodo();
        }
    }
}
