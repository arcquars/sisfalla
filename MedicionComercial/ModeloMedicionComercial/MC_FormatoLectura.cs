using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.UtilesComunes;

namespace MC
{
    [Serializable]
    public class MC_FormatoLectura : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_MC_FTO_LECTURA";

        public const string C_PK_COD_FTO = "PK_COD_FTO";
        public const string C_DESCRIPCION_FTO = "DESCRIPCION_FTO";
        public const string C_EXTENSION = "EXTENSION";
        public const string C_VERSION = "VERSION";
        public const string C_DLL_LECTOR = "DLL_LECTOR";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_CLASE_LECTOR = "CLASE_LECTOR";

        public long PkCodFto { get; set; }
        public string DescripcionFto { get; set; }
        public string Extension { get; set; }
        public short Version { get; set; }
        public string DllLector { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public string ClaseLector { get; set; }

        public MC_FormatoLectura() { }

        public MC_FormatoLectura(DataRow dataRow)
        {
            PkCodFto = GetValor<long>(dataRow[C_PK_COD_FTO]);
            DescripcionFto = GetValor<string>(dataRow[C_DESCRIPCION_FTO]);
            Extension = GetValor<string>(dataRow[C_EXTENSION]);
            Version = GetValor<short>(dataRow[C_VERSION]);
            DllLector = GetValor<string>(dataRow[C_DLL_LECTOR]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            ClaseLector = GetValor<string>(dataRow[C_CLASE_LECTOR]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FTO] = PkCodFto;
            dataRow[C_DESCRIPCION_FTO] = DescripcionFto;
            dataRow[C_EXTENSION] = Extension;
            dataRow[C_VERSION] = Version;
            dataRow[C_DLL_LECTOR] = DllLector;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_CLASE_LECTOR] = ClaseLector;
        }
    }

    public interface IMC_FormatoLecturaMgr
    {
        void Guardar(MC_FormatoLectura obj);
        DataTable GetTabla();
        BindingList<MC_FormatoLectura> GetLista();
    }   
}