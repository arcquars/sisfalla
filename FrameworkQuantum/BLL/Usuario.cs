using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace CNDC.BLL
{
    [Serializable]
    public class Usuario : ObjetoDeNegocio
    {
        public const string C_LOGIN = "LOGIN";
        public const string C_CELULAR = "CELULAR";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_NUM_PERSONA = "NUM_PERSONA";
        public const string C_PIN = "PIN";
        public const string C_D_COD_ESTADO_AUT = "D_COD_ESTADO_AUT";
        public const string C_PK_COD_USUARIO = "PK_COD_USUARIO";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_NOMBRE = "NOMBRE";

        public string Login { get; set; }
        public string Celular { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public string Pin { get; set; }
        public string DCodEstadoAut { get; set; }
        public decimal PkCodUsuario { get; set; }
        public long SincVer { get; set; }
        public string Nombre { get; set; }

        public Usuario() { }

        public Usuario(DataRow dataRow)
        {
            Login = GetValor<string>(dataRow[C_LOGIN]);
            Celular = GetValor<string>(dataRow[C_CELULAR]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Pin = GetValor<string>(dataRow[C_PIN]);
            DCodEstadoAut = GetValor<string>(dataRow[C_D_COD_ESTADO_AUT]);
            PkCodUsuario = GetValor<decimal>(dataRow[C_PK_COD_USUARIO]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
        }
    }

    public interface IUsuarioMgr
    {
        void Guardar(Usuario obj);
        DataTable GetTabla();
        BindingList<Usuario> GetLista();
    }
}
