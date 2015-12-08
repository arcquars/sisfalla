using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using OraDalComponentes;
using ModeloComponentes;

namespace ComponentesUI
{
    public partial class CtrlDescNodo : QuantumBaseControl
    {
        public CtrlDescNodo()
        {
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Sesion.Instancia.SesionIniciada)
            {

                 DataTable tnodos =  OraDalComponentes.NodoMgr.Instancia.GetTabla();
               // DataTable tnodos = OraDalComponentes.NodoMgr.Instancia.GetNodoPorFecha(DateTime.Now.Date);
                _cmbNodo.DisplayMember = Nodo.C_SIGLA_NODO;
                _cmbNodo.ValueMember = Nodo.C_PK_COD_NODO;
                _cmbNodo.DataSource = tnodos;
                    
            }
            base.OnLoad(e);
        }
        public void SeleccionarNodo(long pkCodNodo)
        {
            _cmbNodo.SelectedValue = pkCodNodo;
                        
        }
        public void SinDatos()
        {
            _cmbNodo.SelectedIndex = -1;
           
        }

        public long GetNodoSeleccionado()
        {
            return (long)_cmbNodo.SelectedValue;
        }

        public bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_cmbNodo.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbNodo, "Seleccione un nodo");
                resultado = false;
            }
            return resultado;
        }

        private void _cmbNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbNodo.SelectedValue == null)
            {
                _txtDescripcionNodo.Text = string.Empty;
                _txtNombreNodo.Text = string.Empty;
            }
            else
            {
                DataRow row = (_cmbNodo.SelectedItem as DataRowView).Row;
               _txtNombreNodo.Text  = ObjetoDeNegocio.GetValor<string>(row[Nodo.C_NOMBRE_NODO]);
               _txtDescripcionNodo.Text = ObjetoDeNegocio.GetValor<string>(row[Nodo.C_DESCRIPCION_NODO]);
            }

        }
    }
}
