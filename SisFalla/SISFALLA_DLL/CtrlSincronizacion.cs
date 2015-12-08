using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SISFALLA
{
    public partial class CtrlSincronizacion : UserControl
    {
        List<MensajeEmergente> _mensajesNuevos;
        public CtrlSincronizacion()
        {
            InitializeComponent();
            _mensajesNuevos = new List<MensajeEmergente>();
        }

        public void Iniciar()
        {
            _btnVerMensajes.Visible = false;
            _pgBar.Visible = true;
            _pgBar.Dock = DockStyle.Fill;
        }

        public void Finalizar(List<MensajeEmergente> mensajes)
        {
            _pgBar.Visible = false;
            _btnVerMensajes.Visible = true;
            _btnVerMensajes.Dock = DockStyle.Fill;
            if (mensajes.Count > 0)
            {
                foreach (var m in mensajes)
                {
                    m.Borrado += new EventHandler(m_Borrado);
                    _mensajesNuevos.Insert(0, m);
                }
            }

            int leidos = ContarLeidos();
            if (leidos==_mensajesNuevos.Count)
            {
                _btnVerMensajes.Text = "No hay mensajes nuevos.";
            }
            else
            {
                _btnVerMensajes.Text = string.Format("Hay {0} mensaje(s) sin leer.", _mensajesNuevos.Count - leidos);
            }
        }

        void m_Borrado(object sender, EventArgs e)
        {
            _mensajesNuevos.Remove(sender as MensajeEmergente);
        }

        private int ContarLeidos()
        {
            int contador = 0;
            foreach (var item in _mensajesNuevos)
            {
                if (item.Leido)
                {
                    contador++;
                }
            }
            return contador;
        }

        private void _btnVerMensajes_Click(object sender, EventArgs e)
        {
            FormMensajes fMensajes = new FormMensajes();
            fMensajes.Visualizar(_mensajesNuevos);
        }
    }
}
