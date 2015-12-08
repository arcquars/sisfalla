using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CNDC.BaseForms
{
    public class PanelComandos : Control
    {
        List<Comando> _comandos;
        Dictionary<Comando, Button> _dicBotones;
        public PanelComandos()
        {
            _comandos = new List<Comando>();
            _dicBotones = new Dictionary<Comando, Button>();
            BackColor = Color.FromArgb(162, 183, 213);
        }

        public void AdicionarComando(Comando cmd)
        {
            if (!_comandos.Contains(cmd))
            {
                _comandos.Add(cmd);
                _dicBotones[cmd] = GetBoton(cmd);
                cmd.TextoModificado += new EventHandler(cmd_TextoModificado);
            }
        }

        void cmd_TextoModificado(object sender, EventArgs e)
        {
            Comando cmd = sender as Comando;
            _dicBotones[cmd].Text = cmd.Texto;
        }

        private Button GetBoton(Comando cmd)
        {
            BotonComando resultado = new BotonComando();
            resultado.Cmd = cmd;
            if (cmd.Imagen != null)
            {
                resultado.Image = cmd.Imagen;
                resultado.ImageAlign = ContentAlignment.MiddleLeft;
                resultado.TextAlign = ContentAlignment.MiddleRight;
            }
            resultado.Text = cmd.Texto;
            resultado.Size = cmd.Tamanio;
            resultado.Visible = false;
            resultado.Click += new EventHandler(resultado_Click);
            this.Controls.Add(resultado);
            return resultado;
        }

        void resultado_Click(object sender, EventArgs e)
        {
            (sender as BotonComando).Cmd.Ejecutar();
            if (Visible)
            {
                Acomodar();
            }
        }

        public void Acomodar()
        {
            int xIzq = 0, xDer = this.Width;

            foreach (var cmd in _comandos)
            {
                if (cmd.GetVisible())
                {
                    _dicBotones[cmd].Visible = true;
                    if (cmd.Alineacion == TipoAlineamiento.Izquierda)
                    {
                        _dicBotones[cmd].Left = xIzq;
                        xIzq += _dicBotones[cmd].Width + 1;
                    }
                    else
                    {
                        xDer -= _dicBotones[cmd].Width;
                        _dicBotones[cmd].Left = xDer;
                        xDer -= 1;
                    }
                }
                else
                {
                    _dicBotones[cmd].Visible = false;
                }
            }
        }
    }

    public abstract class Comando
    {

        private string _texto;
        public Image Imagen { get; set; }
        
        public Size Tamanio { get; set; }
        public TipoAlineamiento Alineacion { get; set; }
        public event EventHandler TextoModificado;
        public event EventHandler ClickButton;
       

        public Comando()
        {
            _texto = string.Empty;
        }

        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                OnTextoModificado();
            }
        }

        protected void OnTextoModificado()
        {
            if (TextoModificado != null)
            {
                TextoModificado(this, EventArgs.Empty);
            }
        }

        public abstract void Ejecutar();
        public abstract bool GetVisible();
    }

    public enum TipoAlineamiento
    {
        Izquierda,
        Derecha
    }

    public class BotonComando : Button
    {
        public Comando Cmd { get; set; }
        public BotonComando()
        {
            UseVisualStyleBackColor = true;
        }
    }
}
