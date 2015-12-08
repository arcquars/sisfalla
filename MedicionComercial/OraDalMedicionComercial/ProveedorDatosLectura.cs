using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpresionesLib;
using System.Data;

namespace MC
{
    public class ProveedorDatosLectura : IProveedorDatos
    {
        private DateTime _desde;
        private DateTime _hasta;
        private long _codIntervalo;
        private DateTime _fecha;
        Dictionary<long, Dictionary<DateTime, Dictionary<long, Dictionary<long, double>>>> _valores;

        public ProveedorDatosLectura(DateTime desde, DateTime hasta)
        {
            _desde = desde;
            _hasta = hasta;
            _valores = new Dictionary<long, Dictionary<DateTime, Dictionary<long, Dictionary<long, double>>>>();
        }

        public double GetValor(string variable)
        {
            double resultado = 0;
            string[] datos = variable.Split('.');
            long codPuntoMedicion = long.Parse(datos[0].Substring(2));
            long codMagnitudElec = long.Parse(datos[1].Substring(2));

            if (!_valores.ContainsKey(codPuntoMedicion))
            {
                _valores[codPuntoMedicion] = LeerDatosLectura(codPuntoMedicion);
            }
            resultado = _valores[codPuntoMedicion][_fecha][_codIntervalo][codMagnitudElec];

            return resultado;
        }

        private Dictionary<DateTime, Dictionary<long, Dictionary<long, double>>> LeerDatosLectura(long codPuntoMedicion)
        {
            Dictionary<DateTime, Dictionary<long, Dictionary<long, double>>> resultado = new Dictionary<DateTime, Dictionary<long, Dictionary<long, double>>>();
            DataTable tablaDatos = OraDalMC_LecturaDetalleMgr.Instancia.GetDatos(codPuntoMedicion, _desde, _hasta);
            foreach (DataRow r in tablaDatos.Rows)
            {
                long codIntervalo = (long)r["pk_cod_intervalo"];
                long codMagnitudElec = (long)r["pk_cod_magnitud_elec"];
                double valor = (double)r["valor"];
                DateTime fecha = (DateTime)r["pk_fecha"];
                if (!resultado.ContainsKey(fecha))
                {
                    resultado[fecha] = new Dictionary<long, Dictionary<long, double>>();
                }
                if (!resultado[fecha].ContainsKey(codIntervalo))
                {
                    resultado[fecha][codIntervalo] = new Dictionary<long, double>();
                }

                resultado[fecha][codIntervalo][codMagnitudElec] = valor;
            }
            return resultado;
        }

        public void SetIntervalo(long codIntervalo)
        {
            _codIntervalo = codIntervalo;
        }

        public void SetFecha(DateTime f)
        {
            _fecha = f;
        }
    }
}
