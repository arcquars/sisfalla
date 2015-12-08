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
    public class MedidorFlujoMaxMinDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_MEDIDOR_FLUJO_MAX_MIN_DET";

        public const string C_PK_COD_MED_MAX_MIN = "PK_COD_MED_MAX_MIN";
        public const string C_MINIMO = "MINIMO";
        public const string C_MAXIMO = "MAXIMO";
        public const string C_PK_COD_MAGNITUD_ELEC = "PK_COD_MAGNITUD_ELEC";

        public long PkCodMedMaxMin { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }
        public long PkCodMagnitudElec { get; set; }

        public MedidorFlujoMaxMinDetalle() { }

        public MedidorFlujoMaxMinDetalle(DataRow dataRow)
        {
            PkCodMedMaxMin = GetValor<long>(dataRow[C_PK_COD_MED_MAX_MIN]);
            Minimo = GetValor<double>(dataRow[C_MINIMO]);
            Maximo = GetValor<double>(dataRow[C_MAXIMO]);
            PkCodMagnitudElec = GetValor<long>(dataRow[C_PK_COD_MAGNITUD_ELEC]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_MED_MAX_MIN] = PkCodMedMaxMin;
            dataRow[C_MINIMO] = Minimo;
            dataRow[C_MAXIMO] = Maximo;
            dataRow[C_PK_COD_MAGNITUD_ELEC] = PkCodMagnitudElec;
        }
    }

    public interface IMedidorFlujoMaxMinDetalleMgr
    {
        bool Guardar(MedidorFlujoMaxMinDetalle obj);
        DataTable GetTabla();
        BindingList<MedidorFlujoMaxMinDetalle> GetLista();
    }
}