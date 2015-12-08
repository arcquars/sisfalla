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
    public class P_GF_Correos : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_GF_CORREOS";

        public const string C_PK_COD_CORREO = "PK_COD_CORREO";
        public const string C_D_COD_SECC_CORREO = "D_COD_SECC_CORREO";
        public const string C_FK_TRANSACCION = "FK_TRANSACCION";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_TEXTO = "TEXTO";
        public const string C_SINC_VER = "SINC_VER";

        public long PkCodCorreo { get; set; }
        public long DCodSeccCorreo { get; set; }
        public long FkTransaccion { get; set; }
        public long DCodEstado { get; set; }
        public string Texto { get; set; }
        public long SincVer { get; set; }

        public P_GF_Correos() { }

        public P_GF_Correos(DataRow dataRow)
        {
            PkCodCorreo = GetValor<long>(dataRow[C_PK_COD_CORREO]);
            DCodSeccCorreo = GetValor<long>(dataRow[C_D_COD_SECC_CORREO]);
            FkTransaccion = GetValor<long>(dataRow[C_FK_TRANSACCION]);
            DCodEstado = GetValor<long>(dataRow[C_D_COD_ESTADO]);
            Texto = GetValor<string>(dataRow[C_TEXTO]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_CORREO] = PkCodCorreo;
            dataRow[C_D_COD_SECC_CORREO] = DCodSeccCorreo;
            dataRow[C_FK_TRANSACCION] = FkTransaccion;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_TEXTO] = Texto;
            dataRow[C_SINC_VER] = SincVer;
        }
    }

    public interface IP_GF_CorreosMgr
    {
        void Guardar(P_GF_Correos obj);
        DataTable GetTabla();
        BindingList<P_GF_Correos> GetLista();

        P_GF_Correos Get(long pkCodTransac, CNDC.Dominios.D_COD_SECC_CORREO d_COD_SECC_CORREO);
    }
}