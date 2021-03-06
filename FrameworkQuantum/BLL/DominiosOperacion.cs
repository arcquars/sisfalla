﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.Dominios
{
    public enum DOMINIOS_OPERACION
    {
        NULL = 0,
        CNDC_ENVIA_NOTIFICACION = 1,
        CNDC_ELABORA_PRELIMINAR = 2,
        CNDC_TERMINA_PRELIMINAR = 3,
        CNDC_ENVIA_PRELIMINAR = 4,
        CNDC_ELABORA_FINAL = 5,
        CNDC_TERMINA_FINAL = 6,
        CNDC_ENVIA_FINAL = 7,
        AGENTE_NOTIFICACION_RECIBIDA = 8,
        AGENTE_ELABORA_PRELIMINAR = 9,
        AGENTE_ELABORA_FINAL = 10,
        AGENTE_ENVIA_PRELIMINAR = 11,
        AGENTE_ENVIA_FINAL = 12,
        CNDC_ELABORA_RECTIFICATORIO = 13,
        CNDC_TERMINA_RECTIFICATORIO = 14,
        CNDC_ENVIA_RECTIFICATORIO = 15,
        AGENTE_ELABORA_RECTIFICATORIO = 16,
        AGENTE_ENVIA_RECTIFICATORIO = 17,
        MANUAL_AGENTE_ENVIA_PRELIMINAR = 18,
        MANUAL_AGENTE_ENVIA_FINAL=19,
        CNDC_REVIERTE_INF_PRE_AGENTE = 1011,
        CNDC_REVIERTE_NOTIF_AGENTE = 1012,
        CNDC_PUBLICA_INFORME_FINAL = 1013,
        CNDC_REVIERTE_INF_FIN_AGENTE = 1014

    }
    public enum DOMINIOS_OPERACION_PUBLICACION
    {
        NULL = 0,
        PUBLICACION_PREDESPACHO_DIARIO = 1015,
        PUBLICACION_REDESPACHO_DIARIO = 1016,
        PUBLICACION_CURVAS_PRE_DIARIO = 1017,
        PUBLICACION_PREDESPACHO_SEMANAL = 1018,
        PUBLICACION_CONTINGENCIAS_DIARIO = 1019
    }
}
