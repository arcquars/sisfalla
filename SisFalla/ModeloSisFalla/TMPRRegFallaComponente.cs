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
    public class RRegFallaComponente : ObjetoDeNegocio
    {
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
        public const string C_COD_ANT = "COD_ANT";
        public const string C_AGENTE_ANT = "AGENTE_ANT";
        public const string C_COMP_ANT = "COMP_ANT";
        public const string C_TIPO_INF_ANT = "TIPO_INF_ANT";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_FLUJO_N1_N2 = "FLUJO_N1_N2";
        public const string C_TTOTAL_DESCONEXION = "TTOTAL_DESCONEXION";

        public int PkCodFalla { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public decimal PkCodComponente { get; set; }
        public Single PotenciaDesconectada { get; set; }
        public DateTime TiempoIndisponibilidad { get; set; }
        public DateTime TiempoPreconexion { get; set; }
        public DateTime TiempoConexion { get; set; }
        public DateTime TiempoSistema { get; set; }
        public DateTime TTotalDesconexion { get; set; }
        public long DCodMotivo { get; set; }
        public long FkCodResponsable { get; set; }
        public DateTime FecApertura { get; set; }
        public long DCodTipoperacionapertura { get; set; }
        public DateTime FecCierre { get; set; }
        public long DCodTipooperacioncierre { get; set; }
        public string EtapaEdac { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public string CodAnt { get; set; }
        public string AgenteAnt { get; set; }
        public string CompAnt { get; set; }
        public string TipoInfAnt { get; set; }
        public long SincVer { get; set; }
        public TipoFlujoNodo FlujoN1N2 { get; set; }

        public RRegFallaComponente() { }

        public RRegFallaComponente(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            PkCodComponente = GetValor<decimal>(dataRow[C_PK_COD_COMPONENTE]);
            PotenciaDesconectada = GetValor<Single>(dataRow[C_POTENCIA_DESCONECTADA]);
            TiempoIndisponibilidad = GetValor<DateTime>(dataRow[C_TIEMPO_INDISPONIBILIDAD]);
            TiempoPreconexion = GetValor<DateTime>(dataRow[C_TIEMPO_PRECONEXION]);
            TiempoConexion = GetValor<DateTime>(dataRow[C_TIEMPO_CONEXION]);
            TiempoSistema = GetValor<DateTime>(dataRow[C_TIEMPO_SISTEMA]);
            TTotalDesconexion = GetValor<DateTime>(dataRow[C_TIEMPO_SISTEMA]);
            DCodMotivo = GetValor<long>(dataRow[C_D_COD_MOTIVO]);
            FkCodResponsable = GetValor<long>(dataRow[C_FK_COD_RESPONSABLE]);
            FecApertura = GetValor<DateTime>(dataRow[C_FEC_APERTURA]);
            DCodTipoperacionapertura = GetValor<long>(dataRow[C_D_COD_TIPOPERACIONAPERTURA]);
            FecCierre = GetValor<DateTime>(dataRow[C_FEC_CIERRE]);
            DCodTipooperacioncierre = GetValor<long>(dataRow[C_D_COD_TIPOOPERACIONCIERRE]);
            EtapaEdac = GetValor<string>(dataRow[C_ETAPA_EDAC]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            CodAnt = GetValor<string>(dataRow[C_COD_ANT]);
            AgenteAnt = GetValor<string>(dataRow[C_AGENTE_ANT]);
            CompAnt = GetValor<string>(dataRow[C_COMP_ANT]);
            TipoInfAnt = GetValor<string>(dataRow[C_TIPO_INF_ANT]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            FlujoN1N2 = (TipoFlujoNodo)Enum.Parse(typeof(TipoFlujoNodo), GetValor<string>(dataRow[C_FLUJO_N1_N2],TipoFlujoNodo.Positivo.ToString()));
        }

        private static Dictionary<string, EstiloColumna> _estilos;
        static RRegFallaComponente()
        {
            _estilos = new Dictionary<string, EstiloColumna>();
            
            EstiloColumna e = new EstiloColumna();
            e.NombreColumna = RRegFallaComponente.C_FEC_APERTURA;
            e.TextoColumna = "Fecha";
            e.Alineacion = AlineacionColumna.Der;
            e.Ancho = 110;
            e.Formato = "dd/MM/yyyy HH:mm:ss";
            _estilos[RRegFallaComponente.C_FEC_APERTURA] = e;

            e = new EstiloColumna();
            e.NombreColumna = RRegFallaComponente.C_POTENCIA_DESCONECTADA;
            e.TextoColumna = "Pot.Desc";
            e.Alineacion = AlineacionColumna.Der;
            e.Ancho = 80;
            e.Formato = "";
            _estilos[RRegFallaComponente.C_POTENCIA_DESCONECTADA] = e;

            e = new EstiloColumna();
            e.NombreColumna = RRegFallaComponente.C_FLUJO_N1_N2;
            e.TextoColumna = "Flujo_nodo";
            e.Alineacion = AlineacionColumna.Izq;
            e.Ancho = 80;
            e.Formato = "";
            _estilos[RRegFallaComponente.C_FLUJO_N1_N2] = e;

            e = new EstiloColumna();
            e.NombreColumna = RRegFallaComponente.C_TTOTAL_DESCONEXION;
            e.TextoColumna = "T.Desc";
            e.Alineacion = AlineacionColumna.Der;
            e.Ancho = 80;
            e.Formato = "";
            _estilos[RRegFallaComponente.C_TTOTAL_DESCONEXION] = e;
        }

        public static EstiloColumna GetEstilo(string p)
        {
            EstiloColumna s = null;
            if (_estilos.ContainsKey(p))
            {
                s = _estilos[p];
            }
            return s;
        }
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
    }
}