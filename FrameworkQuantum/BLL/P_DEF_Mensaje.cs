using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace CNDC.BLL
{
    [Serializable]
    public class P_DEF_Mensaje : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_DEF_MENSAJE";

        public const string C_COD_MENSAJE = "COD_MENSAJE";
        public const string C_TEXTO_MENSAJE = "TEXTO_MENSAJE";
        public const string C_SINC_VER = "SINC_VER";

        public string CodMensaje { get; set; }
        public string TextoMensaje { get; set; }
        public long SincVer { get; set; }

        public P_DEF_Mensaje() { }

        public P_DEF_Mensaje(DataRow dataRow)
        {
            CodMensaje = GetValor<string>(dataRow[C_COD_MENSAJE]);
            TextoMensaje = GetValor<string>(dataRow[C_TEXTO_MENSAJE]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_COD_MENSAJE] = CodMensaje;
            dataRow[C_TEXTO_MENSAJE] = TextoMensaje;
            dataRow[C_SINC_VER] = SincVer;
        }
    }

    public interface IP_DEF_MensajeMgr
    {
        void Guardar(P_DEF_Mensaje obj);
        DataTable GetTabla();
        BindingList<P_DEF_Mensaje> GetLista();
    }
}