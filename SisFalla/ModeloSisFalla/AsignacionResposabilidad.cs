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
    public class AsignacionResposabilidad : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_RESPONSABILIDAD";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_PK_COD_PERSONA_RESPONSABLE = "PK_COD_PERSONA_RESPONSABLE";
        public const string C_FEC_APERTURA = "FEC_APERTURA";
        public const string C_TIEMPO_RESPONSABILIDAD = "TIEMPO_RESPONSABILIDAD";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public int PkCodFalla { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkCodComponente { get; set; }
        public long PkCodPersonaResponsable { get; set; }
        public long PkCodPersonaResponsableAnterior { get; set; }
        public DateTime FecApertura { get; set; }
        public float Tiempo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }

        public AsignacionResposabilidad() { }

        public AsignacionResposabilidad(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            PkCodPersonaResponsable = GetValor<long>(dataRow[C_PK_COD_PERSONA_RESPONSABLE]);
            PkCodPersonaResponsableAnterior = GetValor<long>(dataRow[C_PK_COD_PERSONA_RESPONSABLE]);
            FecApertura = GetValor<DateTime>(dataRow[C_FEC_APERTURA]);
            Tiempo = GetValor<float>(dataRow[C_TIEMPO_RESPONSABILIDAD]);
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
            dataRow[C_PK_COD_PERSONA_RESPONSABLE] = PkCodPersonaResponsable;
            dataRow[C_FEC_APERTURA] = FecApertura;
            dataRow[C_TIEMPO_RESPONSABILIDAD] = Tiempo;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_SINC_VER] = SincVer;
        }
    }

    public interface IAsignacionResposabilidadMgr
    {
        void Guardar(AsignacionResposabilidad obj);
        DataTable GetTabla();
        BindingList<AsignacionResposabilidad> GetLista();
        DataTable GetAsigResp(RRegFallaComponente _compComprometido);
        void Eliminar(AsignacionResposabilidad a);
    }
}