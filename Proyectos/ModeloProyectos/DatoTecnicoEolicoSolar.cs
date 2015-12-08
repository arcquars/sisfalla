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
    public class DatoTecnicoEolicoSolar : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_EOLICO_SOLAR";

        public const string C_PK_DATO_TEC_EOLICO_SOLAR = "PK_DATO_TEC_EOLICO_SOLAR";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_D_COD_TECNOLOGIA_EOLICO = "D_COD_TECNOLOGIA_EOLICO";
        public const string C_POTENCIA_INSTALADA = "POTENCIA_INSTALADA";
        public const string C_NRO_UNIDADES = "NRO_UNIDADES";
        public const string C_TECNOLOGIA = "TECNOLOGIA";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecEolicoSolar { get; set; }
        public long FkProyecto { get; set; }
        public long DCodTecnologiaEolico { get; set; }
        public double PotenciaInstalada { get; set; }
        public long NroUnidades { get; set; }
        public string Tecnologia { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoEolicoSolar() { }

        public DatoTecnicoEolicoSolar(DataRow dataRow)
        {
            PkDatoTecEolicoSolar = GetValor<long>(dataRow[C_PK_DATO_TEC_EOLICO_SOLAR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTecnologiaEolico = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_EOLICO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            Tecnologia = GetValor<string>(dataRow[C_TECNOLOGIA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_EOLICO_SOLAR] = PkDatoTecEolicoSolar;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_D_COD_TECNOLOGIA_EOLICO] = DCodTecnologiaEolico;
            dataRow[C_POTENCIA_INSTALADA] = PotenciaInstalada;
            dataRow[C_NRO_UNIDADES] = NroUnidades;
            dataRow[C_TECNOLOGIA] = Tecnologia;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecEolicoSolar = GetValor<long>(dataRow[C_PK_DATO_TEC_EOLICO_SOLAR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            DCodTecnologiaEolico = GetValor<long>(dataRow[C_D_COD_TECNOLOGIA_EOLICO]);
            PotenciaInstalada = GetValor<double>(dataRow[C_POTENCIA_INSTALADA]);
            NroUnidades = GetValor<long>(dataRow[C_NRO_UNIDADES]);
            Tecnologia = GetValor<string>(dataRow[C_TECNOLOGIA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }
    }

    public interface IDatoTecnicoEolicoSolarMgr
    {
        void Guardar(DatoTecnicoEolicoSolar obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoEolicoSolar> GetLista();
    }
}
