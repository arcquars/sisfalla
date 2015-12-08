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
    public class DatoTecnicoGeotermico : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_GEOTERMICO";

        public const string C_PK_DATO_TEC_GEOTERMICO = "PK_DATO_TEC_GEOTERMICO";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_POTENCIA_INSTALADA = "POTENCIA_INSTALADA";
        public const string C_NRO_UNIDADES = "NRO_UNIDADES";
        public const string C_D_COD_TECNOLOGIA_GEOTERMICA = "D_COD_TECNOLOGIA_GEOTERMICA";
        public const string C_GENERACION_MEDIA_ANUAL = "GENERACION_MEDIA_ANUAL";
        public const string C_PODER_CALORIFICO = "PODER_CALORIFICO";
        public const string C_PRODUCTIVIDAD = "PRODUCTIVIDAD";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecGeotermico { get; set; }
        public long FkProyecto { get; set; }
        public double PotenciaInstalada { get; set; }
        public long NroUnidades { get; set; }
        public long DCodTecnologiaGeotermica { get; set; }
        public double GeneracionMediaAnual { get; set; }
        public double PoderCalorifico { get; set; }
        public double Productividad { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoGeotermico() { }

        public DatoTecnicoGeotermico(DataRow dataRow)
        {
            PkDatoTecGeotermico = GetValor<long>(dataRow[C_PK_DATO_TEC_GEOTERMICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            DCodTecnologiaGeotermica = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_GEOTERMICA]);
            GeneracionMediaAnual = GetValor<double>(dataRow[C_GENERACION_MEDIA_ANUAL]);
            PoderCalorifico = GetValor<double>(dataRow[C_PODER_CALORIFICO]);
            Productividad = GetValor<double>(dataRow[C_PRODUCTIVIDAD]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_GEOTERMICO] = PkDatoTecGeotermico;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_POTENCIA_INSTALADA] = PotenciaInstalada;
            dataRow[C_NRO_UNIDADES] = NroUnidades;
            dataRow[C_D_COD_TECNOLOGIA_GEOTERMICA] = DCodTecnologiaGeotermica;
            dataRow[C_GENERACION_MEDIA_ANUAL] = GeneracionMediaAnual;
            dataRow[C_PODER_CALORIFICO] = PoderCalorifico;
            dataRow[C_PRODUCTIVIDAD] = Productividad;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecGeotermico = GetValor<long>(dataRow[C_PK_DATO_TEC_GEOTERMICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            DCodTecnologiaGeotermica = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_GEOTERMICA]);
            GeneracionMediaAnual = GetValor<double>(dataRow[C_GENERACION_MEDIA_ANUAL]);
            PoderCalorifico = GetValor<double>(dataRow[C_PODER_CALORIFICO]);
            Productividad = GetValor<double>(dataRow[C_PRODUCTIVIDAD]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoGeotermicoMgr
    {
        void Guardar(DatoTecnicoGeotermico obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoGeotermico> GetLista();
    }
}
