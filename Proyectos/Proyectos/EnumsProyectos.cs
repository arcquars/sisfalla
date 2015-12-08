using System;
using System.Collections.Generic;
using System.Text;

//Codigo generado por Utilitario CNDC
namespace Proyectos
{

    public class Dominios
    {
        public const string D_COD_DEPARTAMENTOS = "D_COD_DEPARTAMENTOS";
        public const string D_COD_ETAPA_PROYECTO = "D_COD_ETAPA_PROYECTO";
        public const string D_COD_CONF_BAHIA = "D_COD_CONF_BAHIA";
        public const string D_COD_TIPO_REACTOR = "D_COD_TIPO_REACTOR";
        public const string D_COD_TEC_EOLICA = "D_COD_TEC_EOLICA";
        public const string D_COD_TIPO_CAPACITORES = "D_COD_TIPO_CAPACITORES";
        public const string D_COD_TIPO_TRANSFORMADOR = "D_COD_TIPO_TRANSFORMADOR";
        public const string D_COD_TIPO_ESTRUC_SOPORTE = "D_COD_TIPO_ESTRUC_SOPORTE";
        public const string D_COD_TEC_GEOTERMICA = "D_COD_TEC_GEOTERMICA";
        public const string D_COD_TEC_BIOMASA = "D_COD_TEC_BIOMASA";
        public const string D_COD_TIPO_TURBINA_HIDRO = "D_COD_TIPO_TURBINA_HIDRO";
        public const string D_COD_TIPO_PROYECTO = "D_COD_TIPO_PROYECTO";
    }

    public enum D_COD_DEPARTAMENTOS
    {
        POTOSÍ = 3642,
        TARIJA = 3664,
        CHUQUISACA = 3665,
        SANTA_CRUZ = 3666,
        PANDO = 3667,
        ORURO = 3668,
        LA_PAZ = 3669,
        BENI = 3670,
        COCHABAMBA = 3671,
    }

    public enum D_COD_ETAPA_PROYECTO
    {
        PERFIL = 3648,
        PREFACTIBILIDAD = 3673,
        FACTIBILIDAD = 3674,
        DISEÑO_FINAL = 3675,
        EJECUCIÓN = 3676,
        OPERACIÓN = 3678,
        RETIRADO = 3679,
    }

    public enum D_COD_CONF_BAHIA
    {
        ANILLO = 3680,
        BARRA_DOBLE = 3681,
        BARRA_PRINCIPAL_CON_BARRA_DE_TRANSFERENCIA = 3682,
        BARRA_SIMPLE_CON_BYPASS = 3683,
    }

    public enum D_COD_TIPO_REACTOR
    {
        BARRA = 3684,
        LINEA = 3685,
    }

    public enum D_COD_TEC_EOLICA
    {
        VERTICAL = 3686,
        HORIZONTAL = 3687,
    }

    public enum D_COD_TIPO_CAPACITORES
    {
        CAPACITOR_EN_SERIE = 3688,
        CAPACITOR_EN_PARALELO = 3689,
    }

    public enum D_COD_TIPO_TRANSFORMADOR
    {
        AUTOTRANSFORMADOR = 3690,
        TRANSFORMADOR = 3691,
    }

    public enum D_COD_TIPO_ESTRUC_SOPORTE
    {
        POSTE_DE_MADERA = 3692,
        POSTE_DE_HORMIGÓN_ARMADO = 3693,
        ESTRUCTURA_AUTOSOPORTADA_RETICULADA = 3694,
    }

    public enum D_COD_TEC_GEOTERMICA
    {
        BINARIO = 3695,
        FLASH = 3696,
        VAPOR_SECO = 3697,
    }

    public enum D_COD_TEC_BIOMASA
    {
        CONDENSACIÓN = 3698,
        CONTRAPRESIÓN = 3699,
    }

    public enum D_COD_TIPO_TURBINA_HIDRO
    {
        BULBO = 3700,
        KAPLAN = 3701,
        FRANCIS = 3702,
        PELTON = 3703,
    }

    public enum D_COD_TIPO_PROYECTO
    {
        REACTOR = 3704,
        CAPACITOR = 3705,
        TRANSFORMADOR = 3706,
        LINEA_DE_TRANSMISIÓN = 3707,
        PROYECTOS_DE_TRANSMISIÓN = 3708,
        SOLAR = 3709,
        EÓLICO = 3710,
        BIOMASA = 3711,
        GEOTÉRMICO = 3712,
        TÉRMICO_CICLO_COMBINADO = 3713,
        TÉRMICO_A_DUAL_FUEL = 3714,
        TÉRMICO_A_DIESEL = 3715,
        MOTORES = 3716,
        TURBINAS = 3717,
        TÉRMICO_A_GAS = 3718,
        TÉRMICO = 3719,
        HIDROELÉCTRICO = 3720,
        PROYECTOS_DE_GENERACIÓN = 3721,
    }

}
