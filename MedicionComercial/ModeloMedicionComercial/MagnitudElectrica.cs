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
    public class MagnitudElectrica : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_MC_DEF_MAGNITUD_ELEC";

        public const string C_NOMBRE_MAGNITUD_ELEC = "NOMBRE_MAGNITUD_ELEC";
        public const string C_DESCRIPCION_MAG_ELEC = "DESCRIPCION_MAG_ELEC";
        public const string C_UNIDADES = "UNIDADES";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_PK_COD_MAGNITUD_ELEC = "PK_COD_MAGNITUD_ELEC";

        public string NombreMagnitudElec { get; set; }
        public string DescripcionMagElec { get; set; }
        public string Unidades { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long PkCodMagnitudElec { get; set; }

        public MagnitudElectrica() { }

        public MagnitudElectrica(DataRow dataRow)
        {
            NombreMagnitudElec = GetValor<string>(dataRow[C_NOMBRE_MAGNITUD_ELEC]);
            DescripcionMagElec = GetValor<string>(dataRow[C_DESCRIPCION_MAG_ELEC]);
            Unidades = GetValor<string>(dataRow[C_UNIDADES]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            PkCodMagnitudElec = GetValor<long>(dataRow[C_PK_COD_MAGNITUD_ELEC]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_NOMBRE_MAGNITUD_ELEC] = NombreMagnitudElec;
            dataRow[C_DESCRIPCION_MAG_ELEC] = DescripcionMagElec;
            dataRow[C_UNIDADES] = Unidades;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_PK_COD_MAGNITUD_ELEC] = PkCodMagnitudElec;
        }
    }

    public interface IMagnitudElectricaMgr
    {
        void Guardar(MagnitudElectrica obj);
        DataTable GetTabla();
        BindingList<MagnitudElectrica> GetLista();
    }
}
