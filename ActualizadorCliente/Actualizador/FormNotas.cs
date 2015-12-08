using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Actualizador
{
    public partial class FormNotas : Form
    {
        public FormNotas()
        {
            InitializeComponent();
        }

        public void VisualizarNotas(string archivoNotas)
        {
            StreamReader r = new StreamReader(archivoNotas);

            while (!r.EndOfStream)
            {
                string linea = r.ReadLine();
                _txtResumenActualizacion.Text += linea + Environment.NewLine;
            }

            r.Close();
            ShowDialog();
        }

    }
}
