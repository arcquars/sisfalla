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
    public partial class CtrlDefCanal : QuantumBaseControl
    {
        MagnitudElectrica _magnitudElecSeleccionada;
        public CtrlDefCanal()
        {
            InitializeComponent();
        }

        public void Visualizar(MagnitudElectrica magnitudElectrica)
        {
            _magnitudElecSeleccionada = magnitudElectrica;
            _txtDescripcion.Text = _magnitudElecSeleccionada.DescripcionMagElec;
            _txtEstado.Text = _magnitudElecSeleccionada.DCodEstado;
            _txtNombre.Text = _magnitudElecSeleccionada.NombreMagnitudElec;
            _txtUnidades.Text = _magnitudElecSeleccionada.Unidades;
        }
    }
}
