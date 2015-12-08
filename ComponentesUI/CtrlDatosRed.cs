using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloComponentes;

namespace ComponentesUI
{
    public partial class CtrlDatosRed : CtrlBaseComponente, IControl
    {
        public CtrlDatosRed()
        {
            InitializeComponent();
            this.Deshabilitar();
            
        }

        public void Visualizar(Componente componenteSeleccionado)
        {
            DataTable nodorelacionado = OraDalComponentes.NodoMgr.Instancia.GetNodoPorFecha(componenteSeleccionado.PkCodComponente, DateTime.Now.Date);
            if (nodorelacionado.Rows.Count > 0)
            {
                long prueba=long.Parse(nodorelacionado.Rows[0]["pk_cod_nodo"].ToString());
                _ctrlDescNodoOrigen.SeleccionarNodo(long.Parse(nodorelacionado.Rows[0]["pk_cod_nodo"].ToString()));
            }
                DataTable pertenenciaSTI = OraDalComponentes.ComponenteMgr.Instancia.PerteneceSTI(componenteSeleccionado.PkCodComponente);
                if (pertenenciaSTI.Rows.Count > 0)
                {
                    _rbNo.Checked = false;
                    _rbSi.Checked = true;
                    _txtReferencia.Text = pertenenciaSTI.Rows[0]["REFERENCIA"].ToString();
                }
                else
                {
                    _rbNo.Checked = true;
                    _rbSi.Checked = false;
                    _txtReferencia.Text = string.Empty;
                }
            
        }
        public override void Deshabilitar()
        {
            base.Deshabilitar();
            _ctrlDescNodoOrigen.Enabled = false;
            _rbNo.Enabled = false;
            _rbSi.Enabled = false;
            _txtReferencia.Enabled = false;
        }

        public override void Habilitar()
        {
            base.Habilitar();
            _ctrlDescNodoOrigen.Enabled = true;
            _rbNo.Enabled = true;
            _rbSi.Enabled = true;
            _txtReferencia.Enabled = true;
        }


        public void Visualizar(Componente componenteSeleccionado, DateTime fechaConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
