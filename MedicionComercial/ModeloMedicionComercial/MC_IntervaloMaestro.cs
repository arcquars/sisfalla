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
    public class MC_IntervaloMaestro : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_MC_INTERVALO_MAESTRO";

        public const string C_PK_COD_INTERVALO_MAESTRO = "PK_COD_INTERVALO_MAESTRO";
        public const string C_NOMBRE = "NOMBRE";
        public const string C_PERIODO_TIEMPO = "PERIODO_TIEMPO";
        public const string C_FECHA_DESDE = "FECHA_DESDE";
        public const string C_FECHA_HASTA = "FECHA_HASTA";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodIntervaloMaestro { get; set; }
        public string Nombre { get; set; }
        public int PeriodoTiempo { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public short DCodEstado { get; set; }
        public long SecLog { get; set; }

        public MC_IntervaloMaestro() { }

        public MC_IntervaloMaestro(DataRow dataRow)
        {
            PkCodIntervaloMaestro = GetValor<long>(dataRow[C_PK_COD_INTERVALO_MAESTRO]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
            PeriodoTiempo = GetValor<int>(dataRow[C_PERIODO_TIEMPO]);
            FechaDesde = GetValor<DateTime>(dataRow[C_FECHA_DESDE]);
            FechaHasta = GetValor<DateTime?>(dataRow[C_FECHA_HASTA]);
            DCodEstado = GetValor<short>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_INTERVALO_MAESTRO] = PkCodIntervaloMaestro;
            dataRow[C_NOMBRE] = Nombre;
            dataRow[C_PERIODO_TIEMPO] = PeriodoTiempo;
            dataRow[C_FECHA_DESDE] = FechaDesde;
            if (FechaHasta == null)
            {
                dataRow[C_FECHA_HASTA] = System.DBNull.Value;
            }
            else
            {
                dataRow[C_FECHA_HASTA] = FechaHasta.Value;
            }
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
        }
    }

    public interface IMC_IntervaloMaestroMgr
    {
        bool Guardar(MC_IntervaloMaestro obj);
        DataTable GetTabla();
        BindingList<MC_IntervaloMaestro> GetLista();
        MC_IntervaloMaestro GetIntervaloPorFecha(DateTime fecha);
    }

    public class MC_IntervaloMaestroMgr
    {
        #region Singleton
        private static IMC_IntervaloMaestroMgr _instancia;
        public static IMC_IntervaloMaestroMgr Instancia
        {
            get { return _instancia; }
        }

        static MC_IntervaloMaestroMgr()
        {
            _instancia = Instanciador.Instancia.IntanciarPlugin<IMC_IntervaloMaestroMgr>();
        }

        #endregion Singleton
    }
}
