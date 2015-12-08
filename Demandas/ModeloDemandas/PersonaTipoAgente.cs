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
    public class PersonaTipoAgente : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_R_PERSONA_TIPO";

        public const string C_PK_PERSONA_TIPO = "PK_PERSONA_TIPO";
        public const string C_D_COD_TIPO_PERSONA = "D_COD_TIPO_PERSONA";
        public const string C_FK_PERSONSA = "FK_PERSONSA";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkPersonaTipo { get; set; }
        public long DCodTipoPersona { get; set; }
        public long FkPersonsa { get; set; }
        public long SecLog { get; set; }

        public PersonaTipoAgente() { }

        public PersonaTipoAgente(DataRow dataRow)
        {
            PkPersonaTipo = GetValor<long>(dataRow[C_PK_PERSONA_TIPO]);
            DCodTipoPersona = GetValor<long>(dataRow[C_D_COD_TIPO_PERSONA]);
            FkPersonsa = GetValor<long>(dataRow[C_FK_PERSONSA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_PERSONA_TIPO] = PkPersonaTipo;
            dataRow[C_D_COD_TIPO_PERSONA] = DCodTipoPersona;
            dataRow[C_FK_PERSONSA] = FkPersonsa;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public override void Leer(DataRow dataRow)
        {
            PkPersonaTipo = GetValor<long>(dataRow[C_PK_PERSONA_TIPO]);
            DCodTipoPersona = GetValor<long>(dataRow[C_D_COD_TIPO_PERSONA]);
            FkPersonsa = GetValor<long>(dataRow[C_FK_PERSONSA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }
    }

    public interface IPersonaTipoAgenteMgr
    {
        void Guardar(PersonaTipoAgente obj);
        DataTable GetTabla();
        BindingList<PersonaTipoAgente> GetLista();
    }
}
