using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISFALLA
{
    public partial class SplashQuantum : Form
    {
        public SplashQuantum()
        {
            InitializeComponent();
        }

        public void SetEstadoSincronizacion(int actual, int total, string texto )
        {
            if (cndcProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                cndcLabel1.Text = texto;
                cndcProgressBar1.Style = ProgressBarStyle.Blocks;
            }
            cndcProgressBar1.Maximum = total;
            cndcProgressBar1.Value = actual;
            Application.DoEvents();
        }
    }
}
