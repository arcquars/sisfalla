using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloProyectos
{
    [Serializable]
    public class DatoTecnicoCapacitor : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_CAPACITOR";

        public const string C_PK_DATO_TEC_CAPACITOR = "PK_DATO_TEC_CAPACITOR";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_D_COD_TIPO_BANCO_CAPACITOR = "D_COD_TIPO_BANCO_CAPACITOR";
        public const string C_POT_NOMINAL_TRIFASICA_REAC = "POT_NOMINAL_TRIFASICA_REAC";
        public const string C_NODO_CONEXION_ORIGEN = "NODO_CONEXION_ORIGEN";
        public const string C_NODO_CONEXION_DESTINO = "NODO_CONEXION_DESTINO";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_XC_REACTANCIA_CAPACITIVA = "XC_REACTANCIA_CAPACITIVA";
        public const string C_TENSION_NOMINAL = "TENSION_NOMINAL";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecCapacitor { get; set; }
        public long FkProyecto { get; set; }
        public long DCodTipoBancoCapacitor { get; set; }
        public double PotNominalTrifasicaReac { get; set; }
        public string NodoConexionOrigen { get; set; }
        public string NodoConexionDestino { get; set; }
        public string Observaciones { get; set; }
        public double XcReactanciaCapacitiva { get; set; }
        public double TensionNominal { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaRegistro { get; set; }

        public DatoTecnicoCapacitor() { }

        public DatoTecnicoCapacitor(DataRow dataRow)
        {
            PkDatoTecCapacitor = GetValor<long>(dataRow[C_PK_DATO_TEC_CAPACITOR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTipoBancoCapacitor = GetValor<long>(dataRow[C_D_COD_TIPO_BANCO_CAPACITOR]);
            PotNominalTrifasicaReac = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_REAC]);
            NodoConexionOrigen = GetValor<string>(dataRow[C_NODO_CONEXION_ORIGEN]);
            NodoConexionDestino = GetValor<string>(dataRow[C_NODO_CONEXION_DESTINO]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            XcReactanciaCapacitiva = GetValor<double>(dataRow[C_XC_REACTANCIA_CAPACITIVA]);
            TensionNominal = GetValor<double>(dataRow[C_TENSION_NOMINAL]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_CAPACITOR] = PkDatoTecCapacitor;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_D_COD_TIPO_BANCO_CAPACITOR] = DCodTipoBancoCapacitor;
            dataRow[C_POT_NOMINAL_TRIFASICA_REAC] = PotNominalTrifasicaReac;
            dataRow[C_NODO_CONEXION_ORIGEN] = NodoConexionOrigen;
            dataRow[C_NODO_CONEXION_DESTINO] = NodoConexionDestino;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_XC_REACTANCIA_CAPACITIVA] = XcReactanciaCapacitiva;
            dataRow[C_TENSION_NOMINAL] = TensionNominal;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecCapacitor = GetValor<long>(dataRow[C_PK_DATO_TEC_CAPACITOR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTipoBancoCapacitor = GetValor<long>(dataRow[C_D_COD_TIPO_BANCO_CAPACITOR]);
            PotNominalTrifasicaReac = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_REAC]);
            NodoConexionOrigen = GetValor<string>(dataRow[C_NODO_CONEXION_ORIGEN]);
            NodoConexionDestino = GetValor<string>(dataRow[C_NODO_CONEXION_DESTINO]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            XcReactanciaCapacitiva = GetValor<double>(dataRow[C_XC_REACTANCIA_CAPACITIVA]);
            TensionNominal = GetValor<double>(dataRow[C_TENSION_NOMINAL]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

    }

    public interface IDatoTecnicoCapacitorMgr
    {
        void Guardar(DatoTecnicoCapacitor obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoCapacitor> GetLista();
    }
}
