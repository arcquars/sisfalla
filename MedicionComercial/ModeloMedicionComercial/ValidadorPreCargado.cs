using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MC
{
    public class ValidadorPreCargado : IValidadorLectura
    {
        public string Nombre
        {
            get { return "PreCarga"; }
        }

        public TipoValidador Tipo
        {
            get { return TipoValidador.Cargado; }
        }

        public Type TipoDato
        { get { return typeof(string); } }

        public bool Validar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            bool resultado = true;
            RegistroLectura ultimoEnBD = MC_LecturaMgr.Instancia.GetUltimoRegistroBD(resumen.PkCodPuntoMedicion);
            MC_IntervaloMaestro defIntervaloActual = MC_IntervaloMaestroMgr.Instancia.GetIntervaloPorFecha(DateTime.Now.Date);

            if (ultimoEnBD == null || ultimoEnBD.Fecha.AddMinutes(defIntervaloActual.PeriodoTiempo) == res.Registros[0].Fecha)
            {
                resumen[Nombre] = "OK";
            }
            else if (ultimoEnBD.Fecha.AddMinutes(defIntervaloActual.PeriodoTiempo) < res.Registros[0].Fecha)
            {//hay hueco 
                resumen[Nombre] = "Faltan Registros";
                resultado = false;
            }
            else
            {
                List<RegistroLectura> registrosAnteriores = MC_LecturaMgr.Instancia.GetRegistrosDesdeFecha(resumen.PkCodPuntoMedicion, res.Registros[0].Fecha.Date);
                MC_LecturaDetalle.EliminarDuplicados(resumen, res, parametros);
                MC_LecturaDetalle.EliminarFueraDeIntervalo(resumen, res, parametros);
                int i = 0, j = 0;
                for (; i < registrosAnteriores.Count && j < res.Registros.Count; i++)
                {
                    if (registrosAnteriores[i].Igual(res.Registros[j]))
                    {
                        res.Registros[j].MarcadoParaBorrar = true;
                    }
                    else
                    {
                        resumen[Nombre] = "Datos Inconsistentes";
                        resultado = false;
                    }
                    j++;
                }
                if (resultado)
                {
                    resumen[Nombre] = "OK";
                }
            }
            return resultado;
        }
    }

    public class ValidadorDuplicados : IValidadorLectura
    {
        public string Nombre
        {
            get { return "Reg.Duplicados"; }
        }

        public TipoValidador Tipo
        {
            get { return TipoValidador.Cargado; }
        }

        public Type TipoDato
        { get { return typeof(int); } }

        public bool Validar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            bool resultado = true;
            Dictionary<string, int> contadores = new Dictionary<string, int>();
            foreach (RegistroLectura registro in res.Registros)
            {
                string llave = registro.Fecha.Date.ToString("ddMMyy") + " " + registro.Hora;
                if (contadores.ContainsKey(llave))
                {
                    contadores[llave]++;
                }
                else
                {
                    contadores[llave] = 1;
                }
            }

            int registroRepetidos = 0;
            foreach (int c in contadores.Values)
            {
                if (c > 1)
                {
                    registroRepetidos++;
                }
            }

            resumen[Nombre] = registroRepetidos;
            return resultado;
        }
    }

    public class ValidadorFueraIntervalo : IValidadorLectura
    {
        public string Nombre
        {
            get { return "Fuera Interv."; }
        }

        public TipoValidador Tipo
        {
            get { return TipoValidador.Cargado; }
        }

        public Type TipoDato
        { get { return typeof(int); } }

        public bool Validar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            bool resultado = true;
            MC_IntervaloMaestro intervaloMaestro = MC_IntervaloMaestroMgr.Instancia.GetIntervaloPorFecha(DateTime.Now.Date);
            DataTable tabla = MC_IntervaloDetalleMgr.Instancia.GetPorPkCodMaestro(intervaloMaestro.PkCodIntervaloMaestro);
            Dictionary<string,long> horasIntervalos = new Dictionary<string,long>();
            foreach (DataRow r in tabla.Rows)
            {
                horasIntervalos.Add((string)r[MC_IntervaloDetalle.C_HORA_INTERVALO],(long)r[MC_IntervaloDetalle.C_PK_COD_INTERVALO]);
            }

            int contadorFueraIntervalo = 0;
            foreach (RegistroLectura registro in res.Registros)
            {
                if (horasIntervalos.ContainsKey(registro.Hora))
                {
                    foreach (DataRow row in registro.RowsItems)
                    {
                        row["CodIntervalo"] = horasIntervalos[registro.Hora];
                    }
                }
                else
                {
                    contadorFueraIntervalo++;
                }
            }

            resumen[Nombre] = contadorFueraIntervalo;
            return resultado;
        }
    }

    public class ValidadorRegFaltantes : IValidadorLectura
    {
        public string Nombre
        {
            get { return "Reg.Faltantes"; }
        }

        public TipoValidador Tipo
        {
            get { return TipoValidador.Consistencia; }
        }

        public Type TipoDato
        { get { return typeof(int); } }

        public bool Validar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            bool resultado = true;
            MC_IntervaloMaestro intervaloMaestro = MC_IntervaloMaestroMgr.Instancia.GetIntervaloPorFecha(DateTime.Now.Date);
            DataTable tabla = MC_IntervaloDetalleMgr.Instancia.GetPorPkCodMaestro(intervaloMaestro.PkCodIntervaloMaestro);
            List<string> horasIntervalos = new List<string>();
            Dictionary<DateTime, List<string>> dicVerifDatosInterv = new Dictionary<DateTime, List<string>>();
            
            foreach (DataRow r in tabla.Rows)
            {
                horasIntervalos.Add((string)r[MC_IntervaloDetalle.C_HORA_INTERVALO]);
            }

            int contadorFaltantes = 0;
            foreach (RegistroLectura registro in res.Registros)
            {
                if (!dicVerifDatosInterv.ContainsKey(registro.Fecha.Date))
                {
                    dicVerifDatosInterv[registro.Fecha.Date] = new List<string>();
                    foreach (string h in horasIntervalos)
                    {
                        dicVerifDatosInterv[registro.Fecha.Date].Add(h);
                    }
                }

                dicVerifDatosInterv[registro.Fecha.Date].Remove(registro.Hora);
            }

            int idx = 0;
            foreach (List<string> lista in dicVerifDatosInterv.Values)
            {
                if (idx > 0 && idx < dicVerifDatosInterv.Values.Count - 1)
                {
                    contadorFaltantes += lista.Count;
                }
                idx++;
            }

            resumen[Nombre] = contadorFaltantes;
            return resultado;
        }
    }
}
