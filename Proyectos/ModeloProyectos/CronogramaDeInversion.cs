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
    public class CronogramaDeInversion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_CRONOGRAMA_INVERSION";

        public const string C_PK_CRONOGRAMA_INVERSION = "PK_CRONOGRAMA_INVERSION";
        public const string C_FK_DATO_ECONOMICO = "FK_DATO_ECONOMICO";
        public const string C_ANIO = "ANIO";
        public const string C_MONTO = "MONTO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_ANIO_REF = "ANIO_REF";
        public const string C_HISTORICO = "HISTORICO";

        public long PkCronogramaInversion { get; set; }
        public long FkDatoEconomico { get; set; }
        public string Anio { get; set; }
        public double Monto { get; set; }
        public long SecLog { get; set; }
        public long AnioRef { get; set; }
        public short Historico { get; set; }

        public CronogramaDeInversion() { }

        public CronogramaDeInversion(DataRow dataRow)
        {
            PkCronogramaInversion = GetValor<long>(dataRow[C_PK_CRONOGRAMA_INVERSION]);
            FkDatoEconomico = GetValor<long>(dataRow[C_FK_DATO_ECONOMICO]);
            Anio = GetValor<string>(dataRow[C_ANIO]);
            Monto = GetValor<double>(dataRow[C_MONTO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            AnioRef = GetValor<long>(dataRow[C_ANIO_REF]);
            Historico = GetValor<short>(dataRow[C_HISTORICO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_CRONOGRAMA_INVERSION] = PkCronogramaInversion;
            dataRow[C_FK_DATO_ECONOMICO] = FkDatoEconomico;
            dataRow[C_ANIO] = Anio;
            dataRow[C_MONTO] = Monto;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_ANIO_REF] = AnioRef;
            dataRow[C_HISTORICO] = Historico;
        }

        public override void Leer(DataRow dataRow)
        {
            PkCronogramaInversion = GetValor<long>(dataRow[C_PK_CRONOGRAMA_INVERSION]);
            FkDatoEconomico = GetValor<long>(dataRow[C_FK_DATO_ECONOMICO]);
            Anio = GetValor<string>(dataRow[C_ANIO]);
            Monto = GetValor<double>(dataRow[C_MONTO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            AnioRef = GetValor<long>(dataRow[C_ANIO_REF]);
            Historico = GetValor<short>(dataRow[C_HISTORICO]);
        }
    }

    public interface ICronogramaDeInversionMgr
    {
        void Guardar(CronogramaDeInversion obj);
        DataTable GetTabla();
        BindingList<CronogramaDeInversion> GetLista();
    }
}
