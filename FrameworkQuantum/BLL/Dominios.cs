using System;
using System.Collections.Generic;
using System.Text;

//Codigo generado por Utilitario CNDC
namespace CNDC.Dominios
{

    public class Dominios
    {
        public const string D_COD_TIPO_PERSONA = "D_COD_TIPO_PERSONA";
        public const string D_COD_TIPO_RELE = "D_COD_TIPO_RELE";
        public const string D_COD_ZONA = "D_COD_ZONA";
        public const string D_COD_ESTADO_INF = "D_COD_ESTADO_INF";
        public const string D_TIPO_COMPONENTE = "D_TIPO_COMPONENTE";
        public const string D_COD_ORIGEN_INSTALACION = "D_COD_ORIGEN_INSTALACION";
        public const string D_COD_SECC_CORREO = "D_COD_SECC_CORREO";
        public const string D_TIPO_OPCION_MENU = "D_TIPO_OPCION_MENU";
        public const string D_COD_PROBLEMA_GEN = "D_COD_PROBLEMA_GEN";
        public const string D_COD_ESTADO_NOTIFICACION = "D_COD_ESTADO_NOTIFICACION";
        public const string D_COD_COLAPSO = "D_COD_COLAPSO";
        public const string PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string D_TIPO_DESCONEXION = "D_TIPO_DESCONEXION";
        public const string D_CAUSA_DESCONEXION = "D_CAUSA_DESCONEXION";
        public const string D_COD_TIPO_OPERACION = "D_COD_TIPO_OPERACION";
        public const string D_COD_FUNCION = "D_COD_FUNCION";
    }

    public enum D_COD_TIPO_PERSONA
    {
        PERSONA_NATURAL = 18,
        PERSONA_JURIDICA = 19,
    }

    public enum D_COD_TIPO_RELE
    {
        SF01 = 64,
        SF06 = 65,
        SF09 = 66,
        RE01 = 67,
        SF07 = 68,
        SF02 = 69,
        RE03 = 70,
        SF05 = 71,
        RE02 = 72,
        SF10 = 73,
        SF04 = 74,
        SF08 = 75,
        GR02 = 76,
        GR01 = 77,
        SF03 = 78,
        PRUEBA1 = 3568,
        NUEVO_1 = 3564,
    }

    public enum D_COD_ZONA
    {
        NORTE = 3587,
        CENTRAL = 3588,
        SUR = 3589,
        A = 3590,
        B = 3591,
    }

    public enum D_COD_ESTADO_INF
    {
        EN_ELABORACION = 3592,
        ELABORADO = 3593,
        ENVIADO = 3594,
        ENVIADO_ERROR = 3742
    }

    public enum D_TIPO_COMPONENTE
    {
        LT = 1,
        TR = 2,
        AL = 3,
        RE = 4,
        IT = 5,
        CS = 6,
        CP = 7,
        IG = 8,
        AT = 9,
        UG = 10,
        EO = 11,
    }

    public enum D_COD_ORIGEN_INSTALACION
    {
        INSTALACIONES_DE_TRANSMISION = 12,
        INSTALACIONES_DE_GENERACIÓN = 13,
        INSTALACIONES_DE_DISTRIBUCIÓN = 14,
        INSTALACIONES_DE_CONSUMIDORES_NO_REGULADOS = 15,
        INSTALACIONES_DE_TERCEROS = 16,
        NO_DETERMINADO = 17,
    }

    public enum D_COD_SECC_CORREO
    {
        ENCABEZADO = 38,
        CUERPO = 39,
        ADJUNTO = 40,
        ENCABEZADO_INFORME = 82,
        CUERPO_INFORME = 83,
        ENCABEZADO_REVERSION_NOTIF = 3604,
        CUERPO_REVERSION_NOTIF = 3605,
        ENCABEZADO_BORRAR_FALLA = 3606,
        CUERPO_BORRAR_FALLA = 3607
    }

    public enum D_TIPO_OPCION_MENU
    {
        OPCION_MENU = 44,
        OPCION_INTERNA = 45,
    }

    public enum D_COD_PROBLEMA_GEN
    {
        Problemas_en_la_oferta_de_Generación = 3585,
        Mayor_demanda_a_la_oferta = 3586,
    }

    public enum D_COD_ESTADO_NOTIFICACION
    {
        REGISTRADO = 41,
        ENVIADO = 42,
        RECIBIDO = 43,
    }

    public enum D_COD_COLAPSO
    {
        NO_COLAPSO = 3529,
        TOTAL = 3530,
        PARCIAL = 3531,
    }

    public enum PK_D_COD_TIPOINFORME
    {
        PRELIMINAR = 20,
        FINAL = 21,
        RECTIFICATORIO = 22,
    }

    public enum D_TIPO_DESCONEXION
    {
        FORZADA = 23,
        PROGRAMADA = 24,
    }

    public enum D_CAUSA_DESCONEXION
    {
        CONDICIONES_CLIMATICAS = 26,
        FABRICACION = 27,
        ANIMALES = 25,
        MEDIO_AMBIENTE = 28,
        NO_IDENTIFICADA = 29,
        OTROS = 30,
        OTROS_AGENTES = 31,
        PROPIOS_DE_LAS_INSTALACIONES = 32,
        TERCEROS = 33,
        AMPLIACION = 34,
        EXTERNAS = 35,
        MANTENIMIENTO = 36,
        PRUEBAS = 37,
    }

    public enum D_COD_TIPO_OPERACION
    {
        MANUAL = 79,
        AUTOMATICO = 80,
        REMOTA = 81,
    }

    public enum D_COD_FUNCION
    {
        SOBREVELOCIDAD = 104,
        BAJA_VELOCIDAD = 105,
        DISTANCIA = 106,
        RELACION_VOLTIOS_HERTZIOS = 107,
        SINCRONISMOS = 108,
        BAJO_VOLTAJE = 109,
        POTENCIA_INVERSA = 110,
        PERDIDA_EXITACION = 111,
        SECUENCIA_INVERSA = 112,
        TEMPERATURA = 113,
        SOBRECORRIENTE_INSTANTANEO = 114,
        SOBRECORRIENTE_DE_TIEMPO = 115,
        SOBREVOLTAJE = 116,
        TEMPORIZACION = 117,
        PRESION = 118,
        PROTECCION_A_TIERRA = 119,
        DIRECCIONAL_SOBRECORRIENTE = 120,
        RECIENTE = 121,
        SOBREFRECUENCIA = 122,
        SUBFRECUENCIA = 123,
        MECANISMO_DE_OPERACION, _MECANISMOS_O_SERVOMECANISMOS = 124,
        BLOQUEO = 125,
        DIFERENCIA_GENERADOR_TRANSFORMADOR_LINEA = 126,
    }
}