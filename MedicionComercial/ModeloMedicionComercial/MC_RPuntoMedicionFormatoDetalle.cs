using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace MC
{
    [Serializable]
    public class MC_RPuntoMedicionFormatoDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_RPTO_MED_FTO_DET";

        public const string C_PK_RPTO_MED_FTO_DET = "PK_RPTO_MED_FTO_DET";
        public const string C_FK_COD_RPTO_MED_FTO = "FK_COD_RPTO_MED_FTO";
        public const string C_FK_COD_MAGNITUD_ELEC = "FK_COD_MAGNITUD_ELEC";
        public const string C_CANAL = "CANAL";
        public const string C_COL_ARCHIVO = "COL_ARCHIVO";
        public const string C_KC = "KC";
        public const string C_KCT = "KCT";
        public const string C_KPT = "KPT";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodRPtoMedFtoDetalle { get; set; }
        public long FkCodRPtoMedFto { get; set; }
        public long FkCodMagnitudElec { get; set; }
        public long Canal { get; set; }
        public string ColArchivo { get; set; }
        public double Kc { get; set; }
        public double Kct { get; set; }
        public double Kpt { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }

        public MC_RPuntoMedicionFormatoDetalle() { }

        public MC_RPuntoMedicionFormatoDetalle(DataRow dataRow)
        {
            FkCodRPtoMedFto = GetValor<long>(dataRow[C_FK_COD_RPTO_MED_FTO]);
            Canal = GetValor<long>(dataRow[C_CANAL]);
            FkCodMagnitudElec = GetValor<long>(dataRow[C_FK_COD_MAGNITUD_ELEC]);
            Kc = GetValor<double>(dataRow[C_KC]);
            Kct = GetValor<double>(dataRow[C_KCT]);
            Kpt = GetValor<double>(dataRow[C_KPT]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            PkCodRPtoMedFtoDetalle = GetValor<long>(dataRow[C_PK_RPTO_MED_FTO_DET]);
            ColArchivo = GetValor<string>(dataRow[C_COL_ARCHIVO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_FK_COD_RPTO_MED_FTO] = FkCodRPtoMedFto;
            dataRow[C_CANAL] = Canal;
            dataRow[C_FK_COD_MAGNITUD_ELEC] = FkCodMagnitudElec;
            dataRow[C_KC] = Kc;
            dataRow[C_KCT] = Kct;
            dataRow[C_KPT] = Kpt;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_PK_RPTO_MED_FTO_DET] = PkCodRPtoMedFtoDetalle;
            dataRow[C_COL_ARCHIVO] = ColArchivo;
        }

        public int GetNumColumna()
        {
            int resultado = ColArchivo[0] - 'A';
            return resultado;
        }
    }

    public interface IRMedidorCanalMgr
    {
        bool Guardar(MC_RPuntoMedicionFormatoDetalle obj);
        DataTable GetTabla();
        BindingList<MC_RPuntoMedicionFormatoDetalle> GetLista();
    }
}
