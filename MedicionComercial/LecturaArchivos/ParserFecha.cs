using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LecturaArchivos
{
    public class ParserFecha
    {
        #region Singleton
        private static ParserFecha _instancia;
        public static ParserFecha Instancia
        { get { return _instancia; } }

        static ParserFecha()
        { _instancia = new ParserFecha(); }

        private ParserFecha()
        { 
        }
        #endregion Singleton

        public DateTime? GetFecha(string cadena)
        {
            DateTime? resultado = null;
            return resultado;
        }

        public DateTime? GetFechaConHora(string cadena)
        {
            DateTime? resultado = null;
            return resultado;
        }
    }
}
