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
    public class Notificacion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_NOTIFICACION";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_COD_PERSONA = "PK_COD_PERSONA";
        public const string C_D_COD_ESTADO_NOTIFICACION = "D_COD_ESTADO_NOTIFICACION";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";

        public int PkCodFalla { get; set; }
        public long PkCodPersona { get; set; }
        public long DCodEstadoNotificacion { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }

        public Notificacion() { }

        public Notificacion(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkCodPersona = GetValor<long>(dataRow[C_PK_COD_PERSONA]);
            DCodEstadoNotificacion = GetValor<long>(dataRow[C_D_COD_ESTADO_NOTIFICACION]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[C_PK_COD_PERSONA] = PkCodPersona;
            dataRow[C_D_COD_ESTADO_NOTIFICACION] = DCodEstadoNotificacion;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_SINC_VER] = SincVer;
        }
        public void llenarNotificacion(DataRow dataRow)
        {
            PkCodFalla = Parse<int>(dataRow[C_PK_COD_FALLA].ToString());
            PkCodPersona = Parse<long>(dataRow[C_PK_COD_PERSONA].ToString());
            DCodEstadoNotificacion = Parse<long>(dataRow[C_D_COD_ESTADO_NOTIFICACION].ToString());
            DCodEstado = dataRow[C_D_COD_ESTADO].ToString();
            SecLog = Parse<long>(dataRow[C_SEC_LOG].ToString());
            SincVer = Parse<long>(dataRow[C_SINC_VER].ToString());
        }
    }

    public interface INotificacionMgr
    {
        void Guardar(Notificacion obj);
        DataTable GetTabla();
        BindingList<Notificacion> GetLista();
        DataTable GetRegistros(string codigo);
        bool Existe(DataRow row, DataTable tablaLocal);
        BindingList<Notificacion> GetAgentesInvolucrados(int codFalla);
        bool Existe(int numFalla, long codPersona);

        void BorrarNotificacionesIncorrectas(int numFalla, string codPersonasCorrectas);

        void RevertirNotificacion(int p, string codAgentesSeparadosPorComa);
    }

    public enum ResultadoEnvioEmail
    {
        Enviado,
        NoEnviado,
        EnviadoConError,
        EnvioCanceladoPorUs
    }
}