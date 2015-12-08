using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace CNDC.BLL
{
    [Serializable]
    public class Persona : ObjetoDeNegocio , IComparable<Persona>
    {
        public const string C_PK_COD_PERSONA = "PK_COD_PERSONA";
        public const string C_NOM_COD_AGENTE = "NOM_COD_AGENTE";
        public const string C_NOM_PERSONA = "NOM_PERSONA";
        public const string C_SIGLA = "SIGLA";
        public const string C_D_COD_TIPO_PERSONA = "D_COD_TIPO_PERSONA";
        public const string C_DIRECCION = "DIRECCION";
        public const string C_TELEFONO = "TELEFONO";
        public const string C_IDENTIFICACION = "IDENTIFICACION";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public long PkCodPersona { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public long DCodTipoPersona { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }
        public string Nomcodagente { get; set; }
        public Persona()
        {

        }

        public Persona(DataRow dataRow)
        {
            PkCodPersona = (long)dataRow[C_PK_COD_PERSONA];
            Nombre = GetValor<string>(dataRow[C_NOM_PERSONA]);
            Sigla = GetValor<string>(dataRow[C_SIGLA]);
            DCodTipoPersona = GetValor<long>(dataRow[C_D_COD_TIPO_PERSONA]);
            Direccion = GetValor<string>(dataRow[C_DIRECCION]);
            Telefono = GetValor<string>(dataRow[C_TELEFONO]);
            Identificacion = GetValor<string>(dataRow[C_IDENTIFICACION]);
            DCodEstado = dataRow[C_D_COD_ESTADO].ToString();
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            if (dataRow.Table.Columns.Contains(C_NOM_COD_AGENTE))
            {
                Nomcodagente = GetValor<string>(dataRow[C_NOM_COD_AGENTE]);
            }
        }

        public override void Leer(DataRow dataRow)
        {
            PkCodPersona = (long)dataRow[C_PK_COD_PERSONA];
            Nombre = GetValor<string>(dataRow[C_NOM_PERSONA]);
            Sigla = GetValor<string>(dataRow[C_SIGLA]);
            DCodTipoPersona = GetValor<long>(dataRow[C_D_COD_TIPO_PERSONA]);
            Direccion = GetValor<string>(dataRow[C_DIRECCION]);
            Telefono = GetValor<string>(dataRow[C_TELEFONO]);
            Identificacion = GetValor<string>(dataRow[C_IDENTIFICACION]);
            DCodEstado = dataRow[C_D_COD_ESTADO].ToString();
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public int CompareTo(Persona other)
        {
            int rtn = 0; 
           long diff = this.PkCodPersona - other.PkCodPersona;

            if  (diff ==0)
            {
                rtn  = 0 ;
            } else 
            {if (diff > 0)
            {
                rtn = 1;
            }
            else
            {
                rtn = -1 ;
            }
            }

            return ( rtn );
        }

        public override bool Equals(object obj)
        {
            Persona p = (Persona)obj;
            return (this.PkCodPersona == p.PkCodPersona);
        }
    }

    public interface IPersonaMgr
    {
        void Guardar(Persona p);
        DataTable GetTabla();
        Persona GetAgente(long IdPersona);
        Persona GetPersona(long IdPersona);
        DataTable GetAgentes();
        DataTable GetAgentes(long codPersona);
        BindingList<Persona> GetListaAgentes();

        Persona GetPorPkCodPersona(long p);
    }
}
