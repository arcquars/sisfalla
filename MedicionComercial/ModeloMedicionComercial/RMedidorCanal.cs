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
    public class RMedidorCanal : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_RMEDIDOR_CANALES";

        public const string C_FK_COD_MEDIDOR = "FK_COD_MEDIDOR";
        public const string C_CANAL = "CANAL";
        public const string C_FK_COD_INFCANAL = "FK_COD_INFCANAL";
        public const string C_KC = "KC";
        public const string C_KCT = "KCT";
        public const string C_KPT = "KPT";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_PK_COD_RMED_CANAL = "PK_COD_RMED_CANAL";
        public const string C_COL_ARCHIVO = "COL_ARCHIVO";
        public const string C_FK_COD_FORMATO = "FK_COD_FORMATO";

        public long FkCodMedidor { get; set; }
        public long Canal { get; set; }
        public long FkCodInfcanal { get; set; }
        public double Kc { get; set; }
        public double Kct { get; set; }
        public double Kpt { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long PkCodRmedCanal { get; set; }
        public string ColArchivo { get; set; }
        public long FkCodFormato { get; set; }

        public RMedidorCanal() { }

        public RMedidorCanal(DataRow dataRow)
        {
            FkCodMedidor = GetValor<long>(dataRow[C_FK_COD_MEDIDOR]);
            Canal = GetValor<long>(dataRow[C_CANAL]);
            FkCodInfcanal = GetValor<long>(dataRow[C_FK_COD_INFCANAL]);
            Kc = GetValor<double>(dataRow[C_KC]);
            Kct = GetValor<double>(dataRow[C_KCT]);
            Kpt = GetValor<double>(dataRow[C_KPT]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            PkCodRmedCanal = GetValor<long>(dataRow[C_PK_COD_RMED_CANAL]);
            ColArchivo = GetValor<string>(dataRow[C_COL_ARCHIVO]);
            FkCodFormato = GetValor<long>(dataRow[C_FK_COD_FORMATO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_FK_COD_MEDIDOR] = FkCodMedidor;
            dataRow[C_CANAL] = Canal;
            dataRow[C_FK_COD_INFCANAL] = FkCodInfcanal;
            dataRow[C_KC] = Kc;
            dataRow[C_KCT] = Kct;
            dataRow[C_KPT] = Kpt;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_PK_COD_RMED_CANAL] = PkCodRmedCanal;
            dataRow[C_COL_ARCHIVO] = ColArchivo;
            dataRow[C_FK_COD_FORMATO] = FkCodFormato;
        }

        public int GetNumColumna()
        {
            int resultado = ColArchivo[0] - 'A';
            return resultado;
        }
    }

    public interface IRMedidorCanalMgr
    {
        bool Guardar(RMedidorCanal obj);
        DataTable GetTabla();
        BindingList<RMedidorCanal> GetLista();
    }
}
