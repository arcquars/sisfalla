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
    public class OperacionInterruptores : ObjetoDeNegocio, IOperacionInterruptores
    {
        public const string NOMBRE_TABLA = "F_GF_OP_INTERRUPTOR";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_D_COD_INFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_FECHA_APERTURA = "FECHA_APERTURA";
        public const string C_PK_D_COD_TIPO_OPER_APER = "PK_D_COD_TIPO_OPER_APER";
        public const string C_FECHA_CIERRE = "FECHA_CIERRE";
        public const string C_PK_D_COD_TIPO_OPER_CIERRE = "PK_D_COD_TIPO_OPER_CIERRE";
        public const string C_RECONECTADO = "RECONECTADO";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_ROW_ID = "RowId";

        public long PkCodFalla { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkDCodInforme { get; set; }
        public long PkCodComponente { get; set; }
        public DateTime FechaApertura { get; set; }
        public long PkDCodTipoOperAper { get; set; }
        public DateTime FechaCierre { get; set; }
        public long PkDCodTipoOperCierre { get; set; }
        public short Reconectado { get; set; }
        public long SincVer { get; set; }
        public string RowId { get; set; }

        public OperacionInterruptores() { RowId = "0"; }

        public OperacionInterruptores(DataRow dataRow)
        {
            PkCodFalla = GetValor<long>(dataRow[C_PK_COD_FALLA]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodInforme = GetValor<long>(dataRow[C_PK_D_COD_INFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            FechaApertura = GetValor<DateTime>(dataRow[C_FECHA_APERTURA]);
            PkDCodTipoOperAper = GetValor<long>(dataRow[C_PK_D_COD_TIPO_OPER_APER]);
            FechaCierre = GetValor<DateTime>(dataRow[C_FECHA_CIERRE]);
            PkDCodTipoOperCierre = GetValor<long>(dataRow[C_PK_D_COD_TIPO_OPER_CIERRE]);
            Reconectado = GetValor<short>(dataRow[C_RECONECTADO]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);

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
            dataRow[C_PK_D_COD_TIPO_OPER_APER] = PkDCodTipoOperAper;
            dataRow[C_FECHA_CIERRE] = FechaCierre;
            dataRow[C_PK_D_COD_TIPO_OPER_CIERRE] = PkDCodTipoOperCierre;
            dataRow[C_RECONECTADO] = Reconectado;
            dataRow[C_SINC_VER] = SincVer;
        }

        public RelesOperados CrearNuevoReleOperado()
        {
            RelesOperados resultado = new RelesOperados();
            resultado.PkCodComponente = (long)this.PkCodComponente;
            resultado.PkCodFalla = this.PkCodFalla;
            resultado.PkDCodTipoinforme = this.PkDCodInforme;
            resultado.PkOrigenFalla = this.PkOrigenInforme;
            resultado.FecApertura = this.FechaApertura;
            resultado.EsNuevo = true;
            return resultado;
        }
    }

    public interface IOperacionInterruptores
    {
        DateTime FechaApertura { get; set; }
        DateTime FechaCierre { get; set; }
        long PkCodComponente { get; set; }
        long PkDCodTipoOperAper { get; set; }
        long PkDCodTipoOperCierre { get; set; }
        short Reconectado { get; set; }
    }

    public interface IOperacionInterruptoresMgr
    {
        void Guardar(OperacionInterruptores obj);
        DataTable GetTabla();
        BindingList<OperacionInterruptores> GetLista();
        DataTable GetInterruptores(InformeFalla informe);
        void Borrar(OperacionInterruptores interruptorSeleccionado);
        void Copiar(DataRow row, InformeFalla informeDestino);
        int CopiarInterruptoresDeAgentes(InformeFalla informeDestino);
        bool SolapaTiempos(OperacionInterruptores opInterrup);

        void Refrescar(OperacionInterruptores interruptor, DataRow row);
    }
}