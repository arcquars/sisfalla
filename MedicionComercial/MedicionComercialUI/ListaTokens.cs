using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpresionesLib;

namespace MedicionComercialUI
{
    class ListaTokens
    {
        private List<TokenExpresion> _tokens;
        private int _cursor;
        public ListaTokens()
        {
            _tokens = new List<TokenExpresion>();
            _cursor = 0;
        }

        public void Insertar(string token)
        {
            _tokens.Insert(_cursor, new TokenExpresion(token));
            _cursor++;
        }

        public override string ToString()
        {
            return GetTexto(true);
        }

        public string GetTexto(bool incluirCursor)
        {
            StringBuilder sb = new StringBuilder(256);
            bool adicionarCursor = incluirCursor;
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (i == _cursor && adicionarCursor)
                {
                    sb.Append("|");
                    adicionarCursor = false;
                }

                TokenExpresion t = _tokens[i];
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(t.Token);
            }

            if (adicionarCursor)
            {
                sb.Append("|");
            }

            return sb.ToString();
        }

        public void AvanzarCursor()
        {
            if (_cursor < _tokens.Count)
            {
                _cursor++;
            }
        }

        public void LlevarCursorAlFinal()
        {
            _cursor = _tokens.Count;
        }

        public void LlevarCursorAlInicio()
        {
            _cursor = 0;
        }

        public void RetrocederCursor()
        {
            if (_cursor > 0)
            {
                _cursor--;
            }
        }

        public void Suprimir()
        {
            if (_cursor < _tokens.Count)
            {
                _tokens.RemoveAt(_cursor);
            }
        }

        public void Borrar()
        {
            if (_cursor > 0)
            {
                _tokens.RemoveAt(_cursor - 1);
                _cursor--;
            }
        }
    }
}
