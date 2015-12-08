using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using BLL;

namespace ModeloSisFalla
{
    [Serializable]
    public class RRegFallaComponente : ObjetoDeNegocio, IRRegFallaComponente
    {
        public const string NOMBRE_TABLA = "F_GF_RREGFALLA_COMPONENTE";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_POTENCIA_DESCONECTADA = "POTENCIA_DESCONECTADA";
        public const string C_TIEMPO_INDISPONIBILIDAD = "TIEMPO_INDISPONIBILIDAD";
        public const string C_TIEMPO_PRECONEXION = "TIEMPO_PRECONEXION";
        public const string C_TIEMPO_CONEXION = "TIEMPO_CONEXION";
        public const string C_TIEMPO_SISTEMA = "TIEMPO_SISTEMA";
        public const string C_D_COD_MOTIVO = "D_COD_MOTIVO";
        public const string C_FK_COD_RESPONSABLE = "FK_COD_RESPONSABLE";
        public const string C_FEC_APERTURA = "FEC_APERTURA";
        public const string C_D_COD_TIPOPERACIONAPERTURA = "D_COD_TIPOPERACIONAPERTURA";
        public const string C_FEC_CIERRE = "FEC_CIERRE";
        public const string C_D_COD_TIPOOPERACIONCIERRE = "D_COD_TIPOOPERACIONCIERRE";
        public const string C_ETAPA_EDAC = "ETAPA_EDAC";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_FLUJO_N1_N2 = "FLUJO_N1_N2";
        public const string C_TTOTAL_DESCONEXION = "TTOTAL_DESCONEXION";
        public const string C_TIEMPO_P_SIST = "TIEMPO_P_SIST";
        public const string C_TIEMPO_P_OPER = "TIEMPO_P_OPER";
        public const string C_ROW_ID = "RowId";

        public int PkCodFalla { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public long PkCodComponente { get; set; }
        public float PotenciaDesconectada { get; set; }
        public float TiempoIndisponibilidad { get; set; }
        public float TiempoPreconexion { get; set; }
        public float TiempoConexion { get; set; }
        public float TiempoSistema { get; set; }
        public long DCodMotivo { get; set; }
        public long FkCodResponsable { get; set; }
        public DateTime FecApertura { get; set; }
        public long DCodTipoperacionapertura { get; set; }
        public DateTime FecCierre { get; set; }
        public long DCodTipooperacioncierre { get; set; }
        public string EtapaEdac { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }
        public TipoFlujoNodo FlujoN1N2 { get; set; }
        public float TtotalDesconexion { get; set; }
        public float TiempoPSist { get; set; }
        public float TiempoPOper { get; set; }
        public string RowId { get; set; }

        public RRegFallaComponente() { RowId = "0"; }

        public RRegFallaComponente(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            PotenciaDesconectada = GetValor<float>(dataRow[C_POTENCIA_DESCONECTADA]);
            TiempoIndisponibilidad = GetValor<float>(dataRow[C_TIEMPO_INDISPONIBILIDAD]);
            TiempoPreconexion = GetValor<float>(dataRow[C_TIEMPO_PRECONEXION]);
            TiempoConexion = GetValor<float>(dataRow[C_TIEMPO_CONEXION]);
            TiempoSistema =(float) GetValor<double>(dataRow[C_TIEMPO_SISTEMA]);
            DCodMotivo = GetValor<long>(dataRow[C_D_COD_MOTIVO]);
            FkCodResponsable = GetValor<long>(dataRow[C_FK_COD_RESPONSABLE]);
            FecApertura = GetValor<DateTime>(dataRow[C_FEC_APERTURA]);
            DCodTipoperacionapertura = GetValor<long>(dataRow[C_D_COD_TIPOPERACIONAPERTURA]);
            FecCierre = GetValor<DateTime>(dataRow[C_FEC_CIERRE]);
            DCodTipooperacioncierre = GetValor<long>(dataRow[C_D_COD_TIPOOPERACIONCIERRE]);
            EtapaEdac = GetValor<string>(dataRow[C_ETAPA_EDAC]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            FlujoN1N2 = (TipoFlujoNodo)Enum.Parse(typeof(TipoFlujoNodo), GetValor<string>(dataRow[C_FLUJO_N1_N2], TipoFlujoNodo.Positivo.ToString()));
            TtotalDesconexion = GetValor<float>(dataRow[C_TTOTAL_DESCONEXION]);
            TiempoPSist = GetValor<float>(dataRow[C_TIEMPO_P_SIST]);
            TiempoPOper =(float)GetValor<double>(dataRow[C_TIEMPO_P_OPER]);
            if (dataRow.Table.Columns.Contains(C_ROW_ID))
            {
                RowId = GetValor<string>(dataRow[C_ROW_ID]);
            }
            if (RowId == null)
            {
                RowId = string.Empty;
            }
        }

        public TiempoDetalle GetNuevoTiempo()
        {
            TiempoDetalle resultado = new TiempoDetalle();
            resultado.PkCodComponente = this.PkCodComponente;
            resultado.PkCodFalla = this.PkCodFalla;
            resultado.PkDCodTipoinforme = this.PkDCodTipoinforme;
            resultado.PkOrigenInforme = this.PkOrigenInforme;
            resultado.FecApertura = this.FecApertura;
            resultado.EsNuevo = true;
            return resultado;
        }

        public AsignacionResposabilidad GetNuevoAsignacionResp()
        {
            AsignacionResposabilidad resultado = new AsignacionResposabilidad();
            resultado.PkCodComponente = this.PkCodComponente;
            resultado.PkCodFalla = this.PkCodFalla;
            resultado.PkDCodTipoinforme = this.PkDCodTipoinforme;
            resultado.PkOrigenInforme = this.PkOrigenInforme;
            resultado.FecApertura = this.FecApertura;
            resultado.EsNuevo = true;
            return resultado;
        }
    }

    public interface IRRegFallaComponente
    {
        DateTime FecApertura { get; set; }
        TipoFlujoNodo FlujoN1N2 { get; set; }
        long PkCodComponente { get; set; }
        float PotenciaDesconectada { get; set; }
        float TiempoConexion { get; set; }
        float TiempoIndisponibilidad { get; set; }
        float TiempoPreconexion { get; set; }
        float TiempoSistema { get; set; }
    }

    public enum TipoFlujoNodo
    {
        Positivo,
        Negativo
    }

    public interface IRRegFallaComponenteMgr
    {
        void Guardar(RRegFallaComponente obj);
        DataTable GetTabla();
        BindingList<RRegFallaComponente> GetLista();
        DataTable GetTablaVisualizable();
        DataTable GetTablaVisualizable(InformeFalla informe);
        int CopiarCompComproDeAgentes(InformeFalla informe);

        void Borrar(RRegFallaComponente _compComprSeleccionado);

        bool SolapaTiempos(RRegFallaComponente _compComprometido);

        void Refrescar(DataRow _rowSeleccionado);
    }
}