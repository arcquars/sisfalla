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
    public class OperacionAlimentador : ObjetoDeNegocio, IOperacionAlimentador
    {
        public const string NOMBRE_TABLA = "F_GF_OP_ALIMENTADOR";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_D_COD_INFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_FECHA_APERTURA = "FECHA_APERTURA";
        public const string C_D_COD_TIPO_OPER_APER = "D_COD_TIPO_OPER_APER";
        public const string C_FECHA_CIERRE = "FECHA_CIERRE";
        public const string C_RELE_OPERADO = "RELE_OPERADO";
        public const string C_D_COD_TIPO_OP_CIERRE = "D_COD_TIPO_OP_CIERRE";
        public const string C_POT_DESC = "POT_DESC";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_COD_EDAC = "COD_EDAC";
        public const string C_ROW_ID = "RowId";

        public int PkCodFalla { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkDCodInforme { get; set; }
        public long PkCodComponente { get; set; }
        public DateTime FechaApertura { get; set; }
        public decimal DCodTipoOperAper { get; set; }
        public DateTime FechaCierre { get; set; }
        public short ReleOperado { get; set; }
        public decimal DCodTipoOpCierre { get; set; }
        public float PotDesc { get; set; }
        public long SincVer { get; set; }
        public long CodEdac { get; set; }
        public string RowId { get; set; }

        public OperacionAlimentador() { RowId = "0"; }

        public OperacionAlimentador(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodInforme = GetValor<long>(dataRow[C_PK_D_COD_INFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            FechaApertura = GetValor<DateTime>(dataRow[C_FECHA_APERTURA]);
            DCodTipoOperAper = GetValor<decimal>(dataRow[C_D_COD_TIPO_OPER_APER]);
            FechaCierre = GetValor<DateTime>(dataRow[C_FECHA_CIERRE]);
            ReleOperado = GetValor<short>(dataRow[C_RELE_OPERADO]);
            DCodTipoOpCierre = GetValor<decimal>(dataRow[C_D_COD_TIPO_OP_CIERRE]);
            PotDesc = GetValor<float>(dataRow[C_POT_DESC]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            CodEdac = GetValor<long>(dataRow[C_COD_EDAC]);

            if (dataRow.Table.Columns.Contains(C_ROW_ID))
            {
                RowId = GetValor<string>(dataRow[C_ROW_ID]);
            }
            if (RowId == null)
            {
                RowId = string.Empty;
            }
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[C_PK_ORIGEN_INFORME] = PkOrigenInforme;
            dataRow[C_PK_D_COD_INFORME] = PkDCodInforme;
            dataRow[C_PK_COD_COMPONENTE] = PkCodComponente;
            dataRow[C_FECHA_APERTURA] = FechaApertura;
            dataRow[C_D_COD_TIPO_OPER_APER] = DCodTipoOperAper;
            dataRow[C_FECHA_CIERRE] = FechaCierre;
            dataRow[C_RELE_OPERADO] = ReleOperado;
            dataRow[C_D_COD_TIPO_OP_CIERRE] = DCodTipoOpCierre;
            dataRow[C_POT_DESC] = PotDesc;
            dataRow[C_SINC_VER] = SincVer;
            dataRow[C_COD_EDAC] = CodEdac;
        }
    }

    public interface IOperacionAlimentador
    {
        decimal DCodTipoOpCierre { get; set; }
        decimal DCodTipoOperAper { get; set; }
        DateTime FechaApertura { get; set; }
        DateTime FechaCierre { get; set; }
        long PkCodComponente { get; set; }
        float PotDesc { get; set; }
        short ReleOperado { get; set; }
    }

    public interface IOperacionAlimentadorMgr
    {
        void Guardar(OperacionAlimentador obj);
        DataTable GetTabla();
        BindingList<OperacionAlimentador> GetLista();
        DataTable GetOpeAlim(InformeFalla informe);
        DataTable GetOpeAlimConOpEdac(InformeFalla informe);
        DataTable GetEtapasConEdac(string Agente,int Categoria, string fecha);
        DataTable GetEtapasDeEdac(int Categoria);
        long GetEtapasDeEdac(string descripcion);
        DataTable GetAlimentadoresEdac(String Agente);
        DataTable GetAgentesDeEdac(DateTime fecha);
        string GetUltimoEdac();
        bool ExistePeriodoEdac(PeriodoEdac periodo);
        void InsertarPeriodoEdac(PeriodoEdac periodo);
        void ActualizarPeriodoEdac(PeriodoEdac periodo);
        bool CrearNuevoPeriodo(DateTime periodo, DateTime nuevoPeriodo);
        bool ModificarNuevoPeriodo(DateTime periodo, DateTime nuevoPeriodo);
        void BorrarPeriodoEdac(PeriodoEdac periodo);
        DataTable GetPotenciaPorAgenteConOpEdac(InformeFalla informe);
        Edac GetEdac(decimal codComponente, DateTime fecha);
        void Borrar(OperacionAlimentador opAlimenSeleccionado);
        void GopiarAlimentador(DataRow row, InformeFalla informeDestino);
        int CopiarAlimentadoresDeAgentes(InformeFalla infFalla);
        bool SolapaTiempos(OperacionAlimentador opAlim);
        void Refrescar(OperacionAlimentador _opAlimenSeleccionado, DataRow _rowSeleccionado);
    }
}