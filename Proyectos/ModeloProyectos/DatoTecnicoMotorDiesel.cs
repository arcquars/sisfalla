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
    public class DatoTecnicoMotorDiesel : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_GAS_MOTOR_DIESEL";

        public const string C_PK_DATO_TEC_GAS_MOTOR_DIESEL = "PK_DATO_TEC_GAS_MOTOR_DIESEL";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_MODELO = "MODELO";
        public const string C_CAPACIDAD_INSTALADA = "CAPACIDAD_INSTALADA";
        public const string C_HEAT_RATE100 = "HEAT_RATE100";
        public const string C_HEAT_RATE75 = "HEAT_RATE75";
        public const string C_HEAT_RATE50 = "HEAT_RATE50";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecGasMotorDiesel { get; set; }
        public long FkProyecto { get; set; }
        public string Modelo { get; set; }
        public double CapacidadInstalada { get; set; }
        public long HeatRate100 { get; set; }
        public long HeatRate75 { get; set; }
        public long HeatRate50 { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoMotorDiesel() { }

        public DatoTecnicoMotorDiesel(DataRow dataRow)
        {
            PkDatoTecGasMotorDiesel = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_MOTOR_DIESEL]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Modelo = GetValor<string>(dataRow[C_MODELO]);
            CapacidadInstalada = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA]);
            HeatRate100 = GetValor<long>(dataRow[C_HEAT_RATE100]);
            HeatRate75 = GetValor<long>(dataRow[C_HEAT_RATE75]);
            HeatRate50 = GetValor<long>(dataRow[C_HEAT_RATE50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_GAS_MOTOR_DIESEL] = PkDatoTecGasMotorDiesel;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_MODELO] = Modelo;
            dataRow[C_CAPACIDAD_INSTALADA] = CapacidadInstalada;
            dataRow[C_HEAT_RATE100] = HeatRate100;
            dataRow[C_HEAT_RATE75] = HeatRate75;
            dataRow[C_HEAT_RATE50] = HeatRate50;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecGasMotorDiesel = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_MOTOR_DIESEL]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Modelo = GetValor<string>(dataRow[C_MODELO]);
            CapacidadInstalada = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA]);
            HeatRate100 = GetValor<long>(dataRow[C_HEAT_RATE100]);
            HeatRate75 = GetValor<long>(dataRow[C_HEAT_RATE75]);
            HeatRate50 = GetValor<long>(dataRow[C_HEAT_RATE50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoMotorDieselMgr
    {
        void Guardar(DatoTecnicoMotorDiesel obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoMotorDiesel> GetLista();
    }
}
