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
    public class DatoTecnicoCicloCombinado : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_CICLO_COMBINADO";

        public const string C_PK_DATO_TEC_CICLO_COMBINADO = "PK_DATO_TEC_CICLO_COMBINADO";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_MODELO_TURBINA = "MODELO_TURBINA";
        public const string C_CAPACIDAD_INSTALDA = "CAPACIDAD_INSTALDA";
        public const string C_HEAT_RATE_100 = "HEAT_RATE_100";
        public const string C_HEAT_RATE_75 = "HEAT_RATE_75";
        public const string C_HEAT_RATE_50 = "HEAT_RATE_50";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecCicloCombinado { get; set; }
        public long FkProyecto { get; set; }
        public string ModeloTurbina { get; set; }
        public double CapacidadInstalda { get; set; }
        public long HeatRate100 { get; set; }
        public long HeatRate75 { get; set; }
        public long HeatRate50 { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoCicloCombinado() { }

        public DatoTecnicoCicloCombinado(DataRow dataRow)
        {
            PkDatoTecCicloCombinado = GetValor<long>(dataRow[C_PK_DATO_TEC_CICLO_COMBINADO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ModeloTurbina = GetValor<string>(dataRow[C_MODELO_TURBINA]);
            CapacidadInstalda = GetValor<double>(dataRow[C_CAPACIDAD_INSTALDA]);
            HeatRate100 = GetValor<long>(dataRow[C_HEAT_RATE_100]);
            HeatRate75 = GetValor<long>(dataRow[C_HEAT_RATE_75]);
            HeatRate50 = GetValor<long>(dataRow[C_HEAT_RATE_50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_CICLO_COMBINADO] = PkDatoTecCicloCombinado;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_MODELO_TURBINA] = ModeloTurbina;
            dataRow[C_CAPACIDAD_INSTALDA] = CapacidadInstalda;
            dataRow[C_HEAT_RATE_100] = HeatRate100;
            dataRow[C_HEAT_RATE_75] = HeatRate75;
            dataRow[C_HEAT_RATE_50] = HeatRate50;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecCicloCombinado = GetValor<long>(dataRow[C_PK_DATO_TEC_CICLO_COMBINADO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ModeloTurbina = GetValor<string>(dataRow[C_MODELO_TURBINA]);
            CapacidadInstalda = GetValor<double>(dataRow[C_CAPACIDAD_INSTALDA]);
            HeatRate100 = GetValor<long>(dataRow[C_HEAT_RATE_100]);
            HeatRate75 = GetValor<long>(dataRow[C_HEAT_RATE_75]);
            HeatRate50 = GetValor<long>(dataRow[C_HEAT_RATE_50]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoCicloCombinadoMgr
    {
        void Guardar(DatoTecnicoCicloCombinado obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoCicloCombinado> GetLista();
    }
}
