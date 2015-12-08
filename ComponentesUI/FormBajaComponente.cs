using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using ModeloComponentes;

namespace ComponentesUI
{
    public partial class FormBajaComponente : BaseForm, IFuncionalidad
    {
        public FormBajaComponente()
        {
            InitializeComponent();
            MostrarComponentes();
        }

        public ParametrosFuncionalidad Parametros
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Ejecutar()
        {
            ShowDialog();
        }
        private void MostrarComponentes()
        {
            // gridControl1.DataSource = OraDalComponentes.ComponenteMgr.Instancia.GetComponenteCompleto();
            DataTable listaComponente = OraDalComponentes.ComponenteMgr.Instancia.GetComponenteCompleto();

           
        }

    }
}
