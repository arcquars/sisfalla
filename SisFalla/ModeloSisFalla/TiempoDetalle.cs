using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloSisFalla
{
    [Serializable]
    public class TiempoDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_TIEMPOSDETALLE";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_PK_COD_PERSONA = "PK_COD_PERSONA";
        public const string C_TIEMPO_INDISPONIBILIDAD = "TIEMPO_INDISPONIBILIDAD";
        public const string C_FEC_APERTURA = "FEC_APERTURA";
        public const string C_TIEMPO_PRECONEXION = "TIEMPO_PRECONEXION";
        public const string C_TIEMPO_CONEXION = "TIEMPO_CONEXION";
        public const string C_FK_COD_RESPONSABLE = "FK_COD_RESPONSABLE";
        public const string C_D_COD_MOTIVO = "D_COD_MOTIVO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public int PkCodFalla { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkCodComponente { get; set; }
        public long PkCodPersona { get; set; }
        public long PkCodPersonaAnterior { get; set; }
        public DateTime FecApertura { get; set; }
        public float TiempoIndisponibilidad { get; set; }
        public float TiempoPreconexion { get; set; }
        public float TiempoConexion { get; set; }
        public long FkCodResponsable { get; set; }
        public long DCodMotivo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }

        public TiempoDetalle() { }

        public TiempoDetalle(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            PkCodPersona = GetValor<long>(dataRow[C_PK_COD_PERSONA]);
            PkCodPersonaAnterior = GetValor<long>(dataRow[C_PK_COD_PERSONA]);
            FecApertura = GetValor<DateTime>(dataRow[C_FEC_APERTURA]);
            TiempoIndisponibilidad = GetValor<float>(dataRow[C_TIEMPO_INDISPONIBILIDAD]);
            TiempoPreconexion = GetValor<float>(dataRow[C_TIEMPO_PRECONEXION]);
            TiempoConexion = GetValor<float>(dataRow[C_TIEMPO_CONEXION]);
            FkCodResponsable = GetValor<long>(dataRow[C_FK_COD_RESPONSABLE]);
            DCodMotivo = GetValor<long>(dataRow[C_D_COD_MOTIVO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[C_PK_D_COD_TIPOINFORME] = PkDCodTipoinforme;
            dataRow[C_PK_ORIGEN_INFORME] = PkOrigenInforme;
            dataRow[C_PK_COD_COMPONENTE] = PkCodComponente;
            dataRow[C_PK_COD_PERSONA] = PkCodPersona;
            dataRow[C_FEC_APERTURA] = FecApertura;
            dataRow[C_TIEMPO_INDISPONIBILIDAD] = TiempoIndisponibilidad;
            dataRow[C_TIEMPO_PRECONEXION] = TiempoPreconexion;
            dataRow[C_TIEMPO_CONEXION] = TiempoConexion;
            dataRow[C_FK_COD_RESPONSABLE] = FkCodResponsable;
            dataRow[C_D_COD_MOTIVO] = DCodMotivo;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_SINC_VER] = SincVer;
        }
    }

    public interface ITiempoDetalleMgr
    {
        void Guardar(TiempoDetalle obj);
        DataTable GetTabla();
        BindingList<TiempoDetalle> GetLista();
        DataTable GetTiempos(RRegFallaComponente _compComprometido);

        void Eliminar(TiempoDetalle t);
    }
}