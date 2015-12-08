using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data;

namespace CNDC.BLL
{
    [Serializable]
    public class ObjetoDeNegocio
    {
        public string MensajeError { get; set; }
        public bool EsNuevo { get; set; }

        public string GetEstadoString()
        {
            return string.Empty;
        }

        public virtual void Leer(DataRow r)
        { 
        }

        public static T GetValor<T>(object obj)
        {
            T resultado = default(T);

            if (obj != null && !(obj is DBNull))
            {
                resultado = (T)obj;
            }
            return resultado;
        }

        public static T GetValor<T>(object obj, T defecto)
        {
            T resultado = defecto;
            if (!(obj is DBNull))
            {
                resultado = (T)obj;
            }
            return resultado;
        }

        public static DateTime GetDateTime(string s)
        {
            DateTime resultado;
            if (DateTime.TryParseExact(s, Sesion.FORMATO_FECHA, new System.Globalization.CultureInfo("es-bo"), System.Globalization.DateTimeStyles.None, out resultado))
                return resultado;
            return default(DateTime);
        }

        public static T Parse<T>(object value)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(value) ? (T)converter.ConvertFrom(value) : default(T);
        }

    }
}