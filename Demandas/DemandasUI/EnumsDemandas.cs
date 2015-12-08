using System;
using System.Collections.Generic;
using System.Text;

//Codigo generado por Utilitario CNDC
namespace DemandasUI
{

    public class Dominios
    {
        public const string D_COD_TIPO_NODO = "D_COD_TIPO_NODO";
        public const string D_COD_CATEGORIA_DATO = "D_COD_CATEGORIA_DATO";
        public const string D_COD_TIPO_AGENTE = "D_COD_TIPO_AGENTE";
    }

    public enum D_COD_TIPO_NODO
    {
        NODO_DE_CONEXION=3756,
        NODO_DEMANDA=3757,
        NODO_PROYECTO = 4865,
        NODO_SALIDA = 4902,
    }

    public enum D_COD_CATEGORIA_DATO
    {
        ENERGIA_MENSUAL_HISTORICA = 3748,
        POTENCIA_MAXIMA = 3749,
        POTENCIA_COINCIDENTAL = 3750,
        FACTOR_PARA_LLEVAR_ENERGIA_A_BLOQUES = 3751,
        IDENTIFICACION_SEMANA_LLUVIOSA = 3752,
        IDENTIFICACION_SEMANA_SECA = 3753,
        IDENTIFICACION_SEMANA_PROMEDIO = 3754,
    }

    public enum D_COD_TIPO_AGENTE
    {
        SISTEMA_AISLADO = 3725,
        PROYECTO = 3724,
        CONSUMIDOR_NO_REGULADO = 3723,
        DISTRIBUCIÓN = 3722,
    }

    public enum D_COD_TIPO_NODO_SALIDA
    {
        SDDP = 4882,
        NCP = 4890,
        OPTGEN = 4891,
        POWER_FACTORY = 4962,
    }

    public enum D_COD_DIA_SEMANA
    {
        SABADO = 4883,
        DOMINGO = 4884,
        LUNES = 4885,
        MARTES = 4886,
        MIERCOLES = 4887,
        JUEVES = 4888,
        VIERNES = 4889,
    }
}

