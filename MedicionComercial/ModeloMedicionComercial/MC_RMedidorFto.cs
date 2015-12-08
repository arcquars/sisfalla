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
    public class MC_RMedidorFto : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_RMEDIDOR_FTO";

        public const string C_PK_COD_MEDIDOR = "PK_COD_MEDIDOR";
        public const string C_PK_COD_FORMATO = "PK_COD_FORMATO";
        public const string C_NOMBRE_ARCHIVO = "NOMBRE_ARCHIVO";
        public const string C_PRIORIDAD_LECTURA = "PRIORIDAD_LECTURA";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_CONTIENE_FIN_INTERVALO = "CONTIENE_FIN_INTERVALO";

        public long PkCodMedidor { get; set; }
        public long PkCodFormato { get; set; }
        public string NombreArchivo { get; set; }
        public short PrioridadLectura { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public short ContieneFinIntervalo { get; set; }

        public MC_RMedidorFto() { }

        public MC_RMedidorFto(DataRow dataRow)
        {
            PkCodMedidor = GetValor<long>(dataRow[C_PK_COD_MEDIDOR]);
            PkCodFormato = GetValor<long>(dataRow[C_PK_COD_FORMATO]);
            NombreArchivo = GetValor<string>(dataRow[C_NOMBRE_ARCHIVO]);
            PrioridadLectura = GetValor<short>(dataRow[C_PRIORIDAD_LECTURA]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            ContieneFinIntervalo = GetValor<short>(dataRow[C_CONTIENE_FIN_INTERVALO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_MEDIDOR] = PkCodMedidor;
            dataRow[C_PK_COD_FORMATO] = PkCodFormato;
            dataRow[C_NOMBRE_ARCHIVO] = NombreArchivo;
            dataRow[C_PRIORIDAD_LECTURA] = PrioridadLectura;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_CONTIENE_FIN_INTERVALO] = ContieneFinIntervalo;
        }
    }

    public interface IMC_RMedidorFtoMgr
    {
        void Guardar(MC_RMedidorFto obj);
        DataTable GetTabla();
        BindingList<MC_RMedidorFto> GetLista();
    }
}
