using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloComponentes
{
    public class Componente:ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_AC_COMPONENTE";

        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_NOMBRE_COMPONENTE = "NOMBRE_COMPONENTE";
        //// CAMBIADO POR QUERY DE jj
        //public const string C_DESCRIPCION = "DESCRIPCION_COMPONENTE";
        public const string C_DESCRIPCION = "DESC_COMP";
        public const string C_D_TIPO_COMPONENTE = "D_TIPO_COMPONENTE";
        //public const string C_P_TIPO_COMPONENTE = "P_TIPO_COMPONENTE";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA";
        public const string C_PROPIETARIO = "PROPIETARIO";
        public const string C_PK_COD_NODO_ORIGEN = "PK_COD_NODO_ORIGEN";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_CODIGO_COMPONENTE = "CODIGO_COMPONENTE";
        public const string C_PK_COD_NODO_DESTINO = "PK_COD_NODO_DESTINO";
        public const string C_SINC_VER = "SINC_VER";
        
       // public const string C_D_EQUIVALENCIA = "D_EQUIVALENCIA";

        public decimal PkCodComponente { get; set; }
        public string NombreComponente { get; set; }
        public string Descripcion { get; set; }
        public long DTipoComponente { get; set; }
        //public long PTipoComponente {get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public long Propietario { get; set; }
        public long PkCodNodoOrigen { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public string CodigoComponente { get; set; }
        public long PkCodNodoDestino { get; set; }
        public long SincVer { get; set; }
        public bool TieneFechaSalida { get; set; }
        
       // public long DEquivalencia {get; set; }

        public Componente()
        { }
        public Componente(System.Windows.Forms.DataGridViewRow row)
        {
            PkCodComponente = (decimal)row.Cells["pk_cmp"].Value;
            CodigoComponente = (string)row.Cells["id_comp"].Value;
            NombreComponente = (string)row.Cells["cod_comp"].Value;
            
            DTipoComponente = (long)(decimal)row.Cells["tipo_comp"].Value;
            Propietario = Convert.ToInt64((decimal)row.Cells["pk_agente"].Value);
            Descripcion = (string)row.Cells["descripcion"].Value;
            FechaIngreso = (DateTime)row.Cells["fecha_ini"].Value;
           
            if (row.Cells["pk_cod_nodo_origen"].Value == System.DBNull.Value)
            {
                PkCodNodoOrigen = -1;
            }
            else
            {
                PkCodNodoOrigen = Convert.ToInt64((decimal)row.Cells["pk_cod_nodo_origen"].Value);
            }

            if (row.Cells["pk_cod_nodo_destino"].Value == System.DBNull.Value)
            {
                 PkCodNodoDestino  = -1;
            }
            else
            {
                PkCodNodoDestino = Convert.ToInt64((decimal)row.Cells["pk_cod_nodo_destino"].Value);
            }

             
            if (row.Cells["fecha_baja"].Value == System.DBNull.Value)
            {
                TieneFechaSalida = false;
            }
            else
            {
                TieneFechaSalida = true;
                FechaSalida = (DateTime)row.Cells["fecha_baja"].Value;
            }
            
        }
        public Componente(DataRow row)
        {
            PkCodComponente = (decimal)row[C_PK_COD_COMPONENTE];
            NombreComponente = (string)row[C_NOMBRE_COMPONENTE];
            Descripcion = (string)row[C_DESCRIPCION];
            DTipoComponente = (long)row[C_D_TIPO_COMPONENTE];
            //PTipoComponente = (long)row[C_P_TIPO_COMPONENTE];
            FechaIngreso = ObjetoDeNegocio.GetValor<DateTime>(row[C_FECHA_INGRESO]);
            FechaSalida = ObjetoDeNegocio.GetValor<DateTime>(row[C_FECHA_SALIDA]);
            Propietario = (long)row[C_PROPIETARIO];
           // PkCodNodoOrigen = ObjetoDeNegocio.GetValor<long>(row[C_PK_COD_NODO_ORIGEN]);
           // DCodEstado = (string)row[C_D_COD_ESTADO];
            //SecLog = (long)row[C_SEC_LOG];
            CodigoComponente = (string) row[C_CODIGO_COMPONENTE];
           // PkCodNodoDestino=ObjetoDeNegocio.GetValor<long>(row[C_PK_COD_NODO_DESTINO]);
            //SincVer = (long)row[C_SINC_VER];
           // DEquivalencia = ObjetoDeNegocio.GetValor<long>(row[C_D_EQUIVALENCIA]);
        }

        // **** De la version disponible en el ModeloSisfalla
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
        DataTable GetComponenteCompleto(long p);
        bool IdUniversalExiste(string idUniversal);
        DataTable GetComponentesAbm();
        DataTable GetNodos();
        DataTable GetTipoComponentes();
        long Guardar(ModeloComponentes.Componente c);
        bool Eliminar(ModeloComponentes.Componente c);
        bool InsertarNodo(ModeloComponentes.Componente c, long pkCodNodo, long TipoRelacion);
     
    }
    
}
