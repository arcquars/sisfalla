using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CNDC.BaseForms
{
    public partial class FormMensajes : BaseForm
    {
        List<Mensaje> _mensajes;
        Font _fuente;
        public FormMensajes()
        {
            InitializeComponent();
            _fuente = new System.Drawing.Font("Arial", 10);
            _btnAbortar.Tag = DialogResult.Abort;
            _btnCacnelar.Tag = DialogResult.Cancel;
            _btnIgnorar.Tag = DialogResult.Ignore;
            _btnNo.Tag = DialogResult.No;
            _btnAceptar.Tag = DialogResult.OK;
            _btnReintentar.Tag = DialogResult.Retry;
            _btnSi.Tag = DialogResult.Yes;
        }

        public DialogResult Visualizar(Mensaje m)
        {
            return Visualizar("Quantum",m, BotonesDeMensaje.OK);
        }

        public DialogResult Visualizar(List<Mensaje> mensajes)
        {
            return Visualizar("Quantum",mensajes, BotonesDeMensaje.OK);
        }

        public DialogResult Visualizar(Mensaje m, BotonesDeMensaje botones)
        {
            return Visualizar("Quantum", m, botones);
        }

        public void Visualizar(string titulo, List<Mensaje> mensajes)
        {
            Visualizar(titulo, mensajes, BotonesDeMensaje.OK);
        }

        public DialogResult Visualizar(string titulo, Mensaje m, BotonesDeMensaje botones)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            mensajes.Add(m);
            return Visualizar(titulo, mensajes, botones);
        }

        public DialogResult Visualizar(string titulo,List<Mensaje> mensajes, BotonesDeMensaje botones)
        {
            Text = titulo;
            _mensajes = mensajes;
            switch (botones)
            {
                case BotonesDeMensaje.OK:
                    _btnAceptar.Visible = true;
                    break;
                case BotonesDeMensaje.OKCancel:
                    _btnAceptar.Visible = true;
                    _btnCacnelar.Visible = true;
                    break;
                case BotonesDeMensaje.AbortRetryIgnore:
                    _btnAbortar.Visible = true;
                    _btnReintentar.Visible = true;
                    _btnIgnorar.Visible = true;
                    break;
                case BotonesDeMensaje.YesNoCancel:
                    _btnSi.Visible = true;
                    _btnNo.Visible = true;
                    _btnCacnelar.Visible = true;
                    break;
                case BotonesDeMensaje.YesNo:
                    _btnSi.Visible = true;
                    _btnNo.Visible = true;
                    break;
                case BotonesDeMensaje.RetryCancel:
                    _btnReintentar.Visible = true;
                    _btnCacnelar.Visible = true;
                    break;
            }
            return ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int y = 30;
            foreach (Mensaje m in _mensajes)
            {
                if (!string.IsNullOrEmpty(m.Msg))
                {
                    SizeF si = e.Graphics.MeasureString(m.Msg, _fuente, this.Width - 90);
                    RectangleF r = new RectangleF(60, y, si.Width, si.Height);
                    e.Graphics.DrawString(m.Msg, _fuente, new SolidBrush(Color.Black), r);
                    Icon icono = null;
                    switch (m.Icono)
                    {
                        case IconoMsg.Error:
                            icono = System.Drawing.SystemIcons.Error;
                            break;
                        case IconoMsg.Pregunta:
                            icono = System.Drawing.SystemIcons.Question;
                            break;
                        case IconoMsg.Advertencia:
                            icono = System.Drawing.SystemIcons.Warning;
                            break;
                        case IconoMsg.Informacion:
                            icono = System.Drawing.SystemIcons.Information;
                            break;
                    }
                    if (icono != null)
                    {
                        e.Graphics.DrawIcon(icono, 25, y - 5);
                    }
                    y += (int)si.Height + 18;
                }
            }
            this.Height = y + 70;
        }

        private void _btn_Click(object sender, EventArgs e)
        {
            DialogResult = (DialogResult)(sender as Button).Tag;
        }
    }

    public class Mensaje
    {
        public string Msg { get; set; }
        public IconoMsg Icono { get; set; }
    }

    public enum BotonesDeMensaje
    {
        // Resumen:
        //     El cuadro de mensaje contiene un botón Aceptar.
        OK = 0,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Aceptar y otro Cancelar.
        OKCancel = 1,
        //
        // Resumen:
        //     El cuadro de mensaje contiene los botones Anular, Reintentar y Omitir.
        AbortRetryIgnore = 2,
        //
        // Resumen:
        //     El cuadro de mensaje contiene los botones Sí, No y Cancelar.
        YesNoCancel = 3,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Sí y otro No.
        YesNo = 4,
        //
        // Resumen:
        //     El cuadro de mensaje contiene un botón Reintentar y otro Cancelar.
        RetryCancel = 5,
    }

    public enum IconoMsg
    {
        // Resumen:
        //     El cuadro de mensaje no contiene ningún símbolo.
        Ninguno = 0,
        //
        // Resumen:
        //     El cuadro de mensaje está compuesto por un símbolo que consiste en una X
        //     blanca en un círculo con fondo rojo.
        Error = 16,
        //
        // Resumen:
        //     El cuadro de mensaje está compuesto por un símbolo que consiste en un signo
        //     de interrogación en un círculo. Ya no se recomienda el icono de mensaje de
        //     signo de interrogación porque no representa claramente un tipo específico
        //     de mensaje y porque la formulación de un mensaje como una pregunta puede
        //     aplicarse a cualquier tipo de mensaje. Además, los usuarios pueden confundir
        //     el signo de interrogación del mensaje con la información de ayuda. Por lo
        //     tanto, no utilice este símbolo de signo de interrogación en los cuadros de
        //     mensaje. El sistema seguirá admitiendo su inclusión únicamente por motivos
        //     de compatibilidad con las versiones anteriores.
        Pregunta = 32,
        //
        // Resumen:
        //     El cuadro de mensaje está compuesto por un símbolo que consiste en un signo
        //     de exclamación en un triángulo con fondo amarillo.
        Advertencia = 48,
        //
        // Resumen:
        //     El cuadro de mensaje está compuesto por un símbolo que consiste en un letra
        //     'i' minúscula en un círculo.
        Informacion = 64,        
    }
}
