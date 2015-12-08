using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class FormSeriesHidrologicas : Form
    {
        public FormSeriesHidrologicas()
        {
            InitializeComponent();
            CargarSerieHidrologica();
        }

        private void CargarSerieHidrologica()
        {
            CtrlSeriesHidrolologicas ctrl = new CtrlSeriesHidrolologicas();
            this.Controls.Add(ctrl);
        }
    }
}
