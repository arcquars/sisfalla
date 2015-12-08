using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloDemandas
{
    [Serializable]
    public class NodosReales : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_AC_NODO";

        public const string C_PK_COD_NODO = "PK_COD_NODO";
        public const string C_PK_NIVEL_TENSION = "PK_NIVEL_TENSION";
        public const string C_D_COD_AREA = "D_COD_AREA";
        public const string C_SIGLA_NODO = "SIGLA_NODO";
        public const string C_NOMBRE_NODO = "NOMBRE_NODO";
        public const string C_DESCRIPCION_NODO = "DESCRIPCION_NODO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA";

        public long PkCodNodo { get; set; }
        public float PkNivelTension { get; set; }
        public long DCodArea { get; set; }
        public string SiglaNodo { get; set; }
        public string NombreNodo { get; set; }
        public string DescripcionNodo { get; set; }
        public string DCodEstado { get; set; }
        public decimal SecLog { get; set; }
        public long SincVer { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }

        public NodosReales() { }

        public NodosReales(DataRow dataRow)
        {
            PkCodNodo = GetValor<long>(dataRow[C_PK_COD_NODO]);
            PkNivelTension = GetValor<float>(dataRow[C_PK_NIVEL_TENSION]);
            DCodArea = GetValor<long>(dataRow[C_D_COD_AREA]);
            SiglaNodo = GetValor<string>(dataRow[C_SIGLA_NODO]);
            NombreNodo = GetValor<string>(dataRow[C_NOMBRE_NODO]);
            DescripcionNodo = GetValor<string>(dataRow[C_DESCRIPCION_NODO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<decimal>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INGRESO]);
            FechaSalida = GetValor<DateTime>(dataRow[C_FECHA_SALIDA]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_NODO] = PkCodNodo;
            dataRow[C_PK_NIVEL_TENSION] = PkNivelTension;
            dataRow[C_D_COD_AREA] = DCodArea;
            dataRow[C_SIGLA_NODO] = SiglaNodo;
            dataRow[C_NOMBRE_NODO] = NombreNodo;
            dataRow[C_DESCRIPCION_NODO] = DescripcionNodo;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_SINC_VER] = SincVer;
            dataRow[C_FECHA_INGRESO] = FechaIngreso;
            dataRow[C_FECHA_SALIDA] = FechaSalida;
        }

        public override void Leer(DataRow dataRow)
        {
            PkCodNodo = GetValor<long>(dataRow[C_PK_COD_NODO]);
            PkNivelTension = GetValor<float>(dataRow[C_PK_NIVEL_TENSION]);
            DCodArea = GetValor<long>(dataRow[C_D_COD_AREA]);
            SiglaNodo = GetValor<string>(dataRow[C_SIGLA_NODO]);
            NombreNodo = GetValor<string>(dataRow[C_NOMBRE_NODO]);
            DescripcionNodo = GetValor<string>(dataRow[C_DESCRIPCION_NODO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<decimal>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INGRESO]);
            FechaSalida = GetValor<DateTime>(dataRow[C_FECHA_SALIDA]);
        }

        public override string ToString()
        {
            return NombreNodo + " - " + SiglaNodo;
        }
    }

    public interface INodosRealesMgr
    {
        void Guardar(NodosReales obj);
        DataTable GetTabla();
        BindingList<NodosReales> GetLista();
    }
}
