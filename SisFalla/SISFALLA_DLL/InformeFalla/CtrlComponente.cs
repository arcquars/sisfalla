using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.Dominios;
using CNDC.BLL;

namespace SISFALLA
{
    public partial class CtrlComponente : UserControl
    {
        Componente _componente;
        List<D_TIPO_COMPONENTE> _filtroTipo;
        public event EventHandler ComponenteSeleccionadoPorUsuario;
        private List<long> _componenteNoSeleccionables;
        public CtrlComponente()
        {
            InitializeComponent();
            _componenteNoSeleccionables = new List<long>();
        }

        public Componente Componente
        {
            get { return _componente; }
            set
            {
                _componente = value;
                VisualizarComponente();
            }
        }

        public decimal PkCodComponente
        {
            get
            {
                if (_componente == null)
                {
                    return 0;
                }
                else
                {
                    return _componente.PkCodComponente;
                }
            }
            set
            {
                VisualizarComponente(value);
            }
        }

        public string TextoBoton
        {
            get { return _btnSeleccionarComponente.Text; }
            set { _btnSeleccionarComponente.Text = value; }
        }

        public int AnchoBoton
        {
            get { return _btnSeleccionarComponente.Width; }
            set
            {
                int diferencia = value - _btnSeleccionarComponente.Width; 
                _btnSeleccionarComponente.Width = value;
                //this.Width += diferencia;

                //_txtAgente.Left += diferencia;
                //_txtDescComponente.Left += diferencia;
                _txtNombreComponente.Left += diferencia;
                _txtNombreComponente.Width -= diferencia;
            }
        }

        public void SetComponenteNoSeleccionables(List<long> componenteNoSeleccionables)
        {
            _componenteNoSeleccionables = componenteNoSeleccionables;
        }

        public void SetFiltroTipo(List<D_TIPO_COMPONENTE> filtroTipo)
        {
            _filtroTipo = filtroTipo;
        }

        public void VisualizarComponente(decimal pkCodComponente)
        {
            if (pkCodComponente == 0)
            {
                _componente = null;
            }
            else
            {
                _componente = ModeloMgr.Instancia.ComponenteMgr.GetComponente(pkCodComponente);
            }
            VisualizarComponente();
        }

        private void LimpiarCampos()
        {
            _txtDescComponente.Text = string.Empty;
            _txtNombreComponente.Text = string.Empty;
        }

        private void _btnSeleccionarComponente_Click(object sender, EventArgs e)
        {
            SeleccionComponenteDialog s = new SeleccionComponenteDialog();
            s.SetFiltroTipo(_filtroTipo, _componenteNoSeleccionables);
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _componente = s.ComponenteSeleccionado;
                VisualizarComponente();
                OnComponenteSeleccionadoPorUsuario();
            }
        }

        private void OnComponenteSeleccionadoPorUsuario()
        {
            if (ComponenteSeleccionadoPorUsuario != null)
            {
                ComponenteSeleccionadoPorUsuario(this, EventArgs.Empty);
            }
        }

        private void VisualizarComponente()
        {
            if (_componente == null)
            {
                LimpiarCampos();
            }
            else
            {
                _txtDescComponente.Text = _componente.Descripcion;
                _txtNombreComponente.Text = _componente.NombreComponente;
                Persona p = OraDalPersonaMgr.Instancia.GetAgente(_componente.Propietario);
                _txtAgente.Text = p.Nomcodagente;
            }
        }
    }

    public enum TipoCtrlCompComprometido
    {
        Visualizador,
        Selector
    }
}
