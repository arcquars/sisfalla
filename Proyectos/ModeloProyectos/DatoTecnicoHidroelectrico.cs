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
    public class DatoTecnicoHidroelectrico : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_HIDROELECTRICO";

        public const string C_PK_DATO_TEC_HIDROELECTRICO = "PK_DATO_TEC_HIDROELECTRICO";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_POTENCIA_INSTALADA = "POTENCIA_INSTALADA";
        public const string C_NRO_UNIDADES = "NRO_UNIDADES";
        public const string C_D_COD_TURBINA_HIDROELECTRICA = "D_COD_TURBINA_HIDROELECTRICA";
        public const string C_CAUDAL_DISENO = "CAUDAL_DISENO";
        public const string C_CUENCA = "CUENCA";
        public const string C_FK_PROY_VERTIMIENTO = "FK_PROY_VERTIMIENTO";
        public const string C_FK_PROY_TURBINAMIENTO = "FK_PROY_TURBINAMIENTO";
        public const string C_GENERACION_MEDIA_ANUAL = "GENERACION_MEDIA_ANUAL";
        public const string C_FACTOR_PRODUCTIVIDAD = "FACTOR_PRODUCTIVIDAD";
        public const string C_CAIDA_BRUTA = "CAIDA_BRUTA";
        public const string C_VOLUMEN_TOTAL = "VOLUMEN_TOTAL";
        public const string C_AREA_CUENCA = "AREA_CUENCA";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_FK_PROY_INFILTRACION = "FK_PROY_INFILTRACION";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_VOLUMEN_UTIL = "VOLUMEN_UTIL";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecHidroelectrico { get; set; }
        public long FkProyecto { get; set; }
        public double PotenciaInstalada { get; set; }
        public long NroUnidades { get; set; }
        public long DCodTurbinaHidroelectrica { get; set; }
        public double CaudalDiseno { get; set; }
        public string Cuenca { get; set; }
        public long FkProyVertimiento { get; set; }
        public long FkProyTurbinamiento { get; set; }
        public double GeneracionMediaAnual { get; set; }
        public double FactorProductividad { get; set; }
        public double CaidaBruta { get; set; }
        public double VolumenTotal { get; set; }
        public double AreaCuenca { get; set; }
        public string Observaciones { get; set; }
        public long FkProyInfiltracion { get; set; }
        public long SecLog { get; set; }
        public double VolumenUtil { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoHidroelectrico() { }

        public DatoTecnicoHidroelectrico(DataRow dataRow)
        {
            PkDatoTecHidroelectrico = GetValor<long>(dataRow[C_PK_DATO_TEC_HIDROELECTRICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            DCodTurbinaHidroelectrica = GetValor<long>(dataRow[C_D_COD_TURBINA_HIDROELECTRICA]);
            CaudalDiseno = GetValor<double>(dataRow[C_CAUDAL_DISENO]);
            Cuenca = GetValor<string>(dataRow[C_CUENCA]);
            FkProyVertimiento = GetValor<long>(dataRow[C_FK_PROY_VERTIMIENTO]);
            FkProyTurbinamiento = GetValor<long>(dataRow[C_FK_PROY_TURBINAMIENTO]);
            GeneracionMediaAnual = GetValor<double>(dataRow[C_GENERACION_MEDIA_ANUAL]);
            FactorProductividad = GetValor<double>(dataRow[C_FACTOR_PRODUCTIVIDAD]);
            CaidaBruta = GetValor<double>(dataRow[C_CAIDA_BRUTA]);
            VolumenTotal = GetValor<double>(dataRow[C_VOLUMEN_TOTAL]);
            AreaCuenca = GetValor<double>(dataRow[C_AREA_CUENCA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            FkProyInfiltracion = GetValor<long>(dataRow[C_FK_PROY_INFILTRACION]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            VolumenUtil = GetValor<double>(dataRow[C_VOLUMEN_UTIL]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_HIDROELECTRICO] = PkDatoTecHidroelectrico;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_POTENCIA_INSTALADA] = PotenciaInstalada;
            dataRow[C_NRO_UNIDADES] = NroUnidades;
            dataRow[C_D_COD_TURBINA_HIDROELECTRICA] = DCodTurbinaHidroelectrica;
            dataRow[C_CAUDAL_DISENO] = CaudalDiseno;
            dataRow[C_CUENCA] = Cuenca;
            dataRow[C_FK_PROY_VERTIMIENTO] = FkProyVertimiento;
            dataRow[C_FK_PROY_TURBINAMIENTO] = FkProyTurbinamiento;
            dataRow[C_GENERACION_MEDIA_ANUAL] = GeneracionMediaAnual;
            dataRow[C_FACTOR_PRODUCTIVIDAD] = FactorProductividad;
            dataRow[C_CAIDA_BRUTA] = CaidaBruta;
            dataRow[C_VOLUMEN_TOTAL] = VolumenTotal;
            dataRow[C_AREA_CUENCA] = AreaCuenca;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_FK_PROY_INFILTRACION] = FkProyInfiltracion;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_VOLUMEN_UTIL] = VolumenUtil;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecHidroelectrico = GetValor<long>(dataRow[C_PK_DATO_TEC_HIDROELECTRICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            DCodTurbinaHidroelectrica = GetValor<long>(dataRow[C_D_COD_TURBINA_HIDROELECTRICA]);
            CaudalDiseno = GetValor<double>(dataRow[C_CAUDAL_DISENO]);
            Cuenca = GetValor<string>(dataRow[C_CUENCA]);
            FkProyVertimiento = GetValor<long>(dataRow[C_FK_PROY_VERTIMIENTO]);
            FkProyTurbinamiento = GetValor<long>(dataRow[C_FK_PROY_TURBINAMIENTO]);
            GeneracionMediaAnual = GetValor<double>(dataRow[C_GENERACION_MEDIA_ANUAL]);
            FactorProductividad = GetValor<double>(dataRow[C_FACTOR_PRODUCTIVIDAD]);
            CaidaBruta = GetValor<double>(dataRow[C_CAIDA_BRUTA]);
            VolumenTotal = GetValor<double>(dataRow[C_VOLUMEN_TOTAL]);
            AreaCuenca = GetValor<double>(dataRow[C_AREA_CUENCA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            FkProyInfiltracion = GetValor<long>(dataRow[C_FK_PROY_INFILTRACION]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            VolumenUtil = GetValor<double>(dataRow[C_VOLUMEN_UTIL]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoHidroelectricoMgr
    {
        void Guardar(DatoTecnicoHidroelectrico obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoHidroelectrico> GetLista();
    }
}
