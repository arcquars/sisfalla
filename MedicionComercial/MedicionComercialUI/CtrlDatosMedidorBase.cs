using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;
using CNDC.BaseForms;

namespace MedicionComercialUI
{
    public partial class CtrlDatosMedidorBase : QuantumBaseControl
    {
        protected AC_Medidor _medidor;
        public CtrlDatosMedidorBase()
        {
            InitializeComponent();
        }

        public AC_Medidor Medidor
        {
            get { return _medidor; }
            set { _medidor = value; }
        }

        public virtual void Visualizar()
        { 
        }
    }
}
