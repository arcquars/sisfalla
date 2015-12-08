using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;

namespace SISFALLA.Informe
{
    public partial class AnalisisFalla : ABMBaseForm
    {
        public AnalisisFalla()
        {
            InitializeComponent();
        }

        private void _btnComponente_Click(object sender, EventArgs e)
        {
            SeleccionComponenteDialog s = new SeleccionComponenteDialog();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              
            }
        }


        private void _btnAdjuntarAnalisis_Click(object sender, EventArgs e)
        {
            String input = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos pdf (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
            dialog.InitialDirectory = "C:";

            dialog.Title = "Seleccionar Archivo de Analisis de Falla";

            if (dialog.ShowDialog() == DialogResult.OK)

                _lblArchivoAnalisisFalla.Text = dialog.FileName;

            if (_lblArchivoAnalisisFalla.Text == String.Empty)

                return;



        }

    }
}
