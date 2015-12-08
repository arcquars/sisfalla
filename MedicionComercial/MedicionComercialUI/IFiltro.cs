using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MC;

namespace MedicionComercialUI
{
    public interface IFiltro<T>
    {
        bool CumpleCondicion(T elemento);
    }

    public class FiltroCompuesto<T> : IFiltro<T>
    {
        private List<IFiltro<T>> _filtros;

        public FiltroCompuesto()
        {
            _filtros = new List<IFiltro<T>>();
        }

        public void AdicionarFiltro(IFiltro<T> filtro)
        {
            if (!_filtros.Contains(filtro))
            {
                _filtros.Add(filtro);
            }
        }

        public void QuitarFiltro(IFiltro<T> filtro)
        {
            if (_filtros.Contains(filtro))
            {
                _filtros.Remove(filtro);
            }
        }

        public bool CumpleCondicion(T elemento)
        {
            bool resultado = true;
            foreach (IFiltro<T> f in _filtros)
            {
                if (!f.CumpleCondicion(elemento))
                {
                    resultado = false;
                    break;
                }
            }
            return resultado;
        }
    }

    public class FiltroMedidor : IFiltro<ResumenLecturaMedidor>
    {
        public bool Activo { get; set; }
        private string _criterio;

        public FiltroMedidor()
        {
            _criterio = string.Empty;
        }

        public string Criterio
        {
            get { return _criterio; }
            set
            {
                _criterio = value;
                if (_criterio == null)
                {
                    _criterio = string.Empty;
                }
            }
        }

        public bool CumpleCondicion(ResumenLecturaMedidor elemento)
        {
            bool resultado = true;
            if (Activo)
            {
                resultado = elemento.NombrePuntoMedicion == null ? true : elemento.NombrePuntoMedicion.ToUpper().Contains(_criterio.ToUpper());
            }
            return resultado;
        }
    }

    public class FiltroAgente : IFiltro<ResumenLecturaMedidor>
    {
        public bool Activo { get; set; }
        public long CodAgente { get; set; }

        public bool CumpleCondicion(ResumenLecturaMedidor elemento)
        {
            bool resultado = true;
            if (Activo)
            {
                resultado = CodAgente == elemento.FkCodPropietario;
            }
            return resultado;
        }
    }
}
