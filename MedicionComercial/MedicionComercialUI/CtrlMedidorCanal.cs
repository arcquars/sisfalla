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

namespace MedicionComercialUI
{
    public partial class CtrlMedidorCanal : QuantumBaseControl
    {
        public CtrlMedidorCanal()
        {
            InitializeComponent();
        }

        public void Visualizar(MC_RPuntoMedicionFormatoDetalle _rMedidorCanalSeleccionado)
        {
            _ctrlSelecCanal.Seleccionar(_rMedidorCanalSeleccionado.FkCodMagnitudElec);
            _txtKC.ValorDouble = _rMedidorCanalSeleccionado.Kc;
            _txtKCT.ValorDouble = _rMedidorCanalSeleccionado.Kct;
            _txtKPT.ValorDouble = _rMedidorCanalSeleccionado.Kpt;
            _txtNumCanal.Text = _rMedidorCanalSeleccionado.Canal.ToString();
        }
    }
}
