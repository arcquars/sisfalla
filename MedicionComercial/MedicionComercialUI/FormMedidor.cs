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

namespace MedicionComercialUI
{
    public partial class FormMedidor : ABMBaseForm
    {
        AC_Medidor _medidorSeleccionado;
        public FormMedidor()
        {
            InitializeComponent();
        }

        public bool Editar(AC_Medidor medidor)
        {
            bool resultado = false;
            _medidorSeleccionado = medidor;
            Visualizar();
            if (ShowDialog() == DialogResult.OK)
            {
                resultado = true;
            }
            return resultado;
        }

        private void Visualizar()
        {
            if (_medidorSeleccionado.RealVirtual == 1)
            {
                _rbtnReal.Checked = true;
            }
            else
            {
                _rbtnVirtual.Checked = true;
            }

            _txtNombre.Text = _medidorSeleccionado.Nombre;
            _txtDescripcion.Text = _medidorSeleccionado.Descripcion;
            _txtMarca.Text = _medidorSeleccionado.Marca;
            _txtModelo.Text = _medidorSeleccionado.Modelo;
            _txtPresicion.ValorDecimal = _medidorSeleccionado.Precision;
            _txtPrimeNoins.Text = _medidorSeleccionado.PrimeNoins;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _medidorSeleccionado.Nombre = _txtNombre.Text;
                _medidorSeleccionado.Descripcion = _txtDescripcion.Text;
                _medidorSeleccionado.Marca = _txtMarca.Text;
                _medidorSeleccionado.Modelo = _txtModelo.Text;
                _medidorSeleccionado.Precision = _txtPresicion.ValorDecimal;
                _medidorSeleccionado.PrimeNoins = _txtPrimeNoins.Text;
                if (_rbtnReal.Checked)
                {
                    _medidorSeleccionado.RealVirtual = 1;
                }
                else
                {
                    _medidorSeleccionado.RealVirtual = 0;
                }
                OraDalMedidorMgr.Instancia.Guardar(_medidorSeleccionado);
                DialogResult = DialogResult.OK;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            _txtNombre.Text = _txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(_txtNombre.Text))
            {
                resultado = false;
                _errorProvider.SetError(_txtNombre, "Ingrese el nombre del Medidor");
            }
            
            return resultado;
        }
    }
}
