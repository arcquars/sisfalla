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
    public class DatoTecnicoBiomasa : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_BIOMASA";

        public const string C_PK_DATO_TEC_BIOMASA = "PK_DATO_TEC_BIOMASA";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_D_COD_TECNOLOGIA_BIOMASA = "D_COD_TECNOLOGIA_BIOMASA";
        public const string C_POTENCIA_INSTALADA = "POTENCIA_INSTALADA";
        public const string C_NRO_UNIDADES = "NRO_UNIDADES";
        public const string C_PERIODO_OPERACION_MES_DE = "PERIODO_OPERACION_MES_DE";
        public const string C_PERIODO_OPERACION_MES_A = "PERIODO_OPERACION_MES_A";
        public const string C_BIOMADA_DISPONIBLE = "BIOMADA_DISPONIBLE";
        public const string C_CONSUMO_ESPECIFICO = "CONSUMO_ESPECIFICO";
        public const string C_PORDER_CALORIFICO = "PORDER_CALORIFICO";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecBiomasa { get; set; }
        public long FkProyecto { get; set; }
        public long DCodTecnologiaBiomasa { get; set; }
        public double PotenciaInstalada { get; set; }
        public long NroUnidades { get; set; }
        public DateTime PeriodoOperacionMesDe { get; set; }
        public DateTime PeriodoOperacionMesA { get; set; }
        public double BiomadaDisponible { get; set; }
        public double ConsumoEspecifico { get; set; }
        public double PorderCalorifico { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaRegistro { get; set; }

        public DatoTecnicoBiomasa() { }

        public DatoTecnicoBiomasa(DataRow dataRow)
        {
            PkDatoTecBiomasa = GetValor<long>(dataRow[C_PK_DATO_TEC_BIOMASA]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTecnologiaBiomasa = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_BIOMASA]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            PeriodoOperacionMesDe = GetValor<DateTime>(dataRow[C_PERIODO_OPERACION_MES_DE]);
            PeriodoOperacionMesA = GetValor<DateTime>(dataRow[C_PERIODO_OPERACION_MES_A]);
            BiomadaDisponible = GetValor<double>(dataRow[C_BIOMADA_DISPONIBLE]);
            ConsumoEspecifico = GetValor<double>(dataRow[C_CONSUMO_ESPECIFICO]);
            PorderCalorifico = GetValor<double>(dataRow[C_PORDER_CALORIFICO]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_BIOMASA] = PkDatoTecBiomasa;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_D_COD_TECNOLOGIA_BIOMASA] = DCodTecnologiaBiomasa;
            dataRow[C_POTENCIA_INSTALADA] = PotenciaInstalada;
            dataRow[C_NRO_UNIDADES] = NroUnidades;
            dataRow[C_PERIODO_OPERACION_MES_DE] = PeriodoOperacionMesDe;
            dataRow[C_PERIODO_OPERACION_MES_A] = PeriodoOperacionMesA;
            dataRow[C_BIOMADA_DISPONIBLE] = BiomadaDisponible;
            dataRow[C_CONSUMO_ESPECIFICO] = ConsumoEspecifico;
            dataRow[C_PORDER_CALORIFICO] = PorderCalorifico;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecBiomasa = GetValor<long>(dataRow[C_PK_DATO_TEC_BIOMASA]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTecnologiaBiomasa = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_BIOMASA]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            PeriodoOperacionMesDe = GetValor<DateTime>(dataRow[C_PERIODO_OPERACION_MES_DE]);
            PeriodoOperacionMesA = GetValor<DateTime>(dataRow[C_PERIODO_OPERACION_MES_A]);
            BiomadaDisponible = GetValor<double>(dataRow[C_BIOMADA_DISPONIBLE]);
            ConsumoEspecifico = GetValor<double>(dataRow[C_CONSUMO_ESPECIFICO]);
            PorderCalorifico = GetValor<double>(dataRow[C_PORDER_CALORIFICO]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoBiomasaMgr
    {
        void Guardar(DatoTecnicoBiomasa obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoBiomasa> GetLista();
    }
}
