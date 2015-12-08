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
    public class DatoTecnicoTurbina : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_GAS_TURBINA";

        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_MODELO_TURBINA = "MODELO_TURBINA";
        public const string C_TEMP_ISO = "TEMP_ISO";
        public const string C_TEMP_MAX_SITIO = "TEMP_MAX_SITIO";
        public const string C_TEMP_MEDIA_SITIO = "TEMP_MEDIA_SITIO";
        public const string C_CAPACIDAD_INSTALADA_ISO = "CAPACIDAD_INSTALADA_ISO";
        public const string C_CAPACIDAD_INST_MEDIA_SITIO = "CAPACIDAD_INST_MEDIA_SITIO";
        public const string C_HR_ISO_100 = "HR_ISO_100";
        public const string C_HR_ISO_75 = "HR_ISO_75";
        public const string C_HR_ISO_50 = "HR_ISO_50";
        public const string C_CAPACIDAD_INST_MAX_SITIO = "CAPACIDAD_INST_MAX_SITIO";
        public const string C_PK_DATO_TEC_GAS_TURBINA = "PK_DATO_TEC_GAS_TURBINA";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_HR_TEM_MAX_100 = "HR_TEM_MAX_100";
        public const string C_HR_TEM_MAX_75 = "HR_TEM_MAX_75";
        public const string C_HR_TEM_MAX_50 = "HR_TEM_MAX_50";
        public const string C_HR_TEM_MEDIA_100 = "HR_TEM_MEDIA_100";
        public const string C_HR_TEM_MEDIA_75 = "HR_TEM_MEDIA_75";
        public const string C_HR_TEM_MEDIA_50 = "HR_TEM_MEDIA_50";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long FkProyecto { get; set; }
        public string ModeloTurbina { get; set; }
        public double TempIso { get; set; }
        public double TempMaxSitio { get; set; }
        public double TempMediaSitio { get; set; }
        public double CapacidadInstaladaIso { get; set; }
        public double CapacidadInstMediaSitio { get; set; }
        public long HrIso100 { get; set; }
        public long HrIso75 { get; set; }
        public long HrIso50 { get; set; }
        public double CapacidadInstMaxSitio { get; set; }
        public long PkDatoTecGasTurbina { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public long HrTemMax100 { get; set; }
        public long HrTemMax75 { get; set; }
        public long HrTemMax50 { get; set; }
        public long HrTemMedia100 { get; set; }
        public long HrTemMedia75 { get; set; }
        public long HrTemMedia50 { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoTurbina() { }

        public DatoTecnicoTurbina(DataRow dataRow)
        {
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ModeloTurbina = GetValor<string>(dataRow[C_MODELO_TURBINA]);
            TempIso = GetValor<double>(dataRow[C_TEMP_ISO]);
            TempMaxSitio = GetValor<double>(dataRow[C_TEMP_MAX_SITIO]);
            TempMediaSitio = GetValor<double>(dataRow[C_TEMP_MEDIA_SITIO]);
            CapacidadInstaladaIso = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA_ISO]);
            CapacidadInstMediaSitio = GetValor<double>(dataRow[C_CAPACIDAD_INST_MEDIA_SITIO]);
            HrIso100 = GetValor<long>(dataRow[C_HR_ISO_100]);
            HrIso75 = GetValor<long>(dataRow[C_HR_ISO_75]);
            HrIso50 = GetValor<long>(dataRow[C_HR_ISO_50]);
            CapacidadInstMaxSitio = GetValor<double>(dataRow[C_CAPACIDAD_INST_MAX_SITIO]);
            PkDatoTecGasTurbina = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_TURBINA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            HrTemMax100 = GetValor<long>(dataRow[C_HR_TEM_MAX_100]);
            HrTemMax75 = GetValor<long>(dataRow[C_HR_TEM_MAX_75]);
            HrTemMax50 = GetValor<long>(dataRow[C_HR_TEM_MAX_50]);
            HrTemMedia100 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_100]);
            HrTemMedia75 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_75]);
            HrTemMedia50 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_50]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_MODELO_TURBINA] = ModeloTurbina;
            dataRow[C_TEMP_ISO] = TempIso;
            dataRow[C_TEMP_MAX_SITIO] = TempMaxSitio;
            dataRow[C_TEMP_MEDIA_SITIO] = TempMediaSitio;
            dataRow[C_CAPACIDAD_INSTALADA_ISO] = CapacidadInstaladaIso;
            dataRow[C_CAPACIDAD_INST_MEDIA_SITIO] = CapacidadInstMediaSitio;
            dataRow[C_HR_ISO_100] = HrIso100;
            dataRow[C_HR_ISO_75] = HrIso75;
            dataRow[C_HR_ISO_50] = HrIso50;
            dataRow[C_CAPACIDAD_INST_MAX_SITIO] = CapacidadInstMaxSitio;
            dataRow[C_PK_DATO_TEC_GAS_TURBINA] = PkDatoTecGasTurbina;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_HR_TEM_MAX_100] = HrTemMax100;
            dataRow[C_HR_TEM_MAX_75] = HrTemMax75;
            dataRow[C_HR_TEM_MAX_50] = HrTemMax50;
            dataRow[C_HR_TEM_MEDIA_100] = HrTemMedia100;
            dataRow[C_HR_TEM_MEDIA_75] = HrTemMedia75;
            dataRow[C_HR_TEM_MEDIA_50] = HrTemMedia50;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ModeloTurbina = GetValor<string>(dataRow[C_MODELO_TURBINA]);
            TempIso = GetValor<double>(dataRow[C_TEMP_ISO]);
            TempMaxSitio = GetValor<double>(dataRow[C_TEMP_MAX_SITIO]);
            TempMediaSitio = GetValor<double>(dataRow[C_TEMP_MEDIA_SITIO]);
            CapacidadInstaladaIso = GetValor<double>(dataRow[C_CAPACIDAD_INSTALADA_ISO]);
            CapacidadInstMediaSitio = GetValor<double>(dataRow[C_CAPACIDAD_INST_MEDIA_SITIO]);
            HrIso100 = GetValor<long>(dataRow[C_HR_ISO_100]);
            HrIso75 = GetValor<long>(dataRow[C_HR_ISO_75]);
            HrIso50 = GetValor<long>(dataRow[C_HR_ISO_50]);
            CapacidadInstMaxSitio = GetValor<double>(dataRow[C_CAPACIDAD_INST_MAX_SITIO]);
            PkDatoTecGasTurbina = GetValor<long>(dataRow[C_PK_DATO_TEC_GAS_TURBINA]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            HrTemMax100 = GetValor<long>(dataRow[C_HR_TEM_MAX_100]);
            HrTemMax75 = GetValor<long>(dataRow[C_HR_TEM_MAX_75]);
            HrTemMax50 = GetValor<long>(dataRow[C_HR_TEM_MAX_50]);
            HrTemMedia100 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_100]);
            HrTemMedia75 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_75]);
            HrTemMedia50 = GetValor<long>(dataRow[C_HR_TEM_MEDIA_50]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoTurbinaMgr
    {
        void Guardar(DatoTecnicoTurbina obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoTurbina> GetLista();
    }
}
