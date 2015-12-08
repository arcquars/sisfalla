using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;
using CNDC.BLL;

namespace MedicionComercialUI
{
    public partial class CtrlSelecCanal : QuantumBaseControl
    {
        public CtrlSelecCanal()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Sesion.Instancia.SesionIniciada)
            {
                DataTable tablaCanales = OraDalMagnitudElectricaMgr.Instancia.GetTabla();
                _cmbCanal.DisplayMember = MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC;
                _cmbCanal.ValueMember = MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC;
                _cmbCanal.DataSource = tablaCanales;
                _txtDescripcion.DataBindings.Add("Text", tablaCanales, MagnitudElectrica.C_DESCRIPCION_MAG_ELEC);
                _txtUnidades.DataBindings.Add("Text", tablaCanales, MagnitudElectrica.C_UNIDADES);
            }
            base.OnLoad(e);
        }

        public void Seleccionar(long codInfCanal)
        {
            _cmbCanal.SelectedValue = codInfCanal;
        }

        public long GetCanalSeleccionado()
        {
            return (long)_cmbCanal.SelectedValue;
        }

        public bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_cmbCanal.SelectedValue == null)
            {
                resultado = false;
                _errorProvider.SetError(_cmbCanal, "Debe seleccionar un item de la lista");
            }
            return resultado;
        }
    }
}
