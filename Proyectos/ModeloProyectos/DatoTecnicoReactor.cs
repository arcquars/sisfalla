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
    public class DatoTecnicoReactor : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_REACTOR";

        public const string C_PK_DATO_TEC_REACTOR = "PK_DATO_TEC_REACTOR";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_TENSION_NOMINAL = "TENSION_NOMINAL";
        public const string C_POT_NOMINAL_TRIFASICA_REACTIVO = "POT_NOMINAL_TRIFASICA_REACTIVO";
        public const string C_NODO_CONEXION = "NODO_CONEXION";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_D_COD_TIPO_REACTOR = "D_COD_TIPO_REACTOR";
        public const string C_LINEA = "LINEA";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";
        public const string C_FACTOR_CALIDAD = "FACTOR_CALIDAD";
        public const string C_TENSION_NOMINAL_RN = "TENSION_NOMINAL_RN";
        public const string C_POT_NOMINAL_TRIFASICA_RN = "POT_NOMINAL_TRIFASICA_RN";
        public const string C_FACTOR_CALIDAD_RN = "FACTOR_CALIDAD_RN";
        public const string C_NODO_CONEXION_RN = "NODO_CONEXION_RN";
        public const string C_OBSERVACIONES_RN = "OBSERVACIONES_RN";

        public long PkDatoTecReactor { get; set; }
        public long FkProyecto { get; set; }
        public double TensionNominal { get; set; }
        public double PotNominalTrifasicaReactivo { get; set; }
        public string NodoConexion { get; set; }
        public string Observaciones { get; set; }
        public long DCodTipoReactor { get; set; }
        public string Linea { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double FactorCalidad { get; set; }
        public double TensionNominalRn { get; set; }
        public double PotNominalTrifasicaRn { get; set; }
        public double FactorCalidadRn { get; set; }
        public string NodoConexionRn { get; set; }
        public string ObservacionesRn { get; set; }

        public DatoTecnicoReactor() { }

        public DatoTecnicoReactor(DataRow dataRow)
        {
            PkDatoTecReactor = GetValor<long>(dataRow[C_PK_DATO_TEC_REACTOR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            TensionNominal = GetValor<double>(dataRow[C_TENSION_NOMINAL]);
            PotNominalTrifasicaReactivo = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_REACTIVO]);
            NodoConexion = GetValor<string>(dataRow[C_NODO_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            DCodTipoReactor = GetValor<long>(dataRow[C_D_COD_TIPO_REACTOR]);
            Linea = GetValor<string>(dataRow[C_LINEA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            FactorCalidad = GetValor<double>(dataRow[C_FACTOR_CALIDAD]);
            TensionNominalRn = GetValor<double>(dataRow[C_TENSION_NOMINAL_RN]);
            PotNominalTrifasicaRn = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_RN]);
            FactorCalidadRn = GetValor<double>(dataRow[C_FACTOR_CALIDAD_RN]);
            NodoConexionRn = GetValor<string>(dataRow[C_NODO_CONEXION_RN]);
            ObservacionesRn = GetValor<string>(dataRow[C_OBSERVACIONES_RN]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_REACTOR] = PkDatoTecReactor;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_TENSION_NOMINAL] = TensionNominal;
            dataRow[C_POT_NOMINAL_TRIFASICA_REACTIVO] = PotNominalTrifasicaReactivo;
            dataRow[C_NODO_CONEXION] = NodoConexion;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_D_COD_TIPO_REACTOR] = DCodTipoReactor;
            dataRow[C_LINEA] = Linea;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaRegistro;
            dataRow[C_FACTOR_CALIDAD] = FactorCalidad;
            dataRow[C_TENSION_NOMINAL_RN] = TensionNominalRn;
            dataRow[C_POT_NOMINAL_TRIFASICA_RN] = PotNominalTrifasicaRn;
            dataRow[C_FACTOR_CALIDAD_RN] = FactorCalidadRn;
            dataRow[C_NODO_CONEXION_RN] = NodoConexionRn;
            dataRow[C_OBSERVACIONES_RN] = ObservacionesRn;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecReactor = GetValor<long>(dataRow[C_PK_DATO_TEC_REACTOR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            TensionNominal = GetValor<double>(dataRow[C_TENSION_NOMINAL]);
            PotNominalTrifasicaReactivo = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_REACTIVO]);
            NodoConexion = GetValor<string>(dataRow[C_NODO_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            DCodTipoReactor = GetValor<long>(dataRow[C_D_COD_TIPO_REACTOR]);
            Linea = GetValor<string>(dataRow[C_LINEA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            FactorCalidad = GetValor<double>(dataRow[C_FACTOR_CALIDAD]);
            TensionNominalRn = GetValor<double>(dataRow[C_TENSION_NOMINAL_RN]);
            PotNominalTrifasicaRn = GetValor<double>(dataRow[C_POT_NOMINAL_TRIFASICA_RN]);
            FactorCalidadRn = GetValor<double>(dataRow[C_FACTOR_CALIDAD_RN]);
            NodoConexionRn = GetValor<string>(dataRow[C_NODO_CONEXION_RN]);
            ObservacionesRn = GetValor<string>(dataRow[C_OBSERVACIONES_RN]);
        }
    }

    public interface IDatoTecnicoReactorMgr
    {
        void Guardar(DatoTecnicoReactor obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoReactor> GetLista();
    }
}
