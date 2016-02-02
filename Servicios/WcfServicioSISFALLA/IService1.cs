using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModeloSisFalla;
using System.Data;

namespace WcfServicioSISFALLA
{
    [ServiceContract]
    public interface IServicioSISFALLA
    {
        /*
         * @jjla: 26/Marzo/2014 -> Informes de falla sincronización
         */
        [OperationContract]
        byte[] GetInformesFallaSincronizacion(string token);

        [OperationContract]
        byte[] GetTabla(string token, string nombreTabla);
 
        [OperationContract]
        byte[] GetMaxSincVer(string token);
        
        [OperationContract]
        byte[] TablesColumns(string token);

        [OperationContract]
        byte[] GetRegistrosSincronizacion(string token, string tabla, decimal versionCliente, long pkCodPersona);

        [OperationContract]
        bool Subir(string token, byte[] dataSet, string modulo);

        [OperationContract]
        bool ConfirmarSinc(string token, long codPersona, string nombreTabla, byte[] tabla);

        [OperationContract]
        string GetStrFechaHora(string token);

        [OperationContract]
        byte[] GetTablaTest(string token, string nombreTabla);

        [OperationContract]
        long IniciarSesion(string token);

        [OperationContract]
        bool ValidarOperacion(long EstadoOperacion, int pk_cod_falla, long PkDCodTipoinforme, long pkcodpersona);

        [OperationContract]
        void CerrarSesion(string token);

        [OperationContract]
        byte[] GetInforme(string token,int codFalla, long origen, long tipo);

        [OperationContract]
        bool TestConexion();

        [OperationContract]
        bool UpdateRegFallaFecInicio(string token, long codRegFalla, DateTime fecInicio);

    }
}
