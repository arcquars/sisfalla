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
    public class MC_IntervaloDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_MC_INTERVALO_DETALLE";

        public const string C_PK_COD_INTERVALO = "PK_COD_INTERVALO";
        public const string C_HORA_INTERVALO = "HORA_INTERVALO";
        public const string C_NUMERO_INTERVALO = "NUMERO_INTERVALO";
        public const string C_FK_COD_INTERVALO_MAESTRO = "FK_COD_INTERVALO_MAESTRO";

        public long PkCodIntervalo { get; set; }
        public string HoraIntervalo { get; set; }
        public int NumeroIntervalo { get; set; }
        public long FkCodIntervaloMaestro { get; set; }

        public MC_IntervaloDetalle() { }

        public MC_IntervaloDetalle(DataRow dataRow)
        {
            PkCodIntervalo = GetValor<long>(dataRow[C_PK_COD_INTERVALO]);
            HoraIntervalo = GetValor<string>(dataRow[C_HORA_INTERVALO]);
            NumeroIntervalo = GetValor<int>(dataRow[C_NUMERO_INTERVALO]);
            FkCodIntervaloMaestro = GetValor<long>(dataRow[C_FK_COD_INTERVALO_MAESTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_INTERVALO] = PkCodIntervalo;
            dataRow[C_HORA_INTERVALO] = HoraIntervalo;
            dataRow[C_NUMERO_INTERVALO] = NumeroIntervalo;
            dataRow[C_FK_COD_INTERVALO_MAESTRO] = FkCodIntervaloMaestro;
        }
    }

    public interface IMC_IntervaloDetalleMgr
    {
        void Guardar(MC_IntervaloDetalle obj);
        DataTable GetTabla();
        BindingList<MC_IntervaloDetalle> GetLista();

        DataTable GetPorPkCodMaestro(long p);

        List<MC_IntervaloDetalle> GetLista(DateTime desde, DateTime hasta);
    }

    public class MC_IntervaloDetalleMgr
    {
        #region Singleton
        private static IMC_IntervaloDetalleMgr _instancia;
        public static IMC_IntervaloDetalleMgr Instancia
        {
            get { return _instancia; }
        }

        static MC_IntervaloDetalleMgr()
        {
            _instancia = Instanciador.Instancia.IntanciarPlugin<IMC_IntervaloDetalleMgr>();
        }

        #endregion Singleton
    }
}
