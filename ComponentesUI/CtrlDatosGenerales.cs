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
using ModeloComponentes;
using OraDalComponentes;

namespace ComponentesUI
{
    public partial class CtrlDatosGenerales : CtrlBaseComponente, IControl
    {
        public Componente componenteActual;
        public CtrlDatosGenerales()
        {
            InitializeComponent();
            Deshabilitar();
        }

        public void Visualizar(Componente componenteSeleccionado)
        {
            _tipoComponente = componenteSeleccionado.DTipoComponente;
            componenteActual = componenteSeleccionado;
            DefDominioMgr _dominiomgr=new DefDominioMgr();
            DataTable _persona = CNDC.BLL.OraDalPersonaMgr.Instancia.GetAgentes();
            _cmbPropietario.DisplayMember = "nom_cod_agente";
            _cmbPropietario.ValueMember = "pk_cod_persona";
            _cmbPropietario.DataSource = _persona;
            _cmbPropietario.SelectedValue = (long)componenteSeleccionado.Propietario;
            _txtNombreComponente.Text = componenteSeleccionado.NombreComponente;
            _txtIDUniversal.Text = componenteSeleccionado.CodigoComponente;
            _txtDescComponente.Text = componenteSeleccionado.Descripcion;
            _dtpFechaIngreso.Value = componenteSeleccionado.FechaIngreso;
           
            
            if (componenteSeleccionado.FechaSalida.Year == 1)
            {
                _dtpFechaSalida.Visible = false;
                _chkFechaSalida.Checked = false;

            }
            else
            {
                _dtpFechaSalida.Visible = true;
                _chkFechaSalida.Checked = true;
                _dtpFechaSalida.Value = componenteSeleccionado.FechaSalida;
            }
          /*  DataTable _equivalencia = _dominiomgr.GetDominio("D_EQUIVALENCIA");
            _cmbEquivalencia.DisplayMember = "descripcion_dominio";
            _cmbEquivalencia.ValueMember = "cod_dominio";
            _cmbEquivalencia.DataSource = _equivalencia;
            _cmbEquivalencia.SelectedValue = (long)componenteSeleccionado.DEquivalencia;
            */
        }

     
        public override void Habilitar()
        {
            this._txtNombreComponente.Enabled = true;
            this._txtDescComponente.Enabled = true;
            this._txtIDUniversal.Enabled = true;
            this._dtpFechaIngreso.Enabled = true;
            //this._dtpFechaSalida.Enabled = true;
            this._dtpFechaVigencia.Enabled = true;
            //this._chkFechaSalida.Enabled = true;
            this._cmbPropietario.Enabled = true;
            this._cmbEquivalencia.Enabled = true;
            if (this._esNuevo)
            {
                DataTable _persona = CNDC.BLL.OraDalPersonaMgr.Instancia.GetAgentes();
                _cmbPropietario.DisplayMember = "nom_cod_agente";
                _cmbPropietario.ValueMember = "pk_cod_persona";
                _cmbPropietario.DataSource = _persona;
                DefDominioMgr _dominiomgr = new DefDominioMgr();
                DataTable _equivalencia =  _dominiomgr.GetDominio("D_EQUIVALENCIA");
                _cmbEquivalencia.DisplayMember = "descripcion_dominio";
                _cmbEquivalencia.ValueMember = "cod_dominio";
                _cmbEquivalencia.DataSource = _equivalencia;
            }
            this._enEdicion = true;
           
        }
        public override void Deshabilitar()
        {
            this._txtNombreComponente.Enabled = false;
            this._txtDescComponente.Enabled = false;
            this._txtIDUniversal.Enabled = false;
            this._dtpFechaIngreso.Enabled = false;
            this._dtpFechaSalida.Enabled = false;
            this._dtpFechaVigencia.Enabled = false;
            this._chkFechaSalida.Enabled = false;
            this._cmbPropietario.Enabled = false;
            this._cmbEquivalencia.Enabled = false;
            this._enEdicion = false;
        }

        public override void _tSBCancelar_Click(object sender, EventArgs e)
        {
            if (!this._esNuevo)
            {
                Visualizar(componenteActual);
            }
            base._tSBCancelar_Click(null,e);
        }

        public override bool Guardar()
        {
            Componente nuevoComponente = new Componente();
                nuevoComponente = CargarComponente();
                if (this._esNuevo)
                {
                    // Nuevo();
                    nuevoComponente.EsNuevo = true;
                    ComponenteMgr.Instancia.GuardarComponente(nuevoComponente);
                }
                else
                {
                    nuevoComponente.EsNuevo = false;
                    nuevoComponente.PkCodComponente = componenteActual.PkCodComponente;
                    ComponenteMgr.Instancia.GuardarComponente(nuevoComponente);
                }
                Visualizar(nuevoComponente);
            return true;
                        
        }

        
        
        private Componente CargarComponente()
        {
            Componente resultado=new Componente();
            resultado.NombreComponente = _txtNombreComponente.Text;
            resultado.Descripcion = _txtDescComponente.Text;
            resultado.DTipoComponente = _tipoComponente;
            resultado.FechaIngreso = _dtpFechaIngreso.Value;
            resultado.Propietario = long.Parse(_cmbPropietario.SelectedValue.ToString());
            resultado.CodigoComponente = _txtIDUniversal.Text;
            //resultado.DEquivalencia = long.Parse(_cmbEquivalencia.SelectedValue.ToString());
            return resultado;
        }
       /* public override void Nuevo()
        {
            Componente nuevoComponente = new Componente();
            nuevoComponente=CargarComponente();
            nuevoComponente.EsNuevo = true;
            MessageBox.Show("Insertando nuevo registro");
        }*/

        private void _chkFechaSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkFechaSalida.Checked)
            {
                _dtpFechaSalida.Visible = true;
            }
            else
            {
                _dtpFechaSalida.Visible = false;
            }
        }



        public void Visualizar(Componente componenteSeleccionado, DateTime fechaConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
