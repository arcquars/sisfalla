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
    public class Colapso : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_COLAPSO";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_D_COD_ZONA = "PK_D_COD_ZONA";
        public const string C_SINC_VER = "SINC_VER";

        public int PkCodFalla { get; set; }
        public long PkDCodZona { get; set; }

        public Colapso() { }

        public Colapso(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkDCodZona = GetValor<long>(dataRow[C_PK_D_COD_ZONA]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[C_PK_D_COD_ZONA] = PkDCodZona;
        }
    }

    public interface IColapsoMgr
    {
        void Guardar(Colapso obj);
        DataTable GetTabla();
        BindingList<Colapso> GetLista();

        List<Colapso> GetLista(int p);

        void Guardar(List<Colapso> listaColapso, int numFalla);

        DataTable GetDatos(int PkCodFalla);
    }
}
