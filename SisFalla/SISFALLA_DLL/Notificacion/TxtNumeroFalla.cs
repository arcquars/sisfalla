using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controles;

namespace SISFALLA
{
    public class TxtNumeroFalla : CNDCMaskedTextBox
    {
        private int _numeroFalla;
        public TxtNumeroFalla()
        {
            this.Mask = "0000-00";
        }

        public int NumeroFalla
        {
            get
            {
                AsegurarNumero();
                return _numeroFalla;
            }
            set
            {
                _numeroFalla = value;
                VisualizarNumFalla();
            }
        }

        public int AnioFalla
        {
            get
            {
                int resultado = 0;
                string strNumFalla = Text;
                string[] arrayNumFalla = strNumFalla.Split('-');
                if (!int.TryParse(arrayNumFalla[1], out resultado))
                {
                    resultado = 0;
                }
                return resultado;
            }
        }

        private void AsegurarNumero()
        {
            string strNumFalla = Text;
            string[] arrayNumFalla = strNumFalla.Split('-');
            _numeroFalla = int.Parse(arrayNumFalla[1]) * 10000 + int.Parse(arrayNumFalla[0]);
        }

        private void VisualizarNumFalla()
        {
            if (_numeroFalla != 0)
            {
                string gestion = Completar((_numeroFalla / 10000).ToString(), 2);
                string falla = Completar((_numeroFalla % 10000).ToString(), 4);
                Text = falla + "-" + gestion;
            }
        }

        private string Completar(string valor, int cantidadDigitos)
        {
            while (valor.Length < cantidadDigitos)
            {
                valor = "0" + valor;
            }
            return valor;
        }
    }
}
