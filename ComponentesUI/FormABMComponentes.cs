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


namespace ComponentesUI
{
    public partial class FormABMComponentes : BaseForm,IFuncionalidad
    {
        public FormABMComponentes()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmComponente frm = new FrmComponente();
            frm.Show();
        }
       
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
        }



        public ParametrosFuncionalidad Parametros
        {
            get;
            set;
            
        }

        public void Ejecutar()
        {
            ShowDialog();
        }
    }
}

