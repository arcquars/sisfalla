using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.Dominios;
using CNDC.ExceptionHandlerLib;
using CNDC.BLL;

namespace SISFALLA
{
    public partial class FormReleOperado : ABMBaseForm, IReleOperado
    {
        RelesOperados _releOperado = null;
        public FormReleOperado()
        {
            InitializeComponent();
        }
        List<string> _funcionesUsadas;
        public DialogResult Editar(RelesOperados releOperado, List<string> funcionesUsadas)
        {
            _releOperado = releOperado;
            _funcionesUsadas = funcionesUsadas;
            CargarFunciones();
            VisualizarRele();
            return ShowDialog();
        }

        private void CargarFunciones()
        {
            BindingList<DefDominio> funciones = ModeloMgr.Instancia.DefDominioMgr.GetListaDominio(Dominios.D_COD_FUNCION);
            _cmbFuncion.DisplayMember = "Descripciones";
            _cmbFuncion.ValueMember = "CodDominio";
            _cmbFuncion.DataSource = funciones;

            foreach (string f in _funcionesUsadas)
            {
                for (int i = funciones.Count - 1; i >= 0; i--)
                {
                    if (funciones[i].Descripciones == f)
                    {
                        funciones.RemoveAt(i);
                    }
                }
            }
        }

        private void VisualizarRele()
        {
            Distancia = _releOperado.Distancia;
            Funcion = _releOperado.Funcion;
            Tiempo = _releOperado.Tiempo;
            TipoRele = _releOperado.TipoRele;
            Zona = _releOperado.Zona;

            _cmbFuncion.Enabled = _releOperado.EsNuevo;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            _releOperado.Distancia =(double ) Distancia;
            _releOperado.Funcion = Funcion;
            _releOperado.Tiempo = Tiempo;
            _releOperado.TipoRele = TipoRele;
            _releOperado.Zona = Zona;

            if (_releOperado.Zona == 0 || _releOperado.Distancia == 0)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("DIST_ZONA_NO_REGISTRADOS"), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            resultado = true;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            return resultado;
        }

        protected override bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (Distancia != _releOperado.Distancia)
            {
                resultado = true;
            }

            if (Funcion != Asegurar(_releOperado.Funcion))
            {
                resultado = true;
            }

            if (Tiempo != _releOperado.Tiempo)
            {
                resultado = true;
            }

            if (TipoRele != Asegurar(_releOperado.TipoRele))
            {
                resultado = true;
            }

            if (Zona != _releOperado.Zona)
            {
                resultado = true;
            }
            return resultado;
        }

        private string Asegurar(string p)
        {
            return p == null ? string.Empty : p;
        }

        #region IReleOperado
        public double Distancia
        {
            get {
                double val = (double)_txtDistancia.ValDouble ;
                
                return val; 
            
            }
            set { _txtDistancia.Value = (float)value; }
        }

        public string Funcion
        {
            get { return _cmbFuncion.Text; }
            set { _cmbFuncion.Text = value; }
        }

        public double Tiempo
        {
            get
            {
                double val = (double)_txtTiempo.Value ;

                return val;
            }
            set { _txtTiempo.Value = (int)value; }
        }

        public string TipoRele
        {
            get { return _txtTipoRele.Text; }
            set { _txtTipoRele.Text = value; }
        }

        public double Zona
        {
            get { return _txtZona.Value; }
            set { _txtZona.Value = (int)value; }
        }
        #endregion
    }
}
