using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloProyectos
{
    [Serializable]
    public class VolumenVsFactorDeProduccion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_VOL_VS_FACT_PRODUCCION";

        public const string C_PK_VOL_VS_FACT_PRODUCCION = "PK_VOL_VS_FACT_PRODUCCION";
        public const string C_FK_DATO_TEC_HIDROELECTRICO = "FK_DATO_TEC_HIDROELECTRICO";
        public const string C_VOLUMEN = "VOLUMEN";
        public const string C_FACTOR_PRODUCTIVIDAD = "FACTOR_PRODUCTIVIDAD";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkVolVsFactProduccion { get; set; }
        public long FkDatoTecHidroelectrico { get; set; }
        public double Volumen { get; set; }
        public double FactorProductividad { get; set; }
        public long SecLog { get; set; }

        public VolumenVsFactorDeProduccion() { }

        public VolumenVsFactorDeProduccion(DataRow dataRow)
        {
            PkVolVsFactProduccion = GetValor<long>(dataRow[C_PK_VOL_VS_FACT_PRODUCCION]);
            FkDatoTecHidroelectrico = GetValor<long>(dataRow[C_FK_DATO_TEC_HIDROELECTRICO]);
            Volumen = GetValor<double>(dataRow[C_VOLUMEN]);
            FactorProductividad = GetValor<double>(dataRow[C_FACTOR_PRODUCTIVIDAD]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_VOL_VS_FACT_PRODUCCION] = PkVolVsFactProduccion;
            dataRow[C_FK_DATO_TEC_HIDROELECTRICO] = FkDatoTecHidroelectrico;
            dataRow[C_VOLUMEN] = Volumen;
            dataRow[C_FACTOR_PRODUCTIVIDAD] = FactorProductividad;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public override void Leer(DataRow dataRow)
        {
            PkVolVsFactProduccion = GetValor<long>(dataRow[C_PK_VOL_VS_FACT_PRODUCCION]);
            FkDatoTecHidroelectrico = GetValor<long>(dataRow[C_FK_DATO_TEC_HIDROELECTRICO]);
            Volumen = GetValor<double>(dataRow[C_VOLUMEN]);
            FactorProductividad = GetValor<double>(dataRow[C_FACTOR_PRODUCTIVIDAD]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }
    }

    public interface IVolumenVsFactorDeProduccionMgr
    {
        void Guardar(VolumenVsFactorDeProduccion obj);
        DataTable GetTabla();
        BindingList<VolumenVsFactorDeProduccion> GetLista();
    }
}
