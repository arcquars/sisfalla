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
    public class VolumenVsArea : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_VOLUMEN_VS_AREA";

        public const string C_PK_VOLUMEN_VS_AREA = "PK_VOLUMEN_VS_AREA";
        public const string C_FK_DATO_TEC_HIDROELECTRICO = "FK_DATO_TEC_HIDROELECTRICO";
        public const string C_VOLUMEN = "VOLUMEN";
        public const string C_AREA = "AREA";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkVolumenVsArea { get; set; }
        public long FkDatoTecHidroelectrico { get; set; }
        public double Volumen { get; set; }
        public double Area { get; set; }
        public long SecLog { get; set; }

        public VolumenVsArea() { }

        public VolumenVsArea(DataRow dataRow)
        {
            PkVolumenVsArea = GetValor<long>(dataRow[C_PK_VOLUMEN_VS_AREA]);
            FkDatoTecHidroelectrico = GetValor<long>(dataRow[C_FK_DATO_TEC_HIDROELECTRICO]);
            Volumen = GetValor<double>(dataRow[C_VOLUMEN]);
            Area = GetValor<double>(dataRow[C_AREA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_VOLUMEN_VS_AREA] = PkVolumenVsArea;
            dataRow[C_FK_DATO_TEC_HIDROELECTRICO] = FkDatoTecHidroelectrico;
            dataRow[C_VOLUMEN] = Volumen;
            dataRow[C_AREA] = Area;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public override void Leer(DataRow dataRow)
        {
            PkVolumenVsArea = GetValor<long>(dataRow[C_PK_VOLUMEN_VS_AREA]);
            FkDatoTecHidroelectrico = GetValor<long>(dataRow[C_FK_DATO_TEC_HIDROELECTRICO]);
            Volumen = GetValor<double>(dataRow[C_VOLUMEN]);
            Area = GetValor<double>(dataRow[C_AREA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }
    }

    public interface IVolumenVsAreaMgr
    {
        void Guardar(VolumenVsArea obj);
        DataTable GetTabla();
        BindingList<VolumenVsArea> GetLista();
    }
}
