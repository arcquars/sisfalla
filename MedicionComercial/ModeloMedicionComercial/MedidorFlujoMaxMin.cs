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
    public class MedidorFlujoMaxMin : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_MEDIDOR_FLUJO_MAX_MIN";

        public const string C_PK_COD_MED_MAX_MIN = "PK_COD_MED_MAX_MIN";
        public const string C_FK_COD_MEDIDOR = "FK_COD_MEDIDOR";
        public const string C_DESDE = "DESDE";
        public const string C_HASTA = "HASTA";

        public long PkCodMedMaxMin { get; set; }
        public long FkCodMedidor { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public MedidorFlujoMaxMin() { }

        public MedidorFlujoMaxMin(DataRow dataRow)
        {
            PkCodMedMaxMin = GetValor<long>(dataRow[C_PK_COD_MED_MAX_MIN]);
            FkCodMedidor = GetValor<long>(dataRow[C_FK_COD_MEDIDOR]);
            Desde = GetValor<DateTime>(dataRow[C_DESDE]);
            Hasta = GetValor<DateTime>(dataRow[C_HASTA]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_MED_MAX_MIN] = PkCodMedMaxMin;
            dataRow[C_FK_COD_MEDIDOR] = FkCodMedidor;
            dataRow[C_DESDE] = Desde;
            dataRow[C_HASTA] = Hasta;
        }
    }

    public interface IMedidorFlujoMaxMinMgr
    {
        bool Guardar(MedidorFlujoMaxMin obj);
        DataTable GetTabla();
        BindingList<MedidorFlujoMaxMin> GetLista();
    }
}