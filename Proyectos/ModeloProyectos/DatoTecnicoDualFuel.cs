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
    public class DatoTecnicoDualFuel : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_GAS_DUAL_FUEL";

        public const string C_PK_DATO_TEC_GAS_DUAL_FUEL = "PK_DATO_TEC_GAS_DUAL_FUEL";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_MODELO = "MODELO";
        public const string C_CAPACIDAD_INSTALADA = "CAPACIDAD_INSTALADA";
        public const string C_HEAT_RATE_GAS_NATURAL_100 = "HEAT_RATE_GAS_NATURAL_100";
        public const string C_HEAT_RATE_GAS_NATURAL_75 = "HEAT_RATE_GAS_NATURAL_75";
        public const string C_HEAT_RATE_GAS_NATURAL_50 = "HEAT_RATE_GAS_NATURAL_50";
        public const string C_HEAT_RATE_DIESEL_100 = "HEAT_RATE_DIESEL_100";
        public const string C_HEAT_RATE_DIESEL_75 = "HEAT_RATE_DIESEL_75";
        public const string C_HEAT_RATE_DIESEL_50 = "HEAT_RATE_DIESEL_50";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecGasDualFuel { get; set; }
        public long FkProyecto { get; set; }
        public string Modelo { get; set; }
        public double CapacidadInstalada { get; set; }
        public long HeatRateGasNatural100 { get; set; }
        public long HeatRateGasNatural75 { get; set; }
        public long HeatRateGasNatural50 { get; set; }
        public long HeatRateDiesel100 { get; set; }
        public long HeatRateDiesel75 { get; set; }
        public long HeatRateDiesel50 { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoDualFuel() { }

        public DatoTecnicoDualFuel(DataRow dataRow)
        {
            PkDatoTecGasDualFuel = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_DUAL_FUEL]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Modelo = GetValor<string>(dataRow[C_MODELO]);
            CapacidadInstalada = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA]);
            HeatRateGasNatural100 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_100]);
            HeatRateGasNatural75 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_75]);
            HeatRateGasNatural50 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_50]);
            HeatRateDiesel100 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_100]);
            HeatRateDiesel75 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_75]);
            HeatRateDiesel50 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_GAS_DUAL_FUEL] = PkDatoTecGasDualFuel;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_MODELO] = Modelo;
            dataRow[C_CAPACIDAD_INSTALADA] = CapacidadInstalada;
            dataRow[C_HEAT_RATE_GAS_NATURAL_100] = HeatRateGasNatural100;
            dataRow[C_HEAT_RATE_GAS_NATURAL_75] = HeatRateGasNatural75;
            dataRow[C_HEAT_RATE_GAS_NATURAL_50] = HeatRateGasNatural50;
            dataRow[C_HEAT_RATE_DIESEL_100] = HeatRateDiesel100;
            dataRow[C_HEAT_RATE_DIESEL_75] = HeatRateDiesel75;
            dataRow[C_HEAT_RATE_DIESEL_50] = HeatRateDiesel50;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecGasDualFuel = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_DUAL_FUEL]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Modelo = GetValor<string>(dataRow[C_MODELO]);
            CapacidadInstalada = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA]);
            HeatRateGasNatural100 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_100]);
            HeatRateGasNatural75 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_75]);
            HeatRateGasNatural50 = GetValor<long>(dataRow[C_HEAT_RATE_GAS_NATURAL_50]);
            HeatRateDiesel100 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_100]);
            HeatRateDiesel75 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_75]);
            HeatRateDiesel50 = GetValor<long>(dataRow[C_HEAT_RATE_DIESEL_50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoDualFuelMgr
    {
        void Guardar(DatoTecnicoDualFuel obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoDualFuel> GetLista();
    }
}
