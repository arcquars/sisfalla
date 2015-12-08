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
    public class ReduccionEmisores : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_REDUCCION_EMISORES";

        public const string C_PK_REDUCCION_EMISORES = "PK_REDUCCION_EMISORES";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_REDUCCION_CO2 = "REDUCCION_CO2";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkReduccionEmisores { get; set; }
        public long FkProyecto { get; set; }
        public double ReduccionCo2 { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public ReduccionEmisores() { }

        public ReduccionEmisores(DataRow dataRow)
        {
            PkReduccionEmisores = GetValor<long>(dataRow[C_PK_REDUCCION_EMISORES]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ReduccionCo2 = GetValor<double>(dataRow[C_REDUCCION_CO2]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_REDUCCION_EMISORES] = PkReduccionEmisores;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_REDUCCION_CO2] = ReduccionCo2;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkReduccionEmisores = GetValor<long>(dataRow[C_PK_REDUCCION_EMISORES]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            ReduccionCo2 = GetValor<double>(dataRow[C_REDUCCION_CO2]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IReduccionEmisoresMgr
    {
        void Guardar(ReduccionEmisores obj);
        DataTable GetTabla();
        BindingList<ReduccionEmisores> GetLista();
    }
}
