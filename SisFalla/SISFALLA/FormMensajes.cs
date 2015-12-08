using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SISFALLA
{
    public partial class FormMensajes : Form
    {
        public FormMensajes()
        {
            InitializeComponent();
        }

        public void Visualizar(List<MensajeEmergente> mensajesNuevos)
        {
            ctrlPanelMensajes1.Visualizar(mensajesNuevos);
            Show();
        }
    }
}
