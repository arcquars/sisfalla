using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace MC
{
    [Serializable]
    public class MC_LecturaDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_LECTURA_DETALLE";

        public const string C_PK_COD_LECTURA = "PK_COD_LECTURA";
        public const string C_PK_FECHA = "PK_FECHA";
        public const string C_PK_COD_INTERVALO = "PK_COD_INTERVALO";
        public const string C_PK_COD_MAGNITUD_ELEC = "PK_COD_MAGNITUD_ELEC";
        public const string C_VALOR = "VALOR";
        public const string C_ESTADO = "ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_D_COD_ORIGEN = "D_COD_ORIGEN";
        public const string C_FK_COD_PUNTO_MEDICION = "FK_COD_PUNTO_MEDICION";

        public long PkCodLectura { get; set; }
        public DateTime PkFecha { get; set; }
        public long PkCodIntervalo { get; set; }
        public long PkCodMagnitudElec { get; set; }
        public double Valor { get; set; }
        public int Estado { get; set; }
        public long SecLog { get; set; }
        public long DCodOrigen { get; set; }
        public long FkCodPuntoMedicion { get; set; }

        public MC_LecturaDetalle() { }

        public MC_LecturaDetalle(DataRow dataRow)
        {
            PkCodLectura = GetValor<long>(dataRow[C_PK_COD_LECTURA]);
            PkFecha = GetValor<DateTime>(dataRow[C_PK_FECHA]);
            PkCodIntervalo = GetValor<long>(dataRow[C_PK_COD_INTERVALO]);
            PkCodMagnitudElec = GetValor<long>(dataRow[C_PK_COD_MAGNITUD_ELEC]);
            Valor = GetValor<double>(dataRow[C_VALOR]);
            Estado = GetValor<int>(dataRow[C_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodOrigen = GetValor<long>(dataRow[C_D_COD_ORIGEN]);
            FkCodPuntoMedicion = GetValor<long>(dataRow[C_FK_COD_PUNTO_MEDICION]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_LECTURA] = PkCodLectura;
            dataRow[C_PK_FECHA] = PkFecha;
            dataRow[C_PK_COD_INTERVALO] = PkCodIntervalo;
            dataRow[C_PK_COD_MAGNITUD_ELEC] = PkCodMagnitudElec;
            dataRow[C_VALOR] = Valor;
            dataRow[C_ESTADO] = Estado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_D_COD_ORIGEN] = DCodOrigen;
            dataRow[C_FK_COD_PUNTO_MEDICION] = FkCodPuntoMedicion;
        }

        public static void EliminarMarcadosParaBorrar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            for (int i = 0; i < res.Registros.Count; i++)
            {
                RegistroLectura registro = res.Registros[i];
                if (registro.MarcadoParaBorrar)
                {
                    res.Registros.RemoveAt(i);
                    foreach (DataRow r in registro.RowsItems)
                    {
                        res.Tabla.Rows.Remove(r);
                    }
                    i--;
                }
            }
        }

        public static void EliminarFueraDeIntervalo(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            MC_IntervaloMaestro intervaloMaestro = MC_IntervaloMaestroMgr.Instancia.GetIntervaloPorFecha(DateTime.Now.Date);
            DataTable tabla = MC_IntervaloDetalleMgr.Instancia.GetPorPkCodMaestro(intervaloMaestro.PkCodIntervaloMaestro);
            List<string> horasIntervalos = new List<string>();
            foreach (DataRow r in tabla.Rows)
            {
                horasIntervalos.Add((string)r[MC_IntervaloDetalle.C_HORA_INTERVALO]);
            }

            for (int i = 0; i < res.Registros.Count; i++)
            {
                RegistroLectura registro = res.Registros[i];
                if (!horasIntervalos.Contains(registro.Hora))
                {
                    res.Registros.RemoveAt(i);
                    foreach (DataRow r in registro.RowsItems)
                    {
                        res.Tabla.Rows.Remove(r);
                    }
                    i--;
                }
            }
        }

        public static void EliminarDuplicados(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            Dictionary<string, int> contadores = new Dictionary<string, int>();
            for (int i = 0; i < res.Registros.Count; i++)
            {
                RegistroLectura registro = res.Registros[i];
                string llave = registro.Fecha.Date.ToString("ddMMyy") + " " + registro.Hora;
                if (contadores.ContainsKey(llave))
                {
                    res.Registros.RemoveAt(i);
                    foreach (DataRow r in registro.RowsItems)
                    {
                        res.Tabla.Rows.Remove(r);
                    }
                    i--;
                }
                else
                {
                    contadores[llave] = 1;
                }
            }
        }
    }

    public interface IMC_LecturaDetalleMgr
    {
        void Guardar(MC_LecturaDetalle obj);
        DataTable GetTabla();
        BindingList<MC_LecturaDetalle> GetLista();
    }
}