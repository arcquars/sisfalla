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
using MenuQuantum;

namespace SISFALLA
{
    public partial class Dominio : BaseForm, IFuncionalidad
    {
        public Dominio()
        {
            InitializeComponent();
            CtrlOrdenMenu c = new CtrlOrdenMenu();
            c.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(c);
        }

        #region IFuncionalidad
        public Dictionary<string, string> Parametros { get; set; }
        public void Ejecutar()
        {
            ctrlConfiguracion1.CargarDatos();
            ctrlDominio1.CargarDatos();
            ShowDialog();
        }
        #endregion IFuncionalidad
    }
}
