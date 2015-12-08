using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrlDatosPuntoMedicionBase : UserControl
    {
        protected MC_PuntoMedicion _puntoMedicion;
        public CtrlDatosPuntoMedicionBase()
        {
            InitializeComponent();
        }

        public MC_PuntoMedicion PuntoMedicion
        {
            get { return _puntoMedicion; }
            set { _puntoMedicion = value; }
        }

        public virtual void Visualizar()
        { 
        }
    }
}
