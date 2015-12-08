using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloSisFalla
{
    public class RContacto : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_AP_RCONTACTO";

        public const string C_NOMBRE = Persona.C_NOM_PERSONA;//Campo tomado de la tabla Persona

        public const string C_PK_COD_EMPRESA = "PK_COD_EMPRESA";
        public const string C_PK_COD_CONTACTO = "PK_COD_CONTACTO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_CARGO = "CARGO";
        public const string C_CELULAR = "CELULAR";
        public const string C_EMAIL = "EMAIL";
        public const string C_EMAIL2 = "EMAIL2";
        public const string C_FEC_SALIDA = "FEC_SALIDA";
        public const string C_FEC_INGRESO = "FEC_INGRESO";
        public const string C_FK_COD_MODULO = "FK_COD_MODULO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public string Nombre { get; set; }//Campo tomado de la tabla Persona

        public long PkCodEmpresa { get; set; }
        public long PkCodContacto { get; set; }
        public string DCodEstado { get; set; }
        public string Cargo { get; set; }
        public string Celular { get; set; }
        public string EMail { get; set; }
        public string EMail2 { get; set; }
        public DateTime FecSalida { get; set; }
        public DateTime FecIngreso { get; set; }
        public long FkCodModulo { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }

        public RContacto()
        {

        }

        public RContacto(DataRow dataRow)
        {
            if (dataRow.Table.Columns.Contains(C_NOMBRE))
            {
                Nombre = (string)dataRow[C_NOMBRE];
            }
            PkCodEmpresa = (long)dataRow[C_PK_COD_EMPRESA];
            PkCodContacto = (long)dataRow[C_PK_COD_CONTACTO];
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            Cargo = GetValor<string>(dataRow[C_CARGO]);
            Celular = GetValor<string>(dataRow[C_CELULAR]);
            EMail = GetValor<string>(dataRow[C_EMAIL]);
            EMail2 = GetValor<string>(dataRow[C_EMAIL2]);
            FecIngreso = GetValor<DateTime>(dataRow[C_FEC_INGRESO]);
            FecSalida = GetValor<DateTime>(dataRow[C_FEC_SALIDA]);
            FkCodModulo = GetValor<long>(dataRow[C_FK_COD_MODULO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public string NombreEMail
        { get { return string.Format("{0}({1})", Nombre, EMail); } }
    }

    public interface IRContactoMgr
    {
        void Guardar(RContacto p);
        DataTable GetTabla();
        BindingList<RContacto> GetLista();
        DataTable GetRegistros(long codFalla, long codPersonaImplicado);
        List<string> GetEmails(long codFalla, long codPersonaImplicado);

        List<string> GetEmailsDeContactos(BindingList<Persona> agentesNotificar);
        List<string> GetEmailsDeContactos(string codPersonasSeparadosPorComa);
    }
}
