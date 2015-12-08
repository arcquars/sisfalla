using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;
using CNDC.BLL;
using ExpresionesLib;

namespace MedicionComercialUI
{
    public partial class FormEditorFormula : ABMBaseForm
    {
        DataView _dvwPuntosMedicion;
        MC_PuntoMedicion _puntoMedicionSeleccionado;
        long _codMagnitudElecSeleccionada;
        ListaTokens _listaTokens;

        public FormEditorFormula()
        {
            _listaTokens = new ListaTokens();
            InitializeComponent();
        }

        public bool Editar(string formula)
        {
            _txtFormula.Text = formula;
            return ShowDialog() == DialogResult.OK;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                resultado = true;
                DialogResult = DialogResult.OK;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;

            return resultado;
        }

        protected override void OnLoad(EventArgs e)
        {
            _dvwPuntosMedicion = new DataView(OraDalMC_PuntoMedicionMgr.Instancia.GetTabla());
            _dgvPuntosMedicion.DataSource = _dvwPuntosMedicion;
        }

        private void _dgvPuntosMedicion_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvPuntosMedicion.SelectedRows.Count > 0)
            {
                DataRow rowSeleccionado = (_dgvPuntosMedicion.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _puntoMedicionSeleccionado = new MC_PuntoMedicion(rowSeleccionado);
                DataTable magnitudes = OraDalMC_RPuntoMedicionFormatoDetalleMgr.Instancia.GetMagnitudesPorPuntoMedicion(_puntoMedicionSeleccionado.PkCodPtoMedicion);
                _dgvMagnitudesElectricas.DataSource = magnitudes;
            }
        }

        private void _dgvMagnitudesElectricas_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMagnitudesElectricas.SelectedRows.Count>0)
            {
                DataRow rowSeleccionado = (_dgvMagnitudesElectricas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _codMagnitudElecSeleccionada = ObjetoDeNegocio.GetValor<long>(rowSeleccionado["pk_cod_magnitud_elec"]);
                _btnAdjuntar.Enabled = true;
            }
            else
            {
                _btnAdjuntar.Enabled = false;
            }
        }

        private void _btnAdjuntar_Click(object sender, EventArgs e)
        {
            AdicionarToken("PM" + _puntoMedicionSeleccionado.PkCodPtoMedicion + ".ME" + _codMagnitudElecSeleccionada);            
        }

        private void AdicionarToken(string t)
        {
            _listaTokens.Insertar(t);
            VisualizarTokens();
        }

        private void VisualizarTokens()
        {
            _txtFormula.Text = _listaTokens.ToString();
        }

        private void _btnIngresar_Click(object sender, EventArgs e)
        {
            double valorDouble = _txtConstante.ValorDouble;
            int valorInt = (int)valorDouble;
            if (valorDouble - valorInt > 0.0)
            {
                AdicionarToken(_txtConstante.Text);
            }
            else
            {
                AdicionarToken(valorInt.ToString());
            }
        }

        private void _btnSimbolo_Click(object sender, EventArgs e)
        {
            AdicionarToken((sender as Button).Text);
        }

        private void _btnRetrocederCursor_Click(object sender, EventArgs e)
        {
            _listaTokens.RetrocederCursor();
            VisualizarTokens();
        }

        private void _btnAvanzarCursor_Click(object sender, EventArgs e)
        {
            _listaTokens.AvanzarCursor();
            VisualizarTokens();
        }

        private void _btnBorrar_Click(object sender, EventArgs e)
        {
            _listaTokens.Borrar();
            VisualizarTokens();
        }

        private void _btnSuprimir_Click(object sender, EventArgs e)
        {
            _listaTokens.Suprimir();
            VisualizarTokens();
        }

        private void _btnCursorAlInicio_Click(object sender, EventArgs e)
        {
            _listaTokens.LlevarCursorAlInicio();
            VisualizarTokens();
        }

        private void _btnCursorAlFinal_Click(object sender, EventArgs e)
        {
            _listaTokens.LlevarCursorAlFinal();
            VisualizarTokens();
        }

        public string GetFormula()
        {
            return _listaTokens.GetTexto(false);
        }
    }
}
