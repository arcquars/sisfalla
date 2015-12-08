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
using CNDC.BLL;

namespace SISFALLA
{
    public partial class FormDominios : BaseForm
    {
        DefDominio _tDominio;
        string _tipoCodigo;

        public FormDominios()
        {
            InitializeComponent();
        }

        public DialogResult Editar(DefDominio a, string tipoCodigo)
        {
            _tDominio = a;
            _tipoCodigo = tipoCodigo;
            VisualizarDominio();
            return ShowDialog();
        }

        private void VisualizarDominio()
        {
            _txtDescParam.Text = _tDominio.Descripcion;
            if (_tDominio.Fec_inicio_dom == DateTime.MinValue)
            {
                _dtpFecInicio.Value = DateTime.Now;
            }
            else
            {
                _dtpFecInicio.Value = _tDominio.Fec_inicio_dom;
            }
            if (_tDominio.Fec_fin_dom == DateTime.MinValue)
            {
                _dtpFecFin.Value = DateTime.Now;
            }
            else
            {
                _dtpFecFin.Value = _tDominio.Fec_fin_dom;
            }
           _txtComentario.Text = _tDominio.Comentario_dom;
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _tDominio.Descripcion = _txtDescParam.Text;
                _tDominio.Comentario_dom = _txtComentario.Text;
                _tDominio.Fec_inicio_dom = !(_dtpFecInicio.Value == DateTime.MinValue) ? _dtpFecInicio.Value : DateTime.MinValue;
                _tDominio.Fec_fin_dom = !(_dtpFecFin.Value == DateTime.Now)?_dtpFecFin.Value:DateTime.MinValue;
                _tDominio.DCodTipo = _tipoCodigo;
                _tDominio.DCodEstado = "1";

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();

            if (_txtDescParam.Text == "")
            {
                _errorProvider.SetError(_txtDescParam, "Debe ingresar un Valor distinto a vacio.");
                resultado = false;
            }
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
