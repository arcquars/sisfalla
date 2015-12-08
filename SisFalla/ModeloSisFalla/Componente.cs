using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;

namespace ModeloSisFalla
{
    public class Componente
    {
        public const string NOMBRE_TABLA = "F_AC_COMPONENTE";

        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_NOMBRE_COMPONENTE = "NOMBRE_COMPONENTE";
        public const string C_DESCRIPCION = "DESCRIPCION_COMPONENTE";
        public const string C_D_TIPO_COMPONENTE = "D_TIPO_COMPONENTE";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA";
        public const string C_PROPIETARIO = "PROPIETARIO";
        public const string C_PK_COD_NODO_ORIGEN = "PK_COD_NODO_ORIGEN";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public decimal PkCodComponente { get; set; }
        public string NombreComponente { get; set; }
        public string Descripcion { get; set; }
        public long DTipoComponente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public long Propietario { get; set; }
        public long PkCodNodo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }

        public Componente()
        {
        }

        public Componente(decimal PkComponente)
        { 
        }

        public Componente(DataRow row)
        {
            PkCodComponente = (decimal)row[C_PK_COD_COMPONENTE];
            NombreComponente = (string)row[C_NOMBRE_COMPONENTE];
            Descripcion = (string)row[C_DESCRIPCION];
            DTipoComponente = (long)row[C_D_TIPO_COMPONENTE];
            FechaIngreso = (DateTime)row[C_FECHA_INGRESO];
            FechaSalida = ObjetoDeNegocio.GetValor<DateTime>(row[C_FECHA_SALIDA]);
            Propietario = (long)row[C_PROPIETARIO];
            PkCodNodo = (long)row[C_PK_COD_NODO_ORIGEN];
            DCodEstado = (string)row[C_D_COD_ESTADO];
            SecLog = (long)row[C_SEC_LOG];
            SincVer = (long)row[C_SINC_VER];
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", NombreComponente, Descripcion);
        }
    }

    public interface IComponenteMgr
    {
        DataTable GetTabla();
        DataTable GetComponenteCompleto();
        Componente GetComponente(decimal pkCodComponente);
    }
}
