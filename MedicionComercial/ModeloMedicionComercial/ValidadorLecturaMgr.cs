using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.UtilesComunes;

namespace MC
{
    public class ValidadorLecturaMgr
    {
        #region Singleton
        private static ValidadorLecturaMgr _instancia;
        public static ValidadorLecturaMgr Instancia
        {
            get { return _instancia; }
        }

        static ValidadorLecturaMgr()
        {
            _instancia = new ValidadorLecturaMgr();
        }

        private ValidadorLecturaMgr()
        {
            Inicializar();
        }
        #endregion Singleton

        private List<IValidadorLectura> _validadores;

        private void Inicializar()
        {
            _validadores = Instanciador.Instancia.IntanciarTodos<IValidadorLectura>();
        }

        public IEnumerable<IValidadorLectura> GetValidadores()
        {
            return _validadores;
        }

        public bool AplicarValidaciones(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros, TipoValidador tipo)
        {
            bool resultado = true;
            foreach (IValidadorLectura v in _validadores)
            {
                if (v.Tipo == tipo)
                {
                    resultado = resultado && v.Validar(resumen, res, parametros);
                }
            }
            return resultado;
        }
    }

    public interface IValidadorLectura
    {
        string Nombre { get; }
        TipoValidador Tipo { get; }
        bool Validar(ResumenLecturaMedidor r, ResultadoLectura res, ParametrosLectura parametros);
        Type TipoDato { get; }
    }

    public enum TipoValidador
    {
        Cargado,
        Consistencia
    }
}
