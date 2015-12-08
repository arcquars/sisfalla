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
    public class MC_MedidorMaxMin : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_MEDIDOR_FLUJO_MAX_MIN";

        public const string C_PK_COD_MEDIDOR = "PK_COD_MEDIDOR";
        public const string C_PK_DESDE = "PK_DESDE";
        public const string C_HASTA = "HASTA";
        public const string C_MINIMO = "MINIMO";
        public const string C_MAXIMO = "MAXIMO";
        public const string C_PK_COD_MAGNITUD_ELEC = "PK_COD_MAGNITUD_ELEC";

        public long PkCodMedidor { get; set; }
        public DateTime PkDesde { get; set; }
        public DateTime? Hasta { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }
        public long PkCodMagnitudElec { get; set; }

        public MC_MedidorMaxMin() { }

        public MC_MedidorMaxMin(DataRow dataRow)
        {
            PkCodMedidor = GetValor<long>(dataRow[C_PK_COD_MEDIDOR]);
            PkDesde = GetValor<DateTime>(dataRow[C_PK_DESDE]);
            Hasta = GetValor<DateTime?>(dataRow[C_HASTA]);
            Minimo = GetValor<double>(dataRow[C_MINIMO]);
            Maximo = GetValor<double>(dataRow[C_MAXIMO]);
            PkCodMagnitudElec = GetValor<long>(dataRow[C_PK_COD_MAGNITUD_ELEC]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_MEDIDOR] = PkCodMedidor;
            dataRow[C_PK_DESDE] = PkDesde;
            dataRow[C_HASTA] = Hasta;
            dataRow[C_MINIMO] = Minimo;
            dataRow[C_MAXIMO] = Maximo;
            dataRow[C_PK_COD_MAGNITUD_ELEC] = PkCodMagnitudElec;
        }
    }

    public interface IMC_MedidorMaxMinMgr
    {
        bool Guardar(MC_MedidorMaxMin obj);
        DataTable GetTabla();
        BindingList<MC_MedidorMaxMin> GetLista();
    }
}