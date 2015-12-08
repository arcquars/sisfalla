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
    public delegate void Tarea();
    public partial class FormTareaAsincrona : Form
    {
        Tarea _tarea;
        public FormTareaAsincrona()
        {
            InitializeComponent();
        }

        public void Visualizar(string titulo, string mensaje, Tarea t)
        {
            _tarea = t;
            Text = titulo;
            _lblMensaje.Text = mensaje;
            _bgWorker.RunWorkerAsync();
            ShowDialog();
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _tarea.Invoke();
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult =  DialogResult.OK;
        }
    }
}
